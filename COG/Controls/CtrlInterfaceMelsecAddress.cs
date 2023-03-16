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
    public partial class CtrlInterfaceMelsecAddress : UserControl
    {
        private int _address = 0;
        private int _value = 0;
        private string _mode = "";
        private string _caption = "";

        public CtrlInterfaceMelsecAddress(int address, int value, string mode, string caption)
        {
            InitializeComponent();

            SetItem(address, value, mode, caption);
        }

        private void SetItem(int address, int value, string mode, string caption)
        {
            _address = address;
            _value = value;
            _mode = mode;
            _caption = caption;
        }

        private void CtrlInterfaceMelsecAddress_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            lblAddress.Text = _address.ToString();
            lblValue.Text = _value.ToString();
            lblMode.Text = _mode.ToString();
            lblCaption.Text = _caption.ToString();
        }

        private void lblValue_Click(object sender, EventArgs e)
        {
            SetValue();
        }

        private void SetValue()
        {
            int outputData = 0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = Convert.ToInt32(formKeyPad.m_data);

            Main.WriteDevice(_address, outputData);
        }
    }
}
