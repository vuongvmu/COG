namespace COG
{
    partial class Form_AkkonTeaching
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AkkonTeaching));
            this.PT_DisplayToolbar01 = new Cognex.VisionPro.CogDisplayToolbarV2();
            this.PT_DisplayStatusBar01 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.TAB_ATT_LIST = new System.Windows.Forms.TabControl();
            this.tabPageROI = new System.Windows.Forms.TabPage();
            this.DG_AKKON_ROI_LIST = new System.Windows.Forms.DataGridView();
            this.COL_00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageResult = new System.Windows.Forms.TabPage();
            this.DG_AKKON_RESULT = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cog_Display_Thumbnail = new Cognex.VisionPro.CogRecordDisplay();
            this.GB_MOVE_ = new System.Windows.Forms.GroupBox();
            this.btn_Size = new System.Windows.Forms.Button();
            this.btn_Move = new System.Windows.Forms.Button();
            this.BTN_ROIORIGN = new System.Windows.Forms.Button();
            this.BTN_ROIMARK = new System.Windows.Forms.Button();
            this.LB_ATT_MOVE_PIXEL_COUNT = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.LB_RECTANGLE = new System.Windows.Forms.Label();
            this.BTN_UP = new System.Windows.Forms.Button();
            this.BTN_DOWN = new System.Windows.Forms.Button();
            this.BTN_LEFT = new System.Windows.Forms.Button();
            this.BTN_ROI_SKEW_ZERO = new System.Windows.Forms.Button();
            this.BTN_RIGHT = new System.Windows.Forms.Button();
            this.BTN_ROI_SKEW_CW = new System.Windows.Forms.Button();
            this.BTN_ROI_SKEW_CCW = new System.Windows.Forms.Button();
            this.panel_Mark = new System.Windows.Forms.Panel();
            this.cogSubDisplay01 = new Cognex.VisionPro.Display.CogDisplay();
            this.label5 = new System.Windows.Forms.Label();
            this.NUD_AngleMin = new System.Windows.Forms.NumericUpDown();
            this.btn_Mark_Complet = new System.Windows.Forms.Button();
            this.btn_MarkTest = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NUD_AngleMax = new System.Windows.Forms.NumericUpDown();
            this.BTN_MARKAPPLY = new System.Windows.Forms.Button();
            this.BTN_MARKDELETE = new System.Windows.Forms.Button();
            this.BTN_MASKING = new System.Windows.Forms.Button();
            this.BTN_SEARCHROI = new System.Windows.Forms.Button();
            this.BTN_SETMARK = new System.Windows.Forms.Button();
            this.BTN_PATTERN = new System.Windows.Forms.Button();
            this.btn_SubMark4 = new System.Windows.Forms.Button();
            this.btn_SubMark3 = new System.Windows.Forms.Button();
            this.btn_SubMark2 = new System.Windows.Forms.Button();
            this.btn_SubMark1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Main_Mark = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_PATTERN_00 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NUD_PAT_SCORE = new System.Windows.Forms.NumericUpDown();
            this.cogSubDisplay05 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogSubDisplay04 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogSubDisplay03 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogSubDisplay02 = new Cognex.VisionPro.Display.CogDisplay();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBTN_AKKON00 = new System.Windows.Forms.Button();
            this.BTN_AKKON_RIGHT_MARK = new System.Windows.Forms.Button();
            this.BTN_AKKON_LEFT_MARK = new System.Windows.Forms.Button();
            this.CB_AKKON_MARK_USE = new System.Windows.Forms.CheckBox();
            this.BTN_AKKON_APPLY = new System.Windows.Forms.Button();
            this.BTN_AKKON_CLEAR_ROI = new System.Windows.Forms.Button();
            this.BTN_AKKON_LOAD_ROI = new System.Windows.Forms.Button();
            this.btn_TabNo = new System.Windows.Forms.Button();
            this.panel_AkkonParam = new System.Windows.Forms.Panel();
            this.lbl_Spec_Count = new System.Windows.Forms.Label();
            this.lb_Spec_Count = new System.Windows.Forms.Label();
            this.lb_Spec_Length = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.LB_ATT_MIN_SZ_FILTER = new System.Windows.Forms.Label();
            this.LB_ATT_MAX_SZ_FILTER = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.LB_ATT_GRP_DIST = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.LB_ATT_STRN_FILTER = new System.Windows.Forms.Label();
            this.LB_ATT_EXTRE_LEAD_DISP = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.LB_ATT_WIDTH_CUT = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.LB_ATT_HEIGHT_CUT = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.LB_ATT_BW_RATIO = new System.Windows.Forms.Label();
            this.panel_MakerParam = new System.Windows.Forms.Panel();
            this.label64 = new System.Windows.Forms.Label();
            this.LB_ATT_THRES_WEIGHT = new System.Windows.Forms.Label();
            this.LB_ATT_PEAK_THRES = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.LB_ATT_STREN_SCALE_FACTOR = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.LB_ATT_SLICE_OVERLAP = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.LB_ATT_STD_DEV = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.CB_ATT_FILTER_TYPE = new System.Windows.Forms.ComboBox();
            this.CB_ATT_INSP_TYPE = new System.Windows.Forms.ComboBox();
            this.label59 = new System.Windows.Forms.Label();
            this.CB_ATT_PANEL_TYPE = new System.Windows.Forms.ComboBox();
            this.CB_ATT_USE_LOG_TRACE = new System.Windows.Forms.CheckBox();
            this.label60 = new System.Windows.Forms.Label();
            this.CB_ATT_TARGET_TYPE = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.CB_ATT_THRES_MODE = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.CB_ATT_SHADOW_DIR = new System.Windows.Forms.ComboBox();
            this.CB_ATT_FILTER_DIR = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.CB_ATT_PEAK_PROP = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.CB_ATT_STREN_BASE = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.panel_Akkon_ROI_Grup = new System.Windows.Forms.Panel();
            this.btn_ROI_Show = new System.Windows.Forms.Button();
            this.btn_list_delete = new System.Windows.Forms.Button();
            this.btn_GropROIApply = new System.Windows.Forms.Button();
            this.BTN_ATT_ROI_COPY = new System.Windows.Forms.Button();
            this.BTN_ATT_ROI_CREATE = new System.Windows.Forms.Button();
            this.CB_ATT_GROUP_NO = new System.Windows.Forms.ComboBox();
            this.LB_ATT_ROI_HEIGHT = new System.Windows.Forms.Label();
            this.LBL_ATT_ROI_HEIGHT = new System.Windows.Forms.Label();
            this.LB_ATT_ROI_WIDTH = new System.Windows.Forms.Label();
            this.LBL_ATT_ROI_WIDTH = new System.Windows.Forms.Label();
            this.BTN_ATT_AUTO_SORT = new System.Windows.Forms.Button();
            this.LBL_ATT_ADJUST = new System.Windows.Forms.Label();
            this.BTN_AKKON_CLONE_VER = new System.Windows.Forms.Button();
            this.LBL_ATT_CLONE_ROI = new System.Windows.Forms.Label();
            this.BTN_ATT_FIRSTLEAD_REGISTER = new System.Windows.Forms.Button();
            this.BTN_AKKON_CLONE_HOR = new System.Windows.Forms.Button();
            this.LBL_ATT_FIRST_LEAD = new System.Windows.Forms.Label();
            this.LB_ATT_LEAD_PITCH = new System.Windows.Forms.Label();
            this.LB_ATT_LEAD_COUNT = new System.Windows.Forms.Label();
            this.LBL_ATT_LEAD_COUNT = new System.Windows.Forms.Label();
            this.LBL_ATT_LEAD_PITCH = new System.Windows.Forms.Label();
            this.LBL_ATT_GROUP_NO = new System.Windows.Forms.Label();
            this.LB_ATT_GROUP_COUNT = new System.Windows.Forms.Label();
            this.LBL_ATT_GROUP_COUNT = new System.Windows.Forms.Label();
            this.BTN_IMAGE_OPEN = new System.Windows.Forms.Button();
            this.BTN_AKKON_GROUP = new System.Windows.Forms.Button();
            this.BTN_AKKON_PARAMETER = new System.Windows.Forms.Button();
            this.btn_Maker_Parm = new System.Windows.Forms.Button();
            this.LB_ShowTodo = new System.Windows.Forms.Label();
            this.BTN_TEST = new System.Windows.Forms.Button();
            this.LB_MESSAGE1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BTN_AKKON_RESULT_IMAGE = new System.Windows.Forms.Button();
            this.BTN_AKKON_ORIGINAL_IMAGE = new System.Windows.Forms.Button();
            this.BTN_AKKON_TEACH_IMAGE = new System.Windows.Forms.Button();
            this.Panel_AlingInsp = new System.Windows.Forms.Panel();
            this.RBTN_ALIGN_TARPOS_PANEL = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_TARPOS_FPC = new System.Windows.Forms.RadioButton();
            this.lab_AlignInsp_Target_Pos = new System.Windows.Forms.Label();
            this.RBTN_ALIGNPOS_Y = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_TEACH_MARK = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_TEACH_EDGE = new System.Windows.Forms.RadioButton();
            this.lab_TeachMode = new System.Windows.Forms.Label();
            this.RBTN_ALIGN_INSPOS_RIGHT = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGNPOS_X = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_INSPOS_LEFT = new System.Windows.Forms.RadioButton();
            this.lab_Insp_Pos = new System.Windows.Forms.Label();
            this.lab_AlingInsp_pos = new System.Windows.Forms.Label();
            this.PANEL_AT_CALIPER = new System.Windows.Forms.Panel();
            this.RBTN_ALIGN_INSPECTION_TEST = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_EDGE_APPLY = new System.Windows.Forms.RadioButton();
            this.RBTN_ALIGN_EDGE_SHOWROI = new System.Windows.Forms.RadioButton();
            this.RBTN_BRIGHT_TO_DARK = new System.Windows.Forms.RadioButton();
            this.RBTN_DARK_TO_BRIGHT = new System.Windows.Forms.RadioButton();
            this.LB_ALIGN_EDGE_THRESHOLD = new System.Windows.Forms.Label();
            this.LB_ALIGN_LEAD_COUNT = new System.Windows.Forms.Label();
            this.CB_ALIGN_ROI_TRACKING = new System.Windows.Forms.CheckBox();
            this.LB_ALIGN_FILTER_SIZE = new System.Windows.Forms.Label();
            this.lab_Edge_Polarty = new System.Windows.Forms.Label();
            this.lab_AlignInspLeadCnt = new System.Windows.Forms.Label();
            this.lab_Filter_Size = new System.Windows.Forms.Label();
            this.lab_EdgeThresHold = new System.Windows.Forms.Label();
            this.BTN_SAVE = new System.Windows.Forms.Button();
            this.BTN_EXIT = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.PT_DISPLAY_CONTROL = new JAS.Controls.Display.Display();
            this.TAB_ATT_LIST.SuspendLayout();
            this.tabPageROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_AKKON_ROI_LIST)).BeginInit();
            this.tabPageResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_AKKON_RESULT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cog_Display_Thumbnail)).BeginInit();
            this.GB_MOVE_.SuspendLayout();
            this.panel_Mark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AngleMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AngleMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PAT_SCORE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay05)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay02)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel_AkkonParam.SuspendLayout();
            this.panel_MakerParam.SuspendLayout();
            this.panel_Akkon_ROI_Grup.SuspendLayout();
            this.Panel_AlingInsp.SuspendLayout();
            this.PANEL_AT_CALIPER.SuspendLayout();
            this.SuspendLayout();
            // 
            // PT_DisplayToolbar01
            // 
            this.PT_DisplayToolbar01.Location = new System.Drawing.Point(2, 3);
            this.PT_DisplayToolbar01.Name = "PT_DisplayToolbar01";
            this.PT_DisplayToolbar01.Size = new System.Drawing.Size(895, 26);
            this.PT_DisplayToolbar01.TabIndex = 35;
            // 
            // PT_DisplayStatusBar01
            // 
            this.PT_DisplayStatusBar01.CoordinateSpaceName = "*\\#";
            this.PT_DisplayStatusBar01.CoordinateSpaceName3D = "*\\#";
            this.PT_DisplayStatusBar01.Location = new System.Drawing.Point(2, 722);
            this.PT_DisplayStatusBar01.Name = "PT_DisplayStatusBar01";
            this.PT_DisplayStatusBar01.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PT_DisplayStatusBar01.Size = new System.Drawing.Size(894, 22);
            this.PT_DisplayStatusBar01.TabIndex = 36;
            this.PT_DisplayStatusBar01.Use3DCoordinateSpaceTree = false;
            // 
            // TAB_ATT_LIST
            // 
            this.TAB_ATT_LIST.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TAB_ATT_LIST.Controls.Add(this.tabPageROI);
            this.TAB_ATT_LIST.Controls.Add(this.tabPageResult);
            this.TAB_ATT_LIST.Location = new System.Drawing.Point(910, 58);
            this.TAB_ATT_LIST.Multiline = true;
            this.TAB_ATT_LIST.Name = "TAB_ATT_LIST";
            this.TAB_ATT_LIST.SelectedIndex = 0;
            this.TAB_ATT_LIST.Size = new System.Drawing.Size(662, 255);
            this.TAB_ATT_LIST.TabIndex = 279;
            // 
            // tabPageROI
            // 
            this.tabPageROI.BackColor = System.Drawing.Color.Silver;
            this.tabPageROI.Controls.Add(this.DG_AKKON_ROI_LIST);
            this.tabPageROI.Location = new System.Drawing.Point(4, 4);
            this.tabPageROI.Name = "tabPageROI";
            this.tabPageROI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageROI.Size = new System.Drawing.Size(654, 229);
            this.tabPageROI.TabIndex = 0;
            this.tabPageROI.Text = "ROI";
            // 
            // DG_AKKON_ROI_LIST
            // 
            this.DG_AKKON_ROI_LIST.AllowUserToAddRows = false;
            this.DG_AKKON_ROI_LIST.AllowUserToDeleteRows = false;
            this.DG_AKKON_ROI_LIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_AKKON_ROI_LIST.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_00,
            this.COL_01,
            this.COL_02,
            this.COL_03,
            this.COL_04});
            this.DG_AKKON_ROI_LIST.Location = new System.Drawing.Point(0, -1);
            this.DG_AKKON_ROI_LIST.Name = "DG_AKKON_ROI_LIST";
            this.DG_AKKON_ROI_LIST.ReadOnly = true;
            this.DG_AKKON_ROI_LIST.RowTemplate.Height = 23;
            this.DG_AKKON_ROI_LIST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_AKKON_ROI_LIST.Size = new System.Drawing.Size(658, 227);
            this.DG_AKKON_ROI_LIST.TabIndex = 0;
            // 
            // COL_00
            // 
            this.COL_00.FillWeight = 110F;
            this.COL_00.HeaderText = "No.";
            this.COL_00.Name = "COL_00";
            this.COL_00.ReadOnly = true;
            this.COL_00.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_00.Width = 70;
            // 
            // COL_01
            // 
            this.COL_01.FillWeight = 140F;
            this.COL_01.HeaderText = "LeftTop";
            this.COL_01.Name = "COL_01";
            this.COL_01.ReadOnly = true;
            this.COL_01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_01.Width = 140;
            // 
            // COL_02
            // 
            this.COL_02.FillWeight = 140F;
            this.COL_02.HeaderText = "RightTop";
            this.COL_02.Name = "COL_02";
            this.COL_02.ReadOnly = true;
            this.COL_02.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_02.Width = 140;
            // 
            // COL_03
            // 
            this.COL_03.FillWeight = 140F;
            this.COL_03.HeaderText = "RightBottom";
            this.COL_03.Name = "COL_03";
            this.COL_03.ReadOnly = true;
            this.COL_03.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_03.Width = 140;
            // 
            // COL_04
            // 
            this.COL_04.FillWeight = 140F;
            this.COL_04.HeaderText = "LeftBottom";
            this.COL_04.Name = "COL_04";
            this.COL_04.ReadOnly = true;
            this.COL_04.Width = 140;
            // 
            // tabPageResult
            // 
            this.tabPageResult.BackColor = System.Drawing.Color.Silver;
            this.tabPageResult.Controls.Add(this.DG_AKKON_RESULT);
            this.tabPageResult.Location = new System.Drawing.Point(4, 4);
            this.tabPageResult.Name = "tabPageResult";
            this.tabPageResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResult.Size = new System.Drawing.Size(654, 229);
            this.tabPageResult.TabIndex = 1;
            this.tabPageResult.Text = "RESULT";
            // 
            // DG_AKKON_RESULT
            // 
            this.DG_AKKON_RESULT.AllowUserToAddRows = false;
            this.DG_AKKON_RESULT.AllowUserToDeleteRows = false;
            this.DG_AKKON_RESULT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_AKKON_RESULT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.DG_AKKON_RESULT.Location = new System.Drawing.Point(2, 2);
            this.DG_AKKON_RESULT.Name = "DG_AKKON_RESULT";
            this.DG_AKKON_RESULT.ReadOnly = true;
            this.DG_AKKON_RESULT.RowTemplate.Height = 23;
            this.DG_AKKON_RESULT.Size = new System.Drawing.Size(649, 222);
            this.DG_AKKON_RESULT.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Length";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Strength";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Judgement";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // cog_Display_Thumbnail
            // 
            this.cog_Display_Thumbnail.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cog_Display_Thumbnail.ColorMapLowerRoiLimit = 0D;
            this.cog_Display_Thumbnail.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cog_Display_Thumbnail.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cog_Display_Thumbnail.ColorMapUpperRoiLimit = 1D;
            this.cog_Display_Thumbnail.DoubleTapZoomCycleLength = 2;
            this.cog_Display_Thumbnail.DoubleTapZoomSensitivity = 2.5D;
            this.cog_Display_Thumbnail.Location = new System.Drawing.Point(0, 650);
            this.cog_Display_Thumbnail.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cog_Display_Thumbnail.MouseWheelSensitivity = 1D;
            this.cog_Display_Thumbnail.Name = "cog_Display_Thumbnail";
            this.cog_Display_Thumbnail.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cog_Display_Thumbnail.OcxState")));
            this.cog_Display_Thumbnail.Size = new System.Drawing.Size(904, 95);
            this.cog_Display_Thumbnail.TabIndex = 280;
            this.cog_Display_Thumbnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cog_Display_Thumbnail_MouseDown);
            this.cog_Display_Thumbnail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cog_Display_Thumbnail_MouseUp);
            this.cog_Display_Thumbnail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cog_Display_Thumbnail_MouseMove);
            // 
            // GB_MOVE_
            // 
            this.GB_MOVE_.Controls.Add(this.btn_Size);
            this.GB_MOVE_.Controls.Add(this.btn_Move);
            this.GB_MOVE_.Controls.Add(this.BTN_ROIORIGN);
            this.GB_MOVE_.Controls.Add(this.BTN_ROIMARK);
            this.GB_MOVE_.Controls.Add(this.LB_ATT_MOVE_PIXEL_COUNT);
            this.GB_MOVE_.Controls.Add(this.label67);
            this.GB_MOVE_.Controls.Add(this.LB_RECTANGLE);
            this.GB_MOVE_.Controls.Add(this.BTN_UP);
            this.GB_MOVE_.Controls.Add(this.BTN_DOWN);
            this.GB_MOVE_.Controls.Add(this.BTN_LEFT);
            this.GB_MOVE_.Controls.Add(this.BTN_ROI_SKEW_ZERO);
            this.GB_MOVE_.Controls.Add(this.BTN_RIGHT);
            this.GB_MOVE_.Controls.Add(this.BTN_ROI_SKEW_CW);
            this.GB_MOVE_.Controls.Add(this.BTN_ROI_SKEW_CCW);
            this.GB_MOVE_.Location = new System.Drawing.Point(41, 165);
            this.GB_MOVE_.Name = "GB_MOVE_";
            this.GB_MOVE_.Size = new System.Drawing.Size(229, 260);
            this.GB_MOVE_.TabIndex = 281;
            this.GB_MOVE_.TabStop = false;
            // 
            // btn_Size
            // 
            this.btn_Size.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Size.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Size.Location = new System.Drawing.Point(160, 72);
            this.btn_Size.Name = "btn_Size";
            this.btn_Size.Size = new System.Drawing.Size(68, 27);
            this.btn_Size.TabIndex = 296;
            this.btn_Size.Tag = "1";
            this.btn_Size.Text = "Size";
            this.btn_Size.UseVisualStyleBackColor = false;
            this.btn_Size.Click += new System.EventHandler(this.btn_ROIMove_Click);
            // 
            // btn_Move
            // 
            this.btn_Move.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Move.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Move.Location = new System.Drawing.Point(15, 71);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(68, 27);
            this.btn_Move.TabIndex = 295;
            this.btn_Move.Tag = "0";
            this.btn_Move.Text = "Move";
            this.btn_Move.UseVisualStyleBackColor = false;
            this.btn_Move.Click += new System.EventHandler(this.btn_ROIMove_Click);
            // 
            // BTN_ROIORIGN
            // 
            this.BTN_ROIORIGN.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ROIORIGN.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ROIORIGN.Location = new System.Drawing.Point(161, 221);
            this.BTN_ROIORIGN.Name = "BTN_ROIORIGN";
            this.BTN_ROIORIGN.Size = new System.Drawing.Size(68, 27);
            this.BTN_ROIORIGN.TabIndex = 294;
            this.BTN_ROIORIGN.Tag = "1";
            this.BTN_ROIORIGN.Text = "Origin";
            this.BTN_ROIORIGN.UseVisualStyleBackColor = false;
            this.BTN_ROIORIGN.Click += new System.EventHandler(this.MarkMoveType);
            // 
            // BTN_ROIMARK
            // 
            this.BTN_ROIMARK.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ROIMARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ROIMARK.Location = new System.Drawing.Point(160, 192);
            this.BTN_ROIMARK.Name = "BTN_ROIMARK";
            this.BTN_ROIMARK.Size = new System.Drawing.Size(68, 27);
            this.BTN_ROIMARK.TabIndex = 282;
            this.BTN_ROIMARK.Tag = "0";
            this.BTN_ROIMARK.Text = "Mark";
            this.BTN_ROIMARK.UseVisualStyleBackColor = false;
            this.BTN_ROIMARK.Click += new System.EventHandler(this.MarkMoveType);
            // 
            // LB_ATT_MOVE_PIXEL_COUNT
            // 
            this.LB_ATT_MOVE_PIXEL_COUNT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_MOVE_PIXEL_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_MOVE_PIXEL_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_MOVE_PIXEL_COUNT.Location = new System.Drawing.Point(6, 220);
            this.LB_ATT_MOVE_PIXEL_COUNT.Name = "LB_ATT_MOVE_PIXEL_COUNT";
            this.LB_ATT_MOVE_PIXEL_COUNT.Size = new System.Drawing.Size(75, 36);
            this.LB_ATT_MOVE_PIXEL_COUNT.TabIndex = 293;
            this.LB_ATT_MOVE_PIXEL_COUNT.Text = "1";
            this.LB_ATT_MOVE_PIXEL_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_MOVE_PIXEL_COUNT.Click += new System.EventHandler(this.LB_ATT_MOVE_PIXEL_COUNT_Click_1);
            // 
            // label67
            // 
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label67.Location = new System.Drawing.Point(6, 183);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(75, 36);
            this.label67.TabIndex = 292;
            this.label67.Text = "Move Pixel ";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_RECTANGLE
            // 
            this.LB_RECTANGLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_RECTANGLE.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_RECTANGLE.Image = ((System.Drawing.Image)(resources.GetObject("LB_RECTANGLE.Image")));
            this.LB_RECTANGLE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LB_RECTANGLE.Location = new System.Drawing.Point(85, 122);
            this.LB_RECTANGLE.Name = "LB_RECTANGLE";
            this.LB_RECTANGLE.Size = new System.Drawing.Size(73, 66);
            this.LB_RECTANGLE.TabIndex = 133;
            this.LB_RECTANGLE.Text = "MOVE";
            this.LB_RECTANGLE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BTN_UP
            // 
            this.BTN_UP.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_UP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_UP.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_UP.Location = new System.Drawing.Point(85, 71);
            this.BTN_UP.Name = "BTN_UP";
            this.BTN_UP.Size = new System.Drawing.Size(73, 51);
            this.BTN_UP.TabIndex = 132;
            this.BTN_UP.Tag = "0";
            this.BTN_UP.Text = "Up";
            this.BTN_UP.UseVisualStyleBackColor = false;
            this.BTN_UP.Click += new System.EventHandler(this.ROI_JogMove_Click);
            // 
            // BTN_DOWN
            // 
            this.BTN_DOWN.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_DOWN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_DOWN.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_DOWN.Location = new System.Drawing.Point(85, 188);
            this.BTN_DOWN.Name = "BTN_DOWN";
            this.BTN_DOWN.Size = new System.Drawing.Size(73, 51);
            this.BTN_DOWN.TabIndex = 131;
            this.BTN_DOWN.Tag = "1";
            this.BTN_DOWN.Text = "Down";
            this.BTN_DOWN.UseVisualStyleBackColor = false;
            this.BTN_DOWN.Click += new System.EventHandler(this.ROI_JogMove_Click);
            // 
            // BTN_LEFT
            // 
            this.BTN_LEFT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_LEFT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_LEFT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_LEFT.Location = new System.Drawing.Point(12, 126);
            this.BTN_LEFT.Name = "BTN_LEFT";
            this.BTN_LEFT.Size = new System.Drawing.Size(73, 51);
            this.BTN_LEFT.TabIndex = 130;
            this.BTN_LEFT.Tag = "2";
            this.BTN_LEFT.Text = "Left";
            this.BTN_LEFT.UseVisualStyleBackColor = false;
            this.BTN_LEFT.Click += new System.EventHandler(this.ROI_JogMove_Click);
            // 
            // BTN_ROI_SKEW_ZERO
            // 
            this.BTN_ROI_SKEW_ZERO.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ROI_SKEW_ZERO.Font = new System.Drawing.Font("맑은 고딕", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ROI_SKEW_ZERO.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ROI_SKEW_ZERO.Image")));
            this.BTN_ROI_SKEW_ZERO.Location = new System.Drawing.Point(95, 16);
            this.BTN_ROI_SKEW_ZERO.Name = "BTN_ROI_SKEW_ZERO";
            this.BTN_ROI_SKEW_ZERO.Size = new System.Drawing.Size(50, 50);
            this.BTN_ROI_SKEW_ZERO.TabIndex = 184;
            this.BTN_ROI_SKEW_ZERO.Tag = "1";
            this.BTN_ROI_SKEW_ZERO.UseVisualStyleBackColor = false;
            this.BTN_ROI_SKEW_ZERO.Click += new System.EventHandler(this.Akkon_ROI_Theta_Jog);
            // 
            // BTN_RIGHT
            // 
            this.BTN_RIGHT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_RIGHT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_RIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_RIGHT.Location = new System.Drawing.Point(158, 126);
            this.BTN_RIGHT.Name = "BTN_RIGHT";
            this.BTN_RIGHT.Size = new System.Drawing.Size(73, 51);
            this.BTN_RIGHT.TabIndex = 129;
            this.BTN_RIGHT.Tag = "3";
            this.BTN_RIGHT.Text = "Right";
            this.BTN_RIGHT.UseVisualStyleBackColor = false;
            this.BTN_RIGHT.Click += new System.EventHandler(this.ROI_JogMove_Click);
            // 
            // BTN_ROI_SKEW_CW
            // 
            this.BTN_ROI_SKEW_CW.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ROI_SKEW_CW.Font = new System.Drawing.Font("맑은 고딕", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ROI_SKEW_CW.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ROI_SKEW_CW.Image")));
            this.BTN_ROI_SKEW_CW.Location = new System.Drawing.Point(172, 16);
            this.BTN_ROI_SKEW_CW.Name = "BTN_ROI_SKEW_CW";
            this.BTN_ROI_SKEW_CW.Size = new System.Drawing.Size(50, 50);
            this.BTN_ROI_SKEW_CW.TabIndex = 183;
            this.BTN_ROI_SKEW_CW.Tag = "2";
            this.BTN_ROI_SKEW_CW.UseVisualStyleBackColor = false;
            this.BTN_ROI_SKEW_CW.Click += new System.EventHandler(this.Akkon_ROI_Theta_Jog);
            // 
            // BTN_ROI_SKEW_CCW
            // 
            this.BTN_ROI_SKEW_CCW.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ROI_SKEW_CCW.Font = new System.Drawing.Font("맑은 고딕", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ROI_SKEW_CCW.Image = ((System.Drawing.Image)(resources.GetObject("BTN_ROI_SKEW_CCW.Image")));
            this.BTN_ROI_SKEW_CCW.Location = new System.Drawing.Point(6, 16);
            this.BTN_ROI_SKEW_CCW.Name = "BTN_ROI_SKEW_CCW";
            this.BTN_ROI_SKEW_CCW.Size = new System.Drawing.Size(50, 50);
            this.BTN_ROI_SKEW_CCW.TabIndex = 182;
            this.BTN_ROI_SKEW_CCW.Tag = "0";
            this.BTN_ROI_SKEW_CCW.UseVisualStyleBackColor = false;
            this.BTN_ROI_SKEW_CCW.Click += new System.EventHandler(this.Akkon_ROI_Theta_Jog);
            // 
            // panel_Mark
            // 
            this.panel_Mark.Controls.Add(this.cogSubDisplay01);
            this.panel_Mark.Controls.Add(this.label5);
            this.panel_Mark.Controls.Add(this.NUD_AngleMin);
            this.panel_Mark.Controls.Add(this.btn_Mark_Complet);
            this.panel_Mark.Controls.Add(this.btn_MarkTest);
            this.panel_Mark.Controls.Add(this.label4);
            this.panel_Mark.Controls.Add(this.NUD_AngleMax);
            this.panel_Mark.Controls.Add(this.BTN_MARKAPPLY);
            this.panel_Mark.Controls.Add(this.BTN_MARKDELETE);
            this.panel_Mark.Controls.Add(this.BTN_MASKING);
            this.panel_Mark.Controls.Add(this.BTN_SEARCHROI);
            this.panel_Mark.Controls.Add(this.BTN_SETMARK);
            this.panel_Mark.Controls.Add(this.BTN_PATTERN);
            this.panel_Mark.Controls.Add(this.btn_SubMark4);
            this.panel_Mark.Controls.Add(this.btn_SubMark3);
            this.panel_Mark.Controls.Add(this.btn_SubMark2);
            this.panel_Mark.Controls.Add(this.btn_SubMark1);
            this.panel_Mark.Controls.Add(this.label2);
            this.panel_Mark.Controls.Add(this.btn_Main_Mark);
            this.panel_Mark.Controls.Add(this.label1);
            this.panel_Mark.Controls.Add(this.LB_PATTERN_00);
            this.panel_Mark.Controls.Add(this.label3);
            this.panel_Mark.Controls.Add(this.NUD_PAT_SCORE);
            this.panel_Mark.Controls.Add(this.cogSubDisplay05);
            this.panel_Mark.Controls.Add(this.cogSubDisplay04);
            this.panel_Mark.Controls.Add(this.cogSubDisplay03);
            this.panel_Mark.Controls.Add(this.cogSubDisplay02);
            this.panel_Mark.Location = new System.Drawing.Point(909, 146);
            this.panel_Mark.Name = "panel_Mark";
            this.panel_Mark.Size = new System.Drawing.Size(668, 285);
            this.panel_Mark.TabIndex = 282;
            // 
            // cogSubDisplay01
            // 
            this.cogSubDisplay01.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay01.ColorMapLowerRoiLimit = 0D;
            this.cogSubDisplay01.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogSubDisplay01.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay01.ColorMapUpperRoiLimit = 1D;
            this.cogSubDisplay01.DoubleTapZoomCycleLength = 2;
            this.cogSubDisplay01.DoubleTapZoomSensitivity = 2.5D;
            this.cogSubDisplay01.Location = new System.Drawing.Point(230, 31);
            this.cogSubDisplay01.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogSubDisplay01.MouseWheelSensitivity = 1D;
            this.cogSubDisplay01.Name = "cogSubDisplay01";
            this.cogSubDisplay01.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogSubDisplay01.OcxState")));
            this.cogSubDisplay01.Size = new System.Drawing.Size(193, 160);
            this.cogSubDisplay01.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(226, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 31);
            this.label5.TabIndex = 198;
            this.label5.Text = "Angle Min";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_AngleMin
            // 
            this.NUD_AngleMin.DecimalPlaces = 2;
            this.NUD_AngleMin.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NUD_AngleMin.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUD_AngleMin.Location = new System.Drawing.Point(300, 245);
            this.NUD_AngleMin.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUD_AngleMin.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.NUD_AngleMin.Name = "NUD_AngleMin";
            this.NUD_AngleMin.Size = new System.Drawing.Size(56, 27);
            this.NUD_AngleMin.TabIndex = 197;
            this.NUD_AngleMin.Tag = "1";
            this.NUD_AngleMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Mark_Complet
            // 
            this.btn_Mark_Complet.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Mark_Complet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Mark_Complet.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Mark_Complet.Location = new System.Drawing.Point(528, 207);
            this.btn_Mark_Complet.Name = "btn_Mark_Complet";
            this.btn_Mark_Complet.Size = new System.Drawing.Size(129, 67);
            this.btn_Mark_Complet.TabIndex = 196;
            this.btn_Mark_Complet.Text = "Complete";
            this.btn_Mark_Complet.UseVisualStyleBackColor = false;
            this.btn_Mark_Complet.Click += new System.EventHandler(this.btn_Mark_Complet_Click);
            // 
            // btn_MarkTest
            // 
            this.btn_MarkTest.BackColor = System.Drawing.Color.DarkGray;
            this.btn_MarkTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_MarkTest.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MarkTest.Location = new System.Drawing.Point(371, 207);
            this.btn_MarkTest.Name = "btn_MarkTest";
            this.btn_MarkTest.Size = new System.Drawing.Size(129, 67);
            this.btn_MarkTest.TabIndex = 195;
            this.btn_MarkTest.Text = "Mark Test";
            this.btn_MarkTest.UseVisualStyleBackColor = false;
            this.btn_MarkTest.Click += new System.EventHandler(this.btn_MarkTest_Click_1);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(226, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 31);
            this.label4.TabIndex = 194;
            this.label4.Text = "Angle Max";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_AngleMax
            // 
            this.NUD_AngleMax.DecimalPlaces = 2;
            this.NUD_AngleMax.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NUD_AngleMax.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NUD_AngleMax.Location = new System.Drawing.Point(300, 209);
            this.NUD_AngleMax.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.NUD_AngleMax.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.NUD_AngleMax.Name = "NUD_AngleMax";
            this.NUD_AngleMax.Size = new System.Drawing.Size(56, 27);
            this.NUD_AngleMax.TabIndex = 193;
            this.NUD_AngleMax.Tag = "0";
            this.NUD_AngleMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_AngleMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BTN_MARKAPPLY
            // 
            this.BTN_MARKAPPLY.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MARKAPPLY.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MARKAPPLY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MARKAPPLY.Location = new System.Drawing.Point(7, 201);
            this.BTN_MARKAPPLY.Name = "BTN_MARKAPPLY";
            this.BTN_MARKAPPLY.Size = new System.Drawing.Size(106, 34);
            this.BTN_MARKAPPLY.TabIndex = 192;
            this.BTN_MARKAPPLY.Text = "Apply";
            this.BTN_MARKAPPLY.UseVisualStyleBackColor = false;
            this.BTN_MARKAPPLY.Click += new System.EventHandler(this.BTN_MARKAPPLY_Click);
            // 
            // BTN_MARKDELETE
            // 
            this.BTN_MARKDELETE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MARKDELETE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MARKDELETE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MARKDELETE.Location = new System.Drawing.Point(7, 240);
            this.BTN_MARKDELETE.Name = "BTN_MARKDELETE";
            this.BTN_MARKDELETE.Size = new System.Drawing.Size(106, 34);
            this.BTN_MARKDELETE.TabIndex = 191;
            this.BTN_MARKDELETE.Text = "Delete";
            this.BTN_MARKDELETE.UseVisualStyleBackColor = false;
            this.BTN_MARKDELETE.Click += new System.EventHandler(this.BTN_MARKDELETE_Click);
            // 
            // BTN_MASKING
            // 
            this.BTN_MASKING.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MASKING.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MASKING.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MASKING.Location = new System.Drawing.Point(7, 161);
            this.BTN_MASKING.Name = "BTN_MASKING";
            this.BTN_MASKING.Size = new System.Drawing.Size(106, 34);
            this.BTN_MASKING.TabIndex = 190;
            this.BTN_MASKING.Text = "Masking";
            this.BTN_MASKING.UseVisualStyleBackColor = false;
            this.BTN_MASKING.Click += new System.EventHandler(this.BTN_MASKING_Click);
            // 
            // BTN_SEARCHROI
            // 
            this.BTN_SEARCHROI.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_SEARCHROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_SEARCHROI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SEARCHROI.Location = new System.Drawing.Point(113, 161);
            this.BTN_SEARCHROI.Name = "BTN_SEARCHROI";
            this.BTN_SEARCHROI.Size = new System.Drawing.Size(106, 34);
            this.BTN_SEARCHROI.TabIndex = 189;
            this.BTN_SEARCHROI.Text = "Search ROI";
            this.BTN_SEARCHROI.UseVisualStyleBackColor = false;
            this.BTN_SEARCHROI.Click += new System.EventHandler(this.BTN_SEARCHROI_Click);
            // 
            // BTN_SETMARK
            // 
            this.BTN_SETMARK.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_SETMARK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_SETMARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SETMARK.Location = new System.Drawing.Point(113, 129);
            this.BTN_SETMARK.Name = "BTN_SETMARK";
            this.BTN_SETMARK.Size = new System.Drawing.Size(106, 34);
            this.BTN_SETMARK.TabIndex = 188;
            this.BTN_SETMARK.Text = "Set Mark";
            this.BTN_SETMARK.UseVisualStyleBackColor = false;
            this.BTN_SETMARK.Click += new System.EventHandler(this.BTN_SETMARK_Click);
            // 
            // BTN_PATTERN
            // 
            this.BTN_PATTERN.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_PATTERN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_PATTERN.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_PATTERN.Location = new System.Drawing.Point(7, 129);
            this.BTN_PATTERN.Name = "BTN_PATTERN";
            this.BTN_PATTERN.Size = new System.Drawing.Size(106, 34);
            this.BTN_PATTERN.TabIndex = 187;
            this.BTN_PATTERN.Text = "MARK ROI";
            this.BTN_PATTERN.UseVisualStyleBackColor = false;
            this.BTN_PATTERN.Click += new System.EventHandler(this.BTN_PATTERN_Click);
            // 
            // btn_SubMark4
            // 
            this.btn_SubMark4.BackColor = System.Drawing.Color.DarkGray;
            this.btn_SubMark4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SubMark4.Location = new System.Drawing.Point(160, 78);
            this.btn_SubMark4.Name = "btn_SubMark4";
            this.btn_SubMark4.Size = new System.Drawing.Size(60, 45);
            this.btn_SubMark4.TabIndex = 186;
            this.btn_SubMark4.Tag = "4";
            this.btn_SubMark4.Text = "5";
            this.btn_SubMark4.UseVisualStyleBackColor = false;
            this.btn_SubMark4.Click += new System.EventHandler(this.MarkIndex_Click);
            // 
            // btn_SubMark3
            // 
            this.btn_SubMark3.BackColor = System.Drawing.Color.DarkGray;
            this.btn_SubMark3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SubMark3.Location = new System.Drawing.Point(99, 78);
            this.btn_SubMark3.Name = "btn_SubMark3";
            this.btn_SubMark3.Size = new System.Drawing.Size(60, 45);
            this.btn_SubMark3.TabIndex = 185;
            this.btn_SubMark3.Tag = "3";
            this.btn_SubMark3.Text = "4";
            this.btn_SubMark3.UseVisualStyleBackColor = false;
            this.btn_SubMark3.Click += new System.EventHandler(this.MarkIndex_Click);
            // 
            // btn_SubMark2
            // 
            this.btn_SubMark2.BackColor = System.Drawing.Color.DarkGray;
            this.btn_SubMark2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SubMark2.Location = new System.Drawing.Point(160, 34);
            this.btn_SubMark2.Name = "btn_SubMark2";
            this.btn_SubMark2.Size = new System.Drawing.Size(60, 45);
            this.btn_SubMark2.TabIndex = 184;
            this.btn_SubMark2.Tag = "2";
            this.btn_SubMark2.Text = "3";
            this.btn_SubMark2.UseVisualStyleBackColor = false;
            this.btn_SubMark2.Click += new System.EventHandler(this.MarkIndex_Click);
            // 
            // btn_SubMark1
            // 
            this.btn_SubMark1.BackColor = System.Drawing.Color.DarkGray;
            this.btn_SubMark1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_SubMark1.Location = new System.Drawing.Point(99, 33);
            this.btn_SubMark1.Name = "btn_SubMark1";
            this.btn_SubMark1.Size = new System.Drawing.Size(60, 45);
            this.btn_SubMark1.TabIndex = 183;
            this.btn_SubMark1.Tag = "1";
            this.btn_SubMark1.Text = "2";
            this.btn_SubMark1.UseVisualStyleBackColor = false;
            this.btn_SubMark1.Click += new System.EventHandler(this.MarkIndex_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(7, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 25);
            this.label2.TabIndex = 182;
            this.label2.Text = "Mark Index";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Main_Mark
            // 
            this.btn_Main_Mark.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Main_Mark.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Main_Mark.Location = new System.Drawing.Point(7, 32);
            this.btn_Main_Mark.Name = "btn_Main_Mark";
            this.btn_Main_Mark.Size = new System.Drawing.Size(91, 91);
            this.btn_Main_Mark.TabIndex = 181;
            this.btn_Main_Mark.Tag = "0";
            this.btn_Main_Mark.Text = "Main";
            this.btn_Main_Mark.UseVisualStyleBackColor = false;
            this.btn_Main_Mark.Click += new System.EventHandler(this.MarkIndex_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(429, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 120;
            this.label1.Text = "Sub Mark";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_PATTERN_00
            // 
            this.LB_PATTERN_00.BackColor = System.Drawing.Color.Black;
            this.LB_PATTERN_00.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_PATTERN_00.ForeColor = System.Drawing.SystemColors.Control;
            this.LB_PATTERN_00.Location = new System.Drawing.Point(230, 4);
            this.LB_PATTERN_00.Name = "LB_PATTERN_00";
            this.LB_PATTERN_00.Size = new System.Drawing.Size(193, 25);
            this.LB_PATTERN_00.TabIndex = 119;
            this.LB_PATTERN_00.Text = "MAIN Mark";
            this.LB_PATTERN_00.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(114, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 31);
            this.label3.TabIndex = 61;
            this.label3.Text = " SCORE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NUD_PAT_SCORE
            // 
            this.NUD_PAT_SCORE.DecimalPlaces = 1;
            this.NUD_PAT_SCORE.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.NUD_PAT_SCORE.Location = new System.Drawing.Point(164, 207);
            this.NUD_PAT_SCORE.Name = "NUD_PAT_SCORE";
            this.NUD_PAT_SCORE.Size = new System.Drawing.Size(56, 27);
            this.NUD_PAT_SCORE.TabIndex = 60;
            this.NUD_PAT_SCORE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NUD_PAT_SCORE.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.NUD_PAT_SCORE.ValueChanged += new System.EventHandler(this.NUD_PAT_SCORE_ValueChanged);
            // 
            // cogSubDisplay05
            // 
            this.cogSubDisplay05.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay05.ColorMapLowerRoiLimit = 0D;
            this.cogSubDisplay05.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogSubDisplay05.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay05.ColorMapUpperRoiLimit = 1D;
            this.cogSubDisplay05.DoubleTapZoomCycleLength = 2;
            this.cogSubDisplay05.DoubleTapZoomSensitivity = 2.5D;
            this.cogSubDisplay05.Location = new System.Drawing.Point(546, 114);
            this.cogSubDisplay05.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogSubDisplay05.MouseWheelSensitivity = 1D;
            this.cogSubDisplay05.Name = "cogSubDisplay05";
            this.cogSubDisplay05.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogSubDisplay05.OcxState")));
            this.cogSubDisplay05.Size = new System.Drawing.Size(111, 77);
            this.cogSubDisplay05.TabIndex = 4;
            // 
            // cogSubDisplay04
            // 
            this.cogSubDisplay04.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay04.ColorMapLowerRoiLimit = 0D;
            this.cogSubDisplay04.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogSubDisplay04.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay04.ColorMapUpperRoiLimit = 1D;
            this.cogSubDisplay04.DoubleTapZoomCycleLength = 2;
            this.cogSubDisplay04.DoubleTapZoomSensitivity = 2.5D;
            this.cogSubDisplay04.Location = new System.Drawing.Point(429, 114);
            this.cogSubDisplay04.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogSubDisplay04.MouseWheelSensitivity = 1D;
            this.cogSubDisplay04.Name = "cogSubDisplay04";
            this.cogSubDisplay04.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogSubDisplay04.OcxState")));
            this.cogSubDisplay04.Size = new System.Drawing.Size(111, 77);
            this.cogSubDisplay04.TabIndex = 3;
            // 
            // cogSubDisplay03
            // 
            this.cogSubDisplay03.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay03.ColorMapLowerRoiLimit = 0D;
            this.cogSubDisplay03.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogSubDisplay03.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay03.ColorMapUpperRoiLimit = 1D;
            this.cogSubDisplay03.DoubleTapZoomCycleLength = 2;
            this.cogSubDisplay03.DoubleTapZoomSensitivity = 2.5D;
            this.cogSubDisplay03.Location = new System.Drawing.Point(546, 31);
            this.cogSubDisplay03.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogSubDisplay03.MouseWheelSensitivity = 1D;
            this.cogSubDisplay03.Name = "cogSubDisplay03";
            this.cogSubDisplay03.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogSubDisplay03.OcxState")));
            this.cogSubDisplay03.Size = new System.Drawing.Size(111, 77);
            this.cogSubDisplay03.TabIndex = 2;
            // 
            // cogSubDisplay02
            // 
            this.cogSubDisplay02.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay02.ColorMapLowerRoiLimit = 0D;
            this.cogSubDisplay02.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogSubDisplay02.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogSubDisplay02.ColorMapUpperRoiLimit = 1D;
            this.cogSubDisplay02.DoubleTapZoomCycleLength = 2;
            this.cogSubDisplay02.DoubleTapZoomSensitivity = 2.5D;
            this.cogSubDisplay02.Location = new System.Drawing.Point(429, 31);
            this.cogSubDisplay02.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogSubDisplay02.MouseWheelSensitivity = 1D;
            this.cogSubDisplay02.Name = "cogSubDisplay02";
            this.cogSubDisplay02.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogSubDisplay02.OcxState")));
            this.cogSubDisplay02.Size = new System.Drawing.Size(111, 77);
            this.cogSubDisplay02.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RBTN_AKKON00);
            this.panel1.Controls.Add(this.BTN_AKKON_RIGHT_MARK);
            this.panel1.Controls.Add(this.BTN_AKKON_LEFT_MARK);
            this.panel1.Controls.Add(this.CB_AKKON_MARK_USE);
            this.panel1.Controls.Add(this.BTN_AKKON_APPLY);
            this.panel1.Controls.Add(this.BTN_AKKON_CLEAR_ROI);
            this.panel1.Controls.Add(this.BTN_AKKON_LOAD_ROI);
            this.panel1.Controls.Add(this.GB_MOVE_);
            this.panel1.Location = new System.Drawing.Point(1578, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 431);
            this.panel1.TabIndex = 283;
            // 
            // RBTN_AKKON00
            // 
            this.RBTN_AKKON00.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_AKKON00.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_AKKON00.Location = new System.Drawing.Point(5, 59);
            this.RBTN_AKKON00.Name = "RBTN_AKKON00";
            this.RBTN_AKKON00.Size = new System.Drawing.Size(228, 50);
            this.RBTN_AKKON00.TabIndex = 282;
            this.RBTN_AKKON00.Tag = "2";
            this.RBTN_AKKON00.Text = "Akkon";
            this.RBTN_AKKON00.UseVisualStyleBackColor = false;
            this.RBTN_AKKON00.Click += new System.EventHandler(this.SelectROIType_Click);
            // 
            // BTN_AKKON_RIGHT_MARK
            // 
            this.BTN_AKKON_RIGHT_MARK.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_RIGHT_MARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_RIGHT_MARK.Location = new System.Drawing.Point(164, 5);
            this.BTN_AKKON_RIGHT_MARK.Name = "BTN_AKKON_RIGHT_MARK";
            this.BTN_AKKON_RIGHT_MARK.Size = new System.Drawing.Size(143, 50);
            this.BTN_AKKON_RIGHT_MARK.TabIndex = 190;
            this.BTN_AKKON_RIGHT_MARK.Tag = "1";
            this.BTN_AKKON_RIGHT_MARK.Text = "RIGHT MARK";
            this.BTN_AKKON_RIGHT_MARK.UseVisualStyleBackColor = false;
            this.BTN_AKKON_RIGHT_MARK.Click += new System.EventHandler(this.SelectROIType_Click);
            // 
            // BTN_AKKON_LEFT_MARK
            // 
            this.BTN_AKKON_LEFT_MARK.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_LEFT_MARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_LEFT_MARK.Location = new System.Drawing.Point(3, 4);
            this.BTN_AKKON_LEFT_MARK.Name = "BTN_AKKON_LEFT_MARK";
            this.BTN_AKKON_LEFT_MARK.Size = new System.Drawing.Size(155, 50);
            this.BTN_AKKON_LEFT_MARK.TabIndex = 189;
            this.BTN_AKKON_LEFT_MARK.Tag = "0";
            this.BTN_AKKON_LEFT_MARK.Text = "LEFT MARK";
            this.BTN_AKKON_LEFT_MARK.UseVisualStyleBackColor = false;
            this.BTN_AKKON_LEFT_MARK.Click += new System.EventHandler(this.SelectROIType_Click);
            // 
            // CB_AKKON_MARK_USE
            // 
            this.CB_AKKON_MARK_USE.BackColor = System.Drawing.Color.Silver;
            this.CB_AKKON_MARK_USE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_AKKON_MARK_USE.ForeColor = System.Drawing.Color.Black;
            this.CB_AKKON_MARK_USE.Location = new System.Drawing.Point(132, 116);
            this.CB_AKKON_MARK_USE.Name = "CB_AKKON_MARK_USE";
            this.CB_AKKON_MARK_USE.Size = new System.Drawing.Size(121, 50);
            this.CB_AKKON_MARK_USE.TabIndex = 188;
            this.CB_AKKON_MARK_USE.Text = "Mark Pos USE";
            this.CB_AKKON_MARK_USE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CB_AKKON_MARK_USE.UseVisualStyleBackColor = false;
            this.CB_AKKON_MARK_USE.CheckedChanged += new System.EventHandler(this.CB_AKKON_MARK_USE_CheckedChanged);
            // 
            // BTN_AKKON_APPLY
            // 
            this.BTN_AKKON_APPLY.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_APPLY.Font = new System.Drawing.Font("맑은 고딕", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_APPLY.Location = new System.Drawing.Point(6, 115);
            this.BTN_AKKON_APPLY.Name = "BTN_AKKON_APPLY";
            this.BTN_AKKON_APPLY.Size = new System.Drawing.Size(120, 50);
            this.BTN_AKKON_APPLY.TabIndex = 187;
            this.BTN_AKKON_APPLY.Text = "APPLY";
            this.BTN_AKKON_APPLY.UseVisualStyleBackColor = false;
            // 
            // BTN_AKKON_CLEAR_ROI
            // 
            this.BTN_AKKON_CLEAR_ROI.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_CLEAR_ROI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_CLEAR_ROI.Location = new System.Drawing.Point(239, 82);
            this.BTN_AKKON_CLEAR_ROI.Name = "BTN_AKKON_CLEAR_ROI";
            this.BTN_AKKON_CLEAR_ROI.Size = new System.Drawing.Size(68, 27);
            this.BTN_AKKON_CLEAR_ROI.TabIndex = 186;
            this.BTN_AKKON_CLEAR_ROI.Text = "CLEAR";
            this.BTN_AKKON_CLEAR_ROI.UseVisualStyleBackColor = false;
            this.BTN_AKKON_CLEAR_ROI.Click += new System.EventHandler(this.BTN_AKKON_CLEAR_ROI_Click);
            // 
            // BTN_AKKON_LOAD_ROI
            // 
            this.BTN_AKKON_LOAD_ROI.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_LOAD_ROI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_LOAD_ROI.Location = new System.Drawing.Point(239, 55);
            this.BTN_AKKON_LOAD_ROI.Name = "BTN_AKKON_LOAD_ROI";
            this.BTN_AKKON_LOAD_ROI.Size = new System.Drawing.Size(68, 27);
            this.BTN_AKKON_LOAD_ROI.TabIndex = 185;
            this.BTN_AKKON_LOAD_ROI.Text = "LOAD";
            this.BTN_AKKON_LOAD_ROI.UseVisualStyleBackColor = false;
            this.BTN_AKKON_LOAD_ROI.Click += new System.EventHandler(this.BTN_AKKON_LOAD_ROI_Click);
            // 
            // btn_TabNo
            // 
            this.btn_TabNo.BackColor = System.Drawing.Color.DarkGray;
            this.btn_TabNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_TabNo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TabNo.Location = new System.Drawing.Point(910, 6);
            this.btn_TabNo.Name = "btn_TabNo";
            this.btn_TabNo.Size = new System.Drawing.Size(211, 49);
            this.btn_TabNo.TabIndex = 197;
            this.btn_TabNo.Text = " TAB 1";
            this.btn_TabNo.UseVisualStyleBackColor = false;
            // 
            // panel_AkkonParam
            // 
            this.panel_AkkonParam.Controls.Add(this.lbl_Spec_Count);
            this.panel_AkkonParam.Controls.Add(this.lb_Spec_Count);
            this.panel_AkkonParam.Controls.Add(this.lb_Spec_Length);
            this.panel_AkkonParam.Controls.Add(this.label9);
            this.panel_AkkonParam.Controls.Add(this.label78);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_MIN_SZ_FILTER);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_MAX_SZ_FILTER);
            this.panel_AkkonParam.Controls.Add(this.label76);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_GRP_DIST);
            this.panel_AkkonParam.Controls.Add(this.label74);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_STRN_FILTER);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_EXTRE_LEAD_DISP);
            this.panel_AkkonParam.Controls.Add(this.label72);
            this.panel_AkkonParam.Controls.Add(this.label65);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_WIDTH_CUT);
            this.panel_AkkonParam.Controls.Add(this.label86);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_HEIGHT_CUT);
            this.panel_AkkonParam.Controls.Add(this.label84);
            this.panel_AkkonParam.Controls.Add(this.label82);
            this.panel_AkkonParam.Controls.Add(this.LB_ATT_BW_RATIO);
            this.panel_AkkonParam.Location = new System.Drawing.Point(30, 381);
            this.panel_AkkonParam.Name = "panel_AkkonParam";
            this.panel_AkkonParam.Size = new System.Drawing.Size(497, 215);
            this.panel_AkkonParam.TabIndex = 286;
            // 
            // lbl_Spec_Count
            // 
            this.lbl_Spec_Count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Spec_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Spec_Count.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Spec_Count.Location = new System.Drawing.Point(2, 5);
            this.lbl_Spec_Count.Name = "lbl_Spec_Count";
            this.lbl_Spec_Count.Size = new System.Drawing.Size(115, 36);
            this.lbl_Spec_Count.TabIndex = 177;
            this.lbl_Spec_Count.Text = "Count";
            this.lbl_Spec_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Spec_Count
            // 
            this.lb_Spec_Count.BackColor = System.Drawing.Color.White;
            this.lb_Spec_Count.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Spec_Count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Spec_Count.Location = new System.Drawing.Point(122, 5);
            this.lb_Spec_Count.Name = "lb_Spec_Count";
            this.lb_Spec_Count.Size = new System.Drawing.Size(122, 36);
            this.lb_Spec_Count.TabIndex = 178;
            this.lb_Spec_Count.Tag = "0";
            this.lb_Spec_Count.Text = "0";
            this.lb_Spec_Count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Spec_Count.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // lb_Spec_Length
            // 
            this.lb_Spec_Length.BackColor = System.Drawing.Color.White;
            this.lb_Spec_Length.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Spec_Length.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Spec_Length.Location = new System.Drawing.Point(373, 5);
            this.lb_Spec_Length.Name = "lb_Spec_Length";
            this.lb_Spec_Length.Size = new System.Drawing.Size(122, 36);
            this.lb_Spec_Length.TabIndex = 180;
            this.lb_Spec_Length.Tag = "1";
            this.lb_Spec_Length.Text = "0";
            this.lb_Spec_Length.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Spec_Length.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(253, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 36);
            this.label9.TabIndex = 179;
            this.label9.Text = "Length";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label78
            // 
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label78.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label78.Location = new System.Drawing.Point(3, 45);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(115, 36);
            this.label78.TabIndex = 158;
            this.label78.Text = "MIN SIZE FILTER (um)";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_MIN_SZ_FILTER
            // 
            this.LB_ATT_MIN_SZ_FILTER.BackColor = System.Drawing.Color.White;
            this.LB_ATT_MIN_SZ_FILTER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_MIN_SZ_FILTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_MIN_SZ_FILTER.Location = new System.Drawing.Point(123, 45);
            this.LB_ATT_MIN_SZ_FILTER.Name = "LB_ATT_MIN_SZ_FILTER";
            this.LB_ATT_MIN_SZ_FILTER.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_MIN_SZ_FILTER.TabIndex = 159;
            this.LB_ATT_MIN_SZ_FILTER.Tag = "2";
            this.LB_ATT_MIN_SZ_FILTER.Text = "0";
            this.LB_ATT_MIN_SZ_FILTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_MIN_SZ_FILTER.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // LB_ATT_MAX_SZ_FILTER
            // 
            this.LB_ATT_MAX_SZ_FILTER.BackColor = System.Drawing.Color.White;
            this.LB_ATT_MAX_SZ_FILTER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_MAX_SZ_FILTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_MAX_SZ_FILTER.Location = new System.Drawing.Point(123, 88);
            this.LB_ATT_MAX_SZ_FILTER.Name = "LB_ATT_MAX_SZ_FILTER";
            this.LB_ATT_MAX_SZ_FILTER.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_MAX_SZ_FILTER.TabIndex = 161;
            this.LB_ATT_MAX_SZ_FILTER.Tag = "3";
            this.LB_ATT_MAX_SZ_FILTER.Text = "0";
            this.LB_ATT_MAX_SZ_FILTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_MAX_SZ_FILTER.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label76
            // 
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label76.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label76.Location = new System.Drawing.Point(3, 88);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(115, 36);
            this.label76.TabIndex = 160;
            this.label76.Text = "MAX SIZE FILTER (um)";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_GRP_DIST
            // 
            this.LB_ATT_GRP_DIST.BackColor = System.Drawing.Color.White;
            this.LB_ATT_GRP_DIST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_GRP_DIST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_GRP_DIST.Location = new System.Drawing.Point(123, 131);
            this.LB_ATT_GRP_DIST.Name = "LB_ATT_GRP_DIST";
            this.LB_ATT_GRP_DIST.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_GRP_DIST.TabIndex = 163;
            this.LB_ATT_GRP_DIST.Tag = "4";
            this.LB_ATT_GRP_DIST.Text = "0";
            this.LB_ATT_GRP_DIST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_GRP_DIST.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label74
            // 
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label74.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label74.Location = new System.Drawing.Point(3, 131);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(115, 36);
            this.label74.TabIndex = 162;
            this.label74.Text = "GROUP DISTANCE (px)";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_STRN_FILTER
            // 
            this.LB_ATT_STRN_FILTER.BackColor = System.Drawing.Color.White;
            this.LB_ATT_STRN_FILTER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_STRN_FILTER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_STRN_FILTER.Location = new System.Drawing.Point(123, 174);
            this.LB_ATT_STRN_FILTER.Name = "LB_ATT_STRN_FILTER";
            this.LB_ATT_STRN_FILTER.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_STRN_FILTER.TabIndex = 165;
            this.LB_ATT_STRN_FILTER.Tag = "5";
            this.LB_ATT_STRN_FILTER.Text = "0";
            this.LB_ATT_STRN_FILTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_STRN_FILTER.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // LB_ATT_EXTRE_LEAD_DISP
            // 
            this.LB_ATT_EXTRE_LEAD_DISP.BackColor = System.Drawing.Color.White;
            this.LB_ATT_EXTRE_LEAD_DISP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_EXTRE_LEAD_DISP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_EXTRE_LEAD_DISP.Location = new System.Drawing.Point(374, 174);
            this.LB_ATT_EXTRE_LEAD_DISP.Name = "LB_ATT_EXTRE_LEAD_DISP";
            this.LB_ATT_EXTRE_LEAD_DISP.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_EXTRE_LEAD_DISP.TabIndex = 176;
            this.LB_ATT_EXTRE_LEAD_DISP.Tag = "9";
            this.LB_ATT_EXTRE_LEAD_DISP.Text = "0";
            this.LB_ATT_EXTRE_LEAD_DISP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_EXTRE_LEAD_DISP.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label72
            // 
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label72.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label72.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label72.Location = new System.Drawing.Point(3, 174);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(115, 36);
            this.label72.TabIndex = 164;
            this.label72.Text = "STRENGTH FILTER (%)";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label65
            // 
            this.label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label65.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label65.Location = new System.Drawing.Point(254, 174);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(115, 36);
            this.label65.TabIndex = 175;
            this.label65.Text = "EXTRA LEAD DISPLAY";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_WIDTH_CUT
            // 
            this.LB_ATT_WIDTH_CUT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_WIDTH_CUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_WIDTH_CUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_WIDTH_CUT.Location = new System.Drawing.Point(374, 45);
            this.LB_ATT_WIDTH_CUT.Name = "LB_ATT_WIDTH_CUT";
            this.LB_ATT_WIDTH_CUT.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_WIDTH_CUT.TabIndex = 167;
            this.LB_ATT_WIDTH_CUT.Tag = "6";
            this.LB_ATT_WIDTH_CUT.Text = "0";
            this.LB_ATT_WIDTH_CUT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_WIDTH_CUT.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label86
            // 
            this.label86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label86.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label86.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label86.Location = new System.Drawing.Point(254, 45);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(115, 36);
            this.label86.TabIndex = 166;
            this.label86.Text = "WIDTH CUT (px)";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_HEIGHT_CUT
            // 
            this.LB_ATT_HEIGHT_CUT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_HEIGHT_CUT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_HEIGHT_CUT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_HEIGHT_CUT.Location = new System.Drawing.Point(374, 88);
            this.LB_ATT_HEIGHT_CUT.Name = "LB_ATT_HEIGHT_CUT";
            this.LB_ATT_HEIGHT_CUT.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_HEIGHT_CUT.TabIndex = 169;
            this.LB_ATT_HEIGHT_CUT.Tag = "7";
            this.LB_ATT_HEIGHT_CUT.Text = "0";
            this.LB_ATT_HEIGHT_CUT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_HEIGHT_CUT.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // label84
            // 
            this.label84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label84.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label84.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label84.Location = new System.Drawing.Point(254, 88);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(115, 36);
            this.label84.TabIndex = 168;
            this.label84.Text = "HEIGHT CUT (px)";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label82
            // 
            this.label82.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label82.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label82.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label82.Location = new System.Drawing.Point(254, 131);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(115, 36);
            this.label82.TabIndex = 170;
            this.label82.Text = "BW RATIO";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_BW_RATIO
            // 
            this.LB_ATT_BW_RATIO.BackColor = System.Drawing.Color.White;
            this.LB_ATT_BW_RATIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_BW_RATIO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_BW_RATIO.Location = new System.Drawing.Point(374, 131);
            this.LB_ATT_BW_RATIO.Name = "LB_ATT_BW_RATIO";
            this.LB_ATT_BW_RATIO.Size = new System.Drawing.Size(122, 36);
            this.LB_ATT_BW_RATIO.TabIndex = 171;
            this.LB_ATT_BW_RATIO.Tag = "8";
            this.LB_ATT_BW_RATIO.Text = "0";
            this.LB_ATT_BW_RATIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_BW_RATIO.Click += new System.EventHandler(this.Set_Akkon_Engineer_Param_Click);
            // 
            // panel_MakerParam
            // 
            this.panel_MakerParam.Controls.Add(this.label64);
            this.panel_MakerParam.Controls.Add(this.LB_ATT_THRES_WEIGHT);
            this.panel_MakerParam.Controls.Add(this.LB_ATT_PEAK_THRES);
            this.panel_MakerParam.Controls.Add(this.label66);
            this.panel_MakerParam.Controls.Add(this.LB_ATT_STREN_SCALE_FACTOR);
            this.panel_MakerParam.Controls.Add(this.label68);
            this.panel_MakerParam.Controls.Add(this.LB_ATT_SLICE_OVERLAP);
            this.panel_MakerParam.Controls.Add(this.label70);
            this.panel_MakerParam.Controls.Add(this.LB_ATT_STD_DEV);
            this.panel_MakerParam.Controls.Add(this.label80);
            this.panel_MakerParam.Controls.Add(this.label58);
            this.panel_MakerParam.Controls.Add(this.label56);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_FILTER_TYPE);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_INSP_TYPE);
            this.panel_MakerParam.Controls.Add(this.label59);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_PANEL_TYPE);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_USE_LOG_TRACE);
            this.panel_MakerParam.Controls.Add(this.label60);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_TARGET_TYPE);
            this.panel_MakerParam.Controls.Add(this.label57);
            this.panel_MakerParam.Controls.Add(this.label54);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_THRES_MODE);
            this.panel_MakerParam.Controls.Add(this.label55);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_SHADOW_DIR);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_FILTER_DIR);
            this.panel_MakerParam.Controls.Add(this.label61);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_PEAK_PROP);
            this.panel_MakerParam.Controls.Add(this.label62);
            this.panel_MakerParam.Controls.Add(this.CB_ATT_STREN_BASE);
            this.panel_MakerParam.Controls.Add(this.label63);
            this.panel_MakerParam.Location = new System.Drawing.Point(33, 20);
            this.panel_MakerParam.Name = "panel_MakerParam";
            this.panel_MakerParam.Size = new System.Drawing.Size(557, 355);
            this.panel_MakerParam.TabIndex = 287;
            // 
            // label64
            // 
            this.label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label64.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label64.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label64.Location = new System.Drawing.Point(7, 229);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(95, 36);
            this.label64.TabIndex = 178;
            this.label64.Text = "THRESHOLD WEIGHT";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_THRES_WEIGHT
            // 
            this.LB_ATT_THRES_WEIGHT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_THRES_WEIGHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_THRES_WEIGHT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_THRES_WEIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_THRES_WEIGHT.Location = new System.Drawing.Point(107, 229);
            this.LB_ATT_THRES_WEIGHT.Name = "LB_ATT_THRES_WEIGHT";
            this.LB_ATT_THRES_WEIGHT.Size = new System.Drawing.Size(100, 36);
            this.LB_ATT_THRES_WEIGHT.TabIndex = 179;
            this.LB_ATT_THRES_WEIGHT.Tag = "10";
            this.LB_ATT_THRES_WEIGHT.Text = "0";
            this.LB_ATT_THRES_WEIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_THRES_WEIGHT.Click += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // LB_ATT_PEAK_THRES
            // 
            this.LB_ATT_PEAK_THRES.BackColor = System.Drawing.Color.White;
            this.LB_ATT_PEAK_THRES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_PEAK_THRES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_PEAK_THRES.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_PEAK_THRES.Location = new System.Drawing.Point(107, 272);
            this.LB_ATT_PEAK_THRES.Name = "LB_ATT_PEAK_THRES";
            this.LB_ATT_PEAK_THRES.Size = new System.Drawing.Size(100, 36);
            this.LB_ATT_PEAK_THRES.TabIndex = 181;
            this.LB_ATT_PEAK_THRES.Tag = "11";
            this.LB_ATT_PEAK_THRES.Text = "0";
            this.LB_ATT_PEAK_THRES.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_PEAK_THRES.Click += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label66
            // 
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label66.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label66.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label66.Location = new System.Drawing.Point(7, 272);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(95, 36);
            this.label66.TabIndex = 180;
            this.label66.Text = "PEAK THRESHOLD";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_STREN_SCALE_FACTOR
            // 
            this.LB_ATT_STREN_SCALE_FACTOR.BackColor = System.Drawing.Color.White;
            this.LB_ATT_STREN_SCALE_FACTOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_STREN_SCALE_FACTOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_STREN_SCALE_FACTOR.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_STREN_SCALE_FACTOR.Location = new System.Drawing.Point(376, 229);
            this.LB_ATT_STREN_SCALE_FACTOR.Name = "LB_ATT_STREN_SCALE_FACTOR";
            this.LB_ATT_STREN_SCALE_FACTOR.Size = new System.Drawing.Size(100, 36);
            this.LB_ATT_STREN_SCALE_FACTOR.TabIndex = 183;
            this.LB_ATT_STREN_SCALE_FACTOR.Tag = "12";
            this.LB_ATT_STREN_SCALE_FACTOR.Text = "0";
            this.LB_ATT_STREN_SCALE_FACTOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_STREN_SCALE_FACTOR.Click += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label68
            // 
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label68.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label68.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label68.Location = new System.Drawing.Point(276, 229);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(95, 36);
            this.label68.TabIndex = 182;
            this.label68.Text = "STRENGTH SCALE FACTOR";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_SLICE_OVERLAP
            // 
            this.LB_ATT_SLICE_OVERLAP.BackColor = System.Drawing.Color.White;
            this.LB_ATT_SLICE_OVERLAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_SLICE_OVERLAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_SLICE_OVERLAP.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_SLICE_OVERLAP.Location = new System.Drawing.Point(376, 272);
            this.LB_ATT_SLICE_OVERLAP.Name = "LB_ATT_SLICE_OVERLAP";
            this.LB_ATT_SLICE_OVERLAP.Size = new System.Drawing.Size(100, 36);
            this.LB_ATT_SLICE_OVERLAP.TabIndex = 185;
            this.LB_ATT_SLICE_OVERLAP.Tag = "13";
            this.LB_ATT_SLICE_OVERLAP.Text = "0";
            this.LB_ATT_SLICE_OVERLAP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_SLICE_OVERLAP.Click += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label70
            // 
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label70.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label70.Location = new System.Drawing.Point(276, 272);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(95, 36);
            this.label70.TabIndex = 184;
            this.label70.Text = "SLICE OVERLAP";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_STD_DEV
            // 
            this.LB_ATT_STD_DEV.BackColor = System.Drawing.Color.White;
            this.LB_ATT_STD_DEV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_STD_DEV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_STD_DEV.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_STD_DEV.Location = new System.Drawing.Point(107, 315);
            this.LB_ATT_STD_DEV.Name = "LB_ATT_STD_DEV";
            this.LB_ATT_STD_DEV.Size = new System.Drawing.Size(100, 36);
            this.LB_ATT_STD_DEV.TabIndex = 187;
            this.LB_ATT_STD_DEV.Tag = "14";
            this.LB_ATT_STD_DEV.Text = "0";
            this.LB_ATT_STD_DEV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_STD_DEV.Click += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label80
            // 
            this.label80.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label80.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label80.Location = new System.Drawing.Point(7, 315);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(95, 36);
            this.label80.TabIndex = 186;
            this.label80.Text = "STANDARD DEVIATION";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label58
            // 
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label58.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label58.Location = new System.Drawing.Point(7, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(95, 36);
            this.label58.TabIndex = 138;
            this.label58.Text = "INSPECTION TYPE";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label56
            // 
            this.label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label56.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label56.Location = new System.Drawing.Point(7, 138);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(95, 36);
            this.label56.TabIndex = 134;
            this.label56.Text = "FILTER TYPE";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_FILTER_TYPE
            // 
            this.CB_ATT_FILTER_TYPE.DisplayMember = "1";
            this.CB_ATT_FILTER_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_FILTER_TYPE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_FILTER_TYPE.FormattingEnabled = true;
            this.CB_ATT_FILTER_TYPE.Items.AddRange(new object[] {
            "NORMAL",
            "SMALL",
            "FILTER #2",
            "FILTER #3",
            "FILTER #4",
            "BIG"});
            this.CB_ATT_FILTER_TYPE.Location = new System.Drawing.Point(107, 139);
            this.CB_ATT_FILTER_TYPE.Name = "CB_ATT_FILTER_TYPE";
            this.CB_ATT_FILTER_TYPE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_FILTER_TYPE.TabIndex = 135;
            this.CB_ATT_FILTER_TYPE.Tag = "3";
            this.CB_ATT_FILTER_TYPE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // CB_ATT_INSP_TYPE
            // 
            this.CB_ATT_INSP_TYPE.DisplayMember = "1";
            this.CB_ATT_INSP_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_INSP_TYPE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_INSP_TYPE.FormattingEnabled = true;
            this.CB_ATT_INSP_TYPE.Items.AddRange(new object[] {
            "THRESHOLD",
            "DL MODE 0",
            "DL MODE 1",
            "DL MODE 2"});
            this.CB_ATT_INSP_TYPE.Location = new System.Drawing.Point(107, 10);
            this.CB_ATT_INSP_TYPE.Name = "CB_ATT_INSP_TYPE";
            this.CB_ATT_INSP_TYPE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_INSP_TYPE.TabIndex = 139;
            this.CB_ATT_INSP_TYPE.Tag = "0";
            this.CB_ATT_INSP_TYPE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label59
            // 
            this.label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label59.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label59.Location = new System.Drawing.Point(7, 52);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(95, 36);
            this.label59.TabIndex = 140;
            this.label59.Text = "PANEL TYPE";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_PANEL_TYPE
            // 
            this.CB_ATT_PANEL_TYPE.DisplayMember = "1";
            this.CB_ATT_PANEL_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_PANEL_TYPE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_PANEL_TYPE.FormattingEnabled = true;
            this.CB_ATT_PANEL_TYPE.Items.AddRange(new object[] {
            "RIGID",
            "FLEXIBLE"});
            this.CB_ATT_PANEL_TYPE.Location = new System.Drawing.Point(107, 53);
            this.CB_ATT_PANEL_TYPE.Name = "CB_ATT_PANEL_TYPE";
            this.CB_ATT_PANEL_TYPE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_PANEL_TYPE.TabIndex = 141;
            this.CB_ATT_PANEL_TYPE.Tag = "1";
            this.CB_ATT_PANEL_TYPE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // CB_ATT_USE_LOG_TRACE
            // 
            this.CB_ATT_USE_LOG_TRACE.BackColor = System.Drawing.Color.Silver;
            this.CB_ATT_USE_LOG_TRACE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_ATT_USE_LOG_TRACE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_USE_LOG_TRACE.Location = new System.Drawing.Point(376, 140);
            this.CB_ATT_USE_LOG_TRACE.Name = "CB_ATT_USE_LOG_TRACE";
            this.CB_ATT_USE_LOG_TRACE.Size = new System.Drawing.Size(163, 36);
            this.CB_ATT_USE_LOG_TRACE.TabIndex = 177;
            this.CB_ATT_USE_LOG_TRACE.Tag = "9";
            this.CB_ATT_USE_LOG_TRACE.Text = "USE CHECK";
            this.CB_ATT_USE_LOG_TRACE.UseVisualStyleBackColor = false;
            this.CB_ATT_USE_LOG_TRACE.CheckedChanged += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label60
            // 
            this.label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label60.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label60.Location = new System.Drawing.Point(7, 95);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(95, 36);
            this.label60.TabIndex = 142;
            this.label60.Text = "TARGET TYPE";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_TARGET_TYPE
            // 
            this.CB_ATT_TARGET_TYPE.DisplayMember = "1";
            this.CB_ATT_TARGET_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_TARGET_TYPE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_TARGET_TYPE.FormattingEnabled = true;
            this.CB_ATT_TARGET_TYPE.Items.AddRange(new object[] {
            "COF",
            "COG",
            "FOG"});
            this.CB_ATT_TARGET_TYPE.Location = new System.Drawing.Point(107, 96);
            this.CB_ATT_TARGET_TYPE.Name = "CB_ATT_TARGET_TYPE";
            this.CB_ATT_TARGET_TYPE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_TARGET_TYPE.TabIndex = 143;
            this.CB_ATT_TARGET_TYPE.Tag = "2";
            this.CB_ATT_TARGET_TYPE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label57
            // 
            this.label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label57.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label57.Location = new System.Drawing.Point(7, 183);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(95, 36);
            this.label57.TabIndex = 136;
            this.label57.Text = "FILTER DIRECTION";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label54
            // 
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label54.Location = new System.Drawing.Point(276, 181);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(95, 36);
            this.label54.TabIndex = 130;
            this.label54.Text = "THRESHOLD MODE";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_THRES_MODE
            // 
            this.CB_ATT_THRES_MODE.DisplayMember = "1";
            this.CB_ATT_THRES_MODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_THRES_MODE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_THRES_MODE.FormattingEnabled = true;
            this.CB_ATT_THRES_MODE.Items.AddRange(new object[] {
            "AUTO",
            "WHITE",
            "BLACK"});
            this.CB_ATT_THRES_MODE.Location = new System.Drawing.Point(376, 178);
            this.CB_ATT_THRES_MODE.Name = "CB_ATT_THRES_MODE";
            this.CB_ATT_THRES_MODE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_THRES_MODE.TabIndex = 131;
            this.CB_ATT_THRES_MODE.Tag = "8";
            this.CB_ATT_THRES_MODE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label55
            // 
            this.label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label55.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label55.Location = new System.Drawing.Point(276, 10);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(95, 36);
            this.label55.TabIndex = 132;
            this.label55.Text = "SHADOW DIRECTION";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_SHADOW_DIR
            // 
            this.CB_ATT_SHADOW_DIR.DisplayMember = "1";
            this.CB_ATT_SHADOW_DIR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_SHADOW_DIR.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_SHADOW_DIR.FormattingEnabled = true;
            this.CB_ATT_SHADOW_DIR.Items.AddRange(new object[] {
            "UP",
            "DOWN",
            "LEFT",
            "RIGHT"});
            this.CB_ATT_SHADOW_DIR.Location = new System.Drawing.Point(376, 11);
            this.CB_ATT_SHADOW_DIR.Name = "CB_ATT_SHADOW_DIR";
            this.CB_ATT_SHADOW_DIR.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_SHADOW_DIR.TabIndex = 133;
            this.CB_ATT_SHADOW_DIR.Tag = "5";
            this.CB_ATT_SHADOW_DIR.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // CB_ATT_FILTER_DIR
            // 
            this.CB_ATT_FILTER_DIR.DisplayMember = "1";
            this.CB_ATT_FILTER_DIR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_FILTER_DIR.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_FILTER_DIR.FormattingEnabled = true;
            this.CB_ATT_FILTER_DIR.Items.AddRange(new object[] {
            "HORIZONTAL",
            "VERTICAL"});
            this.CB_ATT_FILTER_DIR.Location = new System.Drawing.Point(107, 184);
            this.CB_ATT_FILTER_DIR.Name = "CB_ATT_FILTER_DIR";
            this.CB_ATT_FILTER_DIR.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_FILTER_DIR.TabIndex = 137;
            this.CB_ATT_FILTER_DIR.Tag = "4";
            this.CB_ATT_FILTER_DIR.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label61
            // 
            this.label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label61.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label61.Location = new System.Drawing.Point(276, 53);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(95, 36);
            this.label61.TabIndex = 144;
            this.label61.Text = "PEAK PROPERTY";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_PEAK_PROP
            // 
            this.CB_ATT_PEAK_PROP.DisplayMember = "1";
            this.CB_ATT_PEAK_PROP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_PEAK_PROP.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_PEAK_PROP.FormattingEnabled = true;
            this.CB_ATT_PEAK_PROP.Items.AddRange(new object[] {
            "NORMAL",
            "NEAR"});
            this.CB_ATT_PEAK_PROP.Location = new System.Drawing.Point(376, 55);
            this.CB_ATT_PEAK_PROP.Name = "CB_ATT_PEAK_PROP";
            this.CB_ATT_PEAK_PROP.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_PEAK_PROP.TabIndex = 145;
            this.CB_ATT_PEAK_PROP.Tag = "6";
            this.CB_ATT_PEAK_PROP.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label62
            // 
            this.label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label62.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label62.Location = new System.Drawing.Point(276, 96);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(95, 36);
            this.label62.TabIndex = 146;
            this.label62.Text = "STRENGTH BASE";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CB_ATT_STREN_BASE
            // 
            this.CB_ATT_STREN_BASE.DisplayMember = "1";
            this.CB_ATT_STREN_BASE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_ATT_STREN_BASE.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_STREN_BASE.FormattingEnabled = true;
            this.CB_ATT_STREN_BASE.Items.AddRange(new object[] {
            "ENH",
            "RAW"});
            this.CB_ATT_STREN_BASE.Location = new System.Drawing.Point(376, 98);
            this.CB_ATT_STREN_BASE.Name = "CB_ATT_STREN_BASE";
            this.CB_ATT_STREN_BASE.Size = new System.Drawing.Size(163, 33);
            this.CB_ATT_STREN_BASE.TabIndex = 147;
            this.CB_ATT_STREN_BASE.Tag = "7";
            this.CB_ATT_STREN_BASE.SelectionChangeCommitted += new System.EventHandler(this.Set_Maker_Parames_Changed);
            // 
            // label63
            // 
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label63.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label63.Location = new System.Drawing.Point(276, 136);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(95, 36);
            this.label63.TabIndex = 148;
            this.label63.Text = "LOG TRACE";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_Akkon_ROI_Grup
            // 
            this.panel_Akkon_ROI_Grup.Controls.Add(this.btn_ROI_Show);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.btn_list_delete);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.btn_GropROIApply);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_ATT_ROI_COPY);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_ATT_ROI_CREATE);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.CB_ATT_GROUP_NO);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LB_ATT_ROI_HEIGHT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_ROI_HEIGHT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LB_ATT_ROI_WIDTH);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_ROI_WIDTH);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_ATT_AUTO_SORT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_ADJUST);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_AKKON_CLONE_VER);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_CLONE_ROI);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_ATT_FIRSTLEAD_REGISTER);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.BTN_AKKON_CLONE_HOR);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_FIRST_LEAD);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LB_ATT_LEAD_PITCH);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LB_ATT_LEAD_COUNT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_LEAD_COUNT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_LEAD_PITCH);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_GROUP_NO);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LB_ATT_GROUP_COUNT);
            this.panel_Akkon_ROI_Grup.Controls.Add(this.LBL_ATT_GROUP_COUNT);
            this.panel_Akkon_ROI_Grup.Location = new System.Drawing.Point(937, 469);
            this.panel_Akkon_ROI_Grup.Name = "panel_Akkon_ROI_Grup";
            this.panel_Akkon_ROI_Grup.Size = new System.Drawing.Size(314, 363);
            this.panel_Akkon_ROI_Grup.TabIndex = 290;
            this.panel_Akkon_ROI_Grup.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // btn_ROI_Show
            // 
            this.btn_ROI_Show.BackColor = System.Drawing.Color.DarkGray;
            this.btn_ROI_Show.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_ROI_Show.Location = new System.Drawing.Point(208, 51);
            this.btn_ROI_Show.Name = "btn_ROI_Show";
            this.btn_ROI_Show.Size = new System.Drawing.Size(97, 36);
            this.btn_ROI_Show.TabIndex = 207;
            this.btn_ROI_Show.Tag = "14";
            this.btn_ROI_Show.Text = "ROI SHOW";
            this.btn_ROI_Show.UseVisualStyleBackColor = false;
            // 
            // btn_list_delete
            // 
            this.btn_list_delete.BackColor = System.Drawing.Color.DarkGray;
            this.btn_list_delete.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_list_delete.Location = new System.Drawing.Point(103, 317);
            this.btn_list_delete.Name = "btn_list_delete";
            this.btn_list_delete.Size = new System.Drawing.Size(97, 36);
            this.btn_list_delete.TabIndex = 206;
            this.btn_list_delete.Tag = "12";
            this.btn_list_delete.Text = "Delete";
            this.btn_list_delete.UseVisualStyleBackColor = false;
            this.btn_list_delete.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // btn_GropROIApply
            // 
            this.btn_GropROIApply.BackColor = System.Drawing.Color.DarkGray;
            this.btn_GropROIApply.Font = new System.Drawing.Font("맑은 고딕", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_GropROIApply.Location = new System.Drawing.Point(206, 316);
            this.btn_GropROIApply.Name = "btn_GropROIApply";
            this.btn_GropROIApply.Size = new System.Drawing.Size(96, 36);
            this.btn_GropROIApply.TabIndex = 205;
            this.btn_GropROIApply.Tag = "13";
            this.btn_GropROIApply.Text = "APPLY";
            this.btn_GropROIApply.UseVisualStyleBackColor = false;
            this.btn_GropROIApply.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // BTN_ATT_ROI_COPY
            // 
            this.BTN_ATT_ROI_COPY.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ATT_ROI_COPY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ATT_ROI_COPY.Location = new System.Drawing.Point(205, 280);
            this.BTN_ATT_ROI_COPY.Name = "BTN_ATT_ROI_COPY";
            this.BTN_ATT_ROI_COPY.Size = new System.Drawing.Size(97, 36);
            this.BTN_ATT_ROI_COPY.TabIndex = 204;
            this.BTN_ATT_ROI_COPY.Tag = "10";
            this.BTN_ATT_ROI_COPY.Text = "ROI COPY";
            this.BTN_ATT_ROI_COPY.UseVisualStyleBackColor = false;
            this.BTN_ATT_ROI_COPY.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // BTN_ATT_ROI_CREATE
            // 
            this.BTN_ATT_ROI_CREATE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ATT_ROI_CREATE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ATT_ROI_CREATE.Location = new System.Drawing.Point(105, 160);
            this.BTN_ATT_ROI_CREATE.Name = "BTN_ATT_ROI_CREATE";
            this.BTN_ATT_ROI_CREATE.Size = new System.Drawing.Size(97, 36);
            this.BTN_ATT_ROI_CREATE.TabIndex = 203;
            this.BTN_ATT_ROI_CREATE.Tag = "4";
            this.BTN_ATT_ROI_CREATE.Text = "ROI CREATE";
            this.BTN_ATT_ROI_CREATE.UseVisualStyleBackColor = false;
            this.BTN_ATT_ROI_CREATE.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // CB_ATT_GROUP_NO
            // 
            this.CB_ATT_GROUP_NO.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CB_ATT_GROUP_NO.FormattingEnabled = true;
            this.CB_ATT_GROUP_NO.Location = new System.Drawing.Point(104, 51);
            this.CB_ATT_GROUP_NO.Name = "CB_ATT_GROUP_NO";
            this.CB_ATT_GROUP_NO.Size = new System.Drawing.Size(98, 29);
            this.CB_ATT_GROUP_NO.TabIndex = 202;
            this.CB_ATT_GROUP_NO.Tag = "1";
            this.CB_ATT_GROUP_NO.SelectedIndexChanged += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LB_ATT_ROI_HEIGHT
            // 
            this.LB_ATT_ROI_HEIGHT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_ROI_HEIGHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_ROI_HEIGHT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_ROI_HEIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_ROI_HEIGHT.Location = new System.Drawing.Point(104, 121);
            this.LB_ATT_ROI_HEIGHT.Name = "LB_ATT_ROI_HEIGHT";
            this.LB_ATT_ROI_HEIGHT.Size = new System.Drawing.Size(97, 36);
            this.LB_ATT_ROI_HEIGHT.TabIndex = 201;
            this.LB_ATT_ROI_HEIGHT.Tag = "3";
            this.LB_ATT_ROI_HEIGHT.Text = "0";
            this.LB_ATT_ROI_HEIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_ROI_HEIGHT.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_ROI_HEIGHT
            // 
            this.LBL_ATT_ROI_HEIGHT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_ROI_HEIGHT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_ROI_HEIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_ROI_HEIGHT.Location = new System.Drawing.Point(5, 121);
            this.LBL_ATT_ROI_HEIGHT.Name = "LBL_ATT_ROI_HEIGHT";
            this.LBL_ATT_ROI_HEIGHT.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_ROI_HEIGHT.TabIndex = 200;
            this.LBL_ATT_ROI_HEIGHT.Text = "ROI HEIGHT(㎛)";
            this.LBL_ATT_ROI_HEIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_ROI_WIDTH
            // 
            this.LB_ATT_ROI_WIDTH.BackColor = System.Drawing.Color.White;
            this.LB_ATT_ROI_WIDTH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_ROI_WIDTH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_ROI_WIDTH.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_ROI_WIDTH.Location = new System.Drawing.Point(104, 83);
            this.LB_ATT_ROI_WIDTH.Name = "LB_ATT_ROI_WIDTH";
            this.LB_ATT_ROI_WIDTH.Size = new System.Drawing.Size(97, 36);
            this.LB_ATT_ROI_WIDTH.TabIndex = 199;
            this.LB_ATT_ROI_WIDTH.Tag = "2";
            this.LB_ATT_ROI_WIDTH.Text = "0";
            this.LB_ATT_ROI_WIDTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_ROI_WIDTH.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_ROI_WIDTH
            // 
            this.LBL_ATT_ROI_WIDTH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_ROI_WIDTH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_ROI_WIDTH.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_ROI_WIDTH.Location = new System.Drawing.Point(5, 83);
            this.LBL_ATT_ROI_WIDTH.Name = "LBL_ATT_ROI_WIDTH";
            this.LBL_ATT_ROI_WIDTH.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_ROI_WIDTH.TabIndex = 198;
            this.LBL_ATT_ROI_WIDTH.Text = "ROI WIDTH(㎛)";
            this.LBL_ATT_ROI_WIDTH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_ATT_AUTO_SORT
            // 
            this.BTN_ATT_AUTO_SORT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ATT_AUTO_SORT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ATT_AUTO_SORT.Location = new System.Drawing.Point(5, 318);
            this.BTN_ATT_AUTO_SORT.Name = "BTN_ATT_AUTO_SORT";
            this.BTN_ATT_AUTO_SORT.Size = new System.Drawing.Size(97, 36);
            this.BTN_ATT_AUTO_SORT.TabIndex = 196;
            this.BTN_ATT_AUTO_SORT.Tag = "11";
            this.BTN_ATT_AUTO_SORT.Text = "AUTO SORT";
            this.BTN_ATT_AUTO_SORT.UseVisualStyleBackColor = false;
            this.BTN_ATT_AUTO_SORT.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_ADJUST
            // 
            this.LBL_ATT_ADJUST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_ADJUST.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_ADJUST.Location = new System.Drawing.Point(4, 317);
            this.LBL_ATT_ADJUST.Name = "LBL_ATT_ADJUST";
            this.LBL_ATT_ADJUST.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_ADJUST.TabIndex = 197;
            this.LBL_ATT_ADJUST.Text = "ADJUST";
            this.LBL_ATT_ADJUST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_AKKON_CLONE_VER
            // 
            this.BTN_AKKON_CLONE_VER.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_CLONE_VER.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_CLONE_VER.Image = ((System.Drawing.Image)(resources.GetObject("BTN_AKKON_CLONE_VER.Image")));
            this.BTN_AKKON_CLONE_VER.Location = new System.Drawing.Point(153, 277);
            this.BTN_AKKON_CLONE_VER.Name = "BTN_AKKON_CLONE_VER";
            this.BTN_AKKON_CLONE_VER.Size = new System.Drawing.Size(50, 36);
            this.BTN_AKKON_CLONE_VER.TabIndex = 195;
            this.BTN_AKKON_CLONE_VER.Tag = "9";
            this.BTN_AKKON_CLONE_VER.UseVisualStyleBackColor = false;
            this.BTN_AKKON_CLONE_VER.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_CLONE_ROI
            // 
            this.LBL_ATT_CLONE_ROI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_CLONE_ROI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_CLONE_ROI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_CLONE_ROI.Location = new System.Drawing.Point(5, 278);
            this.LBL_ATT_CLONE_ROI.Name = "LBL_ATT_CLONE_ROI";
            this.LBL_ATT_CLONE_ROI.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_CLONE_ROI.TabIndex = 194;
            this.LBL_ATT_CLONE_ROI.Text = "CLONE ROI";
            this.LBL_ATT_CLONE_ROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_ATT_FIRSTLEAD_REGISTER
            // 
            this.BTN_ATT_FIRSTLEAD_REGISTER.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_ATT_FIRSTLEAD_REGISTER.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_ATT_FIRSTLEAD_REGISTER.Location = new System.Drawing.Point(204, 160);
            this.BTN_ATT_FIRSTLEAD_REGISTER.Name = "BTN_ATT_FIRSTLEAD_REGISTER";
            this.BTN_ATT_FIRSTLEAD_REGISTER.Size = new System.Drawing.Size(97, 36);
            this.BTN_ATT_FIRSTLEAD_REGISTER.TabIndex = 180;
            this.BTN_ATT_FIRSTLEAD_REGISTER.Tag = "5";
            this.BTN_ATT_FIRSTLEAD_REGISTER.Text = "REGISTER";
            this.BTN_ATT_FIRSTLEAD_REGISTER.UseVisualStyleBackColor = false;
            this.BTN_ATT_FIRSTLEAD_REGISTER.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // BTN_AKKON_CLONE_HOR
            // 
            this.BTN_AKKON_CLONE_HOR.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_CLONE_HOR.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_CLONE_HOR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTN_AKKON_CLONE_HOR.Image = ((System.Drawing.Image)(resources.GetObject("BTN_AKKON_CLONE_HOR.Image")));
            this.BTN_AKKON_CLONE_HOR.Location = new System.Drawing.Point(104, 277);
            this.BTN_AKKON_CLONE_HOR.Name = "BTN_AKKON_CLONE_HOR";
            this.BTN_AKKON_CLONE_HOR.Size = new System.Drawing.Size(50, 36);
            this.BTN_AKKON_CLONE_HOR.TabIndex = 193;
            this.BTN_AKKON_CLONE_HOR.Tag = "8";
            this.BTN_AKKON_CLONE_HOR.UseVisualStyleBackColor = false;
            this.BTN_AKKON_CLONE_HOR.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_FIRST_LEAD
            // 
            this.LBL_ATT_FIRST_LEAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_FIRST_LEAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_FIRST_LEAD.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_FIRST_LEAD.Location = new System.Drawing.Point(5, 160);
            this.LBL_ATT_FIRST_LEAD.Name = "LBL_ATT_FIRST_LEAD";
            this.LBL_ATT_FIRST_LEAD.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_FIRST_LEAD.TabIndex = 192;
            this.LBL_ATT_FIRST_LEAD.Text = "FIRST LEAD";
            this.LBL_ATT_FIRST_LEAD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_LEAD_PITCH
            // 
            this.LB_ATT_LEAD_PITCH.BackColor = System.Drawing.Color.White;
            this.LB_ATT_LEAD_PITCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_LEAD_PITCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_LEAD_PITCH.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_LEAD_PITCH.Location = new System.Drawing.Point(105, 199);
            this.LB_ATT_LEAD_PITCH.Name = "LB_ATT_LEAD_PITCH";
            this.LB_ATT_LEAD_PITCH.Size = new System.Drawing.Size(97, 36);
            this.LB_ATT_LEAD_PITCH.TabIndex = 191;
            this.LB_ATT_LEAD_PITCH.Tag = "7";
            this.LB_ATT_LEAD_PITCH.Text = "0";
            this.LB_ATT_LEAD_PITCH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_LEAD_PITCH.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LB_ATT_LEAD_COUNT
            // 
            this.LB_ATT_LEAD_COUNT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_LEAD_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_LEAD_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_LEAD_COUNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_LEAD_COUNT.Location = new System.Drawing.Point(105, 237);
            this.LB_ATT_LEAD_COUNT.Name = "LB_ATT_LEAD_COUNT";
            this.LB_ATT_LEAD_COUNT.Size = new System.Drawing.Size(97, 36);
            this.LB_ATT_LEAD_COUNT.TabIndex = 189;
            this.LB_ATT_LEAD_COUNT.Tag = "6";
            this.LB_ATT_LEAD_COUNT.Text = "0";
            this.LB_ATT_LEAD_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_LEAD_COUNT.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_LEAD_COUNT
            // 
            this.LBL_ATT_LEAD_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_LEAD_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_LEAD_COUNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_LEAD_COUNT.Location = new System.Drawing.Point(5, 237);
            this.LBL_ATT_LEAD_COUNT.Name = "LBL_ATT_LEAD_COUNT";
            this.LBL_ATT_LEAD_COUNT.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_LEAD_COUNT.TabIndex = 188;
            this.LBL_ATT_LEAD_COUNT.Text = "LEAD COUNT";
            this.LBL_ATT_LEAD_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_ATT_LEAD_PITCH
            // 
            this.LBL_ATT_LEAD_PITCH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_LEAD_PITCH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_LEAD_PITCH.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_LEAD_PITCH.Location = new System.Drawing.Point(5, 199);
            this.LBL_ATT_LEAD_PITCH.Name = "LBL_ATT_LEAD_PITCH";
            this.LBL_ATT_LEAD_PITCH.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_LEAD_PITCH.TabIndex = 190;
            this.LBL_ATT_LEAD_PITCH.Text = "LEAD PITCH(㎛)";
            this.LBL_ATT_LEAD_PITCH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_ATT_GROUP_NO
            // 
            this.LBL_ATT_GROUP_NO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_GROUP_NO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_GROUP_NO.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_GROUP_NO.Location = new System.Drawing.Point(5, 45);
            this.LBL_ATT_GROUP_NO.Name = "LBL_ATT_GROUP_NO";
            this.LBL_ATT_GROUP_NO.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_GROUP_NO.TabIndex = 186;
            this.LBL_ATT_GROUP_NO.Text = "GROUP NO.";
            this.LBL_ATT_GROUP_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_ATT_GROUP_COUNT
            // 
            this.LB_ATT_GROUP_COUNT.BackColor = System.Drawing.Color.White;
            this.LB_ATT_GROUP_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ATT_GROUP_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ATT_GROUP_COUNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ATT_GROUP_COUNT.Location = new System.Drawing.Point(105, 7);
            this.LB_ATT_GROUP_COUNT.Name = "LB_ATT_GROUP_COUNT";
            this.LB_ATT_GROUP_COUNT.Size = new System.Drawing.Size(97, 36);
            this.LB_ATT_GROUP_COUNT.TabIndex = 185;
            this.LB_ATT_GROUP_COUNT.Tag = "0";
            this.LB_ATT_GROUP_COUNT.Text = "0";
            this.LB_ATT_GROUP_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ATT_GROUP_COUNT.Click += new System.EventHandler(this.BTN_AkkonROI_Click);
            // 
            // LBL_ATT_GROUP_COUNT
            // 
            this.LBL_ATT_GROUP_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LBL_ATT_GROUP_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LBL_ATT_GROUP_COUNT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LBL_ATT_GROUP_COUNT.Location = new System.Drawing.Point(5, 7);
            this.LBL_ATT_GROUP_COUNT.Name = "LBL_ATT_GROUP_COUNT";
            this.LBL_ATT_GROUP_COUNT.Size = new System.Drawing.Size(95, 36);
            this.LBL_ATT_GROUP_COUNT.TabIndex = 174;
            this.LBL_ATT_GROUP_COUNT.Text = "GROUP COUNT";
            this.LBL_ATT_GROUP_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_IMAGE_OPEN
            // 
            this.BTN_IMAGE_OPEN.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_IMAGE_OPEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_IMAGE_OPEN.Location = new System.Drawing.Point(769, 604);
            this.BTN_IMAGE_OPEN.Name = "BTN_IMAGE_OPEN";
            this.BTN_IMAGE_OPEN.Size = new System.Drawing.Size(136, 43);
            this.BTN_IMAGE_OPEN.TabIndex = 291;
            this.BTN_IMAGE_OPEN.Text = "FILE OPEN";
            this.BTN_IMAGE_OPEN.UseVisualStyleBackColor = false;
            this.BTN_IMAGE_OPEN.Click += new System.EventHandler(this.BTN_IMAGE_OPEN_Click);
            // 
            // BTN_AKKON_GROUP
            // 
            this.BTN_AKKON_GROUP.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_GROUP.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_GROUP.Location = new System.Drawing.Point(1578, 495);
            this.BTN_AKKON_GROUP.Name = "BTN_AKKON_GROUP";
            this.BTN_AKKON_GROUP.Size = new System.Drawing.Size(87, 50);
            this.BTN_AKKON_GROUP.TabIndex = 292;
            this.BTN_AKKON_GROUP.Text = "GROUP";
            this.BTN_AKKON_GROUP.UseVisualStyleBackColor = false;
            this.BTN_AKKON_GROUP.Click += new System.EventHandler(this.BTN_AKKON_GROUP_Click);
            // 
            // BTN_AKKON_PARAMETER
            // 
            this.BTN_AKKON_PARAMETER.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_PARAMETER.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_PARAMETER.Location = new System.Drawing.Point(1690, 495);
            this.BTN_AKKON_PARAMETER.Name = "BTN_AKKON_PARAMETER";
            this.BTN_AKKON_PARAMETER.Size = new System.Drawing.Size(87, 50);
            this.BTN_AKKON_PARAMETER.TabIndex = 293;
            this.BTN_AKKON_PARAMETER.Tag = "1";
            this.BTN_AKKON_PARAMETER.Text = "PARAMETER";
            this.BTN_AKKON_PARAMETER.UseVisualStyleBackColor = false;
            this.BTN_AKKON_PARAMETER.Click += new System.EventHandler(this.BTN_Akkon_Parameter_Click);
            // 
            // btn_Maker_Parm
            // 
            this.btn_Maker_Parm.BackColor = System.Drawing.Color.DarkGray;
            this.btn_Maker_Parm.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Maker_Parm.Location = new System.Drawing.Point(1801, 495);
            this.btn_Maker_Parm.Name = "btn_Maker_Parm";
            this.btn_Maker_Parm.Size = new System.Drawing.Size(87, 50);
            this.btn_Maker_Parm.TabIndex = 294;
            this.btn_Maker_Parm.Tag = "0";
            this.btn_Maker_Parm.Text = "Maker PARAMETER";
            this.btn_Maker_Parm.UseVisualStyleBackColor = false;
            this.btn_Maker_Parm.Click += new System.EventHandler(this.BTN_Akkon_Parameter_Click);
            // 
            // LB_ShowTodo
            // 
            this.LB_ShowTodo.BackColor = System.Drawing.Color.Black;
            this.LB_ShowTodo.Font = new System.Drawing.Font("맑은 고딕 Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_ShowTodo.ForeColor = System.Drawing.SystemColors.Control;
            this.LB_ShowTodo.Location = new System.Drawing.Point(6, 752);
            this.LB_ShowTodo.Name = "LB_ShowTodo";
            this.LB_ShowTodo.Size = new System.Drawing.Size(765, 135);
            this.LB_ShowTodo.TabIndex = 295;
            this.LB_ShowTodo.Text = "label6";
            // 
            // BTN_TEST
            // 
            this.BTN_TEST.AutoSize = true;
            this.BTN_TEST.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_TEST.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_TEST.Font = new System.Drawing.Font("맑은 고딕", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_TEST.Location = new System.Drawing.Point(775, 750);
            this.BTN_TEST.Name = "BTN_TEST";
            this.BTN_TEST.Size = new System.Drawing.Size(131, 98);
            this.BTN_TEST.TabIndex = 296;
            this.BTN_TEST.Text = "TEST";
            this.BTN_TEST.UseVisualStyleBackColor = false;
            this.BTN_TEST.Click += new System.EventHandler(this.BTN_TEST_Click);
            // 
            // LB_MESSAGE1
            // 
            this.LB_MESSAGE1.BackColor = System.Drawing.Color.Black;
            this.LB_MESSAGE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_MESSAGE1.Cursor = System.Windows.Forms.Cursors.Default;
            this.LB_MESSAGE1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LB_MESSAGE1.ForeColor = System.Drawing.Color.Red;
            this.LB_MESSAGE1.Location = new System.Drawing.Point(531, 608);
            this.LB_MESSAGE1.Name = "LB_MESSAGE1";
            this.LB_MESSAGE1.Size = new System.Drawing.Size(235, 36);
            this.LB_MESSAGE1.TabIndex = 297;
            this.LB_MESSAGE1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BTN_AKKON_RESULT_IMAGE
            // 
            this.BTN_AKKON_RESULT_IMAGE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_RESULT_IMAGE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_RESULT_IMAGE.Location = new System.Drawing.Point(1690, 551);
            this.BTN_AKKON_RESULT_IMAGE.Name = "BTN_AKKON_RESULT_IMAGE";
            this.BTN_AKKON_RESULT_IMAGE.Size = new System.Drawing.Size(87, 50);
            this.BTN_AKKON_RESULT_IMAGE.TabIndex = 300;
            this.BTN_AKKON_RESULT_IMAGE.Text = "RESULT IMAGE";
            this.BTN_AKKON_RESULT_IMAGE.UseVisualStyleBackColor = false;
            this.BTN_AKKON_RESULT_IMAGE.Click += new System.EventHandler(this.BTN_AKKON_RESULT_IMAGE_Click);
            // 
            // BTN_AKKON_ORIGINAL_IMAGE
            // 
            this.BTN_AKKON_ORIGINAL_IMAGE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_ORIGINAL_IMAGE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_ORIGINAL_IMAGE.Location = new System.Drawing.Point(1578, 551);
            this.BTN_AKKON_ORIGINAL_IMAGE.Name = "BTN_AKKON_ORIGINAL_IMAGE";
            this.BTN_AKKON_ORIGINAL_IMAGE.Size = new System.Drawing.Size(87, 50);
            this.BTN_AKKON_ORIGINAL_IMAGE.TabIndex = 299;
            this.BTN_AKKON_ORIGINAL_IMAGE.Text = "Source IMAGE";
            this.BTN_AKKON_ORIGINAL_IMAGE.UseVisualStyleBackColor = false;
            this.BTN_AKKON_ORIGINAL_IMAGE.Click += new System.EventHandler(this.BTN_AKKON_ORIGINAL_IMAGE_Click);
            // 
            // BTN_AKKON_TEACH_IMAGE
            // 
            this.BTN_AKKON_TEACH_IMAGE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_AKKON_TEACH_IMAGE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_AKKON_TEACH_IMAGE.Location = new System.Drawing.Point(1801, 549);
            this.BTN_AKKON_TEACH_IMAGE.Name = "BTN_AKKON_TEACH_IMAGE";
            this.BTN_AKKON_TEACH_IMAGE.Size = new System.Drawing.Size(87, 50);
            this.BTN_AKKON_TEACH_IMAGE.TabIndex = 298;
            this.BTN_AKKON_TEACH_IMAGE.Text = "TEACH IMAGE";
            this.BTN_AKKON_TEACH_IMAGE.UseVisualStyleBackColor = false;
            this.BTN_AKKON_TEACH_IMAGE.Click += new System.EventHandler(this.BTN_AKKON_TEACH_IMAGE_Click);
            // 
            // Panel_AlingInsp
            // 
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_TARPOS_PANEL);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_TARPOS_FPC);
            this.Panel_AlingInsp.Controls.Add(this.lab_AlignInsp_Target_Pos);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGNPOS_Y);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_TEACH_MARK);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_TEACH_EDGE);
            this.Panel_AlingInsp.Controls.Add(this.lab_TeachMode);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_INSPOS_RIGHT);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGNPOS_X);
            this.Panel_AlingInsp.Controls.Add(this.RBTN_ALIGN_INSPOS_LEFT);
            this.Panel_AlingInsp.Controls.Add(this.lab_Insp_Pos);
            this.Panel_AlingInsp.Controls.Add(this.lab_AlingInsp_pos);
            this.Panel_AlingInsp.Location = new System.Drawing.Point(912, 58);
            this.Panel_AlingInsp.Name = "Panel_AlingInsp";
            this.Panel_AlingInsp.Size = new System.Drawing.Size(769, 87);
            this.Panel_AlingInsp.TabIndex = 301;
            // 
            // RBTN_ALIGN_TARPOS_PANEL
            // 
            this.RBTN_ALIGN_TARPOS_PANEL.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_TARPOS_PANEL.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_TARPOS_PANEL.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_TARPOS_PANEL.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_TARPOS_PANEL.Location = new System.Drawing.Point(278, 46);
            this.RBTN_ALIGN_TARPOS_PANEL.Name = "RBTN_ALIGN_TARPOS_PANEL";
            this.RBTN_ALIGN_TARPOS_PANEL.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_TARPOS_PANEL.TabIndex = 150;
            this.RBTN_ALIGN_TARPOS_PANEL.Tag = "3";
            this.RBTN_ALIGN_TARPOS_PANEL.Text = "PANEL";
            this.RBTN_ALIGN_TARPOS_PANEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_TARPOS_PANEL.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_TARPOS_PANEL.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // RBTN_ALIGN_TARPOS_FPC
            // 
            this.RBTN_ALIGN_TARPOS_FPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_TARPOS_FPC.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_TARPOS_FPC.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_TARPOS_FPC.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_TARPOS_FPC.Location = new System.Drawing.Point(169, 46);
            this.RBTN_ALIGN_TARPOS_FPC.Name = "RBTN_ALIGN_TARPOS_FPC";
            this.RBTN_ALIGN_TARPOS_FPC.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_TARPOS_FPC.TabIndex = 149;
            this.RBTN_ALIGN_TARPOS_FPC.Tag = "2";
            this.RBTN_ALIGN_TARPOS_FPC.Text = "FPC";
            this.RBTN_ALIGN_TARPOS_FPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_TARPOS_FPC.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_TARPOS_FPC.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // lab_AlignInsp_Target_Pos
            // 
            this.lab_AlignInsp_Target_Pos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_AlignInsp_Target_Pos.Location = new System.Drawing.Point(4, 47);
            this.lab_AlignInsp_Target_Pos.Name = "lab_AlignInsp_Target_Pos";
            this.lab_AlignInsp_Target_Pos.Size = new System.Drawing.Size(159, 36);
            this.lab_AlignInsp_Target_Pos.TabIndex = 148;
            this.lab_AlignInsp_Target_Pos.Text = "TARGET POSITION";
            this.lab_AlignInsp_Target_Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RBTN_ALIGNPOS_Y
            // 
            this.RBTN_ALIGNPOS_Y.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGNPOS_Y.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGNPOS_Y.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGNPOS_Y.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGNPOS_Y.Location = new System.Drawing.Point(663, 46);
            this.RBTN_ALIGNPOS_Y.Name = "RBTN_ALIGNPOS_Y";
            this.RBTN_ALIGNPOS_Y.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGNPOS_Y.TabIndex = 147;
            this.RBTN_ALIGNPOS_Y.Tag = "7";
            this.RBTN_ALIGNPOS_Y.Text = "Y";
            this.RBTN_ALIGNPOS_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGNPOS_Y.UseVisualStyleBackColor = false;
            this.RBTN_ALIGNPOS_Y.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // RBTN_ALIGN_TEACH_MARK
            // 
            this.RBTN_ALIGN_TEACH_MARK.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_TEACH_MARK.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_TEACH_MARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_TEACH_MARK.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_TEACH_MARK.Location = new System.Drawing.Point(554, 8);
            this.RBTN_ALIGN_TEACH_MARK.Name = "RBTN_ALIGN_TEACH_MARK";
            this.RBTN_ALIGN_TEACH_MARK.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_TEACH_MARK.TabIndex = 144;
            this.RBTN_ALIGN_TEACH_MARK.Tag = "4";
            this.RBTN_ALIGN_TEACH_MARK.Text = "MARK";
            this.RBTN_ALIGN_TEACH_MARK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_TEACH_MARK.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_TEACH_MARK.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // RBTN_ALIGN_TEACH_EDGE
            // 
            this.RBTN_ALIGN_TEACH_EDGE.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_TEACH_EDGE.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_TEACH_EDGE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_TEACH_EDGE.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_TEACH_EDGE.Location = new System.Drawing.Point(664, 8);
            this.RBTN_ALIGN_TEACH_EDGE.Name = "RBTN_ALIGN_TEACH_EDGE";
            this.RBTN_ALIGN_TEACH_EDGE.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_TEACH_EDGE.TabIndex = 143;
            this.RBTN_ALIGN_TEACH_EDGE.Tag = "5";
            this.RBTN_ALIGN_TEACH_EDGE.Text = "EDGE";
            this.RBTN_ALIGN_TEACH_EDGE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_TEACH_EDGE.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_TEACH_EDGE.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // lab_TeachMode
            // 
            this.lab_TeachMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_TeachMode.Location = new System.Drawing.Point(389, 8);
            this.lab_TeachMode.Name = "lab_TeachMode";
            this.lab_TeachMode.Size = new System.Drawing.Size(159, 36);
            this.lab_TeachMode.TabIndex = 142;
            this.lab_TeachMode.Text = "TEACH MODE";
            this.lab_TeachMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RBTN_ALIGN_INSPOS_RIGHT
            // 
            this.RBTN_ALIGN_INSPOS_RIGHT.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_INSPOS_RIGHT.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_INSPOS_RIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_INSPOS_RIGHT.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_INSPOS_RIGHT.Location = new System.Drawing.Point(279, 7);
            this.RBTN_ALIGN_INSPOS_RIGHT.Name = "RBTN_ALIGN_INSPOS_RIGHT";
            this.RBTN_ALIGN_INSPOS_RIGHT.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_INSPOS_RIGHT.TabIndex = 141;
            this.RBTN_ALIGN_INSPOS_RIGHT.Tag = "1";
            this.RBTN_ALIGN_INSPOS_RIGHT.Text = "RIGHT";
            this.RBTN_ALIGN_INSPOS_RIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_INSPOS_RIGHT.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_INSPOS_RIGHT.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // RBTN_ALIGNPOS_X
            // 
            this.RBTN_ALIGNPOS_X.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGNPOS_X.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGNPOS_X.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGNPOS_X.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGNPOS_X.Location = new System.Drawing.Point(554, 46);
            this.RBTN_ALIGNPOS_X.Name = "RBTN_ALIGNPOS_X";
            this.RBTN_ALIGNPOS_X.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGNPOS_X.TabIndex = 146;
            this.RBTN_ALIGNPOS_X.Tag = "6";
            this.RBTN_ALIGNPOS_X.Text = "X";
            this.RBTN_ALIGNPOS_X.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGNPOS_X.UseVisualStyleBackColor = false;
            this.RBTN_ALIGNPOS_X.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // RBTN_ALIGN_INSPOS_LEFT
            // 
            this.RBTN_ALIGN_INSPOS_LEFT.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_INSPOS_LEFT.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_INSPOS_LEFT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_INSPOS_LEFT.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_INSPOS_LEFT.Location = new System.Drawing.Point(169, 7);
            this.RBTN_ALIGN_INSPOS_LEFT.Name = "RBTN_ALIGN_INSPOS_LEFT";
            this.RBTN_ALIGN_INSPOS_LEFT.Size = new System.Drawing.Size(104, 36);
            this.RBTN_ALIGN_INSPOS_LEFT.TabIndex = 140;
            this.RBTN_ALIGN_INSPOS_LEFT.Tag = "0";
            this.RBTN_ALIGN_INSPOS_LEFT.Text = "LEFT";
            this.RBTN_ALIGN_INSPOS_LEFT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_INSPOS_LEFT.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_INSPOS_LEFT.Click += new System.EventHandler(this.btn_AlignInsp_Setting_Click);
            // 
            // lab_Insp_Pos
            // 
            this.lab_Insp_Pos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Insp_Pos.Location = new System.Drawing.Point(4, 7);
            this.lab_Insp_Pos.Name = "lab_Insp_Pos";
            this.lab_Insp_Pos.Size = new System.Drawing.Size(159, 36);
            this.lab_Insp_Pos.TabIndex = 139;
            this.lab_Insp_Pos.Text = "INSPECTION POSITION";
            this.lab_Insp_Pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_AlingInsp_pos
            // 
            this.lab_AlingInsp_pos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_AlingInsp_pos.Location = new System.Drawing.Point(389, 47);
            this.lab_AlingInsp_pos.Name = "lab_AlingInsp_pos";
            this.lab_AlingInsp_pos.Size = new System.Drawing.Size(159, 36);
            this.lab_AlingInsp_pos.TabIndex = 145;
            this.lab_AlingInsp_pos.Text = "ALIGN POSITION";
            this.lab_AlingInsp_pos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PANEL_AT_CALIPER
            // 
            this.PANEL_AT_CALIPER.Controls.Add(this.RBTN_ALIGN_INSPECTION_TEST);
            this.PANEL_AT_CALIPER.Controls.Add(this.RBTN_ALIGN_EDGE_APPLY);
            this.PANEL_AT_CALIPER.Controls.Add(this.RBTN_ALIGN_EDGE_SHOWROI);
            this.PANEL_AT_CALIPER.Controls.Add(this.RBTN_BRIGHT_TO_DARK);
            this.PANEL_AT_CALIPER.Controls.Add(this.RBTN_DARK_TO_BRIGHT);
            this.PANEL_AT_CALIPER.Controls.Add(this.LB_ALIGN_EDGE_THRESHOLD);
            this.PANEL_AT_CALIPER.Controls.Add(this.LB_ALIGN_LEAD_COUNT);
            this.PANEL_AT_CALIPER.Controls.Add(this.CB_ALIGN_ROI_TRACKING);
            this.PANEL_AT_CALIPER.Controls.Add(this.LB_ALIGN_FILTER_SIZE);
            this.PANEL_AT_CALIPER.Controls.Add(this.lab_Edge_Polarty);
            this.PANEL_AT_CALIPER.Controls.Add(this.lab_AlignInspLeadCnt);
            this.PANEL_AT_CALIPER.Controls.Add(this.lab_Filter_Size);
            this.PANEL_AT_CALIPER.Controls.Add(this.lab_EdgeThresHold);
            this.PANEL_AT_CALIPER.Location = new System.Drawing.Point(1257, 614);
            this.PANEL_AT_CALIPER.Name = "PANEL_AT_CALIPER";
            this.PANEL_AT_CALIPER.Size = new System.Drawing.Size(424, 234);
            this.PANEL_AT_CALIPER.TabIndex = 302;
            // 
            // RBTN_ALIGN_INSPECTION_TEST
            // 
            this.RBTN_ALIGN_INSPECTION_TEST.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_INSPECTION_TEST.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_INSPECTION_TEST.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_INSPECTION_TEST.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_INSPECTION_TEST.Location = new System.Drawing.Point(295, 153);
            this.RBTN_ALIGN_INSPECTION_TEST.Name = "RBTN_ALIGN_INSPECTION_TEST";
            this.RBTN_ALIGN_INSPECTION_TEST.Size = new System.Drawing.Size(118, 78);
            this.RBTN_ALIGN_INSPECTION_TEST.TabIndex = 164;
            this.RBTN_ALIGN_INSPECTION_TEST.Tag = "7";
            this.RBTN_ALIGN_INSPECTION_TEST.Text = "Align Inspection Test";
            this.RBTN_ALIGN_INSPECTION_TEST.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_INSPECTION_TEST.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_INSPECTION_TEST.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // RBTN_ALIGN_EDGE_APPLY
            // 
            this.RBTN_ALIGN_EDGE_APPLY.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_EDGE_APPLY.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_EDGE_APPLY.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_EDGE_APPLY.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_EDGE_APPLY.Location = new System.Drawing.Point(295, 78);
            this.RBTN_ALIGN_EDGE_APPLY.Name = "RBTN_ALIGN_EDGE_APPLY";
            this.RBTN_ALIGN_EDGE_APPLY.Size = new System.Drawing.Size(118, 36);
            this.RBTN_ALIGN_EDGE_APPLY.TabIndex = 163;
            this.RBTN_ALIGN_EDGE_APPLY.Tag = "6";
            this.RBTN_ALIGN_EDGE_APPLY.Text = "Apply";
            this.RBTN_ALIGN_EDGE_APPLY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_EDGE_APPLY.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_EDGE_APPLY.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // RBTN_ALIGN_EDGE_SHOWROI
            // 
            this.RBTN_ALIGN_EDGE_SHOWROI.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_ALIGN_EDGE_SHOWROI.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_ALIGN_EDGE_SHOWROI.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_ALIGN_EDGE_SHOWROI.ForeColor = System.Drawing.Color.Black;
            this.RBTN_ALIGN_EDGE_SHOWROI.Location = new System.Drawing.Point(295, 40);
            this.RBTN_ALIGN_EDGE_SHOWROI.Name = "RBTN_ALIGN_EDGE_SHOWROI";
            this.RBTN_ALIGN_EDGE_SHOWROI.Size = new System.Drawing.Size(118, 36);
            this.RBTN_ALIGN_EDGE_SHOWROI.TabIndex = 162;
            this.RBTN_ALIGN_EDGE_SHOWROI.Tag = "0";
            this.RBTN_ALIGN_EDGE_SHOWROI.Text = "Show ROI";
            this.RBTN_ALIGN_EDGE_SHOWROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_ALIGN_EDGE_SHOWROI.UseVisualStyleBackColor = false;
            this.RBTN_ALIGN_EDGE_SHOWROI.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // RBTN_BRIGHT_TO_DARK
            // 
            this.RBTN_BRIGHT_TO_DARK.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_BRIGHT_TO_DARK.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_BRIGHT_TO_DARK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_BRIGHT_TO_DARK.ForeColor = System.Drawing.Color.Black;
            this.RBTN_BRIGHT_TO_DARK.Location = new System.Drawing.Point(168, 114);
            this.RBTN_BRIGHT_TO_DARK.Name = "RBTN_BRIGHT_TO_DARK";
            this.RBTN_BRIGHT_TO_DARK.Size = new System.Drawing.Size(118, 36);
            this.RBTN_BRIGHT_TO_DARK.TabIndex = 161;
            this.RBTN_BRIGHT_TO_DARK.Tag = "3";
            this.RBTN_BRIGHT_TO_DARK.Text = "BRIGHT ▶DARK";
            this.RBTN_BRIGHT_TO_DARK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_BRIGHT_TO_DARK.UseVisualStyleBackColor = false;
            this.RBTN_BRIGHT_TO_DARK.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // RBTN_DARK_TO_BRIGHT
            // 
            this.RBTN_DARK_TO_BRIGHT.Appearance = System.Windows.Forms.Appearance.Button;
            this.RBTN_DARK_TO_BRIGHT.BackColor = System.Drawing.Color.DarkGray;
            this.RBTN_DARK_TO_BRIGHT.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RBTN_DARK_TO_BRIGHT.ForeColor = System.Drawing.Color.Black;
            this.RBTN_DARK_TO_BRIGHT.Location = new System.Drawing.Point(168, 77);
            this.RBTN_DARK_TO_BRIGHT.Name = "RBTN_DARK_TO_BRIGHT";
            this.RBTN_DARK_TO_BRIGHT.Size = new System.Drawing.Size(118, 36);
            this.RBTN_DARK_TO_BRIGHT.TabIndex = 151;
            this.RBTN_DARK_TO_BRIGHT.Tag = "2";
            this.RBTN_DARK_TO_BRIGHT.Text = "DARK ▶BRIGHT";
            this.RBTN_DARK_TO_BRIGHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RBTN_DARK_TO_BRIGHT.UseVisualStyleBackColor = false;
            this.RBTN_DARK_TO_BRIGHT.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // LB_ALIGN_EDGE_THRESHOLD
            // 
            this.LB_ALIGN_EDGE_THRESHOLD.BackColor = System.Drawing.Color.White;
            this.LB_ALIGN_EDGE_THRESHOLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ALIGN_EDGE_THRESHOLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ALIGN_EDGE_THRESHOLD.Location = new System.Drawing.Point(170, 191);
            this.LB_ALIGN_EDGE_THRESHOLD.Name = "LB_ALIGN_EDGE_THRESHOLD";
            this.LB_ALIGN_EDGE_THRESHOLD.Size = new System.Drawing.Size(116, 36);
            this.LB_ALIGN_EDGE_THRESHOLD.TabIndex = 159;
            this.LB_ALIGN_EDGE_THRESHOLD.Tag = "5";
            this.LB_ALIGN_EDGE_THRESHOLD.Text = "0";
            this.LB_ALIGN_EDGE_THRESHOLD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ALIGN_EDGE_THRESHOLD.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // LB_ALIGN_LEAD_COUNT
            // 
            this.LB_ALIGN_LEAD_COUNT.BackColor = System.Drawing.Color.White;
            this.LB_ALIGN_LEAD_COUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ALIGN_LEAD_COUNT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ALIGN_LEAD_COUNT.Location = new System.Drawing.Point(169, 40);
            this.LB_ALIGN_LEAD_COUNT.Name = "LB_ALIGN_LEAD_COUNT";
            this.LB_ALIGN_LEAD_COUNT.Size = new System.Drawing.Size(116, 36);
            this.LB_ALIGN_LEAD_COUNT.TabIndex = 157;
            this.LB_ALIGN_LEAD_COUNT.Tag = "1";
            this.LB_ALIGN_LEAD_COUNT.Text = "0";
            this.LB_ALIGN_LEAD_COUNT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ALIGN_LEAD_COUNT.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // CB_ALIGN_ROI_TRACKING
            // 
            this.CB_ALIGN_ROI_TRACKING.AutoSize = true;
            this.CB_ALIGN_ROI_TRACKING.Location = new System.Drawing.Point(4, 10);
            this.CB_ALIGN_ROI_TRACKING.Name = "CB_ALIGN_ROI_TRACKING";
            this.CB_ALIGN_ROI_TRACKING.Size = new System.Drawing.Size(101, 16);
            this.CB_ALIGN_ROI_TRACKING.TabIndex = 156;
            this.CB_ALIGN_ROI_TRACKING.Tag = "9";
            this.CB_ALIGN_ROI_TRACKING.Text = "ROI Tracking ";
            this.CB_ALIGN_ROI_TRACKING.UseVisualStyleBackColor = true;
            // 
            // LB_ALIGN_FILTER_SIZE
            // 
            this.LB_ALIGN_FILTER_SIZE.BackColor = System.Drawing.Color.White;
            this.LB_ALIGN_FILTER_SIZE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_ALIGN_FILTER_SIZE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LB_ALIGN_FILTER_SIZE.Location = new System.Drawing.Point(170, 153);
            this.LB_ALIGN_FILTER_SIZE.Name = "LB_ALIGN_FILTER_SIZE";
            this.LB_ALIGN_FILTER_SIZE.Size = new System.Drawing.Size(116, 36);
            this.LB_ALIGN_FILTER_SIZE.TabIndex = 158;
            this.LB_ALIGN_FILTER_SIZE.Tag = "4";
            this.LB_ALIGN_FILTER_SIZE.Text = "0";
            this.LB_ALIGN_FILTER_SIZE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_ALIGN_FILTER_SIZE.Click += new System.EventHandler(this.btnEdgeParams_Click);
            // 
            // lab_Edge_Polarty
            // 
            this.lab_Edge_Polarty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Edge_Polarty.Location = new System.Drawing.Point(5, 79);
            this.lab_Edge_Polarty.Name = "lab_Edge_Polarty";
            this.lab_Edge_Polarty.Size = new System.Drawing.Size(159, 70);
            this.lab_Edge_Polarty.TabIndex = 155;
            this.lab_Edge_Polarty.Text = "EDGE POLARITY";
            this.lab_Edge_Polarty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_AlignInspLeadCnt
            // 
            this.lab_AlignInspLeadCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_AlignInspLeadCnt.Location = new System.Drawing.Point(4, 40);
            this.lab_AlignInspLeadCnt.Name = "lab_AlignInspLeadCnt";
            this.lab_AlignInspLeadCnt.Size = new System.Drawing.Size(159, 36);
            this.lab_AlignInspLeadCnt.TabIndex = 151;
            this.lab_AlignInspLeadCnt.Text = "LEAD COUNT";
            this.lab_AlignInspLeadCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_Filter_Size
            // 
            this.lab_Filter_Size.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_Filter_Size.Location = new System.Drawing.Point(5, 153);
            this.lab_Filter_Size.Name = "lab_Filter_Size";
            this.lab_Filter_Size.Size = new System.Drawing.Size(159, 36);
            this.lab_Filter_Size.TabIndex = 152;
            this.lab_Filter_Size.Text = "FILTER SIZE";
            this.lab_Filter_Size.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lab_EdgeThresHold
            // 
            this.lab_EdgeThresHold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_EdgeThresHold.Location = new System.Drawing.Point(5, 191);
            this.lab_EdgeThresHold.Name = "lab_EdgeThresHold";
            this.lab_EdgeThresHold.Size = new System.Drawing.Size(159, 36);
            this.lab_EdgeThresHold.TabIndex = 153;
            this.lab_EdgeThresHold.Text = "EDGE THRESHOLD";
            this.lab_EdgeThresHold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_SAVE
            // 
            this.BTN_SAVE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_SAVE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_SAVE.BackgroundImage")));
            this.BTN_SAVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_SAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SAVE.Location = new System.Drawing.Point(1667, 925);
            this.BTN_SAVE.Name = "BTN_SAVE";
            this.BTN_SAVE.Size = new System.Drawing.Size(100, 100);
            this.BTN_SAVE.TabIndex = 289;
            this.BTN_SAVE.Text = "SAVE";
            this.BTN_SAVE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_SAVE.UseVisualStyleBackColor = false;
            this.BTN_SAVE.Click += new System.EventHandler(this.BTN_SAVE_Click);
            // 
            // BTN_EXIT
            // 
            this.BTN_EXIT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_EXIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_EXIT.BackgroundImage")));
            this.BTN_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_EXIT.Location = new System.Drawing.Point(1788, 925);
            this.BTN_EXIT.Name = "BTN_EXIT";
            this.BTN_EXIT.Size = new System.Drawing.Size(100, 100);
            this.BTN_EXIT.TabIndex = 288;
            this.BTN_EXIT.Text = "EXIT";
            this.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_EXIT.UseVisualStyleBackColor = false;
            this.BTN_EXIT.Click += new System.EventHandler(this.BTN_EXIT_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.DarkGray;
            this.button14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button14.Image = global::COG.Properties.Resources.RIGHT;
            this.button14.Location = new System.Drawing.Point(1163, 8);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(41, 45);
            this.button14.TabIndex = 285;
            this.button14.Tag = "0";
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.SelectTab_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.DarkGray;
            this.button13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button13.Image = global::COG.Properties.Resources.LEFT;
            this.button13.Location = new System.Drawing.Point(1124, 8);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(41, 44);
            this.button13.TabIndex = 284;
            this.button13.Tag = "1";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.SelectTab_Click);
            // 
            // PT_DISPLAY_CONTROL
            // 
            this.PT_DISPLAY_CONTROL.BackColor = System.Drawing.Color.DarkGray;
            this.PT_DISPLAY_CONTROL.CustomCross = ((System.Drawing.PointF)(resources.GetObject("PT_DISPLAY_CONTROL.CustomCross")));
            this.PT_DISPLAY_CONTROL.DisplayManuConstants = ((JAS.Controls.Display.DisplayEnableConstants)((((((((((JAS.Controls.Display.DisplayEnableConstants.DisplayFit | JAS.Controls.Display.DisplayEnableConstants.Undo) 
            | JAS.Controls.Display.DisplayEnableConstants.Delete) 
            | JAS.Controls.Display.DisplayEnableConstants.TouchMove0) 
            | JAS.Controls.Display.DisplayEnableConstants.PointToPoint1) 
            | JAS.Controls.Display.DisplayEnableConstants.LineToLine2) 
            | JAS.Controls.Display.DisplayEnableConstants.Arc3Points) 
            | JAS.Controls.Display.DisplayEnableConstants.Square5) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossLine6) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossCustom)));
            this.PT_DISPLAY_CONTROL.Image = null;
            this.PT_DISPLAY_CONTROL.Location = new System.Drawing.Point(0, 1);
            this.PT_DISPLAY_CONTROL.Name = "PT_DISPLAY_CONTROL";
            this.PT_DISPLAY_CONTROL.Resuloution = 1D;
            this.PT_DISPLAY_CONTROL.Size = new System.Drawing.Size(904, 643);
            this.PT_DISPLAY_CONTROL.TabIndex = 278;
            this.PT_DISPLAY_CONTROL.UseCustomCross = false;
            // 
            // Form_AkkonTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1884, 917);
            this.ControlBox = false;
            this.Controls.Add(this.PANEL_AT_CALIPER);
            this.Controls.Add(this.Panel_AlingInsp);
            this.Controls.Add(this.BTN_AKKON_RESULT_IMAGE);
            this.Controls.Add(this.BTN_AKKON_ORIGINAL_IMAGE);
            this.Controls.Add(this.BTN_AKKON_TEACH_IMAGE);
            this.Controls.Add(this.LB_MESSAGE1);
            this.Controls.Add(this.BTN_TEST);
            this.Controls.Add(this.panel_MakerParam);
            this.Controls.Add(this.LB_ShowTodo);
            this.Controls.Add(this.btn_Maker_Parm);
            this.Controls.Add(this.BTN_AKKON_PARAMETER);
            this.Controls.Add(this.BTN_AKKON_GROUP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Mark);
            this.Controls.Add(this.panel_AkkonParam);
            this.Controls.Add(this.BTN_IMAGE_OPEN);
            this.Controls.Add(this.panel_Akkon_ROI_Grup);
            this.Controls.Add(this.BTN_SAVE);
            this.Controls.Add(this.BTN_EXIT);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.btn_TabNo);
            this.Controls.Add(this.cog_Display_Thumbnail);
            this.Controls.Add(this.TAB_ATT_LIST);
            this.Controls.Add(this.PT_DISPLAY_CONTROL);
            this.Controls.Add(this.PT_DisplayToolbar01);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_AkkonTeaching";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_AkkonTeaching";
            this.Load += new System.EventHandler(this.Form_AkkonTeaching_Load);
            this.TAB_ATT_LIST.ResumeLayout(false);
            this.tabPageROI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_AKKON_ROI_LIST)).EndInit();
            this.tabPageResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_AKKON_RESULT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cog_Display_Thumbnail)).EndInit();
            this.GB_MOVE_.ResumeLayout(false);
            this.panel_Mark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AngleMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_AngleMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_PAT_SCORE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay05)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogSubDisplay02)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel_AkkonParam.ResumeLayout(false);
            this.panel_MakerParam.ResumeLayout(false);
            this.panel_Akkon_ROI_Grup.ResumeLayout(false);
            this.Panel_AlingInsp.ResumeLayout(false);
            this.PANEL_AT_CALIPER.ResumeLayout(false);
            this.PANEL_AT_CALIPER.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private JAS.Controls.Display.Display PT_DISPLAY_CONTROL;
        private Cognex.VisionPro.CogDisplayToolbarV2 PT_DisplayToolbar01;
        private Cognex.VisionPro.CogDisplayStatusBarV2 PT_DisplayStatusBar01;
        private System.Windows.Forms.TabControl TAB_ATT_LIST;
        private System.Windows.Forms.TabPage tabPageROI;
        private System.Windows.Forms.DataGridView DG_AKKON_ROI_LIST;
        private System.Windows.Forms.TabPage tabPageResult;
        private System.Windows.Forms.DataGridView DG_AKKON_RESULT;
        public Cognex.VisionPro.CogRecordDisplay cog_Display_Thumbnail;
        private System.Windows.Forms.GroupBox GB_MOVE_;
        private System.Windows.Forms.Label LB_RECTANGLE;
        private System.Windows.Forms.Button BTN_UP;
        private System.Windows.Forms.Button BTN_DOWN;
        private System.Windows.Forms.Button BTN_LEFT;
        private System.Windows.Forms.Button BTN_RIGHT;
        private System.Windows.Forms.Panel panel_Mark;
        private Cognex.VisionPro.Display.CogDisplay cogSubDisplay05;
        private Cognex.VisionPro.Display.CogDisplay cogSubDisplay04;
        private Cognex.VisionPro.Display.CogDisplay cogSubDisplay03;
        private Cognex.VisionPro.Display.CogDisplay cogSubDisplay02;
        private Cognex.VisionPro.Display.CogDisplay cogSubDisplay01;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUD_PAT_SCORE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_PATTERN_00;
        private System.Windows.Forms.Button btn_SubMark4;
        private System.Windows.Forms.Button btn_SubMark3;
        private System.Windows.Forms.Button btn_SubMark2;
        private System.Windows.Forms.Button btn_SubMark1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Main_Mark;
        private System.Windows.Forms.Button BTN_PATTERN;
        private System.Windows.Forms.Button BTN_MARKDELETE;
        private System.Windows.Forms.Button BTN_MASKING;
        private System.Windows.Forms.Button BTN_SEARCHROI;
        private System.Windows.Forms.Button BTN_SETMARK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUD_AngleMax;
        private System.Windows.Forms.Button BTN_MARKAPPLY;
        private System.Windows.Forms.Button btn_Mark_Complet;
        private System.Windows.Forms.Button btn_MarkTest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_AKKON_CLEAR_ROI;
        private System.Windows.Forms.Button BTN_AKKON_LOAD_ROI;
        private System.Windows.Forms.Button BTN_ROI_SKEW_ZERO;
        private System.Windows.Forms.Button BTN_ROI_SKEW_CW;
        private System.Windows.Forms.Button BTN_ROI_SKEW_CCW;
        private System.Windows.Forms.Button btn_TabNo;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.CheckBox CB_AKKON_MARK_USE;
        private System.Windows.Forms.Button BTN_AKKON_APPLY;
        private System.Windows.Forms.Button BTN_AKKON_RIGHT_MARK;
        private System.Windows.Forms.Button BTN_AKKON_LEFT_MARK;
        private System.Windows.Forms.Panel panel_AkkonParam;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label LB_ATT_MIN_SZ_FILTER;
        private System.Windows.Forms.Label LB_ATT_MAX_SZ_FILTER;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label LB_ATT_GRP_DIST;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label LB_ATT_STRN_FILTER;
        private System.Windows.Forms.Label LB_ATT_EXTRE_LEAD_DISP;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label LB_ATT_WIDTH_CUT;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.Label LB_ATT_HEIGHT_CUT;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Label LB_ATT_BW_RATIO;
        private System.Windows.Forms.Panel panel_MakerParam;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.ComboBox CB_ATT_FILTER_TYPE;
        private System.Windows.Forms.ComboBox CB_ATT_INSP_TYPE;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.ComboBox CB_ATT_PANEL_TYPE;
        private System.Windows.Forms.CheckBox CB_ATT_USE_LOG_TRACE;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.ComboBox CB_ATT_TARGET_TYPE;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.ComboBox CB_ATT_THRES_MODE;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox CB_ATT_SHADOW_DIR;
        private System.Windows.Forms.ComboBox CB_ATT_FILTER_DIR;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.ComboBox CB_ATT_PEAK_PROP;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.ComboBox CB_ATT_STREN_BASE;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label LB_ATT_THRES_WEIGHT;
        private System.Windows.Forms.Label LB_ATT_PEAK_THRES;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label LB_ATT_STREN_SCALE_FACTOR;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label LB_ATT_SLICE_OVERLAP;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label LB_ATT_STD_DEV;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button BTN_SAVE;
        private System.Windows.Forms.Button BTN_EXIT;
        private System.Windows.Forms.Panel panel_Akkon_ROI_Grup;
        private System.Windows.Forms.Button BTN_ATT_ROI_COPY;
        private System.Windows.Forms.Button BTN_ATT_ROI_CREATE;
        private System.Windows.Forms.ComboBox CB_ATT_GROUP_NO;
        private System.Windows.Forms.Label LB_ATT_ROI_HEIGHT;
        private System.Windows.Forms.Label LBL_ATT_ROI_HEIGHT;
        private System.Windows.Forms.Label LB_ATT_ROI_WIDTH;
        private System.Windows.Forms.Label LBL_ATT_ROI_WIDTH;
        private System.Windows.Forms.Button BTN_ATT_AUTO_SORT;
        private System.Windows.Forms.Label LBL_ATT_ADJUST;
        private System.Windows.Forms.Button BTN_AKKON_CLONE_VER;
        private System.Windows.Forms.Button BTN_AKKON_CLONE_HOR;
        private System.Windows.Forms.Label LBL_ATT_CLONE_ROI;
        private System.Windows.Forms.Button BTN_ATT_FIRSTLEAD_REGISTER;
        private System.Windows.Forms.Label LBL_ATT_FIRST_LEAD;
        private System.Windows.Forms.Label LB_ATT_LEAD_PITCH;
        private System.Windows.Forms.Label LBL_ATT_LEAD_PITCH;
        private System.Windows.Forms.Label LB_ATT_LEAD_COUNT;
        private System.Windows.Forms.Label LBL_ATT_LEAD_COUNT;
        private System.Windows.Forms.Label LBL_ATT_GROUP_NO;
        private System.Windows.Forms.Label LB_ATT_GROUP_COUNT;
        private System.Windows.Forms.Label LBL_ATT_GROUP_COUNT;
        private System.Windows.Forms.Button BTN_IMAGE_OPEN;
        private System.Windows.Forms.Label LB_ATT_MOVE_PIXEL_COUNT;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NUD_AngleMin;
        private System.Windows.Forms.Button BTN_ROIORIGN;
        private System.Windows.Forms.Button BTN_ROIMARK;
        private System.Windows.Forms.Button BTN_AKKON_GROUP;
        private System.Windows.Forms.Button BTN_AKKON_PARAMETER;
        private System.Windows.Forms.Button btn_GropROIApply;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_00;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_02;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_03;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_04;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button RBTN_AKKON00;
        private System.Windows.Forms.Button btn_Size;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Button btn_list_delete;
        private System.Windows.Forms.Button btn_Maker_Parm;
        private System.Windows.Forms.Label lbl_Spec_Count;
        private System.Windows.Forms.Label lb_Spec_Count;
        private System.Windows.Forms.Label lb_Spec_Length;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LB_ShowTodo;
        private System.Windows.Forms.Button btn_ROI_Show;
        private System.Windows.Forms.Button BTN_TEST;
        private System.Windows.Forms.Label LB_MESSAGE1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BTN_AKKON_RESULT_IMAGE;
        private System.Windows.Forms.Button BTN_AKKON_ORIGINAL_IMAGE;
        private System.Windows.Forms.Button BTN_AKKON_TEACH_IMAGE;
        private System.Windows.Forms.Panel Panel_AlingInsp;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_TARPOS_PANEL;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_TARPOS_FPC;
        private System.Windows.Forms.Label lab_AlignInsp_Target_Pos;
        private System.Windows.Forms.RadioButton RBTN_ALIGNPOS_Y;
        private System.Windows.Forms.RadioButton RBTN_ALIGNPOS_X;
        private System.Windows.Forms.Label lab_AlingInsp_pos;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_TEACH_MARK;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_TEACH_EDGE;
        private System.Windows.Forms.Label lab_TeachMode;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_INSPOS_RIGHT;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_INSPOS_LEFT;
        private System.Windows.Forms.Label lab_Insp_Pos;
        private System.Windows.Forms.Panel PANEL_AT_CALIPER;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_INSPECTION_TEST;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_EDGE_APPLY;
        private System.Windows.Forms.RadioButton RBTN_ALIGN_EDGE_SHOWROI;
        private System.Windows.Forms.RadioButton RBTN_BRIGHT_TO_DARK;
        private System.Windows.Forms.RadioButton RBTN_DARK_TO_BRIGHT;
        private System.Windows.Forms.Label LB_ALIGN_FILTER_SIZE;
        private System.Windows.Forms.Label LB_ALIGN_LEAD_COUNT;
        private System.Windows.Forms.CheckBox CB_ALIGN_ROI_TRACKING;
        private System.Windows.Forms.Label lab_Edge_Polarty;
        private System.Windows.Forms.Label lab_EdgeThresHold;
        private System.Windows.Forms.Label lab_Filter_Size;
        private System.Windows.Forms.Label lab_AlignInspLeadCnt;
        private System.Windows.Forms.Label LB_ALIGN_EDGE_THRESHOLD;
    }
}