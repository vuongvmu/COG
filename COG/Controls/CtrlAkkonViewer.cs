using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using COG.Class;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using static COG.Controls.CtrlGraph_Line;

namespace COG.Controls
{
    public partial class CtrlAkkonViewer : UserControl
    {
        public CtrlAkkonResult AkkonHistoryControl = null;
        public CtrlGraph_Line GraphControl = null;
        private bool _buttonSeledted = false;
        private int _tabNumber = -1;
        private bool Thumbnail_MoveFlag = false;
        public List<CtrlTabButton> listTabButton = new List<CtrlTabButton>();
        public CtrlAkkonViewer()
        {
            InitializeComponent();
        }

        private void CtrlAkkonViewer_Load(object sender, EventArgs e)
        {
            AddControls();
        }

        private void AddControls()
        {
            AkkonHistoryControl = new CtrlAkkonResult();
            AkkonHistoryControl.Dock = DockStyle.Fill;
            this.pnlAkkonResult.Controls.Add(AkkonHistoryControl);

            GraphControl = new CtrlGraph_Line();
            GraphControl.Dock = DockStyle.Fill;
            GraphControl.Initialize(eChartContents.Akkon);
            this.pnlAkkonGraph.Controls.Add(GraphControl);
        }

        public void MakeDisplay(int tabCount)
        {
            try
            {
                int controlWidth = this.pnlTabButton.Width / tabCount;
                Point point = new Point(0, 0);

                for (int i = 0; i < tabCount; i++)
                {
                    CtrlTabButton buttonControl = new CtrlTabButton(i);
                    buttonControl.SendEventHandler += new CtrlTabButton.SetTabNumberDelegate(ReceiveTabNumber);
                    buttonControl.Size = new Size(controlWidth, this.pnlTabButton.Height);
                    buttonControl.Location = point;
                    this.pnlTabButton.Controls.Add(buttonControl);
                    point.X += controlWidth;
                    listTabButton.Add(buttonControl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void ReceiveTabNumber(bool selected, int tabNumber)
        {
            _buttonSeledted = selected;
            _tabNumber = tabNumber;

            cogDisplayAkkonViewer.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
            //cogDisplayAkkonScale.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay;

            cogDisplayAkkonScale.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
            string fileName = string.Format("D:\\Image{0}.bmp", tabNumber);
               
          
            CogImageFileBMP imagecontrol = new CogImageFileBMP();
            try
            {
                imagecontrol.Open(fileName, CogImageFileModeConstants.Write);
                imagecontrol.Append(cogDisplayAkkonViewer.Image);
                imagecontrol.Close();
            }
            catch
            {

            }
            if ( _buttonSeledted) //Result Image
            {       
                if(Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay == null)
                    Main.ATT_GetResultImageView(0, 0, _tabNumber);

                cogDisplayAkkonViewer.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
                //cogDisplayAkkonScale.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay;
                cogDisplayAkkonScale.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
                Main.DisplayRefresh(cogDisplayAkkonViewer);
                //Main.DisplayRefresh(cogDisplayAkkonScale);
                //압흔검사 NG 일 경우 썸네일에 표시해주는 기능 YSH
                //DrawThumbnailNgLine(_tabNumber);
                //Console.WriteLine("m_imgOverlay : {0:D},{1:D}", Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay.Width, Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay.Height);
            }

            if (!_buttonSeledted) //Original Image
            {
                if(Main.AlignUnit[0].PAT[0, _tabNumber].m_CogResizeImage != null)
                {
                    cogDisplayAkkonViewer.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogResizeImage;
                    cogDisplayAkkonScale.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogResizeImage;
                    Console.WriteLine("m_CogResizeImage : {0:D},{1:D}", Main.AlignUnit[0].PAT[0, _tabNumber].m_CogResizeImage.Width, Main.AlignUnit[0].PAT[0, _tabNumber].m_CogResizeImage.Height);

                    Main.DisplayRefresh(cogDisplayAkkonViewer);
                    Main.DisplayRefresh(cogDisplayAkkonScale);
                    cogDisplayAkkonScale.Fit(true);
                }
            }
        }

        /// <summary>
        /// C# DLL단 내부에서 원하는 위치에 해당하는 리드정보에 대한 변수가 없어 주석처리
        /// DLL내부 수정작업 필요
        /// </summary>
        /// <param name="TabNo"></param>
        private void DrawThumbnailNgLine(int TabNo)
        {
            if (Main.AlignUnit[0].PAT[0, TabNo].AkkonResult.AkkonResultArray.Length == 0)
                return;

            cogDisplayAkkonScale.StaticGraphics.Clear();
            cogDisplayAkkonScale.InteractiveGraphics.Clear();
            int Count = 0;
            for (int i = 1; i < Main.AlignUnit[0].PAT[0, TabNo].AkkonResult.AkkonResultArray[0].Length; ++i)
            {
                if(Main.AlignUnit[0].PAT[0, TabNo].AkkonResult.AkkonResultArray[0][i].s_bJudgement == false)
                {
                    double ratio = cogDisplayAkkonScale.ClientSize.Width / Main.AlignUnit[0].PAT[0, _tabNumber].m_imgOverlay.Width;
                    int pointX = 0;//Main.AlignUnit[0].PAT[0, TabNo].AkkonResult[0].m_AkkonResult[0][i]. //NG났던 lead의 위치좌표
                    int drawPointX = (int)(pointX * ratio);
                    Cognex.VisionPro.Dimensioning.CogCreateLineTool CogNgLine = new Cognex.VisionPro.Dimensioning.CogCreateLineTool();
                    CogLine DrawNGLine = new CogLine();
                    DrawNGLine.Interactive = false;
                    DrawNGLine.Color = CogColorConstants.Red;
                    DrawNGLine.DragLineStyle = CogGraphicLineStyleConstants.Solid;
                    DrawNGLine.LineWidthInScreenPixels = 5;
                    DrawNGLine.Rotation = 1.57;
                    DrawNGLine.X = drawPointX;
                    DrawNGLine.Y = 0;
                    cogDisplayAkkonScale.InteractiveGraphics.Add(DrawNGLine, "NGLine", false);
                    Count++;
                }
                if (Count == 50)
                    break;
            }   
        }

        private delegate void UpdateAkkonDisplayDelegate(bool bMode, object cogObject);
        public void UpdateAkkonDisplay(bool bMode, object cogObject)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAkkonDisplayDelegate callback = UpdateAkkonDisplay;
                    BeginInvoke(callback, bMode, cogObject);
                    return;
                }

                UpdateDisplay(bMode, cogObject);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateDisplay(bool bMode, object cogObject)
        {
            // TODO : 영상 뿌리는거 구현
            //if (bMode)
            //{
                //GreyImage
                cogDisplayAkkonViewer.Image = (CogImage8Grey)cogObject;
                cogDisplayAkkonScale.Image = (CogImage8Grey)cogObject;
                cogDisplayAkkonScale.Fit(false);
                Main.DisplayRefresh(cogDisplayAkkonViewer);
                //Main.DisplayRefresh(cogDisplayAkkonScale);
            //}
            //else
            //{
            //    //Color Image
            //    cogDisplayAkkonViewer.Image = (CogImage24PlanarColor)cogObject;
            //    cogDisplayAkkonScale.Image = (CogImage24PlanarColor)cogObject;
            //    cogDisplayAkkonScale.Fit(true);
            //    Main.DisplayRefresh(cogDisplayAkkonViewer);
            //    //Main.DisplayRefresh(cogDisplayAkkonScale);
            //}
        }

        public void UpdateGridView(List<InspectionResult.AkkonInspectionResult> akkonInspectionResultList)
        {
            AkkonHistoryControl.UpdateAkkonInspectionHistory(akkonInspectionResultList, true);
        }

        private void cogDisplayAkkonScale_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayAkkonScale.GetType())
            {
                Cognex.VisionPro.CogRecordDisplay thumbnailDisplay = (Cognex.VisionPro.CogRecordDisplay)sender;
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;
                System.Drawing.Point mousePos = new System.Drawing.Point(x, y); //프로그램 내 좌표

                System.Drawing.Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당

                System.Drawing.Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)


                this.Text = x.ToString() + ", " + y.ToString() +

                    "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();


                double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

                double panPointX = (double)cogDisplayAkkonViewer.Image.Width * ratio;
                if (cogDisplayAkkonViewer.Zoom > 0 && cogDisplayAkkonViewer.Zoom < 0.2)
                {
                    cogDisplayAkkonViewer.Zoom = 0.5;
                }
                panPointX = (cogDisplayAkkonViewer.Image.Width / 2) - panPointX;
                cogDisplayAkkonViewer.PanX = panPointX;


                Thumbnail_MoveFlag = true;
            }
        }

        private void cogDisplayAkkonScale_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayAkkonScale.GetType() && Thumbnail_MoveFlag)
            {
                Cognex.VisionPro.CogRecordDisplay thumbnailDisplay = (Cognex.VisionPro.CogRecordDisplay)sender;
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;
                System.Drawing.Point mousePos = new System.Drawing.Point(x, y); //프로그램 내 좌표

                System.Drawing.Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당

                System.Drawing.Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)


                this.Text = x.ToString() + ", " + y.ToString() +

                    "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();


                double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

                double panPointX = (double)cogDisplayAkkonViewer.Image.Width * ratio;
                if (cogDisplayAkkonViewer.Zoom > 0 && cogDisplayAkkonViewer.Zoom < 0.2)
                {
                    cogDisplayAkkonViewer.Zoom = 0.5;
                }
                panPointX = (cogDisplayAkkonViewer.Image.Width / 2) - panPointX;
                cogDisplayAkkonViewer.PanX = panPointX;
            }
        }

        private void cogDisplayAkkonScale_MouseUp(object sender, MouseEventArgs e)
        {
            Thumbnail_MoveFlag = false;
        }

        private delegate void UpdateAkkonDrawChartDelegate(List<InspectionResult.AkkonInspectionResult> akkonResultList);
        public void UpdateAkkonChart(List<InspectionResult.AkkonInspectionResult> akkonResultList)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAkkonDrawChartDelegate callback = UpdateAkkonChart;
                    BeginInvoke(callback, akkonResultList);
                    return;
                }

                UpdateChart(akkonResultList);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        public void UpdateChart(List<InspectionResult.AkkonInspectionResult> akkonInspectionResultList)
        {
            GraphControl.DrawChart(eChartContents.Akkon, akkonInspectionResultList.Cast<object>().ToList());
        }
    }
}
