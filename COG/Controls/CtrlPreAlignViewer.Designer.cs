namespace COG.Controls
{
    partial class CtrlPreAlignViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPreAlignViewer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpPreAlignViewer = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplayPreAlignViewerLeft = new Cognex.VisionPro.Display.CogDisplay();
            this.dgvPreAlignResult = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPanelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStageNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cogDisplayPreAlignViewerRight = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPreAlignViewer = new System.Windows.Forms.Label();
            this.tlpPreAlignViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreAlignResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerRight)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpPreAlignViewer
            // 
            this.tlpPreAlignViewer.ColumnCount = 4;
            this.tlpPreAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPreAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tlpPreAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPreAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPreAlignViewer.Controls.Add(this.cogDisplayPreAlignViewerLeft, 0, 0);
            this.tlpPreAlignViewer.Controls.Add(this.dgvPreAlignResult, 3, 0);
            this.tlpPreAlignViewer.Controls.Add(this.cogDisplayPreAlignViewerRight, 2, 0);
            this.tlpPreAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreAlignViewer.Location = new System.Drawing.Point(0, 30);
            this.tlpPreAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPreAlignViewer.Name = "tlpPreAlignViewer";
            this.tlpPreAlignViewer.RowCount = 1;
            this.tlpPreAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreAlignViewer.Size = new System.Drawing.Size(922, 175);
            this.tlpPreAlignViewer.TabIndex = 0;
            // 
            // cogDisplayPreAlignViewerLeft
            // 
            this.cogDisplayPreAlignViewerLeft.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayPreAlignViewerLeft.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayPreAlignViewerLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayPreAlignViewerLeft.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayPreAlignViewerLeft.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayPreAlignViewerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayPreAlignViewerLeft.DoubleTapZoomCycleLength = 2;
            this.cogDisplayPreAlignViewerLeft.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayPreAlignViewerLeft.Location = new System.Drawing.Point(1, 1);
            this.cogDisplayPreAlignViewerLeft.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayPreAlignViewerLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayPreAlignViewerLeft.MouseWheelSensitivity = 1D;
            this.cogDisplayPreAlignViewerLeft.Name = "cogDisplayPreAlignViewerLeft";
            this.cogDisplayPreAlignViewerLeft.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayPreAlignViewerLeft.OcxState")));
            this.cogDisplayPreAlignViewerLeft.Size = new System.Drawing.Size(228, 173);
            this.cogDisplayPreAlignViewerLeft.TabIndex = 5;
            // 
            // dgvPreAlignResult
            // 
            this.dgvPreAlignResult.AllowUserToAddRows = false;
            this.dgvPreAlignResult.AllowUserToDeleteRows = false;
            this.dgvPreAlignResult.AllowUserToResizeRows = false;
            this.dgvPreAlignResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreAlignResult.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPreAlignResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPreAlignResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPreAlignResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPreAlignResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colPanelID,
            this.colStageNo,
            this.colX,
            this.colY,
            this.colT});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPreAlignResult.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPreAlignResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPreAlignResult.Location = new System.Drawing.Point(461, 0);
            this.dgvPreAlignResult.Margin = new System.Windows.Forms.Padding(0);
            this.dgvPreAlignResult.MultiSelect = false;
            this.dgvPreAlignResult.Name = "dgvPreAlignResult";
            this.dgvPreAlignResult.ReadOnly = true;
            this.dgvPreAlignResult.RowHeadersVisible = false;
            this.dgvPreAlignResult.RowTemplate.Height = 23;
            this.dgvPreAlignResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreAlignResult.Size = new System.Drawing.Size(461, 175);
            this.dgvPreAlignResult.TabIndex = 1;
            // 
            // colTime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTime.HeaderText = "Time";
            this.colTime.MinimumWidth = 100;
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            // colStageNo
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStageNo.DefaultCellStyle = dataGridViewCellStyle4;
            this.colStageNo.HeaderText = "Stage No.";
            this.colStageNo.MinimumWidth = 120;
            this.colStageNo.Name = "colStageNo";
            this.colStageNo.ReadOnly = true;
            this.colStageNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStageNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colX
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colX.DefaultCellStyle = dataGridViewCellStyle5;
            this.colX.HeaderText = "X";
            this.colX.MinimumWidth = 40;
            this.colX.Name = "colX";
            this.colX.ReadOnly = true;
            this.colX.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colY
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colY.DefaultCellStyle = dataGridViewCellStyle6;
            this.colY.HeaderText = "Y";
            this.colY.MinimumWidth = 40;
            this.colY.Name = "colY";
            this.colY.ReadOnly = true;
            this.colY.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colT
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colT.DefaultCellStyle = dataGridViewCellStyle7;
            this.colT.HeaderText = "T";
            this.colT.MinimumWidth = 60;
            this.colT.Name = "colT";
            this.colT.ReadOnly = true;
            this.colT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cogDisplayPreAlignViewerRight
            // 
            this.cogDisplayPreAlignViewerRight.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayPreAlignViewerRight.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayPreAlignViewerRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayPreAlignViewerRight.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayPreAlignViewerRight.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayPreAlignViewerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayPreAlignViewerRight.DoubleTapZoomCycleLength = 2;
            this.cogDisplayPreAlignViewerRight.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayPreAlignViewerRight.Location = new System.Drawing.Point(232, 1);
            this.cogDisplayPreAlignViewerRight.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayPreAlignViewerRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayPreAlignViewerRight.MouseWheelSensitivity = 1D;
            this.cogDisplayPreAlignViewerRight.Name = "cogDisplayPreAlignViewerRight";
            this.cogDisplayPreAlignViewerRight.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayPreAlignViewerRight.OcxState")));
            this.cogDisplayPreAlignViewerRight.Size = new System.Drawing.Size(228, 173);
            this.cogDisplayPreAlignViewerRight.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblPreAlignViewer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tlpPreAlignViewer, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 205);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblPreAlignViewer
            // 
            this.lblPreAlignViewer.BackColor = System.Drawing.Color.DarkGray;
            this.lblPreAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreAlignViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblPreAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.lblPreAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblPreAlignViewer.Name = "lblPreAlignViewer";
            this.lblPreAlignViewer.Size = new System.Drawing.Size(922, 30);
            this.lblPreAlignViewer.TabIndex = 2;
            this.lblPreAlignViewer.Text = "PreAlign";
            this.lblPreAlignViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlPreAlignViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlPreAlignViewer";
            this.Size = new System.Drawing.Size(922, 205);
            this.tlpPreAlignViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreAlignResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerRight)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPreAlignViewer;
        private System.Windows.Forms.DataGridView dgvPreAlignResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPanelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStageNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
        private System.Windows.Forms.DataGridViewTextBoxColumn colT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPreAlignViewer;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayPreAlignViewerLeft;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayPreAlignViewerRight;
    }
}
