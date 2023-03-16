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

namespace COG
{
    public partial class FormAuthority : Form
    {
        public CtrlAuthority AuthorityControl = null;

        public Action CloseEventDelegate;

        public FormAuthority()
        {
            InitializeComponent();
        }

        private void FormAuthority_Load(object sender, EventArgs e)
        {
            AddControl();
        }

        private void AddControl()
        {
            AuthorityControl = new CtrlAuthority();
            AuthorityControl.Dock = DockStyle.Fill;
            this.pnlAuthority.Controls.Add(AuthorityControl);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAuthority_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
    }
}
