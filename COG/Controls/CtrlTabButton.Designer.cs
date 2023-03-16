namespace COG.Controls
{
    partial class CtrlTabButton
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
            this.chkTabButton = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkTabButton
            // 
            this.chkTabButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTabButton.AutoSize = true;
            this.chkTabButton.BackColor = System.Drawing.Color.DarkGray;
            this.chkTabButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTabButton.Location = new System.Drawing.Point(0, 0);
            this.chkTabButton.Margin = new System.Windows.Forms.Padding(0);
            this.chkTabButton.Name = "chkTabButton";
            this.chkTabButton.Size = new System.Drawing.Size(150, 150);
            this.chkTabButton.TabIndex = 0;
            this.chkTabButton.Text = "checkBox1";
            this.chkTabButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkTabButton.UseVisualStyleBackColor = false;
            this.chkTabButton.CheckedChanged += new System.EventHandler(this.chkTabButton_CheckedChanged);
            // 
            // CtrlTabButton
            // 
            this.Controls.Add(this.chkTabButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlTabButton";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTabButton;
    }
}
