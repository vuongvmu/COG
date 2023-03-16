using COG.Class.MOTION;
using COG.Class.MOTION.ACS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class.Manager
{
    public class MotionManager : IMotion
    {
        private IMotion _motion = null;

        public void CreateObject(eMotionMaker type)
        {
            switch (type)
            {
                case eMotionMaker.None:
                    break;

                case eMotionMaker.ACS:
                    _motion = new ACSMotion();
                    break;

                default:
                    break;
            }
        }

        public override eConnectionStatus InitializeDevice(eProtocolType protocolType)
        {
            if (_motion == null)
                return eConnectionStatus.Connection_Error;

            return _motion.InitializeDevice(protocolType);
        }

        public override bool IsConnected()
        {
            if (_motion == null)
                return false;

            return _motion.IsConnected();
        }

        public override double GetActualPosition(eAxis axis)
        {
            if (_motion == null)
                return 0;

            return _motion.GetActualPosition(axis);
        }

        public override void StopMove(eAxis axis)
        {
            if (_motion == null)
                return;

            _motion.StopMove(axis);
        }

        public override void JogMove(eAxis axis, eDirection direction)
        {
            if (_motion == null)
                return;

            _motion.JogMove(axis, direction);
        }

        public override void ServoOff(eAxis axis)
        {
            if (_motion == null)
                return;

            _motion.ServoOff(axis);
        }

        public override void AllServoOff()
        {
            if (_motion == null)
                return;

            _motion.AllServoOff();
        }

        public override void ServoOn(eAxis axis)
        {
            if (_motion == null)
                return;

            _motion.ServoOn(axis);
        }

        public override void Terminate()
        {
            if (_motion == null)
                return;

            _motion.Terminate();
        }

        public override void MoveTo(eAxis axis, double targetPosition, double velocity = 10, double accdec = 10)
        {
            if (_motion == null)
                return;

            _motion.MoveTo(axis, targetPosition, velocity, accdec);
        }

        //public override void MoveTo(Main.MotionPositionData motionData, eAxis axis, double targetPosition)
        //{
        //    if (_motion == null)
        //        return;

        //    _motion.MoveTo(motionData, axis, targetPosition);
        //}

        public override void SetDefaultParameter(eAxis axis, double velocity = 10, double accdec = 10)
        {
            if (_motion == null)
                return;

            _motion.SetDefaultParameter(axis, velocity, accdec);
        }

        public override bool WaitForDone(eAxis axis)
        {
            if (_motion == null)
                return false;

            return _motion.WaitForDone(axis);
        }

        public override void StartHome(eAxis axis)
        {
            if (_motion == null)
                return;

            _motion.StartHome(axis);
        }

        public override string GetCurrentMotionStatus(eAxis axis)
        {
            if (_motion == null)
                return null;

            return _motion.GetCurrentMotionStatus(axis);
        }

        public override void MoveRepeat(eAxis axis, double startPosition, double endPosition, int setRepeatCount, int dwellTime)
        {
            if (_motion == null)
                return;

            _motion.MoveRepeat(axis, startPosition, endPosition, setRepeatCount, dwellTime);
        }

        public override void StopRepeat()
        {
            if (_motion == null)
                return;

            _motion.StopRepeat();
        }

        public override void SetRepeatFlag(bool isRepeat)
        {
            if (_motion == null)
                return;

            _motion.SetRepeatFlag(isRepeat);
        }

        public override int GetRemainRepeatCount()
        {
            if (_motion == null)
                return -1;

            return _motion.GetRemainRepeatCount();
        }

        public override int GetRepeatCount()
        {
            if (_motion == null)
                return -1;

            return _motion.GetRepeatCount();
        }

        //public override void SetProperty(/*object param*/)
        //{
        //    if (_motion == null)
        //        return;

        //    _motion.SetProperty(/*param*/);
        //}

        public override bool IsNegativeLimit(eAxis axis)
        {
            if (_motion == null)
                return false;

            return _motion.IsNegativeLimit(axis);
        }

        public override bool IsPositiveLimit(eAxis axis)
        {
            if (_motion == null)
                return false;

            return _motion.IsPositiveLimit(axis);
        }
    }
}
