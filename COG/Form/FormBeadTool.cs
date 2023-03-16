using Cognex.VisionPro.EdgeInspect;
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
    public partial class FormBeadTool : Form
    {
        private CogBeadInspectTool _cogBeadInspectTool = new CogBeadInspectTool();

        private Cognex.VisionPro.CogImage8Grey _tlqkf = new Cognex.VisionPro.CogImage8Grey();
        public FormBeadTool(Cognex.VisionPro.CogImage8Grey tt)
        {
            InitializeComponent();

            _tlqkf = tt;
        }

        private void Init()
        {
            cogBeadInspectEditV21.Subject.InputImage = _tlqkf;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBeadTool_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
