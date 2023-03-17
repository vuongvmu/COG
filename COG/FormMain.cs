using COG.Class;
using COG.Class.MOTION;
using COG.Controls;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using JASLogLibrary;
using JASUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static COG.InspectionItem;

namespace COG
{
    public partial class FormMain : Form
    {
        private static int nDisMax = 24;//갯수는 메인화면 디스플레이 갯수랑 통일

        private List<DataGridView> GridView_Log = new List<DataGridView>();
        private DataGridView[] InspecGridView = new DataGridView[Main.DEFINE.AlignUnit_Max];
        private Thread LineScanGrab = null;
        private List<ListBox> ListBox_Log = new List<ListBox>();
        private List<ListBox> ListBox_Length = new List<ListBox>();

        private List<CogRecordDisplay> cogDisplay = new List<CogRecordDisplay>();
        private List<Button> cogDisplayButton = new List<Button>();

        private static int[] cogDisplayCamNo = new int[nDisMax]; 
        private List<CogDisplayToolbarV2> cogDiToolBar = new List<CogDisplayToolbarV2>();
        private List<CogDisplayStatusBarV2> cogDisStatuBar = new List<CogDisplayStatusBarV2>();
        private static Mutex[] Mutex_lock_LoglistBox = new Mutex[Main.DEFINE.AlignUnit_Max];
        private static Mutex[] Mutex_lock_GridView = new Mutex[Main.DEFINE.AlignUnit_Max];
        private static Mutex[] Mutex_lock_InspecGridView = new Mutex[Main.DEFINE.AlignUnit_Max];
        private static Mutex[] Mutex_lock_ProcStatus = new Mutex[Main.DEFINE.AlignUnit_Max];

        private static Mutex[] Mutex_lock_CogDisplay = new Mutex[Main.DEFINE.DISPLAY_MAX];
        private bool threadFlag;
        private bool GrabThreadFlag;
        private Thread ThreadProcM;
        private int nSelectStageNum = 0;

        private Form_PatternSelect Pattern_Select = new Form_PatternSelect();
        private Form_LogView Formlogview = new Form_LogView();
        private Form_Melsec Melsec = new Form_Melsec();
        private Form_CCLink FormCCLink = new Form_CCLink();
        private Form_CalDisplay formCalDis = new Form_CalDisplay();
        private Form_Message formMessage = new Form_Message();

        private Form_RCS form_RCS = new Form_RCS();

        private Form_TrayDataView form_trayDataview = new Form_TrayDataView();

        private Main.MTickTimer timerTemp = new Main.MTickTimer();

        private Form_LiveView[] formLiveview = new Form_LiveView[Main.DEFINE.CAM_MAX];

        private DateTime mCurrentTime = new DateTime();

        private Form_ManualSet[] FormManualSet = new Form_ManualSet[Main.DEFINE.AlignUnit_Max];
        private Form_Chart[] formChart = new Form_Chart[Main.DEFINE.AlignUnit_Max];
        private Form_NGMonitor[] FormNgMonitor = new Form_NGMonitor[Main.DEFINE.AlignUnit_Max];
       //  private Form_Chart formChart = new Form_Chart();

        private List<Label>[] LB_INSP = new List<Label>[8];

        private List<Label> LIST_LB_PROC_TIME = new List<Label>();
        private List<Label> LIST_LB_POINT_NG_CNT = new List<Label>();
        private List<PictureBox> LIST_PB_CAM_CONSTAT = new List<PictureBox>();
        private List<PictureBox> LIST_PB_CAM_DISCONSTAT = new List<PictureBox>();
        private List<PictureBox> LIST_PB_LIGHT_CONSTAT = new List<PictureBox>();
        private List<PictureBox> LIST_PB_LIGHT_DISCONSTAT = new List<PictureBox>();

        public CtrlPreAlignViewer PreAlignViewerControl = null;
        public CtrlCGMSResult CGMSResultControl = null;
        public CtrlLogViewer SystemLogViewerControl = null;

        private int[] nMainLiveFlag = new int[Main.DEFINE.CAM_MAX];

        private int nModelChangeTime = 0;

        #region SystemTime
        [DllImport("kernel32.dll", SetLastError = true)]
         public static extern int SetSystemTime([In] Main.SystemTime st);
        #endregion

        #region ATT
        //public static void cbProgress(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ProcessATTResult(nStageNo, nTapNo, bSliceInsp, nError);
        //    }
        //}
        //CALLBACKFUNC cb = new CALLBACKFUNC(cbProgress); //콜백함수 선언
        #endregion

        private UserControl_Info _mUI_Info;

        // FormMain.Instance()를 통해 Control 호출 시 Null Ex 발생 중
        ///* ATT
        public CtrlAkkonViewer AkkonViewerControl = null;
        public CtrlAlignViewer AlignViewerControl = null;
        /**/

        // CGMS
        public CtrlCGMSViewer CGMSViewerControl = null;
        public CtrlCGMSHistory CGMSHistoryControl = null;

        public FormAuthority AuthorityForm = null;
        public CtrlSystemInformation SystemInformationControl = null;

        //public FormVisionTeach VisionTeachForm = null;

        private static FormMain _instance = null;
        public static FormMain Instance()
        {
            if (_instance == null)
                _instance = new FormMain();

            return _instance;
        }

        public FormMain()
        {
            InitializeComponent();
            string _Assemblyname = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; //속성 -> 응용프로그램 ->어셈블리이름
            DateTime lastWriteTime = System.IO.File.GetLastWriteTimeUtc(Application.StartupPath + "\\" + _Assemblyname + ".exe").ToLocalTime(); //Application.ProductName 
            this.Text = this.Text+"  "+"Build: " + lastWriteTime.ToString();

            string LoginDate;
            LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(Main.DEFINE.NON_STANDARD)
                this.Text += "          " + "Login: " + LoginDate.ToString() + "  SYMMETRY 대칭 장비" + "   " + Main.DEFINE.PROGRAM_TYPE.ToString();
            else
                this.Text += "          " + "Login: " + LoginDate.ToString() + "  STANDARD 표준 장비" + "   " + Main.DEFINE.PROGRAM_TYPE.ToString();

            this.Size = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);

            // PJH_230104_S
            _mUI_Info = new UserControl_Info(1);
            _mUI_Info.Dock = DockStyle.Fill;
            pnlCPU_Usage.Controls.Add(_mUI_Info);

            SystemInformationControl = new CtrlSystemInformation();
            pnlSystemInformation.Dock = DockStyle.Fill;
            pnlSystemInformation.Controls.Add(SystemInformationControl);
            // PJH_230104_E
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Logo
#if CGMS
            picLogo.Image = COG.Properties.Resources.SDBIO;
#endif
#if ATT
            picLogo.Image = COG.Properties.Resources.SAMSUNG;
#endif
            OpenCvSharp.Mat m_MatTempImage = new OpenCvSharp.Mat();
            TAB_IMG_DISPLAY.Appearance = TabAppearance.Buttons;
            TAB_IMG_DISPLAY.SizeMode = TabSizeMode.Fixed;
            TAB_IMG_DISPLAY.ItemSize = new Size(0, 1); // TAB 우측 버튼부분 숨기려고 만듬
                                                       //TAB_IMG_DISPLAY.ItemSize = new System.Drawing.Size(0, 1); //TAB 옆라인숨김 지우지말것
                                                       //YSH 2022 08 30
            // Logger Initial
            Logger.Initialize();

            // CSV Helper Initial
            CSVHelper.Initialize();
            CSVHelper.WriteHeader(InspectionResult.AkkonInspectionResult.HistoryName, InspectionResult.AkkonInspectionResult.CSVHeader);
            CSVHelper.WriteHeader(InspectionResult.AlignInspectionResult.HistoryName, InspectionResult.AlignInspectionResult.CSVHeader);

            Main.System_Initial();
            Main.Vision_Initial();
            Light.Port_Initial();
            Console.WriteLine("Vision Intialize Finished.");

            //Main.AlignUnit_Initial();   
            Main.MachineDataLoad();
            Main.RecipeDataLoad();
            Main.AlignUnitPat_Initial();
            Main.SystemLoad();
            Settings.Instance().Load();

#if SIMUL
            LicenseCheck();
            MessageBox.Show("Simlulation Mode");
#else
            if (LicenseCheck())
            {
                for (int camNo = 0; camNo < Main.DEFINE.CAM_COUNT; camNo++)
                {
                    for (int stageNo = 0; stageNo < Main.DEFINE.STAGE_COUNT; stageNo++)
                    {
                        string filePath = Main.ModelPath + Main.ProjectName;
                        string fileName = string.Format("\\MeasureCount_Cam{0:D}_Stage{1:D}.xml", camNo, stageNo);

                        filePath += fileName;
                        Main.AlignUnit[camNo].InspectionCnt[stageNo].LoadXml(filePath);
                        filePath = Main.ModelPath + Main.ProjectName;

                        for (int toolNo = 0; toolNo < Main.AlignUnit[camNo].InspectionCnt[stageNo].BlobCount; toolNo++)
                            Main.ReadBlobParameter(camNo, stageNo, toolNo);

                        for (int toolNo = 0; toolNo < Main.AlignUnit[camNo].InspectionCnt[stageNo].CaliperCount; toolNo++)
                            Main.ReadCaliperParamerter(camNo, stageNo, toolNo);

                        for (int toolNo = 0; toolNo < Main.AlignUnit[camNo].InspectionCnt[stageNo].CircleCount; toolNo++)
                            Main.ReadFindCircleParamerter(camNo, stageNo, toolNo);

                        for (int toolNo = 0; toolNo < Main.AlignUnit[camNo].InspectionCnt[stageNo].BeadToolCount; toolNo++)
                            Main.ReadBeadParameter(camNo, stageNo, toolNo);

                        for (int markIndex = 0; markIndex < Enum.GetValues(typeof(eMarkIndex)).Length; markIndex++)
                            Main.ReadPatternParameter(camNo, stageNo, markIndex);
                    }
                }
            }
#endif

            //Initialize_LineScanBuffer();
            //2023 0117 YSH 조명연결부분 - 동작테스트 -
            //LightControl.LightComport[0] = 3;//Main_DataFile.cs에 추후 구현 필요
            //LightControl.LightMaker[0] = "DR";//Main_DataFile.cs에 추후 구현 필요
            //LightControl.Port_Initial((int)LightControl.eLightController.PREALIGN_CONTROL, LightControl.LightComport[0]);
            //LightControl.SetLightLevel((int)LightControl.eLightController.PREALIGN_CONTROL, (int)LightControl.eLightChannel.ATT_PREALIGN_SPOT_WHITE, 100);


            //Main.VieworksLineScanCamera.SetDefaultParameter();
            ////////////////////////////////////////

            //Light.Port_Initial();
            //CameraLinkComms.InitPort();



            InitializeMotionDevice();
            Initialize_LineScanBuffer();
            Main.MilFrameGrabber.ReceiveImage += Get_LineScanImage;
            ////////////////////////////////////////////////////////////////////////////////////
            // ATT Initialize
            //if (Main.DEFINE.OPEN_F)
            //{
            //    //추후 Model Recipe Read 하여 BufferSize 설정하는 방식으로 개선 예정
            //    Main.vision.IMAGE_SIZE_X[0] = 30400;    
            //    Main.vision.IMAGE_SIZE_Y[0] = 2150;
            //}
            Main.ATT_InitSystem(this.Handle, 8, 0xF8);   // Core 1111 1000
                                                         //NativeMethods.CallBackRegistry(cb);


            //Main.ATT_CreateDLLBuffer();
            //Main.ATT_CreateImageBuffer();

            //Main.MilFrameGrabber.ReceiveImage += Get_LineScanImage;
            //2022 1004 YSH
            //Resize 0.5 사용시 Result 이미지 이상출력, 추후 수정필요
            Main.DEFINE.ImageResizeRatio = (float)0.6;
            Main.ATT_CreateDLLBuffer();
            Main.ATT_CreateImageBuffer();
            ////////////////////////////////////////////////////////////////////////////////////


            if (!Main.DEFINE.OPEN_F && !Main.DEFINE.OPEN_CAM)
            {
                // CCLink
                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" && Main.DEFINE.UNIT_TYPE == "5588")
                    Main.CCLink_Initialize(0x4E0, 0x400, 0x4E0, 24, 56, 2, 14, 6, 32, 64, 1000, 2000, 3000, 4000, 5000, 6000);      // 5588
                else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" && Main.DEFINE.UNIT_TYPE == "2755")
                    Main.CCLink_Initialize(0x500, 0x420, 0x500, 40, 72, 2, 14, 6, 32, 64, 1000, 2000, 3000, 4000, 5000, 6000);    // 2755
                else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                    Main.CCLink_Initialize(0x6C0, 0x420, 0x6C0, 136, 136, 4, 0, 4, 32, 64, 1000, 2000, 3000, 4000, 5000, 6000);

                // MELSEC
                try
                {
                    Main.OpenDM(Main.DEFINE.ReadLocalPort, Main.DEFINE.ReadRemotePor, Main.DEFINE.RemoteIP, 5000, Main.DEFINE.WriteLocalPort, Main.DEFINE.WriteRemotePort);
                    Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.CURRENT_MODEL_CODE, Convert.ToInt32(Main.ProjectName));
                }
                catch
                {

                }

                // RDP
                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
                {
                    if (!Main.FTPConnectToServer("12.96.142.43", "21", "rdpusr", "rdp!rdp"))
                        Save_SystemLog("Failed to connecting FTP Server!", Main.DEFINE.CMD);
                }
            }

            // PJH_20220921_S
            //Allocate_Array();
            InitializeViewerUI();
            // PJH_20220921_E

            // PJH_20220826_S
            //string strTempName = "";
            //for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
            //{
            //    cogDisplay[i].Image = Main.vision.CogCamBuf[cogDisplayCamNo[i]];
            //    Main.DisplayClear(cogDisplay[i]);
            //    Main.DisplayRefresh(cogDisplay[i]);
            //    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            //    {
            //        strTempName = "CB_LIVE_CHECK_CAM" + (i+1).ToString("0");
            //        CheckBox CB = (CheckBox)this.Controls["TAB_IMG_DISPLAY"].Controls["Tab_Num_0"].Controls[strTempName];

            //        //CB_LIVE_CHECK_CAM1.Size = new System.Drawing.Size(30, 30);
            //        // 왼쪽 하단
            //        int nX = cogDisplay[i].Location.X;
            //        int nY = cogDisplay[i].Location.Y + cogDisplay[i].Size.Height - CB_LIVE_CHECK_CAM1.Size.Height;
            //        // 오른쪽 하단
            //        //int nX = cogDisplay[i].Location.X + cogDisplay[i].Size.Width - CB_LIVE_CHECK_CAM1.Size.Width;
            //        //int nY = cogDisplay[i].Location.Y + cogDisplay[i].Size.Height - CB_LIVE_CHECK_CAM1.Size.Height;
            //        //CB_LIVE_CHECK_CAM1.Location = new System.Drawing.Point(nX, nY);
            //        CB.Location = new System.Drawing.Point(nX, nY);
            //    }
            //    //Main.AlignUnit[0].LogdataDisplay(i.ToString() + "th X " + cogDisplay[i].Location.X.ToString() + " Y " + cogDisplay[i].Location.Y.ToString()
            //    //     + " W " + cogDisplay[i].Size.Width.ToString() + " H " + cogDisplay[i].Size.Height.ToString(), true);
            //}
            // PJH_20220826_E

            Main.Status.MC_MODE = Main.DEFINE.MC_MAINFORM;
            Thread_Initial_Start();
            Main.Thread_Initial_Start();

            Main.ThreadCAM_Initial_Start();

            timer1.Enabled = true;
            timerStatus.Enabled = true;
            if (Main.machine.m_nOldLogCheckPeriod > 0)
                SetTimerDirInterval(Main.machine.m_nOldLogCheckPeriod);
            timer_Directory.Enabled = true;

            if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC3")
            {
                BTN_LIGHT_FPC.Visible = true;
                BTN_LIGHT_PANEL.Visible = true;
            }
            else
            {
                BTN_LIGHT_FPC.Visible = false;
                BTN_LIGHT_PANEL.Visible = false;
            }

            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                if (Main.AlignUnit[i].m_AlignName == "COF_CUTTING_ALIGN"|| Main.AlignUnit[i].m_AlignName == "PBD1" || Main.AlignUnit[i].m_AlignName == "PBD2" || Main.AlignUnit[i].m_AlignName == "PBD_FOF1" || Main.AlignUnit[i].m_AlignName == "PBD_FOF2") //|| Main.AlignUnit[i].m_AlignName == "ACF_CUT_2")
                        ListBox_Length[i].Visible = true;


                if (Main.AlignUnit[i].m_AlignName == "FPC_TRAY1")
                    BTN_TRAY_VIEW.Visible = true;
            }
            Save_SystemLog("PROGRAM START", Main.DEFINE.CMD);

            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_READY, true);
            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_RUN, false);

            // PJH_TEST_20230306_S
#if ATT
            SystemLogViewerControl.AddLog("PROGRAM START");
#endif
#if CGMS
            for (int unitIndex = 0; unitIndex < Main.DEFINE.PJH_TEST_UNIT_COUNT; unitIndex++)
            {
                string tempText = string.Empty;
                if (unitIndex == 0)
                    tempText = "PREALIGN1 - CAM1";
                else if (unitIndex == 1)
                    tempText = "STAGE1 - CAM2";

                CGMSHistoryControl.CGMSLogViewerControlList[unitIndex].AddLog("[" + tempText + "] " + "PROGRAM START");
            }
            // PJH_TEST_20230306_E
#endif
            LineScanGrabThreadstart();
        }

        /// <summary>
        /// Line Scan Image Buffer 활당
        /// </summary>
        public void Initialize_LineScanBuffer()
        {
            int Scanid = 1;
            double[] dStart = new double[Main.recipe.m_nTabCount];
            double[] dEnd = new double[Main.recipe.m_nTabCount];
            double dTabLength = 0;
            
                for (int i = 0; i < Main.recipe.m_nTabCount; i++)
                {
                    //2023 0126 YSH Buffer 계산부분         
                    dTabLength = Main.recipe.m_PatternYSize; //Pattern Size
                    if (i == 0)
                        dStart[i] = 0;
                    else
                        dStart[i] = dEnd[i-1] + Main.recipe.m_PatternToPatternYDistance; //각 Grab 시작 위치

                    dEnd[i] = dStart[i] + dTabLength;
                }
              
                Main.MilFrameGrabber.UpdateScanGrabParamsManual(0, Main.recipe.m_nScanCount, Main.recipe.m_nTabCount, dStart, dEnd, ref Main.AlignUnit[0].PAT, false);
            
        }
        private void InitializeMotionDevice()
        {
            // Motion 연결 안한 상태로 코딩 작업
            Main.Instance().MotionManager.CreateObject(eMotionMaker.ACS);

            if (Main.Instance().MotionManager.InitializeDevice(eProtocolType.Ethernet) != eConnectionStatus.Done)
                Save_SystemLog("[ACS Motion Device] Connection Fail", Main.DEFINE.CMD);
            else
            {
                Save_SystemLog("[ACS Motion Device] Connection Success", Main.DEFINE.CMD);

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                    Main.Instance().MotionManager.SetDefaultParameter(axis);

                Save_SystemLog("[ACS Motion Device] Set Default Parameter", Main.DEFINE.CMD);
            }

            Main.ReadMotionData();

            // Main.CreateMotionParameter();

            //Main.ReadMotionParameter();
            //foreach (eAxis axis in collection)
            //{

            //}
            //Main.Instance().MotionManager.SetProperty();

            Main.CreateTeachingParameter();
            Main.ReadTeachingParameter();
        }

        //public void Navi_ReDraw()
        //{
        //    if (CGMSNavigatorControl != null)
        //        CGMSNavigatorControl = null;

        //    CGMSNavigatorControl = new CtrlCGMSNavigator(Main.recipe.m_nScanCount , Main.recipe.m_nTabCount);
        //    this.pnlPreAlignViewer.Controls.Clear();

        //    CGMSNavigatorControl.Dock = DockStyle.Fill;
        //    this.pnlPreAlignViewer.Controls.Add(CGMSNavigatorControl);
        //}

        private void InitializeViewerUI()
        {
            TAB_IMG_DISPLAY.Visible = false;
            this.tlpGrabView.Visible = true;
            //this.tlpGrabView.Location = new Point(0, 62);
            //this.tlpGrabView.Size = new Size(1419, 832);

#if ATT
            // Top
            tlpGrabView.RowStyles.Clear();
            tlpGrabView.ColumnStyles.Clear();

            tlpGrabView.RowCount = 2;
            tlpGrabView.ColumnCount = 1;

            tlpGrabView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            tlpGrabView.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            AkkonViewerControl = new CtrlAkkonViewer();
            this.tlpGrabView.Controls.Add(AkkonViewerControl, 0, 0);
            AkkonViewerControl.Dock = DockStyle.Fill;
            AkkonViewerControl.MakeDisplay(tabCount: 5);

            tlpGrabView.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            AlignViewerControl = new CtrlAlignViewer();
            this.tlpGrabView.Controls.Add(AlignViewerControl, 0, 1);
            AlignViewerControl.Dock = DockStyle.Fill;
            AlignViewerControl.MakeDisplay(tabCount: 5);


            // Bottom
            tlpInformation.RowStyles.Clear();
            tlpInformation.ColumnStyles.Clear();

            tlpInformation.RowCount = 1;
            tlpInformation.ColumnCount = 2;

            tlpInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            tlpInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75));
            PreAlignViewerControl = new CtrlPreAlignViewer();
            this.tlpInformation.Controls.Add(PreAlignViewerControl);
            PreAlignViewerControl.Dock = DockStyle.Fill;

            tlpInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            SystemLogViewerControl = new CtrlLogViewer("System");
            this.tlpInformation.Controls.Add(SystemLogViewerControl);
            SystemLogViewerControl.Dock = DockStyle.Fill;
#endif


#if CGMS
            // Top
            CGMSViewerControl = new CtrlCGMSViewer();
            this.tlpGrabView.Controls.Add(CGMSViewerControl, 0, 0);
            CGMSViewerControl.Dock = DockStyle.Fill;

            // Bottom
            tlpInformation.RowStyles.Clear();
            tlpInformation.ColumnStyles.Clear();

            // TEST_230303_S
            //tlpInformation.RowCount = 1;
            //tlpInformation.ColumnCount = 2;

            //tlpInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            //tlpInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            //CGMSResultControl = new CtrlCGMSResult();
            //this.tlpInformation.Controls.Add(CGMSResultControl);
            //CGMSResultControl.Dock = DockStyle.Fill;

            //tlpInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            //SystemLogViewerControl = new CtrlLogViewer("System");
            //this.tlpInformation.Controls.Add(SystemLogViewerControl);
            //SystemLogViewerControl.Dock = DockStyle.Fill;

            tlpInformation.RowCount = 1;
            tlpInformation.ColumnCount = 1;

            tlpInformation.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tlpInformation.RowCount));
            tlpInformation.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tlpInformation.ColumnCount));

            CGMSHistoryControl = new CtrlCGMSHistory();
            this.tlpInformation.Controls.Add(CGMSHistoryControl);
            CGMSHistoryControl.Dock = DockStyle.Fill;
            // TEST_230303_E


            // CGMS Navigator : 삭제
            //CGMSNavigatorControl = new CtrlCGMSNavigator(Main.recipe.m_nScanCount, Main.recipe.m_nTabCount);
            //CGMSNavigatorControl.Dock = DockStyle.Fill;
            //this.pnlPreAlignViewer.Controls.Add(CGMSNavigatorControl);
#endif
            //// Example
            //List<CogImage8Grey> exampleImageList = new List<CogImage8Grey>();

            //// Image from file
            //Cognex.VisionPro.ImageFile.CogImageFileTool exampleImageFileTool = new Cognex.VisionPro.ImageFile.CogImageFileTool();

            //int totalImageCount = rowCount * columnCount;
            //for (int totalCount = 0; totalCount < totalImageCount; totalCount++)
            //{
            //    exampleImageFileTool.Operator.Open("D:\\Systemdata_ATT_LINE_PC1\\" + Main.ProjectName + "\\MODEL_VISION\\Test_" + totalCount.ToString("D2") + ".bmp", Cognex.VisionPro.ImageFile.CogImageFileModeConstants.Read);
            //    exampleImageFileTool.Run();
            //    exampleImageList.Add(new CogImage8Grey(exampleImageFileTool.OutputImage as CogImage8Grey));

            //    // Change backcolor after grab
            //    CGMSNavigatorControl.UpdateGrabStatus(totalCount);
            //}



            //2022 1009 YSH
            //해당부분 호출 시, 티칭UI에서 Display 동작이 안됨.. 확인필요
            //FormMain.Instance().AkkonViewerControl = AkkonViewerControl;
            //FormMain.Instance().AlignViewerControl = AlignViewerControl;

            //for (int i = 0; i < stageCount; i++)
            //{
            //    Controls.CtrlGrabView grabViewControl = new Controls.CtrlGrabView();
            //    this.tlpGrabView.Controls.Add(grabViewControl, 0, i);

            //    grabViewControl.Dock = DockStyle.Fill;
            //    grabViewControl.MakeDisplay(i);
            //}
        }

        private void TestImageLoad(int tt)
        {
            if (tt == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        string strFile = string.Format("D:\\1\\1\\{0:D}_{1:D}.bmp", i, j);
                        if (Main.vision.CogImgTool[0] == null)
                            Main.vision.CogImgTool[0] = new CogImageFileTool();

                        Main.GetImageFile(Main.vision.CogImgTool[0], strFile);
                        Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;
                        Main.AlignUnit[0].PAT[i, j].m_CogLineScanBuf = (CogImage8Grey)Main.vision.CogCamBuf[0];
                    }
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        string strFile = string.Format("D:\\1\\2\\{0:D}_{1:D}.bmp", i, j);
                        if (Main.vision.CogImgTool[0] == null)
                            Main.vision.CogImgTool[0] = new CogImageFileTool();

                        Main.GetImageFile(Main.vision.CogImgTool[0], strFile);
                        Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;
                        Main.AlignUnit[0].PAT[i, j].m_CogLineScanBuf = (CogImage8Grey)Main.vision.CogCamBuf[0];
                    }
                }
            }
        }

        private bool LicenseCheck()
        {
            bool nRet = false;

            CogStringCollection LicensedFeatures = new CogStringCollection();

            try
            {
                //LicensedFeatures = CogMisc.GetLicensedFeatures(false);
                LicensedFeatures = CogLicense.GetLicensedFeatures(false, false);

                for (int i = 0; i < LicensedFeatures.Count; i++)
                {
                    //if (LicensedFeatures[i] == "VxCnlSearch") // "VxCaliper" , "VxBlob"
                    if (LicensedFeatures[i] == "VisionPro.CnlSearch") // "VxCaliper" , "VxBlob"
                    {
                        nRet = true;
                        break;
                    }
                }
            }
            catch
            {
                nRet = false;
            }

            if (!nRet) 
                MessageBox.Show("Cognex USB Lincense not detected");

            return nRet;
        }

        private void ReadModuleID()
        {
            string LogMsg = "";
            string m_data;
            char m_CharData;
            long dataNum;
            int Cellid_READ_Address = 0;

            Cellid_READ_Address = Main.DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.MODULED_NUM;
            Main.machine.m_strModuleID = "";

            for (int i = 0; i < 10; i++)
            {
                dataNum = PLCDataTag.RData[Cellid_READ_Address + i] & 0x00ff;       //RData 1개 = 2byte => 한글자 1byte 
                m_CharData = Convert.ToChar(dataNum);
                m_data = m_CharData.ToString();
                if (m_data == "\0") break;
                Main.machine.m_strModuleID += m_CharData.ToString();     //하위 글자

                dataNum = (PLCDataTag.RData[Cellid_READ_Address + i] >> 8) & 0x00ff;
                m_CharData = Convert.ToChar(dataNum);
                m_data = m_CharData.ToString();
                if (m_data == "\0") break;
                Main.machine.m_strModuleID += m_CharData.ToString();     //상위 글자
            }

            LogMsg = "Module_ID" + " <- " + Main.machine.m_strModuleID;
            Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
        }

        private void Allocate_Array()
        {
            int[,] nDefaultName = new int[Main.DEFINE.DISPLAY_MAX, 3];
            int nAlignUnit = 0;
            int nPatTag = 1;
            int nPat = 2;

            if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM)
            {
                btnCommandTest.Visible = true;
                txtCommandTest.Visible = true;
                BTN_CCLINKTEST.Visible = true;
                BTN_MXTEST.Visible = true;
            }

//            if (Main.DEFINE.PROGRAM_TYPE == "FOF_PC1" || Main.DEFINE.PROGRAM_TYPE == "TFOF_PC1") BTN_TRAY_VIEW.Visible = true;


#region Allocate_Control
            int nTabNum = 0;
            cogDisplay.Clear();
            for (int i = 0; i < nDisMax; i++)
            {
                string nTempName;
                int nNum;
                nNum = (i + 1);

                if (i < 8)
                {
                    nTabNum = 0;
                }
                else
                {
                    if (i < 16)
                        nTabNum = 1;
                    else
                        nTabNum = 2;
                }

                nTempName = "MA_Display" + nNum.ToString("00");
                CogRecordDisplay nType1 = (CogRecordDisplay)this.Controls["TAB_IMG_DISPLAY"].Controls["Tab_Num_" + nTabNum.ToString()].Controls[nTempName];
                cogDisplay.Add(nType1); //TAB_IMG_DISPLAY

                nNum = (i + 1);
                nTempName = "BTN_DISNAME_" + nNum.ToString("00");

                Button nButton = (Button)this.Controls["TAB_IMG_DISPLAY"].Controls["Tab_Num_" + nTabNum.ToString()].Controls[nTempName];
                cogDisplayButton.Add(nButton);

            }

            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                string nTempName;
                int nNum;
                nNum = i + 1;

                nTempName = "LB_Lisi_" + nNum.ToString("00");
                ListBox nType1 = (ListBox)this.Controls["TAB_LOGDISPLAY"].Controls["tabPage" + i.ToString()].Controls[nTempName];
                ListBox_Log.Add(nType1);

                nTempName = "DG_VIEW_" + nNum.ToString("00");
                DataGridView nType2 = (DataGridView)this.Controls["TAB_LOGDISPLAY"].Controls["tabPage" + i.ToString()].Controls[nTempName];
                GridView_Log.Add(nType2);

                nTempName = "LB_Lisi_LENGTH_" + nNum.ToString("00");
                ListBox nType3 = (ListBox)this.Controls["TAB_LOGDISPLAY"].Controls["tabPage" + i.ToString()].Controls[nTempName];
                ListBox_Length.Add(nType3);

                FormManualSet[i] = new Form_ManualSet();
                FormNgMonitor[i] = new Form_NGMonitor(Main.AlignUnit[i]);
                formChart[i] = new Form_Chart();
            }

            for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
            {
                for (int k = 0; k < Main.DEFINE.AlignUnit_Max; k++)
                {
                    for (int jj = 0; jj < Main.AlignUnit[k].m_AlignPatTagMax; jj++)
                    {
                        for (int j = 0; j < Main.AlignUnit[k].m_AlignPatMax[jj]; j++)
                        {
                            if (i == Main.AlignUnit[k].PAT[jj, j].m_DisNo)
                            {
                                cogDisplayCamNo[i] = Main.AlignUnit[k].PAT[jj, j].m_CamNo;
                                nDefaultName[i, nAlignUnit] = k;
                                nDefaultName[i, nPatTag] = jj;
                                nDefaultName[i, nPat] = j;
                            }
                        }
                    }
                }
                cogDisplay[i].Visible = true;
                cogDisplayButton[i].Visible = true;
            }

            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                //TAB_LOGDISPLAY.TabPages[i].Text = Main.AlignUnit[i].m_AlignName;
            }

            // PJH_221220_S
            //while (true)
            //{
            //    if (TAB_LOGDISPLAY.Controls.Count == Main.DEFINE.AlignUnit_Max) break;
            //    TAB_LOGDISPLAY.Controls.RemoveAt(TAB_LOGDISPLAY.Controls.Count - 1);
            //}
            // PJH_221220_E

            for (int i = 0; i < 3; i++)
            {
                LB_INSP[i] = new List<Label>();
                switch (i)
                {
                    case 0:
                        LB_INSP[0].Add(LB_INSPEC_0_00); LB_INSP[0].Add(LB_INSPEC_0_01); LB_INSP[0].Add(LB_INSPEC_0_02); LB_INSP[0].Add(LB_INSPEC_0_03); LB_INSP[0].Add(LB_INSPEC_0_04);
                        LB_INSP[0].Add(LB_INSPEC_0_05); LB_INSP[0].Add(LB_INSPEC_0_06); LB_INSP[0].Add(LB_INSPEC_0_07);
                        break;

                    case 1:
                        LB_INSP[1].Add(LB_INSPEC_1_00); LB_INSP[1].Add(LB_INSPEC_1_01); LB_INSP[1].Add(LB_INSPEC_1_02); LB_INSP[1].Add(LB_INSPEC_1_03); LB_INSP[1].Add(LB_INSPEC_1_04);
                        LB_INSP[1].Add(LB_INSPEC_1_05); LB_INSP[1].Add(LB_INSPEC_1_06); LB_INSP[1].Add(LB_INSPEC_1_07);
                        break;

                    case 2:
                        LB_INSP[2].Add(LB_INSPEC_2_00); LB_INSP[2].Add(LB_INSPEC_2_01); LB_INSP[2].Add(LB_INSPEC_2_02); LB_INSP[2].Add(LB_INSPEC_2_03); LB_INSP[2].Add(LB_INSPEC_2_04);
                        LB_INSP[2].Add(LB_INSPEC_2_05); LB_INSP[2].Add(LB_INSPEC_2_06); LB_INSP[2].Add(LB_INSPEC_2_07);
                        break;
                }
            }

            for (int i = 0; i < Main.DEFINE.MeasurePoint_Max; i++)
            {

            }

            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" || Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                LIST_LB_PROC_TIME.Add(LB_PROCTIME_1);
                LIST_LB_PROC_TIME.Add(LB_PROCTIME_2);
                LIST_LB_PROC_TIME.Add(LB_PROCTIME_3);
                LIST_LB_PROC_TIME.Add(LB_PROCTIME_4);

                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P1);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P2);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P3);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P4);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P5);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P6);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P7);
                LIST_LB_POINT_NG_CNT.Add(LB_NG_COUNT_P8);

                LIST_PB_CAM_CONSTAT.Add(picCamera1_Connect);
                LIST_PB_CAM_CONSTAT.Add(picCamera2_Connect);
                LIST_PB_CAM_CONSTAT.Add(picCamera3_Connect);

                LIST_PB_CAM_DISCONSTAT.Add(picCamera1_Disconnect);
                LIST_PB_CAM_DISCONSTAT.Add(picCamera2_Disconnect);
                LIST_PB_CAM_DISCONSTAT.Add(picCamera3_Disconnect);

                LIST_PB_LIGHT_CONSTAT.Add(picLight1_Connect);

                LIST_PB_LIGHT_DISCONSTAT.Add(picLight1_Disconnect);

                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
                {
                    LIST_PB_CAM_CONSTAT.Add(picCamera4_Connect);
                    LIST_PB_CAM_CONSTAT.Add(picCamera5_Connect);
                    LIST_PB_CAM_CONSTAT.Add(picCamera6_Connect);
                    LIST_PB_CAM_CONSTAT.Add(picCamera7_Connect);
                    LIST_PB_CAM_CONSTAT.Add(picCamera8_Connect);

                    LIST_PB_CAM_DISCONSTAT.Add(picCamera4_Disconnect);
                    LIST_PB_CAM_DISCONSTAT.Add(picCamera5_Disconnect);
                    LIST_PB_CAM_DISCONSTAT.Add(picCamera6_Disconnect);
                    LIST_PB_CAM_DISCONSTAT.Add(picCamera7_Disconnect);
                    LIST_PB_CAM_DISCONSTAT.Add(picCamera8_Disconnect);

                    LIST_PB_LIGHT_CONSTAT.Add(picLight2_Connect);

                    LIST_PB_LIGHT_DISCONSTAT.Add(picLight2_Disconnect);
                }
                else
                {
                    Point tempPoint = picCamera1_Connect.Location;
                    picCamera1_Connect.Location = picCamera3_Connect.Location;
                    picCamera3_Connect.Location = tempPoint;
                    picCamera1_Disconnect.Location = picCamera3_Disconnect.Location;
                    picCamera3_Disconnect.Location = tempPoint;

                    CB_LIVE_CHECK_CAM1.Visible = true;
                    CB_LIVE_CHECK_CAM2.Visible = true;
                    CB_LIVE_CHECK_CAM3.Visible = true;

                    for (int cam = 0; cam < Main.DEFINE.CAM_MAX; cam++)
                    {
                        nMainLiveFlag[cam] = new int();
                        nMainLiveFlag[cam] = 0;
                    }

                    btnRCS.Visible = false;

                    LB_PROCTIME_TITLE1.Text = "REAR CAM";
                    LB_PROCTIME_TITLE2.Text = "FRONT CAM";
                    LB_PROCTIME_TITLE3.Text = "1st CAM";
                    LB_PROCTIME_TITLE4.Visible = false;
                    LB_PROCTIME_4.Visible = false;
                }

                for (int j = 0; j < Main.DEFINE.CAM_MAX; j++)
                {
                    LIST_PB_CAM_CONSTAT[j].Visible = true;
                    LIST_PB_CAM_DISCONSTAT[j].Visible = true;
                }

                for (int k = 0; k < Main.DEFINE.Light_Control_Max; k++)
                {
                    LIST_PB_LIGHT_CONSTAT[k].Visible = true;
                    LIST_PB_LIGHT_DISCONSTAT[k].Visible = true;
                }
            }
#endregion

#region DisplatButton Text Input
                for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
                cogDisplayButton[i].Text = Main.Common.VIEW_NAME[i];
            DisplayViewLocation(Main.Common.VIEW_Pos, Main.Common.VIEW_Size);
#endregion
        }

        private void DisplayViewLocation(string[] Location, string[] nSize)
        {
            if (Location.Length != Main.DEFINE.DISPLAY_MAX) MessageBox.Show("DisplayViewPosition Count Check");

            int[] SizeX = new int[Main.DEFINE.DISPLAY_MAX]; int[] SizeY = new int[Main.DEFINE.DISPLAY_MAX];
            int[] PosX = new int[Main.DEFINE.DISPLAY_MAX]; int[] PosY = new int[Main.DEFINE.DISPLAY_MAX];

            int[] nDisTabNo = new int[Main.DEFINE.DISPLAY_MAX];

            int[] nTabNo = new int[Main.DEFINE.DISPLAY_MAX];
            int[] nDisNo = new int[Main.DEFINE.DISPLAY_MAX];
            int[] nSizeX = new int[Main.DEFINE.DISPLAY_MAX];
            int[] nSizeY = new int[Main.DEFINE.DISPLAY_MAX];

            int nTabAmt = 1;

            int TempTabNo = 0;

            for (int i = 0; i < Location.Length; i++)
            {
                TempTabNo = Convert.ToInt16(Location[i].ToString().Substring(0, 1)) - 1;
                nDisNo[i] = Convert.ToInt16(Location[i].ToString().Substring(Location[i].Length - 1, 1)) - 1;

                nSizeX[i] = Convert.ToInt16((nSize[i].ToString().Trim()).ToString().Substring(0, 1));
                nSizeY[i] = Convert.ToInt16((nSize[i].ToString().Trim()).ToString().Substring(nSize[i].ToString().Trim().Count() - 1, 1));

                nDisTabNo[i] = TempTabNo;

                if (TempTabNo > 0) nTabAmt = 2;
                if (TempTabNo > 1) nTabAmt = 3;
            }

#region 각 View_Tab 에 따라 표시되는 갯수에따라 사이즈 조정, 위치 조정.

            Point[] nDisPos = new Point[Main.DEFINE.DISPLAY_MAX];
            Point[] nBtnPos = new Point[Main.DEFINE.DISPLAY_MAX];


            int nWidth__Cnt = Main.Common.VIEW_WIDTH_CNT[0];
            int nHeight_Cnt = 2;

            int BtnGap = cogDisplayButton[0].Height;

            //실제 TAB_IMG_DISPLAY.Height 길이에서 12만큼은 밑단이 안보이기때문에 계산시 길이값 축소계산

            int View_Width = ((TAB_IMG_DISPLAY.Width - 16)) / nWidth__Cnt;
            int ViewHeight = ((TAB_IMG_DISPLAY.Height - 12) - (BtnGap * nHeight_Cnt)) / nHeight_Cnt;
            int nTempCnt = 0;

            for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
            {
                nWidth__Cnt = Main.Common.VIEW_WIDTH_CNT[nDisTabNo[i]];
                View_Width = ((TAB_IMG_DISPLAY.Width - 16)) / nWidth__Cnt;

                PosX[i] = (View_Width + 1) * (nDisNo[i] % nWidth__Cnt);
                PosY[i] = (ViewHeight + 1) * (nDisNo[i] / nWidth__Cnt);

                SizeX[i] = View_Width * nSizeX[i];

                if (nSizeY[i] == 2)
                    SizeY[i] = ViewHeight * nSizeY[i] + BtnGap + 1; // 세로가 갈때 버튼 길이만큼 늘려 줄라고.
                else
                    SizeY[i] = ViewHeight * nSizeY[i];

                nBtnPos[i].X = PosX[i];
                nBtnPos[i].Y = PosY[i] + (BtnGap * (nDisNo[i] / nWidth__Cnt));

                nDisPos[i].X = PosX[i];
                nDisPos[i].Y = PosY[i] + (BtnGap * (nDisNo[i] / nWidth__Cnt)) + BtnGap;

                cogDisplayButton[i].Location = nBtnPos[i];
                cogDisplayButton[i].Width = SizeX[i];

                cogDisplay[i].Location = nDisPos[i];
                cogDisplay[i].Width = SizeX[i];
                cogDisplay[i].Height = SizeY[i];// -BtnGap;
            }
#endregion

#region 각 View_Tab 에 따라 표시되는 갯수에따라 Tab에 맞는 창 띄우기.
            for (int i = 0; i < nTabAmt; i++)
            {
                for (int j = 0; j < Main.DEFINE.DISPLAY_MAX; j++)
                {
                    if (nDisTabNo[j] == 1)                      // 두번째 TAB
                    {
                        RBTN_TAB_1.Visible = true;
                        Tab_Num_1.Controls.Add(cogDisplay[j]);
                        Tab_Num_1.Controls.Add(cogDisplayButton[j]);
                    }
                    if (nDisTabNo[j] == 2)   // 세번째 TAB
                    {
                        RBTN_TAB_2.Visible = true;
                        Tab_Num_2.Controls.Add(cogDisplay[j]);
                        Tab_Num_2.Controls.Add(cogDisplayButton[j]);
                    }
                }
            }
#endregion
        }
        private void DisplayViewPosition(int Col, int Row)
        {
            if ((Col * Row) > nDisMax) MessageBox.Show("DisplayViewPosition Count Check");
            int SizeX, SizeY;
            int PitchX, PitchY;

            SizeX = TAB_IMG_DISPLAY.Width / Col - 1;
            SizeY = TAB_IMG_DISPLAY.Height / Row - cogDisplayButton[0].Height - 2;

            PitchX = TAB_IMG_DISPLAY.Width / Col;
            PitchY = TAB_IMG_DISPLAY.Height / Row;

            for (int i = 0; i < nDisMax; i++)
            {
                cogDisplay[i].Width = SizeX;
                cogDisplayButton[i].Width = SizeX;

                cogDisplay[i].Height = SizeY;
            }

            Point[,] nDisPos = new Point[Row, Col];
            Point[,] nBtnPos = new Point[Row, Col];

            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    nDisPos[i, j].X = cogDisplay[0].Location.X + (PitchX * j);
                    nBtnPos[i, j].X = cogDisplayButton[0].Location.X + (PitchX * j);

                    nDisPos[i, j].Y = cogDisplay[0].Location.Y + (PitchY * i);
                    nBtnPos[i, j].Y = cogDisplayButton[0].Location.Y + (PitchY * i);
                }
            }


            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    cogDisplay[i * Col + j].Location = nDisPos[i, j];
                    cogDisplayButton[i * Col + j].Location = nBtnPos[i, j];
                }
            }
        }
        private void LiveFormHide()
        {
            Melsec.BTN_EXIT_Click(null,null);
            for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
            {
                try
                {
                    formLiveview[i].BTN_EXIT_Click(null, null);
                }
                catch
                {
                    if (i < Main.DEFINE.CAM_MAX)
                        formLiveview[i] = new Form_LiveView(i);
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string value = string.Empty;
            lblProjectInformation.Text = Main.ProjectName + " - " + Main.ProjectInfo;

            //if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && Main.MODEL_COPY == true)
            //{
            //    //if (++nModelChangeTime >= 10)
            //    //{
            //    //    Main.ProjectRename(Main.MODEL_COPY_NAME, Main.MODEL_COPY_INFO);

            //    //    Main.MODEL_COPY = false;
            //    //    Main.MODEL_COPY_NAME = "";
            //    //    Main.MODEL_COPY_INFO = "";

            //    //    nModelChangeTime = 0;
            //    //}
            //}

            string LogMsg = "";
            string m_data;
            int nCMD = 0;
            char m_CharData;
            int dataNum;
            int TIME_READ_Address = 0;
            string m_TIME_ID_Temp = "";

            lblDateTime.Text = DateTime.Now.ToString();

            if (Main.PLC_AUTO_READY
                && Main.Status.MC_STATUS == Main.DEFINE.MC_STOP
                && Main.Status.MC_MODE == Main.DEFINE.MC_MAINFORM
                && Main.CCLink_IsBit(Main.DEFINE.CCLINK_OUT_VISION_BUSY) == false)
            {
                BTN_START_Click(null, null);
            }

            if (Main.Status.MC_STATUS == Main.DEFINE.MC_RUN)
            {
                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    if (Main.AlignUnit[i].m_ManualMatchFlag && !Main.AlignUnit[i].m_ManualMatchRunning)
                    {
                        Main.AlignUnit[i].m_ManualMatchRunning = true;
                        ManualSetForm(FormManualSet[i], i);
                        Main.AlignUnit[i].m_ManualMatchRunning = false;
                    }
                    if (Main.AlignUnit[i].m_NgImage_MonitorFlag)
                    {
                        Main.AlignUnit[i].m_NgImage_MonitorFlag = false;
                        NgMonitorFormSet(FormNgMonitor[i], Main.AlignUnit[i].StageNo);
                    }
                }
            }
            /*
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                for (int j = 0; j < Main.AlignUnit[i].m_AlignPatTagMax; j++)
                {
                    for (int k = 0; k < Main.AlignUnit[i].m_AlignPatMax[j]; k++)
                    {
                        if (!Main.DEFINE.OPEN_F)
                         {
                             if (Main.AlignUnit[i].PAT[j, k].m_CamNo > Main.DEFINE.MIL_CAM_MAX && Main.vision.CogImageBlock[Main.AlignUnit[i].PAT[j, k].m_CamNo].RunStatus.ProcessingTime > Main.DEFINE.CAMEARA_TIMEOUT)
                             {
                                  BTN_STOP_Click(null, null);
                                  formMessage.LB_MESSAGE.Text = "Please check the connection of the " + Main.AlignUnit[i].PAT[j, k].m_PatternName + "camera cable Stop Mode";    
                                  if (!formMessage.Visible)
                                  {
                                      formMessage.ShowDialog();
                                      Save_SystemLog(formMessage.LB_MESSAGE.Text, Main.DEFINE.CMD);
                                  }
                             }
                         }
                    }
                }
            }
            */

            //if (!Main.DEFINE.OPEN_F)
            //{
            //    string nMssage = "";
            //    if (!CameraStatus(ref nMssage))
            //    {
            //        BTN_STOP_Click(null, null);
            //        formMessage.LB_MESSAGE.Text = nMssage + "Start Mode";
            //        if (!formMessage.Visible)
            //        {
            //            formMessage.ShowDialog();
            //            Save_SystemLog(formMessage.LB_MESSAGE.Text, Main.DEFINE.CMD);
            //        }
            //    }
            //}

            //              if ((Main.Status.MC_MODE == Main.DEFINE.MC_LIVEFORM || Main.Status.MC_MODE == Main.DEFINE.MC_TEACHFORM))
            if (Main.Status.MC_STATUS == Main.DEFINE.MC_STOP && Main.Status.MC_MODE != Main.DEFINE.MC_CAMERAFORM)
                Main.Refresh_Unit();
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                Main.Refresh_Unit_Part(nMainLiveFlag);
            }

            if (Main.Status.MC_STATUS == Main.DEFINE.MC_RUN && Main.Status.MC_MODE != Main.DEFINE.MC_CAMERAFORM)
             {
                 if (Main.DEFINE.PROGRAM_TYPE == "TFOG_PC4")    //Monitoring
                 {
                     for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
                     {
                         if (Main.AlignUnit[i].m_AlignName == "MONITORING")
                         {
                             Main.Refresh_Unit(Main.AlignUnit[i]);
                         }
                     }

                 }
             }
             

            if(Main.DEFINE.PROGRAM_TYPE == "OLB_PC4" || Main.DEFINE.PROGRAM_TYPE == "OLB_PC5")
            {
/*                ListBox_Length[Main.AlignUnit["PBD"].m_AlignNo].Visible = true;  */

                if(Main.machine.LengthCheck_Onf)
                {
                    // PJH_20221013_S
                    //ListBox_Length[Main.AlignUnit["COF_CUTTING_ALIGN"].m_AlignNo].Visible = true;
                    ListBox_Length[Main.AlignUnit["COF_CUTTING_ALIGN"].CamNo].Visible = true;
                    // PJH_20221013_E
                }
                else
                {
                    // PJH_20221013_S
                    //ListBox_Length[Main.AlignUnit["COF_CUTTING_ALIGN"].m_AlignNo].Visible = false;
                    ListBox_Length[Main.AlignUnit["COF_CUTTING_ALIGN"].CamNo].Visible = false;
                    // PJH_20221013_E
                }

            }

            if (/*Main.DEFINE.PROGRAM_TYPE == "FOF_PC2" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC3" || */Main.DEFINE.PROGRAM_TYPE == "COP_PC2")
            {
                // PJH_20221013_S
                //ListBox_Length[Main.AlignUnit["PBD"].m_AlignNo].Visible = true;
                ListBox_Length[Main.AlignUnit["PBD"].CamNo].Visible = true;
                // PJH_20221013_S
            }
        }
        private void timer_Directory_Tick(object sender, EventArgs e)
        {
            //Main.DirectorySizeCheck(Main.LogdataPath);
            Main.machine.LogDirDeleteFlag = true;
        }

        public void SetTimerDirInterval(int nDays)
        {
            // Log Check Period를 설정할 당시 시간을 저장한 파일 로드
            FileInfo info = new FileInfo(Main.DEFINE.SYS_DATADIR + "OLD_LOG_CHECK_FILE.dat");
            int nRestSeconds = (int)((DateTime.Now.Ticks - info.LastWriteTime.Ticks) / 10000000); // Ticks to Seconds
            if (nDays <= 0) nDays = 1;
            if (nRestSeconds > nDays * 24 * 60 * 60)
                timer_Directory.Interval = nDays * 24 * 60 * 60;
            else
                timer_Directory.Interval = (nDays * 24 * 60 * 60 - nRestSeconds);
        }

        private void BTN_PROJECT_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Recipe Button");

            if (!MessageShow())
                return;

            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && Main.MODEL_COPY == true)
            {
                Main.ProjectRename(Main.MODEL_COPY_NAME, Main.MODEL_COPY_INFO);
                Main.MODEL_COPY = false;
            }

            Form_Project formProject = new Form_Project();
            formProject.ShowDialog();
        }

        public FormSelectUnit SelectUnitForm = null;
        private void BTN_TEACH_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Setting Button");
            Main.MilFrameGrabber.ReceiveImage -= Get_LineScanImage;
            //FormVisionTeach formVisionTeach = new FormVisionTeach();
            //formVisionTeach.ShowDialog();

            //VisionTeachForm = new FormVisionTeach();
            //VisionTeachForm.ShowDialog();

            //FormSelectUnit formSelectUnit = new FormSelectUnit();
            //formSelectUnit.ShowDialog();
            SelectUnitForm = new FormSelectUnit();
            SelectUnitForm.ShowDialog();
            return;

            if (!MessageShow())
                return;

            LiveFormHide();

//             Form_Password formpassword = new Form_Password(false);
//             formpassword.ShowDialog();
// 
//             if (!formpassword.LOGINOK)
//             {
//                 formpassword.Dispose();
//                 return;
//             }
//             formpassword.Dispose();

            Main.Status.MC_MODE = Main.DEFINE.MC_TEACHFORM;
            //Pattern_Select.ShowDialog();
            using (FormSelectTeaching SelectTeaching = new FormSelectTeaching())
            {
                SelectTeaching.ShowDialog();
            }
            Main.Status.MC_MODE = Main.DEFINE.MC_MAINFORM;
 //           Main.machine.EngineerMode = false;
        }
        private void BTN_SETUP_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Setting Button");

//          if (!MessageShow()) return;
//              Form_SetUp form_setup = new Form_SetUp();

            Main.Status.MC_MODE = Main.DEFINE.MC_SETUPFORM;
            timer_Directory.Enabled = false;

            FormSystem formSystem = new FormSystem();
            formSystem.ShowDialog();

            SetTimerDirInterval(Main.machine.m_nOldLogCheckPeriod);
            timer_Directory.Enabled = true;
  //          form_setup.ControlUpDate();
            Main.Status.MC_MODE = Main.DEFINE.MC_MAINFORM;
        }

        public FormInterface InterfaceForm = null;
        private void BTN_MELSEC_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Interface Button");

            InterfaceForm = new FormInterface();
            InterfaceForm.ShowDialog();

            return;
            try
            {
                FormCCLink.BTN_EXIT_Click(null, null);
                FormCCLink.Show();
                FormCCLink.Form_CCLink_Load();
                //Melsec.BTN_EXIT_Click(null, null);
                //Melsec.Show();
                //Melsec.Form_Melsec_Load();
            }
            catch
            {
                FormCCLink = new Form_CCLink();
                //Melsec = new Form_Melsec();
            }
        }
        private void BTN_LOGVIEW_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Log View Button");

            try
            {
                Formlogview.Show();
                Formlogview.ControlUpDate();
            }
            catch
            {
                Formlogview = new Form_LogView();
            }
        }
        private void BTN_CALDIS_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Cal Data Button");

            try
            {
                formCalDis.Show();
                formCalDis.ControlUpDate();
            }
            catch
            {
                formCalDis = new Form_CalDisplay();
            }

        }
        private void BTN_CAMERASET_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Camera Button");

            if (!MessageShow()) return;
            bool nResult = false;
            Form_Password formpassword = new Form_Password(true);
            formpassword.ShowDialog();
            nResult = formpassword.LOGINOK;
            formpassword.Dispose();
            if (nResult)
            {
                Main.Status.MC_MODE = Main.DEFINE.MC_CAMERAFORM;
                Form_CameraSet formcamera = new Form_CameraSet();
                formcamera.ShowDialog();
                formcamera.Dispose();
                Main.Status.MC_MODE = Main.DEFINE.MC_MAINFORM;
            }
            //LB_CAMERA.Visible = true;
        }
        private void BTN_LIVEVIEW_Click(object sender, EventArgs e)
        {
//            if (!MessageShow()) return;
            Button nBtn = (Button)sender;

            int CamNo = (Convert.ToInt32(nBtn.Name.Substring(nBtn.Name.Length - 2, 2)) - 1);

            try
            {
                formLiveview[cogDisplayCamNo[CamNo]].BTN_EXIT_Click(null, null);
                formLiveview[cogDisplayCamNo[CamNo]].Show();
                formLiveview[cogDisplayCamNo[CamNo]].FormLoad();

            }
            catch
            {
                if (CamNo < Main.DEFINE.CAM_MAX)
                    formLiveview[cogDisplayCamNo[CamNo]] = new Form_LiveView(cogDisplayCamNo[CamNo]);
            }
        }


        private void BTN_PASSWORD_Click(object sender, EventArgs e)
        {
            Form_Password formpassword = new Form_Password(false);
            formpassword.ShowDialog();
            formpassword.Dispose();
        }
        private void RBTN_TAB_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            int m_Number;
            m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 1, 1));
            TAB_IMG_DISPLAY.SelectedIndex = m_Number;
        }
        private void RBTN_TAB_Checked_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }

        private void BTN_OVERLAY_CLEAR_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
            {
                Main.DisplayClear(cogDisplay[i]);
            }
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                ListBox_Log[i].Items.Clear();
            }
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                ListBox_Length[i].Items.Clear();
            }
        }
        private void BTN_START_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Start Button");

            if (Main.DEFINE.OPEN_F)
            {
                for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
                {
                    Main.DisplayClear(cogDisplay[i]);
                }
                //                 int icmd, iunit;
                //                 iunit = Convert.ToInt16(TB_COMMANDTEST.Text.Substring(0, 1));
                //                 icmd = Convert.ToInt16(TB_COMMANDTEST.Text.Substring(1, 4));
                //                 Main.AlignUnit[iunit].m_Cmd = icmd;

                //try
                //{
                //    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"test.csv", false, System.Text.Encoding.GetEncoding("utf-8")))
                //    {
                //        // 필드에 값을 채워준다.  
                //        file.WriteLine("{0},{1},{2},{3}", "민수", "67", "D", "합격");

                //        // 필드에 값을 채워준다.  
                //        file.WriteLine("{0},{1},{2},{3}", "바보", "49", "F", "불합격");
                //    }
                //}
                //catch (IOException ee)
                //{
                //    MessageBox.Show(ee.Message);
                //}

                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    Main.AlignUnit[i].m_UnitBusy = false;
                    Main.AlignUnit[i].WriteCSVLogFile("111.222,333.444", Main.DEFINE.CAM_SELECT_INSPECT);
                    Main.AlignUnit[i].WriteCSVLogFile("555.666,777.888", Main.DEFINE.CAM_SELECT_ALIGN);
                }
            }
            LiveFormHide();
            this.btnStop.Visible = true;
            this.btnStart.Visible = false;

            if (Main.Status.MC_LIGHT == Main.DEFINE.MC_LIGHT_OFF)
            {
                BTN_LIGHT_ON_Click(null, null);
            }

            Main.Status.MC_STATUS = Main.DEFINE.MC_RUN;

            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_RUN, true);
            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_READY, true);
            //Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.VIS_READY, 1);

            //Main.CCLink_WriteWord(Main.DEFINE.CCLINK_WW_CAMERA1_SEARCH1_X, 1234);
            //Main.CCLink_WriteWord(Main.DEFINE.CCLINK_WW_CAMERA1_SEARCH1_X+1, 5678);
            //Main.CCLink_WriteDWord(Main.DEFINE.CCLINK_WW_CAMERA1_SEARCH1_Y, -1234567);
            //Form_RCS r = new Form_RCS();
            //r.ShowDialog();
            //r.Dispose();

            BTN_FIT_IMAGE_Click(null, null);

            ReadModuleID();
        }
        private void BTN_STOP_Click(object sender, EventArgs e)
        {
//             DialogResult result = MessageBox.Show("Do you want STOP?", "Information"Main.nMainLiveCamera[nCamNo], MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//             if (result == DialogResult.Yes)
//             {
                this.btnStart.Visible = true;
                this.btnStop.Visible = false;
                for (int j = 0; j < Main.DEFINE.DISPLAY_MAX; j++)
                {
//                     cogDisplay[j].Image = Main.vision.CogCamBuf[cogDisplayCamNo[j]];
//                     Main.DisplayClear(cogDisplay[j]);
                }
                Main.Status.MC_STATUS = Main.DEFINE.MC_STOP;
            //Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.VIS_READY, 0);
            //            }

            if (Main.DEFINE.OPEN_F)
            {
                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    Main.AlignUnit[i].m_UnitBusy = false;
                    Main.AlignUnit[i].WriteCSVLogFile("111.222,333.444", Main.DEFINE.CAM_SELECT_ALIGN);
                    Main.AlignUnit[i].WriteCSVLogFile("555.666,777.888", Main.DEFINE.CAM_SELECT_INSPECT);
                }
            }

            //Main.AlignUnit[0].WriteTrackOutFile();
            //Main.AlignUnit[0].WriteRCSLogFile();

            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && Main.MODEL_COPY == true)
            {
                Main.ProjectRename(Main.MODEL_COPY_NAME, Main.MODEL_COPY_INFO);
                Main.MODEL_COPY = false;
            }

            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_RUN, false);
            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_AUTO_READY, false);

            Main.CCLink_PutBit(Main.DEFINE.CCLINK_OUT_VISION_BUSY, false);

            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_STAGE1_FINE_ALIGN_MODE);
            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_STAGE1_INSPECTION_MODE);
            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_2002);
            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_2003);
            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_2004);
            //Main.CCLink_IsBit(Main.DEFINE.CCLINK_IN_2005);

            //short a = Main.CCLink_ReadWord(Main.DEFINE.CCLINK_WW_PANEL1_CELL_ID);
            //short b = Main.CCLink_ReadWord(Main.DEFINE.CCLINK_WW_PANEL1_CELL_ID_1 + 1);
            //int c = Main.CCLink_ReadDWord(Main.DEFINE.CCLINK_WW_PANEL1_CELL_ID_2);
            //MessageBox.Show(a.ToString() + b.ToString() + c.ToString());
        }
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Exit Button");

            if (Main.Status.MC_STATUS != Main.DEFINE.MC_STOP)
                return;

            DialogResult result = MessageBox.Show("Do you want EXIT?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Save_SystemLog("PROGRAM END", Main.DEFINE.CMD);

                //SystemLogViewerControl.AddLog("PROGRAM END");
                Main.MilFrameGrabber.ReceiveImage -= Get_LineScanImage;
                this.Close();
            }
        }

        private void Form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                timerStatus.Enabled = false;
                timer_Directory.Enabled = false;

                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    if (FormManualSet[i] != null)
                        FormManualSet[i].Dispose();
                    if (formChart[i] != null)
                        formChart[i].Dispose();
                }
                for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
                {
                    if (formLiveview[i] == null)
                        continue;

                    formLiveview[i].Close();
                    formLiveview[i].Dispose();
                }

         //       Main.SystemSave();
                Thread.Sleep(50);
                Thread_Stop();
                Main.Thread_Stop();
                Main.ThreadCAM_Stop();
                Main.Vision_Close();
                Thread.Sleep(10);
                _mUI_Info.Dispose();
                Melsec.Dispose();
                FormCCLink.Dispose();
                Formlogview.Dispose();
                form_trayDataview.Dispose();
                Pattern_Select.PatternTagSelect.PatternTeach.Dispose();
                Pattern_Select.PatternTagSelect.Dispose();
                Pattern_Select.PatternTeach.Dispose();
                Pattern_Select.Dispose();
                formCalDis.Dispose();
                formMessage.Dispose();
                Thread.Sleep(10);
                Main.CloseDM();
                Main.CCLinkTerminate();
                Light.Port_Close();
                Thread.Sleep(50);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
        }

#region Thread_관련
        private void Thread_Initial_Start()
        {
            ThreadProcM = new Thread(new ThreadStart(ThreadProc_M));
            threadFlag = true;
            ThreadProcM.Start();
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                Mutex_lock_LoglistBox[i] = new Mutex();
                Mutex_lock_GridView[i] = new Mutex();
                Mutex_lock_InspecGridView[i] = new Mutex();
                Mutex_lock_ProcStatus[i] = new Mutex();
            }
            for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
            {
                Mutex_lock_CogDisplay[i] = new Mutex();
            }
        }
        private void ThreadProc_M()
        {
            while (threadFlag)
            {
                if (Main.Status.MC_STATUS == Main.DEFINE.MC_RUN)
                {
                    for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                    {
                        ListBox_TABLength_Display(i);
                        ListBox_Display(i);
                        ProcStatus_Display(i);
                        for (int jj = 0; jj < Main.AlignUnit[i].m_AlignPatTagMax; jj++)
                        {
                            Grid_Display(i,jj);
                            for (int j = 0; j < Main.AlignUnit[i].m_AlignPatMax[jj]; j++)
                            {
                                Overlay_Display(i, jj,j);
                            }
                        }
                    }
                }
                if (Main.Status.MC_MODE == Main.DEFINE.MC_MAINFORM && Main.Status.MC_STATUS == Main.DEFINE.MC_STOP)
                {
                    for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
                    {
                          if (Main.vision.Grab_Flag_End[i])
                          {
                             for (int j = 0; j < Main.DEFINE.DISPLAY_MAX; j++)
                             {
                                // PJH_20220826_S
                                //cogDisplay[j].Image = Main.vision.CogCamBuf[cogDisplayCamNo[j]];                                
                                // PJH_20220826_E
                            }
                        }
                    }
                 }
                else if (Main.Status.MC_MODE == Main.DEFINE.MC_MAINFORM && Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                {
                    for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
                    {
                          if (nMainLiveFlag[i] > 0 && Main.vision.Grab_Flag_End[i])
                          {
                             //for (int j = 0; j < Main.DEFINE.DISPLAY_MAX; j++)
                             {
                                 //cogDisplay[j].Image = Main.vision.CogCamBuf[cogDisplayCamNo[j]];                                
                                 cogDisplay[i].Image = Main.vision.CogCamBuf[cogDisplayCamNo[i]];                                
                             }
                        }
                    }
                }
//                 if (Main.Status.MC_STATUS == Main.DEFINE.MC_RUN && Main.Status.MC_MODE != Main.DEFINE.MC_CAMERAFORM)
//                 {
//                     if (Main.DEFINE.PROGRAM_TYPE == "TFOG_PC4")    //Monitoring
//                     {
//                         for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
//                         {
//                             if (Main.AlignUnit[i].m_AlignName == "FBD_MONITORING")
//                             {
//                                 if (Main.vision.Grab_Flag_End[Main.AlignUnit[i].PAT[0, 0].m_CamNo])
//                                 {
//                                     for (int j = 0; j < Main.DEFINE.DISPLAY_MAX; j++)
//                                     {
//                                         if (Main.AlignUnit[i].PAT[0, 0].m_CamNo == cogDisplayCamNo[j])
//                                         {
//                                             cogDisplay[j].Image = Main.vision.CogCamBuf[cogDisplayCamNo[j]];
//                                         }
//                                     }
//                                 }
//                             }
//                         }
//                     }
//                 }
                Thread.Sleep(5);
            }
        }
        private void Thread_Stop()
        {
            threadFlag = false;
            if (ThreadProcM != null)
            {
                if (ThreadProcM.IsAlive) ThreadProcM.Abort();
            }
        }
#endregion

#region Display Invoke 관련

        delegate void dManualSetForm(Form_ManualSet nForm, int m_AlignNo);
        private void ManualSetForm(Form_ManualSet nForm, int m_AlignNo)
        {
            if (nForm.InvokeRequired)
            {
                dManualSetForm call = new dManualSetForm(ManualSetForm);
                nForm.Invoke(call, nForm, m_AlignNo);
            }
            else
            {
                nForm.m_AlignNo = m_AlignNo;
                nForm.ShowDialog();
                GC.Collect();
//                 Main.AlignUnit[m_AlignNo].ManualMatch = false;
//                 Main.AlignUnit[m_AlignNo].ManualMatch_Result = ret;
            }
        }
        delegate void dNgMonitorFormSet(Form_NGMonitor nForm, int m_PatTag);
        private void NgMonitorFormSet(Form_NGMonitor nForm, int m_PatTag)
        {
            if (nForm.InvokeRequired)
            {
                dNgMonitorFormSet call = new dNgMonitorFormSet(NgMonitorFormSet);
                nForm.Invoke(call, nForm, m_PatTag);
            }
            else
            {
                if (nForm.IsFormLoad)
                {
                    nForm.m_PatTagNo = m_PatTag;
                    nForm.Form_ImageChange();
                }
                else
                {
                    nForm.m_PatTagNo = m_PatTag;
                    nForm.Form_ImageChange();
                    nForm.ShowDialog();
                   
                }
                GC.Collect();
            }
        }
        delegate void dGrabRefresh(CogRecordDisplay nDisplay, ICogImage nImageBuf);
        public static void GrabDisRefresh(CogRecordDisplay nDisplay, ICogImage nImageBuf)
        {
            if (nDisplay.InvokeRequired)
            {
                dGrabRefresh call = new dGrabRefresh(GrabDisRefresh);
                nDisplay.Invoke(call, nDisplay, nImageBuf);
            }
            else
            {
                nDisplay.Image = nImageBuf;
            }
        }
        object syncLock = new object();
        private void ListBox_TABLength_Display(int AlignNo)
        {
            string LogMessage = " ";
            lock (syncLock)
            {
                try
                {
                    if (Main.AlignUnit[AlignNo].m_LogStringLength.Count > 0)
                    {
                        LogMessage = Main.AlignUnit[AlignNo].m_LogStringLength.Dequeue();
                        //InsertList(LB_Lisi_LENGTH, LogMessage);
                        InsertList(ListBox_Length[AlignNo], LogMessage);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                }
            }
        }
        private void ListBox_Display(int AlignNo)
        {
            string LogMessage = " ";
            Mutex_lock_LoglistBox[AlignNo].WaitOne();
            try
            {
                if (Main.AlignUnit[AlignNo].m_LogString.Count > 0)
                {
                    LogMessage = Main.AlignUnit[AlignNo].m_LogString.Dequeue();
                    InsertList(ListBox_Log[AlignNo], LogMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //            MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                Mutex_lock_LoglistBox[AlignNo].ReleaseMutex();
            }
        }
  
       delegate void dInsertList(ListBox nlistbox, string str);
        public static void InsertList(ListBox nlistbox, string str)
        {
            if (nlistbox.InvokeRequired)
            {
                dInsertList call = new dInsertList(InsertList);
                nlistbox.Invoke(call, nlistbox, str);
            }
            else
            {
                if (str != null)
                {
                    nlistbox.Items.Insert(nlistbox.Items.Count, str);
                    if (nlistbox.Items.Count > 100)
                        nlistbox.Items.RemoveAt(0);
                    nlistbox.SelectedIndex = (nlistbox.Items.Count - 1);
                }
            }
        }





        private void Inspec_Grid_Display(int AlignNo)
        {
//             Mutex_lock_InspecGridView[AlignNo].WaitOne();
//             try
//             {
//                 if (Main.AlignUnit[AlignNo].m_InspecGridString.Count > 1)
//                 {
//                     InspecInsertGridView(InspecGridView[AlignNo], Main.AlignUnit[AlignNo].m_InspecGridString, Main.AlignUnit[AlignNo].nSearchPosition);
//                 }
//             }
//             catch (System.Exception ex)
//             {
//                 Main.AlignUnit[AlignNo].m_InspecGridString.Clear();
//          //       MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
//             }
//             finally
//             {
//                 Mutex_lock_InspecGridView[AlignNo].ReleaseMutex();
//             }
        }
//         delegate void dInspecInsertGridView(DataGridView nlistbox, Queue<string[]> str, int nSearchPos);
//         public static void InspecInsertGridView(DataGridView nGridView, Queue<string[]> str, int nSearchPos)
//         {
//             if (nGridView.InvokeRequired)
//             {
//                 dInspecInsertGridView call = new dInspecInsertGridView(InspecInsertGridView);
//                 nGridView.Invoke(call, nGridView, str, nSearchPos);
//             }
//             else
//             {
//                 if(nGridView.RowCount>3 || nSearchPos == Main.DEFINE.FRONT)
//                     nGridView.Rows.Clear();
//                 while (str.Count > 0)
//                 {
//                     string[] LogMessage;
//                     LogMessage = str.Dequeue();
//                     nGridView.Rows.Add(LogMessage);
//                 }
//             }
//         }

        private void Grid_Display(int AlignNo, int PatMax)
        {
            Mutex_lock_GridView[AlignNo].WaitOne();
            try
            {
                if (Main.AlignUnit[AlignNo].m_MainGridString.Count > Main.AlignUnit[AlignNo].m_AlignPatMax[PatMax]-1)
                {
                    InsertGridView(GridView_Log[AlignNo], Main.AlignUnit[AlignNo].m_MainGridString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Main.AlignUnit[AlignNo].m_MainGridString.Clear();
          //      MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                Mutex_lock_GridView[AlignNo].ReleaseMutex();
            }
        }
        delegate void dInsertGridView(DataGridView nlistbox, Queue<string[]> str);
        public static void InsertGridView(DataGridView nGridView, Queue<string[]> str)
        {
            if (nGridView.InvokeRequired)
            {
                dInsertGridView call = new dInsertGridView(InsertGridView);
                nGridView.Invoke(call, nGridView, str);
            }
            else
            {
                nGridView.Rows.Clear();
                while (str.Count > 0)
                {
                    string[] LogMessage;
                    LogMessage = str.Dequeue();
                    nGridView.Rows.Add(LogMessage);
               
                }
            }
        }

        private void Overlay_Display(int AlignNo, int PatTagNo ,int PatNo)
        {
            int nDisNo;

            if (Main.AlignUnit[AlignNo].PAT[PatTagNo,PatNo].m_DrawPat == 1)
            {
                nDisNo = Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DisNo;

                Mutex_lock_CogDisplay[nDisNo].WaitOne();
                try
                {
                    InsertDisplayPAT(cogDisplay[nDisNo], AlignNo, PatTagNo,PatNo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //       MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                }
                finally
                {
                    Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DrawPat = 0;
                    Mutex_lock_CogDisplay[nDisNo].ReleaseMutex();
                }
            }
            if (Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DrawPat_CAL == 1)
            {
                nDisNo = Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DisNo;

                Mutex_lock_CogDisplay[nDisNo].WaitOne();
                try
                {
                    InsertDisplayPAT_CAL(cogDisplay[nDisNo], AlignNo, PatTagNo,PatNo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //       MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                }
                finally
                {
                    Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DrawPat_CAL = 0;
                    Mutex_lock_CogDisplay[nDisNo].ReleaseMutex();
                }
            }
            if (Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DrawPat_CAL_THETA == 1)
            {
                nDisNo = Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DisNo;

                Mutex_lock_CogDisplay[nDisNo].WaitOne();
                try
                {
                    InsertDisplayPAT_CAL_Theta(cogDisplay[nDisNo], AlignNo, PatTagNo, PatNo);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //       MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                }
                finally
                {
                    Main.AlignUnit[AlignNo].PAT[PatTagNo, PatNo].m_DrawPat_CAL_THETA = 0;
                    Mutex_lock_CogDisplay[nDisNo].ReleaseMutex();
                }
            }

            if (Main.AlignUnit[AlignNo].DrawAll_Pat[PatTagNo] > 0)
            {
              //  int nDrawPatNo = 0; //-> Display Count -> List nDrawPatNo 리스트로 선언해서 저거 카운터 만큼 For문 돌리기
                List<int> nDrawPatNo = new List<int>(); //-> Display Count -> List nDrawPatNo 리스트로 선언해서 저거 카운터 만큼 For문 돌리기
                List<int> nDrawType = new List<int>();
                switch (Main.AlignUnit[AlignNo].DrawAll_Pat[PatTagNo])
                {

                    case Main.DEFINE.OBJ_ALL:
                        nDrawPatNo.Add(0);
                        nDrawType.Add(Main.DEFINE.OBJ_ALL);
                        break;
                    case Main.DEFINE.TAR_ALL:
                        nDrawPatNo.Add(2);
                        nDrawType.Add(Main.DEFINE.TAR_ALL);
                        break;

                    case Main.DEFINE.LEFT_ALL:
                        nDrawPatNo.Add(0);
                        nDrawType.Add(Main.DEFINE.LEFT_ALL);
                        break;

                    case Main.DEFINE.RIGHT_ALL:
                        nDrawPatNo.Add(1);
                        nDrawType.Add(Main.DEFINE.RIGHT_ALL);
                        break;

                    case Main.DEFINE.OBJTAR_ALL:
                        if (Main.AlignUnit[AlignNo].m_AlignType[PatTagNo] == Main.DEFINE.M_2CAM2SHOT)
                        {
                            nDrawPatNo.Add(0);
                            nDrawType.Add(Main.DEFINE.LEFT_ALL);

                            nDrawPatNo.Add(1);
                            nDrawType.Add(Main.DEFINE.RIGHT_ALL);
                        }
                        else
                        {
                            nDrawPatNo.Add(0);
                            nDrawType.Add(Main.DEFINE.OBJTAR_ALL);
                        }
                        break;

                    case Main.DEFINE.CHIPPAT_ALL:
                            nDrawPatNo.Add(0);
                            nDrawType.Add(Main.DEFINE.CHIPPAT_ALL);
                        break;
                }

                for (int i = 0; i < nDrawPatNo.Count; i++)
                {
                    // PJH_20221013_S
                    //nDisNo = Main.AlignUnit[AlignNo].PAT[Main.AlignUnit[AlignNo].m_PatTagNo, nDrawPatNo[i]].m_DisNo;
                    nDisNo = Main.AlignUnit[AlignNo].PAT[Main.AlignUnit[AlignNo].StageNo, nDrawPatNo[i]].m_DisNo;
                    // PJH_20221013_E
                    Mutex_lock_CogDisplay[nDisNo].WaitOne();
                    try
                    {
                        InsertDisplay(cogDisplay[nDisNo], AlignNo, PatTagNo, PatNo, nDrawType[i]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        //       MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                    }
                    finally
                    {
                        Mutex_lock_CogDisplay[nDisNo].ReleaseMutex();
                    }
                }
                Main.AlignUnit[AlignNo].DrawAll_Pat[PatTagNo] = 0;
            }

        }
        delegate void dDrawResult(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo);
        delegate void dDrawResult_ALL(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo, int nType);
        public static void InsertDisplayPAT(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo)
        {
            if (nDisplay.InvokeRequired)
            {
                dDrawResult call = new dDrawResult(InsertDisplayPAT);
                nDisplay.Invoke(call, nDisplay, nAlignNo, nPatTagNo, nPatNo);
            }
            else
            {
                Main.AlignUnit[nAlignNo].PAT[nPatTagNo, nPatNo].DrawResult(nDisplay);

                int nDisNo = (Convert.ToInt32(nDisplay.Name.Substring(nDisplay.Name.Length - 2, 2)) - 1);
                Main.CrossLine(nDisplay, cogDisplayCamNo[nDisNo]);
            }
        }
        public static void InsertDisplayPAT_CAL(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo)
        {
            if (nDisplay.InvokeRequired)
            {
                dDrawResult call = new dDrawResult(InsertDisplayPAT_CAL);
                nDisplay.Invoke(call, nDisplay, nAlignNo, nPatTagNo, nPatNo);
            }
            else
            {
                Main.AlignUnit[nAlignNo].PAT[nPatTagNo, nPatNo].DrawResultCalibration(nDisplay);
            }
        }
        public static void InsertDisplayPAT_CAL_Theta(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo)
        {
            if (nDisplay.InvokeRequired)
            {
                dDrawResult call = new dDrawResult(InsertDisplayPAT_CAL_Theta);
                nDisplay.Invoke(call, nDisplay, nAlignNo, nPatTagNo, nPatNo);
            }
            else
            {
                Main.AlignUnit[nAlignNo].PAT[nPatTagNo, nPatNo].DrawResultCalibration_Theta(nDisplay);
            }
        }

        public static void InsertDisplay(CogRecordDisplay nDisplay, int nAlignNo, int nPatTagNo, int nPatNo , int nType)
        {
            if (nDisplay.InvokeRequired)
            {
                dDrawResult_ALL call = new dDrawResult_ALL(InsertDisplay);
                nDisplay.Invoke(call, nDisplay, nAlignNo, nPatTagNo, nPatNo, nType);
            }
            else
            {
                Main.AlignUnit[nAlignNo].DrawResultALL(nDisplay, nType);
            }
        }


        private void ProcStatus_Display(int AlignNo)
        {
            string strProcTime = " ";
            Mutex_lock_ProcStatus[AlignNo].WaitOne();
            try
            {
                if (Main.AlignUnit[AlignNo].m_bDisplayStatus == true)
                {
                    Main.AlignUnit[AlignNo].m_bDisplayStatus = false;
                    strProcTime = Main.AlignUnit[AlignNo].m_lInOutTime.ToString() + " ms";
                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                    {
                        if (AlignNo == 0)
                            DispProcStatus(LIST_LB_PROC_TIME[2], strProcTime);
                        else
                            DispProcStatus(LIST_LB_PROC_TIME[AlignNo - 1], strProcTime);
                    }
                    else
                        DispProcStatus(LIST_LB_PROC_TIME[AlignNo], strProcTime);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //            MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                Mutex_lock_ProcStatus[AlignNo].ReleaseMutex();
            }
        }

        delegate void dDispProcStatus(Label aLabel, string str);
        public static void DispProcStatus(Label aLabel, string str)
        {
            if (aLabel.InvokeRequired)
            {
                dDispProcStatus call = new dDispProcStatus(DispProcStatus);
                aLabel.Invoke(call, aLabel, str);
            }
            else
            {
                if (str != null)
                {
                    aLabel.Text = str;
                }
            }
        }



#endregion

        public void button1_Click(object sender, EventArgs e)
        {
            int icmd, iunit, iCam, iPad;
            try
            {
                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
                {
                    iunit = Convert.ToInt16(txtCommandTest.Text.Substring(0, 1));
                    iCam = Convert.ToInt16(txtCommandTest.Text.Substring(1, 1));
                    iPad = Convert.ToInt16(txtCommandTest.Text.Substring(2, 1));
                    icmd = Convert.ToInt16(txtCommandTest.Text.Substring(3, 3));
                    Main.AlignUnit[iunit].ExecuteSearch(iCam, iPad, (ushort)icmd);
                }
                else
                {
                    iunit = Convert.ToInt16(txtCommandTest.Text.Substring(0, 2));
                    icmd = Convert.ToInt16(txtCommandTest.Text.Substring(2, 4));
                    Main.AlignUnit[iunit].m_Cmd = icmd;
                }
//                ((Main.vision.CogImageBlock[0].Tools[0]) as CogAcqFifoTool).Operator.Flush();
//                 cogDisplay[1].StopLiveDisplay();
//                 cogDisplay[1].StartLiveDisplay(((Main.vision.CogImageBlock[0].Tools[0]) as CogAcqFifoTool).Operator);
            }
            catch
            {

            }
        }

        private bool MessageShow()
        {
            if (Main.Status.MC_STATUS != Main.DEFINE.MC_STOP)
            {
                formMessage.LB_MESSAGE.Text = "Machine STOP!!";
                formMessage.ShowDialog();
                return false;
            }
            return true;
        }

        private void BTN_LIGHT_INITIAL_Click(object sender, EventArgs e)
        {
            Light.Port_Refresh();
        }

        private void BTN_LIGHT_ON_Click(object sender, EventArgs e)
        {
            if (Main.Status.MC_STATUS != Main.DEFINE.MC_RUN)
            {
                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    if (Main.DEFINE.PROGRAM_TYPE == "COP_PC3" || Main.DEFINE.PROGRAM_TYPE == "OLB_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC4")
                        Main.AlignUnit[i].PAT[0, 0].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                    else
                    {
                        for (int j = 0; j < Main.DEFINE.Pattern_Max; j++)
                        {
                            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
                                Main.AlignUnit[i].PAT[0, j].SetAllLight(Main.DEFINE.M_LIGHT_LINE);
                            else
                                Main.AlignUnit[i].PAT[0, j].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                        }
                    }
                }

                Main.Status.MC_LIGHT = Main.DEFINE.MC_LIGHT_ON;
            }
        }

        private void BTN_LIGHT_OFF_Click(object sender, EventArgs e)
        {
            if (Main.Status.MC_STATUS != Main.DEFINE.MC_RUN)
            {
                for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                {
                    for (int j = 0; j < Main.DEFINE.Pattern_Max; j++)
                        Main.AlignUnit[i].PAT[0, j].SetAllLightOFF();
                }

                Main.Status.MC_LIGHT = Main.DEFINE.MC_LIGHT_OFF;
            }
        }

        object syncLock_Log = new object();
        private void Save_SystemLog(string nMessage, string nType)
        {
            string nFolder;
            string nFileName = "";
            nFolder = Main.LogdataPath + DateTime.Now.ToString("yyyyMMdd") + "\\";
            if (!Directory.Exists(Main.LogdataPath)) Directory.CreateDirectory(Main.LogdataPath);
            if (!Directory.Exists(nFolder)) Directory.CreateDirectory(nFolder);

            string Date;
            Date = DateTime.Now.ToString("[MM_dd HH:mm:ss:fff] ");

            lock (syncLock_Log)
            {
                try
                {
                    switch (nType)
                    {
                        case Main.DEFINE.CMD:
                            nFileName = "SystemLog.txt";
                            nMessage = Date + nMessage;
                            break;

                        case Main.DEFINE.LIGHTCTRL:
                            nFileName = "CommsLog.txt";
                            nMessage = Date + nMessage;
                            break;
                    }

                    StreamWriter SW = new StreamWriter(nFolder + nFileName, true, Encoding.Unicode);
                    SW.WriteLine(nMessage);
                    SW.Close();
                }
                catch
                {

                }
            }
        }

        private void LogFolderShow_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Main.LogdataPath))
                System.Diagnostics.Process.Start(Main.LogdataPath);
        }

        private void BTN_INSPECT_SHOW_Click(object sender, EventArgs e)
        {
            if (GB_INSPECTION.Visible)
            {
                GB_INSPECTION.Visible = false;
                BTN_INSPECT_SHOW.BackColor = System.Drawing.Color.DarkGray;
            }
            else 
            { 
                GB_INSPECTION.Visible = true;
                BTN_INSPECT_SHOW.BackColor = System.Drawing.Color.GreenYellow;
            }                                        
        }

        private void LB_Lisi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int nAlignNo;
                nAlignNo = Convert.ToInt16(((System.Windows.Forms.Control)(sender)).Name.Substring(((System.Windows.Forms.Control)(sender)).Name.Length - 2, 2));
                nAlignNo = nAlignNo - 1;
                //GridView_Log

                if (!formChart[nAlignNo].Visible)
                {
                    formChart[nAlignNo].m_AlignNo = nAlignNo;
                    formChart[nAlignNo].m_PatTagNo = 0;

                    if (Main.AlignUnit[nAlignNo].m_AlignName == "AOI_INSPECTION" 
                        || Main.AlignUnit[nAlignNo].m_AlignName == "FOB_INSPECT" 
                        || Main.AlignUnit[nAlignNo].m_AlignName == "FOF_INSPECTION1"
                        || Main.AlignUnit[nAlignNo].m_AlignName == "FOF_INSPECTION2"
                        || Main.AlignUnit[nAlignNo].m_AlignName == "FOP_INSPECTION1")
                        formChart[nAlignNo].DISPLAY_MODE = 1;
                    else
                        formChart[nAlignNo].DISPLAY_MODE = 0;
                    formChart[nAlignNo].Show();
                    formChart[nAlignNo].Form_Load();
                }
            }
            catch
            {

            }
        }

        private void MA_Display_DoubleClick(object sender, EventArgs e)
        {
            CogRecordDisplay nDis = (CogRecordDisplay)sender;

            int nDisNo = (Convert.ToInt32(nDis.Name.Substring(nDis.Name.Length - 2, 2)) - 1);
            Main.CrossLine(nDis, cogDisplayCamNo[nDisNo]);
        }

        private void BTN_LIGHT_FPC_Click(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC4" )
            {
                for (int i = Main.AlignUnit["PBD1"].m_AlignPatTagMax - 1; i >= 0; i--)
                {
                    Main.AlignUnit["PBD1"].PAT[i, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                    Main.AlignUnit["PBD1"].PAT[i, Main.DEFINE.OBJ_R].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                }

                for (int i = Main.AlignUnit["PBD2"].m_AlignPatTagMax - 1; i >= 0; i--)
                {
                    Main.AlignUnit["PBD2"].PAT[i, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                    Main.AlignUnit["PBD2"].PAT[i, Main.DEFINE.OBJ_R].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                }
//                 Main.AlignUnit[0].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
//                 Main.AlignUnit[0].PAT[0, Main.DEFINE.OBJ_R].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
            }

            if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC1")
            {
                Main.AlignUnit[2].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
                Main.AlignUnit[3].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
            }

            if (Main.DEFINE.PROGRAM_TYPE == "FOF_PC1")
            {
                Main.AlignUnit[0].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
                Main.AlignUnit[1].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
                Main.AlignUnit[2].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
                Main.AlignUnit[3].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_BLOB);
            }
        }

        private void BTN_LIGHT_PANEL_Click(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC4")
            {
                for (int i = Main.AlignUnit["PBD1"].m_AlignPatTagMax - 1; i >= 0; i--)
                {
                    Main.AlignUnit["PBD1"].PAT[i, Main.DEFINE.TAR_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                    Main.AlignUnit["PBD1"].PAT[i, Main.DEFINE.TAR_R].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                }

                for (int i = Main.AlignUnit["PBD2"].m_AlignPatTagMax - 1; i >= 0; i--)
                {
                    Main.AlignUnit["PBD2"].PAT[i, Main.DEFINE.TAR_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                    Main.AlignUnit["PBD2"].PAT[i, Main.DEFINE.TAR_R].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                }
            }

            if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC1")
            {
                Main.AlignUnit[2].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                Main.AlignUnit[3].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
            }

            if (Main.DEFINE.PROGRAM_TYPE == "FOF_PC1")
            {
                Main.AlignUnit[0].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                Main.AlignUnit[1].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                Main.AlignUnit[2].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                Main.AlignUnit[3].PAT[0, Main.DEFINE.OBJ_L].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
            }
        }

        private void BTN_TRAY_VIEW_Click(object sender, EventArgs e)
        {
            form_trayDataview.Show();
            form_trayDataview.ControlUpDate();
        }

        private bool CameraStatus(ref string nMsg)
        {
            bool nRet = true;
            nMsg = "";
            NetworkInterface[] network = NetworkInterface.GetAllNetworkInterfaces();
            //for (int ii = 0; ii < Main.DEFINE.CAM_MAX; ii++)
            for (int ii = Main.DEFINE.MIL_CAM_MAX; ii < Main.DEFINE.CAM_MAX; ii++)
            {
                for (int i = 0; i < network.Length; i++)
                {
                    if (network[i].NetworkInterfaceType == NetworkInterfaceType.Ethernet && Main.vision.CamName[ii] == network[i].Name)
                    {
                        if (network[i].OperationalStatus == OperationalStatus.Down)
                        {
                            nMsg = Main.vision.CamName[ii] + "_ Camera disconnect";
                            LIST_PB_CAM_DISCONSTAT[ii].Visible = true;
                            LIST_PB_CAM_CONSTAT[ii].Visible = false;
                            nRet = false;
                            break;
                        }
                        else
                        {
                            LIST_PB_CAM_CONSTAT[ii].Visible = true;
                            LIST_PB_CAM_DISCONSTAT[ii].Visible = false;
                        }
                    }
                }
            }

            return nRet;
        }

        private void BTN_CCLINKTEST_Click(object sender, EventArgs e)
        {
            ushort iAddr;
            bool bCmd;
            try
            {
                iAddr = Convert.ToUInt16(txtCommandTest.Text.Substring(0, 5), 16);
                bCmd = txtCommandTest.Text.Substring(5, 1).Equals("1");
                Main.CCLink_PutBit(iAddr, bCmd);
            }
            catch
            {

            }
        }

        private void BTN_MXTEST_Click(object sender, EventArgs e)
        {
            int iAddr;
            int iCmd;
            try
            {
                iAddr = Convert.ToInt32(txtCommandTest.Text.Substring(0, 6));
                iCmd = Convert.ToInt32(txtCommandTest.Text.Substring(6, 4));
                Main.WriteDevice(iAddr, iCmd);
            }
            catch
            {

            }
        }

        private void BTN_FIT_IMAGE_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.DEFINE.DISPLAY_MAX; i++)
                cogDisplay[i].Fit(false);
        }

        private void UpdateAuthority()
        {
            switch (Main.Instance().Authority)
            {
                case Main.eAuthority.Maker:
                    btnAuthority.Image = COG.Properties.Resources.Maker;
                    break;

                case Main.eAuthority.Engineer:
                    btnAuthority.Image = COG.Properties.Resources.Engineer;
                    break;

                case Main.eAuthority.Operator:
                    btnAuthority.Image = COG.Properties.Resources.Operator;
                    break;
                default:
                    break;
            }

            btnAuthority.Text = "     " + Main.Instance().Authority.ToString();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateAuthority();

            if (!Main.DEFINE.OPEN_F)
            {
                // GIGE CAMERA
                string nMssage = "";

                if (!CameraStatus(ref nMssage))
                {
                    BTN_STOP_Click(null, null);
                    formMessage.LB_MESSAGE.Text = nMssage + "Start Mode";
                    if (!formMessage.Visible)
                    {
                        //formMessage.ShowDialog();
                        Save_SystemLog(formMessage.LB_MESSAGE.Text, Main.DEFINE.CMD);
                    }
                }

                // PJH_Modify_20220819_Flying Vision_S
                // GigE Type으로 분류할 것
                //for (int i = 0; i < Main.DEFINE.MIL_CAM_MAX; i++)
                //{
                //    if (/*CameraLinkComms.CameraLink_ReadTest(j)*/Main.MilFrameGrabber.CheckCamera(i))
                //    {
                //        LIST_PB_CAM_CONSTAT[i].Visible = true;
                //        LIST_PB_CAM_DISCONSTAT[i].Visible = false;
                //    }
                //    else
                //    {
                //        LIST_PB_CAM_CONSTAT[i].Visible = false;
                //        LIST_PB_CAM_DISCONSTAT[i].Visible = true;
                //    }
                //}
                // PJH_Modify_20220819_Flying Vision_E

                // PLC
                if (Main.PLCALIVE == true)
                {
                    picPLC_Connect.Visible = true;
                    picPLC_Disconnect.Visible = false;
                }
                else
                {
                    picPLC_Connect.Visible = false;
                    picPLC_Disconnect.Visible = true;
                }

                // PJH_Modify_20220819_Flying Vision_S
                //for (int i = 0; i < Main.DEFINE.Light_Control_Max; i++)
                //{
                //    if (Main.CCLink_IsBit(Main.DEFINE.CCLINK_OUT_VISION_BUSY))
                //        break;

                //    if (Light.LightControl_ReadTest(i))
                //    {
                //        LIST_PB_LIGHT_CONSTAT[i].Visible = true;
                //        LIST_PB_LIGHT_DISCONSTAT[i].Visible = false;
                //    }
                //    else
                //    {
                //        LIST_PB_LIGHT_CONSTAT[i].Visible = false;
                //        LIST_PB_LIGHT_DISCONSTAT[i].Visible = true;
                //    }
                //}
                // PJH_Modify_20220819_Flying Vision_E

                // RCS Temp
                if (Main.RCSCHECK == true && Main.Status.MC_MODE == Main.DEFINE.MC_ERROR)
                {
                    Main.RCSCHECK = false;
                    btnRCS.BackColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    Main.RCSCHECK = true;
                    btnRCS.BackColor = System.Drawing.Color.DarkGray;
                }
            }
        }

        private void BTN_RCS_Click(object sender, EventArgs e)
        {
            Main.Status.MC_MODE = Main.DEFINE.MC_RCSFORM;

            form_RCS.ShowDialog();

            Main.Status.MC_MODE = Main.DEFINE.MC_MAINFORM;
        }

        private void BTN_VISION_RESET_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                Main.AlignUnit[i].m_UnitBusy = false;
            }
        }

        private void CB_LIVE_CHECK_CAM_Click(object sender, EventArgs e)
        {
            CheckBox tempCB = (CheckBox)sender;

            int nCamNo = (Convert.ToInt32(tempCB.Name.Substring(tempCB.Name.Length - 1, 1)) - 1);

            if (tempCB.Checked)
            {
                // Live true
                nMainLiveFlag[nCamNo] = 1;
            }
            else
            {
                // false
                nMainLiveFlag[nCamNo] = 0;
            }
        }

        private void CB_LIVE_CHECK_CAM_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox tempCB = (CheckBox)sender;

            if (tempCB.Checked)
                tempCB.BackColor = Color.LawnGreen;
            else
                tempCB.BackColor = Color.DarkGray;
        }

        public static void ProcessATTResult(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        {
            //if (sw.IsRunning) sw.Stop();
            //if (nError == 0)
            //{
            //    m_rstImage = new Mat(m_vvReadMats[nStageNo][nTapNo].Size(), MatType.CV_8UC3);
            //    if (bSliceInsp == false)
            //    {


            //        unsafe
            //        {

            //            m_Wrapper.AWGetATTResultData(nStageNo, nTapNo, ref m_sAkkonFilter, ref m_Result);
            //            m_Wrapper.AWGetATTResultImage(nStageNo, nTapNo, ref m_sAkkonFilter, ref m_sDrawOption, (byte*)m_rstImage.DataPointer, 0);
            //            //DLL에서 검사결과 받아옴
            //        }


            //        WriteLeadInfo(nStageNo, nTapNo, m_Result.Length, m_Result);
            //        String strPath;
            //        strPath = String.Format("D:\\05_수행자료\\11_JASTECH\\03_통합ATT\\result{0:D}_{1:D}.bmp", nStageNo, nTapNo);
            //        Cv2.ImWrite(strPath, m_rstImage);

            //        m_nInspectionEnd++;

            //        int nImageCnt = m_vvReadMats.Count;
            //        int nTotalImageCount = 0;

            //        for (int i = 0; i < nImageCnt; i++)
            //        {
            //            for (int j = 0; j < m_vvReadMats[i].Count; j++)
            //            {
            //                nTotalImageCount++;
            //            }
            //        }

            //        if (m_nInspectionEnd == nTotalImageCount)
            //        {
            //            m_nInspectionEnd = 0;
            //            if (m_bAging)
            //            {
            //                //sw.Stop();

            //                MessageBox.Show(sw.Elapsed.ToString());
            //                sw.Reset();

            //            }
            //            Trace.WriteLine("sharp : Insp End");

            //        }
            //    }
            //    else
            //    {
            //        float fInspResizeRatio = s_fInspResizeRatio;
            //        int nSliceHeight = s_nSliceHeight;
            //        int nSliceWidth = s_nSliceWidth;
            //        int nSliceID = s_nSliceID;

            //        unsafe
            //        {
            //            m_Wrapper.AWGetATTResultData(nStageNo, nTapNo, ref m_sAkkonFilter, ref m_Result);
            //            m_Wrapper.AWGetATTResultImage(nStageNo, nTapNo, ref m_sAkkonFilter, ref m_sDrawOption, (byte*)m_rstImage.DataPointer, 0);
            //        }


            //        WriteLeadInfo(nStageNo, nTapNo, m_Result.Length, m_Result);

            //        Rect rcROI = new Rect();
            //        if (m_rstImage.Rows > m_rstImage.Cols)
            //        {
            //            rcROI.X = 0;
            //            rcROI.Y = nSliceID * ((int)(nSliceHeight * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
            //            rcROI.Width = m_rstImage.Cols;
            //            rcROI.Height = (int)(nSliceHeight * fInspResizeRatio);

            //            if (rcROI.Y < m_rstImage.Rows)
            //            {
            //                if (rcROI.Y + rcROI.Height > m_rstImage.Rows)
            //                {
            //                    rcROI.Height = m_rstImage.Rows - rcROI.Y;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            rcROI.X = nSliceID * (Convert.ToInt32(nSliceWidth * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
            //            rcROI.Y = 0; //
            //            rcROI.Width = Convert.ToInt32(nSliceWidth * fInspResizeRatio);
            //            rcROI.Height = m_rstImage.Rows;

            //            if (rcROI.X < m_rstImage.Cols)
            //            {
            //                if (rcROI.X + rcROI.Width > m_rstImage.Cols)
            //                {
            //                    rcROI.Width = m_rstImage.Cols - rcROI.X;
            //                }
            //            }
            //        }
            //        Mat sliceImage = m_rstImage.SubMat(rcROI);

            //        String strPath;
            //        strPath = String.Format("D:\\05_수행자료\\11_JASTECH\\03_통합ATT\\result{0:D}_{1:D}_Slice{2:D}.bmp", nStageNo, nTapNo, nSliceID);
            //        Cv2.ImWrite(strPath, sliceImage);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Error: dongle key");
            //}
        }

        private void BTN_MOTION_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Motion Button");

            FormMotionTeach formMotionTeach = new FormMotionTeach();
            formMotionTeach.ShowDialog();

            //Form_Motion formMotion = new Form_Motion();
            //formMotion.Show();
        }

        private void btnTest_AddResult_Click(object sender, EventArgs e)
        {
            // CSV Test
            InspectionResult.AkkonInspectionResult t1 = new InspectionResult.AkkonInspectionResult();

            t1.InspectionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            t1.PanelID = "test";
            t1.TabNumber = 5;
            t1.Judge = InspectionResult.eInspectionResult.OK;
            t1.AkkonCount = 10;
            t1.Length = 0.5;

            CSVManager.Instance().AddResult(t1);


            // Control Update Test
            List<InspectionResult.AkkonInspectionResult> akkonResultList = new List<InspectionResult.AkkonInspectionResult>();
            akkonResultList.Add(t1);

            AkkonViewerControl.UpdateGridView(akkonResultList);
            AkkonViewerControl.UpdateAkkonChart(akkonResultList);

            // CSV Test
            InspectionResult.AlignInspectionResult t2 = new InspectionResult.AlignInspectionResult();

            t2.InspectionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            t2.PanelID = "test";
            t2.TabNumber = 5;
            t2.Judge = InspectionResult.eInspectionResult.OK;
            t2.LeftAlignX = -10.0;
            t2.LeftAlignY = 10.1;
            t2.RightAlignX = -100.0;
            t2.RightAlignY = 100.1;
            t2.CenterAlignX = 50.5;

            CSVManager.Instance().AddResult(t2);

            // Control Update Test
            List<InspectionResult.AlignInspectionResult> alignResultList = new List<InspectionResult.AlignInspectionResult>();
            alignResultList.Add(t2);

            AlignViewerControl.UpdateGridView(alignResultList);
        }

        public void Get_LineScanImage(int nScan, int scene)
        {
            //FormMain.Instance().CGMSNavigatorControl.UpdateGrabStatus(scene, nScan);
            //FormMain.Instance().CGMSViewerControl.UpdateDisplay(scene, Main.AlignUnit[0].PAT[nScan, scene].m_CogLineScanBuf);
        }

        private void LineScanGrabThreadstart()
        {
            GrabThreadFlag = false;
            LineScanGrab = new Thread(GrabStart);
            LineScanGrab.Start();
        }

        private void GrabStart()
        {
            bool isLive = true;
            while(isLive)
            {
                if (GrabThreadFlag)
                {
                    Grab_Squence();
                    //Test();
                }
                else
                    isLive = false;
                Thread.Sleep(100);
            }
        }

        private void Grab_Squence()
        {
            int ScanCount = 1;
            int GrabTimeout = 10000;
            bool bGrabTimeout = false;
            double[] dPosX = new double[Main.recipe.m_nScanCount];
            double[] dPosY = new double[Main.recipe.m_nScanCount];
            double[] dEndPosX = new double[Main.recipe.m_nScanCount];
            bool bGrabComplete = false, bGrabRes = false;
            double dist = 0, dTagetPosX =0;
            System.Diagnostics.Stopwatch GrabTimer = new System.Diagnostics.Stopwatch();

            FormMain.Instance().CGMSViewerControl.CGMSNavigatorControl.ClearGrabStatus();
            for (int nScanCnt =0; nScanCnt < Main.recipe.m_nScanCount; nScanCnt++)
            {
                if (nScanCnt == 0)
                    dPosY[nScanCnt] = -226.2;
                else
                    dPosY[nScanCnt] = dPosY[nScanCnt-1] + 5.52;
                dPosX[nScanCnt] = 133.5;
                // 첫위치 Stage 이동
                Main.LAF.SetMotionAbsoluteMove(15.9);
                Main.Instance().MotionManager.MoveTo(eAxis.Axis_Y, dPosY[nScanCnt]);
                Thread.Sleep(50);
                Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, dPosX[nScanCnt]);
                Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
                Thread.Sleep(50);
                Main.Instance().MotionManager.WaitForDone(eAxis.Axis_Y);
                Main.LAF.SetAutoFocusOnOFF(true);
                dist = (Main.recipe.m_PatternYSize * Main.recipe.m_nTabCount) + (Main.recipe.m_PatternToPatternYDistance * Main.recipe.m_nTabCount - 1);
                dTagetPosX = dist + 2 + Main.Instance().MotionManager.GetActualPosition(eAxis.Axis_X);
                bGrabRes = Main.MilFrameGrabber.GrabLineScan(nScanCnt + 1, Main.recipe.m_nTabCount, 0, dist);
             
                if (bGrabRes)
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, dTagetPosX);
                GrabTimer.Start();
                while (GrabTimer.ElapsedMilliseconds < GrabTimeout)
                {
                    bGrabComplete = Main.MilFrameGrabber.LineScanGrabStatus(nScanCnt);
                    if (bGrabComplete == true)
                    {
                        bGrabTimeout = true;
                        break;
                    }
                    else
                        bGrabTimeout = false;
                }
                if (bGrabTimeout == false)
                {
                    //Main.MilFrameGrabber.LineScanStop(0);
                    //SystemLogViewerControl.AddLog("Grab Time out");
                    Main.LAF.SetAutoFocusOnOFF(false);
                    break;
                }
                Main.LAF.SetAutoFocusOnOFF(false);
                GrabTimer.Stop();
                GrabTimer.Reset();
            }

            Main.LAF.SetAutoFocusOnOFF(false);
            GrabThreadFlag = false;
        }

        private void BTN_ATTINSP_Click(object sender, EventArgs e)
        {
            //TestImageLoad(0);
            GrabThreadFlag = true;
        }

        private void Test()
        {
            int nCamNo = 0;
            int nStage = 0;
         
            for (int nScan = 0; nScan < 2; nScan++)
            {
                for (int scenen = 0; scenen < 3; scenen++)
                {
                    //CGMSNavigatorControl.UpdateGrabStatus(scenen, nScan);
                    if (nScan == 1)
                    {
                        CGMSViewerControl.DisplayClear(scenen + 5);
                        //CGMSViewerControl.UpdateDisplay(scenen + 5, Main.AlignUnit[0].PAT[nScan, scenen].m_CogLineScanBuf);
                    }
                    else
                    {
                        CGMSViewerControl.DisplayClear(scenen);
                        //CGMSViewerControl.UpdateDisplay(scenen, Main.AlignUnit[0].PAT[nScan, scenen].m_CogLineScanBuf);
                    }
                    Main.CGMSInspection(nCamNo, nStage, nScan, scenen);
                }
            }
            GrabThreadFlag = false;
        }

        public void Set_History(int No, int Judge, int Patcial, double Dimention, int ShortCnt)
        {
            InspectionResult.CGMSInspectionResult Result = new InspectionResult.CGMSInspectionResult();
            Result.No = No+1;
            Result.Judge = (InspectionResult.eInspectionResult)Judge;
            Result.ParticleCount = Patcial;
            Result.Dimension = Dimention;
            Result.ShortCount = ShortCnt;
            List<InspectionResult.CGMSInspectionResult> testList = new List<InspectionResult.CGMSInspectionResult>();
            testList.Add(Result);
            CGMSResultControl.UpdateCGMSInspectionHistory(testList, true);
        }

        private void btnFlyingVision_Click(object sender, EventArgs e)
        {
            FormFlyingVisionView tt = new FormFlyingVisionView();
            tt.Show();
        }

        private void btnAuthority_Click(object sender, EventArgs e)
        {
            //SystemLogViewerControl.AddLog("Click Authority Button");

            OpenAuthority();
        }

        public void OpenAuthority()
        {
            if (AuthorityForm == null)
            {
                AuthorityForm = new FormAuthority();
                AuthorityForm.CloseEventDelegate = () => this.AuthorityForm = null;
                AuthorityForm.ShowDialog();
            }
        }

        private void btnInspectionTestFrom_Click(object sender, EventArgs e)
        {
            //FormInspectionSimulationForEngineer tt = new FormInspectionSimulationForEngineer();
            //tt.ShowDialog();
            TestImageLoad(1);
            GrabThreadFlag = true;
        }
    }
}
