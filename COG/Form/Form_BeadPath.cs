using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.EdgeInspect;
namespace COG
{
    public partial class Form_BeadPath : Form
    {
        private CogGeneralContour mCogGeneralContour = new CogGeneralContour();
        private CogImage8Grey _objimage = new CogImage8Grey();
        public CogGeneralContour _cogGeneralContour
        {
            get { return mCogGeneralContour; } 
            set { mCogGeneralContour = value; }
         }
        public CogImage8Grey objImage
        {
           set { _objimage = value; }
        }
        public Form_BeadPath()
        {
            InitializeComponent();
        }

        private void cogContourEditV21_Load(object sender, EventArgs e)
        {
           // _cogGeneralContour.FitToImage(_objimage, 1, 1);
            cogContourEditV21.SetSubjectAndImage(_cogGeneralContour, _objimage);
            cogContourEditV21.OKClicked += Click_OK;
            cogContourEditV21.CancelClicked += Close;
            //cogContourEditV21.
            //cogContourEditV21.Subject = _cogGeneralContour;
        }
        private void Click_OK(object sender, EventArgs e)
        {
            mCogGeneralContour = cogContourEditV21.Subject;
            this.Close();
        }
        private void Close(object sender, EventArgs e)
        {
            mCogGeneralContour = cogContourEditV21.Subject;
            this.Close();
        }
    }
}
