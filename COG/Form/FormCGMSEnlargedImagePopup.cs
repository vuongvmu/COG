using COG.Controls;
using Cognex.VisionPro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro.ImageFile;
namespace COG
{
    public partial class FormCGMSEnlargedImagePopup : Form
    {
        private CogRecordDisplay _cogRecordDisplay = new CogRecordDisplay();

        public Action CloseEventDelegate;

        private int _selectedIndex = -1;
        private int _row;
        private int _col;

        private CogImage8Grey _image = null;
        private CogGraphicInteractiveCollection _Graph;
        public FormCGMSEnlargedImagePopup(CogImage8Grey image, CogGraphicInteractiveCollection Graphy /*int index ,int row, int col*/)
        {
            InitializeComponent();

            _image = image;
            _Graph = Graphy;
        }

        private void FormCGMSEnlargedImagePopup_Load(object sender, EventArgs e)
        {
            AddControl();
        }

        private void AddControl()
        {
            //CogImage8Grey cogImage = (CogImage8Grey)FormMain.Instance().CGMSViewerControl.GetImage(_selectedIndex);
            //CogImage8Grey cogImage = Main.AlignUnit[0].PAT[_Row, _Col].m_CogLineScanBuf;
            PT_DISPLAY_CONTROL.Resuloution = (Settings.Instance().Operation.LineScanPixelSize / Settings.Instance().Operation.LensMagnification) * 1000;
            _cogRecordDisplay = PT_DISPLAY_CONTROL.CogDisplay00;

            CogImage8Grey cogImage = _image;
            if (cogImage == null)
                return;

            _cogRecordDisplay.Image = cogImage;
            _cogRecordDisplay.Fit();

            if (_Graph != null)
                _cogRecordDisplay.InteractiveGraphics.AddList(_Graph, "result", false);
            //string fileName = string.Format("D:\\CGMSImage\\");
            //fileName += DateTime.Now.ToString("hh_mm_ss_");
            //string strFile = string.Format("{0:D}_{1:D}.bmp", _Row, _Col);
            //fileName += strFile;
            //CogImageFileBMP imagecontrol = new CogImageFileBMP();
            //try
            //{
            //    imagecontrol.Open(fileName, CogImageFileModeConstants.Write);
            //    imagecontrol.Append(cogDisplay.Image);
            //    imagecontrol.Close();
            //}
            //catch
            //{

            //}
            ////cogDisplay.AutoFit(true);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCGMSEnlargedImagePopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }
    }
}
