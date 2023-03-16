using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG
{
    public partial class Main
    {
        public enum DefaultMotionData
        {
            #region Position 설명
            //Scan방향 2개, 7개 포지션, 2개의 축(X, Z)으로 설정
            //                   TOP                                            BOTTOM
            //Stage#1 Prealign Left  Stage#1 Prealign Right	  Stage#1 Prealign Left  Stage#1 Prealign Right
            //Stage#2 Prealign Left  Stage#2 Prealign Right	  Stage#2 Prealign Left  Stage#2 Prealign Right
            //Stage#1 Scan Start     Stage#2 Scan Start		  Stage#1 Scan Start     Stage#2 Scan Start
            //Standby										  Standby
            #endregion
            MAX_DIRECTION_COUNT = 2,
            MAX_POSITION_COUNT = 7,
            MAX_AXIS_COUNT = 2,
            MOTION_AXIS_X = 0,
            MOTION_AXIS_Z = 1,
            DEFAULT_X_JOG_SPEED = 30,
            DEFAULT_Z_JOG_SPEED = 1,
            DEFAULT_X_VELOCITY = 20,
            DEFAULT_Z_VELOCITY = 30,
            DEFAULT_MOVE_LIMIT_TIME = 10,
            DEFAULT_X_ACCELERATION = 100,
            DEFAULT_X_DECELERATION = 100,
            DEFAULT_Z_ACCELERATION = 10,
            DEFAULT_Z_DECELERATION = 10,
            DEFAULT_MOVE_TOLERANCE = 0,
            DEFAULT_X_LIMIT_POSITIVE = 1250,
            DEFAULT_X_LIMIT_NEGATIVE = 0,
            DEFAULT_Z_LIMIT_POSITIVE = 0,
            DEFAULT_Z_LIMIT_NEGATIVE = 0,
            DEFAULT_AFTER_WAIT_TIME = 0,
            DEFAULT_HOMINT_LIMIT_TIME = 120,
            DEFAULT_TARGET_POSITION = 0,

            STAGE1_PREALIGN_LEFT_POSTION = 0,
            STAGE1_PREALIGN_RIGHT_POSTION = 1,
            STAGE2_PREALIGN_LEFT_POSTION = 2,
            STAGE2_PREALIGN_RIGHT_POSTION = 3,
            STAGE1_SCAN_START_POSTION = 4,
            STAGE2_SCAN_START_POSTION = 5,
            STANDBY_POSITION = 6,

            PANEL_DIRECTION_TOP = 0,
            PANEL_DIRECTION_BOTTOM = 1
        }

        public class MotionInfo
        {
            bool bServoOn = false;

            bool bHomeSensor = false;
            bool bNegativeLimit = false;
            bool bPositiveLimit = false;

            int nStatus = 0x00000000;

            double dPosition = 0.0;
            double dVelocity = 0.0;
        }

        // IT설비에서 X 축은 ACS에서 동작, Z축은 다른 모션에서 제어.
        // [MAX_DIRECTION_COUNT] 0 : Top, 1 : Bottom
        // [MAX_POSITION_COUNT] Stage1/2 Left/Right Prealign Position, Stage 1/2 LineScan Start Position, Standby
        // [MAX_AXIS_COUNT] 0 : Axis X , 1 : Axis Z
        // 각 축마다 현재 모션 상태 정보를 가지고 있다.
        public static MotionPositionData[,,] m_sPositionData = new MotionPositionData[(int)DefaultMotionData.MAX_DIRECTION_COUNT,
            (int)DefaultMotionData.MAX_POSITION_COUNT, (int)DefaultMotionData.MAX_AXIS_COUNT];
        public static MotionInfo[] m_sMotionInfo = new MotionInfo[(int)DefaultMotionData.MAX_AXIS_COUNT];
        public class MotionPositionData
        {
            // AXIS Parameter
            public double JogSpeed = (double)DefaultMotionData.DEFAULT_X_JOG_SPEED;
            public double Velocity = (double)DefaultMotionData.DEFAULT_X_VELOCITY;
            public double MoveLimitTime = (double)DefaultMotionData.DEFAULT_MOVE_LIMIT_TIME;
            public int Acceleration = (int)DefaultMotionData.DEFAULT_X_ACCELERATION;
            public int Deceleration = (int)DefaultMotionData.DEFAULT_X_DECELERATION;
            public double MoveTolerance = (double)DefaultMotionData.DEFAULT_MOVE_TOLERANCE;
            public double LimitPositive = (double)DefaultMotionData.DEFAULT_X_LIMIT_POSITIVE;
            public double LimitNegative = (double)DefaultMotionData.DEFAULT_X_LIMIT_NEGATIVE;
            public double AfterWaitTime = (double)DefaultMotionData.DEFAULT_AFTER_WAIT_TIME;
            public double HomingLimitTime = (double)DefaultMotionData.DEFAULT_HOMINT_LIMIT_TIME;
            public int AFOffsetValue = (int)DefaultMotionData.DEFAULT_TARGET_POSITION;
            public double Target_Position = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
            public double Target_PositionOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
            public double Target_PositionStartOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;
            public double Target_PositionEndOffset = (double)DefaultMotionData.DEFAULT_TARGET_POSITION;

        }

        public static void MotionDataInitialize()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        m_sPositionData[i, j, k] = new MotionPositionData();
                    }
                }
            }
        }
        public static bool LoadMotionDataFile()
        {
            return true;
        }

        public static bool SaveMotionDataFile()
        {
            return true;
        }
    }
}
