using ACS.SPiiPlusNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static COG.Main;

namespace COG.Class.MOTION.ACS
{
    public class ACSMotion : IMotion
    {
        private Api _motion = null;
        private const int _bufferCount = 8;

        private List<MotionProperty> _propertyList = new List<MotionProperty>();
        public List<TeachingPosition> _teachingPositionList = new List<TeachingPosition>();

        private bool _isConnected
        {
            get
            {
                if (_motion != null)
                    return _motion.IsConnected;
                return false;
            }
        }

        public override bool IsConnected()
        {
            return _isConnected;
        }

        public override eConnectionStatus InitializeDevice(eProtocolType protocolType)
        {
            // Create object
            CreateObject();

            bool isConnect = false;

            switch (protocolType)
            {
                case eProtocolType.None:
                    break;

                case eProtocolType.Serial:
                    isConnect = Connect(0, 0);
                    break;

                case eProtocolType.Ethernet:
                    isConnect = Connect("10.0.0.100");
                    break;

                default:
                    break;
            }

            // Stop buffer
            StopBuffer();

            // Compile buffer
            if (GetStateBuffer())
                ExcuteCompileBuffer();

            // Run buffer
            //RunBuffer(startHome : false);

            // Connection status output
            if (isConnect)
                return eConnectionStatus.Done;
            else
                return eConnectionStatus.Connection_Error;
        }

        private void CreateObject()
        {
            if (_motion == null)
                _motion = new Api();
        }

        private bool Connect(int comPort, int baudRate)
        {
            try
            {
                if (_isConnected)
                    return false;

                foreach (var info in _motion.GetConnectionsList())
                {
                    // Except ACS Framework 
                    if (!info.Application.Contains("ACS"))
                        _motion.TerminateConnection(info);
                }

                _motion.OpenCommSerial(comPort, baudRate);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool Connect(string address, bool isTcp = true)
        {
            try
            {
                if (_motion == null)
                    return false;

                //foreach (var info in _motion.GetConnectionsList())
                //{
                //    // Except ACS Framework 
                //    if (!info.Application.Contains("ACS"))
                //        _motion.TerminateConnection(info);
                //}

                // Open ethernet protocol
                if (isTcp)
                    _motion.OpenCommEthernet(address, (int)EthernetCommOption.ACSC_SOCKET_STREAM_PORT);
                else
                    _motion.OpenCommEthernet(address, (int)EthernetCommOption.ACSC_SOCKET_DGRAM_PORT);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private void Release()
        {
            if (_motion.IsConnected)
                _motion.KillAll();

            _motion?.CloseComm();
        }

        public override void Terminate()
        {
            Release();
        }

        public override void ServoOn(eAxis axis)
        {
            if (!_isConnected)
                return;

            _motion.Enable(SetBufferNumberFromAxis(axis));
        }

        public override void ServoOff(eAxis axis)
        {
            if (!_isConnected)
                return;

            _motion.Disable(SetBufferNumberFromAxis(axis));
        }

        public override void AllServoOff()
        {
            if (!_isConnected)
                return;

            _motion.DisableAll();
        }

        public override void StopMove(eAxis axis)
        {
            if (!_isConnected)
                return;

            _motion.Kill(SetBufferNumberFromAxis(axis));
        }

        public override void JogMove(eAxis axis, eDirection direction)
        {
            if (!_isConnected)
                return;

            _motion.Jog(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(axis), (double)direction);
        }

        public override double GetActualPosition(eAxis axis)
        {
            if (!_isConnected)
                return 0;

            return _motion.GetFPosition(SetBufferNumberFromAxis(axis));
        }

        //_propertyList[(int)axis].PositiveSWLimit

        public override void MoveTo(eAxis axis, double targetPosition, double velocity, double accdec)
        {
            if (!_isConnected)
                return;

            SetBasicParameter(axis, velocity, accdec);

            if (ReadyToMove(axis, targetPosition))
                _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(axis), targetPosition);
        }

        private bool ReadyToMove(eAxis axis, double targetPosition)
        {
            // Release axis event
            _motion.FaultClear(SetBufferNumberFromAxis(axis));

            Thread.Sleep(100);

            // Read motor status
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));

            // Check enable to move
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                return false;

            // Check motor's error status
            var error = _motion.GetMotorError(SetBufferNumberFromAxis(axis));
            if (error != (int)MotorStates.ACSC_NONE)
            {
                Console.WriteLine("Motor error has occurred.");
                return false;
            }

            // Check sw limit
            //if (targetPosition < _propertyList[(int)axis].NegativeSWLimit)
            //{
            //    Console.WriteLine("The point to move out of software limit setting. [NAGATIVE_LIMIT]");
            //    return false;
            //}

            //if (targetPosition > _propertyList[(int)axis].PositiveSWLimit)
            //{
            //    Console.WriteLine("The point to move out of software limit setting. [POSITIVE_LIMIT]");
            //    return false;
            //}

            return true;
        }
        //public override void MoveTo(MotionPositionData motionData, eAxis axis, double targetPosition)
        //{
        //    if (!_isConnected)
        //        return;

        //    if (ReadyToMove(motionData, axis))
        //        _motion.ToPointAsync(MotionFlags.ACSC_NONE, (Axis)axis, targetPosition);
        //}

        //private bool ReadyToMove(MotionPositionData axisModel, eAxis axis)
        //{
        //    // Release axis event
        //    _motion.FaultClear((Axis)axis);

        //    Thread.Sleep(100);

        //    // Read motor status
        //    var state = _motion.GetMotorState((Axis)axis);

        //    // Check enable to move
        //    if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
        //        return false;

        //    // Check motor's error status
        //    var error = _motion.GetMotorError((Axis)axis);
        //    if (error != (int)MotorStates.ACSC_NONE)
        //    {
        //        Console.WriteLine("Motor error has occurred.");
        //        return false;
        //    }

        //    // Check sw limit
        //    //if (axisModel.TargetPosition > axisModel.LimitPositive)
        //    //{
        //    //    Console.WriteLine("The point to move out of software limit setting. [POSITIVE_LIMIT]");
        //    //    return false;
        //    //}

        //    //if (axisModel.TargetPosition < axisModel.LimitNegative)
        //    //{
        //    //    Console.WriteLine("The point to move out of software limit setting. [NAGATIVE_LIMIT]");
        //    //    return false;
        //    //}

        //    return true;
        //}

        public override void SetDefaultParameter(eAxis axis, double velocity = 10, double accdec = 10)
        {
            SetBasicParameter(axis, velocity, accdec);
        }

        private void SetBasicParameter(eAxis axis, double velocity, double accdec)
        {
            // Acceleration & Deceleration : 90%, Jerk : 10%
            // Convert Acc & Dec to rate
            double jogAcceleration = Math.Abs(velocity / ((accdec * 0.9) / 1000.0));

            // Convert Jerk time to rate
            double jogJerk = Math.Abs(jogAcceleration / ((accdec * 0.1) / 1000.0));

            _motion.SetVelocity(SetBufferNumberFromAxis(axis), velocity);
            _motion.SetAcceleration(SetBufferNumberFromAxis(axis), jogAcceleration);
            _motion.SetDeceleration(SetBufferNumberFromAxis(axis), jogAcceleration);
            _motion.SetKillDeceleration(SetBufferNumberFromAxis(axis), jogAcceleration * 2);
            _motion.SetJerk(SetBufferNumberFromAxis(axis), jogJerk);
        }

        public override bool WaitForDone(eAxis axis)
        {
            if (WaitForDone(axis))
                return true;
            else
                return false;
        }

        private bool WaitForDone(int nAlignUnitNo, int axis)
        {
            return false;
        }

        private bool WaitForDone(eAxis axis, int timeOut = 10)
        {
            Stopwatch timeoutChecker = new Stopwatch();

            if (!_isConnected)
                return false;

            timeoutChecker.Start();
            while (!IsAxisDone(axis))
            {
                //축 상태 확인
                //if (false == CheckAxisState(_axis))
                //{
                //    //TODO LOG
                //    return ACS_MOTION_RESULT.ERR_AXIS_ALREADY_USED_AXIS_ID;
                //}

                //Amp Fault 확인
                var safetyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
                if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                {
                    //Amp Fault 발생
                    //####ESTOP!!####
                    _motion.KillAll();
                    _motion.Disable(SetBufferNumberFromAxis(axis));

                    Console.WriteLine("Fault occurs in axis Amp.");

                    return false;
                }

                // Check timeout
                if (timeoutChecker.ElapsedMilliseconds / 1000 >= timeOut)
                {
                    Console.WriteLine("Axis movement has exceeded the set time.");
                    return false;
                }

                Thread.Sleep(1);
            }
            timeoutChecker.Reset();

            Console.WriteLine("Axis movement has arrived at its destination.");

            return true;
        }

        private bool IsAxisDone(eAxis axis)
        {
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));
            var position = _motion.GetFPosition(SetBufferNumberFromAxis(axis));

            if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                return true;
            else
                return false;
        }

        public override string GetCurrentMotionStatus(eAxis axis)
        {
            if (!_isConnected)
                return null;

            //모터 상태 읽음
            var state = _motion.GetMotorState(SetBufferNumberFromAxis(axis));
            string strMotorStates = "";

            //사용가능 상태인지, 멈춘 상태인지, 이동중이 아닌지 확인
            if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE))
                strMotorStates = "MOVING";
            else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                strMotorStates = "STOP";
            else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                strMotorStates = "NOT ENABLE";
            else
                strMotorStates = "NORMAL";

            return strMotorStates;
        }

        public override void StartHome(eAxis axis)
        {
            Home(axis);
        }

        private void Home(eAxis axis)
        {
            if (!_isConnected)
                return;

            // 기존
            // Home
            //RunBuffer(startHome: true);

            // 신규1
            //switch (axis)
            //{
            //    case eAxis.None:
            //        break;

            //    case eAxis.Axis_X:
            //        _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_0, null);
            //        break;

            //    case eAxis.Axis_Y:
            //        _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_8, null);
            //        break;

            //    case eAxis.Axis_Z:
            //        break;

            //    default:
            //        break;
            //}

            // 신규2
            _motion.RunBuffer((ProgramBuffer)SetBufferNumberFromAxis(axis), null);
        }

        // 축 수정 안함
        private void RunBuffer(bool startHome)
        {
            if (!_isConnected)
                return;

            // Stop Buffer
            StopBuffer();

            // Run buffer
            // Buffer 0 : X Axis - Home + Control
            if (startHome)
                _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_0, null);
            else
            {
                // Buffer 3 : Trigger signal anage
                _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_3, null);

                // Buffer 5 : Z Axis - Home + Control
                _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_5, null);

                // Buffer 8 : Trigger dispense
                _motion.RunBuffer(ProgramBuffer.ACSC_BUFFER_8, null);
            }
        }

        // 축 수정 안함
        private void StopBuffer()
        {
            if (!_isConnected)
                return;

            // Stop buffer
            // Buffer 0 : X Axis - Home + Control
            _motion.StopBuffer(ProgramBuffer.ACSC_BUFFER_0);

            // Buffer 3 : Trigger signal anage
            _motion.StopBuffer(ProgramBuffer.ACSC_BUFFER_3);

            // Buffer 5 : Z Axis - Home + Control
            _motion.StopBuffer(ProgramBuffer.ACSC_BUFFER_5);

            // Buffer 8 : Trigger dispense
            _motion.StopBuffer(ProgramBuffer.ACSC_BUFFER_8);
        }

        // 축 수정 안함
        private bool GetStateBuffer()
        {
            if (!_isConnected)
                return false;

            ProgramStates programState = ProgramStates.ACSC_NONE;

            programState =_motion.GetProgramState(ProgramBuffer.ACSC_BUFFER_0);
            if (programState != ProgramStates.ACSC_PST_COMPILED)
            {
                Console.WriteLine("Buffer 0 state is not none.");
                return false;
            }

            programState = _motion.GetProgramState(ProgramBuffer.ACSC_BUFFER_3);
            if (programState != ProgramStates.ACSC_PST_COMPILED)
            {
                Console.WriteLine("Buffer 3 state is not none.");
                return false;
            }

            programState = _motion.GetProgramState(ProgramBuffer.ACSC_BUFFER_5);
            if (programState != ProgramStates.ACSC_PST_COMPILED)
            {
                Console.WriteLine("Buffer 5 state is not none.");
                return false;
            }

            programState = _motion.GetProgramState(ProgramBuffer.ACSC_BUFFER_8);
            if (programState != ProgramStates.ACSC_PST_COMPILED)
            {
                Console.WriteLine("Buffer 8 state is not none.");
                return false;
            }

            Console.WriteLine("All Buffer state is done.");
            return true;
        }

        private void ExcuteCompileBuffer()
        {
            if (!_isConnected)
                return;

            /*
            // Buffer 0 : X Axis - Home + Control
            _motion.CompileBuffer(ProgramBuffer.ACSC_BUFFER_0);
            
            // Buffer 3 : Trigger signal anage
            _motion.CompileBuffer(ProgramBuffer.ACSC_BUFFER_3);

            // Buffer 5 : Z Axis - Home + Control
            _motion.CompileBuffer(ProgramBuffer.ACSC_BUFFER_5);

            // Buffer 8 : Trigger dispense
            _motion.CompileBuffer(ProgramBuffer.ACSC_BUFFER_8);
            /**/

            foreach (eAxis axis in Enum.GetValues(typeof(eAxis)))
                _motion.CompileBuffer((ProgramBuffer)SetBufferNumberFromAxis(axis));
        }

        // Repeat
        private Thread _repeatThread = null;
        private double _startPosition = 0.0;
        private double _endPosition = 0.0;
        private int _setRepeatCount = 0;
        private int _repeatCount = 0;
        private int _remainRepeatCount = 0;
        private bool _isRepeat = false;
        private int _dwellTime = 0;
        private bool _infiniteRepeat = false;

        public override void SetRepeatFlag(bool isRepeat)
        {
            if (!isRepeat)
                _infiniteRepeat = false;

            this._isRepeat = isRepeat;
        }

        public override int GetRemainRepeatCount()
        {
            return _remainRepeatCount;
        }

        public override int GetRepeatCount()
        {
            return _repeatCount;
        }

        public override void MoveRepeat(eAxis axis, double startPosition, double endPosition, int setRepeatCount, int dwellTime)
        {
            if (startPosition == endPosition)
            {
                Console.WriteLine("The StartPosition is the same as the EndPosition.");
                return;
            }

            if (setRepeatCount == 0)
                _infiniteRepeat = true;

            _isRepeat = true;
            _repeatCount = 0;

            _startPosition = startPosition;
            _endPosition = endPosition;
            _setRepeatCount = setRepeatCount;
            _remainRepeatCount = setRepeatCount;
            _dwellTime = dwellTime;

            _repeatThread = new Thread(new ParameterizedThreadStart(this.MoveRepeatThread));
            _repeatThread.Start(axis);
        }

        private void MoveRepeatThread(object obj)
        {
            int axis = Convert.ToInt16(obj);
            eAxis enumAxis = (eAxis)axis;

            while (_isRepeat)
            {
                //_motion.ToPointAsync(MotionFlags.ACSC_NONE, (Axis)axis, _startPosition);
                _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _startPosition);

                while (!WaitForDone((eAxis)axis))
                    //Thread.Sleep(1);
                    Thread.Sleep(_dwellTime);

                int Scanid = 1, TabCnt = 1;
                double dist = Math.Abs(_endPosition - _startPosition);
                Main.MilFrameGrabber.QueueClear();
                Main.MilFrameGrabber.GrabLineScan(Scanid, TabCnt, 0, dist);
                _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _endPosition);

                while (!WaitForDone((eAxis)axis))
                    //Thread.Sleep(1);
                    Thread.Sleep(_dwellTime);

                _motion.ToPointAsync(MotionFlags.ACSC_NONE, SetBufferNumberFromAxis(enumAxis), _startPosition);

                while (!WaitForDone((eAxis)axis))
                    //Thread.Sleep(1);
                    Thread.Sleep(_dwellTime);

                _remainRepeatCount--;

                if (_setRepeatCount == ++_repeatCount)
                    _isRepeat = false;

                if (_infiniteRepeat)
                {
                    _isRepeat = true;
                    _remainRepeatCount = 0;
                }

                Console.WriteLine("Set Repeat Count : " + _setRepeatCount.ToString() + " / " + "Remain Count : " + _remainRepeatCount.ToString() + " / " + "Repeat Count : " + _repeatCount.ToString());
            }
        }

        public override void StopRepeat()
        {
            _isRepeat = false;
        }
        //public override void SetProperty(/*object param*/)
        //{
        //    //this._property.Add((MotionProperty)param);
        //    //this._property = Main.MotionPropertyList.cop;
        //    if (!_isConnected)
        //        return;

        //    //this._propertyList = Main.MotionPropertyList.ConvertAll(MotionProperty => MotionProperty.Copy());
        //    this._propertyList = Main.MotionPropertyList.ConvertAll(MotionProperty => MotionProperty.Copy());

        //    int axisCount = 0;
        //    foreach (var item in _propertyList)
        //    {
        //        // Acceleration & Deceleration : 90%, Jerk : 10%
        //        // Convert Acc & Dec to rate
        //        double jogAcceleration = Math.Abs(item.Velocity / ((item.Acceleration * 0.9) / 1000.0));

        //        // Convert Jerk time to rate
        //        double jogJerk = Math.Abs(jogAcceleration / ((item.Acceleration * 0.1) / 1000.0));

        //        _motion.SetVelocity((Axis)axisCount, item.Velocity);
        //        _motion.SetAcceleration((Axis)axisCount, jogAcceleration);
        //        _motion.SetDeceleration((Axis)axisCount, jogAcceleration);
        //        _motion.SetKillDeceleration((Axis)axisCount, jogAcceleration * 2);
        //        _motion.SetJerk((Axis)axisCount, jogJerk);

        //        axisCount++;
        //    }
        //}

        public override bool IsNegativeLimit(eAxis axis)
        {
            if (!_isConnected)
                return false;
            var saftyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
            if (saftyFlag == SafetyControlMasks.ACSC_SAFETY_LL)
            {
                return true;
            }
            return false;
            //if (!_isConnected)
            //    return false;

            ////return (SafetyControlMasks.ACSC_SAFETY_LL == _motion.GetSafetyInput((Axis)axis, SafetyControlMasks.ACSC_SAFETY_LL));
            //return (SafetyControlMasks.ACSC_SAFETY_LL == _motion.GetSafetyInput(SetBufferNumberFromAxis(axis), SafetyControlMasks.ACSC_SAFETY_LL));
        }

        public override bool IsPositiveLimit(eAxis axis)
        {
            if (!_isConnected)
                return false;
            var saftyFlag = _motion.GetFault(SetBufferNumberFromAxis(axis));
            if(saftyFlag == SafetyControlMasks.ACSC_SAFETY_RL)
            {
                return true;
            }
            return false;
            //if (!_isConnected)
            //    return false;

            ////return (SafetyControlMasks.ACSC_SAFETY_RL == _motion.GetSafetyInput((Axis)axis, SafetyControlMasks.ACSC_SAFETY_RL))
            //return (SafetyControlMasks.ACSC_SAFETY_RL == _motion.GetSafetyInput(SetBufferNumberFromAxis(axis), SafetyControlMasks.ACSC_SAFETY_RL));
        }

        private Axis SetBufferNumberFromAxis(eAxis axis)
        {
            Axis convertAxis = Axis.ACSC_AXIS_0;

            switch (axis)
            {
                case eAxis.None:
                    break;

                case eAxis.Axis_X:
                    convertAxis = Axis.ACSC_AXIS_0;
                    break;

                case eAxis.Axis_Y:
                    convertAxis = Axis.ACSC_AXIS_8;
                    break;

                case eAxis.Axis_Z:
                    break;

                default:
                    break;
            }

            return convertAxis;
        }
    }
}
