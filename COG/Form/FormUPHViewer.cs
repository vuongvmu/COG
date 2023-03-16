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
    public partial class FormUPHViewer : Form
    {
        CtrlUPHViewer uphViewerControl = null;

        public FormUPHViewer()
        {
            InitializeComponent();
        }

        private void FormUPHViewer_Load(object sender, EventArgs e)
        {
            InitializeUI();
            AddControl();
        }

        private void InitializeUI()
        {
            this.Width = 1800;
            this.Height = 900;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(20, 20);
        }

        private void AddControl()
        {
            uphViewerControl = new CtrlUPHViewer();
            uphViewerControl.Dock = DockStyle.Fill;
            pnlUPHViewer.Controls.Add(uphViewerControl);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
