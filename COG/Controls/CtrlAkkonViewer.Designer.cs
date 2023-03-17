namespace COG.Controls
{
    partial class CtrlAkkonViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlAkkonViewer));
            this.tlpAkkonViewer = new System.Windows.Forms.TableLayoutPanel();
            this.lblAkkonViewer = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpViewer = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplayAkkonScale = new Cognex.VisionPro.CogRecordDisplay();
            this.pnlTabButton = new System.Windows.Forms.Panel();
            this.cogDisplayAkkonViewer = new Cognex.VisionPro.CogRecordDisplay();
            this.tlpAkkonHistory = new System.Windows.Forms.TableLayoutPanel();
            this.lblAkkonHistory = new System.Windows.Forms.Label();
            this.pnlAkkonResult = new System.Windows.Forms.Panel();
            this.pnlAkkonGraph = new System.Windows.Forms.Panel();
            this.tlpAkkonViewer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpViewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAkkonScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAkkonViewer)).BeginInit();
            this.tlpAkkonHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAkkonViewer
            // 
            this.tlpAkkonViewer.ColumnCount = 1;
            this.tlpAkkonViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAkkonViewer.Controls.Add(this.lblAkkonViewer, 0, 0);
            this.tlpAkkonViewer.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpAkkonViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAkkonViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpAkkonViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAkkonViewer.Name = "tlpAkkonViewer";
            this.tlpAkkonViewer.RowCount = 2;
            this.tlpAkkonViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAkkonViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAkkonViewer.Size = new System.Drawing.Size(900, 400);
            this.tlpAkkonViewer.TabIndex = 1;
            // 
            // lblAkkonViewer
            // 
            this.lblAkkonViewer.BackColor = System.Drawing.Color.DarkGray;
            this.lblAkkonViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAkkonViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblAkkonViewer.Location = new System.Drawing.Point(0, 0);
            this.lblAkkonViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblAkkonViewer.Name = "lblAkkonViewer";
            this.lblAkkonViewer.Size = new System.Drawing.Size(900, 40);
            this.lblAkkonViewer.TabIndex = 1;
            this.lblAkkonViewer.Text = "AKKON";
            this.lblAkkonViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tlpViewer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlpAkkonHistory, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 360);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tlpViewer
            // 
            this.tlpViewer.ColumnCount = 1;
            this.tlpViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViewer.Controls.Add(this.cogDisplayAkkonScale, 0, 2);
            this.tlpViewer.Controls.Add(this.pnlTabButton, 0, 0);
            this.tlpViewer.Controls.Add(this.cogDisplayAkkonViewer, 0, 1);
            this.tlpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpViewer.Name = "tlpViewer";
            this.tlpViewer.RowCount = 3;
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpViewer.Size = new System.Drawing.Size(675, 360);
            this.tlpViewer.TabIndex = 1;
            // 
            // cogDisplayAkkonScale
            // 
            this.cogDisplayAkkonScale.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayAkkonScale.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayAkkonScale.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayAkkonScale.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayAkkonScale.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayAkkonScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayAkkonScale.DoubleTapZoomCycleLength = 2;
            this.cogDisplayAkkonScale.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayAkkonScale.Location = new System.Drawing.Point(1, 328);
            this.cogDisplayAkkonScale.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayAkkonScale.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayAkkonScale.MouseWheelSensitivity = 1D;
            this.cogDisplayAkkonScale.Name = "cogDisplayAkkonScale";
            this.cogDisplayAkkonScale.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayAkkonScale.OcxState")));
            this.cogDisplayAkkonScale.Size = new System.Drawing.Size(673, 31);
            this.cogDisplayAkkonScale.TabIndex = 139;
            this.cogDisplayAkkonScale.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cogDisplayAkkonScale_MouseDown);
            this.cogDisplayAkkonScale.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cogDisplayAkkonScale_MouseUp);
            this.cogDisplayAkkonScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cogDisplayAkkonScale_MouseMove);
            // 
            // pnlTabButton
            // 
            this.pnlTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTabButton.Location = new System.Drawing.Point(0, 0);
            this.pnlTabButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTabButton.Name = "pnlTabButton";
            this.pnlTabButton.Size = new System.Drawing.Size(675, 30);
            this.pnlTabButton.TabIndex = 0;
            // 
            // cogDisplayAkkonViewer
            // 
            this.cogDisplayAkkonViewer.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayAkkonViewer.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayAkkonViewer.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayAkkonViewer.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayAkkonViewer.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayAkkonViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayAkkonViewer.DoubleTapZoomCycleLength = 2;
            this.cogDisplayAkkonViewer.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayAkkonViewer.Location = new System.Drawing.Point(1, 31);
            this.cogDisplayAkkonViewer.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayAkkonViewer.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayAkkonViewer.MouseWheelSensitivity = 1D;
            this.cogDisplayAkkonViewer.Name = "cogDisplayAkkonViewer";
            this.cogDisplayAkkonViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayAkkonViewer.OcxState")));
            this.cogDisplayAkkonViewer.Size = new System.Drawing.Size(673, 295);
            this.cogDisplayAkkonViewer.TabIndex = 140;
            // 
            // tlpAkkonHistory
            // 
            this.tlpAkkonHistory.ColumnCount = 1;
            this.tlpAkkonHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAkkonHistory.Controls.Add(this.lblAkkonHistory, 0, 0);
            this.tlpAkkonHistory.Controls.Add(this.pnlAkkonResult, 0, 1);
            this.tlpAkkonHistory.Controls.Add(this.pnlAkkonGraph, 0, 2);
            this.tlpAkkonHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAkkonHistory.Location = new System.Drawing.Point(675, 0);
            this.tlpAkkonHistory.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAkkonHistory.Name = "tlpAkkonHistory";
            this.tlpAkkonHistory.RowCount = 3;
            this.tlpAkkonHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAkkonHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAkkonHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAkkonHistory.Size = new System.Drawing.Size(225, 360);
            this.tlpAkkonHistory.TabIndex = 2;
            // 
            // lblAkkonHistory
            // 
            this.lblAkkonHistory.BackColor = System.Drawing.Color.DarkGray;
            this.lblAkkonHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAkkonHistory.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAkkonHistory.Location = new System.Drawing.Point(1, 1);
            this.lblAkkonHistory.Margin = new System.Windows.Forms.Padding(1);
            this.lblAkkonHistory.Name = "lblAkkonHistory";
            this.lblAkkonHistory.Size = new System.Drawing.Size(223, 38);
            this.lblAkkonHistory.TabIndex = 2;
            this.lblAkkonHistory.Text = "AKKON LOG";
            this.lblAkkonHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAkkonResult
            // 
            this.pnlAkkonResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAkkonResult.Location = new System.Drawing.Point(1, 41);
            this.pnlAkkonResult.Margin = new System.Windows.Forms.Padding(1);
            this.pnlAkkonResult.Name = "pnlAkkonResult";
            this.pnlAkkonResult.Size = new System.Drawing.Size(223, 158);
            this.pnlAkkonResult.TabIndex = 3;
            // 
            // pnlAkkonGraph
            // 
            this.pnlAkkonGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAkkonGraph.Location = new System.Drawing.Point(1, 201);
            this.pnlAkkonGraph.Margin = new System.Windows.Forms.Padding(1);
            this.pnlAkkonGraph.Name = "pnlAkkonGraph";
            this.pnlAkkonGraph.Size = new System.Drawing.Size(223, 158);
            this.pnlAkkonGraph.TabIndex = 4;
            // 
            // CtrlAkkonViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpAkkonViewer);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlAkkonViewer";
            this.Size = new System.Drawing.Size(900, 400);
            this.Load += new System.EventHandler(this.CtrlAkkonViewer_Load);
            this.tlpAkkonViewer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpViewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAkkonScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAkkonViewer)).EndInit();
            this.tlpAkkonHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAkkonViewer;
        private System.Windows.Forms.Label lblAkkonViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tlpViewer;
        private System.Windows.Forms.Panel pnlTabButton;
        private System.Windows.Forms.TableLayoutPanel tlpAkkonHistory;
        private System.Windows.Forms.Label lblAkkonHistory;
        private System.Windows.Forms.Panel pnlAkkonResult;
        private System.Windows.Forms.Panel pnlAkkonGraph;
        private Cognex.VisionPro.CogRecordDisplay cogDisplayAkkonScale;
        private Cognex.VisionPro.CogRecordDisplay cogDisplayAkkonViewer;
    }
}
