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
            this.tlpSave = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.tlpROI = new System.Windows.Forms.TableLayoutPanel();
            this.btnMarkROI = new System.Windows.Forms.Button();
            this.btnSetMark = new System.Windows.Forms.Button();
            this.btnSearchROI = new System.Windows.Forms.Button();
            this.btnMasking = new System.Windows.Forms.Button();
            this.tlpApply = new System.Windows.Forms.TableLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.tlpTest = new System.Windows.Forms.TableLayoutPanel();
            this.btnAlignTest = new System.Windows.Forms.Button();
            this.btnMarkTest = new System.Windows.Forms.Button();
            this.tlpSpec = new System.Windows.Forms.TableLayoutPanel();
            this.lblSpec = new System.Windows.Forms.Label();
            this.tlpSpecData = new System.Windows.Forms.TableLayoutPanel();
            this.lblMarkScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.lblMarkAngleThreshold = new System.Windows.Forms.Label();
            this.tlpROIPosition = new System.Windows.Forms.TableLayoutPanel();
            this.lblTargetObject = new System.Windows.Forms.Label();
            this.lblMarkPosition = new System.Windows.Forms.Label();
            this.tlpMarkPosition = new System.Windows.Forms.TableLayoutPanel();
            this.rdoMarkRight = new System.Windows.Forms.RadioButton();
            this.rdoMarkLeft = new System.Windows.Forms.RadioButton();
            this.tlpTargetObject = new System.Windows.Forms.TableLayoutPanel();
            this.rdoPanel = new System.Windows.Forms.RadioButton();
            this.rdoFPC = new System.Windows.Forms.RadioButton();
            this.tlpROIJog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlROIJog = new System.Windows.Forms.Panel();
            this.tlpShowROIJog = new System.Windows.Forms.TableLayoutPanel();
            this.chkShowROIJog = new System.Windows.Forms.CheckBox();
            this.tlpTeachMark.SuspendLayout();
            this.tlpMarkRegister.SuspendLayout();
            this.tlpSave.SuspendLayout();
            this.pnlMainMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogMarkDisplay)).BeginInit();
            this.tlpMarkIndex.SuspendLayout();
            this.tlpSeperateMarkIndex.SuspendLayout();
            this.tlpSubMarkIndex.SuspendLayout();
            this.pnlMainMarkIndex.SuspendLayout();
            this.tlpROI.SuspendLayout();
            this.tlpApply.SuspendLayout();
            this.tlpTest.SuspendLayout();
            this.tlpSpec.SuspendLayout();
            this.tlpSpecData.SuspendLayout();
            this.tlpROIPosition.SuspendLayout();
            this.tlpMarkPosition.SuspendLayout();
            this.tlpTargetObject.SuspendLayout();
            this.tlpROIJog.SuspendLayout();
            this.tlpShowROIJog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachMark
            // 
            this.tlpTeachMark.ColumnCount = 1;
            this.tlpTeachMark.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachMark.Controls.Add(this.tlpMarkRegister, 0, 1);
            this.tlpTeachMark.Controls.Add(this.tlpROIPosition, 0, 0);
            this.tlpTeachMark.Controls.Add(this.tlpROIJog, 0, 2);
            this.tlpTeachMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachMark.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachMark.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachMark.Name = "tlpTeachMark";
            this.tlpTeachMark.RowCount = 3;
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpTeachMark.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTeachMark.Size = new System.Drawing.Size(800, 700);
            this.tlpTeachMark.TabIndex = 285;
            // 
            // tlpMarkRegister
            // 
            this.tlpMarkRegister.ColumnCount = 2;
            this.tlpMarkRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkRegister.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkRegister.Controls.Add(this.tlpSave, 1, 3);
            this.tlpMarkRegister.Controls.Add(this.lblMarkIndex, 0, 0);
            this.tlpMarkRegister.Controls.Add(this.lblMainMark, 1, 0);
            this.tlpMarkRegister.Controls.Add(this.pnlMainMark, 1, 1);
            this.tlpMarkRegister.Controls.Add(this.tlpMarkIndex, 0, 1);
            this.tlpMarkRegister.Controls.Add(this.tlpApply, 0, 2);
            this.tlpMarkRegister.Controls.Add(this.tlpTest, 1, 2);
            this.tlpMarkRegister.Controls.Add(this.tlpSpec, 0, 3);
            this.tlpMarkRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkRegister.Location = new System.Drawing.Point(0, 105);
            this.tlpMarkRegister.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkRegister.Name = "tlpMarkRegister";
            this.tlpMarkRegister.RowCount = 4;
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMarkRegister.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMarkRegister.Size = new System.Drawing.Size(800, 385);
            this.tlpMarkRegister.TabIndex = 284;
            // 
            // tlpSave
            // 
            this.tlpSave.ColumnCount = 2;
            this.tlpSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSave.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSave.Controls.Add(this.btnSave, 1, 0);
            this.tlpSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSave.Location = new System.Drawing.Point(400, 316);
            this.tlpSave.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSave.Name = "tlpSave";
            this.tlpSave.RowCount = 1;
            this.tlpSave.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSave.Size = new System.Drawing.Size(400, 69);
            this.tlpSave.TabIndex = 189;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::COG.Properties.Resources.SAVE1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(203, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(194, 63);
            this.btnSave.TabIndex = 196;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblMarkIndex
            // 
            this.lblMarkIndex.BackColor = System.Drawing.Color.Black;
            this.lblMarkIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkIndex.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lblMarkIndex.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMarkIndex.Location = new System.Drawing.Point(1, 1);
            this.lblMarkIndex.Margin = new System.Windows.Forms.Padding(1);
            this.lblMarkIndex.Name = "lblMarkIndex";
            this.lblMarkIndex.Size = new System.Drawing.Size(398, 38);
            this.lblMarkIndex.TabIndex = 182;
            this.lblMarkIndex.Text = "Mark Index";
            this.lblMarkIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMainMark
            // 
            this.lblMainMark.BackColor = System.Drawing.Color.Black;
            this.lblMainMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMainMark.Font = new System.Drawing.Font("맑은 고딕", 13F, System.Drawing.FontStyle.Bold);
            this.lblMainMark.ForeColor = System.Drawing.SystemColors.Control;
            this.lblMainMark.Location = new System.Drawing.Point(401, 1);
            this.lblMainMark.Margin = new System.Windows.Forms.Padding(1);
            this.lblMainMark.Name = "lblMainMark";
            this.lblMainMark.Size = new System.Drawing.Size(398, 38);
            this.lblMainMark.TabIndex = 119;
            this.lblMainMark.Text = "Main Mark";
            this.lblMainMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainMark
            // 
            this.pnlMainMark.Controls.Add(this.cogMarkDisplay);
            this.pnlMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainMark.Location = new System.Drawing.Point(403, 43);
            this.pnlMainMark.Name = "pnlMainMark";
            this.pnlMainMark.Size = new System.Drawing.Size(394, 201);
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
            this.cogMarkDisplay.Size = new System.Drawing.Size(394, 201);
            this.cogMarkDisplay.TabIndex = 0;
            // 
            // tlpMarkIndex
            // 
            this.tlpMarkIndex.ColumnCount = 1;
            this.tlpMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkIndex.Controls.Add(this.tlpSeperateMarkIndex, 0, 0);
            this.tlpMarkIndex.Controls.Add(this.tlpROI, 0, 1);
            this.tlpMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkIndex.Location = new System.Drawing.Point(0, 40);
            this.tlpMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkIndex.Name = "tlpMarkIndex";
            this.tlpMarkIndex.RowCount = 2;
            this.tlpMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkIndex.Size = new System.Drawing.Size(400, 207);
            this.tlpMarkIndex.TabIndex = 187;
            // 
            // tlpSeperateMarkIndex
            // 
            this.tlpSeperateMarkIndex.ColumnCount = 2;
            this.tlpSeperateMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpSeperateMarkIndex.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpSeperateMarkIndex.Controls.Add(this.tlpSubMarkIndex, 1, 0);
            this.tlpSeperateMarkIndex.Controls.Add(this.pnlMainMarkIndex, 0, 0);
            this.tlpSeperateMarkIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSeperateMarkIndex.Location = new System.Drawing.Point(0, 0);
            this.tlpSeperateMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSeperateMarkIndex.Name = "tlpSeperateMarkIndex";
            this.tlpSeperateMarkIndex.RowCount = 1;
            this.tlpSeperateMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSeperateMarkIndex.Size = new System.Drawing.Size(400, 103);
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
            this.tlpSubMarkIndex.Location = new System.Drawing.Point(160, 0);
            this.tlpSubMarkIndex.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSubMarkIndex.Name = "tlpSubMarkIndex";
            this.tlpSubMarkIndex.RowCount = 2;
            this.tlpSubMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSubMarkIndex.Size = new System.Drawing.Size(240, 103);
            this.tlpSubMarkIndex.TabIndex = 0;
            // 
            // btnSubMark2
            // 
            this.btnSubMark2.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubMark2.Location = new System.Drawing.Point(123, 3);
            this.btnSubMark2.Name = "btnSubMark2";
            this.btnSubMark2.Size = new System.Drawing.Size(114, 45);
            this.btnSubMark2.TabIndex = 184;
            this.btnSubMark2.Tag = "2";
            this.btnSubMark2.Text = "2";
            this.btnSubMark2.UseVisualStyleBackColor = false;
            this.btnSubMark2.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark1
            // 
            this.btnSubMark1.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubMark1.Location = new System.Drawing.Point(3, 3);
            this.btnSubMark1.Name = "btnSubMark1";
            this.btnSubMark1.Size = new System.Drawing.Size(114, 45);
            this.btnSubMark1.TabIndex = 183;
            this.btnSubMark1.Tag = "1";
            this.btnSubMark1.Text = "1";
            this.btnSubMark1.UseVisualStyleBackColor = false;
            this.btnSubMark1.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark3
            // 
            this.btnSubMark3.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubMark3.Location = new System.Drawing.Point(3, 54);
            this.btnSubMark3.Name = "btnSubMark3";
            this.btnSubMark3.Size = new System.Drawing.Size(114, 46);
            this.btnSubMark3.TabIndex = 185;
            this.btnSubMark3.Tag = "3";
            this.btnSubMark3.Text = "3";
            this.btnSubMark3.UseVisualStyleBackColor = false;
            this.btnSubMark3.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // btnSubMark4
            // 
            this.btnSubMark4.BackColor = System.Drawing.Color.DarkGray;
            this.btnSubMark4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSubMark4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSubMark4.Location = new System.Drawing.Point(123, 54);
            this.btnSubMark4.Name = "btnSubMark4";
            this.btnSubMark4.Size = new System.Drawing.Size(114, 46);
            this.btnSubMark4.TabIndex = 186;
            this.btnSubMark4.Tag = "4";
            this.btnSubMark4.Text = "4";
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
            this.pnlMainMarkIndex.Size = new System.Drawing.Size(160, 103);
            this.pnlMainMarkIndex.TabIndex = 1;
            // 
            // btnMainMark
            // 
            this.btnMainMark.BackColor = System.Drawing.Color.DarkGray;
            this.btnMainMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMainMark.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnMainMark.Location = new System.Drawing.Point(0, 0);
            this.btnMainMark.Name = "btnMainMark";
            this.btnMainMark.Size = new System.Drawing.Size(160, 103);
            this.btnMainMark.TabIndex = 181;
            this.btnMainMark.Tag = "0";
            this.btnMainMark.Text = "MAIN";
            this.btnMainMark.UseVisualStyleBackColor = false;
            this.btnMainMark.Click += new System.EventHandler(this.btnSetMarkIndex_Click);
            // 
            // tlpROI
            // 
            this.tlpROI.ColumnCount = 2;
            this.tlpROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.Controls.Add(this.btnMarkROI, 0, 0);
            this.tlpROI.Controls.Add(this.btnSetMark, 1, 0);
            this.tlpROI.Controls.Add(this.btnSearchROI, 1, 1);
            this.tlpROI.Controls.Add(this.btnMasking, 0, 1);
            this.tlpROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROI.Location = new System.Drawing.Point(0, 103);
            this.tlpROI.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROI.Name = "tlpROI";
            this.tlpROI.RowCount = 2;
            this.tlpROI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpROI.Size = new System.Drawing.Size(400, 104);
            this.tlpROI.TabIndex = 188;
            // 
            // btnMarkROI
            // 
            this.btnMarkROI.BackColor = System.Drawing.Color.DarkGray;
            this.btnMarkROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMarkROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMarkROI.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnMarkROI.Location = new System.Drawing.Point(3, 3);
            this.btnMarkROI.Name = "btnMarkROI";
            this.btnMarkROI.Size = new System.Drawing.Size(194, 46);
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
            this.btnSetMark.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetMark.Location = new System.Drawing.Point(203, 3);
            this.btnSetMark.Name = "btnSetMark";
            this.btnSetMark.Size = new System.Drawing.Size(194, 46);
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
            this.btnSearchROI.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearchROI.Location = new System.Drawing.Point(203, 55);
            this.btnSearchROI.Name = "btnSearchROI";
            this.btnSearchROI.Size = new System.Drawing.Size(194, 46);
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
            this.btnMasking.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnMasking.Location = new System.Drawing.Point(3, 55);
            this.btnMasking.Name = "btnMasking";
            this.btnMasking.Size = new System.Drawing.Size(194, 46);
            this.btnMasking.TabIndex = 190;
            this.btnMasking.Text = "MASKING";
            this.btnMasking.UseVisualStyleBackColor = false;
            this.btnMasking.Click += new System.EventHandler(this.btnMasking_Click);
            // 
            // tlpApply
            // 
            this.tlpApply.ColumnCount = 2;
            this.tlpApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpApply.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpApply.Controls.Add(this.btnDelete, 1, 0);
            this.tlpApply.Controls.Add(this.btnApply, 0, 0);
            this.tlpApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpApply.Location = new System.Drawing.Point(0, 247);
            this.tlpApply.Margin = new System.Windows.Forms.Padding(0);
            this.tlpApply.Name = "tlpApply";
            this.tlpApply.RowCount = 1;
            this.tlpApply.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpApply.Size = new System.Drawing.Size(400, 69);
            this.tlpApply.TabIndex = 188;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkGray;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(203, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(194, 63);
            this.btnDelete.TabIndex = 191;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(3, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(194, 63);
            this.btnApply.TabIndex = 192;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // tlpTest
            // 
            this.tlpTest.ColumnCount = 2;
            this.tlpTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTest.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTest.Controls.Add(this.btnAlignTest, 1, 0);
            this.tlpTest.Controls.Add(this.btnMarkTest, 0, 0);
            this.tlpTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTest.Location = new System.Drawing.Point(400, 247);
            this.tlpTest.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTest.Name = "tlpTest";
            this.tlpTest.RowCount = 1;
            this.tlpTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTest.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpTest.Size = new System.Drawing.Size(400, 69);
            this.tlpTest.TabIndex = 185;
            // 
            // btnAlignTest
            // 
            this.btnAlignTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnAlignTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlignTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlignTest.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAlignTest.Location = new System.Drawing.Point(203, 3);
            this.btnAlignTest.Name = "btnAlignTest";
            this.btnAlignTest.Size = new System.Drawing.Size(194, 63);
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
            this.btnMarkTest.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnMarkTest.Location = new System.Drawing.Point(3, 3);
            this.btnMarkTest.Name = "btnMarkTest";
            this.btnMarkTest.Size = new System.Drawing.Size(194, 63);
            this.btnMarkTest.TabIndex = 195;
            this.btnMarkTest.Text = "MARK TEST";
            this.btnMarkTest.UseVisualStyleBackColor = false;
            this.btnMarkTest.Click += new System.EventHandler(this.btnMarkTest_Click);
            // 
            // tlpSpec
            // 
            this.tlpSpec.ColumnCount = 2;
            this.tlpSpec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.07692F));
            this.tlpSpec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.92308F));
            this.tlpSpec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSpec.Controls.Add(this.lblSpec, 0, 0);
            this.tlpSpec.Controls.Add(this.tlpSpecData, 1, 0);
            this.tlpSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpec.Location = new System.Drawing.Point(0, 316);
            this.tlpSpec.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSpec.Name = "tlpSpec";
            this.tlpSpec.RowCount = 1;
            this.tlpSpec.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSpec.Size = new System.Drawing.Size(400, 69);
            this.tlpSpec.TabIndex = 190;
            // 
            // lblSpec
            // 
            this.lblSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpec.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSpec.Location = new System.Drawing.Point(6, 3);
            this.lblSpec.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(80, 63);
            this.lblSpec.TabIndex = 61;
            this.lblSpec.Text = "SPEC";
            this.lblSpec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tlpSpecData.Location = new System.Drawing.Point(92, 0);
            this.tlpSpecData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSpecData.Name = "tlpSpecData";
            this.tlpSpecData.RowCount = 2;
            this.tlpSpecData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpecData.Size = new System.Drawing.Size(308, 69);
            this.tlpSpecData.TabIndex = 62;
            // 
            // lblMarkScore
            // 
            this.lblMarkScore.BackColor = System.Drawing.Color.White;
            this.lblMarkScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkScore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMarkScore.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarkScore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkScore.Location = new System.Drawing.Point(160, 3);
            this.lblMarkScore.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMarkScore.Name = "lblMarkScore";
            this.lblMarkScore.Size = new System.Drawing.Size(142, 28);
            this.lblMarkScore.TabIndex = 261;
            this.lblMarkScore.Text = "80";
            this.lblMarkScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkScore.Click += new System.EventHandler(this.lblMarkScore_Click);
            // 
            // lblScore
            // 
            this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScore.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblScore.Location = new System.Drawing.Point(6, 3);
            this.lblScore.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(142, 28);
            this.lblScore.TabIndex = 61;
            this.lblScore.Text = "SCORE [%]";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAngle
            // 
            this.lblAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAngle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAngle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblAngle.Location = new System.Drawing.Point(6, 37);
            this.lblAngle.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(142, 29);
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
            this.lblMarkAngleThreshold.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarkAngleThreshold.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkAngleThreshold.Location = new System.Drawing.Point(160, 37);
            this.lblMarkAngleThreshold.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMarkAngleThreshold.Name = "lblMarkAngleThreshold";
            this.lblMarkAngleThreshold.Size = new System.Drawing.Size(142, 29);
            this.lblMarkAngleThreshold.TabIndex = 261;
            this.lblMarkAngleThreshold.Text = "0.1";
            this.lblMarkAngleThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkAngleThreshold.Click += new System.EventHandler(this.lblMarkAngleThreshold_Click);
            // 
            // tlpROIPosition
            // 
            this.tlpROIPosition.ColumnCount = 2;
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0075F));
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.9925F));
            this.tlpROIPosition.Controls.Add(this.lblTargetObject, 1, 0);
            this.tlpROIPosition.Controls.Add(this.lblMarkPosition, 0, 0);
            this.tlpROIPosition.Controls.Add(this.tlpMarkPosition, 0, 1);
            this.tlpROIPosition.Controls.Add(this.tlpTargetObject, 1, 1);
            this.tlpROIPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROIPosition.Location = new System.Drawing.Point(0, 0);
            this.tlpROIPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROIPosition.Name = "tlpROIPosition";
            this.tlpROIPosition.RowCount = 2;
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpROIPosition.Size = new System.Drawing.Size(800, 105);
            this.tlpROIPosition.TabIndex = 0;
            // 
            // lblTargetObject
            // 
            this.lblTargetObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetObject.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTargetObject.Location = new System.Drawing.Point(406, 3);
            this.lblTargetObject.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTargetObject.Name = "lblTargetObject";
            this.lblTargetObject.Size = new System.Drawing.Size(388, 36);
            this.lblTargetObject.TabIndex = 149;
            this.lblTargetObject.Text = "TARGET OBJECT";
            this.lblTargetObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkPosition
            // 
            this.lblMarkPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkPosition.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMarkPosition.Location = new System.Drawing.Point(6, 3);
            this.lblMarkPosition.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblMarkPosition.Name = "lblMarkPosition";
            this.lblMarkPosition.Size = new System.Drawing.Size(388, 36);
            this.lblMarkPosition.TabIndex = 140;
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
            this.tlpMarkPosition.Location = new System.Drawing.Point(0, 42);
            this.tlpMarkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkPosition.Name = "tlpMarkPosition";
            this.tlpMarkPosition.RowCount = 1;
            this.tlpMarkPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkPosition.Size = new System.Drawing.Size(400, 63);
            this.tlpMarkPosition.TabIndex = 0;
            // 
            // rdoMarkRight
            // 
            this.rdoMarkRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMarkRight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMarkRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMarkRight.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoMarkRight.ForeColor = System.Drawing.Color.Black;
            this.rdoMarkRight.Location = new System.Drawing.Point(203, 3);
            this.rdoMarkRight.Name = "rdoMarkRight";
            this.rdoMarkRight.Size = new System.Drawing.Size(194, 57);
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
            this.rdoMarkLeft.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoMarkLeft.ForeColor = System.Drawing.Color.Black;
            this.rdoMarkLeft.Location = new System.Drawing.Point(3, 3);
            this.rdoMarkLeft.Name = "rdoMarkLeft";
            this.rdoMarkLeft.Size = new System.Drawing.Size(194, 57);
            this.rdoMarkLeft.TabIndex = 141;
            this.rdoMarkLeft.Tag = "0";
            this.rdoMarkLeft.Text = "LEFT MARK";
            this.rdoMarkLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMarkLeft.UseVisualStyleBackColor = false;
            this.rdoMarkLeft.CheckedChanged += new System.EventHandler(this.rdoSetMarkPosition_CheckedChanged);
            // 
            // tlpTargetObject
            // 
            this.tlpTargetObject.ColumnCount = 2;
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.Controls.Add(this.rdoPanel, 0, 0);
            this.tlpTargetObject.Controls.Add(this.rdoFPC, 0, 0);
            this.tlpTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTargetObject.Location = new System.Drawing.Point(400, 42);
            this.tlpTargetObject.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTargetObject.Name = "tlpTargetObject";
            this.tlpTargetObject.RowCount = 1;
            this.tlpTargetObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.Size = new System.Drawing.Size(400, 63);
            this.tlpTargetObject.TabIndex = 1;
            // 
            // rdoPanel
            // 
            this.rdoPanel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoPanel.BackColor = System.Drawing.Color.DarkGray;
            this.rdoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoPanel.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoPanel.ForeColor = System.Drawing.Color.Black;
            this.rdoPanel.Location = new System.Drawing.Point(203, 3);
            this.rdoPanel.Name = "rdoPanel";
            this.rdoPanel.Size = new System.Drawing.Size(194, 57);
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
            this.rdoFPC.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoFPC.ForeColor = System.Drawing.Color.Black;
            this.rdoFPC.Location = new System.Drawing.Point(3, 3);
            this.rdoFPC.Name = "rdoFPC";
            this.rdoFPC.Size = new System.Drawing.Size(194, 57);
            this.rdoFPC.TabIndex = 142;
            this.rdoFPC.Tag = "0";
            this.rdoFPC.Text = "FPC";
            this.rdoFPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoFPC.UseVisualStyleBackColor = false;
            this.rdoFPC.CheckedChanged += new System.EventHandler(this.rdoSetTargetObject_CheckedChanged);
            // 
            // tlpROIJog
            // 
            this.tlpROIJog.ColumnCount = 2;
            this.tlpROIJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpROIJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpROIJog.Controls.Add(this.pnlROIJog, 1, 1);
            this.tlpROIJog.Controls.Add(this.tlpShowROIJog, 1, 0);
            this.tlpROIJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROIJog.Location = new System.Drawing.Point(0, 490);
            this.tlpROIJog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROIJog.Name = "tlpROIJog";
            this.tlpROIJog.RowCount = 2;
            this.tlpROIJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpROIJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpROIJog.Size = new System.Drawing.Size(800, 210);
            this.tlpROIJog.TabIndex = 290;
            // 
            // pnlROIJog
            // 
            this.pnlROIJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlROIJog.Location = new System.Drawing.Point(240, 40);
            this.pnlROIJog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlROIJog.Name = "pnlROIJog";
            this.pnlROIJog.Size = new System.Drawing.Size(560, 170);
            this.pnlROIJog.TabIndex = 288;
            // 
            // tlpShowROIJog
            // 
            this.tlpShowROIJog.ColumnCount = 2;
            this.tlpShowROIJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShowROIJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpShowROIJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpShowROIJog.Controls.Add(this.chkShowROIJog, 1, 0);
            this.tlpShowROIJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpShowROIJog.Location = new System.Drawing.Point(240, 0);
            this.tlpShowROIJog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpShowROIJog.Name = "tlpShowROIJog";
            this.tlpShowROIJog.RowCount = 1;
            this.tlpShowROIJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpShowROIJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpShowROIJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpShowROIJog.Size = new System.Drawing.Size(560, 40);
            this.tlpShowROIJog.TabIndex = 296;
            // 
            // chkShowROIJog
            // 
            this.chkShowROIJog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowROIJog.AutoSize = true;
            this.chkShowROIJog.BackColor = System.Drawing.Color.DarkGray;
            this.chkShowROIJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowROIJog.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.chkShowROIJog.Location = new System.Drawing.Point(320, 0);
            this.chkShowROIJog.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowROIJog.Name = "chkShowROIJog";
            this.chkShowROIJog.Size = new System.Drawing.Size(240, 40);
            this.chkShowROIJog.TabIndex = 203;
            this.chkShowROIJog.Text = "SHOW ROI JOG";
            this.chkShowROIJog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowROIJog.UseVisualStyleBackColor = false;
            this.chkShowROIJog.Click += new System.EventHandler(this.chkShowROIJog_CheckedChanged);
            // 
            // CtrlTeachMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeachMark);
            this.Name = "CtrlTeachMark";
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.CtrlTeachMark_Load);
            this.tlpTeachMark.ResumeLayout(false);
            this.tlpMarkRegister.ResumeLayout(false);
            this.tlpSave.ResumeLayout(false);
            this.pnlMainMark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogMarkDisplay)).EndInit();
            this.tlpMarkIndex.ResumeLayout(false);
            this.tlpSeperateMarkIndex.ResumeLayout(false);
            this.tlpSubMarkIndex.ResumeLayout(false);
            this.pnlMainMarkIndex.ResumeLayout(false);
            this.tlpROI.ResumeLayout(false);
            this.tlpApply.ResumeLayout(false);
            this.tlpTest.ResumeLayout(false);
            this.tlpSpec.ResumeLayout(false);
            this.tlpSpecData.ResumeLayout(false);
            this.tlpROIPosition.ResumeLayout(false);
            this.tlpMarkPosition.ResumeLayout(false);
            this.tlpTargetObject.ResumeLayout(false);
            this.tlpROIJog.ResumeLayout(false);
            this.tlpShowROIJog.ResumeLayout(false);
            this.tlpShowROIJog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeachMark;
        private System.Windows.Forms.TableLayoutPanel tlpROIJog;
        private System.Windows.Forms.Panel pnlROIJog;
        private System.Windows.Forms.TableLayoutPanel tlpShowROIJog;
        private System.Windows.Forms.CheckBox chkShowROIJog;
        private System.Windows.Forms.TableLayoutPanel tlpMarkRegister;
        private System.Windows.Forms.TableLayoutPanel tlpSave;
        private System.Windows.Forms.Button btnSave;
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
        private System.Windows.Forms.Button btnMasking;
        private System.Windows.Forms.TableLayoutPanel tlpApply;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tlpTest;
        private System.Windows.Forms.Button btnAlignTest;
        private System.Windows.Forms.Button btnMarkTest;
        private System.Windows.Forms.TableLayoutPanel tlpSpec;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.TableLayoutPanel tlpSpecData;
        private System.Windows.Forms.Label lblMarkScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Label lblMarkAngleThreshold;
        private System.Windows.Forms.TableLayoutPanel tlpROIPosition;
        private System.Windows.Forms.Label lblTargetObject;
        private System.Windows.Forms.Label lblMarkPosition;
        private System.Windows.Forms.TableLayoutPanel tlpMarkPosition;
        private System.Windows.Forms.RadioButton rdoMarkRight;
        private System.Windows.Forms.RadioButton rdoMarkLeft;
        private System.Windows.Forms.TableLayoutPanel tlpTargetObject;
        private System.Windows.Forms.RadioButton rdoPanel;
        private System.Windows.Forms.RadioButton rdoFPC;
    }
}
