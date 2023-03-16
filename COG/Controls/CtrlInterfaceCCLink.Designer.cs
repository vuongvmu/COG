namespace COG.Controls
{
    partial class CtrlInterfaceCCLink
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
            this.tlpInterfaceCCLink = new System.Windows.Forms.TableLayoutPanel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.tlpPage = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tlpAddress = new System.Windows.Forms.TableLayoutPanel();
            this.lblPage = new System.Windows.Forms.Label();
            this.tlpInterfaceCCLink.SuspendLayout();
            this.tlpPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInterfaceCCLink
            // 
            this.tlpInterfaceCCLink.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpInterfaceCCLink.ColumnCount = 1;
            this.tlpInterfaceCCLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInterfaceCCLink.Controls.Add(this.lblSubject, 0, 0);
            this.tlpInterfaceCCLink.Controls.Add(this.tlpPage, 0, 2);
            this.tlpInterfaceCCLink.Controls.Add(this.tlpAddress, 0, 1);
            this.tlpInterfaceCCLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInterfaceCCLink.Location = new System.Drawing.Point(0, 0);
            this.tlpInterfaceCCLink.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInterfaceCCLink.Name = "tlpInterfaceCCLink";
            this.tlpInterfaceCCLink.RowCount = 3;
            this.tlpInterfaceCCLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpInterfaceCCLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88F));
            this.tlpInterfaceCCLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpInterfaceCCLink.Size = new System.Drawing.Size(327, 700);
            this.tlpInterfaceCCLink.TabIndex = 0;
            // 
            // lblSubject
            // 
            this.lblSubject.BackColor = System.Drawing.Color.DimGray;
            this.lblSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSubject.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(5, 2);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(317, 41);
            this.lblSubject.TabIndex = 1001;
            this.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPage
            // 
            this.tlpPage.ColumnCount = 3;
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpPage.Controls.Add(this.lblPage, 0, 0);
            this.tlpPage.Controls.Add(this.btnPrev, 0, 0);
            this.tlpPage.Controls.Add(this.btnNext, 2, 0);
            this.tlpPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPage.Location = new System.Drawing.Point(2, 655);
            this.tlpPage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPage.Name = "tlpPage";
            this.tlpPage.RowCount = 1;
            this.tlpPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPage.Size = new System.Drawing.Size(323, 43);
            this.tlpPage.TabIndex = 1002;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.DarkGray;
            this.btnPrev.BackgroundImage = global::COG.Properties.Resources.LEFT2;
            this.btnPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrev.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(3, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(123, 37);
            this.btnPrev.TabIndex = 2630;
            this.btnPrev.Text = "PREV";
            this.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkGray;
            this.btnNext.BackgroundImage = global::COG.Properties.Resources.RIGHT1;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNext.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(196, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 37);
            this.btnNext.TabIndex = 2632;
            this.btnNext.Text = "NEXT";
            this.btnNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tlpAddress
            // 
            this.tlpAddress.ColumnCount = 1;
            this.tlpAddress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAddress.Location = new System.Drawing.Point(2, 45);
            this.tlpAddress.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAddress.Name = "tlpAddress";
            this.tlpAddress.RowCount = 1;
            this.tlpAddress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAddress.Size = new System.Drawing.Size(323, 608);
            this.tlpAddress.TabIndex = 1003;
            // 
            // lblPage
            // 
            this.lblPage.BackColor = System.Drawing.Color.Silver;
            this.lblPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPage.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPage.ForeColor = System.Drawing.Color.Black;
            this.lblPage.Location = new System.Drawing.Point(132, 3);
            this.lblPage.Margin = new System.Windows.Forms.Padding(3);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(58, 37);
            this.lblPage.TabIndex = 2633;
            this.lblPage.Text = "0 / 0";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlInterfaceCCLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpInterfaceCCLink);
            this.Name = "CtrlInterfaceCCLink";
            this.Size = new System.Drawing.Size(327, 700);
            this.Load += new System.EventHandler(this.CtrlInterfaceCCLink_Load);
            this.tlpInterfaceCCLink.ResumeLayout(false);
            this.tlpPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpInterfaceCCLink;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.TableLayoutPanel tlpPage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TableLayoutPanel tlpAddress;
        private System.Windows.Forms.Label lblPage;
    }
}
