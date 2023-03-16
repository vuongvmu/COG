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
    public partial class CtrlInterfaceMelsec : UserControl
    {
        private List<CtrlInterfaceMelsecAddress> _addressControlList = new List<CtrlInterfaceMelsecAddress>();

        public CtrlInterfaceMelsec()
        {
            InitializeComponent();
        }
    }
}
