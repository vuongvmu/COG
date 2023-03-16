namespace COG
{
    partial class FormRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecipe));
            this.tlpFormFucntion = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRecipe = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpRecipe = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFormFucntion.SuspendLayout();
            this.tlpRecipe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpFormFucntion
            // 
            this.tlpFormFucntion.ColumnCount = 4;
            this.tlpFormFucntion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFucntion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpFormFucntion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpFormFucntion.Controls.Add(this.btnExit, 3, 0);
            this.tlpFormFucntion.Controls.Add(this.btnSave, 1, 0);
            this.tlpFormFucntion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFucntion.Location = new System.Drawing.Point(0, 451);
            this.tlpFormFucntion.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFucntion.Name = "tlpFormFucntion";
            this.tlpFormFucntion.RowCount = 1;
            this.tlpFormFucntion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFucntion.Size = new System.Drawing.Size(1194, 100);
            this.tlpFormFucntion.TabIndex = 1;
            // 
            // pnlRecipe
            // 
            this.pnlRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRecipe.Location = new System.Drawing.Point(0, 0);
            this.pnlRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRecipe.Name = "pnlRecipe";
            this.pnlRecipe.Size = new System.Drawing.Size(1194, 451);
            this.pnlRecipe.TabIndex = 45;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(1097, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 94);
            this.btnExit.TabIndex = 38;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(987, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 94);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpRecipe
            // 
            this.tlpRecipe.ColumnCount = 1;
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipe.Controls.Add(this.pnlRecipe, 0, 0);
            this.tlpRecipe.Controls.Add(this.tlpFormFucntion, 0, 1);
            this.tlpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipe.Location = new System.Drawing.Point(0, 0);
            this.tlpRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipe.Name = "tlpRecipe";
            this.tlpRecipe.RowCount = 2;
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpRecipe.Size = new System.Drawing.Size(1194, 551);
            this.tlpRecipe.TabIndex = 46;
            // 
            // FormRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1194, 551);
            this.ControlBox = false;
            this.Controls.Add(this.tlpRecipe);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormRecipe_Load);
            this.tlpFormFucntion.ResumeLayout(false);
            this.tlpRecipe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpFormFucntion;
        private System.Windows.Forms.Panel pnlRecipe;
        private System.Windows.Forms.TableLayoutPanel tlpRecipe;
    }
}