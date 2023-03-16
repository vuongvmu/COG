using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class.MOTION.Nurione
{
    public class Nurione : IMotion
    {
        public override void AllServoOff()
        {
            throw new NotImplementedException();
        }

        public override double GetActualPosition(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override string GetCurrentMotionStatus(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override int GetRemainRepeatCount()
        {
            throw new NotImplementedException();
        }

        public override int GetRepeatCount()
        {
            throw new NotImplementedException();
        }

        public override eConnectionStatus InitializeDevice(eProtocolType protocolType)
        {
            throw new NotImplementedException();
        }

        public override bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public override bool IsNegativeLimit(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override bool IsPositiveLimit(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override void JogMove(eAxis axis, eDirection direction)
        {
            throw new NotImplementedException();
        }

        public override void MoveRepeat(eAxis axis, double startPosition, double endPosition, int setRepeatCount)
        {
            throw new NotImplementedException();
        }

        public override void MoveTo(eAxis axis, double targetPosition)
        {
            throw new NotImplementedException();
        }

        public override void ServoOff(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override void ServoOn(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override void SetDefaultParameter(eAxis axis, double velocity = 100, double accdec = 10)
        {
            throw new NotImplementedException();
        }

        public override void SetProperty()
        {
            throw new NotImplementedException();
        }

        public override void SetRepeatFlag(bool isRepeat)
        {
            throw new NotImplementedException();
        }

        public override void StartHome(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override void StopMove(eAxis axis)
        {
            throw new NotImplementedException();
        }

        public override void Terminate()
        {
            throw new NotImplementedException();
        }

        public override bool WaitForDone(eAxis axis)
        {
            throw new NotImplementedException();
        }
    }
}
