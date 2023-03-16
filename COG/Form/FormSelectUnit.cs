using COG.Class;
using COG.Controls;
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
    public partial class FormSelectUnit : Form
    {
        public CtrlTeachPosition TeachingPositionControl = null;
        public List<CtrlTeachPosition> TeachingPositionControlList = new List<CtrlTeachPosition>();

        //private eTeachingPosition _teachingPosition;
        //private eStageNo _stageNo = eStageNo.Inspection1;
        //private eCameraNo _camNo = eCameraNo.Inspection1;

        public FormVisionTeach VisionTeachForm = null;

        public FormSelectUnit()
        {
            InitializeComponent();
        }

        private void FormSelectUnit_Load(object sender, EventArgs e)
        {
            MakeTeachingListControl();
        }

        private void MakeTeachingListControl()
        {
            tlpTeachingList.ColumnStyles.Clear();
            tlpTeachingList.RowStyles.Clear();

            tlpTeachingList.ColumnCount = 4;
            tlpTeachingList.RowCount = 1;

            for (int columnIndex = 0; columnIndex < tlpTeachingList.ColumnCount; columnIndex++)
                tlpTeachingList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tlpTeachingList.ColumnCount));

            for (int rowIndex = 0; rowIndex < tlpTeachingList.RowCount; rowIndex++)
                tlpTeachingList.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tlpTeachingList.RowCount));

            foreach (eTeachingPosition teachingPosition in Enum.GetValues(typeof(eTeachingPosition)))
            {
                switch (teachingPosition)
                {
                    //case eTeachingPosition.Standby:
                    //    TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                    //    this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition, 0);
                    //    TeachingPositionControl.Dock = DockStyle.Fill;

                    //    TeachingPositionControlList.Add(TeachingPositionControl);
                    //    TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                    //    //TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
                    //    break;

                    case eTeachingPosition.Stage1_PreAlign_Left:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition - 1, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                        break;

                    case eTeachingPosition.Stage1_PreAlign_Right:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition - 1, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                        break;

                    case eTeachingPosition.Stage1_Scan_Start:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition - 1, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                        break;

                    //case eTeachingPosition.Stage2_PreAlign_Left:
                    //    TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                    //    this.tlpTeachingList.Controls.Add(TeachingPositionControl, 6, 0);
                    //    TeachingPositionControl.Dock = DockStyle.Fill;

                    //    TeachingPositionControlList.Add(TeachingPositionControl);
                    //    TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                    //    break;

                    //case eTeachingPosition.Stage2_PreAlign_Right:
                    //    TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                    //    this.tlpTeachingList.Controls.Add(TeachingPositionControl, 7, 0);
                    //    TeachingPositionControl.Dock = DockStyle.Fill;

                    //    TeachingPositionControlList.Add(TeachingPositionControl);
                    //    TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                    //    break;

                    //case eTeachingPosition.Stage2_Scan_Start:
                    //    TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                    //    this.tlpTeachingList.Controls.Add(TeachingPositionControl, 6, 1);
                    //    TeachingPositionControl.Dock = DockStyle.Fill;

                    //    TeachingPositionControlList.Add(TeachingPositionControl);
                    //    TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                    //    break;

                    default:
                        break;
                }
            }
        }

        private void ReceiveTeachingPosition(eTeachingPosition teachingPosition)
        {
            //foreach (var teachingPositionControl in TeachingPositionControlList)
            //    teachingPositionControl.SetButtonStatus(false);

            //TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
            //_teachingPosition = teachingPosition;
            ShowVisionTeachForm(teachingPosition);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            this.Close();
            Main.MilFrameGrabber.ReceiveImage -= FormMain.Instance().Get_LineScanImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ShowVisionTeachForm(eStageNo.Stage1, eCameraNo.PreAlign);
            //ShowVisionTeachForm(eStageNo.Inspection1, eCameraNo.Inspection1);
        }

        //private void ShowVisionTeachForm(eStageNo stageNo, eCameraNo camNo)
        //{
        //    VisionTeachForm = new FormVisionTeach(stageNo, camNo);
        //    VisionTeachForm.ShowDialog();
        //}

        private void ShowVisionTeachForm(eTeachingPosition teachingPosition)
        {
            //SetTeachingUnitDevice(teachingPosition);

            VisionTeachForm = new FormVisionTeach(teachingPosition);
            VisionTeachForm.ShowDialog();
        }

        //private void SetTeachingUnitDevice(eTeachingPosition teachingPosition)
        //{
        //    switch (teachingPosition)
        //    {
        //        case eTeachingPosition.Standby:
        //            _stageNo = eStageNo.Stage1;
        //            _camNo = eCameraNo.PreAlign;
        //            break;

        //        case eTeachingPosition.Stage1_PreAlign_Left:
        //            _stageNo = eStageNo.Stage1;
        //            _camNo = eCameraNo.PreAlign;
        //            break;

        //        case eTeachingPosition.Stage1_PreAlign_Right:
        //            _stageNo = eStageNo.Stage1;
        //            _camNo = eCameraNo.PreAlign;
        //            break;

        //        case eTeachingPosition.Stage1_Scan_Start:
        //            _stageNo = eStageNo.Inspection1;
        //            _camNo = eCameraNo.Inspection1;
        //            break;

        //        default:
        //            break;
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            //ShowVisionTeachForm(eStageNo.Inspection1, eCameraNo.Inspection1);
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            OpenRecipeForm();
        }

        private void OpenRecipeForm()
        {
            try
            {
                string modelName = FormMain.Instance().lblProjectInformation.Text.ToString().Substring(0, 3);
                int modelNo = Convert.ToInt32(String.Format("{0:000}", modelName));

                FormRecipe formRecipe = new FormRecipe(modelNo);
                formRecipe.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No selected recipe.");
                Console.WriteLine(ex.ToString());
                return;
            }
        }

        
    }
}
