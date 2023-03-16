using COG.Class.COM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG
{
    public class VieworksLineScanner
    {
        // Command
        const string SensorMode = "som";            // Set Sensor Mode Command (0 : TDI 1 : AREA)
        const string ScanDirection = "ssd";         // Set ScanDirection Command (0 : FWD 1 : RVS 2 : LINE1)
        const string ExposureTime = "set";          // Set Exposure Time Command (When Area Mode, us)
        const string OutputMode = "stm";           // Set Trigger Mode Command (0 : Free-Run 1 : Trigger Mode)
        const string ReverseX = "shf";              // Set Reverse X Command (0 : Off 1 : On)
        const string AnalogGain = "sag";            // Set Analog Gain Command (1 : 1x 2 : 2x 3 : 3x 4 : 4x)
        const string DigitalGain = "sdg";           // Set Digital Gain Command (1.0 ~ 8.0)
        const string TriggerSource = "sts";         // Set Trigger Source Command (1 : CC1 Port 5 : External Port)
        const string OffsetX = "sox";               // Set Offset X Mode Command (ROI Start coordinate)
        const string ImageWidth = "siw";            // Set Image Width Command (VT_6K3_5C : 256 ~ 6560)
        const string StrobeMode = "ssm";            // Set Strobe Mode Command (0 : Off 1 : Strobe Duration 2 : Trigger Pulse 3 : Successive High Pulse
        const string StrobeDuration = "ssr";        // Set Strobe Duration Command (1.00 ~ 1000.00 us)
        const string StrobeCurrent = "sscc";        // Set Strobe Current (0 ~ 1000) mA
        const string StrobeBrightness = "sscb";     // Set Strobe Brightness (0 ~ 300) %

        const string OutputFrequency = "w clfq";
        const string FFCEnable = "w ffcp";
        const string FFCCalibration = "w calg";
        const string PRNUCalibration = "w calo";
        const string TriggerPreset = "w sync";

        const double NullCommand = -1.0;

        private SerialComm serialComm = new SerialComm();
        private bool _isOpen = false;


        public enum eParameterValue
        {
            SET_LINESCAN_OPMODE_TDI = 0,
            SET_LINESCAN_DIR_REVERSE = 1,

            SET_LINESCAN_TRIGGER_MODE = 1,


            SET_REVERSE_X = 0,
            SET_LINESCAN_OPMODE_AREA = 1,
            SET_LINESCAN_DIR_FORWARD = 0,
            SET_LINESCAN_FREERUN_MODE = 0,
            SET_SCAN_MODE_RANGE = 0,
            SET_SCAN_MODE_LENGTH = 1,
            SET_STROBE_MODE_OFF = 0,
            SET_STROBE_MODE_TIMED = 1,
            SET_STROBE_MODE_ON = 3
        }

        public void Initialize(string comPort, int baudRate)
        {
            if (OpenPort(comPort, baudRate))
            { }
                //SetDefaultParameter();
            else
                Console.WriteLine("Line Scanner Initialize Fail.");
        }

        public bool OpenPort(string comPort, int baudRate)
        {
            if (serialComm == null)
            {
                Console.WriteLine("Serial Object is Null.");
                return false;
            }

            serialComm.Initialize(comPort, baudRate);
            _isOpen = true;

            return _isOpen;
        }

        public void SetDefaultParameter()
        {
            SetSensorMode((int)eParameterValue.SET_LINESCAN_OPMODE_TDI);
            SetScanDirection((int)eParameterValue.SET_LINESCAN_DIR_FORWARD);
            SetOutputMode((int)eParameterValue.SET_LINESCAN_TRIGGER_MODE);   // Set Trigger Mode Command (0 : Free-Run 1 : Trigger Mode)
            SetExposureTime(6000);
            SetAnalogGain(2);                     // Analog Gain : 1, Range : 1x ~ 4x
            SetDigitalGain(2);                    // Digital Gain : 0, Range : 1.0 ~ 8.0
            SetOffsetX(0);
            SetImageWidth(3200);
            SetReverseX(1);
            SetTriggerSource(1);
        }

        private string MakeCommand(string command, double value1, double value2 = NullCommand)
        {
            if (value2 == NullCommand)
                return string.Format(command + " " + value1 + "\r");
            else
                return string.Format(command + " " + value1 + " " + value2 + "\r");
        }

        public void SetSensorMode(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(SensorMode, value));
        }

        public void SetScanDirection(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(ScanDirection, value));
        }

        public void SetExposureTime(double value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(ExposureTime, value));
        }

        public void SetOutputMode(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(OutputMode, value));
        }

        public void SetReverseX(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(ReverseX, value));
        }

        public void SetAnalogGain(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(AnalogGain, value));
        }

        public void SetDigitalGain(double value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(DigitalGain, value));
        }

        public void SetTriggerSource(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(TriggerSource, value));
        }

        public void SetOffsetX(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(OffsetX, value));
        }

        public void SetImageWidth(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(ImageWidth, value));
        }

        public void SetStrobeMode(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(StrobeMode, value));
        }

        public void SetStrobeDuration(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(StrobeDuration, value));
        }

        public void SetStrobeCurrent(int channel, int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(StrobeCurrent, channel, value));
        }

        public void SetStrobeBrightness(int channel, int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(StrobeBrightness, channel, value));
        }

        public void SetOutputFrequency(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(OutputFrequency, value));
        }

        public void SetFFCEnable(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(FFCEnable, value));
        }

        public void SetFFCCalibration(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(FFCCalibration, value));
        }

        public void SetPRNUCalibration(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(PRNUCalibration, value));
        }

        public void SetTriggerPreset(int value)
        {
            if (!_isOpen)
                return;

            serialComm.SendData(MakeCommand(TriggerPreset, value));
        }

        private void ClosePort()
        {
            serialComm.Terminate();
        }

        public void ReleaseLineScan()
        {
            ClosePort();
        }
    }
}
