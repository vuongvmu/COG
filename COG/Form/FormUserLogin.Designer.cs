namespace COG
{
    partial class FormUserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.tlpUserLogin = new System.Windows.Forms.TableLayoutPanel();
            this.tlpChangePassword = new System.Windows.Forms.TableLayoutPanel();
            this.lblConfirmPasswordValue = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.lblNewPasswordValue = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tlpData = new System.Windows.Forms.TableLayoutPanel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMessageValue = new System.Windows.Forms.Label();
            this.lblPasswordValue = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserNameValue = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.btnPasswordSave = new System.Windows.Forms.Button();
            this.chkChangePassword = new System.Windows.Forms.CheckBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlLogin.SuspendLayout();
            this.tlpUserLogin.SuspendLayout();
            this.tlpChangePassword.SuspendLayout();
            this.tlpData.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.DarkGray;
            this.pnlLogin.Controls.Add(this.tlpUserLogin);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(0, 0);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(653, 456);
            this.pnlLogin.TabIndex = 0;
            // 
            // tlpUserLogin
            // 
            this.tlpUserLogin.ColumnCount = 1;
            this.tlpUserLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUserLogin.Controls.Add(this.tlpChangePassword, 0, 1);
            this.tlpUserLogin.Controls.Add(this.tlpData, 0, 0);
            this.tlpUserLogin.Controls.Add(this.tlpButton, 0, 2);
            this.tlpUserLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUserLogin.Location = new System.Drawing.Point(0, 0);
            this.tlpUserLogin.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUserLogin.Name = "tlpUserLogin";
            this.tlpUserLogin.Padding = new System.Windows.Forms.Padding(10);
            this.tlpUserLogin.RowCount = 3;
            this.tlpUserLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpUserLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpUserLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpUserLogin.Size = new System.Drawing.Size(653, 456);
            this.tlpUserLogin.TabIndex = 1;
            // 
            // tlpChangePassword
            // 
            this.tlpChangePassword.ColumnCount = 2;
            this.tlpChangePassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpChangePassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpChangePassword.Controls.Add(this.lblConfirmPasswordValue, 1, 1);
            this.tlpChangePassword.Controls.Add(this.lblConfirmPassword, 0, 1);
            this.tlpChangePassword.Controls.Add(this.lblNewPasswordValue, 1, 0);
            this.tlpChangePassword.Controls.Add(this.lblNewPassword, 0, 0);
            this.tlpChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChangePassword.Location = new System.Drawing.Point(10, 199);
            this.tlpChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.tlpChangePassword.Name = "tlpChangePassword";
            this.tlpChangePassword.Padding = new System.Windows.Forms.Padding(10);
            this.tlpChangePassword.RowCount = 2;
            this.tlpChangePassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChangePassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChangePassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpChangePassword.Size = new System.Drawing.Size(633, 126);
            this.tlpChangePassword.TabIndex = 2;
            this.tlpChangePassword.Visible = false;
            // 
            // lblConfirmPasswordValue
            // 
            this.lblConfirmPasswordValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConfirmPasswordValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfirmPasswordValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPasswordValue.Location = new System.Drawing.Point(168, 68);
            this.lblConfirmPasswordValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblConfirmPasswordValue.Name = "lblConfirmPasswordValue";
            this.lblConfirmPasswordValue.Size = new System.Drawing.Size(450, 43);
            this.lblConfirmPasswordValue.TabIndex = 3;
            this.lblConfirmPasswordValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConfirmPasswordValue.Click += new System.EventHandler(this.lblInputText_Click);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConfirmPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfirmPassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblConfirmPassword.Location = new System.Drawing.Point(15, 68);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(5);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(143, 43);
            this.lblConfirmPassword.TabIndex = 2;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNewPasswordValue
            // 
            this.lblNewPasswordValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewPasswordValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewPasswordValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewPasswordValue.Location = new System.Drawing.Point(168, 15);
            this.lblNewPasswordValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblNewPasswordValue.Name = "lblNewPasswordValue";
            this.lblNewPasswordValue.Size = new System.Drawing.Size(450, 43);
            this.lblNewPasswordValue.TabIndex = 1;
            this.lblNewPasswordValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNewPasswordValue.Click += new System.EventHandler(this.lblInputText_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNewPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewPassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblNewPassword.Location = new System.Drawing.Point(15, 15);
            this.lblNewPassword.Margin = new System.Windows.Forms.Padding(5);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(143, 43);
            this.lblNewPassword.TabIndex = 0;
            this.lblNewPassword.Text = "New Password";
            this.lblNewPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpData
            // 
            this.tlpData.ColumnCount = 2;
            this.tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpData.Controls.Add(this.lblMessage, 0, 2);
            this.tlpData.Controls.Add(this.lblMessageValue, 0, 2);
            this.tlpData.Controls.Add(this.lblPasswordValue, 1, 1);
            this.tlpData.Controls.Add(this.lblPassword, 0, 1);
            this.tlpData.Controls.Add(this.lblUserNameValue, 1, 0);
            this.tlpData.Controls.Add(this.lblUserName, 0, 0);
            this.tlpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpData.Location = new System.Drawing.Point(10, 10);
            this.tlpData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpData.Name = "tlpData";
            this.tlpData.Padding = new System.Windows.Forms.Padding(10);
            this.tlpData.RowCount = 3;
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpData.Size = new System.Drawing.Size(633, 189);
            this.tlpData.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMessage.Location = new System.Drawing.Point(15, 127);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(5);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(143, 47);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessageValue
            // 
            this.lblMessageValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessageValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessageValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblMessageValue.Location = new System.Drawing.Point(168, 127);
            this.lblMessageValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblMessageValue.Name = "lblMessageValue";
            this.lblMessageValue.Size = new System.Drawing.Size(450, 47);
            this.lblMessageValue.TabIndex = 4;
            this.lblMessageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPasswordValue
            // 
            this.lblPasswordValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPasswordValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPasswordValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordValue.Location = new System.Drawing.Point(168, 71);
            this.lblPasswordValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblPasswordValue.Name = "lblPasswordValue";
            this.lblPasswordValue.Size = new System.Drawing.Size(450, 46);
            this.lblPasswordValue.TabIndex = 3;
            this.lblPasswordValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPasswordValue.Click += new System.EventHandler(this.lblInputText_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Location = new System.Drawing.Point(15, 71);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(143, 46);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserNameValue
            // 
            this.lblUserNameValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUserNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserNameValue.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserNameValue.Location = new System.Drawing.Point(168, 15);
            this.lblUserNameValue.Margin = new System.Windows.Forms.Padding(5);
            this.lblUserNameValue.Name = "lblUserNameValue";
            this.lblUserNameValue.Size = new System.Drawing.Size(450, 46);
            this.lblUserNameValue.TabIndex = 1;
            this.lblUserNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUserName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lblUserName.Location = new System.Drawing.Point(15, 15);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(5);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(143, 46);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 4;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.Controls.Add(this.btnPasswordSave, 0, 0);
            this.tlpButton.Controls.Add(this.chkChangePassword, 0, 0);
            this.tlpButton.Controls.Add(this.btnEnter, 2, 0);
            this.tlpButton.Controls.Add(this.btnExit, 3, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(10, 325);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.Padding = new System.Windows.Forms.Padding(10);
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(633, 121);
            this.tlpButton.TabIndex = 0;
            // 
            // btnPasswordSave
            // 
            this.btnPasswordSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnPasswordSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPasswordSave.BackgroundImage")));
            this.btnPasswordSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPasswordSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPasswordSave.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            this.btnPasswordSave.Location = new System.Drawing.Point(166, 13);
            this.btnPasswordSave.Name = "btnPasswordSave";
            this.btnPasswordSave.Size = new System.Drawing.Size(147, 95);
            this.btnPasswordSave.TabIndex = 244;
            this.btnPasswordSave.Text = "Save Changed Password";
            this.btnPasswordSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPasswordSave.UseVisualStyleBackColor = false;
            this.btnPasswordSave.Visible = false;
            this.btnPasswordSave.Click += new System.EventHandler(this.btnPasswordSave_Click);
            // 
            // chkChangePassword
            // 
            this.chkChangePassword.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkChangePassword.BackColor = System.Drawing.Color.DarkGray;
            this.chkChangePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkChangePassword.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkChangePassword.Location = new System.Drawing.Point(13, 13);
            this.chkChangePassword.Name = "chkChangePassword";
            this.chkChangePassword.Size = new System.Drawing.Size(147, 95);
            this.chkChangePassword.TabIndex = 243;
            this.chkChangePassword.Text = "CHANGE PASSWORD";
            this.chkChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkChangePassword.UseVisualStyleBackColor = false;
            this.chkChangePassword.CheckedChanged += new System.EventHandler(this.chkChangePassword_CheckedChanged);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.DarkGray;
            this.btnEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnter.Font = new System.Drawing.Font("맑은 고딕", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnter.Image = ((System.Drawing.Image)(resources.GetObject("btnEnter.Image")));
            this.btnEnter.Location = new System.Drawing.Point(319, 13);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(147, 95);
            this.btnEnter.TabIndex = 241;
            this.btnEnter.Text = "ENTER";
            this.btnEnter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(472, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(148, 95);
            this.btnExit.TabIndex = 242;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormUserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 456);
            this.ControlBox = false;
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormUserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormUserLogin_FormClosed);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.pnlLogin.ResumeLayout(false);
            this.tlpUserLogin.ResumeLayout(false);
            this.tlpChangePassword.ResumeLayout(false);
            this.tlpData.ResumeLayout(false);
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.TableLayoutPanel tlpUserLogin;
        private System.Windows.Forms.TableLayoutPanel tlpData;
        private System.Windows.Forms.Label lblPasswordValue;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserNameValue;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblMessageValue;
        private System.Windows.Forms.TableLayoutPanel tlpChangePassword;
        private System.Windows.Forms.Label lblConfirmPasswordValue;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblNewPasswordValue;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.CheckBox chkChangePassword;
        private System.Windows.Forms.Button btnPasswordSave;
    }
}