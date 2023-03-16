using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JAS.Controls.Display;
using Cognex.VisionPro.Display;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using System.Runtime.InteropServices;
using static COG.ClsImage;
using System.Drawing.Imaging;
using COG.Class.MOTION;

namespace COG
{
    public partial class FormFlyingVisionView : Form
    {
        private CogDisplay[] _cogDisplayList = new CogDisplay[6];
        bool isGrabbing = false;

        public FormFlyingVisionView()
        {
            InitializeComponent();
        }

        private void AddControls()
        {
            for (int i = 0; i < 6; i++)
            {
                _cogDisplayList[i] = new CogDisplay();
            }
            _cogDisplayList[0] = cogDisplay1;
            _cogDisplayList[1] = cogDisplay2;
            _cogDisplayList[2] = cogDisplay3;
            _cogDisplayList[3] = cogDisplay4;
            _cogDisplayList[4] = cogDisplay5;
            _cogDisplayList[5] = cogDisplay6;
        }

        private void ClearDisplay()
        {
            foreach (var item in _cogDisplayList)
            {
                if (item.Image != null)
                    item.Image = null;
            }
        }

        private void Form_Test_Load(object sender, EventArgs e)
        {
            AddControls();

            RegisterReceiveImageEvent();
        }

        private void RegisterReceiveImageEvent()
        {
            //Main.MilFrameGrabber.ReceiveImage += _mfg_ReceiveImage;
        }

        private void Form_Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            Terminate();
        }

        private void ReleaseReceiveImageEvent()
        {
            //Main.MilFrameGrabber.ReceiveImage -= _mfg_ReceiveImage;
        }

        private void Terminate()
        {
            ReleaseReceiveImageEvent();
        }

        private void btnGrabStart_Click(object sender, EventArgs e)
        {
            ClearDisplay();

            // 0 -> 250
            Main.Instance().MotionManager.SetDefaultParameter(eAxis.Axis_X);

            double targetPosition = 250;
            //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
            //    (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], Class.MOTION.eAxis.Axis_X, targetPosition);
            Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, targetPosition);

            Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);

            // Grab
            isGrabbing = true;
            GetImage();

            // 250 -> 0
            targetPosition = 0;
            //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
            //    (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], Class.MOTION.eAxis.Axis_X, targetPosition);
            Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, targetPosition);

            /*
            Main.MotionCtrl.MotionSetParameter_Start(0, 100, 10, 250);
            Main.MotionCtrl.StartMove(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP, 
                (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], (int)Main.DefaultMotionData.MOTION_AXIS_X, 250);
            Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
                (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], (int)Main.DefaultMotionData.MOTION_AXIS_X);
            isGrabbing = true;
            GetImage();
            Main.MotionCtrl.StartMove(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
                (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], (int)Main.DefaultMotionData.MOTION_AXIS_X, 0);
            /**/
        }

        private void GetImage()
        {
            int TriggerCount = 6;
            isGrabbing = true;
            if (isGrabbing)
            {
                if (Main.MilFrameGrabber.AllocBuffer_ExternalTriggerGrab(TriggerCount))
                {
                    Task.Factory.StartNew(() => { Main.MilFrameGrabber.ExternalTriggerGrabStart(); });
                }
            }
            else
                Main.MilFrameGrabber.ExternalTriggerGrabStop();
        }

        private Bitmap ByteToBitmap(byte[] arr)
        {
            Bitmap bmp = new Bitmap(4096, 3000, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            System.Drawing.Imaging.BitmapData data = bmp.LockBits(new Rectangle(0, 0, 4096, 3000), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            IntPtr ptr = data.Scan0;
            Marshal.Copy(arr, 0, ptr, 4096 * 3000);
            bmp.UnlockBits(data);

            System.Drawing.Imaging.ColorPalette Gpal = bmp.Palette;
            for (int i = 0; i < 256; i++)
                Gpal.Entries[i] = Color.FromArgb(i, i, i);

            bmp.Palette = Gpal;

            return bmp;
        }

        private void _mfg_ReceiveImage(int index)
        {
            byte[] imageByte = Main.MilFrameGrabber.GetImageBytes(index);
            if (imageByte == null)
                return;

            Console.WriteLine("Image Byte Lenth : {0:D}", imageByte.Length.ToString());
            var cogImage = Convert8BitRawImageToCognexImage(imageByte, Main.MilFrameGrabber.ImageWidthDefault, Main.MilFrameGrabber.ImageHeightDefault);
            //cogDisplay[index].ClearImage8GreyColorMap();
            // cogDisplay[index].ClearImage8GreyColorMap();
            Console.WriteLine("Image Width : {0:D}", cogImage.Width.ToString());
            Console.WriteLine("Image Height : {0:D}", cogImage.Height.ToString());
            _cogDisplayList[index].Image = cogImage;
            _cogDisplayList[index].Fit();

            if (index == 5)
            {
               //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
               //      (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], (int)Main.DefaultMotionData.MOTION_AXIS_X);

                Main.Instance().MotionManager.WaitForDone(Class.MOTION.eAxis.Axis_X);
            }
        }

        //Bitmap bmp;
        //using (var ms = new System.IO.MemoryStream(imageByte))
        //{
        //    bmp = new Bitmap(ms);
        //    bmp.Save("D:\\Test" + index.ToString() + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
        //}



        //if (index == 5)
        //{
        //    using (CogImageFile _ImageFile = new CogImageFile())
        //    {
        //        _ImageFile.Open($@"D:\JASTECH\AlignInspection\ImageLog\{_displayIndex.ToString()}.bmp", CogImageFileModeConstants.Write);
        //        _ImageFile.Append(cogDisplay[index].Image);
        //        _ImageFile.Close();
        //    }
        //    //if(_MainProcess.CaliperAlign(0, 0, 0, (CogImage24PlanarColor)cogImage, AlignResult, cogDisplay[index]))
        //    //      Logger.Instance.Log(LEVEL.INFO, CLASS.PROCESS, $"{_displayIndex} X : {AlignResult.X.ToString("F1")} Y : {AlignResult.Y.ToString("F1")}");
        //}
        //else if (index == 6)
        //{
        //    using (CogImageFile _ImageFile = new CogImageFile())
        //    {
        //        _ImageFile.Open($@"D:\JASTECH\AlignInspection\ImageLog\{_displayIndex.ToString()}.bmp", CogImageFileModeConstants.Write);
        //        _ImageFile.Append(cogDisplay[index].Image);
        //        _ImageFile.Close();
        //    }
        //    //if(_MainProcess.CaliperAlign(0, 0, 1, (CogImage24PlanarColor)cogImage, AlignResult, cogDisplay[index]))
        //    //     Logger.Instance.Log(LEVEL.INFO, CLASS.PROCESS, $"{_displayIndex} X : {AlignResult.X.ToString("F1")} Y : {AlignResult.Y.ToString("F1")}");
        //}

        //DisplayIndexIncreaseCheck();
    

       

        /// <summary>
        /// CogImage Type으로 변경
        /// </summary>
        /// <param name="imageData"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public ICogImage Convert8BitRawImageToCognexImage(byte[] imageData, int width, int height)
        {
            var rawSize = width * height;
            var buf = new SafeMalloc(rawSize);
            Marshal.Copy(imageData, 0, buf, rawSize);

            var cogRoot = new CogImage8Root();
            cogRoot.Initialize(width, height, buf, width, buf);
            var cogImage = new CogImage8Grey();
            cogImage.SetRoot(cogRoot);

            return cogImage;
        }

        private void btnGrabStop_Click(object sender, EventArgs e)
        {
            isGrabbing = false;
            Main.MilFrameGrabber.ExternalTriggerGrabStop();
            //Main.MotionCtrl.StopMove((int)Main.DefaultMotionData.MOTION_AXIS_X);
            Main.Instance().MotionManager.StopMove(Class.MOTION.eAxis.Axis_X);
        }
    }
}
