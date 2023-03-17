namespace COG.Controls
{
    partial class CtrlTeachParticle
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
            this.tlpTeachParticle = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBlobData = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBlobParameter = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoBlobLight = new System.Windows.Forms.RadioButton();
            this.rdoBlobDark = new System.Windows.Forms.RadioButton();
            this.lblMinPixelSize = new System.Windows.Forms.Label();
            this.chkROITracking = new System.Windows.Forms.CheckBox();
            this.lblPolarity = new System.Windows.Forms.Label();
            this.lblMinimumPixelSize = new System.Windows.Forms.Label();
            this.tlpThresholdValue = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTrbThresholdValue = new System.Windows.Forms.Panel();
            this.trbThresholdValue = new System.Windows.Forms.TrackBar();
            this.nudThresholdValue = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.btnROIShow = new System.Windows.Forms.Button();
            this.btnBlobTest = new System.Windows.Forms.Button();
            this.chkOverlay = new System.Windows.Forms.CheckBox();
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lvBlobResult = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSpec = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxHeightSizeValue = new System.Windows.Forms.Label();
            this.lblMaxHeightSize = new System.Windows.Forms.Label();
            this.lblMaxWidthSizeValue = new System.Windows.Forms.Label();
            this.lblMaxWidthSize = new System.Windows.Forms.Label();
            this.tlpBlobCount = new System.Windows.Forms.TableLayoutPanel();
            this.lblBlobCountValue = new System.Windows.Forms.Label();
            this.lblBlobCount = new System.Windows.Forms.Label();
            this.cmbBlobPointSelect = new System.Windows.Forms.ComboBox();
            this.tlpTeachParticle.SuspendLayout();
            this.tlpBlobData.SuspendLayout();
            this.tlpBlobParameter.SuspendLayout();
            this.tlpPolarity.SuspendLayout();
            this.tlpThresholdValue.SuspendLayout();
            this.pnlTrbThresholdValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresholdValue)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpBlobCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachParticle
            // 
            this.tlpTeachParticle.ColumnCount = 1;
            this.tlpTeachParticle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachParticle.Controls.Add(this.tlpBlobData, 0, 3);
            this.tlpTeachParticle.Controls.Add(this.lvBlobResult, 0, 4);
            this.tlpTeachParticle.Controls.Add(this.tableLayoutPanel1, 0, 6);
            this.tlpTeachParticle.Controls.Add(this.tlpBlobCount, 0, 1);
            this.tlpTeachParticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachParticle.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachParticle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachParticle.Name = "tlpTeachParticle";
            this.tlpTeachParticle.RowCount = 8;
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachParticle.Size = new System.Drawing.Size(800, 900);
            this.tlpTeachParticle.TabIndex = 290;
            // 
            // tlpBlobData
            // 
            this.tlpBlobData.ColumnCount = 1;
            this.tlpBlobData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBlobData.Controls.Add(this.tlpBlobParameter, 0, 0);
            this.tlpBlobData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobData.Location = new System.Drawing.Point(0, 120);
            this.tlpBlobData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobData.Name = "tlpBlobData";
            this.tlpBlobData.RowCount = 1;
            this.tlpBlobData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBlobData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 432F));
            this.tlpBlobData.Size = new System.Drawing.Size(800, 432);
            this.tlpBlobData.TabIndex = 0;
            // 
            // tlpBlobParameter
            // 
            this.tlpBlobParameter.ColumnCount = 4;
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.Controls.Add(this.tlpPolarity, 1, 1);
            this.tlpBlobParameter.Controls.Add(this.lblMinPixelSize, 1, 0);
            this.tlpBlobParameter.Controls.Add(this.chkROITracking, 1, 3);
            this.tlpBlobParameter.Controls.Add(this.lblPolarity, 0, 1);
            this.tlpBlobParameter.Controls.Add(this.lblMinimumPixelSize, 0, 0);
            this.tlpBlobParameter.Controls.Add(this.tlpThresholdValue, 3, 0);
            this.tlpBlobParameter.Controls.Add(this.lblThreshold, 2, 0);
            this.tlpBlobParameter.Controls.Add(this.btnROIShow, 0, 3);
            this.tlpBlobParameter.Controls.Add(this.btnBlobTest, 3, 6);
            this.tlpBlobParameter.Controls.Add(this.chkOverlay, 2, 6);
            this.tlpBlobParameter.Controls.Add(this.btnConvert, 1, 6);
            this.tlpBlobParameter.Controls.Add(this.btnApply, 0, 6);
            this.tlpBlobParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpBlobParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobParameter.Name = "tlpBlobParameter";
            this.tlpBlobParameter.RowCount = 7;
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38349F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38254F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.700124F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38036F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38431F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38025F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38893F));
            this.tlpBlobParameter.Size = new System.Drawing.Size(800, 432);
            this.tlpBlobParameter.TabIndex = 290;
            // 
            // tlpPolarity
            // 
            this.tlpPolarity.ColumnCount = 2;
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Controls.Add(this.rdoBlobLight, 0, 0);
            this.tlpPolarity.Controls.Add(this.rdoBlobDark, 0, 0);
            this.tlpPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPolarity.Location = new System.Drawing.Point(200, 66);
            this.tlpPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPolarity.Name = "tlpPolarity";
            this.tlpPolarity.RowCount = 1;
            this.tlpPolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Size = new System.Drawing.Size(200, 66);
            this.tlpPolarity.TabIndex = 208;
            // 
            // rdoBlobLight
            // 
            this.rdoBlobLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBlobLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoBlobLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoBlobLight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoBlobLight.ForeColor = System.Drawing.Color.Black;
            this.rdoBlobLight.Location = new System.Drawing.Point(100, 0);
            this.rdoBlobLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoBlobLight.Name = "rdoBlobLight";
            this.rdoBlobLight.Size = new System.Drawing.Size(100, 66);
            this.rdoBlobLight.TabIndex = 143;
            this.rdoBlobLight.Tag = "0";
            this.rdoBlobLight.Text = "LIGHT";
            this.rdoBlobLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBlobLight.UseVisualStyleBackColor = false;
            this.rdoBlobLight.CheckedChanged += new System.EventHandler(this.rdoSetBlobPolarity_CheckedChanged);
            // 
            // rdoBlobDark
            // 
            this.rdoBlobDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBlobDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoBlobDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoBlobDark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoBlobDark.ForeColor = System.Drawing.Color.Black;
            this.rdoBlobDark.Location = new System.Drawing.Point(0, 0);
            this.rdoBlobDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoBlobDark.Name = "rdoBlobDark";
            this.rdoBlobDark.Size = new System.Drawing.Size(100, 66);
            this.rdoBlobDark.TabIndex = 142;
            this.rdoBlobDark.Tag = "0";
            this.rdoBlobDark.Text = "DARK";
            this.rdoBlobDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBlobDark.UseVisualStyleBackColor = false;
            this.rdoBlobDark.CheckedChanged += new System.EventHandler(this.rdoSetBlobPolarity_CheckedChanged);
            // 
            // lblMinPixelSize
            // 
            this.lblMinPixelSize.AutoSize = true;
            this.lblMinPixelSize.BackColor = System.Drawing.Color.White;
            this.lblMinPixelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinPixelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinPixelSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMinPixelSize.Location = new System.Drawing.Point(200, 0);
            this.lblMinPixelSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinPixelSize.Name = "lblMinPixelSize";
            this.lblMinPixelSize.Size = new System.Drawing.Size(200, 66);
            this.lblMinPixelSize.TabIndex = 9;
            this.lblMinPixelSize.Text = "0";
            this.lblMinPixelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinPixelSize.Click += new System.EventHandler(this.lblMinPixelSize_Click);
            // 
            // chkROITracking
            // 
            this.chkROITracking.AutoSize = true;
            this.chkROITracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkROITracking.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkROITracking.Location = new System.Drawing.Point(206, 165);
            this.chkROITracking.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chkROITracking.Name = "chkROITracking";
            this.chkROITracking.Size = new System.Drawing.Size(194, 66);
            this.chkROITracking.TabIndex = 209;
            this.chkROITracking.Text = "ROI Tracking";
            this.chkROITracking.UseVisualStyleBackColor = true;
            this.chkROITracking.CheckedChanged += new System.EventHandler(this.chkROITracking_CheckedChanged);
            // 
            // lblPolarity
            // 
            this.lblPolarity.AutoSize = true;
            this.lblPolarity.BackColor = System.Drawing.Color.DarkGray;
            this.lblPolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPolarity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPolarity.Location = new System.Drawing.Point(0, 66);
            this.lblPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblPolarity.Name = "lblPolarity";
            this.lblPolarity.Size = new System.Drawing.Size(200, 66);
            this.lblPolarity.TabIndex = 4;
            this.lblPolarity.Text = "POLARITY";
            this.lblPolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinimumPixelSize
            // 
            this.lblMinimumPixelSize.AutoSize = true;
            this.lblMinimumPixelSize.BackColor = System.Drawing.Color.DarkGray;
            this.lblMinimumPixelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinimumPixelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinimumPixelSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMinimumPixelSize.Location = new System.Drawing.Point(0, 0);
            this.lblMinimumPixelSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinimumPixelSize.Name = "lblMinimumPixelSize";
            this.lblMinimumPixelSize.Size = new System.Drawing.Size(200, 66);
            this.lblMinimumPixelSize.TabIndex = 3;
            this.lblMinimumPixelSize.Text = "MIN. PIXEL SIZE";
            this.lblMinimumPixelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpThresholdValue
            // 
            this.tlpThresholdValue.ColumnCount = 1;
            this.tlpThresholdValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThresholdValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpThresholdValue.Controls.Add(this.pnlTrbThresholdValue, 0, 0);
            this.tlpThresholdValue.Controls.Add(this.nudThresholdValue, 0, 1);
            this.tlpThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThresholdValue.Location = new System.Drawing.Point(600, 0);
            this.tlpThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.tlpThresholdValue.Name = "tlpThresholdValue";
            this.tlpThresholdValue.RowCount = 2;
            this.tlpThresholdValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThresholdValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThresholdValue.Size = new System.Drawing.Size(200, 66);
            this.tlpThresholdValue.TabIndex = 210;
            // 
            // pnlTrbThresholdValue
            // 
            this.pnlTrbThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTrbThresholdValue.Controls.Add(this.trbThresholdValue);
            this.pnlTrbThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrbThresholdValue.Location = new System.Drawing.Point(9, 3);
            this.pnlTrbThresholdValue.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.pnlTrbThresholdValue.Name = "pnlTrbThresholdValue";
            this.pnlTrbThresholdValue.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.pnlTrbThresholdValue.Size = new System.Drawing.Size(188, 27);
            this.pnlTrbThresholdValue.TabIndex = 208;
            // 
            // trbThresholdValue
            // 
            this.trbThresholdValue.BackColor = System.Drawing.Color.Silver;
            this.trbThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trbThresholdValue.Location = new System.Drawing.Point(0, 9);
            this.trbThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.trbThresholdValue.Maximum = 255;
            this.trbThresholdValue.Name = "trbThresholdValue";
            this.trbThresholdValue.Size = new System.Drawing.Size(186, 16);
            this.trbThresholdValue.TabIndex = 208;
            this.trbThresholdValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbThresholdValue.Scroll += new System.EventHandler(this.trbThresholdValue_Scroll);
            // 
            // nudThresholdValue
            // 
            this.nudThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.nudThresholdValue.Location = new System.Drawing.Point(0, 37);
            this.nudThresholdValue.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.nudThresholdValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudThresholdValue.Name = "nudThresholdValue";
            this.nudThresholdValue.Size = new System.Drawing.Size(200, 27);
            this.nudThresholdValue.TabIndex = 209;
            this.nudThresholdValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudThresholdValue.ValueChanged += new System.EventHandler(this.nudThresholdValue_ValueChanged);
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.BackColor = System.Drawing.Color.DarkGray;
            this.lblThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblThreshold.Location = new System.Drawing.Point(400, 0);
            this.lblThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(200, 66);
            this.lblThreshold.TabIndex = 2;
            this.lblThreshold.Text = "THRESHOLD";
            this.lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnROIShow
            // 
            this.btnROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnROIShow.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnROIShow.Location = new System.Drawing.Point(0, 165);
            this.btnROIShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnROIShow.Name = "btnROIShow";
            this.btnROIShow.Size = new System.Drawing.Size(200, 66);
            this.btnROIShow.TabIndex = 198;
            this.btnROIShow.Text = "SHOW ROI";
            this.btnROIShow.UseVisualStyleBackColor = false;
            this.btnROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // btnBlobTest
            // 
            this.btnBlobTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnBlobTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlobTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBlobTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnBlobTest.Location = new System.Drawing.Point(600, 363);
            this.btnBlobTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlobTest.Name = "btnBlobTest";
            this.btnBlobTest.Size = new System.Drawing.Size(200, 69);
            this.btnBlobTest.TabIndex = 198;
            this.btnBlobTest.Text = "BLOB TEST";
            this.btnBlobTest.UseVisualStyleBackColor = false;
            this.btnBlobTest.Click += new System.EventHandler(this.btnBlobTest_Click);
            // 
            // chkOverlay
            // 
            this.chkOverlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOverlay.AutoSize = true;
            this.chkOverlay.BackColor = System.Drawing.Color.DarkGray;
            this.chkOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOverlay.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkOverlay.Location = new System.Drawing.Point(400, 363);
            this.chkOverlay.Margin = new System.Windows.Forms.Padding(0);
            this.chkOverlay.Name = "chkOverlay";
            this.chkOverlay.Size = new System.Drawing.Size(200, 69);
            this.chkOverlay.TabIndex = 267;
            this.chkOverlay.Text = "OVERLAY";
            this.chkOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOverlay.UseVisualStyleBackColor = false;
            this.chkOverlay.CheckedChanged += new System.EventHandler(this.chkOverlay_CheckedChanged);
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.DarkGray;
            this.btnConvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvert.Location = new System.Drawing.Point(200, 363);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(0);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(200, 69);
            this.btnConvert.TabIndex = 268;
            this.btnConvert.Text = "CONVERT";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(0, 363);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(200, 69);
            this.btnApply.TabIndex = 198;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lvBlobResult
            // 
            this.lvBlobResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Width,
            this.Height});
            this.lvBlobResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBlobResult.HideSelection = false;
            this.lvBlobResult.Location = new System.Drawing.Point(0, 552);
            this.lvBlobResult.Margin = new System.Windows.Forms.Padding(0);
            this.lvBlobResult.Name = "lvBlobResult";
            this.lvBlobResult.Size = new System.Drawing.Size(800, 180);
            this.lvBlobResult.TabIndex = 0;
            this.lvBlobResult.UseCompatibleStateImageBehavior = false;
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 100;
            // 
            // Width
            // 
            this.Width.Text = "Width(um)";
            this.Width.Width = 200;
            // 
            // Height
            // 
            this.Height.Text = "Height(um)";
            this.Height.Width = 200;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 762);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 108);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblSpec, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(385, 108);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSpec.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblSpec.Location = new System.Drawing.Point(0, 0);
            this.lblSpec.Margin = new System.Windows.Forms.Padding(0);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(385, 30);
            this.lblSpec.TabIndex = 205;
            this.lblSpec.Text = "SPEC";
            this.lblSpec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33555F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66445F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaxSize, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(385, 78);
            this.tableLayoutPanel3.TabIndex = 206;
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.BackColor = System.Drawing.Color.DarkGray;
            this.lblMaxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSize.Location = new System.Drawing.Point(0, 0);
            this.lblMaxSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(128, 78);
            this.lblMaxSize.TabIndex = 204;
            this.lblMaxSize.Text = "MAX PIXEL SIZE\r\n[um]";
            this.lblMaxSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lblMaxHeightSizeValue, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblMaxHeightSize, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblMaxWidthSizeValue, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblMaxWidthSize, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(128, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(257, 78);
            this.tableLayoutPanel4.TabIndex = 205;
            // 
            // lblMaxHeightSizeValue
            // 
            this.lblMaxHeightSizeValue.AutoSize = true;
            this.lblMaxHeightSizeValue.BackColor = System.Drawing.Color.White;
            this.lblMaxHeightSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxHeightSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxHeightSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxHeightSizeValue.Location = new System.Drawing.Point(128, 39);
            this.lblMaxHeightSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxHeightSizeValue.Name = "lblMaxHeightSizeValue";
            this.lblMaxHeightSizeValue.Size = new System.Drawing.Size(129, 39);
            this.lblMaxHeightSizeValue.TabIndex = 9;
            this.lblMaxHeightSizeValue.Text = "0";
            this.lblMaxHeightSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxHeightSizeValue.Click += new System.EventHandler(this.lblMaxHeightSizeValue_Click);
            // 
            // lblMaxHeightSize
            // 
            this.lblMaxHeightSize.AutoSize = true;
            this.lblMaxHeightSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxHeightSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxHeightSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxHeightSize.Location = new System.Drawing.Point(0, 39);
            this.lblMaxHeightSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxHeightSize.Name = "lblMaxHeightSize";
            this.lblMaxHeightSize.Size = new System.Drawing.Size(128, 39);
            this.lblMaxHeightSize.TabIndex = 204;
            this.lblMaxHeightSize.Text = "HEIGHT";
            this.lblMaxHeightSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxWidthSizeValue
            // 
            this.lblMaxWidthSizeValue.AutoSize = true;
            this.lblMaxWidthSizeValue.BackColor = System.Drawing.Color.White;
            this.lblMaxWidthSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWidthSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxWidthSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxWidthSizeValue.Location = new System.Drawing.Point(128, 0);
            this.lblMaxWidthSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxWidthSizeValue.Name = "lblMaxWidthSizeValue";
            this.lblMaxWidthSizeValue.Size = new System.Drawing.Size(129, 39);
            this.lblMaxWidthSizeValue.TabIndex = 9;
            this.lblMaxWidthSizeValue.Text = "0";
            this.lblMaxWidthSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxWidthSizeValue.Click += new System.EventHandler(this.lblMaxWidthSizeValue_Click);
            // 
            // lblMaxWidthSize
            // 
            this.lblMaxWidthSize.AutoSize = true;
            this.lblMaxWidthSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWidthSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxWidthSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxWidthSize.Location = new System.Drawing.Point(0, 0);
            this.lblMaxWidthSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxWidthSize.Name = "lblMaxWidthSize";
            this.lblMaxWidthSize.Size = new System.Drawing.Size(128, 39);
            this.lblMaxWidthSize.TabIndex = 204;
            this.lblMaxWidthSize.Text = "WIDTH";
            this.lblMaxWidthSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpBlobCount
            // 
            this.tlpBlobCount.ColumnCount = 4;
            this.tlpBlobCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobCount.Controls.Add(this.lblBlobCountValue, 1, 0);
            this.tlpBlobCount.Controls.Add(this.lblBlobCount, 0, 0);
            this.tlpBlobCount.Controls.Add(this.cmbBlobPointSelect, 2, 0);
            this.tlpBlobCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobCount.Location = new System.Drawing.Point(0, 30);
            this.tlpBlobCount.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobCount.Name = "tlpBlobCount";
            this.tlpBlobCount.RowCount = 1;
            this.tlpBlobCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBlobCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBlobCount.Size = new System.Drawing.Size(800, 30);
            this.tlpBlobCount.TabIndex = 2;
            // 
            // lblBlobCountValue
            // 
            this.lblBlobCountValue.AutoSize = true;
            this.lblBlobCountValue.BackColor = System.Drawing.Color.White;
            this.lblBlobCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBlobCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBlobCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBlobCountValue.Location = new System.Drawing.Point(200, 0);
            this.lblBlobCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlobCountValue.Name = "lblBlobCountValue";
            this.lblBlobCountValue.Size = new System.Drawing.Size(200, 30);
            this.lblBlobCountValue.TabIndex = 8;
            this.lblBlobCountValue.Text = "0";
            this.lblBlobCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBlobCountValue.Click += new System.EventHandler(this.lblBlobCountValue_Click);
            // 
            // lblBlobCount
            // 
            this.lblBlobCount.AutoSize = true;
            this.lblBlobCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblBlobCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBlobCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBlobCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBlobCount.Location = new System.Drawing.Point(0, 0);
            this.lblBlobCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlobCount.Name = "lblBlobCount";
            this.lblBlobCount.Size = new System.Drawing.Size(200, 30);
            this.lblBlobCount.TabIndex = 200;
            this.lblBlobCount.Text = "BLOB COUNT";
            this.lblBlobCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBlobPointSelect
            // 
            this.cmbBlobPointSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBlobPointSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBlobPointSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlobPointSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbBlobPointSelect.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbBlobPointSelect.FormattingEnabled = true;
            this.cmbBlobPointSelect.Location = new System.Drawing.Point(406, 1);
            this.cmbBlobPointSelect.Margin = new System.Windows.Forms.Padding(6, 1, 6, 0);
            this.cmbBlobPointSelect.Name = "cmbBlobPointSelect";
            this.cmbBlobPointSelect.Size = new System.Drawing.Size(188, 28);
            this.cmbBlobPointSelect.TabIndex = 202;
            this.cmbBlobPointSelect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbBlobPointSelect.SelectedIndexChanged += new System.EventHandler(this.cmbBlobPointSelect_SelectedIndexChanged);
            // 
            // CtrlTeachParticle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeachParticle);
            this.Name = "CtrlTeachParticle";
            this.Size = new System.Drawing.Size(800, 900);
            this.Load += new System.EventHandler(this.CtrlTeachBlob_Load);
            this.tlpTeachParticle.ResumeLayout(false);
            this.tlpBlobData.ResumeLayout(false);
            this.tlpBlobParameter.ResumeLayout(false);
            this.tlpBlobParameter.PerformLayout();
            this.tlpPolarity.ResumeLayout(false);
            this.tlpThresholdValue.ResumeLayout(false);
            this.pnlTrbThresholdValue.ResumeLayout(false);
            this.pnlTrbThresholdValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresholdValue)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tlpBlobCount.ResumeLayout(false);
            this.tlpBlobCount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeachParticle;
        private System.Windows.Forms.TableLayoutPanel tlpBlobData;
        private System.Windows.Forms.TableLayoutPanel tlpBlobParameter;
        private System.Windows.Forms.Label lblBlobCount;
        private System.Windows.Forms.Label lblBlobCountValue;
        private System.Windows.Forms.TableLayoutPanel tlpPolarity;
        private System.Windows.Forms.RadioButton rdoBlobLight;
        private System.Windows.Forms.RadioButton rdoBlobDark;
        private System.Windows.Forms.Label lblMinPixelSize;
        private System.Windows.Forms.CheckBox chkROITracking;
        private System.Windows.Forms.Button btnROIShow;
        private System.Windows.Forms.Label lblPolarity;
        private System.Windows.Forms.Label lblMinimumPixelSize;
        private System.Windows.Forms.Label lblMaxSize;
        private System.Windows.Forms.Label lblMaxHeightSizeValue;
        private System.Windows.Forms.Label lblMaxWidthSizeValue;
        private System.Windows.Forms.TableLayoutPanel tlpThresholdValue;
        private System.Windows.Forms.Panel pnlTrbThresholdValue;
        private System.Windows.Forms.TrackBar trbThresholdValue;
        private System.Windows.Forms.NumericUpDown nudThresholdValue;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Button btnBlobTest;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox cmbBlobPointSelect;
        private System.Windows.Forms.Label lblMaxWidthSize;
        private System.Windows.Forms.Label lblMaxHeightSize;
        private System.Windows.Forms.CheckBox chkOverlay;
        private System.Windows.Forms.ListView lvBlobResult;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Width;
        private System.Windows.Forms.ColumnHeader Height;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tlpBlobCount;
    }
}
