namespace COG.Controls
{
    partial class CtrlSystemInformation
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lblSystemInfo = new System.Windows.Forms.Label();
            this.pnlSystemInfo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDriveC = new System.Windows.Forms.Panel();
            this.pnlMemory = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlDriveD = new System.Windows.Forms.Panel();
            this.pnlCPU = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlSystemInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlMemory.SuspendLayout();
            this.pnlCPU.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.Gray;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel1.Controls.Add(this.lblSystemInfo);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlSystemInfo);
            this.splitContainer.Size = new System.Drawing.Size(305, 268);
            this.splitContainer.SplitterDistance = 30;
            this.splitContainer.TabIndex = 2;
            this.splitContainer.TabStop = false;
            // 
            // lblSystemInfo
            // 
            this.lblSystemInfo.BackColor = System.Drawing.Color.Gray;
            this.lblSystemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSystemInfo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSystemInfo.Location = new System.Drawing.Point(0, 0);
            this.lblSystemInfo.Margin = new System.Windows.Forms.Padding(3);
            this.lblSystemInfo.Name = "lblSystemInfo";
            this.lblSystemInfo.Size = new System.Drawing.Size(305, 30);
            this.lblSystemInfo.TabIndex = 0;
            this.lblSystemInfo.Text = "System INFO";
            this.lblSystemInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSystemInfo
            // 
            this.pnlSystemInfo.BackColor = System.Drawing.Color.DarkGray;
            this.pnlSystemInfo.Controls.Add(this.tableLayoutPanel1);
            this.pnlSystemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystemInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlSystemInfo.Name = "pnlSystemInfo";
            this.pnlSystemInfo.Size = new System.Drawing.Size(305, 234);
            this.pnlSystemInfo.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pnlDriveC, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlDriveD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pnlCPU, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlMemory, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 234);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // pnlDriveC
            // 
            this.pnlDriveC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriveC.Location = new System.Drawing.Point(3, 3);
            this.pnlDriveC.Name = "pnlDriveC";
            this.pnlDriveC.Size = new System.Drawing.Size(146, 154);
            this.pnlDriveC.TabIndex = 0;
            // 
            // pnlMemory
            // 
            this.pnlMemory.Controls.Add(this.label4);
            this.pnlMemory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemory.Location = new System.Drawing.Point(155, 163);
            this.pnlMemory.Name = "pnlMemory";
            this.pnlMemory.Size = new System.Drawing.Size(147, 134);
            this.pnlMemory.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(2, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Memory Usage(%)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDriveD
            // 
            this.pnlDriveD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDriveD.Location = new System.Drawing.Point(155, 3);
            this.pnlDriveD.Name = "pnlDriveD";
            this.pnlDriveD.Size = new System.Drawing.Size(147, 154);
            this.pnlDriveD.TabIndex = 2;
            // 
            // pnlCPU
            // 
            this.pnlCPU.Controls.Add(this.label3);
            this.pnlCPU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCPU.Location = new System.Drawing.Point(3, 163);
            this.pnlCPU.Name = "pnlCPU";
            this.pnlCPU.Size = new System.Drawing.Size(146, 134);
            this.pnlCPU.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(2, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "CPU Usage(%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlSystemInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "CtrlSystemInformation";
            this.Size = new System.Drawing.Size(305, 268);
            this.Load += new System.EventHandler(this.CtrlSystemInformation_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlSystemInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlMemory.ResumeLayout(false);
            this.pnlCPU.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Label lblSystemInfo;
        private System.Windows.Forms.Panel pnlSystemInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlDriveC;
        private System.Windows.Forms.Panel pnlMemory;
        private System.Windows.Forms.Panel pnlDriveD;
        private System.Windows.Forms.Panel pnlCPU;
        private System.Windows.Forms.Label label3;
    }
}
