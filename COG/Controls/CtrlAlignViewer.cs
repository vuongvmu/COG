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
using static COG.Controls.CtrlGraph_Line;

namespace COG.Controls
{
    public partial class CtrlAlignViewer : UserControl
    {
        public CtrlAlignResult AlignResultControl = null;
        public CtrlGraph_Line GraphControl = null;
        private bool _buttonSeledted = false;
        private int _tabNumber = -1;

        public CtrlAlignViewer()
        {
            InitializeComponent();
        }

        private void CtrlAlignViewer_Load(object sender, EventArgs e)
        {
            AddControls();
        }

        private void AddControls()
        {
            AlignResultControl = new CtrlAlignResult();
            AlignResultControl.Dock = DockStyle.Fill;
            this.pnlAlignResult.Controls.Add(AlignResultControl);

            GraphControl = new CtrlGraph_Line();
            GraphControl.Initialize(eChartContents.Align);
            GraphControl.Dock = DockStyle.Fill;
            this.pnlAlignGraph.Controls.Add(GraphControl);
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
                }

                //AddDisplayControl();
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

            if (Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf != null)
            {
                cogDisplayAlignViewerLeft.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
                cogDisplayAlignViewerLeft.AutoFit = false;
                cogDisplayAlignViewerLeft.Zoom = 0.2;
                cogDisplayAlignViewerLeft.PanX = 60000;
                cogDisplayAlignViewerLeft.PanY = 500;

                cogDisplayAlignViewerRight.Image = Main.AlignUnit[0].PAT[0, _tabNumber].m_CogLineScanBuf;
                cogDisplayAlignViewerRight.AutoFit = false;
                cogDisplayAlignViewerRight.Zoom = 0.2;
                cogDisplayAlignViewerRight.PanX = -60000;
                cogDisplayAlignViewerRight.PanY = 500;
            }
        }

        private delegate void UpdateAlignDisplayDelegate(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint);
        public void UpdateAlignDisplay(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAlignDisplayDelegate callback = UpdateAlignDisplay;
                    BeginInvoke(callback, nMode, nPosition, cogObject);
                    return;
                }

                UpdateDisplay(nMode, nPosition, cogObject, ViewPoint);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateDisplay(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint)
        {
            // TODO : 영상 뿌리는거 구현
            if(nMode == Main.DEFINE.DISPLAY_VIEW)
            {
                //Image View
                if(nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {                    
                    cogDisplayAlignViewerLeft.Image = (CogImage8Grey)cogObject;
                    cogDisplayAlignViewerLeft.AutoFit = false;
                    cogDisplayAlignViewerLeft.Zoom = 0.2;
                    if (ViewPoint.X > 0)
                    {
                        CogImage8Grey tmpImage = new CogImage8Grey();
                        tmpImage = (CogImage8Grey)cogObject;
                        cogDisplayAlignViewerLeft.PanX = ((tmpImage.Width - ViewPoint.X) / 2) - 1500;
                        cogDisplayAlignViewerLeft.PanY = ((tmpImage.Height - ViewPoint.Y) / 2) - 300;
                    }
                    else
                    {
                        cogDisplayAlignViewerLeft.PanX = ViewPoint.X;
                        cogDisplayAlignViewerLeft.PanY = ViewPoint.Y;
                    }     
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayAlignViewerRight.Image = (CogImage8Grey)cogObject;
                    cogDisplayAlignViewerRight.AutoFit = false;
                    cogDisplayAlignViewerRight.Zoom = 0.2;
                    if (ViewPoint.X > 0)
                    {
                        CogImage8Grey tmpImage = new CogImage8Grey();
                        tmpImage = (CogImage8Grey)cogObject;
                        cogDisplayAlignViewerRight.PanX = -60000;
                        cogDisplayAlignViewerRight.PanY = ((tmpImage.Height - ViewPoint.Y) / 2) - 300;
                    }
                    else
                    {
                        cogDisplayAlignViewerRight.PanX = ViewPoint.X;
                        cogDisplayAlignViewerRight.PanY = ViewPoint.Y;
                    }
                }     
            }
            else if(nMode == Main.DEFINE.DISPLAY_STATIC)
            {
                //Overlay
                if (nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {
                    cogDisplayAlignViewerLeft.StaticGraphics.Add(cogObject as ICogGraphic, "DrawObj");
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayAlignViewerRight.StaticGraphics.Add(cogObject as ICogGraphic, "DrawObj");
                }                
            }
            else if(nMode == Main.DEFINE.DISPLAY_INTERACTIVE)
            {
                //Overlay
                if (nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {
                    cogDisplayAlignViewerLeft.InteractiveGraphics.AddList((CogGraphicInteractiveCollection)cogObject, "RESULT", false);
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayAlignViewerRight.InteractiveGraphics.AddList((CogGraphicInteractiveCollection)cogObject, "RESULT", false);
                }
            }
        }

        private void DrawOverlay(CogFitLine tt)
        {
            cogDisplayAlignViewerLeft.StaticGraphics.Add(tt as ICogGraphic, "CenterLine");
        }

        public void UpdateGridView(List<InspectionResult.AlignInspectionResult> alignInspectionResultList)
        {
            AlignResultControl.UpdateAlignInspectionHistory(alignInspectionResultList, true);
        }

        private delegate void UpdateAlignDrawChartDelegate(List<InspectionResult.AlignInspectionResult> alignInspectionResultList);
        public void UpdateAlignChart(List<InspectionResult.AlignInspectionResult> alignInspectionResultList)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAlignDrawChartDelegate callback = UpdateAlignChart;
                    BeginInvoke(callback, alignInspectionResultList);
                    return;
                }

                UpdateChart(alignInspectionResultList);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
        public void UpdateChart(List<InspectionResult.AlignInspectionResult> alignInspectionResultList)
        {
            GraphControl.DrawChart(eChartContents.Align, alignInspectionResultList.Cast<object>().ToList());
        }
    }
}
