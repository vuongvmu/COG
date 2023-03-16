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
    public partial class CtrlMotionFunction : UserControl
    {
        private eAxis _axis = eAxis.None;
        private bool _isScaleJogMode = false;

        public CtrlMotionFunction(eAxis axis)
        {
            InitializeComponent();

            InitializeUI(axis);
        }

        private void InitializeUI(eAxis axis)
        {
            _axis = axis;

            switch (axis)
            {
                case eAxis.None:
                    lblAxisName.Text = "None";
                    btnJogStop.Hide();
                    btnJogUp.Hide();
                    btnJogDown.Hide();
                    btnJogLeft.Hide();
                    btnJogRight.Hide();
                    break;

                case eAxis.Axis_X:
                    lblAxisName.Text = eAxis.Axis_X.ToString().Replace("_", " ");
                    btnJogUp.Hide();
                    btnJogDown.Hide();
                    break;

                case eAxis.Axis_Y:
                    lblAxisName.Text = eAxis.Axis_Y.ToString().Replace("_", " ");
                    btnJogLeft.Hide();
                    btnJogRight.Hide();
                    break;

                case eAxis.Axis_Z:
                    lblAxisName.Text = eAxis.Axis_Z.ToString().Replace("_", " ");
                    btnJogLeft.Hide();
                    btnJogRight.Hide();
                    break;

                default:
                    break;
            }
        }

        private void lblTargetPosition_Click(object sender, EventArgs e)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double targetPosition = formKeyPad.m_data;
            lblTargetPosition.Text = targetPosition.ToString();
        }

        private void lblOffset_Click(object sender, EventArgs e)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double offset = formKeyPad.m_data;
            lblOffset.Text = offset.ToString();
        }

        private void btnServoOn_Click(object sender, EventArgs e)
        {
            Main.Instance().MotionManager.ServoOn(_axis);
        }

        private void btnServoOff_Click(object sender, EventArgs e)
        {
            Main.Instance().MotionManager.ServoOff(_axis);
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
                    // Update Current Position
                    if (Main.Instance().MotionManager.GetActualPosition(_axis) <= 0)
                        lblCurrentPosition.Text = "0.0";
                    else
                        lblCurrentPosition.Text = Main.Instance().MotionManager.GetActualPosition(_axis).ToString();

                    // Update Sensor Status
                    if (Main.Instance().MotionManager.IsNegativeLimit(_axis))
                        lblNegativeLimit.BackColor = Color.Red;
                    else
                        lblNegativeLimit.BackColor = SystemColors.ControlLight;

                    if (Main.Instance().MotionManager.IsPositiveLimit(_axis))
                        lblPositiveLimit.BackColor = Color.Red;
                    else
                        lblPositiveLimit.BackColor = SystemColors.ControlLight;

                    // Update Axis Status
                    lblAxisStatus.Text = Main.Instance().MotionManager.GetCurrentMotionStatus(_axis);

                    // Repeat
                    if (Main.Instance().MotionManager.GetActualPosition(_axis) <= 0)
                        lblRepeatStartPosition.Text = "0.0";
                    else
                        lblRepeatStartPosition.Text = Main.Instance().MotionManager.GetActualPosition(_axis).ToString();
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void btnJogStop_Click(object sender, EventArgs e)
        {
            Main.Instance().MotionManager.StopMove(_axis);
        }

        private void MoveJog(eDirection direction)
        {
            if (_isScaleJogMode)
            {
                //Main.Instance().MotionManager.MoveTo(_axis, Convert.ToDouble(lblCurrentPosition.Text) + Convert.ToDouble(btnJogScaleValue.Text) * (int)direction);

                if (direction == eDirection.CW)
                    Main.Instance().MotionManager.MoveTo(_axis, Convert.ToDouble(lblCurrentPosition.Text) + Convert.ToDouble(btnJogScaleValue.Text));
                else
                    Main.Instance().MotionManager.MoveTo(_axis, Convert.ToDouble(lblCurrentPosition.Text) - Convert.ToDouble(btnJogScaleValue.Text));

                Main.Instance().MotionManager.WaitForDone(_axis);
            }
            else
                Main.Instance().MotionManager.JogMove(_axis, direction);
        }

        private void btnJogUp_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eDirection.CW);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Main.Instance().MotionManager.StartHome(_axis);
        }

        private void btnJogDown_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eDirection.CCW);
        }

        private void btnJogUp_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Instance().MotionManager.StopMove(_axis);
        }

        private void btnJogLeft_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eDirection.CW);
        }

        private void btnJogDown_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Instance().MotionManager.StopMove(_axis);
        }

        private void btnJogRight_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eDirection.CCW);
        }

        private void btnJogLeft_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Instance().MotionManager.StopMove(_axis);
        }

        private void btnJogRight_MouseUp(object sender, MouseEventArgs e)
        {
            Main.Instance().MotionManager.StopMove(_axis);
        }
        private void btnMoveTargetPosition_Click(object sender, EventArgs e)
        {
            double targetPosition = Convert.ToDouble(lblTargetPosition.Text);
            Main.Instance().MotionManager.MoveTo(_axis, targetPosition);
            Main.Instance().MotionManager.WaitForDone(_axis);
        }

        private void lblJogScale_Click(object sender, EventArgs e)
        {
            _isScaleJogMode = !_isScaleJogMode;

            if (_isScaleJogMode)
                lblJogScale.BackColor = Color.LimeGreen;
            else
                lblJogScale.BackColor = SystemColors.ControlLight;
        }

        private void btnJogScaleValue_Click(object sender, EventArgs e)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double jogScale = formKeyPad.m_data;
            btnJogScaleValue.Text = jogScale.ToString();
        }

        private void btnRepeatStart_Click(object sender, EventArgs e)
        {
            SetRepeatParameter();
            MoveRepeat();
        }

        private void SetRepeatParameter()
        {
            //double velocity = Convert.ToDouble(lblVelocityValue.Text);
            //double accdec = Convert.ToDouble(lblAccelationValue.Text);
            double velocity = 0;
            double accdec = 0;

            if (velocity <= 0 || accdec <= 0)
            {
                MessageBox.Show("Check the parameters");
                return;
            }

            Main.Instance().MotionManager.SetDefaultParameter(_axis, velocity, accdec);
        }

        private void MoveRepeat()
        {
            double initialPosition = Main.Instance().MotionManager.GetActualPosition(_axis);

            double startPosition = initialPosition;
            double endPosition = Convert.ToDouble(lblRepeatTargetPosition.Text);
            int repeatCount = Convert.ToInt16(lblRepeatCount.Text);

            //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[(int)Main.DefaultMotionData.PANEL_DIRECTION_TOP,
            //    (int)Main.DefaultMotionData.STAGE1_PREALIGN_LEFT_POSTION, (int)Main.DefaultMotionData.MOTION_AXIS_X], _axis, initialPosition);
            Main.Instance().MotionManager.MoveTo(_axis, initialPosition);

            Main.Instance().MotionManager.WaitForDone(_axis);

            Main.Instance().MotionManager.MoveRepeat(_axis, startPosition, endPosition, repeatCount, dwellTime:1);
        }
    }
}
