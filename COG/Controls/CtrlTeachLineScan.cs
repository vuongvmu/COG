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
using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using COG.Class;

namespace COG.Controls
{
    public partial class CtrlTeachLineScan : UserControl
    {
        private CogRecordDisplay _teachingDisplay = new CogRecordDisplay();

        enum Mode { TDI = 0, Area = 1, FreeRun = 0, Trigger = 1 }
        private System.Threading.Timer _timer = null;
        private System.Threading.Timer GrabTimer = null;
        

        private bool _isRepeat = false;
        private int _repeatCount = 0;

        private int _tabNumber = 0;
        private int _tabMaxCount = Main.DEFINE.TAP_UNIT_MAX;

        // YP_S
        CogGraphicInteractiveCollection cogGraphic;

        public System.Windows.Forms.DataVisualization.Charting.Series Chart1;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart2;

        private CogRectangle _cogRect = null;
        private CogRectangle CenterRect = null;
        private bool bHistogramFunction = false;
        CogImage8Grey HistogramImage = null;
        // YP_E
        private double dExposureTime = 60000;
        public eGrabMode _grabMode = eGrabMode.None;
        public double ScanLenth = 0;
        public enum eGrabMode
        {
            None,
            AreaMode,
            LineMode,
        }


        private eDirection _direction = eDirection.CW;
        private eJogSpeedMode _jogSpeedMode = eJogSpeedMode.Slow;
        private eJogMode _jogMode = eJogMode.Jog;

        private eTeachingPosition _teachingPosition = eTeachingPosition.Stage1_PreAlign_Left;
        private eStageNo _stageNo = eStageNo.Stage1;
        private eCameraNo _camNo = eCameraNo.Inspection1;


        public CtrlTeachLineScan(eTeachingPosition teachingPosition)
        {
            InitializeComponent();
            //SetUnitIndex(stageNo, camNo);
            SetTeachingUnitDevice(teachingPosition);
            
        }

        //private void SetUnitIndex(eStageNo stageNo, eCameraNo camNo)
        //{
        //    // PJH_TEST_20230306_S
        //    //_stageNo = stageNo;
        //    //_camNo = camNo;
        //    _stageNo = 0;
        //    _camNo = 0;
        //    // PJH_TEST_20230306_E
        //}

        private void SetTeachingUnitDevice(eTeachingPosition teachingPosition)
        {
            _teachingPosition = teachingPosition;

            switch (teachingPosition)
            {
                case eTeachingPosition.Standby:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_PreAlign_Left:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_PreAlign_Right:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.PreAlign;
                    break;

                case eTeachingPosition.Stage1_Scan_Start:
                    _stageNo = eStageNo.Stage1;
                    _camNo = eCameraNo.Inspection1;
                    break;

                default:
                    break;
            }
        }

        private void CtrlTeachAutoFocus_Load(object sender, EventArgs e)
        {
            StartTimer();
            AddControl();
            InitializeUI();
            //UpdateData();
        }

        private void AddControl()
        {
            _teachingDisplay = FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachDisplay;
        }

        private void InitializeUI()
        {
            lblOperationAxis.Text = Main.machine.LineScanAxis.ToString().ToUpper().Replace("_", " ");

            rdoLineMode.Checked = true;
            rdoForward.Checked = true;
            rdoJogSlowMode.Checked = true;
            rdoIncreaseMode.Checked = true;
        }

        private void UpdateData()
        {
            //teachingPosition.OpticParam.ExposureTime
            if (eGrabMode.AreaMode == _grabMode)
                lblCameraExposureValue.Text = Main.TeachingPositionList[(int)_teachingPosition].OpticParam.ExposureTime.ToString();
            else
                lblCameraExposureValue.Text = Main.TeachingPositionList[(int)_teachingPosition].OpticParam.DigitalGain.ToString();

            lblCameraGainValue.Text = Main.TeachingPositionList[(int)_teachingPosition].OpticParam.AnalogGain.ToString();
            nudLightDimmingLevel.Text = Main.TeachingPositionList[(int)_teachingPosition].OpticParam.LightLevel.ToString();

            lblTargetPositionZValue.Text = Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition.ToString("F3");
            lblTeachCogValue.Text = Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.CenterOfGravity.ToString();
        }

        private void StartTimer()
        {
            _timer = new System.Threading.Timer(UpdateUI, null, 1000, 500);
        }

        private void StartGrabTimer()
        {
            GrabTimer = new System.Threading.Timer(AreaGrab, null, 100, 100);
        }

        private void StopGrabTimer()
        {
            if(GrabTimer != null)
               GrabTimer.Dispose();
        }

        private delegate void AreaGrabDelegate(object obj);
        private void AreaGrab(object obj)
        {
            if(this.InvokeRequired)
            {
                AreaGrabDelegate Callback = AreaGrab;
                BeginInvoke(Callback, obj);
                return;
            }

            GrabImage();
        }

        private void GrabImage()
        {
            int Width = 0, Height = 0;
            byte[] data = Main.MilFrameGrabber.Get_Image(out Width, out Height);
            if(data != null)
                _teachingDisplay.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(data, Width, Height);
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

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            UpdateMotionStatus();
            UpdateRepeatCount();
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
                            lblCurrentPositionXValue.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString("F3");

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitX.BackColor = Color.Red;
                            else
                                lblNegativeLimitX.BackColor = Color.Silver;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitX.BackColor = Color.Red;
                            else
                                lblPositiveLimitX.BackColor = Color.Silver;
                            break;

                        case eAxis.Axis_Y:
                            // Update Current Position
                            lblCurrentPositionYValue.Text = Main.Instance().MotionManager.GetActualPosition(axis).ToString("F3");

                            // Update Negative Limit Sensor
                            if (Main.Instance().MotionManager.IsNegativeLimit(axis))
                                lblNegativeLimitY.BackColor = Color.Red;
                            else
                                lblNegativeLimitY.BackColor = Color.Silver;

                            // Update Positive Limit Sensor
                            if (Main.Instance().MotionManager.IsPositiveLimit(axis))
                                lblPositiveLimitY.BackColor = Color.Red;
                            else
                                lblPositiveLimitY.BackColor = Color.Silver;
                            break;

                        case eAxis.Axis_Z:
                            // Update Current Position
                            lblCurrentPositionZValue.Text = Main.LAF.AFStatus.MPos.ToString("F3");
                            lblCuttentPositionZ.Text = Main.LAF.AFStatus.MPos.ToString("F3");
                            lblCurrentCogValue.Text = Main.LAF.AFStatus.CenterOfGravity.ToString();

                            // Update Negative Limit Sensor
                            if (Main.LAF.AFStatus.IsNegativeLimit)
                                lblNegativeLimitZ.BackColor = Color.Red;
                            else
                                lblNegativeLimitZ.BackColor = Color.Silver;

                            // Update Positive Limit Sensor
                            if (Main.LAF.AFStatus.IsPositiveLimit)
                                lblPositiveLimitZ.BackColor = Color.Red;
                            else
                                lblPositiveLimitZ.BackColor = Color.Silver;
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

        private void UpdateRepeatCount()
        {
            if (!_isRepeat)
                return;

            lblRepeatRemain.Text = Main.Instance().MotionManager.GetRemainRepeatCount() + " / " + _repeatCount;
        }

        #region Load Image
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
                if (Main.vision.CogImgTool[0] == null)
                    Main.vision.CogImgTool[0] = new CogImageFileTool();

                Main.GetImageFile(Main.vision.CogImgTool[0], ofd.FileName);
                Main.vision.CogCamBuf[0] = Main.vision.CogImgTool[0].OutputImage;
            }

            //ClearGraphic();
            //PT_Display01.Image = Main.AlignUnit[0].PAT[0, tabNumber].m_CogLineScanBuf;

            _teachingDisplay.Image = Main.vision.CogCamBuf[0];
            Main.DisplayRefresh(_teachingDisplay);
        }
        #endregion

        private void rdoGrabType_CheckedChanged(object sender, EventArgs e)
        {
            SetSelecteGrabType(sender);
        }

        private void SetSelecteGrabType(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Text.ToLower().Contains("area"))
                    ShowUpdateUI(eGrabMode.AreaMode);
                else
                    ShowUpdateUI(eGrabMode.LineMode);

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;

            UpdateData();
            FormMain.Instance().SelectUnitForm.VisionTeachForm.ButtonRename();
        }

        private void ShowUpdateUI(eGrabMode grabMode)
        {
            switch (grabMode)
            {
                case eGrabMode.None:
                    break;

                case eGrabMode.AreaMode:
                    ShowAreaMode();
                    break;

                case eGrabMode.LineMode:
                    ShowLineMode();
                    break;

                default:
                    break;
            }
        }

        private void ShowAreaMode()
        {
            _grabMode = eGrabMode.AreaMode;
            //btnGrabStart.Text = "LIVE";
            //btnGrabStop.Text = "STOP";
            //pnlLineMode.Visible = false;

            lblCameraExposure.Text = "EXPOSURE [us]";
           // Main.VieworksLineScanCamera.SetSensorMode((int)Mode.FreeRun);
            Main.VieworksLineScanCamera.SetSensorMode((int)Mode.Area);
            Main.VieworksLineScanCamera.SetOutputMode((int)Mode.FreeRun);
            //Main.VieworksLineScanCamera.SetExposureTime(dExposureTime);
            //Main.VieworksLineScanCamera.SetDigitalGain(1);
            //Main.VieworksLineScanCamera.SetAnalogGain(1);
        }

        private void ShowLineMode()
        {
            StopGrabTimer();
            _grabMode = eGrabMode.LineMode;
            //btnGrabStart.Text = "GRAB START";
            //btnGrabStop.Text = "GRAB STOP";
            //pnlLineMode.Visible = true;

            lblCameraExposure.Text = "D GAIN (0 ~ 8[dB])";
            Main.VieworksLineScanCamera.SetSensorMode((int)Mode.TDI);
            Main.VieworksLineScanCamera.SetOutputMode((int)Mode.Trigger);
            // Main.VieworksLineScanCamera.SetSensorMode((int)Mode.Trigger);

            // 조명 및 게인 로딩 시 입력
            //Main.VieworksLineScanCamera.SetDigitalGain(1);
            //Main.VieworksLineScanCamera.SetAnalogGain(1);
        }

        

        private void Get_LineScanImage(int nScan, int nScence)
        {
            _teachingDisplay.Image = Main.AlignUnit[0].PAT[nScan, nScence].m_CogLineScanBuf;
            _teachingDisplay.Fit();
        }

        private void lblCameraExposureValue_Click(object sender, EventArgs e)
        {
            SetCameraExposure(sender);
        }

        private int _exposureTime = 0;
        private double _digitalGain = 0.0;
        private int _analogGain = 0;
        //private int _lightLevel = 0;

        private void SetCameraExposure(object sender)
        {
            Label lbl = sender as Label;

            int outputData = 0;
            int Maxdata = 0;
            if (eGrabMode.AreaMode == _grabMode)
            {
                Maxdata = 100000;
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, Maxdata, outputData, "Input Expousretime", 1))
                {
                    form_keypad.ShowDialog();
                    outputData = (int)form_keypad.m_data;
                    lbl.Text = outputData.ToString();

                    _exposureTime = outputData;
                    Main.VieworksLineScanCamera.SetExposureTime(_exposureTime);
                }
            }
            else
            {
                Maxdata = 8;
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, Maxdata, outputData, "Input DigtalGain", 1))
                {
                    form_keypad.ShowDialog();
                    outputData = (int)form_keypad.m_data;
                    lbl.Text = outputData.ToString();

                    _digitalGain = outputData;
                    Main.VieworksLineScanCamera.SetDigitalGain(_digitalGain);
                }
            }
        
        }

        private void lblCameraGainValue_Click(object sender, EventArgs e)
        {
            SetCameraGain(sender);
        }

        private void SetCameraGain(object sender)
        {
            Label lbl = sender as Label;
            int outputData = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 4, outputData, "Input Expousretime", 1))
            {
                form_keypad.ShowDialog();
                outputData = (int)form_keypad.m_data;
                lbl.Text = outputData.ToString();

                _analogGain = outputData;
                Main.VieworksLineScanCamera.SetAnalogGain(_analogGain);
            }
        }

        private void trbDimmingLevelValue_Scroll(object sender, EventArgs e)
        {
            SetLightDimmingLevel(sender);
        }

        private void nudLightDimmingLevel_ValueChanged(object sender, EventArgs e)
        {
            SetLightDimmingLevel(sender);
        }

        private void SetLightDimmingLevel(object sender)
        {
            int level = 0;

            Control ctr = sender as Control;

            if (ctr.GetType().Name.ToLower() == "trackbar")
            {
                nudLightDimmingLevel.Text = trbDimmingLevelValue.Value.ToString();
                level = Convert.ToInt32(nudLightDimmingLevel.Text);
            }
            else if (ctr.GetType().Name.ToLower() == "numericupdown")
            {
                trbDimmingLevelValue.Value = Convert.ToInt32(nudLightDimmingLevel.Text);
                level = trbDimmingLevelValue.Value;
            }
            else { }

            
            Main.AlignUnit[0].PAT[0, 0].SetLight(LightNum: 0, m_Value: level);
            Main.AlignUnit[0].PAT[0, 0].m_LightValue[0, 0] = level;
        }

        private void lblLigntOn_Click(object sender, EventArgs e)
        {
            LightOnOff(true);
        }

        private void lblLigntOff_Click(object sender, EventArgs e)
        {
            LightOnOff(false);
        }

        private void LightOnOff(bool isOn)
        {

        }

        private bool _isAvailableAxisX = false;
        private bool _isAvailableAxisY = false;
        private bool _isAvailableAxisZ = false;

        #region Repeat
        private void lblTargetVelocityXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTargetAccelerationXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblDwellTimeValue_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void lblTargetPositionZValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTeachCogValue_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void lblScanXLength_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void rdoScanDirection_CheckedChanged(object sender, EventArgs e)
        {
            SetSelecteScanDirection(sender);
        }

        private void SetSelecteScanDirection(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Text.ToLower().Contains("forward"))
                SetScanDirection(eDirection.CW);
            else
                SetScanDirection(eDirection.CCW);

            if (btn.Checked)
                btn.BackColor = Color.LimeGreen;
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetScanDirection(eDirection direction)
        {
            _direction = direction;
        }

        private void lblRepeatCount_Click(object sender, EventArgs e)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            int outputData = (int)formKeyPad.m_data;
            lblRepeatCount.Text = outputData.ToString();
        }

        //private void btnRepeatStart_Click(object sender, EventArgs e)
        //{
        //    SetRepeatParameter();
        //    MoveRepeat();
        //}

        public void SetRepeatParameter()
        {
            //double velocity = Convert.ToDouble(lblVelocityValue.Text);
            //double accdec = Convert.ToDouble(lblAccelationValue.Text);
            double velocity = Convert.ToDouble(lblRepeatVelocityValue.Text);
            double accdec = Convert.ToDouble(lblRepeatAccelerationValue.Text);

            if (velocity <= 0 || accdec <= 0)
            {
                MessageBox.Show("Check the parameters");
                return;
            }

            Main.Instance().MotionManager.SetDefaultParameter(eAxis.Axis_X, velocity, accdec);
        }

        public void MoveRepeat()
        {
            _isRepeat = true;
            _repeatCount = Convert.ToInt32(lblRepeatCount.Text);

            double currentPosition = Main.Instance().MotionManager.GetActualPosition(eAxis.Axis_X);
            int repeatCount = Convert.ToInt32(lblRepeatCount.Text);
            int dwellTime = Convert.ToInt32(lblDwellTimeValue.Text);

            double startPosition = 0.0;
            double endPosition = 0.0;

            startPosition = currentPosition;
            endPosition = Convert.ToDouble(lblScanXLength.Text);

            if (_direction == eDirection.CCW)
                Main.Instance().MotionManager.MoveRepeat(eAxis.Axis_X, startPosition, startPosition - endPosition, repeatCount, dwellTime);
            else
                Main.Instance().MotionManager.MoveRepeat(eAxis.Axis_X, startPosition, startPosition + endPosition, repeatCount, dwellTime);

            //switch (_scanMode)
            //{
            //    case eScanMode.None:
            //        break;

            //    case eScanMode.Range:
            //        startPosition = Convert.ToDouble(lblScanXRangeStart.Text);
            //        endPosition = Convert.ToDouble(lblScanXRangeEnd.Text);
            //        Main.Instance().MotionManager.MoveRepeat(eAxis.Axis_X, startPosition, endPosition, repeatCount);
            //        break;

            //    case eScanMode.Length:
            //        startPosition = currentPosition;
            //        endPosition = Convert.ToDouble(lblScanXLength.Text);

            //        if (_direction == eDirection.CW)
            //            Main.Instance().MotionManager.MoveRepeat(eAxis.Axis_X, startPosition, startPosition - endPosition, repeatCount);
            //        else
            //            Main.Instance().MotionManager.MoveRepeat(eAxis.Axis_X, startPosition, startPosition + endPosition, repeatCount);
            //        break;

            //    default:
            //        break;
            //}
        }

        //private void btnRepeatStop_Click(object sender, EventArgs e)
        //{
        //    RepeatStop();
        //}

        public void RepeatStop()
        {
            Main.Instance().MotionManager.SetRepeatFlag(false);
            Main.Instance().MotionManager.StopMove(eAxis.Axis_X);
        }
        #endregion

        private void btnCurrentToTeach_Click(object sender, EventArgs e)
        {
            SetCurrentToTeach();
        }

        private void SetCurrentToTeach()
        {
            int cog = Convert.ToInt32(lblCurrentCogValue.Text);

            Main.LAF.SetFocusPosition(cog);

            //Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.CenterOfGravity = cog;
            lblTeachCogValue.Text = cog.ToString();
        }

        private void btnSetCurrentToTarget_Click(object sender, EventArgs e)
        {
            lblTargetPositionZValue.Text = lblCurrentPositionZValue.Text;
        }

        public void Save()
        {
            if (eGrabMode.AreaMode == _grabMode)
                Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].OpticParam.ExposureTime = Convert.ToInt32(lblCameraExposureValue.Text);
            else
                Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].OpticParam.DigitalGain = Convert.ToDouble(lblCameraExposureValue.Text);

            Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].OpticParam.AnalogGain = Convert.ToInt32(lblCameraGainValue.Text);
            Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].OpticParam.LightLevel = Convert.ToInt32(nudLightDimmingLevel.Text);

            Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition = Convert.ToDouble(lblTargetPositionZValue.Text);
            Main.TeachingPositionList[(int)eTeachingPosition.Stage1_Scan_Start].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.CenterOfGravity = Convert.ToInt32(lblTeachCogValue.Text);

            Main.SaveTeachingParameter();
        }

        
        /*
        private void btnStopTeachingPosition_Click(object sender, EventArgs e)
        {

        }

        private void btnMoveTeachingPosition_Click(object sender, EventArgs e)
        {

        }

        private void btnAutoFocusTest_Click(object sender, EventArgs e)
        {

        }

        private void chkAutoFocusOnOff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMoveTargetPosition_Click(object sender, EventArgs e)
        {
            MoveTeachingPosition();
        }

        private eTeachingPosition _teachingPosition = eTeachingPosition.Standby;
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
        */

        #region Jog Move
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
            SetLabelDoubleData(sender);
        }

        private void lblPitchZValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void btnJogLeftX_Click(object sender, EventArgs e)
        {

        }

        private void btnJogLeftX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_X, eDirection.CCW);
        }

        private void btnJogLeftX_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_X);
        }

        private void btnJogRightX_Click(object sender, EventArgs e)
        {

        }

        private void btnJogRightX_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_X, eDirection.CW);
        }

        private void btnJogRightX_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_X);
        }

        private void btnJogUpY_Click(object sender, EventArgs e)
        {

        }

        private void btnJogUpY_MouseDown(object sender, MouseEventArgs e)
        {
            MoveJog(eAxis.Axis_Y, eDirection.CCW);
        }

        private void btnJogUpY_MouseUp(object sender, MouseEventArgs e)
        {
            MoveStop(eAxis.Axis_Y);
        }

        private void btnJogDownY_Click(object sender, EventArgs e)
        {

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

        private void MoveJog(eAxis axis, eDirection direction)
        {
            if (axis == eAxis.None)
                return;

            bool isScaleMode = rdoIncreaseMode.Checked;
            double targetPosition = 0.0;
            double scaleValue = 0.0;

            switch (axis)
            {
                case eAxis.None:
                    break;

                case eAxis.Axis_X:
                    targetPosition = Convert.ToDouble(lblCurrentPositionXValue.Text);
                    scaleValue = Convert.ToDouble(lblPitchXYValue.Text);
                    break;

                case eAxis.Axis_Y:
                    targetPosition = Convert.ToDouble(lblCurrentPositionYValue.Text);
                    scaleValue = Convert.ToDouble(lblPitchXYValue.Text);
                    break;

                case eAxis.Axis_Z:
                    targetPosition = Convert.ToDouble(lblCurrentPositionZValue.Text);
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

        private void AllMoveStop()
        {
            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                MoveStop(axis);
        }
        #endregion Jog Move

        

        private void SetLabelDoubleData(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label labelButton = sender as Label;

            labelButton.Text = outputData.ToString("F3");
            if (labelButton.Name.CompareTo("lblScanXLength") == 0)
                ScanLenth = outputData;
        }

        private void SetLabelIntegerData(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            int outputData = (int)formKeyPad.m_data;

            Label labelButton = sender as Label;

            labelButton.Text = outputData.ToString();
        }

        private void bnAFOn_Click(object sender, EventArgs e)
        {
            AutoFocusOnOff(true);
        }

        private void btnAFOff_Click(object sender, EventArgs e)
        {
            AutoFocusOnOff(false);
        }

        private void AutoFocusOnOff(bool isOn)
        {
            if (isOn)
            {
                int negative = Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition - (Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.NegativeSWLimit * Main.LAF.GetPulseResolution()));
                int positive = Convert.ToInt32(Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].TargetPosition + (Main.TeachingPositionList[(int)_teachingPosition].UnitPositionList[(int)eAxis.Axis_Z].MotionProperty.PositiveSWLimit * Main.LAF.GetPulseResolution()));

                Main.LAF.SetMotionNegativeLimit(negative);
                Main.LAF.SetMotionPositiveLimit(positive);
            }
            else
            {
                Main.LAF.SetMotionNegativeLimit(0);
                Main.LAF.SetMotionPositiveLimit(0);
            }

            Main.LAF.SetAutoFocusOnOFF(isOn);
        }
    }
}
