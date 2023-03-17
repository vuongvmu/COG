using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.ImageFile;
using COG.Params;
using COG.Class;
using JAS.Controls.Display;
using Cognex.VisionPro.Dimensioning;
using static COG.Controls.CtrlTeachROIJog;

namespace COG.Controls
{
    public partial class CtrlTeachMeasure : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        private MeasureLineParameter _measureLineParam = new MeasureLineParameter();
        private List<MeasureLineParameter> _measureLineParamList = new List<MeasureLineParameter>();

        public List<MeasureLineParameter> IsParamlist
        {
            get { return _measureLineParamList; }
            set { _measureLineParamList = value; }
        }
        private MeasureCircleParameter _measureCircleParam = new MeasureCircleParameter();
        private List<MeasureCircleParameter> _measureCircleParamList = new List<MeasureCircleParameter>();

        private InspectionCount _inspectionCount = new InspectionCount();

        private const int PAIR = 2;
        private CogCaliperTool[] _cogCaliperTool = new CogCaliperTool[PAIR];
        // private List<CogCaliperTool[]> _cogCaliperToolList = new List<CogCaliperTool[]>();
        //private List<MeasureLineParameter> _cogCaliperToolList = new List<MeasureLineParameter>();
        private int _lineCount = 0;
        private int _selectedLineIndex = 0;

        private CogFindCircleTool _cogFindCircleTool = new CogFindCircleTool();
        private List<CogFindCircleTool> _cogFindCircleToolList = new List<CogFindCircleTool>();
        private CogGraphicLabel[] _cogGraphicLabel = new CogGraphicLabel[PAIR];
        private int _circleCount = 0;
        private int _selectedCircleIndex = 0;

        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        private int _tabNo = 0;
        public int TabNo
        {
            get { return _tabNo; }
            set { _tabNo = value; }
        }

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_Scan_Start;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        private eMeasureType _measureType = eMeasureType.Line;
        public enum eMeasureType
        {
            Line,
            Circle,
        }
        private enum ePair
        {
            Edge1,
            Edge2,
        }

        public CtrlTeachMeasure(eTeachingPosition teachingPosition)
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

        private void CtrlTeachMeasure_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();
            CreateObject();

            SetMeasureCountProperty();

            _lineCount = _inspectionCount.CaliperCount;
            _circleCount = _inspectionCount.CircleCount;

            GetLineMeasureProperty();
            GetCircleMeasureProperty();

            SetLineMeasureItemProperty();
            SetMeasureCircleItemProperty();
			
            for(int i = 0; i < PAIR; i++)
                _cogGraphicLabel[i] = new CogGraphicLabel();

            SetComboboxMeasureType();
        }

        private bool _isLabelMove = false;
        private void _teachingDisplay_MouseMove(object sender, EventArgs e)
        {
            if (sender.GetType() == _teachingDisplay.GetType() && _isLabelMove)
            {
                CogLabelEvent(sender);
            }
        }

        private void _teachingDisplay_MouseDawn(object sender, EventArgs e)
        {
            if (sender.GetType() == _teachingDisplay.GetType())
            {
                CogLabelEvent(sender);
                _isLabelMove = true;
            }
        }

        private void _teachingDisplay_MousseUp(object sender, EventArgs e)
        {
            if (sender.GetType() == _teachingDisplay.GetType() && _isLabelMove)
            {
                CogLabelEvent(sender);
                _isLabelMove = false;
            }
        }

        private void CogLabelEvent(object sender)
        {
            for (int i = 0; i < PAIR; i++)
            {
                CogRectangleAffine cogRectAffine = new CogRectangleAffine();
                // cogRectAffine = _cogCaliperToolList[_selectedLineIndex].CogCaliperTool[i].Region;
                cogRectAffine = _cogCaliperTool[i].Region;
                _cogGraphicLabel[i].X = cogRectAffine.CornerXX;
                _cogGraphicLabel[i].Y = cogRectAffine.CornerXY;
            }
        }

        private void AddControl()
        {
            // Display
            //_teachingDisplay = PT_DISPLAY_CONTROL.CogDisplay00;
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;
        }

        public void DisplayEvent(bool bEvent)
        {
            if(bEvent)
            {
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseMove += _teachingDisplay_MouseMove;
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseUp += _teachingDisplay_MousseUp;
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseDown += _teachingDisplay_MouseDawn;
            }
            else
            {
                
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseMove -= _teachingDisplay_MouseMove;
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseUp -= _teachingDisplay_MousseUp;
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay.MouseDown -= _teachingDisplay_MouseDawn;
            }
        }
        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            // Checked Radio Button
            //OptionToMeasureItem();
            rdoMeasureLine.Checked = true;
            rdoLine1EdgeDarkToLight.Checked = true;
            rdoLine2EdgeDarkToLight.Checked = true;
            rdoCircleEdgeDarkToLight.Checked = true;
            rdoCircleSearchInward.Checked = true;

            // Parameter Panel Dock
            this.pnlMeasureLine.Dock = DockStyle.Fill;
            this.pnlMeasureCircle.Dock = DockStyle.Fill;

            SetComboboxMeasureType();
        }


        private void OptionToMeasureItem()
        {
            if (Main.machine.UseMeasureLine && Main.machine.UseMeasureCircle)
            {
                rdoMeasureLine.Checked = true;
                rdoMeasureLine.Enabled = true;
                rdoMeasureCircle.Enabled = true;
            }

            if (Main.machine.UseMeasureLine && !Main.machine.UseMeasureCircle)
            {
                rdoMeasureLine.Checked = true;
                rdoMeasureCircle.Enabled = false;
            }

            if (!Main.machine.UseMeasureLine && Main.machine.UseMeasureCircle)
            {
                rdoMeasureCircle.Checked = true;
                rdoMeasureLine.Enabled = false;
            }

            if (!Main.machine.UseMeasureLine && !Main.machine.UseMeasureCircle)
            {
                rdoMeasureLine.Enabled = false;
                rdoMeasureCircle.Enabled = false;
                pnlMeasureLine.Enabled = false;
                pnlMeasureCircle.Enabled = false;
            }
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

            if (_measureLineParamList.Count <= 0)
                return;

            for (int pair = 0; pair < PAIR; pair++)
            {
                CogRectangleAffine cogRectAffine = new CogRectangleAffine();
                cogRectAffine = _measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region;

                if (_measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region.Selected)
                {
                    cogRectAffine.CenterX += jogMoveX;
                    cogRectAffine.CenterY += jogMoveY;
                }

                cogRectAffine.Interactive = true;
                _measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region = cogRectAffine;

                cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;
                _teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "CALIPER", false);
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

            if (_measureLineParamList.Count <= 0)
                return;

            for (int pair = 0; pair < PAIR; pair++)
            {
                CogRectangleAffine cogRectAffine = new CogRectangleAffine();
                cogRectAffine = _measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region;

                if (_measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region.Selected)
                {
                    cogRectAffine.SideXLength += jogSizeX;
                    cogRectAffine.SideYLength += jogSizeY;
                }

                cogRectAffine.Interactive = true;
                _measureLineParamList[_selectedLineIndex].CogCaliperTool[pair].Region = cogRectAffine;

                cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;
                _teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "CALIPER", false);
            }
        }
        #endregion

        private void ClearGraphic()
        {
            _teachingDisplay.StaticGraphics.Clear();
            _teachingDisplay.InteractiveGraphics.Clear();
        }

        #region Tab Index
        //private void btnPrevTab_Click(object sender, EventArgs e)
        //{
        //    TabPrev();
        //}

        //private void TabPrev()
        //{
        //    if (_tabNo <= 0)
        //    {
        //        _tabNo = 0;
        //        lblTabNo.Text = "TAB " + (_tabNo + 1).ToString();
        //    }
        //    else
        //    {
        //        _tabNo--;
        //        lblTabNo.Text = "TAB " + (_tabNo + 1).ToString();
        //    }

        //    DisplayImage(_tabNo);
        //}

        //private void btnNextTab_Click(object sender, EventArgs e)
        //{
        //    TabNext();
        //}

        //private void TabNext()
        //{
        //    if (_tabNo >= (_tabMaxCount - 1))
        //    {
        //        _tabNo = _tabMaxCount - 1;
        //        lblTabNo.Text = "TAB " + (_tabNo + 1).ToString();
        //    }
        //    else
        //    {
        //        _tabNo++;
        //        lblTabNo.Text = "TAB " + (_tabNo + 1).ToString();
        //    }

        //    DisplayImage(_tabNo);
        //}

        //private void DisplayImage(int tabNumber)
        //{
        //    if (Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabNumber].m_CogLineScanBuf == null)
        //        return;

        //    _teachingDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabNumber].m_CogLineScanBuf;

        //    cogDisplayThumbnail.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabNumber].m_CogLineScanBuf;
        //    cogDisplayThumbnail.Fit();
        //}
        #endregion

        private void CreateObject()
        {
            for (int i = 0; i < PAIR; i++)
                _cogCaliperTool[i] = new CogCaliperTool();

            _cogFindCircleTool = new CogFindCircleTool();
        }

        private void SetMeasureCountProperty()
        {
            _inspectionCount = new InspectionCount();
            _inspectionCount.SetParam(Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo]);
        }

        private void GetLineMeasureProperty()
        {
            _lineCount = Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo].CaliperCount;

            if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList.Count <= 0)
                return;

            _measureLineParamList = Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList.ToList();
        }

        private void GetCircleMeasureProperty()
        {
            _circleCount = Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo].CircleCount;

            if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList.Count <= 0)
                return;

            _measureCircleParamList = Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList.ToList();
        }

        private void SetLineMeasureItemProperty()
        {
            if (_measureLineParamList.Count == 0)
                _measureLineParamList.Add(new MeasureLineParameter());
            for (int i = 0; i < PAIR; i++)
            {
                if (_measureLineParamList[_selectedLineIndex].CogCaliperTool[i] != null)
                    _cogCaliperTool[i] = _measureLineParamList[_selectedLineIndex].CogCaliperTool[i];
            }
        }

        private void SetMeasureCircleItemProperty()
        {
            for (int circleCount = 0; circleCount < _circleCount; circleCount++)
            {
                CogFindCircleTool tt = new CogFindCircleTool();

                _cogFindCircleToolList.Add(tt);

                _cogFindCircleToolList[circleCount] = _measureCircleParamList[circleCount].CogFindCircleTool;
            }
        }

        private void SetComboboxMeasureType()
        {
            lblLinePointValue.Text = _lineCount.ToString();
            lblCirclePointValue.Text = _circleCount.ToString();

            if (_measureType == eMeasureType.Line)
            {
                AddMeasurePointInComboBox(_lineCount);

                //for (int i = 0; i < _lineCount; i++)
                //GetCaliperParameter(i);
                GetCaliperParameter(0);
            }
            else
            {
                AddMeasurePointInComboBox(_circleCount);
                GetCircleParamter(0);
            }
        }        

        private void rdoSetMeasureType_CheckedChanged(object sender, EventArgs e)
        {
            SetSelecteMeasureType(sender);
        }

        private void SetSelecteMeasureType(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("line"))
                {
                    SetMeasureType(eMeasureType.Line);
                    ShowMeasureLine();
                }
                else
                {
                    SetMeasureType(eMeasureType.Circle);
                    ShowMeasureCircle();
                }

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;

            SetComboboxMeasureType();
        }

        private void SetMeasureType(eMeasureType measureType)
        {
            _measureType = measureType;
        }

        private void ShowMeasureLine()
        {
            pnlMeasureCircle.Visible = false;
            pnlMeasureLine.Visible = true;
        }

        private void ShowMeasureCircle()
        {
            pnlMeasureLine.Visible = false;
            pnlMeasureCircle.Visible = true;
        }

        #region Measure Point : Set, Select
        private void lblSetMeasurePointValue_Click(object sender, EventArgs e)
        {
            SetMeasurePoint(sender);
        }

        private void SetMeasurePoint(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10, outputData, "Input Measure Point", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();
            }

            int measurePointIndex = outputData;

            CreateList(measurePointIndex);
            AddMeasurePointInComboBox(measurePointIndex);

           
        }

        private void AddMeasurePointInComboBox(int index)
        {
            cmbLinePointSelect.Items.Clear();
            cmbCirclePointSelect.Items.Clear();

            string point = "";

            switch (_measureType)
            {
                case eMeasureType.Line:
                    cmbLinePointSelect.Items.Clear();
                    for (int i = 0; i < index; i++)
                    {
                        point = "Point_" + i.ToString();
                        cmbLinePointSelect.Items.Add(point);
                    }
                    if(index > 0)
                        cmbLinePointSelect.SelectedIndex = 0;
                    break;

                case eMeasureType.Circle:
                    cmbCirclePointSelect.Items.Clear();
                    for (int i = 0; i < index; i++)
                    {
                        point = "Point_" + i.ToString();
                        cmbCirclePointSelect.Items.Add(point);

                    }
                    if (index > 0)
                        cmbCirclePointSelect.SelectedIndex = 0;
                    break;

                default:
                    break;
            }
        }

        private void CreateList(int index)
        {
            switch (_measureType)
            {
                case eMeasureType.Line:
                    _lineCount = index;
                    if (_measureLineParamList.Count != index)
                    {
                        //_cogCaliperToolList.Clear();
                        _measureLineParamList.Clear();
                        for (int i = 0; i < index; i++)
                        {
                            if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList.Count > i)
                            {
                                MeasureLineParameter param = new MeasureLineParameter();
                                param.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList[i]);
                                _measureLineParamList.Add(param);
                            }
                            else
                            {
                                for (int lineCount = 0; lineCount < index; lineCount++)
                                {
                                    CogCaliperTool[] cogCaliperToolArray = new CogCaliperTool[PAIR];

                                    //for (int pair = 0; pair < PAIR; pair++)
                                    //    cogCaliperToolArray[pair] = new CogCaliperTool();
                                    MeasureLineParameter param = new MeasureLineParameter();
                                    param.SetParam(new MeasureLineParameter());

                                    //_cogCaliperToolList.Add(param);
                                    _measureLineParamList.Add(param);
                                }
                            }
                        }
                    }
                    else
                    {
                        int Cnt = (index + _measureLineParamList.Count) - index;
                        _measureLineParamList.Clear();
                        for (int i = 0; i < index; i++)
                        {
                            if (i < Cnt)
                            {
                                MeasureLineParameter param = new MeasureLineParameter();
                                if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList.Count == 0)
                                {
                                    _measureLineParamList.Add(new MeasureLineParameter());
                                }
                                else
                                {
                                    param.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList[i]);
                                    _measureLineParamList.Add(param);
                                }
                            }
                            else
                            {
                                for (int lineCount = 0; lineCount < index; lineCount++)
                                {
                                    MeasureLineParameter cogCaliperToolArray = new MeasureLineParameter();

                               
                                    //_cogCaliperToolList.Add(cogCaliperToolArray);

                                    _measureLineParam = new MeasureLineParameter();
                                    _measureLineParamList.Add(_measureLineParam);
                                }
                            }
                        }
                    }
                    SetLineMeasureItemProperty();
                    break;

                case eMeasureType.Circle:
                    _circleCount = index;
                    if (_measureCircleParamList.Count != index)
                    {
                        _measureCircleParamList.Clear();
                        for (int i = 0; i < index; i++)
                        {
                            if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList.Count > i)
                            {
                                MeasureCircleParameter param = new MeasureCircleParameter();
                                param.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList[i]);
                                _measureCircleParamList.Add(param);
                            }
                            else
                            {
                                MeasureCircleParameter Params = new MeasureCircleParameter();
                                _measureCircleParamList.Add(Params);
                            }
                        }
                    }
                    else
                    {
                        int Cnt = (index + _measureCircleParamList.Count) - index;
                        _measureLineParamList.Clear();
                        for (int i = 0; i < index; i++)
                        {
                            if (i < Cnt)
                            {
                                MeasureCircleParameter param = new MeasureCircleParameter();
                                param.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList[i]);
                                _measureCircleParamList.Add(param);
                            }
                            else
                            {
                                MeasureCircleParameter Params = new MeasureCircleParameter();
                                _measureCircleParamList.Add(Params);
                            }
                        }
                    }
                    SetMeasureCircleItemProperty();
                    break;

                default:
                    break;
            }
        }

        private void cmbMeasurePointIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearGraphic();
            SetMeasurePointIndex(sender);
            ShowROI();
        }

        private void cmbMeasurePointIndex_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ClearGraphic();
            //SetMeasurePointIndex(sender);
            //ShowROI();
        }

        private void SetMeasurePointIndex(object sender)
        {
            ComboBox cmb = sender as ComboBox;
            
            switch (_measureType)
            {
                case eMeasureType.Line:
                    _selectedLineIndex = cmb.SelectedIndex;
                    SetLineMeasureItemProperty();
                    GetCaliperParameter(_selectedLineIndex);
                    break;

                case eMeasureType.Circle:
                    _selectedCircleIndex = cmb.SelectedIndex;
                    GetCircleParamter(_selectedLineIndex);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Line
        private void lblLineEdgeFilterSizeValue_Click(object sender, EventArgs e)
        {
            SetLineEdgeFilterSize(sender);
        }

        private void SetLineEdgeFilterSize(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Edge Filter Size", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                if (outputData != 0)
                {
                    lbl.Text = outputData.ToString();

                    if (lbl.Name.ToString().Contains("1"))
                        //_cogCaliperTool[0].RunParams.FilterHalfSizeInPixels = outputData;
                        //_cogCaliperToolList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge1].RunParams.FilterHalfSizeInPixels = outputData;
                        _measureLineParamList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge1].RunParams.FilterHalfSizeInPixels = outputData;
                    else
                        //_cogCaliperTool[1].RunParams.FilterHalfSizeInPixels = outputData;
                        //_cogCaliperToolList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge2].RunParams.FilterHalfSizeInPixels = outputData;
                        _measureLineParamList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge2].RunParams.FilterHalfSizeInPixels = outputData;
                }

                int gg = 0;
            }
        }

        private void lblLineEdgeThresholdValue_Click(object sender, EventArgs e)
        {
            SetLineEdgeThredshold(sender);
        }

        private void SetLineEdgeThredshold(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, outputData, "Input Edge Threshold", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();

                if (lbl.Name.ToString().Contains("1"))
                    //_cogCaliperTool[0].RunParams.ContrastThreshold = outputData;
                    //_cogCaliperToolList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge1].RunParams.ContrastThreshold = outputData;
                    _measureLineParamList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge1].RunParams.ContrastThreshold = outputData;
                else
                    //_cogCaliperTool[1].RunParams.ContrastThreshold = outputData;
                    //_cogCaliperToolList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge2].RunParams.ContrastThreshold = outputData;
                    _measureLineParamList[_selectedLineIndex].CogCaliperTool[(int)ePair.Edge2].RunParams.ContrastThreshold = outputData;
            }
        }

        private void rdoSetLineEdgePolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectEdgePolarity(sender);
        }

        #endregion

        #region Circle
        private void lblCircleProjectionLengthValue_Click(object sender, EventArgs e)
        {
            SetCircleProjectionLength(sender);
            FindCircleROI();
        }

        private void SetCircleProjectionLength(object sender)
        {
            Label lbl = sender as Label;

            double outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Projection Length", 1))
            {
                form_keypad.ShowDialog();
                outputData = form_keypad.m_data;
                lbl.Text = outputData.ToString("F3");
                _cogFindCircleToolList[_selectedCircleIndex].RunParams.CaliperProjectionLength = outputData;
            }
        }

        private void SetCircleSearchDirection(CogFindCircleSearchDirectionConstants searchDirection)
        {
            if (_cogFindCircleToolList.Count <= 0)
                return;

            _cogFindCircleToolList[_selectedCircleIndex].RunParams.CaliperSearchDirection = searchDirection;
        }

        private void lblCircleSearchLengthValue_Click(object sender, EventArgs e)
        {
            SetCircleSearchLength(sender);
            FindCircleROI();
        }

        private void SetCircleSearchLength(object sender)
        {
            Label lbl = sender as Label;

            double outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Search Length", 1))
            {
                form_keypad.ShowDialog();
                outputData = form_keypad.m_data;
                lbl.Text = outputData.ToString("F3");
                _cogFindCircleToolList[_selectedCircleIndex].RunParams.CaliperSearchLength = outputData;
            }
        }

        private void lblCircleContrastValue_Click(object sender, EventArgs e)
        {
            SetCircleContrast(sender);
        }

        private void SetCircleContrast(object sender)
        {
            Label lbl = sender as Label;

            double outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, outputData, "Input Contrast", 1))
            {
                form_keypad.ShowDialog();
                outputData = (double)form_keypad.m_data;
                lbl.Text = outputData.ToString();
                _cogFindCircleToolList[_selectedCircleIndex].RunParams.CaliperRunParams.ContrastThreshold = outputData;
            }
        }
        private void rdoSetCircleSearchDirction_CheckedChaged(object sender, EventArgs e)
        {
            SetSelectSearchDirection(sender);
            FindCircleROI();
        }

        private void rdoSetCircleEdgePolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectEdgePolarity(sender);
        }

        private void lblCircleCaliperNumberValue_Click(object sender, EventArgs e)
        {
            SetCircleCaliperNumber(sender);
        }

        private void GetCircleParamter(int index)
        {
            if (_measureCircleParamList.Count <= 0)
                return;

            if (_measureCircleParamList[index].CogFindCircleTool == null)
                return;

            lblCircleProjectionLengthValue.Text = _cogFindCircleToolList[index].RunParams.CaliperProjectionLength.ToString("F3");
            lblCircleSearchLengthValue.Text = _cogFindCircleToolList[index].RunParams.CaliperSearchLength.ToString("F3");
            lblCircleContrastValue.Text = _cogFindCircleToolList[index].RunParams.CaliperRunParams.ContrastThreshold.ToString();
            lblCircleCaliperNumberValue.Text = _cogFindCircleToolList[index].RunParams.NumCalipers.ToString();
            lblCircleIgnoreNumberValue.Text = _cogFindCircleToolList[index].RunParams.NumToIgnore.ToString();

            if (_cogFindCircleToolList[index].RunParams.CaliperRunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                rdoCircleEdgeDarkToLight.Checked = true;
            else
                rdoCircleEdgeLightToDark.Checked = true;

            if (_cogFindCircleToolList[index].RunParams.CaliperSearchDirection == CogFindCircleSearchDirectionConstants.Inward)
                rdoCircleSearchInward.Checked = true;
            else
                rdoCircleSearchOutward.Checked = true;
        }

        private void GetCaliperParameter(int index)
        {
            if (_measureLineParamList.Count <= 0)
                return;

            //if (_cogCaliperToolList.Count <= 0)
            //    return;
            if(_measureLineParamList[index].CogCaliperTool[(int)ePair.Edge1] != null)
            {
                lblLine1EdgeFilterSizeValue.Text = _measureLineParamList[index].CogCaliperTool[(int)ePair.Edge1].RunParams.FilterHalfSizeInPixels.ToString();
                lblLine1EdgeThresholdValue.Text = _measureLineParamList[index].CogCaliperTool[(int)ePair.Edge1].RunParams.ContrastThreshold.ToString();
                if (_measureLineParamList[index].CogCaliperTool[(int)ePair.Edge1].RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                    rdoLine1EdgeDarkToLight.Checked = true;
                else
                    rdoLine1EdgeLightToDark.Checked = true;
            }
            if (_measureLineParamList[index].CogCaliperTool[(int)ePair.Edge2] != null)
            {
                lblLine2EdgeFilterSizeValue.Text = _measureLineParamList[index].CogCaliperTool[(int)ePair.Edge2].RunParams.FilterHalfSizeInPixels.ToString();
                lblLine2EdgeThresholdValue.Text = _measureLineParamList[index].CogCaliperTool[(int)ePair.Edge2].RunParams.ContrastThreshold.ToString();
                if (_measureLineParamList[index].CogCaliperTool[(int)ePair.Edge2].RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                    rdoLine2EdgeDarkToLight.Checked = true;
                else
                    rdoLine2EdgeLightToDark.Checked = true;
            }

        }

        private void SetCircleCaliperNumber(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Contrast", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();
                _cogFindCircleToolList[_selectedCircleIndex].RunParams.NumCalipers = outputData;
                FindCircleROI();
            }
        }

        private void FindCircleROI()
        {
            ClearGraphic();
            if (_teachingDisplay.Image == null) return;
            _cogFindCircleToolList[_selectedCircleIndex].InputImage = (CogImage8Grey)_teachingDisplay.Image;
            CogCircularArc circlarArc = new CogCircularArc(_cogFindCircleToolList[_selectedCircleIndex].RunParams.ExpectedCircularArc);
            if (_cogFindCircleToolList[_selectedCircleIndex].RunParams.ExpectedCircularArc.CenterX <= 150 && (_cogFindCircleToolList[_selectedCircleIndex].RunParams.ExpectedCircularArc.CenterY <= 50))
            {
                circlarArc.CenterX = (_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX);
                circlarArc.CenterY = (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY);
            }
            _cogFindCircleToolList[_selectedCircleIndex].RunParams.ExpectedCircularArc = circlarArc;
            _cogFindCircleToolList[_selectedCircleIndex].CurrentRecordEnable = CogFindCircleCurrentRecordConstants.InputImage | CogFindCircleCurrentRecordConstants.CaliperRegions | CogFindCircleCurrentRecordConstants.ExpectedCircularArc |
                                                           CogFindCircleCurrentRecordConstants.InteractiveCaliperSize;
            SetInteractiveGraphics(_cogFindCircleToolList[_selectedCircleIndex].CreateCurrentRecord(), false);
        }

        private void lblCircleIgnoreNumberValue_Click(object sender, EventArgs e)
        {
            SetCircleIgnoreNumber(sender);
        }

        private void SetCircleIgnoreNumber(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, outputData, "Input Contrast", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();
                _cogFindCircleToolList[_selectedCircleIndex].RunParams.NumToIgnore = outputData;
            }
        }
        #endregion
        
        #region Edge Polarity
        private void SetSelectSearchDirection(object sender)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("inward"))
                    SetCircleSearchDirection(CogFindCircleSearchDirectionConstants.Inward);
                else
                    SetCircleSearchDirection(CogFindCircleSearchDirectionConstants.Outward);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetSelectEdgePolarity(object sender)
        {
            RadioButton btn = sender as RadioButton;

            ePair edgeNo;

            if (btn.Name.ToLower().Contains("1"))
                edgeNo = ePair.Edge1;
            else
                edgeNo = ePair.Edge2;

            if (btn.Checked)
            {
                if (btn.Name.ToLower().Contains("darktolight"))
                    SetEdgePolarity(CogCaliperPolarityConstants.DarkToLight, edgeNo);
                else
                    SetEdgePolarity(CogCaliperPolarityConstants.LightToDark, edgeNo);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetEdgePolarity(CogCaliperPolarityConstants edgePolarity, ePair edgeNo)
        {
            switch (_measureType)
            {
                case eMeasureType.Line:
                    if (_measureLineParamList.Count <= 0)
                        return;

                    _measureLineParamList[_selectedLineIndex].CogCaliperTool[(int)edgeNo].RunParams.Edge0Polarity = edgePolarity;
                    break;

                case eMeasureType.Circle:
                    if (_cogFindCircleToolList.Count <= 0)
                        return;

                    _cogFindCircleToolList[_selectedLineIndex].RunParams.CaliperRunParams.Edge0Polarity = edgePolarity;
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Show ROI
        private void btnROIShow_Click(object sender, EventArgs e)
        {
            ShowROI();
        }

        private void ShowROI()
        {
            switch (_measureType)
            {
                case eMeasureType.Line:
                    ShowCaliperROI();
                    break;

                case eMeasureType.Circle:
                    FindCircleROI();
                    break;

                default:
                    break;
            }
        }

        private void ShowCaliperROI()
        {
            ClearGraphic();

            //if (_cogCaliperToolList.Count <= 0)
            //    return;

            if (_teachingDisplay.Image == null)
                return;

            for (int pair = 0; pair < PAIR; pair++)
            {
               // _cogCaliperToolList[_selectedLineIndex].CogCaliperTool[pair].InputImage = _teachingDisplay.Image;
                _cogCaliperTool[pair].InputImage = _teachingDisplay.Image;
                CogRectangleAffine cogRectAffine = new CogRectangleAffine();

                //cogRectAffine = _cogCaliperToolList[_selectedLineIndex].CogCaliperTool[pair].Region;
                cogRectAffine = _cogCaliperTool[pair].Region;
                _cogGraphicLabel[pair].X = cogRectAffine.CornerXX;
                _cogGraphicLabel[pair].Y = cogRectAffine.CornerXY;
                _cogGraphicLabel[pair].Color = CogColorConstants.Orange;
                _cogGraphicLabel[pair].Interactive = false;
                _cogGraphicLabel[pair].Text = "POINT" + (pair + 1).ToString();

                cogRectAffine.Interactive = true;
                cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;

                //if (_cogCaliperToolList[_selectedLineIndex].CogCaliperTool[pair].Region.CenterX == 70 && _cogCaliperToolList[_selectedLineIndex].CogCaliperTool[pair].Region.CenterY == 30)
                //{
                //    cogRectAffine.SetCenterLengthsRotationSkew((_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX), (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY) + 100 * pair,
                //            cogRectAffine.SideXLength, cogRectAffine.SideYLength, cogRectAffine.Rotation, cogRectAffine.Skew);
                //}

                if (_cogCaliperTool[pair].Region.CenterX == 70 && _cogCaliperTool[pair].Region.CenterY == 30)
                {
                    cogRectAffine.SetCenterLengthsRotationSkew((_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX), (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY) + 100 * pair,
                            cogRectAffine.SideXLength, cogRectAffine.SideYLength, cogRectAffine.Rotation, cogRectAffine.Skew);
                }
                _teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "CALIPER", false);
                _teachingDisplay.InteractiveGraphics.Add(_cogGraphicLabel[pair], "Name", false);
                _cogCaliperTool[pair].Region = cogRectAffine;
            }
        }
        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            if (_measureType == eMeasureType.Line)
            {
                if (_lineCount <= 0)
                    return;

                _inspectionCount.CaliperCount = _lineCount;

                for (int lineCount = 0; lineCount < _lineCount; lineCount++)
                {
                    MeasureLineParameter lineParam = new MeasureLineParameter();
                    lineParam.CogCaliperTool = _measureLineParamList[lineCount].CogCaliperTool;
                    _measureLineParamList[lineCount] = lineParam.Copy();
                }
            }
            else
            {
                if (_circleCount <= 0)
                    return;

                _inspectionCount.CircleCount = _circleCount;

                for (int circleCount = 0; circleCount < _circleCount; circleCount++)
                {
                    MeasureCircleParameter circleParam = new MeasureCircleParameter();
                    circleParam.CogFindCircleTool = _cogFindCircleToolList[circleCount];
                    _measureCircleParamList[circleCount] = circleParam.Copy();
                }
            }
        }

        private void btnMeasureTest_Click(object sender, EventArgs e)
        {
            ExecuteMeasure();
        }

        private void ExecuteMeasure()
        {
            switch (_measureType)
            {
                case eMeasureType.Line:
                    ExcuteCaliper();
                    break;

                case eMeasureType.Circle:
                    ExcuteFindCircle(_cogFindCircleToolList[_selectedCircleIndex]);
                    break;

                default:
                    break;
            }
        }

        private void ExcuteCaliper()
        {
            ClearGraphic();

            PointF[] resultPoint = new PointF[2];
            double distance = CalculateDistance(resultPoint);

            string resultMessage = string.Empty;
            string errorMessage = string.Empty;

            CogGraphicInteractiveCollection cogGraphic = new CogGraphicInteractiveCollection();

            // Run Caliper
            for (int pair = 0; pair < PAIR; pair++)
            {
                _cogCaliperTool[pair].InputImage = _teachingDisplay.Image;
                _cogCaliperTool[pair].Run();

                if (_cogCaliperTool[pair].Results.Count > 0)
                {
                    resultPoint[pair].X = (float)_cogCaliperTool[pair].Results[0].PositionX;
                    resultPoint[pair].Y = (float)_cogCaliperTool[pair].Results[0].PositionY;
                    cogGraphic.Add(_cogCaliperTool[pair].Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));

                    WriteLabel(pair);
                }
                else
                {
                    errorMessage = "Point " + (pair + 1).ToString() + " search failed";
                    //DrawLabel(_teachingDisplay, errorMessage, pair);
                    FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, errorMessage, pair);
                }
            }

            // Calculate Distance
            if (_cogCaliperTool[0].Results.Count > 0 && _cogCaliperTool[1].Results.Count > 0)
            {
                distance = CalculateDistance(resultPoint);

                resultMessage = string.Format("Point 1 X:{0:F3} Y:{1:F3}", resultPoint[0].X, resultPoint[0].Y);
                //DrawLabel(_teachingDisplay, resultMessage,0);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 0);

                resultMessage = string.Format("Point 2 X:{0:F3} Y:{1:F3}", resultPoint[1].X, resultPoint[1].Y);
                //DrawLabel(_teachingDisplay, resultMessage,1);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 1);

                resultMessage = string.Format("Distance: {0:F3} mm", distance);
                //DrawLabel(_teachingDisplay, resultMessage,2);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 2);

                DrawLineThroughTwoPoints(_teachingDisplay, resultPoint);
            }

            _teachingDisplay.Image.SelectedSpaceName = "@";
            _teachingDisplay.InteractiveGraphics.AddList(cogGraphic, "Result", false);
        }

        private void WriteLabel(int pair)
        {
            CogRectangleAffine cogRectAffine = new CogRectangleAffine();

            cogRectAffine = _cogCaliperTool[pair].Region;
            _cogGraphicLabel[pair].X = cogRectAffine.CenterX;
            _cogGraphicLabel[pair].Y = cogRectAffine.CenterY;
            _cogGraphicLabel[pair].Color = CogColorConstants.Orange;
            _cogGraphicLabel[pair].Interactive = false;
            _cogGraphicLabel[pair].Text = "POINT" + (pair + 1).ToString();

            cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;
            cogRectAffine.Interactive = true;

            //_teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "CALIPER", false);
            _teachingDisplay.InteractiveGraphics.Add(_cogGraphicLabel[pair], "Name", false);
            _cogCaliperTool[pair].Region = cogRectAffine;
        }

        private double CalculateDistance(PointF[] ResultPoint)
        {
            double distance = 0.0;

            double dx = ResultPoint[1].X - ResultPoint[0].X;
            double dy = ResultPoint[1].Y - ResultPoint[0].Y;

            distance = Math.Abs(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
            distance = distance * (Settings.Instance().Operation.LineScanPixelSize / Settings.Instance().Operation.LensMagnification);

            return distance;
        }

        private void DrawLineThroughTwoPoints(CogRecordDisplay cogRecordDisplay, PointF[] point)
        {
            if (point.Length == 2)
            {
                CogDistancePointPointTool cogDistanceTool = new CogDistancePointPointTool();

                cogDistanceTool.StartX = point[0].X;
                cogDistanceTool.StartY = point[0].Y;

                cogDistanceTool.EndX = point[1].X;
                cogDistanceTool.EndY = point[1].Y;

                cogDistanceTool.InputImage = cogRecordDisplay.Image;
                cogDistanceTool.Run();

                SetInteractiveGraphics(cogDistanceTool.CreateLastRunRecord(), false);
            }
        }

        private void ExcuteFindCircle(CogFindCircleTool cogFindCicle)
        {
            //_cogCaliperToolList[_selectedLineIndex]
            ClearGraphic();
            CogGraphicInteractiveCollection Resultgraph = new CogGraphicInteractiveCollection();
            double CenterX, CenterY, Radius;

            cogFindCicle.InputImage = (CogImage8Grey)_teachingDisplay.Image;
            cogFindCicle.Run();
            
            if (cogFindCicle.Results.GetCircle() != null)
            {

                CenterX = cogFindCicle.Results.GetCircle().CenterX;
                CenterY = cogFindCicle.Results.GetCircle().CenterY;
                Radius = cogFindCicle.Results.GetCircle().Radius;

                SetInteractiveGraphics(cogFindCicle.CreateLastRunRecord(), false);

                string resultMessage = string.Empty;

                resultMessage = string.Format("CenterX: {0:F3}", CenterX);
                //DrawLabel(_teachingDisplay, strResult, 0);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 0);

                resultMessage = string.Format("CenterY: {0:F3}", CenterY);
                //DrawLabel(_teachingDisplay, strResult, 1);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 1);

                resultMessage = string.Format("Radius {0:F3}", Radius);
                //DrawLabel(_teachingDisplay, strResult, 2);
                FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, resultMessage, 2);
            }
        }

        //private void ExcuteFindCircle(CogFindCircleTool cogFindCicle)
        //{
        //    CogGraphicInteractiveCollection Resultgraph = new CogGraphicInteractiveCollection();
        //    double CenterX, CenterY, Radius;

        //    //////////Find Circle Params//////////////////////////
        //    cogFindCicle.RunParams.CaliperRunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
        //    cogFindCicle.RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
        //    cogFindCicle.RunParams.CaliperProjectionLength = 40;
        //    cogFindCicle.RunParams.CaliperSearchDirection = CogFindCircleSearchDirectionConstants.Inward;
        //    cogFindCicle.RunParams.NumCalipers = 10;
        //    cogFindCicle.RunParams.NumToIgnore = 1;
        //    cogFindCicle.RunParams.CaliperProjectionLength = 35;
        //    cogFindCicle.RunParams.CaliperRunParams.FilterHalfSizeInPixels = 5;
        //    /////////////////////////////////////////////////////////////////////////

        //    cogFindCicle.Run();

        //    if (cogFindCicle.Results.Count > 0)
        //    {
        //        CenterX = cogFindCicle.Results.GetCircle().CenterX;
        //        CenterY = cogFindCicle.Results.GetCircle().CenterY;
        //        Radius = cogFindCicle.Results.GetCircle().Radius;
        //    }
        //}

        private void SaveParams()
        {
            Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo] = _inspectionCount.Copy();

            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList.Clear();
            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureLineParamList = _measureLineParamList.ToList();

            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList.Clear();
            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].MeasureCircleParamList = _measureCircleParamList.ToList();
        }

        public void Save()
        {
            SaveParams();

            string filePath = Main.DEFINE.SYS_DATADIR + Main.DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            string strFileName = string.Format("\\MeasureCount_Cam{0:D}_Stage{1:D}", _camNo, _stageNo);
            filePath += strFileName;
            _inspectionCount.SaveXml(filePath);

            filePath = Main.DEFINE.SYS_DATADIR + Main.DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MEASURE\\Caliper\\";
            for (int i=0; i<_lineCount; i++)
            {
                _measureLineParamList[i].SaveVPP(filePath, (int)_camNo, (int)_stageNo, i);
                _measureLineParamList[i].SaveXml(filePath, (int)_camNo, (int)_stageNo, i);
            }

            filePath = Main.DEFINE.SYS_DATADIR + Main.DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\MEASURE\\Circle\\";
            for (int i = 0; i < _circleCount; i++)
            {
                _measureCircleParamList[i].SaveVPP(filePath, (int)_camNo, (int)_stageNo, i);
                _measureCircleParamList[i].SaveXml(filePath, (int)_camNo, (int)_stageNo, i);
            }
        }

        private void DrawLabel(CogRecordDisplay cogDisplay, string resultText, int index = 0)
        {
            CogGraphicLabel cogLabel = new CogGraphicLabel();

            float fontSize = 0;
            double baseZoomX = 0;
            double baseZoomY = 0;

            if ((double)cogDisplay.Width / cogDisplay.Image.Width < (double)cogDisplay.Height / cogDisplay.Image.Height)
            {
                baseZoomX = ((double)cogDisplay.Width) / cogDisplay.Image.Width;
                baseZoomY = ((double)cogDisplay.Height) / cogDisplay.Image.Height;
                fontSize = (float)((cogDisplay.Image.Width / Main.DEFINE.FontSize) * baseZoomX);
            }
            else
            {
                baseZoomX = ((double)cogDisplay.Width) / cogDisplay.Image.Width;
                baseZoomY = ((double)cogDisplay.Height) / cogDisplay.Image.Height;
                fontSize = (float)((cogDisplay.Image.Width / Main.DEFINE.FontSize) * baseZoomX);
            }

            double fontPitch = (fontSize / cogDisplay.Zoom);

            cogLabel.Text = resultText;
            cogLabel.Color = CogColorConstants.Cyan;
            cogLabel.Font = new Font(Main.DEFINE.FontStyle, fontSize);
            cogLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;

            cogLabel.X = (cogDisplay.Image.Width - (cogDisplay.Image.Width / (cogDisplay.Zoom / baseZoomX))) / 2 - cogDisplay.PanX;
            cogLabel.Y = (cogDisplay.Image.Height - (cogDisplay.Image.Height / (cogDisplay.Zoom / baseZoomY))) / 2 - cogDisplay.PanY + (index * fontPitch);

            cogDisplay.StaticGraphics.Add(cogLabel as ICogGraphic, "Result Text");
        }

        public void SetInteractiveGraphics(ICogRecord _ICogRecord, bool _bGraphicIndex)
        {
            foreach (Cognex.VisionPro.Implementation.CogRecord _record in _ICogRecord.SubRecords)
            {
                if (typeof(ICogImage).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        _teachingDisplay.Image = (ICogImage)_record.Content;
                    }
                }
                else if (typeof(ICogGraphic).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        _teachingDisplay.InteractiveGraphics.Add(_record.Content as ICogGraphicInteractive, _bGraphicIndex ? "Result0" : "Result1", false);
                    }
                }
                else if (typeof(CogGraphicCollection).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        CogGraphicCollection graphics = _record.Content as CogGraphicCollection;
                        foreach (ICogGraphic graphic in graphics)
                        {
                            //graphic.Color = CogColorConstants.Red;
                            _teachingDisplay.InteractiveGraphics.Add(graphic as ICogGraphicInteractive, _bGraphicIndex ? "Result0" : "Result1", false);
                        }
                    }
                }
                else if (typeof(CogGraphicInteractiveCollection).IsAssignableFrom(_record.ContentType))
                {
                    if (_record.Content != null)
                    {
                        _teachingDisplay.InteractiveGraphics.AddList(_record.Content as CogGraphicInteractiveCollection, _bGraphicIndex ? "Result0" : "Result1", false);
                    }
                }

                SetInteractiveGraphics(_record, _bGraphicIndex);
            }
        }

        private void ROITracking()
        {
            _teachingDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            CogGraphicInteractiveCollection ResultGraphy = new CogGraphicInteractiveCollection();
            PointF LeftTranslationData, RightTranslationData, LeftOriginData, RightOriginData;
            if (!Main.MarkSearch((CogImage8Grey)_teachingDisplay.Image, out LeftTranslationData, out RightTranslationData, out LeftOriginData, out RightOriginData, ref ResultGraphy)) return ;

            // Step2 Theta Calculation
            double RotT = 0;
            Main.CalculateRotion(LeftOriginData, RightOriginData, LeftTranslationData, RightTranslationData, out RotT);
            CogImage8Grey FixtureImage = new CogImage8Grey();

            // Step3 Image Point Translation
            if(Main.ExcuteFixture((CogImage8Grey)_teachingDisplay.Image, LeftTranslationData, RotT, out FixtureImage) == true)
                _teachingDisplay.Image = FixtureImage;

            _teachingDisplay.InteractiveGraphics.AddList(ResultGraphy, "Result", false);
        }

        private void chkROITracking_CheckedChanged(object sender, EventArgs e)
        {
            SetROITracking(sender);
        }

        private void SetROITracking(object sender)
        {
            ClearGraphic();

            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
                ROITracking();
            else
                _teachingDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
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
                cmb.ItemHeight = lblLineCount.Height - 7;

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
    }
}
