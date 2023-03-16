using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace COG
{
    public partial class Main
    {
        public partial class PatternTag
        {
            public int m_SpotLightValue;
            public int m_RingLightValue;
            public int m_BarLightValue;
        }
    }

    public class LightControl
    {
        public enum eLightController
        {
            PREALIGN_CONTROL = 0,
            ATT_CONTROL = 1,
        }
        public enum eLightChannel
        {
            ATT_PREALIGN_SPOT_WHITE = 0,
            ATT_INSP_SPOT_RED = 1,
            ATT_INSP_SPOT_BLUE = 2,
            ATT_BAR_WHITE = 3,
        }

        private static SerialPort[] LightController = new SerialPort[Main.DEFINE.Light_Control_Max];
        public static int[] LightComport = new int[Main.DEFINE.Light_Control_Max];
        public static string[] LightMaker = new string[Main.DEFINE.Light_Control_Max];
        private static Main.MTickTimer LightTimer = new Main.MTickTimer();


        public static void Port_Initial(int ControlNum, int PortNum)
        {
            //if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM) return;
           
            try
            {
                LightController[ControlNum] = new SerialPort("COM" + PortNum.ToString(), 19200, Parity.None, 8, StopBits.One);
                Port_Open(ControlNum);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
                  
        }
        public static bool Port_Open(int ControlNum)
        {
            try
            {
                if (LightController[ControlNum].IsOpen)
                    LightController[ControlNum].Close();
                else
                    LightController[ControlNum].Open();
            }
            catch (System.Exception ex)
            {
                if (!LightController[ControlNum].IsOpen)
                {
                    //MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
                    //                     resultMessage = "Light" + com.ToString() + " isn't Open.";
                    //                     MessageBox.Show(resultMessage);

                    Console.WriteLine(ex.Source + ex.Message + ex.StackTrace);
                    return false;
                }
            }
            return true;
        }
        public static void Port_Close(int ControlNum)
        {
            for (int i = 0; i < Main.DEFINE.Light_Control_Max; i++)
            {
                for (int j = 0; j < Main.DEFINE.Light_ChannelCount; j++)
                {
                    SetLightLevel(i, j, 0);
                }
            }
            LightController[ControlNum].Close();
        }
        public static void SetLightLevel(int ControlNum, int Channel, int value)
        {
            string m_sendData;
  
            if (LightMaker[ControlNum] == "LVS")
            {        
                byte[] commandCode = new byte[6];
                Channel = 0x01 << Channel;

                commandCode[0] = Main.DEFINE.LVS_LIGHT_CMD_START;           //START
                commandCode[1] = Main.DEFINE.LVS_LIGHT_CMD_WRITE;           //OP Code
                commandCode[2] = 0x01;                                      //Data length
                commandCode[3] = Main.DEFINE.LVS_LIGHT_CMD_RIGISTER_CSR;    //SET Channel Rigister 
                commandCode[4] = Convert.ToByte(Channel);                   //channel bits
                commandCode[5] = Main.DEFINE.LVS_LIGHT_CMD_END;             //END

                Write(ControlNum, commandCode, 0, commandCode.Length);

                commandCode[0] = Main.DEFINE.LVS_LIGHT_CMD_START;           //START
                commandCode[1] = Main.DEFINE.LVS_LIGHT_CMD_WRITE;           //OP Code
                commandCode[2] = 0x01;                                      //Data length
                commandCode[3] = Main.DEFINE.LVS_LIGHT_CMD_RIGISTER_SVR;    //SET VALUE Rigister 
                commandCode[4] = Convert.ToByte(value);                     //value bits
                commandCode[5] = Main.DEFINE.LVS_LIGHT_CMD_END;             //END

                Write(ControlNum, commandCode, 0, commandCode.Length);
                
            }
            else if(LightMaker[ControlNum] == "DR")
            {
                m_sendData = "[" + Channel.ToString("D2") + value.ToString("D3");

                Write(ControlNum, m_sendData);
            } 
        }
        public static void Write(int ControlNum, string SendData, bool bRetry = false)
        {
            //if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM) return;
            try
            {
                LightController[ControlNum].Write(SendData);

                bool bRet = false;
                if (bRetry)
                {
                    int readCnt = 0;
                    byte[] recvBuf = new byte[128];
                    LightTimer.StartTimer();
                    while (LightTimer.GetElapsedTime() < Main.DEFINE.LVS_LIGHT_RESP_TIMEOUT)
                    {
                        readCnt = LightController[ControlNum].Read(recvBuf, 0, 128);
                        if (recvBuf[0] == Main.DEFINE.LVS_LIGHT_CMD_ACK)
                            bRet = true;
                    }
                    if (!bRet)
                        LightController[ControlNum].Write(SendData);
                }
            }
            catch
            {
            }

        }
        private static void Write(int ControlNum, byte[] SendData, int offset, int length, bool bRetry = false)
        {
            if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM) return;

            try
            {
                LightController[ControlNum].Write(SendData, offset, length);

                bool bRet = false;
                if (bRetry)
                {
                    int readCnt = 0;
                    byte[] recvBuf = new byte[128];

                    LightTimer.StartTimer();
                    while (LightTimer.GetElapsedTime() < Main.DEFINE.LVS_LIGHT_RESP_TIMEOUT)
                    {
                        readCnt = LightController[ControlNum].Read(recvBuf, 0, 128);
                        if (recvBuf[0] == Main.DEFINE.LVS_LIGHT_CMD_ACK)
                            bRet = true;
                    }
                    if (!bRet)
                        LightController[ControlNum].Write(SendData, offset, length);
                }
            }
            catch
            {

            }

        }
    }
}
