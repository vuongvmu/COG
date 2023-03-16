namespace COG
{
    partial class FormInspectionSimulationForEngineer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInspectionSimulationForEngineer));
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnShowROI_MarkRegister = new System.Windows.Forms.Button();
            this.PT_DISPLAY_CONTROL = new JAS.Controls.Display.Display();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(652, 9);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(129, 44);
            this.btnLoadImage.TabIndex = 281;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(943, 465);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 44);
            this.btnClose.TabIndex = 281;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(652, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 400);
            this.tabControl1.TabIndex = 282;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnShowROI_MarkRegister);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(412, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mark Register";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(412, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnShowROI_MarkRegister
            // 
            this.btnShowROI_MarkRegister.Location = new System.Drawing.Point(6, 6);
            this.btnShowROI_MarkRegister.Name = "btnShowROI_MarkRegister";
            this.btnShowROI_MarkRegister.Size = new System.Drawing.Size(100, 46);
            this.btnShowROI_MarkRegister.TabIndex = 0;
            this.btnShowROI_MarkRegister.Text = "Show ROI";
            this.btnShowROI_MarkRegister.UseVisualStyleBackColor = true;
            this.btnShowROI_MarkRegister.Click += new System.EventHandler(this.btnShowROI_MarkRegister_Click);
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
            this.PT_DISPLAY_CONTROL.Image = null;
            this.PT_DISPLAY_CONTROL.Location = new System.Drawing.Point(9, 9);
            this.PT_DISPLAY_CONTROL.Margin = new System.Windows.Forms.Padding(0);
            this.PT_DISPLAY_CONTROL.Name = "PT_DISPLAY_CONTROL";
            this.PT_DISPLAY_CONTROL.Resuloution = 1D;
            this.PT_DISPLAY_CONTROL.Size = new System.Drawing.Size(640, 500);
            this.PT_DISPLAY_CONTROL.TabIndex = 280;
            this.PT_DISPLAY_CONTROL.UseCustomCross = false;
            // 
            // FormInspectionSimulationForEngineer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1084, 519);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.PT_DISPLAY_CONTROL);
            this.Name = "FormInspectionSimulationForEngineer";
            this.Text = "FormInspectionSimulationForEngineer";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private JAS.Controls.Display.Display PT_DISPLAY_CONTROL;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnShowROI_MarkRegister;
        private System.Windows.Forms.TabPage tabPage2;
    }
}