namespace COG
{
    partial class Form_Mask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Mask));
            this.MaskEdit = new Cognex.VisionPro.CogImageMaskEditV2();
            this.BTN_SAVE = new System.Windows.Forms.Button();
            this.BTN_EXIT = new System.Windows.Forms.Button();
            this.BTN_MASK_CLEAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MaskEdit
            // 
            this.MaskEdit.Location = new System.Drawing.Point(2, 0);
            this.MaskEdit.Name = "MaskEdit";
            this.MaskEdit.Size = new System.Drawing.Size(768, 673);
            this.MaskEdit.TabIndex = 63;
            // 
            // BTN_SAVE
            // 
            this.BTN_SAVE.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_SAVE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_SAVE.BackgroundImage")));
            this.BTN_SAVE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_SAVE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_SAVE.Location = new System.Drawing.Point(534, 688);
            this.BTN_SAVE.Name = "BTN_SAVE";
            this.BTN_SAVE.Size = new System.Drawing.Size(100, 100);
            this.BTN_SAVE.TabIndex = 65;
            this.BTN_SAVE.Text = "SAVE";
            this.BTN_SAVE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_SAVE.UseVisualStyleBackColor = false;
            this.BTN_SAVE.Click += new System.EventHandler(this.BTN_SAVE_Click);
            // 
            // BTN_EXIT
            // 
            this.BTN_EXIT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_EXIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_EXIT.BackgroundImage")));
            this.BTN_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_EXIT.Location = new System.Drawing.Point(659, 688);
            this.BTN_EXIT.Name = "BTN_EXIT";
            this.BTN_EXIT.Size = new System.Drawing.Size(100, 100);
            this.BTN_EXIT.TabIndex = 66;
            this.BTN_EXIT.Text = "EXIT";
            this.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_EXIT.UseVisualStyleBackColor = false;
            this.BTN_EXIT.Click += new System.EventHandler(this.BTN_EXIT_Click);
            // 
            // BTN_MASK_CLEAR
            // 
            this.BTN_MASK_CLEAR.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_MASK_CLEAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_MASK_CLEAR.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MASK_CLEAR.Location = new System.Drawing.Point(12, 700);
            this.BTN_MASK_CLEAR.Name = "BTN_MASK_CLEAR";
            this.BTN_MASK_CLEAR.Size = new System.Drawing.Size(96, 88);
            this.BTN_MASK_CLEAR.TabIndex = 67;
            this.BTN_MASK_CLEAR.Text = "CLEAR";
            this.BTN_MASK_CLEAR.UseVisualStyleBackColor = false;
            this.BTN_MASK_CLEAR.Click += new System.EventHandler(this.BTN_MASK_CLEAR_Click);
            // 
            // Form_Mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(771, 791);
            this.ControlBox = false;
            this.Controls.Add(this.BTN_MASK_CLEAR);
            this.Controls.Add(this.BTN_EXIT);
            this.Controls.Add(this.BTN_SAVE);
            this.Controls.Add(this.MaskEdit);
            this.Name = "Form_Mask";
            this.Text = "Form_Mask";
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogImageMaskEditV2 MaskEdit;
        private System.Windows.Forms.Button BTN_SAVE;
        private System.Windows.Forms.Button BTN_EXIT;
        private System.Windows.Forms.Button BTN_MASK_CLEAR;
    }
}