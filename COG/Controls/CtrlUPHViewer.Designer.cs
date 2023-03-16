namespace COG.Controls
{
    partial class CtrlUPHViewer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpFunction = new System.Windows.Forms.TableLayoutPanel();
            this.lblDownload = new System.Windows.Forms.Label();
            this.lblTotalFail = new System.Windows.Forms.Label();
            this.lblTotalNG = new System.Windows.Forms.Label();
            this.lblTotalOK = new System.Windows.Forms.Label();
            this.lblTotalProduction = new System.Windows.Forms.Label();
            this.cdrMonthCalendar = new System.Windows.Forms.MonthCalendar();
            this.tlpDataViewer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCircleChart = new System.Windows.Forms.Panel();
            this.chartCircle = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlListView = new System.Windows.Forms.Panel();
            this.dgvProduction = new System.Windows.Forms.DataGridView();
            this.pnlBarChart = new System.Windows.Forms.Panel();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpUPHViewer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFunction.SuspendLayout();
            this.tlpDataViewer.SuspendLayout();
            this.pnlCircleChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCircle)).BeginInit();
            this.pnlListView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduction)).BeginInit();
            this.pnlBarChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            this.tlpUPHViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFunction
            // 
            this.tlpFunction.ColumnCount = 6;
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpFunction.Controls.Add(this.lblDownload, 4, 0);
            this.tlpFunction.Controls.Add(this.lblTotalFail, 3, 0);
            this.tlpFunction.Controls.Add(this.lblTotalNG, 2, 0);
            this.tlpFunction.Controls.Add(this.lblTotalOK, 1, 0);
            this.tlpFunction.Controls.Add(this.lblTotalProduction, 0, 0);
            this.tlpFunction.Controls.Add(this.cdrMonthCalendar, 5, 0);
            this.tlpFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFunction.Name = "tlpFunction";
            this.tlpFunction.RowCount = 1;
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFunction.Size = new System.Drawing.Size(1200, 60);
            this.tlpFunction.TabIndex = 0;
            // 
            // lblDownload
            // 
            this.lblDownload.BackColor = System.Drawing.Color.DarkGray;
            this.lblDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDownload.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblDownload.Location = new System.Drawing.Point(802, 3);
            this.lblDownload.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(187, 54);
            this.lblDownload.TabIndex = 4;
            this.lblDownload.Text = "DOWNLOAD";
            this.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDownload.Click += new System.EventHandler(this.lblDownload_Click);
            // 
            // lblTotalFail
            // 
            this.lblTotalFail.BackColor = System.Drawing.Color.DarkGray;
            this.lblTotalFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalFail.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalFail.Location = new System.Drawing.Point(603, 3);
            this.lblTotalFail.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTotalFail.Name = "lblTotalFail";
            this.lblTotalFail.Size = new System.Drawing.Size(187, 54);
            this.lblTotalFail.TabIndex = 3;
            this.lblTotalFail.Text = "TOTAL\r\nFAIL : 0";
            this.lblTotalFail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalFail.Click += new System.EventHandler(this.lblTotalFail_Click);
            // 
            // lblTotalNG
            // 
            this.lblTotalNG.BackColor = System.Drawing.Color.DarkGray;
            this.lblTotalNG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalNG.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalNG.Location = new System.Drawing.Point(404, 3);
            this.lblTotalNG.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTotalNG.Name = "lblTotalNG";
            this.lblTotalNG.Size = new System.Drawing.Size(187, 54);
            this.lblTotalNG.TabIndex = 2;
            this.lblTotalNG.Text = "TOTAL\r\nNG : 0";
            this.lblTotalNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalNG.Click += new System.EventHandler(this.lblTotalNG_Click);
            // 
            // lblTotalOK
            // 
            this.lblTotalOK.BackColor = System.Drawing.Color.DarkGray;
            this.lblTotalOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalOK.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalOK.Location = new System.Drawing.Point(205, 3);
            this.lblTotalOK.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTotalOK.Name = "lblTotalOK";
            this.lblTotalOK.Size = new System.Drawing.Size(187, 54);
            this.lblTotalOK.TabIndex = 1;
            this.lblTotalOK.Text = "TOTAL\r\nOK : 0";
            this.lblTotalOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalOK.Click += new System.EventHandler(this.lblTotalOK_Click);
            // 
            // lblTotalProduction
            // 
            this.lblTotalProduction.BackColor = System.Drawing.Color.DarkGray;
            this.lblTotalProduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalProduction.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalProduction.Location = new System.Drawing.Point(6, 3);
            this.lblTotalProduction.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTotalProduction.Name = "lblTotalProduction";
            this.lblTotalProduction.Size = new System.Drawing.Size(187, 54);
            this.lblTotalProduction.TabIndex = 0;
            this.lblTotalProduction.Text = "TOTAL\r\nPRODUCTION : 0";
            this.lblTotalProduction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalProduction.Click += new System.EventHandler(this.lblTotalProduction_Click);
            // 
            // cdrMonthCalendar
            // 
            this.cdrMonthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cdrMonthCalendar.Location = new System.Drawing.Point(995, 0);
            this.cdrMonthCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.cdrMonthCalendar.Name = "cdrMonthCalendar";
            this.cdrMonthCalendar.TabIndex = 5;
            this.cdrMonthCalendar.Visible = false;
            this.cdrMonthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cdrCalendar_DateChanged);
            // 
            // tlpDataViewer
            // 
            this.tlpDataViewer.ColumnCount = 2;
            this.tlpDataViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDataViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpDataViewer.Controls.Add(this.pnlCircleChart, 0, 0);
            this.tlpDataViewer.Controls.Add(this.pnlListView, 1, 0);
            this.tlpDataViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDataViewer.Location = new System.Drawing.Point(3, 63);
            this.tlpDataViewer.Name = "tlpDataViewer";
            this.tlpDataViewer.RowCount = 1;
            this.tlpDataViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDataViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tlpDataViewer.Size = new System.Drawing.Size(1194, 264);
            this.tlpDataViewer.TabIndex = 0;
            // 
            // pnlCircleChart
            // 
            this.pnlCircleChart.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCircleChart.Controls.Add(this.chartCircle);
            this.pnlCircleChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCircleChart.Location = new System.Drawing.Point(10, 10);
            this.pnlCircleChart.Margin = new System.Windows.Forms.Padding(10);
            this.pnlCircleChart.Name = "pnlCircleChart";
            this.pnlCircleChart.Size = new System.Drawing.Size(577, 244);
            this.pnlCircleChart.TabIndex = 0;
            // 
            // chartCircle
            // 
            this.chartCircle.BackColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.Silver;
            chartArea1.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartCircle.ChartAreas.Add(chartArea1);
            this.chartCircle.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.Silver;
            legend1.Name = "Legend1";
            this.chartCircle.Legends.Add(legend1);
            this.chartCircle.Location = new System.Drawing.Point(0, 0);
            this.chartCircle.Name = "chartCircle";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartCircle.Series.Add(series1);
            this.chartCircle.Size = new System.Drawing.Size(573, 240);
            this.chartCircle.TabIndex = 1;
            this.chartCircle.Text = "Circle";
            // 
            // pnlListView
            // 
            this.pnlListView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlListView.Controls.Add(this.dgvProduction);
            this.pnlListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListView.Location = new System.Drawing.Point(607, 10);
            this.pnlListView.Margin = new System.Windows.Forms.Padding(10);
            this.pnlListView.Name = "pnlListView";
            this.pnlListView.Size = new System.Drawing.Size(577, 244);
            this.pnlListView.TabIndex = 1;
            // 
            // dgvProduction
            // 
            this.dgvProduction.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvProduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduction.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProduction.Location = new System.Drawing.Point(0, 0);
            this.dgvProduction.Name = "dgvProduction";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduction.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProduction.RowTemplate.Height = 23;
            this.dgvProduction.Size = new System.Drawing.Size(573, 240);
            this.dgvProduction.TabIndex = 0;
            // 
            // pnlBarChart
            // 
            this.pnlBarChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBarChart.Controls.Add(this.chartBar);
            this.pnlBarChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBarChart.Location = new System.Drawing.Point(10, 340);
            this.pnlBarChart.Margin = new System.Windows.Forms.Padding(10);
            this.pnlBarChart.Name = "pnlBarChart";
            this.pnlBarChart.Size = new System.Drawing.Size(1180, 250);
            this.pnlBarChart.TabIndex = 1;
            // 
            // chartBar
            // 
            this.chartBar.BackColor = System.Drawing.Color.Silver;
            this.chartBar.BorderlineColor = System.Drawing.Color.Black;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.BackColor = System.Drawing.Color.Silver;
            chartArea2.BackImageTransparentColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            this.chartBar.ChartAreas.Add(chartArea2);
            this.chartBar.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.BackColor = System.Drawing.Color.Silver;
            legend2.Name = "Legend1";
            legend2.ShadowColor = System.Drawing.Color.Silver;
            this.chartBar.Legends.Add(legend2);
            this.chartBar.Location = new System.Drawing.Point(0, 0);
            this.chartBar.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.chartBar.Name = "chartBar";
            series2.ChartArea = "ChartArea1";
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartBar.Series.Add(series2);
            this.chartBar.Size = new System.Drawing.Size(1178, 248);
            this.chartBar.TabIndex = 1;
            this.chartBar.Text = "Bar";
            // 
            // tlpUPHViewer
            // 
            this.tlpUPHViewer.ColumnCount = 1;
            this.tlpUPHViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUPHViewer.Controls.Add(this.pnlBarChart, 0, 2);
            this.tlpUPHViewer.Controls.Add(this.tlpDataViewer, 0, 1);
            this.tlpUPHViewer.Controls.Add(this.tlpFunction, 0, 0);
            this.tlpUPHViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUPHViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpUPHViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUPHViewer.Name = "tlpUPHViewer";
            this.tlpUPHViewer.RowCount = 3;
            this.tlpUPHViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpUPHViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpUPHViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpUPHViewer.Size = new System.Drawing.Size(1200, 600);
            this.tlpUPHViewer.TabIndex = 1;
            // 
            // CtrlUPHViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpUPHViewer);
            this.Name = "CtrlUPHViewer";
            this.Size = new System.Drawing.Size(1200, 600);
            this.Load += new System.EventHandler(this.CtrlUPHViewer_Load);
            this.tlpFunction.ResumeLayout(false);
            this.tlpDataViewer.ResumeLayout(false);
            this.pnlCircleChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCircle)).EndInit();
            this.pnlListView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduction)).EndInit();
            this.pnlBarChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            this.tlpUPHViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpFunction;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label lblTotalFail;
        private System.Windows.Forms.Label lblTotalNG;
        private System.Windows.Forms.Label lblTotalOK;
        private System.Windows.Forms.Label lblTotalProduction;
        private System.Windows.Forms.MonthCalendar cdrMonthCalendar;
        private System.Windows.Forms.TableLayoutPanel tlpDataViewer;
        private System.Windows.Forms.Panel pnlListView;
        private System.Windows.Forms.Panel pnlBarChart;
        private System.Windows.Forms.Panel pnlCircleChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCircle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        private System.Windows.Forms.DataGridView dgvProduction;
        private System.Windows.Forms.TableLayoutPanel tlpUPHViewer;
    }
}
