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
using System.Reflection;
using COG.Class.MOTION;

namespace COG.Controls
{
    public partial class CtrlTeaching : UserControl
    {
        public CtrlTeachingData TeachingDataControl = null;
        public List<CtrlTeachingData> TeachingDataControlList = new List<CtrlTeachingData>();

        private eTeachingPosition _teachingPosition = eTeachingPosition.Standby;

        public CtrlTeaching(eTeachingPosition teachingPosition)
        {
            InitializeComponent();

            InitializeUI(teachingPosition);

            MakeTeachingDataControl();
        }

        private void InitializeUI(eTeachingPosition teachingPosition)
        {
            _teachingPosition = teachingPosition;

            switch (teachingPosition)
            {
                case eTeachingPosition.Standby:
                    grpTeaching.Text = eTeachingPosition.Standby.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage1_PreAlign_Left:
                    grpTeaching.Text = eTeachingPosition.Stage1_PreAlign_Left.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage1_PreAlign_Right:
                    grpTeaching.Text = eTeachingPosition.Stage1_PreAlign_Right.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage1_Scan_Start:
                    grpTeaching.Text = eTeachingPosition.Stage1_Scan_Start.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage2_PreAlign_Left:
                    grpTeaching.Text = eTeachingPosition.Stage2_PreAlign_Left.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage2_PreAlign_Right:
                    grpTeaching.Text = eTeachingPosition.Stage2_PreAlign_Right.ToString().Replace("_", " ");
                    break;

                case eTeachingPosition.Stage2_Scan_Start:
                    grpTeaching.Text = eTeachingPosition.Stage2_Scan_Start.ToString().Replace("_", " ");
                    break;

                default:
                    break;
            }
        }

        private void MakeTeachingDataControl()
        {
            try
            {
                int controlHeight = this.pnlTeachingData.Height / (Enum.GetValues(typeof(eAxis)).Length - 1);
                Point point = new Point(0, 0);

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    TeachingDataControl = new CtrlTeachingData(_teachingPosition, axis);
                    TeachingDataControl.Size = new Size(this.pnlTeachingData.Width, controlHeight);
                    TeachingDataControl.Location = point;
                    this.pnlTeachingData.Controls.Add(TeachingDataControl);
                    point.Y += controlHeight;

                    TeachingDataControlList.Add(TeachingDataControl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void SetDisplayTeachingParameter()
        {

        }
    }
}
