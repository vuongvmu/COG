using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using OpenCvSharp;

using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Implementation.Internal;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.CNLSearch;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.SearchMax;
using Cognex.VisionPro.LineMax;

using AW;
using System.Threading;

namespace COG
{

    public partial class Main
    {
        // 210416 ATT
        private static CATTWrapper ATTWrapper = new CATTWrapper();

        public static MVINSPPARA ATTInspParam = new MVINSPPARA();
        public static MVINSP_OPTION ATTInspOption = new MVINSP_OPTION();
        public static MVAKKONFILTER ATTInspFilter = new MVAKKONFILTER();
        public static MVDRAWOPTION ATTDrawOption = new MVDRAWOPTION();
        public static System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        public static string[] strtmp = new string[10];
        public static List<COG.Class.InspectionResult.AkkonInspectionResult> AkkonResultList = new List<COG.Class.InspectionResult.AkkonInspectionResult>();
        public static List<COG.Class.InspectionResult.AlignInspectionResult> alignResultList = new List<COG.Class.InspectionResult.AlignInspectionResult>();
        //
        static List<List<int>> m_vvSliceOverlap;    // Stage, Tap
        static List<List<int>> m_vvTotalSliceCnt;   // Stage, Tap

        public static bool isFormTeaching = false;

        // PJH_20221013_S
        //public static void cbProgress(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //    }
        //}
        public static void cbProgress(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        {
            unsafe
            {
                ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
                Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
                AkkonInspectionDoneEvent.Set();
            }
        }

        //public static void cbProgress1(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //        Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
        //        AkkonInspectionDoneEvent.Set();
        //    }
        //}
        //public static void cbProgress2(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //        Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
        //        AkkonInspectionDoneEvent.Set();
        //    }
        //}
        //public static void cbProgress3(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //        Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
        //        AkkonInspectionDoneEvent.Set();
        //    }
        //}
        //public static void cbProgress4(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //        Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
        //        AkkonInspectionDoneEvent.Set();
        //    }
        //}
        //public static void cbProgress5(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    unsafe
        //    {
        //        ATT_ResultProcess(nStageNo, nTapNo, bSliceInsp, nError);
        //        Console.WriteLine("ATT_Completed - Stage : " + nStageNo.ToString() + " / Tap : " + nTapNo.ToString() + " [" + DateTime.Now.ToString() + "]\n");
        //        AkkonInspectionDoneEvent.Set();
        //    }
        //}
        // YSH Test
        public static CALLBACKFUNC cb = new CALLBACKFUNC(cbProgress); //콜백함수 선언


        //public static CALLBACKFUNC[] cb2 = new CALLBACKFUNC[5];
 

        private static ManualResetEvent AkkonInspectionDoneEvent = new ManualResetEvent(false);
        public static bool SendInspection(int nCamNo, int nStageNo, int nTapNo, CogImage8Grey cogImage, int tabCount)
        {
            AkkonInspectionDoneEvent.Reset();

            ATT_AkkonInspcetion(nCamNo, nStageNo, tabCount, cogImage);
            return AkkonInspectionDoneEvent.WaitOne(60000);
        }
        /// <summary>
        /// ATT System 초기화
        /// </summary>
        /// <param name="pHandle">프로그램 핸들</param>
        /// <param name="nThreadCnt">Thread 할당 개수</param>
        /// <param name="nCoreMask">ATT할당 CPU Core 마스크 (SetThreadAffinityMask)</param>
        /// <returns></returns>
        public static void ATT_InitSystem(IntPtr pHandle, int nThreadCnt, UInt32 nCoreMask)
        {
            ATTWrapper.AWCreateProcessingThread();
            ATTWrapper.AWCreateAttThread(pHandle, nThreadCnt, nCoreMask);

            m_vvSliceOverlap = new List<List<int>>();
            m_vvTotalSliceCnt = new List<List<int>>();

            m_vvSliceOverlap.Clear();
            m_vvTotalSliceCnt.Clear();

            List<int> vSliceOverLap = new List<int>();
            List<int> vTotalSliceCnt = new List<int>();

            vSliceOverLap.Clear();
            vTotalSliceCnt.Clear();

            for (int panelUnitCount = 0; panelUnitCount < DEFINE.PANEL_UNIT_MAX; panelUnitCount++)
            {
                for (int tabUnitCount = 0; tabUnitCount < DEFINE.TAP_UNIT_MAX; tabUnitCount++)
                {
                    vSliceOverLap.Add(0);
                    vTotalSliceCnt.Add(0);
                }
                m_vvSliceOverlap.Add(vSliceOverLap);
                m_vvTotalSliceCnt.Add(vTotalSliceCnt);
            }
            NativeMethods.CallBackRegistry(cb);
            //YSH 콜백 테스트
            //for (int i = 0; i < 5; i++)
            //{
            //    if(i==0)
            //        cb2[i] = new CALLBACKFUNC(cbProgress1);
            //    else if(i == 1)
            //        cb2[i] = new CALLBACKFUNC(cbProgress2);
            //    else if (i == 2)
            //        cb2[i] = new CALLBACKFUNC(cbProgress3);
            //    else if (i == 3)
            //        cb2[i] = new CALLBACKFUNC(cbProgress4);
            //    else if (i == 4)
            //        cb2[i] = new CALLBACKFUNC(cbProgress5);

            //    NativeMethods.CallBackRegistry(cb2[i]);
            //}
        }
        // PJH_20221013_S

        /// <summary>
        /// ATT DLL Manger 초기화
        /// Slice Image Buffer 초기화
        /// </summary>
        /// <returns></returns>
        public static void ATT_CreateDLLBuffer()
        {
            ATTWrapper.AWFreeInspectionFlag();
            ATTWrapper.AWDeleteInspManager();
            ATTWrapper.AWCreateInspManager(DEFINE.PANEL_UNIT_MAX, DEFINE.TAP_UNIT_MAX);
            ATTWrapper.AWCreateAttSliceImageBuffer(DEFINE.TAP_UNIT_MAX, DEFINE.ATT_THREAD_MAX, DEFINE.LINE_PAGE_LENGTH, Main.AlignUnit[0].PAT[0, 0].m_OrginalImgRows, Main.DEFINE.ImageResizeRatio); // CamNo?
        }

        /// <summary>
        /// ATT Image Buffer 초기화
        /// (Main.vision.IMAGE_SIZE_X가 모든 탭 같을 때 사용)
        /// </summary>
        /// <returns></returns>
        public static void ATT_CreateImageBuffer()
        {
            for (int panelUnitCount = 0; panelUnitCount < DEFINE.PANEL_UNIT_MAX; panelUnitCount++)
            {
                for (int tabUnitCount = 0; tabUnitCount < DEFINE.TAP_UNIT_MAX; tabUnitCount++)
                {
                    ATTWrapper.AWCreateAttFullImageBuffer(panelUnitCount, tabUnitCount, Main.AlignUnit[0].PAT[panelUnitCount, tabUnitCount].m_OrginalImgCols,
                        Main.AlignUnit[0].PAT[panelUnitCount, tabUnitCount].m_OrginalImgRows, Main.DEFINE.ImageResizeRatio);
                    //InitDefaultParameter(i, j);
                }
            }
        }
        // PJH_20221013_S

        /// <summary>
        /// ATT Image Buffer 초기화(탭별)
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <param name="nWidth">이미지 버퍼 길이</param>
        /// <param name="nHeight">이미지 버퍼 높이</param>
        /// <returns></returns>
        public static void ATT_CreateImageBuffer(int nStageNo, int nTapNo, int nWidth, int nHeight)
        {
            ATTWrapper.AWCreateAttFullImageBuffer(nStageNo, nTapNo, nWidth, nHeight, Main.DEFINE.ImageResizeRatio);
        }

        /// <summary>
        /// ATT 검사 시작(탭별)
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <returns>검사 시작 실패</returns>
        public static bool ATT_InspectByTap(int nCamNo, int nStageNo, int nTapNo)
        {
            Console.WriteLine("압흔검사요청[" + DateTime.Now.ToString() + "]");
            Console.WriteLine("ATT_InspectionByTap - nCamNo : " + nCamNo.ToString() + " / nStageNo : " + nStageNo.ToString() + " / nTapNo " + nTapNo.ToString());
            bool bRet = false;

            if (AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT.Length <= 0)
                return bRet;

            unsafe
            {
                //IntPtr unmanagedPointer = Marshal.AllocHGlobal(AlignUnit[nStageNo].PAT[0, nTapNo].m_imgDataATT.Length);
                //Marshal.Copy(AlignUnit[nStageNo].PAT[0, nTapNo].m_imgDataATT, 0, unmanagedPointer, AlignUnit[nStageNo].PAT[0, nTapNo].m_imgDataATT.Length);

                bRet = ATTWrapper.AWATTFullInspection(nStageNo, nTapNo, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.DataPointer,
                    AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows);

                //Console.WriteLine("ATTWrapper.AWATTFullInspection - " + bRet.ToString() + " [" + DateTime.Now.ToString() + "]");
                Console.WriteLine("ATTWrapper.AWATTFullInspection - " + bRet.ToString());
                Console.WriteLine("ATTWrapper.AWATTFullInspection - " + "nStageNo : " + nStageNo.ToString() + " / nTapNo : " + nTapNo.ToString());
                //Marshal.FreeHGlobal(unmanagedPointer);

                //int m_CamNo = 0;
                //CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[m_CamNo].OutputImage as CogImage8Grey);

                //Cognex.VisionPro.ImageFile.CogImageFileBMP imagecontrol = new Cognex.VisionPro.ImageFile.CogImageFileBMP();
                //string fileName = "D:\\MacronDllTrace\\Input.bmp";
                //try
                //{
                //    imagecontrol.Open(fileName, Cognex.VisionPro.ImageFile.CogImageFileModeConstants.Write);
                //    imagecontrol.Append(CogConvertImage);
                //    imagecontrol.Close();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //ICogImage8PixelMemory OriginImage8PixelMemory = CogConvertImage.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0, Main.vision.CogImgTool[m_CamNo].OutputImage.Width, Main.vision.CogImgTool[m_CamNo].OutputImage.Height);
                //ATTWrapper.AWATTFullInspection(nStageNo, nTapNo, (byte*)OriginImage8PixelMemory.Scan0.ToPointer(), AlignUnit[nStageNo].PAT[0, nTapNo].m_imgCols, AlignUnit[nStageNo].PAT[0, nTapNo].m_imgRows);
                //OriginImage8PixelMemory.Dispose();
            }
            return bRet;
        }
        // PJH_20221013_E

        /// <summary>
        /// ATT ROI 설정
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <param name="nLeadPoints">Lead Point 배열</param>
        /// <returns>ROI 설정 실패</returns>
        public static bool ATT_SendROI(int nStageNo, int nTapNo, int[][] nLeadPoints)
        {
            return ATTWrapper.AWReadROI(nStageNo, nTapNo, nLeadPoints, Main.DEFINE.ImageResizeRatio);
        }

        /// <summary>
        /// ATT 검사 준비
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <returns>검사 준비 실패</returns>
        public static bool ATT_ReadyToInsp(int nCamNo, int nStageNo, int nTapNo, Main.AkkonTagData AkkonParam)
        {
            int nOverlap = ATTWrapper.AWCalcSliceOverlap(nStageNo, nTapNo); // stage, tab 별로 Overlap 계산
            m_vvSliceOverlap[nStageNo][nTapNo] = nOverlap;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_nOverlap = m_vvSliceOverlap[nStageNo][nTapNo];

            unsafe
            {
                m_vvTotalSliceCnt[nStageNo][nTapNo] = ATTWrapper.AWCalcTotalSliceCnt(nStageNo, nTapNo, nOverlap, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows, false);
            }

            int[][] intSliceCnt = m_vvTotalSliceCnt.Select(list => list.ToArray()).ToArray();
            ATTWrapper.AWAllocInspectionFlag(intSliceCnt);  //검사 FLag 할당


            UpdateParameter(nCamNo, nStageNo, nTapNo, AkkonParam);

            ATTWrapper.AWSetAllPara(nStageNo, nTapNo, ref ATTInspParam, ref ATTInspFilter, ref ATTDrawOption, ref ATTInspOption);   // stage, tab 별 파라미터 세팅

            if (m_vvTotalSliceCnt[nStageNo][nTapNo] < 1)
            {
                MessageBox.Show("전체 조각수가 1이 되지 않습니다!!\n 조각수 계산을 확인하세요.!");

                return false;
            }

            return true;
        }

        public static bool ATT_CalcSliceOverlap(int nCamNo, int nStageNo, int nTapNo)
        {
            int nOverlap = ATTWrapper.AWCalcSliceOverlap(nStageNo, nTapNo); // stage, tab 별로 Overlap 계산
            m_vvSliceOverlap[nStageNo][nTapNo] = nOverlap;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_nOverlap = m_vvSliceOverlap[nStageNo][nTapNo];

            return true;
        }
        // PJH_20221013_E

        /// <summary>
        /// ATT 검사 결과 취득
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <returns></returns>
        public static void ATT_GetResult(int nCamNo, int nStageNo, int nTapNo)
        {
            unsafe
            {
                ATTWrapper.AWGetATTResultData(nStageNo, nTapNo, ref ATTInspFilter, ref AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray);

                int nCountSumdata = 0;
                double dLengthSumdata = 0;
                Byte flagInspectResult = 0;
                AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.FlagInspectionResultList.Clear();

                if (AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray.Length == 0 ||
                    AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[0].Length == 0)
                {
                    Console.WriteLine("Judgement : No Final Result!");
                    AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.Judge = false;
                    return;
                }

                //압흔결과 데이터 종합
                for (int i = 0; i < AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray.Length; i++)
                {
                    for (int j = 0; j < AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i].Length; j++)
                    {
                        nCountSumdata = nCountSumdata + AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_nNumBlobs;
                        dLengthSumdata = dLengthSumdata + AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_fLength;

                        if(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_nNumBlobs >= AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.JudgeCount)
                            flagInspectResult |= 1;

                        if (AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_fLength >= AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.JudgeLength)
                            flagInspectResult |= 2;

                        AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.FlagInspectionResultList.Add(flagInspectResult);

                        if(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.FlagInspectionResultList[i] == 0x00000003)
                            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_bJudgement = true;
                        else
                        {
                            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i][j].s_bJudgement = false;
                            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.Judge = false;
                            Console.WriteLine("Tab " + nTapNo.ToString() +" Lead : " + j.ToString() + " NG");
                        }
                    }
                    nCountSumdata = nCountSumdata / AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i].Length;
                    dLengthSumdata = dLengthSumdata / AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray[i].Length;
                }

                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonAverageCount = nCountSumdata;
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonAverageLength = dLengthSumdata * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);

                sw.Stop();
                Console.WriteLine("Inspection T/T [2]: " + sw.ElapsedMilliseconds.ToString() + "ms");
                sw.Reset();
            }

            //String strPath;
            //strPath = String.Format("D:\\MacronDllTrace\\result{0:D}_{1:D}.bmp", nStageNo, nTapNo);
            //Cv2.ImWrite(strPath, m_rstImage);
        }
        public static void ATT_GetResultImageView(int nCamNo, int nStageNo, int nTapNo)
        {
            unsafe
            {
                //shkang_s
                if (AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT == null)
                    return;
                // unmanagedPointer 이용 방법
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT.Length * 3);
                ATTWrapper.AWGetATTResultImage(nStageNo, nTapNo, ref ATTInspFilter, ref ATTDrawOption, (byte*)unmanagedPointer, 0);
                byte[] rstData = new byte[AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols * AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows * 3];
                Marshal.Copy(unmanagedPointer, rstData, 0, rstData.Length);  // 메모리 카피

                //AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatResultImage = new Mat(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Rows, 
                //    AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Cols, MatType.CV_8UC3);

                //ATTWrapper.AWGetATTResultImage(nStageNo, nTapNo, ref ATTInspFilter, ref ATTDrawOption, (byte*)AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatResultImage.DataPointer, 0);

                // OpenCV Color : bgrbgrbgrbgrbgrbgr...
                // Cognex Color : bbbbb...ggggg...rrrrr
                // 추후 DLL 단에서 R G B Split 해서 전달할 것임
                byte[] rearrdata = new byte[AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols * AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows * 3];
                for (int i = 0, j = 0; i < rstData.Length; i += 3, j++)
                {
                    rearrdata[j] = rstData[i + 0];
                    rearrdata[AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT.Length + j] = rstData[i + 1];
                    rearrdata[(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT.Length * 2) + j] = rstData[i + 2];
                }

                AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgOverlay = _ClsImage.ConvertColorImageToCognexImage(rearrdata, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows);
                Marshal.FreeHGlobal(unmanagedPointer);

                // opencv 거치는 방법
                //Mat m_rstImage = new Mat(AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols, MatType.CV_8UC3);
                //ATTWrapper.AWGetATTResultImage(nStageNo, nTapNo, ref ATTInspFilter, ref ATTDrawOption, (byte*)m_rstImage.DataPointer, 0);

                //AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgOverlay = _ClsImage.ConvertOCVColorImageToCognexImage(m_rstImage, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows);
            }

        }

        /// <summary>
        /// ATT 검사 파라미터 업데이트
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <returns></returns>
        public static void UpdateParameter(int nCamNo, int nStageNo, int nTapNo, Main.AkkonTagData AkkonData)
        {
            double dMaxSize = AkkonData.AkkonInspectionFilter.s_fMaxSize;
            double dMinSize = AkkonData.AkkonInspectionFilter.s_fMinSize;

            ATTInspParam  = AkkonData.AkkonInspectionParameter;
            ATTInspOption = AkkonData.AkkonInspectionOption;
            ATTInspFilter = AkkonData.AkkonInspectionFilter;
            ATTInspOption.s_fInspResizeRatio = Main.DEFINE.ImageResizeRatio;
            ATTInspOption.s_fPixelResolution = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000;
            ATTInspFilter.s_fMaxSize = (float)(dMaxSize / (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/));
            ATTInspFilter.s_fMinSize = (float)(dMinSize / (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/));



            //double dMaxSize = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fMaxSize;
            //double dMinSize = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fMinSize;

            //ATTInspParam = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter;
            //ATTInspOption = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption;
            //ATTInspFilter = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter;
            //ATTInspOption.s_fInspResizeRatio = Main.DEFINE.ImageResizeRatio;
            //ATTInspOption.s_fPixelResolution = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000;
            //ATTInspFilter.s_fMaxSize = (float)(dMaxSize / (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/));
            //ATTInspFilter.s_fMinSize = (float)(dMinSize / (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/));

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bSelectLeadDisplay = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bColorStrength = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bFirstLastPoint = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShadowBox = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShowSize = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShowStrength = false;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bContour = true;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bCenter = !AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bContour;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bDrawBlobNumbering = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_fPixelSize_um = ATTInspOption.s_fPixelResolution;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bDisplayLength = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_nPanelnfo = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nPanelInfo;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_nExtraLead = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nExtraLead;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_fDrawResizeRatio = Main.DEFINE.ImageResizeRatio;
            ATTDrawOption = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption;
            ATTDrawOption.s_bCenter = Main.machine.IsDrawCenter;
            ATTDrawOption.s_bContour = Main.machine.IsDrawContour;
            ATTDrawOption.s_bDisplayLength = Main.machine.IsDrawlength;
        }
        // PJH_20221013_E

        /// <summary>
        /// ATT 검사 파라미터 초기값 세팅
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <returns></returns>

        // PJH_20221013_S
        //public static void InitDefaultParameter(int nStageNo, int nTapNo)
        //{
        //    float s_fInspResizeRatio = (float)1.0;
        //    int s_nSliceHeight = 2150;
        //    int s_nSliceWidth = 2048;
        //    int s_nSliceID = 0;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_eShadowDir = EN_SHADOWDIR_WRAP._MV_SHADOW_DN;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nFilterDir = 1;   // 0 Horizontal, 1 Vertical
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fThWeight = 1.5;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nShadowOffset = 0;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fStrengthThreshold = 0;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_ePeakProp = EN_PEAK_PROP_WRAP._MV_PEAK_NEAR;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_eStrengthBase = EN_STRENGTH_BASE_WRAP._MV_STRENGTH_RAW;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nThPeak = 70;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nMinShadowWidth = 5;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fStrengthScaleFactor = (float)0.2;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nExtraLead = 20;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_bEdgeFlip = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fStdDevLeadJudge = 0;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nPanelInfo = 1;   // 0 COF, 1 COG, 2 FOG
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nIsFlexible = 0;  // 0 Rigid, 1 Flexible

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nAbsoluteThHi = 255;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nAbsoluteThLow = 0;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_bUseAbsTh = false;

        //    // 2019.10.21 Deep Learning Para
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fDLPeakProb = (float)0.9;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fDLSizeProb = (float)0.9;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nDLNetWorkType = 1;   // 0 or 1
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nDLSperateCut = 0;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nDLPatchSizeX = -1;   //160;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nDLPatchSizeY = -1;   //160;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_eFilterType = EN_MVFILTERTYPE_WRAP._MV_FILTER_4;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_eThMode = EN_THMODE_WRAP._MV_TH_WHITE;


        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_bLogTrace = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_nInspType = 0;  // 0 ThresholdMode, 1 DLMode0, 2 DLMode1, 3 DLMode2

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_fInspResizeRatio = s_fInspResizeRatio;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_fPixelResolution = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_nOverlap = m_vvSliceOverlap[nStageNo][nTapNo];

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_nRotOffset = 0;



        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bSelectLeadDisplay = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bColorStrength = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bFirstLastPoint = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bShadowBox = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bShowSize = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bShowStrength = false;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bContour = true;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bCenter = !AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bContour;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bDrawBlobNumbering = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_fPixelSize_um = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_bDisplayLength = false;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_nPanelnfo = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nPanelInfo;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_nExtraLead = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_nExtraLead;

        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption.s_fDrawResizeRatio = s_fInspResizeRatio;



        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_fMinStrength = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara.s_fStrengthThreshold;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_fMinSize = 0 / AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_fPixelResolution;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_fMaxSize = 100 / AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption.s_fPixelResolution;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_fGroupingDistance = 2;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_fBWRatio = -100;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_nROIDiv = 0;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_nWidthCut = 50;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_nHeightCut = 50;
        //    AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter.s_nRawPeakCut = 0;

        //    ATTInspParam = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspPara;
        //    ATTInspOption = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspOption;
        //    ATTInspFilter = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonInspFilter;
        //    ATTDrawOption = AlignUnit[nStageNo].PAT[0, nTapNo].AkkonPara.m_AkkonDrawOption;
        //}
        public static void InitDefaultParameter(int nCamNo, int nStageNo, int nTapNo)
        {
            float s_fInspResizeRatio = (float)1.0;
            int s_nSliceHeight = 2150;
            int s_nSliceWidth = 2048;
            int s_nSliceID = 0;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_eShadowDir = EN_SHADOWDIR_WRAP._MV_SHADOW_DN;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nFilterDir = 1;   // 0 Horizontal, 1 Vertical
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fThWeight = 1.5;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nShadowOffset = 0;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fStrengthThreshold = 0;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_ePeakProp = EN_PEAK_PROP_WRAP._MV_PEAK_NEAR;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_eStrengthBase = EN_STRENGTH_BASE_WRAP._MV_STRENGTH_RAW;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nThPeak = 70;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nMinShadowWidth = 5;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.2;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nExtraLead = 20;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_bEdgeFlip = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fStdDevLeadJudge = 0;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nPanelInfo = 1;   // 0 COF, 1 COG, 2 FOG
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nIsFlexible = 0;  // 0 Rigid, 1 Flexible

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nAbsoluteThHi = 255;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nAbsoluteThLow = 0;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_bUseAbsTh = false;

            // 2019.10.21 Deep Learning Para
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fDLPeakProb = (float)0.9;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fDLSizeProb = (float)0.9;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nDLNetWorkType = 1;   // 0 or 1
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nDLSperateCut = 0;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nDLPatchSizeX = -1;   //160;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nDLPatchSizeY = -1;   //160;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_eFilterType = EN_MVFILTERTYPE_WRAP._MV_FILTER_4;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_eThMode = EN_THMODE_WRAP._MV_TH_WHITE;


            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_bLogTrace = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_nInspType = 0;  // 0 ThresholdMode, 1 DLMode0, 2 DLMode1, 3 DLMode2

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_fInspResizeRatio = s_fInspResizeRatio;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_fPixelResolution = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_nOverlap = m_vvSliceOverlap[nStageNo][nTapNo];

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_nRotOffset = 0;



            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bSelectLeadDisplay = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bColorStrength = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bFirstLastPoint = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShadowBox = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShowSize = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bShowStrength = false;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bContour = true;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bCenter = !AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bContour;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bDrawBlobNumbering = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_fPixelSize_um = (float)(Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE);
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_bDisplayLength = false;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_nPanelnfo = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nPanelInfo;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_nExtraLead = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_nExtraLead;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption.s_fDrawResizeRatio = s_fInspResizeRatio;

            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fMinStrength = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter.s_fStrengthThreshold;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fMinSize = 0 / AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_fPixelResolution;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fMaxSize = 100 / AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption.s_fPixelResolution;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fGroupingDistance = 2;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_fBWRatio = -100;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_nROIDiv = 0;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_nWidthCut = 50;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_nHeightCut = 50;
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter.s_nRawPeakCut = 0;

            ATTInspParam = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionParameter;
            ATTInspOption = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionOption;
            ATTInspFilter = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonInspectionFilter;
            ATTDrawOption = AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonDrawOption;
        }
        // PJH_20221013_E

        /// <summary>
        /// ATT 검사 결과 저장
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <param name="size">검사 이미지 버퍼 크기</param>
        /// <param name="nTapNo">검사 결과 클래스</param>
        /// <returns></returns>
        public static void WriteLeadInfo(int nStageNo, int nTapNo, int size, AW.MVRESULT[][] FinalBuf)
        {
            String strDir, strTemp, strData;
            strTemp = "Lead Info_OK.csv";

            // 판정용.
            for (int a = 0; a < FinalBuf.Length; a++)
            {
                for (int b = 0; b < FinalBuf[a].Length; b++)
                {
                    if (FinalBuf[a][b].s_bJudgement == false)
                    {
                        strTemp = "Lead Info_NG.csv";
                        break;
                    }
                }
            }


            //strDir = String.Format("D:\\05_수행자료\\11_JASTECH\\03_통합ATT\\result{0:D}_{1:D}.csv", nStageNo, nTapNo);
            strDir = String.Format("D:\\result{0:D}_{1:D}.csv", nStageNo, nTapNo);

            BinaryWriter WriteFile = new BinaryWriter(new FileStream(strDir, FileMode.Create));

            strData = "LEAD_ID, BLOB_COUNT, AVG_STRENGTH, LENGTH, LEAD_AVG, Focus, Imul_Cnt \r\n";
            int str_length = strData.Length;
            byte[] temp = System.Text.Encoding.Default.GetBytes(strData);
            WriteFile.Write(temp, 0, str_length);
            WriteFile.Seek(0, SeekOrigin.End);

            for (int i = 0; i < size; i++)
            {
                int nSize_2 = FinalBuf[i].Length;
                for (int j = 0; j < nSize_2; j++)
                {
                    strData = String.Format("{0:D}, {1:D}, {2:F2}, {3:F2}, {4:F2}, {5:F2}, {6:D} \r\n", FinalBuf[i][j].s_nId, FinalBuf[i][j].s_nNumBlobs, FinalBuf[i][j].s_fAvgStrength, FinalBuf[i][j].s_fLength, FinalBuf[i][j].s_fLeadAvg, FinalBuf[i][j].s_fLeadStdDEV, FinalBuf[i][j].s_nImulCount);
                    str_length = strData.Length;
                    temp = System.Text.Encoding.Default.GetBytes(strData);
                    WriteFile.Write(temp, 0, str_length);
                    WriteFile.Seek(0, SeekOrigin.End);
                }
            }

            WriteFile.Close();
        }

        /// <summary>
        /// ATT 검사 결과 처리 콜백 함수
        /// </summary>
        /// <param name="nStageNo">Stage(Panel) 번호</param>
        /// <param name="nTapNo">Tap 번호</param>
        /// <param name="bSliceInsp">Slice 검사 여부</param>
        /// <param name="nError">Error 번호</param>
        /// <returns></returns>

        // PJH_20221013_S
        //public static void ATT_ResultProcess(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        //{
        //    try
        //    {
        //        if (nError == 0)
        //        {
        //            //m_rstImage = new Mat(m_vvReadMats[nStageNo][nTapNo].Size(), MatType.CV_8UC3);
        //            if (bSliceInsp == false)
        //            {
        //                //DLL에서 검사결과 받아옴
        //                Main.ATT_GetResult(nStageNo, nTapNo);

        //                if (isFormTeaching)
        //                {
        //                    //티칭창에서 검사시
        //                    Form_PatternTeach.ShowAkkonResultImage(Main.AlignUnit[nStageNo].PAT[0, nTapNo].m_imgOverlay);
        //                }
        //                else
        //                {
        //                    //메인에서 검사시
        //                    FormMain.Instance().AkkonViewerControl.UpdateAkkonDisplay(false, Main.AlignUnit[nStageNo].PAT[0, nTapNo].m_imgOverlay);
        //                    Main.AlignUnit[0].PAT[0, 0].AkkonResult[0].s_bJudge = true; //임시
        //                    ATT_AkkonResultDataUpdate(nStageNo, nTapNo);
        //                }


        //                WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult.Length, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult);
        //                //String strPath;
        //                //strPath = String.Format("D:\\JASProgram_AkkonResult.bmp", nStageNo, nTapNo);
        //                //Cv2.ImWrite(strPath, m_rstImage);

        //                //m_nInspectionEnd++;

        //                //int nImageCnt = m_vvReadMats.Count;
        //                //int nTotalImageCount = 0;

        //                //for (int i = 0; i < nImageCnt; i++)
        //                //{
        //                //    for (int j = 0; j < m_vvReadMats[i].Count; j++)
        //                //    {
        //                //        nTotalImageCount++;
        //                //    }
        //                //}

        //                //if (m_nInspectionEnd == nTotalImageCount)
        //                //{
        //                //    m_nInspectionEnd = 0;
        //                //    if (m_bAging)
        //                //    {
        //                //        //sw.Stop();

        //                //        MessageBox.Show(sw.Elapsed.ToString());
        //                //        sw.Reset();

        //                //    }
        //                //    Trace.WriteLine("sharp : Insp End");

        //                //}
        //            }
        //            //else
        //            //{
        //            //    float fInspResizeRatio = s_fInspResizeRatio;
        //            //    int nSliceHeight = s_nSliceHeight;
        //            //    int nSliceWidth = s_nSliceWidth;
        //            //    int nSliceID = s_nSliceID;

        //            //    //DLL에서 검사결과 받아옴
        //            //    Main.ATT_GetResult(nStageNo, nTapNo);

        //            //    WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult.Length, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult);

        //            //    Rect rcROI = new Rect();
        //            //    if (m_rstImage.Rows > m_rstImage.Cols)
        //            //    {
        //            //        rcROI.X = 0;
        //            //        rcROI.Y = nSliceID * ((int)(nSliceHeight * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
        //            //        rcROI.Width = m_rstImage.Cols;
        //            //        rcROI.Height = (int)(nSliceHeight * fInspResizeRatio);

        //            //        if (rcROI.Y < m_rstImage.Rows)
        //            //        {
        //            //            if (rcROI.Y + rcROI.Height > m_rstImage.Rows)
        //            //            {
        //            //                rcROI.Height = m_rstImage.Rows - rcROI.Y;
        //            //            }
        //            //        }
        //            //    }
        //            //    else
        //            //    {
        //            //        rcROI.X = nSliceID * (Convert.ToInt32(nSliceWidth * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
        //            //        rcROI.Y = 0; //
        //            //        rcROI.Width = Convert.ToInt32(nSliceWidth * fInspResizeRatio);
        //            //        rcROI.Height = m_rstImage.Rows;

        //            //        if (rcROI.X < m_rstImage.Cols)
        //            //        {
        //            //            if (rcROI.X + rcROI.Width > m_rstImage.Cols)
        //            //            {
        //            //                rcROI.Width = m_rstImage.Cols - rcROI.X;
        //            //            }
        //            //        }
        //            //    }
        //            //    Mat sliceImage = m_rstImage.SubMat(rcROI);

        //            //    String strPath;
        //            //    strPath = String.Format("D:\\05_수행자료\\11_JASTECH\\03_통합ATT\\result{0:D}_{1:D}_Slice{2:D}.bmp", nStageNo, nTapNo, nSliceID);
        //            //    Cv2.ImWrite(strPath, sliceImage);
        //            //}
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error: dongle key");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        // 시도 1 : 해당 함수를 delegate로 변경해볼 것
        // -> 해당 함수는 콜백 요청 후, 콜백이 수신되면 타는 부분
        public static void ATT_ResultProcess(int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        {
            try
            {
                if (nError == 0)
                {
                    //m_rstImage = new Mat(m_vvReadMats[nStageNo][nTapNo].Size(), MatType.CV_8UC3);
                    int nCamNo = 0;
                    if (bSliceInsp == false)
                    {
                        //DLL에서 검사결과 받아옴
                        Main.ATT_GetResult(nCamNo, nStageNo, nTapNo);
                        ATTInspFilter.s_fMaxSize = ATTInspFilter.s_fMaxSize * (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/);
                        ATTInspFilter.s_fMinSize = ATTInspFilter.s_fMinSize * (ATTInspOption.s_fPixelResolution /*/ ATTInspOption.s_fInspResizeRatio*/);
                        if (isFormTeaching)
                        {
                            //티칭창에서 검사시
                            Main.ATT_GetResultImageView(nCamNo, nStageNo, nTapNo);
                            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].bResulteTime = true;
                            //Form_PatternTeach.ShowAkkonResultImage(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgOverlay);
                            FormMain.Instance().SelectUnitForm.VisionTeachForm.TeachAkkonControl.UpdateAkkonResultDisplay(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgOverlay);
                        }
                
                        else
                        {
                            //메인에서 검사시
                            FormMain.Instance().AkkonViewerControl.UpdateAkkonDisplay(true, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_CogResizeImage);
                            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.Judge = true; //임시
                            ATT_AkkonResultDataUpdate(nCamNo, nStageNo, nTapNo);
                        }

                        isFormTeaching = false;
                        WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray.Length, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonResultArray);
                        //String strPath;
                        //strPath = String.Format("D:\\JASProgram_AkkonResult.bmp", nStageNo, nTapNo);
                        //Cv2.ImWrite(strPath, m_rstImage);

                        //m_nInspectionEnd++;

                        //int nImageCnt = m_vvReadMats.Count;
                        //int nTotalImageCount = 0;

                        //for (int i = 0; i < nImageCnt; i++)
                        //{
                        //    for (int j = 0; j < m_vvReadMats[i].Count; j++)
                        //    {
                        //        nTotalImageCount++;
                        //    }
                        //}

                        //if (m_nInspectionEnd == nTotalImageCount)
                        //{
                        //    m_nInspectionEnd = 0;
                        //    if (m_bAging)
                        //    {
                        //        //sw.Stop();

                        //        MessageBox.Show(sw.Elapsed.ToString());
                        //        sw.Reset();

                        //    }
                        //    Trace.WriteLine("sharp : Insp End");

                        //}
                    }
                    //else
                    //{
                    //    float fInspResizeRatio = s_fInspResizeRatio;
                    //    int nSliceHeight = s_nSliceHeight;
                    //    int nSliceWidth = s_nSliceWidth;
                    //    int nSliceID = s_nSliceID;

                    //    //DLL에서 검사결과 받아옴
                    //    Main.ATT_GetResult(nStageNo, nTapNo);

                    //    WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult[0].m_AkkonResult.Length, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult[0].m_AkkonResult);

                    //    Rect rcROI = new Rect();
                    //    if (m_rstImage.Rows > m_rstImage.Cols)
                    //    {
                    //        rcROI.X = 0;
                    //        rcROI.Y = nSliceID * ((int)(nSliceHeight * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
                    //        rcROI.Width = m_rstImage.Cols;
                    //        rcROI.Height = (int)(nSliceHeight * fInspResizeRatio);

                    //        if (rcROI.Y < m_rstImage.Rows)
                    //        {
                    //            if (rcROI.Y + rcROI.Height > m_rstImage.Rows)
                    //            {
                    //                rcROI.Height = m_rstImage.Rows - rcROI.Y;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {
                    //        rcROI.X = nSliceID * (Convert.ToInt32(nSliceWidth * fInspResizeRatio) - m_vvSliceOverlap[0][0]);
                    //        rcROI.Y = 0; //
                    //        rcROI.Width = Convert.ToInt32(nSliceWidth * fInspResizeRatio);
                    //        rcROI.Height = m_rstImage.Rows;

                    //        if (rcROI.X < m_rstImage.Cols)
                    //        {
                    //            if (rcROI.X + rcROI.Width > m_rstImage.Cols)
                    //            {
                    //                rcROI.Width = m_rstImage.Cols - rcROI.X;
                    //            }
                    //        }
                    //    }
                    //    Mat sliceImage = m_rstImage.SubMat(rcROI);

                    //    String strPath;
                    //    strPath = String.Format("D:\\05_수행자료\\11_JASTECH\\03_통합ATT\\result{0:D}_{1:D}_Slice{2:D}.bmp", nStageNo, nTapNo, nSliceID);
                    //    Cv2.ImWrite(strPath, sliceImage);
                    //}
                }
                else
                {
                    MessageBox.Show("Error: dongle key");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        // PJH_20221013_E

        public static void ATT_JudgeResult()
        {

        }

        public static void RotationTransform(OpenCvSharp.Point2d apntCenter, OpenCvSharp.Point2d apntOffset, double adAngle, ref OpenCvSharp.Point[] apntTarget)
        {
            OpenCvSharp.Point2d pntTempPos;

            for (int i = 0; i < 4; i++)
            {
                pntTempPos = (OpenCvSharp.Point2d)apntTarget[i];
                pntTempPos.X = pntTempPos.X + apntOffset.X;
                pntTempPos.Y = pntTempPos.Y + apntOffset.Y;
                apntTarget[i].X = (int)(Math.Round(apntCenter.X + (((Math.Cos(DEG2RAD(adAngle)) * (pntTempPos.X - apntCenter.X)) - (Math.Sin(DEG2RAD(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
                apntTarget[i].Y = (int)(Math.Round(apntCenter.Y + (((Math.Sin(DEG2RAD(adAngle)) * (pntTempPos.X - apntCenter.X)) + (Math.Cos(DEG2RAD(adAngle)) * (pntTempPos.Y - apntCenter.Y))))));
            }
        }

        public static double DEG2RAD(double adAngle)
        {
            return adAngle * OpenCvSharp.Cv2.PI / 180.0;
        }

        public delegate void CALLBACKFUNC(int nStageNo, int nTapNo, bool bSliceInsp, int nError);
        internal static class NativeMethods
        {
#if DEBUG
            [DllImport("mv_akkonInspd.dll")]
#endif

#if RELEASE
            [DllImport("mv_akkonInsp.dll")]
#endif
            internal static extern void CallBackRegistry(CALLBACKFUNC cb);
            //internal static extern void CallBackRegistry(CALLBACKFUNC cb2);
            // DLL 연결 및 Callback 함수 등록
        }

        public static bool ATT_AlignInspection(int nCamNo, int nStageNo, int nTapNo, CogImage8Grey cogImage)
        {
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge = true;
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.InspectionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.PanelID = "TestPanel_Tab" + (nTapNo + 1).ToString();
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.TabNumber = nTapNo + 1;

            //DisplayClear();
            string strResult;
            Point2d[] TrackingPos = new Point2d[(int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS];
            Point2d[] ResultViewPos = new Point2d[(int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS];

            //X Caliper의 경우 Left,Right  FPC,Panel  Caliper개수로 관리(ex : [0,0][0] -> Left, FPC, 0번째 Caliper)
            //Y Caliper의 경우 Left,Right  FPC,Panel 로만 관리 (ex : [0][0] -> Left, FPC Caliper)
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                TrackingPos[i] = new Point2d();
                ResultViewPos[i] = new Point2d();

                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j] = new List<Point2d>();
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j] = new List<Point2d>();
                }

                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i] = new List<Point2d>();
            }

            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList.Clear();
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList.Clear();

#region X Align Insepection
            CogRectangleAffine[] PTCaliperDividedRegion;
            int nTotalLeadCount = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeadCount * 2;
            PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            Point2d CaliperPos = new Point2d();

            bool bLeftMarkCheck = false;
            bool bRightMarkCheck = false;

            //ROI Tracking용 Mark Search
            for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
            {
                if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i] != null)
                {
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].InputImage = cogImage;
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Run();
                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results != null)
                    {
                        if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results.Count >= 1 && bLeftMarkCheck == false)
                        {
                            bLeftMarkCheck = true;
                            TrackingPos[0].X = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results[0].GetPose().TranslationX
                                - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Pattern.Origin.TranslationX;
                            TrackingPos[0].Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results[0].GetPose().TranslationY
                            - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Pattern.Origin.TranslationY;
                            ResultViewPos[0].X = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results[0].GetPose().TranslationX;
                            ResultViewPos[0].Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeftPattern[i].Results[0].GetPose().TranslationY;
                        }
                    }
                }

                if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i] != null)
                {
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].InputImage = cogImage;
                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Run();

                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results != null)
                    {
                        if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results.Count >= 1 && bRightMarkCheck == false)
                        {
                            bRightMarkCheck = true;
                            TrackingPos[1].X = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results[0].GetPose().TranslationX
                                - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Pattern.Origin.TranslationX;
                            TrackingPos[1].Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results[0].GetPose().TranslationY
                            - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Pattern.Origin.TranslationY;
                            ResultViewPos[1].X = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results[0].GetPose().TranslationX;
                            ResultViewPos[1].Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.RightPattern[i].Results[0].GetPose().TranslationY;
                        }
                    }
                }
            }
#region X Caliper Search
            //i = LEFT = 0, i = RIGHT = 1
            //j = FPC = 0, j = PANEL = 1
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.LeadCount > 0)
                    {
                        double dNewX = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.CenterX -
                            (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.SideXLength / 2) + (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.SideXLength / (nTotalLeadCount * 2));
                        double dNewY = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.CenterY;

                        //ROI Division
                        for (int k = 0; k < nTotalLeadCount; k++)
                        {
                            //ROI Tracking 추가 필요

                            PTCaliperDividedRegion[k] = new CogRectangleAffine(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region);

                            double dX = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.SideXLength / nTotalLeadCount * k * Math.Cos(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.Rotation);
                            double dY = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.SideXLength / nTotalLeadCount * k * Math.Sin(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].Region.Rotation);

                            PTCaliperDividedRegion[k].SideXLength = PTCaliperDividedRegion[k].SideXLength / nTotalLeadCount;
                            PTCaliperDividedRegion[k].CenterX = dNewX + dX;
                            PTCaliperDividedRegion[k].CenterY = dNewY + dY;

                            if (bLeftMarkCheck == true && i == 0) //Left Position
                            {
                                PTCaliperDividedRegion[k].CenterX = dNewX + dX + TrackingPos[0].X;
                                PTCaliperDividedRegion[k].CenterY = dNewY + dY + TrackingPos[0].Y;
                            }

                            if (bRightMarkCheck == true && i == 1) //Right Position
                            {
                                PTCaliperDividedRegion[k].CenterX = dNewX + dX + TrackingPos[1].X;
                                PTCaliperDividedRegion[k].CenterY = dNewY + dY + TrackingPos[1].Y;
                            }


                            if (k % 2 == 0) //좌측부분 ROI
                            {
                                PTCaliperDividedRegion[k].Rotation = PTCaliperDividedRegion[k].Rotation - 3.14;
                                if (CogCaliperPolarityConstants.DarkToLight == Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].RunParams.Edge0Polarity)
                                    CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                            }
                            else
                            {
                                if (CogCaliperPolarityConstants.DarkToLight == Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].RunParams.Edge0Polarity)
                                    CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                            }
                            //Caliper Search
                            CaliperTool.InputImage = cogImage;
                            CaliperTool.RunParams.FilterHalfSizeInPixels = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].RunParams.FilterHalfSizeInPixels;
                            CaliperTool.RunParams.ContrastThreshold = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].RunParams.ContrastThreshold;
                            //CaliperTool.RunParams.Edge0Polarity = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, j].RunParams.Edge0Polarity;
                            CaliperTool.Region = PTCaliperDividedRegion[k];
                            CaliperTool.Run();

                            if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)                                               //Caliper Search OK
                            {
                                resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                                CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                                CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;

                                if (k % 2 == 0)
                                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j].Add(CaliperPos);        //Left Edge
                                else
                                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j].Add(CaliperPos);       //Right Edge
                            }
                            else                                                                                                             //Caliper Search NG
                            {
                                CaliperPos.X = 0;
                                CaliperPos.Y = 0;
                                if (k % 2 == 0)
                                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j].Add(CaliperPos);        //Left Edge
                                else
                                    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j].Add(CaliperPos);       //Right Edge
                            }
                        }

                    }
                }
                if (i == 0)
                {
                    FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_INTERACTIVE, Main.DEFINE.DISPLAY_ALIGN_LEFT, resultGraphics, ResultViewPos[0]);
                    resultGraphics.Clear();
                }
                else
                {
                    FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_INTERACTIVE, Main.DEFINE.DISPLAY_ALIGN_RIGHT, resultGraphics, ResultViewPos[1]);
                    resultGraphics.Clear();
                }
            }
            //cogDisplay.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
#endregion

#region X Caliper Data Summary
            //Caliper Data 1차 정리
            //한쪽 Caliper Search NG일 경우 동일선상의 반대편 Caliper도 0으로 통일
            CaliperPos.X = 0;
            CaliperPos.Y = 0;
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    for (int k = 0; k < Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j].Count; k++)
                    {
                        if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j][k] == CaliperPos ||
                            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j][k] == CaliperPos)
                        {
                            //동일 선상에 있는 Caliper중 FPC나 Panel 둘중 하나라도 못찾을 경우
                            //반대편에 있는 Caliper 데이터도 0으로 초기화.
                            if (j == 0)
                            {
                                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j + 1][k] = CaliperPos;
                                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j + 1][k] = CaliperPos;
                            }
                            else
                            {
                                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, j - 1][k] = CaliperPos;
                                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, j - 1][k] = CaliperPos;
                            }
                        }
                    }
                }
            }
#endregion

#region X Align Calculate
            CogCreateLineTool cogCenterLineTool = new CogCreateLineTool();
            CogCreateLineTool cogFPCLineTool = new CogCreateLineTool();
            CogCreateLineTool cogPanelLineTool = new CogCreateLineTool();
            CogIntersectLineLineTool cogIntersectPoint_FPC = new CogIntersectLineLineTool();
            CogIntersectLineLineTool cogIntersectPoint_Panel = new CogIntersectLineLineTool();
            CogDistancePointPointTool cogDistancePoint = new CogDistancePointPointTool();
            List<double> DistanceToPoint = new List<double>();
            //수평선 생성(FPC ROI 와 Panel ROI 사이에 생성)
            cogFPCLineTool.InputImage = cogImage;
            cogPanelLineTool.InputImage = cogImage;
            cogCenterLineTool.InputImage = cogImage;
            cogIntersectPoint_FPC.InputImage = cogImage;
            cogIntersectPoint_Panel.InputImage = cogImage;
            cogDistancePoint.InputImage = cogImage;

            cogFPCLineTool.OutputColor = CogColorConstants.Purple;
            cogPanelLineTool.OutputColor = CogColorConstants.Orange;

            cogCenterLineTool.Line.X = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[0, 0].Region.CornerOriginX;
            cogCenterLineTool.Line.Y = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[0, 0].Region.CornerYY
                + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[0, 1].Region.CornerOriginY) / 2;
            cogCenterLineTool.Line.Rotation = 0;
            cogCenterLineTool.Run();

            //PT_Display01.StaticGraphics.Add(cogCenterLineTool.Line as ICogGraphic, "CenterLine");
            double dLeftAvergeX;
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                //for (int j = 0; j < (int)Main.AlignTagData.DefaultParam.DEF_TARGET_POS; j++)
                {
                    for (int k = 0; k < Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, 0].Count; k++)//Caliper 개수만큼 동작
                    {
                        //object, [FPC]  -> Panel 각도로 통일 
                        if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, 0][k].X > 0 && Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 0][k].X > 0)
                        {
                            cogFPCLineTool.Line.X = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, 0][k].X + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 0][k].X) / 2;
                            cogFPCLineTool.Line.Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 0][k].Y;
                            cogFPCLineTool.Line.Rotation = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, 1].Region.Skew + 1.57;
                            cogFPCLineTool.Run();
                            //PT_Display01.StaticGraphics.Add(cogFPCLineTool.Line as ICogGraphic, "FPCLine");
                            if (i == 0)
                                FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_STATIC, Main.DEFINE.DISPLAY_ALIGN_LEFT, cogFPCLineTool.Line, ResultViewPos[0]);
                            else
                                FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_STATIC, Main.DEFINE.DISPLAY_ALIGN_RIGHT, cogFPCLineTool.Line, ResultViewPos[1]);

                            cogIntersectPoint_FPC.LineA = cogCenterLineTool.GetOutputLine();
                            cogIntersectPoint_FPC.LineB = cogFPCLineTool.GetOutputLine();
                            cogIntersectPoint_FPC.Run();

                        }
                        //object, [Panel] -> Panel 각도로 통일
                        if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, 1][k].X > 0 && Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 1][k].X > 0)
                        {
                            cogPanelLineTool.Line.X = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.LeftEdgePointList[i, 1][k].X + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 1][k].X) / 2;
                            cogPanelLineTool.Line.Y = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.RightEdgePointList[i, 1][k].Y;
                            cogPanelLineTool.Line.Rotation = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperX[i, 1].Region.Skew + 1.57;
                            cogPanelLineTool.Run();
                            //PT_Display01.StaticGraphics.Add(cogPanelLineTool.Line as ICogGraphic, "PanelLine");

                            if (i == 0)
                                FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_STATIC, Main.DEFINE.DISPLAY_ALIGN_LEFT, cogPanelLineTool.Line, ResultViewPos[0]);
                            else
                                FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_STATIC, Main.DEFINE.DISPLAY_ALIGN_RIGHT, cogPanelLineTool.Line, ResultViewPos[1]);

                            cogIntersectPoint_Panel.LineA = cogCenterLineTool.GetOutputLine();
                            cogIntersectPoint_Panel.LineB = cogPanelLineTool.GetOutputLine();
                            cogIntersectPoint_Panel.Run();
                        }
                        if (cogIntersectPoint_FPC.Intersects && cogIntersectPoint_Panel.Intersects)
                        {
                            cogDistancePoint.StartX = cogIntersectPoint_FPC.X;
                            cogDistancePoint.StartY = cogIntersectPoint_FPC.Y;
                            cogDistancePoint.EndX = cogIntersectPoint_Panel.X;
                            cogDistancePoint.EndY = cogIntersectPoint_Panel.Y;
                            cogDistancePoint.Run();
                            DistanceToPoint.Add(cogDistancePoint.Distance);
                        }
                    }

                    //위에서 Left or Right Position에 대한 모든 연산이 끝나고
                    //각 결과 정리부분
                    //Align X 값이 한개도 없을 때
                    if (DistanceToPoint.Count == 0)
                    {
                        dLeftAvergeX = 0;
                        strResult = "X Align Search Fail";
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge = false;
                    }
                    else if (DistanceToPoint.Count == 1)
                        dLeftAvergeX = DistanceToPoint[0];
                    else if (DistanceToPoint.Count == 2)
                        dLeftAvergeX = (DistanceToPoint[0] + DistanceToPoint[1]) / 2;
                    else
                    {
                        DistanceToPoint.Sort();
                        DistanceToPoint.RemoveAt(0); //Min 삭제
                        DistanceToPoint.RemoveAt(DistanceToPoint.Count - 1);//Max 삭제
                        dLeftAvergeX = DistanceToPoint.Average();
                    }

                    //Panel기준 FPC가 좌측에 위치할 때, 부호 - [Panel기준]
                    if (cogIntersectPoint_FPC.X < cogIntersectPoint_Panel.X)
                        dLeftAvergeX = dLeftAvergeX * -1;

                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge)
                    {
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList.Add(dLeftAvergeX * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                        strResult = "X Align Result : " + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList[i].ToString("0.000") + "um";
                    }
                    else
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList.Add(0);
                }
            }

#endregion

#endregion

#region Y Align Inspection

#region Y Caliper Search
            //i = LEFT = 0,
            //i = RIGHT = 1,
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                //j = FPC = 0,
                //j = PANEL = 1,
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    CaliperTool.InputImage = cogImage;
                    CaliperTool.RunParams.FilterHalfSizeInPixels = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperY[i, j].RunParams.FilterHalfSizeInPixels;
                    CaliperTool.RunParams.ContrastThreshold = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperY[i, j].RunParams.ContrastThreshold;
                    CaliperTool.RunParams.Edge0Polarity = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperY[i, j].RunParams.Edge0Polarity;
                    CaliperTool.Region = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignPara.AlignCaliperY[i, j].Region;
                    CaliperTool.Run();
                    if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
                    {
                        resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                        //PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                        CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                        CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;

                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i].Add(CaliperPos);
                    }
                    else
                    {
                        //Caliper Search NG
                        CaliperPos.X = 0;
                        CaliperPos.Y = 0;
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i].Add(CaliperPos);
                    }
                }

                if (i == 0)
                {
                    FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_INTERACTIVE, Main.DEFINE.DISPLAY_ALIGN_LEFT, resultGraphics, ResultViewPos[0]);
                    resultGraphics.Clear();
                }
                else
                {
                    FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_INTERACTIVE, Main.DEFINE.DISPLAY_ALIGN_RIGHT, resultGraphics, ResultViewPos[1]);
                    resultGraphics.Clear();
                }

            }

#region Y Align Calculate
            double YAlignDistance;

            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    //Caliper Search NG
                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i][j].X == 0)
                    {
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge = false;
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList.Add(0);
                        strResult = "Y Align Search Fail";
                    }
                    else
                    {
                        YAlignDistance = Math.Abs(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i][0].Y - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.YEdgePointList[i][1].Y);
                        YAlignDistance = YAlignDistance * ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                        Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList.Add(YAlignDistance);
                        strResult = "Y Align Result : " + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList[i].ToString("0.000") + "um";
                    }

                    i++;
                }
            }
#endregion


#endregion
#endregion
            ATT_AlignResultDataUpdate(nCamNo, nStageNo, nTapNo);

            FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_VIEW, Main.DEFINE.DISPLAY_ALIGN_LEFT, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_CogLineScanBuf, ResultViewPos[0]);//Image View
            FormMain.Instance().AlignViewerControl.UpdateAlignDisplay(Main.DEFINE.DISPLAY_VIEW, Main.DEFINE.DISPLAY_ALIGN_RIGHT, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_CogLineScanBuf, ResultViewPos[1]);//Image View

            return Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge;
        }

        private static void ATT_AlignResultDataUpdate(int nCamNo, int nStageNo, int nTapNo)
        {
            COG.Class.InspectionResult.AlignInspectionResult AlignResult = new COG.Class.InspectionResult.AlignInspectionResult();
            AlignResult.InspectionTime = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.InspectionTime;
            AlignResult.PanelID = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.PanelID;
            AlignResult.TabNumber = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.TabNumber;

            if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.Judge)
                AlignResult.Judge = COG.Class.InspectionResult.eInspectionResult.OK;
            else
                AlignResult.Judge = COG.Class.InspectionResult.eInspectionResult.NG;

            AlignResult.LeftAlignX = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList[0];
            AlignResult.LeftAlignY = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList[0];
            AlignResult.RightAlignX = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList[1];
            AlignResult.RightAlignY = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapYRealList[1];
            AlignResult.CenterAlignX = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList[0] + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AlignResult.AlignGapXRealList[1]) / 2;

            alignResultList.Add(AlignResult);
        }

        public static bool ATT_AkkonInspcetion(int nCamNo, int nStageNo, int nTapNo, CogImage8Grey cogImage)
        {
            bool bRet = true;
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.InspectionTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.PanelID = "Test_Tab" + (nTapNo + 1).ToString();
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.TabNumber = nTapNo + 1;


            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.Judge = true;
            Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.UseCheckAkkonInspection = true;
            Main.sw.Start();

            if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.UseCheckAkkonInspection)
            {
                //if (PT_Akkon_MarkUSE[m_PatNo])
                //{
                //    for (int j = 0; j < PT_AkkonPara[m_PatNo, i].m_AkkonBumpROI.Count; j++)
                //    {
                //        PT_AkkonPara[m_PatNo, i].m_AkkonBumpROI[j].CenterX = PatResult.TranslationX + PT_AkkonPara[m_PatNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                //        PT_AkkonPara[m_PatNo, i].m_AkkonBumpROI[j].CenterY = PatResult.TranslationY + PT_AkkonPara[m_PatNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                //    }
                //}

                //// ATT Initialize
                //if (Main.DEFINE.OPEN_F)
                //{
                //    //YSH
                //    //이미지 컨버팅 방법 확인 필요 (CogImage8Grey to Mat)
                //    //Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf = new Mat("D:\\Systemdata_ATT_LINE_PC1\\MODEL_VISION\\Tab5.bmp", ImreadModes.AnyColor);
                //    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Cols;
                //    Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Rows;
                //    Main.vision.IMAGE_SIZE_X[0] = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                //    Main.vision.IMAGE_SIZE_Y[0] = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows;

                //}



                //// 0 COF, 1 COG, 2 FOG
                //if (Main.AlignUnit[0].PAT[0, 0].AkkonPara.m_AkkonInspPara.s_nPanelInfo == 0)
                //    Main.DEFINE.ImageResizeRatio = (float)0.5;
                //else if (Main.AlignUnit[0].PAT[0, 0].AkkonPara.m_AkkonInspPara.s_nPanelInfo == 1)
                //    Main.DEFINE.ImageResizeRatio = (float)1.0;
                //else if (Main.AlignUnit[0].PAT[0, 0].AkkonPara.m_AkkonInspPara.s_nPanelInfo == 2)
                //    Main.DEFINE.ImageResizeRatio = (float)0.6;

                ////2022 1004 YSH
                ////Resize 0.5 사용시 Result 이미지 이상출력, 추후 수정필요
                //Main.DEFINE.ImageResizeRatio = (float)0.6;
                //Main.ATT_CreateDLLBuffer();
                //Main.ATT_CreateImageBuffer();


                //ATT Mark search 
                double dX = 0, dY = 0, dTeachT = 0, dRotT = 0;
                OpenCvSharp.Point2d pntCenter = new Point2d();
                OpenCvSharp.Point2d pntdXY = new Point2d();
                pntCenter.X = 0; pntCenter.Y = 0;

                bool bLeftMarkCheck = false;
                bool bRightMarkCheck = false;
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].InputImage = cogImage;
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].InputImage = cogImage;

                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Run();
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Run();

                if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results != null)
                {
                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results.Count >= 1)
                        bLeftMarkCheck = true;
                }
                if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results != null)
                {
                    if (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results.Count >= 1)
                        bRightMarkCheck = true;
                }

                if (bLeftMarkCheck && bRightMarkCheck)
                {
                    //추후 Score 기능 추가 예정 - YSH        
                    dX = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationX + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationX) / 2
                    - (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationX + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationX) / 2;

                    dY = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationY + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationY) / 2
                    - (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationY + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationY) / 2;

                    double dRotDx = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationX - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationX;
                    double dRotDy = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationY - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationY;
                    dRotT = OpenCvSharp.Cv2.FastAtan2((float)dRotDy, (float)dRotDx);
                    if (dRotT > 180) dRotT -= 360;

                    //float a = (float)(PT_AkkonPara[0, m_SelectAkkon].m_RightPattern[0_Sub].Pattern.Origin.TranslationY - PT_AkkonPara[0, m_SelectAkkon].m_LeftPattern[0_Sub].Pattern.Origin.TranslationY);
                    //float b = (float)(PT_AkkonPara[0, m_SelectAkkon].m_RightPattern[0_Sub].Pattern.Origin.TranslationX - PT_AkkonPara[0, m_SelectAkkon].m_LeftPattern[0_Sub].Pattern.Origin.TranslationX);

                    dTeachT = OpenCvSharp.Cv2.FastAtan2((float)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationY - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationY),
                        (float)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationX - Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationX));
                    if (dTeachT > 180.0) dTeachT -= 360.0;


                    dRotT -= dTeachT;
                    pntCenter.X = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationX + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationX) / 2;
                    pntCenter.Y = (Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.RightPattern[0].Results[0].GetPose().TranslationY + Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.LeftPattern[0].Results[0].GetPose().TranslationY) / 2;

                    pntdXY.X = dX;
                    pntdXY.Y = dY;
                }
                else
                {
                    //LABEL_MESSAGE(LB_MESSAGE, "Mark Search NG! ", System.Drawing.Color.Red);
                }

                Cv2.Resize(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanOriginalBuf, Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf,
                    new OpenCvSharp.Size(0, 0), Main.DEFINE.ImageResizeRatio, Main.DEFINE.ImageResizeRatio);
                byte[] bytes2 = new byte[Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Cols * Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Rows];
                Cv2.ImEncode(".bmp", Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf, out bytes2);
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgDataATT = new byte[Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Cols * Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Rows];
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgCols = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Cols;
                Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_imgRows = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].m_MatLineScanBuf.Rows;
                Main.strtmp[0] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();



                //압흔 Parameter 갱신부분 추가 필요 - YSH



                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                Main.sw.Start();
                // ROI Resize
                int[][] nLeadPoint = new int[Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList.Count][];
                OpenCvSharp.Point[] ptPos = new OpenCvSharp.Point[4];
                for (int j = 0; j < Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList.Count; j++)
                {
                    nLeadPoint[j] = new int[8];

                    nLeadPoint[j][0] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerOriginX);  //LeftTop
                    nLeadPoint[j][1] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerOriginY);  //LeftTop

                    nLeadPoint[j][2] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerXX);  //RightTop
                    nLeadPoint[j][3] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerXY);  //RightTop

                    nLeadPoint[j][4] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerOppositeX);  //RightBottom
                    nLeadPoint[j][5] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerOppositeY);  //RightBottom

                    nLeadPoint[j][6] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerYX);  //LeftBottom
                    nLeadPoint[j][7] = (int)(Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara.AkkonBumpROIList[j].CornerYY);  //LeftBottom

                    ptPos[0].X = nLeadPoint[j][0];
                    ptPos[0].Y = nLeadPoint[j][1];

                    ptPos[1].X = nLeadPoint[j][2];
                    ptPos[1].Y = nLeadPoint[j][3];

                    ptPos[2].X = nLeadPoint[j][4];
                    ptPos[2].Y = nLeadPoint[j][5];

                    ptPos[3].X = nLeadPoint[j][6];
                    ptPos[3].Y = nLeadPoint[j][7];

                    Main.RotationTransform(pntCenter, pntdXY, dRotT, ref ptPos);

                    //CogRectangleAffine tempRectAffine = new CogRectangleAffine();
                    //tempRectAffine.SetOriginCornerXCornerY(ptPos[0].X, ptPos[0].Y, ptPos[1].X, ptPos[1].Y, ptPos[3].X, ptPos[3].Y);
                    //PT_AkkonPara[m_PatNo, i].m_AkkonBumpROI[j] = tempRectAffine;

                    nLeadPoint[j][0] = ptPos[0].X;
                    nLeadPoint[j][1] = ptPos[0].Y;

                    nLeadPoint[j][2] = ptPos[1].X;
                    nLeadPoint[j][3] = ptPos[1].Y;

                    nLeadPoint[j][4] = ptPos[2].X;
                    nLeadPoint[j][5] = ptPos[2].Y;

                    nLeadPoint[j][6] = ptPos[3].X;
                    nLeadPoint[j][7] = ptPos[3].Y;

                    //strROI = tempRectAffine.CornerOriginX.ToString() + "\t" + tempRectAffine.CornerOriginY.ToString() + "\t" + tempRectAffine.CornerXX.ToString() + "\t"
                    //    + tempRectAffine.CornerXY.ToString() + "\t" + tempRectAffine.CornerOppositeX.ToString() + "\t" + tempRectAffine.CornerOppositeY.ToString() + "\t"
                    //    + tempRectAffine.CornerYX.ToString() + "\t" + tempRectAffine.CornerYY.ToString();

                    //SW.WriteLine(strROI);
                }
                //SW.Close();
                Main.strtmp[1] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();
                Main.sw.Start();
                bool bReadRoi = Main.ATT_SendROI(nStageNo, nTapNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    return false;
                }

                // ATT RUN
                bool bReady = Main.ATT_ReadyToInsp(nCamNo, nStageNo, nTapNo, AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonPara);

                // 자동 계산 overlap 확인
                //LB_ATT_SLICE_OVERLAP.Text = Main.AlignUnit[m_AlignNo].PAT[0, i].AkkonPara[m_SelectAkkon].m_AkkonInspOption.s_nOverlap.ToString();

                // 최종적으로 dll에 검사 요청
                if (bReady)
                    Main.ATT_InspectByTap(nCamNo, nStageNo, nTapNo);
            }

            return bRet;
        }

        private static void ATT_AkkonResultDataUpdate(int nCamNo, int nStageNo, int nTapNo)
        {
            COG.Class.InspectionResult.AkkonInspectionResult AkkonResult = new COG.Class.InspectionResult.AkkonInspectionResult();
            AkkonResult.InspectionTime = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.InspectionTime;
            AkkonResult.PanelID = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.PanelID;
            AkkonResult.TabNumber = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.TabNumber;

            if (Main.AlignUnit[nCamNo].PAT[nStageNo, 0].AkkonResult.Judge)
                AkkonResult.Judge = COG.Class.InspectionResult.eInspectionResult.OK;
            else
                AkkonResult.Judge = COG.Class.InspectionResult.eInspectionResult.NG;

            AkkonResult.AkkonCount = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonAverageCount;
            AkkonResult.Length = Main.AlignUnit[nCamNo].PAT[nStageNo, nTapNo].AkkonResult.AkkonAverageLength;

           // List<COG.Class.InspectionResult.AkkonInspectionResult> AkkonResultList = new List<COG.Class.InspectionResult.AkkonInspectionResult>();
           // AkkonResultList.Add(AkkonResult);

            // DataGridView 및 Chart에 누적 데이터를 사용하기 위해 AddRange Example
            //List<COG.Class.InspectionResult.AkkonInspectionResult> tt = new List<Class.InspectionResult.AkkonInspectionResult>();

            // 계속 쌓기 위한 객체 생성으로, 상위에 생성할 것
            //List<COG.Class.InspectionResult.AkkonInspectionResult> ListAkkonResult = null;

            // Add List Obj
            //AkkonResultList.AddRange(AkkonResult);
            AkkonResultList.Add(AkkonResult);
            // 갯수가 몇 개 이상일 때 Shift 처리하기
            //if (AkkonResultList.Count > 100)

            FormMain.Instance().AkkonViewerControl.UpdateGridView(AkkonResultList);
            FormMain.Instance().AkkonViewerControl.UpdateAkkonChart(AkkonResultList);
        }
    }
}
