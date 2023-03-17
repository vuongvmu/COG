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
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ImageFile;

using static COG.Main;
using JAS.Controls.Display;
using COG.Params;
using COG.Class;
using static COG.Controls.CtrlTeachROIJog;

namespace COG.Controls
{
    public partial class CtrlTeachParticle : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        private BlobParameter _blobParam = new BlobParameter();
  
        private List<BlobParameter> _blobParamList = new List<BlobParameter>();
        private InspectionCount _inspectionCount = new InspectionCount();
        private int _selectedBlobIndex = 0;

        private CogBlobTool _cogBlobTool = new CogBlobTool();
        private CogImage8Grey BlobImage = new CogImage8Grey();
        public CogImage8Grey OriginImage = new CogImage8Grey();
        private List<CogBlobTool> _cogBlobToolList = new List<CogBlobTool>();

        private int _tabNo = 0;
        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_Scan_Start;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        private bool bBlobConvert = false;
        private bool bBlobSearch = false;
        public CtrlTeachParticle(eTeachingPosition teachingPosition)
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

        private void CtrlTeachBlob_Load(object sender, EventArgs e)
        {
            AddControl();

            //CreateObject();
            //GetAlignParameter();

            InitializeUI();
            SetParticleCountProperty((int)_camNo, (int)_stageNo);

            SetParticleProperty((int)_camNo, (int)_stageNo);
            Set_Parameter();
            SetBlobParameter();
            lvBlobResult.View = View.Details;
        }

        private void Set_Parameter()
        {
            lblBlobCountValue.Text = _inspectionCount.BlobCount.ToString();
            AddBlobPointInComboBox(_inspectionCount.BlobCount);
        }

        private void InitializeUI()
        {
            // Area Mode : Thumbnail visible false
            //if (_camNo == eCameraNo.PreAlign)
            //    cogDisplayThumbnail.Visible = false;

            rdoBlobDark.Checked = true;

            trbThresholdValue.Minimum = 0;
            trbThresholdValue.Maximum = 255;
        }

        private void SetParticleCountProperty(int CamNo, int nStageNo)
        {
            _inspectionCount.SetParam(Main.AlignUnit[CamNo].InspectionCnt[nStageNo]);
        }

        private void SetParticleProperty(int nCamNo, int nStagNo)
        {
            for (int i = 0; i < Main.AlignUnit[nCamNo].InspectionParams[nStagNo].BlobParams.Count; i++)
            {
                BlobParameter _blobParam = new BlobParameter();
                _blobParam.SetParam(Main.AlignUnit[nCamNo].InspectionParams[nStagNo].BlobParams[i]);
                _blobParamList.Add(_blobParam);
            }
        }

        private void AddControl()
        {
            // Display
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;
            OriginImage = FormMain.Instance().SelectUnitForm.VisionTeachForm.OriginImage;
            //cogDisplayThumbnail.Image = Main.vision.CogCamBuf[_CamNo];
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

        //private void SetBlobProperty()
        //{
        //    _blobParamList = new List<BlobParameter>();
        //    _blobParamList = Main.AlignUnit[CamNo].InspectionParams[StageNo].BlobParams;
        //}

        //private void btnPrevTab_Click(object sender, EventArgs e)
        //{
        //    PrevTab();
        //}

        //private void PrevTab()
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
        //    NextTab();
        //}

        //private void NextTab()
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

        private void DisplayImage(int tabNumber)
        {
            if (Main.AlignUnit[0].PAT[0, tabNumber].m_CogLineScanBuf == null)
                return;

            _teachingDisplay.Image = Main.AlignUnit[0].PAT[0, tabNumber].m_CogLineScanBuf;

            //cogDisplayThumbnail.Image = Main.AlignUnit[0].PAT[0, tabNumber].m_CogLineScanBuf;
            //cogDisplayThumbnail.Fit();
        }

        private void lblBlobCountValue_Click(object sender, EventArgs e)
        {
            SetBlobAreaCount(sender);
        }

        private void SetBlobAreaCount(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10, outputData, "Input Measure Point", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();
            }

            int blobAreaPointCnt = outputData;
            _inspectionCount.BlobCount = blobAreaPointCnt;
            AddBlobPointInComboBox(blobAreaPointCnt);
            CreateList(blobAreaPointCnt);
            SetBlobParameter();
        }

        private void AddBlobPointInComboBox(int index)
        {
            cmbBlobPointSelect.Items.Clear();

            string point = "";

            for (int i = 0; i < index; i++)
            {
                point = "Point_" + i.ToString();
                cmbBlobPointSelect.Items.Add(point);
            }

            if(index != 0)
               cmbBlobPointSelect.SelectedIndex = 0;
        }

        private void CreateList(int index)
        {
            int nListCnt = _blobParamList.Count;
            if (_blobParamList.Count != index)
            {
                if (_blobParamList.Count > index)
                {
                    _cogBlobToolList.Clear();
                    _blobParamList.Clear();

                    for (int i = 0; i < index; i++)
                    {
                        if (Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobItem != null)
                        {
                            _blobParam = new BlobParameter();
                            _blobParam.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobParams[i]);
                            _blobParamList.Add(_blobParam);
                        }
                        else
                            _blobParamList.Add(new BlobParameter());
                    }
                }
                else
                {
                    int Cnt =   (index + _blobParamList.Count)- index;
                    _cogBlobToolList.Clear();
                    _blobParamList.Clear();
                    for (int i = 0; i < index; i++)
                    {
                        if (i < Cnt)
                        {
                            _blobParam = new BlobParameter();
                            _blobParam.SetParam(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobParams[i]);
                            _blobParamList.Add(_blobParam);
                        }
                        else
                        {
                            _cogBlobToolList.Add(new CogBlobTool());
                            _blobParamList.Add(new BlobParameter());
                        }
                    }
                }
            }
        }

        private void cmbBlobPointSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBlobPointIndex(sender);
            SetBlobParameter();
            ShowROI();
        }

        private void SetBlobPointIndex(object sender)
        {
            ComboBox cmb = sender as ComboBox;
            _selectedBlobIndex = cmb.SelectedIndex;
        }

        private void SetBlobParameter()
        {
            if (_blobParamList.Count <= 0)
                return;

            BlobParameter Para = new BlobParameter();
            Para.SetParam(_blobParamList[_selectedBlobIndex]);

            _cogBlobTool = Para.CogBlobTool;
            _cogBlobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;

            lblMinPixelSize.Text = _cogBlobTool.RunParams.ConnectivityMinPixels.ToString();
            nudThresholdValue.Text = _cogBlobTool.RunParams.SegmentationParams.HardFixedThreshold.ToString();
            lblMaxWidthSizeValue.Text = _blobParamList[_selectedBlobIndex].WidthMax.ToString();
            lblMaxHeightSizeValue.Text = _blobParamList[_selectedBlobIndex].HeightMax.ToString();

            if (_cogBlobTool.RunParams.SegmentationParams.Polarity == CogBlobSegmentationPolarityConstants.DarkBlobs)
                rdoBlobDark.Checked = true;
            else
                rdoBlobLight.Checked = true;
        }

        private void trbThresholdValue_Scroll(object sender, EventArgs e)
        {
            SetHardFixedThreshold(sender);
        }

        private void nudThresholdValue_ValueChanged(object sender, EventArgs e)
        {
            SetHardFixedThreshold(sender);
        }

        private void SetHardFixedThreshold(object sender)
        {
            Control ct = sender as Control;

            if (ct.GetType().Name.ToLower() == "trackbar")
                nudThresholdValue.Text = trbThresholdValue.Value.ToString();
            else if (ct.GetType().Name.ToLower() == "numericupdown")
                trbThresholdValue.Value = Convert.ToInt32(nudThresholdValue.Text);
            else { }

            _cogBlobTool.RunParams.SegmentationParams.HardFixedThreshold = Convert.ToInt32(nudThresholdValue.Text);

            if (_cogBlobTool.Region == null)
                return;
            else
                ExecuteBlob();
        }

        private void lblMinPixelSize_Click(object sender, EventArgs e)
        {
            SetConnectivityMinPixels();
        }

        private void SetConnectivityMinPixels()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 5000, outputData, "Input Lead Count", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                _cogBlobTool.RunParams.ConnectivityMinPixels = outputData;
            }

            lblMinPixelSize.Text = outputData.ToString();
        }
        
        private void rdoSetBlobPolarity_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectBlobPolarity(sender);
        }

        private void SetSelectBlobPolarity(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("dark"))
                    SetBlobPolarity(CogBlobSegmentationPolarityConstants.DarkBlobs);
                else
                    SetBlobPolarity(CogBlobSegmentationPolarityConstants.LightBlobs);

                btn.BackColor = Color.LimeGreen;
                if (_cogBlobTool.Region == null) return;
                else
                    ExecuteBlob();
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetBlobPolarity(CogBlobSegmentationPolarityConstants polarity)
        {
            _cogBlobTool.RunParams.SegmentationParams.Polarity = polarity;
        }

        private void lblMaxWidthSizeValue_Click(object sender, EventArgs e)
        {
            SetMaxWidthSizeValue();
        }

        private void SetMaxWidthSizeValue()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 1000, outputData, "Input Blob Maximum Width", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lblMaxWidthSizeValue.Text = outputData.ToString();
                _blobParam.WidthMax = outputData;
            }
        }

        private void lblMaxHeightSizeValue_Click(object sender, EventArgs e)
        {
            SetMaxHeightSizeValue();
        }

        private void SetMaxHeightSizeValue()
        {
            int outputData = 0;

            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 1000, outputData, "Input Blob Maximum Width", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lblMaxHeightSizeValue.Text = outputData.ToString();
                _blobParam.HeightMax = outputData;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Apply();
        }

        private void Apply()
        {
            ClearGraphic();

            //if (_teachingDisplay.Image == null)
            //    return;

            // _cogBlobToolList[_selectedBlobIndex] = _cogBlobTool;
            BlobParameter Para = new BlobParameter();
            Para.CogBlobTool = _cogBlobTool;
            Para.WidthMax = _blobParam.WidthMax;
            Para.WidthMin = _blobParam.WidthMin;
            Para.HeightMax = _blobParam.HeightMax;
            Para.HeightMin = _blobParam.HeightMin;
            _blobParamList[_selectedBlobIndex] = Para;
        }

        private void btnBlobTest_Click(object sender, EventArgs e)
        {
            ExecuteBlob(/*_cogBlobTool*/);
        }

        private CogGraphicInteractiveCollection _resultOverlay = null;
        private CogGraphicInteractiveCollection _resultOverlayString = null;
        private List<CogBlobResult> _blobResultList = new List<CogBlobResult>();
        private void ExecuteBlob()
        {
            try
            {
                int blobCount = 0;
                ClearGraphic();
                _blobResultList.Clear();

                CogBlobResultCollection blobResult = new CogBlobResultCollection();
                _resultOverlay = new CogGraphicInteractiveCollection();
                _resultOverlayString = new CogGraphicInteractiveCollection();

                lvBlobResult.Items.Clear();

                if (_teachingDisplay.Image == null)
                    return;

                _cogBlobTool.InputImage = OriginImage;
                _cogBlobTool.Run();

                if (_cogBlobTool.Results != null)
                {
                    blobResult = _cogBlobTool.Results.GetBlobs();
                    BlobImage = _cogBlobTool.Results.CreateBlobImage();
                    bBlobSearch = true;
                    

                    foreach (CogBlobResult cogBlobResult in blobResult)
                    {
                        double blobWidth = cogBlobResult.GetMeasure(CogBlobMeasureConstants.BoundingBoxPrincipalAxisWidth);
                        double blobHeight = cogBlobResult.GetMeasure(CogBlobMeasureConstants.BoundingBoxPrincipalAxisHeight);

                        blobWidth = blobWidth * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000;
                        blobHeight = blobHeight * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000;

                        if ((blobWidth < _blobParam.WidthMax) && (blobHeight < _blobParam.HeightMax))
                        {

                        }
                        else
                        {
                            _blobResultList.Add(cogBlobResult);

                            _resultOverlay.Add(cogBlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary));
                            _resultOverlayString.Add(cogBlobResult.CreateResultGraphics(CogBlobResultGraphicConstants.Boundary));

                            CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
                            cogGraphicLabel.Color = CogColorConstants.Red;
                            cogGraphicLabel.Font = new Font(Main.DEFINE.FontStyle, 9);
                            //cogGraphicLabel.Text = string.Format("Width: {0:F3}um, Height: {1:F3}um", blobWidth, blobHeight);
                            cogGraphicLabel.Text = (blobCount + 1).ToString();
                            cogGraphicLabel.X = cogBlobResult.CenterOfMassX;
                            cogGraphicLabel.Y = cogBlobResult.CenterOfMassY;

                            _resultOverlayString.Add(cogGraphicLabel);

                            ListViewItem Data = new ListViewItem((blobCount + 1).ToString());
                            Data.SubItems.Add(blobWidth.ToString("F3"));
                            Data.SubItems.Add(blobHeight.ToString("F3"));
                            lvBlobResult.Items.Add(Data);

                            blobCount++;
                        }
                    }

                    if (chkOverlay.Checked)
                        _teachingDisplay.InteractiveGraphics.AddList(_resultOverlayString, "Result", false);
                    else
                        _teachingDisplay.InteractiveGraphics.AddList(_resultOverlay, "Result", false);
                }
                else
                    //DrawLabel(_teachingDisplay, "Blob search fail.", 0);
                    FormMain.Instance().SelectUnitForm.VisionTeachForm.DrawLabel(_teachingDisplay, "Blob search fail.", 0);

                if (blobCount > 0)
                {
                    bBlobConvert = true;
                    _teachingDisplay.Image = BlobImage;
                    _teachingDisplay.Fit();
                }
                else
                {
                    bBlobSearch = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        private void SaveParams()
        {
            Main.AlignUnit[(int)_camNo].InspectionCnt[(int)_stageNo] = _inspectionCount.Copy();
            Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobParams.Clear();

            for (int i = 0; i < _inspectionCount.BlobCount; i++)
            {
                BlobParameter param = new BlobParameter();

                param.SetParam(_blobParamList[i]);
                Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobItem = param.Copy();
                Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobParams.Add(Main.AlignUnit[(int)_camNo].InspectionParams[(int)_stageNo].BlobItem);
            }
        }

        public void Save()
        {
            SaveParams();

            string filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            string strFileName = string.Format("\\MeasureCount_Cam{0:D}_Stage{1:D}", _camNo, _stageNo);
            filePath += strFileName;
            _inspectionCount.SaveXml(filePath);
            filePath = DEFINE.SYS_DATADIR + DEFINE.MODEL_DATADIR + "\\" + Main.ProjectName + "\\BLOB\\";
            
           // filePath += strFileName;
            for (int i = 0; i < _blobParamList.Count; i++)
            {
                _blobParamList[i].SaveVPP(filePath, (int)_camNo, (int)_stageNo, i);
                _blobParamList[i].SaveXml(filePath, (int)_camNo, (int)_stageNo, i);
            }
        }

        private void btnROIShow_Click(object sender, EventArgs e)
        {
            ShowROI();
        }

        private void ShowROI()
        {
            if (_teachingDisplay.Image == null)
                return;

            ClearGraphic();

            CogRectangleAffine cogRectAffine = new CogRectangleAffine();

            if (_cogBlobTool.Region == null)
            {
                cogRectAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Rotation | CogRectangleAffineDOFConstants.Skew;
                cogRectAffine.Interactive = true;
                cogRectAffine.SetCenterLengthsRotationSkew((_teachingDisplay.Image.Width / 2 - _teachingDisplay.PanX), (_teachingDisplay.Image.Height / 2 - _teachingDisplay.PanY), 300, 300, 0, 0);
            }
            else
                cogRectAffine = (CogRectangleAffine)_cogBlobTool.Region;

            _cogBlobTool.InputImage = _teachingDisplay.Image;
            cogRectAffine.Interactive = true;
            _teachingDisplay.InteractiveGraphics.Add(cogRectAffine, "ROI", false);
            _cogBlobTool.Region = cogRectAffine;
        }

        private void ROITracking()
        {
            _teachingDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            CogGraphicInteractiveCollection ResultGraphy = new CogGraphicInteractiveCollection();
            PointF LeftTranslationData, RightTranslationData, LeftOriginData, RightOriginData;
            if (!Main.MarkSearch((CogImage8Grey)_teachingDisplay.Image, out LeftTranslationData, out RightTranslationData, out LeftOriginData, out RightOriginData, ref ResultGraphy)) return;

            // Step2 Theta Calculation
            double RotT = 0;
            Main.CalculateRotion(LeftOriginData, RightOriginData, LeftTranslationData, RightTranslationData, out RotT);
            CogImage8Grey FixtureImage = new CogImage8Grey();
            // Step3 Image Point Translation
            if (Main.ExcuteFixture((CogImage8Grey)_teachingDisplay.Image, LeftTranslationData, RotT, out FixtureImage))
            {
                _teachingDisplay.Image = FixtureImage;
                _teachingDisplay.InteractiveGraphics.AddList(ResultGraphy, "Result",false);
            }
        }

        private void chkROITracking_CheckedChanged(object sender, EventArgs e)
        {
            if (chkROITracking.Checked)
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
                cmb.ItemHeight = lblBlobCount.Height - 7;

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

        private void chkOverlay_CheckedChanged(object sender, EventArgs e)
        {
            SetOverlay(sender);
        }

        private void SetOverlay(object sender)
        {
            ClearGraphic();

            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
                chk.BackColor = Color.LimeGreen;
            else
                chk.BackColor = Color.DarkGray;

            if (chk.Checked)
            {
                if (_resultOverlayString != null)
                    _teachingDisplay.InteractiveGraphics.AddList(_resultOverlayString, "Result", false);
            }
            else
            {
                if (_resultOverlay != null)
                    _teachingDisplay.InteractiveGraphics.AddList(_resultOverlay, "Result", false);
            }
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
        private void btnConvert_Click(object sender, EventArgs e)
        {
            convert();
        }

        private void convert()
        {
            if (bBlobConvert == true)
            {
                bBlobConvert = false;
                _teachingDisplay.Image = OriginImage;
                _teachingDisplay.Fit();
            }
            else
            {
                bBlobConvert = true;
                if (bBlobSearch == false) return;

                _teachingDisplay.Image = BlobImage;
                _teachingDisplay.Fit();
            }
        }
    }
}
