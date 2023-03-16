using COG.Class;
using COG.Class.MOTION;
using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormMotionTeach : Form
    {
        public CtrlTeachPosition TeachingPositionControl = null;
        public List<CtrlTeachPosition> TeachingPositionControlList = new List<CtrlTeachPosition>();
        

        //private eAxis _axis = eAxis.None;
        public CtrlMotionParameter TeachMotionControl = null;
        public List<CtrlMotionParameter> TeachMotionControlList = new List<CtrlMotionParameter>();

        //private List<TeachingPosition> _teachingPositionList = new List<TeachingPosition>();
        private List<TeachingPosition> _teachingPositionList = null;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Standby;
        //public eTeachingPosition TeachingPosition
        //{
        //    get { return _teachingPosition; }
        //    set { _teachingPosition = value; }
        //}

        private System.Threading.Timer _formMotionTeachTimer = null;

        private bool _isJogScaleModeX = false;
        private bool _isJogScaleModeY = false;
        private bool _isJogScaleModeZ = false;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FormMotionTeach()
        {
            InitializeComponent();
        }

        private void FormMotionTeach_Load(object sender, EventArgs e)
        {
            StartTimer();
            AddControls();
            GetTeachingPosition();
            IntializeUI();
        }

        private void GetTeachingPosition()
        {
            _teachingPositionList = new List<TeachingPosition>();
            _teachingPositionList = Main.TeachingPositionList.ToList();
        }

        private void StartTimer()
        {
            _formMotionTeachTimer = new System.Threading.Timer(UpdateUI, null, 1000, 1000);
        }

        private delegate void UpdateUIDelegate(object obj);
        private void UpdateUI(object obj)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateUIDelegate callback = UpdateUI;
                    BeginInvoke(callback, obj);
                    return;
                }

                UpdateMotionStatus();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateMotionStatus()
        {
            try
            {
                if (!Main.Instance().MotionManager.IsConnected())
                    return;

                foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                {
                    if (axis == eAxis.None)
                        break;

                    // Update Status
                    switch (axis)
                    {
                        case eAxis.None:
                            break;

                        case eAxis.Axis_X:
                            // Update Current Position
                            lblCurrentPositionX.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString("F3");

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitSensorX.BackColor = Color.Red;
                            else
                                lblNegativeLimitSensorX.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitSensorX.BackColor = Color.Red;
                            else
                                lblPositiveLimitSensorX.BackColor = Color.DarkGray;
                            
                            // Update Axis Status
                            lblAxisStatusX.Text = Main.Instance().MotionManager.GetCurrentMotionStatus(axis);
                            break;

                        case eAxis.Axis_Y:
                            // Update Current Position
                            lblCurrentPositionY.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString("F3");

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitSensorY.BackColor = Color.Red;
                            else
                                lblNegativeLimitSensorY.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitSensorY.BackColor = Color.Red;
                            else
                                lblPositiveLimitSensorY.BackColor = Color.DarkGray;

                            // Update Axis Status
                            lblAxisStatusY.Text = Main.Instance().MotionManager.GetCurrentMotionStatus(axis);
                            break;

                        case eAxis.Axis_Z:
                            // Update Current Position
                            lblCurrentPositionZ.Text = Main.LAF.AFStatus.MPos.ToString("F3");
                           // lblCurrentPositionZ.Text = Main.LAF.AFStatus.CenterOfGravity.ToString();

                            // Update Negative Limit Sensor
                            if (Main.LAF.AFStatus.IsNegativeLimit)
                                lblPositiveLimitSensorZ.BackColor = Color.Red;
                            else
                                lblPositiveLimitSensorZ.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.LAF.AFStatus.IsPositiveLimit)
                                lblPositiveLimitSensorZ.BackColor = Color.Red;
                            else
                                lblPositiveLimitSensorZ.BackColor = Color.DarkGray;

                            // Update Axis Status
                            lblAxisStatusZ.Text = "-";
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void AddControls()
        {
            MakeTeachingListControl();
            MakeTeachingParameterControl();
        }

        private void MakeTeachingListControl()
        {
            tlpTeachingList.ColumnStyles.Clear();
            tlpTeachingList.RowStyles.Clear();

            tlpTeachingList.ColumnCount = 8;
            tlpTeachingList.RowCount = 2;

            for (int columnIndex = 0; columnIndex < tlpTeachingList.ColumnCount; columnIndex++)
                tlpTeachingList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)12.5));

            for (int rowIndex = 0; rowIndex < tlpTeachingList.RowCount; rowIndex++)
                tlpTeachingList.RowStyles.Add(new RowStyle(SizeType.Percent, (float)50));

            foreach (eTeachingPosition teachingPosition in Enum.GetValues(typeof(eTeachingPosition)))
            {
                switch (teachingPosition)
                {
                    case eTeachingPosition.Standby:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, 0, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                        TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
                        break;

                    case eTeachingPosition.Stage1_PreAlign_Left:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, 3, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                        break;

                    case eTeachingPosition.Stage1_PreAlign_Right:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, 4, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);
                        break;

                    case eTeachingPosition.Stage1_Scan_Start:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, 3, 1);
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
            foreach (var teachingPositionControl in TeachingPositionControlList)
                teachingPositionControl.SetButtonStatus(false);

            TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
            _teachingPosition = teachingPosition;

            IntializeUI();
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                TeachMotionControlList[(int)axis].SetDisplayParameter(_teachingPosition);
            }
        }

        private void MakeTeachingParameterControl()
        {
            tlpTeachPosition.ColumnStyles.Clear();
            tlpTeachPosition.RowStyles.Clear();

            tlpTeachPosition.ColumnCount = 1;
            tlpTeachPosition.RowCount = 5;

            for (int rowIndex = 0; rowIndex < tlpTeachPosition.RowCount; rowIndex++)
            {
                if (rowIndex == 0 || rowIndex == 2 || rowIndex == 4)
                    tlpTeachPosition.RowStyles.Add(new RowStyle(SizeType.Percent, (float)30));
                else
                    tlpTeachPosition.RowStyles.Add(new RowStyle(SizeType.Percent, (float)5));
            }

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                switch (axis)
                {
                    case eAxis.None:
                        break;

                    case eAxis.Axis_X:
                        TeachMotionControl = new CtrlMotionParameter(axis);
                        this.tlpTeachPosition.Controls.Add(TeachMotionControl, 0, 0);
                        TeachMotionControl.Dock = DockStyle.Fill;
                        TeachMotionControlList.Add(TeachMotionControl);
                        ActivateUI(axis, false);
                        break;

                    case eAxis.Axis_Y:
                        TeachMotionControl = new CtrlMotionParameter(axis);
                        this.tlpTeachPosition.Controls.Add(TeachMotionControl, 0, 2);
                        TeachMotionControl.Dock = DockStyle.Fill;
                        TeachMotionControlList.Add(TeachMotionControl);
                        ActivateUI(axis, false);
                        break;

                    case eAxis.Axis_Z:
                        TeachMotionControl = new CtrlMotionParameter(axis);
                        this.tlpTeachPosition.Controls.Add(TeachMotionControl, 0, 4);
                        TeachMotionControl.Dock = DockStyle.Fill;
                        TeachMotionControlList.Add(TeachMotionControl);
                        ActivateUI(axis, false);
                        break;

                    default:
                        break;
                }
            }
        }

        private delegate void SetTeachingPositionDelegate(eTeachingPosition teachingPosition);
        public void SetTeachingPosition(eTeachingPosition teachingPosition)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    SetTeachingPositionDelegate callback = SetTeachingPosition;
                    BeginInvoke(callback, teachingPosition);
                    return;
                }

                SetTeachPosition(teachingPosition);
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private void SetTeachPosition(eTeachingPosition teachingPosition)
        {
            _teachingPosition = teachingPosition;
        }

        private void IntializeUI()
        {
            rdoJogSlowMode.Checked = true;
            rdoIncreaseMode.Checked = true;

            lblTargetPositionX.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition.ToString();
            lblOffsetX.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPositionOffset.ToString();

            lblTargetPositionY.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition.ToString();
            lblOffsetY.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPositionOffset.ToString();

            lblTargetPositionZ.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition.ToString();
            lblOffsetZ.Text = _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPositionOffset.ToString();
        }

        private void chkAxisX_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAxisX.Checked)
            {
                chkAxisX.BackColor = Color.LimeGreen;
                ActivateUI(eAxis.Axis_X, true);
            }
            else
            {
                chkAxisX.BackColor = Color.DarkGray;
                ActivateUI(eAxis.Axis_X, false);
            }
        }

        private void chkAxisY_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAxisY.Checked)
            {
                chkAxisY.BackColor = Color.LimeGreen;
                ActivateUI(eAxis.Axis_Y, true);
            }
            else
            {
                chkAxisY.BackColor = Color.DarkGray;
                ActivateUI(eAxis.Axis_Y, false);
            }
        }

        private void chkAxisZ_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAxisZ.Checked)
            {
                chkAxisZ.BackColor = Color.LimeGreen;
                ActivateUI(eAxis.Axis_Z, true);
            }
            else
            {
                chkAxisZ.BackColor = Color.DarkGray;
                ActivateUI(eAxis.Axis_Z, false);
            }
        }

        private void ActivateUI(eAxis axis, bool isActive)
        {
            TeachMotionControlList[(int)axis].Enabled = isActive;
        }

        private void SetTargetPosition_Click(object sender, EventArgs e)
        {
            SetTargetPosition(sender);
        }

        private void SetTargetPosition(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label labelButton = sender as Label;

            if (labelButton.Name.Contains("X"))
            {
                lblTargetPositionX.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition = outputData;
            }
            else if (labelButton.Name.Contains("Y"))
            {
                lblTargetPositionY.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition = outputData;
            }
            else
            {
                lblTargetPositionZ.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition = outputData;
            }
        }

        private void SetOffset_Click(object sender, EventArgs e)
        {
            SetOffset(sender);
        }

        private void SetOffset(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label label = sender as Label;

            if (label.Name.Contains("X"))
            {
                lblOffsetX.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPositionOffset = outputData;
            }
            else if (label.Name.Contains("Y"))
            {
                lblOffsetY.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPositionOffset = outputData;
            }
            else if (label.Name.Contains("Z"))
            {
                lblOffsetZ.Text = outputData.ToString();
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPositionOffset = outputData;
            }
            else { }
            //lblTeachCog.Text = outputData.ToString();
        }

        private void btnMoveTargetPosition_Click(object sender, EventArgs e)
        {
            MoveTargetPosition();
        }

        private void MoveTargetPosition()
        {
            // Z축 위치 확인 관련 인터락 필요
            if (!chkAxisX.Checked || !chkAxisY.Checked || !chkAxisZ.Checked)
                MessageBox.Show("No Axis Selected.");

            if (chkAxisX.Checked)
            {
                Main.Instance().MotionManager.MoveTo(eAxis.Axis_X,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].MotionProperty.Velocity,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].MotionProperty.Acceleration);
            }

            if (chkAxisY.Checked)
            {
                Main.Instance().MotionManager.MoveTo(eAxis.Axis_Y,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].MotionProperty.Velocity,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].MotionProperty.Acceleration);
            }

            if (chkAxisZ.Checked)
            {
                Main.Instance().MotionManager.MoveTo(eAxis.Axis_Z,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.Velocity,
                                                    Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.Acceleration);
            }
        }

        private void btnInputCurrentPosition_Click(object sender, EventArgs e)
        {
            InputCurrentPosition();
        }

        private void InputCurrentPosition()
        {
            if (chkAxisX.Checked)
            {
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition = Convert.ToDouble(lblCurrentPositionX.Text.ToString());
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPositionOffset = Convert.ToDouble(lblOffsetX.Text.ToString());
            }

            if (chkAxisY.Checked)
            {
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition = Convert.ToDouble(lblCurrentPositionY.Text.ToString());
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPositionOffset = Convert.ToDouble(lblOffsetY.Text.ToString());
            }

            if (chkAxisZ.Checked)
            {
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition = Convert.ToDouble(lblCurrentPositionZ.Text.ToString());
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPositionOffset = Convert.ToDouble(lblOffsetZ.Text.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                TeachMotionControlList[(int)axis].SetParameter(_teachingPosition);
            }

            Main.SaveTeachingParameter();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_X, eDirection.CCW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_X);
        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_X, eDirection.CW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_X);
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_Y, eDirection.CW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_Y);
        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_Y, eDirection.CCW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_Y);
        }

        private void btnJogDownZ_Click(object sender, EventArgs e)
        {
            MoveJog(eAxis.Axis_Z, eDirection.CCW);
        }

        private void btnJogUpZ_Click(object sender, EventArgs e)
        {
            MoveJog(eAxis.Axis_Z, eDirection.CW);
        }

        private void btnJogStop_Click(object sender, EventArgs e)
        {
            AllMoveStop();
        }

        private void AllMoveStop()
        {
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                MoveStop(axis);
        }

        private void MoveJog(eAxis axis, eDirection direction)
        {
            if (axis == eAxis.None)
                return;

            bool isScaleMode = false;
            double targetPosition = 0.0;
            double scaleValue = 0.0;

            switch (axis)
            {
                case eAxis.None:
                    break;

                case eAxis.Axis_X:
                    isScaleMode = _isJogScaleModeX;
                    targetPosition = Convert.ToDouble(lblCurrentPositionX.Text);
                    scaleValue = Convert.ToDouble(lblPitchXYValue.Text);
                    break;

                case eAxis.Axis_Y:
                    isScaleMode = _isJogScaleModeY;
                    targetPosition = Convert.ToDouble(lblCurrentPositionY.Text);
                    scaleValue = Convert.ToDouble(lblPitchXYValue.Text);
                    break;

                case eAxis.Axis_Z:
                    isScaleMode = _isJogScaleModeZ;
                    targetPosition = Convert.ToDouble(lblCurrentPositionZ.Text);
                    scaleValue = Convert.ToDouble(lblPitchZValue.Text);
                    break;

                default:
                    break;
            }

            if (axis == eAxis.Axis_Z)
            {
                double moveAmount = 1.0;

                if (isScaleMode)
                {
                    if (Convert.ToDouble(lblPitchZValue.Text) >= 1.0)
                        moveAmount = 1.0;
                    else
                        moveAmount = Convert.ToDouble(lblPitchZValue.Text);
                }

                Main.LAF.SetMotionRelativeMove(direction, moveAmount);
            }
            else
            {
                if (isScaleMode)
                {
                    if (direction == eDirection.CW)
                        Main.Instance().MotionManager.MoveTo(axis, targetPosition - scaleValue);
                    else
                        Main.Instance().MotionManager.MoveTo(axis, targetPosition + scaleValue);

                    Main.Instance().MotionManager.WaitForDone(axis);
                }
                else
                    Main.Instance().MotionManager.JogMove(axis, direction);
            }
        }

        private void MoveStop(eAxis axis)
        {
            if (axis == eAxis.None)
                return;

            if (axis == eAxis.Axis_Z)
                Main.LAF.SetMotionStop();
            else
                Main.Instance().MotionManager.StopMove(axis);
        }

        private void SetScaleMode_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                if (checkBox.Name.Contains("X"))
                    _isJogScaleModeX = true;
                else if (checkBox.Name.Contains("Y"))
                    _isJogScaleModeY = true;
                else
                    _isJogScaleModeZ = true;

                checkBox.BackColor = Color.DarkRed;
            }
            else
            {
                if (checkBox.Name.Contains("X"))
                    _isJogScaleModeX = false;
                else if (checkBox.Name.Contains("Y"))
                    _isJogScaleModeY = false;
                else
                    _isJogScaleModeZ = false;

                checkBox.BackColor = Color.Gray;
            }
        }

        private void SetScale_Click(object sender, EventArgs e)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label labelButton = sender as Label;

            if (labelButton.Name.Contains("X"))
                lblPitchXYValue.Text = outputData.ToString();
            else if (labelButton.Name.Contains("Y"))
                lblPitchXYValue.Text = outputData.ToString();
            else
                lblPitchZValue.Text = outputData.ToString();
        }

        private eJogSpeedMode _jogSpeedMode = eJogSpeedMode.Slow;
        private eJogMode _jogMode = eJogMode.Jog;
        private void rdoJogSpeedMode_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectJogSpeedMode(sender);
        }

        private void SetSelectJogSpeedMode(object sender)
        {
            RadioButton rdo = sender as RadioButton;

            if (rdo.Text.ToLower().Contains("slow"))
                SetJogSpeedMode(eJogSpeedMode.Slow);
            else if (rdo.Text.ToLower().Contains("fast"))
                SetJogSpeedMode(eJogSpeedMode.Fast);
            else { }

            if (rdo.Checked)
                rdo.BackColor = Color.LimeGreen;
            else
                rdo.BackColor = Color.DarkGray;
        }

        private void SetJogSpeedMode(eJogSpeedMode jogSpeedMode)
        {
            _jogSpeedMode = jogSpeedMode;
        }

        private void rdoJogMode_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectJogMode(sender);
        }

        private void SetSelectJogMode(object sender)
        {
            RadioButton rdo = sender as RadioButton;

            if (rdo.Text.ToLower().Contains("jog"))
                SetJogMode(eJogMode.Jog);
            else if (rdo.Text.ToLower().Contains("inc"))
                SetJogMode(eJogMode.Increase);
            else { }

            if (rdo.Checked)
                rdo.BackColor = Color.LimeGreen;
            else
                rdo.BackColor = Color.DarkGray;
        }

        private void SetJogMode(eJogMode jogMode)
        {
            _jogMode = jogMode;
        }

        private void lblPitchXYValue_Click(object sender, EventArgs e)
        {
            SetJogPitch(sender);
        }

        private void lblPitchZValue_Click(object sender, EventArgs e)
        {
            SetJogPitch(sender);
        }

        private void SetJogPitch(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label labelButton = sender as Label;

            labelButton.Text = outputData.ToString();
        }

        private void btnSetCurrentToTeachX_Click(object sender, EventArgs e)
        {
            SetCurrentToTeachData(sender);
        }

        private void btnSetCurrentToTeachY_Click(object sender, EventArgs e)
        {
            SetCurrentToTeachData(sender);
        }

        private void btnSetCurrentToTeachZ_Click(object sender, EventArgs e)
        {
            SetCurrentToTeachData(sender);
        }

        private void SetCurrentToTeachData(object sender)
        {
            Button btn = sender as Button;

            if (btn.Name.Contains("X"))
            {
                lblTargetPositionX.Text = lblCurrentPositionX.Text;
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition = Convert.ToDouble(lblCurrentPositionX.Text);
            }
            else if (btn.Name.Contains("Y"))
            {
                lblTargetPositionY.Text = lblCurrentPositionY.Text;
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition = Convert.ToDouble(lblCurrentPositionY.Text);
            }
            else if (btn.Name.Contains("Z"))
            {
                lblTargetPositionZ.Text = lblCurrentPositionZ.Text;
                _teachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition = Convert.ToDouble(lblCurrentPositionZ.Text);
            }
            else { }
        }
    }
}
