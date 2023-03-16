using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Caliper;
using static COG.Main;
using JAS.Controls.Display;
using COG.Class;
using static COG.Controls.CtrlTeachROIJog;

namespace COG.Controls
{
    public partial class CtrlTeachAlign : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        private AlignTagData[] _alignTagData = new AlignTagData[DEFINE.TAB_NUM];

        private CogCaliperTool[,] _alignXTool = new CogCaliperTool[2, 2];
        private CogCaliperTool[,] _alignYTool = new CogCaliperTool[2, 2];
        private List<CogCaliperTool[,]> _alignTool = new List<CogCaliperTool[,]>();

        private eAlignPosition _alignPosition = eAlignPosition.Left;
        private enum eAlignPosition
        {
            Left,
            Right,
        }

        private eTargetObject _targetObject = eTargetObject.FPC;
        private enum eTargetObject
        {
            FPC,
            PANEL,
        }

        private eEdgeType _edgeType = eEdgeType.X;
        private enum eEdgeType
        {
            X,
            Y,
        }

        private int _tabNo = 0;
        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        private int _alignLeadCount = 0;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_Scan_Start;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        public CtrlTeachAlign(eTeachingPosition teachingPosition)
        {
            InitializeComponent();
            SetTeachingUnitDevice(teachingPosition);
        }

        //private void SetUnitIndex(eStageNo stageNo, eCameraNo camNo)
        //{
        //    // PJH_TEST_20230306_S
        //    //_stageNo = stageNo;
        //    //_camNo = camNo;
        //    _stageNo = 0;
        //    _camNo = 0;
        //    // PJH_TEST_20230306_E
        //}

        private void SetTeachingUnitDevice(eTeachingPosition teachingPosition)
        {
            _teachingPosition = teachingPosition;

            switch (teachingPosition)
            {
                case eTeachingPosition.Standby:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_PreAlign_Left:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_PreAlign_Right:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_Scan_Start:
                    // 임시
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.Inspection1;
                    break;

                default:
                    break;
            }
        }

        private void CtrlTeachAlign_Load(object sender, EventArgs e)
        {
            AddControl();

            CreateObject();
            GetAlignParameter();

            InitializeUI();
        }

        private void AddControl()
        {
            // Display
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;

            // Thumbnail
            //cogDisplayThumbnail.Image = Main.vision.CogCamBuf[_CamNo];

            // Current Unit Control
            //CurrentUnitControl = new CtrlCGMSCurrentUnit(_stageNo, _camNo);
            //this.pnlTeachIndex.Controls.Add(CurrentUnitControl);
            //CurrentUnitControl.Dock = DockStyle.Fill;

            // ROI Jog Control
            //FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl = new CtrlTeachROIJog();
            //this.pnlROIJog.Controls.Add(FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl);
            //FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl.Dock = DockStyle.Fill;
            //pnlROIJog.Visible = false;
            //FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl.SendEventHandler += new CtrlTeachROIJog.SendClickEventDelegate(ReceiveClickEvent);
            //FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl.tlpSkew.Enabled = false;
            //FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogControl.tlpMarkOrigin.Enabled = false;
        }

        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            rdoAlignLeft.Checked = true;
            rdoFPC.Checked = true;
            rdoEdgeX.Checked = true;
            //rdoDarkToLight.Checked = true;
        }


        public void MoveROIJog(eMoveDirection moveDirection)
        {
            ClearGraphic();

            int movePixel = Convert.ToInt32(FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogForm.ROIJogControl.lblJogScale.Text);
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
            
            if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] == null)
            {
                MessageBox.Show("Select Edge Poasition");
                return;
            }

            CogRectangleAffine AlignROI = new CogRectangleAffine(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region);
            AlignROI.Interactive = true;

            AlignROI.CenterX += jogMoveX;
            AlignROI.CenterY += jogMoveY;

            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region = AlignROI;
            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].CurrentRecordEnable = CogCaliperCurrentRecordConstants.InputImage | CogCaliperCurrentRecordConstants.Region;
            Display.SetGraphics(_teachingDisplay, _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].CreateCurrentRecord());
        }

        public void SizeROIJog(eSizeDirection sizeDirection)
        {
            ClearGraphic();

            int sizePixel = Convert.ToInt32(FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogForm.ROIJogControl.lblJogScale.Text);
            int jogSizeX = 0;
            int jogSizeY = 0;

            switch (sizeDirection)
            {
                case eSizeDirection.IncreaseUpDown:
                    jogSizeX = 0;
                    jogSizeY = sizePixel * (1);
                    break;

                case eSizeDirection.DecreaseUpDown:
                    jogSizeX = 0;
                    jogSizeY = sizePixel * (-1);
                    break;

                case eSizeDirection.IncreaseLeftRight:
                    jogSizeX = sizePixel * (1);
                    jogSizeY = 0;
                    break;

                case eSizeDirection.DecreaseLeftRight:
                    jogSizeX = sizePixel * (-1);
                    jogSizeY = 0;
                    break;

                default:
                    break;
            }

            if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] == null)
            {
                MessageBox.Show("Select Edge Poasition");
                return;
            }

            CogRectangleAffine AlignROI = new CogRectangleAffine(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region);
            AlignROI.Interactive = true;

            AlignROI.SideXLength += jogSizeX;
            AlignROI.SideYLength += jogSizeY;

            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region = AlignROI;
            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].CurrentRecordEnable = CogCaliperCurrentRecordConstants.InputImage | CogCaliperCurrentRecordConstants.Region;
            Display.SetGraphics(_teachingDisplay, _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].CreateCurrentRecord());
        }



        private void rdoSetAlignPosition_CheckedChanged(object sender, EventArgs e)
        {
            SetSelecteAlignPosition(sender);

            ChangeMainDisplayFocus(sender);
        }

        private void SetSelecteAlignPosition(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("left"))
                    SetAlignPosition(eAlignPosition.Left);
                else
                    SetAlignPosition(eAlignPosition.Right);

                GetAlignParameter();

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetAlignPosition(eAlignPosition alignPosition)
        {
            _alignPosition = alignPosition;
        }

        private void ChangeMainDisplayFocus(object sender)
        {
            RadioButton rdo = sender as RadioButton;

            if (!rdo.Checked)
                return;

            if (_teachingDisplay.Image == null)
                return;

            if (_alignPosition == eAlignPosition.Left)
                _teachingDisplay.PanX = _teachingDisplay.Image.Width / 2 * 0.96;
            else
                _teachingDisplay.PanX = -_teachingDisplay.Image.Width / 2 * 0.96;
        }

        private void UpdateEdgePolarity()
        {
            if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                rdoDarkToLight.Checked = true;
            else if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark)
                rdoLightToDark.Checked = true;
            else { }
        }

        private void rdoSetTargetObject_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectTargetObject(sender);
        }

        private void SetSelectTargetObject(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("fpc"))
                    SetTargetObject(eTargetObject.FPC);
                else
                    SetTargetObject(eTargetObject.PANEL);

                GetAlignParameter();

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetTargetObject(eTargetObject targetObject)
        {
            _targetObject = targetObject;
        }

        private void rdoSetEdgeType_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectEdgeType(sender);
        }

        private void SetSelectEdgeType(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("x"))
                    SetEdgeType(eEdgeType.X);
                else
                    SetEdgeType(eEdgeType.Y);

                GetAlignParameter();

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetEdgeType(eEdgeType edgeType)
        {
            _edgeType = edgeType;
        }

        private void lblLeadCountValue_Click(object sender, EventArgs e)
        {
            SetLabelData(sender as Label);
        }

        private void lblFilterSizeValue_Click(object sender, EventArgs e)
        {
            SetLabelData(sender as Label);
        }

        private void lblEdgeThresholdValue_Click(object sender, EventArgs e)
        {
            SetLabelData(sender as Label);
        }

        private void SetLabelData(Control control)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            if (control.Name.ToLower().Contains("leadcount"))
            {
                int leadCount = Convert.ToInt32(outputData);
                _alignLeadCount = leadCount;
            }
            else if (control.Name.ToLower().Contains("filter"))
            {
                int filterSize = Convert.ToInt32(outputData);
                _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.FilterHalfSizeInPixels = filterSize;
            }
            else if (control.Name.ToLower().Contains("threshold"))
            {
                int threshold = Convert.ToInt32(outputData);
                _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.ContrastThreshold = threshold;
            }

            control.Text = outputData.ToString();
        }

        private void rdoSetEdgePolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectEdgePolarity(sender);
        }

        private void SetSelectEdgePolarity(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Name.ToLower().Contains("darktolight"))
                    SetEdgePolarity(CogCaliperPolarityConstants.DarkToLight);
                else
                    SetEdgePolarity(CogCaliperPolarityConstants.LightToDark);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetEdgePolarity(CogCaliperPolarityConstants caliperPolarity)
        {
            //TempCaliperTool.RunParams.Edge0Polarity = edgePolarity;
            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity = caliperPolarity;
        }

        private void btnROIShow_Click(object sender, EventArgs e)
        {
            ShowCaliperROI();
        }

        private void ShowCaliperROI()
        {
            ClearGraphic();

            CogRectangleAffine cogRectAffine = new CogRectangleAffine();
            cogRectAffine = new CogRectangleAffine(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region);

            if (cogRectAffine.CenterX <= 70)
            {
                cogRectAffine.SetCenterLengthsRotationSkew((_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX), (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY), 500, 500, 0, 0);
                // CaliperRegion.SetCenterLengthsRotationSkew(500, 500, CaliperRegion.SideXLength / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000),
                //  CaliperRegion.SideYLength / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), 0, 0);
            }

            cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;
            cogRectAffine.Interactive = true;
            _teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "CALIPER", false);

            _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region = cogRectAffine;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            if (_teachingDisplay.Image == null)
                return;

            ClearGraphic();

            _alignTagData[_tabNo].LeadCount = _alignLeadCount;

            if (_edgeType == eEdgeType.X)
                _alignTagData[_tabNo].AlignCaliperX[(int)_alignPosition, (int)_targetObject] = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject];
            else
                _alignTagData[_tabNo].AlignCaliperY[(int)_alignPosition, (int)_targetObject] = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject];

            CogRectangleAffine PTCaliperRegion = new CogRectangleAffine(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region);

            if (_edgeType == eEdgeType.X)
            {
                int leadCount = _alignLeadCount * 2;

                if (_alignTagData[_tabNo].LeadCount > 0)
                {
                    _teachingDisplay.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
                    CogRectangleAffine[] PTCaliperDividedRegion = new CogRectangleAffine[leadCount];

                    double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (leadCount * 2));
                    double dNewY = PTCaliperRegion.CenterY;

                    for (int i = 0; i < leadCount; i++)
                    {
                        PTCaliperDividedRegion[i] = new CogRectangleAffine(PTCaliperRegion);

                        double dX = PTCaliperRegion.SideXLength / leadCount * i * Math.Cos(PTCaliperRegion.Rotation);
                        double dY = PTCaliperRegion.SideXLength / leadCount * i * Math.Sin(PTCaliperRegion.Rotation);

                        PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / leadCount;
                        PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                        if (i % 2 == 0) //좌측부분 ROI
                            PTCaliperDividedRegion[i].Rotation = PTCaliperDividedRegion[i].Rotation - 3.14;

                        PTCaliperDividedRegion[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                        _teachingDisplay.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
                    }
                }
            }
            else
            {
                _teachingDisplay.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
            }
        }

        private void btnAlignTest_Click(object sender, EventArgs e)
        {
            AlignTest();
        }

        private void AlignTest()
        {
            ClearGraphic();

            switch (_edgeType)
            {
                case eEdgeType.X:
                    ExecuteCaliperX();
                    break;

                case eEdgeType.Y:
                    ExecuteCaliperY();
                    break;

                default:
                    break;
            }
        }

        private void ExecuteCaliperX()
        {
            //ClearGraphic();

            int nTotalLeadCount = _alignLeadCount * 2;
            CogRectangleAffine[] PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];
            CogCaliperTool CaliperTool = new CogCaliperTool();
            //CaliperTool = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject];
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            OpenCvSharp.Point2d CaliperPos = new OpenCvSharp.Point2d();
            
            if (_alignLeadCount > 0)
            {
                double dNewX = (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.CenterX - _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.SideXLength / 2) + _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.SideXLength / (nTotalLeadCount * 2);
                double dNewY = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.CenterY;

                //ROI Division
                for (int j = 0; j < nTotalLeadCount; j++)
                {
                    //ROI Tracking 추가 필요

                    PTCaliperDividedRegion[j] = new CogRectangleAffine(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region);

                    double dX = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.SideXLength / nTotalLeadCount * j * Math.Cos(_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.Rotation);
                    double dY = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.SideXLength / nTotalLeadCount * j * _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].Region.Rotation;

                    PTCaliperDividedRegion[j].SideXLength = PTCaliperDividedRegion[j].SideXLength / nTotalLeadCount;
                    PTCaliperDividedRegion[j].CenterX = dNewX + dX;
                    PTCaliperDividedRegion[j].CenterY = dNewY + dY;

                    if (j % 2 == 0) //좌측부분 ROI
                    {
                        PTCaliperDividedRegion[j].Rotation = PTCaliperDividedRegion[j].Rotation - 3.14;

                        if (CogCaliperPolarityConstants.DarkToLight == _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity)
                            CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                    }
                    else
                    {
                        if (CogCaliperPolarityConstants.DarkToLight == _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity)
                            CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                    }

                    //Caliper Search
                    //CaliperTool = PT_AlignPara[TapNo].m_AlignCaliperX[nInspectionPos, i];
                    CaliperTool.InputImage = (CogImage8Grey)_teachingDisplay.Image;
                    //CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                    //CaliperTool.RunParams.FilterHalfSizeInPixels = TempCaliperTool.RunParams.FilterHalfSizeInPixels;
                    //CaliperTool.RunParams.ContrastThreshold = TempCaliperTool.RunParams.ContrastThreshold;
                    CaliperTool.RunParams.FilterHalfSizeInPixels = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.FilterHalfSizeInPixels;
                    CaliperTool.RunParams.ContrastThreshold = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.ContrastThreshold;

                    CaliperTool.Region = PTCaliperDividedRegion[j];
                    CaliperTool.Run();

                    if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)               //Caliper Search OK
                        resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    else                                                                            //Caliper Search NG
                    {
                        CaliperPos.X = 0;
                        CaliperPos.Y = 0;
                    }
                }
            }

            _teachingDisplay.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
        }

        private void ExecuteCaliperY()
        {
            //ClearGraphic();

            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();

            CaliperTool = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject];

            if (CaliperTool == null)
                return;

            if (_teachingDisplay.Image == null)
                return;

            CaliperTool.InputImage = (CogImage8Grey)_teachingDisplay.Image;
            CaliperTool.Run();

            if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
            {
                resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                _teachingDisplay.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
            }
        }

        private void ClearGraphic()
        {
            _teachingDisplay.StaticGraphics.Clear();
            _teachingDisplay.InteractiveGraphics.Clear();
        }


        private void CreateObject()
        {
            SetAlignProperty();

            CreateList();

            foreach (eEdgeType edgeType in Enum.GetValues(typeof(eEdgeType)))
            {
                foreach (eAlignPosition alignPosition in Enum.GetValues(typeof(eAlignPosition)))
                {
                    foreach (eTargetObject targetObject in Enum.GetValues(typeof(eTargetObject)))
                    {
                        if (_alignTool[(int)edgeType][(int)alignPosition, (int)targetObject] == null)
                            _alignTool[(int)edgeType][(int)alignPosition, (int)targetObject] = new CogCaliperTool();
                    }
                }
            }
        }

        private void CreateList()
        {
            _alignTool.Add(_alignXTool);
            _alignTool.Add(_alignYTool);
        }

        private void SetAlignProperty()
        {
            _alignTagData = new Main.AlignTagData[DEFINE.TAB_NUM];

            for (int tabCount = 0; tabCount < Main.DEFINE.TAP_UNIT_MAX; tabCount++)
            {
                _alignTagData[tabCount] = new Main.AlignTagData();
                _alignTagData[tabCount].SetParam(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AlignPara);
            }
        }

        private void GetAlignParameter()
        {
            ClearGraphic();

            //foreach (eEdgeType edgeType in Enum.GetValues(typeof(eEdgeType)))
            //{
            //    foreach (eAlignPosition alignPosition in Enum.GetValues(typeof(eAlignPosition)))
            //    {
            //        foreach (eTargetObject targetObject in Enum.GetValues(typeof(eTargetObject)))
            //        {
            //            if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] == null)
            //                _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] = new CogCaliperTool();
            //        }
            //    }
            //}

            switch (_edgeType)
            {
                case eEdgeType.X:
                    _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] = _alignTagData[_tabNo].AlignCaliperX[(int)_alignPosition, (int)_targetObject];
                    _alignLeadCount = _alignTagData[_tabNo].LeadCount;
                    lblLeadCountValue.Text = _alignLeadCount.ToString();
                    break;

                case eEdgeType.Y:
                    _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] = _alignTagData[_tabNo].AlignCaliperY[(int)_alignPosition, (int)_targetObject];
                    lblLeadCountValue.Text = "1";
                    break;

                default:
                    break;
            }

            if (_alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] == null)
                _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject] = new CogCaliperTool();

            lblFilterSizeValue.Text = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.FilterHalfSizeInPixels.ToString();
            lblEdgeThresholdValue.Text = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.ContrastThreshold.ToString();

            CogCaliperPolarityConstants nPolarity = _alignTool[(int)_edgeType][(int)_alignPosition, (int)_targetObject].RunParams.Edge0Polarity;
            if (nPolarity == CogCaliperPolarityConstants.DarkToLight)
                rdoDarkToLight.Checked = true;
            else if (nPolarity == CogCaliperPolarityConstants.LightToDark)
                rdoLightToDark.Checked = true;
            else { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            for (int tabCount = 0; tabCount < Main.DEFINE.TAP_UNIT_MAX; tabCount++)
            {
                // Main.유닛[].펫[스테이지, 카메라].탭.파라메타
                // 유닛 : 프리얼라인, 검사
                
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AlignPara = _alignTagData[tabCount].Copy();
                Main.AlignUnit[(int)_camNo].SaveAlign((int)_stageNo, tabCount);
            }
        }
    }
}
