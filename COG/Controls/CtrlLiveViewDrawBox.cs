using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro.Display;
using Cognex.VisionPro;
using static COG.ClsImage;
using System.Runtime.InteropServices;
using JAS.Controls.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ImageProcessing;
using System.Threading;
using System.Reflection;

namespace COG.Controls
{
    public partial class CtrlLiveViewDrawBox : UserControl
    {
        public CogDisplay CogDisplay = null;
        private CogRectangle _cogRect = null;
        private CogHistogramTool _cogHistogramTool = new CogHistogramTool();

        private CogRectangle _prevCogRectangle = new CogRectangle();
        private double _prevX, _prevY, _prevWidth, _prevHeight = 0.0;

        public CtrlLiveViewDrawBox()
        {
            InitializeComponent();
        }

        private void CtrlLiveViewDrawBox_Load(object sender, EventArgs e)
        {
            AddControl();

            RegisterReceiveImageEvent();
        }

        private void AddControl()
        {
            CogDisplay = new CogDisplay();
            CogDisplay = cogLiveViewDisplay;

            _cogRect = new CogRectangle();
            _cogRect.Interactive = true;
            _cogRect.GraphicDOFEnable = CogRectangleDOFConstants.All;
            _cogRect.SetCenterWidthHeight(cogLiveViewDisplay.Width / 2 - cogLiveViewDisplay.PanX, cogLiveViewDisplay.Height / 2 - cogLiveViewDisplay.PanY, 50, 50);

            //_tempRectangle = new CogRectangle();
        }

        private void RegisterReceiveImageEvent()
        {
            //Main.MilFrameGrabber.ReceiveImage2 += MatroxGrabber_ReceiveImage;
            //Main.MilFrameGrabber.ReceiveImage += MatroxGrabber_ReceiveImage;
        }

        private void ReleaseReceiveImageEvent()
        {
            //Main.MilFrameGrabber.ReceiveImage2 -= MatroxGrabber_ReceiveImage;
            //Main.MilFrameGrabber.ReceiveImage -= MatroxGrabber_ReceiveImage;
        }

        private void MatroxGrabber_ReceiveImage(int index)
        {
            byte[] imageByte = Main.MilFrameGrabber.GetImageBytes(index);
            if (imageByte == null)
                return;

            Console.WriteLine("Image Byte Lenth : {0:D}", imageByte.Length.ToString());
            var cogImage = Convert8BitRawImageToCognexImage(imageByte, Main.MilFrameGrabber.ImageWidthDefault, Main.MilFrameGrabber.ImageHeightDefault);
            Console.WriteLine("Image Width : {0:D}", cogImage.Width.ToString());
            Console.WriteLine("Image Height : {0:D}", cogImage.Height.ToString());
            CogDisplay.Image = cogImage;
            CogDisplay.Fit();

            // PJH_Temp
            //if (index == 5)
            //{
            //    Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
            //         (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], (int)Main.DefaultMotionData.MOTION_AXIS_X);

            //}
            // PJH_Temp
        }

        private void GigE_ReceiveImage()
        {

        }

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

        public void ClearDisplay()
        {
            if (CogDisplay != null)
                CogDisplay = null;
        }

        private Thread _onDisplayThread = null;
        private bool _isDisplayStop = false;
        public void ThreadRun(bool isRun)
        {
            _isDisplayStop = false;
            _onDisplayThread = new Thread(new ParameterizedThreadStart(this.OnDisplayThread));
            _onDisplayThread.Start(isRun);
        }

        private void OnDisplayThread(object obj)
        {
            while (!_isDisplayStop)
            {
                if (Convert.ToBoolean(obj))
                    HistogramOnDisplay();
                else
                    _isDisplayStop = true;

                Thread.Sleep(100);
            }
        }

        private void HistogramOnDisplay()
        {
            try
            {
                if (cogLiveViewDisplay.Image == null)
                    return;

                _cogHistogramTool.InputImage = cogLiveViewDisplay.Image;
                _cogHistogramTool.Region = _cogRect;

                _cogHistogramTool.Run();
                _cogHistogramTool.CurrentRecordEnable = CogHistogramCurrentRecordConstants.InputImage | CogHistogramCurrentRecordConstants.Region | CogHistogramCurrentRecordConstants.InputImageMask;

                Display.SetGraphics(cogLiveViewDisplay, _cogHistogramTool.CreateCurrentRecord());
                DrawMessage(cogLiveViewDisplay, _cogRect, _cogHistogramTool.Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void DrawMessage(CogDisplay cogDisplay, CogRectangle cogRectangle, CogHistogramResult cogHistogramResult)
        {
            try
            {
                if (cogHistogramResult == null)
                    return;

                if (_prevX != cogRectangle.X || _prevY != cogRectangle.Y || _prevWidth != cogRectangle.Width || _prevHeight != cogRectangle.Height)
                {
                    ClearHistogram();

                    double dev = cogHistogramResult.StandardDeviation;

                    CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();

                    float fontSize = (float)((cogDisplay.Height / Main.DEFINE.FontSize)/* * cogDisplay.Zoom*/);

                    cogGraphicLabel.Font = new Font(Main.DEFINE.FontStyle, fontSize, FontStyle.Bold);
                    cogGraphicLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
                    cogGraphicLabel.GraphicDOFEnable = CogGraphicLabelDOFConstants.All;
                    cogGraphicLabel.Color = CogColorConstants.Cyan;
                    cogGraphicLabel.SetXYText(cogRectangle.X + cogRectangle.Width + 10, cogRectangle.Y + cogRectangle.Height + 10, dev.ToString("F3"));
                    cogGraphicLabel.Text = cogHistogramResult.StandardDeviation.ToString("F3");

                    cogDisplay.StaticGraphics.Add(cogGraphicLabel, cogGraphicLabel.Text);

                    _prevX = cogRectangle.X;
                    _prevY = cogRectangle.Y;
                    _prevWidth = cogRectangle.Width;
                    _prevHeight = cogRectangle.Height;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        public void ClearHistogram()
        {
            cogLiveViewDisplay.StaticGraphics.Clear();
            cogLiveViewDisplay.InteractiveGraphics.Clear();
        }

        public void OpenImageFile(string fileName)
        {
            CogImageFileTool cogImageFileTool = new CogImageFileTool();
            cogImageFileTool.Operator.Open(fileName, CogImageFileModeConstants.Read);
            cogImageFileTool.Run();
            cogLiveViewDisplay.Image = cogImageFileTool.OutputImage;
        }

        public bool IsOpenedImage()
        {
            if (cogLiveViewDisplay.Image != null)
                return true;

            return false;
        }

        public void ClearDrawBox()
        {
            if (cogLiveViewDisplay.Image != null)
                cogLiveViewDisplay.Image = null;
        }
    }
}
