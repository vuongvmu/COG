using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormInspectionSimulationForEngineer : Form
    {
        // Cognex Recored Display
        public static Cognex.VisionPro.CogRecordDisplay PT_Display01 = new Cognex.VisionPro.CogRecordDisplay();

        public FormInspectionSimulationForEngineer()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void LoadImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ReadOnlyChecked = true;
            ofd.Filter = "Bmp File | *.bmp";
            ofd.ShowDialog();

            if (ofd.FileName != "")
            {
                // Image loading using Cognex ImageFileTool
                Cognex.VisionPro.ImageFile.CogImageFileTool imageFileTool = new Cognex.VisionPro.ImageFile.CogImageFileTool();
                imageFileTool.Operator.Open(ofd.FileName, Cognex.VisionPro.ImageFile.CogImageFileModeConstants.Read);
                imageFileTool.Run();

                PT_Display01.Image = imageFileTool.OutputImage;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearGraphic()
        {
            PT_Display01.StaticGraphics.Clear();
            PT_Display01.InteractiveGraphics.Clear();
        }

        private void btnShowROI_MarkRegister_Click(object sender, EventArgs e)
        {
            if (PT_Display01.Image == null)
                return;

            ClearGraphic();

            using (Cognex.VisionPro.CogRectangle cogRect = new Cognex.VisionPro.CogRectangle())
            {
                cogRect.Interactive = true;
                cogRect.GraphicDOFEnable = Cognex.VisionPro.CogRectangleDOFConstants.All;

                cogRect.SetCenterWidthHeight(PT_Display01.Image.Width / 2 - PT_Display01.PanX, PT_Display01.Image.Height / 2 - PT_Display01.PanY, 200, 200);
            }
        }
    }
}