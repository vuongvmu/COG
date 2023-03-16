namespace COG.Controls
{
    partial class CtrlAlignTrend
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
            this.lblTab = new System.Windows.Forms.Label();
            this.pnlTabButton = new System.Windows.Forms.Panel();
            this.lblTrend = new System.Windows.Forms.Label();
            this.tlpCountButton = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount = new System.Windows.Forms.Label();
            this.tlpCount = new System.Windows.Forms.TableLayoutPanel();
            this.btnTwenty = new System.Windows.Forms.Button();
            this.btnFifty = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnHundred = new System.Windows.Forms.Button();
            this.lblChart = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlignX = new System.Windows.Forms.Label();
            this.lblAlignY = new System.Windows.Forms.Label();
            this.pnlChartAlignX = new System.Windows.Forms.Panel();
            this.pnlChartAlignY = new System.Windows.Forms.Panel();
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
            this.tlpTrend.Size = new System.Drawing.Size(900, 600);
            this.tlpTrend.TabIndex = 0;
            // 
            // tlpTabButton
            // 
            this.tlpTabButton.ColumnCount = 2;
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTabButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTabButton.Controls.Add(this.lblTab, 0, 0);
            this.tlpTabButton.Controls.Add(this.pnlTabButton, 1, 0);
            this.tlpTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTabButton.Location = new System.Drawing.Point(0, 30);
            this.tlpTabButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTabButton.Name = "tlpTabButton";
            this.tlpTabButton.RowCount = 1;
            this.tlpTabButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTabButton.Size = new System.Drawing.Size(900, 30);
            this.tlpTabButton.TabIndex = 5;
            // 
            // lblTab
            // 
            this.lblTab.BackColor = System.Drawing.Color.Gray;
            this.lblTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTab.Location = new System.Drawing.Point(0, 0);
            this.lblTab.Margin = new System.Windows.Forms.Padding(0);
            this.lblTab.Name = "lblTab";
            this.lblTab.Size = new System.Drawing.Size(100, 30);
            this.lblTab.TabIndex = 4;
            this.lblTab.Text = "Tab :";
            this.lblTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTabButton
            // 
            this.pnlTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabButton.Location = new System.Drawing.Point(100, 0);
            this.pnlTabButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTabButton.Name = "pnlTabButton";
            this.pnlTabButton.Size = new System.Drawing.Size(800, 30);
            this.pnlTabButton.TabIndex = 3;
            // 
            // lblTrend
            // 
            this.lblTrend.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrend.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblTrend.Location = new System.Drawing.Point(0, 0);
            this.lblTrend.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrend.Name = "lblTrend";
            this.lblTrend.Size = new System.Drawing.Size(900, 30);
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
            this.tlpCountButton.Location = new System.Drawing.Point(0, 570);
            this.tlpCountButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCountButton.Name = "tlpCountButton";
            this.tlpCountButton.RowCount = 1;
            this.tlpCountButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCountButton.Size = new System.Drawing.Size(900, 30);
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
            this.lblCount.Size = new System.Drawing.Size(100, 30);
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
            this.tlpCount.Size = new System.Drawing.Size(800, 30);
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
            this.btnTwenty.Size = new System.Drawing.Size(80, 30);
            this.btnTwenty.TabIndex = 0;
            this.btnTwenty.Text = "20";
            this.btnTwenty.UseVisualStyleBackColor = false;
            this.btnTwenty.Click += new System.EventHandler(this.btnThity_Click);
            // 
            // btnFifty
            // 
            this.btnFifty.BackColor = System.Drawing.Color.DarkGray;
            this.btnFifty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFifty.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnFifty.Location = new System.Drawing.Point(120, 0);
            this.btnFifty.Margin = new System.Windows.Forms.Padding(0);
            this.btnFifty.Name = "btnFifty";
            this.btnFifty.Size = new System.Drawing.Size(80, 30);
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
            this.chkAll.Size = new System.Drawing.Size(39, 30);
            this.chkAll.TabIndex = 5;
            this.chkAll.Text = "All";
            this.chkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnHundred
            // 
            this.btnHundred.BackColor = System.Drawing.Color.DarkGray;
            this.btnHundred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHundred.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnHundred.Location = new System.Drawing.Point(220, 0);
            this.btnHundred.Margin = new System.Windows.Forms.Padding(0);
            this.btnHundred.Name = "btnHundred";
            this.btnHundred.Size = new System.Drawing.Size(80, 30);
            this.btnHundred.TabIndex = 2;
            this.btnHundred.Text = "100";
            this.btnHundred.UseVisualStyleBackColor = false;
            this.btnHundred.Click += new System.EventHandler(this.btnHundred_Click);
            // 
            // lblChart
            // 
            this.lblChart.ColumnCount = 3;
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.lblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lblChart.Controls.Add(this.lblAlignX, 0, 0);
            this.lblChart.Controls.Add(this.lblAlignY, 2, 0);
            this.lblChart.Controls.Add(this.pnlChartAlignX, 0, 1);
            this.lblChart.Controls.Add(this.pnlChartAlignY, 2, 1);
            this.lblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChart.Location = new System.Drawing.Point(0, 60);
            this.lblChart.Margin = new System.Windows.Forms.Padding(0);
            this.lblChart.Name = "lblChart";
            this.lblChart.RowCount = 2;
            this.lblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.lblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.lblChart.Size = new System.Drawing.Size(900, 510);
            this.lblChart.TabIndex = 6;
            // 
            // lblAlignX
            // 
            this.lblAlignX.BackColor = System.Drawing.Color.Gray;
            this.lblAlignX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignX.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlignX.Location = new System.Drawing.Point(0, 0);
            this.lblAlignX.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlignX.Name = "lblAlignX";
            this.lblAlignX.Size = new System.Drawing.Size(440, 25);
            this.lblAlignX.TabIndex = 5;
            this.lblAlignX.Text = "Align X";
            this.lblAlignX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlignY
            // 
            this.lblAlignY.BackColor = System.Drawing.Color.Gray;
            this.lblAlignY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignY.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlignY.Location = new System.Drawing.Point(460, 0);
            this.lblAlignY.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlignY.Name = "lblAlignY";
            this.lblAlignY.Size = new System.Drawing.Size(440, 25);
            this.lblAlignY.TabIndex = 6;
            this.lblAlignY.Text = "Align Y";
            this.lblAlignY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlChartAlignX
            // 
            this.pnlChartAlignX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartAlignX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartAlignX.Location = new System.Drawing.Point(0, 25);
            this.pnlChartAlignX.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartAlignX.Name = "pnlChartAlignX";
            this.pnlChartAlignX.Size = new System.Drawing.Size(440, 485);
            this.pnlChartAlignX.TabIndex = 9;
            // 
            // pnlChartAlignY
            // 
            this.pnlChartAlignY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlChartAlignY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartAlignY.Location = new System.Drawing.Point(460, 25);
            this.pnlChartAlignY.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartAlignY.Name = "pnlChartAlignY";
            this.pnlChartAlignY.Size = new System.Drawing.Size(440, 485);
            this.pnlChartAlignY.TabIndex = 9;
            // 
            // CtrlAlignTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTrend);
            this.Name = "CtrlAlignTrend";
            this.Size = new System.Drawing.Size(900, 600);
            this.Load += new System.EventHandler(this.CtrlTrend_Load);
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
        private System.Windows.Forms.Label lblTrend;
        private System.Windows.Forms.Panel pnlTabButton;
        private System.Windows.Forms.TableLayoutPanel tlpTabButton;
        private System.Windows.Forms.Label lblTab;
        private System.Windows.Forms.TableLayoutPanel tlpCountButton;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TableLayoutPanel tlpCount;
        private System.Windows.Forms.Button btnTwenty;
        private System.Windows.Forms.Button btnFifty;
        private System.Windows.Forms.Button btnHundred;
        private System.Windows.Forms.TableLayoutPanel lblChart;
        private System.Windows.Forms.Label lblAlignX;
        private System.Windows.Forms.Label lblAlignY;
        private System.Windows.Forms.Panel pnlChartAlignX;
        private System.Windows.Forms.Panel pnlChartAlignY;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
