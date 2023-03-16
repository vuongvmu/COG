using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PMAlign;
using JAS.Controls.Display;
using static COG.Main;
using Cognex.VisionPro.ImageFile;
using COG.Class;
using static COG.InspectionItem;
using JASUtility;

namespace COG.Controls
{
    public partial class CtrlTeachMark : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        private CtrlTeachROIJog _roiJogControl = null;

        public enum eMoveDirection
        {
            Up,
            Down,
            Left,
            Right,
        }

        public enum eSizeDirection
        {
            IncreaseUpDown,
            DecreaseUpDown,
            IncreaseLeftRight,
            DecreaseLeftRight,
        }

        
        private CogDisplay _markDisplay = null;


        private int _tabNo = 0;
        private AlignTagData[] _alignTagData = new AlignTagData[DEFINE.TAB_NUM];
        private AkkonTagData[] _akkonTagData = new AkkonTagData[DEFINE.TAB_NUM];

        //private PatternMatchParameter[,] _patternParam = new PatternMatchParameter[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];

        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        private List<CogPMAlignTool[,]> _markToolList = new List<CogPMAlignTool[,]>();

        private PatternMatchParameter _patternParam = new PatternMatchParameter();

        private List<PatternMatchParameter[,]> _patternParamList = new List<PatternMatchParameter[,]>();
        private eMarkTeachStep _markTeachStep = eMarkTeachStep.None;
        public enum eMarkTeachStep
        {
            None,
            SetMark,
            SetROI,
        }

        private eMarkIndex _markIndex = eMarkIndex.MainMark;
        private eMarkPosition _markPosition = eMarkPosition.Left;
#if CGMS
        private eTargetObject _targetObject = eTargetObject.BackLight;
#endif
#if ATT
        private eTargetObject _targetObject = eTargetObject.FPC;
#endif

        private eStageNo _stageNo = eStageNo.Inspection1;
        private eCameraNo _camNo = eCameraNo.PreAlign;

        public CtrlTeachMark(eStageNo stageNo, eCameraNo camNo)
        {
            InitializeComponent();

            SetUnitIndex(stageNo, camNo);
        }

        private void SetUnitIndex(eStageNo stageNo, eCameraNo camNo)
        {
            _stageNo = stageNo;
            _camNo = camNo;
        }

        private void CtrlTeachMark_Load(object sender, EventArgs e)
        {
#if !SIMUL
            GetMarkParameter();
            CreateTeachTool();
#endif
            AddControl();
            InitializeUI();

            RefreshMarkDisplay();
        }

        private void GetMarkParameter()
        {
            foreach (eMarkIndex markIndex in Enum.GetValues(typeof(eMarkIndex)))
            {
                PatternMatchParameter[,] patternMatchArray = new PatternMatchParameter[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];

                foreach (eTargetObject targetObject in Enum.GetValues(typeof(eTargetObject)))
                {
                    foreach (eMarkPosition markPosition in Enum.GetValues(typeof(eMarkPosition)))
                        patternMatchArray[(int)targetObject, (int)markPosition] = Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].PatternList[(int)markIndex][(int)targetObject, (int)markPosition].Copy();
                }

                _patternParamList.Add(patternMatchArray);
            }
        }

        private void CreateTeachTool()
        {
            foreach (eMarkIndex markIndex in Enum.GetValues(typeof(eMarkIndex)))
            {
                CogPMAlignTool[,] cogPMAlignToolArray = new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];

                foreach (eTargetObject targetObject in Enum.GetValues(typeof(eTargetObject)))
                {
                    foreach (eMarkPosition markPosition in Enum.GetValues(typeof(eMarkPosition)))
                        cogPMAlignToolArray[(int)targetObject, (int)markPosition] = _patternParamList[(int)markIndex][(int)targetObject, (int)markPosition].CogPMAlignTool;
                }

                _markToolList.Add(cogPMAlignToolArray);
            }






            //_markToolList = new List<CogPMAlignTool[,]>();

            //for (int markIndex = 0; markIndex < Enum.GetValues(typeof(eMarkIndex)).Length; markIndex++)
            //{
            //    _markToolList.Add(new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length]);

            //    for (int targetIndex = 0; targetIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetIndex++)
            //    {
            //        for (int positionIndex = 0; positionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; positionIndex++)
            //        {
            //            if (_patternParamList[markIndex][targetIndex, positionIndex].CogPMAlignTool.Pattern.Trained)
            //            {
            //                _markToolList[markIndex][targetIndex, positionIndex] = _patternParamList[markIndex][targetIndex, positionIndex].CogPMAlignTool;
            //            }
            //        }
            //    }
            //}
        }

        private void AddControl()
        {
            // Display
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;

            // Mark Display
            _markDisplay = new CogDisplay();
            _markDisplay = cogMarkDisplay;
            _markDisplay.Fit();

            //cogDisplayThumbnail.Image = Main.vision.CogCamBuf[_CamNo];

            // ROI Jog Control
            _roiJogControl = new CtrlTeachROIJog();
            this.pnlROIJog.Controls.Add(_roiJogControl);
            _roiJogControl.Dock = DockStyle.Fill;
            pnlROIJog.Visible = false;
            _roiJogControl.SendEventHandler += new CtrlTeachROIJog.SendClickEventDelegate(ReceiveClickEvent);
            _roiJogControl.tlpSkew.Enabled = false;
        }

        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            if (Main.machine.UseMarkWhenAlign)
                btnAlignTest.Enabled = true;
            else
                btnAlignTest.Enabled = false;

#if CGMS
            rdoFPC.Text = "BACKLIGHT";
            rdoPanel.Text = "COAXIAL";
#endif
#if ATT
            rdoFPC.Text = "FPC";
            rdoPanel.Text = "PANEL";
#endif
            rdoMarkLeft.Checked = true;
            rdoFPC.Checked = true;

            btnMainMark.BackColor = Color.LimeGreen;
        }

#region ROI Jog
        private void ReceiveClickEvent(object sender)
        {
            Button button = sender as Button;

            if (button.Name.ToString().Contains("MoveUp"))
                MoveROIJog(eMoveDirection.Up);

            if (button.Name.ToString().Contains("MoveDown"))
                MoveROIJog(eMoveDirection.Down);

            if (button.Name.ToString().Contains("MoveLeft"))
                MoveROIJog(eMoveDirection.Left);

            if (button.Name.ToString().Contains("MoveRight"))
                MoveROIJog(eMoveDirection.Right);

            if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
                SizeROIJog(eSizeDirection.IncreaseUpDown);

            if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
                SizeROIJog(eSizeDirection.DecreaseUpDown);

            if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
                SizeROIJog(eSizeDirection.IncreaseLeftRight);

            if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
                SizeROIJog(eSizeDirection.DecreaseLeftRight);
        }

        private void MoveROIJog(eMoveDirection moveDirection)
        {
            ClearGraphic();

            int movePixel = Convert.ToInt32(_roiJogControl.lblJogScale.Text);
            int jogMoveX = 0;
            int jogMoveY = 0;

            switch (moveDirection)
            {
                case eMoveDirection.Up:
                    jogMoveX = 0;
                    jogMoveY = movePixel * (-1);
                    break;

                case eMoveDirection.Down:
                    jogMoveX = 0;
                    jogMoveY = movePixel * (1);
                    break;

                case eMoveDirection.Left:
                    jogMoveX = movePixel * (-1);
                    jogMoveY = 0;
                    break;

                case eMoveDirection.Right:
                    jogMoveX = movePixel * (1);
                    jogMoveY = 0;
                    break;

                default:
                    break;
            }

            if (_roiJogControl.rdoMark.Checked)
            {
                CogRectangle cogRect = new CogRectangle();

                if (_markTeachStep == eMarkTeachStep.SetMark)
                {
                    cogRect = (CogRectangle)_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainRegion;

                    cogRect.X += jogMoveX;
                    cogRect.Y += jogMoveY;

                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainRegion = cogRect;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                        | CogPMAlignCurrentRecordConstants.PatternOrigin;
                }
                else if (_markTeachStep == eMarkTeachStep.SetROI)
                {
                    cogRect = (CogRectangle)_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion;

                    cogRect.X += jogMoveX;
                    cogRect.Y += jogMoveY;

                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion = cogRect;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
                }
                else { }
            }
            else
            {
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationX += jogMoveX;
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationY += jogMoveY;
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                        | CogPMAlignCurrentRecordConstants.PatternOrigin;
            }

            Display.SetGraphics(_teachingDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());
        }

        private void SizeROIJog(eSizeDirection sizeDirection)
        {
            ClearGraphic();

            int movePixel = Convert.ToInt32(_roiJogControl.lblJogScale.Text);
            int jogSizeX = 0;
            int jogSizeY = 0;

            switch (sizeDirection)
            {
                case eSizeDirection.IncreaseUpDown:
                    jogSizeX = 0;
                    jogSizeY = movePixel * (1);
                    break;

                case eSizeDirection.DecreaseUpDown:
                    jogSizeX = 0;
                    jogSizeY = movePixel * (-1);
                    break;

                case eSizeDirection.IncreaseLeftRight:
                    jogSizeX = movePixel * (1);
                    jogSizeY = 0;
                    break;

                case eSizeDirection.DecreaseLeftRight:
                    jogSizeX = movePixel * (-1);
                    jogSizeY = 0;
                    break;

                default:
                    break;
            }

            if (_roiJogControl.rdoMark.Checked)
            {
                CogRectangle cogRect = new CogRectangle();

                if (_markTeachStep == eMarkTeachStep.SetMark)
                {
                    cogRect = (CogRectangle)_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainRegion;

                    cogRect.Width += jogSizeX;
                    cogRect.Height += jogSizeY;

                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainRegion = cogRect;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                        | CogPMAlignCurrentRecordConstants.PatternOrigin;
                }
                else if (_markTeachStep == eMarkTeachStep.SetROI)
                {
                    cogRect = (CogRectangle)_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion;

                    cogRect.Width += jogSizeX;
                    cogRect.Height += jogSizeY;

                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion = cogRect;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
                }
                else { }
            }
            else
            {
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationX += jogSizeX;
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationY += jogSizeY;
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                        | CogPMAlignCurrentRecordConstants.PatternOrigin;
            }

            Display.SetGraphics(_teachingDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());
        }

        private void chkShowROIJog_CheckedChanged(object sender, EventArgs e)
        {
            ShowROIJog(sender);
        }

        private void ShowROIJog(object sender)
        {
            if (chkShowROIJog.Checked)
            {
                pnlROIJog.Visible = true;
                chkShowROIJog.BackColor = Color.LimeGreen;
            }
            else
            {
                pnlROIJog.Visible = false;
                chkShowROIJog.BackColor = Color.DarkGray;
            }
        }
#endregion

        private void ClearGraphic()
        {
            _teachingDisplay.StaticGraphics.Clear();
            _teachingDisplay.InteractiveGraphics.Clear();
        }

        private void rdoSetMarkPosition_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectMarkPosition(sender);
            RefreshMarkDisplay();
            ChangeMainDisplayFocus(sender);
        }

        private void SetSelectMarkPosition(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("left"))
                    SetMarkPosition(eMarkPosition.Left);
                else
                    SetMarkPosition(eMarkPosition.Right);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetMarkPosition(eMarkPosition markPosition)
        {
            _markPosition = markPosition;
        }

        private void rdoSetTargetObject_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectTargetObject(sender);

            RadioButton rdo = sender as RadioButton;

            if (!rdo.Checked)
                return;

            RefreshMarkDisplay();
        }

        private void SetSelectTargetObject(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
#if CGMS
                if (btn.Text.ToLower().Contains("backlight"))
                    SetTargetObject(eTargetObject.BackLight);
                else
                    SetTargetObject(eTargetObject.Coaxial);
#endif
#if ATT
                if (btn.Text.ToLower().Contains("fpc"))
                    SetTargetObject(eTargetObject.FPC);
                else
                    SetTargetObject(eTargetObject.PANEL);
#endif
                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetTargetObject(eTargetObject targetObject)
        {
            _targetObject = targetObject;
        }

        private void btnSetMarkIndex_Click(object sender, EventArgs e)
        {
            SetSelectMarkIndex(sender);
            RefreshMarkDisplay();
            SetROI();
        }

        private void SetSelectMarkIndex(object sender)
        {
            Button btn = sender as Button;

            int markIndex = Convert.ToInt32(btn.Tag);

            SetMarkIndex((eMarkIndex)markIndex);

            // Main Mark
            if (_markIndex == eMarkIndex.MainMark)
                btn.BackColor = Color.LimeGreen;
            else
                btn.BackColor = Color.DarkGray;

            // SubMark
            foreach (var control in tlpSubMarkIndex.Controls)
            {
                if (control.GetType().Name.ToLower() == "button")
                {
                    Button controlButton = control as Button;

                    if (controlButton.Name.Contains(_markIndex.ToString()))
                    {
                        btnMainMark.BackColor = Color.DarkGray;
                        controlButton.BackColor = Color.LimeGreen;
                    }
                    else
                        controlButton.BackColor = Color.DarkGray;
                }
            }
        }

        private void SetMarkIndex(eMarkIndex markIndex)
        {
            _markIndex = markIndex;
        }

        private void SetSelectButtonColor(object sender)
        {
            Button btn = sender as Button;

            foreach (Button button in tlpROI.Controls)
            {
                if (button.GetType().Name.ToLower() == "button")
                {
                    if (button.Name.Contains(btn.Name))
                        button.BackColor = Color.LimeGreen;
                    else
                        button.BackColor = Color.DarkGray;
                }
            }
        }

        private void btnMarkROI_Click(object sender, EventArgs e)
        {
            SetSelectButtonColor(sender);
            SetROI();
        }

        private void SetROI()
        {
            _markTeachStep = eMarkTeachStep.SetMark;

            if (_teachingDisplay.Image == null)
                return;

            ClearGraphic();
			
            if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition] == null)
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition] = new CogPMAlignTool();
				
            if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Trained == false)
            {
                using (CogRectangle PatternRect = new CogRectangle())
                {
                    PatternRect.Interactive = true;
                    PatternRect.GraphicDOFEnable = CogRectangleDOFConstants.All;

                    PatternRect.SetCenterWidthHeight(_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX, _teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY, 200, 200);
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationX = _teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Origin.TranslationY = _teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY;
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainRegion = new CogRectangle(PatternRect);
                }
            }

            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion | CogPMAlignCurrentRecordConstants.PatternOrigin;
            Display.SetGraphics(_teachingDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());
        }

        private void btnSetMark_Click(object sender, EventArgs e)
        {
            SetSelectButtonColor(sender);
            SetMark();
        }

        private void SetMark()
        {
            _markDisplay.InteractiveGraphics.Clear();

            _markTeachStep = eMarkTeachStep.SetROI;

            if ((CogImage8Grey)_teachingDisplay.Image == null)
                return;

            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.TrainImage = (CogImage8Grey)_teachingDisplay.Image;
            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Train();
            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainedPatternImage | CogPMAlignCurrentRecordConstants.TrainedPatternImageMask;
            _markDisplay.Image = _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.GetTrainedPatternImage();

            SetGraphics(_markDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());

            _markDisplay.Fit();

            ClearGraphic();
        }

        private void btnMasking_Click(object sender, EventArgs e)
        {
            SetSelectButtonColor(sender);
            OpenMasking();
        }

        private void OpenMasking()
        {
            ClearGraphic();

            using (Form_Mask PatternMask = new Form_Mask())
            {
                PatternMask._CogImage8Grey = (CogImage8Grey)_teachingDisplay.Image;
                PatternMask.IsCogPMAlignTool = _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition];
                PatternMask.ShowDialog();
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition] = PatternMask.IsCogPMAlignTool;
                _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Train();
                RefreshMarkDisplay();
            }
        }

        private void btnSearchROI_Click(object sender, EventArgs e)
        {
            SetSelectButtonColor(sender);
            SearchROI();
        }

        private void SearchROI()
        {
            _markTeachStep = eMarkTeachStep.SetROI;

            if ((CogImage8Grey)_teachingDisplay.Image == null)
                return;

            ClearGraphic();

            if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion == null)
            {
                using (CogRectangle SearchRect = new CogRectangle())
                {
                    SearchRect.Interactive = true;
                    SearchRect.GraphicDOFEnable = CogRectangleDOFConstants.All;
                    SearchRect.SetCenterWidthHeight(_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX, _teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY, 300, 300);
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SearchRegion = new CogRectangle(SearchRect);
                }
            }

            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
            Display.SetGraphics(_teachingDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            MarkApply();

            btnSearchROI.BackColor = Color.DarkGray;
        }

        private void MarkApply()
        {
            PatternMatchParameter patternParam = new PatternMatchParameter();

            patternParam.CogPMAlignTool = _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition];
            patternParam.Score = Convert.ToDouble(lblMarkScore.Text) / 100;
            patternParam.Angle = Convert.ToDouble(lblMarkAngleThreshold.Text);

            _patternParamList[(int)_markIndex][(int)_targetObject, (int)_markPosition].SetParam(patternParam);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Untrain();
            _markDisplay.Image = null;
        }

        private void lblMarkScore_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            int outputData = 0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = Convert.ToInt32(formKeyPad.m_data);
            lblMarkScore.Text = outputData.ToString();

            SetMarkScore();
        }

        private void SetMarkScore()
        {
            for (int markIndex = 0; markIndex < Main.DEFINE.SUBPATTERNMAX; markIndex++)
            {
                for (int targetObjectIndex = 0; targetObjectIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetObjectIndex++)
                {
                    for (int markPositionIndex = 0; markPositionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; markPositionIndex++)
                        _patternParamList[markIndex][targetObjectIndex, markPositionIndex].Score = Convert.ToDouble(lblMarkScore.Text) / 100;
                }
            }
        }

        private void lblMarkAngleThreshold_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            double outputData = 0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = Convert.ToDouble(formKeyPad.m_data);
            lblMarkAngleThreshold.Text = outputData.ToString();

            SetMarkAngle();
        }

        private void SetMarkAngle()
        {
            for (int markIndex = 0; markIndex < Main.DEFINE.SUBPATTERNMAX; markIndex++)
            {
                for (int targetObjectIndex = 0; targetObjectIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetObjectIndex++)
                {
                    for (int markPositionIndex = 0; markPositionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; markPositionIndex++)
                        _patternParamList[markIndex][targetObjectIndex, markPositionIndex].Angle = Convert.ToDouble(lblMarkAngleThreshold.Text);
                }
            }
        }

        private void btnMarkTest_Click(object sender, EventArgs e)
        {
            MarkTest();
        }

        private void MarkTest()
        {
            ClearGraphic();

            CogGraphicInteractiveCollection ResultOverly = new CogGraphicInteractiveCollection();

            if (_teachingDisplay.Image == null)
                return;

            CogPMAlignTool[,] testTool = new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkIndex)).Length];

            if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition] != null)
                testTool[(int)_targetObject, (int)_markPosition] = _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition];
            else
            {
                MessageBox.Show("This is the area of ​​unregistered marks.");
                return;
            }

            testTool[(int)_targetObject, (int)_markPosition].InputImage = _teachingDisplay.Image;
            testTool[(int)_targetObject, (int)_markPosition].Run();

            if (testTool[(int)_targetObject, (int)_markPosition].Results == null)
                return;

            if (testTool[(int)_targetObject, (int)_markPosition].Results.Count > 0)
            {
                if (testTool[(int)_targetObject, (int)_markPosition].Results[0].Score >= _patternParamList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Score)
                {
                    DrawLabel(_teachingDisplay, "Mark   X : " + (testTool[(int)_targetObject, (int)_markPosition].Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                    DrawLabel(_teachingDisplay, "Mark   Y : " + (testTool[(int)_targetObject, (int)_markPosition].Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                    DrawLabel(_teachingDisplay, "Score     : " + ((testTool[(int)_targetObject, (int)_markPosition].Results[0].Score)*100).ToString("0.000"), 3);
                    ResultOverly.Add(testTool[(int)_targetObject, (int)_markPosition].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                    _teachingDisplay.InteractiveGraphics.AddList(ResultOverly, "Result", false);
                }
                else
                {
                    DrawLabel(_teachingDisplay, "Mark Search Fail", 1);
                    DrawLabel(_teachingDisplay, "Score : " + ((testTool[(int)_targetObject, (int)_markPosition].Results[0].Score) * 100).ToString("0.000"), 2);
                }

                ResultOverly.Clear();
            }

            CogPMAlignZoneAngle cogPMAlignAngle = new CogPMAlignZoneAngle();
            cogPMAlignAngle = testTool[(int)_targetObject, (int)_markPosition].RunParams.ZoneAngle;

            double angleHigh = (cogPMAlignAngle.High * 180) / Math.PI;
            double angleLow = (cogPMAlignAngle.Low * 180) / Math.PI;
        }

        private void DrawLabel(CogRecordDisplay cogDisplay, string resultText, int index)
        {
            CogGraphicLabel cogLabel = new CogGraphicLabel();

            float fontSize = 0;
            double baseZoom = 0;

            if ((double)cogDisplay.Width / cogDisplay.Image.Width < (double)cogDisplay.Height / cogDisplay.Image.Height)
            {
                baseZoom = ((double)cogDisplay.Width - 22) / cogDisplay.Image.Width;
                fontSize = (float)((cogDisplay.Image.Width / Main.DEFINE.FontSize) * baseZoom);
            }
            else
            {
                baseZoom = ((double)cogDisplay.Height - 22) / cogDisplay.Image.Height;
                fontSize = (float)((cogDisplay.Image.Height / Main.DEFINE.FontSize) * baseZoom);
            }

            double nFontpitch = (fontSize / cogDisplay.Zoom);
            cogLabel.Text = resultText;
            cogLabel.Color = CogColorConstants.Cyan;
            cogLabel.Font = new Font(Main.DEFINE.FontStyle, fontSize);
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            cogLabel.X = (cogDisplay.Image.Width - (cogDisplay.Image.Width / (cogDisplay.Zoom / baseZoom))) / 2 - cogDisplay.PanX;
            cogLabel.Y = (cogDisplay.Image.Height - (cogDisplay.Image.Height / (cogDisplay.Zoom / baseZoom))) / 2 - cogDisplay.PanY + (index * nFontpitch);

            cogDisplay.StaticGraphics.Add(cogLabel as ICogGraphic, "Result Text");
        }

        private void SetAlignProperty()
        {
#if ATT
            _alignTagData = new Main.AlignTagData[DEFINE.TAB_NUM];

            for (int tabNo = 0; tabNo < Main.DEFINE.TAP_UNIT_MAX; tabNo++)
            {
                _alignTagData[tabNo] = new Main.AlignTagData();
                _alignTagData[tabNo].SetParam(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabNo].AlignPara);
            }
#else
            //_patternParamList = new List<PatternMatchParameter[,]>();

            //for (int markIndex = 0; markIndex < Enum.GetValues(typeof(eMarkIndex)).Length; markIndex++)
            //{
            //    CogPMAlignTool[,] tempTool = new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkPosition)).Length];

            //    for (int targetIndex = 0; targetIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetIndex++)
            //    {
            //        for (int positionIndex = 0; positionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; positionIndex++)
            //        {
            //            _patternParam[targetIndex, positionIndex] = new PatternMatchParameter();

            //            tempTool[targetIndex, positionIndex] = new CogPMAlignTool();
            //            _patternParam[targetIndex, positionIndex].SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].PatternList[markIndex][targetIndex, positionIndex]);
            //            tempTool[targetIndex, positionIndex] = _patternParam[targetIndex, positionIndex].CogPMAlignTool;
            //        }
            //    }

            //    _markToolList[markIndex] = tempTool;
            //    _patternParamList.Add(_patternParam);
            //}
#endif
        }

        private void SetAkkonProperty()
        {
            _akkonTagData = new Main.AkkonTagData[DEFINE.TAB_NUM];

            for (int tabCount = 0; tabCount < Main.DEFINE.TAP_UNIT_MAX; tabCount++)
            {
                _akkonTagData[tabCount] = new Main.AkkonTagData();
                _akkonTagData[tabCount].SetParam(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AkkonPara[0]);
            }
        }

        private void ChangeMainDisplayFocus(object sender)
        {
            RadioButton rdo = sender as RadioButton;

            if (!rdo.Checked)
                return;

            if (_teachingDisplay.Image == null)
                return;

            if (_markPosition == eMarkPosition.Left)
                _teachingDisplay.PanX = _teachingDisplay.Image.Width / 2 * 0.96;
            else
                _teachingDisplay.PanX = -_teachingDisplay.Image.Width / 2 * 0.96;
        }

        private void RefreshMarkDisplay()
        {
            _markDisplay.InteractiveGraphics.Clear();
            _markDisplay.StaticGraphics.Clear();

            if (_markToolList.Count <= 0)
                return;

            if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition] == null)
                _markDisplay.Image = null;
            else
            {
                if (_markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.Trained == true)
                {
                    _markDisplay.Image = _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Pattern.GetTrainedPatternImage();
                    _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainedPatternImage | CogPMAlignCurrentRecordConstants.TrainedPatternImageMask;
                    SetGraphics(_markDisplay, _markToolList[(int)_markIndex][(int)_targetObject, (int)_markPosition].CreateCurrentRecord());
                }
                else
                    _markDisplay.Image = null;
            }

            lblMarkScore.Text = (_patternParamList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Score * 100).ToString();
            lblMarkAngleThreshold.Text = _patternParamList[(int)_markIndex][(int)_targetObject, (int)_markPosition].Angle.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
#if ATT
            for (int tabCount = 0; tabCount < DEFINE.TAP_UNIT_MAX; tabCount++)
            {
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AlignPara = _alignTagData[tabCount].Copy();
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AkkonPara[0] = _akkonTagData[tabCount].Copy();
                Main.AlignUnit[(int)_camNo].SaveMark((int)_stageNo, tabCount);
            }
#endif
            Main.ProgerssBar_PAT(Main.formProgressBar_1, Enum.GetValues(typeof(eMarkIndex)).Length, true, 0, "Saving");


            for (int markIndex = 0; markIndex < Enum.GetValues(typeof(eMarkIndex)).Length; markIndex++)
            {
                for (int targetObjectIndex = 0; targetObjectIndex < Enum.GetValues(typeof(eTargetObject)).Length; targetObjectIndex++)
                {
                    for (int markPositionIndex = 0; markPositionIndex < Enum.GetValues(typeof(eMarkPosition)).Length; markPositionIndex++)
                    {
                        Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].PatternList[markIndex][targetObjectIndex, markPositionIndex] = _patternParamList[markIndex][targetObjectIndex, markPositionIndex].Copy();
                        SavePattern(markIndex, targetObjectIndex, markPositionIndex);
                    }
                }

                Main.ProgerssBar_PAT(Main.formProgressBar_1, Main.DEFINE.SUBPATTERNMAX, true, markIndex + 1, "Saving");
            }
        }

        private void SavePattern(int markIndex, int targetIndex, int positionIndex)
        {
            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MARK\\";

            if (!Directory.Exists(filePath))
                Utility.CreateDir(filePath);

            _patternParamList[markIndex][targetIndex, positionIndex].SaveVPP(filePath, (int)_camNo, (int)_stageNo, targetIndex, positionIndex, markIndex);
            _patternParamList[markIndex][targetIndex, positionIndex].SaveXml(filePath, (int)_camNo, (int)_stageNo);
        }

        private void SetGraphics(CogDisplay display, ICogRecord record)
        {
            foreach (Cognex.VisionPro.Implementation.CogRecord _record in record.SubRecords)
            {
                if (typeof(ICogImage).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        display.Image = (ICogImage)_record.Content;
                    }
                }
                if (typeof(ICogGraphic).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                        display.InteractiveGraphics.Add(_record.Content as ICogGraphicInteractive, "Result", false);
                }

                else if (typeof(CogGraphicCollection).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        CogGraphicCollection graphics = _record.Content as CogGraphicCollection;
                        foreach (ICogGraphic graphic in graphics)
                        {
                            display.InteractiveGraphics.Add(graphic as ICogGraphicInteractive, "Result", false);
                        }
                    }
                }
                else if (typeof(CogGraphicInteractiveCollection).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        display.InteractiveGraphics.AddList(_record.Content as CogGraphicInteractiveCollection, "IDResult", false);
                    }
                }

                SetGraphics(display, _record);
            }
        }

#region AlignTest using mark data
        private void btnAlignTest_Click(object sender, EventArgs e)
        {
            AlignTest();
        }

        private void AlignTest()
        {
            ClearGraphic();

            CogGraphicInteractiveCollection ResultOverly = new CogGraphicInteractiveCollection();

            // Left
            CogPMAlignTool[,] testLeftTool = new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkIndex)).Length];
            double leftFPC_X = 0.0;
            double leftFPC_Y = 0.0;
            double leftPANEL_X = 0.0;
            double leftPANEL_Y = 0.0;
            double leftDX = 0.0;
            double leftDY = 0.0;

            if (_alignTagData[_tabNo].LeftPattern[(int)_markIndex] != null)
            {
#if CGMS
                testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex] = _alignTagData[_tabNo].LeftPattern[(int)_markIndex];
                testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].Run();

                if (testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].Results.Count > 0)
                {
                    leftFPC_X = testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].GetPose().TranslationX;
                    leftFPC_Y = testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
#if ATT
                testLeftTool[(int)eTargetObject.FPC, (int)_markIndex] = _alignTagData[_tabNo].LeftPattern[(int)_markIndex];
                testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].Run();

                if (testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].Results.Count > 0)
                {
                    leftFPC_X = testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].GetPose().TranslationX;
                    leftFPC_Y = testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
            }

            if (_akkonTagData[_tabNo].LeftPattern[(int)_markIndex] != null)
            {
#if CGMS
                testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex] = _akkonTagData[_tabNo].LeftPattern[(int)_markIndex];
                testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].Run();

                if (testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results.Count > 0)
                {
                    leftPANEL_X = testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].GetPose().TranslationX;
                    leftPANEL_Y = testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
#if ATT
                testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex] = _akkonTagData[_tabNo].LeftPattern[(int)_markIndex];
                testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].Run();

                if (testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].Results.Count > 0)
                {
                    leftPANEL_X = testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].GetPose().TranslationX;
                    leftPANEL_Y = testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
            }

            leftDX = Math.Abs(leftFPC_X - leftPANEL_X);
            leftDY = Math.Abs(leftFPC_Y - leftPANEL_Y);

            // Right
            CogPMAlignTool[,] testRightTool = new CogPMAlignTool[Enum.GetValues(typeof(eTargetObject)).Length, Enum.GetValues(typeof(eMarkIndex)).Length];
            double rightFPC_X = 0.0;
            double rightFPC_Y = 0.0;
            double rightPANEL_X = 0.0;
            double rightPANEL_Y = 0.0;
            double rightDX = 0.0;
            double rightDY = 0.0;

            if (_alignTagData[_tabNo].RightPattern[(int)_markIndex] != null)
            {
#if CGMS
                testRightTool[(int)eTargetObject.BackLight, (int)_markIndex] = _alignTagData[_tabNo].RightPattern[(int)_markIndex];
                testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].Run();

                if (testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].Results.Count > 0)
                {
                    rightFPC_X = testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].GetPose().TranslationX;
                    rightFPC_Y = testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
#if ATT
                testRightTool[(int)eTargetObject.FPC, (int)_markIndex] = _alignTagData[_tabNo].RightPattern[(int)_markIndex];
                testRightTool[(int)eTargetObject.FPC, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testRightTool[(int)eTargetObject.FPC, (int)_markIndex].Run();

                if (testRightTool[(int)eTargetObject.FPC, (int)_markIndex].Results.Count > 0)
                {
                    rightFPC_X = testRightTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].GetPose().TranslationX;
                    rightFPC_Y = testRightTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
            }

            if (_akkonTagData[_tabNo].RightPattern[(int)_markIndex] != null)
            {
#if CGMS
                testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex] = _akkonTagData[_tabNo].RightPattern[(int)_markIndex];
                testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].Run();

                if (testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results.Count > 0)
                {
                    rightPANEL_X = testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].GetPose().TranslationX;
                    rightPANEL_Y = testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
#if ATT
                testRightTool[(int)eTargetObject.PANEL, (int)_markIndex] = _akkonTagData[_tabNo].RightPattern[(int)_markIndex];
                testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].InputImage = _teachingDisplay.Image;
                testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].Run();

                if (testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].Results.Count > 0)
                {
                    rightPANEL_X = testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].GetPose().TranslationX;
                    rightPANEL_Y = testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].GetPose().TranslationY;
                }
#endif
            }

            rightDX = Math.Abs(leftFPC_X - leftPANEL_X);
            rightDY = Math.Abs(leftFPC_Y - leftPANEL_Y);

            if (_markPosition == eMarkPosition.Left)
            {
                DrawLabel(_teachingDisplay, "LEFT   - dX : " + leftDX.ToString("F2") + " / dY : " + leftDY.ToString("F2"), 1);
#if CGMS
                ResultOverly.Add(testLeftTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                ResultOverly.Add(testLeftTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
#endif
#if ATT
                ResultOverly.Add(testLeftTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                ResultOverly.Add(testLeftTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
#endif
            }
            else
            {
                DrawLabel(_teachingDisplay, "RIGHT  - dX : " + rightDX.ToString("F2") + " / dY : " + rightDY.ToString("F2"), 2);
#if CGMS
                ResultOverly.Add(testRightTool[(int)eTargetObject.BackLight, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                ResultOverly.Add(testRightTool[(int)eTargetObject.Coaxial, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
#endif
#if ATT
                ResultOverly.Add(testRightTool[(int)eTargetObject.FPC, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                ResultOverly.Add(testRightTool[(int)eTargetObject.PANEL, (int)_markIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
#endif
            }

            _teachingDisplay.InteractiveGraphics.AddList(ResultOverly, "Result", false);
        }

        private CogImage8Grey CopyIMG(ICogImage IMG)
        {
            if (IMG == null)
                return new CogImage8Grey();

            CogImage8Grey returnIMG;

            returnIMG = new CogImage8Grey(IMG as CogImage8Grey);
            return returnIMG;
        }
#endregion
    }
}
