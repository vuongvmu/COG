namespace COG.Controls
{
    partial class CtrlCGMSDrawBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlCGMSDrawBox));
            this.cogDisplay = new Cognex.VisionPro.CogRecordDisplay();
            this.tlpCGMSDrawBox = new System.Windows.Forms.TableLayoutPanel();
            this.btnSceneNumber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.tlpCGMSDrawBox.SuspendLayout();
            this.SuspendLayout();
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
            this.cogDisplay.Location = new System.Drawing.Point(1, 33);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(1);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(288, 256);
            this.cogDisplay.TabIndex = 141;
            // 
            // tlpCGMSDrawBox
            // 
            this.tlpCGMSDrawBox.ColumnCount = 1;
            this.tlpCGMSDrawBox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSDrawBox.Controls.Add(this.btnSceneNumber, 0, 0);
            this.tlpCGMSDrawBox.Controls.Add(this.cogDisplay, 0, 1);
            this.tlpCGMSDrawBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCGMSDrawBox.Location = new System.Drawing.Point(5, 5);
            this.tlpCGMSDrawBox.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCGMSDrawBox.Name = "tlpCGMSDrawBox";
            this.tlpCGMSDrawBox.RowCount = 2;
            this.tlpCGMSDrawBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tlpCGMSDrawBox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.88889F));
            this.tlpCGMSDrawBox.Size = new System.Drawing.Size(290, 290);
            this.tlpCGMSDrawBox.TabIndex = 142;
            // 
            // btnSceneNumber
            // 
            this.btnSceneNumber.BackColor = System.Drawing.Color.DarkGray;
            this.btnSceneNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSceneNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSceneNumber.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnSceneNumber.Location = new System.Drawing.Point(0, 0);
            this.btnSceneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.btnSceneNumber.Name = "btnSceneNumber";
            this.btnSceneNumber.Size = new System.Drawing.Size(290, 32);
            this.btnSceneNumber.TabIndex = 199;
            this.btnSceneNumber.UseVisualStyleBackColor = false;
            this.btnSceneNumber.Click += new System.EventHandler(this.btnSceneNumber_Click);
            // 
            // CtrlCGMSDrawBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpCGMSDrawBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlCGMSDrawBox";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(300, 300);
            this.Load += new System.EventHandler(this.CtrlCGMSDrawBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.tlpCGMSDrawBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay cogDisplay;
        private System.Windows.Forms.TableLayoutPanel tlpCGMSDrawBox;
        private System.Windows.Forms.Button btnSceneNumber;
    }
}
