using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace COG.Controls
{
    public partial class CtrlCGMSViewer : UserControl
    {
        public CtrlCGMSNavigator CGMSNavigatorControl = new CtrlCGMSNavigator();
        public CtrlCGMSPreAlignViewer CGMSPreAlignViewerControl = new CtrlCGMSPreAlignViewer();
        private CogRecordDisplay _cogRecordDisplay = new CogRecordDisplay();

        public CtrlCGMSViewer()
        {
            InitializeComponent();
        }

        private void CtrlCGMSViewer_Load(object sender, EventArgs e)
        {
            AddControl();
            InitializeUI();
        }

        private void AddControl()
        {
            CGMSNavigatorControl = new CtrlCGMSNavigator(Main.recipe.m_nScanCount, Main.recipe.m_nTabCount);
            CGMSNavigatorControl.Dock = DockStyle.Fill;
            pnlNavigator.Controls.Add(CGMSNavigatorControl);

            //CGMSNavigatorControl.dgvNavigator.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Console.WriteLine("tlqkf : " + CGMSNavigatorControl.dgvNavigator.RowTemplate.Height.ToString());

            _cogRecordDisplay = cogDisplay;
            //CGMSPreAlignViewerControl = new CtrlCGMSPreAlignViewer();
            //CGMSPreAlignViewerControl.Dock = DockStyle.Fill;
            //pnlPreAlignViewer.Controls.Add(CGMSPreAlignViewerControl);
        }

        private void InitializeUI()
        {
            SetThumbnailDisplayMouseMode();
        }

        private void SetThumbnailDisplayMouseMode()
        {
            cogDisplayThumbnail.MouseMode = Cognex.VisionPro.Display.CogDisplayMouseModeConstants.Pointer;
            cogDisplayThumbnail.PopupMenu = false;
        }

        public void UpdateDisplay(int imageIndex, int row = 0, int col = 0, CogImage8Grey image = null)
        {
            if (_cogRecordDisplay.Image != null)
                _cogRecordDisplay.Image = null;

            Console.WriteLine((imageIndex + 1).ToString() + "번 째 이미지 선택");
            //_cogRecordDisplay.Image = image[row, col];
            //_cogRecordDisplay.Image = image[row][col];
            //_cogRecordDisplay.Image = Main.AlignUnit[0].PAT[row, col].m_CogLineScanBuf


            //CGMSDrawBoxList[displayIndex].UpdateCGMSDisplay(image);
        }

        public void UpdateResultimage(int displayIndex, CogImage8Grey image, CogGraphicInteractiveCollection resultOverlay)
        {
            //CGMSDrawBoxList[displayIndex].UpdateResult(image, resultOverlay);
        }

        public void DisplayClear(int imageIndex)
        {
            //CGMSDrawBoxList[displayIndex].ClearGraphic();
        }

        public void RedrawNavigator()
        {
            if (CGMSNavigatorControl != null)
            {
                this.pnlNavigator.Controls.Clear();
                CGMSNavigatorControl = null;
            }

            CGMSNavigatorControl = new CtrlCGMSNavigator(Main.recipe.m_nScanCount, Main.recipe.m_nTabCount);
            CGMSNavigatorControl.Dock = DockStyle.Fill;
            this.pnlNavigator.Controls.Add(CGMSNavigatorControl);
        }
        //public CogImage8Grey GetImage(int index)
        //{
        //    if (index >= CGMSDrawBoxList.Count)
        //        return null;

        //    return CGMSDrawBoxList[index].GetImage();
        //}

        #region Event functions related to the thumbnail function
        private bool _isThumbnailMove = false;
        private void cogDisplayThumbnail_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayThumbnail.GetType())
            {
                UpdateDisplayFromThumbnailEvent(sender);
                _isThumbnailMove = true;
            }
        }

        private void cogDisplayThumbnail_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cogDisplayThumbnail.GetType() && _isThumbnailMove)
                UpdateDisplayFromThumbnailEvent(sender);
        }

        private void cogDisplayThumbnail_MouseUp(object sender, MouseEventArgs e)
        {
            _isThumbnailMove = false;
        }

        private void UpdateDisplayFromThumbnailEvent(object sender)
        {
            if (_cogRecordDisplay.Image == null)
                return;

            CogRecordDisplay thumbnailDisplay = (CogRecordDisplay)sender;

            int x = MousePosition.X;
            int y = MousePosition.Y;

            Point mousePos = new Point(x, y); //프로그램 내 좌표
            Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당
            Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)

            this.Text = x.ToString() + ", " + y.ToString() +
                "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();

            double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

            double panPointX = (double)_cogRecordDisplay.Image.Width * ratio;

            if (_cogRecordDisplay.Zoom > 0 && _cogRecordDisplay.Zoom < 0.2)
                _cogRecordDisplay.Zoom = 0.5;

            panPointX = (_cogRecordDisplay.Image.Width / 2) - panPointX;
            _cogRecordDisplay.PanX = panPointX;
        }
        #endregion
    }
}
