namespace COG.Controls
{
    partial class CtrlTeachMark
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
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTeachMark));
            this.tlpTeachMark = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMarkRegister = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTest = new System.Windows.Forms.TableLayoutPanel();
            this.btnAlignTest = new System.Windows.Forms.Button();
            this.btnMarkTest = new System.Windows.Forms.Button();
            this.tlpROI = new System.Windows.Forms.TableLayoutPanel();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnMarkROI = new System.Windows.Forms.Button();
            this.btnSetMark = new System.Windows.Forms.Button();
            this.btnSearchROI = new System.Windows.Forms.Button();
            this.btnMasking = new System.Windows.Forms.Button();
            this.lblMarkIndex = new System.Windows.Forms.Label();
            this.lblMainMark = new System.Windows.Forms.Label();
            this.pnlMainMark = new System.Windows.Forms.Panel();
            this.cogMarkDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.tlpMarkIndex = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSeperateMarkIndex = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSubMarkIndex = new System.Windows.Forms.TableLayoutPanel();
            this.btnSubMark2 = new System.Windows.Forms.Button();
            this.btnSubMark1 = new System.Windows.Forms.Button();
            this.btnSubMark3 = new System.Windows.Forms.Button();
            this.btnSubMark4 = new System.Windows.Forms.Button();
            this.pnlMainMarkIndex = new System.Windows.Forms.Panel();
            this.btnMainMark = new System.Windows.Forms.Button();
            this.tlpROIPosition = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMarkPosition = new System.Windows.Forms.Label();
            this.tlpMarkPosition = new System.Windows.Forms.TableLayoutPanel();
            this.rdoMarkRight = new System.Windows.Forms.RadioButton();
            this.rdoMarkLeft = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTargetObject = new System.Windows.Forms.Label();
            this.tlpTargetObject = new System.Windows.Forms.TableLayoutPanel();
            this.rdoPanel = new System.Windows.Forms.RadioButton();
            this.rdoFPC = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPreAlignLight = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLight = new System.Windows.Forms.TableLayoutPanel();
            this.lblLightOnOff = new System.Windows.Forms.Label();
            this.lblLightDimmingLevel = new System.Windows.Forms.Label();
            this.tlpLightDimmingLevel = new System.Windows.Forms.TableLayoutPanel();
            this.nudLightDimmingLevel = new System.Windows.Forms.NumericUpDown();
            this.pnlTrbDimmingLevelValue = new System.Windows.Forms.Panel();
            this.trbDimmingLevelValue = new System.Windows.Forms.TrackBar();
            this.tlpLightOnOff = new System.Windows.Forms.TableLayoutPanel();
            this.lblLightOff = new System.Windows.Forms.Button();
            this.lblLigntOn = new System.Windows.Forms.Button();
            this.lblLight = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tlpSpec = new System.Windows.Forms.TableLayoutPanel();
            this.tlpSpecData = new System.Windows.Forms.TableLayoutPanel();
            this.lblMarkScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblMarkAngleThreshold = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTeachMark.SuspendLayout();
            this.tlpMarkRegister.SuspendLayout();
            this.tlpTest.SuspendLayout();
            this.tlpROI.SuspendLayout();
            this.pnlMainMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogMarkDisplay)).BeginInit();
            this.tlpMarkIndex.SuspendLayout();
            this.tlpSeperateMarkIndex.SuspendLayout();
            this.tlpSubMarkIndex.SuspendLayout();
            this.pnlMainMarkIndex.SuspendLayout();
            this.tlpROIPosition.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpMarkPosition.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpTargetObject.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tlpPreAlignLight.SuspendLayout();
            this.tlpLight.SuspendLayout();
            this.tlpLightDimmingLevel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLightDimmingLevel)).BeginInit();
            this.pnlTrbDimmingLevelValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDimmingLevelValue)).BeginInit();
            this.tlpLightOnOff.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tlpSpec.SuspendLayout();
            this.tlpSpecData.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachMark
            // 
            this.tlpTeachMark.ColumnCount = 1;
            this.tlpTeachMark.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachMark.Controls.Add(this.tlpMarkRegister, 0, 3);
            this.tlpTeachMark.Controls.Add(this.tlpROIPosition, 0, 1);
            this.tlpTeachMark.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.tlpTeachMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachMark.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachMark.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachMark.Name = "tlpTeachMark";
            this.tlpTeachMark.RowCount = 7;
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMark.Size = new System.Drawing.Size(800, 900);
            this.tlpTeachMark.TabIndex = 285;
            // 
            // tlpMarkRegister
            // 
            this.tlpMarkRegister.ColumnCount = 2;
            this.tlpMarkRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkRegister.Controls.Add(this.tlpTest, 1, 2);
            this.tlpMarkRegister.Controls.Add(this.tlpROI, 0, 2);
            this.tlpMarkRegister.Controls.Add(this.lblMarkIndex, 0, 0);
            this.tlpMarkRegister.Controls.Add(this.lblMainMark, 1, 0);
            this.tlpMarkRegister.Controls.Add(this.pnlMainMark, 1, 1);
            this.tlpMarkRegister.Controls.Add(this.tlpMarkIndex, 0, 1);
            this.tlpMarkRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkRegister.Location = new System.Drawing.Point(0, 138);
            this.tlpMarkRegister.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkRegister.Name = "tlpMarkRegister";
            this.tlpMarkRegister.RowCount = 3;
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMarkRegister.Size = new System.Drawing.Size(800, 585);
            this.tlpMarkRegister.TabIndex = 284;
            // 
            // tlpTest
            // 
            this.tlpTest.ColumnCount = 3;
            this.tlpTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpTest.Controls.Add(this.btnAlignTest, 1, 1);
            this.tlpTest.Controls.Add(this.btnMarkTest, 2, 1);
            this.tlpTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTest.Location = new System.Drawing.Point(400, 363);
            this.tlpTest.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTest.Name = "tlpTest";
            this.tlpTest.RowCount = 2;
            this.tlpTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTest.Size = new System.Drawing.Size(400, 222);
            this.tlpTest.TabIndex = 185;
            // 
            // btnAlignTest
            // 
            this.btnAlignTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnAlignTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlignTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlignTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnAlignTest.Location = new System.Drawing.Point(136, 114);
            this.btnAlignTest.Name = "btnAlignTest";
            this.btnAlignTest.Size = new System.Drawing.Size(127, 105);
            this.btnAlignTest.TabIndex = 195;
            this.btnAlignTest.Text = "ALIGN TEST";
            this.btnAlignTest.UseVisualStyleBackColor = false;
            this.btnAlignTest.Click += new System.EventHandler(this.btnAlignTest_Click);
            // 
            // btnMarkTest
            // 
            this.btnMarkTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnMarkTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMarkTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMarkTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkTest.Location = new System.Drawing.Point(269, 114);
            this.btnMarkTest.Name = "btnMarkTest";
            this.btnMarkTest.Size = new System.Drawing.Size(128, 105);
            this.btnMarkTest.TabIndex = 195;
            this.btnMarkTest.Text = "MARK TEST";
            this.btnMarkTest.UseVisualStyleBackColor = false;
            this.btnMarkTest.Click += new System.EventHandler(this.btnMarkTest_Click);
            // 
            // tlpROI
            // 
            this.tlpROI.ColumnCount = 3;
            this.tlpROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tlpROI.Controls.Add(this.btnApply, 0, 1);
            this.tlpROI.Controls.Add(this.btnDelete, 1, 1);
            this.tlpROI.Controls.Add(this.btnMasking, 2, 1);
            this.tlpROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROI.Location = new System.Drawing.Point(0, 363);
            this.tlpROI.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROI.Name = "tlpROI";
            this.tlpROI.RowCount = 2;
            this.tlpROI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.Size = new System.Drawing.Size(400, 222);
            this.tlpROI.TabIndex = 188;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(3, 114);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(130, 105);
            this.btnApply.TabIndex = 192;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkGray;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(139, 114);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 105);
            this.btnDelete.TabIndex = 191;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnMarkROI
            // 
            this.btnMarkROI.BackColor = System.Drawing.Color.DarkGray;
            this.btnMarkROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMarkROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMarkROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMarkROI.Location = new System.Drawing.Point(3, 3);
            this.btnMarkROI.Name = "btnMarkROI";
            this.btnMarkROI.Size = new System.Drawing.Size(127, 108);
            this.btnMarkROI.TabIndex = 187;
            this.btnMarkROI.Text = "MARK ROI";
            this.btnMarkROI.UseVisualStyleBackColor = false;
            this.btnMarkROI.Click += new System.EventHandler(this.btnMarkROI_Click);
            // 
            // btnSetMark
            // 
            this.btnSetMark.BackColor = System.Drawing.Color.DarkGray;
            this.btnSetMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetMark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSetMark.Location = new System.Drawing.Point(136, 3);
            this.btnSetMark.Name = "btnSetMark";
            this.btnSetMark.Size = new System.Drawing.Size(127, 108);
            this.btnSetMark.TabIndex = 188;
            this.btnSetMark.Text = "SET MARK";
            this.btnSetMark.UseVisualStyleBackColor = false;
            this.btnSetMark.Click += new System.EventHandler(this.btnSetMark_Click);
            // 
            // btnSearchROI
            // 
            this.btnSearchROI.BackColor = System.Drawing.Color.DarkGray;
            this.btnSearchROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearchROI.Location = new System.Drawing.Point(269, 3);
            this.btnSearchROI.Name = "btnSearchROI";
            this.btnSearchROI.Size = new System.Drawing.Size(128, 108);
            this.btnSearchROI.TabIndex = 189;
            this.btnSearchROI.Text = "SEARCH ROI";
            this.btnSearchROI.UseVisualStyleBackColor = false;
            this.btnSearchROI.Click += new System.EventHandler(this.btnSearchROI_Click);
            // 
            // btnMasking
            // 
            this.btnMasking.BackColor = System.Drawing.Color.DarkGray;
            this.btnMasking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMasking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMasking.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMasking.Location = new System.Drawing.Point(271, 114);
            this.btnMasking.Name = "btnMasking";
            this.btnMasking.Size = new System.Drawing.Size(126, 105);
            this.btnMasking.TabIndex = 190;
            this.btnMasking.Text = "MASKING";
            this.btnMasking.UseVisualStyleBackColor = false;
            this.btnMasking.Click += new System.EventHandler(this.btnMasking_Click);
            // 
            // lblMarkIndex
            // 
            this.lblMarkIndex.BackColor = System.Drawing.Color.Silver;
            this.lblMarkIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkIndex.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblMarkIndex.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkIndex.Location = new System.Drawing.Point(1, 1);
            this.lblMarkIndex.Margin = new System.Windows.Forms.Padding(1);
            this.lblMarkIndex.Name = "lblMarkIndex";
            this.lblMarkIndex.Size = new System.Drawing.Size(398, 28);
            this.lblMarkIndex.TabIndex = 182;
            this.lblMarkIndex.Text = "MARK INDEX";
            this.lblMarkIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMainMark
            // 
            this.lblMainMark.BackColor = System.Drawing.Color.Silver;
            this.lblMainMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainMark.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblMainMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMainMark.Location = new System.Drawing.Point(401, 1);
            this.lblMainMark.Margin = new System.Windows.Forms.Padding(1);
            this.lblMainMark.Name = "lblMainMark";
            this.lblMainMark.Size = new System.Drawing.Size(398, 28);
            this.lblMainMark.TabIndex = 119;
            this.lblMainMark.Text = "REGISTERED MARK";
            this.lblMainMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainMark
            // 
            this.pnlMainMark.Controls.Add(this.cogMarkDisplay);
            this.pnlMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMark.Location = new System.Drawing.Point(403, 33);
            this.pnlMainMark.Name = "pnlMainMark";
            this.pnlMainMark.Size = new System.Drawing.Size(394, 327);
            this.pnlMainMark.TabIndex = 183;
            // 
            // cogMarkDisplay
            // 
            this.cogMarkDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogMarkDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogMarkDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogMarkDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogMarkDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogMarkDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogMarkDisplay.DoubleTapZoomCycleLength = 2;
            this.cogMarkDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogMarkDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogMarkDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogMarkDisplay.MouseWheelSensitivity = 1D;
            this.cogMarkDisplay.Name = "cogMarkDisplay";
            this.cogMarkDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogMarkDisplay.OcxState")));
            this.cogMarkDisplay.Size = new System.Drawing.Size(394, 327);
            this.cogMarkDisplay.TabIndex = 0;
            // 
            // tlpMarkIndex
            // 
            this.tlpMarkIndex.ColumnCount = 1;
            this.tlpMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMarkIndex.Controls.Add(this.tlpSeperateMarkIndex, 0, 0);
            this.tlpMarkIndex.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tlpMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkIndex.Location = new System.Drawing.Point(0, 30);
            this.tlpMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkIndex.Name = "tlpMarkIndex";
            this.tlpMarkIndex.RowCount = 2;
            this.tlpMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66F));
            this.tlpMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tlpMarkIndex.Size = new System.Drawing.Size(400, 333);
            this.tlpMarkIndex.TabIndex = 187;
            // 
            // tlpSeperateMarkIndex
            // 
            this.tlpSeperateMarkIndex.ColumnCount = 2;
            this.tlpSeperateMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSeperateMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpSeperateMarkIndex.Controls.Add(this.tlpSubMarkIndex, 1, 0);
            this.tlpSeperateMarkIndex.Controls.Add(this.pnlMainMarkIndex, 0, 0);
            this.tlpSeperateMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSeperateMarkIndex.Location = new System.Drawing.Point(0, 0);
            this.tlpSeperateMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSeperateMarkIndex.Name = "tlpSeperateMarkIndex";
            this.tlpSeperateMarkIndex.RowCount = 1;
            this.tlpSeperateMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSeperateMarkIndex.Size = new System.Drawing.Size(400, 219);
            this.tlpSeperateMarkIndex.TabIndex = 187;
            // 
            // tlpSubMarkIndex
            // 
            this.tlpSubMarkIndex.ColumnCount = 2;
            this.tlpSubMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.Controls.Add(this.btnSubMark2, 1, 0);
            this.tlpSubMarkIndex.Controls.Add(this.btnSubMark1, 0, 0);
            this.tlpSubMarkIndex.Controls.Add(this.btnSubMark3, 0, 1);
            this.tlpSubMarkIndex.Controls.Add(this.btnSubMark4, 1, 1);
            this.tlpSubMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSubMarkIndex.Location = new System.Drawing.Point(133, 0);
            this.tlpSubMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSubMarkIndex.Name = "tlpSubMarkIndex";
            this.tlpSubMarkIndex.RowCount = 2;
            this.tlpSubMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.Size = new System.Drawing.Size(267, 219);
            this.tlpSubMarkIndex.TabIndex = 0;
            // 
            // btnSubMark2
            // 
            this.btnSubMark2.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubMark2.Location = new System.Drawing.Point(136, 3);
            this.btnSubMark2.Name = "btnSubMark2";
            this.btnSubMark2.Size = new System.Drawing.Size(128, 103);
            this.btnSubMark2.TabIndex = 184;
            this.btnSubMark2.Tag = "2";
            this.btnSubMark2.Text = "SUB 2";
            this.btnSubMark2.UseVisualStyleBackColor = false;
            this.btnSubMark2.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark1
            // 
            this.btnSubMark1.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubMark1.Location = new System.Drawing.Point(3, 3);
            this.btnSubMark1.Name = "btnSubMark1";
            this.btnSubMark1.Size = new System.Drawing.Size(127, 103);
            this.btnSubMark1.TabIndex = 183;
            this.btnSubMark1.Tag = "1";
            this.btnSubMark1.Text = "SUB 1";
            this.btnSubMark1.UseVisualStyleBackColor = false;
            this.btnSubMark1.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark3
            // 
            this.btnSubMark3.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubMark3.Location = new System.Drawing.Point(3, 112);
            this.btnSubMark3.Name = "btnSubMark3";
            this.btnSubMark3.Size = new System.Drawing.Size(127, 104);
            this.btnSubMark3.TabIndex = 185;
            this.btnSubMark3.Tag = "3";
            this.btnSubMark3.Text = "SUB 3";
            this.btnSubMark3.UseVisualStyleBackColor = false;
            this.btnSubMark3.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark4
            // 
            this.btnSubMark4.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubMark4.Location = new System.Drawing.Point(136, 112);
            this.btnSubMark4.Name = "btnSubMark4";
            this.btnSubMark4.Size = new System.Drawing.Size(128, 104);
            this.btnSubMark4.TabIndex = 186;
            this.btnSubMark4.Tag = "4";
            this.btnSubMark4.Text = "SUB 4";
            this.btnSubMark4.UseVisualStyleBackColor = false;
            this.btnSubMark4.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // pnlMainMarkIndex
            // 
            this.pnlMainMarkIndex.Controls.Add(this.btnMainMark);
            this.pnlMainMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMarkIndex.Location = new System.Drawing.Point(0, 0);
            this.pnlMainMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMainMarkIndex.Name = "pnlMainMarkIndex";
            this.pnlMainMarkIndex.Size = new System.Drawing.Size(133, 219);
            this.pnlMainMarkIndex.TabIndex = 1;
            // 
            // btnMainMark
            // 
            this.btnMainMark.BackColor = System.Drawing.Color.DarkGray;
            this.btnMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainMark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMainMark.Location = new System.Drawing.Point(0, 0);
            this.btnMainMark.Name = "btnMainMark";
            this.btnMainMark.Size = new System.Drawing.Size(133, 219);
            this.btnMainMark.TabIndex = 181;
            this.btnMainMark.Tag = "0";
            this.btnMainMark.Text = "MAIN";
            this.btnMainMark.UseVisualStyleBackColor = false;
            this.btnMainMark.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // tlpROIPosition
            // 
            this.tlpROIPosition.ColumnCount = 2;
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROIPosition.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpROIPosition.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tlpROIPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROIPosition.Location = new System.Drawing.Point(0, 30);
            this.tlpROIPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROIPosition.Name = "tlpROIPosition";
            this.tlpROIPosition.RowCount = 1;
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlpROIPosition.Size = new System.Drawing.Size(800, 78);
            this.tlpROIPosition.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblMarkPosition, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlpMarkPosition, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(400, 78);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblMarkPosition
            // 
            this.lblMarkPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkPosition.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblMarkPosition.Location = new System.Drawing.Point(0, 0);
            this.lblMarkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblMarkPosition.Name = "lblMarkPosition";
            this.lblMarkPosition.Size = new System.Drawing.Size(400, 30);
            this.lblMarkPosition.TabIndex = 141;
            this.lblMarkPosition.Text = "MARK POSITION";
            this.lblMarkPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMarkPosition
            // 
            this.tlpMarkPosition.ColumnCount = 2;
            this.tlpMarkPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkPosition.Controls.Add(this.rdoMarkRight, 0, 0);
            this.tlpMarkPosition.Controls.Add(this.rdoMarkLeft, 0, 0);
            this.tlpMarkPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkPosition.Location = new System.Drawing.Point(0, 30);
            this.tlpMarkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkPosition.Name = "tlpMarkPosition";
            this.tlpMarkPosition.RowCount = 1;
            this.tlpMarkPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkPosition.Size = new System.Drawing.Size(400, 48);
            this.tlpMarkPosition.TabIndex = 0;
            // 
            // rdoMarkRight
            // 
            this.rdoMarkRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMarkRight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMarkRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMarkRight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMarkRight.ForeColor = System.Drawing.Color.Black;
            this.rdoMarkRight.Location = new System.Drawing.Point(200, 0);
            this.rdoMarkRight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMarkRight.Name = "rdoMarkRight";
            this.rdoMarkRight.Size = new System.Drawing.Size(200, 48);
            this.rdoMarkRight.TabIndex = 142;
            this.rdoMarkRight.Tag = "0";
            this.rdoMarkRight.Text = "RIGHT MARK";
            this.rdoMarkRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMarkRight.UseVisualStyleBackColor = false;
            this.rdoMarkRight.CheckedChanged += new System.EventHandler(this.rdoSetMarkPosition_CheckedChanged);
            // 
            // rdoMarkLeft
            // 
            this.rdoMarkLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMarkLeft.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMarkLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMarkLeft.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMarkLeft.ForeColor = System.Drawing.Color.Black;
            this.rdoMarkLeft.Location = new System.Drawing.Point(0, 0);
            this.rdoMarkLeft.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMarkLeft.Name = "rdoMarkLeft";
            this.rdoMarkLeft.Size = new System.Drawing.Size(200, 48);
            this.rdoMarkLeft.TabIndex = 141;
            this.rdoMarkLeft.Tag = "0";
            this.rdoMarkLeft.Text = "LEFT MARK";
            this.rdoMarkLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMarkLeft.UseVisualStyleBackColor = false;
            this.rdoMarkLeft.CheckedChanged += new System.EventHandler(this.rdoSetMarkPosition_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblTargetObject, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tlpTargetObject, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(400, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(400, 78);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblTargetObject
            // 
            this.lblTargetObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetObject.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblTargetObject.Location = new System.Drawing.Point(0, 0);
            this.lblTargetObject.Margin = new System.Windows.Forms.Padding(0);
            this.lblTargetObject.Name = "lblTargetObject";
            this.lblTargetObject.Size = new System.Drawing.Size(400, 30);
            this.lblTargetObject.TabIndex = 150;
            this.lblTargetObject.Text = "TARGET OBJECT";
            this.lblTargetObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpTargetObject
            // 
            this.tlpTargetObject.ColumnCount = 2;
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.Controls.Add(this.rdoPanel, 0, 0);
            this.tlpTargetObject.Controls.Add(this.rdoFPC, 0, 0);
            this.tlpTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTargetObject.Location = new System.Drawing.Point(0, 30);
            this.tlpTargetObject.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTargetObject.Name = "tlpTargetObject";
            this.tlpTargetObject.RowCount = 1;
            this.tlpTargetObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.Size = new System.Drawing.Size(400, 48);
            this.tlpTargetObject.TabIndex = 1;
            // 
            // rdoPanel
            // 
            this.rdoPanel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoPanel.BackColor = System.Drawing.Color.DarkGray;
            this.rdoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoPanel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoPanel.ForeColor = System.Drawing.Color.Black;
            this.rdoPanel.Location = new System.Drawing.Point(200, 0);
            this.rdoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rdoPanel.Name = "rdoPanel";
            this.rdoPanel.Size = new System.Drawing.Size(200, 48);
            this.rdoPanel.TabIndex = 143;
            this.rdoPanel.Tag = "0";
            this.rdoPanel.Text = "PANEL";
            this.rdoPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoPanel.UseVisualStyleBackColor = false;
            this.rdoPanel.CheckedChanged += new System.EventHandler(this.rdoSetTargetObject_CheckedChanged);
            // 
            // rdoFPC
            // 
            this.rdoFPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoFPC.BackColor = System.Drawing.Color.DarkGray;
            this.rdoFPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoFPC.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoFPC.ForeColor = System.Drawing.Color.Black;
            this.rdoFPC.Location = new System.Drawing.Point(0, 0);
            this.rdoFPC.Margin = new System.Windows.Forms.Padding(0);
            this.rdoFPC.Name = "rdoFPC";
            this.rdoFPC.Size = new System.Drawing.Size(200, 48);
            this.rdoFPC.TabIndex = 142;
            this.rdoFPC.Tag = "0";
            this.rdoFPC.Text = "FPC";
            this.rdoFPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoFPC.UseVisualStyleBackColor = false;
            this.rdoFPC.CheckedChanged += new System.EventHandler(this.rdoSetTargetObject_CheckedChanged);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tlpPreAlignLight, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 753);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(800, 117);
            this.tableLayoutPanel6.TabIndex = 286;
            // 
            // tlpPreAlignLight
            // 
            this.tlpPreAlignLight.ColumnCount = 1;
            this.tlpPreAlignLight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreAlignLight.Controls.Add(this.tlpLight, 0, 1);
            this.tlpPreAlignLight.Controls.Add(this.lblLight, 0, 0);
            this.tlpPreAlignLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreAlignLight.Location = new System.Drawing.Point(415, 0);
            this.tlpPreAlignLight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPreAlignLight.Name = "tlpPreAlignLight";
            this.tlpPreAlignLight.RowCount = 2;
            this.tlpPreAlignLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPreAlignLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreAlignLight.Size = new System.Drawing.Size(385, 117);
            this.tlpPreAlignLight.TabIndex = 296;
            // 
            // tlpLight
            // 
            this.tlpLight.ColumnCount = 2;
            this.tlpLight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLight.Controls.Add(this.lblLightOnOff, 0, 1);
            this.tlpLight.Controls.Add(this.lblLightDimmingLevel, 0, 0);
            this.tlpLight.Controls.Add(this.tlpLightDimmingLevel, 1, 0);
            this.tlpLight.Controls.Add(this.tlpLightOnOff, 1, 1);
            this.tlpLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLight.Location = new System.Drawing.Point(0, 30);
            this.tlpLight.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLight.Name = "tlpLight";
            this.tlpLight.RowCount = 2;
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLight.Size = new System.Drawing.Size(385, 87);
            this.tlpLight.TabIndex = 300;
            // 
            // lblLightOnOff
            // 
            this.lblLightOnOff.BackColor = System.Drawing.Color.DarkGray;
            this.lblLightOnOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLightOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightOnOff.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLightOnOff.Location = new System.Drawing.Point(0, 43);
            this.lblLightOnOff.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightOnOff.Name = "lblLightOnOff";
            this.lblLightOnOff.Size = new System.Drawing.Size(192, 44);
            this.lblLightOnOff.TabIndex = 150;
            this.lblLightOnOff.Text = "ON / OFF";
            this.lblLightOnOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLightDimmingLevel
            // 
            this.lblLightDimmingLevel.BackColor = System.Drawing.Color.DarkGray;
            this.lblLightDimmingLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLightDimmingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightDimmingLevel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLightDimmingLevel.Location = new System.Drawing.Point(0, 0);
            this.lblLightDimmingLevel.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightDimmingLevel.Name = "lblLightDimmingLevel";
            this.lblLightDimmingLevel.Size = new System.Drawing.Size(192, 43);
            this.lblLightDimmingLevel.TabIndex = 146;
            this.lblLightDimmingLevel.Text = "LIGHT [0~255]";
            this.lblLightDimmingLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLightDimmingLevel
            // 
            this.tlpLightDimmingLevel.ColumnCount = 2;
            this.tlpLightDimmingLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpLightDimmingLevel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLightDimmingLevel.Controls.Add(this.nudLightDimmingLevel, 0, 0);
            this.tlpLightDimmingLevel.Controls.Add(this.pnlTrbDimmingLevelValue, 0, 0);
            this.tlpLightDimmingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightDimmingLevel.Location = new System.Drawing.Point(192, 0);
            this.tlpLightDimmingLevel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightDimmingLevel.Name = "tlpLightDimmingLevel";
            this.tlpLightDimmingLevel.RowCount = 1;
            this.tlpLightDimmingLevel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLightDimmingLevel.Size = new System.Drawing.Size(193, 43);
            this.tlpLightDimmingLevel.TabIndex = 5;
            // 
            // nudLightDimmingLevel
            // 
            this.nudLightDimmingLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudLightDimmingLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudLightDimmingLevel.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.nudLightDimmingLevel.Location = new System.Drawing.Point(138, 6);
            this.nudLightDimmingLevel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.nudLightDimmingLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudLightDimmingLevel.Name = "nudLightDimmingLevel";
            this.nudLightDimmingLevel.Size = new System.Drawing.Size(52, 27);
            this.nudLightDimmingLevel.TabIndex = 210;
            this.nudLightDimmingLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudLightDimmingLevel.ValueChanged += new System.EventHandler(this.nudLightDimmingLevel_ValueChanged);
            // 
            // pnlTrbDimmingLevelValue
            // 
            this.pnlTrbDimmingLevelValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrbDimmingLevelValue.Controls.Add(this.trbDimmingLevelValue);
            this.pnlTrbDimmingLevelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrbDimmingLevelValue.Location = new System.Drawing.Point(9, 3);
            this.pnlTrbDimmingLevelValue.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.pnlTrbDimmingLevelValue.Name = "pnlTrbDimmingLevelValue";
            this.pnlTrbDimmingLevelValue.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.pnlTrbDimmingLevelValue.Size = new System.Drawing.Size(123, 37);
            this.pnlTrbDimmingLevelValue.TabIndex = 209;
            // 
            // trbDimmingLevelValue
            // 
            this.trbDimmingLevelValue.BackColor = System.Drawing.Color.Silver;
            this.trbDimmingLevelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbDimmingLevelValue.Location = new System.Drawing.Point(0, 9);
            this.trbDimmingLevelValue.Margin = new System.Windows.Forms.Padding(0);
            this.trbDimmingLevelValue.Maximum = 255;
            this.trbDimmingLevelValue.Name = "trbDimmingLevelValue";
            this.trbDimmingLevelValue.Size = new System.Drawing.Size(121, 26);
            this.trbDimmingLevelValue.TabIndex = 208;
            this.trbDimmingLevelValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbDimmingLevelValue.Scroll += new System.EventHandler(this.trbDimmingLevelValue_Scroll);
            // 
            // tlpLightOnOff
            // 
            this.tlpLightOnOff.ColumnCount = 2;
            this.tlpLightOnOff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightOnOff.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightOnOff.Controls.Add(this.lblLightOff, 0, 0);
            this.tlpLightOnOff.Controls.Add(this.lblLigntOn, 0, 0);
            this.tlpLightOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLightOnOff.Location = new System.Drawing.Point(192, 43);
            this.tlpLightOnOff.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLightOnOff.Name = "tlpLightOnOff";
            this.tlpLightOnOff.RowCount = 1;
            this.tlpLightOnOff.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLightOnOff.Size = new System.Drawing.Size(193, 44);
            this.tlpLightOnOff.TabIndex = 149;
            // 
            // lblLightOff
            // 
            this.lblLightOff.BackColor = System.Drawing.Color.DarkGray;
            this.lblLightOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLightOff.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLightOff.Location = new System.Drawing.Point(96, 0);
            this.lblLightOff.Margin = new System.Windows.Forms.Padding(0);
            this.lblLightOff.Name = "lblLightOff";
            this.lblLightOff.Size = new System.Drawing.Size(97, 44);
            this.lblLightOff.TabIndex = 152;
            this.lblLightOff.Text = "OFF";
            this.lblLightOff.UseVisualStyleBackColor = false;
            this.lblLightOff.Click += new System.EventHandler(this.lblLigntOff_Click);
            // 
            // lblLigntOn
            // 
            this.lblLigntOn.BackColor = System.Drawing.Color.DarkGray;
            this.lblLigntOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLigntOn.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLigntOn.Location = new System.Drawing.Point(0, 0);
            this.lblLigntOn.Margin = new System.Windows.Forms.Padding(0);
            this.lblLigntOn.Name = "lblLigntOn";
            this.lblLigntOn.Size = new System.Drawing.Size(96, 44);
            this.lblLigntOn.TabIndex = 151;
            this.lblLigntOn.Text = "ON";
            this.lblLigntOn.UseVisualStyleBackColor = false;
            this.lblLigntOn.Click += new System.EventHandler(this.lblLigntOn_Click);
            // 
            // lblLight
            // 
            this.lblLight.BackColor = System.Drawing.Color.Silver;
            this.lblLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLight.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblLight.ForeColor = System.Drawing.Color.Black;
            this.lblLight.Location = new System.Drawing.Point(0, 0);
            this.lblLight.Margin = new System.Windows.Forms.Padding(0);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(385, 30);
            this.lblLight.TabIndex = 299;
            this.lblLight.Text = "LIGHT";
            this.lblLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tlpSpec, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(385, 117);
            this.tableLayoutPanel5.TabIndex = 297;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 30);
            this.label1.TabIndex = 300;
            this.label1.Text = "SPEC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSpec
            // 
            this.tlpSpec.ColumnCount = 1;
            this.tlpSpec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSpec.Controls.Add(this.tlpSpecData, 0, 0);
            this.tlpSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpec.Location = new System.Drawing.Point(0, 30);
            this.tlpSpec.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSpec.Name = "tlpSpec";
            this.tlpSpec.RowCount = 1;
            this.tlpSpec.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpec.Size = new System.Drawing.Size(385, 87);
            this.tlpSpec.TabIndex = 190;
            // 
            // tlpSpecData
            // 
            this.tlpSpecData.ColumnCount = 2;
            this.tlpSpecData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.Controls.Add(this.lblMarkScore, 1, 0);
            this.tlpSpecData.Controls.Add(this.lblScore, 0, 0);
            this.tlpSpecData.Controls.Add(this.lblAngle, 0, 1);
            this.tlpSpecData.Controls.Add(this.lblMarkAngleThreshold, 1, 1);
            this.tlpSpecData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpecData.Location = new System.Drawing.Point(0, 0);
            this.tlpSpecData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSpecData.Name = "tlpSpecData";
            this.tlpSpecData.RowCount = 2;
            this.tlpSpecData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.Size = new System.Drawing.Size(385, 87);
            this.tlpSpecData.TabIndex = 62;
            // 
            // lblMarkScore
            // 
            this.lblMarkScore.BackColor = System.Drawing.Color.White;
            this.lblMarkScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMarkScore.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMarkScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkScore.Location = new System.Drawing.Point(192, 0);
            this.lblMarkScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblMarkScore.Name = "lblMarkScore";
            this.lblMarkScore.Size = new System.Drawing.Size(193, 43);
            this.lblMarkScore.TabIndex = 261;
            this.lblMarkScore.Text = "80";
            this.lblMarkScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkScore.Click += new System.EventHandler(this.lblMarkScore_Click);
            // 
            // lblScore
            // 
            this.lblScore.BackColor = System.Drawing.Color.DarkGray;
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(0, 0);
            this.lblScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(192, 43);
            this.lblScore.TabIndex = 61;
            this.lblScore.Text = "SCORE [%]";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngle
            // 
            this.lblAngle.BackColor = System.Drawing.Color.DarkGray;
            this.lblAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAngle.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAngle.Location = new System.Drawing.Point(0, 43);
            this.lblAngle.Margin = new System.Windows.Forms.Padding(0);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(192, 44);
            this.lblAngle.TabIndex = 194;
            this.lblAngle.Text = "ANGLE MAX";
            this.lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkAngleThreshold
            // 
            this.lblMarkAngleThreshold.BackColor = System.Drawing.Color.White;
            this.lblMarkAngleThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkAngleThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkAngleThreshold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMarkAngleThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMarkAngleThreshold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkAngleThreshold.Location = new System.Drawing.Point(192, 43);
            this.lblMarkAngleThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblMarkAngleThreshold.Name = "lblMarkAngleThreshold";
            this.lblMarkAngleThreshold.Size = new System.Drawing.Size(193, 44);
            this.lblMarkAngleThreshold.TabIndex = 261;
            this.lblMarkAngleThreshold.Text = "0.1";
            this.lblMarkAngleThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkAngleThreshold.Click += new System.EventHandler(this.lblMarkAngleThreshold_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnMarkROI, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSetMark, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSearchROI, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 219);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 114);
            this.tableLayoutPanel1.TabIndex = 188;
            // 
            // CtrlTeachMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeachMark);
            this.Name = "CtrlTeachMark";
            this.Size = new System.Drawing.Size(800, 900);
            this.Load += new System.EventHandler(this.CtrlTeachMark_Load);
            this.tlpTeachMark.ResumeLayout(false);
            this.tlpMarkRegister.ResumeLayout(false);
            this.tlpTest.ResumeLayout(false);
            this.tlpROI.ResumeLayout(false);
            this.pnlMainMark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogMarkDisplay)).EndInit();
            this.tlpMarkIndex.ResumeLayout(false);
            this.tlpSeperateMarkIndex.ResumeLayout(false);
            this.tlpSubMarkIndex.ResumeLayout(false);
            this.pnlMainMarkIndex.ResumeLayout(false);
            this.tlpROIPosition.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpMarkPosition.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tlpTargetObject.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tlpPreAlignLight.ResumeLayout(false);
            this.tlpLight.ResumeLayout(false);
            this.tlpLightDimmingLevel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLightDimmingLevel)).EndInit();
            this.pnlTrbDimmingLevelValue.ResumeLayout(false);
            this.pnlTrbDimmingLevelValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDimmingLevelValue)).EndInit();
            this.tlpLightOnOff.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tlpSpec.ResumeLayout(false);
            this.tlpSpecData.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeachMark;
        private System.Windows.Forms.TableLayoutPanel tlpMarkRegister;
        private System.Windows.Forms.Label lblMarkIndex;
        private System.Windows.Forms.Label lblMainMark;
        private System.Windows.Forms.Panel pnlMainMark;
        private Cognex.VisionPro.Display.CogDisplay cogMarkDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpMarkIndex;
        private System.Windows.Forms.TableLayoutPanel tlpSeperateMarkIndex;
        private System.Windows.Forms.TableLayoutPanel tlpSubMarkIndex;
        private System.Windows.Forms.Button btnSubMark2;
        private System.Windows.Forms.Button btnSubMark1;
        private System.Windows.Forms.Button btnSubMark3;
        private System.Windows.Forms.Button btnSubMark4;
        private System.Windows.Forms.Panel pnlMainMarkIndex;
        private System.Windows.Forms.Button btnMainMark;
        private System.Windows.Forms.TableLayoutPanel tlpROI;
        private System.Windows.Forms.Button btnMarkROI;
        private System.Windows.Forms.Button btnSetMark;
        private System.Windows.Forms.Button btnSearchROI;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tlpTest;
        private System.Windows.Forms.Button btnAlignTest;
        private System.Windows.Forms.Button btnMarkTest;
        private System.Windows.Forms.TableLayoutPanel tlpSpec;
        private System.Windows.Forms.TableLayoutPanel tlpSpecData;
        private System.Windows.Forms.Label lblMarkScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblMarkAngleThreshold;
        private System.Windows.Forms.TableLayoutPanel tlpROIPosition;
        private System.Windows.Forms.TableLayoutPanel tlpMarkPosition;
        private System.Windows.Forms.RadioButton rdoMarkRight;
        private System.Windows.Forms.RadioButton rdoMarkLeft;
        private System.Windows.Forms.TableLayoutPanel tlpTargetObject;
        private System.Windows.Forms.RadioButton rdoPanel;
        private System.Windows.Forms.RadioButton rdoFPC;
        private System.Windows.Forms.Button btnMasking;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMarkPosition;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblTargetObject;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tlpPreAlignLight;
        private System.Windows.Forms.TableLayoutPanel tlpLight;
        private System.Windows.Forms.Label lblLightOnOff;
        private System.Windows.Forms.Label lblLightDimmingLevel;
        private System.Windows.Forms.TableLayoutPanel tlpLightDimmingLevel;
        private System.Windows.Forms.NumericUpDown nudLightDimmingLevel;
        private System.Windows.Forms.Panel pnlTrbDimmingLevelValue;
        private System.Windows.Forms.TrackBar trbDimmingLevelValue;
        private System.Windows.Forms.TableLayoutPanel tlpLightOnOff;
        private System.Windows.Forms.Button lblLightOff;
        private System.Windows.Forms.Button lblLigntOn;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
