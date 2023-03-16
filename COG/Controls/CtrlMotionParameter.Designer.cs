namespace COG.Controls
{
    partial class CtrlMotionParameter
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
            this.grpMotionParameter = new System.Windows.Forms.GroupBox();
            this.tlpMotionParameter = new System.Windows.Forms.TableLayoutPanel();
            this.grpMotionParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMotionParameter
            // 
            this.grpMotionParameter.Controls.Add(this.tlpMotionParameter);
            this.grpMotionParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotionParameter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.grpMotionParameter.Location = new System.Drawing.Point(0, 0);
            this.grpMotionParameter.Margin = new System.Windows.Forms.Padding(0);
            this.grpMotionParameter.Name = "grpMotionParameter";
            this.grpMotionParameter.Size = new System.Drawing.Size(718, 317);
            this.grpMotionParameter.TabIndex = 1;
            this.grpMotionParameter.TabStop = false;
            this.grpMotionParameter.Text = "AXIS X SET-UP";
            // 
            // tlpMotionParameter
            // 
            this.tlpMotionParameter.ColumnCount = 1;
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionParameter.Location = new System.Drawing.Point(3, 23);
            this.tlpMotionParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionParameter.Name = "tlpMotionParameter";
            this.tlpMotionParameter.RowCount = 2;
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionParameter.Size = new System.Drawing.Size(712, 291);
            this.tlpMotionParameter.TabIndex = 0;
            // 
            // CtrlMotionParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.grpMotionParameter);
            this.Name = "CtrlMotionParameter";
            this.Size = new System.Drawing.Size(718, 317);
            this.Load += new System.EventHandler(this.CtrlTeachMotion_Load);
            this.grpMotionParameter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMotionParameter;
        private System.Windows.Forms.TableLayoutPanel tlpMotionParameter;
    }
}
