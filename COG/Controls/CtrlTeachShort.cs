using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro.EdgeInspect;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using COG.Class;
using static COG.Main;
using System.IO;
using static COG.Controls.CtrlTeachROIJog;

namespace COG.Controls
{
    public partial class CtrlTeachShort : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        private ShortParameter _ShortParam = new ShortParameter();

        private CogBeadInspectTool[] _cogBeadInspectionTool = null;
        private CogGeneralContour _cogGenralContour = new CogGeneralContour();
        private List<ShortParameter> _ShortParamList = new List<ShortParameter>();

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_Scan_Start;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        private int _selectedBeadIndex = 0;
        private int _tabNo = 0;
        private InspectionCount _inspectionCount = new InspectionCount();
        
        public CtrlTeachShort(eTeachingPosition teachingPosition)
        {
            InitializeComponent();
            //SetUnitIndex(stageNo, camNo);
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

        private void CtrlTeachBead_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();

            SetShortCountProperty();
            Set_Parameter();
            SetShortProperty(_camNo, _stageNo);
        }
        private void SetShortProperty(eCameraNo nCamNo, eStageNo nStagNo)
        {
            for (int i = 0; i < Main.AlignUnit[(int)nCamNo].InspectionParams[(int)nStagNo].ShortParamList.Count; i++)
            {
                ShortParameter _Shortparam = new ShortParameter();
                _Shortparam.SetParam(Main.AlignUnit[(int)nCamNo].InspectionParams[(int)nStagNo].ShortParamList[i]);
                _ShortParamList.Add(_Shortparam);
            }
            UpdateParameter();
        }
        private void CreateList(int index)
        {
            int nListCnt = _ShortParamList.Count;
            if (_ShortParamList.Count != index)
            {
                if (_ShortParamList.Count > index)
                {
                    _ShortParamList.Clear();

                    for (int i = 0; i < index; i++)
                    {
                        if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortItem != null)
                        {
                            _ShortParam = new ShortParameter();
                            _ShortParam.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortParamList[i]);
                            _ShortParamList.Add(_ShortParam);
                        }
                        else
                            _ShortParamList.Add(new ShortParameter());
                    }
                }
                else
                {
                    int Cnt = (index + _ShortParamList.Count) - index;
                    _ShortParamList.Clear();
                    ;
                    for (int i = 0; i < index; i++)
                    {
                        if (i < Cnt)
                        {
                            _ShortParam = new ShortParameter();
                            _ShortParam.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortParamList[i]);
                            _ShortParamList.Add(_ShortParam);
                        }
                        else
                        {
                            _ShortParamList.Add(new ShortParameter());
                        }
                    }
                }
            }
        }
        private void UpdateParameter()
        {
            if (_ShortParamList.Count <= 0)
				return;
				
            ShortParameter Para = new ShortParameter();
            Para.SetParam(_ShortParamList[_selectedBeadIndex]);
			
            _cogBeadInspectionTool[_selectedBeadIndex] = Para.CogBeadTool;
            ///////////Train Parameter////////////////////////////////////////
            chkAutoCompute.Checked = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.AutoCompute;
            lblBeadWidthValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.BeadWidth.ToString("F1");
            lblTrainContrastThresholdValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.ContrastThreshold.ToString("F1");
            lblMaxResultValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxNumResults.ToString();
            lblMaxWidthDeviationValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxWidthDeviation.ToString("F1");
            lblMaxSkipCountValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxSkipCount.ToString();
            lblCaliperSpacingValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.CaliperSpacing.ToString("F1");
            lblSmoothingFactorValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.SmoothingFactor.ToString();
			
            if (_cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.DarkBead == true)
                rdoBeadDark.Checked = true;
            else
                rdoBeadLight.Checked = true;
            ///////////////////////////////////////////////////////////////////
            //////////////////////////Run Parameter////////////////////////////
            lblContrastThresholdValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.ContrastThreshold.ToString();
            lblAbsoluteDistanceValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.AbsoluteDistanceThreshold.ToString("F1");
            lblConsecutiveFallingCaliperValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.ConsecutiveFailingCalipersMin.ToString();
            lblCoverageValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.CoverageMin.ToString("F1");
            lblWidthValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.WidthMin.ToString("F1");
            lblStepThresholdValue.Text = _cogBeadInspectionTool[_selectedBeadIndex].RunParams.StepThreshold.ToString("F1");
        }
		
        private void Set_Parameter()
        {
            lblBeadCountValue.Text = _inspectionCount.BeadToolCount.ToString();
            AddBeadPointInComboBox(_inspectionCount.BeadToolCount);
            _cogBeadInspectionTool = new CogBeadInspectTool[_inspectionCount.BeadToolCount];
            for (int nCnt = 0; nCnt < _inspectionCount.BeadToolCount; nCnt++)
            {
                _cogBeadInspectionTool[nCnt] = new CogBeadInspectTool();
            }

        }

        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            //SetThumbnailDisplayMouseMode();
        }


        private void AddControl()
        {
            // Display
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;
        }

        #region ROI Jog
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
        }
        #endregion

        private void ClearGraphic()
        {
            _teachingDisplay.StaticGraphics.Clear();
            _teachingDisplay.InteractiveGraphics.Clear();
        }

        private void SetShortCountProperty()
        {
            _inspectionCount = new InspectionCount();
            _inspectionCount.SetParam(Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo]);
        }

        private void lblBeadCountValue_Click(object sender, EventArgs e)
        {
            SetBeadPointCount();
        }

        private void SetBeadPointCount()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10, outputData, "Input Edge Filter Size", 1))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;

                    lblBeadCountValue.Text = outputData.ToString();
                    _cogBeadInspectionTool = new CogBeadInspectTool[outputData];

                    for (int i = 0; i < outputData; i++)
                        _cogBeadInspectionTool[i] = new CogBeadInspectTool();

                    AddBeadPointInComboBox(outputData);
                    CreateList(outputData);
                    _inspectionCount.BeadToolCount = outputData;
                }
            }
        }

        private void AddBeadPointInComboBox(int index)
        {
            cmbBeadPointSelect.Items.Clear();

            string point = "";

            for (int i = 0; i < index; i++)
            {
                point = "Point_" + i.ToString();
                cmbBeadPointSelect.Items.Add(point);
            }

            if (index != 0)
                cmbBeadPointSelect.SelectedIndex = 0;
        }

        private void cmbBeadPointSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectBeadPoint(sender);
        }

        private void SelectBeadPoint(object sender)
        {
            ComboBox cmb = sender as ComboBox;
            _selectedBeadIndex = cmb.SelectedIndex;
            _teachingDisplay.InteractiveGraphics.Clear();
            UpdateParameter();
        }

        #region Train Parameter
        #region Find Parameter
        #region Auto Compute Parameter
        private void chkAutoCompute_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoComputeParameter(sender);
        }

        private void SetAutoComputeParameter(object sender)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
            {
                chkAutoCompute.BackColor = Color.LimeGreen;

                tlpBeadWidth.Enabled = false;
                tlpContrastThreshold.Enabled = false;
                tlpBeadPolarity.Enabled = false;
            }
            else
            {
                chkAutoCompute.BackColor = Color.DarkGray;

                tlpBeadWidth.Enabled = true;
                tlpContrastThreshold.Enabled = true;
                tlpBeadPolarity.Enabled = true;
            }
        }

        private void lblBeadWidthValue_Click(object sender, EventArgs e)
        {
            SetBeadWidth(sender);
        }

        private void SetBeadWidth(object sender)
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Bead Width", 1))
            {
                form_keypad.ShowDialog();
                outputData = form_keypad.m_data;

                lblBeadWidthValue.Text = outputData.ToString("F3");
                _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.BeadWidth = outputData;
            }
        }

        private void lblTrainContrastThresholdValue_Click(object sender, EventArgs e)
        {
            SetTrainContrastThreshold(sender);
        }

        private void SetTrainContrastThreshold(object sender)
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, outputData, "Input Patten Contrast Thresholds", 1))
            {
                form_keypad.ShowDialog();
                outputData = form_keypad.m_data;

                lblTrainContrastThresholdValue.Text = outputData.ToString("F3");
                _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.ContrastThreshold = outputData;
            }
        }

        private void rdoSetBeadPolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectBeadPolarity(sender);
        }

        private void SetSelectBeadPolarity(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("dark"))
                    SetBeadPolarity(polarityIsDark: true);
                else
                    SetBeadPolarity(polarityIsDark: false);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetBeadPolarity(bool polarityIsDark)
        {
            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.DarkBead = polarityIsDark;
        }

        #endregion

        private void lblMaxResultValue_Click(object sender, EventArgs e)
        {
            SetMaxResult();
        }

        private void SetMaxResult()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10, outputData, "Max Num Resulte", 1))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;
                    lblMaxResultValue.Text = outputData.ToString();
                    _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxNumResults = outputData;
                }
            }
        }

        private void lblMaxWidthDeviationValue_Click(object sender, EventArgs e)
        {
            SetMaxWidthDeviation();
        }

        private void SetMaxWidthDeviation()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.1, 10.0, outputData, "Input Width Deviation", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;
                    lblMaxWidthDeviationValue.Text = outputData.ToString("F1");
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxWidthDeviation = outputData;
                }

            }
        }

        private void lblMaxSkipCountValue_Click(object sender, EventArgs e)
        {
            SetMaxSkipCount();
        }

        private void SetMaxSkipCount()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10, outputData, "Max Num Result", 1))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;

                    lblMaxSkipCountValue.Text = outputData.ToString();
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.MaxSkipCount = outputData;
                }

            }
        }
        #endregion

        private void lblCaliperSpacingValue_Click(object sender, EventArgs e)
        {
            SetCaliperSpacing();
        }

        private void SetCaliperSpacing()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Caliper Spacing", 1))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;

                    lblCaliperSpacingValue.Text = outputData.ToString();
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].Pattern.CaliperSpacing = outputData;
                    _teachingDisplay.InteractiveGraphics.Clear();
                    //Train();
                }
            }
        }

        private void lblSmoothingFactorValue_Click(object sender, EventArgs e)
        {
            SetSmoothingFactor();
        }

        private void SetSmoothingFactor()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 30, outputData, "Input Caliper Smoothing Factor", 1))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;

                    lblSmoothingFactorValue.Text = outputData.ToString();
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].Pattern.SmoothingFactor = outputData;
                    _teachingDisplay.InteractiveGraphics.Clear();
                    //Train();
                }
            }
        }
        #endregion

        #region Run Parameter
        private void lblContrastThresholdValue_Click(object sender, EventArgs e)
        {
            SetContrastThreshold();
        }

        private void SetContrastThreshold()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, outputData, "Input RunPara Contrast Thr"))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;

                    lblContrastThresholdValue.Text = outputData.ToString();
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.ContrastThreshold = outputData;
                }
            }
        }

        private void lblAbsoluteDistanceValue_Click(object sender, EventArgs e)
        {
            SetAbsoluteDistance();
        }

        private void SetAbsoluteDistance()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1, outputData, "Input RunPara AbsoltDist Thr"))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;

                    lblAbsoluteDistanceValue.Text = outputData.ToString("F3");
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.AbsoluteDistanceThreshold = outputData;
                }
            }
        }

        private void lblConsecutiveFallingCaliperValue_Click(object sender, EventArgs e)
        {
            SetConsecutiveFallingCaliper();
        }

        private void SetConsecutiveFallingCaliper()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, outputData, "Input RunPara Consecutive Falling Caliper"))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = (int)form_keypad.m_data;

                    lblConsecutiveFallingCaliperValue.Text = outputData.ToString();
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.ConsecutiveFailingCalipersMin = outputData;
                }
            }
        }

        private void lblCoverageValue_Click(object sender, EventArgs e)
        {
            SetCoverage();
        }

        private void SetCoverage()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.1, 0.99, outputData, "Input RunPara Coverage "))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;

                    lblCoverageValue.Text = outputData.ToString("F2");
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.CoverageMin = outputData;
                }
            }
        }

        private void lblWidthValue_Click(object sender, EventArgs e)
        {
            SetWidth();
        }

        private void SetWidth()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.1, 0.99, outputData, "Input RunPara Min Width"))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;

                    lblWidthValue.Text = outputData.ToString("F2");
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.WidthMin = outputData;
                }
            }
        }

        private void lblStepThresholdValue_Click(object sender, EventArgs e)
        {
            SetStepThreshold();
        }

        private void SetStepThreshold()
        {
            double outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1.0, outputData, "Input RunPara Step Thr"))
            {
                form_keypad.ShowDialog();
                if (form_keypad.bOK)
                {
                    outputData = form_keypad.m_data;

                    lblStepThresholdValue.Text = outputData.ToString("F2");
                    if (outputData != 0)
                        _cogBeadInspectionTool[_selectedBeadIndex].RunParams.StepThreshold = outputData;
                }
            }
        }
        #endregion

        private void btnTrainROI_Click(object sender, EventArgs e)
        {
            ShowTrainROI();
        }

        private void ShowTrainROI()
        {
            _teachingDisplay.InteractiveGraphics.Clear();
            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.TrainImage = (CogImage8Grey)_teachingDisplay.Image;

            if (_cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.StartCircle == null)
            {
                CogCircle TraninCircleROI = new CogCircle();
                TraninCircleROI.SetCenterRadius(100, 100, 100);
                TraninCircleROI.Interactive = true;
                TraninCircleROI.GraphicDOFEnable = CogCircleDOFConstants.All;
                _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindParams.StartCircle = TraninCircleROI;
            }

            _cogBeadInspectionTool[_selectedBeadIndex].CurrentRecordEnable = CogBeadInspectCurrentRecordConstants.TrainImage | CogBeadInspectCurrentRecordConstants.StartCircle;
            SetGraphics(_teachingDisplay, _cogBeadInspectionTool[_selectedBeadIndex].CreateCurrentRecord());
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void Find()
        {
            ClearGraphic();

            CogGraphicInteractiveCollection TrainRsult = new CogGraphicInteractiveCollection();

            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.TrainImage = (CogImage8Grey)_teachingDisplay.Image;
            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.Find();

            if (_cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindResults.Count > 0)
            {
                CogBeadInspectFindResult Resulte = _cogBeadInspectionTool[_selectedBeadIndex].Pattern.FindResults[0];
                _cogGenralContour = Resulte.GetCoarsePath();
                _cogGenralContour.GraphicDOFEnable = CogGeneralContourDOFConstants.All;
                switch (_selectedBeadIndex)
                {
                    case 0:
                        _cogGenralContour.Color = CogColorConstants.Green;
                        break;
                    case 1:
                        _cogGenralContour.Color = CogColorConstants.Orange;
                        break;
                    case 2:
                        _cogGenralContour.Color = CogColorConstants.Purple;
                        break;

                    default:
                        break;
                }
                //(CogBeadInspectTrainResultGraphicConstants.All, _CogBeadInspectionTool[index].RunParams, false);
                _teachingDisplay.InteractiveGraphics.Add(_cogGenralContour, "Train", false);
            }
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            FindPath();
        }

        private void FindPath()
        {
            using (Form_BeadPath formbeadPath = new Form_BeadPath())
            {
                formbeadPath.objImage = (CogImage8Grey)_teachingDisplay.Image;
                formbeadPath._cogGeneralContour = _cogGenralContour;
                formbeadPath.ShowDialog();
                _cogGenralContour = formbeadPath._cogGeneralContour;
                _cogBeadInspectionTool[_selectedBeadIndex].Pattern.SetCoarseContour(_cogGenralContour);
                _teachingDisplay.InteractiveGraphics.Clear();
                _teachingDisplay.InteractiveGraphics.Add(_cogGenralContour, "Find", false);
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            Train();
        }

        private void Train()
        {
            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.TrainImage = (CogImage8Grey)_teachingDisplay.Image;
            _cogBeadInspectionTool[_selectedBeadIndex].Pattern.Train();
            _cogBeadInspectionTool[_selectedBeadIndex].CurrentRecordEnable = CogBeadInspectCurrentRecordConstants.TrainedPath | CogBeadInspectCurrentRecordConstants.TrainedCalipers | CogBeadInspectCurrentRecordConstants.TrainImage;
            _teachingDisplay.InteractiveGraphics.Clear();
            SetGraphics(_teachingDisplay, _cogBeadInspectionTool[_selectedBeadIndex].CreateCurrentRecord());
        }

        private void btnSearchTest_Click(object sender, EventArgs e)
        {
            SearchTest();
        }

        private void SearchTest()
        {
            _teachingDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection ResultGraphy = new CogGraphicInteractiveCollection();

            if (_teachingDisplay.Image == null)
                return;

            if (_cogBeadInspectionTool[_selectedBeadIndex].Pattern.Trained == false)
                return;

            _cogBeadInspectionTool[_selectedBeadIndex].InputImage = (CogImage8Grey)_teachingDisplay.Image;
            _cogBeadInspectionTool[_selectedBeadIndex].Run();

            if (_cogBeadInspectionTool[_selectedBeadIndex].Result != null)
            {
                switch (_selectedBeadIndex)
                {
                    case 0:
                        _cogBeadInspectionTool[_selectedBeadIndex].Result.Contour.Color = CogColorConstants.Green;
                        break;
                    case 1:
                        _cogBeadInspectionTool[_selectedBeadIndex].Result.Contour.Color = CogColorConstants.Orange;
                        break;
                    case 2:
                        _cogBeadInspectionTool[_selectedBeadIndex].Result.Contour.Color = CogColorConstants.Purple;
                        break;

                    default:
                        break;
                }
                
                ResultGraphy.Add(_cogBeadInspectionTool[_selectedBeadIndex].Result.Contour);

                for (int DefectCnt = 0; DefectCnt < _cogBeadInspectionTool[_selectedBeadIndex].Result.Defects.Count(); DefectCnt++)
                {
                    CogRectangleAffine cogRectNG;
                    cogRectNG = _cogBeadInspectionTool[_selectedBeadIndex].Result.Defects[DefectCnt].Bounds;
                    cogRectNG.Color = CogColorConstants.Red;
                    ResultGraphy.Add(cogRectNG);
                }
            }

            _teachingDisplay.InteractiveGraphics.AddList(ResultGraphy, "result", false);
        }

        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboboxCenterAlign(sender, e);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            if (cmb != null)
            {
                e.DrawBackground();
                cmb.ItemHeight = lblBeadCount.Height - 7;

                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cmb.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ClearGraphic();

            //if (_teachingDisplay.Image == null)
            //    return;

            // _cogBlobToolList[_selectedBlobIndex] = _cogBlobTool;
            ShortParameter Para = new ShortParameter();
            Para.CogBeadTool = _cogBeadInspectionTool[_selectedBeadIndex];
            _ShortParamList[_selectedBeadIndex] = Para;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            Save();
        }

        private void SaveParams()
        {
            if (MessageBox.Show("Save ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                return;
            Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo] = _inspectionCount.Copy();
            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortParamList.Clear();
            for (int i = 0; i < _inspectionCount.BeadToolCount; i++)
            {
                ShortParameter param = new ShortParameter();
                param.SetParam(_ShortParamList[i]);
                Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortItem = param.Copy();
                Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortParamList.Add(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].ShortItem);
            }
        }

        public void Save()
        {
            SaveParams();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            string strFileName = string.Format("\\MeasureCount_Cam{0:D}_Stage{1:D}", (int)_camNo, (int)_stageNo);
            filePath += strFileName;
            _inspectionCount.SaveXml(filePath);
            filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\Bead\\";

            // filePath += strFileName;
            for (int i = 0; i < _ShortParamList.Count; i++)
            {
                _ShortParamList[i].SaveVPP(filePath, (int)_stageNo, (int)_camNo, i);
            }
        }
        private void btnBeadTest_Click(object sender, EventArgs e)
        {
            BeadTest();
        }

        private void BeadTest()
        {
            _teachingDisplay.InteractiveGraphics.Clear();

            CogGraphicInteractiveCollection ResultGraphy = new CogGraphicInteractiveCollection();

            if (_teachingDisplay.Image == null)
                return;

           
            for (int nCnt = 0; nCnt < _inspectionCount.BeadToolCount; nCnt++)
            {
                if (_ShortParamList[nCnt].CogBeadTool.Pattern.Trained == false)
                    return;
                _ShortParamList[nCnt].CogBeadTool.InputImage = (CogImage8Grey)_teachingDisplay.Image;
                _ShortParamList[nCnt].CogBeadTool.Run();

                if (_ShortParamList[nCnt].CogBeadTool.Result != null)
                {
                    ResultGraphy.Add(_ShortParamList[nCnt].CogBeadTool.Result.Contour);
                    switch (nCnt)
                    {
                        case 0:
                            _cogBeadInspectionTool[nCnt].Result.Contour.Color = CogColorConstants.Green;
                            break;
                        case 1:
                            _cogBeadInspectionTool[nCnt].Result.Contour.Color = CogColorConstants.Orange;
                            break;
                        case 2:
                            _cogBeadInspectionTool[nCnt].Result.Contour.Color = CogColorConstants.Purple;
                            break;

                        default:
                            break;
                    }
                    for (int DefectCnt = 0; DefectCnt < _ShortParamList[nCnt].CogBeadTool.Result.Defects.Count(); DefectCnt++)
                    {
                        CogRectangleAffine cogRectNG;
                        cogRectNG = _ShortParamList[nCnt].CogBeadTool.Result.Defects[DefectCnt].Bounds;
                        cogRectNG.Color = CogColorConstants.Red;
                        ResultGraphy.Add(cogRectNG);
                    }
                }
            }

            _teachingDisplay.InteractiveGraphics.AddList(ResultGraphy, "result", false);
        }

        
    }
}
