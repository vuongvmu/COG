namespace COG.Controls
{
    partial class CtrlTeaching
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
            this.grpTeaching = new System.Windows.Forms.GroupBox();
            this.pnlTeachingData = new System.Windows.Forms.Panel();
            this.grpTeaching.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTeaching
            // 
            this.grpTeaching.Controls.Add(this.pnlTeachingData);
            this.grpTeaching.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTeaching.Location = new System.Drawing.Point(0, 0);
            this.grpTeaching.Name = "grpTeaching";
            this.grpTeaching.Size = new System.Drawing.Size(687, 137);
            this.grpTeaching.TabIndex = 1;
            this.grpTeaching.TabStop = false;
            this.grpTeaching.Text = "Teaching Position";
            // 
            // pnlTeachingData
            // 
            this.pnlTeachingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachingData.Location = new System.Drawing.Point(3, 17);
            this.pnlTeachingData.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeachingData.Name = "pnlTeachingData";
            this.pnlTeachingData.Size = new System.Drawing.Size(681, 117);
            this.pnlTeachingData.TabIndex = 3;
            // 
            // CtrlTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpTeaching);
            this.Name = "CtrlTeaching";
            this.Size = new System.Drawing.Size(687, 137);
            this.grpTeaching.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTeaching;
        private System.Windows.Forms.Panel pnlTeachingData;
    }
}
