namespace COG
{
    partial class FormRecipeCopy
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
            this.tlpRecipeCopy = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tlpFromItems = new System.Windows.Forms.TableLayoutPanel();
            this.tlpToItems = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFromStage = new System.Windows.Forms.TableLayoutPanel();
            this.tlpFromTab = new System.Windows.Forms.TableLayoutPanel();
            this.tlpToStage = new System.Windows.Forms.TableLayoutPanel();
            this.tlpToTab = new System.Windows.Forms.TableLayoutPanel();
            this.lblFromStage = new System.Windows.Forms.Label();
            this.lblFromTab = new System.Windows.Forms.Label();
            this.lblToStage = new System.Windows.Forms.Label();
            this.lblToTab = new System.Windows.Forms.Label();
            this.tlpRecipeCopy.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.tlpFromItems.SuspendLayout();
            this.tlpToItems.SuspendLayout();
            this.tlpFromStage.SuspendLayout();
            this.tlpFromTab.SuspendLayout();
            this.tlpToStage.SuspendLayout();
            this.tlpToTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRecipeCopy
            // 
            this.tlpRecipeCopy.ColumnCount = 2;
            this.tlpRecipeCopy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRecipeCopy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRecipeCopy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRecipeCopy.Controls.Add(this.tlpFromItems, 0, 1);
            this.tlpRecipeCopy.Controls.Add(this.tlpToItems, 1, 1);
            this.tlpRecipeCopy.Controls.Add(this.lblTo, 1, 0);
            this.tlpRecipeCopy.Controls.Add(this.lblFrom, 0, 0);
            this.tlpRecipeCopy.Controls.Add(this.tlpButtons, 1, 2);
            this.tlpRecipeCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipeCopy.Location = new System.Drawing.Point(0, 0);
            this.tlpRecipeCopy.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipeCopy.Name = "tlpRecipeCopy";
            this.tlpRecipeCopy.Padding = new System.Windows.Forms.Padding(10);
            this.tlpRecipeCopy.RowCount = 3;
            this.tlpRecipeCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRecipeCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipeCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpRecipeCopy.Size = new System.Drawing.Size(800, 450);
            this.tlpRecipeCopy.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Controls.Add(this.btnClose, 0, 0);
            this.tlpButtons.Controls.Add(this.btnApply, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(400, 380);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.Padding = new System.Windows.Forms.Padding(5);
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(390, 60);
            this.tlpButtons.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFrom.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblFrom.Location = new System.Drawing.Point(15, 15);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(5);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(380, 50);
            this.lblFrom.TabIndex = 4;
            this.lblFrom.Text = "FROM";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTo
            // 
            this.lblTo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTo.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(405, 15);
            this.lblTo.Margin = new System.Windows.Forms.Padding(5);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(380, 50);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.ForeColor = System.Drawing.Color.Red;
            this.btnApply.Location = new System.Drawing.Point(8, 8);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(184, 44);
            this.btnApply.TabIndex = 242;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkGray;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(198, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(184, 44);
            this.btnClose.TabIndex = 243;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpFromItems
            // 
            this.tlpFromItems.ColumnCount = 1;
            this.tlpFromItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFromItems.Controls.Add(this.tlpFromTab, 0, 1);
            this.tlpFromItems.Controls.Add(this.tlpFromStage, 0, 0);
            this.tlpFromItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFromItems.Location = new System.Drawing.Point(10, 70);
            this.tlpFromItems.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFromItems.Name = "tlpFromItems";
            this.tlpFromItems.RowCount = 2;
            this.tlpFromItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFromItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFromItems.Size = new System.Drawing.Size(390, 310);
            this.tlpFromItems.TabIndex = 6;
            // 
            // tlpToItems
            // 
            this.tlpToItems.ColumnCount = 1;
            this.tlpToItems.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpToItems.Controls.Add(this.tlpToTab, 0, 1);
            this.tlpToItems.Controls.Add(this.tlpToStage, 0, 0);
            this.tlpToItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToItems.Location = new System.Drawing.Point(400, 70);
            this.tlpToItems.Margin = new System.Windows.Forms.Padding(0);
            this.tlpToItems.Name = "tlpToItems";
            this.tlpToItems.RowCount = 2;
            this.tlpToItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpToItems.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpToItems.Size = new System.Drawing.Size(390, 310);
            this.tlpToItems.TabIndex = 7;
            // 
            // tlpFromStage
            // 
            this.tlpFromStage.ColumnCount = 2;
            this.tlpFromStage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFromStage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpFromStage.Controls.Add(this.lblFromStage, 0, 0);
            this.tlpFromStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFromStage.Location = new System.Drawing.Point(0, 0);
            this.tlpFromStage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFromStage.Name = "tlpFromStage";
            this.tlpFromStage.RowCount = 1;
            this.tlpFromStage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFromStage.Size = new System.Drawing.Size(390, 155);
            this.tlpFromStage.TabIndex = 0;
            // 
            // tlpFromTab
            // 
            this.tlpFromTab.ColumnCount = 2;
            this.tlpFromTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFromTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpFromTab.Controls.Add(this.lblFromTab, 0, 0);
            this.tlpFromTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFromTab.Location = new System.Drawing.Point(0, 155);
            this.tlpFromTab.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFromTab.Name = "tlpFromTab";
            this.tlpFromTab.RowCount = 1;
            this.tlpFromTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFromTab.Size = new System.Drawing.Size(390, 155);
            this.tlpFromTab.TabIndex = 1;
            // 
            // tlpToStage
            // 
            this.tlpToStage.ColumnCount = 2;
            this.tlpToStage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpToStage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpToStage.Controls.Add(this.lblToStage, 0, 0);
            this.tlpToStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToStage.Location = new System.Drawing.Point(0, 0);
            this.tlpToStage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpToStage.Name = "tlpToStage";
            this.tlpToStage.RowCount = 1;
            this.tlpToStage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToStage.Size = new System.Drawing.Size(390, 155);
            this.tlpToStage.TabIndex = 1;
            // 
            // tlpToTab
            // 
            this.tlpToTab.ColumnCount = 2;
            this.tlpToTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpToTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlpToTab.Controls.Add(this.lblToTab, 0, 0);
            this.tlpToTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpToTab.Location = new System.Drawing.Point(0, 155);
            this.tlpToTab.Margin = new System.Windows.Forms.Padding(0);
            this.tlpToTab.Name = "tlpToTab";
            this.tlpToTab.RowCount = 1;
            this.tlpToTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpToTab.Size = new System.Drawing.Size(390, 155);
            this.tlpToTab.TabIndex = 2;
            // 
            // lblFromStage
            // 
            this.lblFromStage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblFromStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFromStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromStage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromStage.Location = new System.Drawing.Point(5, 5);
            this.lblFromStage.Margin = new System.Windows.Forms.Padding(5);
            this.lblFromStage.Name = "lblFromStage";
            this.lblFromStage.Size = new System.Drawing.Size(119, 145);
            this.lblFromStage.TabIndex = 5;
            this.lblFromStage.Text = "STAGE";
            this.lblFromStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromTab
            // 
            this.lblFromTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblFromTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFromTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFromTab.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblFromTab.Location = new System.Drawing.Point(5, 5);
            this.lblFromTab.Margin = new System.Windows.Forms.Padding(5);
            this.lblFromTab.Name = "lblFromTab";
            this.lblFromTab.Size = new System.Drawing.Size(119, 145);
            this.lblFromTab.TabIndex = 6;
            this.lblFromTab.Text = "TAB";
            this.lblFromTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToStage
            // 
            this.lblToStage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblToStage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToStage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblToStage.Location = new System.Drawing.Point(5, 5);
            this.lblToStage.Margin = new System.Windows.Forms.Padding(5);
            this.lblToStage.Name = "lblToStage";
            this.lblToStage.Size = new System.Drawing.Size(119, 145);
            this.lblToStage.TabIndex = 6;
            this.lblToStage.Text = "STAGE";
            this.lblToStage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblToTab
            // 
            this.lblToTab.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblToTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblToTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblToTab.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblToTab.Location = new System.Drawing.Point(5, 5);
            this.lblToTab.Margin = new System.Windows.Forms.Padding(5);
            this.lblToTab.Name = "lblToTab";
            this.lblToTab.Size = new System.Drawing.Size(119, 145);
            this.lblToTab.TabIndex = 7;
            this.lblToTab.Text = "TAB";
            this.lblToTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormRecipeCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.tlpRecipeCopy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRecipeCopy";
            this.Text = "Copy Control";
            this.Load += new System.EventHandler(this.FormRecipeCopy_Load);
            this.tlpRecipeCopy.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpFromItems.ResumeLayout(false);
            this.tlpToItems.ResumeLayout(false);
            this.tlpFromStage.ResumeLayout(false);
            this.tlpFromTab.ResumeLayout(false);
            this.tlpToStage.ResumeLayout(false);
            this.tlpToTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRecipeCopy;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tlpFromItems;
        private System.Windows.Forms.TableLayoutPanel tlpFromStage;
        private System.Windows.Forms.TableLayoutPanel tlpToItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tlpFromTab;
        private System.Windows.Forms.Label lblFromTab;
        private System.Windows.Forms.Label lblFromStage;
        private System.Windows.Forms.TableLayoutPanel tlpToTab;
        private System.Windows.Forms.Label lblToTab;
        private System.Windows.Forms.TableLayoutPanel tlpToStage;
        private System.Windows.Forms.Label lblToStage;
    }
}