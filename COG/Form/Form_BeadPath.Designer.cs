namespace COG
{
    partial class Form_BeadPath
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
            this.cogContourEditV21 = new Cognex.VisionPro.EdgeInspect.CogContourEditV2();
            this.SuspendLayout();
            // 
            // cogContourEditV21
            // 
            this.cogContourEditV21.Location = new System.Drawing.Point(12, 12);
            this.cogContourEditV21.Name = "cogContourEditV21";
            this.cogContourEditV21.Size = new System.Drawing.Size(1119, 530);
            this.cogContourEditV21.Subject = null;
            this.cogContourEditV21.TabIndex = 0;
            this.cogContourEditV21.Load += new System.EventHandler(this.cogContourEditV21_Load);
            // 
            // Form_BeadPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 548);
            this.Controls.Add(this.cogContourEditV21);
            this.Name = "Form_BeadPath";
            this.Text = " ";
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.EdgeInspect.CogContourEditV2 cogContourEditV21;
    }
}