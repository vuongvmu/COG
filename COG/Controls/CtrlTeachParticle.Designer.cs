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
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblBlobCount = new System.Windows.Forms.Label();
            this.lblBlobCountValue = new System.Windows.Forms.Label();
            this.tlpPolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoBlobLight = new System.Windows.Forms.RadioButton();
            this.rdoBlobDark = new System.Windows.Forms.RadioButton();
            this.lblMinPixelSize = new System.Windows.Forms.Label();
            this.chkROITracking = new System.Windows.Forms.CheckBox();
            this.btnROIShow = new System.Windows.Forms.Button();
            this.lblPolarity = new System.Windows.Forms.Label();
            this.lblMinimumPixelSize = new System.Windows.Forms.Label();
            this.lblMaxSize = new System.Windows.Forms.Label();
            this.lblBlobSpecification = new System.Windows.Forms.Label();
            this.lblMaxPixelSizeValue = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxHeightSizeValue = new System.Windows.Forms.Label();
            this.lblMaxWidthSizeValue = new System.Windows.Forms.Label();
            this.tlpThresholdValue = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTrbThresholdValue = new System.Windows.Forms.Panel();
            this.trbThresholdValue = new System.Windows.Forms.TrackBar();
            this.nudThresholdValue = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.btnBlobTest = new System.Windows.Forms.Button();
            this.cmbBlobPointSelect = new System.Windows.Forms.ComboBox();
            this.tlpBlobSpecification = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaxWidthSize = new System.Windows.Forms.Label();
            this.lblMaxHeightSize = new System.Windows.Forms.Label();
            this.chkOverlay = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.lvBlobResult = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Width = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Height = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tlpTeachParticle.SuspendLayout();
            this.tlpBlobData.SuspendLayout();
            this.tlpBlobParameter.SuspendLayout();
            this.tlpPolarity.SuspendLayout();
            this.lblMaxPixelSizeValue.SuspendLayout();
            this.tlpThresholdValue.SuspendLayout();
            this.pnlTrbThresholdValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresholdValue)).BeginInit();
            this.tlpBlobSpecification.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachParticle
            // 
            this.tlpTeachParticle.ColumnCount = 1;
            this.tlpTeachParticle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachParticle.Controls.Add(this.tlpBlobData, 0, 1);
            this.tlpTeachParticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachParticle.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachParticle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachParticle.Name = "tlpTeachParticle";
            this.tlpTeachParticle.RowCount = 2;
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachParticle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachParticle.Size = new System.Drawing.Size(800, 900);
            this.tlpTeachParticle.TabIndex = 290;
            // 
            // tlpBlobData
            // 
            this.tlpBlobData.ColumnCount = 1;
            this.tlpBlobData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBlobData.Controls.Add(this.tlpBlobParameter, 0, 0);
            this.tlpBlobData.Controls.Add(this.lvBlobResult, 0, 1);
            this.tlpBlobData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobData.Location = new System.Drawing.Point(0, 30);
            this.tlpBlobData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobData.Name = "tlpBlobData";
            this.tlpBlobData.RowCount = 2;
            this.tlpBlobData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpBlobData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpBlobData.Size = new System.Drawing.Size(800, 870);
            this.tlpBlobData.TabIndex = 0;
            // 
            // tlpBlobParameter
            // 
            this.tlpBlobParameter.ColumnCount = 4;
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.Controls.Add(this.lblBlobCount, 0, 0);
            this.tlpBlobParameter.Controls.Add(this.lblBlobCountValue, 1, 0);
            this.tlpBlobParameter.Controls.Add(this.tlpPolarity, 1, 3);
            this.tlpBlobParameter.Controls.Add(this.lblMinPixelSize, 1, 2);
            this.tlpBlobParameter.Controls.Add(this.chkROITracking, 0, 5);
            this.tlpBlobParameter.Controls.Add(this.lblPolarity, 0, 3);
            this.tlpBlobParameter.Controls.Add(this.lblMinimumPixelSize, 0, 2);
            this.tlpBlobParameter.Controls.Add(this.lblMaxSize, 2, 5);
            this.tlpBlobParameter.Controls.Add(this.lblBlobSpecification, 2, 4);
            this.tlpBlobParameter.Controls.Add(this.lblMaxPixelSizeValue, 3, 5);
            this.tlpBlobParameter.Controls.Add(this.tlpThresholdValue, 3, 2);
            this.tlpBlobParameter.Controls.Add(this.lblThreshold, 2, 2);
            this.tlpBlobParameter.Controls.Add(this.cmbBlobPointSelect, 2, 0);
            this.tlpBlobParameter.Controls.Add(this.tlpBlobSpecification, 3, 4);
            this.tlpBlobParameter.Controls.Add(this.btnROIShow, 0, 6);
            this.tlpBlobParameter.Controls.Add(this.btnBlobTest, 3, 7);
            this.tlpBlobParameter.Controls.Add(this.chkOverlay, 2, 7);
            this.tlpBlobParameter.Controls.Add(this.btnConvert, 1, 7);
            this.tlpBlobParameter.Controls.Add(this.btnApply, 0, 7);
            this.tlpBlobParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpBlobParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobParameter.Name = "tlpBlobParameter";
            this.tlpBlobParameter.RowCount = 8;
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tlpBlobParameter.Size = new System.Drawing.Size(800, 522);
            this.tlpBlobParameter.TabIndex = 290;
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.DarkGray;
            this.btnConvert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConvert.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnConvert.Location = new System.Drawing.Point(200, 450);
            this.btnConvert.Margin = new System.Windows.Forms.Padding(0);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(200, 72);
            this.btnConvert.TabIndex = 268;
            this.btnConvert.Text = "CONVERT";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblBlobCount
            // 
            this.lblBlobCount.AutoSize = true;
            this.lblBlobCount.BackColor = System.Drawing.Color.Silver;
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
            // tlpPolarity
            // 
            this.tlpPolarity.ColumnCount = 2;
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Controls.Add(this.rdoBlobLight, 0, 0);
            this.tlpPolarity.Controls.Add(this.rdoBlobDark, 0, 0);
            this.tlpPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPolarity.Location = new System.Drawing.Point(200, 170);
            this.tlpPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPolarity.Name = "tlpPolarity";
            this.tlpPolarity.RowCount = 1;
            this.tlpPolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Size = new System.Drawing.Size(200, 70);
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
            this.rdoBlobLight.Size = new System.Drawing.Size(100, 70);
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
            this.rdoBlobDark.Size = new System.Drawing.Size(100, 70);
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
            this.lblMinPixelSize.Location = new System.Drawing.Point(200, 100);
            this.lblMinPixelSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinPixelSize.Name = "lblMinPixelSize";
            this.lblMinPixelSize.Size = new System.Drawing.Size(200, 70);
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
            this.chkROITracking.Location = new System.Drawing.Point(0, 310);
            this.chkROITracking.Margin = new System.Windows.Forms.Padding(0);
            this.chkROITracking.Name = "chkROITracking";
            this.chkROITracking.Size = new System.Drawing.Size(200, 70);
            this.chkROITracking.TabIndex = 209;
            this.chkROITracking.Text = "ROI Tracking";
            this.chkROITracking.UseVisualStyleBackColor = true;
            this.chkROITracking.CheckedChanged += new System.EventHandler(this.chkROITracking_CheckedChanged);
            // 
            // btnROIShow
            // 
            this.btnROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnROIShow.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnROIShow.Location = new System.Drawing.Point(0, 380);
            this.btnROIShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnROIShow.Name = "btnROIShow";
            this.btnROIShow.Size = new System.Drawing.Size(200, 70);
            this.btnROIShow.TabIndex = 198;
            this.btnROIShow.Text = "SHOW ROI";
            this.btnROIShow.UseVisualStyleBackColor = false;
            this.btnROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // lblPolarity
            // 
            this.lblPolarity.AutoSize = true;
            this.lblPolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPolarity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPolarity.Location = new System.Drawing.Point(0, 170);
            this.lblPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblPolarity.Name = "lblPolarity";
            this.lblPolarity.Size = new System.Drawing.Size(200, 70);
            this.lblPolarity.TabIndex = 4;
            this.lblPolarity.Text = "POLARITY";
            this.lblPolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinimumPixelSize
            // 
            this.lblMinimumPixelSize.AutoSize = true;
            this.lblMinimumPixelSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinimumPixelSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinimumPixelSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMinimumPixelSize.Location = new System.Drawing.Point(0, 100);
            this.lblMinimumPixelSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinimumPixelSize.Name = "lblMinimumPixelSize";
            this.lblMinimumPixelSize.Size = new System.Drawing.Size(200, 70);
            this.lblMinimumPixelSize.TabIndex = 3;
            this.lblMinimumPixelSize.Text = "MIN. PIXEL SIZE";
            this.lblMinimumPixelSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxSize
            // 
            this.lblMaxSize.AutoSize = true;
            this.lblMaxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSize.Location = new System.Drawing.Point(400, 310);
            this.lblMaxSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSize.Name = "lblMaxSize";
            this.lblMaxSize.Size = new System.Drawing.Size(200, 70);
            this.lblMaxSize.TabIndex = 204;
            this.lblMaxSize.Text = "MAX PIXEL SIZE [um]";
            this.lblMaxSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBlobSpecification
            // 
            this.lblBlobSpecification.AutoSize = true;
            this.lblBlobSpecification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBlobSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBlobSpecification.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBlobSpecification.Location = new System.Drawing.Point(400, 240);
            this.lblBlobSpecification.Margin = new System.Windows.Forms.Padding(0);
            this.lblBlobSpecification.Name = "lblBlobSpecification";
            this.lblBlobSpecification.Size = new System.Drawing.Size(200, 70);
            this.lblBlobSpecification.TabIndex = 204;
            this.lblBlobSpecification.Text = "BLOB Spec.";
            this.lblBlobSpecification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxPixelSizeValue
            // 
            this.lblMaxPixelSizeValue.ColumnCount = 2;
            this.lblMaxPixelSizeValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lblMaxPixelSizeValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lblMaxPixelSizeValue.Controls.Add(this.lblMaxHeightSizeValue, 1, 0);
            this.lblMaxPixelSizeValue.Controls.Add(this.lblMaxWidthSizeValue, 0, 0);
            this.lblMaxPixelSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxPixelSizeValue.Location = new System.Drawing.Point(600, 310);
            this.lblMaxPixelSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxPixelSizeValue.Name = "lblMaxPixelSizeValue";
            this.lblMaxPixelSizeValue.RowCount = 1;
            this.lblMaxPixelSizeValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lblMaxPixelSizeValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.lblMaxPixelSizeValue.Size = new System.Drawing.Size(200, 70);
            this.lblMaxPixelSizeValue.TabIndex = 206;
            // 
            // lblMaxHeightSizeValue
            // 
            this.lblMaxHeightSizeValue.AutoSize = true;
            this.lblMaxHeightSizeValue.BackColor = System.Drawing.Color.White;
            this.lblMaxHeightSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxHeightSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxHeightSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxHeightSizeValue.Location = new System.Drawing.Point(100, 0);
            this.lblMaxHeightSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxHeightSizeValue.Name = "lblMaxHeightSizeValue";
            this.lblMaxHeightSizeValue.Size = new System.Drawing.Size(100, 70);
            this.lblMaxHeightSizeValue.TabIndex = 9;
            this.lblMaxHeightSizeValue.Text = "0";
            this.lblMaxHeightSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxHeightSizeValue.Click += new System.EventHandler(this.lblMaxHeightSizeValue_Click);
            // 
            // lblMaxWidthSizeValue
            // 
            this.lblMaxWidthSizeValue.AutoSize = true;
            this.lblMaxWidthSizeValue.BackColor = System.Drawing.Color.White;
            this.lblMaxWidthSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWidthSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxWidthSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxWidthSizeValue.Location = new System.Drawing.Point(0, 0);
            this.lblMaxWidthSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxWidthSizeValue.Name = "lblMaxWidthSizeValue";
            this.lblMaxWidthSizeValue.Size = new System.Drawing.Size(100, 70);
            this.lblMaxWidthSizeValue.TabIndex = 9;
            this.lblMaxWidthSizeValue.Text = "0";
            this.lblMaxWidthSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxWidthSizeValue.Click += new System.EventHandler(this.lblMaxWidthSizeValue_Click);
            // 
            // tlpThresholdValue
            // 
            this.tlpThresholdValue.ColumnCount = 1;
            this.tlpThresholdValue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpThresholdValue.Controls.Add(this.pnlTrbThresholdValue, 0, 0);
            this.tlpThresholdValue.Controls.Add(this.nudThresholdValue, 0, 1);
            this.tlpThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThresholdValue.Location = new System.Drawing.Point(600, 100);
            this.tlpThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.tlpThresholdValue.Name = "tlpThresholdValue";
            this.tlpThresholdValue.RowCount = 2;
            this.tlpThresholdValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThresholdValue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpThresholdValue.Size = new System.Drawing.Size(200, 70);
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
            this.pnlTrbThresholdValue.Size = new System.Drawing.Size(188, 29);
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
            this.trbThresholdValue.Size = new System.Drawing.Size(186, 18);
            this.trbThresholdValue.TabIndex = 208;
            this.trbThresholdValue.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbThresholdValue.Scroll += new System.EventHandler(this.trbThresholdValue_Scroll);
            // 
            // nudThresholdValue
            // 
            this.nudThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.nudThresholdValue.Location = new System.Drawing.Point(0, 39);
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
            this.lblThreshold.BackColor = System.Drawing.Color.Silver;
            this.lblThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblThreshold.Location = new System.Drawing.Point(400, 100);
            this.lblThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(200, 70);
            this.lblThreshold.TabIndex = 2;
            this.lblThreshold.Text = "THRESHOLD";
            this.lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBlobTest
            // 
            this.btnBlobTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnBlobTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlobTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBlobTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnBlobTest.Location = new System.Drawing.Point(600, 450);
            this.btnBlobTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlobTest.Name = "btnBlobTest";
            this.btnBlobTest.Size = new System.Drawing.Size(200, 72);
            this.btnBlobTest.TabIndex = 198;
            this.btnBlobTest.Text = "BLOB TEST";
            this.btnBlobTest.UseVisualStyleBackColor = false;
            this.btnBlobTest.Click += new System.EventHandler(this.btnBlobTest_Click);
            // 
            // cmbBlobPointSelect
            // 
            this.cmbBlobPointSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBlobPointSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBlobPointSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlobPointSelect.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbBlobPointSelect.FormattingEnabled = true;
            this.cmbBlobPointSelect.Location = new System.Drawing.Point(400, 1);
            this.cmbBlobPointSelect.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cmbBlobPointSelect.Name = "cmbBlobPointSelect";
            this.cmbBlobPointSelect.Size = new System.Drawing.Size(200, 28);
            this.cmbBlobPointSelect.TabIndex = 202;
            this.cmbBlobPointSelect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbBlobPointSelect.SelectedIndexChanged += new System.EventHandler(this.cmbBlobPointSelect_SelectedIndexChanged);
            // 
            // tlpBlobSpecification
            // 
            this.tlpBlobSpecification.ColumnCount = 2;
            this.tlpBlobSpecification.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBlobSpecification.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBlobSpecification.Controls.Add(this.lblMaxWidthSize, 0, 0);
            this.tlpBlobSpecification.Controls.Add(this.lblMaxHeightSize, 1, 0);
            this.tlpBlobSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobSpecification.Location = new System.Drawing.Point(600, 240);
            this.tlpBlobSpecification.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobSpecification.Name = "tlpBlobSpecification";
            this.tlpBlobSpecification.RowCount = 1;
            this.tlpBlobSpecification.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBlobSpecification.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpBlobSpecification.Size = new System.Drawing.Size(200, 70);
            this.tlpBlobSpecification.TabIndex = 206;
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
            this.lblMaxWidthSize.Size = new System.Drawing.Size(100, 70);
            this.lblMaxWidthSize.TabIndex = 204;
            this.lblMaxWidthSize.Text = "WIDTH";
            this.lblMaxWidthSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxHeightSize
            // 
            this.lblMaxHeightSize.AutoSize = true;
            this.lblMaxHeightSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxHeightSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxHeightSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxHeightSize.Location = new System.Drawing.Point(100, 0);
            this.lblMaxHeightSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxHeightSize.Name = "lblMaxHeightSize";
            this.lblMaxHeightSize.Size = new System.Drawing.Size(100, 70);
            this.lblMaxHeightSize.TabIndex = 204;
            this.lblMaxHeightSize.Text = "HEIGHT";
            this.lblMaxHeightSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkOverlay
            // 
            this.chkOverlay.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOverlay.AutoSize = true;
            this.chkOverlay.BackColor = System.Drawing.Color.DarkGray;
            this.chkOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOverlay.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkOverlay.Location = new System.Drawing.Point(400, 450);
            this.chkOverlay.Margin = new System.Windows.Forms.Padding(0);
            this.chkOverlay.Name = "chkOverlay";
            this.chkOverlay.Size = new System.Drawing.Size(200, 72);
            this.chkOverlay.TabIndex = 267;
            this.chkOverlay.Text = "OVERLAY";
            this.chkOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOverlay.UseVisualStyleBackColor = false;
            this.chkOverlay.CheckedChanged += new System.EventHandler(this.chkOverlay_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(0, 450);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(200, 72);
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
            this.lvBlobResult.Location = new System.Drawing.Point(0, 522);
            this.lvBlobResult.Margin = new System.Windows.Forms.Padding(0);
            this.lvBlobResult.Name = "lvBlobResult";
            this.lvBlobResult.Size = new System.Drawing.Size(800, 348);
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
            this.lblMaxPixelSizeValue.ResumeLayout(false);
            this.lblMaxPixelSizeValue.PerformLayout();
            this.tlpThresholdValue.ResumeLayout(false);
            this.pnlTrbThresholdValue.ResumeLayout(false);
            this.pnlTrbThresholdValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbThresholdValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThresholdValue)).EndInit();
            this.tlpBlobSpecification.ResumeLayout(false);
            this.tlpBlobSpecification.PerformLayout();
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
        private System.Windows.Forms.Label lblBlobSpecification;
        private System.Windows.Forms.TableLayoutPanel lblMaxPixelSizeValue;
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
        private System.Windows.Forms.TableLayoutPanel tlpBlobSpecification;
        private System.Windows.Forms.Label lblMaxWidthSize;
        private System.Windows.Forms.Label lblMaxHeightSize;
        private System.Windows.Forms.CheckBox chkOverlay;
        private System.Windows.Forms.ListView lvBlobResult;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Width;
        private System.Windows.Forms.ColumnHeader Height;
        private System.Windows.Forms.Button btnConvert;
    }
}
