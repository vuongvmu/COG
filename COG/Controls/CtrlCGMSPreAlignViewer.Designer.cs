namespace COG.Controls
{
    partial class CtrlCGMSPreAlignViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCGMSPreAlignViewer));
            this.tlpPreAlignViewer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPreAlignDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplayPreAlignViewerLeft = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayPreAlignViewerRight = new Cognex.VisionPro.Display.CogDisplay();
            this.lblPreAlignViewer = new System.Windows.Forms.Label();
            this.tlpPreAlignViewer.SuspendLayout();
            this.tlpPreAlignDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerRight)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpPreAlignViewer
            // 
            this.tlpPreAlignViewer.ColumnCount = 1;
            this.tlpPreAlignViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreAlignViewer.Controls.Add(this.lblPreAlignViewer, 0, 0);
            this.tlpPreAlignViewer.Controls.Add(this.tlpPreAlignDisplay, 0, 1);
            this.tlpPreAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpPreAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPreAlignViewer.Name = "tlpPreAlignViewer";
            this.tlpPreAlignViewer.RowCount = 2;
            this.tlpPreAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpPreAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPreAlignViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPreAlignViewer.Size = new System.Drawing.Size(300, 300);
            this.tlpPreAlignViewer.TabIndex = 0;
            // 
            // tlpPreAlignDisplay
            // 
            this.tlpPreAlignDisplay.ColumnCount = 2;
            this.tlpPreAlignDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPreAlignDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPreAlignDisplay.Controls.Add(this.cogDisplayPreAlignViewerRight, 0, 0);
            this.tlpPreAlignDisplay.Controls.Add(this.cogDisplayPreAlignViewerLeft, 0, 0);
            this.tlpPreAlignDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPreAlignDisplay.Location = new System.Drawing.Point(0, 30);
            this.tlpPreAlignDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPreAlignDisplay.Name = "tlpPreAlignDisplay";
            this.tlpPreAlignDisplay.RowCount = 1;
            this.tlpPreAlignDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPreAlignDisplay.Size = new System.Drawing.Size(300, 270);
            this.tlpPreAlignDisplay.TabIndex = 0;
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
            this.cogDisplayPreAlignViewerLeft.Size = new System.Drawing.Size(148, 268);
            this.cogDisplayPreAlignViewerLeft.TabIndex = 6;
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
            this.cogDisplayPreAlignViewerRight.Location = new System.Drawing.Point(151, 1);
            this.cogDisplayPreAlignViewerRight.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayPreAlignViewerRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayPreAlignViewerRight.MouseWheelSensitivity = 1D;
            this.cogDisplayPreAlignViewerRight.Name = "cogDisplayPreAlignViewerRight";
            this.cogDisplayPreAlignViewerRight.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayPreAlignViewerRight.OcxState")));
            this.cogDisplayPreAlignViewerRight.Size = new System.Drawing.Size(148, 268);
            this.cogDisplayPreAlignViewerRight.TabIndex = 7;
            // 
            // lblPreAlignViewer
            // 
            this.lblPreAlignViewer.BackColor = System.Drawing.Color.DarkGray;
            this.lblPreAlignViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPreAlignViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreAlignViewer.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblPreAlignViewer.Location = new System.Drawing.Point(0, 0);
            this.lblPreAlignViewer.Margin = new System.Windows.Forms.Padding(0);
            this.lblPreAlignViewer.Name = "lblPreAlignViewer";
            this.lblPreAlignViewer.Size = new System.Drawing.Size(300, 30);
            this.lblPreAlignViewer.TabIndex = 3;
            this.lblPreAlignViewer.Text = "PreAlign";
            this.lblPreAlignViewer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlCGMSPreAlignViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpPreAlignViewer);
            this.Name = "CtrlCGMSPreAlignViewer";
            this.Size = new System.Drawing.Size(300, 300);
            this.tlpPreAlignViewer.ResumeLayout(false);
            this.tlpPreAlignDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayPreAlignViewerRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpPreAlignViewer;
        private System.Windows.Forms.TableLayoutPanel tlpPreAlignDisplay;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayPreAlignViewerLeft;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayPreAlignViewerRight;
        private System.Windows.Forms.Label lblPreAlignViewer;
    }
}
