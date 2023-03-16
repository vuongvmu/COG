namespace COG.Controls
{
    partial class CtrlDefectTrend
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
            this.tlpTrend = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTabButton = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrend = new System.Windows.Forms.Label();
            this.tlpCountButton = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.tlpCount = new System.Windows.Forms.TableLayoutPanel();
            this.btnTwenty = new System.Windows.Forms.Button();
            this.btnFifty = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnHundred = new System.Windows.Forms.Button();
            this.lblChart = new System.Windows.Forms.TableLayoutPanel();
            this.lblParticle = new System.Windows.Forms.Label();
            this.lblShort = new System.Windows.Forms.Label();
            this.pnlChartParticle = new System.Windows.Forms.Panel();
            this.pnlChartShort = new System.Windows.Forms.Panel();
            this.lblDimension = new System.Windows.Forms.Label();
            this.lblCamNo = new System.Windows.Forms.Label();
            this.lblStageNo = new System.Windows.Forms.Label();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblColumn = new System.Windows.Forms.Label();
            this.cmbStageNo = new System.Windows.Forms.ComboBox();
            this.cmbCamNo = new System.Windows.Forms.ComboBox();
            this.cmbRowNo = new System.Windows.Forms.ComboBox();
            this.cmbColNo = new System.Windows.Forms.ComboBox();
            this.pnlChartDimension = new System.Windows.Forms.Panel();
            this.tlpTrend.SuspendLayout();
            this.tlpTabButton.SuspendLayout();
            this.tlpCountButton.SuspendLayout();
            this.tlpCount.SuspendLayout();
            this.lblChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTrend
            // 
            this.tlpTrend.ColumnCount = 1;
            this.tlpTrend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrend.Controls.Add(this.tlpTabButton, 0, 1);
            this.tlpTrend.Controls.Add(this.lblTrend, 0, 0);
            this.tlpTrend.Controls.Add(this.tlpCountButton, 0, 3);
            this.tlpTrend.Controls.Add(this.lblChart, 0, 2);
            this.tlpTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrend.Location = new System.Drawing.Point(0, 0);
            this.tlpTrend.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTrend.Name = "tlpTrend";
            this.tlpTrend.RowCount = 4;
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpTrend.Size = new System.Drawing.Size(731, 544);
            this.tlpTrend.TabIndex = 1;
            // 
            // tlpTabButton
            // 
            this.tlpTabButton.ColumnCount = 8;
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpTabButton.Controls.Add(this.cmbStageNo, 0, 0);
            this.tlpTabButton.Controls.Add(this.lblStageNo, 0, 0);
            this.tlpTabButton.Controls.Add(this.lblCamNo, 2, 0);
            this.tlpTabButton.Controls.Add(this.lblRow, 4, 0);
            this.tlpTabButton.Controls.Add(this.lblColumn, 6, 0);
            this.tlpTabButton.Controls.Add(this.cmbCamNo, 3, 0);
            this.tlpTabButton.Controls.Add(this.cmbRowNo, 5, 0);
            this.tlpTabButton.Controls.Add(this.cmbColNo, 7, 0);
            this.tlpTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTabButton.Location = new System.Drawing.Point(0, 27);
            this.tlpTabButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTabButton.Name = "tlpTabButton";
            this.tlpTabButton.RowCount = 1;
            this.tlpTabButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTabButton.Size = new System.Drawing.Size(731, 27);
            this.tlpTabButton.TabIndex = 5;
            // 
            // lblTrend
            // 
            this.lblTrend.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrend.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrend.Location = new System.Drawing.Point(0, 0);
            this.lblTrend.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrend.Name = "lblTrend";
            this.lblTrend.Size = new System.Drawing.Size(731, 27);
            this.lblTrend.TabIndex = 2;
            this.lblTrend.Text = "Trend";
            this.lblTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCountButton
            // 
            this.tlpCountButton.ColumnCount = 2;
            this.tlpCountButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpCountButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCountButton.Controls.Add(this.lblCount, 0, 0);
            this.tlpCountButton.Controls.Add(this.tlpCount, 1, 0);
            this.tlpCountButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCountButton.Location = new System.Drawing.Point(0, 516);
            this.tlpCountButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCountButton.Name = "tlpCountButton";
            this.tlpCountButton.RowCount = 1;
            this.tlpCountButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCountButton.Size = new System.Drawing.Size(731, 28);
            this.tlpCountButton.TabIndex = 4;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.Gray;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(0, 0);
            this.lblCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(100, 28);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "Count :";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCount
            // 
            this.tlpCount.ColumnCount = 7;
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCount.Controls.Add(this.btnTwenty, 1, 0);
            this.tlpCount.Controls.Add(this.btnFifty, 3, 0);
            this.tlpCount.Controls.Add(this.chkAll, 6, 0);
            this.tlpCount.Controls.Add(this.btnHundred, 5, 0);
            this.tlpCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCount.Location = new System.Drawing.Point(100, 0);
            this.tlpCount.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCount.Name = "tlpCount";
            this.tlpCount.RowCount = 1;
            this.tlpCount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCount.Size = new System.Drawing.Size(631, 28);
            this.tlpCount.TabIndex = 8;
            // 
            // btnTwenty
            // 
            this.btnTwenty.BackColor = System.Drawing.Color.DarkGray;
            this.btnTwenty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTwenty.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnTwenty.Location = new System.Drawing.Point(20, 0);
            this.btnTwenty.Margin = new System.Windows.Forms.Padding(0);
            this.btnTwenty.Name = "btnTwenty";
            this.btnTwenty.Size = new System.Drawing.Size(80, 28);
            this.btnTwenty.TabIndex = 0;
            this.btnTwenty.Text = "20";
            this.btnTwenty.UseVisualStyleBackColor = false;
            this.btnTwenty.Click += new System.EventHandler(this.btnTwenty_Click);
            // 
            // btnFifty
            // 
            this.btnFifty.BackColor = System.Drawing.Color.DarkGray;
            this.btnFifty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFifty.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnFifty.Location = new System.Drawing.Point(120, 0);
            this.btnFifty.Margin = new System.Windows.Forms.Padding(0);
            this.btnFifty.Name = "btnFifty";
            this.btnFifty.Size = new System.Drawing.Size(80, 28);
            this.btnFifty.TabIndex = 1;
            this.btnFifty.Text = "50";
            this.btnFifty.UseVisualStyleBackColor = false;
            this.btnFifty.Click += new System.EventHandler(this.btnFifty_Click);
            // 
            // chkAll
            // 
            this.chkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.SystemColors.Control;
            this.chkAll.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.chkAll.Location = new System.Drawing.Point(300, 0);
            this.chkAll.Margin = new System.Windows.Forms.Padding(0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(39, 28);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "All";
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.Visible = false;
            // 
            // btnHundred
            // 
            this.btnHundred.BackColor = System.Drawing.Color.DarkGray;
            this.btnHundred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHundred.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnHundred.Location = new System.Drawing.Point(220, 0);
            this.btnHundred.Margin = new System.Windows.Forms.Padding(0);
            this.btnHundred.Name = "btnHundred";
            this.btnHundred.Size = new System.Drawing.Size(80, 28);
            this.btnHundred.TabIndex = 2;
            this.btnHundred.Text = "100";
            this.btnHundred.UseVisualStyleBackColor = false;
            this.btnHundred.Click += new System.EventHandler(this.btnHundred_Click);
            // 
            // lblChart
            // 
            this.lblChart.ColumnCount = 5;
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.846154F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.846154F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.76923F));
            this.lblChart.Controls.Add(this.lblDimension, 4, 0);
            this.lblChart.Controls.Add(this.lblParticle, 0, 0);
            this.lblChart.Controls.Add(this.lblShort, 2, 0);
            this.lblChart.Controls.Add(this.pnlChartParticle, 0, 1);
            this.lblChart.Controls.Add(this.pnlChartShort, 2, 1);
            this.lblChart.Controls.Add(this.pnlChartDimension, 4, 1);
            this.lblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart.Location = new System.Drawing.Point(0, 54);
            this.lblChart.Margin = new System.Windows.Forms.Padding(0);
            this.lblChart.Name = "lblChart";
            this.lblChart.RowCount = 2;
            this.lblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.lblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.lblChart.Size = new System.Drawing.Size(731, 462);
            this.lblChart.TabIndex = 6;
            // 
            // lblParticle
            // 
            this.lblParticle.BackColor = System.Drawing.Color.Gray;
            this.lblParticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParticle.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblParticle.Location = new System.Drawing.Point(0, 0);
            this.lblParticle.Margin = new System.Windows.Forms.Padding(0);
            this.lblParticle.Name = "lblParticle";
            this.lblParticle.Size = new System.Drawing.Size(224, 23);
            this.lblParticle.TabIndex = 5;
            this.lblParticle.Text = "Particle";
            this.lblParticle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShort
            // 
            this.lblShort.BackColor = System.Drawing.Color.Gray;
            this.lblShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShort.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblShort.Location = new System.Drawing.Point(252, 0);
            this.lblShort.Margin = new System.Windows.Forms.Padding(0);
            this.lblShort.Name = "lblShort";
            this.lblShort.Size = new System.Drawing.Size(224, 23);
            this.lblShort.TabIndex = 6;
            this.lblShort.Text = "Short";
            this.lblShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlChartParticle
            // 
            this.pnlChartParticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartParticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartParticle.Location = new System.Drawing.Point(0, 23);
            this.pnlChartParticle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartParticle.Name = "pnlChartParticle";
            this.pnlChartParticle.Size = new System.Drawing.Size(224, 439);
            this.pnlChartParticle.TabIndex = 9;
            // 
            // pnlChartShort
            // 
            this.pnlChartShort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartShort.Location = new System.Drawing.Point(252, 23);
            this.pnlChartShort.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartShort.Name = "pnlChartShort";
            this.pnlChartShort.Size = new System.Drawing.Size(224, 439);
            this.pnlChartShort.TabIndex = 9;
            // 
            // lblDimension
            // 
            this.lblDimension.BackColor = System.Drawing.Color.Gray;
            this.lblDimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimension.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimension.Location = new System.Drawing.Point(504, 0);
            this.lblDimension.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimension.Name = "lblDimension";
            this.lblDimension.Size = new System.Drawing.Size(227, 23);
            this.lblDimension.TabIndex = 10;
            this.lblDimension.Text = "Dimension";
            this.lblDimension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCamNo
            // 
            this.lblCamNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCamNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCamNo.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCamNo.Location = new System.Drawing.Point(188, 3);
            this.lblCamNo.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblCamNo.Name = "lblCamNo";
            this.lblCamNo.Size = new System.Drawing.Size(79, 21);
            this.lblCamNo.TabIndex = 290;
            this.lblCamNo.Text = "CAM";
            this.lblCamNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStageNo
            // 
            this.lblStageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStageNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStageNo.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblStageNo.Location = new System.Drawing.Point(6, 3);
            this.lblStageNo.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblStageNo.Name = "lblStageNo";
            this.lblStageNo.Size = new System.Drawing.Size(79, 21);
            this.lblStageNo.TabIndex = 290;
            this.lblStageNo.Text = "STAGE";
            this.lblStageNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRow
            // 
            this.lblRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRow.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblRow.Location = new System.Drawing.Point(370, 3);
            this.lblRow.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(79, 21);
            this.lblRow.TabIndex = 290;
            this.lblRow.Text = "ROW";
            this.lblRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColumn
            // 
            this.lblColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblColumn.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblColumn.Location = new System.Drawing.Point(552, 3);
            this.lblColumn.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(79, 21);
            this.lblColumn.TabIndex = 290;
            this.lblColumn.Text = "COL";
            this.lblColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbStageNo
            // 
            this.cmbStageNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStageNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStageNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStageNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStageNo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.cmbStageNo.FormattingEnabled = true;
            this.cmbStageNo.Location = new System.Drawing.Point(94, 3);
            this.cmbStageNo.Name = "cmbStageNo";
            this.cmbStageNo.Size = new System.Drawing.Size(85, 30);
            this.cmbStageNo.TabIndex = 291;
            this.cmbStageNo.SelectedIndexChanged += new System.EventHandler(this.cmbStageNo_SelectedIndexChanged);
            // 
            // cmbCamNo
            // 
            this.cmbCamNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCamNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCamNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCamNo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.cmbCamNo.FormattingEnabled = true;
            this.cmbCamNo.Location = new System.Drawing.Point(276, 3);
            this.cmbCamNo.Name = "cmbCamNo";
            this.cmbCamNo.Size = new System.Drawing.Size(85, 30);
            this.cmbCamNo.TabIndex = 291;
            this.cmbCamNo.SelectedIndexChanged += new System.EventHandler(this.cmbCamNo_SelectedIndexChanged);
            // 
            // cmbRowNo
            // 
            this.cmbRowNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRowNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRowNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRowNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbRowNo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.cmbRowNo.FormattingEnabled = true;
            this.cmbRowNo.Location = new System.Drawing.Point(458, 3);
            this.cmbRowNo.Name = "cmbRowNo";
            this.cmbRowNo.Size = new System.Drawing.Size(85, 30);
            this.cmbRowNo.TabIndex = 291;
            this.cmbRowNo.SelectedIndexChanged += new System.EventHandler(this.cmbRowNo_SelectedIndexChanged);
            // 
            // cmbColNo
            // 
            this.cmbColNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbColNo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbColNo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.cmbColNo.FormattingEnabled = true;
            this.cmbColNo.Location = new System.Drawing.Point(640, 3);
            this.cmbColNo.Name = "cmbColNo";
            this.cmbColNo.Size = new System.Drawing.Size(88, 30);
            this.cmbColNo.TabIndex = 291;
            this.cmbColNo.SelectedIndexChanged += new System.EventHandler(this.cmbColNo_SelectedIndexChanged);
            // 
            // pnlChartDimension
            // 
            this.pnlChartDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartDimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartDimension.Location = new System.Drawing.Point(504, 23);
            this.pnlChartDimension.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartDimension.Name = "pnlChartDimension";
            this.pnlChartDimension.Size = new System.Drawing.Size(227, 439);
            this.pnlChartDimension.TabIndex = 9;
            // 
            // CtrlDefectTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTrend);
            this.Name = "CtrlDefectTrend";
            this.Size = new System.Drawing.Size(731, 544);
            this.Load += new System.EventHandler(this.CtrlDefectTrend_Load);
            this.tlpTrend.ResumeLayout(false);
            this.tlpTabButton.ResumeLayout(false);
            this.tlpCountButton.ResumeLayout(false);
            this.tlpCount.ResumeLayout(false);
            this.tlpCount.PerformLayout();
            this.lblChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTrend;
        private System.Windows.Forms.TableLayoutPanel tlpTabButton;
        private System.Windows.Forms.Label lblTrend;
        private System.Windows.Forms.TableLayoutPanel tlpCountButton;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TableLayoutPanel tlpCount;
        private System.Windows.Forms.Button btnTwenty;
        private System.Windows.Forms.Button btnFifty;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnHundred;
        private System.Windows.Forms.TableLayoutPanel lblChart;
        private System.Windows.Forms.Label lblParticle;
        private System.Windows.Forms.Label lblShort;
        private System.Windows.Forms.Panel pnlChartParticle;
        private System.Windows.Forms.Panel pnlChartShort;
        private System.Windows.Forms.Label lblDimension;
        private System.Windows.Forms.Label lblCamNo;
        private System.Windows.Forms.Label lblStageNo;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.ComboBox cmbStageNo;
        private System.Windows.Forms.ComboBox cmbCamNo;
        private System.Windows.Forms.ComboBox cmbRowNo;
        private System.Windows.Forms.ComboBox cmbColNo;
        private System.Windows.Forms.Panel pnlChartDimension;
    }
}
