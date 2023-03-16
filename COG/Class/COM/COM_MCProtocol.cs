using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

using JAS.Interface.PLC;

namespace COG
{
    public partial class Main
    {
        private static Mutex Mutex_lock_RD = new Mutex();
        private static Mutex Mutex_lock_WD = new Mutex();

        private static MCProtocol MCClient = new MCProtocol();
        public static void OpenDM(int _intReadLocalPort, int _intReadRemotePort, string _strRemoteIP, int _intReadRecTimeOut, int _intWriteLocalPort, int _intWriteRemotePort)
        {
            int nReturnCode = 1;
            bool bRet = false; 
            try
            {
                bRet = MCClient.Open(_intReadLocalPort, _intReadRemotePort, _strRemoteIP, _intReadRecTimeOut, _intWriteLocalPort, _intWriteRemotePort);
            }
            catch (System.Exception)
            {
                MessageBox.Show("PLC OPEN ERROR" + nReturnCode.ToString());
            }
            finally
            {
                if (!bRet)
                    MessageBox.Show("PLC OPEN ERROR");
            }
        }
        public static void CloseDM()
        {
            //            int nReturnCode = 1;
            try
            {
                MCClient.UClose();
            }
            catch (System.Exception)
            {
                //   MessageBox.Show("PLC OPEN ERROR" + nReturnCode.ToString());
            }
            finally
            {
                //              if (nReturnCode != 0)
                //              MessageBox.Show("PLC OPEN ERROR" + nReturnCode.ToString());
            }
        }
        public static void ReadDeviceBlock(string szDevice, int lSize, out int[] lplData)
        {
            Mutex_lock_RD.WaitOne();
            int[] returnValue = new int[lSize];
            int num;

            try
            {
                num = MCClient.ReadDevice_W(szDevice, lSize, ref returnValue);
                lSize = returnValue.Length;
                if (num == lSize)
                {
                    lplData = returnValue;
                }
                else
                {
                    for (int i = 0; i < lSize; i++)
                    {
                        returnValue[i] = 0;
                    }
                    lplData = returnValue;
                }

            }
            catch// (System.Exception ex)
            {
                //  MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                lplData = returnValue;
                Mutex_lock_RD.ReleaseMutex();
            }

        }
        private static void ThreadPLC_Read()
        {
            if (!Main.DEFINE.OPEN_F && !Main.DEFINE.OPEN_CAM)
            {
                string DeviceNameWS, DeviceNameWP, DeviceNameRS, DeviceNameRP;

                DeviceNameWS = "D" + Convert.ToString(PLCDataTag.BASE_RW_ADDR).ToUpper();
                DeviceNameWP = "D" + Convert.ToString(PLCDataTag.BASE_RW_ADDR + DEFINE.PROC_DATA_OFFSET).ToUpper();
                DeviceNameRS = "D" + Convert.ToString(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_READ_OFFSET).ToUpper();
                //DeviceNameRP = "D" + Convert.ToString(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_READ_OFFSET + DEFINE.PROC_DATA_OFFSET).ToUpper();
                DeviceNameRP = "D" + Convert.ToString(PLCDataTag.BASE_MAIN_PC_RW_ADDR + DEFINE.L_PC_DATA_OFFSET).ToUpper();

                while (threadFlag)
                {
                    ReadDeviceBlock(DeviceNameWS, PLCDataTag.VisionStatusSize, out PLCDataTag.SData);
                    for (int i = 0; i < PLCDataTag.VisionStatusSize; i++)
                        PLCDataTag.RData[i + DEFINE.MX_ARRAY_WSTAT_OFFSET] = (Int16)PLCDataTag.SData[i];

                    // Read PC Data
                    ReadDeviceBlock(DeviceNameRP, PLCDataTag.ProcessSize, out PLCDataTag.SData);
                    for (int i = 0; i < PLCDataTag.ProcessSize; i++)
                        PLCDataTag.RData[i + DEFINE.MX_ARRAY_RPROC_OFFSET] = (Int16)PLCDataTag.SData[i];

                    //ReadDeviceBlock(DeviceNameWP, PLCDataTag.ProcessSize, out PLCDataTag.PData);
                    //for (int i = 0; i < PLCDataTag.ProcessSize; i++)
                    //    PLCDataTag.RData[i + DEFINE.MX_ARRAY_WPROC_OFFSET] = (Int16)PLCDataTag.PData[i];

                    ReadDeviceBlock(DeviceNameRS, PLCDataTag.PLCStatusSize, out PLCDataTag.SData);
                    for (int i = 0; i < PLCDataTag.PLCStatusSize; i++)
                        //PLCDataTag.RData[i + DEFINE.MX_ARRAY_WSTAT_OFFSET] = (Int16)PLCDataTag.SData[i];
                    PLCDataTag.RData[i + DEFINE.MX_ARRAY_RSTAT_OFFSET] = (Int16)PLCDataTag.SData[i];

                    //ReadDeviceBlock(DeviceNameRP, PLCDataTag.ProcessSize, out PLCDataTag.PData);
                    //for (int i = 0; i < PLCDataTag.ProcessSize; i++)
                    //    //PLCDataTag.RData[i + DEFINE.MX_ARRAY_WPROC_OFFSET] = (Int16)PLCDataTag.PData[i];
                    //PLCDataTag.RData[i + DEFINE.MX_ARRAY_RPROC_OFFSET] = (Int16)PLCDataTag.PData[i];

                    //     Buffer.BlockCopy(PLCDataTag.BData, 0, PLCDataTag.RData, 0, PLCDataTag.ReadSize);
                    Thread.Sleep(5);
                }
            }
        }
        public static void TwoWordtoDouble(int _highWord, int _lowWord, ref double _dbval)
        {
            int num = 0;
            num = (_highWord << 0x10) | _lowWord;
            _dbval = ((double)num) / 1000.0;
        }
        public static void WriteDevice(int szDevice, int lData)
        {
            //if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM) return;

            Mutex_lock_WD.WaitOne();

            string DeviceName;
            DeviceName = "D" + Convert.ToString(szDevice).ToUpper();

            try
            {
                int[] setValue = new int[] { lData };
                int nRet = MCClient.FuncPlcWriteSend(DeviceName.Substring(0, 1), DeviceName.Remove(0, 1), 1, setValue);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                Mutex_lock_WD.ReleaseMutex();
            }

        }
        public static void WriteDeviceBlock(int szDevice, int lSize, ref int[] lplData)
        {
            if (Main.DEFINE.OPEN_F || Main.DEFINE.OPEN_CAM) return;
            Mutex_lock_WD.WaitOne();

            string DeviceName;
            DeviceName = "D" + Convert.ToString(szDevice).ToUpper();

            try
            {
                int[] setValue = new int[lSize];
                setValue = lplData;
                MCClient.FuncPlcWriteSend(DeviceName.Substring(0, 1), DeviceName.Remove(0, 1), lSize, setValue);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Source + ex.Message + ex.StackTrace);
            }
            finally
            {
                Mutex_lock_WD.ReleaseMutex();
            }
        }

    }

}
