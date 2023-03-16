namespace COG.Controls
{
    partial class CtrlLiveViewDrawBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlLiveViewDrawBox));
            this.cogLiveViewDisplay = new Cognex.VisionPro.Display.CogDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.cogLiveViewDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // cogLiveViewDisplay
            // 
            this.cogLiveViewDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogLiveViewDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogLiveViewDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogLiveViewDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogLiveViewDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogLiveViewDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogLiveViewDisplay.DoubleTapZoomCycleLength = 2;
            this.cogLiveViewDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogLiveViewDisplay.Location = new System.Drawing.Point(0, 0);
            this.cogLiveViewDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.cogLiveViewDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogLiveViewDisplay.MouseWheelSensitivity = 1D;
            this.cogLiveViewDisplay.Name = "cogLiveViewDisplay";
            this.cogLiveViewDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogLiveViewDisplay.OcxState")));
            this.cogLiveViewDisplay.Size = new System.Drawing.Size(335, 335);
            this.cogLiveViewDisplay.TabIndex = 1;
            // 
            // CtrlLiveViewDrawBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cogLiveViewDisplay);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlLiveViewDrawBox";
            this.Size = new System.Drawing.Size(335, 335);
            this.Load += new System.EventHandler(this.CtrlLiveViewDrawBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogLiveViewDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Display.CogDisplay cogLiveViewDisplay;
    }
}
