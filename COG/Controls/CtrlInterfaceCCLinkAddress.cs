using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG.Controls
{
    public partial class CtrlInterfaceCCLinkAddress : UserControl
    {
        //private Dictionary<string, string> _dataDictinary = null;
        private string _name = "";
        private string _caption = "";
        private bool _isEnable = false;

        public CtrlInterfaceCCLinkAddress(string name, string caption, bool isEnable = false)
        {
            InitializeComponent();

            SetItem(name, caption, isEnable);
        }

        private void SetItem(string name, string caption, bool isEnable)
        {
            _name = name;
            _caption = caption;
            _isEnable = isEnable;
        }

        private void CtrlPLCAddress_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            chkBit.Text = _name.ToString();
            lblCaption.Text = _caption.ToString();
        }

        private void chkBit_CheckedChanged(object sender, EventArgs e)
        {
            SetChecked(sender);
        }

        private void SetChecked(object sender)
        {
            CheckBox chk = sender as CheckBox;

            if (_isEnable)
            {
                if (chk.Checked)
                    chk.BackColor = Color.LimeGreen;
                else
                    chk.BackColor = Color.DarkGray;
            }
        }
    }
}
