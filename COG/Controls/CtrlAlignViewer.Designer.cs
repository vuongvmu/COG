namespace COG.Controls
{
    partial class CtrlAlignViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlAlignViewer));
            this.tlpAlignViewer = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlignViewer = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpViewer = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTabButton = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplayAlignViewerLeft = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayAlignViewerRight = new Cognex.VisionPro.Display.CogDisplay();
            this.tlpAlignHistory = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlignHistory = new System.Windows.Forms.Label();
            this.pnlAlignResult = new System.Windows.Forms.Panel();
            this.pnlAlignGraph = new System.Windows.Forms.Panel();
            this.tlpAlignViewer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpViewer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAlignViewerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAlignViewerRight)).BeginInit();
            this.tlpAlignHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAlignViewer
            // 
            this.tlpAlignViewer.ColumnCount = 1;
            this.tlpAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlignViewer.Controls.Add(this.lblAlignViewer, 0, 0);
            this.tlpAlignViewer.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAlignViewer.Name = "tlpAlignViewer";
            this.tlpAlignViewer.RowCount = 2;
            this.tlpAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlignViewer.Size = new System.Drawing.Size(900, 400);
            this.tlpAlignViewer.TabIndex = 0;
            // 
            // lblAlignViewer
            // 
            this.lblAlignViewer.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.lblAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlignViewer.Name = "lblAlignViewer";
            this.lblAlignViewer.Size = new System.Drawing.Size(900, 40);
            this.lblAlignViewer.TabIndex = 0;
            this.lblAlignViewer.Text = "Align";
            this.lblAlignViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.tlpViewer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlpAlignHistory, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 360);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tlpViewer
            // 
            this.tlpViewer.ColumnCount = 1;
            this.tlpViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViewer.Controls.Add(this.pnlTabButton, 0, 0);
            this.tlpViewer.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tlpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpViewer.Name = "tlpViewer";
            this.tlpViewer.RowCount = 2;
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViewer.Size = new System.Drawing.Size(675, 360);
            this.tlpViewer.TabIndex = 2;
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
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.cogDisplayAlignViewerLeft, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cogDisplayAlignViewerRight, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(675, 330);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // cogDisplayAlignViewerLeft
            // 
            this.cogDisplayAlignViewerLeft.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayAlignViewerLeft.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayAlignViewerLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayAlignViewerLeft.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayAlignViewerLeft.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayAlignViewerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayAlignViewerLeft.DoubleTapZoomCycleLength = 2;
            this.cogDisplayAlignViewerLeft.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayAlignViewerLeft.Location = new System.Drawing.Point(1, 1);
            this.cogDisplayAlignViewerLeft.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayAlignViewerLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayAlignViewerLeft.MouseWheelSensitivity = 1D;
            this.cogDisplayAlignViewerLeft.Name = "cogDisplayAlignViewerLeft";
            this.cogDisplayAlignViewerLeft.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayAlignViewerLeft.OcxState")));
            this.cogDisplayAlignViewerLeft.Size = new System.Drawing.Size(335, 328);
            this.cogDisplayAlignViewerLeft.TabIndex = 4;
            // 
            // cogDisplayAlignViewerRight
            // 
            this.cogDisplayAlignViewerRight.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayAlignViewerRight.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayAlignViewerRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayAlignViewerRight.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayAlignViewerRight.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayAlignViewerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayAlignViewerRight.DoubleTapZoomCycleLength = 2;
            this.cogDisplayAlignViewerRight.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayAlignViewerRight.Location = new System.Drawing.Point(339, 1);
            this.cogDisplayAlignViewerRight.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayAlignViewerRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayAlignViewerRight.MouseWheelSensitivity = 1D;
            this.cogDisplayAlignViewerRight.Name = "cogDisplayAlignViewerRight";
            this.cogDisplayAlignViewerRight.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayAlignViewerRight.OcxState")));
            this.cogDisplayAlignViewerRight.Size = new System.Drawing.Size(335, 328);
            this.cogDisplayAlignViewerRight.TabIndex = 5;
            // 
            // tlpAlignHistory
            // 
            this.tlpAlignHistory.ColumnCount = 1;
            this.tlpAlignHistory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAlignHistory.Controls.Add(this.lblAlignHistory, 0, 0);
            this.tlpAlignHistory.Controls.Add(this.pnlAlignResult, 0, 1);
            this.tlpAlignHistory.Controls.Add(this.pnlAlignGraph, 0, 2);
            this.tlpAlignHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlignHistory.Location = new System.Drawing.Point(675, 0);
            this.tlpAlignHistory.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAlignHistory.Name = "tlpAlignHistory";
            this.tlpAlignHistory.RowCount = 3;
            this.tlpAlignHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpAlignHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlignHistory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlignHistory.Size = new System.Drawing.Size(225, 360);
            this.tlpAlignHistory.TabIndex = 3;
            // 
            // lblAlignHistory
            // 
            this.lblAlignHistory.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlignHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignHistory.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlignHistory.Location = new System.Drawing.Point(1, 1);
            this.lblAlignHistory.Margin = new System.Windows.Forms.Padding(1);
            this.lblAlignHistory.Name = "lblAlignHistory";
            this.lblAlignHistory.Size = new System.Drawing.Size(223, 38);
            this.lblAlignHistory.TabIndex = 2;
            this.lblAlignHistory.Text = "Align Log";
            this.lblAlignHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAlignResult
            // 
            this.pnlAlignResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlignResult.Location = new System.Drawing.Point(1, 41);
            this.pnlAlignResult.Margin = new System.Windows.Forms.Padding(1);
            this.pnlAlignResult.Name = "pnlAlignResult";
            this.pnlAlignResult.Size = new System.Drawing.Size(223, 158);
            this.pnlAlignResult.TabIndex = 3;
            // 
            // pnlAlignGraph
            // 
            this.pnlAlignGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAlignGraph.Location = new System.Drawing.Point(1, 201);
            this.pnlAlignGraph.Margin = new System.Windows.Forms.Padding(1);
            this.pnlAlignGraph.Name = "pnlAlignGraph";
            this.pnlAlignGraph.Size = new System.Drawing.Size(223, 158);
            this.pnlAlignGraph.TabIndex = 4;
            // 
            // CtrlAlignViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpAlignViewer);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "CtrlAlignViewer";
            this.Size = new System.Drawing.Size(900, 400);
            this.Load += new System.EventHandler(this.CtrlAlignViewer_Load);
            this.tlpAlignViewer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpViewer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAlignViewerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayAlignViewerRight)).EndInit();
            this.tlpAlignHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAlignViewer;
        private System.Windows.Forms.Label lblAlignViewer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tlpViewer;
        private System.Windows.Forms.Panel pnlTabButton;
        private System.Windows.Forms.TableLayoutPanel tlpAlignHistory;
        private System.Windows.Forms.Label lblAlignHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayAlignViewerLeft;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayAlignViewerRight;
        private System.Windows.Forms.Panel pnlAlignResult;
        private System.Windows.Forms.Panel pnlAlignGraph;
    }
}
