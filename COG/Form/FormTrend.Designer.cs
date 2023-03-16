namespace COG
{
    partial class FormTrend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTrend));
            this.pnlTrend = new System.Windows.Forms.Panel();
            this.tlpTrend = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tlpTrend.SuspendLayout();
            this.tlpFormFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTrend
            // 
            this.pnlTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTrend.Location = new System.Drawing.Point(0, 0);
            this.pnlTrend.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTrend.Name = "pnlTrend";
            this.pnlTrend.Size = new System.Drawing.Size(434, 311);
            this.pnlTrend.TabIndex = 0;
            // 
            // tlpTrend
            // 
            this.tlpTrend.ColumnCount = 1;
            this.tlpTrend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrend.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTrend.Controls.Add(this.tlpFormFunction, 0, 1);
            this.tlpTrend.Controls.Add(this.pnlTrend, 0, 0);
            this.tlpTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTrend.Location = new System.Drawing.Point(0, 0);
            this.tlpTrend.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTrend.Name = "tlpTrend";
            this.tlpTrend.RowCount = 2;
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTrend.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTrend.Size = new System.Drawing.Size(434, 411);
            this.tlpTrend.TabIndex = 1;
            // 
            // tlpFormFunction
            // 
            this.tlpFormFunction.ColumnCount = 2;
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFormFunction.Controls.Add(this.btnExit, 1, 0);
            this.tlpFormFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFunction.Location = new System.Drawing.Point(0, 311);
            this.tlpFormFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFunction.Name = "tlpFormFunction";
            this.tlpFormFunction.RowCount = 1;
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.Size = new System.Drawing.Size(434, 100);
            this.tlpFormFunction.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(337, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 94);
            this.btnExit.TabIndex = 295;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormTrend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(434, 411);
            this.ControlBox = false;
            this.Controls.Add(this.tlpTrend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTrend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormTrend_Load);
            this.tlpTrend.ResumeLayout(false);
            this.tlpFormFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTrend;
        private System.Windows.Forms.TableLayoutPanel tlpTrend;
        private System.Windows.Forms.TableLayoutPanel tlpFormFunction;
        private System.Windows.Forms.Button btnExit;
    }
}