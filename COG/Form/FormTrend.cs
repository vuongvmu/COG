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
    public partial class FormTrend : Form
    {
        public CtrlAlignTrend TrendControl = null;

        public FormTrend()
        {
            InitializeComponent();
        }

        private void FormTrend_Load(object sender, EventArgs e)
        {
            InitializeUI();
            AddControl();
        }

        private void InitializeUI()
        {
            this.Width = 1400;
            this.Height = 900;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(20, 20);
        }

        private void AddControl()
        {
            TrendControl = new CtrlAlignTrend();
            TrendControl.Dock = DockStyle.Fill;
            this.pnlTrend.Controls.Add(TrendControl);
            TrendControl.MakeDisplay(5);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
