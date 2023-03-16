namespace COG
{
    partial class FormSelectTeaching
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectTeaching));
            this.BTN_PATTERN_TAG_00 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.BTN_EXIT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_PATTERN_TAG_00
            // 
            this.BTN_PATTERN_TAG_00.BackColor = System.Drawing.Color.Silver;
            this.BTN_PATTERN_TAG_00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_PATTERN_TAG_00.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_PATTERN_TAG_00.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTN_PATTERN_TAG_00.Location = new System.Drawing.Point(37, 36);
            this.BTN_PATTERN_TAG_00.Name = "BTN_PATTERN_TAG_00";
            this.BTN_PATTERN_TAG_00.Size = new System.Drawing.Size(374, 102);
            this.BTN_PATTERN_TAG_00.TabIndex = 56;
            this.BTN_PATTERN_TAG_00.Tag = "0";
            this.BTN_PATTERN_TAG_00.Text = "PreAlign";
            this.BTN_PATTERN_TAG_00.UseVisualStyleBackColor = false;
            this.BTN_PATTERN_TAG_00.Click += new System.EventHandler(this.BTN_SelectTeaching_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(451, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(374, 102);
            this.button1.TabIndex = 57;
            this.button1.Tag = "1";
            this.button1.Text = "Akkon";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BTN_SelectTeaching_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(868, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(374, 102);
            this.button2.TabIndex = 58;
            this.button2.Tag = "2";
            this.button2.Text = "Align Inspection";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.BTN_SelectTeaching_Click);
            // 
            // BTN_EXIT
            // 
            this.BTN_EXIT.BackColor = System.Drawing.Color.DarkGray;
            this.BTN_EXIT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_EXIT.BackgroundImage")));
            this.BTN_EXIT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTN_EXIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BTN_EXIT.Location = new System.Drawing.Point(1664, 863);
            this.BTN_EXIT.Name = "BTN_EXIT";
            this.BTN_EXIT.Size = new System.Drawing.Size(100, 100);
            this.BTN_EXIT.TabIndex = 59;
            this.BTN_EXIT.Text = "EXIT";
            this.BTN_EXIT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BTN_EXIT.UseVisualStyleBackColor = false;
            this.BTN_EXIT.Click += new System.EventHandler(this.BTN_EXIT_Click);
            // 
            // FormSelectTeaching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1776, 975);
            this.ControlBox = false;
            this.Controls.Add(this.BTN_EXIT);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTN_PATTERN_TAG_00);
            this.Name = "FormSelectTeaching";
            this.Text = "FormSelectTeaching";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_PATTERN_TAG_00;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BTN_EXIT;
    }
}