namespace COG.Controls
{
    partial class CtrlInspectionItem
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
            this.chkInspectionItem = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkInspectionItem
            // 
            this.chkInspectionItem.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInspectionItem.AutoSize = true;
            this.chkInspectionItem.BackColor = System.Drawing.Color.DarkGray;
            this.chkInspectionItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkInspectionItem.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkInspectionItem.Location = new System.Drawing.Point(0, 0);
            this.chkInspectionItem.Margin = new System.Windows.Forms.Padding(0);
            this.chkInspectionItem.Name = "chkInspectionItem";
            this.chkInspectionItem.Size = new System.Drawing.Size(150, 150);
            this.chkInspectionItem.TabIndex = 2;
            this.chkInspectionItem.Text = "checkBox1";
            this.chkInspectionItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInspectionItem.UseVisualStyleBackColor = false;
            this.chkInspectionItem.CheckedChanged += new System.EventHandler(this.chkInspectionItem_CheckedChanged);
            this.chkInspectionItem.Click += new System.EventHandler(this.chkInspectionItem_Click);
            // 
            // CtrlInspectionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.chkInspectionItem);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CtrlInspectionItem";
            this.Load += new System.EventHandler(this.CtrlInspectionItem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkInspectionItem;
    }
}
