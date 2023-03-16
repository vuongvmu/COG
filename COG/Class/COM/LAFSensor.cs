using COG.Class.COM;
using COG.Class.MOTION;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace COG
{
    public class LAFSensor
    {
        // Command
        const string CMD_WRITE_STORE_PERMANENT_PARAMETERS = "write_all_parameters";	    // 이 커맨드는 파라미터를 영구적으로 저장시킬 수 있습니다. (Non-permanent 항목은 제외) 응답시간은 500~1000ms입니다. 이 커맨드는 센서 또는 모터 동작에 영향을 줄 수 있기 때문에, Normal Sensor 구동 중인 경우에는 사용하지 마십시오.
        const string CMD_WRITE_LASER_ONOFF = "uc lasergate";                       // SET Laser On/Off 1= gate laser on, 0= gate laser off
        const string CMD_READ_LASER_ONOFF = "uc lasergate";                             // GET Laser On/Off Status
        const string CMD_WRITE_AF_ONOFF = "uc motiontrack";                             // SET AF On/Off 1= af on, 0= af off
        const string CMD_READ_AF_ONOFF = "uc motiontrack";                              // GET AF On/Off Status
        const string CMD_WRITE_MOTION_ENABLE = "uc motionenable";                       // SET Motor On/Off 1= Motor on, 0= Motor off
        const string CMD_READ_MOTION_ENABLE = "uc motionenable";                        // GET Motor On/Off Status
        const string CMD_WRITE_MOTION_STOP = "uc motionstop";                           // SET Motor Stop
        const string CMD_WRITE_MOTION_ZERO = "uc motionzero";                           // SET Motion Zero Set (mpos value 0)
        const string CMD_WRITE_MOTION_RELATIVE_MOVE = "uc move 0";                      // SET Motion Relative Move (um)
        const string CMD_WRITE_MOTION_ABSOLUTE_MOVE = "uc move 2";                      // SET Motion Absolute Move (um)
        const string CMD_WRITE_MOTION_MAX_SPEED = "uc motionmaxspeed";                  // SET Motion Max Speed (hz)
        const string CMD_WRITE_MOTION_LIMIT_PLUS = "uc motionpluslimit";                // SET Motion Limit(+) Position 
        const string CMD_WRITE_MOTION_LIMIT_MINUS = "uc motionminuslimit";              // SET Motion Limit(-) Position 
        const string CMD_WRITE_FOCUS_POSITION = "uc motionrefpos";                      // SET Focus Position Value (cog)
        const string CMD_READ_STATUS_REPORT = "uc rep cog mpos ls1 ls2";                // GET Sensor Status (cog mpos -limit +limit)
        const string CMD_WRITE_BAUDRATE = "baud %s 0";                                  // SET Focus Position Value (cog)
        const string CMD_WRITE_ACCELDECEL = "uc motionacctcms";                         // SET Motion Acceleration/Deceleration
        const int AF_SENSOR_PORT_RES_WAIT = 200;

        // Default
        const double Z_AXIS_CONTROL_RESOLUTION = 10000.0;                        // 1=0.1um, 10=1um 100 =10um 1000=100um 10000=1mm
        const double Z_AXIS_BALL_SCREW_PITCH = 2.0;                                     // mm
        const int Z_AXIS_MAX_SPEED_HZ = 300000;                                         // Hz

        const int AF_SENSOR_PORT_DEFAULT_BPS = 9600;

        const int RESULT_TIMEOUT = -1;
        const int AF_ON = 1;
        const int AF_OFF = 0;
        const int LASER_ON = 1;
        const int LASER_OFF = 0;
        const int LIMIT_OFF = 0;

        const int HOMING_VELOCITY = 5;                      // mm/s
        const int HOMING_TIMEOUT = 60000;                   // ms
        const double HOMING_SEARCH_DISTANCE = 0.100;        // mm
        const double HOMING_DISTANCE_AWAY_FROM_LIMIT = 0.5; // mm

        const int INDEX_COG = 0;
        const int INDEX_MPOS = 1;
        const int INDEX_MINUS_LIMIT = 2;
        const int INDEX_PLUS_LIMIT = 3;

        const int DETECT_LIMIT_SENSOR = 1;
        const int MAX_BUF_SIZE = 1024;

        private SerialComm serialComm = new SerialComm();
        private bool _isOpen = false;

        private bool _isUpdateThreadStop = false;
        private Thread _updateStatusThread = null;

        public LAFStatus AFStatus = new LAFStatus();
        private static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        public class LAFStatus
        {
            public int CenterOfGravity = 0;
            private int _centerOfGravit
            {
                get { return _centerOfGravit; }
                set { _centerOfGravit = value; }
            }

            public double MPos = 0.0;
            private double _mPos
            {
                get { return _mPos; }
                set { _mPos = value; }
            }

            public bool IsNegativeLimit = false;
            private bool _isNegativeLimit
            {
                get { return _isNegativeLimit; }
                set { _isNegativeLimit = value; }
            }

            public bool IsPositiveLimit = false;
            private bool _isPositiveLimit
            {
                get { return _isPositiveLimit; }
                set { _isPositiveLimit = value; }
            }
        }

        public void Initialize(string comPort, int baudRate)
        {
            if (OpenPort(comPort, baudRate))
            { }
            //SetDefaultParameter();
            else
                Console.WriteLine("Auto Focus Initialize Fail.");
        }

        public bool OpenPort(string comPort, int baudRate)
        {
            if (serialComm == null)
            {
                Console.WriteLine("Serial Object is Null.");
                return false;
            }

            serialComm.Initialize(comPort, baudRate, timeOut:AF_SENSOR_PORT_RES_WAIT );
            _isOpen = true;

            SetDefaultParameter();
            SetLaserOnOff(isOn: true);
            //SetMotionEnable(isOn: true);

            StartUpdateStatusThread();

            return _isOpen;
        }

        public void ClosePort()
        {
            // SetStoreAllParameter();
            //SetLaserOnOff(isOn: false);
            //SetBaudRate(AF_SENSOR_PORT_DEFAULT_BPS);

            serialComm.Terminate();
            Dispose();
      
        }

        private void Dispose()
        {
            _isUpdateThreadStop = true;

            if (_updateStatusThread != null)
                _updateStatusThread = null;
        }

        private string MakeCommand(string command, string value = "")
        {
            if (value == string.Empty)
                return string.Format(";" + command + "\r");
            else
                return string.Format(";" + command + " " + value + "\r");
        }

        public void SetStoreAllParameter()
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_STORE_PERMANENT_PARAMETERS));
        }

        public void SetLaserOnOff(bool isOn)
        {
            if (!_isOpen)
                return;

            string value = Convert.ToInt16(isOn).ToString();
            
            serialComm.SendData(MakeCommand(CMD_WRITE_LASER_ONOFF, value));
        }

        public void GetLaserOnOff()
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_READ_LASER_ONOFF));
        }

        public void SetAutoFocusOnOFF(bool isOn)
        {
            if (!_isOpen)
                return;

            string value = Convert.ToInt16(isOn).ToString();

            serialComm.SendData(MakeCommand(CMD_WRITE_AF_ONOFF, value));
        }

        public bool GetAutoFocusOnOFF()
        {
            if (!_isOpen)
                return false;

            serialComm.SendData(MakeCommand(CMD_READ_AF_ONOFF));

            string receiveData = "";

            receiveData += serialComm.Received;

            if (receiveData == "")
                return false;

            int indexString = receiveData.IndexOf("\r\n\n");
            string tt = receiveData.Substring(indexString, 3);
            char[] dest = new char[10];

            //if ()
            //{

            //}
                return true;
        }

        public void SetMotionEnable(bool isOn)
        {
            if (!_isOpen)
                return;

            string value = Convert.ToInt16(isOn).ToString();

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_ENABLE, value));
        }

        public void GetMotionEnable()
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_READ_MOTION_ENABLE));
        }

        public void SetMotionStop()
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_STOP));
        }

        public void SetMotionZeroSet()
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_ZERO));
        }

        public void SetMotionRelativeMove(eDirection direction, double value)
        {
            if (!_isOpen)
                return;

            if (value * Z_AXIS_CONTROL_RESOLUTION < 1)
                return;

            value = Math.Abs(value);

            int moveAmount = Convert.ToInt32(value * Z_AXIS_CONTROL_RESOLUTION) * (int)direction;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_RELATIVE_MOVE, moveAmount.ToString()));
        }

        public void SetMotionAbsoluteMove(double value)
        {
            if (!_isOpen)
                return;

            int targetPosition = Convert.ToInt32(value * Z_AXIS_CONTROL_RESOLUTION);

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_ABSOLUTE_MOVE, targetPosition.ToString()));
        }

        public void SetMotionMaxSpeed(int value)
        {
            //****Example****
            //[설정값]
            //Ball screw Pitch : 5 mm
            //Control Resolution : 10000 cts / mm-+
            //[입력값]
            //10 mm / sec
            //계산식 : 10[mm / sec] / ((360 / (5[mm] * 10000[cts]) / 360) * 5[mm]) = 100000[Hz]

            //Velocity TO Pulse(Hz) formula

            if (!_isOpen)
                return;

            int maxPulse = Convert.ToInt32(value / ((360.0 / (Z_AXIS_BALL_SCREW_PITCH * Z_AXIS_CONTROL_RESOLUTION) / 360.0) * Z_AXIS_BALL_SCREW_PITCH));
            maxPulse = (maxPulse > Z_AXIS_MAX_SPEED_HZ) ? Z_AXIS_MAX_SPEED_HZ : maxPulse;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_MAX_SPEED, maxPulse.ToString()));
        }

        /// <summary>
        /// Set Positive Limit
        /// </summary>
        /// <param name="value">Unuse - value : 0</param>
        public void SetMotionPositiveLimit(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_LIMIT_PLUS, value.ToString()));
        }

        /// <summary>
        /// Set Negative Limit
        /// </summary>
        /// <param name="value">Unuse - value : 0</param>
        public void SetMotionNegativeLimit(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_MOTION_LIMIT_MINUS, value.ToString()));
        }

        public void SetFocusPosition(int value)
        {
            if (!_isOpen)
                return;

            int offset = (value > 10000) ? 9999 : value;
            offset = (value < -10000) ? -9999 : value;

            serialComm.SendData(MakeCommand(CMD_WRITE_FOCUS_POSITION, offset.ToString()));
        }

        public void StartUpdateStatusThread()
        {
            _isUpdateThreadStop = false;
            _updateStatusThread = new Thread(UpdateStatusThread);
            _updateStatusThread.Start();
        }

        private void UpdateStatusThread()
        {
            while (!_isUpdateThreadStop)
            {
                GetStatusReport();
                Thread.Sleep(300);
            }
        }

        public void GetStatusReport()
        {
            if (!_isOpen)
                return;

           serialComm.SendData(MakeCommand(CMD_READ_STATUS_REPORT));
            sw.Start();
          
            int nIn = 0;
            int nBuffersize = 1024;
            do
            {
                string receiveData = "";
                receiveData += serialComm.Received;
              

                if (receiveData == "")
                    continue;

                if (receiveData.Contains("cog"))
                {
                    string[] readlines = receiveData.Split(new char[] { '\n', '\r' });

                    for (int line = 0; line < readlines.Length; line++)
                    {
                        // 상태 메시지 example
                        // "4\rcog: -2139 mpos: +98050 ls1: 0 ls2: 0 ";
                        if (readlines[line].Contains("MLLAF3"))
                            continue;

                        if (readlines[line].Contains("mpos") && readlines[line].Contains(":") && readlines[line].Contains("cog"))
                        {
                            string[] parsedData = readlines[line].Split(new char[] { ' ', ':', '\r' });

                            int cogIndex = -1;
                            int mposIndex = -1;
                            int ls1Index = -1;
                            int ls2Index = -1;

                            for (int i = 0; i < parsedData.Length; i++)
                            {
                                if (parsedData[i] == "cog")
                                    cogIndex = i;
                                if (parsedData[i] == "mpos")
                                    mposIndex = i;
                                if (parsedData[i] == "ls1")
                                    ls1Index = i;
                                if (parsedData[i] == "ls2")
                                    ls2Index = i;
                            }

                            // cog 값이 있는 곳까지 공백 패스
                            for (int i = cogIndex + 1; i < parsedData.Length; i++)
                            {
                                if (parsedData[i] != "")
                                {
                                    cogIndex = i;
                                    break;
                                }
                            }

                            // mpos 값이 있는 곳까지 공백 패스
                            for (int i = mposIndex + 1; i < parsedData.Length; i++)
                            {
                                if (parsedData[i] != "")
                                {
                                    mposIndex = i;
                                    break;
                                }
                            }

                            // ls1 값이 있는 곳까지 공백 패스
                            for (int i = ls1Index + 1; i < parsedData.Length; i++)
                            {
                                if (parsedData[i] != "")
                                {
                                    ls1Index = i;
                                    break;
                                }
                            }

                            // ls2 값이 있는 곳까지 공백 패스
                            for (int i = ls2Index + 1; i < parsedData.Length; i++)
                            {
                                if (parsedData[i] != "")
                                {
                                    ls2Index = i;
                                    break;
                                }
                            }

                            AFStatus.CenterOfGravity = Convert.ToInt32(parsedData[cogIndex]);
                            AFStatus.MPos = Convert.ToDouble(parsedData[mposIndex]) / Z_AXIS_CONTROL_RESOLUTION;
                            AFStatus.IsNegativeLimit = Convert.ToBoolean(Convert.ToInt32(parsedData[ls1Index]));
                            AFStatus.IsPositiveLimit = Convert.ToBoolean(Convert.ToInt32(parsedData[ls2Index]));
                        }
                    }
                }
            } while (sw.ElapsedMilliseconds < AF_SENSOR_PORT_RES_WAIT && nIn < nBuffersize);
            sw.Stop();
            sw.Reset();
        }

        public void SetBaudRate(int value)
        {
            if (!_isOpen)
                return;

            string temp = value.ToString();
            string command = string.Format(CMD_WRITE_BAUDRATE, temp);
            command = ";" + command + "\r";

            serialComm.SendData(command);
        }

        public void SetAccDec(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(CMD_WRITE_ACCELDECEL, value.ToString()));
        }

        private void SetDefaultParameter()
        {
            SetMotionMaxSpeed(1000);
            SetAccDec(100);
        }

        public double GetPulseResolution()
        {
            return Z_AXIS_CONTROL_RESOLUTION;
        }

        private eHomeSequenceStep _homeSequenceStep = eHomeSequenceStep.Stop;

        private enum eHomeSequenceStep
        {
            Stop,
            Start,

            MoveToNegativeLimit,
            MoveToStep,
            ReleaseNegativeLimitDetection,
            MoveAfterDeceleration1,
            MoveAfterDeceleration2,
            ZeroSet,

            End,
        }

        private bool _isHomeThreadStop = false;
        private Thread _homeThread = null;

        public void StartHomeThread()
        {
            _isHomeThreadStop = false;
            _homeThread = new Thread(HomeSequenceThread);
            _homeThread.Start();
        }

        private void HomeSequenceThread()
        {
            _homeSequenceStep = eHomeSequenceStep.Start;

            while (!_isHomeThreadStop)
            {
                HomeSequenceStep();
                Thread.Sleep(100);
            }
        }

        private void PrepareHome()
        {
            SetMotionNegativeLimit(0);
            SetMotionPositiveLimit(0);
            SetMotionMaxSpeed(1);
            SetMotionZeroSet();
            Thread.Sleep(50);
        }

        private void HomeSequenceStep()
        {
            try
            {
                switch (_homeSequenceStep)
                {
                    case eHomeSequenceStep.Stop:
                        break;

                    case eHomeSequenceStep.Start:
                        PrepareHome();
                        _homeSequenceStep = eHomeSequenceStep.MoveToNegativeLimit;
                        break;

                    case eHomeSequenceStep.MoveToNegativeLimit:
                        if (AFStatus.IsNegativeLimit)
                        {
                            SetMotionStop();
                            Thread.Sleep(1000);

                            SetMotionZeroSet();
                            Thread.Sleep(500);

                            _homeSequenceStep = eHomeSequenceStep.MoveToStep;
                        }
                        break;

                    case eHomeSequenceStep.MoveToStep:
                        SetMotionRelativeMove(eDirection.CCW, HOMING_SEARCH_DISTANCE);
                        _homeSequenceStep = eHomeSequenceStep.ReleaseNegativeLimitDetection;
                        break;

                    case eHomeSequenceStep.ReleaseNegativeLimitDetection:
                        if (!AFStatus.IsNegativeLimit)
                        {
                            SetMotionStop();
                            Thread.Sleep(100);

                            SetMotionZeroSet();
                            Thread.Sleep(500);

                            _homeSequenceStep = eHomeSequenceStep.MoveAfterDeceleration1;
                        }
                        else
                            _homeSequenceStep = eHomeSequenceStep.MoveToStep;
                        break;

                    case eHomeSequenceStep.MoveAfterDeceleration1:
                        if (AFStatus.IsNegativeLimit)
                        {
                            SetMotionStop();
                            Thread.Sleep(100);

                            SetMotionZeroSet();
                            Thread.Sleep(500);

                            _homeSequenceStep = eHomeSequenceStep.MoveAfterDeceleration2;
                        }
                        else
                            SetMotionRelativeMove(eDirection.CW, HOMING_SEARCH_DISTANCE / 10);
                        break;

                    case eHomeSequenceStep.MoveAfterDeceleration2:
                        if (AFStatus.IsNegativeLimit)
                        {
                            SetMotionStop();
                            Thread.Sleep(500);

                            SetMotionZeroSet();
                            Thread.Sleep(500);

                            SetMotionRelativeMove(eDirection.CW, HOMING_DISTANCE_AWAY_FROM_LIMIT);

                            _homeSequenceStep = eHomeSequenceStep.MoveAfterDeceleration2;
                        }
                        else
                            SetMotionRelativeMove(eDirection.CW, HOMING_SEARCH_DISTANCE / 10);
                        break;

                    case eHomeSequenceStep.ZeroSet:
                        if (Math.Abs(AFStatus.MPos - HOMING_DISTANCE_AWAY_FROM_LIMIT) <= float.Epsilon)
                        {
                            SetMotionStop();
                            Thread.Sleep(500);

                            SetMotionZeroSet();
                            Thread.Sleep(100);

                            SetMotionMaxSpeed(15);
                            Thread.Sleep(100);
                            
                            // 대기 위치로 이동 - 포지션 필요함
                            SetMotionAbsoluteMove(0);
                            Thread.Sleep(1000);
                        }
                        _homeSequenceStep = eHomeSequenceStep.End;
                        break;

                    case eHomeSequenceStep.End:
                        _isHomeThreadStop = true;
                        _homeSequenceStep = eHomeSequenceStep.Stop;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _isHomeThreadStop = true;
            }
        }

        // Unuse
        /*
        private eShuttleSequenceStep _shuttleSequenceStep = eShuttleSequenceStep.Stop;
        private enum eShuttleSequenceStep
        {
            Stop,
            Start,

            MoveStartPosition,
            WaitForStartPosition,
            MoveEndPosition,
            WaitForEndPosition,

            End,
        }

        private bool _isShuttleThreadStop = false;
        private Thread _shuttleThread = null;
        public void StartShuttleThread()
        {
            _isShuttleThreadStop = false;
            _shuttleThread = new Thread(ShuttleSequenceThread);
            _shuttleThread.Start();
        }

        private void ShuttleSequenceThread()
        {
            _shuttleSequenceStep = eShuttleSequenceStep.Start;

            while (!_isShuttleThreadStop)   // && 셔틀 동작 플래그 함께 걸 것
            {
                ShuttleSequenceStep();
                Thread.Sleep(100);
            }
        }

        private void ShuttleSequenceStep()
        {
            try
            {
                switch (_shuttleSequenceStep)
                {
                    case eShuttleSequenceStep.Stop:
                        break;

                    case eShuttleSequenceStep.Start:
                        // 준비과정이 필요하다면 이 곳을 활용
                        _shuttleSequenceStep = eShuttleSequenceStep.MoveStartPosition;
                        break;

                    case eShuttleSequenceStep.MoveStartPosition:
                        // 0 : 원하는 시작 위치 넣을 것
                        SetMotionAbsoluteMove(0);
                        _shuttleSequenceStep = eShuttleSequenceStep.WaitForStartPosition;
                        break;

                    case eShuttleSequenceStep.WaitForStartPosition:
                        // 0 : 원하는 시작 위치 넣을 것
                        if (Math.Abs(AFStatus.MPos - 0) <= float.Epsilon)
                        {
                            // 0 : 원하는 딜레이 넣을 것
                            Thread.Sleep(0);
                            _shuttleSequenceStep = eShuttleSequenceStep.MoveEndPosition;
                        }
                        break;

                    case eShuttleSequenceStep.MoveEndPosition:
                        // 0 : 원하는 종료 위치 넣을 것
                        SetMotionAbsoluteMove(0);
                        _shuttleSequenceStep = eShuttleSequenceStep.WaitForEndPosition;
                        break;

                    case eShuttleSequenceStep.WaitForEndPosition:
                        // 0 : 원하는 종료 위치 넣을 것
                        if (Math.Abs(AFStatus.MPos - 0) <= float.Epsilon)
                        {
                            // 0 : 원하는 딜레이 넣을 것
                            Thread.Sleep(0);
                            _shuttleSequenceStep = eShuttleSequenceStep.MoveStartPosition;
                        }
                        break;

                    case eShuttleSequenceStep.End:
                        _isShuttleThreadStop = true;
                        _shuttleSequenceStep = eShuttleSequenceStep.Stop;
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _isShuttleThreadStop = true;
            }
        }
        /**/
    }
}
