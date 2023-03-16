namespace COG.Controls
{
    partial class CtrlCGMSNavigator
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpCGMSNavigator = new System.Windows.Forms.TableLayoutPanel();
            this.lblCGMVSViewer = new System.Windows.Forms.Label();
            this.dgvNavigator = new System.Windows.Forms.DataGridView();
            this.tlpCGMSNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNavigator)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCGMSNavigator
            // 
            this.tlpCGMSNavigator.ColumnCount = 1;
            this.tlpCGMSNavigator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSNavigator.Controls.Add(this.lblCGMVSViewer, 0, 0);
            this.tlpCGMSNavigator.Controls.Add(this.dgvNavigator, 0, 1);
            this.tlpCGMSNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCGMSNavigator.Location = new System.Drawing.Point(0, 0);
            this.tlpCGMSNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCGMSNavigator.Name = "tlpCGMSNavigator";
            this.tlpCGMSNavigator.RowCount = 2;
            this.tlpCGMSNavigator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpCGMSNavigator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSNavigator.Size = new System.Drawing.Size(300, 300);
            this.tlpCGMSNavigator.TabIndex = 1;
            // 
            // lblCGMVSViewer
            // 
            this.lblCGMVSViewer.BackColor = System.Drawing.Color.DarkGray;
            this.lblCGMVSViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCGMVSViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCGMVSViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblCGMVSViewer.Location = new System.Drawing.Point(0, 0);
            this.lblCGMVSViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblCGMVSViewer.Name = "lblCGMVSViewer";
            this.lblCGMVSViewer.Size = new System.Drawing.Size(300, 30);
            this.lblCGMVSViewer.TabIndex = 3;
            this.lblCGMVSViewer.Text = "NAVIGATOR";
            this.lblCGMVSViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvNavigator
            // 
            this.dgvNavigator.AllowUserToAddRows = false;
            this.dgvNavigator.AllowUserToDeleteRows = false;
            this.dgvNavigator.AllowUserToResizeColumns = false;
            this.dgvNavigator.AllowUserToResizeRows = false;
            this.dgvNavigator.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvNavigator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNavigator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvNavigator.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNavigator.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNavigator.EnableHeadersVisualStyles = false;
            this.dgvNavigator.GridColor = System.Drawing.Color.Silver;
            this.dgvNavigator.Location = new System.Drawing.Point(0, 30);
            this.dgvNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNavigator.MultiSelect = false;
            this.dgvNavigator.Name = "dgvNavigator";
            this.dgvNavigator.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNavigator.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNavigator.RowHeadersVisible = false;
            this.dgvNavigator.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dgvNavigator.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNavigator.RowTemplate.Height = 15;
            this.dgvNavigator.RowTemplate.ReadOnly = true;
            this.dgvNavigator.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvNavigator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvNavigator.Size = new System.Drawing.Size(300, 270);
            this.dgvNavigator.TabIndex = 4;
            this.dgvNavigator.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNavigator_CellClick);
            // 
            // CtrlCGMSNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpCGMSNavigator);
            this.Name = "CtrlCGMSNavigator";
            this.Size = new System.Drawing.Size(300, 300);
            this.Load += new System.EventHandler(this.CtrlCGMSNavigator_Load);
            this.tlpCGMSNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNavigator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpCGMSNavigator;
        private System.Windows.Forms.Label lblCGMVSViewer;
        public System.Windows.Forms.DataGridView dgvNavigator;
    }
}
