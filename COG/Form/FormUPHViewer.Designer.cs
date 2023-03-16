namespace COG
{
    partial class FormUPHViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUPHViewer));
            this.pnlUPHViewer = new System.Windows.Forms.Panel();
            this.tlpUPHViewer = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tlpUPHViewer.SuspendLayout();
            this.tlpFormFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlUPHViewer
            // 
            this.pnlUPHViewer.BackColor = System.Drawing.Color.Silver;
            this.pnlUPHViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUPHViewer.Location = new System.Drawing.Point(0, 0);
            this.pnlUPHViewer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlUPHViewer.Name = "pnlUPHViewer";
            this.pnlUPHViewer.Size = new System.Drawing.Size(829, 372);
            this.pnlUPHViewer.TabIndex = 0;
            // 
            // tlpUPHViewer
            // 
            this.tlpUPHViewer.ColumnCount = 1;
            this.tlpUPHViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUPHViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpUPHViewer.Controls.Add(this.pnlUPHViewer, 0, 0);
            this.tlpUPHViewer.Controls.Add(this.tlpFormFunction, 0, 1);
            this.tlpUPHViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUPHViewer.Location = new System.Drawing.Point(0, 0);
            this.tlpUPHViewer.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUPHViewer.Name = "tlpUPHViewer";
            this.tlpUPHViewer.RowCount = 2;
            this.tlpUPHViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUPHViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpUPHViewer.Size = new System.Drawing.Size(829, 472);
            this.tlpUPHViewer.TabIndex = 1;
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
            this.tlpFormFunction.Location = new System.Drawing.Point(0, 372);
            this.tlpFormFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFunction.Name = "tlpFormFunction";
            this.tlpFormFunction.RowCount = 1;
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.Size = new System.Drawing.Size(829, 100);
            this.tlpFormFunction.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(732, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 94);
            this.btnExit.TabIndex = 295;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormUPHViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(829, 472);
            this.ControlBox = false;
            this.Controls.Add(this.tlpUPHViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormUPHViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormUPHViewer_Load);
            this.tlpUPHViewer.ResumeLayout(false);
            this.tlpFormFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlUPHViewer;
        private System.Windows.Forms.TableLayoutPanel tlpUPHViewer;
        private System.Windows.Forms.TableLayoutPanel tlpFormFunction;
        private System.Windows.Forms.Button btnExit;
    }
}