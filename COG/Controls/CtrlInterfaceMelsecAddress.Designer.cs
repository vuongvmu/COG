namespace COG.Controls
{
    partial class CtrlInterfaceMelsecAddress
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
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tlpddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpddress
            // 
            this.tlpddress.ColumnCount = 4;
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpddress.Controls.Add(this.lblCaption, 3, 0);
            this.tlpddress.Controls.Add(this.lblMode, 2, 0);
            this.tlpddress.Controls.Add(this.lblValue, 1, 0);
            this.tlpddress.Controls.Add(this.lblAddress, 0, 0);
            this.tlpddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpddress.Location = new System.Drawing.Point(0, 0);
            this.tlpddress.Margin = new System.Windows.Forms.Padding(0);
            this.tlpddress.Name = "tlpddress";
            this.tlpddress.RowCount = 1;
            this.tlpddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpddress.Size = new System.Drawing.Size(250, 40);
            this.tlpddress.TabIndex = 1;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaption.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblCaption.Location = new System.Drawing.Point(153, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(94, 40);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMode
            // 
            this.lblMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMode.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblMode.Location = new System.Drawing.Point(128, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(19, 40);
            this.lblMode.TabIndex = 1;
            this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblValue.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblValue.Location = new System.Drawing.Point(78, 0);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(44, 40);
            this.lblValue.TabIndex = 1;
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblValue.Click += new System.EventHandler(this.lblValue_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddress.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(3, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(69, 40);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlInterfaceMelsecAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpddress);
            this.Name = "CtrlInterfaceMelsecAddress";
            this.Size = new System.Drawing.Size(250, 40);
            this.Load += new System.EventHandler(this.CtrlInterfaceMelsecAddress_Load);
            this.tlpddress.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpddress;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblAddress;
    }
}
