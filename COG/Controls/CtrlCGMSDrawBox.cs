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
using Cognex.VisionPro;

namespace COG.Controls
{
    public partial class CtrlCGMSDrawBox : UserControl
    {
        private CogImage8Grey _image = new CogImage8Grey();
        private CogGraphicInteractiveCollection ovlay = new CogGraphicInteractiveCollection();
        private FormCGMSEnlargedImagePopup _formCGMSEnlargedImagePopup = null;

        private int _displayNumber = 0;

        public CtrlCGMSDrawBox(int displayNo)
        {
            InitializeComponent();

            _displayNumber = displayNo;
        }

        private void CtrlCGMSDrawBox_Load(object sender, EventArgs e)
        {
            IntializeUI();
        }

        private void IntializeUI()
        {
            btnSceneNumber.Text = "DISPLAY " + (_displayNumber + 1).ToString("D2");
        }

        // 촬영 여상 업데이트
        private delegate void UpdateCGMSDisplayDelegate(object cogObject);
        public void UpdateCGMSDisplay(object cogObject)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCGMSDisplayDelegate callback = UpdateCGMSDisplay;
                    BeginInvoke(callback, cogObject);
                    return;
                }

                UpdateDisplay(cogObject);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateDisplay(object cogObject)
        {
            cogDisplay.Image = (CogImage8Grey)cogObject;

            _image = (CogImage8Grey)cogObject;
            cogDisplay.Fit();
            Main.DisplayRefresh(cogDisplay);
        }

        // 결과 그래픽 뿌리기
        private delegate void UpdateResultDelegate(CogImage8Grey cogImage, CogGraphicInteractiveCollection cogGraphic);
        public void UpdateResult(CogImage8Grey cogImage, CogGraphicInteractiveCollection cogGraphic)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateResultDelegate callback = UpdateResult;
                    BeginInvoke(callback, cogImage, cogGraphic);
                    return;
                }

                UpdateResultOnDisplay(cogImage, cogGraphic);

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void UpdateResultOnDisplay(CogImage8Grey cogImage, CogGraphicInteractiveCollection cogObject)
        {
            cogDisplay.Image = cogImage;
            ovlay = cogObject;
            cogDisplay.InteractiveGraphics.AddList(cogObject, "Result", false);
        }

        // 결과 그래픽 클리어
        private delegate void ClearGraphicDelegate();
        public void ClearGraphic()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    ClearGraphicDelegate callback = ClearGraphic;
                    BeginInvoke(callback);
                    return;
                }

                ClearGraphics();

            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void ClearGraphics()
        {
            cogDisplay.InteractiveGraphics.Clear();
        }

        public CogImage8Grey GetImage()
        {
            return _image;
        }
        public CogGraphicInteractiveCollection GetOverlay()
        {
            return ovlay;
        }
        private void btnSceneNumber_Click(object sender, EventArgs e)
        {
            OpenFormCGMSEnlargedImagePopup(GetImage(), GetOverlay());
        }

        public void OpenFormCGMSEnlargedImagePopup(CogImage8Grey image, CogGraphicInteractiveCollection Result)
        {
            if (_formCGMSEnlargedImagePopup == null)
            {
                _formCGMSEnlargedImagePopup = new FormCGMSEnlargedImagePopup(image, Result);
                _formCGMSEnlargedImagePopup.CloseEventDelegate = () => this._formCGMSEnlargedImagePopup = null;
                _formCGMSEnlargedImagePopup.ShowDialog();
            }
        }
    }
}
