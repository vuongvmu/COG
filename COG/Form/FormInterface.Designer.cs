namespace COG
{
    partial class FormInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInterface));
            this.tlpInterface = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormFucntion = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.rdoCCLink = new System.Windows.Forms.RadioButton();
            this.rdoMelsec = new System.Windows.Forms.RadioButton();
            this.pnlInterfaceView = new System.Windows.Forms.Panel();
            this.pnlCCLink = new System.Windows.Forms.Panel();
            this.tlpCCLink = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMelsec = new System.Windows.Forms.Panel();
            this.tlpMelsec = new System.Windows.Forms.TableLayoutPanel();
            this.tlpInterface.SuspendLayout();
            this.tlpFormFucntion.SuspendLayout();
            this.pnlInterfaceView.SuspendLayout();
            this.pnlCCLink.SuspendLayout();
            this.pnlMelsec.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpInterface
            // 
            this.tlpInterface.ColumnCount = 2;
            this.tlpInterface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInterface.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpInterface.Controls.Add(this.tlpFormFucntion, 1, 0);
            this.tlpInterface.Controls.Add(this.pnlInterfaceView, 0, 0);
            this.tlpInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpInterface.Location = new System.Drawing.Point(0, 0);
            this.tlpInterface.Margin = new System.Windows.Forms.Padding(0);
            this.tlpInterface.Name = "tlpInterface";
            this.tlpInterface.RowCount = 1;
            this.tlpInterface.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInterface.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpInterface.Size = new System.Drawing.Size(800, 450);
            this.tlpInterface.TabIndex = 0;
            // 
            // tlpFormFucntion
            // 
            this.tlpFormFucntion.ColumnCount = 1;
            this.tlpFormFucntion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.Controls.Add(this.btnExit, 0, 5);
            this.tlpFormFucntion.Controls.Add(this.rdoCCLink, 0, 1);
            this.tlpFormFucntion.Controls.Add(this.rdoMelsec, 0, 3);
            this.tlpFormFucntion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFucntion.Location = new System.Drawing.Point(700, 0);
            this.tlpFormFucntion.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFucntion.Name = "tlpFormFucntion";
            this.tlpFormFucntion.RowCount = 6;
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFormFucntion.Size = new System.Drawing.Size(100, 450);
            this.tlpFormFucntion.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(3, 353);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 94);
            this.btnExit.TabIndex = 291;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rdoCCLink
            // 
            this.rdoCCLink.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCCLink.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCCLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCCLink.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoCCLink.ForeColor = System.Drawing.Color.Black;
            this.rdoCCLink.Location = new System.Drawing.Point(3, 68);
            this.rdoCCLink.Name = "rdoCCLink";
            this.rdoCCLink.Size = new System.Drawing.Size(94, 94);
            this.rdoCCLink.TabIndex = 292;
            this.rdoCCLink.Tag = "0";
            this.rdoCCLink.Text = "CCLink";
            this.rdoCCLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCCLink.UseVisualStyleBackColor = false;
            this.rdoCCLink.CheckedChanged += new System.EventHandler(this.rdoShowInterface_CheckedChanged);
            // 
            // rdoMelsec
            // 
            this.rdoMelsec.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMelsec.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMelsec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMelsec.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoMelsec.ForeColor = System.Drawing.Color.Black;
            this.rdoMelsec.Location = new System.Drawing.Point(3, 188);
            this.rdoMelsec.Name = "rdoMelsec";
            this.rdoMelsec.Size = new System.Drawing.Size(94, 94);
            this.rdoMelsec.TabIndex = 292;
            this.rdoMelsec.Tag = "0";
            this.rdoMelsec.Text = "Melsec";
            this.rdoMelsec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMelsec.UseVisualStyleBackColor = false;
            this.rdoMelsec.CheckedChanged += new System.EventHandler(this.rdoShowInterface_CheckedChanged);
            // 
            // pnlInterfaceView
            // 
            this.pnlInterfaceView.Controls.Add(this.pnlCCLink);
            this.pnlInterfaceView.Controls.Add(this.pnlMelsec);
            this.pnlInterfaceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInterfaceView.Location = new System.Drawing.Point(0, 0);
            this.pnlInterfaceView.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInterfaceView.Name = "pnlInterfaceView";
            this.pnlInterfaceView.Size = new System.Drawing.Size(700, 450);
            this.pnlInterfaceView.TabIndex = 2;
            // 
            // pnlCCLink
            // 
            this.pnlCCLink.Controls.Add(this.tlpCCLink);
            this.pnlCCLink.Location = new System.Drawing.Point(9, 9);
            this.pnlCCLink.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCCLink.Name = "pnlCCLink";
            this.pnlCCLink.Size = new System.Drawing.Size(200, 200);
            this.pnlCCLink.TabIndex = 4;
            // 
            // tlpCCLink
            // 
            this.tlpCCLink.ColumnCount = 1;
            this.tlpCCLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCCLink.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCCLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCCLink.Location = new System.Drawing.Point(0, 0);
            this.tlpCCLink.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCCLink.Name = "tlpCCLink";
            this.tlpCCLink.RowCount = 1;
            this.tlpCCLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCCLink.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCCLink.Size = new System.Drawing.Size(200, 200);
            this.tlpCCLink.TabIndex = 0;
            // 
            // pnlMelsec
            // 
            this.pnlMelsec.AutoScroll = true;
            this.pnlMelsec.Controls.Add(this.tlpMelsec);
            this.pnlMelsec.Location = new System.Drawing.Point(9, 241);
            this.pnlMelsec.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMelsec.Name = "pnlMelsec";
            this.pnlMelsec.Size = new System.Drawing.Size(200, 200);
            this.pnlMelsec.TabIndex = 3;
            this.pnlMelsec.Visible = false;
            // 
            // tlpMelsec
            // 
            this.tlpMelsec.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMelsec.ColumnCount = 1;
            this.tlpMelsec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMelsec.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMelsec.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpMelsec.Location = new System.Drawing.Point(0, 0);
            this.tlpMelsec.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMelsec.Name = "tlpMelsec";
            this.tlpMelsec.RowCount = 1;
            this.tlpMelsec.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMelsec.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMelsec.Size = new System.Drawing.Size(200, 200);
            this.tlpMelsec.TabIndex = 1;
            // 
            // FormInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tlpInterface);
            this.Name = "FormInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInterface_Load);
            this.tlpInterface.ResumeLayout(false);
            this.tlpFormFucntion.ResumeLayout(false);
            this.pnlInterfaceView.ResumeLayout(false);
            this.pnlCCLink.ResumeLayout(false);
            this.pnlMelsec.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpInterface;
        private System.Windows.Forms.TableLayoutPanel tlpFormFucntion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel pnlInterfaceView;
        private System.Windows.Forms.Panel pnlMelsec;
        private System.Windows.Forms.RadioButton rdoCCLink;
        private System.Windows.Forms.RadioButton rdoMelsec;
        private System.Windows.Forms.Panel pnlCCLink;
        private System.Windows.Forms.TableLayoutPanel tlpCCLink;
        private System.Windows.Forms.TableLayoutPanel tlpMelsec;
    }
}