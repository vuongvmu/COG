using COG.Class;
using COG.Class.MOTION;
using COG.Controls;
using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.Controls.CtrlTeachROIJog;

namespace COG
{
    public partial class FormVisionTeach : Form
    {
        // Renew
        enum Motion {axis_X, axis_Y, axis_Z}
        private FormMotionPopup _formMotionPopup = null;
        public FormROIJog ROIJogForm = null;

        private System.Threading.Timer _grabTimer = null;

        private int _tabNo = 0;

        public CogRecordDisplay TeachDisplay = null;
        public CogImage8Grey OriginImage;


        public CtrlInspectionItem InspecionItemControl = null;
        public List<CtrlInspectionItem> InspectionItemControlList = new List<CtrlInspectionItem>();

        public CtrlTeachLineScan TeachLineScanControl = null;
        public CtrlTeachMark TeachMarkControl = null;
        public CtrlTeachAlign TeachAlignControl = null;
        public CtrlTeachAkkon TeachAkkonControl = null;
        public CtrlTeachMeasure TeachMeasureControl = null;
        public CtrlTeachParticle TeachParticleControl = null;
        public CtrlTeachShort TeachShortControl = null;

        private eTeachingItem _inspectionItem = eTeachingItem.Mark;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_PreAlign_Left;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FormVisionTeach(eTeachingPosition teachingPosition)
        {
            InitializeComponent();
            SetTeachingPosition(teachingPosition);
            SetTeachingUnit(teachingPosition);

            timer1.Tick += timer1_Tick;
            timer1.Interval = 200;

            HistogramImage = new CogImage8Grey();
            CenterRect = new CogRectangle();
            Main.MilFrameGrabber.ReceiveImage += Get_LineScanImage;
        }

        private void SetTeachingPosition(eTeachingPosition teachingPosition)
        {
            _teachingPosition = teachingPosition;
        }

        private void SetTeachingUnit(eTeachingPosition teachingPosition)
        {
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
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.Inspection1;
                    break;

                default:
                    break;
            }
        }

        private void FormVisionTeach_Load(object sender, EventArgs e)
        {
            AddControls();
            InitializeUI();
            UpdateDisplayImage();
        }

        private void AddControls()
        {
            pnlTeach.Visible = false;

            // Add Display
            TeachDisplay = JASDiplayControl.CogDisplay00;
            SetThumbnailDisplayMouseMode();

            // Add Teaching Controls
            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 0);

            TeachLineScanControl = new CtrlTeachLineScan(_teachingPosition);
            TeachLineScanControl.Dock = DockStyle.Fill;
            this.pnlTeachLineScan.Controls.Add(TeachLineScanControl);
            this.pnlTeachLineScan.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 1);

            TeachMarkControl = new CtrlTeachMark(_teachingPosition);
            TeachMarkControl.Dock = DockStyle.Fill;
            this.pnlTeachMark.Controls.Add(TeachMarkControl);
            this.pnlTeachMark.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 2);

            TeachAlignControl = new CtrlTeachAlign(_teachingPosition);
            TeachAlignControl.Dock = DockStyle.Fill;
            this.pnlTeachAlign.Controls.Add(TeachAlignControl);
            this.pnlTeachAlign.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 3);

            TeachAkkonControl = new CtrlTeachAkkon(_teachingPosition);
            TeachAkkonControl.Dock = DockStyle.Fill;
            this.pnlTeachAkkon.Controls.Add(TeachAkkonControl);
            this.pnlTeachAkkon.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 4);

            TeachMeasureControl = new CtrlTeachMeasure(_teachingPosition);
            TeachMeasureControl.Dock = DockStyle.Fill;
            this.pnlTeachMeasure.Controls.Add(TeachMeasureControl);
            this.pnlTeachMeasure.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 5);

            TeachParticleControl = new CtrlTeachParticle(_teachingPosition);
            TeachParticleControl.Dock = DockStyle.Fill;
            this.pnlTeachParticle.Controls.Add(TeachParticleControl);
            this.pnlTeachParticle.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 6);

            TeachShortControl = new CtrlTeachShort(_teachingPosition);
            TeachShortControl.Dock = DockStyle.Fill;
            this.pnlTeachShort.Controls.Add(TeachShortControl);
            this.pnlTeachShort.Visible = false;

            Main.ProgerssBar_Unit(Main.formProgressBar, 7, true, 7);

            pnlTeach.Visible = true;
        }

        private void SetThumbnailDisplayMouseMode()
        {
            cogDisplayThumbnail.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
            cogDisplayThumbnail.PopupMenu = false;
        }

        private void InitializeUI()
        {
            lblStageCam.Text = "SELECT UNIT : " + _teachingPosition.ToString().Replace("_", " ").ToUpper();

            this.Size = new Size(1920, 1012);
            MakeTeachingItemListControl();

            if (Settings.Instance().Operation.UseMark)
                ReceiveTeachingItem(eTeachingItem.Mark, null);

            cogDisplayThumbnail.Dock = DockStyle.Fill;
            cogDisplayThumbnail.Visible = true;
            tlpHistogram.Dock = DockStyle.Fill;
            tlpHistogram.Visible = false;

            if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                cogDisplayThumbnail.Visible = false;
        }

        private void UpdateDisplayImage()
        {
            if (Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf == null)
                return;

            TeachDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            cogDisplayThumbnail.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
        }

        private void MakeTeachingItemListControl()
        {
            tlpTeachingItem.RowStyles.Clear();
            tlpTeachingItem.ColumnStyles.Clear();

            tlpTeachingItem.RowCount = Enum.GetValues(typeof(eTeachingItem)).Length;
            tlpTeachingItem.ColumnCount = 1;

            for (int rowIndex = 0; rowIndex < tlpTeachingItem.RowCount; rowIndex++)
                tlpTeachingItem.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlpTeachingItem.RowCount)));

            for (int columnIndex = 0; columnIndex < tlpTeachingItem.ColumnCount; columnIndex++)
                tlpTeachingItem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / tlpTeachingItem.ColumnCount)));

            foreach (eTeachingItem inspectionItem in Enum.GetValues(typeof(eTeachingItem)))
            {
                switch (inspectionItem)
                {
                    case eTeachingItem.LineScan:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            InspecionItemControl.Enabled = false;
                        else
                            InspecionItemControl.Enabled = true;
                        break;

                    case eTeachingItem.Mark:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (!Settings.Instance().Operation.UseMark)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;

#if ATT
                    case eTeachingItem.Align:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            break;

                        if (!Settings.Instance().Operation.UseAlign)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;

                    case eTeachingItem.Akkon:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            break;

                        if (!Settings.Instance().Operation.UseAkkon)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;
#endif

#if CGMS
                    case eTeachingItem.Particle:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            break;

                        if (!Settings.Instance().Operation.UseParticle)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;

                    case eTeachingItem.Measure:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            break;

                        if (!Settings.Instance().Operation.UseMeasure)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;

                    case eTeachingItem.Short:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        if (_teachingPosition == eTeachingPosition.Stage1_PreAlign_Left || _teachingPosition == eTeachingPosition.Stage1_PreAlign_Right)
                            break;

                        if (!Settings.Instance().Operation.UseShort)
                            break;

                        this.tlpTeachingItem.Controls.Add(InspecionItemControl, 0, (int)inspectionItem);
                        break;
#endif
                    default:
                        break;
                }
            }
        }

        private void ReceiveTeachingItem(eTeachingItem inspectionItem, object sender)
        {
            foreach (var inspectionItemControl in InspectionItemControlList)
                inspectionItemControl.ShowInspectionItem(false);

            InspectionItemControlList[(int)inspectionItem].ShowInspectionItem(true);
            _inspectionItem = inspectionItem;

            ShowTeachControl(_inspectionItem);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Main.MilFrameGrabber.ReceiveImage -= Get_LineScanImage;
            this.Close();
        }

        private void ShowTeachControl(eTeachingItem inspectionItem)
        {
            foreach (Panel panel in pnlTeach.Controls)
            {
                if (panel.Name.ToString().Substring(8) == inspectionItem.ToString())
                {
                    TeachDisplay.InteractiveGraphics.Clear();
                    TeachDisplay.StaticGraphics.Clear();
                    panel.Visible = true;
                }
                else
                    panel.Visible = false;
            }

#if CGMS
            if (inspectionItem == eTeachingItem.Measure)
                TeachMeasureControl.DisplayEvent(true);
            else
                TeachMeasureControl.DisplayEvent(false);
#endif
            if (inspectionItem == eTeachingItem.LineScan)
            {
                cogDisplayThumbnail.Visible = false;
                tlpHistogram.Visible = true;

                chkShowROIJog.Enabled = false;
                chkShowROIJog.Checked = false;
                chkShowROIJog.Visible = false;
            }
            else
            {
                tlpHistogram.Visible = false;
                cogDisplayThumbnail.Visible = true;

                chkShowROIJog.Enabled = true;
                chkShowROIJog.Visible = true;

                Main.VieworksLineScanCamera.SetSensorMode(0);
            }
        }

#region GRAB
        private void Grab()
        {
            if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.AreaMode)
            {
                Main.MilFrameGrabber.AreaGrabImage_Init(0);
                StartGrabTimer();
            }
            else if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.LineMode)
            {
                if (pnlTeachLineScan.Visible)
                {
                    GrabLineScan();
                    TeachLineScanControl.SetRepeatParameter();
                    TeachLineScanControl.MoveRepeat();
                }
                else
                {
                    double dist = (Main.recipe.m_PatternYSize * Main.recipe.m_nTabCount) + (Main.recipe.m_PatternToPatternYDistance * Main.recipe.m_nTabCount - 1);
                    GrabLineScan();
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_Y, Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].UnitPositionList[(int)Motion.axis_Y].TargetPosition);
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_Y);
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].UnitPositionList[(int)Motion.axis_X].TargetPosition);
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
                    int nScanID = 1, nTabCnt;
                    nTabCnt = Main.recipe.m_nTabCount;

                    Main.MilFrameGrabber.GrabLineScan(nScanID, nTabCnt, 0, dist);
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].UnitPositionList[(int)Motion.axis_X].TargetPosition + dist);
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);

                    //Main.MilFrameGrabber.GrabLineScan()
                }
            }
        }
        private void GrabStop()
        {
            if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.AreaMode)
            {
                StopGrabTimer();
            }
            else if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.LineMode)
            {
                Main.MilFrameGrabber.QueueClear();
                TeachLineScanControl.RepeatStop();
            }
        }
		
        private void GrabLineScan()
        {
            CreateScanBuffer();
        }
		
        private void CreateScanBuffer()
        {
            double dist, dTaget = 0;
            // 과장님 테스트용
            double[] dStart;
            double[] dEnd;
            int Scanid = 1, TabCnt = 1;
            if (pnlTeachLineScan.Visible)
            {
                dStart = new double[1];
                dEnd = new double[1];
                dStart[0] = 0;
                dist = TeachLineScanControl.ScanLenth;
                dEnd[0] = dist;
                Main.MilFrameGrabber.UpdateScanGrabParamsManual(0, Scanid, TabCnt, dStart, dEnd, ref Main.AlignUnit[0].PAT, true);
                //Main.MilFrameGrabber.GrabLineScan(Scanid, TabCnt, 0, dist);
            }
            else
            {
                dStart = new double[Main.recipe.m_nTabCount];
                dEnd = new double[Main.recipe.m_nTabCount];
                double dTabLength = Main.recipe.m_PatternYSize;
                for (int nTabNo =0; nTabNo < Main.recipe.m_nTabCount; nTabNo++)
                {
                    if (nTabNo == 0)
                        dStart[nTabNo] = 0;
                    else
                        dStart[nTabNo] = dEnd[nTabNo - 1] + Main.recipe.m_PatternToPatternYDistance; //각 Grab 시작 위치
                    dEnd[nTabNo] = dStart[nTabNo] + dTabLength;
                }
                TabCnt = Main.recipe.m_nTabCount;
                Main.MilFrameGrabber.UpdateScanGrabParamsManual(0, Scanid, TabCnt, dStart, dEnd, ref Main.AlignUnit[0].PAT, true);
            }
        }

        private void StartGrabTimer()
        {
            _grabTimer = new System.Threading.Timer(AreaGrab, null, 100, 100);
        }

        public void StopGrabTimer()
        {
            if (_grabTimer != null)
                _grabTimer.Dispose();
        }

        private delegate void AreaGrabDelegate(object obj);
        private void AreaGrab(object obj)
        {
            if (this.InvokeRequired)
            {
                AreaGrabDelegate Callback = AreaGrab;
                BeginInvoke(Callback, obj);
                return;
            }

            GrabImage();
        }
        private void GrabImage()
        {
            int Width = 0, Height = 0;
            byte[] data = Main.MilFrameGrabber.Grab(0, out Width, out Height);
            if (data != null)
                TeachDisplay.Image = (CogImage8Grey) Main._ClsImage.Convert8BitRawImageToCognexImage(data, Width, Height);
        }
        public void Get_LineScanImage(int nScan, int scene)
        { 
            TeachDisplay.Image = Main.AlignUnit[0].PAT[nScan, scene].m_CogLineScanBuf;
        }
#endregion

#region Event functions related to the thumbnail function
        private bool _isThumbnailMove = false;
        private void cogDisplayThumbnail_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayThumbnail.GetType())
            {
                UpdateDisplayFromThumbnailEvent(sender);
                _isThumbnailMove = true;
            }
        }

        private void cogDisplayThumbnail_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayThumbnail.GetType() && _isThumbnailMove)
                UpdateDisplayFromThumbnailEvent(sender);
        }

        private void cogDisplayThumbnail_MouseUp(object sender, MouseEventArgs e)
        {
            _isThumbnailMove = false;
        }

        private void UpdateDisplayFromThumbnailEvent(object sender)
        {
            if (TeachDisplay.Image == null)
                return;

            CogRecordDisplay thumbnailDisplay = (CogRecordDisplay)sender;

            int x = MousePosition.X;
            int y = MousePosition.Y;

            Point mousePos = new Point(x, y); //프로그램 내 좌표
            Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당
            Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)

            this.Text = x.ToString() + ", " + y.ToString() +
                "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();

            double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

            double panPointX = (double)TeachDisplay.Image.Width * ratio;

            if (TeachDisplay.Zoom > 0 && TeachDisplay.Zoom < 0.2)
                TeachDisplay.Zoom = 0.5;

            panPointX = (TeachDisplay.Image.Width / 2) - panPointX;
            TeachDisplay.PanX = panPointX;
        }
#endregion

#region Renewing...
        private void btnGrabStart_Click(object sender, EventArgs e)
        {
            Grab();
        }

        private void btnGrabStop_Click(object sender, EventArgs e)
        {
            GrabStop();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
		
        public void ButtonRename()
        {
            if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.AreaMode)
            {
                btnGrabStart.Text = "LIVE";
                btnGrabStop.Text = "LIVE STOP";
            }
            else if (TeachLineScanControl._grabMode == CtrlTeachLineScan.eGrabMode.LineMode)
            {
                btnGrabStart.Text = "GRAB START";
                btnGrabStop.Text = "GRAB STOP";
            }
        }
		
        private void LoadImage()
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.ReadOnlyChecked = true;
            openfileDialog.Filter = "Bmp File | *.bmp";
            openfileDialog.ShowDialog();

            if (openfileDialog.FileName != "")
            {
                if (Main.vision.CogImgTool[0] == null)
                    Main.vision.CogImgTool[0] = new Cognex.VisionPro.ImageFile.CogImageFileTool();

                Main.GetImageFile(Main.vision.CogImgTool[0], openfileDialog.FileName);
                Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf = (CogImage8Grey)Main.vision.CogCamBuf[0];
            }

            TeachDisplay.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            cogDisplayThumbnail.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            cogDisplayThumbnail.Zoom = 0.06;
            cogDisplayThumbnail.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
            Main.DisplayRefresh(TeachDisplay);
			TeachParticleControl.OriginImage =(CogImage8Grey) TeachDisplay.Image;
        }
#endregion

#region Histogram
        private void chkHistogram_CheckedChanged(object sender, EventArgs e)
        {
            ExecuteHistogram(chkHistogram.Checked);
        }

        private CogRectangle _cogRect = null;
        private CogRectangle CenterRect = null;
        CogGraphicInteractiveCollection cogGraphic;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart1;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart2;
        CogImage8Grey HistogramImage = null;

        private void ExecuteHistogram(bool isOn)
        {
            if (isOn)
            {
                _cogRect = new CogRectangle();
                _cogRect.Interactive = true;
                _cogRect.GraphicDOFEnable = CogRectangleDOFConstants.All;
                _cogRect.SetCenterWidthHeight(TeachDisplay.Width / 2 - TeachDisplay.PanX, TeachDisplay.Height / 2 - TeachDisplay.PanY, 50, 50);

                if (_cogRect.X < 0)
                    _cogRect.X = 0;
                if (_cogRect.Y < 0)
                    _cogRect.Y = 0;

                cogGraphic = new CogGraphicInteractiveCollection();
                cogGraphic.Add(_cogRect);
                TeachDisplay.InteractiveGraphics.AddList(cogGraphic, "ROI", false);
                HistogramImage = new CogImage8Grey(TeachDisplay.Image as CogImage8Grey);

                timer1.Start();
                chkHistogram.BackColor = Color.LimeGreen;
            }
            else
            {
                timer1.Stop();
                chkHistogram.BackColor = Color.DarkGray;
                TeachDisplay.InteractiveGraphics.Clear();
                chartHistogram.Series.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (TeachDisplay.Image == null)
                return;

            chartHistogram.Series.Clear();

            Chart1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Chart1 = chartHistogram.Series.Add("Gray Level");
            Chart1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            Chart1.Color = Color.Blue;


            CenterRect.SetCenterWidthHeight(_cogRect.CenterX, _cogRect.CenterY, 1, _cogRect.Height);
            CenterRect.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
            CenterRect.Color = CogColorConstants.Cyan;
            TeachDisplay.InteractiveGraphics.Add(CenterRect, "ROI", false);


            chartHistogram.ChartAreas[0].AxisX.LabelStyle.Interval = 10;
            for (int i = (int)CenterRect.Y; i < CenterRect.Y + CenterRect.Height; i++)
            {
                chartHistogram.Series[0].Points.AddXY(i, HistogramImage.GetPixel((int)CenterRect.X, i));    // 그래프에 x, y축 데이터 저장
            }
        }
#endregion
		
		public void DrawLabel(CogRecordDisplay cogDisplay, string resultText, int index = 0)
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

#region ROI Jog
        private void chkShowROIJog_CheckedChanged(object sender, EventArgs e)
        {
            ShowROIJog(sender);
        }

        private void ShowROIJog(object sender)
        {
            if (chkShowROIJog.Checked)
            {
                //pnlROIJog.Visible = true;
                chkShowROIJog.BackColor = Color.LimeGreen;
                ROIJogForm = new FormROIJog(_inspectionItem);
                ROIJogForm.ShowDialog();
            }
            else
            {
                //pnlROIJog.Visible = false;
                chkShowROIJog.BackColor = Color.DarkGray;
            }
        }
        
//        private void ReceiveClickEvent(object sender)
//        {
//            Button button = sender as Button;

//            switch (_inspectionItem)
//            {
//                case eTeachingItem.LineScan:
//                    break;

//                case eTeachingItem.Mark:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        _teachMarkControl.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        _teachMarkControl.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        _teachMarkControl.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        _teachMarkControl.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        _teachMarkControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        _teachMarkControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        _teachMarkControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        _teachMarkControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
//                    break;
//#if ATT
//                case eTeachingItem.Align:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        _teachAlignControl.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        _teachAlignControl.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        _teachAlignControl.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        _teachAlignControl.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        _teachAlignControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        _teachAlignControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        _teachAlignControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        _teachAlignControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
//                    break;

//                case eTeachingItem.Akkon:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        TeachAkkonControl.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        TeachAkkonControl.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        TeachAkkonControl.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        TeachAkkonControl.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        TeachAkkonControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        TeachAkkonControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        TeachAkkonControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        TeachAkkonControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);

//                    if (button.Name.ToString().Contains("SkewCCW"))
//                        TeachAkkonControl.SkewROIJog(eSkewType.CCW);

//                    if (button.Name.ToString().Contains("SkewZero"))
//                        TeachAkkonControl.SkewROIJog(eSkewType.Zero);

//                    if (button.Name.ToString().Contains("SkewCW"))
//                        TeachAkkonControl.SkewROIJog(eSkewType.CW);
//                    break;
//#endif
//#if CGMS
//                case eTeachingItem.Particle:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        _teachParticleControl.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        _teachParticleControl.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        _teachParticleControl.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        _teachParticleControl.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        _teachParticleControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        _teachParticleControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        _teachParticleControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        _teachParticleControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
//                    break;

//                case eTeachingItem.Measure:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        _teachMeasure.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        _teachMeasure.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        _teachMeasure.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        _teachMeasure.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        _teachMeasure.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        _teachMeasure.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        _teachMeasure.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        _teachMeasure.SizeROIJog(eSizeDirection.DecreaseLeftRight);
//                    break;

//                case eTeachingItem.Short:
//                    if (button.Name.ToString().Contains("MoveUp"))
//                        _teachShortControl.MoveROIJog(eMoveDirection.Up);

//                    if (button.Name.ToString().Contains("MoveDown"))
//                        _teachShortControl.MoveROIJog(eMoveDirection.Down);

//                    if (button.Name.ToString().Contains("MoveLeft"))
//                        _teachShortControl.MoveROIJog(eMoveDirection.Left);

//                    if (button.Name.ToString().Contains("MoveRight"))
//                        _teachShortControl.MoveROIJog(eMoveDirection.Right);

//                    if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//                        _teachShortControl.SizeROIJog(eSizeDirection.IncreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//                        _teachShortControl.SizeROIJog(eSizeDirection.DecreaseUpDown);

//                    if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//                        _teachShortControl.SizeROIJog(eSizeDirection.IncreaseLeftRight);

//                    if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//                        _teachShortControl.SizeROIJog(eSizeDirection.DecreaseLeftRight);
//                    break;
//#endif
//                default:
//                    break;
//            }
//            //if (button.Name.ToString().Contains("MoveUp"))
//            //    MoveROIJog(eMoveDirection.Up);

//            //if (button.Name.ToString().Contains("MoveDown"))
//            //    MoveROIJog(eMoveDirection.Down);

//            //if (button.Name.ToString().Contains("MoveLeft"))
//            //    MoveROIJog(eMoveDirection.Left);

//            //if (button.Name.ToString().Contains("MoveRight"))
//            //    MoveROIJog(eMoveDirection.Right);

//            //if (button.Name.ToString().Contains("SizeIncreaseUpDown"))
//            //    SizeROIJog(eSizeDirection.IncreaseUpDown);

//            //if (button.Name.ToString().Contains("SizeDecreaseUpDown"))
//            //    SizeROIJog(eSizeDirection.DecreaseUpDown);

//            //if (button.Name.ToString().Contains("SizeIncreaseLeftRight"))
//            //    SizeROIJog(eSizeDirection.IncreaseLeftRight);

//            //if (button.Name.ToString().Contains("SizeDecreaseLeftRight"))
//            //    SizeROIJog(eSizeDirection.DecreaseLeftRight);
//        }
#endregion

        private void btnMotionPopup_Click(object sender, EventArgs e)
        {
            OpenFromMotionPopup();
        }

        private void OpenFromMotionPopup()
        {
            if (_formMotionPopup == null)
            {
                _formMotionPopup = new FormMotionPopup(_teachingPosition);
                _formMotionPopup.CloseEventDelegate = () => this._formMotionPopup = null;
                _formMotionPopup.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            switch (_inspectionItem)
            {
                case eTeachingItem.LineScan:
                    TeachLineScanControl.Save();
                    break;

                case eTeachingItem.Mark:
                    TeachMarkControl.Save();
                    break;
#if CGMS
                case eTeachingItem.Particle:
                    TeachParticleControl.Save();
                    break;

                case eTeachingItem.Measure:
                    TeachMeasureControl.Save();
                    break;

                case eTeachingItem.Short:
                    TeachShortControl.Save();
                    break;
#endif
#if ATT
                case eTeachingItem.Align:
                    TeachAlignControl.Save();
                    break;

                case eTeachingItem.Akkon:
                    TeachAkkonControl.Save();
                    break;
#endif
                default:
                    break;
            }
        }
    }
}
