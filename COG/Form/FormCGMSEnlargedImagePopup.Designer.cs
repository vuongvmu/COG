namespace COG
{
    partial class FormCGMSEnlargedImagePopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCGMSEnlargedImagePopup));
            this.tlpCGMSEnlargedImagePopup = new System.Windows.Forms.TableLayoutPanel();
            this.PT_DISPLAY_CONTROL = new JAS.Controls.Display.Display();
            this.tlpFormFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.tlpCGMSEnlargedImagePopup.SuspendLayout();
            this.tlpFormFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpCGMSEnlargedImagePopup
            // 
            this.tlpCGMSEnlargedImagePopup.ColumnCount = 1;
            this.tlpCGMSEnlargedImagePopup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSEnlargedImagePopup.Controls.Add(this.PT_DISPLAY_CONTROL, 0, 0);
            this.tlpCGMSEnlargedImagePopup.Controls.Add(this.tlpFormFunction, 0, 1);
            this.tlpCGMSEnlargedImagePopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCGMSEnlargedImagePopup.Location = new System.Drawing.Point(0, 0);
            this.tlpCGMSEnlargedImagePopup.Name = "tlpCGMSEnlargedImagePopup";
            this.tlpCGMSEnlargedImagePopup.RowCount = 2;
            this.tlpCGMSEnlargedImagePopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCGMSEnlargedImagePopup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpCGMSEnlargedImagePopup.Size = new System.Drawing.Size(944, 601);
            this.tlpCGMSEnlargedImagePopup.TabIndex = 0;
            // 
            // PT_DISPLAY_CONTROL
            // 
            this.PT_DISPLAY_CONTROL.BackColor = System.Drawing.Color.DarkGray;
            this.PT_DISPLAY_CONTROL.CustomCross = ((System.Drawing.PointF)(resources.GetObject("PT_DISPLAY_CONTROL.CustomCross")));
            this.PT_DISPLAY_CONTROL.DisplayManuConstants = ((JAS.Controls.Display.DisplayEnableConstants)((((((((((JAS.Controls.Display.DisplayEnableConstants.DisplayFit | JAS.Controls.Display.DisplayEnableConstants.Undo) 
            | JAS.Controls.Display.DisplayEnableConstants.Delete) 
            | JAS.Controls.Display.DisplayEnableConstants.TouchMove0) 
            | JAS.Controls.Display.DisplayEnableConstants.PointToPoint1) 
            | JAS.Controls.Display.DisplayEnableConstants.LineToLine2) 
            | JAS.Controls.Display.DisplayEnableConstants.Arc3Points) 
            | JAS.Controls.Display.DisplayEnableConstants.Square5) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossLine6) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossCustom)));
            this.PT_DISPLAY_CONTROL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PT_DISPLAY_CONTROL.Image = null;
            this.PT_DISPLAY_CONTROL.Location = new System.Drawing.Point(0, 0);
            this.PT_DISPLAY_CONTROL.Margin = new System.Windows.Forms.Padding(0);
            this.PT_DISPLAY_CONTROL.Name = "PT_DISPLAY_CONTROL";
            this.PT_DISPLAY_CONTROL.Resuloution = 1D;
            this.PT_DISPLAY_CONTROL.Size = new System.Drawing.Size(944, 501);
            this.PT_DISPLAY_CONTROL.TabIndex = 294;
            this.PT_DISPLAY_CONTROL.UseCustomCross = false;
            // 
            // tlpFormFunction
            // 
            this.tlpFormFunction.ColumnCount = 2;
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFormFunction.Controls.Add(this.btnExit, 1, 0);
            this.tlpFormFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFunction.Location = new System.Drawing.Point(0, 501);
            this.tlpFormFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFunction.Name = "tlpFormFunction";
            this.tlpFormFunction.RowCount = 1;
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.Size = new System.Drawing.Size(944, 100);
            this.tlpFormFunction.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(805, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(136, 94);
            this.btnExit.TabIndex = 293;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormCGMSEnlargedImagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(944, 601);
            this.ControlBox = false;
            this.Controls.Add(this.tlpCGMSEnlargedImagePopup);
            this.Name = "FormCGMSEnlargedImagePopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCGMSEnlargedImagePopup_FormClosed);
            this.Load += new System.EventHandler(this.FormCGMSEnlargedImagePopup_Load);
            this.tlpCGMSEnlargedImagePopup.ResumeLayout(false);
            this.tlpFormFunction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpCGMSEnlargedImagePopup;
        private System.Windows.Forms.TableLayoutPanel tlpFormFunction;
        private System.Windows.Forms.Button btnExit;
        public JAS.Controls.Display.Display PT_DISPLAY_CONTROL;
    }
}