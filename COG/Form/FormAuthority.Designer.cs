namespace COG
{
    partial class FormAuthority
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpAuthority = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAuthority = new System.Windows.Forms.Panel();
            this.pnlClose = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpAuthority.SuspendLayout();
            this.pnlClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpAuthority
            // 
            this.tlpAuthority.ColumnCount = 1;
            this.tlpAuthority.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthority.Controls.Add(this.pnlAuthority, 0, 0);
            this.tlpAuthority.Controls.Add(this.pnlClose, 0, 1);
            this.tlpAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAuthority.Location = new System.Drawing.Point(0, 0);
            this.tlpAuthority.Name = "tlpAuthority";
            this.tlpAuthority.RowCount = 2;
            this.tlpAuthority.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAuthority.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpAuthority.Size = new System.Drawing.Size(476, 165);
            this.tlpAuthority.TabIndex = 0;
            // 
            // pnlAuthority
            // 
            this.pnlAuthority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAuthority.Location = new System.Drawing.Point(0, 0);
            this.pnlAuthority.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAuthority.Name = "pnlAuthority";
            this.pnlAuthority.Padding = new System.Windows.Forms.Padding(10);
            this.pnlAuthority.Size = new System.Drawing.Size(476, 105);
            this.pnlAuthority.TabIndex = 0;
            // 
            // pnlClose
            // 
            this.pnlClose.Controls.Add(this.btnClose);
            this.pnlClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClose.Location = new System.Drawing.Point(0, 105);
            this.pnlClose.Margin = new System.Windows.Forms.Padding(0);
            this.pnlClose.Name = "pnlClose";
            this.pnlClose.Padding = new System.Windows.Forms.Padding(10);
            this.pnlClose.Size = new System.Drawing.Size(476, 60);
            this.pnlClose.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(10, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(456, 40);
            this.btnClose.TabIndex = 239;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(476, 165);
            this.ControlBox = false;
            this.Controls.Add(this.tlpAuthority);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAuthority";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAuthority_FormClosed);
            this.Load += new System.EventHandler(this.FormAuthority_Load);
            this.tlpAuthority.ResumeLayout(false);
            this.pnlClose.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpAuthority;
        private System.Windows.Forms.Panel pnlAuthority;
        private System.Windows.Forms.Panel pnlClose;
        private System.Windows.Forms.Button btnClose;
    }
}