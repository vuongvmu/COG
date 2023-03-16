namespace COG.Controls
{
    partial class CtrlAuthority
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
            this.tlpAuthority = new System.Windows.Forms.TableLayoutPanel();
            this.btnOperator = new System.Windows.Forms.Button();
            this.btnEngineer = new System.Windows.Forms.Button();
            this.btnMaker = new System.Windows.Forms.Button();
            this.tlpAuthority.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAuthority
            // 
            this.tlpAuthority.ColumnCount = 5;
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAuthority.Controls.Add(this.btnOperator, 0, 0);
            this.tlpAuthority.Controls.Add(this.btnEngineer, 2, 0);
            this.tlpAuthority.Controls.Add(this.btnMaker, 4, 0);
            this.tlpAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthority.Location = new System.Drawing.Point(0, 0);
            this.tlpAuthority.Name = "tlpAuthority";
            this.tlpAuthority.RowCount = 1;
            this.tlpAuthority.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthority.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 137F));
            this.tlpAuthority.Size = new System.Drawing.Size(495, 137);
            this.tlpAuthority.TabIndex = 0;
            // 
            // btnOperator
            // 
            this.btnOperator.BackColor = System.Drawing.Color.DarkGray;
            this.btnOperator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOperator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOperator.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnOperator.Location = new System.Drawing.Point(0, 0);
            this.btnOperator.Margin = new System.Windows.Forms.Padding(0);
            this.btnOperator.Name = "btnOperator";
            this.btnOperator.Size = new System.Drawing.Size(148, 137);
            this.btnOperator.TabIndex = 236;
            this.btnOperator.Text = "Operator";
            this.btnOperator.UseVisualStyleBackColor = false;
            this.btnOperator.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnEngineer
            // 
            this.btnEngineer.BackColor = System.Drawing.Color.DarkGray;
            this.btnEngineer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEngineer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEngineer.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnEngineer.Location = new System.Drawing.Point(172, 0);
            this.btnEngineer.Margin = new System.Windows.Forms.Padding(0);
            this.btnEngineer.Name = "btnEngineer";
            this.btnEngineer.Size = new System.Drawing.Size(148, 137);
            this.btnEngineer.TabIndex = 237;
            this.btnEngineer.Text = "Engineer";
            this.btnEngineer.UseVisualStyleBackColor = false;
            this.btnEngineer.Click += new System.EventHandler(this.btnEngineer_Click);
            // 
            // btnMaker
            // 
            this.btnMaker.BackColor = System.Drawing.Color.DarkGray;
            this.btnMaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaker.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMaker.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaker.Location = new System.Drawing.Point(344, 0);
            this.btnMaker.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaker.Name = "btnMaker";
            this.btnMaker.Size = new System.Drawing.Size(151, 137);
            this.btnMaker.TabIndex = 238;
            this.btnMaker.Text = "Maker";
            this.btnMaker.UseVisualStyleBackColor = false;
            this.btnMaker.Click += new System.EventHandler(this.btnMaker_Click);
            // 
            // CtrlAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpAuthority);
            this.Name = "CtrlAuthority";
            this.Size = new System.Drawing.Size(495, 137);
            this.tlpAuthority.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAuthority;
        private System.Windows.Forms.Button btnOperator;
        private System.Windows.Forms.Button btnEngineer;
        private System.Windows.Forms.Button btnMaker;
    }
}
