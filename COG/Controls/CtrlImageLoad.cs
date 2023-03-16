using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COG.Class;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro;

namespace COG.Controls
{
    public partial class CtrlImageLoad : UserControl
    {
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;
        private int _tabNo = 0;

        public CtrlImageLoad(eStageNo stageNo, eCameraNo camNo)
        {
            InitializeComponent();
        }

        private void SetUnitIndex(eStageNo stageNo, eCameraNo camNo)
        {
            _stageNo = stageNo;
            _camNo = camNo;
        }

        private void CtrlImageLoad_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {

        }

        private void btnGrabStart_Click(object sender, EventArgs e)
        {
            StartGrab();
        }

        private void StartGrab()
        {

        }

        private void btnGrabStop_Click(object sender, EventArgs e)
        {
            StopGrab();
        }

        private void StopGrab()
        {

        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            OpenFileDialog openfileDialog = new OpenFileDialog();
            openfileDialog.ReadOnlyChecked = true;
            openfileDialog.Filter = "Bmp File | *.bmp";
            openfileDialog.ShowDialog();

            if (openfileDialog.FileName != "")
            {
                if (Main.vision.CogImgTool[0] == null)
                    Main.vision.CogImgTool[0] = new CogImageFileTool();

                Main.GetImageFile(Main.vision.CogImgTool[0], openfileDialog.FileName);
                Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;           // Main.vision.CogCamBuf[0] : 이미지 들어있다.
                Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf = (CogImage8Grey)Main.vision.CogCamBuf[0];
            }

            //PT_Display01.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            //cogDisplayThumbnail.Image = Main.AlignUnit[(int)_camNo].PAT[(int)_stageNo, _tabNo].m_CogLineScanBuf;
            //cogDisplayThumbnail.Zoom = 0.06;
            //cogDisplayThumbnail.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
            //Main.DisplayRefresh(PT_Display01);
        }
    }
}
