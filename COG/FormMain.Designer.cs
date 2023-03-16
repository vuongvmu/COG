namespace COG
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
//             CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
//             foreach (ICogFrameGrabber fg in frameGrabbers)
//                 fg.Disconnect(false);
                base.Dispose(disposing);

        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtCommandTest = new System.Windows.Forms.TextBox();
            this.btnCommandTest = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblModel = new System.Windows.Forms.Label();
            this.lblProjectInformation = new System.Windows.Forms.Label();
            this.timer_Directory = new System.Windows.Forms.Timer(this.components);
            this.TAB_IMG_DISPLAY = new System.Windows.Forms.TabControl();
            this.Tab_Num_0 = new System.Windows.Forms.TabPage();
            this.CB_LIVE_CHECK_CAM3 = new System.Windows.Forms.CheckBox();
            this.CB_LIVE_CHECK_CAM2 = new System.Windows.Forms.CheckBox();
            this.CB_LIVE_CHECK_CAM1 = new System.Windows.Forms.CheckBox();
            this.MA_Display02 = new Cognex.VisionPro.CogRecordDisplay();
            this.BTN_DISNAME_08 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_07 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_06 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_05 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_04 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_03 = new System.Windows.Forms.Button();
            this.MA_Display06 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display05 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display04 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display08 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display07 = new Cognex.VisionPro.CogRecordDisplay();
            this.BTN_DISNAME_02 = new System.Windows.Forms.Button();
            this.MA_Display01 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display03 = new Cognex.VisionPro.CogRecordDisplay();
            this.Tab_Num_1 = new System.Windows.Forms.TabPage();
            this.BTN_DISNAME_16 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_15 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_14 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_13 = new System.Windows.Forms.Button();
            this.MA_Display14 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display13 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display16 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display15 = new Cognex.VisionPro.CogRecordDisplay();
            this.BTN_DISNAME_12 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_11 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_10 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_09 = new System.Windows.Forms.Button();
            this.MA_Display10 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display09 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display12 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display11 = new Cognex.VisionPro.CogRecordDisplay();
            this.Tab_Num_2 = new System.Windows.Forms.TabPage();
            this.BTN_DISNAME_24 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_23 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_22 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_21 = new System.Windows.Forms.Button();
            this.MA_Display22 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display21 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display24 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display23 = new Cognex.VisionPro.CogRecordDisplay();
            this.BTN_DISNAME_20 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_19 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_18 = new System.Windows.Forms.Button();
            this.BTN_DISNAME_17 = new System.Windows.Forms.Button();
            this.MA_Display18 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display17 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display20 = new Cognex.VisionPro.CogRecordDisplay();
            this.MA_Display19 = new Cognex.VisionPro.CogRecordDisplay();
            this.BTN_DISNAME_01 = new System.Windows.Forms.Button();
            this.RBTN_TAB_1 = new System.Windows.Forms.RadioButton();
            this.RBTN_TAB_2 = new System.Windows.Forms.RadioButton();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.BTN_LIGHT_INITIAL = new System.Windows.Forms.Button();
            this.BTN_INSPECT_SHOW = new System.Windows.Forms.Button();
            this.GB_INSPECTION = new System.Windows.Forms.GroupBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_07 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_05 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_03 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_01 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_06 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_04 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_02 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.LB_INSPEC_2_00 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_07 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_05 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_03 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_01 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_06 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_04 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_02 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.LB_INSPEC_1_00 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label35 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_07 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_05 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_03 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_01 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_06 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_04 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_02 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.LB_INSPEC_0_00 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnTest_AddResult = new System.Windows.Forms.Button();
            this.BTN_LIGHT_PANEL = new System.Windows.Forms.Button();
            this.BTN_LIGHT_FPC = new System.Windows.Forms.Button();
            this.BTN_TRAY_VIEW = new System.Windows.Forms.Button();
            this.BTN_LIGHT_ON = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_CCLINKTEST = new System.Windows.Forms.Button();
            this.BTN_MXTEST = new System.Windows.Forms.Button();
            this.BTN_FIT_IMAGE = new System.Windows.Forms.Button();
            this.pnlCPU_Usage = new System.Windows.Forms.Panel();
            this.btnFlyingVision = new System.Windows.Forms.Button();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.BTN_VISION_RESET = new System.Windows.Forms.Button();
            this.tlpGrabView = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.tlpFunction = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnInterface = new System.Windows.Forms.Button();
            this.btnSystem = new System.Windows.Forms.Button();
            this.btnAuthority = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.BTN_MOTION = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.tlpInformation = new System.Windows.Forms.TableLayoutPanel();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.btnCamera = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlExit = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlEtcFunction = new System.Windows.Forms.Panel();
            this.tlpEtcFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnCal = new System.Windows.Forms.Button();
            this.btnInspectionTestFrom = new System.Windows.Forms.Button();
            this.tlpCommunicationStatus = new System.Windows.Forms.TableLayoutPanel();
            this.pnlPLCStatus = new System.Windows.Forms.Panel();
            this.picCamera1_Connect = new System.Windows.Forms.PictureBox();
            this.picPLC_Connect = new System.Windows.Forms.PictureBox();
            this.picPLC_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlLight1_Status = new System.Windows.Forms.Panel();
            this.picLight1_Connect = new System.Windows.Forms.PictureBox();
            this.picLight1_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlLight2_Status = new System.Windows.Forms.Panel();
            this.picLight2_Connect = new System.Windows.Forms.PictureBox();
            this.picLight2_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera1_Status = new System.Windows.Forms.Panel();
            this.picCamera1_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera2_Status = new System.Windows.Forms.Panel();
            this.picCamera2_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera2_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera3_Status = new System.Windows.Forms.Panel();
            this.picCamera3_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera3_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera4_Status = new System.Windows.Forms.Panel();
            this.picCamera4_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera4_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera5_Status = new System.Windows.Forms.Panel();
            this.picCamera5_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera5_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera6_Status = new System.Windows.Forms.Panel();
            this.picCamera6_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera6_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera7_Status = new System.Windows.Forms.Panel();
            this.picCamera7_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera7_Disconnect = new System.Windows.Forms.PictureBox();
            this.pnlCamera8_Status = new System.Windows.Forms.Panel();
            this.picCamera8_Connect = new System.Windows.Forms.PictureBox();
            this.picCamera8_Disconnect = new System.Windows.Forms.PictureBox();
            this.tlpButton_VisibleFalse = new System.Windows.Forms.TableLayoutPanel();
            this.btnRCS = new System.Windows.Forms.Button();
            this.BTN_PASSWORD = new System.Windows.Forms.Button();
            this.tlpEtcFunction_VisibleFalse = new System.Windows.Forms.TableLayoutPanel();
            this.BTN_ATTINSP = new System.Windows.Forms.Button();
            this.pnlMCCTime = new System.Windows.Forms.Panel();
            this.LB_PROCTIME_2 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_TITLE2 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_4 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_TITLE4 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_1 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_3 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_TITLE1 = new System.Windows.Forms.Label();
            this.LB_PROCTIME_TITLE3 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P6 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P5 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P4 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P3 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P7 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P8 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P1 = new System.Windows.Forms.Label();
            this.LB_NG_COUNT_P2 = new System.Windows.Forms.Label();
            this.LB_POINT_NG_CNT = new System.Windows.Forms.Label();
            this.LB_PROCTIME = new System.Windows.Forms.Label();
            this.pnlSystemInformation = new System.Windows.Forms.Panel();
            this.TAB_IMG_DISPLAY.SuspendLayout();
            this.Tab_Num_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display06)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display08)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display07)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display03)).BeginInit();
            this.Tab_Num_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display09)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display11)).BeginInit();
            this.Tab_Num_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display19)).BeginInit();
            this.GB_INSPECTION.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pnlCPU_Usage.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            this.tlpFunction.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlExit.SuspendLayout();
            this.pnlStart.SuspendLayout();
            this.pnlEtcFunction.SuspendLayout();
            this.tlpEtcFunction.SuspendLayout();
            this.tlpCommunicationStatus.SuspendLayout();
            this.pnlPLCStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPLC_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPLC_Disconnect)).BeginInit();
            this.pnlLight1_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLight1_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLight1_Disconnect)).BeginInit();
            this.pnlLight2_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLight2_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLight2_Disconnect)).BeginInit();
            this.pnlCamera1_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1_Disconnect)).BeginInit();
            this.pnlCamera2_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2_Disconnect)).BeginInit();
            this.pnlCamera3_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3_Disconnect)).BeginInit();
            this.pnlCamera4_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera4_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera4_Disconnect)).BeginInit();
            this.pnlCamera5_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera5_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera5_Disconnect)).BeginInit();
            this.pnlCamera6_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera6_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera6_Disconnect)).BeginInit();
            this.pnlCamera7_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera7_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera7_Disconnect)).BeginInit();
            this.pnlCamera8_Status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera8_Connect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera8_Disconnect)).BeginInit();
            this.tlpButton_VisibleFalse.SuspendLayout();
            this.tlpEtcFunction_VisibleFalse.SuspendLayout();
            this.pnlMCCTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommandTest
            // 
            this.txtCommandTest.Location = new System.Drawing.Point(40, 3);
            this.txtCommandTest.Name = "txtCommandTest";
            this.txtCommandTest.Size = new System.Drawing.Size(31, 21);
            this.txtCommandTest.TabIndex = 12;
            this.txtCommandTest.Text = "001181";
            this.txtCommandTest.Visible = false;
            // 
            // btnCommandTest
            // 
            this.btnCommandTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnCommandTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCommandTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCommandTest.Location = new System.Drawing.Point(-34, 31);
            this.btnCommandTest.Name = "btnCommandTest";
            this.btnCommandTest.Size = new System.Drawing.Size(120, 30);
            this.btnCommandTest.TabIndex = 33;
            this.btnCommandTest.Text = "TEST CMD";
            this.btnCommandTest.UseVisualStyleBackColor = false;
            this.btnCommandTest.Visible = false;
            this.btnCommandTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.Gray;
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModel.ForeColor = System.Drawing.Color.Black;
            this.lblModel.Location = new System.Drawing.Point(3, 100);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(238, 50);
            this.lblModel.TabIndex = 46;
            this.lblModel.Text = "MODEL ";
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProjectInformation
            // 
            this.lblProjectInformation.BackColor = System.Drawing.Color.Lime;
            this.lblProjectInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProjectInformation.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProjectInformation.ForeColor = System.Drawing.Color.Black;
            this.lblProjectInformation.Location = new System.Drawing.Point(3, 150);
            this.lblProjectInformation.Name = "lblProjectInformation";
            this.lblProjectInformation.Size = new System.Drawing.Size(238, 50);
            this.lblProjectInformation.TabIndex = 47;
            this.lblProjectInformation.Text = "abc";
            this.lblProjectInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_Directory
            // 
            this.timer_Directory.Interval = 3600000;
            this.timer_Directory.Tick += new System.EventHandler(this.timer_Directory_Tick);
            // 
            // TAB_IMG_DISPLAY
            // 
            this.TAB_IMG_DISPLAY.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.TAB_IMG_DISPLAY.Controls.Add(this.Tab_Num_0);
            this.TAB_IMG_DISPLAY.Controls.Add(this.Tab_Num_1);
            this.TAB_IMG_DISPLAY.Controls.Add(this.Tab_Num_2);
            this.TAB_IMG_DISPLAY.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TAB_IMG_DISPLAY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TAB_IMG_DISPLAY.ItemSize = new System.Drawing.Size(1, 30);
            this.TAB_IMG_DISPLAY.Location = new System.Drawing.Point(40, 3);
            this.TAB_IMG_DISPLAY.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.TAB_IMG_DISPLAY.Multiline = true;
            this.TAB_IMG_DISPLAY.Name = "TAB_IMG_DISPLAY";
            this.TAB_IMG_DISPLAY.Padding = new System.Drawing.Point(0, 3);
            this.TAB_IMG_DISPLAY.SelectedIndex = 0;
            this.TAB_IMG_DISPLAY.Size = new System.Drawing.Size(34, 1);
            this.TAB_IMG_DISPLAY.TabIndex = 83;
            this.TAB_IMG_DISPLAY.Visible = false;
            // 
            // Tab_Num_0
            // 
            this.Tab_Num_0.BackColor = System.Drawing.Color.Silver;
            this.Tab_Num_0.Controls.Add(this.CB_LIVE_CHECK_CAM3);
            this.Tab_Num_0.Controls.Add(this.CB_LIVE_CHECK_CAM2);
            this.Tab_Num_0.Controls.Add(this.CB_LIVE_CHECK_CAM1);
            this.Tab_Num_0.Controls.Add(this.MA_Display02);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_08);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_07);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_06);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_05);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_04);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_03);
            this.Tab_Num_0.Controls.Add(this.MA_Display06);
            this.Tab_Num_0.Controls.Add(this.MA_Display05);
            this.Tab_Num_0.Controls.Add(this.btnCommandTest);
            this.Tab_Num_0.Controls.Add(this.MA_Display04);
            this.Tab_Num_0.Controls.Add(this.MA_Display08);
            this.Tab_Num_0.Controls.Add(this.MA_Display07);
            this.Tab_Num_0.Controls.Add(this.BTN_DISNAME_02);
            this.Tab_Num_0.Controls.Add(this.MA_Display01);
            this.Tab_Num_0.Controls.Add(this.MA_Display03);
            this.Tab_Num_0.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Tab_Num_0.Location = new System.Drawing.Point(4, 4);
            this.Tab_Num_0.Name = "Tab_Num_0";
            this.Tab_Num_0.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Num_0.Size = new System.Drawing.Size(0, 0);
            this.Tab_Num_0.TabIndex = 0;
            this.Tab_Num_0.Text = "DIS_0";
            // 
            // CB_LIVE_CHECK_CAM3
            // 
            this.CB_LIVE_CHECK_CAM3.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_LIVE_CHECK_CAM3.BackColor = System.Drawing.Color.White;
            this.CB_LIVE_CHECK_CAM3.Image = global::COG.Properties.Resources.Focus;
            this.CB_LIVE_CHECK_CAM3.Location = new System.Drawing.Point(824, 348);
            this.CB_LIVE_CHECK_CAM3.Name = "CB_LIVE_CHECK_CAM3";
            this.CB_LIVE_CHECK_CAM3.Size = new System.Drawing.Size(30, 30);
            this.CB_LIVE_CHECK_CAM3.TabIndex = 127;
            this.CB_LIVE_CHECK_CAM3.UseVisualStyleBackColor = false;
            this.CB_LIVE_CHECK_CAM3.Visible = false;
            this.CB_LIVE_CHECK_CAM3.CheckedChanged += new System.EventHandler(this.CB_LIVE_CHECK_CAM_CheckedChanged);
            this.CB_LIVE_CHECK_CAM3.Click += new System.EventHandler(this.CB_LIVE_CHECK_CAM_Click);
            // 
            // CB_LIVE_CHECK_CAM2
            // 
            this.CB_LIVE_CHECK_CAM2.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_LIVE_CHECK_CAM2.BackColor = System.Drawing.Color.White;
            this.CB_LIVE_CHECK_CAM2.Image = global::COG.Properties.Resources.Focus;
            this.CB_LIVE_CHECK_CAM2.Location = new System.Drawing.Point(412, 348);
            this.CB_LIVE_CHECK_CAM2.Name = "CB_LIVE_CHECK_CAM2";
            this.CB_LIVE_CHECK_CAM2.Size = new System.Drawing.Size(30, 30);
            this.CB_LIVE_CHECK_CAM2.TabIndex = 126;
            this.CB_LIVE_CHECK_CAM2.UseVisualStyleBackColor = false;
            this.CB_LIVE_CHECK_CAM2.Visible = false;
            this.CB_LIVE_CHECK_CAM2.CheckedChanged += new System.EventHandler(this.CB_LIVE_CHECK_CAM_CheckedChanged);
            this.CB_LIVE_CHECK_CAM2.Click += new System.EventHandler(this.CB_LIVE_CHECK_CAM_Click);
            // 
            // CB_LIVE_CHECK_CAM1
            // 
            this.CB_LIVE_CHECK_CAM1.Appearance = System.Windows.Forms.Appearance.Button;
            this.CB_LIVE_CHECK_CAM1.BackColor = System.Drawing.Color.White;
            this.CB_LIVE_CHECK_CAM1.Image = global::COG.Properties.Resources.Focus;
            this.CB_LIVE_CHECK_CAM1.Location = new System.Drawing.Point(1, 348);
            this.CB_LIVE_CHECK_CAM1.Name = "CB_LIVE_CHECK_CAM1";
            this.CB_LIVE_CHECK_CAM1.Size = new System.Drawing.Size(30, 30);
            this.CB_LIVE_CHECK_CAM1.TabIndex = 23;
            this.CB_LIVE_CHECK_CAM1.UseVisualStyleBackColor = false;
            this.CB_LIVE_CHECK_CAM1.Visible = false;
            this.CB_LIVE_CHECK_CAM1.CheckedChanged += new System.EventHandler(this.CB_LIVE_CHECK_CAM_CheckedChanged);
            this.CB_LIVE_CHECK_CAM1.Click += new System.EventHandler(this.CB_LIVE_CHECK_CAM_Click);
            // 
            // MA_Display02
            // 
            this.MA_Display02.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display02.ColorMapLowerRoiLimit = 0D;
            this.MA_Display02.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display02.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display02.ColorMapUpperRoiLimit = 1D;
            this.MA_Display02.DoubleTapZoomCycleLength = 2;
            this.MA_Display02.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display02.Location = new System.Drawing.Point(412, 28);
            this.MA_Display02.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display02.MouseWheelSensitivity = 1D;
            this.MA_Display02.Name = "MA_Display02";
            this.MA_Display02.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display02.OcxState")));
            this.MA_Display02.Size = new System.Drawing.Size(411, 350);
            this.MA_Display02.TabIndex = 105;
            this.MA_Display02.Visible = false;
            this.MA_Display02.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // BTN_DISNAME_08
            // 
            this.BTN_DISNAME_08.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_08.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_08.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_08.Location = new System.Drawing.Point(1235, 380);
            this.BTN_DISNAME_08.Name = "BTN_DISNAME_08";
            this.BTN_DISNAME_08.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_08.TabIndex = 125;
            this.BTN_DISNAME_08.Text = "DISPLAY_08";
            this.BTN_DISNAME_08.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_08.Visible = false;
            this.BTN_DISNAME_08.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_07
            // 
            this.BTN_DISNAME_07.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_07.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_07.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_07.Location = new System.Drawing.Point(824, 380);
            this.BTN_DISNAME_07.Name = "BTN_DISNAME_07";
            this.BTN_DISNAME_07.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_07.TabIndex = 124;
            this.BTN_DISNAME_07.Text = "DISPLAY_07";
            this.BTN_DISNAME_07.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_07.Visible = false;
            this.BTN_DISNAME_07.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_06
            // 
            this.BTN_DISNAME_06.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_06.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_06.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_06.Location = new System.Drawing.Point(1235, 1);
            this.BTN_DISNAME_06.Name = "BTN_DISNAME_06";
            this.BTN_DISNAME_06.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_06.TabIndex = 123;
            this.BTN_DISNAME_06.Text = "DISPLAY_06";
            this.BTN_DISNAME_06.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_06.Visible = false;
            this.BTN_DISNAME_06.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_05
            // 
            this.BTN_DISNAME_05.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_05.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_05.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_05.Location = new System.Drawing.Point(824, 1);
            this.BTN_DISNAME_05.Name = "BTN_DISNAME_05";
            this.BTN_DISNAME_05.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_05.TabIndex = 122;
            this.BTN_DISNAME_05.Text = "DISPLAY_05";
            this.BTN_DISNAME_05.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_05.Visible = false;
            this.BTN_DISNAME_05.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_04
            // 
            this.BTN_DISNAME_04.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_04.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_04.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_04.Location = new System.Drawing.Point(412, 380);
            this.BTN_DISNAME_04.Name = "BTN_DISNAME_04";
            this.BTN_DISNAME_04.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_04.TabIndex = 111;
            this.BTN_DISNAME_04.Text = "DISPLAY_04";
            this.BTN_DISNAME_04.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_04.Visible = false;
            this.BTN_DISNAME_04.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_03
            // 
            this.BTN_DISNAME_03.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_03.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_03.Location = new System.Drawing.Point(0, 380);
            this.BTN_DISNAME_03.Name = "BTN_DISNAME_03";
            this.BTN_DISNAME_03.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_03.TabIndex = 104;
            this.BTN_DISNAME_03.Text = "DISPLAY_03";
            this.BTN_DISNAME_03.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_03.Visible = false;
            this.BTN_DISNAME_03.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display06
            // 
            this.MA_Display06.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display06.ColorMapLowerRoiLimit = 0D;
            this.MA_Display06.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display06.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display06.ColorMapUpperRoiLimit = 1D;
            this.MA_Display06.DoubleTapZoomCycleLength = 2;
            this.MA_Display06.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display06.Location = new System.Drawing.Point(1236, 28);
            this.MA_Display06.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display06.MouseWheelSensitivity = 1D;
            this.MA_Display06.Name = "MA_Display06";
            this.MA_Display06.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display06.OcxState")));
            this.MA_Display06.Size = new System.Drawing.Size(411, 350);
            this.MA_Display06.TabIndex = 113;
            this.MA_Display06.Visible = false;
            this.MA_Display06.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display05
            // 
            this.MA_Display05.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display05.ColorMapLowerRoiLimit = 0D;
            this.MA_Display05.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display05.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display05.ColorMapUpperRoiLimit = 1D;
            this.MA_Display05.DoubleTapZoomCycleLength = 2;
            this.MA_Display05.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display05.Location = new System.Drawing.Point(824, 28);
            this.MA_Display05.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display05.MouseWheelSensitivity = 1D;
            this.MA_Display05.Name = "MA_Display05";
            this.MA_Display05.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display05.OcxState")));
            this.MA_Display05.Size = new System.Drawing.Size(411, 350);
            this.MA_Display05.TabIndex = 112;
            this.MA_Display05.Visible = false;
            this.MA_Display05.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display04
            // 
            this.MA_Display04.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display04.ColorMapLowerRoiLimit = 0D;
            this.MA_Display04.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display04.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display04.ColorMapUpperRoiLimit = 1D;
            this.MA_Display04.DoubleTapZoomCycleLength = 2;
            this.MA_Display04.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display04.Location = new System.Drawing.Point(412, 407);
            this.MA_Display04.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display04.MouseWheelSensitivity = 1D;
            this.MA_Display04.Name = "MA_Display04";
            this.MA_Display04.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display04.OcxState")));
            this.MA_Display04.Size = new System.Drawing.Size(411, 350);
            this.MA_Display04.TabIndex = 106;
            this.MA_Display04.Visible = false;
            this.MA_Display04.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display08
            // 
            this.MA_Display08.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display08.ColorMapLowerRoiLimit = 0D;
            this.MA_Display08.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display08.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display08.ColorMapUpperRoiLimit = 1D;
            this.MA_Display08.DoubleTapZoomCycleLength = 2;
            this.MA_Display08.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display08.Location = new System.Drawing.Point(1236, 407);
            this.MA_Display08.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display08.MouseWheelSensitivity = 1D;
            this.MA_Display08.Name = "MA_Display08";
            this.MA_Display08.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display08.OcxState")));
            this.MA_Display08.Size = new System.Drawing.Size(411, 350);
            this.MA_Display08.TabIndex = 115;
            this.MA_Display08.Visible = false;
            this.MA_Display08.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display07
            // 
            this.MA_Display07.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display07.ColorMapLowerRoiLimit = 0D;
            this.MA_Display07.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display07.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display07.ColorMapUpperRoiLimit = 1D;
            this.MA_Display07.DoubleTapZoomCycleLength = 2;
            this.MA_Display07.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display07.Location = new System.Drawing.Point(824, 407);
            this.MA_Display07.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display07.MouseWheelSensitivity = 1D;
            this.MA_Display07.Name = "MA_Display07";
            this.MA_Display07.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display07.OcxState")));
            this.MA_Display07.Size = new System.Drawing.Size(411, 350);
            this.MA_Display07.TabIndex = 114;
            this.MA_Display07.Visible = false;
            this.MA_Display07.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // BTN_DISNAME_02
            // 
            this.BTN_DISNAME_02.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_02.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_02.Location = new System.Drawing.Point(412, 1);
            this.BTN_DISNAME_02.Name = "BTN_DISNAME_02";
            this.BTN_DISNAME_02.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_02.TabIndex = 110;
            this.BTN_DISNAME_02.Text = "DISPLAY_02";
            this.BTN_DISNAME_02.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_02.Visible = false;
            this.BTN_DISNAME_02.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display01
            // 
            this.MA_Display01.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display01.ColorMapLowerRoiLimit = 0D;
            this.MA_Display01.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display01.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display01.ColorMapUpperRoiLimit = 1D;
            this.MA_Display01.DoubleTapZoomCycleLength = 2;
            this.MA_Display01.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display01.Location = new System.Drawing.Point(0, 28);
            this.MA_Display01.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display01.MouseWheelSensitivity = 1D;
            this.MA_Display01.Name = "MA_Display01";
            this.MA_Display01.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display01.OcxState")));
            this.MA_Display01.Size = new System.Drawing.Size(411, 350);
            this.MA_Display01.TabIndex = 98;
            this.MA_Display01.Visible = false;
            this.MA_Display01.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display03
            // 
            this.MA_Display03.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display03.ColorMapLowerRoiLimit = 0D;
            this.MA_Display03.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display03.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display03.ColorMapUpperRoiLimit = 1D;
            this.MA_Display03.DoubleTapZoomCycleLength = 2;
            this.MA_Display03.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display03.Location = new System.Drawing.Point(0, 407);
            this.MA_Display03.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display03.MouseWheelSensitivity = 1D;
            this.MA_Display03.Name = "MA_Display03";
            this.MA_Display03.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display03.OcxState")));
            this.MA_Display03.Size = new System.Drawing.Size(411, 350);
            this.MA_Display03.TabIndex = 99;
            this.MA_Display03.Visible = false;
            this.MA_Display03.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // Tab_Num_1
            // 
            this.Tab_Num_1.BackColor = System.Drawing.Color.Silver;
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_16);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_15);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_14);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_13);
            this.Tab_Num_1.Controls.Add(this.MA_Display14);
            this.Tab_Num_1.Controls.Add(this.MA_Display13);
            this.Tab_Num_1.Controls.Add(this.MA_Display16);
            this.Tab_Num_1.Controls.Add(this.MA_Display15);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_12);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_11);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_10);
            this.Tab_Num_1.Controls.Add(this.BTN_DISNAME_09);
            this.Tab_Num_1.Controls.Add(this.MA_Display10);
            this.Tab_Num_1.Controls.Add(this.MA_Display09);
            this.Tab_Num_1.Controls.Add(this.MA_Display12);
            this.Tab_Num_1.Controls.Add(this.MA_Display11);
            this.Tab_Num_1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Tab_Num_1.Location = new System.Drawing.Point(4, 4);
            this.Tab_Num_1.Name = "Tab_Num_1";
            this.Tab_Num_1.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Num_1.Size = new System.Drawing.Size(0, 0);
            this.Tab_Num_1.TabIndex = 1;
            this.Tab_Num_1.Text = "DIS_1";
            // 
            // BTN_DISNAME_16
            // 
            this.BTN_DISNAME_16.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_16.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_16.Location = new System.Drawing.Point(1235, 380);
            this.BTN_DISNAME_16.Name = "BTN_DISNAME_16";
            this.BTN_DISNAME_16.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_16.TabIndex = 149;
            this.BTN_DISNAME_16.Text = "DISPLAY_16";
            this.BTN_DISNAME_16.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_16.Visible = false;
            this.BTN_DISNAME_16.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_15
            // 
            this.BTN_DISNAME_15.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_15.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_15.Location = new System.Drawing.Point(824, 380);
            this.BTN_DISNAME_15.Name = "BTN_DISNAME_15";
            this.BTN_DISNAME_15.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_15.TabIndex = 148;
            this.BTN_DISNAME_15.Text = "DISPLAY_15";
            this.BTN_DISNAME_15.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_15.Visible = false;
            this.BTN_DISNAME_15.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_14
            // 
            this.BTN_DISNAME_14.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_14.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_14.Location = new System.Drawing.Point(1235, 1);
            this.BTN_DISNAME_14.Name = "BTN_DISNAME_14";
            this.BTN_DISNAME_14.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_14.TabIndex = 147;
            this.BTN_DISNAME_14.Text = "DISPLAY_14";
            this.BTN_DISNAME_14.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_14.Visible = false;
            this.BTN_DISNAME_14.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_13
            // 
            this.BTN_DISNAME_13.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_13.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_13.Location = new System.Drawing.Point(824, 1);
            this.BTN_DISNAME_13.Name = "BTN_DISNAME_13";
            this.BTN_DISNAME_13.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_13.TabIndex = 146;
            this.BTN_DISNAME_13.Text = "DISPLAY_13";
            this.BTN_DISNAME_13.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_13.Visible = false;
            this.BTN_DISNAME_13.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display14
            // 
            this.MA_Display14.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display14.ColorMapLowerRoiLimit = 0D;
            this.MA_Display14.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display14.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display14.ColorMapUpperRoiLimit = 1D;
            this.MA_Display14.DoubleTapZoomCycleLength = 2;
            this.MA_Display14.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display14.Location = new System.Drawing.Point(1236, 28);
            this.MA_Display14.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display14.MouseWheelSensitivity = 1D;
            this.MA_Display14.Name = "MA_Display14";
            this.MA_Display14.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display14.OcxState")));
            this.MA_Display14.Size = new System.Drawing.Size(411, 350);
            this.MA_Display14.TabIndex = 143;
            this.MA_Display14.Visible = false;
            this.MA_Display14.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display13
            // 
            this.MA_Display13.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display13.ColorMapLowerRoiLimit = 0D;
            this.MA_Display13.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display13.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display13.ColorMapUpperRoiLimit = 1D;
            this.MA_Display13.DoubleTapZoomCycleLength = 2;
            this.MA_Display13.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display13.Location = new System.Drawing.Point(824, 28);
            this.MA_Display13.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display13.MouseWheelSensitivity = 1D;
            this.MA_Display13.Name = "MA_Display13";
            this.MA_Display13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display13.OcxState")));
            this.MA_Display13.Size = new System.Drawing.Size(411, 350);
            this.MA_Display13.TabIndex = 142;
            this.MA_Display13.Visible = false;
            this.MA_Display13.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display16
            // 
            this.MA_Display16.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display16.ColorMapLowerRoiLimit = 0D;
            this.MA_Display16.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display16.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display16.ColorMapUpperRoiLimit = 1D;
            this.MA_Display16.DoubleTapZoomCycleLength = 2;
            this.MA_Display16.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display16.Location = new System.Drawing.Point(1236, 407);
            this.MA_Display16.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display16.MouseWheelSensitivity = 1D;
            this.MA_Display16.Name = "MA_Display16";
            this.MA_Display16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display16.OcxState")));
            this.MA_Display16.Size = new System.Drawing.Size(411, 350);
            this.MA_Display16.TabIndex = 145;
            this.MA_Display16.Visible = false;
            this.MA_Display16.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display15
            // 
            this.MA_Display15.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display15.ColorMapLowerRoiLimit = 0D;
            this.MA_Display15.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display15.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display15.ColorMapUpperRoiLimit = 1D;
            this.MA_Display15.DoubleTapZoomCycleLength = 2;
            this.MA_Display15.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display15.Location = new System.Drawing.Point(824, 407);
            this.MA_Display15.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display15.MouseWheelSensitivity = 1D;
            this.MA_Display15.Name = "MA_Display15";
            this.MA_Display15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display15.OcxState")));
            this.MA_Display15.Size = new System.Drawing.Size(411, 350);
            this.MA_Display15.TabIndex = 144;
            this.MA_Display15.Visible = false;
            this.MA_Display15.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // BTN_DISNAME_12
            // 
            this.BTN_DISNAME_12.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_12.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_12.Location = new System.Drawing.Point(412, 380);
            this.BTN_DISNAME_12.Name = "BTN_DISNAME_12";
            this.BTN_DISNAME_12.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_12.TabIndex = 141;
            this.BTN_DISNAME_12.Text = "DISPLAY_12";
            this.BTN_DISNAME_12.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_12.Visible = false;
            this.BTN_DISNAME_12.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_11
            // 
            this.BTN_DISNAME_11.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_11.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_11.Location = new System.Drawing.Point(0, 380);
            this.BTN_DISNAME_11.Name = "BTN_DISNAME_11";
            this.BTN_DISNAME_11.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_11.TabIndex = 140;
            this.BTN_DISNAME_11.Text = "DISPLAY_11";
            this.BTN_DISNAME_11.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_11.Visible = false;
            this.BTN_DISNAME_11.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_10
            // 
            this.BTN_DISNAME_10.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_10.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_10.Location = new System.Drawing.Point(412, 1);
            this.BTN_DISNAME_10.Name = "BTN_DISNAME_10";
            this.BTN_DISNAME_10.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_10.TabIndex = 139;
            this.BTN_DISNAME_10.Text = "DISPLAY_10";
            this.BTN_DISNAME_10.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_10.Visible = false;
            this.BTN_DISNAME_10.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_09
            // 
            this.BTN_DISNAME_09.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_09.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_09.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_09.Location = new System.Drawing.Point(0, 1);
            this.BTN_DISNAME_09.Name = "BTN_DISNAME_09";
            this.BTN_DISNAME_09.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_09.TabIndex = 138;
            this.BTN_DISNAME_09.Text = "DISPLAY_09";
            this.BTN_DISNAME_09.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_09.Visible = false;
            this.BTN_DISNAME_09.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display10
            // 
            this.MA_Display10.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display10.ColorMapLowerRoiLimit = 0D;
            this.MA_Display10.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display10.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display10.ColorMapUpperRoiLimit = 1D;
            this.MA_Display10.DoubleTapZoomCycleLength = 2;
            this.MA_Display10.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display10.Location = new System.Drawing.Point(412, 28);
            this.MA_Display10.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display10.MouseWheelSensitivity = 1D;
            this.MA_Display10.Name = "MA_Display10";
            this.MA_Display10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display10.OcxState")));
            this.MA_Display10.Size = new System.Drawing.Size(411, 350);
            this.MA_Display10.TabIndex = 135;
            this.MA_Display10.Visible = false;
            this.MA_Display10.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display09
            // 
            this.MA_Display09.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display09.ColorMapLowerRoiLimit = 0D;
            this.MA_Display09.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display09.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display09.ColorMapUpperRoiLimit = 1D;
            this.MA_Display09.DoubleTapZoomCycleLength = 2;
            this.MA_Display09.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display09.Location = new System.Drawing.Point(0, 28);
            this.MA_Display09.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display09.MouseWheelSensitivity = 1D;
            this.MA_Display09.Name = "MA_Display09";
            this.MA_Display09.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display09.OcxState")));
            this.MA_Display09.Size = new System.Drawing.Size(411, 350);
            this.MA_Display09.TabIndex = 134;
            this.MA_Display09.Visible = false;
            this.MA_Display09.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display12
            // 
            this.MA_Display12.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display12.ColorMapLowerRoiLimit = 0D;
            this.MA_Display12.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display12.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display12.ColorMapUpperRoiLimit = 1D;
            this.MA_Display12.DoubleTapZoomCycleLength = 2;
            this.MA_Display12.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display12.Location = new System.Drawing.Point(412, 407);
            this.MA_Display12.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display12.MouseWheelSensitivity = 1D;
            this.MA_Display12.Name = "MA_Display12";
            this.MA_Display12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display12.OcxState")));
            this.MA_Display12.Size = new System.Drawing.Size(411, 350);
            this.MA_Display12.TabIndex = 137;
            this.MA_Display12.Visible = false;
            this.MA_Display12.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display11
            // 
            this.MA_Display11.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display11.ColorMapLowerRoiLimit = 0D;
            this.MA_Display11.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display11.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display11.ColorMapUpperRoiLimit = 1D;
            this.MA_Display11.DoubleTapZoomCycleLength = 2;
            this.MA_Display11.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display11.Location = new System.Drawing.Point(0, 407);
            this.MA_Display11.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display11.MouseWheelSensitivity = 1D;
            this.MA_Display11.Name = "MA_Display11";
            this.MA_Display11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display11.OcxState")));
            this.MA_Display11.Size = new System.Drawing.Size(411, 350);
            this.MA_Display11.TabIndex = 136;
            this.MA_Display11.Visible = false;
            this.MA_Display11.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // Tab_Num_2
            // 
            this.Tab_Num_2.BackColor = System.Drawing.Color.Silver;
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_24);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_23);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_22);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_21);
            this.Tab_Num_2.Controls.Add(this.MA_Display22);
            this.Tab_Num_2.Controls.Add(this.MA_Display21);
            this.Tab_Num_2.Controls.Add(this.MA_Display24);
            this.Tab_Num_2.Controls.Add(this.MA_Display23);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_20);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_19);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_18);
            this.Tab_Num_2.Controls.Add(this.BTN_DISNAME_17);
            this.Tab_Num_2.Controls.Add(this.MA_Display18);
            this.Tab_Num_2.Controls.Add(this.MA_Display17);
            this.Tab_Num_2.Controls.Add(this.MA_Display20);
            this.Tab_Num_2.Controls.Add(this.MA_Display19);
            this.Tab_Num_2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Tab_Num_2.Location = new System.Drawing.Point(4, 4);
            this.Tab_Num_2.Name = "Tab_Num_2";
            this.Tab_Num_2.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Num_2.Size = new System.Drawing.Size(0, 0);
            this.Tab_Num_2.TabIndex = 2;
            this.Tab_Num_2.Text = "DIS_2";
            // 
            // BTN_DISNAME_24
            // 
            this.BTN_DISNAME_24.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_24.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_24.Location = new System.Drawing.Point(1235, 380);
            this.BTN_DISNAME_24.Name = "BTN_DISNAME_24";
            this.BTN_DISNAME_24.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_24.TabIndex = 165;
            this.BTN_DISNAME_24.Text = "DISPLAY_24";
            this.BTN_DISNAME_24.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_24.Visible = false;
            this.BTN_DISNAME_24.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_23
            // 
            this.BTN_DISNAME_23.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_23.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_23.Location = new System.Drawing.Point(824, 380);
            this.BTN_DISNAME_23.Name = "BTN_DISNAME_23";
            this.BTN_DISNAME_23.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_23.TabIndex = 164;
            this.BTN_DISNAME_23.Text = "DISPLAY_23";
            this.BTN_DISNAME_23.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_23.Visible = false;
            this.BTN_DISNAME_23.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_22
            // 
            this.BTN_DISNAME_22.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_22.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_22.Location = new System.Drawing.Point(1235, 1);
            this.BTN_DISNAME_22.Name = "BTN_DISNAME_22";
            this.BTN_DISNAME_22.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_22.TabIndex = 163;
            this.BTN_DISNAME_22.Text = "DISPLAY_22";
            this.BTN_DISNAME_22.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_22.Visible = false;
            this.BTN_DISNAME_22.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_21
            // 
            this.BTN_DISNAME_21.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_21.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_21.Location = new System.Drawing.Point(824, 1);
            this.BTN_DISNAME_21.Name = "BTN_DISNAME_21";
            this.BTN_DISNAME_21.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_21.TabIndex = 162;
            this.BTN_DISNAME_21.Text = "DISPLAY_21";
            this.BTN_DISNAME_21.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_21.Visible = false;
            this.BTN_DISNAME_21.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display22
            // 
            this.MA_Display22.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display22.ColorMapLowerRoiLimit = 0D;
            this.MA_Display22.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display22.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display22.ColorMapUpperRoiLimit = 1D;
            this.MA_Display22.DoubleTapZoomCycleLength = 2;
            this.MA_Display22.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display22.Location = new System.Drawing.Point(1236, 28);
            this.MA_Display22.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display22.MouseWheelSensitivity = 1D;
            this.MA_Display22.Name = "MA_Display22";
            this.MA_Display22.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display22.OcxState")));
            this.MA_Display22.Size = new System.Drawing.Size(411, 350);
            this.MA_Display22.TabIndex = 159;
            this.MA_Display22.Visible = false;
            this.MA_Display22.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display21
            // 
            this.MA_Display21.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display21.ColorMapLowerRoiLimit = 0D;
            this.MA_Display21.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display21.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display21.ColorMapUpperRoiLimit = 1D;
            this.MA_Display21.DoubleTapZoomCycleLength = 2;
            this.MA_Display21.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display21.Location = new System.Drawing.Point(824, 28);
            this.MA_Display21.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display21.MouseWheelSensitivity = 1D;
            this.MA_Display21.Name = "MA_Display21";
            this.MA_Display21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display21.OcxState")));
            this.MA_Display21.Size = new System.Drawing.Size(411, 350);
            this.MA_Display21.TabIndex = 158;
            this.MA_Display21.Visible = false;
            this.MA_Display21.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display24
            // 
            this.MA_Display24.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display24.ColorMapLowerRoiLimit = 0D;
            this.MA_Display24.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display24.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display24.ColorMapUpperRoiLimit = 1D;
            this.MA_Display24.DoubleTapZoomCycleLength = 2;
            this.MA_Display24.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display24.Location = new System.Drawing.Point(1236, 407);
            this.MA_Display24.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display24.MouseWheelSensitivity = 1D;
            this.MA_Display24.Name = "MA_Display24";
            this.MA_Display24.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display24.OcxState")));
            this.MA_Display24.Size = new System.Drawing.Size(411, 350);
            this.MA_Display24.TabIndex = 161;
            this.MA_Display24.Visible = false;
            this.MA_Display24.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display23
            // 
            this.MA_Display23.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display23.ColorMapLowerRoiLimit = 0D;
            this.MA_Display23.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display23.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display23.ColorMapUpperRoiLimit = 1D;
            this.MA_Display23.DoubleTapZoomCycleLength = 2;
            this.MA_Display23.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display23.Location = new System.Drawing.Point(824, 407);
            this.MA_Display23.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display23.MouseWheelSensitivity = 1D;
            this.MA_Display23.Name = "MA_Display23";
            this.MA_Display23.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display23.OcxState")));
            this.MA_Display23.Size = new System.Drawing.Size(411, 350);
            this.MA_Display23.TabIndex = 160;
            this.MA_Display23.Visible = false;
            this.MA_Display23.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // BTN_DISNAME_20
            // 
            this.BTN_DISNAME_20.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_20.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_20.Location = new System.Drawing.Point(412, 380);
            this.BTN_DISNAME_20.Name = "BTN_DISNAME_20";
            this.BTN_DISNAME_20.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_20.TabIndex = 157;
            this.BTN_DISNAME_20.Text = "DISPLAY_20";
            this.BTN_DISNAME_20.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_20.Visible = false;
            this.BTN_DISNAME_20.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_19
            // 
            this.BTN_DISNAME_19.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_19.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_19.Location = new System.Drawing.Point(0, 380);
            this.BTN_DISNAME_19.Name = "BTN_DISNAME_19";
            this.BTN_DISNAME_19.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_19.TabIndex = 156;
            this.BTN_DISNAME_19.Text = "DISPLAY_19";
            this.BTN_DISNAME_19.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_19.Visible = false;
            this.BTN_DISNAME_19.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_18
            // 
            this.BTN_DISNAME_18.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_18.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_18.Location = new System.Drawing.Point(412, 1);
            this.BTN_DISNAME_18.Name = "BTN_DISNAME_18";
            this.BTN_DISNAME_18.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_18.TabIndex = 155;
            this.BTN_DISNAME_18.Text = "DISPLAY_18";
            this.BTN_DISNAME_18.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_18.Visible = false;
            this.BTN_DISNAME_18.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // BTN_DISNAME_17
            // 
            this.BTN_DISNAME_17.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_17.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_17.Location = new System.Drawing.Point(0, 1);
            this.BTN_DISNAME_17.Name = "BTN_DISNAME_17";
            this.BTN_DISNAME_17.Size = new System.Drawing.Size(411, 26);
            this.BTN_DISNAME_17.TabIndex = 154;
            this.BTN_DISNAME_17.Text = "DISPLAY_17";
            this.BTN_DISNAME_17.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_17.Visible = false;
            this.BTN_DISNAME_17.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // MA_Display18
            // 
            this.MA_Display18.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display18.ColorMapLowerRoiLimit = 0D;
            this.MA_Display18.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display18.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display18.ColorMapUpperRoiLimit = 1D;
            this.MA_Display18.DoubleTapZoomCycleLength = 2;
            this.MA_Display18.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display18.Location = new System.Drawing.Point(412, 28);
            this.MA_Display18.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display18.MouseWheelSensitivity = 1D;
            this.MA_Display18.Name = "MA_Display18";
            this.MA_Display18.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display18.OcxState")));
            this.MA_Display18.Size = new System.Drawing.Size(411, 350);
            this.MA_Display18.TabIndex = 151;
            this.MA_Display18.Visible = false;
            this.MA_Display18.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display17
            // 
            this.MA_Display17.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display17.ColorMapLowerRoiLimit = 0D;
            this.MA_Display17.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display17.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display17.ColorMapUpperRoiLimit = 1D;
            this.MA_Display17.DoubleTapZoomCycleLength = 2;
            this.MA_Display17.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display17.Location = new System.Drawing.Point(0, 28);
            this.MA_Display17.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display17.MouseWheelSensitivity = 1D;
            this.MA_Display17.Name = "MA_Display17";
            this.MA_Display17.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display17.OcxState")));
            this.MA_Display17.Size = new System.Drawing.Size(411, 350);
            this.MA_Display17.TabIndex = 150;
            this.MA_Display17.Visible = false;
            this.MA_Display17.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display20
            // 
            this.MA_Display20.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display20.ColorMapLowerRoiLimit = 0D;
            this.MA_Display20.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display20.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display20.ColorMapUpperRoiLimit = 1D;
            this.MA_Display20.DoubleTapZoomCycleLength = 2;
            this.MA_Display20.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display20.Location = new System.Drawing.Point(412, 407);
            this.MA_Display20.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display20.MouseWheelSensitivity = 1D;
            this.MA_Display20.Name = "MA_Display20";
            this.MA_Display20.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display20.OcxState")));
            this.MA_Display20.Size = new System.Drawing.Size(411, 350);
            this.MA_Display20.TabIndex = 153;
            this.MA_Display20.Visible = false;
            this.MA_Display20.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // MA_Display19
            // 
            this.MA_Display19.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.MA_Display19.ColorMapLowerRoiLimit = 0D;
            this.MA_Display19.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.MA_Display19.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.MA_Display19.ColorMapUpperRoiLimit = 1D;
            this.MA_Display19.DoubleTapZoomCycleLength = 2;
            this.MA_Display19.DoubleTapZoomSensitivity = 2.5D;
            this.MA_Display19.Location = new System.Drawing.Point(0, 407);
            this.MA_Display19.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.MA_Display19.MouseWheelSensitivity = 1D;
            this.MA_Display19.Name = "MA_Display19";
            this.MA_Display19.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MA_Display19.OcxState")));
            this.MA_Display19.Size = new System.Drawing.Size(411, 350);
            this.MA_Display19.TabIndex = 152;
            this.MA_Display19.Visible = false;
            this.MA_Display19.DoubleClick += new System.EventHandler(this.MA_Display_DoubleClick);
            // 
            // BTN_DISNAME_01
            // 
            this.BTN_DISNAME_01.BackColor = System.Drawing.Color.SkyBlue;
            this.BTN_DISNAME_01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_DISNAME_01.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_DISNAME_01.Location = new System.Drawing.Point(77, 3);
            this.BTN_DISNAME_01.Name = "BTN_DISNAME_01";
            this.BTN_DISNAME_01.Size = new System.Drawing.Size(33, 1);
            this.BTN_DISNAME_01.TabIndex = 103;
            this.BTN_DISNAME_01.Text = "DISPLAY_01";
            this.BTN_DISNAME_01.UseVisualStyleBackColor = false;
            this.BTN_DISNAME_01.Visible = false;
            this.BTN_DISNAME_01.Click += new System.EventHandler(this.BTN_LIVEVIEW_Click);
            // 
            // RBTN_TAB_1
            // 
            this.RBTN_TAB_1.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_TAB_1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)), true);
            this.RBTN_TAB_1.ForeColor = System.Drawing.Color.Black;
            this.RBTN_TAB_1.Location = new System.Drawing.Point(40, 3);
            this.RBTN_TAB_1.Name = "RBTN_TAB_1";
            this.RBTN_TAB_1.Size = new System.Drawing.Size(31, 1);
            this.RBTN_TAB_1.TabIndex = 11;
            this.RBTN_TAB_1.Text = "DISPLAY_1";
            this.RBTN_TAB_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_TAB_1.UseVisualStyleBackColor = false;
            this.RBTN_TAB_1.Visible = false;
            this.RBTN_TAB_1.CheckedChanged += new System.EventHandler(this.RBTN_TAB_Checked_Click);
            this.RBTN_TAB_1.Click += new System.EventHandler(this.RBTN_TAB_Click);
            // 
            // RBTN_TAB_2
            // 
            this.RBTN_TAB_2.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_TAB_2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)), true);
            this.RBTN_TAB_2.ForeColor = System.Drawing.Color.Black;
            this.RBTN_TAB_2.Location = new System.Drawing.Point(77, 3);
            this.RBTN_TAB_2.Name = "RBTN_TAB_2";
            this.RBTN_TAB_2.Size = new System.Drawing.Size(33, 1);
            this.RBTN_TAB_2.TabIndex = 12;
            this.RBTN_TAB_2.Text = "DISPLAY_2";
            this.RBTN_TAB_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_TAB_2.UseVisualStyleBackColor = false;
            this.RBTN_TAB_2.Visible = false;
            this.RBTN_TAB_2.CheckedChanged += new System.EventHandler(this.RBTN_TAB_Checked_Click);
            this.RBTN_TAB_2.Click += new System.EventHandler(this.RBTN_TAB_Click);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Gray;
            this.lblDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDateTime.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDateTime.ForeColor = System.Drawing.Color.Black;
            this.lblDateTime.Location = new System.Drawing.Point(3, 50);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(238, 50);
            this.lblDateTime.TabIndex = 85;
            this.lblDateTime.Text = "Time";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_LIGHT_INITIAL
            // 
            this.BTN_LIGHT_INITIAL.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_LIGHT_INITIAL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_LIGHT_INITIAL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_LIGHT_INITIAL.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_LIGHT_INITIAL.Location = new System.Drawing.Point(56, 0);
            this.BTN_LIGHT_INITIAL.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_LIGHT_INITIAL.Name = "BTN_LIGHT_INITIAL";
            this.BTN_LIGHT_INITIAL.Size = new System.Drawing.Size(28, 3);
            this.BTN_LIGHT_INITIAL.TabIndex = 86;
            this.BTN_LIGHT_INITIAL.Text = "Light  Initial";
            this.BTN_LIGHT_INITIAL.UseVisualStyleBackColor = false;
            this.BTN_LIGHT_INITIAL.Visible = false;
            this.BTN_LIGHT_INITIAL.Click += new System.EventHandler(this.BTN_LIGHT_INITIAL_Click);
            // 
            // BTN_INSPECT_SHOW
            // 
            this.BTN_INSPECT_SHOW.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_INSPECT_SHOW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_INSPECT_SHOW.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_INSPECT_SHOW.Location = new System.Drawing.Point(3, 3);
            this.BTN_INSPECT_SHOW.Name = "BTN_INSPECT_SHOW";
            this.BTN_INSPECT_SHOW.Size = new System.Drawing.Size(31, 1);
            this.BTN_INSPECT_SHOW.TabIndex = 88;
            this.BTN_INSPECT_SHOW.Text = "INSPECTION_SHOW";
            this.BTN_INSPECT_SHOW.UseVisualStyleBackColor = false;
            this.BTN_INSPECT_SHOW.Visible = false;
            this.BTN_INSPECT_SHOW.Click += new System.EventHandler(this.BTN_INSPECT_SHOW_Click);
            // 
            // GB_INSPECTION
            // 
            this.GB_INSPECTION.Controls.Add(this.label56);
            this.GB_INSPECTION.Controls.Add(this.label55);
            this.GB_INSPECTION.Controls.Add(this.label30);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_07);
            this.GB_INSPECTION.Controls.Add(this.label40);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_05);
            this.GB_INSPECTION.Controls.Add(this.label42);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_03);
            this.GB_INSPECTION.Controls.Add(this.label44);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_01);
            this.GB_INSPECTION.Controls.Add(this.label46);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_06);
            this.GB_INSPECTION.Controls.Add(this.label48);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_04);
            this.GB_INSPECTION.Controls.Add(this.label50);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_02);
            this.GB_INSPECTION.Controls.Add(this.label52);
            this.GB_INSPECTION.Controls.Add(this.label53);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_2_00);
            this.GB_INSPECTION.Controls.Add(this.pictureBox2);
            this.GB_INSPECTION.Controls.Add(this.label12);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_07);
            this.GB_INSPECTION.Controls.Add(this.label14);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_05);
            this.GB_INSPECTION.Controls.Add(this.label16);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_03);
            this.GB_INSPECTION.Controls.Add(this.label18);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_01);
            this.GB_INSPECTION.Controls.Add(this.label20);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_06);
            this.GB_INSPECTION.Controls.Add(this.label22);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_04);
            this.GB_INSPECTION.Controls.Add(this.label24);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_02);
            this.GB_INSPECTION.Controls.Add(this.label26);
            this.GB_INSPECTION.Controls.Add(this.label27);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_1_00);
            this.GB_INSPECTION.Controls.Add(this.pictureBox1);
            this.GB_INSPECTION.Controls.Add(this.label35);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_07);
            this.GB_INSPECTION.Controls.Add(this.label37);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_05);
            this.GB_INSPECTION.Controls.Add(this.label33);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_03);
            this.GB_INSPECTION.Controls.Add(this.label11);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_01);
            this.GB_INSPECTION.Controls.Add(this.label9);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_06);
            this.GB_INSPECTION.Controls.Add(this.label3);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_04);
            this.GB_INSPECTION.Controls.Add(this.label1);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_02);
            this.GB_INSPECTION.Controls.Add(this.label31);
            this.GB_INSPECTION.Controls.Add(this.label28);
            this.GB_INSPECTION.Controls.Add(this.LB_INSPEC_0_00);
            this.GB_INSPECTION.Controls.Add(this.pictureBox3);
            this.GB_INSPECTION.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GB_INSPECTION.ForeColor = System.Drawing.Color.White;
            this.GB_INSPECTION.Location = new System.Drawing.Point(3, 3);
            this.GB_INSPECTION.Name = "GB_INSPECTION";
            this.GB_INSPECTION.Size = new System.Drawing.Size(31, 1);
            this.GB_INSPECTION.TabIndex = 210;
            this.GB_INSPECTION.TabStop = false;
            this.GB_INSPECTION.Text = "INSPECTION DISPLAY (um)";
            this.GB_INSPECTION.Visible = false;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.DarkGray;
            this.label56.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label56.ForeColor = System.Drawing.Color.Black;
            this.label56.Location = new System.Drawing.Point(464, 12);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(10, 166);
            this.label56.TabIndex = 108;
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.DarkGray;
            this.label55.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(231, 13);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(10, 166);
            this.label55.TabIndex = 107;
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Silver;
            this.label30.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(650, 150);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 23);
            this.label30.TabIndex = 106;
            this.label30.Text = "RY";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_07
            // 
            this.LB_INSPEC_2_07.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_07.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_07.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_07.Location = new System.Drawing.Point(593, 150);
            this.LB_INSPEC_2_07.Name = "LB_INSPEC_2_07";
            this.LB_INSPEC_2_07.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_07.TabIndex = 105;
            this.LB_INSPEC_2_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.Color.Silver;
            this.label40.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label40.ForeColor = System.Drawing.Color.Black;
            this.label40.Location = new System.Drawing.Point(505, 150);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(24, 23);
            this.label40.TabIndex = 104;
            this.label40.Text = "RY";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_05
            // 
            this.LB_INSPEC_2_05.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_05.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_05.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_05.Location = new System.Drawing.Point(528, 150);
            this.LB_INSPEC_2_05.Name = "LB_INSPEC_2_05";
            this.LB_INSPEC_2_05.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_05.TabIndex = 103;
            this.LB_INSPEC_2_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Silver;
            this.label42.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(650, 17);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(24, 23);
            this.label42.TabIndex = 102;
            this.label42.Text = "FY";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_03
            // 
            this.LB_INSPEC_2_03.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_03.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_03.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_03.Location = new System.Drawing.Point(593, 17);
            this.LB_INSPEC_2_03.Name = "LB_INSPEC_2_03";
            this.LB_INSPEC_2_03.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_03.TabIndex = 101;
            this.LB_INSPEC_2_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Silver;
            this.label44.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(505, 17);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(24, 23);
            this.label44.TabIndex = 100;
            this.label44.Text = "FY";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_01
            // 
            this.LB_INSPEC_2_01.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_01.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_01.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_01.Location = new System.Drawing.Point(528, 17);
            this.LB_INSPEC_2_01.Name = "LB_INSPEC_2_01";
            this.LB_INSPEC_2_01.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_01.TabIndex = 99;
            this.LB_INSPEC_2_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Silver;
            this.label46.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label46.ForeColor = System.Drawing.Color.Black;
            this.label46.Location = new System.Drawing.Point(675, 125);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(24, 23);
            this.label46.TabIndex = 98;
            this.label46.Text = "RX";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_06
            // 
            this.LB_INSPEC_2_06.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_06.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_06.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_06.Location = new System.Drawing.Point(626, 125);
            this.LB_INSPEC_2_06.Name = "LB_INSPEC_2_06";
            this.LB_INSPEC_2_06.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_06.TabIndex = 97;
            this.LB_INSPEC_2_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Silver;
            this.label48.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(474, 125);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(24, 23);
            this.label48.TabIndex = 96;
            this.label48.Text = "RX";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_04
            // 
            this.LB_INSPEC_2_04.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_04.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_04.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_04.Location = new System.Drawing.Point(498, 125);
            this.LB_INSPEC_2_04.Name = "LB_INSPEC_2_04";
            this.LB_INSPEC_2_04.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_04.TabIndex = 95;
            this.LB_INSPEC_2_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Silver;
            this.label50.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(677, 43);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(24, 23);
            this.label50.TabIndex = 94;
            this.label50.Text = "FX";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_02
            // 
            this.LB_INSPEC_2_02.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_02.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_02.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_02.Location = new System.Drawing.Point(626, 43);
            this.LB_INSPEC_2_02.Name = "LB_INSPEC_2_02";
            this.LB_INSPEC_2_02.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_02.TabIndex = 93;
            this.LB_INSPEC_2_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Silver;
            this.label52.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label52.ForeColor = System.Drawing.Color.Black;
            this.label52.Location = new System.Drawing.Point(474, 42);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(24, 23);
            this.label52.TabIndex = 92;
            this.label52.Text = "FX";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label53.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(572, 90);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(30, 23);
            this.label53.TabIndex = 91;
            this.label53.Text = "3S";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_2_00
            // 
            this.LB_INSPEC_2_00.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_2_00.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_2_00.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_2_00.Location = new System.Drawing.Point(498, 42);
            this.LB_INSPEC_2_00.Name = "LB_INSPEC_2_00";
            this.LB_INSPEC_2_00.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_2_00.TabIndex = 90;
            this.LB_INSPEC_2_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::COG.Properties.Resources.inspection1;
            this.pictureBox2.Location = new System.Drawing.Point(549, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 104);
            this.pictureBox2.TabIndex = 89;
            this.pictureBox2.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Silver;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(415, 150);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 23);
            this.label12.TabIndex = 88;
            this.label12.Text = "RY";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_07
            // 
            this.LB_INSPEC_1_07.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_07.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_07.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_07.Location = new System.Drawing.Point(358, 150);
            this.LB_INSPEC_1_07.Name = "LB_INSPEC_1_07";
            this.LB_INSPEC_1_07.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_07.TabIndex = 87;
            this.LB_INSPEC_1_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Silver;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(269, 150);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 23);
            this.label14.TabIndex = 86;
            this.label14.Text = "RY";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_05
            // 
            this.LB_INSPEC_1_05.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_05.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_05.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_05.Location = new System.Drawing.Point(294, 150);
            this.LB_INSPEC_1_05.Name = "LB_INSPEC_1_05";
            this.LB_INSPEC_1_05.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_05.TabIndex = 85;
            this.LB_INSPEC_1_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Silver;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(415, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(24, 23);
            this.label16.TabIndex = 84;
            this.label16.Text = "FY";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_03
            // 
            this.LB_INSPEC_1_03.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_03.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_03.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_03.Location = new System.Drawing.Point(358, 17);
            this.LB_INSPEC_1_03.Name = "LB_INSPEC_1_03";
            this.LB_INSPEC_1_03.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_03.TabIndex = 83;
            this.LB_INSPEC_1_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Silver;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(269, 17);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 23);
            this.label18.TabIndex = 82;
            this.label18.Text = "FY";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_01
            // 
            this.LB_INSPEC_1_01.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_01.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_01.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_01.Location = new System.Drawing.Point(294, 17);
            this.LB_INSPEC_1_01.Name = "LB_INSPEC_1_01";
            this.LB_INSPEC_1_01.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_01.TabIndex = 81;
            this.LB_INSPEC_1_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Silver;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(440, 125);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(24, 23);
            this.label20.TabIndex = 80;
            this.label20.Text = "RX";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_06
            // 
            this.LB_INSPEC_1_06.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_06.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_06.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_06.Location = new System.Drawing.Point(391, 125);
            this.LB_INSPEC_1_06.Name = "LB_INSPEC_1_06";
            this.LB_INSPEC_1_06.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_06.TabIndex = 79;
            this.LB_INSPEC_1_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Silver;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(239, 125);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(24, 23);
            this.label22.TabIndex = 78;
            this.label22.Text = "RX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_04
            // 
            this.LB_INSPEC_1_04.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_04.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_04.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_04.Location = new System.Drawing.Point(262, 125);
            this.LB_INSPEC_1_04.Name = "LB_INSPEC_1_04";
            this.LB_INSPEC_1_04.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_04.TabIndex = 77;
            this.LB_INSPEC_1_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Silver;
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(442, 43);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 23);
            this.label24.TabIndex = 76;
            this.label24.Text = "FX";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_02
            // 
            this.LB_INSPEC_1_02.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_02.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_02.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_02.Location = new System.Drawing.Point(391, 43);
            this.LB_INSPEC_1_02.Name = "LB_INSPEC_1_02";
            this.LB_INSPEC_1_02.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_02.TabIndex = 75;
            this.LB_INSPEC_1_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Silver;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(239, 42);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 23);
            this.label26.TabIndex = 74;
            this.label26.Text = "FX";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(337, 90);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 23);
            this.label27.TabIndex = 73;
            this.label27.Text = "2S";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_1_00
            // 
            this.LB_INSPEC_1_00.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_1_00.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_1_00.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_1_00.Location = new System.Drawing.Point(262, 42);
            this.LB_INSPEC_1_00.Name = "LB_INSPEC_1_00";
            this.LB_INSPEC_1_00.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_1_00.TabIndex = 72;
            this.LB_INSPEC_1_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::COG.Properties.Resources.inspection1;
            this.pictureBox1.Location = new System.Drawing.Point(314, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 104);
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Silver;
            this.label35.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(183, 150);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(24, 23);
            this.label35.TabIndex = 70;
            this.label35.Text = "RY";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_07
            // 
            this.LB_INSPEC_0_07.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_07.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_07.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_07.Location = new System.Drawing.Point(126, 150);
            this.LB_INSPEC_0_07.Name = "LB_INSPEC_0_07";
            this.LB_INSPEC_0_07.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_07.TabIndex = 69;
            this.LB_INSPEC_0_07.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Silver;
            this.label37.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(38, 150);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(24, 23);
            this.label37.TabIndex = 68;
            this.label37.Text = "RY";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_05
            // 
            this.LB_INSPEC_0_05.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_05.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_05.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_05.Location = new System.Drawing.Point(62, 150);
            this.LB_INSPEC_0_05.Name = "LB_INSPEC_0_05";
            this.LB_INSPEC_0_05.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_05.TabIndex = 67;
            this.LB_INSPEC_0_05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Silver;
            this.label33.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(183, 17);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(24, 23);
            this.label33.TabIndex = 66;
            this.label33.Text = "FY";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_03
            // 
            this.LB_INSPEC_0_03.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_03.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_03.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_03.Location = new System.Drawing.Point(126, 17);
            this.LB_INSPEC_0_03.Name = "LB_INSPEC_0_03";
            this.LB_INSPEC_0_03.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_03.TabIndex = 65;
            this.LB_INSPEC_0_03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(38, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 23);
            this.label11.TabIndex = 64;
            this.label11.Text = "FY";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_01
            // 
            this.LB_INSPEC_0_01.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_01.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_01.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_01.Location = new System.Drawing.Point(62, 17);
            this.LB_INSPEC_0_01.Name = "LB_INSPEC_0_01";
            this.LB_INSPEC_0_01.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_01.TabIndex = 63;
            this.LB_INSPEC_0_01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(208, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 23);
            this.label9.TabIndex = 62;
            this.label9.Text = "RX";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_06
            // 
            this.LB_INSPEC_0_06.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_06.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_06.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_06.Location = new System.Drawing.Point(159, 125);
            this.LB_INSPEC_0_06.Name = "LB_INSPEC_0_06";
            this.LB_INSPEC_0_06.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_06.TabIndex = 61;
            this.LB_INSPEC_0_06.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 23);
            this.label3.TabIndex = 60;
            this.label3.Text = "RX";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_04
            // 
            this.LB_INSPEC_0_04.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_04.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_04.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_04.Location = new System.Drawing.Point(31, 124);
            this.LB_INSPEC_0_04.Name = "LB_INSPEC_0_04";
            this.LB_INSPEC_0_04.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_04.TabIndex = 59;
            this.LB_INSPEC_0_04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(210, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 23);
            this.label1.TabIndex = 58;
            this.label1.Text = "FX";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_02
            // 
            this.LB_INSPEC_0_02.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_02.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_02.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_02.Location = new System.Drawing.Point(159, 43);
            this.LB_INSPEC_0_02.Name = "LB_INSPEC_0_02";
            this.LB_INSPEC_0_02.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_02.TabIndex = 57;
            this.LB_INSPEC_0_02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Silver;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(7, 42);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(24, 23);
            this.label31.TabIndex = 56;
            this.label31.Text = "FX";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label28.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(105, 90);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 23);
            this.label28.TabIndex = 53;
            this.label28.Text = "1S";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_INSPEC_0_00
            // 
            this.LB_INSPEC_0_00.BackColor = System.Drawing.Color.White;
            this.LB_INSPEC_0_00.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_INSPEC_0_00.ForeColor = System.Drawing.Color.Black;
            this.LB_INSPEC_0_00.Location = new System.Drawing.Point(31, 42);
            this.LB_INSPEC_0_00.Name = "LB_INSPEC_0_00";
            this.LB_INSPEC_0_00.Size = new System.Drawing.Size(50, 23);
            this.LB_INSPEC_0_00.TabIndex = 27;
            this.LB_INSPEC_0_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::COG.Properties.Resources.inspection1;
            this.pictureBox3.Location = new System.Drawing.Point(82, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 104);
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // btnTest_AddResult
            // 
            this.btnTest_AddResult.BackColor = System.Drawing.Color.DarkGray;
            this.btnTest_AddResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTest_AddResult.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnTest_AddResult.Location = new System.Drawing.Point(77, 3);
            this.btnTest_AddResult.Name = "btnTest_AddResult";
            this.btnTest_AddResult.Size = new System.Drawing.Size(33, 1);
            this.btnTest_AddResult.TabIndex = 232;
            this.btnTest_AddResult.Text = "Test_AddResult";
            this.btnTest_AddResult.UseVisualStyleBackColor = false;
            this.btnTest_AddResult.Visible = false;
            this.btnTest_AddResult.Click += new System.EventHandler(this.btnTest_AddResult_Click);
            // 
            // BTN_LIGHT_PANEL
            // 
            this.BTN_LIGHT_PANEL.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_LIGHT_PANEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_LIGHT_PANEL.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_LIGHT_PANEL.Location = new System.Drawing.Point(40, 3);
            this.BTN_LIGHT_PANEL.Name = "BTN_LIGHT_PANEL";
            this.BTN_LIGHT_PANEL.Size = new System.Drawing.Size(31, 1);
            this.BTN_LIGHT_PANEL.TabIndex = 212;
            this.BTN_LIGHT_PANEL.Text = "PBD_PANEL_LIGHT";
            this.BTN_LIGHT_PANEL.UseVisualStyleBackColor = false;
            this.BTN_LIGHT_PANEL.Visible = false;
            this.BTN_LIGHT_PANEL.Click += new System.EventHandler(this.BTN_LIGHT_PANEL_Click);
            // 
            // BTN_LIGHT_FPC
            // 
            this.BTN_LIGHT_FPC.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_LIGHT_FPC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_LIGHT_FPC.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_LIGHT_FPC.Location = new System.Drawing.Point(77, 3);
            this.BTN_LIGHT_FPC.Name = "BTN_LIGHT_FPC";
            this.BTN_LIGHT_FPC.Size = new System.Drawing.Size(33, 1);
            this.BTN_LIGHT_FPC.TabIndex = 213;
            this.BTN_LIGHT_FPC.Text = "PBD_CHIP_LIGHT";
            this.BTN_LIGHT_FPC.UseVisualStyleBackColor = false;
            this.BTN_LIGHT_FPC.Visible = false;
            this.BTN_LIGHT_FPC.Click += new System.EventHandler(this.BTN_LIGHT_FPC_Click);
            // 
            // BTN_TRAY_VIEW
            // 
            this.BTN_TRAY_VIEW.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_TRAY_VIEW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_TRAY_VIEW.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_TRAY_VIEW.Location = new System.Drawing.Point(40, 3);
            this.BTN_TRAY_VIEW.Name = "BTN_TRAY_VIEW";
            this.BTN_TRAY_VIEW.Size = new System.Drawing.Size(31, 1);
            this.BTN_TRAY_VIEW.TabIndex = 218;
            this.BTN_TRAY_VIEW.Text = "TRAY_DATA_VIEW";
            this.BTN_TRAY_VIEW.UseVisualStyleBackColor = false;
            this.BTN_TRAY_VIEW.Visible = false;
            this.BTN_TRAY_VIEW.Click += new System.EventHandler(this.BTN_TRAY_VIEW_Click);
            // 
            // BTN_LIGHT_ON
            // 
            this.BTN_LIGHT_ON.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_LIGHT_ON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_LIGHT_ON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_LIGHT_ON.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_LIGHT_ON.Location = new System.Drawing.Point(3, 3);
            this.BTN_LIGHT_ON.Name = "BTN_LIGHT_ON";
            this.BTN_LIGHT_ON.Size = new System.Drawing.Size(113, 52);
            this.BTN_LIGHT_ON.TabIndex = 220;
            this.BTN_LIGHT_ON.Text = "LIGHT ON";
            this.BTN_LIGHT_ON.UseVisualStyleBackColor = false;
            this.BTN_LIGHT_ON.Click += new System.EventHandler(this.BTN_LIGHT_ON_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(122, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 52);
            this.button1.TabIndex = 219;
            this.button1.Text = "LIGHT OFF";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BTN_LIGHT_OFF_Click);
            // 
            // BTN_CCLINKTEST
            // 
            this.BTN_CCLINKTEST.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_CCLINKTEST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_CCLINKTEST.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_CCLINKTEST.Location = new System.Drawing.Point(3, 3);
            this.BTN_CCLINKTEST.Name = "BTN_CCLINKTEST";
            this.BTN_CCLINKTEST.Size = new System.Drawing.Size(31, 1);
            this.BTN_CCLINKTEST.TabIndex = 222;
            this.BTN_CCLINKTEST.Text = "TEST BIT";
            this.BTN_CCLINKTEST.UseVisualStyleBackColor = false;
            this.BTN_CCLINKTEST.Visible = false;
            this.BTN_CCLINKTEST.Click += new System.EventHandler(this.BTN_CCLINKTEST_Click);
            // 
            // BTN_MXTEST
            // 
            this.BTN_MXTEST.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MXTEST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MXTEST.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_MXTEST.Location = new System.Drawing.Point(77, 3);
            this.BTN_MXTEST.Name = "BTN_MXTEST";
            this.BTN_MXTEST.Size = new System.Drawing.Size(33, 1);
            this.BTN_MXTEST.TabIndex = 223;
            this.BTN_MXTEST.Text = "TEST MXCOM";
            this.BTN_MXTEST.UseVisualStyleBackColor = false;
            this.BTN_MXTEST.Visible = false;
            this.BTN_MXTEST.Click += new System.EventHandler(this.BTN_MXTEST_Click);
            // 
            // BTN_FIT_IMAGE
            // 
            this.BTN_FIT_IMAGE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_FIT_IMAGE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_FIT_IMAGE.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_FIT_IMAGE.Location = new System.Drawing.Point(3, 3);
            this.BTN_FIT_IMAGE.Name = "BTN_FIT_IMAGE";
            this.BTN_FIT_IMAGE.Size = new System.Drawing.Size(31, 1);
            this.BTN_FIT_IMAGE.TabIndex = 224;
            this.BTN_FIT_IMAGE.Text = "DISPLAY FIT";
            this.BTN_FIT_IMAGE.UseVisualStyleBackColor = false;
            this.BTN_FIT_IMAGE.Visible = false;
            this.BTN_FIT_IMAGE.Click += new System.EventHandler(this.BTN_FIT_IMAGE_Click);
            // 
            // pnlCPU_Usage
            // 
            this.pnlCPU_Usage.BackColor = System.Drawing.Color.Silver;
            this.pnlCPU_Usage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCPU_Usage.Controls.Add(this.btnFlyingVision);
            this.pnlCPU_Usage.Location = new System.Drawing.Point(3, 137);
            this.pnlCPU_Usage.Name = "pnlCPU_Usage";
            this.pnlCPU_Usage.Size = new System.Drawing.Size(113, 54);
            this.pnlCPU_Usage.TabIndex = 226;
            this.pnlCPU_Usage.Visible = false;
            // 
            // btnFlyingVision
            // 
            this.btnFlyingVision.BackColor = System.Drawing.Color.DarkGray;
            this.btnFlyingVision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFlyingVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFlyingVision.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnFlyingVision.Location = new System.Drawing.Point(0, 0);
            this.btnFlyingVision.Name = "btnFlyingVision";
            this.btnFlyingVision.Size = new System.Drawing.Size(111, 52);
            this.btnFlyingVision.TabIndex = 236;
            this.btnFlyingVision.Text = "Flying Vision";
            this.btnFlyingVision.UseVisualStyleBackColor = false;
            this.btnFlyingVision.Visible = false;
            this.btnFlyingVision.Click += new System.EventHandler(this.btnFlyingVision_Click);
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 1000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // BTN_VISION_RESET
            // 
            this.BTN_VISION_RESET.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_VISION_RESET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_VISION_RESET.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.BTN_VISION_RESET.Location = new System.Drawing.Point(3, 3);
            this.BTN_VISION_RESET.Name = "BTN_VISION_RESET";
            this.BTN_VISION_RESET.Size = new System.Drawing.Size(31, 1);
            this.BTN_VISION_RESET.TabIndex = 229;
            this.BTN_VISION_RESET.Text = "VISION RESET";
            this.BTN_VISION_RESET.UseVisualStyleBackColor = false;
            this.BTN_VISION_RESET.Visible = false;
            this.BTN_VISION_RESET.Click += new System.EventHandler(this.BTN_VISION_RESET_Click);
            // 
            // tlpGrabView
            // 
            this.tlpGrabView.ColumnCount = 1;
            this.tlpGrabView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrabView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpGrabView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGrabView.Location = new System.Drawing.Point(0, 60);
            this.tlpGrabView.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGrabView.Name = "tlpGrabView";
            this.tlpGrabView.RowCount = 1;
            this.tlpGrabView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrabView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 727F));
            this.tlpGrabView.Size = new System.Drawing.Size(1651, 727);
            this.tlpGrabView.TabIndex = 230;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1900, 969);
            this.pnlMain.TabIndex = 231;
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.Margin = new System.Windows.Forms.Padding(0);
            this.splMain.Name = "splMain";
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.tlpFunction);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.tlpStatus);
            this.splMain.Size = new System.Drawing.Size(1900, 969);
            this.splMain.SplitterDistance = 1651;
            this.splMain.SplitterWidth = 5;
            this.splMain.TabIndex = 0;
            // 
            // tlpFunction
            // 
            this.tlpFunction.ColumnCount = 1;
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunction.Controls.Add(this.tlpButton, 0, 0);
            this.tlpFunction.Controls.Add(this.tlpGrabView, 0, 1);
            this.tlpFunction.Controls.Add(this.tlpInformation, 0, 2);
            this.tlpFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunction.Name = "tlpFunction";
            this.tlpFunction.RowCount = 3;
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpFunction.Size = new System.Drawing.Size(1651, 969);
            this.tlpFunction.TabIndex = 0;
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 8;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButton.Controls.Add(this.btnInterface, 4, 0);
            this.tlpButton.Controls.Add(this.btnSystem, 1, 0);
            this.tlpButton.Controls.Add(this.btnAuthority, 7, 0);
            this.tlpButton.Controls.Add(this.btnRecipe, 0, 0);
            this.tlpButton.Controls.Add(this.btnSetting, 2, 0);
            this.tlpButton.Controls.Add(this.BTN_MOTION, 3, 0);
            this.tlpButton.Controls.Add(this.btnLog, 5, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(0, 0);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(1651, 60);
            this.tlpButton.TabIndex = 0;
            // 
            // btnInterface
            // 
            this.btnInterface.BackColor = System.Drawing.Color.DarkGray;
            this.btnInterface.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInterface.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnInterface.Image = global::COG.Properties.Resources.interface40;
            this.btnInterface.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInterface.Location = new System.Drawing.Point(824, 0);
            this.btnInterface.Margin = new System.Windows.Forms.Padding(0);
            this.btnInterface.Name = "btnInterface";
            this.btnInterface.Size = new System.Drawing.Size(206, 60);
            this.btnInterface.TabIndex = 39;
            this.btnInterface.Text = "INTERFACE";
            this.btnInterface.UseVisualStyleBackColor = false;
            this.btnInterface.Click += new System.EventHandler(this.BTN_MELSEC_Click);
            // 
            // btnSystem
            // 
            this.btnSystem.BackColor = System.Drawing.Color.DarkGray;
            this.btnSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSystem.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSystem.Image = global::COG.Properties.Resources.setup40;
            this.btnSystem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystem.Location = new System.Drawing.Point(206, 0);
            this.btnSystem.Margin = new System.Windows.Forms.Padding(0);
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.Size = new System.Drawing.Size(206, 60);
            this.btnSystem.TabIndex = 40;
            this.btnSystem.Text = "SYSTEM";
            this.btnSystem.UseVisualStyleBackColor = false;
            this.btnSystem.Click += new System.EventHandler(this.BTN_SETUP_Click);
            // 
            // btnAuthority
            // 
            this.btnAuthority.BackColor = System.Drawing.Color.DarkGray;
            this.btnAuthority.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAuthority.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnAuthority.Image = global::COG.Properties.Resources.Key;
            this.btnAuthority.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAuthority.Location = new System.Drawing.Point(1442, 0);
            this.btnAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.btnAuthority.Name = "btnAuthority";
            this.btnAuthority.Size = new System.Drawing.Size(209, 60);
            this.btnAuthority.TabIndex = 236;
            this.btnAuthority.Text = "Authority";
            this.btnAuthority.UseVisualStyleBackColor = false;
            this.btnAuthority.Click += new System.EventHandler(this.btnAuthority_Click);
            // 
            // btnRecipe
            // 
            this.btnRecipe.BackColor = System.Drawing.Color.DarkGray;
            this.btnRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipe.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnRecipe.Image = global::COG.Properties.Resources.project40;
            this.btnRecipe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecipe.Location = new System.Drawing.Point(0, 0);
            this.btnRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(206, 60);
            this.btnRecipe.TabIndex = 41;
            this.btnRecipe.Text = "MODEL";
            this.btnRecipe.UseVisualStyleBackColor = false;
            this.btnRecipe.Click += new System.EventHandler(this.BTN_PROJECT_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.DarkGray;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetting.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetting.Image = global::COG.Properties.Resources.recipe40;
            this.btnSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Location = new System.Drawing.Point(412, 0);
            this.btnSetting.Margin = new System.Windows.Forms.Padding(0);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(206, 60);
            this.btnSetting.TabIndex = 38;
            this.btnSetting.Text = "RECIPE";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.BTN_TEACH_Click);
            // 
            // BTN_MOTION
            // 
            this.BTN_MOTION.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MOTION.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MOTION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_MOTION.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BTN_MOTION.Image = global::COG.Properties.Resources.square1_24;
            this.BTN_MOTION.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_MOTION.Location = new System.Drawing.Point(618, 0);
            this.BTN_MOTION.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_MOTION.Name = "BTN_MOTION";
            this.BTN_MOTION.Size = new System.Drawing.Size(206, 60);
            this.BTN_MOTION.TabIndex = 220;
            this.BTN_MOTION.Text = "MOTION";
            this.BTN_MOTION.UseVisualStyleBackColor = false;
            this.BTN_MOTION.Click += new System.EventHandler(this.BTN_MOTION_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.DarkGray;
            this.btnLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLog.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnLog.Image = global::COG.Properties.Resources.log40;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(1030, 0);
            this.btnLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(206, 60);
            this.btnLog.TabIndex = 81;
            this.btnLog.Text = "LOG VIEW";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.BTN_LOGVIEW_Click);
            // 
            // tlpInformation
            // 
            this.tlpInformation.ColumnCount = 1;
            this.tlpInformation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInformation.Location = new System.Drawing.Point(0, 787);
            this.tlpInformation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInformation.Name = "tlpInformation";
            this.tlpInformation.RowCount = 1;
            this.tlpInformation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInformation.Size = new System.Drawing.Size(1651, 182);
            this.tlpInformation.TabIndex = 231;
            // 
            // tlpStatus
            // 
            this.tlpStatus.ColumnCount = 1;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatus.Controls.Add(this.btnCamera, 0, 6);
            this.tlpStatus.Controls.Add(this.picLogo, 0, 0);
            this.tlpStatus.Controls.Add(this.lblDateTime, 0, 1);
            this.tlpStatus.Controls.Add(this.lblModel, 0, 2);
            this.tlpStatus.Controls.Add(this.lblProjectInformation, 0, 3);
            this.tlpStatus.Controls.Add(this.pnlExit, 0, 9);
            this.tlpStatus.Controls.Add(this.pnlStart, 0, 8);
            this.tlpStatus.Controls.Add(this.pnlEtcFunction, 0, 7);
            this.tlpStatus.Controls.Add(this.pnlSystemInformation, 0, 5);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(0, 0);
            this.tlpStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 10;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpStatus.Size = new System.Drawing.Size(244, 969);
            this.tlpStatus.TabIndex = 0;
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.Color.DarkGray;
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCamera.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnCamera.Image = global::COG.Properties.Resources.CAMSETTING1;
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCamera.Location = new System.Drawing.Point(0, 534);
            this.btnCamera.Margin = new System.Windows.Forms.Padding(0);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(206, 34);
            this.btnCamera.TabIndex = 78;
            this.btnCamera.Text = "CAMERA";
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Visible = false;
            this.btnCamera.Click += new System.EventHandler(this.BTN_CAMERASET_Click);
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLogo.Image = global::COG.Properties.Resources.SAMSUNG;
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(3, 3);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(238, 44);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 84;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.LogFolderShow_Click);
            // 
            // pnlExit
            // 
            this.pnlExit.Controls.Add(this.btnExit);
            this.pnlExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExit.Location = new System.Drawing.Point(3, 871);
            this.pnlExit.Name = "pnlExit";
            this.pnlExit.Size = new System.Drawing.Size(238, 95);
            this.pnlExit.TabIndex = 230;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = global::COG.Properties.Resources.EXIT;
            this.btnExit.Location = new System.Drawing.Point(0, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(238, 95);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "EXIT  ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BTN_EXIT_Click);
            // 
            // pnlStart
            // 
            this.pnlStart.Controls.Add(this.btnStart);
            this.pnlStart.Controls.Add(this.btnStop);
            this.pnlStart.Location = new System.Drawing.Point(3, 771);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(238, 94);
            this.pnlStart.TabIndex = 229;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkGray;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(238, 94);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "START  ";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BTN_START_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LawnGreen;
            this.btnStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStop.BackgroundImage")));
            this.btnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStop.Location = new System.Drawing.Point(0, 0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(238, 94);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "                            STOP\r\n";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.BTN_STOP_Click);
            // 
            // pnlEtcFunction
            // 
            this.pnlEtcFunction.Controls.Add(this.tlpEtcFunction);
            this.pnlEtcFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEtcFunction.Location = new System.Drawing.Point(3, 571);
            this.pnlEtcFunction.Name = "pnlEtcFunction";
            this.pnlEtcFunction.Size = new System.Drawing.Size(238, 194);
            this.pnlEtcFunction.TabIndex = 228;
            // 
            // tlpEtcFunction
            // 
            this.tlpEtcFunction.ColumnCount = 2;
            this.tlpEtcFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEtcFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEtcFunction.Controls.Add(this.btnCal, 1, 2);
            this.tlpEtcFunction.Controls.Add(this.btnInspectionTestFrom, 1, 4);
            this.tlpEtcFunction.Controls.Add(this.tlpCommunicationStatus, 0, 3);
            this.tlpEtcFunction.Controls.Add(this.tlpButton_VisibleFalse, 1, 3);
            this.tlpEtcFunction.Controls.Add(this.tlpEtcFunction_VisibleFalse, 0, 1);
            this.tlpEtcFunction.Controls.Add(this.BTN_LIGHT_ON, 0, 0);
            this.tlpEtcFunction.Controls.Add(this.button1, 1, 0);
            this.tlpEtcFunction.Controls.Add(this.pnlCPU_Usage, 0, 4);
            this.tlpEtcFunction.Controls.Add(this.BTN_ATTINSP, 0, 2);
            this.tlpEtcFunction.Controls.Add(this.pnlMCCTime, 1, 1);
            this.tlpEtcFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEtcFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpEtcFunction.Name = "tlpEtcFunction";
            this.tlpEtcFunction.RowCount = 5;
            this.tlpEtcFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEtcFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEtcFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEtcFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpEtcFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEtcFunction.Size = new System.Drawing.Size(238, 194);
            this.tlpEtcFunction.TabIndex = 1;
            // 
            // btnCal
            // 
            this.btnCal.BackColor = System.Drawing.Color.DarkGray;
            this.btnCal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCal.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCal.Image = global::COG.Properties.Resources.caldata40;
            this.btnCal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCal.Location = new System.Drawing.Point(119, 67);
            this.btnCal.Margin = new System.Windows.Forms.Padding(0);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(119, 58);
            this.btnCal.TabIndex = 50;
            this.btnCal.Text = "      CAL DATA";
            this.btnCal.UseVisualStyleBackColor = false;
            this.btnCal.Visible = false;
            this.btnCal.Click += new System.EventHandler(this.BTN_CALDIS_Click);
            // 
            // btnInspectionTestFrom
            // 
            this.btnInspectionTestFrom.BackColor = System.Drawing.Color.DarkGray;
            this.btnInspectionTestFrom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInspectionTestFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInspectionTestFrom.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnInspectionTestFrom.Location = new System.Drawing.Point(122, 137);
            this.btnInspectionTestFrom.Name = "btnInspectionTestFrom";
            this.btnInspectionTestFrom.Size = new System.Drawing.Size(113, 54);
            this.btnInspectionTestFrom.TabIndex = 236;
            this.btnInspectionTestFrom.Text = "InspectionTest For Engineer";
            this.btnInspectionTestFrom.UseVisualStyleBackColor = false;
            this.btnInspectionTestFrom.Visible = false;
            this.btnInspectionTestFrom.Click += new System.EventHandler(this.btnInspectionTestFrom_Click);
            // 
            // tlpCommunicationStatus
            // 
            this.tlpCommunicationStatus.ColumnCount = 4;
            this.tlpCommunicationStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCommunicationStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCommunicationStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCommunicationStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCommunicationStatus.Controls.Add(this.pnlPLCStatus, 0, 2);
            this.tlpCommunicationStatus.Controls.Add(this.pnlLight1_Status, 1, 2);
            this.tlpCommunicationStatus.Controls.Add(this.pnlLight2_Status, 2, 2);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera1_Status, 0, 0);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera2_Status, 1, 0);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera3_Status, 2, 0);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera4_Status, 3, 0);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera5_Status, 0, 1);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera6_Status, 1, 1);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera7_Status, 2, 1);
            this.tlpCommunicationStatus.Controls.Add(this.pnlCamera8_Status, 3, 1);
            this.tlpCommunicationStatus.Location = new System.Drawing.Point(0, 125);
            this.tlpCommunicationStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommunicationStatus.Name = "tlpCommunicationStatus";
            this.tlpCommunicationStatus.RowCount = 3;
            this.tlpCommunicationStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCommunicationStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCommunicationStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCommunicationStatus.Size = new System.Drawing.Size(119, 6);
            this.tlpCommunicationStatus.TabIndex = 86;
            this.tlpCommunicationStatus.Visible = false;
            // 
            // pnlPLCStatus
            // 
            this.pnlPLCStatus.Controls.Add(this.picCamera1_Connect);
            this.pnlPLCStatus.Controls.Add(this.picPLC_Connect);
            this.pnlPLCStatus.Controls.Add(this.picPLC_Disconnect);
            this.pnlPLCStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPLCStatus.Location = new System.Drawing.Point(3, 7);
            this.pnlPLCStatus.Name = "pnlPLCStatus";
            this.pnlPLCStatus.Size = new System.Drawing.Size(23, 1);
            this.pnlPLCStatus.TabIndex = 0;
            // 
            // picCamera1_Connect
            // 
            this.picCamera1_Connect.Image = global::COG.Properties.Resources._1;
            this.picCamera1_Connect.Location = new System.Drawing.Point(17, -35);
            this.picCamera1_Connect.Name = "picCamera1_Connect";
            this.picCamera1_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera1_Connect.TabIndex = 13;
            this.picCamera1_Connect.TabStop = false;
            this.picCamera1_Connect.Visible = false;
            // 
            // picPLC_Connect
            // 
            this.picPLC_Connect.Image = global::COG.Properties.Resources.PLC;
            this.picPLC_Connect.Location = new System.Drawing.Point(8, -1);
            this.picPLC_Connect.Name = "picPLC_Connect";
            this.picPLC_Connect.Size = new System.Drawing.Size(52, 52);
            this.picPLC_Connect.TabIndex = 21;
            this.picPLC_Connect.TabStop = false;
            this.picPLC_Connect.Visible = false;
            // 
            // picPLC_Disconnect
            // 
            this.picPLC_Disconnect.Image = global::COG.Properties.Resources.PLCX;
            this.picPLC_Disconnect.Location = new System.Drawing.Point(6, 3);
            this.picPLC_Disconnect.Name = "picPLC_Disconnect";
            this.picPLC_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picPLC_Disconnect.TabIndex = 9;
            this.picPLC_Disconnect.TabStop = false;
            this.picPLC_Disconnect.Visible = false;
            // 
            // pnlLight1_Status
            // 
            this.pnlLight1_Status.Controls.Add(this.picLight1_Connect);
            this.pnlLight1_Status.Controls.Add(this.picLight1_Disconnect);
            this.pnlLight1_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLight1_Status.Location = new System.Drawing.Point(32, 7);
            this.pnlLight1_Status.Name = "pnlLight1_Status";
            this.pnlLight1_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlLight1_Status.TabIndex = 1;
            // 
            // picLight1_Connect
            // 
            this.picLight1_Connect.Image = global::COG.Properties.Resources.L1;
            this.picLight1_Connect.Location = new System.Drawing.Point(0, 0);
            this.picLight1_Connect.Name = "picLight1_Connect";
            this.picLight1_Connect.Size = new System.Drawing.Size(52, 52);
            this.picLight1_Connect.TabIndex = 20;
            this.picLight1_Connect.TabStop = false;
            this.picLight1_Connect.Visible = false;
            // 
            // picLight1_Disconnect
            // 
            this.picLight1_Disconnect.Image = global::COG.Properties.Resources.L1X;
            this.picLight1_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picLight1_Disconnect.Name = "picLight1_Disconnect";
            this.picLight1_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picLight1_Disconnect.TabIndex = 8;
            this.picLight1_Disconnect.TabStop = false;
            this.picLight1_Disconnect.Visible = false;
            // 
            // pnlLight2_Status
            // 
            this.pnlLight2_Status.Controls.Add(this.picLight2_Connect);
            this.pnlLight2_Status.Controls.Add(this.picLight2_Disconnect);
            this.pnlLight2_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLight2_Status.Location = new System.Drawing.Point(61, 7);
            this.pnlLight2_Status.Name = "pnlLight2_Status";
            this.pnlLight2_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlLight2_Status.TabIndex = 2;
            // 
            // picLight2_Connect
            // 
            this.picLight2_Connect.Image = global::COG.Properties.Resources.L2;
            this.picLight2_Connect.Location = new System.Drawing.Point(0, 1);
            this.picLight2_Connect.Name = "picLight2_Connect";
            this.picLight2_Connect.Size = new System.Drawing.Size(52, 52);
            this.picLight2_Connect.TabIndex = 22;
            this.picLight2_Connect.TabStop = false;
            this.picLight2_Connect.Visible = false;
            // 
            // picLight2_Disconnect
            // 
            this.picLight2_Disconnect.Image = global::COG.Properties.Resources.L2X;
            this.picLight2_Disconnect.Location = new System.Drawing.Point(8, 1);
            this.picLight2_Disconnect.Name = "picLight2_Disconnect";
            this.picLight2_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picLight2_Disconnect.TabIndex = 10;
            this.picLight2_Disconnect.TabStop = false;
            this.picLight2_Disconnect.Visible = false;
            // 
            // pnlCamera1_Status
            // 
            this.pnlCamera1_Status.Controls.Add(this.picCamera1_Disconnect);
            this.pnlCamera1_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera1_Status.Location = new System.Drawing.Point(3, 3);
            this.pnlCamera1_Status.Name = "pnlCamera1_Status";
            this.pnlCamera1_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera1_Status.TabIndex = 3;
            // 
            // picCamera1_Disconnect
            // 
            this.picCamera1_Disconnect.Image = global::COG.Properties.Resources._1X;
            this.picCamera1_Disconnect.Location = new System.Drawing.Point(3, 3);
            this.picCamera1_Disconnect.Name = "picCamera1_Disconnect";
            this.picCamera1_Disconnect.Size = new System.Drawing.Size(53, 52);
            this.picCamera1_Disconnect.TabIndex = 1;
            this.picCamera1_Disconnect.TabStop = false;
            this.picCamera1_Disconnect.Visible = false;
            // 
            // pnlCamera2_Status
            // 
            this.pnlCamera2_Status.Controls.Add(this.picCamera2_Connect);
            this.pnlCamera2_Status.Controls.Add(this.picCamera2_Disconnect);
            this.pnlCamera2_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera2_Status.Location = new System.Drawing.Point(32, 3);
            this.pnlCamera2_Status.Name = "pnlCamera2_Status";
            this.pnlCamera2_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera2_Status.TabIndex = 4;
            // 
            // picCamera2_Connect
            // 
            this.picCamera2_Connect.Image = global::COG.Properties.Resources._2;
            this.picCamera2_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera2_Connect.Name = "picCamera2_Connect";
            this.picCamera2_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera2_Connect.TabIndex = 17;
            this.picCamera2_Connect.TabStop = false;
            this.picCamera2_Connect.Visible = false;
            // 
            // picCamera2_Disconnect
            // 
            this.picCamera2_Disconnect.Image = global::COG.Properties.Resources._2X;
            this.picCamera2_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picCamera2_Disconnect.Name = "picCamera2_Disconnect";
            this.picCamera2_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera2_Disconnect.TabIndex = 5;
            this.picCamera2_Disconnect.TabStop = false;
            this.picCamera2_Disconnect.Visible = false;
            // 
            // pnlCamera3_Status
            // 
            this.pnlCamera3_Status.Controls.Add(this.picCamera3_Connect);
            this.pnlCamera3_Status.Controls.Add(this.picCamera3_Disconnect);
            this.pnlCamera3_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera3_Status.Location = new System.Drawing.Point(61, 3);
            this.pnlCamera3_Status.Name = "pnlCamera3_Status";
            this.pnlCamera3_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera3_Status.TabIndex = 5;
            // 
            // picCamera3_Connect
            // 
            this.picCamera3_Connect.Image = global::COG.Properties.Resources._3;
            this.picCamera3_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera3_Connect.Name = "picCamera3_Connect";
            this.picCamera3_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera3_Connect.TabIndex = 12;
            this.picCamera3_Connect.TabStop = false;
            this.picCamera3_Connect.Visible = false;
            // 
            // picCamera3_Disconnect
            // 
            this.picCamera3_Disconnect.Image = global::COG.Properties.Resources._3X;
            this.picCamera3_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picCamera3_Disconnect.Name = "picCamera3_Disconnect";
            this.picCamera3_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera3_Disconnect.TabIndex = 0;
            this.picCamera3_Disconnect.TabStop = false;
            this.picCamera3_Disconnect.Visible = false;
            // 
            // pnlCamera4_Status
            // 
            this.pnlCamera4_Status.Controls.Add(this.picCamera4_Connect);
            this.pnlCamera4_Status.Controls.Add(this.picCamera4_Disconnect);
            this.pnlCamera4_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera4_Status.Location = new System.Drawing.Point(90, 3);
            this.pnlCamera4_Status.Name = "pnlCamera4_Status";
            this.pnlCamera4_Status.Size = new System.Drawing.Size(26, 1);
            this.pnlCamera4_Status.TabIndex = 6;
            // 
            // picCamera4_Connect
            // 
            this.picCamera4_Connect.Image = global::COG.Properties.Resources._4;
            this.picCamera4_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera4_Connect.Name = "picCamera4_Connect";
            this.picCamera4_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera4_Connect.TabIndex = 16;
            this.picCamera4_Connect.TabStop = false;
            this.picCamera4_Connect.Visible = false;
            // 
            // picCamera4_Disconnect
            // 
            this.picCamera4_Disconnect.Image = global::COG.Properties.Resources._4X;
            this.picCamera4_Disconnect.Location = new System.Drawing.Point(10, 0);
            this.picCamera4_Disconnect.Name = "picCamera4_Disconnect";
            this.picCamera4_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera4_Disconnect.TabIndex = 4;
            this.picCamera4_Disconnect.TabStop = false;
            this.picCamera4_Disconnect.Visible = false;
            // 
            // pnlCamera5_Status
            // 
            this.pnlCamera5_Status.Controls.Add(this.picCamera5_Connect);
            this.pnlCamera5_Status.Controls.Add(this.picCamera5_Disconnect);
            this.pnlCamera5_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera5_Status.Location = new System.Drawing.Point(3, 5);
            this.pnlCamera5_Status.Name = "pnlCamera5_Status";
            this.pnlCamera5_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera5_Status.TabIndex = 7;
            // 
            // picCamera5_Connect
            // 
            this.picCamera5_Connect.Image = global::COG.Properties.Resources._5;
            this.picCamera5_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera5_Connect.Name = "picCamera5_Connect";
            this.picCamera5_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera5_Connect.TabIndex = 15;
            this.picCamera5_Connect.TabStop = false;
            this.picCamera5_Connect.Visible = false;
            // 
            // picCamera5_Disconnect
            // 
            this.picCamera5_Disconnect.Image = global::COG.Properties.Resources._5X;
            this.picCamera5_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picCamera5_Disconnect.Name = "picCamera5_Disconnect";
            this.picCamera5_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera5_Disconnect.TabIndex = 3;
            this.picCamera5_Disconnect.TabStop = false;
            this.picCamera5_Disconnect.Visible = false;
            // 
            // pnlCamera6_Status
            // 
            this.pnlCamera6_Status.Controls.Add(this.picCamera6_Connect);
            this.pnlCamera6_Status.Controls.Add(this.picCamera6_Disconnect);
            this.pnlCamera6_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera6_Status.Location = new System.Drawing.Point(32, 5);
            this.pnlCamera6_Status.Name = "pnlCamera6_Status";
            this.pnlCamera6_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera6_Status.TabIndex = 8;
            // 
            // picCamera6_Connect
            // 
            this.picCamera6_Connect.Image = global::COG.Properties.Resources._6;
            this.picCamera6_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera6_Connect.Name = "picCamera6_Connect";
            this.picCamera6_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera6_Connect.TabIndex = 19;
            this.picCamera6_Connect.TabStop = false;
            this.picCamera6_Connect.Visible = false;
            // 
            // picCamera6_Disconnect
            // 
            this.picCamera6_Disconnect.Image = global::COG.Properties.Resources._6X;
            this.picCamera6_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picCamera6_Disconnect.Name = "picCamera6_Disconnect";
            this.picCamera6_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera6_Disconnect.TabIndex = 7;
            this.picCamera6_Disconnect.TabStop = false;
            this.picCamera6_Disconnect.Visible = false;
            // 
            // pnlCamera7_Status
            // 
            this.pnlCamera7_Status.Controls.Add(this.picCamera7_Connect);
            this.pnlCamera7_Status.Controls.Add(this.picCamera7_Disconnect);
            this.pnlCamera7_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera7_Status.Location = new System.Drawing.Point(61, 5);
            this.pnlCamera7_Status.Name = "pnlCamera7_Status";
            this.pnlCamera7_Status.Size = new System.Drawing.Size(23, 1);
            this.pnlCamera7_Status.TabIndex = 9;
            // 
            // picCamera7_Connect
            // 
            this.picCamera7_Connect.Image = global::COG.Properties.Resources._7;
            this.picCamera7_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera7_Connect.Name = "picCamera7_Connect";
            this.picCamera7_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera7_Connect.TabIndex = 14;
            this.picCamera7_Connect.TabStop = false;
            this.picCamera7_Connect.Visible = false;
            // 
            // picCamera7_Disconnect
            // 
            this.picCamera7_Disconnect.Image = global::COG.Properties.Resources._7X;
            this.picCamera7_Disconnect.Location = new System.Drawing.Point(8, 0);
            this.picCamera7_Disconnect.Name = "picCamera7_Disconnect";
            this.picCamera7_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera7_Disconnect.TabIndex = 2;
            this.picCamera7_Disconnect.TabStop = false;
            this.picCamera7_Disconnect.Visible = false;
            // 
            // pnlCamera8_Status
            // 
            this.pnlCamera8_Status.Controls.Add(this.picCamera8_Connect);
            this.pnlCamera8_Status.Controls.Add(this.picCamera8_Disconnect);
            this.pnlCamera8_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCamera8_Status.Location = new System.Drawing.Point(90, 5);
            this.pnlCamera8_Status.Name = "pnlCamera8_Status";
            this.pnlCamera8_Status.Size = new System.Drawing.Size(26, 1);
            this.pnlCamera8_Status.TabIndex = 10;
            // 
            // picCamera8_Connect
            // 
            this.picCamera8_Connect.Image = global::COG.Properties.Resources._8;
            this.picCamera8_Connect.Location = new System.Drawing.Point(0, 0);
            this.picCamera8_Connect.Name = "picCamera8_Connect";
            this.picCamera8_Connect.Size = new System.Drawing.Size(52, 52);
            this.picCamera8_Connect.TabIndex = 18;
            this.picCamera8_Connect.TabStop = false;
            this.picCamera8_Connect.Visible = false;
            // 
            // picCamera8_Disconnect
            // 
            this.picCamera8_Disconnect.Image = global::COG.Properties.Resources._8X;
            this.picCamera8_Disconnect.Location = new System.Drawing.Point(13, 0);
            this.picCamera8_Disconnect.Name = "picCamera8_Disconnect";
            this.picCamera8_Disconnect.Size = new System.Drawing.Size(52, 52);
            this.picCamera8_Disconnect.TabIndex = 6;
            this.picCamera8_Disconnect.TabStop = false;
            this.picCamera8_Disconnect.Visible = false;
            // 
            // tlpButton_VisibleFalse
            // 
            this.tlpButton_VisibleFalse.ColumnCount = 4;
            this.tlpButton_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton_VisibleFalse.Controls.Add(this.btnRCS, 0, 0);
            this.tlpButton_VisibleFalse.Controls.Add(this.BTN_PASSWORD, 1, 0);
            this.tlpButton_VisibleFalse.Controls.Add(this.BTN_LIGHT_INITIAL, 2, 0);
            this.tlpButton_VisibleFalse.Location = new System.Drawing.Point(122, 128);
            this.tlpButton_VisibleFalse.Name = "tlpButton_VisibleFalse";
            this.tlpButton_VisibleFalse.RowCount = 1;
            this.tlpButton_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton_VisibleFalse.Size = new System.Drawing.Size(113, 3);
            this.tlpButton_VisibleFalse.TabIndex = 221;
            this.tlpButton_VisibleFalse.Visible = false;
            // 
            // btnRCS
            // 
            this.btnRCS.BackColor = System.Drawing.Color.DarkGray;
            this.btnRCS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRCS.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnRCS.Image = global::COG.Properties.Resources.Check_1_48;
            this.btnRCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRCS.Location = new System.Drawing.Point(0, 0);
            this.btnRCS.Margin = new System.Windows.Forms.Padding(0);
            this.btnRCS.Name = "btnRCS";
            this.btnRCS.Size = new System.Drawing.Size(28, 3);
            this.btnRCS.TabIndex = 218;
            this.btnRCS.Text = "     RCS";
            this.btnRCS.UseVisualStyleBackColor = false;
            this.btnRCS.Visible = false;
            this.btnRCS.Click += new System.EventHandler(this.BTN_RCS_Click);
            // 
            // BTN_PASSWORD
            // 
            this.BTN_PASSWORD.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_PASSWORD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_PASSWORD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_PASSWORD.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_PASSWORD.Image = global::COG.Properties.Resources.Key;
            this.BTN_PASSWORD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_PASSWORD.Location = new System.Drawing.Point(28, 0);
            this.BTN_PASSWORD.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_PASSWORD.Name = "BTN_PASSWORD";
            this.BTN_PASSWORD.Size = new System.Drawing.Size(28, 3);
            this.BTN_PASSWORD.TabIndex = 211;
            this.BTN_PASSWORD.Text = "PASSWORD";
            this.BTN_PASSWORD.UseVisualStyleBackColor = false;
            this.BTN_PASSWORD.Visible = false;
            this.BTN_PASSWORD.Click += new System.EventHandler(this.BTN_PASSWORD_Click);
            // 
            // tlpEtcFunction_VisibleFalse
            // 
            this.tlpEtcFunction_VisibleFalse.ColumnCount = 3;
            this.tlpEtcFunction_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpEtcFunction_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpEtcFunction_VisibleFalse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_DISNAME_01, 2, 2);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_MXTEST, 2, 4);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.GB_INSPECTION, 0, 3);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.TAB_IMG_DISPLAY, 1, 3);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.txtCommandTest, 1, 4);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_CCLINKTEST, 0, 4);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.btnTest_AddResult, 2, 3);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_LIGHT_PANEL, 1, 0);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_LIGHT_FPC, 2, 0);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.RBTN_TAB_1, 1, 1);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_FIT_IMAGE, 0, 1);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_VISION_RESET, 0, 0);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.RBTN_TAB_2, 2, 1);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_INSPECT_SHOW, 0, 2);
            this.tlpEtcFunction_VisibleFalse.Controls.Add(this.BTN_TRAY_VIEW, 1, 2);
            this.tlpEtcFunction_VisibleFalse.Location = new System.Drawing.Point(3, 61);
            this.tlpEtcFunction_VisibleFalse.Name = "tlpEtcFunction_VisibleFalse";
            this.tlpEtcFunction_VisibleFalse.RowCount = 5;
            this.tlpEtcFunction_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEtcFunction_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEtcFunction_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEtcFunction_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEtcFunction_VisibleFalse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEtcFunction_VisibleFalse.Size = new System.Drawing.Size(113, 1);
            this.tlpEtcFunction_VisibleFalse.TabIndex = 0;
            this.tlpEtcFunction_VisibleFalse.Visible = false;
            // 
            // BTN_ATTINSP
            // 
            this.BTN_ATTINSP.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ATTINSP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_ATTINSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_ATTINSP.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.BTN_ATTINSP.Location = new System.Drawing.Point(3, 70);
            this.BTN_ATTINSP.Name = "BTN_ATTINSP";
            this.BTN_ATTINSP.Size = new System.Drawing.Size(113, 52);
            this.BTN_ATTINSP.TabIndex = 233;
            this.BTN_ATTINSP.Text = "ATT INSPECTION";
            this.BTN_ATTINSP.UseVisualStyleBackColor = false;
            this.BTN_ATTINSP.Click += new System.EventHandler(this.BTN_ATTINSP_Click);
            // 
            // pnlMCCTime
            // 
            this.pnlMCCTime.BackColor = System.Drawing.Color.DarkGray;
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_2);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_TITLE2);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_4);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_TITLE4);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_1);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_3);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_TITLE1);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME_TITLE3);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P6);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P5);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P4);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P3);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P7);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P8);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P1);
            this.pnlMCCTime.Controls.Add(this.LB_NG_COUNT_P2);
            this.pnlMCCTime.Controls.Add(this.LB_POINT_NG_CNT);
            this.pnlMCCTime.Controls.Add(this.LB_PROCTIME);
            this.pnlMCCTime.Location = new System.Drawing.Point(122, 61);
            this.pnlMCCTime.Name = "pnlMCCTime";
            this.pnlMCCTime.Size = new System.Drawing.Size(113, 1);
            this.pnlMCCTime.TabIndex = 237;
            this.pnlMCCTime.Visible = false;
            // 
            // LB_PROCTIME_2
            // 
            this.LB_PROCTIME_2.BackColor = System.Drawing.Color.Silver;
            this.LB_PROCTIME_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_2.Location = new System.Drawing.Point(125, 107);
            this.LB_PROCTIME_2.Name = "LB_PROCTIME_2";
            this.LB_PROCTIME_2.Size = new System.Drawing.Size(110, 25);
            this.LB_PROCTIME_2.TabIndex = 132;
            this.LB_PROCTIME_2.Text = "000 ms";
            this.LB_PROCTIME_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_PROCTIME_TITLE2
            // 
            this.LB_PROCTIME_TITLE2.BackColor = System.Drawing.Color.DarkGray;
            this.LB_PROCTIME_TITLE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_TITLE2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_TITLE2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_TITLE2.Location = new System.Drawing.Point(122, 85);
            this.LB_PROCTIME_TITLE2.Name = "LB_PROCTIME_TITLE2";
            this.LB_PROCTIME_TITLE2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LB_PROCTIME_TITLE2.Size = new System.Drawing.Size(116, 50);
            this.LB_PROCTIME_TITLE2.TabIndex = 146;
            this.LB_PROCTIME_TITLE2.Text = "CAM2";
            this.LB_PROCTIME_TITLE2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LB_PROCTIME_4
            // 
            this.LB_PROCTIME_4.BackColor = System.Drawing.Color.Silver;
            this.LB_PROCTIME_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_4.Location = new System.Drawing.Point(6, 107);
            this.LB_PROCTIME_4.Name = "LB_PROCTIME_4";
            this.LB_PROCTIME_4.Size = new System.Drawing.Size(110, 25);
            this.LB_PROCTIME_4.TabIndex = 133;
            this.LB_PROCTIME_4.Text = "000 ms";
            this.LB_PROCTIME_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_PROCTIME_TITLE4
            // 
            this.LB_PROCTIME_TITLE4.BackColor = System.Drawing.Color.DarkGray;
            this.LB_PROCTIME_TITLE4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_TITLE4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_TITLE4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_TITLE4.Location = new System.Drawing.Point(3, 85);
            this.LB_PROCTIME_TITLE4.Name = "LB_PROCTIME_TITLE4";
            this.LB_PROCTIME_TITLE4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LB_PROCTIME_TITLE4.Size = new System.Drawing.Size(116, 50);
            this.LB_PROCTIME_TITLE4.TabIndex = 145;
            this.LB_PROCTIME_TITLE4.Text = "CAM4";
            this.LB_PROCTIME_TITLE4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LB_PROCTIME_1
            // 
            this.LB_PROCTIME_1.BackColor = System.Drawing.Color.Silver;
            this.LB_PROCTIME_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_1.Location = new System.Drawing.Point(125, 55);
            this.LB_PROCTIME_1.Name = "LB_PROCTIME_1";
            this.LB_PROCTIME_1.Size = new System.Drawing.Size(110, 25);
            this.LB_PROCTIME_1.TabIndex = 131;
            this.LB_PROCTIME_1.Text = "000 ms";
            this.LB_PROCTIME_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_PROCTIME_3
            // 
            this.LB_PROCTIME_3.BackColor = System.Drawing.Color.Silver;
            this.LB_PROCTIME_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_3.Location = new System.Drawing.Point(6, 55);
            this.LB_PROCTIME_3.Name = "LB_PROCTIME_3";
            this.LB_PROCTIME_3.Size = new System.Drawing.Size(110, 25);
            this.LB_PROCTIME_3.TabIndex = 130;
            this.LB_PROCTIME_3.Text = "000 ms";
            this.LB_PROCTIME_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_PROCTIME_TITLE1
            // 
            this.LB_PROCTIME_TITLE1.BackColor = System.Drawing.Color.DarkGray;
            this.LB_PROCTIME_TITLE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_TITLE1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_TITLE1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_TITLE1.Location = new System.Drawing.Point(122, 33);
            this.LB_PROCTIME_TITLE1.Name = "LB_PROCTIME_TITLE1";
            this.LB_PROCTIME_TITLE1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LB_PROCTIME_TITLE1.Size = new System.Drawing.Size(116, 50);
            this.LB_PROCTIME_TITLE1.TabIndex = 144;
            this.LB_PROCTIME_TITLE1.Text = "CAM1";
            this.LB_PROCTIME_TITLE1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LB_PROCTIME_TITLE3
            // 
            this.LB_PROCTIME_TITLE3.BackColor = System.Drawing.Color.DarkGray;
            this.LB_PROCTIME_TITLE3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME_TITLE3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME_TITLE3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME_TITLE3.Location = new System.Drawing.Point(3, 33);
            this.LB_PROCTIME_TITLE3.Name = "LB_PROCTIME_TITLE3";
            this.LB_PROCTIME_TITLE3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.LB_PROCTIME_TITLE3.Size = new System.Drawing.Size(116, 50);
            this.LB_PROCTIME_TITLE3.TabIndex = 143;
            this.LB_PROCTIME_TITLE3.Text = "CAM3";
            this.LB_PROCTIME_TITLE3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LB_NG_COUNT_P6
            // 
            this.LB_NG_COUNT_P6.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P6.Location = new System.Drawing.Point(121, 293);
            this.LB_NG_COUNT_P6.Name = "LB_NG_COUNT_P6";
            this.LB_NG_COUNT_P6.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P6.TabIndex = 142;
            this.LB_NG_COUNT_P6.Text = "P6 : 000000";
            this.LB_NG_COUNT_P6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P6.Visible = false;
            // 
            // LB_NG_COUNT_P5
            // 
            this.LB_NG_COUNT_P5.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P5.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P5.Location = new System.Drawing.Point(0, 293);
            this.LB_NG_COUNT_P5.Name = "LB_NG_COUNT_P5";
            this.LB_NG_COUNT_P5.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P5.TabIndex = 141;
            this.LB_NG_COUNT_P5.Text = "P5 : 000000";
            this.LB_NG_COUNT_P5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P5.Visible = false;
            // 
            // LB_NG_COUNT_P4
            // 
            this.LB_NG_COUNT_P4.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P4.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P4.Location = new System.Drawing.Point(121, 265);
            this.LB_NG_COUNT_P4.Name = "LB_NG_COUNT_P4";
            this.LB_NG_COUNT_P4.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P4.TabIndex = 140;
            this.LB_NG_COUNT_P4.Text = "P4 : 000000";
            this.LB_NG_COUNT_P4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P4.Visible = false;
            // 
            // LB_NG_COUNT_P3
            // 
            this.LB_NG_COUNT_P3.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P3.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P3.Location = new System.Drawing.Point(0, 265);
            this.LB_NG_COUNT_P3.Name = "LB_NG_COUNT_P3";
            this.LB_NG_COUNT_P3.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P3.TabIndex = 139;
            this.LB_NG_COUNT_P3.Text = "P3 : 000000";
            this.LB_NG_COUNT_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P3.Visible = false;
            // 
            // LB_NG_COUNT_P7
            // 
            this.LB_NG_COUNT_P7.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P7.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P7.Location = new System.Drawing.Point(0, 321);
            this.LB_NG_COUNT_P7.Name = "LB_NG_COUNT_P7";
            this.LB_NG_COUNT_P7.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P7.TabIndex = 138;
            this.LB_NG_COUNT_P7.Text = "P7 : 000000";
            this.LB_NG_COUNT_P7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P7.Visible = false;
            // 
            // LB_NG_COUNT_P8
            // 
            this.LB_NG_COUNT_P8.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P8.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P8.Location = new System.Drawing.Point(121, 321);
            this.LB_NG_COUNT_P8.Name = "LB_NG_COUNT_P8";
            this.LB_NG_COUNT_P8.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P8.TabIndex = 137;
            this.LB_NG_COUNT_P8.Text = "P8 : 000000";
            this.LB_NG_COUNT_P8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P8.Visible = false;
            // 
            // LB_NG_COUNT_P1
            // 
            this.LB_NG_COUNT_P1.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P1.Location = new System.Drawing.Point(0, 237);
            this.LB_NG_COUNT_P1.Name = "LB_NG_COUNT_P1";
            this.LB_NG_COUNT_P1.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P1.TabIndex = 136;
            this.LB_NG_COUNT_P1.Text = "P1 : 000000";
            this.LB_NG_COUNT_P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P1.Visible = false;
            // 
            // LB_NG_COUNT_P2
            // 
            this.LB_NG_COUNT_P2.BackColor = System.Drawing.Color.Silver;
            this.LB_NG_COUNT_P2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_NG_COUNT_P2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_NG_COUNT_P2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_NG_COUNT_P2.Location = new System.Drawing.Point(121, 237);
            this.LB_NG_COUNT_P2.Name = "LB_NG_COUNT_P2";
            this.LB_NG_COUNT_P2.Size = new System.Drawing.Size(117, 28);
            this.LB_NG_COUNT_P2.TabIndex = 135;
            this.LB_NG_COUNT_P2.Text = "P2 : 000000";
            this.LB_NG_COUNT_P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_NG_COUNT_P2.Visible = false;
            // 
            // LB_POINT_NG_CNT
            // 
            this.LB_POINT_NG_CNT.BackColor = System.Drawing.Color.Gray;
            this.LB_POINT_NG_CNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_POINT_NG_CNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_POINT_NG_CNT.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_POINT_NG_CNT.Location = new System.Drawing.Point(3, 209);
            this.LB_POINT_NG_CNT.Name = "LB_POINT_NG_CNT";
            this.LB_POINT_NG_CNT.Size = new System.Drawing.Size(235, 28);
            this.LB_POINT_NG_CNT.TabIndex = 134;
            this.LB_POINT_NG_CNT.Text = "POINT NG COUNT";
            this.LB_POINT_NG_CNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_POINT_NG_CNT.Visible = false;
            // 
            // LB_PROCTIME
            // 
            this.LB_PROCTIME.BackColor = System.Drawing.Color.Gray;
            this.LB_PROCTIME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PROCTIME.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_PROCTIME.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_PROCTIME.Location = new System.Drawing.Point(3, 3);
            this.LB_PROCTIME.Name = "LB_PROCTIME";
            this.LB_PROCTIME.Size = new System.Drawing.Size(235, 28);
            this.LB_PROCTIME.TabIndex = 129;
            this.LB_PROCTIME.Text = "MCC TIME (IN - OUT)";
            this.LB_PROCTIME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSystemInformation
            // 
            this.pnlSystemInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystemInformation.Location = new System.Drawing.Point(0, 234);
            this.pnlSystemInformation.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSystemInformation.Name = "pnlSystemInformation";
            this.pnlSystemInformation.Size = new System.Drawing.Size(244, 300);
            this.pnlSystemInformation.TabIndex = 231;
            this.pnlSystemInformation.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1900, 969);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMain);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VISION PROGRAM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TAB_IMG_DISPLAY.ResumeLayout(false);
            this.Tab_Num_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display06)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display08)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display07)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display03)).EndInit();
            this.Tab_Num_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display09)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display11)).EndInit();
            this.Tab_Num_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MA_Display19)).EndInit();
            this.GB_INSPECTION.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pnlCPU_Usage.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            this.tlpFunction.ResumeLayout(false);
            this.tlpButton.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlExit.ResumeLayout(false);
            this.pnlStart.ResumeLayout(false);
            this.pnlEtcFunction.ResumeLayout(false);
            this.tlpEtcFunction.ResumeLayout(false);
            this.tlpCommunicationStatus.ResumeLayout(false);
            this.pnlPLCStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPLC_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPLC_Disconnect)).EndInit();
            this.pnlLight1_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLight1_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLight1_Disconnect)).EndInit();
            this.pnlLight2_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLight2_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLight2_Disconnect)).EndInit();
            this.pnlCamera1_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera1_Disconnect)).EndInit();
            this.pnlCamera2_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera2_Disconnect)).EndInit();
            this.pnlCamera3_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera3_Disconnect)).EndInit();
            this.pnlCamera4_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera4_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera4_Disconnect)).EndInit();
            this.pnlCamera5_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera5_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera5_Disconnect)).EndInit();
            this.pnlCamera6_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera6_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera6_Disconnect)).EndInit();
            this.pnlCamera7_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera7_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera7_Disconnect)).EndInit();
            this.pnlCamera8_Status.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCamera8_Connect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCamera8_Disconnect)).EndInit();
            this.tlpButton_VisibleFalse.ResumeLayout(false);
            this.tlpEtcFunction_VisibleFalse.ResumeLayout(false);
            this.tlpEtcFunction_VisibleFalse.PerformLayout();
            this.pnlMCCTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtCommandTest;
        private System.Windows.Forms.Button btnCommandTest;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRecipe;
        private System.Windows.Forms.Button btnSystem;
        private System.Windows.Forms.Button btnInterface;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Timer timer_Directory;
        private System.Windows.Forms.Button btnCal;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TabControl TAB_IMG_DISPLAY;
        private System.Windows.Forms.TabPage Tab_Num_0;
        private System.Windows.Forms.Button BTN_DISNAME_06;
        private System.Windows.Forms.Button BTN_DISNAME_05;
        private Cognex.VisionPro.CogRecordDisplay MA_Display06;
        private Cognex.VisionPro.CogRecordDisplay MA_Display05;
        private System.Windows.Forms.Button BTN_DISNAME_04;
        private Cognex.VisionPro.CogRecordDisplay MA_Display04;
        private Cognex.VisionPro.CogRecordDisplay MA_Display08;
        private Cognex.VisionPro.CogRecordDisplay MA_Display07;
        private System.Windows.Forms.Button BTN_DISNAME_02;
        private Cognex.VisionPro.CogRecordDisplay MA_Display02;
        private System.Windows.Forms.Button BTN_DISNAME_03;
        private Cognex.VisionPro.CogRecordDisplay MA_Display01;
        private System.Windows.Forms.Button BTN_DISNAME_01;
        private Cognex.VisionPro.CogRecordDisplay MA_Display03;
        private System.Windows.Forms.RadioButton RBTN_TAB_1;
        private System.Windows.Forms.RadioButton RBTN_TAB_2;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button BTN_LIGHT_INITIAL;
        private System.Windows.Forms.Button BTN_INSPECT_SHOW;
        private System.Windows.Forms.GroupBox GB_INSPECTION;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label LB_INSPEC_2_07;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label LB_INSPEC_2_05;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label LB_INSPEC_2_03;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label LB_INSPEC_2_01;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label LB_INSPEC_2_06;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label LB_INSPEC_2_04;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label LB_INSPEC_2_02;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label LB_INSPEC_2_00;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LB_INSPEC_1_07;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LB_INSPEC_1_05;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label LB_INSPEC_1_03;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LB_INSPEC_1_01;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label LB_INSPEC_1_06;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label LB_INSPEC_1_04;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label LB_INSPEC_1_02;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label LB_INSPEC_1_00;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label LB_INSPEC_0_07;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label LB_INSPEC_0_05;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label LB_INSPEC_0_03;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LB_INSPEC_0_01;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LB_INSPEC_0_06;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LB_INSPEC_0_04;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_INSPEC_0_02;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label LB_INSPEC_0_00;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button BTN_DISNAME_08;
        private System.Windows.Forms.Button BTN_DISNAME_07;
        private System.Windows.Forms.Button BTN_PASSWORD;
        private System.Windows.Forms.TabPage Tab_Num_1;
        private System.Windows.Forms.Button BTN_DISNAME_16;
        private System.Windows.Forms.Button BTN_DISNAME_15;
        private System.Windows.Forms.Button BTN_DISNAME_14;
        private System.Windows.Forms.Button BTN_DISNAME_13;
        private Cognex.VisionPro.CogRecordDisplay MA_Display14;
        private Cognex.VisionPro.CogRecordDisplay MA_Display13;
        private Cognex.VisionPro.CogRecordDisplay MA_Display16;
        private Cognex.VisionPro.CogRecordDisplay MA_Display15;
        private System.Windows.Forms.Button BTN_DISNAME_12;
        private System.Windows.Forms.Button BTN_DISNAME_11;
        private System.Windows.Forms.Button BTN_DISNAME_10;
        private System.Windows.Forms.Button BTN_DISNAME_09;
        private Cognex.VisionPro.CogRecordDisplay MA_Display10;
        private Cognex.VisionPro.CogRecordDisplay MA_Display09;
        private Cognex.VisionPro.CogRecordDisplay MA_Display12;
        private Cognex.VisionPro.CogRecordDisplay MA_Display11;
        private System.Windows.Forms.TabPage Tab_Num_2;
        private System.Windows.Forms.Button BTN_DISNAME_24;
        private System.Windows.Forms.Button BTN_DISNAME_23;
        private System.Windows.Forms.Button BTN_DISNAME_22;
        private System.Windows.Forms.Button BTN_DISNAME_21;
        private Cognex.VisionPro.CogRecordDisplay MA_Display22;
        private Cognex.VisionPro.CogRecordDisplay MA_Display21;
        private Cognex.VisionPro.CogRecordDisplay MA_Display24;
        private Cognex.VisionPro.CogRecordDisplay MA_Display23;
        private System.Windows.Forms.Button BTN_DISNAME_20;
        private System.Windows.Forms.Button BTN_DISNAME_19;
        private System.Windows.Forms.Button BTN_DISNAME_18;
        private System.Windows.Forms.Button BTN_DISNAME_17;
        private Cognex.VisionPro.CogRecordDisplay MA_Display18;
        private Cognex.VisionPro.CogRecordDisplay MA_Display17;
        private Cognex.VisionPro.CogRecordDisplay MA_Display20;
        private Cognex.VisionPro.CogRecordDisplay MA_Display19;
        private System.Windows.Forms.Button BTN_LIGHT_PANEL;
        private System.Windows.Forms.Button BTN_LIGHT_FPC;
        private System.Windows.Forms.Button BTN_TRAY_VIEW;
        private System.Windows.Forms.Button BTN_LIGHT_ON;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button BTN_CCLINKTEST;
        private System.Windows.Forms.Button BTN_MXTEST;
        private System.Windows.Forms.Button BTN_FIT_IMAGE;
        private System.Windows.Forms.Panel pnlCPU_Usage;
        private System.Windows.Forms.PictureBox picCamera4_Disconnect;
        private System.Windows.Forms.PictureBox picCamera5_Disconnect;
        private System.Windows.Forms.PictureBox picCamera7_Disconnect;
        private System.Windows.Forms.PictureBox picCamera1_Disconnect;
        private System.Windows.Forms.PictureBox picCamera3_Disconnect;
        private System.Windows.Forms.PictureBox picLight2_Disconnect;
        private System.Windows.Forms.PictureBox picPLC_Disconnect;
        private System.Windows.Forms.PictureBox picLight1_Disconnect;
        private System.Windows.Forms.PictureBox picCamera6_Disconnect;
        private System.Windows.Forms.PictureBox picCamera8_Disconnect;
        private System.Windows.Forms.PictureBox picCamera2_Disconnect;
        private System.Windows.Forms.PictureBox picLight2_Connect;
        private System.Windows.Forms.PictureBox picPLC_Connect;
        private System.Windows.Forms.PictureBox picLight1_Connect;
        private System.Windows.Forms.PictureBox picCamera6_Connect;
        private System.Windows.Forms.PictureBox picCamera8_Connect;
        private System.Windows.Forms.PictureBox picCamera2_Connect;
        private System.Windows.Forms.PictureBox picCamera4_Connect;
        private System.Windows.Forms.PictureBox picCamera5_Connect;
        private System.Windows.Forms.PictureBox picCamera7_Connect;
        private System.Windows.Forms.PictureBox picCamera1_Connect;
        private System.Windows.Forms.PictureBox picCamera3_Connect;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Button btnRCS;
        private System.Windows.Forms.Button BTN_VISION_RESET;
        private System.Windows.Forms.CheckBox CB_LIVE_CHECK_CAM1;
        private System.Windows.Forms.CheckBox CB_LIVE_CHECK_CAM3;
        private System.Windows.Forms.CheckBox CB_LIVE_CHECK_CAM2;
        private System.Windows.Forms.Button BTN_MOTION;
        private System.Windows.Forms.TableLayoutPanel tlpGrabView;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.TableLayoutPanel tlpFunction;
        private System.Windows.Forms.TableLayoutPanel tlpStatus;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.TableLayoutPanel tlpCommunicationStatus;
        private System.Windows.Forms.Panel pnlPLCStatus;
        private System.Windows.Forms.Panel pnlLight1_Status;
        private System.Windows.Forms.Panel pnlLight2_Status;
        private System.Windows.Forms.Panel pnlCamera1_Status;
        private System.Windows.Forms.Panel pnlCamera2_Status;
        private System.Windows.Forms.Panel pnlCamera3_Status;
        private System.Windows.Forms.Panel pnlCamera4_Status;
        private System.Windows.Forms.Panel pnlCamera5_Status;
        private System.Windows.Forms.Panel pnlCamera6_Status;
        private System.Windows.Forms.Panel pnlCamera7_Status;
        private System.Windows.Forms.Panel pnlCamera8_Status;
        private System.Windows.Forms.Panel pnlEtcFunction;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Panel pnlExit;
        private System.Windows.Forms.Button btnTest_AddResult;
        private System.Windows.Forms.Button BTN_ATTINSP;
        private System.Windows.Forms.Button btnFlyingVision;
        private System.Windows.Forms.TableLayoutPanel tlpInformation;
        private System.Windows.Forms.TableLayoutPanel tlpEtcFunction;
        private System.Windows.Forms.TableLayoutPanel tlpEtcFunction_VisibleFalse;
        private System.Windows.Forms.TableLayoutPanel tlpButton_VisibleFalse;
        private System.Windows.Forms.Button btnAuthority;
        private System.Windows.Forms.Panel pnlMCCTime;
        private System.Windows.Forms.Label LB_PROCTIME_2;
        private System.Windows.Forms.Label LB_PROCTIME_TITLE2;
        private System.Windows.Forms.Label LB_PROCTIME_4;
        private System.Windows.Forms.Label LB_PROCTIME_TITLE4;
        private System.Windows.Forms.Label LB_PROCTIME_1;
        private System.Windows.Forms.Label LB_PROCTIME_3;
        private System.Windows.Forms.Label LB_PROCTIME_TITLE1;
        private System.Windows.Forms.Label LB_PROCTIME_TITLE3;
        private System.Windows.Forms.Label LB_NG_COUNT_P6;
        private System.Windows.Forms.Label LB_NG_COUNT_P5;
        private System.Windows.Forms.Label LB_NG_COUNT_P4;
        private System.Windows.Forms.Label LB_NG_COUNT_P3;
        private System.Windows.Forms.Label LB_NG_COUNT_P7;
        private System.Windows.Forms.Label LB_NG_COUNT_P8;
        private System.Windows.Forms.Label LB_NG_COUNT_P1;
        private System.Windows.Forms.Label LB_NG_COUNT_P2;
        private System.Windows.Forms.Label LB_POINT_NG_CNT;
        private System.Windows.Forms.Label LB_PROCTIME;
        private System.Windows.Forms.Panel pnlSystemInformation;
        private System.Windows.Forms.Button btnInspectionTestFrom;
        public System.Windows.Forms.Label lblProjectInformation;
    }
}

