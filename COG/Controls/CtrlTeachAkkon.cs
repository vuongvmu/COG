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
using static COG.Main;
using AW;
using Cognex.VisionPro.ImageFile;
using COG.Class;
using static COG.Controls.CtrlTeachROIJog;

namespace COG.Controls
{
    public partial class CtrlTeachAkkon : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();
        private AkkonTagData[] _akkonTagData = new AkkonTagData[DEFINE.TAB_NUM];
        

        private int _tabNo = 0;
        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        private int _groupNo = 0;
        private int _groupCount = 0;

        private Main.LeadGroupInfo[] _leadGroupInfo;
        private List<List<CogRectangleAffine>> GroupListLeadData = new List<List<CogRectangleAffine>>();

        private CogRectangleAffine _cogRectNewROI;
        private int _roiWidth = 0;
        private int _roiHeight = 0;

        private double _leadPitch = 1;
        private int _leadCount = 1;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_Scan_Start;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        private eParameterType _parameterType = eParameterType.GROUP;
        public enum eParameterType
        {
            GROUP,
            BUMP,
            ENGINEER_PARAMETER,
            MAKER_PARAMETER,
            OPTION,
        }

        private eCopyDirection _copyDirection = eCopyDirection.Horizontal;
        private enum eCopyDirection
        {
            Horizontal,
            Vertical,
        }

        public CtrlTeachAkkon(eTeachingPosition teachingPosition)
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
                    _camNo = eCameraNo.PreAlign;
                    break;

                default:
                    break;
            }
        }

        private void CtrlTeachAkkon_Load(object sender, EventArgs e)
        {
            AddControl();

            SetAkkonProperty();
            SetLeadProperty();

            InitializeUI();
            GetAkkonParameter();
        }

        private void AddControl()
        {
            // Display
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;
        }

        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            // Checked Radio Button
            rdoAkkonROI.Checked = true;
            rdoGroup.Checked = true;
            rdoCopyHorizontal.Checked = true;

            // Authority
            if (Main.Instance().Authority != eAuthority.Maker)
                rdoMakerParmeter.Enabled = false;
            else
                rdoMakerParmeter.Enabled = true;

            // Parameter Panel Dock
            this.pnlGroup.Dock = DockStyle.Fill;
            this.pnlEngineerParameter.Dock = DockStyle.Fill;
            this.pnlMakerParameter.Dock = DockStyle.Fill;
            this.pnlOption.Dock = DockStyle.Fill;

            // Inspection Type
            foreach (MakerParameter.eInspectionType item in Enum.GetValues(typeof(MakerParameter.eInspectionType)))
                cmbInspectionType.Items.Add(item.ToString().ToUpper());

            // Panel Type
            foreach (MakerParameter.ePanelType item in Enum.GetValues(typeof(MakerParameter.ePanelType)))
                cmbPanelType.Items.Add(item.ToString().ToUpper());

            // Target Type
            foreach (MakerParameter.eTargetType item in Enum.GetValues(typeof(MakerParameter.eTargetType)))
                cmbTargetType.Items.Add(item.ToString().ToUpper());

            // Filter Type
            foreach (MakerParameter.eFilterType item in Enum.GetValues(typeof(MakerParameter.eFilterType)))
                cmbFilterType.Items.Add(item.ToString().ToUpper());

            // Filter Direction
            foreach (MakerParameter.eFilterDirection item in Enum.GetValues(typeof(MakerParameter.eFilterDirection)))
                cmbFilterDirection.Items.Add(item.ToString().ToUpper());

            // Shadow Direction
            foreach (MakerParameter.eShadowDirection item in Enum.GetValues(typeof(MakerParameter.eShadowDirection)))
                cmbShadowDirection.Items.Add(item.ToString().ToUpper());

            // Peak Property
            foreach (MakerParameter.ePeakProperty item in Enum.GetValues(typeof(MakerParameter.ePeakProperty)))
                cmbPeakProperty.Items.Add(item.ToString().ToUpper());

            // Strength Base
            foreach (MakerParameter.eStrengthBase item in Enum.GetValues(typeof(MakerParameter.eStrengthBase)))
                cmbStrengthBase.Items.Add(item.ToString().ToUpper());

            // Threshold Mode
            foreach (MakerParameter.eThresholdMode item in Enum.GetValues(typeof(MakerParameter.eThresholdMode)))
                cmbThresholdMode.Items.Add(item.ToString().ToUpper());
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

            CogGraphicInteractiveCollection ROIGraph = new CogGraphicInteractiveCollection();
            int CellCount = dgvAkkonROI.GetCellCount(DataGridViewElementStates.Selected);
            if (CellCount > 0)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    string data = row.Cells[0].Value.ToString();

                    if (_parameterType == eParameterType.GROUP)
                    {
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CenterX += jogMoveX;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CenterY += jogMoveY;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;

                        for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
                        {
                            GroupListLeadData[_groupNo][leadIndex].Interactive = false;
                            ROIGraph.Add(GroupListLeadData[_groupNo][leadIndex]);

                            CogGraphicLabel cogLabel = new CogGraphicLabel();
                            cogLabel.Color = CogColorConstants.Green;
                            cogLabel.Font = new Font(Main.DEFINE.FontStyle, 10);
                            cogLabel.Text = "[" + (leadIndex + 1).ToString() + "]";
                            cogLabel.X = (GroupListLeadData[_groupNo][leadIndex].CornerOppositeX + GroupListLeadData[_groupNo][leadIndex].CornerYX) / 2;
                            cogLabel.Y = GroupListLeadData[_groupNo][leadIndex].CornerYY + 40;
                            ROIGraph.Add(cogLabel);
                        }

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";

                        _teachingDisplay.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                        ROIGraph.Clear();
                    }
                    else if (_parameterType == eParameterType.BUMP)
                    {
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterX += jogMoveX;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterY += jogMoveY;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;

                        for (int leadIndex = 0; leadIndex < dgvAkkonROI.RowCount; leadIndex++)
                        {
                            _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].Interactive = false;
                            ROIGraph.Add(_akkonTagData[_tabNo].AkkonBumpROIList[leadIndex]);

                            CogGraphicLabel cogLabel = new CogGraphicLabel();
                            cogLabel.Color = CogColorConstants.Green;
                            cogLabel.Font = new Font(Main.DEFINE.FontStyle, 10);
                            cogLabel.Text = "[" + (leadIndex + 1).ToString() + "]";
                            cogLabel.X = (_akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerOppositeX + _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerYX) / 2;
                            cogLabel.Y = _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerYY + 40;
                            ROIGraph.Add(cogLabel);
                        }

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";

                        _teachingDisplay.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                        ROIGraph.Clear();
                    }
                    else { }
                }
            }
            else
            {
                if (_cogRectNewROI != null)
                {
                    _cogRectNewROI.CenterX += jogMoveX;
                    _cogRectNewROI.CenterY += jogMoveY;
                    _cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    _cogRectNewROI.Interactive = true;
                    _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);
                }
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

            CogGraphicInteractiveCollection ROIGraph = new CogGraphicInteractiveCollection();
            int CellCount = dgvAkkonROI.GetCellCount(DataGridViewElementStates.Selected);
            if (CellCount > 0)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    string data = row.Cells[0].Value.ToString();

                    if (_parameterType == eParameterType.GROUP)
                    {
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].SideXLength += jogSizeX;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].SideYLength += jogSizeY;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].Interactive = false;

                        for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
                        {
                            GroupListLeadData[_groupNo][leadIndex].Interactive = false;
                            ROIGraph.Add(GroupListLeadData[_groupNo][leadIndex]);

                            CogGraphicLabel cogLabel = new CogGraphicLabel();
                            cogLabel.Color = CogColorConstants.Green;
                            cogLabel.Font = new Font(Main.DEFINE.FontStyle, 10);
                            cogLabel.Text = "[" + (leadIndex + 1).ToString() + "]";
                            cogLabel.X = (GroupListLeadData[_groupNo][leadIndex].CornerOppositeX + GroupListLeadData[_groupNo][leadIndex].CornerYX) / 2;
                            cogLabel.Y = GroupListLeadData[_groupNo][leadIndex].CornerYY + 40;
                            ROIGraph.Add(cogLabel);
                        }

                        _teachingDisplay.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                        ROIGraph.Clear();

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                    }
                    else if (_parameterType == eParameterType.BUMP)
                    {
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideXLength += jogSizeX;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideYLength += jogSizeY;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;

                        for (int leadIndex = 0; leadIndex < dgvAkkonROI.RowCount; leadIndex++)
                        {
                            _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].Interactive = false;
                            ROIGraph.Add(_akkonTagData[_tabNo].AkkonBumpROIList[leadIndex]);

                            CogGraphicLabel labROINo = new CogGraphicLabel();
                            labROINo.Color = CogColorConstants.Green;
                            labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                            labROINo.Text = "[" + (leadIndex + 1).ToString() + "]";
                            labROINo.X = (_akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerOppositeX + _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerYX) / 2;
                            labROINo.Y = _akkonTagData[_tabNo].AkkonBumpROIList[leadIndex].CornerYY + 40;
                            ROIGraph.Add(labROINo);
                        }

                        _teachingDisplay.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                        ROIGraph.Clear();

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                    }
                    else { }
                }
            }
            else
            {
                if (_cogRectNewROI != null)
                {
                    _cogRectNewROI.CenterX += jogSizeX;
                    _cogRectNewROI.CenterY += jogSizeY;
                    _cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    _cogRectNewROI.Interactive = true;
                    _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);
                }
            }
        }

        public void SkewROIJog(eSkewType skewType)
        {
            double skewUnit = Convert.ToDouble(FormMain.Instance().SelectUnitForm.VisionTeachForm.ROIJogForm.ROIJogControl.lblJogScale.Text) / 1000;
            skewUnit /= _teachingDisplay.Zoom;

            bool isZero = false;

            switch (skewType)
            {
                case eSkewType.CCW:
                    skewUnit *= -1;
                    break;

                case eSkewType.Zero:
                    isZero = true;
                    break;

                case eSkewType.CW:
                    skewUnit *= 1;
                    break;

                default:
                    break;
            }

            int CellCount = dgvAkkonROI.GetCellCount(DataGridViewElementStates.Selected);
            if (CellCount > 0)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    if (_parameterType == eParameterType.GROUP)
                    {
                        string data = row.Cells[0].Value.ToString();

                        if (!isZero)
                            GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].Skew += skewUnit;
                        else
                            GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].Skew = 0;

                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].Interactive = false;

                        _teachingDisplay.InteractiveGraphics.Add(GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1], "AKKON", false);

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[_groupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                    }
                    else if (_parameterType == eParameterType.BUMP)
                    {
                        string data = row.Cells[0].Value.ToString(); // row의 컬럼

                        if (!isZero)
                            _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Skew += skewUnit;
                        else
                            _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Skew = 0;

                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;

                        _teachingDisplay.InteractiveGraphics.Add(_akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)], "AKKON", false);

                        dgvAkkonROI[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        dgvAkkonROI[1, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginY.ToString("0.0") + ")";
                        dgvAkkonROI[2, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXY.ToString("0.0") + ")";
                        dgvAkkonROI[3, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeY.ToString("0.0") + ")";
                        dgvAkkonROI[4, Convert.ToInt32(data) - 1].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYY.ToString("0.0") + ")";
                    }
                    else { }
                }
            }
            else
            {
                if (_cogRectNewROI != null)
                    _cogRectNewROI.Skew += skewUnit;
            }
        }
        #endregion

        private void rdoParameterType_CheckedChanged(object sender, EventArgs e)
        {
            SetSelecteParameterType(sender);
        }

        private void SetSelecteParameterType(object sender)
        {
            RadioButton btn = sender as RadioButton;

            _parameterType = (eParameterType)Enum.Parse(typeof(eParameterType), btn.Text.Replace("\r\n", "_"));

            if (btn.Checked)
            {
                switch (_parameterType)
                {
                    case eParameterType.GROUP:
                        ShowGroup();
                        lblGroupCountValue.Enabled = true;
                        cmbGroupNumber.Enabled = true;
                        InitializeGrouping();
                        break;

                    case eParameterType.BUMP:
                        ShowGroup();
                        lblGroupCountValue.Enabled = false;
                        cmbGroupNumber.Enabled = false;
                        break;

                    case eParameterType.ENGINEER_PARAMETER:
                        ShowParameter();
                        break;

                    case eParameterType.MAKER_PARAMETER:
                        ShowMakerParameter();
                        break;

                    case eParameterType.OPTION:
                        ShowOption();
                        break;

                    default:
                        break;
                }

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void ShowGroup()
        {
            pnlGroup.Visible = true;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOption.Visible = false;
        }

        private void ShowParameter()
        {
            pnlGroup.Visible = false;
            pnlEngineerParameter.Visible = true;
            pnlMakerParameter.Visible = false;
            pnlOption.Visible = false;
        }

        private void ShowMakerParameter()
        {
            pnlGroup.Visible = false;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = true;
            pnlOption.Visible = false;
        }

        private void ShowOption()
        {
            pnlGroup.Visible = false;
            pnlEngineerParameter.Visible = false;
            pnlMakerParameter.Visible = false;
            pnlOption.Visible = true;
        }

        private void InitializeGrouping()
        {
            lblGroupCountValue.Text = _akkonTagData[_tabNo].LeadGroupCount.ToString();

            cmbGroupNumber.Items.Clear();

            if (_leadGroupInfo[_tabNo] == null)
                return;

            if (_leadGroupInfo[_tabNo].LeadCount != 0)
            {
                GroupListLeadData.Clear();
                cmbGroupNumber.Items.Clear();

                int leadCount = 0;
                int bumpCount = 0;

                for (int groupCount = 0; groupCount < _akkonTagData[_tabNo].LeadGroupCount; groupCount++)
                {
                    cmbGroupNumber.Items.Add((groupCount + 1).ToString());

                    GroupListLeadData.Add(new List<CogRectangleAffine>());
                    bumpCount += _leadGroupInfo[groupCount].LeadCount;

                    for (int leadIndex = 0; leadIndex < _leadGroupInfo[groupCount].LeadCount; leadIndex++)
                    {
                        if (_akkonTagData[_tabNo].AkkonBumpROIList.Count() < (bumpCount/* - 1*/))
                            break;

                        GroupListLeadData[groupCount].Add(_akkonTagData[_tabNo].AkkonBumpROIList[leadCount]);

                        leadCount++;
                    }
                }

                cmbGroupNumber.SelectedIndex = 0;
                RefreshAkkonRegion();
            }
        }

        private void lblGroupCountValue_Click(object sender, EventArgs e)
        {
            SetGroupCount();
        }

        private void SetGroupCount()
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, Main.DEFINE.MAX_LEAD_GROUP_COUNT, _groupCount, "Input Group Total Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                {
                    _groupCount = (int)form_keypad.m_data;
                    lblGroupCountValue.Text = _groupCount.ToString();

                    cmbGroupNumber.Items.Clear();
                    if (_akkonTagData[_tabNo] == null)
                        SetAkkonProperty();

                    _akkonTagData[_tabNo].LeadGroupCount = _groupCount;

                    if (_leadGroupInfo == null)
                        SetLeadProperty();

                    GroupListLeadData.Clear();
                    if (_groupCount != GroupListLeadData.Count)
                    {
                        if (_akkonTagData[_tabNo].LeadGroupCount <= 0)
                            _leadGroupInfo = new Main.LeadGroupInfo[_groupCount];

                        for (int i = 0; i < _groupCount; i++)
                            GroupListLeadData.Add(new List<CogRectangleAffine>());
                    }
                }
            }

            InitializeGroupROI(_akkonTagData[_tabNo].LeadGroupCount);
        }

        private void GetAkkonParameter()
        {
            ///Enginner Param  
            lblCountValue.Text = _akkonTagData[_tabNo].JudgeCount.ToString();
            lblLengthValue.Text = _akkonTagData[_tabNo].JudgeLength.ToString("F2");
            lblMinSizeFilterValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize.ToString("F2");
            lblMaxSizeFilterValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize.ToString("F2");
            lblGroupDistanceValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance.ToString("F2");
            lblStrengthFilterValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold.ToString("F2");
            lblWidthCutValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_nWidthCut.ToString();
            lblHeightCutValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_nHeightCut.ToString();
            lblBWRatioValue.Text = _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio.ToString("F2");
            lblExtraLeadDisplayValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nExtraLead.ToString();

            // Maker Param
            cmbInspectionType.SelectedIndex = _akkonTagData[_tabNo].AkkonInspectionOption.s_nInspType;
            cmbPanelType.SelectedIndex = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nIsFlexible;
            cmbTargetType.SelectedIndex = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nPanelInfo;
            cmbFilterType.SelectedIndex = (int)_akkonTagData[_tabNo].AkkonInspectionParameter.s_eFilterType;
            cmbFilterDirection.SelectedIndex = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nFilterDir;
            cmbShadowDirection.SelectedIndex = (int)_akkonTagData[_tabNo].AkkonInspectionParameter.s_eShadowDir;
            cmbPeakProperty.SelectedIndex = (int)_akkonTagData[_tabNo].AkkonInspectionParameter.s_ePeakProp;
            cmbStrengthBase.SelectedIndex = (int)_akkonTagData[_tabNo].AkkonInspectionParameter.s_eStrengthBase;
            cmbThresholdMode.SelectedIndex = (int)_akkonTagData[_tabNo].AkkonInspectionParameter.s_eThMode;

            chkLogTraceUseCheck.Checked = _akkonTagData[_tabNo].AkkonInspectionOption.s_bLogTrace;
            lblThresholdWeightValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight.ToString("F2");
            lblPeakThresholdValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak.ToString();
            lblStandardDeviationValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStdDevLeadJudge.ToString();
            lblStrengthScaleFactorValue.Text = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor.ToString("F2");
            lblSliceOverlapValue.Text = _akkonTagData[_tabNo].AkkonInspectionOption.s_nOverlap.ToString("F2");

            // Option
            chkUseDimple.Checked = true;
            lblDimpleNGCountValue.Text = "0";
            lblDimpleThresholdValue.Text = "0";

            chkUseAlarm.Checked = true;
            lblAlarmCapacityValue.Text = "0";
            lblAlarmNGCountValue.Text = "0";
        }

        private void SetAkkonProperty()
        {
            _akkonTagData = new Main.AkkonTagData[DEFINE.TAB_NUM];
            _leadGroupInfo = new Main.LeadGroupInfo[DEFINE.TAB_NUM];

            for (int tabCount = 0; tabCount < Main.DEFINE.TAP_UNIT_MAX; tabCount++)
            {
                _akkonTagData[tabCount] = new Main.AkkonTagData();
                _akkonTagData[tabCount].SetParam(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, tabCount].AkkonPara);
            }
        }

        private void SetLeadProperty()
        {
            for (int groupCount = 0; groupCount < _akkonTagData[_tabNo].LeadGroupCount; groupCount++)
            {
                _leadGroupInfo[groupCount] = new Main.LeadGroupInfo();
                _leadGroupInfo[groupCount].SetParam(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].LeadGroupInfo[groupCount]);
            }
        }

        private void InitializeGroupROI(int leadGroupCount)
        {
            cmbGroupNumber.Items.Clear();

            if (_leadGroupInfo == null)
            {
                _leadGroupInfo = new LeadGroupInfo[leadGroupCount];
                cmbGroupNumber.Items.Clear();

                for (int groupIndex = 0; groupIndex < leadGroupCount; groupIndex++)
                {
                    _leadGroupInfo[groupIndex] = new LeadGroupInfo();
                    cmbGroupNumber.Items.Add((groupIndex + 1).ToString());
                }

            }
            else if (_leadGroupInfo[_groupNo] == null)
            {
                cmbGroupNumber.Items.Clear();
                for (int groupIndex = 0; groupIndex < leadGroupCount; groupIndex++)
                {
                    _leadGroupInfo[groupIndex] = new LeadGroupInfo();
                    cmbGroupNumber.Items.Add((groupIndex + 1).ToString());
                }
            }
            else if (_akkonTagData[_tabNo].LeadGroupCount != leadGroupCount)
            {
                cmbGroupNumber.Items.Clear();

                for (int groupIndex = 0; groupIndex < leadGroupCount; groupIndex++)
                {
                    _leadGroupInfo[groupIndex] = new LeadGroupInfo();
                    cmbGroupNumber.Items.Add((groupIndex + 1).ToString());
                }
            }
            else
            {
                cmbGroupNumber.Items.Clear();

                for (int groupIndex = 0; groupIndex < leadGroupCount; groupIndex++)
                    cmbGroupNumber.Items.Add((groupIndex + 1).ToString());
            }
        }

        private void cmbGroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGroupNumber();
        }

        private void SetGroupNumber()
        {
            _groupNo = cmbGroupNumber.SelectedIndex;

            RefreshAkkonRegion();

            if (_cogRectNewROI == null)
                _cogRectNewROI = new CogRectangleAffine();

            _roiWidth = (int)_cogRectNewROI.SideXLength;
            _roiHeight = (int)_cogRectNewROI.SideYLength;
            lblROIWidthValue.Text = _roiWidth.ToString();
            lblROIHeightValue.Text = _roiHeight.ToString();
            lblLeadCountValue.Text = _leadGroupInfo[_groupNo].LeadCount.ToString();
            lblLeadPitchValue.Text = _leadGroupInfo[_groupNo].LeadPitch.ToString("F2");
        }

        private void RefreshAkkonRegion()
        {
            ClearGraphic();
            dgvAkkonROI.Rows.Clear();

            CogGraphicInteractiveCollection ROIGraphic = new CogGraphicInteractiveCollection();

            if (_parameterType == eParameterType.GROUP)
            {
                dgvAkkonROI.RowCount = _leadGroupInfo[_groupNo].LeadCount;

                //현재 선택된 Group 번호에 해당하는 ROI View
                for (int i = 0; i < _leadGroupInfo[_groupNo].LeadCount; i++)
                {
                    if (GroupListLeadData[_groupNo].Count == 0)
                        continue;

                    GroupListLeadData[_groupNo][i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    GroupListLeadData[_groupNo][i].Interactive = false;
                    ROIGraphic.Add(GroupListLeadData[_groupNo][i]);

                    dgvAkkonROI[0, i].Value = (i + 1).ToString();
                    dgvAkkonROI[1, i].Value = "(" + GroupListLeadData[_groupNo][i].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[_groupNo][i].CornerOriginY.ToString("0.0") + ")";
                    dgvAkkonROI[2, i].Value = "(" + GroupListLeadData[_groupNo][i].CornerXX.ToString("0.0") + "," + GroupListLeadData[_groupNo][i].CornerXY.ToString("0.0") + ")";
                    dgvAkkonROI[3, i].Value = "(" + GroupListLeadData[_groupNo][i].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[_groupNo][i].CornerOppositeY.ToString("0.0") + ")";
                    dgvAkkonROI[4, i].Value = "(" + GroupListLeadData[_groupNo][i].CornerYX.ToString("0.0") + "," + GroupListLeadData[_groupNo][i].CornerYY.ToString("0.0") + ")";

                    CogGraphicLabel cogLabel = new CogGraphicLabel();
                    cogLabel.Color = CogColorConstants.Green;
                    cogLabel.Font = new Font(Main.DEFINE.FontStyle, 10);
                    cogLabel.Text = "[" + (i + 1).ToString() + "]";
                    cogLabel.X = (GroupListLeadData[_groupNo][i].CornerOppositeX + GroupListLeadData[_groupNo][i].CornerYX) / 2;
                    cogLabel.Y = GroupListLeadData[_groupNo][i].CornerYY + 40;
                    ROIGraphic.Add(cogLabel);
                }
                _teachingDisplay.InteractiveGraphics.AddList(ROIGraphic, "ROI", false);
                ROIGraphic.Clear();
            }
            else if (_parameterType == eParameterType.BUMP)
            {
                dgvAkkonROI.RowCount = _akkonTagData[_tabNo].AkkonBumpROIList.Count;

                for (int i = 0; i < _akkonTagData[_tabNo].AkkonBumpROIList.Count; i++)
                {
                    _akkonTagData[_tabNo].AkkonBumpROIList[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    _akkonTagData[_tabNo].AkkonBumpROIList[i].Interactive = false;
                    ROIGraphic.Add(_akkonTagData[_tabNo].AkkonBumpROIList[i]);

                    dgvAkkonROI[0, i].Value = (i + 1).ToString();
                    dgvAkkonROI[1, i].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerOriginX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerOriginY.ToString("0.0") + ")";
                    dgvAkkonROI[2, i].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerXX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerXY.ToString("0.0") + ")";
                    dgvAkkonROI[3, i].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerOppositeX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerOppositeY.ToString("0.0") + ")";
                    dgvAkkonROI[4, i].Value = "(" + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerYX.ToString("0.0") + "," + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerYY.ToString("0.0") + ")";

                    //CogGraphicLabel labROINo = new CogGraphicLabel();
                    CogGraphicLabel cogLabel = new CogGraphicLabel();

                    cogLabel.Color = CogColorConstants.Green;
                    cogLabel.Font = new Font(Main.DEFINE.FontStyle, 10);
                    cogLabel.Text = "[" + (i + 1).ToString() + "]";
                    cogLabel.X = (_akkonTagData[_tabNo].AkkonBumpROIList[i].CornerOppositeX + _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerYX) / 2;
                    cogLabel.Y = _akkonTagData[_tabNo].AkkonBumpROIList[i].CornerYY + 40;
                    ROIGraphic.Add(cogLabel);
                }

                _teachingDisplay.InteractiveGraphics.AddList(ROIGraphic, "ROI", false);
                ROIGraphic.Clear();
            }
            else { }
        }

        private void ClearGraphic()
        {
            _teachingDisplay.StaticGraphics.Clear();
            _teachingDisplay.InteractiveGraphics.Clear();
        }

        private void lblROIWidthValue_Click(object sender, EventArgs e)
        {
            SetROIWidth();
        }

        private void SetROIWidth()
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, _roiWidth, "Input ROI Width", 1))
            {
                form_keypad.ShowDialog();

                _roiWidth = (int)form_keypad.m_data;

                if (_cogRectNewROI == null)
                    _cogRectNewROI = new CogRectangleAffine();

                _cogRectNewROI.SideXLength = _roiWidth / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);

                btnRegister.Visible = true;
                lblROIWidthValue.Text = _roiWidth.ToString();
            }
        }

        private void lblROIHeightValue_Click(object sender, EventArgs e)
        {
            SetROIHeight();
        }

        private void SetROIHeight()
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, _roiHeight, "Input ROI Width", 1))
            {
                form_keypad.ShowDialog();

                _roiHeight = (int)form_keypad.m_data;

                if (_cogRectNewROI != null)
                {
                    ClearGraphic();

                    _cogRectNewROI.SideYLength = _roiHeight / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                    _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);

                    btnRegister.Visible = true;
                    lblROIHeightValue.Text = _roiHeight.ToString();
                }
            }
        }

        private void btnROICreate_Click(object sender, EventArgs e)
        {
            CreateAkkonROI();
        }

        private void CreateAkkonROI()
        {
            ClearGraphic();
            dgvAkkonROI.Rows.Clear();

            if (_teachingDisplay.Image == null)
                return;

            _cogRectNewROI = new CogRectangleAffine();
            _cogRectNewROI.SetCenterLengthsRotationSkew(500, 500, _roiWidth / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), _roiHeight / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), 0, 0);
            _cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
            _cogRectNewROI.Interactive = true;
            _cogRectNewROI.SetCenterLengthsRotationSkew((_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX), (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY),
                _cogRectNewROI.SideXLength, _cogRectNewROI.SideYLength, _cogRectNewROI.Rotation, _cogRectNewROI.Skew);

            _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterAkkonROI();
        }

        private void RegisterAkkonROI()
        {
            if (GroupListLeadData.Count() == 0)
            {
                for (int nGroup = 0; nGroup < _akkonTagData[_tabNo].LeadGroupCount; nGroup++)
                    GroupListLeadData.Add(new List<CogRectangleAffine>());
            }

            GroupListLeadData[_groupNo].Clear();
            dgvAkkonROI.Rows.Clear();

            GroupListLeadData[_groupNo].Add(_cogRectNewROI);

            dgvAkkonROI.Rows.Add(GroupListLeadData[_groupNo].Count.ToString(), "(" + GroupListLeadData[_groupNo].Last().CornerOriginX.ToString("0.0") + "," + GroupListLeadData[_groupNo].Last().CornerOriginY.ToString("0.0") + ")",
                "(" + GroupListLeadData[_groupNo].Last().CornerXX.ToString("0.0") + "," + GroupListLeadData[_groupNo].Last().CornerXY.ToString("0.0") + ")",
                "(" + GroupListLeadData[_groupNo].Last().CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[_groupNo].Last().CornerOppositeY.ToString("0.0") + ")",
                "(" + GroupListLeadData[_groupNo].Last().CornerYX.ToString("0.0") + "," + GroupListLeadData[_groupNo].Last().CornerYY.ToString("0.0") + ")");

            _cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
            _cogRectNewROI.Interactive = false;
            _teachingDisplay.InteractiveGraphics.Add(_cogRectNewROI, "AKKON", false);

            //LBL_ATT_LEAD_COUNT.Visible = true;
            //LB_ATT_LEAD_COUNT.Visible = true;
            //LBL_ATT_LEAD_PITCH.Visible = true;
            //LB_ATT_LEAD_PITCH.Visible = true;
            //_teachingDisplay.InteractiveGraphics.Clear();
            //_teachingDisplay.StaticGraphics.Clear();

            ClearGraphic();
        }

        private void lblLeadPitchValue_Click(object sender, EventArgs e)
        {
            SetLeadPitch();
        }

        private void SetLeadPitch()
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, _leadPitch, "Input Lead Pitch", 1))
            {
                form_keypad.ShowDialog();
                _leadPitch = (double)form_keypad.m_data;
            }

            lblLeadPitchValue.Text = _leadPitch.ToString("F2");
            _leadGroupInfo[_groupNo].LeadPitch = _leadPitch;

            //LBL_ATT_CLONE_ROI.Visible = true;
            //BTN_AKKON_CLONE_HOR.Visible = true;
            //BTN_AKKON_CLONE_VER.Visible = true;
            //rdoCopyHorizontal.BackColor = Color.Green;
            //rdoCopyVertical.BackColor = Color.White;
        }

        private void lblLeadCountValue_Click(object sender, EventArgs e)
        {
            SetLeadCount();
        }

        private void SetLeadCount()
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 5000, _leadCount, "Input Lead Count", 1))
            {
                form_keypad.ShowDialog();
                _leadCount = (int)form_keypad.m_data;
            }

            lblLeadCountValue.Text = _leadCount.ToString();
            _leadGroupInfo[_groupNo].LeadCount = _leadCount;
            //LBL_ATT_CLONE_ROI.Visible = true;
            //BTN_AKKON_CLONE_HOR.Visible = true;
            //BTN_AKKON_CLONE_VER.Visible = true;
        }

        private void rdoSetROICopyType_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectROICopyType(sender);
        }

        private void SetSelectROICopyType(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Name.ToLower().Contains("horizontal"))
                    SetROICopyType(eCopyDirection.Horizontal);
                else
                    SetROICopyType(eCopyDirection.Vertical);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetROICopyType(eCopyDirection copyDirection)
        {
            _copyDirection = copyDirection;
        }

        private void btnCopyROI_Click(object sender, EventArgs e)
        {
            CopyROI();
        }

        private void CopyROI()
        {
            if (GroupListLeadData[_groupNo].Count == 0)
            {
                MessageBox.Show("Empty ROI Data");
                return;
            }

            //ExecueAutoROI();
            // 아래가 위 함수 정의 부분

            int nSelectIndex = 0;

            //현재 선택된 Rows 중 맨 마지막 Index 찾기
            //foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
            //    nSelectIndex = Convert.ToInt32(row.Cells[0].Value); // row의 컬럼
            nSelectIndex = 1;
            CogRectangleAffine cogTempRectAffine;
            double dNewCenterX, dNewCenterY;
            nSelectIndex += -1;
            //if (nSelectIndex > mLeadGroupInfo[m_nGroupNo].LeadCount)
            //    nSelectIndex = mLeadGroupInfo[m_nGroupNo].LeadCount-1; 

            //for (int i = 0; i < _leadGroupInfo[_groupNo].LeadCount; ++i)
            for (int i = 0; i < _leadCount; i++)
            {
                dNewCenterX = GroupListLeadData[_groupNo][nSelectIndex].CenterX;
                dNewCenterY = GroupListLeadData[_groupNo][nSelectIndex].CenterY;

                //if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL))
                //    dNewCenterY += (_leadGroupInfo[_groupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                //else if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL))
                //    dNewCenterX += (_leadGroupInfo[_groupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                //else
                //    continue;

                if (_copyDirection == eCopyDirection.Horizontal)
                    dNewCenterX += (_leadGroupInfo[_groupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                else
                    dNewCenterY += (_leadGroupInfo[_groupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);

                cogTempRectAffine = new CogRectangleAffine(GroupListLeadData[_groupNo][nSelectIndex]);
                cogTempRectAffine.CenterX = dNewCenterX;
                cogTempRectAffine.CenterY = dNewCenterY;

                if (i == 0)
                    GroupListLeadData[_groupNo].Clear();

                //if (GroupListLeadData[m_nGroupNo][i] != null)
                //    GroupListLeadData[m_nGroupNo][i] = cogTempRectAffine;
                //else

                GroupListLeadData[_groupNo].Add(cogTempRectAffine);
            }

            RefreshAkkonRegion();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SortROI();
        }

        private void SortROI()
        {
            if (GroupListLeadData[_groupNo].Count == 0)
                return;

            if (_copyDirection == eCopyDirection.Horizontal)
                AlignROIGapHorizontal();
            else
                AlignROIGapVertical();
        }

        private void AlignROIGapHorizontal()
        {
            bool isFirstCheck = false;
            int leftIndex = 0, rightIndex = 0, checkCount = 0;
            float deltaX = 0, deltaY = 0;

            CogRadian deltaAngle = 0;
            CogRadian firstAngle = 0;
            CogRadian lastAngle = 0;
            // DG_AKKON_ROI_LIST.SelectAll();

            for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    if (!isFirstCheck)
                    {
                        isFirstCheck = true;
                        leftIndex = leadIndex;
                    }
                    else
                        rightIndex = leadIndex;

                    checkCount++;
                }
            }

            if (leftIndex == rightIndex)
            {
                Console.WriteLine("Left and Right Bump Index is Same!");
                return;
            }

            deltaX = ((float)(GroupListLeadData[_groupNo][rightIndex].CenterX - GroupListLeadData[_groupNo][leftIndex].CenterX) / (float)(checkCount - 1));
            deltaY = ((float)(GroupListLeadData[_groupNo][rightIndex].CenterY - GroupListLeadData[_groupNo][leftIndex].CenterY) / (float)(checkCount - 1));
            _leadGroupInfo[_groupNo].LeadPitch = deltaX;

            firstAngle = GroupListLeadData[_groupNo][leftIndex].Skew;
            lastAngle = GroupListLeadData[_groupNo][rightIndex].Skew;
            deltaAngle = (lastAngle.Value - firstAngle.Value) / (float)(checkCount - 1);

            isFirstCheck = false;
            checkCount = 0;

            double newCenterX, newCenterY;
            CogRadian newSkew;

            for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    if (!isFirstCheck)
                        isFirstCheck = true;
                    else
                    {
                        CogRadian pitchAngle = deltaAngle.Value * leadIndex;

                        newCenterX = GroupListLeadData[_groupNo][leftIndex].CenterX + (deltaX * checkCount);
                        newCenterY = GroupListLeadData[_groupNo][leftIndex].CenterY + (deltaY * checkCount);
                        newSkew = GroupListLeadData[_groupNo][leftIndex].Skew + pitchAngle.Value;

                        GroupListLeadData[_groupNo][leadIndex].CenterX = newCenterX;
                        GroupListLeadData[_groupNo][leadIndex].CenterY = newCenterY;
                        GroupListLeadData[_groupNo][leadIndex].Skew = newSkew.Value;
                    }

                    checkCount++;
                }
            }

            RefreshAkkonRegion();
        }

        private void AlignROIGapVertical()
        {
            bool isFirstCheck = false;
            int topIndex = 0, bottomIndex = 0, checkCount = 0;
            float fDelta = 0;

            CogRadian deltaAngle = 0;
            CogRadian firstAngle = 0;
            CogRadian lastAngle = 0;

            for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    if (!isFirstCheck)
                    {
                        isFirstCheck = true;
                        topIndex = leadIndex;
                    }
                    else
                        bottomIndex = leadIndex;

                    checkCount++;
                }
            }

            if (topIndex == bottomIndex)
            {
                Console.WriteLine("Top and Bottom Bump Index is Same!");
                return;
            }

            fDelta = ((float)(GroupListLeadData[_groupNo][bottomIndex].CenterY - GroupListLeadData[_groupNo][topIndex].CenterY) / (float)(checkCount - 1));
            _leadGroupInfo[_groupNo].LeadPitch = fDelta;
            firstAngle = GroupListLeadData[_groupNo][topIndex].Skew;
            lastAngle = GroupListLeadData[_groupNo][bottomIndex].Skew;

            deltaAngle = (lastAngle.Value - firstAngle.Value) / (float)(checkCount - 1);
            isFirstCheck = false;
            checkCount = 0;

            double newCenterX, newCenterY;
            CogRadian newSkew;

            for (int leadIndex = 0; leadIndex < GroupListLeadData[_groupNo].Count; leadIndex++)
            {
                foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
                {
                    if (!isFirstCheck)
                        isFirstCheck = true;
                    else
                    {
                        CogRadian pitchAngle = deltaAngle.Value * leadIndex;

                        newCenterX = GroupListLeadData[_groupNo][topIndex].CenterX;
                        newCenterY = GroupListLeadData[_groupNo][topIndex].CenterY + (fDelta * checkCount);
                        newSkew = GroupListLeadData[_groupNo][topIndex].Skew + pitchAngle.Value;

                        GroupListLeadData[_groupNo][leadIndex].CenterX = newCenterX;
                        GroupListLeadData[_groupNo][leadIndex].CenterY = newCenterY;
                        GroupListLeadData[_groupNo][leadIndex].Skew = newSkew.Value;
                    }

                    checkCount++;
                }
            }

            RefreshAkkonRegion();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteROI();
        }

        private void DeleteROI()
        {
            foreach (DataGridViewRow row in dgvAkkonROI.SelectedRows)
            {
                int index = row.Index;
                dgvAkkonROI.Rows.RemoveAt(index);
                GroupListLeadData[_groupNo].RemoveAt(index);
                _leadGroupInfo[_groupNo].LeadCount -= 1;
            }

            RefreshAkkonRegion();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyROI();
        }

        private void ApplyROI()
        {
            _akkonTagData[_tabNo].AkkonBumpROIList.Clear();
            _akkonTagData[_tabNo].LeadGroupCount = GroupListLeadData.Count();
            //for (int j = 0; j < akkonParam[m_nTabNo].LeadGroupCount; j++)
            //{
            //    for (int i = 0; i < mLeadGroupInfo[m_nTabNo].LeadCount; i++)
            //    {
            //        if (GroupListLeadData[j].Count != 0 && GroupListLeadData[j] != null)
            //            akkonParam[m_nTabNo].AkkonBumpROIList.Add(GroupListLeadData[j][i]);
            //        else
            //            break;
            //    }
            //}

            //shkang_s
            for (int groupCount = 0; groupCount < _akkonTagData[_tabNo].LeadGroupCount; groupCount++)
            {
                for (int leadCount = 0; leadCount < _leadGroupInfo[groupCount].LeadCount; leadCount++)
                {
                    if (GroupListLeadData[groupCount].Count != 0)
                        _akkonTagData[_tabNo].AkkonBumpROIList.Add(GroupListLeadData[groupCount][leadCount]);
                    else
                        break;
                }
            }

            lblLeadCountValue.Text = _leadGroupInfo[_groupNo].LeadCount.ToString();
        }

        private void lblCountValue_Click(object sender, EventArgs e)
        {
            SetJudgeAkkonCount();
        }

        private void SetJudgeAkkonCount()
        {
            int akkonJudgeCount = _akkonTagData[_tabNo].JudgeCount;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, akkonJudgeCount, "Input Judge Akkon Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    akkonJudgeCount = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeCount = akkonJudgeCount;
                lblCountValue.Text = akkonJudgeCount.ToString();
            }
        }

        private void lblLengthValue_Click(object sender, EventArgs e)
        {
            SetJudgeAkkonLength();
        }

        private void SetJudgeAkkonLength()
        {
            double akkonJudgeLength = _akkonTagData[_tabNo].JudgeLength;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 3000.0, akkonJudgeLength, "Input Judge Akkon Length Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    akkonJudgeLength = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeLength = akkonJudgeLength;
                lblLengthValue.Text = akkonJudgeLength.ToString("F2");
            }
        }

        private void lblMinSizeFilterValue_Click(object sender, EventArgs e)
        {
            SetAkkonMinimumFilterSize();
        }

        private void SetAkkonMinimumFilterSize()
        {
            double filterMinSize = (double)_akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, filterMinSize, "AKKON MIN SIZE FILTER (um)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    filterMinSize = (double)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize = (float)filterMinSize;
                lblMinSizeFilterValue.Text = filterMinSize.ToString("F2");
            }
        }

        private void lblMaxSizeFilterValue_Click(object sender, EventArgs e)
        {
            SetAkkonMaximumFilterSize();
        }

        private void SetAkkonMaximumFilterSize()
        {
            double filterMaxSize = (double)_akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, filterMaxSize, "AKKON MAX SIZE FILTER(um)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK == true)
                    filterMaxSize = (double)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize = (float)filterMaxSize;
                lblMaxSizeFilterValue.Text = filterMaxSize.ToString("F2");
            }
        }

        private void lblGroupDistanceValue_Click(object sender, EventArgs e)
        {
            SetDistanceBetweenGroups();
        }

        private void SetDistanceBetweenGroups()
        {
            double groupDistance = (double)_akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, groupDistance, "AKKON GROUP DISTANCE (pixel)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    groupDistance = form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance = groupDistance;
                lblGroupDistanceValue.Text = groupDistance.ToString("F2");
            }
        }

        private void lblStrengthFilterValue_Click(object sender, EventArgs e)
        {
            SetStrengthFilter();
        }

        private void SetStrengthFilter()
        {
            float strengthFilter = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, strengthFilter, "STRENGTH FILTER (%)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    strengthFilter = (float)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold = strengthFilter;
                lblStrengthFilterValue.Text = strengthFilter.ToString("F2");
            }
        }

#region Dimple
        private void lblDimpleNGCountValue_Click(object sender, EventArgs e)
        {
            SetDimpleNGCount();
        }

        private void SetDimpleNGCount()
        {
            int dimpleNGCount = _akkonTagData[_tabNo].JudgeCount;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, dimpleNGCount, "Input Dimple NG Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    dimpleNGCount = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeCount = dimpleNGCount;
                lblDimpleNGCountValue.Text = dimpleNGCount.ToString();
            }
        }

        private void lblDimpleThresholdValue_Click(object sender, EventArgs e)
        {
            SetDimpleThreshold();
        }

        private void SetDimpleThreshold()
        {
            int dimpleThreshold = _akkonTagData[_tabNo].JudgeCount;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, dimpleThreshold, "Input Dimple NG Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    dimpleThreshold = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeCount = dimpleThreshold;
                lblDimpleThresholdValue.Text = dimpleThreshold.ToString();
            }
        }

        private void chkUseDimple_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }

        private void chkUseAlarm_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }

        private void SetCheckChanged(object sender)
        {
            CheckBox chk = sender as CheckBox;

            //if (chk.Checked)
            //    chk.BackColor = Color.LimeGreen;
            //else
            //    chk.BackColor = Color.DarkGray;

            if (chk.Checked)
                chk.BackColor = Color.LimeGreen;
            else
                chk.BackColor = Color.DarkGray;

            _akkonTagData[_tabNo].JudgeCount = Convert.ToInt32(chkUseDimple.Checked);
        }
#endregion

#region Alarm
        private void lblAlarmCapacityValue_Click(object sender, EventArgs e)
        {
            SetAlarmCapacity();
        }

        private void SetAlarmCapacity()
        {
            int alarmCapacity = _akkonTagData[_tabNo].JudgeCount;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, alarmCapacity, "Input Alarm Capacity Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    alarmCapacity = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeCount = alarmCapacity;
                lblAlarmCapacityValue.Text = alarmCapacity.ToString();
            }
        }

        private void lblAlarmNGCountValue_Click(object sender, EventArgs e)
        {
            SetAlarmNGCount();
        }

        private void SetAlarmNGCount()
        {
            int alarmNGCount = _akkonTagData[_tabNo].JudgeCount;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, alarmNGCount, "Input Alarm NG Count", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    alarmNGCount = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].JudgeCount = alarmNGCount;
                lblAlarmCapacityValue.Text = alarmNGCount.ToString();
            }
        }
#endregion

        private void lblWidthCutValue_Click(object sender, EventArgs e)
        {
            SetWidthCut();
        }

        private void SetWidthCut()
        {
            int widthCut = _akkonTagData[_tabNo].AkkonInspectionFilter.s_nWidthCut;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, widthCut, "AKKON WIDTH CUT (pixel)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    widthCut = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_nWidthCut = widthCut;
                lblWidthCutValue.Text = widthCut.ToString();
            }
        }

        private void lblHeightCutValue_Click(object sender, EventArgs e)
        {
            SetHeightCut();
        }

        private void SetHeightCut()
        {
            int heightCut = _akkonTagData[_tabNo].AkkonInspectionFilter.s_nHeightCut;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, heightCut, "AKKON HEIGHT CUT (pixel)", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    heightCut = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_nHeightCut = heightCut;
                lblHeightCutValue.Text = heightCut.ToString();
            }
        }

        private void lblBWRatioValue_Click(object sender, EventArgs e)
        {
            SetBandWidthRatio();
        }

        private void SetBandWidthRatio()
        {
            float Bw_Ratio = _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio;

            using (Form_KeyPad form_keypad = new Form_KeyPad(-100.0, 100.0, Bw_Ratio, "AKKON BW RATIO", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    Bw_Ratio = (float)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio = Bw_Ratio;
                lblBWRatioValue.Text = Bw_Ratio.ToString("F2");
            }
        }

        private void lblExtraLeadDisplayValue_Click(object sender, EventArgs e)
        {
            SetExtraLeadDisplay();
        }

        private void SetExtraLeadDisplay()
        {
            int extraLeadDisplay = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nExtraLead;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, extraLeadDisplay, "EXTRA LEAD DISPLAY", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    extraLeadDisplay = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_nExtraLead = extraLeadDisplay;
                lblExtraLeadDisplayValue.Text = extraLeadDisplay.ToString();
            }
        }

        private void cmbInspectionType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            SetInspectionType(cmb.SelectedIndex);
        }

        private void SetInspectionType(int index)
        {
            _akkonTagData[_tabNo].AkkonInspectionOption.s_nInspType = index;
        }

        private void cmbPanelType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetPanelType();
        }

        private void SetPanelType()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_nIsFlexible = cmbPanelType.SelectedIndex;
        }

        private void cmbTargetType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetTargetType();
        }

        private void SetTargetType()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_nPanelInfo = cmbTargetType.SelectedIndex;

            if (cmbTargetType.SelectedIndex == (int)MakerParameter.eTargetType.COF)
            {
                cmbFilterType.SelectedIndex = (int)MakerParameter.eFilterType.FILTER_3;
                //Set_Maker_Parames_Changed(null, null);

                cmbPeakProperty.SelectedIndex = (int)MakerParameter.ePeakProperty.NORMAL;
                //Set_Maker_Parames_Changed(null, null);

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight = 2;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = 1;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak = 70;
                
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize = 15;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance = 3;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                cmbStrengthBase.SelectedIndex = (int)MakerParameter.eStrengthBase.ENH;
                //Set_Maker_Parames_Changed(null, null);
            }
            else if (cmbTargetType.SelectedIndex == (int)MakerParameter.eTargetType.COG)
            {
                cmbFilterType.SelectedIndex = (int)MakerParameter.eFilterType.FILTER_4;
                //Set_Maker_Parames_Changed(null, null);

                cmbPeakProperty.SelectedIndex = (int)MakerParameter.ePeakProperty.NEAR;
                //Set_Maker_Parames_Changed(null, null);

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight = 1.5;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.2;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak = 70;
                
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize = 0;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize = 100;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance = 2;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio = -100;

                cmbStrengthBase.SelectedIndex = (int)MakerParameter.eStrengthBase.RAW;
                //Set_Maker_Parames_Changed(null, null);
            }
            else if (cmbTargetType.SelectedIndex == (int)MakerParameter.eTargetType.FOG)
            {
                cmbFilterType.SelectedIndex = (int)MakerParameter.eFilterType.NORMAL;
                //Set_Maker_Parames_Changed(null, null);

                cmbPeakProperty.SelectedIndex = (int)MakerParameter.ePeakProperty.NEAR;
                //Set_Maker_Parames_Changed(null, null);

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight = 4;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.5;
                _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak = 70;

                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fMaxSize = 30;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fGroupingDistance = 5;
                _akkonTagData[_tabNo].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                cmbStrengthBase.SelectedIndex = (int)MakerParameter.eStrengthBase.RAW;
                //Set_Maker_Parames_Changed(null, null);
            }
            else { }
        }

        private void cmbFilterType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetFilterType();
        }

        private void SetFilterType()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_eFilterType = (EN_MVFILTERTYPE_WRAP)cmbFilterType.SelectedIndex;
        }

        private void cmbFilterDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetFilterDirection();
        }

        private void SetFilterDirection()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_nFilterDir = cmbFilterDirection.SelectedIndex;
        }

        private void cmbShadowDirection_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetShadowDirection();
        }

        private void SetShadowDirection()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_eShadowDir = (EN_SHADOWDIR_WRAP)cmbShadowDirection.SelectedIndex;
        }

        private void cmbPeakProperty_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetPeackProperty();
        }

        private void SetPeackProperty()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_ePeakProp = (EN_PEAK_PROP_WRAP)cmbPeakProperty.SelectedIndex;
        }

        private void cmbStrengthBase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetStrengthBase();
        }

        private void SetStrengthBase()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_eStrengthBase = (EN_STRENGTH_BASE_WRAP)cmbStrengthBase.SelectedIndex;
        }

        private void cmbThresholdMode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SetThresholdMode();
        }

        private void SetThresholdMode()
        {
            _akkonTagData[_tabNo].AkkonInspectionParameter.s_eThMode = (EN_THMODE_WRAP)cmbThresholdMode.SelectedIndex;
        }

        private void chkLogTraceUseCheck_CheckedChanged(object sender, EventArgs e)
        {
            SetUseLogTrace();
        }

        private void SetUseLogTrace()
        {
            _akkonTagData[_tabNo].AkkonInspectionOption.s_bLogTrace = chkLogTraceUseCheck.Checked;
        }

        private void lblThresholdWeightValue_Click(object sender, EventArgs e)
        {
            SetThresholdWeight();
        }

        private void SetThresholdWeight()
        {
            double thresholdWeight = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, thresholdWeight, "THRESHOLD WEIGHT", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    thresholdWeight = form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fThWeight = thresholdWeight;
                lblThresholdWeightValue.Text = thresholdWeight.ToString("F2");
            }
        }

        private void lblPeakThresholdValue_Click(object sender, EventArgs e)
        {
            SetPeackThreshold();
        }

        private void SetPeackThreshold()
        {
            int peakThreshold = _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 255, peakThreshold, "PEAK THRESHOLD", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    peakThreshold = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_nThPeak = peakThreshold;
                lblPeakThresholdValue.Text = peakThreshold.ToString();
            }
        }

        private void lblStrengthScaleFactorValue_Click(object sender, EventArgs e)
        {
            SetStrengthScaleFactor();
        }

        private void SetStrengthScaleFactor()
        {
            float strengthScaleFactor = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1, strengthScaleFactor, "STRENGTH SCALE FACTOR", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    strengthScaleFactor = (float)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = strengthScaleFactor;
                lblStrengthScaleFactorValue.Text = strengthScaleFactor.ToString("F2");
            }
        }

        private void lblSliceOverlapValue_Click(object sender, EventArgs e)
        {
            SetSliceOverlap();
        }

        private void SetSliceOverlap()
        {
            int sliceOverlap = _akkonTagData[_tabNo].AkkonInspectionOption.s_nOverlap;
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 1000, sliceOverlap, "LEAD JUDGE STANDARD DEVIATION", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    sliceOverlap = (int)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStdDevLeadJudge = sliceOverlap;
                lblSliceOverlapValue.Text = sliceOverlap.ToString();
            }
        }

        private void lblStandardDeviationValue_Click(object sender, EventArgs e)
        {
            SetStarndardDeviation();
        }

        private void SetStarndardDeviation()
        {
            float standardDeviation = _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStdDevLeadJudge;
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, standardDeviation, "LEAD JUDGE STANDARD DEVIATION", 1))
            {
                form_keypad.ShowDialog();

                if (form_keypad.bOK)
                    standardDeviation = (float)form_keypad.m_data;

                _akkonTagData[_tabNo].AkkonInspectionParameter.s_fStdDevLeadJudge = standardDeviation;
                lblStandardDeviationValue.Text = standardDeviation.ToString("F2");
            }
        }

        private void rdoSetAkkonDataShow_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectAkkonDataShow(sender);
        }

        private void SetSelectAkkonDataShow(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("roi"))
                    tabAkkonData.SelectedIndex = 0;
                else
                    tabAkkonData.SelectedIndex = 1;

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void btnAkkonTest_Click(object sender, EventArgs e)
        {
            AkkonTest();
        }

        private void AkkonTest()
        {
            bool nRet = true;
            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            //if (nALLSEARCH)
            //{
            //    nStartNum = 0;
            //    nLastNum = Main.DEFINE.AKKON_MAX;
            //}
            //else
            //{
            //    nStartNum = m_SelectAkkon;
            //    nLastNum = m_SelectAkkon + 1;
            //}

            _akkonTagData[_tabNo].UseCheckAkkonInspection = true;
            Main.sw.Start();

            if (_akkonTagData[_tabNo].UseCheckAkkonInspection)
            {
                TempSelect = true;

                //if (PT_Akkon_MarkUSE[TapNo])
                //{
                //    for (int j = 0; j < PT_AkkonPara[TapNo].AkkonBumpROIList.Count; j++)
                //    {
                //        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                //        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                //    }
                //}


                ////YSH
                ////Image Resize
                //////////////////////////////////////////////////////////////////////////////////////////////////////
                //CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[m_CamNo].OutputImage as CogImage8Grey);
                //Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(CogConvertImage.ToBitmap()); //CogImage8Grey -> Mat (RGB)
                //Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);  // RGB -> Gray
                //Cv2.Resize(src, src, new OpenCvSharp.Size(0, 0), Imgresizeratio, Imgresizeratio); //임의로 ratio 0.6설정
                ////Mat -> btye[]
                //byte[] bytes2;
                //Cv2.ImEncode(".bmp", src, out bytes2);
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgDataATT = bytes2;
                //// ATT 이미지 버퍼 재설정
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols = src.Cols;
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows = src.Rows;

                //String strPath;
                //strPath = String.Format("D:\\Image_Resize.bmp");
                //Cv2.ImWrite(strPath, src);

                ////정식으로는 프로그램 실행 및 Buffer할당 시에만 동작함. 현재는 임의로 검사하기전에 동작. 해당 함수 소요시간은 T/T 제외가능
                //Main.ATT_CreateImageBuffer(CamNo, TapNo, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows);

                // ATT Initialize
                if (Main.DEFINE.OPEN_F)
                {
                    //Main.vision.IMAGE_SIZE_X[0] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                    //Main.vision.IMAGE_SIZE_Y[0] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgRows;
                    //2022 1004 YSH
                    //Main.vision.IMAGE_SIZE_X[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                    //Main.vision.IMAGE_SIZE_Y[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows;
                }

                // 0 COF, 1 COG, 2 FOG
                if (_akkonTagData[_tabNo].AkkonInspectionParameter.s_nPanelInfo == 0)
                    Main.DEFINE.ImageResizeRatio = (float)0.6;
                else if (_akkonTagData[_tabNo].AkkonInspectionParameter.s_nPanelInfo == 1)
                    Main.DEFINE.ImageResizeRatio = (float)1.0;
                else if (_akkonTagData[_tabNo].AkkonInspectionParameter.s_nPanelInfo == 2)
                    Main.DEFINE.ImageResizeRatio = (float)0.6;

                //2022 1004 YSH
                //Resize 0.5 사용시 Result 이미지 이상출력
                //Main.DEFINE.ImageResizeRatio = (float)0.6;
                Main.ATT_CreateDLLBuffer();
                Main.ATT_CreateImageBuffer();


                //ATT Mark search 
                double dX = 0, dY = 0, dTeachT = 0, dRotT = 0;
                OpenCvSharp.Point2d pntCenter = new OpenCvSharp.Point2d();
                OpenCvSharp.Point2d pntdXY = new OpenCvSharp.Point2d();
                pntCenter.X = 0; pntCenter.Y = 0;

                bool bLeftMarkCheck = false;
                bool bRightMarkCheck = false;
                // 임시
                int m_PatNo_Sub = 0;
                // PJH_TEST_230321_S
                //_akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].InputImage = _teachingDisplay.Image;
                //_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].InputImage = _teachingDisplay.Image;
                
                //_akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Run();
                //_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Run();

                //if (_akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results != null)
                //{
                //    if (_akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                //        bLeftMarkCheck = true;
                //}
                //if (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results != null)
                //{
                //    if (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                //        bRightMarkCheck = true;
                //}

                // PJH_TEST_230321_E
                if (bLeftMarkCheck && bRightMarkCheck)
                {
                    //추후 Score 기능 추가 예정 - YSH        
                    dX = (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2
                    - (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX) / 2;

                    dY = (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2
                    - (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY) / 2;

                    double dRotDx = _akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX - _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX;
                    double dRotDy = _akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY - _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY;
                    dRotT = OpenCvSharp.Cv2.FastAtan2((float)dRotDy, (float)dRotDx);
                    if (dRotT > 180) dRotT -= 360;

                    //float a = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY);
                    //float b = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX);

                    dTeachT = OpenCvSharp.Cv2.FastAtan2((float)(_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY),
                        (float)(_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX));
                    if (dTeachT > 180.0) dTeachT -= 360.0;


                    dRotT -= dTeachT;
                    pntCenter.X = (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2;
                    pntCenter.Y = (_akkonTagData[_tabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + _akkonTagData[_tabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2;

                    pntdXY.X = dX;
                    pntdXY.Y = dY;
                }
                else
                {
                    //LABEL_MESSAGE(LB_MESSAGE1, "Mark Search NG! ", Color.Red);
                }

                OpenCvSharp.Cv2.Resize(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanOriginalBuf, Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf,
                    new OpenCvSharp.Size(0, 0), Main.DEFINE.ImageResizeRatio, Main.DEFINE.ImageResizeRatio);
                byte[] bytes2 = new byte[Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Rows];
                OpenCvSharp.Cv2.ImEncode(".bmp", Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf, out bytes2);
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgDataATT = new byte[Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Rows];
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgCols = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Cols;
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgRows = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Rows;
                Main.strtmp[0] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();



                //압흔 Parameter 갱신부분 추가 필요 - YSH



                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                Main.sw.Start();
                // ROI Resize
                int[][] nLeadPoint = new int[_akkonTagData[_tabNo].AkkonBumpROIList.Count][];
                OpenCvSharp.Point[] ptPos = new OpenCvSharp.Point[4];
                for (int j = 0; j < _akkonTagData[_tabNo].AkkonBumpROIList.Count; j++)
                {
                    nLeadPoint[j] = new int[8];

                    nLeadPoint[j][0] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerOriginX);  //LeftTop
                    nLeadPoint[j][1] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerOriginY);  //LeftTop

                    nLeadPoint[j][2] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerXX);  //RightTop
                    nLeadPoint[j][3] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerXY);  //RightTop

                    nLeadPoint[j][4] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerOppositeX);  //RightBottom
                    nLeadPoint[j][5] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerOppositeY);  //RightBottom

                    nLeadPoint[j][6] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerYX);  //LeftBottom
                    nLeadPoint[j][7] = (int)(_akkonTagData[_tabNo].AkkonBumpROIList[j].CornerYY);  //LeftBottom

                    ptPos[0].X = nLeadPoint[j][0];
                    ptPos[0].Y = nLeadPoint[j][1];

                    ptPos[1].X = nLeadPoint[j][2];
                    ptPos[1].Y = nLeadPoint[j][3];

                    ptPos[2].X = nLeadPoint[j][4];
                    ptPos[2].Y = nLeadPoint[j][5];

                    ptPos[3].X = nLeadPoint[j][6];
                    ptPos[3].Y = nLeadPoint[j][7];

                    Main.RotationTransform(pntCenter, pntdXY, dRotT, ref ptPos);

                    //CogRectangleAffine tempRectAffine = new CogRectangleAffine();
                    //tempRectAffine.SetOriginCornerXCornerY(ptPos[0].X, ptPos[0].Y, ptPos[1].X, ptPos[1].Y, ptPos[3].X, ptPos[3].Y);
                    //PT_AkkonPara[TapNo, i].m_AkkonBumpROI[j] = tempRectAffine;

                    nLeadPoint[j][0] = ptPos[0].X;
                    nLeadPoint[j][1] = ptPos[0].Y;

                    nLeadPoint[j][2] = ptPos[1].X;
                    nLeadPoint[j][3] = ptPos[1].Y;

                    nLeadPoint[j][4] = ptPos[2].X;
                    nLeadPoint[j][5] = ptPos[2].Y;

                    nLeadPoint[j][6] = ptPos[3].X;
                    nLeadPoint[j][7] = ptPos[3].Y;

                    //strROI = tempRectAffine.CornerOriginX.ToString() + "\t" + tempRectAffine.CornerOriginY.ToString() + "\t" + tempRectAffine.CornerXX.ToString() + "\t"
                    //    + tempRectAffine.CornerXY.ToString() + "\t" + tempRectAffine.CornerOppositeX.ToString() + "\t" + tempRectAffine.CornerOppositeY.ToString() + "\t"
                    //    + tempRectAffine.CornerYX.ToString() + "\t" + tempRectAffine.CornerYY.ToString();

                    //SW.WriteLine(strROI);
                }
                //SW.Close();
                Main.strtmp[1] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();
                Main.sw.Start();
                bool bReadRoi = Main.ATT_SendROI((int)_camNo, _tabNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    //return false;
                    return;
                }

                // ATT RUN
                bool bReady = Main.ATT_ReadyToInsp((int)_camNo, (int)_stageNo, _tabNo, _akkonTagData[_tabNo]);

                // 자동 계산 overlap 확인
                //LB_ATT_SLICE_OVERLAP.Text = akkonParam[m_nTabNo].AkkonInspectionOption.s_nOverlap.ToString();

                if (bReady)
                {
                    Main.isFormTeaching = true;
                    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].bResulteTime = false;
                    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray = null;
                    Main.ATT_InspectByTap((int)_camNo, (int)_stageNo, _tabNo);
                }

            }
            //return nRet;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save();
        }

        public void Save()
        {
            //for (int tabNumber = 0; tabNumber < DEFINE.TAP_UNIT_MAX; tabNumber++)
            //{
                for (int groupCount = 0; groupCount < _akkonTagData[_tabNo].LeadGroupCount; groupCount++)
                    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].LeadGroupInfo[groupCount] = _leadGroupInfo[groupCount].Copy();

                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonPara = _akkonTagData[_tabNo].Copy();
                Main.AlignUnit[(int)_camNo].Save_ATT((int)_stageNo, _tabNo);//2022 1014 YSH Tab별 Save        }
            //}
        }

        private void btnROIShow_Click(object sender, EventArgs e)
        {
            ShowROI();
        }

        private void ShowROI()
        {
            RefreshAkkonRegion();
        }

        private void dgvAkkonROI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateLabelData(e.RowIndex);
            SetSelectAkkonROI(e.RowIndex);
        }

        private void UpdateLabelData(int index)
        {
            var LT = dgvAkkonROI.Rows[index].Cells[1].Value;
            var RT = dgvAkkonROI.Rows[index].Cells[2].Value;
            var RB = dgvAkkonROI.Rows[index].Cells[3].Value;

            string[] leftTop = LT.ToString().Split(new char[] { ',' });
            string[] rightTop = RT.ToString().Split(new char[] { ',' });
            string[] rightBottom = RB.ToString().Split(new char[] { ',' });

            string LT_X = leftTop[0].Replace("(", "");
            string LT_Y = leftTop[1].Replace(")", "");

            string RT_X = rightTop[0].Replace("(", "");
            string RT_Y = rightTop[0].Replace(")", "");

            string RB_X = rightBottom[0].Replace("(", "");
            string RB_Y = rightBottom[1].Replace(")", "");

            double width = Math.Abs(Convert.ToDouble(LT_X) - Convert.ToDouble(RT_X));
            double height = Math.Abs(Convert.ToDouble(LT_Y) - Convert.ToDouble(RB_Y));

            lblROIWidthValue.Text = (width / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000)).ToString("F2");
            lblROIHeightValue.Text = (height / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000)).ToString("F2");
        }

        private void SetSelectAkkonROI(int index)
        {
            foreach (DataGridViewRow row in dgvAkkonROI.Rows)
                GroupListLeadData[_groupNo][row.Index].Color = CogColorConstants.Cyan;

            GroupListLeadData[_groupNo][index].Color = CogColorConstants.DarkRed;
        }

        private void RefreshAkkonResult()
        {
            if (Convert.ToInt32(tabAkkonData.SelectedTab.Tag) == Main.DEFINE.M_AKKONTOOL)
            {
                ClearGraphic();

                dgvAkkonResult.Rows.Clear();
                dgvAkkonResult.RowCount = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo].Length;

                for (int i = 0; i < Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo].Length; i++)
                {
                    dgvAkkonResult[0, i].Value = (i + 1).ToString();
                    dgvAkkonResult[1, i].Value = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo][i].s_nNumBlobs.ToString();
                    dgvAkkonResult[2, i].Value = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo][i].s_fLength.ToString("0.000");
                    dgvAkkonResult[3, i].Value = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo][i].s_fAvgStrength.ToString("0.000");
                    dgvAkkonResult[4, i].Value = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].AkkonResult.AkkonResultArray[_tabNo][i].s_bJudgement.ToString();
                }

                tabAkkonData.SelectedIndex = 1;

                Main.DisplayFit(_teachingDisplay);
            }
        }

        private delegate void UpdateAkkonResultDisplayDelegate(CogImage24PlanarColor cogObject);
        public void UpdateAkkonResultDisplay(CogImage24PlanarColor cogObject)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAkkonResultDisplayDelegate callback = UpdateAkkonResultDisplay;
                    BeginInvoke(callback, cogObject);
                    return;
                }

                UpdateDisplay(cogObject);

            }
            catch (Exception err)
            {
                Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateDisplay(CogImage24PlanarColor cogResultImage)
        {
            _teachingDisplay.Image = cogResultImage;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImageFromFile();
        }

        private void LoadImageFromFile()
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.ReadOnlyChecked = true;
            //ofd.Filter = "Bmp File | *.bmp";
            //ofd.ShowDialog();

            //if (ofd.FileName != "")
            //{
            //    if (Main.vision.CogImgTool[0] == null)
            //        Main.vision.CogImgTool[0] = new CogImageFileTool();

            //    Main.GetImageFile(Main.vision.CogImgTool[0], ofd.FileName);
            //    Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf = (CogImage8Grey)Main.vision.CogCamBuf[0];
            //}

            //_teachingDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            //cogDisplayThumbnail.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            //cogDisplayThumbnail.Zoom = 0.06;
            //cogDisplayThumbnail.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
            //Main.DisplayRefresh(_teachingDisplay);

            //Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf = new OpenCvSharp.Mat(ofd.FileName, OpenCvSharp.ImreadModes.Grayscale);

            //if (Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf.Depth() != (int)OpenCvSharp.ImreadModes.Grayscale)
            //    OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf, Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

            //Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanOriginalBuf = new OpenCvSharp.Mat(ofd.FileName, OpenCvSharp.ImreadModes.Grayscale);

            //if (Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanOriginalBuf.Depth() != (int)OpenCvSharp.ImreadModes.Grayscale)
            //    OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanOriginalBuf, Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_MatLineScanOriginalBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY); ;

            ///////////////////
            //CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[(int)_camNo].OutputImage as CogImage8Grey);
            //ICogImage8PixelMemory OriginImage8PixelMemory = CogConvertImage.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0,
            //    Main.vision.CogImgTool[(int)_camNo].OutputImage.Width, Main.vision.CogImgTool[(int)_camNo].OutputImage.Height);
            //if (Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgDataATT == null
            //    || Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgCols != Main.vision.CogImgTool[(int)_camNo].OutputImage.Width
            //    || Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgRows != Main.vision.CogImgTool[(int)_camNo].OutputImage.Height)
            //{
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgDataATT = new byte[Main.vision.CogImgTool[(int)_camNo].OutputImage.Width * Main.vision.CogImgTool[(int)_camNo].OutputImage.Height];
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgCols = Main.vision.CogImgTool[(int)_camNo].OutputImage.Width;
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgRows = Main.vision.CogImgTool[(int)_camNo].OutputImage.Height;
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_OrginalImgCols = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgCols;
            //    Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_OrginalImgRows = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgRows;
            //}
            //System.Runtime.InteropServices.Marshal.Copy(OriginImage8PixelMemory.Scan0, Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_imgDataATT, 0,
            //    Main.vision.CogImgTool[(int)_camNo].OutputImage.Width * Main.vision.CogImgTool[(int)_camNo].OutputImage.Height);
            //OriginImage8PixelMemory.Dispose();
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
                cmb.ItemHeight = lblGroupNumber.Height - 7;

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



    public class MakerParameter
    {
        public enum eInspectionType
        {
            THRESHOLD,
            DL_MODE_0,
            DL_MODE_1,
            DL_MODE_2,
        }

        public enum ePanelType
        {
            RIGID,
            FLEXIBLE,
        }

        public enum eTargetType
        {
            COF,
            COG,
            FOG,
        }

        public enum eFilterType
        {
            NORMAL,
            SMALL,
            FILTER_2,
            FILTER_3,
            FILTER_4,
            BIG,
        }

        public enum eFilterDirection
        {
            HORIZONTAL,
            VERTICAL,
        }

        public enum eShadowDirection
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        public enum ePeakProperty
        {
            NORMAL,
            NEAR,
        }

        public enum eStrengthBase
        {
            ENH,
            RAW,
        }

        public enum eThresholdMode
        {
            AUTO,
            WHITE,
            BLACK,
        }
    }
}