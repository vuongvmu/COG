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
using static COG.Class.InspectionResult;
using Cognex.VisionPro;

namespace COG.Controls
{
    public partial class CtrlPreAlignViewer : UserControl
    {
        public CtrlLiveViewDrawBox LeftDrawBox = null;
        public CtrlLiveViewDrawBox RightDrawBox = null;

        public CtrlPreAlignViewer()
        {
            InitializeComponent();
        }

        private delegate void UpdatePreAlignDisplayDelegate(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint);
        public void UpdatePreAlignDisplay(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdatePreAlignDisplayDelegate callback = UpdatePreAlignDisplay;
                    BeginInvoke(callback, nMode, nPosition, cogObject);
                    return;
                }

                UpdateDisplay(nMode, nPosition, cogObject, ViewPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateDisplay(int nMode, int nPosition, object cogObject, OpenCvSharp.Point2d ViewPoint)
        {
            // TODO : 영상 뿌리는거 구현
            if (nMode == Main.DEFINE.DISPLAY_VIEW)
            {
                //Image View
                if (nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {
                    cogDisplayPreAlignViewerLeft.Image = (CogImage8Grey)cogObject;
                    cogDisplayPreAlignViewerLeft.AutoFit = false;
                    cogDisplayPreAlignViewerLeft.Zoom = 0.2;

                    if (ViewPoint.X > 0)
                    {
                        CogImage8Grey tmpImage = new CogImage8Grey();
                        tmpImage = (CogImage8Grey)cogObject;
                        cogDisplayPreAlignViewerLeft.PanX = ((tmpImage.Width - ViewPoint.X) / 2) - 1500;
                        cogDisplayPreAlignViewerLeft.PanY = ((tmpImage.Height - ViewPoint.Y) / 2) - 300;
                    }
                    else
                    {
                        cogDisplayPreAlignViewerLeft.PanX = ViewPoint.X;
                        cogDisplayPreAlignViewerLeft.PanY = ViewPoint.Y;
                    }
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayPreAlignViewerRight.Image = (CogImage8Grey)cogObject;
                    cogDisplayPreAlignViewerRight.AutoFit = false;
                    cogDisplayPreAlignViewerRight.Zoom = 0.2;

                    if (ViewPoint.X > 0)
                    {
                        CogImage8Grey tmpImage = new CogImage8Grey();
                        tmpImage = (CogImage8Grey)cogObject;
                        cogDisplayPreAlignViewerRight.PanX = -60000;
                        cogDisplayPreAlignViewerRight.PanY = ((tmpImage.Height - ViewPoint.Y) / 2) - 300;
                    }
                    else
                    {
                        cogDisplayPreAlignViewerRight.PanX = ViewPoint.X;
                        cogDisplayPreAlignViewerRight.PanY = ViewPoint.Y;
                    }
                }
            }
            else if (nMode == Main.DEFINE.DISPLAY_STATIC)
            {
                //Overlay
                if (nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {
                    cogDisplayPreAlignViewerLeft.StaticGraphics.Add(cogObject as ICogGraphic, "DrawObj");
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayPreAlignViewerRight.StaticGraphics.Add(cogObject as ICogGraphic, "DrawObj");
                }
            }
            else if (nMode == Main.DEFINE.DISPLAY_INTERACTIVE)
            {
                //Overlay
                if (nPosition == Main.DEFINE.DISPLAY_ALIGN_LEFT)
                {
                    cogDisplayPreAlignViewerLeft.InteractiveGraphics.AddList((CogGraphicInteractiveCollection)cogObject, "RESULT", false);
                }
                else if (nPosition == Main.DEFINE.DISPLAY_ALIGN_RIGHT)
                {
                    cogDisplayPreAlignViewerRight.InteractiveGraphics.AddList((CogGraphicInteractiveCollection)cogObject, "RESULT", false);
                }
            }
        }

        private delegate void UpdatePreAlignHistoryDelegate(List<PreAlignInspectionResult> preAlignHistory, bool isUpdate);
        public void UpdatePreAlignHistory(List<PreAlignInspectionResult> preAlignHistory, bool isUpdate)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdatePreAlignHistoryDelegate callback = UpdatePreAlignHistory;
                    BeginInvoke(callback, preAlignHistory, isUpdate);
                    return;
                }

                dgvPreAlignResult.Rows.Clear();

                if (isUpdate)
                {
                    foreach (PreAlignInspectionResult item in preAlignHistory)
                    {
                        string inspectionTime = item.InspectionTime;
                        string panelID = item.PanelID;
                        int stageNumber = item.StageNumber;
                        double x = item.X;
                        double y = item.Y;
                        double t = item.T;

                        string[] row = { inspectionTime, panelID, stageNumber.ToString(), x.ToString("F3"), y.ToString("F3"), t.ToString("F3") };

                        dgvPreAlignResult.Rows.Add(row);
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private delegate void ActiveDataGridViewDelegate(bool isActive);
        public void ActiveDataGridView(bool isActive)
        {
            if (this.InvokeRequired)
            {
                ActiveDataGridViewDelegate callback = ActiveDataGridView;
                BeginInvoke(callback, isActive);
                return;
            }

            dgvPreAlignResult.Enabled = isActive;
        }
    }
}
