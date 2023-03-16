using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class.COM
{
    public class SerialComm
    {
        private SerialPort _serialPort = new SerialPort();
        public string Received = "";
        private const string CRLF = "\r\n";
        ~ SerialComm()
        {
            _serialPort.Close();
        }
        public void Initialize(string comPort, int baudRate, Parity parity = Parity.None, int dataBit = 8, StopBits stopBit = StopBits.One, int timeOut = 2000)
        {
            string _comPort = comPort;
            int _baudRate = baudRate;
            InitializeDevice(_comPort, _baudRate, parity, dataBit, stopBit, timeOut);

            if (!PortOpen())
            {
                Console.WriteLine("Comport Open Error");
                return;
            }
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        public void InitializeDevice(string comPort, int baudRate, Parity parity, int dataBit, StopBits stopBit, int timeOut)
        {
            try
            {
                _serialPort = new SerialPort(comPort, baudRate, Parity.None, 8, StopBits.One);
				
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                //_serialPort.PortName = comPort;
                //_serialPort.BaudRate = baudRate;
                //_serialPort.Parity = parity;
                //_serialPort.DataBits = dataBit;
                //_serialPort.StopBits = stopBit;
                //_serialPort.ReadTimeout = timeOut;
                //_serialPort.NewLine = "\r\n";
                //_serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool SendData(string sendData)
        {
            if (!_serialPort.IsOpen)
                return false;

           // ResetBuffer();

            string strData = "";
            strData = sendData;
            //strData += MakeChecksum(strData);
            strData += "\n";//CRLF;

            _serialPort.WriteLine(strData);
            return true;
        }

        public bool SendData(byte[] sendData)
        {
            if (!_serialPort.IsOpen)
                return false;

            ResetBuffer();
            _serialPort.Write(sendData, 0, sendData.Length);

            return true;
        }

        private string MakeChecksum(string strSendData)
        {
            string strData = "";
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(strSendData);

            byte[] data = new byte[temp.Length + 4];
            int sum = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                data[i] = temp[i];
                sum = sum + temp[i];
            }
            strData = string.Format("{0:X2}", sum);
            strData = strData.Substring(strData.Length - 2, 2);
            return strData;
        }

        private bool _isStarted;
        private DateTime _timerStart;

        public void Reset()
        {
            _isStarted = false;
            _timerStart = DateTime.Now;
        }

        public bool IsTimeOut(int nInterval)
        {
            if (!_isStarted)
            {
                _timerStart = DateTime.Now;
                _isStarted = true;
            }
            TimeSpan tsSpan = DateTime.Now - _timerStart;
            if (tsSpan.TotalMilliseconds > nInterval)
            {
                _isStarted = false;
                Reset();
                return true;
            }
            else
                return false;
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                Received = "";
                int readcount = _serialPort.BytesToRead;
                Received = _serialPort.ReadLine();
                ParseReceivedData(Received);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public class ReceiveStatus
        {
            public string Message = "";
        }

        public ReceiveStatus receiveStatus = new ReceiveStatus();

        public void ParseReceivedData(string receiveData)
        {
            try
            {
                receiveStatus.Message = "";
                receiveStatus.Message = receiveData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private bool PortOpen()
        {
            try
            {
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                _serialPort.Open();
                if (_serialPort.IsOpen)
                {
                    ResetBuffer();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        private bool PortClose()
        {
            try
            {
                if (_serialPort.IsOpen == true)
                    _serialPort.Close();

                if (!_serialPort.IsOpen)
                {
                    _serialPort.Dispose();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public void Terminate()
        {
            PortClose();
        }

        private void ResetBuffer()
        {
            Received = "";
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
        }

    }
}
