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
using COG.Class.MOTION;

namespace COG.Controls
{
    public partial class CtrlMotionOperation : UserControl
    {
        private CtrlMotionFunction _motionFunctionControl = null;
        private List<CtrlMotionFunction> _motionFunctionControlList = new List<CtrlMotionFunction>();

        private System.Threading.Timer _motionOperationTimer = null;

        public CtrlMotionOperation()
        {
            InitializeComponent();
        }

        private void CtrlMotionOperation_Load(object sender, EventArgs e)
        {
            AddConrol();
            StartTimer();
        }

        private void AddConrol()
        {
            //MakeMotionFunctionControl();
        }

        public void MakeMotionFunctionControl()
        {
            try
            {
                int controlWidth = this.pnlMotionOperation.Width / (Enum.GetValues(typeof(eAxis)).Length - 1);
                Point point = new Point(0, 0);

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    _motionFunctionControl = new CtrlMotionFunction(axis);
                    _motionFunctionControl.Size = new Size(controlWidth, this.pnlCaption.Height);
                    _motionFunctionControl.Location = point;
                    this.pnlMotionOperation.Controls.Add(_motionFunctionControl);
                    point.X += controlWidth;

                    _motionFunctionControlList.Add(_motionFunctionControl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void StartTimer()
        {
            _motionOperationTimer = new System.Threading.Timer(UpdateMotionStatus, null, 1000, 1000);
        }

        private void UpdateMotionStatus(object obj)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            try
            {
                if (this._motionFunctionControl != null)
                    _motionFunctionControl.UpdateStatus();
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }
    }
}
