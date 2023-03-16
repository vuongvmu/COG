using COG.Class.MOTION;
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
    public partial class Form_Motion : Form
    {
        enum MotionInfo
        {   
            Direction_Top = 0,
            Direction_Bottom = 1,
            AxisX = 0,
            AxisZ = 1,
            Stage1_PrealignLeftPosition = 0,
            Stage1_PrealignRightPosition = 1,
            Stage1_ScanStartPosition = 2,
            Stage2_PrealignLeftPosition = 3,
            Stage2_PrealignRightPosition = 4,
            Stage2_ScanStartPosition = 5,
            Standby = 6
        }

        private int nDirection;
        private int nPosition;
        private int nAxis;
        private double dTargetPosition;

        private bool _isScaleJogMode = false;
        private eAxis _axis = eAxis.None;

        public Form_Motion()
        {
            InitializeComponent();

            nDirection = 0;
            nPosition = 0;
            nAxis = 0;
            dTargetPosition = 0;
        }

        private void Form_Motion_Load(object sender, EventArgs e)
        {
            //Main.MotionLoad();
            //Main.ReadMotionParameter();

            Main.ReadTeachingParameter();
            timer1.Enabled = true;
            SetDisplayParameter();
        }

        private void Form_Motion_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        public void SetDisplayParameter()
        {
            if(nDirection == (int)MotionInfo.Direction_Top)
            {
                BTN_DIRECTION_TOP.BackColor = System.Drawing.Color.DarkRed;
                BTN_DIRECTION_BOTTOM.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                BTN_DIRECTION_TOP.BackColor = System.Drawing.Color.Silver;
                BTN_DIRECTION_BOTTOM.BackColor = System.Drawing.Color.DarkRed;
            }

            if(nPosition == (int)MotionInfo.Stage1_PrealignLeftPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Stage1_PrealignRightPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Stage1_ScanStartPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Stage2_PrealignLeftPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Stage2_PrealignRightPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Stage2_ScanStartPosition)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (nPosition == (int)MotionInfo.Standby)
            {
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.DarkRed;
            }
            //LBL_AXIS_X_TARGET_POSITION.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].TargetPosition.ToString();

            //if (Main.MotionCtrl.GetCurrentMotionStatus(nAxis).CompareTo("NORMAL") == 0)
           // if (Main.Instance().MotionManager.GetCurrentMotionStatus(Class.MOTION.eAxis.Axis_X).CompareTo("NORMAL") == 0)
            //{
            //    BTN_AXIS_X_SERVO_ON.BackColor = System.Drawing.Color.Lime;
            //    BTN_AXIS_X_SERVO_OFF.BackColor = System.Drawing.Color.Silver;
            //}
            //else
            //{
            //    BTN_AXIS_X_SERVO_ON.BackColor = System.Drawing.Color.Silver;
            //    BTN_AXIS_X_SERVO_OFF.BackColor = System.Drawing.Color.Red;
            //}

            BTN_AXIS_X_JOG_SPEED.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].JogSpeed.ToString();
            BTN_AXIS_X_VELOCITY.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].Velocity.ToString();
            BTN_AXIS_X_MOVE_LIMIT_TIME.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].MoveLimitTime.ToString();
            BTN_AXIS_X_ACC_TIME.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].Acceleration.ToString();
            BTN_AXIS_X_DEC_TIME.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].Deceleration.ToString();
            BTN_AXIS_X_MOVE_TOLERANCE.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].MoveTolerance.ToString();
            BTN_AXIS_X_LIMIT_POS.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].LimitPositive.ToString();
            BTN_AXIS_X_LIMIT_NEG.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].LimitNegative.ToString();
            BTN_AXIS_X_AFTER_WAIT_TIME.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].AfterWaitTime.ToString();
            BTN_AXIS_X_HOMING_LIMIT_TIME.Text = Main.m_sPositionData[nDirection, nPosition, nAxis].HomingLimitTime.ToString();
        }

        public void UpdateMotionParameter()
        {
            //Main.m_sPositionData[nDirection, nPosition, nAxis].TargetPosition = Convert.ToDouble(LBL_AXIS_X_TARGET_POSITION.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].JogSpeed = Convert.ToDouble(BTN_AXIS_X_JOG_SPEED.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].Velocity = Convert.ToDouble(BTN_AXIS_X_VELOCITY.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].MoveLimitTime = Convert.ToDouble(BTN_AXIS_X_MOVE_LIMIT_TIME.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].Acceleration = Convert.ToInt32(BTN_AXIS_X_ACC_TIME.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].Deceleration = Convert.ToInt32(BTN_AXIS_X_DEC_TIME.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].MoveTolerance = Convert.ToDouble(BTN_AXIS_X_MOVE_TOLERANCE.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].LimitPositive = Convert.ToDouble(BTN_AXIS_X_LIMIT_POS.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].LimitNegative = Convert.ToDouble(BTN_AXIS_X_LIMIT_NEG.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].AfterWaitTime = Convert.ToDouble(BTN_AXIS_X_AFTER_WAIT_TIME.Text);
            Main.m_sPositionData[nDirection, nPosition, nAxis].HomingLimitTime = Convert.ToDouble(BTN_AXIS_X_HOMING_LIMIT_TIME.Text);
            //하기 데이터는 추후 추가 예정 YSH
            //AFOffsetValue = (int)DefaultMotionData.DEFAULT_TARGET_POSITION;
            //Target_PositionOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
            //Target_PositionStartOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
            //Target_PositionEndOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
    }

        private void BTN_DIRECTION_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if(button.Text.CompareTo("TOP") == 0)
            {
                nDirection = 0;
                BTN_DIRECTION_TOP.BackColor = System.Drawing.Color.DarkRed;
                BTN_DIRECTION_BOTTOM.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("BOTTOM") == 0)
            {
                nDirection = 1;
                BTN_DIRECTION_TOP.BackColor = System.Drawing.Color.Silver;
                BTN_DIRECTION_BOTTOM.BackColor = System.Drawing.Color.DarkRed;
            }
        }

        private void BTN_POSITION_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text.CompareTo("STAGE#1 Prealign Left Position") == 0)
            {
                nPosition = 0;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STAGE#1 Prealign Right Position") == 0)
            {
                nPosition = 1;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STAGE#1 Scan Start Position") == 0)
            {
                nPosition = 2;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STAGE#2 Prealign Left Position") == 0)
            {
                nPosition = 3;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STAGE#2 Prealign Right Position") == 0)
            {
                nPosition = 4;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STAGE#2 Scan Start Position") == 0)
            {
                nPosition = 5;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.DarkRed;
                BTN_STANDBY.BackColor = System.Drawing.Color.Silver;
            }
            else if (button.Text.CompareTo("STANDBY") == 0)
            {
                nPosition = 6;
                BTN_STAGE1_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE1_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_LEFT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_PREALIGN_RIGHT_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STAGE2_SCAN_START_POSITION.BackColor = System.Drawing.Color.Silver;
                BTN_STANDBY.BackColor = System.Drawing.Color.DarkRed;
            }
        }

        private void LBL_AXIS_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Text.CompareTo("AXIS X") == 0)
            {
                nAxis = 0;
                LBL_AXIS_X.BackColor = System.Drawing.Color.DarkRed;
                _axis = eAxis.Axis_X;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Main.Instance().MotionManager.IsConnected())
            {
                LBL_AXIS_X_CURRENT_POSITION.Text = Main.Instance().MotionManager.GetActualPosition(Class.MOTION.eAxis.Axis_X).ToString("F3");
                LBL_AXIS_X_STATUS.Text = Main.Instance().MotionManager.GetCurrentMotionStatus(Class.MOTION.eAxis.Axis_X);
            }
        }

        private void LBL_AXIS_X_TARGET_POSITION_Click(object sender, EventArgs e)
        {
            Form_KeyPad form_keypad = new Form_KeyPad();
            form_keypad.ShowDialog();
            dTargetPosition = form_keypad.m_data;
            LBL_AXIS_X_TARGET_POSITION.Text = dTargetPosition.ToString();
        }

        private void BTN_AXIS_X_SERVO_OFF_Click(object sender, EventArgs e)
        {
            //Main.MotionCtrl.AxisEnable((int)MotionInfo.AxisX, false);

            if (_axis == eAxis.None)
            {
                MessageBox.Show("축 선택 후 실행해주십시오.");
                return;
            }

            Main.Instance().MotionManager.ServoOff(eAxis.Axis_X);
        }

        private void BTN_AXIS_X_SERVO_ON_Click(object sender, EventArgs e)
        {
            //Main.MotionCtrl.AxisEnable((int)MotionInfo.AxisX, true);

            if (_axis == eAxis.None)
            {
                MessageBox.Show("축 선택 후 실행해주십시오.");
                return;
            }

            Main.Instance().MotionManager.ServoOn(eAxis.Axis_X);
        }

        private void BTN_MOVE_TARGET_POSITION_Click(object sender, EventArgs e)
        {
            //Main.MotionCtrl.StartMove(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis, dTargetPosition);
            //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis);

            //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[nDirection, nPosition, nAxis], Class.MOTION.eAxis.Axis_X, dTargetPosition);
            Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, dTargetPosition);
            Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
        }

        private void BTN_JOG_Click(object sender, EventArgs e)
        {
            /*
            if (_axis == eAxis.None)
            {
                MessageBox.Show("축 선택 후 실행해주십시오.");
                return;
            }

            Button button = (Button)sender;
            if (button.Name.ToString().CompareTo("BTN_JOG_X_LEFT") == 0)
            {
                ////Main.MotionCtrl.JogMove(Main.m_sPositionData[nDirection, nPosition, (int)MotionInfo.AxisX], (int)MotionInfo.AxisX, false);
                //Main.MotionCtrl.StartMove(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) - 1);
                //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis);

                if (_isScaleJogMode)
                    Main.Instance().MotionManager.JogMove(_axis, eDirection.CW);
                else
                {
                    Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[nDirection, nPosition, nAxis], eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) - Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
                }
            }
            else if (button.Name.ToString().CompareTo("BTN_JOG_X_RIGHT") == 0)
            {
                //// Main.MotionCtrl.JogMove(Main.m_sPositionData[nDirection, nPosition, (int)MotionInfo.AxisX], (int)MotionInfo.AxisX, true);
                //Main.MotionCtrl.StartMove(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) + 1);
                //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis);

                if (_isScaleJogMode)
                    Main.Instance().MotionManager.JogMove(_axis, eDirection.CCW);
                else
                {
                    Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[nDirection, nPosition, nAxis], eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) + Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
                }
            }
            else if (button.Name.ToString().CompareTo("BTN_JOG_STOP") == 0)
            {
                Main.MotionCtrl.StopMove(nAxis);
                //Main.Instance().MotionManager
            }
            */
        }

        private void BTN_AXIS_X_PARAMETER_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            double dInputData;
            Form_KeyPad form_keypad = new Form_KeyPad();
            form_keypad.ShowDialog();
 
            if (button.Name.ToString().CompareTo("BTN_AXIS_X_JOG_SPEED") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_JOG_SPEED.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].JogSpeed = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_VELOCITY") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_VELOCITY.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].Velocity = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_MOVE_LIMIT_TIME") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_MOVE_LIMIT_TIME.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].MoveLimitTime = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_ACC_TIME") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_ACC_TIME.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].Acceleration = Convert.ToInt32(dInputData);
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_DEC_TIME") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_DEC_TIME.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].Deceleration = Convert.ToInt32(dInputData);
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_MOVE_TOLERANCE") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_MOVE_TOLERANCE.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].MoveTolerance = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_LIMIT_POS") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_LIMIT_POS.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].LimitPositive = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_LIMIT_NEG") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_LIMIT_NEG.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].LimitNegative = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_AFTER_WAIT_TIME") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_AFTER_WAIT_TIME.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].AfterWaitTime = dInputData;
            }
            else if (button.Name.ToString().CompareTo("BTN_AXIS_X_HOMING_LIMIT_TIME") == 0)
            {
                dInputData = form_keypad.m_data;
                BTN_AXIS_X_HOMING_LIMIT_TIME.Text = dInputData.ToString();
                Main.m_sPositionData[nDirection, nPosition, nAxis].HomingLimitTime = dInputData;
            }
        }

        private void BTN_INPUT_CURRENT_POSITION_Click(object sender, EventArgs e)
        {
            LBL_AXIS_X_TARGET_POSITION.Text = LBL_AXIS_X_CURRENT_POSITION.Text;
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            UpdateMotionParameter();
            Main.MotionSave();
        }

        private void btnOrigin_Click(object sender, EventArgs e)
        {
            if (_axis == eAxis.None)
            {
                MessageBox.Show("축 선택 후 실행해주십시오.");
                return;
            }

            Main.Instance().MotionManager.StartHome(_axis);
        }

        private void btnJogScale_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            double dInputData;
            Form_KeyPad form_keypad = new Form_KeyPad();
            form_keypad.ShowDialog();

            dInputData = form_keypad.m_data;
            btnJogScale.Text = dInputData.ToString();
            Main.m_sPositionData[nDirection, nPosition, nAxis].JogSpeed = dInputData;
        }

        private void btnJogScaleMode_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            _isScaleJogMode = !_isScaleJogMode;

            if (_isScaleJogMode)
                btnJogScaleMode.BackColor = Color.DarkRed;
            else
                btnJogScaleMode.BackColor = Color.Silver;
        }

        private void btnMouseUp(object sender, MouseEventArgs e)
        {
            if (_axis == eAxis.None)
                return;

            Main.Instance().MotionManager.StopMove(_axis);
        }

        private void btnMouseDown(object sender, MouseEventArgs e)
        {
            if (_axis == eAxis.None)
            {
                MessageBox.Show("축 선택 후 실행해주십시오.");
                return;
            }

            Button button = (Button)sender;
            if (button.Name.ToString().CompareTo("BTN_JOG_X_LEFT") == 0)
            {
                ////Main.MotionCtrl.JogMove(Main.m_sPositionData[nDirection, nPosition, (int)MotionInfo.AxisX], (int)MotionInfo.AxisX, false);
                //Main.MotionCtrl.StartMove(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) - 1);
                //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis);

                if (_isScaleJogMode)
                {
                    //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[nDirection, nPosition, nAxis], eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) - Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) - Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X);
                }
                    
                else
                    Main.Instance().MotionManager.JogMove(_axis, eDirection.CW);
            }
            else if (button.Name.ToString().CompareTo("BTN_JOG_X_RIGHT") == 0)
            {
                //// Main.MotionCtrl.JogMove(Main.m_sPositionData[nDirection, nPosition, (int)MotionInfo.AxisX], (int)MotionInfo.AxisX, true);
                //Main.MotionCtrl.StartMove(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) + 1);
                //Main.MotionCtrl.WaitForDOne(Main.m_sPositionData[nDirection, nPosition, nAxis], nAxis);

                if (_isScaleJogMode)
                {
                    //Main.Instance().MotionManager.MoveTo(Main.m_sPositionData[nDirection, nPosition, nAxis], eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) + Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.MoveTo(eAxis.Axis_X, Convert.ToDouble(LBL_AXIS_X_CURRENT_POSITION.Text) + Convert.ToDouble(btnJogScale.Text));
                    Main.Instance().MotionManager.WaitForDone(eAxis.Axis_X); 
                }
                else
                    Main.Instance().MotionManager.JogMove(_axis, eDirection.CCW);
            }
            else if (button.Name.ToString().CompareTo("BTN_JOG_STOP") == 0)
            {
                //Main.MotionCtrl.StopMove(nAxis);
                Main.Instance().MotionManager.StopMove(_axis);
            }
        }
    }
}
