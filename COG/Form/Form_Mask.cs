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
using Cognex.VisionPro.PMAlign;
namespace COG
{
    public partial class Form_Mask : Form
    {
        public Form_Mask()
        {
            InitializeComponent();
        }
        private CogPMAlignTool _mCogPMAlignTool;
        public CogImage8Grey _CogImage8Grey = new CogImage8Grey();
        public CogPMAlignTool IsCogPMAlignTool
        {
            get { return _mCogPMAlignTool; }
            set
            {
                _mCogPMAlignTool = value;
                MaskEdit.Image = _CogImage8Grey;
                MaskEdit.MaskImage = _mCogPMAlignTool.Pattern.TrainImageMask;
            }
        }

        private void BTN_MASK_CLEAR_Click(object sender, EventArgs e)
        {
            if (_mCogPMAlignTool.Pattern.TrainImage == null) return;
            MaskEdit.Image = null;
            MaskEdit.MaskImage = null;
            MaskEdit.Image = _CogImage8Grey;
            MaskEdit.MaskImage = _mCogPMAlignTool.Pattern.TrainImageMask;
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                _mCogPMAlignTool.Pattern.TrainImageMask = (CogImage8Grey)MaskEdit.MaskImage.CopyBase(CogImageCopyModeConstants.SharePixels);
                _mCogPMAlignTool.Pattern.Train();
            }
            catch { }
           
        }

        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
