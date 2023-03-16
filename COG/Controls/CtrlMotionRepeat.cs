using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COG.Class.MOTION;
using System.Reflection;

namespace COG.Controls
{
    public partial class CtrlMotionRepeat : UserControl
    {
        protected eAxis _axis = eAxis.None;
        
        public CtrlMotionRepeat(eAxis axis)
        {
            InitializeComponent();

            this._axis = axis;
        }

        private void CtrlMotion_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            //this.grpMotionRepeat.Text = _axis.ToString() + " Repeat Parameter";
            this.grpMotionRepeat.Text = "Test Motion Parameter";

            //foreach (var control in tlpMotionRepeat.Controls)
            //{
            //    if (control.ToString().Contains("label"))
            //    {
            //        Label lbl = control as Label;
            //        lbl.Text = "0.0";
            //    }
            //}

            lblVelocityValue.Text = "20";
            lblAccelationValue.Text = "20";
            lblDecelationValue.Text = "20";
            lblStartPositionValue.Text = "0";
            lblEndPositionValue.Text = "100";
            lblRepeatCountValue.Text = "0";
        }

        private delegate void UpdateStatusDelegate();

        public void UpdateStatus()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateStatusDelegate callback = UpdateStatus;
                    BeginInvoke(callback);
                    return;
                }

                UpdateUI();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateUI()
        {
            try
            {
                if (Main.Instance().MotionManager.IsConnected())
                {
                    if (Main.Instance().MotionManager.GetActualPosition(_axis) <= 0)
                        lblActualPositionValue.Text = "0";
                    else
                        lblActualPositionValue.Text = Main.Instance().MotionManager.GetActualPosition(_axis).ToString();

                    if (lblRepeatCountValue.Text == "0")
                        lblRemainRepeat.Text = Main.Instance().MotionManager.GetRepeatCount().ToString() + " / " + "∞";
                    else
                        lblRemainRepeat.Text = Main.Instance().MotionManager.GetRepeatCount().ToString() + " / " + lblRepeatCountValue.Text;

                    Console.WriteLine("Current Position : " + lblActualPositionValue.Text.ToString());
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void SetValue_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            double inputData = 0.0;
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            inputData = formKeyPad.m_data;
            lbl.Text = inputData.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetParameter();
            MoveRepeat();
        }

        private void SetParameter()
        {
            double velocity = Convert.ToDouble(lblVelocityValue.Text);
            double accdec = Convert.ToDouble(lblAccelationValue.Text);

            if (velocity <= 0 || accdec <= 0)
            {
                MessageBox.Show("Check the parameters");
                return;
            }

            Main.Instance().MotionManager.SetDefaultParameter(_axis, velocity, accdec);
        }

        private void MoveRepeat()
        {
            double initialPosition = Convert.ToDouble(lblStartPositionValue.Text);

            double startPosition = initialPosition;
            double endPosition = Convert.ToDouble(lblEndPositionValue.Text);
            int repeatCount = Convert.ToInt16(lblRepeatCountValue.Text);

            //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
            //    (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], _axis, initialPosition);
            Main.Instance().MotionManager.MoveTo(_axis, initialPosition);

            Main.Instance().MotionManager.WaitForDone(_axis);

            Main.Instance().MotionManager.MoveRepeat(_axis, startPosition, endPosition, repeatCount, dwellTime:1);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Main.Instance().MotionManager.SetRepeatFlag(false);
            Main.Instance().MotionManager.StopMove(_axis);
        }
    }
}
