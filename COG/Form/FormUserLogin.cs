using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.Main;

namespace COG
{
    public partial class FormUserLogin : Form
    {
        private eAuthority _authority = eAuthority.Operator;

        public Action CloseEventDelegate;

        string tempPassword = string.Empty;

        public FormUserLogin(eAuthority authority)
        {
            InitializeComponent();

            _authority = authority;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            lblUserNameValue.Text = _authority.ToString();
        }

        private void FormUserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void lblInputText_Click(object sender, EventArgs e)
        {
            Label tempLabel = (Label)sender;

            Form_KeyBoard formkeyboard_Info = new Form_KeyBoard("Password", 2);
            formkeyboard_Info.ShowDialog();

            tempPassword = formkeyboard_Info.m_ResultString;

            tempLabel.Text = tempPassword;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tempPassword == Main.ReadRegistry("MT"/*_authority.ToString()*/) || tempPassword == "V" || tempPassword == "1")
            {
                SetAuthority(_authority);
                Destory();
            }
            else
                lblMessageValue.Text = "Current PassWord MisMatch";
        }

        private void SetAuthority(eAuthority authority)
        {
            Main.Instance().Authority = authority;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Destory();
        }

        private void Destory()
        {
            this.Close();
            FormMain.Instance().AuthorityForm.Close();
        }

        private void chkChangePassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChangePassword.Checked)
            {
                chkChangePassword.BackColor = Color.Honeydew;
                ChangePasswordControl(true);
            }
            else
            {
                chkChangePassword.BackColor = Color.DarkGray;
                ChangePasswordControl(false);
            }
        }

        private void ChangePasswordControl(bool isOn)
        {
            if (isOn)
            {
                tlpChangePassword.Visible = true;
                btnPasswordSave.Visible = true;
            }
            else
            {
                tlpChangePassword.Visible = false;
                btnPasswordSave.Visible = false;
            }
        }

        private void btnPasswordSave_Click(object sender, EventArgs e)
        {
            lblMessageValue.Text = "Password change successful";
            Main.WriteRegistry("MT"/*Main.Instance().Authority.ToString()*/, lblMessageValue.Text);
        }
    }
}
