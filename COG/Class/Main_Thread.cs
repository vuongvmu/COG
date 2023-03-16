using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JAS.Interface.localtime;
namespace COG
{
     public partial class Main
    {
        //-----------------------------------------------------Thread 관련-----------------------------------------------------------------
        private static bool threadFlag;
        private static bool bShowingPMMode = false;
        private static Form_PMMode FormPMMode = new Form_PMMode();

        private static List<Thread> AlignUnitThread = new List<Thread>();
        private static List<Thread> CAMThread = new List<Thread>();

        private static MTickTimer m_Timer = new MTickTimer();
        private static MTickTimer m_AliveTimer = new MTickTimer();

        SetlocalTime.SYSTEMTIME _SetTime = new SetlocalTime.SYSTEMTIME();

        #region Thread Define
        private static Thread ThreadCAM0;
        private static Thread ThreadCAM1;
        private static Thread ThreadCAM2;
        private static Thread ThreadCAM3;
        private static Thread ThreadCAM4;
        private static Thread ThreadCAM5;
        private static Thread ThreadCAM6;
        private static Thread ThreadCAM7;
        private static Thread ThreadCAM8;
        private static Thread ThreadCAM9;
        private static Thread ThreadCAM10;
        private static Thread ThreadCAM11;

        private static Thread ThreadProcM;
        private static Thread ThreadWatchCCLinkMachine;
        private static Thread ThreadPLCRead;

        private static Thread ThreadProc0;
        private static Thread ThreadProc1;
        private static Thread ThreadProc2;
        private static Thread ThreadProc3;
        private static Thread ThreadProc4;
        private static Thread ThreadProc5;
        private static Thread ThreadProc6;
        private static Thread ThreadProc7;
        private static Thread ThreadProc8;

        private static Thread ThreadProc9;
        private static Thread ThreadProc10;
        private static Thread ThreadProc11;
        private static Thread ThreadProc12;
        private static Thread ThreadProc13;
        private static Thread ThreadProc14;
        private static Thread ThreadProc15;
        private static Thread ThreadProc16;
        private static Thread ThreadProc17;


        private static Thread ThreadProcDir;

        public enum eInspectionSequence
        {
            Stop,
            Start,
            End,
            Error
        }

        #endregion

        #region CAM관련 Thread
        public static void ThreadCAM_Initial_Start()
        {
            // PJH_Modify_20220819_Flying Vision_S
            ThreadCAM0 = new Thread(new ThreadStart(ThreadCAM_0));
            //ThreadCAM1 = new Thread(new ThreadStart(ThreadCAM_1));
            //ThreadCAM2 = new Thread(new ThreadStart(ThreadCAM_2));
            //ThreadCAM3 = new Thread(new ThreadStart(ThreadCAM_3));

            //ThreadCAM4 = new Thread(new ThreadStart(ThreadCAM_4));
            //ThreadCAM5 = new Thread(new ThreadStart(ThreadCAM_5));
            //ThreadCAM6 = new Thread(new ThreadStart(ThreadCAM_6));
            //ThreadCAM7 = new Thread(new ThreadStart(ThreadCAM_7));
            // PJH_Modify_20220819_Flying Vision_E

            //ThreadCAM8 = new Thread(new ThreadStart(ThreadCAM_8));
            //ThreadCAM9 = new Thread(new ThreadStart(ThreadCAM_9));
            //ThreadCAM10 = new Thread(new ThreadStart(ThreadCAM_10));
            //ThreadCAM11 = new Thread(new ThreadStart(ThreadCAM_11));

            // PJH_Modify_20220819_Flying Vision_S
            CAMThread.Add(ThreadCAM0);
            //CAMThread.Add(ThreadCAM1);
            //CAMThread.Add(ThreadCAM2);
            //CAMThread.Add(ThreadCAM3);

            //CAMThread.Add(ThreadCAM4);
            //CAMThread.Add(ThreadCAM5);
            //CAMThread.Add(ThreadCAM6);
            //CAMThread.Add(ThreadCAM7);
            // PJH_Modify_20220819_Flying Vision_E

            //CAMThread.Add(ThreadCAM8);
            //CAMThread.Add(ThreadCAM9);
            //CAMThread.Add(ThreadCAM10);
            //CAMThread.Add(ThreadCAM11);

            // PJH_Modify_20220819_Flying Vision_S
            //for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
            for (int i = 0; i < Main.DEFINE.CAM_MAX; i++)
            // PJH_Modify_20220819_Flying Vision_E
            {
                CAMThread[i].SetApartmentState(ApartmentState.STA);
                CAMThread[i].Start();
            }
        }
        public static void ThreadCAM_Stop()
        {
            threadFlag = false;
            Thread.Sleep(500);
            int count = CAMThread.Count;
            for (int i = 0; i < count; i++)
            {
                if (CAMThread[i] != null)
                {
                    if (CAMThread[i].IsAlive) CAMThread[i].Abort();
                }

            }
        }
        private static void ThreadCAM_0()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[0] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(0)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_1()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[1] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(1)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_2()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[2] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(2)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_3()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[3] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(3)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_4()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[4] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(4)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_5()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[5] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(5)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_6()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[6] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(6)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_7()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[7] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(7)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_8()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[8] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(8)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_9()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[9] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(9)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_10()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[10] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(10)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadCAM_11()
        {
            while (threadFlag)
            {
                if (Main.vision.Grab_Flag_Start[11] == true)
                {
                    while (true)
                    {
                        if (ImageGrab(11)) break;
                    }
                }
                Thread.Sleep(1);
            }
        }


        #endregion

        #region Main Thread & AlignUnit Thread & PLC Read Thread
        public static void Thread_Initial_Start()
        {
            threadFlag = true;

            //ThreadProcM = new Thread(new ThreadStart(ThreadProc_MMM));
            ThreadWatchCCLinkMachine = new Thread(new ThreadStart(ThreadProc_MachineStatus));
            ThreadPLCRead = new Thread(new ThreadStart(ThreadPLC_Read));

            //ThreadProcM.SetApartmentState(ApartmentState.STA);
            ThreadWatchCCLinkMachine.SetApartmentState(ApartmentState.STA);
            ThreadPLCRead.SetApartmentState(ApartmentState.STA);

            //ThreadProcM.Start();
            ThreadWatchCCLinkMachine.Start();
            ThreadPLCRead.Start();

            ThreadProcDir = new Thread(new ThreadStart(ThreadDIR_Delete));
            ThreadProcDir.SetApartmentState(ApartmentState.STA);
            ThreadProcDir.Start();



            ThreadProc0 = new Thread(new ThreadStart(ThreadProc_0));
            ThreadProc1 = new Thread(new ThreadStart(ThreadProc_1));
            ThreadProc2 = new Thread(new ThreadStart(ThreadProc_2));
            ThreadProc3 = new Thread(new ThreadStart(ThreadProc_3));
            ThreadProc4 = new Thread(new ThreadStart(ThreadProc_4));
            ThreadProc5 = new Thread(new ThreadStart(ThreadProc_5));
            ThreadProc6 = new Thread(new ThreadStart(ThreadProc_6));
            ThreadProc7 = new Thread(new ThreadStart(ThreadProc_7));
            ThreadProc8 = new Thread(new ThreadStart(ThreadProc_8));

            ThreadProc9 = new Thread(new ThreadStart(ThreadProc_9));
            ThreadProc10 = new Thread(new ThreadStart(ThreadProc_10));
            ThreadProc11 = new Thread(new ThreadStart(ThreadProc_11));
            ThreadProc12 = new Thread(new ThreadStart(ThreadProc_12));
            ThreadProc13 = new Thread(new ThreadStart(ThreadProc_13));
            ThreadProc14 = new Thread(new ThreadStart(ThreadProc_14));
            ThreadProc15 = new Thread(new ThreadStart(ThreadProc_15));
            ThreadProc16 = new Thread(new ThreadStart(ThreadProc_16));
            ThreadProc17 = new Thread(new ThreadStart(ThreadProc_17));


            AlignUnitThread.Add(ThreadProc0);
            AlignUnitThread.Add(ThreadProc1);
            AlignUnitThread.Add(ThreadProc2);
            AlignUnitThread.Add(ThreadProc3);
            AlignUnitThread.Add(ThreadProc4);
            AlignUnitThread.Add(ThreadProc5);
            AlignUnitThread.Add(ThreadProc6);
            AlignUnitThread.Add(ThreadProc7);
            AlignUnitThread.Add(ThreadProc8);

            AlignUnitThread.Add(ThreadProc9);
            AlignUnitThread.Add(ThreadProc10);
            AlignUnitThread.Add(ThreadProc11);
            AlignUnitThread.Add(ThreadProc12);
            AlignUnitThread.Add(ThreadProc13);
            AlignUnitThread.Add(ThreadProc14);
            AlignUnitThread.Add(ThreadProc15);
            AlignUnitThread.Add(ThreadProc16);
            AlignUnitThread.Add(ThreadProc17);




            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                AlignUnitThread[i].SetApartmentState(ApartmentState.STA);
                AlignUnitThread[i].Start();
            }

            //             ThreadPriority.Highest      //스레드 가장 높은 우선권
            //             ThreadPriority.AboveNormal  //스레드      높은 우선권
            //             ThreadPriority.Normal       //스레드      평균 우선권 // default
            //             ThreadPriority.BelowNormal  //스레드      낮은 우선권
            //             ThreadPriority.Lowest       //스레드 가장 낮은 우선권 
            //             ThreadProc0.Priority  = ThreadPriority.Highest;
            //    스레드는 제일 먼저 실행한 스레드가 제일 늦게 진행 되고 제일 늦게 시작한 스레드가  제일 빨리 진행된다. 
        }
        public static void Thread_Stop()
        {
            threadFlag = false;
            Thread.Sleep(500);
            if (ThreadProcM != null)
            {
                if (ThreadProcM.IsAlive) ThreadProcM.Abort();
            }
            if (ThreadWatchCCLinkMachine != null)
            {
                if (ThreadWatchCCLinkMachine.IsAlive) ThreadWatchCCLinkMachine.Abort();
            }
            if (ThreadPLCRead != null)
            {
                if (ThreadPLCRead.IsAlive) ThreadPLCRead.Abort();
            }
            if (ThreadProcDir != null)
            {
                if (ThreadProcDir.IsAlive) ThreadProcDir.Abort();
            }
            //-----------------------------------------------------------------
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                if (AlignUnitThread[i] != null)
                {
                    if (AlignUnitThread[i].IsAlive) AlignUnitThread[i].Abort();
                }
            }
            //-------------------------------------------------

            Thread.Sleep(500);
        }

        private static void ThreadProc_MachineStatus()
        {
            while (threadFlag)
            {
                LoopAlive();

                if (CCLink.IsBit(DEFINE.CCLINK_IN_AUTO_READY) == true)
                {
                    string LogMsg = " ";

                    if (Status.MC_STATUS != DEFINE.MC_RUN && Status.MC_STATUS == DEFINE.MC_STOP && Main.Status.MC_MODE == Main.DEFINE.MC_MAINFORM)
                    {
                        Main.PLC_AUTO_READY = true;
                    }
                }
                else
                    Main.PLC_AUTO_READY = false;


                #region CCLINK_MODEL_CHANGE
                if (CCLink.IsBit(DEFINE.CCLINK_IN_LOC_PPID_MODEL_CHANGE_REQ) == true)
                {
                    string LogMsg = " ";

                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && Main.MODEL_COPY == true)
                    {
                        Main.ProjectRename(Main.MODEL_COPY_NAME, Main.MODEL_COPY_INFO);
                        Main.MODEL_COPY = false;
                    }

                    if (ProjectLoad(PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_CHANGE_MODEL_NUMBER].ToString("000")))
                    {
                        CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                        LogMsg = "MODEL: " + ProjectName + ProjectInfo + " LOAD OK";
                    }
                    else
                    {
                        //CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_CHANGE_MODEL_NUMBER].ToString("000") + " LOAD NG";
                    }
                    Main.CCLink_OffCheckOffHandshake(DEFINE.CCLINK_IN_LOC_PPID_MODEL_CHANGE_REQ, DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, DEFINE.NORMAL_HANDSHAKE_TIMEOUT, 0);
                    Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                    //CmdCheck();
                }
                #endregion

                #region CCLINK_MODEL_COPY
                if (CCLink.IsBit(DEFINE.CCLINK_IN_LOC_PPID_COPY_REQ) == true)
                {
                    string LogMsg = " ";

                    if (ProjectCopy(PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_TARGET_MODEL_NUMBER].ToString("000"),
                        PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000")))
                    {
                        CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_COPY_COMP, true);

                        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000") + " COPY OK";
                    }
                    else
                    {
                        //CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000") + " COPY NG";
                    }
                    Main.CCLink_OffCheckOffHandshake(DEFINE.CCLINK_IN_LOC_PPID_COPY_REQ, DEFINE.CCLINK_OUT_LOC_PPID_COPY_COMP, DEFINE.NORMAL_HANDSHAKE_TIMEOUT, 0);
                    Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                    //CmdCheck();
                }
                #endregion

                #region CCLINK_MODEL_DELETE
                if (CCLink.IsBit(DEFINE.CCLINK_IN_LOC_PPID_DELETE_REQ) == true)
                {
                    string LogMsg = " ";

                    if (ProjectDelete(PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_DELETE_MODEL_NUMBER].ToString("000")))
                    {
                        CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_DELETE_COMP, true);

                        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_DELETE_MODEL_NUMBER].ToString("000") + " DELETE OK";
                    }
                    else
                    {
                        //CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000") + " DELETE NG";
                    }
                    Main.CCLink_OffCheckOffHandshake(DEFINE.CCLINK_IN_LOC_PPID_DELETE_REQ, DEFINE.CCLINK_OUT_LOC_PPID_DELETE_COMP, DEFINE.NORMAL_HANDSHAKE_TIMEOUT, 0);
                    Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                    //CmdCheck();
                }
                #endregion

                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    string LogMsg = " ";

                    bool bBusy = false;
                    for (int i = 0; i < DEFINE.AlignUnit_Max; i++)
                    {
                        if (AlignUnit[i].m_UnitBusy == true)
                            bBusy = true;
                    }

                    if (bBusy == true)
                        Main.CCLink_PutBit(DEFINE.CCLINK_OUT_VISION_BUSY, true);
                    else
                        Main.CCLink_PutBit(DEFINE.CCLINK_OUT_VISION_BUSY, false);


                    #region CCLINK_IN_TIME_CHANGE_REQ
                    if (CCLink.IsBit(DEFINE.CCLINK_IN_TIME_CHANGE_REQ) == true)
                    {
                        SetlocalTime.SYSTEMTIME _SetTime = new SetlocalTime.SYSTEMTIME();
                        _SetTime = SetlocalTime.GetTime();
                        _SetTime.wYear = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 0];   //(ushort)
                        _SetTime.wMonth = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 1];   //(ushort)
                        _SetTime.wDay = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 2];   //(ushort)
                        _SetTime.wHour = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 3];   //(ushort)
                        _SetTime.wMinute = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 4];   //(ushort)
                        _SetTime.wSecond = (ushort)PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.YEAR + 5];   //(ushort)

                        //                                _SetTime.wHour = (ushort)(_SetTime.wHour % 24);
                        int _ErrorCode = 0;
                        if (SetlocalTime.SetLocalTime_(_SetTime, ref _ErrorCode))
                        {
                            LogMsg = "LocalTime Changed OK";
                        }
                        else
                        {
                            LogMsg = "LocalTime Changed NG" + " ,ErrorCode:" + _ErrorCode.ToString();
                        }
                        Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                        //Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_CMD, 0);
                        CCLink.PutBit(DEFINE.CCLINK_OUT_TIME_CHANGE_COMP, true);
                        CmdCheck();
                    }
                    #endregion

                    #region CCLINK_VISION_RESET
                    if (CCLink.IsBit(DEFINE.CCLINK_IN_ERROR_RESET) == true)
                    {
                        for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
                        {
                            Main.AlignUnit[i].m_UnitBusy = false;
                        }
                        
                        Main.AlignUnit[0].LogdataDisplay("VISION ERROR RESET", true);
                    }
                    #endregion

                    //#region CCLINK_MODEL_CHANGE
                    //if (CCLink.IsBit(DEFINE.CCLINK_IN_LOC_PPID_MODEL_CHANGE_REQ) == true)
                    //{
                    //    if (ProjectLoad(PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_CHANGE_MODEL_NUMBER].ToString("000")))
                    //    {
                    //        CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                    //        LogMsg = "MODEL: " + ProjectName + ProjectInfo + " LOAD OK";
                    //    }
                    //    else
                    //    {
                    //        //CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);
                            
                    //        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_CHANGE_MODEL_NUMBER].ToString("000") + " LOAD NG";
                    //    }
                    //    Main.CCLink_OffCheckOffHandshake(DEFINE.CCLINK_IN_LOC_PPID_MODEL_CHANGE_REQ, DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, DEFINE.NORMAL_HANDSHAKE_TIMEOUT, 0);
                    //    Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                    //    //CmdCheck();
                    //}
                    //#endregion

                    //#region CCLINK_MODEL_COPY
                    //if (CCLink.IsBit(DEFINE.CCLINK_IN_LOC_PPID_COPY_REQ) == true)
                    //{
                    //    if (ProjectCopy(PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_TARGET_MODEL_NUMBER].ToString("000"),
                    //        PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000")))
                    //    {
                    //        CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_COPY_COMP, true);

                    //        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000") + " COPY OK";
                    //    }
                    //    else
                    //    {
                    //        //CCLink.PutBit(DEFINE.CCLINK_OUT_LOC_PPID_MODEL_CHANGE_COMP, true);

                    //        LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.MX_ARRAY_RSTAT_OFFSET + Main.DEFINE.PPID_COPY_MODEL_NUMBER].ToString("000") + " COPY NG";
                    //    }
                    //    Main.CCLink_OffCheckOffHandshake(DEFINE.CCLINK_IN_LOC_PPID_COPY_REQ, DEFINE.CCLINK_OUT_LOC_PPID_COPY_COMP, DEFINE.NORMAL_HANDSHAKE_TIMEOUT, 0);
                    //    Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                    //    //CmdCheck();
                    //}
                    //#endregion

                    if (!bShowingPMMode == false && CCLink.IsBit(DEFINE.CCLINK_IN_PM_MODE) == true)
                    {
                        FormPMMode.Show();
                        bShowingPMMode = true;
                    }
                    if (bShowingPMMode == true && CCLink.IsBit(DEFINE.CCLINK_IN_PM_MODE) == false)
                    {
                        bShowingPMMode = false;
                        FormPMMode.Hide();
                    }
                }
                if (DEFINE.OPEN_F)
                {
                    ///nCmd = PLCDataTag.RData[DEFINE.PLC_CMD] = 0;
                    //nstatus = PLCDataTag.RData[DEFINE.VIS_STATUS] = 0;
                }
                Thread.Sleep(30);
            }
        }

        private static void LoopAlive()
        {
            if (Main.DEFINE.OPEN_F)
                return;

            if (m_AliveTimer.IsStarted() == false)
            {
                m_AliveTimer.StartTimer();
            }

            if (m_AliveTimer.GetElapsedTime() >= 1000)
            {
                if (CCLink.IsBit(DEFINE.CCLINK_OUT_ALIVE) == false)
                {
                    CCLink.PutBit(DEFINE.CCLINK_OUT_ALIVE, true);
                    Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.ALIVE, 1);

                    if (CCLink.IsBit(DEFINE.CCLINK_OUT_ALIVE) == true)
                        PLCALIVE = true;
                    else
                        PLCALIVE = false;
                }
                else
                {
                    CCLink.PutBit(DEFINE.CCLINK_OUT_ALIVE, false);
                    Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + Main.DEFINE.ALIVE, 0);

                    if (CCLink.IsBit(DEFINE.CCLINK_OUT_ALIVE) == false)
                        PLCALIVE = true;
                    else
                        PLCALIVE = false;
                }

                m_AliveTimer.StartTimer();
            }
        }

        private static void ThreadProc_MMM()
        {

            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    int nCmd, nstatus;
                    string LogMsg=" ";
                    nCmd = PLCDataTag.RData[DEFINE.PLC_CMD];
                    nstatus = PLCDataTag.RData[DEFINE.VIS_STATUS];
                    if (nstatus == 0 && nCmd != 0)
                    {
                        switch (nCmd)
                        {
                            case 6000:
//                                 Main.SystemTime ServerTime = new Main.SystemTime();
//                                 DateTime tmpdate = new DateTime(PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.YEAR], PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.MONTH],
//                                 PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.DAY], PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.HOUR],
//                                 PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.MINUTE], PLCDataTag.RData[PLCDataTag.BASE_RW_ADDR + Main.DEFINE.SECONDS]);
//                                 tmpdate = tmpdate.AddHours(-9);
// 
//                                 ServerTime.sYear = (ushort)tmpdate.Year;
//                                 ServerTime.sMonth = (ushort)tmpdate.Month;
//                                 ServerTime.sDay = (ushort)tmpdate.Day;
//                                 ServerTime.sHour = (ushort)tmpdate.Hour;
//                                 ServerTime.sMinute = (ushort)tmpdate.Minute;
//                                 ServerTime.sSecond = (ushort)tmpdate.Second;
//                                 Form_Main.SetSystemTime(ServerTime);

                                SetlocalTime.SYSTEMTIME _SetTime = new SetlocalTime.SYSTEMTIME();
                                _SetTime = SetlocalTime.GetTime();
                                _SetTime.wYear      = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 0];   //(ushort)
                                _SetTime.wMonth     = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 1];   //(ushort)
                                _SetTime.wDay       = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 2];   //(ushort)
                                _SetTime.wHour      = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 3];   //(ushort)
                                _SetTime.wMinute    = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 4];   //(ushort)
                                _SetTime.wSecond    = (ushort)PLCDataTag.RData[Main.DEFINE.YEAR + 5];   //(ushort)

//                                _SetTime.wHour = (ushort)(_SetTime.wHour % 24);
                                 int _ErrorCode = 0;
                                 if (SetlocalTime.SetLocalTime_(_SetTime, ref _ErrorCode))
                                 {
                                     LogMsg = "LocalTime Changed OK";
                                 }
                                 else
                                 {                              
                                     LogMsg = "LocalTime Changed NG" + " ,ErrorCode:"+_ErrorCode.ToString();
                                 }
                                Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                                Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_CMD, 0);
                                CmdCheck();
                                break;
                            case 8000:  //에러처리함
                                 if (ProjectLoad(PLCDataTag.RData[DEFINE.PLC_MODEL_CODE].ToString("000")))
                                 { 
                                     Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_CMD, 0);
                                     Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.VIS_STATUS, nCmd);
                                     LogMsg = "MODEL: " + ProjectName + ProjectInfo + " LOAD OK";
                                 }
                                 else
                                 {
                                     Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_CMD, 0);
                                     Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.VIS_STATUS, -nCmd);
                                     LogMsg = "MODEL: " + PLCDataTag.RData[DEFINE.PLC_MODEL_CODE].ToString("000") + " LOAD NG";
                                 }
                                 LogMsg = "<- " + LogMsg;
                                 Main.AlignUnit[0].LogdataDisplay(LogMsg, true);
                                 CmdCheck();
                                break;


                            case 9000:
                                for (int i = 0; i < DEFINE.AlignUnit_Max; i++)
                                {
                                    AlignUnit[i].ClearPlcCmd();
                                }
                                Main.WriteDevice(PLCDataTag.BASE_RW_ADDR + DEFINE.PLC_CMD, 0);
                                CmdCheck();
                                break;   
                         }
            
                    }
                    if(DEFINE.OPEN_F)
                    {
                        nCmd = PLCDataTag.RData[DEFINE.PLC_CMD] = 0;
                        nstatus = PLCDataTag.RData[DEFINE.VIS_STATUS] = 0;
                    }
                }
                Thread.Sleep(30);
            }
        }
        private static void CmdCheck()
        {
            int seq = 0;
            bool LoopFlag = true;

            while (LoopFlag)
            {
                switch (seq)
                {
                    case 0:
                        m_Timer.StartTimer();
                        seq++;
                        break;

                    case 1:
                        if (m_Timer.GetElapsedTime() > DEFINE.CMD_CHECK_TIMEOUT)
                        {
                            seq = SEQ.COMPLET_SEQ;
                            break;
                        }
                        if (PLCDataTag.RData[DEFINE.PLC_CMD] != 0)
                            break;
                        else
                            seq = SEQ.COMPLET_SEQ;
                        break;

                    case SEQ.COMPLET_SEQ:
                        LoopFlag = false;
                        break;

                }

            }

        }
        private static void ThreadProc_0()
        {
            //bool bret = false;
            //eInspectionSequence tt = eInspectionSequence.End;
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        //switch (tt)
                        //{
                        //    case eInspectionSequence.Start:
                        //        // 검사 던짐
                        //        // end로 바꾸고
                        //        break;

                        //    case eInspectionSequence.End:
                        //        // 결과 안오면 여기 계속 타면서 검사결과 대기
                        //        if(ATTWrapper.AWGetATTResultData(nStageNo, nTapNo, ref ATTInspFilter, ref AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult[0].m_AkkonResult))
                        //        {
                        //            tt = eInspectionSequence.Stop;
                        //        }
                        //        else
                        //            tt = eInspectionSequence.End;

                        //        break;

                        //    case eInspectionSequence.Stop:
                        //        Status.MC_STATUS == DEFINE.MC_RUN) 변경
                        //            eInspectionSequence.Start;
                        //        break;
                        //}
                        /*
                        //AlignUnit[0].ExecuteCMD();
                        //AlignUnit[0].ReceiveCommand();
                        if(bret ==false )
                        {
                            // 검사 던저
                            bret = true;
                            Main.ATT_AkkonInspcetion();
                        }
                        else
                        {
                            
                        }
                        ATTWrapper.AWGetATTResultData(nStageNo, nTapNo, ref ATTInspFilter, ref AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult[0].m_AkkonResult);
                        */
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_1()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        //AlignUnit[1].ExecuteCMD();
                        /////////////잠시 주석 jyh /////////////////
                        //AlignUnit[1].ReceiveCommand();
                        //Main.ATT_AkkonInspcetion(AlignUnit[0].CamNo, AlignUnit[0].StageNo, 0, AlignUnit[0].PAT[0, 0].m_CogLineScanBuf);
                        ////////////////////////////////////////////

                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_2()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        //AlignUnit[2].ExecuteCMD();
                        AlignUnit[2].ReceiveCommand();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_3()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        //AlignUnit[3].ExecuteCMD();
                        AlignUnit[3].ReceiveCommand();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_4()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[4].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_5()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[5].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_6()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[6].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_7()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[7].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_8()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[8].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_9()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[9].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }

        private static void ThreadProc_10()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        try
                        {
                            AlignUnit[10].ExecuteCMD();
                        }
                        catch
                        {

                        }
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_11()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[11].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_12()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[12].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_13()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[13].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_14()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[14].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_15()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[15].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_16()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[16].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }
        private static void ThreadProc_17()
        {
            while (threadFlag)
            {
                if (Status.MC_STATUS == DEFINE.MC_RUN)
                {
                    try
                    {
                        AlignUnit[17].ExecuteCMD();
                    }
                    catch
                    {

                    }
                }
                Thread.Sleep(1);
            }
        }








        #endregion












    }//Main
}//COG
