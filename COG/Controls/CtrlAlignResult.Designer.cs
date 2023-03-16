namespace COG.Controls
{
    partial class CtrlAlignResult
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAlignHistory = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPanelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJudge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlignLeftX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlignLeftY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlignRightX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlignRightY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlignCenterX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlignHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlignHistory
            // 
            this.dgvAlignHistory.AllowUserToAddRows = false;
            this.dgvAlignHistory.AllowUserToDeleteRows = false;
            this.dgvAlignHistory.AllowUserToResizeRows = false;
            this.dgvAlignHistory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvAlignHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlignHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlignHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlignHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colPanelID,
            this.colTab,
            this.colJudge,
            this.colAlignLeftX,
            this.colAlignLeftY,
            this.colAlignRightX,
            this.colAlignRightY,
            this.colAlignCenterX});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlignHistory.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvAlignHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlignHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvAlignHistory.Margin = new System.Windows.Forms.Padding(0);
            this.dgvAlignHistory.MultiSelect = false;
            this.dgvAlignHistory.Name = "dgvAlignHistory";
            this.dgvAlignHistory.ReadOnly = true;
            this.dgvAlignHistory.RowHeadersVisible = false;
            this.dgvAlignHistory.RowTemplate.Height = 23;
            this.dgvAlignHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAlignHistory.Size = new System.Drawing.Size(400, 300);
            this.dgvAlignHistory.TabIndex = 1;
            // 
            // colTime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 100;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colPanelID
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colPanelID.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPanelID.HeaderText = "Panel ID";
            this.colPanelID.MinimumWidth = 100;
            this.colPanelID.Name = "colPanelID";
            this.colPanelID.ReadOnly = true;
            this.colPanelID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPanelID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colTab
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTab.DefaultCellStyle = dataGridViewCellStyle4;
            this.colTab.HeaderText = "Tab";
            this.colTab.MinimumWidth = 35;
            this.colTab.Name = "colTab";
            this.colTab.ReadOnly = true;
            this.colTab.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTab.Width = 35;
            // 
            // colJudge
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colJudge.DefaultCellStyle = dataGridViewCellStyle5;
            this.colJudge.HeaderText = "Judge";
            this.colJudge.MinimumWidth = 50;
            this.colJudge.Name = "colJudge";
            this.colJudge.ReadOnly = true;
            this.colJudge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colJudge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colJudge.Width = 50;
            // 
            // colAlignLeftX
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAlignLeftX.DefaultCellStyle = dataGridViewCellStyle6;
            this.colAlignLeftX.HeaderText = "Left_X";
            this.colAlignLeftX.MinimumWidth = 50;
            this.colAlignLeftX.Name = "colAlignLeftX";
            this.colAlignLeftX.ReadOnly = true;
            this.colAlignLeftX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlignLeftX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlignLeftX.Width = 50;
            // 
            // colAlignLeftY
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAlignLeftY.DefaultCellStyle = dataGridViewCellStyle7;
            this.colAlignLeftY.HeaderText = "Left_Y";
            this.colAlignLeftY.MinimumWidth = 50;
            this.colAlignLeftY.Name = "colAlignLeftY";
            this.colAlignLeftY.ReadOnly = true;
            this.colAlignLeftY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlignLeftY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlignLeftY.Width = 50;
            // 
            // colAlignRightX
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAlignRightX.DefaultCellStyle = dataGridViewCellStyle8;
            this.colAlignRightX.HeaderText = "Right_X";
            this.colAlignRightX.MinimumWidth = 50;
            this.colAlignRightX.Name = "colAlignRightX";
            this.colAlignRightX.ReadOnly = true;
            this.colAlignRightX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlignRightX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlignRightX.Width = 50;
            // 
            // colAlignRightY
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAlignRightY.DefaultCellStyle = dataGridViewCellStyle9;
            this.colAlignRightY.HeaderText = "Right_Y";
            this.colAlignRightY.MinimumWidth = 50;
            this.colAlignRightY.Name = "colAlignRightY";
            this.colAlignRightY.ReadOnly = true;
            this.colAlignRightY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlignRightY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlignRightY.Width = 50;
            // 
            // colAlignCenterX
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colAlignCenterX.DefaultCellStyle = dataGridViewCellStyle10;
            this.colAlignCenterX.HeaderText = "Center_X";
            this.colAlignCenterX.MinimumWidth = 50;
            this.colAlignCenterX.Name = "colAlignCenterX";
            this.colAlignCenterX.ReadOnly = true;
            this.colAlignCenterX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlignCenterX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlignCenterX.Width = 50;
            // 
            // CtrlAlignHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.dgvAlignHistory);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlAlignHistory";
            this.Size = new System.Drawing.Size(400, 300);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlignHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlignHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPanelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTab;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJudge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlignLeftX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlignLeftY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlignRightX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlignRightY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlignCenterX;
    }
}
