using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class.MOTION
{
    public enum eMotionMaker
    {
        None,
        ACS,
    }

    public enum eProtocolType
    {
        None,
        Serial,
        Ethernet,
    }

    public enum eConnectionStatus
    {
        Done,
        Connection_Error,
    }

    public enum eAxis
    {
        None = -1,
        Axis_X,
        Axis_Y,
        Axis_Z,
    }

    public enum eDirection
    {
        CW = -1,
        CCW = 1,
    }

    public enum eJogSpeedMode
    {
        Slow,
        Fast
    }

    public enum eJogMode
    {
        Jog,
        Increase
    }

    public enum eErrorStatus
    {
        None,
        Error_NotExist_MotionLibraryObject,
        Error_NotExsit_MotionAxisConfiguration,
    }

    public abstract class IMotion
    {
        public abstract eConnectionStatus InitializeDevice(eProtocolType protocolType);

        public abstract void Terminate();

        public abstract bool IsConnected();

        public abstract void ServoOn(eAxis axis);

        public abstract void ServoOff(eAxis axis);

        public abstract void AllServoOff();

        public abstract void StopMove(eAxis axis);

        public abstract void JogMove(eAxis axis, eDirection direction);

        public abstract double GetActualPosition(eAxis axis);

        public abstract void MoveTo(eAxis axis, double targetPosition, double velocity, double accdec);

        //public abstract void MoveTo(Main.MotionPositionData motionData, eAxis axis, double targetPosition);

        public abstract void SetDefaultParameter(eAxis axis, double velocity = 10, double accdec = 10);

        public abstract bool WaitForDone(eAxis axis);

        public abstract void StartHome(eAxis axis);

        public abstract string GetCurrentMotionStatus(eAxis axis);

        public abstract void MoveRepeat(eAxis axis, double startPosition, double endPosition, int setRepeatCount, int dwellTime);

        public abstract void StopRepeat();

        public abstract void SetRepeatFlag(bool isRepeat);

        public abstract int GetRemainRepeatCount();

        public abstract int GetRepeatCount();

        //public abstract void SetProperty(/*object param*/);

        public abstract bool IsNegativeLimit(eAxis axis);

        public abstract bool IsPositiveLimit(eAxis axis);
    }

    public enum eDefaultMotionData
    {
        JogLowSpeed = 10,
        JogHighSpeed = 20,
        Velocity = 20,
        AccelerationTime = 10,
        DecelerationTime = 10,
        MoveTolerance = 0,

        NegativeSWLimit = 0,
        PositiveSWLimit = 100,
        HomingTimeOut = 120,
        MovingTimeOut = 10,
        AfterWaitTime = 0,

        CenterOfGravity = 0,
    }

    public class MotionProperty
    {
        public double JogLowSpeed { get; set; } = 10.0;
        public double JogHighSpeed { get; set; } = 20.0;
        public double MovingTimeOut { get; set; } = 10.0;


        public double Velocity { get; set; } = 10.0;
        public double Acceleration { get; set; } = 20.0;
        public double Deceleration { get; set; } = 20.0;

        public double NegativeSWLimit { get; set; } = 0.0;
        public double PositiveSWLimit { get; set; } = 100.0;
        public double MoveTolerance { get; set; } = 0.0;

        public double AfterWaitTime { get; set; } = 0.0;
        public double HomingTimeOut { get; set; } = 120.0;
        public int CenterOfGravity { get; set; } = 100;

        public void SetProperty(MotionProperty property)
        {
            this.JogLowSpeed = property.JogLowSpeed;
            this.JogHighSpeed = property.JogHighSpeed;
            this.MovingTimeOut = property.MovingTimeOut;

            this.Velocity = property.Velocity;
            this.Acceleration = property.Acceleration;
            this.Deceleration = property.Deceleration;

            this.NegativeSWLimit = property.NegativeSWLimit;
            this.PositiveSWLimit = property.PositiveSWLimit;
            this.MoveTolerance = property.MoveTolerance;

            this.AfterWaitTime = property.AfterWaitTime;
            this.HomingTimeOut = property.HomingTimeOut;
            this.CenterOfGravity = property.CenterOfGravity;
        }

        public MotionProperty Copy()
        {
            MotionProperty property = new MotionProperty();

            property.JogLowSpeed = this.JogLowSpeed;
            property.JogHighSpeed = this.JogHighSpeed;
            property.MovingTimeOut = this.MovingTimeOut;

            property.Velocity = this.Velocity;
            property.Acceleration = this.Acceleration;
            property.Deceleration = this.Deceleration;

            property.NegativeSWLimit = this.NegativeSWLimit;
            property.PositiveSWLimit = this.PositiveSWLimit;
            property.MoveTolerance = this.MoveTolerance;

            property.AfterWaitTime = this.AfterWaitTime;
            property.HomingTimeOut = this.HomingTimeOut;
            property.CenterOfGravity = this.CenterOfGravity;

            return property;
        }
    }
}
