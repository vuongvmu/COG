using Matrox.MatroxImagingLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

using System.Windows.Forms;
using Cognex.VisionPro;

namespace COG
{
    public partial class Main
    {
        public enum ScanStatus { SCAN_STANBY, SCAN_RUN, SCAN_COMPLETE }
        public enum SceneStatus { SCENE_GRAB_STANBY, SCENE_GRAB_RUN, SCENE_GRAB_COMPLETE }
        public enum CamStatus { SCAN_NONE, SCAN_READY, SCAN_START, SCANNING, SCAN_COMPLETE, PAGE_COMPLETE, LIVE }
        public enum ScanDiretion { SET_DIR_FORWARD = 0, SET_DIR_REVERSE }
        public class MILFrameGrabber
        {
            #region Field
            // private static int BUFFER_SIZE = 1;
            private static int BUFFER_SIZE = 10;
            private MIL_ID _milApplication = MIL.M_NULL;

            private MIL_ID[] _milSystem = new MIL_ID[DEFINE.MIL_BOARD_MAX];
            public MIL_ID[] MilDigitizer = new MIL_ID[DEFINE.MIL_CAM_MAX];
            private MIL_INT _sizeBand = 0;
            private MIL_INT _type = 0;

            public MIL_ID MilGrabImage = new MIL_ID();
            private MIL_ID[] _milScanBuffer = new MIL_ID[BUFFER_SIZE];

            private MIL_ID _BufAttributes = MIL.M_IMAGE + MIL.M_PROC;
            private MIL_ID _BufDispAttributes = MIL.M_IMAGE + MIL.M_PROC + MIL.M_DISP;
            private MIL_ID _BufGrabAttributes = MIL.M_IMAGE + MIL.M_PROC + MIL.M_GRAB + MIL.M_DISP;

            //hook func alloc
            private static MIL_DIG_HOOK_FUNCTION_PTR _ProcessingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(LineEndHookHandler);
            private static HookDataStruct _UserHookData = new HookDataStruct();
            private static GCHandle _hUserData = GCHandle.Alloc(_UserHookData);

            private bool _isSimualtionMode = false;
            private string previousMessage = string.Empty;

            //Scene(Tab) Grab State
            //public List<int> vSceneState = new List<int>();
            //public List<int> vTabStartLine = new List<int>();
            //public List<int> vTabEndLine = new List<int>();
            public int[,,] vSceneState = new int[DEFINE.MIL_CAM_MAX, DEFINE.MAX_SCAN_COUNT, DEFINE.MAX_SCENE_COUNT];
            public int[,,] vTabStartLine = new int[DEFINE.MIL_CAM_MAX, DEFINE.MAX_SCAN_COUNT, DEFINE.MAX_SCENE_COUNT];
            public int[,,] vTabEndLine = new int[DEFINE.MIL_CAM_MAX, DEFINE.MAX_SCAN_COUNT, DEFINE.MAX_SCENE_COUNT];
            private static Thread ThreadCreateLinescanImage;
            #endregion

            #region Property
            public int DeviceID { get; set; } = -1;
            public int ImageWidth { get; set; } = new int();
            public int ImageHeight { get; set; } = new int();

            public int ImageWidthDefault { get; private set; } = new int();

            public int ImageHeightDefault { get; private set; } = new int();
            public int[] COMPortNum { get; private set; } = new int[DEFINE.MIL_CAM_MAX];
            public double LineCount { get; set; } = 0;
            public bool IsInitialize { get; private set; }
            public string DcfFilePath { get; set; } = string.Empty;
            #endregion

            #region Event
            public event Action<int, int> ReceiveImage;
            public event Action<int> LineScanImage;
            public static event Action CheckHookDataState;

            //public event Action ReceiveImage2;
            //private static event Action CheckHookDataState2;
            #endregion

            private string StringFilter(string str, List<Char> seperator)
            {
                foreach (char item in seperator)
                    str = str.Replace(item.ToString(), String.Empty);

                return str;
            }

            public eConnectionStatus Initialize(bool isSimautionMode, string boardType, ref int boardID)
            {
                this._isSimualtionMode = isSimautionMode;

                if (MIL.M_NULL == _milApplication && _isSimualtionMode == false)
                {
                    if (MIL.M_NULL == MIL.MappAlloc(MIL.M_DEFAULT, ref _milApplication))
                        return eConnectionStatus.Connection_Fail;
                }

                MIL.MappControl(MIL.M_ERROR, MIL.M_PRINT_DISABLE);

                if (Main.DEFINE.USE_CONTINUOUS)
                    MIL.MappControl(MIL.M_GRAB_MODE, MIL.M_CONTIGUOUS);

                int foundBoardCount = (int)MIL.MappInquire(MIL.M_INSTALLED_SYSTEM_COUNT);

                if (foundBoardCount < 1)
                    return eConnectionStatus.Connection_NotFound_Board;
                for (int i = 0; i < Main.DEFINE.nScan_Max_Cnt; i++)
                {
                    for (int j = 0; j < Main.DEFINE.nMaxScene; j++)
                    {
                        _UserHookData.m_arrlistSceneState[i] = new List<int>();
                        _UserHookData.m_arrlistSceneState[i].Add(0);
                        _UserHookData.m_arrlistTabStartLine[i] = new List<int>();
                        _UserHookData.m_arrlistTabStartLine[i].Add(0);
                        _UserHookData.m_arrlistSceneState[i] = new List<int>();
                        _UserHookData.m_arrlistSceneState[i].Add(0);
                        _UserHookData.m_arrlistTabEndLine[i] = new List<int>();
                        _UserHookData.m_arrlistTabEndLine[i].Add(0);
                    }
                }
                for (int i = 0; i < foundBoardCount; i++)
                {
                    StringBuilder foundBoardName = new StringBuilder();
                    MIL.MappInquire(MIL.M_INSTALLED_SYSTEM_DESCRIPTOR + i, foundBoardName);

                    List<Char> removeCharacter = new List<char>() { '{', '}' };

                    if (string.Compare(boardType, StringFilter(foundBoardName.ToString(), removeCharacter).ToString(), true) == 0)
                    {
                        if (MIL.MsysAlloc(boardType, MIL.M_DEV0, MIL.M_COMPLETE, ref _milSystem[i]) != MIL.M_NULL)
                        {
                            boardID = i;
                            return eConnectionStatus.Connection_Success;
                        }
                    }
                }

                return eConnectionStatus.Connection_Fail;
            }
            // PJH_Modify_20220818_Flying Vision_E

            /// <summary>
            /// MIL 프레임 그래버 초기화 함수 최초 한번 진행
            /// </summary>
            /// <param name="deviceID">MIL System ID</param>
            /// <param name="dcfFilePath">DCF File 경로</param>
            /// <param name="isSimautionMode">SimautionMode로 사용 여부</param>
            /// <returns></returns>
            public bool OpenDigitizer(int systemID, int deviceID, string dcfFilePath)
            {
                DeviceID = deviceID;
                if (DeviceID == -1)
                    return false;
                if (string.IsNullOrEmpty(dcfFilePath))
                    return false;

                #region MIL 관련 초기화
                if (false == _isSimualtionMode)//Simulation mode Disable
                {
                    //if (deviceID == 0)
                    //{
                    //    dcfFilePath = "D:\\Solb_mil9u5_XCL-S900_s4tap_c2tap_8bit_c.dcf";
                    //}
                    //else if (deviceID == 1)
                    //{
                    //    dcfFilePath = "D:\\solxcl_mil8_g60fv11cl_c_8bit_2tap.dcf";
                    //}
                    //else if (deviceID == 2)
                    //{
                    //    dcfFilePath = "D:\\STC-CMB120APCL-F_4096x3072_2Tap_Cont.dcf";
                    //}

                    //dcf 설정 가져오기
                    //systemID = 0;
                    //DeviceID = 0;

                    //MIL.MdigAlloc(_MilSystem[systemID], MIL.M_DEV0 + (deviceID%2), dcfFilePath, MIL.M_DEFAULT, ref _MilDigitizer[DeviceID]);
                    // MIL.MdigAlloc(_MilSystem[systemID], MIL.M_DEV0 + (deviceID % 2), dcfFilePath, MIL.M_DEFAULT, ref _MilDigitizer[DeviceID]);
                    MIL.MdigAlloc(_milSystem[systemID], MIL.M_DEV0, dcfFilePath, MIL.M_DEFAULT, ref MilDigitizer[DeviceID]);
                    COMPortNum[deviceID] = (int)MIL.MsysInquire(_milSystem[systemID], MIL.M_COM_PORT_NUMBER + MIL.M_UART_NB(deviceID % 2), MIL.M_NULL);

                    //MIL.MdigControl(_MilDigitizer, MIL.M_, MIL.M_ENABLE);
                    if (MIL.M_NULL == MilDigitizer[DeviceID])
                        return false;

                    //dcf 설정값 읽어오기
                    ImageWidth = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_X, MIL.M_NULL);
                    ImageHeight = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_Y, MIL.M_NULL);
                    _UserHookData.mszSize.Width = ImageWidth;
                    _UserHookData.mszSize.Height = ImageHeight;
                    ImageWidthDefault = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_X, MIL.M_NULL);
                    ImageHeightDefault = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_Y, MIL.M_NULL);
                    _type = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_TYPE, MIL.M_NULL);
                    _sizeBand = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_BAND, MIL.M_NULL);
                    _UserHookData.MilSystem = _milSystem[systemID];
                    _UserHookData.MilDigitizer = MilDigitizer;
                    _UserHookData._milScanBuffer = new MIL_ID[BUFFER_SIZE];
                    for (int i = 0; i < BUFFER_SIZE; i++)
                    {
                        ///Mono 일때 나중에 Color Cam 사용시 추가
                        _UserHookData._milScanBuffer[i] = new MIL_ID();
                        MIL.MbufAlloc2d(_UserHookData.MilSystem, _UserHookData.mszSize.Width, _UserHookData.mszSize.Height, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref _UserHookData._milScanBuffer[i]);
                        MIL.MbufClear(_UserHookData._milScanBuffer[i], 0);

                    }
                    /// MIL ERROR 메세지
                    MIL.MappControl(MIL.M_ERROR, MIL.M_PRINT_ENABLE);
#if DEBUG
                    MIL.MdigControl(_UserHookData.MilDigitizer[0], MIL.M_GRAB_TIMEOUT, MIL.M_INFINITE);
#elif RELEASE
                    MIL.MdigControl(_UserHookData.MilDigitizer[0], MIL.M_GRAB_TIMEOUT, 5000);
#endif

                }
                else if (true == _isSimualtionMode)//Simulation mode Enable
                {
                    MIL.MsysAlloc(MIL.M_SYSTEM_VGA, MIL.M_DEV0 + DeviceID, MIL.M_COMPLETE, ref _milSystem[systemID]);
                }

                #endregion

                CheckHookDataState += MILFrameGrabber_CheckHookDataState;
                IsInitialize = true;
                ThreadCreateLinescanImage = new Thread(new ThreadStart(Thread_CreaeLinescanImage));
                ThreadCreateLinescanImage.Start();
                return true;
            }

            public void Release(int nDevNo)
            {
                if (_isSimualtionMode)
                    return;

                for (int i = 0; i < _milScanBuffer.Length; ++i)
                    if (_milScanBuffer[i] != MIL.M_NULL) MIL.MbufFree(_milScanBuffer[i]);

                int systemNo = nDevNo / 2;

                if (MIL.M_NULL != MilGrabImage) { MIL.MbufFree(MilGrabImage); MilGrabImage = MIL.M_NULL; }
                if (MIL.M_NULL != MilDigitizer[nDevNo]) { MIL.MdigFree(MilDigitizer[nDevNo]); MilDigitizer[nDevNo] = MIL.M_NULL; }
                if (MIL.M_NULL != _milSystem[systemNo]) { MIL.MsysFree(_milSystem[systemNo]); _milSystem[systemNo] = MIL.M_NULL; }
                if (MIL.M_NULL != _milApplication) { MIL.MappFree(_milApplication); _milApplication = MIL.M_NULL; }
            }
            static MIL_INT LineEndHookHandler(MIL_INT HookType, MIL_ID EventId, IntPtr UserDataPtr)
            {
                GCHandle hUserData = GCHandle.FromIntPtr(UserDataPtr);
                HookDataStruct UserData = hUserData.Target as HookDataStruct;

                if (UserData.m_arrScanState[UserData.m_nScanIndex] == (int)ScanStatus.SCAN_RUN)
                {
                    ProcessingFunction(HookType, EventId, UserDataPtr);
                }
                return MIL.M_NULL;
            }
            private void MILFrameGrabber_CheckHookDataState()
            {
                //int nScene = _UserHookData.m_nCurSeneIndex;
                //int nScan = _UserHookData.m_nCurScanIndex;
                int nScene = GrabSceneIndex;
                int nScan = GrabScanIndex;
                //switch (_UserHookData.CamStatus)
                switch (GrabCamStatus)
                {
                    case CamStatus.SCAN_NONE:
                        previousMessage = "Buffer Not Alloc.";
                        Debug.WriteLine(previousMessage);
                        break;
                    case CamStatus.SCAN_READY:
                        previousMessage = $"Buffer alloc / ImageWidth : {ImageWidth}/ImageHeight : {(int)ImageHeight}";
                        Console.WriteLine(previousMessage);
                        Debug.WriteLine(previousMessage);
                        break;
                    case CamStatus.SCAN_START:
                        previousMessage = "Scan Start";
                        Debug.WriteLine(previousMessage);
                        break;
                    case CamStatus.SCANNING:
                        previousMessage = "Scaning........";
                        Debug.WriteLine(previousMessage);
                        break;
                    case CamStatus.SCAN_COMPLETE:
                        //previousMessage = "Scan Complete";
                        //Debug.WriteLine(previousMessage);
                        Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf = refVectMatImg[nScene];
                        Convert_CognexImage(nScan, nScene);
                        ReceiveImage?.Invoke(nScan, nScene);
                        _UserHookData.CamStatus = CamStatus.SCAN_COMPLETE;
                        break;
                    case CamStatus.PAGE_COMPLETE:
                        //previousMessage = "Page Complete";
                        //Debug.WriteLine(previousMessage);
                        Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf = refVectMatImg[nScene];
                        Convert_CognexImage(nScan, nScene);
                        ReceiveImage?.Invoke(nScan, nScene);
                        _UserHookData.CamStatus = CamStatus.SCANNING;


                        //if (_UserHookData.ProcessedImageCount == BUFFER_SIZE)
                        //    _UserHookData.CamStatus = CamStatus.SCAN_NONE;

                        break;
                    case CamStatus.LIVE:
                        ReceiveImage?.Invoke(0, 0);
                        break;
                    default:
                        break;
                }
            }

            #region AllocBuffer Gray

            // PJH_Modify_20220811_Flying Vision_S
            //public bool AllocBuffer_Area(int nDevNo)
            //{
            //    bool result = false;


            //    if (IsInitialize == false)
            //    {
            //        return result;
            //    }

            //    if (CheckCamera(nDevNo) == false)
            //    {
            //        return result;
            //    }

            //    if (_UserHookData.Status == ScanStatus.SCANNING)
            //    {
            //        return result;
            //    }

            //    if (_MilGrabImage[nDevNo] != MIL.M_NULL)
            //        MIL.MbufFree(_MilGrabImage[nDevNo]);

            //    ImageHeight = ImageHeightDefault;
            //    MIL.MbufAlloc2d(_MilSystem[nDevNo/2], ImageWidth[nDevNo], ImageHeightDefault[nDevNo], 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref _MilGrabImage[nDevNo]);

            //    result = true;
            //    return result;
            //}
            private void Convert_CognexImage(int nScan, int nScene)
            {
                byte[] bytes = new byte[Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Cols * Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Rows];
                Marshal.Copy(Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Data, bytes, 0, bytes.Length);

                bytes = Convert8BitImage(bytes, Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Cols, Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Rows);

                Main.AlignUnit[0].PAT[nScan, nScene].m_CogLineScanBuf = (CogImage8Grey)Main._ClsImage.Convert8BitRawImageToCognexImage(bytes, Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Cols, Main.AlignUnit[0].PAT[nScan, nScene].m_MatLineScanBuf.Rows);
            }
            private byte[] Convert8BitImage(byte[] bitmatbyte, int width, int hegiht)
            {
                Bitmap bmp = new Bitmap(width, hegiht, PixelFormat.Format8bppIndexed);
                ColorPalette paletee = bmp.Palette;
                BitmapData bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                                                    ImageLockMode.WriteOnly, bmp.PixelFormat);

                ColorPalette _palette = bmp.Palette;
                Color[] _entries = _palette.Entries;
                for (int i = 0; i < 256; i++)
                {
                    Color b = new Color();
                    b = Color.FromArgb((byte)i, (byte)i, (byte)i);
                    _entries[i] = b;
                }
                bmp.Palette = _palette;

                Marshal.Copy(bitmatbyte, 0, bmpData.Scan0, bitmatbyte.Length);
                return bitmatbyte;
            }
            public bool AllocBuffer_AreaCamera(int nDevNo, bool isFlying = false, int point = 0)
            {
                bool result = false;

                if (IsInitialize == false)
                    return result;

                if (CheckCamera(nDevNo) == false)
                    return result;

                if (_UserHookData.CamStatus == CamStatus.SCANNING)
                    return result;

                if (MilGrabImage != MIL.M_NULL)
                    MIL.MbufFree(MilGrabImage);

                ImageHeight = ImageHeightDefault;
                ImageWidth = ImageWidthDefault;

                if (isFlying)
                {
                    if (point == 0)
                        MIL.MbufAlloc2d(_milSystem[nDevNo / 2], ImageWidth, ImageHeightDefault, 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref MilGrabImage);
                    else
                    {
                        //MIL.MbufAlloc2d(_milSystem[nDevNo / 2], ImageWidth[nDevNo] * point, ImageHeightDefault[nDevNo] * point, 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref MilGrabImage[nDevNo]);
                        //MIL.MbufAlloc2d(_milSystem[4], ImageWidth[nDevNo] * point, ImageHeightDefault[nDevNo], 8, _BufGrabAttributes, ref MilGrabImage[nDevNo]);
                    }
                }
                else
                    MIL.MbufAlloc2d(_milSystem[nDevNo / 2], ImageWidth, ImageHeightDefault, 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref MilGrabImage);



                result = true;
                return result;
            }

            #region Trigger Scan

            public void ExternalTriggerGrabStart()
            {
                if (_UserHookData.CamStatus == CamStatus.SCAN_READY)
                {
                    _UserHookData.ProcessedImageCount = 0;
                    // PJH_20220826_S
                    //_UserHookData.RemainLineCount = ImageWidth[0];                    // Linescan 및 Flying Vision 사용 시 구별할 것
                    // _UserHookData.RemainLineCount = ImageWidth[0];        
                    // PJH_20220826_E
                    //_UserHookData.PageUnit = ImageWidthDefault;
                    _UserHookData.m_nRemainLength = ImageHeight;
                    _UserHookData.PageUnit = ImageHeightDefault;

                    Console.WriteLine($"frame : #{_UserHookData.ProcessedImageCount}, RemainLine : #{_UserHookData.m_nRemainLength}");
                    _UserHookData.CamStatus = CamStatus.SCANNING;

                    GCHandle hUserData = GCHandle.Alloc(_UserHookData);
                    MIL.MdigProcess(MilDigitizer[0], _milScanBuffer, BUFFER_SIZE, MIL.M_SEQUENCE, MIL.M_DEFAULT /*MIL.M_SYNCHRONOUS*/, _ProcessingFunctionPtr, GCHandle.ToIntPtr(hUserData));
                    // MIL.MdigProcess(MilDigitizer[0], _milScanBuffer, BUFFER_SIZE, MIL.M_START, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(hUserData));
                }
            }

            public void ExternalTriggerGrabStop()
            {
                if (_UserHookData.CamStatus == CamStatus.SCANNING || _UserHookData.CamStatus == CamStatus.PAGE_COMPLETE)
                {
                    _UserHookData.CamStatus = CamStatus.SCAN_NONE;
                    GCHandle hUserData = GCHandle.Alloc(_UserHookData);
                    MIL.MdigProcess(MilDigitizer[0], _milScanBuffer, BUFFER_SIZE, MIL.M_STOP, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(hUserData));
                }
            }
            #endregion

            public bool AllocBuffer_ExternalTriggerGrab(int TriggerCount)
            {
                bool result = true;

                if (false == _isSimualtionMode)
                {
                    BUFFER_SIZE = TriggerCount;

                    if (_milScanBuffer.Length <= 1) //최초일경우
                        _milScanBuffer = new MIL_ID[BUFFER_SIZE];
                    else
                    {
                        for (int i = 0; i < _milScanBuffer.Length; i++/*++i*/)

                            if (_milScanBuffer[i] != MIL.M_NULL) MIL.MbufFree(_milScanBuffer[i]);

                        _milScanBuffer = new MIL_ID[BUFFER_SIZE];
                    }

                    if (MilGrabImage != MIL.M_NULL)
                    {
                        MIL.MbufFree(MilGrabImage);
                        MilGrabImage = new MIL_ID();
                    }

                    //MIL.MbufClear(MilGrabImage, 0xff);

                    MIL.MbufAlloc2d(_milSystem[4], ImageWidth, (MIL_INT)(ImageHeightDefault * BUFFER_SIZE), 8, _BufGrabAttributes, ref MilGrabImage);

                    //MIL.MbufAlloc2d(_milSystem[4], ImageWidth[0], (MIL_INT)(ImageWidth[0] * BUFFER_SIZE), 8, _BufGrabAttributes, ref MilGrabImage[0]);
                    // MIL_INT buffer = (MIL_INT)(ImageWidth[0] * BUFFER_SIZE);

                    //MIL.MbufAlloc2d(_milSystem[4], (MIL_INT)(ImageWidth[0] * BUFFER_SIZE), (MIL_INT)(ImageHeight[0]), 8, _BufGrabAttributes, ref MilGrabImage[0]);           

                    for (int i = 0; i < BUFFER_SIZE; i++/*++i*/)
                    {
                        MIL.MbufChild2d(MilGrabImage, 0, (MIL_INT)(i * ImageHeightDefault), ImageWidth, (MIL_INT)ImageHeightDefault, ref _milScanBuffer[i]);
                        //MIL.MbufChild2d(MilGrabImage, 0, (MIL_INT)(ImageHeightDefault), ImageWidth, (MIL_INT)ImageHeightDefault, ref _milScanBuffer[i]);
                        //MIL.MbufChild2d(MilGrabImage[0], 0, (MIL_INT)(i * ImageWidthDefault), ImageWidth[0], (MIL_INT)ImageHeightDefault[0], ref _milScanBuffer[i]);

                        //MIL.MbufChild2d(MilGrabImage[0], (MIL_INT)(i * ImageWidthDefault), 0, (MIL_INT)ImageWidth[0], (MIL_INT)ImageHeightDefault[0], ref _milScanBuffer[i]);

                        if (MIL.M_NULL != _milScanBuffer[i])
                        {
                            MIL.MbufClear(_milScanBuffer[i], 0x00);
                            //Thread.Sleep(150);
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }

                    if (result == true)
                    {
                        //this.ImageWidth[0] = ImageWidthDefault * BUFFER_SIZE;
                        this.ImageHeight = ImageHeightDefault * BUFFER_SIZE;
                        _UserHookData.CamStatus = CamStatus.SCAN_READY;
                        return result;
                    }
                }
                else if (true == _isSimualtionMode)
                {
                    this.ImageWidth = ImageWidth;
                    this.ImageHeight = ImageHeight;
                }
                return result;
            }
            // PJH_Modify_20220811_Flying Vision_E

            public bool AllocBuffer_Linescan(int nDevNo = 0, double dScanLength = 0, double dPixelSize = 0)
            {
                bool result = false;

                if (IsInitialize == false)
                {
                    return result;
                }

                if (CheckCamera(nDevNo) == false)
                {
                    return result;
                }

                if (dPixelSize <= 0 || dScanLength <= 0)
                {
                    return result;
                }

                if (!Main.DEFINE.USE_CONTINUOUS)
                {
                    if (_UserHookData.CamStatus == CamStatus.SCANNING)
                    {
                        return result;
                    }
                }

                double dLineCount = (dScanLength / dPixelSize);
                BUFFER_SIZE = (int)(dLineCount / ImageHeightDefault) + 1;
                ImageHeight = (int)dLineCount;
                if (false == _isSimualtionMode)
                {
                    if (_milScanBuffer.Length <= 1) //최초 할당
                        _milScanBuffer = new MIL_ID[BUFFER_SIZE];
                    else                            //재할당시
                    {
                        for (int i = 0; i < _milScanBuffer.Length; ++i)
                        {
                            if (_milScanBuffer[i] != MIL.M_NULL)
                                MIL.MbufFree(_milScanBuffer[i]);
                        }
                        _milScanBuffer = new MIL_ID[BUFFER_SIZE];
                    }

                    if (MilGrabImage != MIL.M_NULL)
                        MIL.MbufFree(MilGrabImage);

                    //MIL.MbufAlloc2d(_milSystem[nDevNo / 2], ImageWidth, ImageHeightDefault * BUFFER_SIZE, 8, _BufGrabAttributes, ref MilGrabImage);
                    MIL.MbufAlloc2d(_milSystem[4], ImageWidth, ImageHeightDefault * BUFFER_SIZE, 8, _BufGrabAttributes, ref MilGrabImage);
                    for (int i = 0; i < BUFFER_SIZE; ++i)
                    {
                        MIL.MbufChild2d(MilGrabImage, 0, i * ImageHeightDefault, ImageWidth, ImageHeightDefault, ref _milScanBuffer[i]);
                        if (MIL.M_NULL != _milScanBuffer[i])
                        {
                            MIL.MbufClear(_milScanBuffer[i], 0x00);
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                    }

                    if (result == true)
                    {
                        _UserHookData.CamStatus = CamStatus.SCAN_READY;
                    }

                    result = true;
                }
                else
                {
                    result = true;
                }

                return result;
            }
            #endregion

            #region Live

            /// <summary>
            /// Live Start
            /// </summary>
            public void ContinuousGrabStart(int nDevNo)
            {
                if (MilGrabImage == MIL.M_NULL)
                {
                    MIL.MbufAlloc2d(_milSystem[nDevNo], ImageWidth, ImageHeightDefault, 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref MilGrabImage);
                }
                MIL.MdigGrabContinuous(MilDigitizer[nDevNo], MilGrabImage);

            }
            public void ContinuousGrabStop(int nDevNo)
            {
                if (MilGrabImage != MIL.M_NULL)
                {
                    MIL.MdigHalt(MilDigitizer[nDevNo]);
                }
            }

            public byte[] Get_Image(out int Width, out int Height)
            {
                Width = 0;
                Height = 0;

                MIL.MbufInquire(MilGrabImage, MIL.M_SIZE_X, ref Width);
                MIL.MbufInquire(MilGrabImage, MIL.M_SIZE_Y, ref Height);

                byte[] data = new byte[Width * Height];
                MIL.MbufGet(MilGrabImage, data);
                MIL.MbufGet2d(MilGrabImage, 0, 0, Width, Height, data);

                return data;
            }

            /// <summary>BU
            /// Live Stop
            /// </summary>

            #endregion

            #region Grab

            /// <summary>
            /// One Shot Grab
            /// </summary>
            /// <returns></returns>
            public void AreaGrabImage_Init(int nDevNo)
            {
                if (MilGrabImage == MIL.M_NULL)
                {
                    MIL.MbufAlloc2d(_milSystem[nDevNo], ImageWidth, ImageHeightDefault, 8, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_PROC, ref MilGrabImage);
                }
            }

            public byte[] Grab(int nDevNo, out int nWidth, out int nHeight)
            {
                nWidth = 0;
                nHeight = 0;
                MIL.MdigGrab(MilDigitizer[nDevNo], MilGrabImage);
                UInt32 BuffSize = (UInt32)(ImageWidth * ImageHeight);
                byte[] Imagebuff = new byte[BuffSize];
                MIL.MbufGet2d(MilGrabImage, 0, 0, ImageWidth, (MIL_INT)ImageHeightDefault, Imagebuff);
                nWidth = ImageWidth;
                nHeight = ImageHeight;
                return Imagebuff;
            }
            #endregion

            #region Get Image Byte

            /// <summary>
            /// Get Buffer Full Image 
            /// </summary>
            /// <returns>image byte</returns>
            public byte[] GetImageBytes(int nDevNo)
            {
                try
                {
                    if (nDevNo < 0)
                        return null;

                    Console.WriteLine("nDevNo : " + nDevNo.ToString());
                    if (IsInitialize && ImageWidth != 0 && ImageHeight != 0)
                    {
                        Console.WriteLine("nDevNo : " + nDevNo.ToString());
                        UInt32 buffSize = (UInt32)(ImageWidthDefault * ImageHeightDefault);
                        byte[] imageBuffer = new byte[buffSize];
                        MIL.MbufGet2d(_milScanBuffer[nDevNo], 0, 0, ImageWidthDefault, ImageHeightDefault, imageBuffer);

                        //Bitmap mbit = new Bitmap(ImageWidthDefault, ImageHeightDefault, 
                        // PixelFormat.Format8bppIndexed, Marshal.UnsafeAddrOfPinnedArrayElement(imageBuffer, 0));


                        return imageBuffer;
                    }
                    return null;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.ToString());
                    return null;
                }
            }
            #endregion

            public bool CheckCamera(int nDevNo)
            {
                MIL_ID result = MIL.M_NO;
                MIL.MdigInquire(MilDigitizer[nDevNo], MIL.M_CAMERA_PRESENT, ref result);
                if (result == MIL.M_YES)
                    return true;
                else
                    return false;
            }

            private static MIL_INT ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr _UserPtr)
            {
                int nScanIndex = _UserHookData.m_nScanIndex;
                int nSceneIndex = _UserHookData.m_nSceneIndex;

                if (_UserHookData.m_nRemainLength > 0)
                {
                    MIL_ID ModifiedBufferId = new MIL_ID();
                    int nLength;

                    MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId);

                    if (_UserHookData.m_nRemainLength >= Main.DEFINE.GRAB_SIZE_Y)
                        nLength = _UserHookData.mszSize.Height;
                    else
                        nLength = _UserHookData.m_nRemainLength;

                    int nCurPageFirstLine = (_UserHookData.m_nGrabMoveLine - _UserHookData.m_nRemainLength);
                    int nCurPageEndLine = nCurPageFirstLine + Main.DEFINE.GRAB_SIZE_Y;

                    refVectMatImg[nSceneIndex] = Main.AlignUnit[0].PAT[nScanIndex, nSceneIndex].m_MatLineScanBuf;

                    int nSceneStartLine = _UserHookData.m_arrlistTabStartLine[nScanIndex][nSceneIndex];
                    int nSceneEndLine = _UserHookData.m_arrlistTabEndLine[nScanIndex][nSceneIndex];

                    Console.WriteLine($"CurPageFirstLine : #{nCurPageFirstLine}, CurPageEndLine : #{nCurPageEndLine}");
                    HookDataStruct TempHookData = new HookDataStruct();
                    switch (_UserHookData.m_arrlistSceneState[nScanIndex][nSceneIndex])
                    {
                        case (int)SceneStatus.SCENE_GRAB_STANBY:
                            if (nSceneStartLine < nCurPageEndLine)
                            {

                                if (_UserHookData.m_nDirection == (int)ScanDiretion.SET_DIR_FORWARD)
                                {
                                    _UserHookData.m_nBufferIndex = (nCurPageEndLine - nSceneStartLine) * _UserHookData.mszSize.Width;

                                    byte[] data = new byte[(nCurPageEndLine - nSceneStartLine) * _UserHookData.mszSize.Width];
                                    MIL.MbufGet2d(ModifiedBufferId, 0, (nSceneStartLine - nCurPageFirstLine), _UserHookData.mszSize.Width, (nCurPageEndLine - nSceneStartLine), data);
                                    //TempHookData = (HookDataStruct)_UserHookData.Clone();
                                    //TempHookData.m_arrlistSceneState = (List<int>[])_UserHookData.m_arrlistSceneState.Clone();
                                    // HookDataStruct struct = TempHookData.
                                    ByteArrQueue.Enqueue(data);
                                    HookDataQueue.Enqueue(_UserHookData.DeepCopy());


                                    _UserHookData.m_arrlistSceneState[nScanIndex][nSceneIndex] = (int)SceneStatus.SCENE_GRAB_RUN;

                                    //OpenCvSharp.Mat tempImgStart = new OpenCvSharp.Mat((nCurPageEndLine - nSceneStartLine), _UserHookData.mszSize.Width, OpenCvSharp.MatType.CV_8UC1, data);
                                    //OpenCvSharp.Mat tempImgTrans = new OpenCvSharp.Mat(_UserHookData.mszSize.Width, (nCurPageEndLine - nSceneStartLine), OpenCvSharp.MatType.CV_8UC1);
                                    //OpenCvSharp.Cv2.Transpose(tempImgStart, tempImgTrans);
                                    //TempMatImage = tempImgTrans;

                                    //tempImgTrans.copyTo(roi);
                                }
                                else
                                {
                                    //Reverse
                                }
                            }
                            break;
                        case (int)SceneStatus.SCENE_GRAB_RUN:
                            if (nSceneEndLine > nCurPageEndLine)
                            {
                                if (_UserHookData.m_nDirection == (int)ScanDiretion.SET_DIR_FORWARD)
                                {

                                    byte[] data = new byte[(Main.DEFINE.GRAB_SIZE_Y * _UserHookData.mszSize.Width)];
                                    MIL.MbufGet2d(ModifiedBufferId, 0, 0, _UserHookData.mszSize.Width, Main.DEFINE.GRAB_SIZE_Y, data);

                                    ByteArrQueue.Enqueue(data);
                                    HookDataQueue.Enqueue(_UserHookData);

                                    //OpenCvSharp.Mat tempImgRun = new OpenCvSharp.Mat(Main.DEFINE.GRAB_SIZE_Y, _UserHookData.mszSize.Width, OpenCvSharp.MatType.CV_8U ,data);
                                    //OpenCvSharp.Mat tempImgTrans = new OpenCvSharp.Mat(_UserHookData.mszSize.Width, (nCurPageEndLine - nSceneStartLine), OpenCvSharp.MatType.CV_8U);

                                    // OpenCvSharp.Cv2.Transpose(tempImgRun, tempImgTrans);
                                    // OpenCvSharp.Cv2.HConcat(TempMatImage, tempImgTrans, TempMatImage);
                                    _UserHookData.m_nBufferIndex += _UserHookData.mszSize.Width * Main.DEFINE.GRAB_SIZE_Y;
                                }
                                else
                                {
                                    //Reverse
                                }

                                _UserHookData.m_nBufferIndex += _UserHookData.mszSize.Width * Main.DEFINE.GRAB_SIZE_Y;
                            }
                            else
                            {
                                if (_UserHookData.m_nDirection == (int)ScanDiretion.SET_DIR_FORWARD)
                                {
                                    byte[] data = new byte[(Main.DEFINE.GRAB_SIZE_Y * _UserHookData.mszSize.Width)];

                                    MIL.MbufGet2d(ModifiedBufferId, 0, 0, _UserHookData.mszSize.Width, (nSceneEndLine - nCurPageFirstLine), data);
                                    ByteArrQueue.Enqueue(data);
                                    HookDataQueue.Enqueue(_UserHookData);

                                    //OpenCvSharp.Mat tempImgEnd = new OpenCvSharp.Mat((nSceneEndLine- nCurPageFirstLine), _UserHookData.mszSize.Width, OpenCvSharp.MatType.CV_8U, data);
                                    //OpenCvSharp.Mat tempImgTrans = new OpenCvSharp.Mat(_UserHookData.mszSize.Width, (nSceneEndLine - nCurPageFirstLine), OpenCvSharp.MatType.CV_8U);
                                    // OpenCvSharp.Cv2.Transpose(tempImgEnd, tempImgTrans);
                                    // OpenCvSharp.Cv2.HConcat(TempMatImage, tempImgTrans, TempMatImage);
                                    //refVectMatImg[nSceneIndex] = TempMatImage;
                                    _UserHookData.m_nBufferIndex += _UserHookData.mszSize.Width * Main.DEFINE.GRAB_SIZE_Y;

                                    if (_UserHookData.m_nSceneIndex < (_UserHookData.m_nSceneCount - 1))
                                    {
                                        _UserHookData.m_nCurSeneIndex = _UserHookData.m_nSceneIndex;
                                        _UserHookData.m_nCurScanIndex = _UserHookData.m_nScanIndex;
                                        _UserHookData.m_nSceneIndex++;
                                        Console.WriteLine($"Page Complete");
                                        _UserHookData.CamStatus = CamStatus.PAGE_COMPLETE;
                                        HookDataQueue.Enqueue(_UserHookData);
                                        ByteArrQueue.Enqueue(data);
                                        //CheckHookDataState?.Invoke();
                                    }
                                    else
                                    {

                                        _UserHookData.m_nCurSeneIndex = _UserHookData.m_nSceneIndex;
                                        _UserHookData.m_nCurScanIndex = _UserHookData.m_nScanIndex;
                                        _UserHookData.m_arrScanState[nScanIndex] = (int)ScanStatus.SCAN_COMPLETE;
                                        Console.WriteLine($"Scan Complete");
                                        _UserHookData.CamStatus = CamStatus.SCAN_COMPLETE;
                                        MIL.MdigProcess(_UserHookData.MilDigitizer[0], _UserHookData._milScanBuffer, BUFFER_SIZE, MIL.M_STOP, MIL.M_DEFAULT, _ProcessingFunctionPtr, _UserPtr);
                                        HookDataQueue.Enqueue(_UserHookData);
                                        ByteArrQueue.Enqueue(data);
                                        //CheckHookDataState?.Invoke();

                                    }

                                }
                                else
                                {
                                    //Reverse
                                }
                            }
                            break;
                    }
                    _UserHookData.m_nRemainLength -= nLength;
                }
                #region 주석
                //MIL_ID ModifiedBufferId = MIL.M_NULL;

                //if (!IntPtr.Zero.Equals(HookDataPtr))
                //{
                //    GCHandle hUserData = GCHandle.FromIntPtr(HookDataPtr);          // get the handle to the DigHookUserData object back from the IntPtr
                //    HookDataStruct UserData = hUserData.Target as HookDataStruct;   // get a reference to the DigHookUserData object


                //    MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId);

                //    UserData.ProcessedImageCount++;

                //    if (Main.DEFINE.USE_CONTINUOUS)
                //    {
                //        UserData.Status = ScanStatus.LIVE;
                //        CheckHookDataState?.Invoke();
                //    }
                //    else
                //    {
                //        if (UserData.m_nRemainLength >= UserData.PageUnit)
                //        {
                //            UserData.m_nRemainLength -= UserData.PageUnit;
                //            UserData.Status = ScanStatus.PAGE_COMPLETE;
                //            CheckHookDataState?.Invoke();
                //        }
                //        else
                //        {
                //            UserData.m_nRemainLength -= UserData.m_nRemainLength;
                //            UserData.Status = ScanStatus.SCAN_COMPLETE;
                //            CheckHookDataState?.Invoke();
                //        }
                //    }

                //    //Debug.WriteLine($"frame : #{UserData.ProcessedImageCount}, RamainLine : #{UserData.RemainLineCount}");
                //    Console.WriteLine($"frame : #{UserData.ProcessedImageCount}, RamainLine : #{UserData.m_nRemainLength}");
                //}
                #endregion
                return 0;
            }
            public void QueueClear()
            {
                HookDataQueue.Clear();
                ByteArrQueue.Clear();
            }
            public void LineScanStart(int nDevNo)
            {
                //if (1 == SerialCommunication.GetSensorMode())
                //{
                //    SerialCommunication.SetSensorMode(0);
                //}

                if (_UserHookData.Status == ScanStatus.SCAN_STANBY)
                {
                    _UserHookData.ProcessedImageCount = 0;
                    _UserHookData.m_nRemainLength = ImageHeight;
                    _UserHookData.PageUnit = ImageHeightDefault;


                    //Logger.Log(LEVEL.INFO, CLASS.CAMERA, $"[{CameraID}] frame : #{_UserHookData.ProcessedImageCount}, RamainLine : #{_UserHookData.RemainLineCount}");
                    Console.WriteLine($"frame : #{_UserHookData.ProcessedImageCount}, RamainLine : #{_UserHookData.m_nRemainLength}");

                    MIL.MdigProcess(MilDigitizer[nDevNo], _milScanBuffer, BUFFER_SIZE, MIL.M_START, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(_hUserData));
                    _UserHookData.Status = ScanStatus.SCAN_RUN;
                }
            }
            public void LineScanStop(int nDevNo)
            {
                MIL.MdigProcess(MilDigitizer[nDevNo], _milScanBuffer, BUFFER_SIZE, MIL.M_STOP, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(_hUserData));
            }

            public void SimualtionModeStart()
            {
                _isSimualtionMode = true;
            }
            public void SimualtionModeStop()
            {
                _isSimualtionMode = false;
            }

            public void UpdateScanGrabParamFromPLC(int nDevNo, int nScanIndex, int nTabCount, List<OpenCvSharp.Mat> ListMatImage, List<CogImage8Grey> ListCogImage)
            {
                int nImgRow = 0;                   //Y Size
                int nImgCol = ImageWidth;  //X Size
                double dSceneStartPos = 0;
                double dSceneEndPos = 0;
                double dSceneStartPosSumOffset = 0;
                double dSceneEndPossSumOffset = 0;
                double dImgSize = 0;

                for (int tab = 0; tab < nTabCount; tab++)
                {
                    //1 : PLC한테서 Panel Scan 위치를 가져온다.
                    nScanIndex = 0; //PLC Read 필요

                    //2 : 현재 Scan위치에 맞는 Model Recipe(Tab 길이, Tab간격 등)을 가져온다.
                    double TabLength = 60/*GetPLC_Recipe_DWord((RW_MX_ATT_TOP_TAB_LENGHT), 1000)*/;
                    if (tab != 0)
                        dSceneStartPos += 100/*GetPLC_Recipe_DWord((RW_MX_ATT_TOP_TAB_1_LEFT_X_TAB_2_LEFT_X + (2 * (tab - 1))), 1000)*/;
                    dSceneEndPos = (dSceneStartPos + TabLength);

                    dSceneStartPosSumOffset = dSceneStartPos /*+ GetPLC_Recipe_Word(RW_MX_ATT_TOP_TAB_LEFT_X_OFFSET, 10)*/;
                    dSceneEndPossSumOffset = dSceneEndPos/* + GetPLC_Recipe_Word(RW_MX_ATT_TOP_TAB_RIGHT_X_OFFSET, 10)*/;

                    dImgSize = dSceneEndPossSumOffset - dSceneStartPosSumOffset;
                    nImgRow = (int)(dImgSize / (DEFINE.LINE_SCAN_PIXEL_SIZE / DEFINE.CAM_LENS_SCALE)) + 1;

                    //3 : PLC한테서 받은 Data로 전체 Grab 길이 및 실제 사용하는 Image Buffer Size를 설정한다.
                    ListMatImage[tab] = new OpenCvSharp.Mat(nImgRow, nImgCol, OpenCvSharp.MatType.CV_8UC1); //Mat
                    ListCogImage[tab] = new CogImage8Grey(nImgCol, nImgRow); //cognex

                    //4 : BufferProcessing 내부 Start ~ End Line 변수 설정
                    vSceneState[nDevNo, nScanIndex, tab] = (int)CamStatus.SCAN_READY;
                    vTabStartLine[nDevNo, nScanIndex, tab] = (int)(dSceneStartPosSumOffset / (DEFINE.LINE_SCAN_PIXEL_SIZE / DEFINE.CAM_LENS_SCALE)) + 1;
                    vTabEndLine[nDevNo, nScanIndex, tab] = (int)(dSceneEndPossSumOffset / (DEFINE.LINE_SCAN_PIXEL_SIZE / DEFINE.CAM_LENS_SCALE)) + 1;

                }
            }
            public void UpdateScanGrabParamsManual(int nMilCamInd, int nScanInd, int nTabCnt, double[] dTabStart, double[] dTabEnd, ref Main.PatternTag[,] Pattern, bool bMannual = false)
            {
                int nImgRow = 0;
                int nImageCol = _UserHookData.mszSize.Width;
                double dSceneStartPos = 0;
                double dSceneEndPos = 0;
                OpenCvSharp.Mat[] refMatimage = new OpenCvSharp.Mat[nTabCnt];
                if (bMannual == false)
                {
                    if (Pattern.GetLength(0) != nScanInd && Pattern.GetLength(1) != nTabCnt)
                    {
                        //int nCols = nScanInd;
                        Pattern = new PatternTag[nScanInd, nTabCnt];
                        for (int nColCnt = 0; nColCnt < nScanInd; nColCnt++)
                        {
                            for (int nCnt = 0; nCnt < nTabCnt; nCnt++)
                            {
                                Pattern[nColCnt, nCnt] = new PatternTag();
                                Pattern[nColCnt, nCnt].m_MatLineScanBuf = refMatimage[nCnt];
                            }
                        }
                    }
                }

                _UserHookData.m_arrlistSceneState = new List<int>[nScanInd];
                _UserHookData.m_arrlistTabStartLine = new List<int>[nScanInd];
                _UserHookData.m_arrlistTabEndLine = new List<int>[nScanInd];

                for (int i = 0; i < nScanInd; i++)
                {
                    _UserHookData.m_arrlistSceneState[i] = new List<int>();
                    _UserHookData.m_arrlistTabStartLine[i] = new List<int>();
                    _UserHookData.m_arrlistTabEndLine[i] = new List<int>();

                    for (int nTabNo = 0; nTabNo < nTabCnt; nTabNo++)
                    {
                        dSceneStartPos = dTabStart[nTabNo];
                        dSceneEndPos = dTabEnd[nTabNo];
                        nImgRow = (int)((dSceneEndPos - dSceneStartPos) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE));
                        refMatimage[nTabNo] = new OpenCvSharp.Mat(nImageCol, nImgRow, OpenCvSharp.MatType.CV_8UC1);
                        _UserHookData.m_arrlistSceneState[i].Add(Convert.ToInt32(SceneStatus.SCENE_GRAB_STANBY));
                        _UserHookData.m_arrlistTabStartLine[i].Add(Convert.ToInt32((dSceneStartPos / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE))));
                        _UserHookData.m_arrlistTabEndLine[i].Add(Convert.ToInt32((dSceneEndPos / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE))));

                        ////2023 0126 YSH 버퍼 계산부분         
                        //dTabLength = Main.recipe.m_PatternYSize; //Pattern Size
                        //if(nTabNo !=0)
                        //    dSceneStartPos = dSceneEndPos + Main.recipe.m_PatternToPatternYDistnace; //각 Grab 시작 위치

                        //dSceneEndPos = dSceneStartPos + dTabLength;

                        //nImgRow = (int)((dSceneEndPos - dSceneStartPos) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE));
                        //refMatimage[nTabNo] = new OpenCvSharp.Mat(nImageCol, nImgRow, OpenCvSharp.MatType.CV_8UC1);
                        //_UserHookData.m_arrlistSceneState[i].Add((int)SceneStatus.SCENE_GRAB_STANBY);
                        //_UserHookData.m_arrlistTabStartLine[i].Add((int)(dSceneStartPos / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE)));
                        //_UserHookData.m_arrlistTabEndLine[i].Add((int)(dSceneEndPos / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE)));
                    }
                }

            }
            public bool GrabLineScan(int nScanInd, int nSceneCount, int nDirection, double dGrabDist)
            {
                bool bRes = true;
                _UserHookData.m_arrScanState = new int[nScanInd];
                refVectMatImg = new OpenCvSharp.Mat[nSceneCount];
                //for (int i = 0; i < nScanInd; i++)
                //{
                _UserHookData.m_arrScanState[nScanInd - 1] = (int)ScanStatus.SCAN_RUN;
                _UserHookData.m_nScanIndex = nScanInd - 1;
                _UserHookData.m_nSceneIndex = 0;
                int nCalcBufferSize = Convert.ToInt32((dGrabDist / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE)));

                for (int nCnt = 0; nCnt < nSceneCount; nCnt++)
                {
                    _UserHookData.m_arrlistSceneState[nScanInd - 1][nCnt] = (int)ScanStatus.SCAN_STANBY;
                    refVectMatImg[nCnt] = new OpenCvSharp.Mat();
                    if (nCalcBufferSize < _UserHookData.m_arrlistTabEndLine[nScanInd - 1][nCnt])
                        return bRes = false;
                }
                //}

                _UserHookData.mszSize.Width = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_X, MIL.M_NULL);
                _UserHookData.mszSize.Height = (int)MIL.MdigInquire(MilDigitizer[DeviceID], MIL.M_SIZE_Y, MIL.M_NULL);
                _UserHookData.m_nRemainLength = (int)(dGrabDist / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / (Main.DEFINE.CAM_LENS_SCALE)));
                _UserHookData.m_nFrameCount = 0;
                _UserHookData.m_nDirection = nDirection;
                _UserHookData.m_nSceneCount = nSceneCount;
                _UserHookData.m_nGrabMoveLine = (int)(dGrabDist / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / (Main.DEFINE.CAM_LENS_SCALE)));
                _UserHookData.m_nReverseBufferLength = 0;



                MIL.MdigProcess(MilDigitizer[DeviceID], _UserHookData._milScanBuffer, BUFFER_SIZE, MIL.M_START, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(_hUserData));
                return bRes;
            }
            public void StopLineScanGrab(int nScanInd)
            {
                _UserHookData.m_arrScanState[nScanInd] = (int)ScanStatus.SCAN_STANBY;

                MIL.MdigProcess(MilDigitizer[DeviceID], _milScanBuffer, BUFFER_SIZE, MIL.M_STOP, MIL.M_DEFAULT, _ProcessingFunctionPtr, GCHandle.ToIntPtr(_hUserData));
            }
            public bool LineScanGrabStatus(int nScanNo)
            {
                if (_UserHookData.m_arrScanState[nScanNo] == (int)ScanStatus.SCAN_COMPLETE)
                    return true;
                else
                    return false;
            }
            private static void Thread_CreaeLinescanImage()
            {
                while (true)
                {
                    //Byte Data 및 현재 HookData 데이터 확인
                    if (HookDataQueue.Count > 0 && ByteArrQueue.Count > 0)
                    {
                        byte[] byteData = ByteArrQueue.Dequeue();
                        HookDataStruct HookData = HookDataQueue.Dequeue();
                        int nCurPageFirstLine = (HookData.m_nGrabMoveLine - HookData.m_nRemainLength);
                        int nCurPageEndLine = nCurPageFirstLine + Main.DEFINE.GRAB_SIZE_Y;
                        int nSceneStartLine = HookData.m_arrlistTabStartLine[HookData.m_nScanIndex][HookData.m_nSceneIndex];
                        int nSceneEndLine = HookData.m_arrlistTabEndLine[HookData.m_nScanIndex][HookData.m_nSceneIndex];

                        switch (HookData.m_arrlistSceneState[HookData.m_nScanIndex][HookData.m_nSceneIndex])
                        {
                            case (int)SceneStatus.SCENE_GRAB_STANBY:
                                OpenCvSharp.Mat tempImgStart = new OpenCvSharp.Mat((nCurPageEndLine - nSceneStartLine), HookData.mszSize.Width, OpenCvSharp.MatType.CV_8UC1, byteData);
                                OpenCvSharp.Mat tempImgTrans = new OpenCvSharp.Mat(HookData.mszSize.Width, (nCurPageEndLine - nSceneStartLine), OpenCvSharp.MatType.CV_8UC1);
                                OpenCvSharp.Cv2.Transpose(tempImgStart, tempImgTrans);
                                TempMatImage = tempImgTrans;
                                break;
                            case (int)SceneStatus.SCENE_GRAB_RUN:
                                if (nSceneEndLine > nCurPageEndLine)
                                {
                                    OpenCvSharp.Mat tempImgRun = new OpenCvSharp.Mat(Main.DEFINE.GRAB_SIZE_Y, HookData.mszSize.Width, OpenCvSharp.MatType.CV_8UC1, byteData);
                                    OpenCvSharp.Mat tempImgTrans2 = new OpenCvSharp.Mat(HookData.mszSize.Width, (nCurPageEndLine - nSceneStartLine), OpenCvSharp.MatType.CV_8UC1);

                                    OpenCvSharp.Cv2.Transpose(tempImgRun, tempImgTrans2);
                                    OpenCvSharp.Cv2.HConcat(TempMatImage, tempImgTrans2, TempMatImage);
                                }
                                else
                                {
                                    OpenCvSharp.Mat tempImgEnd = new OpenCvSharp.Mat((nSceneEndLine - nCurPageFirstLine), HookData.mszSize.Width, OpenCvSharp.MatType.CV_8UC1, byteData);
                                    OpenCvSharp.Mat tempImgTrans3 = new OpenCvSharp.Mat(HookData.mszSize.Width, (nSceneEndLine - nCurPageFirstLine), OpenCvSharp.MatType.CV_8UC1);
                                    OpenCvSharp.Cv2.Transpose(tempImgEnd, tempImgTrans3);
                                    OpenCvSharp.Cv2.HConcat(TempMatImage, tempImgTrans3, TempMatImage);
                                    refVectMatImg[HookData.m_nSceneIndex] = TempMatImage;

                                    if (HookData.CamStatus == CamStatus.PAGE_COMPLETE)
                                    {
                                        GrabScanIndex = HookData.m_nSceneIndex;
                                        GrabSceneIndex = HookData.m_nScanIndex;

                                        Console.WriteLine($"Page Complete");
                                        GrabCamStatus = CamStatus.PAGE_COMPLETE;
                                        CheckHookDataState?.Invoke();
                                    }
                                    if (HookData.CamStatus == CamStatus.SCAN_COMPLETE)
                                    {
                                        GrabScanIndex = HookData.m_nSceneIndex;
                                        GrabSceneIndex = HookData.m_nScanIndex;
                                        //_UserHookData.m_arrScanState[nScanIndex] = (int)ScanStatus.SCAN_COMPLETE;
                                        Console.WriteLine($"Scan Complete");
                                        GrabCamStatus = CamStatus.SCAN_COMPLETE;
                                        //MIL.MdigProcess(_UserHookData.MilDigitizer[0], _UserHookData._milScanBuffer, BUFFER_SIZE, MIL.M_STOP, MIL.M_DEFAULT, _ProcessingFunctionPtr, _UserPtr);
                                        CheckHookDataState?.Invoke();
                                    }

                                }
                                break;
                        }
                    }
                    //Thread.Sleep(5);
                }

            }
        }
        public int nScan_Max_Cnt = 4;
        public enum eConnectionStatus
        {
            Connection_Fail,
            Connection_Success,
            Connection_NotFound_Board,
            Connection_NotFound_Camera,
        }


        private static Queue<HookDataStruct> HookDataQueue = new Queue<HookDataStruct>();
        private static Queue<byte[]> ByteArrQueue = new Queue<byte[]>();

        public class HookDataStruct
        {
            public Size mszSize;
            public MIL_ID MilSystem;
            public MIL_ID MilImageDisp;
            public MIL_ID[] MilDigitizer;
            public MIL_ID[] _milScanBuffer;
            public int ProcessedImageCount;
            public int m_nRemainLength;
            public int m_nFrameCount;
            public int m_nDirection;
            public int PageUnit;
            public int m_nScanIndex;
            public int m_nSceneCount;
            public int m_nSceneIndex;
            public int m_nCurSeneIndex;
            public int m_nCurScanIndex;
            public int m_nBufferIndex;
            public int m_nBufferHeight;
            public int m_nGrabMoveLine;
            public int m_nReverseBufferLength;
            public ScanStatus Status;
            public CamStatus CamStatus;

            public int[] m_arrScanState = new int[Main.DEFINE.nScan_Max_Cnt];
            public List<int>[] m_arrlistSceneState { get; set; } = new List<int>[Main.DEFINE.nScan_Max_Cnt];
            public List<int>[] m_arrlistTabStartLine = new List<int>[Main.DEFINE.nScan_Max_Cnt];
            public List<int>[] m_arrlistTabEndLine = new List<int>[Main.DEFINE.nScan_Max_Cnt];

            public HookDataStruct DeepCopy()
            {
                HookDataStruct hookData = new HookDataStruct();
                hookData.mszSize = mszSize;
                hookData.MilSystem = MilSystem;
                hookData.MilImageDisp = MilImageDisp;
                hookData.MilDigitizer = MilDigitizer;
                hookData._milScanBuffer = _milScanBuffer;
                hookData.ProcessedImageCount = ProcessedImageCount;
                hookData.m_nRemainLength = m_nRemainLength;
                hookData.m_nFrameCount = m_nFrameCount;
                hookData.m_nDirection = m_nDirection;
                hookData.PageUnit = PageUnit;
                hookData.m_nScanIndex = m_nScanIndex;
                hookData.m_nSceneCount = m_nSceneCount;
                hookData.m_nSceneIndex = m_nSceneIndex;
                hookData.m_nCurSeneIndex = m_nCurSeneIndex;
                hookData.m_nCurScanIndex = m_nCurScanIndex;
                hookData.m_nBufferIndex = m_nBufferIndex;
                hookData.m_nBufferHeight = m_nBufferHeight;
                hookData.m_nGrabMoveLine = m_nGrabMoveLine;
                hookData.m_nReverseBufferLength = m_nReverseBufferLength;
                hookData.Status = Status;
                hookData.CamStatus = CamStatus;

                //hookData.m_arrScanState;
                for (int i = 0; i < m_arrScanState.Length; i++)
                    hookData.m_arrScanState[i] = m_arrScanState[i];

                for (int i = 0; i < m_arrlistSceneState.Length; i++)
                    hookData.m_arrlistSceneState[i] = m_arrlistSceneState[i].ToList();

                for (int i = 0; i < m_arrlistTabStartLine.Length; i++)
                    hookData.m_arrlistTabStartLine[i] = m_arrlistTabStartLine[i].ToList();

                for (int i = 0; i < m_arrlistTabEndLine.Length; i++)
                    hookData.m_arrlistTabEndLine[i] = m_arrlistTabEndLine[i].ToList();

                return hookData;
            }

        };
        private static OpenCvSharp.Mat[] refVectMatImg;
        private static OpenCvSharp.Mat TempMatImage;
        private static int GrabScanIndex;
        private static int GrabSceneIndex;
        private static CamStatus GrabCamStatus;
    }
}
