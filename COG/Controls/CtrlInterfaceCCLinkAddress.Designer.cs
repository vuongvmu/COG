namespace COG.Controls
{
    partial class CtrlInterfaceCCLinkAddress
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
            this.tlpddress = new System.Windows.Forms.TableLayoutPanel();
            this.chkBit = new System.Windows.Forms.CheckBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.tlpddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpddress
            // 
            this.tlpddress.ColumnCount = 2;
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpddress.Controls.Add(this.chkBit, 0, 0);
            this.tlpddress.Controls.Add(this.lblCaption, 1, 0);
            this.tlpddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpddress.Location = new System.Drawing.Point(0, 0);
            this.tlpddress.Margin = new System.Windows.Forms.Padding(0);
            this.tlpddress.Name = "tlpddress";
            this.tlpddress.RowCount = 1;
            this.tlpddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpddress.Size = new System.Drawing.Size(250, 40);
            this.tlpddress.TabIndex = 0;
            // 
            // chkBit
            // 
            this.chkBit.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkBit.AutoSize = true;
            this.chkBit.BackColor = System.Drawing.Color.DarkGray;
            this.chkBit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBit.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.chkBit.Location = new System.Drawing.Point(0, 0);
            this.chkBit.Margin = new System.Windows.Forms.Padding(0);
            this.chkBit.Name = "chkBit";
            this.chkBit.Size = new System.Drawing.Size(100, 40);
            this.chkBit.TabIndex = 48;
            this.chkBit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkBit.UseVisualStyleBackColor = false;
            this.chkBit.CheckedChanged += new System.EventHandler(this.chkBit_CheckedChanged);
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Location = new System.Drawing.Point(103, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(144, 40);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlInterfaceCCLinkAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlpddress);
            this.Name = "CtrlInterfaceCCLinkAddress";
            this.Size = new System.Drawing.Size(250, 40);
            this.Load += new System.EventHandler(this.CtrlPLCAddress_Load);
            this.tlpddress.ResumeLayout(false);
            this.tlpddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpddress;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.CheckBox chkBit;
    }
}
