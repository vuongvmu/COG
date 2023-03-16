using ACS.SPiiPlusNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

//TODO
//Exception 발생시 에러 핸들러 추가 -> Messagebox 표시.

namespace COG
{
    public partial class Main
    {
        public static ACSMotion MotionCtrl = ACSMotion.GetInstance();
        public class ACSMotion
        {
            private static ACSMotion instance;
            public static ACSMotion GetInstance()
            {
                if (instance == null)
                    instance = new ACSMotion();

                return instance;
            }

            #region Property
            public Api Motion { get; private set; }
            public int PortNumber { get; set; }
            public int BandRate { get; set; }
            public bool IsConnected
            {
                get
                {
                    if (Motion != null)
                        return Motion.IsConnected;
                    return false;
                }
            }
            #endregion


            /// <summary>
            /// ACS 생성 및 연결
            /// </summary>
            /// <param name="address">연결할 IP</param>
            /// <param name="isTcp">true : TCP, false : UDP</param>
            /// <returns>완료 여부</returns>
            public bool Initialize()
            {
                //create
                Motion = new Api();

                //Event Handler
                Motion.MOTIONSTART += Motion_MOTIONSTART;
                Motion.MOTIONFAILURE += Motion_MOTIONFAILURE;
                Motion.PEG += Motion_PEG;
                Motion.PHYSICALMOTIONEND += Motion_PHYSICALMOTIONEND;
                //Motion State

                //TODO LOG
                return true;
            }

            /// <summary>
            /// ACS 해제
            /// </summary>
            /// <returns>완료 여부</returns>
            public bool Release()
            {
                if (Motion.IsConnected)
                    Motion.KillAll();

                Motion.MOTIONSTART -= Motion_MOTIONSTART;
                Motion.MOTIONFAILURE -= Motion_MOTIONFAILURE;
                Motion.PEG -= Motion_PEG;
                Motion.PHYSICALMOTIONEND -= Motion_PHYSICALMOTIONEND;
                //TODO LOG
                return Disconnect();
            }

            /// <summary>
            ///  ACS 통신 연결
            /// </summary>
            /// <param name="address">ACS Connect IP</param>
            /// <param name="protocol">@0 ACSC_SOCKET_DGRAM_PORT (UDP) @1 ACSC_SOCKET_STREAM_PORT (TCP)</param>
            /// <returns>성공 여부</returns>
            public bool Connect(string address, bool isTcp = true)
            {
                if (Motion == null)
                    return false;

                if (IsConnected == false)
                {
                    try
                    {
                        foreach (var info in Motion.GetConnectionsList())
                        {
                            //Except ACS Framework 
                            if (!info.Application.Contains("ACS"))
                                Motion.TerminateConnection(info);
                        }
                        // Open ethernet communuication.
                        if (isTcp)
                            Motion.OpenCommEthernet(address, (int)EthernetCommOption.ACSC_SOCKET_STREAM_PORT);
                        else
                            Motion.OpenCommEthernet(address, (int)EthernetCommOption.ACSC_SOCKET_DGRAM_PORT);

                        //TODO LOG

                        return true;
                    }
                    catch (ACSException ex)
                    {
                        Save_SystemLog(ex.Source + ex.Message + ex.StackTrace, DEFINE.MOTION);
                        return false;
                    }
                }
                return false;
            }

            /// <summary>
            /// ACS 통시 해제
            /// </summary>
            /// <returns>성공 여부</returns>
            public bool Disconnect()
            {
                if (IsConnected)
                {
                    Motion?.CloseComm();
                    Save_SystemLog("Motion Disconnected.", DEFINE.MOTION);
                    return true;
                }
                return false;
            }


            /// <summary>
            /// 축 이동 명령
            /// </summary>
            /// <param name="axis">축 번호</param>
            /// <param name="destPosition">이동할 위치</param>
            /// <param name="velocity">속도</param>
            /// <param name="accelerate">가속도</param>
            /// <param name="decelerate">감속도</param>
            /// <param name="moveType">이동 플래그 
            /// @0=사다리꼴 속도 Profile, 절대좌표 이동 (defualt)
            /// @1=S-Curve 속도 Profile, 절대좌표 이동
            /// @2: 상대위치 이동
            /// @4=비대칭 사다리꼴 속도 Profile, 절대좌표 이동
            /// @5=비대칭 S-Curve 속도 Profile, 절대좌표 이동</param>
            /// <param name="isAsynchronous"></param>
            /// <returns></returns>
            public bool StartMove(int nAlignUnitNo, int axis, double destPosition, int moveType = 0, bool isAsynchronous = true)
            {
                //축 객체 Get
                var axisModel = AlignUnit[nAlignUnitNo].m_MotionParams;

                //연결 여부 확인
                if (!IsConnected)
                {
                    Save_SystemLog("Motion is Disconnected.", DEFINE.MOTION);

                    return false;//Disconnected
                }

                if (PrepareToMove(axisModel) == true)
                {
                    if (isAsynchronous)
                    {
                        var waitBlock = Motion.ToPointAsync((MotionFlags)moveType, (Axis)axisModel.AxisID, destPosition);
                        Save_SystemLog($"Move motion to {destPosition} point. [Asynchronous]", DEFINE.MOTION);

                        return true;
                    }
                    else
                    {
                        Motion.ToPoint((MotionFlags)moveType, (Axis)axisModel.AxisID, destPosition);
                        Save_SystemLog($"Move motion to {destPosition} point. [Synchronous]", DEFINE.MOTION);

                        return true;
                    }
                }
                else
                {
                    Save_SystemLog($"Failed to Ready to move.", DEFINE.MOTION);

                    return false;
                }
            }
        
            public bool StartMove(MotionPositionData MotionData, int axis, double destPosition, int moveType = 0, bool isAsynchronous = true)
            {
                //연결 여부 확인
                if (!IsConnected)
                {
                    Save_SystemLog("Motion is Disconnected.", DEFINE.MOTION);

                    return false;//Disconnected
                }

                if (PrepareToMove(MotionData, axis) == true)
                {
                    if (isAsynchronous)
                    {
                        var waitBlock = Motion.ToPointAsync((MotionFlags)moveType, (Axis)axis, destPosition);
                        Save_SystemLog($"Move motion to {destPosition} point. [Asynchronous]", DEFINE.MOTION);

                        return true;
                    }
                    else
                    {
                        Motion.ToPoint((MotionFlags)moveType, (Axis)axis, destPosition);
                        Save_SystemLog($"Move motion to {destPosition} point. [Synchronous]", DEFINE.MOTION);

                        return true;
                    }
                }
                else
                {
                    Save_SystemLog("Motion Start Move Fail.", DEFINE.MOTION);
                    return false;
                }
            }
         

            public void MotionSetParameter_Start(int axis, int nVelocity, int nAcc, double destPosition)
            {
                // 가감속 90%, Jerk 10%
                // 가감속 시간을 Rate로 환산
                double jogAccel = Math.Abs(nVelocity / ((nAcc * 0.9) / 1000.0));

                // Jerk시간을 Rate로 환산
                double jogJerk = Math.Abs(jogAccel / ((nAcc * 0.1) / 1000.0));


                //가감속 세팅
                Motion.SetVelocity((Axis)axis, nVelocity);
                Motion.SetAcceleration((Axis)axis, jogAccel);
                Motion.SetDeceleration((Axis)axis, jogAccel);
                Motion.SetKillDeceleration((Axis)axis, jogAccel * 2);
                Motion.SetJerk((Axis)axis, jogJerk);

                var waitBlock = Motion.ToPointAsync((MotionFlags)0, (Axis)axis, destPosition);
                Save_SystemLog($"Move motion to {destPosition} point. [Asynchronous]", DEFINE.MOTION);
            }
            /// <summary>
            /// 축 이동후 완료 확인 (동기)
            /// </summary>
            /// <param name="axis">축 번호</param>
            /// <returns></returns>
            public bool WaitForDone(int nAlignUnitNo, int axis)
            {
                Axis _axis = (Axis)axis;
                Stopwatch timeoutChecker = new Stopwatch();
                MotionParameter acsAxis = AlignUnit[nAlignUnitNo].m_MotionParams;

                if (!IsConnected)
                {
                    Save_SystemLog("Motion is Disconnected.", DEFINE.MOTION);

                    return false;//Disconnected
                }

                timeoutChecker.Start();
                while (!IsAxisDone(nAlignUnitNo, _axis))
                {
                    //축 상태 확인
                    //if (false == CheckAxisState(_axis))
                    //{
                    //    //TODO LOG
                    //    return ACS_MOTION_RESULT.ERR_AXIS_ALREADY_USED_AXIS_ID;
                    //}

                    //Amp Fault 확인
                    var safetyFlag = Motion.GetFault(_axis);
                    if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                    {
                        //Amp Fault 발생
                        //####ESTOP!!####
                        Motion.KillAll();
                        Motion.Disable(_axis);

                        Save_SystemLog($"Fault occurs in axis Amp. [Cause] : {safetyFlag.ToString()}", DEFINE.MOTION);
                        return false;
                    }

                    //Timeout Check
                    if (timeoutChecker.ElapsedMilliseconds >= acsAxis.TimeoutCondition)
                    {
                        Save_SystemLog($"Axis movement has exceeded the set time.", DEFINE.MOTION);

                        return false;
                    }

                    Thread.Sleep(1);
                }
                timeoutChecker.Reset();

                Save_SystemLog($"Axis movement has arrived at its destination.", DEFINE.MOTION);

                return true;
            }

            public bool WaitForDOne(MotionPositionData MotionData, int axis)
            {
                Axis _axis = (Axis)axis;
                Stopwatch timeoutChecker = new Stopwatch();

                if (!IsConnected)
                {
                    Save_SystemLog("Motion is Disconnected.", DEFINE.MOTION);

                    return false;//Disconnected
                }

                timeoutChecker.Start();
                while (!IsAxisDone(MotionData, _axis))
                {
                    //축 상태 확인
                    //if (false == CheckAxisState(_axis))
                    //{
                    //    //TODO LOG
                    //    return ACS_MOTION_RESULT.ERR_AXIS_ALREADY_USED_AXIS_ID;
                    //}

                    //Amp Fault 확인
                    var safetyFlag = Motion.GetFault(_axis);
                    if (safetyFlag != SafetyControlMasks.ACSC_NONE)
                    {
                        //Amp Fault 발생
                        //####ESTOP!!####
                        Motion.KillAll();
                        Motion.Disable(_axis);

                        Save_SystemLog($"Fault occurs in axis Amp. [Cause] : {safetyFlag.ToString()}", DEFINE.MOTION);
                        return false;
                    }

                    //Timeout Check
                    if (timeoutChecker.ElapsedMilliseconds / 1000 >= MotionData.MoveLimitTime)
                    {
                        Save_SystemLog($"Axis movement has exceeded the set time.", DEFINE.MOTION);

                        return false;
                    }

                    Thread.Sleep(1);
                }
                timeoutChecker.Reset();

                Save_SystemLog($"Axis movement has arrived at its destination.", DEFINE.MOTION);

                return true;
            }

            /// <summary>
            /// 축 정지 명령
            /// </summary>
            /// <param name="axis"></param>
            public void StopMove(int axis)
            {
                Motion.Kill((Axis)axis);
            }

            /// <summary>
            /// 축 Jog 이동 명령
            /// </summary>
            /// <param name="axis">이동할 축</param>
            /// <param name="sign">방향</param>
            /// <returns></returns>
            public bool JogMove(int nAlignUnitNo, int axis, bool sign)
            {
                var _axis = AlignUnit[nAlignUnitNo].m_MotionParams;

                if (_axis.Velocity == 0 || _axis.Acceleration == 0)
                {
                    Save_SystemLog($"Axis[{axis}] JogMove Filad. [Cause] : Velocity - {_axis.Velocity} / Acceleration {_axis.Acceleration}", DEFINE.MOTION);

                    return false;
                }

                // 가감속 90%, Jerk 10%
                // 가감속 시간을 Rate로 환산
                double jogAccel = Math.Abs(_axis.Velocity / ((_axis.Acceleration * 0.9) / 1000.0));

                // Jerk시간을 Rate로 환산
                double jogJerk = Math.Abs(jogAccel / ((_axis.Acceleration * 0.1) / 1000.0));

                try
                {
                    // 속도 적용
                    Motion.SetVelocity((Axis)axis, _axis.Velocity);
                    Motion.SetAcceleration((Axis)axis, jogAccel);
                    Motion.SetDeceleration((Axis)axis, jogAccel);
                    Motion.SetKillDeceleration((Axis)axis, jogAccel * 2);
                    Motion.SetJerk((Axis)axis, jogJerk);

                    if (sign)
                        Motion.JogAsync(MotionFlags.ACSC_NONE, (Axis)axis, _axis.Velocity * (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                    else
                        Motion.JogAsync(MotionFlags.ACSC_NONE, (Axis)axis, _axis.Velocity * (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);

                }
                catch (ACSException ex)
                {
                    Save_SystemLog(ex.Source + ex.Message + ex.StackTrace, DEFINE.MOTION);

                    throw ex;
                }
                return true;
            }

            public bool JogMove(MotionPositionData MotionData, int axis, bool sign)
            {
                if (MotionData.Velocity == 0 || MotionData.Acceleration == 0)
                {
                    Save_SystemLog($"Axis[{axis}] JogMove Filad. [Cause] : Velocity - {MotionData.Velocity} / Acceleration {MotionData.Acceleration}", DEFINE.MOTION);

                    return false;
                }

                // 가감속 90%, Jerk 10%
                // 가감속 시간을 Rate로 환산
                double jogAccel = Math.Abs(MotionData.Velocity / ((MotionData.Acceleration * 0.9) / 1000.0));

                // Jerk시간을 Rate로 환산
                double jogJerk = Math.Abs(jogAccel / ((MotionData.Acceleration * 0.1) / 1000.0));

                try
                {
                    // 속도 적용
                    Motion.SetVelocity((Axis)axis, MotionData.Velocity);
                    Motion.SetAcceleration((Axis)axis, jogAccel);
                    Motion.SetDeceleration((Axis)axis, jogAccel);
                    Motion.SetKillDeceleration((Axis)axis, jogAccel * 2);
                    Motion.SetJerk((Axis)axis, jogJerk);

                    if (sign)
                        Motion.JogAsync(MotionFlags.ACSC_NONE, (Axis)axis, MotionData.Velocity * (double)GlobalDirection.ACSC_POSITIVE_DIRECTION);
                    else
                        Motion.JogAsync(MotionFlags.ACSC_NONE, (Axis)axis, MotionData.Velocity * (double)GlobalDirection.ACSC_NEGATIVE_DIRECTION);
                }
                catch (ACSException ex)
                {
                    Save_SystemLog(ex.Source + ex.Message + ex.StackTrace, DEFINE.MOTION);

                    throw ex;
                }
                return true;
            }

            public void AxisEnable(int axis, bool isEnable)
            {
                if (IsConnected)
                {
                    if (isEnable)
                    {
                        int timeout = 3000;
                        Motion.Enable((Axis)axis);
                        // Wait axis 0 enabled during 3 sec
                        Motion.WaitMotorEnabled((Axis)axis, 1, timeout);

                        Save_SystemLog($"Axis[{axis}] Enable", DEFINE.MOTION);
                    }
                    else
                    {
                        Motion.Disable((Axis)axis);
                        
                        Save_SystemLog($"Axis[{axis}] Disable", DEFINE.MOTION);
                    }
                }
            }

            public double GetCurrentPositionAll()
            {
                //Motion.ReadVariable("FPOS", ProgramBuffer.ACSC_BUFFER_ALL);
                return 0;
            }

            public double GetCurrentPosition(int axis)
            {
                if (IsConnected)
                    return Motion.GetFPosition((Axis)axis);
                else
                    return 0;
            }

            public string GetCurrentMotionStatus(int nAxis)
            {            
                //모터 상태 읽음
                var state = Motion.GetMotorState((Axis)nAxis);
                string strMotorStates = "";

                //사용가능 상태인지, 멈춘 상태인지, 이동중이 아닌지 확인
                if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE))
                {
                    strMotorStates = "MOVING";
                }
                else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                {
                    strMotorStates = "STOP";
                }
                else if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                {
                    strMotorStates = "NOT ENABLE";
                }
                else
                {
                    strMotorStates = "NORMAL";
                }
                return strMotorStates;
           
            }

            private bool PrepareToMove(MotionParameter axisModel)
            {
                //축 이벤트 해제
                Motion.FaultClear((Axis)axisModel.AxisID);

                Thread.Sleep(100);

                //모터 상태 읽음
                var state = Motion.GetMotorState((Axis)axisModel.AxisID);
                //사용가능 상태인지, 멈춘 상태인지, 이동중이 아닌지 확인
                if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                    return false;

                //안전 확인
                switch (Motion.GetFault((Axis)axisModel.AxisID))
                {
                    case SafetyControlMasks.ACSC_NONE:
                        break;
                    case SafetyControlMasks.ACSC_ALL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_RL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_LL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_NETWORK:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_HOT:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SRL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SLL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENCNC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC2NC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_DRIVE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC2:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_PE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_CPE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_VL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_AL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_CL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SP:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_PROG:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_MEM:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_TIME:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ES:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_INT:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_INTGR:
                        break;
                    default:
                        break;
                }

                //모터 에러 상태 확인
                var error = Motion.GetMotorError((Axis)axisModel.AxisID);
                if (error != 0)
                {
                    Save_SystemLog($"Motor error has occurred.", DEFINE.MOTION);

                    return false;
                }

                ///원점 복귀 여부 확인

                //소프트웨어 리미트 확인
                if (axisModel.EndPosition > axisModel.PositiveLimit)
                {
                    Save_SystemLog($"The point to move out of software limit setting. [POSITIVE_LIMIT]", DEFINE.MOTION);

                    return false;
                }
                if (axisModel.EndPosition < axisModel.NegativeLimit)
                {
                    Save_SystemLog($"The point to move out of software limit setting. [NAGATIVE_LIMIT]", DEFINE.MOTION);

                    return false;
                }

                //가감속 세팅
                Motion.SetAcceleration((Axis)axisModel.AxisID, axisModel.Acceleration);
                Motion.SetDeceleration((Axis)axisModel.AxisID, axisModel.Deceleration);
                Motion.SetVelocity((Axis)axisModel.AxisID, axisModel.Velocity);
                Motion.SetJerk((Axis)axisModel.AxisID, axisModel.Jerk);
                return true;
            }

            private bool PrepareToMove(MotionPositionData axisModel, int Axis)
            {
                //축 이벤트 해제
                Motion.FaultClear((Axis)Axis);

                Thread.Sleep(100);

                //모터 상태 읽음
                var state = Motion.GetMotorState((Axis)Axis);
                //사용가능 상태인지, 멈춘 상태인지, 이동중이 아닌지 확인
                if (Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) || !Convert.ToBoolean(state & MotorStates.ACSC_MST_ENABLE))
                    return false;

                //안전 확인
                switch (Motion.GetFault((Axis)Axis))
                {
                    case SafetyControlMasks.ACSC_NONE:
                        break;
                    case SafetyControlMasks.ACSC_ALL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_RL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_LL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_NETWORK:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_HOT:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SRL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SLL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENCNC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC2NC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_DRIVE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ENC2:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_PE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_CPE:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_VL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_AL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_CL:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_SP:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_PROG:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_MEM:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_TIME:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_ES:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_INT:
                        break;
                    case SafetyControlMasks.ACSC_SAFETY_INTGR:
                        break;
                    default:
                        break;
                }

                //모터 에러 상태 확인
                var error = Motion.GetMotorError((Axis)Axis);
                if (error != 0)
                {
                    Save_SystemLog($"Motor error has occurred.", DEFINE.MOTION);

                    return false;
                }

                ///원점 복귀 여부 확인

                //소프트웨어 리미트 확인
                if (axisModel.Target_Position > axisModel.LimitPositive)
                {
                    Save_SystemLog($"The point to move out of software limit setting. [POSITIVE_LIMIT]", DEFINE.MOTION);

                    return false;
                }
                if (axisModel.Target_Position < axisModel.LimitNegative)
                {
                    Save_SystemLog($"The point to move out of software limit setting. [NAGATIVE_LIMIT]", DEFINE.MOTION);

                    return false;
                }               

                // 가감속 90%, Jerk 10%
                // 가감속 시간을 Rate로 환산
                double jogAccel = Math.Abs(axisModel.Velocity / ((axisModel.Acceleration * 0.9) / 1000.0));

                // Jerk시간을 Rate로 환산
                double jogJerk = Math.Abs(jogAccel / ((axisModel.Acceleration * 0.1) / 1000.0));

                //가감속 세팅
                Motion.SetVelocity((Axis)Axis, axisModel.Velocity);
                Motion.SetAcceleration((Axis)Axis, jogAccel);
                Motion.SetDeceleration((Axis)Axis, jogAccel);
                Motion.SetKillDeceleration((Axis)Axis, jogAccel * 2);
                Motion.SetJerk((Axis)Axis, jogJerk);
                return true;
            }


            internal void RunBuffer(int _currentAxisNumber)
            {
                Motion.RunBuffer((ProgramBuffer)_currentAxisNumber, ""); //"" the execution starts from the first line.
            }

            private bool IsAxisDone(int nAlignUnitNo, Axis axis)
            {
                var state = Motion.GetMotorState(axis);
                var position = Motion.GetFPosition(axis);
                MotionParameter acsAxis = AlignUnit[nAlignUnitNo].m_MotionParams;
                if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS) && position == acsAxis.Deceleration)
                    return true;
                else
                    return false;
            }

            private bool IsAxisDone(MotionPositionData MotionData, Axis axis)
            {
                var state = Motion.GetMotorState(axis);
                var position = Motion.GetFPosition(axis);
           
                if (!Convert.ToBoolean(state & MotorStates.ACSC_MST_MOVE) && Convert.ToBoolean(state & MotorStates.ACSC_MST_INPOS))
                    return true;
                else
                    return false;
            }

            private bool CheckAxisState(Axis axis)
            {
                switch (Motion.GetAxisState(axis))
                {
                    case AxisStates.ACSC_NONE:
                        return true;
                    case AxisStates.ACSC_ALL: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_LEAD: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_DC: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_PEG: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_PEGREADY: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_MOVE: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_ACC: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_SEGMENT: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_VELLOCK: //TODO LOG
                        return false;
                    case AxisStates.ACSC_AST_POSLOCK: //TODO LOG
                        return false;
                    default:
                        break;
                }
                return false;
            }

            //public string GetAxisStateString(Axis axis)
            //{
            //    switch (Motion.GetAxisState(axis))
            //    {
            //        case AxisStates.ACSC_NONE: if(Convert.ToB)
            //            return true;
            //        case AxisStates.ACSC_ALL: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_LEAD: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_DC: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_PEG: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_PEGREADY: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_MOVE: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_ACC: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_SEGMENT: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_VELLOCK: //TODO LOG
            //            return false;
            //        case AxisStates.ACSC_AST_POSLOCK: //TODO LOG
            //            return false;
            //        default:
            //            break;
            //    }
            //    return false;
            //}

            #region Event
            private void Motion_PHYSICALMOTIONEND(AxisMasks axis)
            {
                Console.WriteLine(axis);
            }
            private void Motion_PEG(AxisMasks axis)
            {
                Console.WriteLine(axis);
            }
            private void Motion_MOTIONFAILURE(AxisMasks axis)
            {
                Console.WriteLine(axis);
            }
            private void Motion_MOTIONSTART(AxisMasks axis)
            {
                Console.WriteLine(axis);
            }
            #endregion


            static object syncLock_ACSLog = new object();
            private static void Save_SystemLog(string nMessage, string nType)
            {
                string nFolder;
                string nFileName = "";
                nFolder = Main.LogdataPath + DateTime.Now.ToString("yyyyMMdd") + "\\";
                if (!Directory.Exists(Main.LogdataPath)) Directory.CreateDirectory(Main.LogdataPath);
                if (!Directory.Exists(nFolder)) Directory.CreateDirectory(nFolder);

                string Date;
                Date = DateTime.Now.ToString("[MM_dd HH:mm:ss:fff] ");

                lock (syncLock_ACSLog)
                {
                    try
                    {
                        switch (nType)
                        {
                            case Main.DEFINE.MOTION:
                                nFileName = "MotionLog.txt";
                                nMessage = Date + nMessage;
                                break;
                        }

                        StreamWriter SW = new StreamWriter(nFolder + nFileName, true, Encoding.Unicode);
                        SW.WriteLine(nMessage);
                        SW.Close();
                    }
                    catch
                    {

                    }
                }
            }
        }   // ACS
    }   // Main
}
