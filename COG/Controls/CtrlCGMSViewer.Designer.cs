namespace COG.Controls
{
    partial class CtrlCGMSViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCGMSViewer));
            this.tlpCGMSViewer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplayThumbnail = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.pnlNavigator = new System.Windows.Forms.Panel();
            this.tlpCGMSViewer.SuspendLayout();
            this.tlpDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayThumbnail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpCGMSViewer
            // 
            this.tlpCGMSViewer.ColumnCount = 2;
            this.tlpCGMSViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpCGMSViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCGMSViewer.Controls.Add(this.tlpDisplay, 0, 0);
            this.tlpCGMSViewer.Controls.Add(this.pnlNavigator, 1, 0);
            this.tlpCGMSViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCGMSViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpCGMSViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCGMSViewer.Name = "tlpCGMSViewer";
            this.tlpCGMSViewer.RowCount = 1;
            this.tlpCGMSViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSViewer.Size = new System.Drawing.Size(780, 399);
            this.tlpCGMSViewer.TabIndex = 142;
            // 
            // tlpDisplay
            // 
            this.tlpDisplay.ColumnCount = 1;
            this.tlpDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay.Controls.Add(this.cogDisplayThumbnail, 0, 1);
            this.tlpDisplay.Controls.Add(this.cogDisplay, 0, 0);
            this.tlpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisplay.Location = new System.Drawing.Point(0, 0);
            this.tlpDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisplay.Name = "tlpDisplay";
            this.tlpDisplay.RowCount = 2;
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpDisplay.Size = new System.Drawing.Size(546, 399);
            this.tlpDisplay.TabIndex = 0;
            // 
            // cogDisplayThumbnail
            // 
            this.cogDisplayThumbnail.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayThumbnail.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayThumbnail.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayThumbnail.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayThumbnail.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplayThumbnail.DoubleTapZoomCycleLength = 2;
            this.cogDisplayThumbnail.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayThumbnail.Location = new System.Drawing.Point(1, 360);
            this.cogDisplayThumbnail.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplayThumbnail.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayThumbnail.MouseWheelSensitivity = 1D;
            this.cogDisplayThumbnail.Name = "cogDisplayThumbnail";
            this.cogDisplayThumbnail.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayThumbnail.OcxState")));
            this.cogDisplayThumbnail.Size = new System.Drawing.Size(544, 38);
            this.cogDisplayThumbnail.TabIndex = 282;
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(1, 1);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(544, 357);
            this.cogDisplay.TabIndex = 142;
            // 
            // pnlNavigator
            // 
            this.pnlNavigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavigator.Location = new System.Drawing.Point(546, 0);
            this.pnlNavigator.Margin = new System.Windows.Forms.Padding(0);
            this.pnlNavigator.Name = "pnlNavigator";
            this.pnlNavigator.Size = new System.Drawing.Size(234, 399);
            this.pnlNavigator.TabIndex = 1;
            // 
            // CtrlCGMSViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpCGMSViewer);
            this.Name = "CtrlCGMSViewer";
            this.Size = new System.Drawing.Size(780, 399);
            this.Load += new System.EventHandler(this.CtrlCGMSViewer_Load);
            this.tlpCGMSViewer.ResumeLayout(false);
            this.tlpDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayThumbnail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpCGMSViewer;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay;
        private Cognex.VisionPro.CogRecordDisplay cogDisplay;
        private System.Windows.Forms.Panel pnlNavigator;
        private Cognex.VisionPro.CogRecordDisplay cogDisplayThumbnail;
    }
}
