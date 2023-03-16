using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.Main;

namespace COG.Controls
{
    public partial class CtrlAuthority : UserControl
    {
        private FormUserLogin _formUserLogin = null;
        //private FormAuthority _formAuthority = null;

        public CtrlAuthority()
        {
            InitializeComponent();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Main.Instance().Authority = eAuthority.Operator;

            //FormMain.Instance().AuthorityForm.CloseEventDelegate = () => FormMain.Instance().AuthorityForm = null;
            FormMain.Instance().AuthorityForm.Close();
        }

        private void btnEngineer_Click(object sender, EventArgs e)
        {
            //Main.Instance().Authority = eAuthority.Engineer;
            //SetAuthority(eAuthority.Engineer);

            //FormUserLogin formUserLogin = new FormUserLogin(_authority);
            //formUserLogin.Show();

            if (_formUserLogin == null)
            {
                _formUserLogin = new FormUserLogin(eAuthority.Engineer);
                _formUserLogin.CloseEventDelegate = () => this._formUserLogin = null;
                _formUserLogin.ShowDialog();

                //_formAuthority.CloseEventDelgate = () => this._formAuthority = null;
                FormMain.Instance().AuthorityForm.CloseEventDelegate = () => FormMain.Instance().AuthorityForm = null;
            }
        }

        private void btnMaker_Click(object sender, EventArgs e)
        {
            //Main.Instance().Authority = eAuthority.Maker;
            //SetAuthority(eAuthority.Maker);

            //FormUserLogin formUserLogin = new FormUserLogin(_authority);
            //formUserLogin.Show();

            if (_formUserLogin == null)
            {
                _formUserLogin = new FormUserLogin(eAuthority.Maker);
                _formUserLogin.CloseEventDelegate = () => this._formUserLogin = null;
                _formUserLogin.ShowDialog();

                FormMain.Instance().AuthorityForm.CloseEventDelegate = () => FormMain.Instance().AuthorityForm = null;
            }
        }
    }
}
