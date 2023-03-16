using COG.Class;
using COG.Class.MOTION;
using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormMotionPopup : Form
    {
        private System.Threading.Timer _formMotionPopupTimer = null;

        public CtrlTeachPosition TeachingPositionControl = null;
        public List<CtrlTeachPosition> TeachingPositionControlList = new List<CtrlTeachPosition>();

        //private CtrlMotionParameter _motionParameterControl = null;
        //private List<CtrlMotionParameter> _motionParameterControlList = new List<CtrlMotionParameter>();
        private CtrlMotionParameterVariable _variableParamControl = null;
        private List<CtrlMotionParameterVariable> _variableParamControlList = new List<CtrlMotionParameterVariable>();

        private List<TeachingPosition> TeachingPositionList = new List<TeachingPosition>();

        private bool _isJogScaleModeX = false;
        private bool _isJogScaleModeY = false;
        private bool _isJogScaleModeZ = false;

        private bool _isAvailableAxisX = false;
        private bool _isAvailableAxisY = false;
        private bool _isAvailableAxisZ = false;

        private eTeachingPosition _teachingPosition;
        private eTeachingPosition _selectedTeachingPosition;
        public Action CloseEventDelegate;

        public FormMotionPopup(eTeachingPosition teachingPosition)
        {
            InitializeComponent();
            SetTeachingPosition(teachingPosition);
        }

        private void FormMotionPopup_Load(object sender, EventArgs e)
        {
            StartTimer();
            GetTeachingPosition();
            AddControl();
            InitializeUI();
            MakeTeachingListControl();
            ActivateTeachingPositionList();
        }

        private void SetTeachingPosition(eTeachingPosition tachingPosition)
        {
            _selectedTeachingPosition = tachingPosition;
        }

        private void GetTeachingPosition()
        {
            TeachingPositionList = Main.TeachingPositionList.ToList();
        }

        private void StartTimer()
        {
            _formMotionPopupTimer = new System.Threading.Timer(UpdateUI, null, 1000, 1000);
        }

        private delegate void UpdateUIDelegate(object obj);
        private void UpdateUI(object obj)
        {
            if (this.InvokeRequired)
            {
                UpdateUIDelegate callback = UpdateUI;
                BeginInvoke(callback, obj);
                return;
            }

            UpdateMotionStatus();
            UpdatePageButton();
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
                            lblCurrentPositionX.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString();

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitX.BackColor = Color.Red;
                            else
                                lblNegativeLimitX.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitX.BackColor = Color.Red;
                            else
                                lblPositiveLimitX.BackColor = Color.DarkGray;
                            break;

                        case eAxis.Axis_Y:
                            // Update Current Position
                            lblCurrentPositionY.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString();

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitY.BackColor = Color.Red;
                            else
                                lblNegativeLimitY.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitY.BackColor = Color.Red;
                            else
                                lblPositiveLimitY.BackColor = Color.DarkGray;
                            break;

                        case eAxis.Axis_Z:
                            // Update Current Position
                            lblCurrentPositionZ.Text = Main.LAF.AFStatus.MPos.ToString();
							
                            // Update Negative Limit Sensor
                            if (Main.LAF.AFStatus.IsNegativeLimit)
                                lblNegativeLimitZ.BackColor = Color.Red;
                            else
                                lblNegativeLimitZ.BackColor = Color.DarkGray;

                            // Update Positive Limit Sensor
                            if (Main.LAF.AFStatus.IsPositiveLimit)
                                lblPositiveLimitZ.BackColor = Color.Red;
                            else
                                lblPositiveLimitZ.BackColor = Color.DarkGray;
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

        private void UpdatePageButton()
        {
            if (tlpMotionCommand.Visible)
            {
                btnCommand.Enabled = false;
                btnParameter.Enabled = true;
            }
            else
            {
                btnCommand.Enabled = true;
                btnParameter.Enabled = false;
            }
        }

        private void InitializeUI()
        {
            tlpMotionCommand.Dock = DockStyle.Fill;
            tlpMotionCommand.Visible = true;

            tlpMotionParameter.Dock = DockStyle.Fill;
            tlpMotionParameter.Visible = false;

            this.Location = new Point(1000, 40);
            this.Size = new Size(720, 800);
            UpdateData(_selectedTeachingPosition);
            rdoJogSlowMode.Checked = true;
            rdoIncreaseMode.Checked = true;
        }

        private void AddControl()
        {
            MakeTeachingParameterControl();
        }

        private void MakeTeachingParameterControl()
        {
            tlpMotionParameter.ColumnStyles.Clear();
            tlpMotionParameter.RowStyles.Clear();

            tlpMotionParameter.ColumnCount = 1;
            tlpMotionParameter.RowCount = 5;

            for (int rowIndex = 0; rowIndex < tlpMotionParameter.RowCount; rowIndex++)
            {
                if (rowIndex == 0 || rowIndex == 2 || rowIndex == 4)
                    tlpMotionParameter.RowStyles.Add(new RowStyle(SizeType.Percent, (float)30));
                else
                    tlpMotionParameter.RowStyles.Add(new RowStyle(SizeType.Percent, (float)5));
            }

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                GroupBox grp = null;

                if (axis == eAxis.None)
                    break;

                switch (axis)
                {
                    case eAxis.None:
                        break;

                    case eAxis.Axis_X:
                        grp = new GroupBox();
                        grp.Text = axis.ToString().ToUpper().Replace("_", " ") + " SET-UP";
                        grp.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
                        grp.Dock = DockStyle.Fill;
                        this.tlpMotionParameter.Controls.Add(grp, 0, 0);

                        _variableParamControl = new CtrlMotionParameterVariable(axis);
                        _variableParamControl.Dock = DockStyle.Fill;
                        grp.Controls.Add(_variableParamControl);
                        _variableParamControlList.Add(_variableParamControl);

                        //_variableParamControl = new CtrlMotionParameterVariable(axis);
                        //this.tlpMotionParameter.Controls.Add(_variableParamControl, 0, 0);
                        //_variableParamControl.Dock = DockStyle.Fill;
                        //_variableParamControlList.Add(_variableParamControl);
                        break;

                    case eAxis.Axis_Y:
                        grp = new GroupBox();
                        grp.Text = axis.ToString().ToUpper().Replace("_", " ") + " SET-UP";
                        grp.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
                        grp.Dock = DockStyle.Fill;
                        this.tlpMotionParameter.Controls.Add(grp, 0, 2);

                        _variableParamControl = new CtrlMotionParameterVariable(axis);
                        _variableParamControl.Dock = DockStyle.Fill;
                        grp.Controls.Add(_variableParamControl);
                        _variableParamControlList.Add(_variableParamControl);

                        //_variableParamControl = new CtrlMotionParameterVariable(axis);
                        //this.tlpMotionParameter.Controls.Add(_variableParamControl, 0, 2);
                        //_variableParamControl.Dock = DockStyle.Fill;
                        //_variableParamControlList.Add(_variableParamControl);
                        break;

                    case eAxis.Axis_Z:
                        grp = new GroupBox();
                        grp.Text = axis.ToString().ToUpper().Replace("_", " ") + " SET-UP";
                        grp.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
                        grp.Dock = DockStyle.Fill;
                        this.tlpMotionParameter.Controls.Add(grp, 0, 4);

                        _variableParamControl = new CtrlMotionParameterVariable(axis);
                        _variableParamControl.Dock = DockStyle.Fill;
                        grp.Controls.Add(_variableParamControl);
                        _variableParamControlList.Add(_variableParamControl);

                        //_variableParamControl = new CtrlMotionParameterVariable(axis);
                        //this.tlpMotionParameter.Controls.Add(_variableParamControl, 0, 4);
                        //_variableParamControl.Dock = DockStyle.Fill;
                        //_variableParamControlList.Add(_variableParamControl);
                        break;

                    default:
                        break;
                }
            }
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
                    case eTeachingPosition.Standby:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                        TeachingPositionControl.Enabled = false;
                        //TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
                        break;

                    case eTeachingPosition.Stage1_PreAlign_Left:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                        if (_selectedTeachingPosition == eTeachingPosition.Stage1_Scan_Start)
                            TeachingPositionControl.Enabled = false;
                        break;

                    case eTeachingPosition.Stage1_PreAlign_Right:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                        if (_selectedTeachingPosition == eTeachingPosition.Stage1_Scan_Start)
                            TeachingPositionControl.Enabled = false;
                        break;

                    case eTeachingPosition.Stage1_Scan_Start:
                        TeachingPositionControl = new CtrlTeachPosition(teachingPosition);
                        this.tlpTeachingList.Controls.Add(TeachingPositionControl, (int)teachingPosition, 0);
                        TeachingPositionControl.Dock = DockStyle.Fill;

                        TeachingPositionControlList.Add(TeachingPositionControl);
                        TeachingPositionControl.SendEventHandler += new CtrlTeachPosition.SetTeachingListDelegate(ReceiveTeachingPosition);

                        if (_selectedTeachingPosition != eTeachingPosition.Stage1_Scan_Start)
                            TeachingPositionControl.Enabled = false;
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

        private void ActivateTeachingPositionList()
        {
            TeachingPositionControlList[(int)_selectedTeachingPosition].SetButtonStatus(true);
            _teachingPosition = _selectedTeachingPosition;
        }

        private void ReceiveTeachingPosition(eTeachingPosition teachingPosition)
        {
            foreach (var teachingPositionControl in TeachingPositionControlList)
                teachingPositionControl.SetButtonStatus(false);

            TeachingPositionControlList[(int)teachingPosition].SetButtonStatus(true);
            _teachingPosition = teachingPosition;

            UpdateData(teachingPosition);

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                _variableParamControlList[(int)axis].SetDisplayParameter(_teachingPosition);
            }
        }

        private void UpdateData(eTeachingPosition teachingPosition)
        {
            lblTargetPositionX.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition.ToString();
            lblOffsetX.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPositionOffset.ToString();

            lblTargetPositionY.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition.ToString();
            lblOffsetY.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPositionOffset.ToString();

            lblTargetPositionZ.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition.ToString();
            lblOffsetZ.Text = TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPositionOffset.ToString();

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                _variableParamControlList[(int)axis].SetDisplayParameter(teachingPosition);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMoveTeachingPosition_Click(object sender, EventArgs e)
        {
            MoveTeachingPosition();
        }

        private void MoveTeachingPosition()
        {
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                switch (axis)
                {
                    case eAxis.None:
                        break;

                    case eAxis.Axis_X:
                        if (!_isAvailableAxisX)
                            break;

                        Main.Instance().MotionManager.MoveTo(axis, Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)axis].TargetPosition);
                        Main.Instance().MotionManager.WaitForDone(axis);
                        break;

                    case eAxis.Axis_Y:
                        if (!_isAvailableAxisY)
                            break;

                        Main.Instance().MotionManager.MoveTo(axis, Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)axis].TargetPosition);
                        Main.Instance().MotionManager.WaitForDone(axis);
                        break;

                    case eAxis.Axis_Z:
                        if (!_isAvailableAxisZ)
                            break;

                        Main.LAF.SetMotionMaxSpeed(Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)axis].MotionProperty.Velocity));
                        Main.LAF.SetAccDec(Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)axis].MotionProperty.Acceleration));
                        Main.LAF.SetMotionAbsoluteMove(Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)axis].TargetPosition));
                        break;

                    default:
                        break;
                }
            }
        }

        private void btnStopTeachingPosition_Click(object sender, EventArgs e)
        {
            StopTeachingPosition();
        }

        private void StopTeachingPosition()
        {
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                Main.Instance().MotionManager.StopMove(axis);
            }
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
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPosition = outputData;
            }
            else if (labelButton.Name.Contains("Y"))
            {
                lblTargetPositionY.Text = outputData.ToString();
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPosition = outputData;
            }
            else
            {
                lblTargetPositionZ.Text = outputData.ToString();
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition = outputData;
                FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachLineScanControl.lblTargetPositionZValue.Text = outputData.ToString();
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
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_X].TargetPositionOffset = outputData;
            }
            else if (label.Name.Contains("Y"))
            {
                lblOffsetY.Text = outputData.ToString();
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Y].TargetPositionOffset = outputData;
            }
            else if (label.Name.Contains("Z"))
            {
                lblOffsetZ.Text = outputData.ToString();
                TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPositionOffset = outputData;
            }
            else { }
        }

        private void FormMotionPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_formMotionPopupTimer != null)
            {
                _formMotionPopupTimer.Dispose();
                _formMotionPopupTimer = null;
            }

            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

        private void SetAxis_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectedAxis(sender);
        }

        private void SetSelectedAxis(object sender)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                if (checkBox.Name.Contains("X"))
                    _isAvailableAxisX = true;
                else if (checkBox.Name.Contains("Y"))
                    _isAvailableAxisY = true;
                else
                    _isAvailableAxisZ = true;

                checkBox.BackColor = Color.LimeGreen;
            }
            else
            {
                if (checkBox.Name.Contains("X"))
                    _isAvailableAxisX = false;
                else if (checkBox.Name.Contains("Y"))
                    _isAvailableAxisY = false;
                else
                    _isAvailableAxisZ = false;

                checkBox.BackColor = Color.DarkGray;
            }
        }

        private void btnSetCurrentToTarget_Click(object sender, EventArgs e)
        {
            lblTargetPositionZ.Text = lblCurrentPositionZ.Text;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // old
            //UpdateMotionParameter();
            //Main.MotionSave();

            // new
            // PJH_TEST_230112_S
            //Main.SaveMotionParameter();
            // PJH_TEST_230112_E

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
            {
                if (axis == eAxis.None)
                    break;

                _variableParamControlList[(int)axis].SetParameter(_teachingPosition);
            }

            Main.SaveTeachingParameter();
        }

        //private void chkAutoFocusOnOff_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetAutoFocusOnOff(sender);
        //}

        //private void SetAutoFocusOnOff(object sender)
        //{
        //    if (chkAutoFocusOnOff.Checked)
        //        chkAutoFocusOnOff.BackColor = Color.LimeGreen;
        //    else
        //        chkAutoFocusOnOff.BackColor = Color.DarkGray;

        //    AutoFocusOnOff(chkAutoFocusOnOff.Checked);
        //}

        //private void AutoFocusOnOff(bool isOn)
        //{
        //    if (isOn)
        //    {
        //        int negative = Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition - (Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.NegativeSWLimit * Main.LAF.GetPulseResolution()));
        //        int positive = Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition + (Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.NegativeSWLimit * Main.LAF.GetPulseResolution()));

        //        Main.LAF.SetMotionNegativeLimit(negative);
        //        Main.LAF.SetMotionPositiveLimit(positive);
        //    }
        //    else
        //    {
        //        Main.LAF.SetMotionNegativeLimit(0);
        //        Main.LAF.SetMotionPositiveLimit(0);
        //    }

        //    Main.LAF.SetAutoFocusOnOFF(isOn);
        //}

        //private void btnAutoFocusTest_Click(object sender, EventArgs e)
        //{
        //    AutoFocusOnOffTest();
        //}

        //private void AutoFocusOnOffTest()
        //{
        //    if (MessageBox.Show("The Z-axis motion can be moved. Are you sure want to AF ON?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        Main.LAF.SetAutoFocusOnOFF(isOn: true);
        //        btnAutoFocusTest.BackColor = Color.LimeGreen;

        //        Thread.Sleep(1000);

        //        Main.LAF.SetAutoFocusOnOFF(isOn: false);
        //        btnAutoFocusTest.BackColor = Color.DarkGray;
        //    }
        //}

        private void SetCurrentToTeach()
        {
            int cog = Convert.ToInt16(lblCurrentPositionZ.Text);

            Main.LAF.SetFocusPosition(cog);

            Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.CenterOfGravity = cog;
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

        }

        private void lblPitchZValue_Click(object sender, EventArgs e)
        {

        }

        private void btnCommand_Click(object sender, EventArgs e)
        {
            ShowCommandPage();
        }

        private void ShowCommandPage()
        {
            tlpMotionCommand.Visible = true;
            tlpMotionParameter.Visible = false;
        }

        private void btnParameter_Click(object sender, EventArgs e)
        {
            ShowParameterPage();
        }

        private void ShowParameterPage()
        {
            tlpMotionCommand.Visible = false;
            tlpMotionParameter.Visible = true;
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

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_Y, eDirection.CCW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_Y);
        }

        private void btnJogDownY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_Y, eDirection.CW);
        }

        private void btnJogDownY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_Y);
        }

        private void btnJogUpZ_Click(object sender, EventArgs e)
        {
            MoveJog(eAxis.Axis_Z, eDirection.CW);
        }

        private void btnJogDownZ_Click(object sender, EventArgs e)
        {
            MoveJog(eAxis.Axis_Z, eDirection.CCW);
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
    }
}
