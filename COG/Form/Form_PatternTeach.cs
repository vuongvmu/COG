using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using OpenCvSharp;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Implementation.Internal;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.CNLSearch;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.SearchMax;
using Cognex.VisionPro.LineMax;

using JAS.Controls.Display;
using COG.Controls;
using AW;

namespace COG
{
    public partial class Form_PatternTeach : Form
    {
        public bool m_ToolShow;
        public int CamNo;
        public int StageNo;
        private int m_CamNo;
        private int m_RetiMode;
        private int TapNo;
        private int m_SelectLight = 0;

        private int m_PatNo_Sub = 0;
        private int m_SelectBlob = 0;
        private int m_SelectCaliper = 0;
        private int m_SelectFindLine = 0;
        private int m_LineSubNo = 0;
        private int m_SelectCircle = 0;
        private int m_SelectAkkon = 0;

        private bool m_TABCHANGE_MODE = false;
        private bool m_PatchangeFlag = false; //Blob번호변경이나 , caliper 번호변경시
        private bool ThresValue_Sts = false;
        private bool NUD_Initial_Flag = false;
        private bool m_AkkonPatChangeFlag = false;
        private bool m_AkkonPatSelectPosFlag = false; //false : Left, True : Right

        private int M_TOOL_MODE = 0;

        private const int M_PATTERN = 1;
        private const int M_SEARCH = 2;
        private const int M_ORIGIN = 3;

        private const int M_ORIGIN_SIZE_S = 120;
        private int M_ORIGIN_SIZE = 120;
        private double ZoomBackup = new double();

        private CogSearchMaxTool[,] PT_Pattern = new CogSearchMaxTool[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBPATTERNMAX]; //MAIN PAT ++[TapNo,m_PatSubNo]
        private CogPMAlignTool[,] PT_GPattern = new CogPMAlignTool[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBPATTERNMAX]; //MAIN PAT ++[TapNo,m_PatSubNo]

        private bool[,] PT_Pattern_USE = new bool[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBPATTERNMAX];
        private double[] PT_AcceptScore = new double[Main.DEFINE.Pattern_Max];
        private double[] PT_GAcceptScore = new double[Main.DEFINE.Pattern_Max];

        CogRectangle PatMaxTrainRegion;
        CogRectangle PatMaxSearchRegion;
        CogPointMarker MarkORGPoint = new CogPointMarker();


        private List<CogFindLineTool> PT_PMFindLineTool = new List<CogFindLineTool>();
        private CogBlobTool PT_PMBlobTool = new CogBlobTool();

        private List<Label> Light_Text = new List<Label>();
        private List<RadioButton> LightRadio = new List<RadioButton>();
        private List<RadioButton> RBTN_PAT = new List<RadioButton>();
        private List<RadioButton> RBTN_CALIPER = new List<RadioButton>();
        private List<RadioButton> RBTN_FINDLINE = new List<RadioButton>();
        private List<RadioButton> RBTN_CIRCLE = new List<RadioButton>();
        private List<RadioButton> RBTN_LINEMAX_H_COND = new List<RadioButton>();
        private List<RadioButton> RBTN_LINEMAX_V_COND = new List<RadioButton>();
        private List<RadioButton> RBTN_CALIPER_METHOD = new List<RadioButton>();
        private List<RadioButton> RBTN_CIR_CALIPER_METHOD = new List<RadioButton>();

        private List<Button> BTN_TOOLSET = new List<Button>();
        private List<string> TOOLTYPE = new List<string>();

        private CogToolBlock PT_BlobToolBlock = new CogToolBlock();
        private Form_ToolTeach ToolTeach = new Form_ToolTeach();
        private Form_PatternMask FormPatternMask = new Form_PatternMask();

        private Main.MTickTimer m_Timer = new Main.MTickTimer();

        private CogFixtureTool PT_FixtureTool = new CogFixtureTool();
        private CogTransform2DLinear PatResult = new CogTransform2DLinear();

        CogPointMarker[,] MarkPoint = new CogPointMarker[Main.DEFINE.Pattern_Max, 2];
        CogDistancePointPointTool nDistance = new CogDistancePointPointTool();
        bool[] nDistanceShow = new bool[Main.DEFINE.Pattern_Max];
        int nCrossSize = 200;

        #region  BLOB
        private Main.BlobTagData[,] PT_BlobPara = new Main.BlobTagData[Main.DEFINE.Pattern_Max, Main.DEFINE.BLOB_CNT_MAX];  //para
        private CogBlobTool[,] PT_BlobTools = new CogBlobTool[Main.DEFINE.Pattern_Max, Main.DEFINE.BLOB_CNT_MAX];
        CogRectangleAffine BlobTrainRegion = new CogRectangleAffine();
        private bool[] PT_Blob_MarkUSE = new bool[Main.DEFINE.Pattern_Max];
        private bool[] PT_Blob_CaliperUSE = new bool[Main.DEFINE.Pattern_Max];
        private int[] PT_Blob_InspCnt = new int[Main.DEFINE.Pattern_Max];
        #endregion

        #region CALIPER
        private static Main.CaliperTagData[,] PT_CaliPara = new Main.CaliperTagData[Main.DEFINE.Pattern_Max, Main.DEFINE.CALIPER_MAX];
        private CogCaliperTool[,] PT_CaliperTools = new CogCaliperTool[Main.DEFINE.Pattern_Max, Main.DEFINE.CALIPER_MAX];
        private CogRectangleAffine PTCaliperRegion;
        private CogRectangleAffine[] PTCaliperDividedRegion;
        private bool[] PT_Caliper_MarkUSE = new bool[Main.DEFINE.Pattern_Max];
        private string[] PT_CaliperName = new string[Main.DEFINE.CALIPER_MAX];
        #endregion

        #region FINDLine
        private static Main.FindLineTagData[,,] PT_FindLinePara = new Main.FindLineTagData[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBLINE_MAX, Main.DEFINE.FINDLINE_MAX];
        private CogFindLineTool[,,] PT_FindLineTools = new CogFindLineTool[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBLINE_MAX, Main.DEFINE.FINDLINE_MAX];
        private CogFindLineTool PT_FindLineTool;
        private bool[] PT_FindLine_MarkUSE = new bool[Main.DEFINE.Pattern_Max];
        private CogIntersectLineLineTool[] PT_LineLineCrossPoints = new CogIntersectLineLineTool[3];
        //  private bool FINDLineRegionChange = false;
        // FPC Tray
        private List<CogCircle> LineEdge_CircleList = new List<CogCircle>();
        private double RectangleAngle;
        Main.DoublePoint[] TrayPocketPoint = new Main.DoublePoint[Main.DEFINE.TRAY_POCKET_LIMIT];
        List<CogPointMarker> MarkerPointList = new List<CogPointMarker>();

        private double[] PT_TRAY_GUIDE_DISX = new double[Main.DEFINE.Pattern_Max];
        private double[] PT_TRAY_GUIDE_DISY = new double[Main.DEFINE.Pattern_Max];
        private double[] PT_TRAY_PITCH_DISX = new double[Main.DEFINE.Pattern_Max];
        private double[] PT_TRAY_PITCH_DISY = new double[Main.DEFINE.Pattern_Max];
        //        private double[,] PT_TRAY_POINT_OFFSET = new double[Main.DEFINE.TRAY_POCKET_X, Main.DEFINE.TRAY_POCKET_Y];

        //==================== LINEMAX ====================//
        private CogLineMaxTool[,,] PT_LineMaxTools = new CogLineMaxTool[Main.DEFINE.Pattern_Max, Main.DEFINE.SUBLINE_MAX, Main.DEFINE.FINDLINE_MAX];
        private CogLineMaxTool PT_LineMaxTool;

        //==================================================//
        private string[] PT_FINDLineName = new string[Main.DEFINE.FINDLINE_MAX];
        #endregion

        #region CIRCLE
        private static Main.FindCircleTagData[,] PT_CirclePara = new Main.FindCircleTagData[Main.DEFINE.Pattern_Max, Main.DEFINE.CIRCLE_MAX];
        private CogFindCircleTool[,] PT_CircleTools = new CogFindCircleTool[Main.DEFINE.Pattern_Max, Main.DEFINE.CIRCLE_MAX];
        private CogFindCircleTool PT_CircleTool;

        private bool[] PT_Circle_MarkUSE = new bool[Main.DEFINE.Pattern_Max];
        private const int M_PLUS = 1;
        private const int M_MINUS = -1;
        private const int M_SEARCHLEGNTH = 0;
        private const int M_PROJECTION = 1;
        private const int M_RADIUS = 2;
        #endregion

        #region AKKON
        private bool[] PT_Akkon_MarkUSE = new bool[Main.DEFINE.Pattern_Max];


        private static Main.AkkonTagData[] PT_AkkonPara = new Main.AkkonTagData[Main.DEFINE.Pattern_Max];



        private Main.LeadGroupInfo[] LeadGroupInfo = new Main.LeadGroupInfo[20]; //Group 최대 개수(임시지정)
        private CogRectangleAffine PTAkkonRegion = new CogRectangleAffine();
        private string[] PT_AkkonName = new string[Main.DEFINE.Pattern_Max]; //Tab 수
        private bool Thumbnail_MoveFlag = false;
        private int nMovePixelCount = 1;
        private bool bGroupModeFlag = false;

        private CogRectangleAffine[,] GroupLeadData = new CogRectangleAffine[Main.DEFINE.MAX_LEAD_GROUP_COUNT, Main.DEFINE.MAX_LEAD_COUNT];

        private List<List<CogRectangleAffine>> GroupListLeadData = new List<List<CogRectangleAffine>>();

        private int nSelectGroupNumber = 0;
        private bool bCloneROIDir = false;
        CogRectangleAffine cogRectNewROI;
        enum ROI_Direction
        {
            CLONE_ROI_DIR_HORIZONTAL = 0,
            CLONE_ROI_DIR_VERTICAL = 1
        }

        private static bool _bATTResult = false;
        #endregion

        #region Align Inspection
        private enum ALIGN_INDEX
        {
            INSP_POS_LEFT = 0,
            INSP_POS_RIGHT = 1,
            TEACH_MODE_MARK = 0,
            TEACH_MODE_EDGE = 1,
            ALIGN_POS_X = 0,
            ALIGN_POS_Y = 1,
            TARGET_POS_FPC = 0,
            TARGET_POS_PANEL = 1
        }
        private int nInspectionPos = (int)ALIGN_INDEX.INSP_POS_LEFT;
        private int nTeachMode = (int)ALIGN_INDEX.TEACH_MODE_MARK;
        private int nAlignPos = (int)ALIGN_INDEX.ALIGN_POS_X;
        private int nTargetPos = (int)ALIGN_INDEX.TARGET_POS_FPC;
        private bool bAlignROITracking = false;
        private static Main.AlignTagData[] PT_AlignPara = new Main.AlignTagData[Main.DEFINE.Pattern_Max];
        private Main.AlignInspectionResult AlignResult = new Main.AlignInspectionResult();
        private CogCaliperPolarityConstants CaliperPol;
        #endregion

        private List<CogRecordDisplay> PT_SubDisplay = new List<CogRecordDisplay>();
        private List<CogRecordDisplay> AM_SubDisplay = new List<CogRecordDisplay>();

        private List<Label> LB_PATTERN = new List<Label>();

        CogPointMarker PatORGPoint = new CogPointMarker();

        CogPointMarker FirstPocketPos = new CogPointMarker();
        CogPointMarker X_PocketPitchPos = new CogPointMarker();
        CogPointMarker Y_PocketPitchPos = new CogPointMarker();

        private int TRAY_POCKET_X = 1;
        private int TRAY_POCKET_Y = 1;

        private Form_Message formMessage = new Form_Message(2);

        private static CogRecordDisplay PT_Display01 = new CogRecordDisplay();

        public CtrlTabButton TabButtonControl = null; //2022 1013 YSH Tab Button
        private bool _buttonSeledted = false; 
        private int _tabNumber = -1;
        private bool b_ParameterMode = false;
        public Form_PatternTeach()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            Allocate_Array();
        }
        private void Allocate_Array()
        {
            PT_Display01 = PT_DISPLAY_CONTROL.CogDisplay00;
            PT_Display01.Changed += PT_Display01_Changed;

            PT_DisplayToolbar01.Display = PT_Display01;
            PT_DisplayStatusBar01.Display = PT_Display01;
            //---------------LIGHT_SETTING----------------
            Light_Text.Add(LB_LIGHT_0);
            Light_Text.Add(LB_LIGHT_1);
            Light_Text.Add(LB_LIGHT_2);
            Light_Text.Add(LB_LIGHT_3);

            LightRadio.Add(RBTN_LIGHT_0);
            LightRadio.Add(RBTN_LIGHT_1);
            LightRadio.Add(RBTN_LIGHT_2);
            LightRadio.Add(RBTN_LIGHT_3);

            RBTN_PAT.Add(RBTN_PAT_0);
            RBTN_PAT.Add(RBTN_PAT_1);
            RBTN_PAT.Add(RBTN_PAT_2);
            RBTN_PAT.Add(RBTN_PAT_3);
            RBTN_PAT.Add(RBTN_PAT_4);
            RBTN_PAT.Add(RBTN_PAT_5);
            RBTN_PAT.Add(RBTN_PAT_6);
            RBTN_PAT.Add(RBTN_PAT_7);

            BTN_TOOLSET.Add(BTN_TOOL_00);
            BTN_TOOLSET.Add(BTN_TOOL_01);
            BTN_TOOLSET.Add(BTN_TOOL_02);

            BTN_TOOLSET.Add(BTN_TOOL_03);
            BTN_TOOLSET.Add(BTN_TOOL_04);
            BTN_TOOLSET.Add(BTN_TOOL_05);   // AKKON TOOL 없음
            BTN_TOOLSET.Add(BTN_TOOL_05);

            RBTN_CALIPER.Add(RBTN_CALIPER00);
            RBTN_CALIPER.Add(RBTN_CALIPER01);
            RBTN_CALIPER.Add(RBTN_CALIPER02);
            RBTN_CALIPER.Add(RBTN_CALIPER03);

            RBTN_FINDLINE.Add(RBTN_FINDLINE00);
            RBTN_FINDLINE.Add(RBTN_FINDLINE01);
            RBTN_FINDLINE.Add(RBTN_FINDLINE02);
            RBTN_FINDLINE.Add(RBTN_FINDLINE03);
            RBTN_FINDLINE.Add(RBTN_FINDLINE_CIRCLE);

            RBTN_LINEMAX_H_COND.Add(RBTN_HORICON_YMIN);
            RBTN_LINEMAX_H_COND.Add(RBTN_HORICON_YMAX);
            RBTN_LINEMAX_V_COND.Add(RBTN_VERTICON_XMIN);
            RBTN_LINEMAX_V_COND.Add(RBTN_VERTICON_XMAX);

            RBTN_CALIPER_METHOD.Add(RBTN_CALIPER_METHOD_SCORE);
            RBTN_CALIPER_METHOD.Add(RBTN_CALIPER_METHOD_POS);

            RBTN_CIR_CALIPER_METHOD.Add(RBTN_CIR_CALIPER_METHOD_SCORE);
            RBTN_CIR_CALIPER_METHOD.Add(RBTN_CIR_CALIPER_METHOD_POS);

            RBTN_CIRCLE.Add(RBTN_CIRCLE00);
            RBTN_CIRCLE.Add(RBTN_CIRCLE01);
            RBTN_CIRCLE.Add(RBTN_CIRCLE_LINE00);
            RBTN_CIRCLE.Add(RBTN_CIRCLE_LINE01);
            RBTN_CIRCLE.Add(RBTN_CIRCLE_LINE02);

            TOOLTYPE.Add("CogPMAlignTool1");
            TOOLTYPE.Add("CogFindLineTool1");
            TOOLTYPE.Add("CogFindLineTool2");

            TOOLTYPE.Add("CogFindLineTool3");
            TOOLTYPE.Add("CogFindLineTool4");
            TOOLTYPE.Add("CogCNLSearchTool1");

            for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
            {
                string ntempSub;
                if (i == 0)
                    ntempSub = "MAIN_PAT" + i.ToString();
                else
                    ntempSub = "SUB__PAT" + i.ToString();
                CB_SUB_PATTERN.Items.Add(ntempSub);

                string nTempName;
                nTempName = "PT_SubDisplay_" + i.ToString("00");
                CogRecordDisplay nType = (CogRecordDisplay)this.Controls["TABC_MANU"].Controls["TAB_00"].Controls[nTempName];
                PT_SubDisplay.Add(nType);
                PT_SubDisplay[i].Visible = true;

                //nTempName = "AM_SubDisplay_" + i.ToString("00");
                //CogRecordDisplay nType2 = (CogRecordDisplay)this.Controls["TABC_MANU"].Controls["TAB_06"].Controls[nTempName];
                //AM_SubDisplay.Add(AM_SubDisplay_00);
                //AM_SubDisplay[i].Visible = true;

                nTempName = "LB_PATTERN_" + i.ToString("00");
                Label nType1 = (Label)this.Controls["TABC_MANU"].Controls["TAB_00"].Controls[nTempName];
                LB_PATTERN.Add(nType1);
                LB_PATTERN[i].Visible = true;
            }

            //YSH 임시
            AM_SubDisplay.Add(AM_SubDisplay_00);
            AM_SubDisplay.Add(AM_SubDisplay_01);
            AM_SubDisplay.Add(AM_SubDisplay_02);
            AM_SubDisplay.Add(AM_SubDisplay_03);
            AM_SubDisplay.Add(AM_SubDisplay_04);
            AM_SubDisplay.Add(AM_SubDisplay_05);
            AM_SubDisplay.Add(AM_SubDisplay_06);
            AM_SubDisplay[0].Visible = true;
            AM_SubDisplay[1].Visible = true;
            AM_SubDisplay[2].Visible = true;
            AM_SubDisplay[3].Visible = true;

            for (int i = 0; i < Main.DEFINE.Pattern_Max; i++)
            {
                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    PT_Pattern[i, j] = new CogSearchMaxTool();
                    PT_GPattern[i, j] = new CogPMAlignTool();
                    PT_Pattern[i, j].Pattern.TrainRegion = new CogRectangle();
                    PT_GPattern[i, j].Pattern.TrainRegion = new CogRectangle();
                }

                for (int j = 0; j < Main.DEFINE.CALIPER_MAX; j++)
                {
                    PT_CaliperTools[i, j] = new CogCaliperTool();
                    PT_CaliPara[i, j] = new Main.CaliperTagData();
                }

                for (int j = 0; j < Main.DEFINE.BLOB_CNT_MAX; j++)
                {
                    PT_BlobTools[i, j] = new CogBlobTool();
                    PT_BlobPara[i, j] = new Main.BlobTagData();
                }

                for (int k = 0; k < Main.DEFINE.SUBLINE_MAX; k++)
                {
                    for (int j = 0; j < Main.DEFINE.FINDLINE_MAX; j++)
                    {
                        PT_FindLinePara[i, k, j] = new Main.FindLineTagData();
                        PT_FindLineTools[i, k, j] = new CogFindLineTool();
                        PT_LineMaxTools[i, k, j] = new CogLineMaxTool();
                    }
                }

                for (int j = 0; j < Main.DEFINE.TRAY_POCKET_LIMIT; j++)
                    TrayPocketPoint[i] = new Main.DoublePoint();

                for (int j = 0; j < Main.DEFINE.CIRCLE_MAX; j++)
                {
                    PT_CircleTools[i, j] = new CogFindCircleTool();
                    PT_CirclePara[i, j] = new Main.FindCircleTagData();
                }

                // ATT
                PT_AkkonPara[i] = new Main.AkkonTagData();
                PT_AlignPara[i] = new Main.AlignTagData();

                for (int nInspPos = 0; nInspPos < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; nInspPos++)
                {
                    for (int nTargetPos = 0; nTargetPos < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; nTargetPos++)
                    {
                        PT_AlignPara[i].AlignCaliperX[nInspPos, nTargetPos] = new CogCaliperTool();
                        PT_AlignPara[i].AlignCaliperY[nInspPos, nTargetPos] = new CogCaliperTool();
                    }
                }

                for (int k = 0; k < Main.DEFINE.SUBPATTERNMAX; k++)
                {
                    PT_AkkonPara[i].LeftPattern[k] = new CogPMAlignTool();
                    PT_AkkonPara[i].RightPattern[k] = new CogPMAlignTool();

                    PT_AkkonPara[i].LeftPattern[k].Pattern.TrainRegion = new CogRectangle();
                    PT_AkkonPara[i].RightPattern[k].Pattern.TrainRegion = new CogRectangle();

                    PT_AlignPara[i].LeftPattern[k] = new CogPMAlignTool();
                    PT_AlignPara[i].RightPattern[k] = new CogPMAlignTool();

                    PT_AlignPara[i].LeftPattern[k].Pattern.TrainRegion = new CogRectangle();
                    PT_AlignPara[i].RightPattern[k].Pattern.TrainRegion = new CogRectangle();
                }
            }

            //Align Result 
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)
                {
                    AlignResult.LeftEdgePointList[i, j] = new List<Point2d>();
                    AlignResult.RightEdgePointList[i, j] = new List<Point2d>();
                }

                AlignResult.YEdgePointList[i] = new List<Point2d>();
            }
            //Group 초기화
            for (int i = 0; i < 20; i++)
                LeadGroupInfo[i] = new Main.LeadGroupInfo();

            for (int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
            {
                string ntempBlob;
                ntempBlob = "BLOB_REGION" + i.ToString();
                CB_BLOB_COUNT.Items.Add(ntempBlob);
            }

            for (int i = 0; i < Main.DEFINE.CALIPER_MAX; i++)
                RBTN_CALIPER[i].Visible = true;

            for (int i = 0; i < Main.DEFINE.FINDLINE_MAX; i++)
            {
                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && i >= 3)
                    break;

                RBTN_FINDLINE[i].Visible = true;
            }

            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
                RBTN_FINDLINE[4].Visible = true;    // 200624 JHKIM 원호 추가
            else
                RBTN_FINDLINE[4].Visible = false;

            for (int i = 0; i < Main.DEFINE.SUBLINE_MAX; i++)
            {
                string ntempSub;
                if (i == 0)
                    ntempSub = "MAIN_LINE" + i.ToString();
                else
                    ntempSub = "SUB__LINE" + i.ToString();
                CB_FINDLINE_SUBLINE.Items.Add(ntempSub);
            }

            for (int i = 0; i < Main.DEFINE.CIRCLE_MAX; i++)
            {
                RBTN_CIRCLE[i].Visible = true;
            }
            RBTN_CIRCLE[2].Visible = true;    // 200624 JHKIM 원호 추가
            RBTN_CIRCLE[3].Visible = true;
            RBTN_CIRCLE[4].Visible = true;

            for (int i = 0; i < 2; i++)
            {
                RBTN_LINEMAX_H_COND[i].Visible = false;
                RBTN_LINEMAX_V_COND[i].Visible = false;
            }

            MarkORGPoint.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            MarkORGPoint.Interactive = true;
            MarkORGPoint.LineStyle = CogGraphicLineStyleConstants.Dot;
            MarkORGPoint.SelectedColor = CogColorConstants.Cyan;
            MarkORGPoint.DragColor = CogColorConstants.Cyan;


            FirstPocketPos.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            FirstPocketPos.Interactive = true;
            FirstPocketPos.LineStyle = CogGraphicLineStyleConstants.Dot;
            FirstPocketPos.Color = CogColorConstants.Orange;
            FirstPocketPos.SelectedColor = CogColorConstants.Orange;
            FirstPocketPos.DragColor = CogColorConstants.Orange;
            FirstPocketPos.SizeInScreenPixels = M_ORIGIN_SIZE;
            FirstPocketPos.LineWidthInScreenPixels = 3;
            FirstPocketPos.SelectedLineWidthInScreenPixels = 3;
            FirstPocketPos.TipText = "First Pos";

            X_PocketPitchPos.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            X_PocketPitchPos.Interactive = true;
            X_PocketPitchPos.LineStyle = CogGraphicLineStyleConstants.Dot;
            X_PocketPitchPos.GraphicType = CogPointMarkerGraphicTypeConstants.InwardArrow;
            X_PocketPitchPos.Color = CogColorConstants.Blue;
            X_PocketPitchPos.SelectedColor = CogColorConstants.Blue;
            X_PocketPitchPos.DragColor = CogColorConstants.Blue;
            X_PocketPitchPos.SizeInScreenPixels = M_ORIGIN_SIZE - 60;
            X_PocketPitchPos.LineWidthInScreenPixels = 2;
            X_PocketPitchPos.SelectedLineWidthInScreenPixels = 2;
            X_PocketPitchPos.TipText = "X PITCH";

            Y_PocketPitchPos.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
            Y_PocketPitchPos.Interactive = true;
            Y_PocketPitchPos.LineStyle = CogGraphicLineStyleConstants.Dot;
            Y_PocketPitchPos.GraphicType = CogPointMarkerGraphicTypeConstants.InwardArrow;
            Y_PocketPitchPos.Color = CogColorConstants.Red;
            Y_PocketPitchPos.SelectedColor = CogColorConstants.Red;
            Y_PocketPitchPos.DragColor = CogColorConstants.Red;
            Y_PocketPitchPos.SizeInScreenPixels = M_ORIGIN_SIZE - 60;
            Y_PocketPitchPos.LineWidthInScreenPixels = 2;
            Y_PocketPitchPos.SelectedLineWidthInScreenPixels = 2;
            Y_PocketPitchPos.TipText = "Y PITCH";

            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                PT_CaliperName[0] = "CALIPER TOP";
                PT_CaliperName[1] = "CALIPER RIGHT";
                PT_CaliperName[2] = "CALIPER BOTTOM";
                PT_CaliperName[3] = "CALIPER LEFT";

                PT_FINDLineName[0] = "HORIZONTAL LINE";
                PT_FINDLineName[1] = "VERTICAL LINE";
                PT_FINDLineName[2] = "DIAGONAL LINE";
                PT_FINDLineName[3] = "POL EDGE LINE";
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                PT_FINDLineName[0] = "HORIZONTAL LINE";
                PT_FINDLineName[1] = "VERTICAL1 LINE";
                PT_FINDLineName[2] = "VERTICAL2 LINE";
                RBTN_FINDLINE[3].Visible = false;
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "ATT_LINE_PC1")
            {
                for(int i =0; i <Main.recipe.m_nTabCount; i++)
                {
                    PT_AkkonName[i] = "Tab" + (i + 1).ToString();
                }
            
            }
        }
        private void Form_PatternTeach_Load(object sender, EventArgs e)
        {
            if (Main.DEFINE.OPEN_F) BTN_IMAGE_OPEN.Visible = true;
            this.Text = Main.AlignUnit[CamNo].m_AlignName;
            this.TopMost = false;
            TapNo = 0;
            m_RetiMode = 0;
            m_CamNo = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo;

            RBTN_FINDLINE00.Checked = true;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" || (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && m_CamNo == Main.DEFINE.CAM_SELECT_1ST_ALIGN))
                TABC_MANU.SelectedIndex = M_TOOL_MODE = Main.DEFINE.M_FINDLINETOOL;
            else
                TABC_MANU.SelectedIndex = M_TOOL_MODE = Main.DEFINE.M_CNLSEARCHTOOL;

            m_PatNo_Sub = 0;
            m_LineSubNo = 0;
            m_SelectBlob = 0;
            m_SelectCaliper = 0;
            m_SelectFindLine = 0;
            m_SelectCircle = 0;
            button1.BringToFront();
            CB_SUB_PATTERN.SelectedIndex = 0;
            CB_BLOB_COUNT.SelectedIndex = 0;
            CB_FINDLINE_SUBLINE.SelectedIndex = 0;
            LightRadio[0].Checked = true;

            GB_TRAY.Visible = false;
            BTN_MAINORIGIN_COPY.Visible = false;
            panel7.Visible = false;
            panel9.Visible = false;
            if (Main.AlignUnit[CamNo].m_AlignName == "PBD" || Main.AlignUnit[CamNo].m_AlignName == "PBD_STAGE" || Main.AlignUnit[CamNo].m_AlignName == "PBD_FOF")
            {
                BTN_PATTERN_COPY.Visible = true;
            }

            if (Main.ALIGNINSPECTION_USE(CamNo))
            {
                CB_BLOB_COUNT.Items[Main.DEFINE.WIDTH_] = "WIDTH__BLOB_REGION";
                CB_BLOB_COUNT.Items[Main.DEFINE.HEIGHT] = "HEIGHT_BLOB_REGION";

                RBTN_CALIPER00.Text = "WIDTH  CALIPER";
                RBTN_CALIPER01.Text = "HEIGHT CALIPER";

                label15.Visible = true;
                CB_EDGEPAIRCHECK.Visible = true;
                #region
                for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
                {
                    for (int j = 0; j < Main.DEFINE.CALIPER_MAX; j++)
                    {
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_UseCheck = true;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].RunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                    }
                }
                for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
                {
                    for (int j = 0; j < Main.DEFINE.BLOB_CNT_MAX; j++)
                    {
                        if (CB_BLOB_USE.Checked)
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_UseCheck = true;
                        }
                        else
                        {
                            Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_UseCheck = false;
                        }

                    }
                }
                #endregion
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                label15.Visible = true;
                CB_EDGEPAIRCHECK.Visible = true;

                RBTN_CALIPER00.Text = "TOP";
                RBTN_CALIPER01.Text = "RIGHT";
                RBTN_CALIPER02.Text = "BOTTOM";
                RBTN_CALIPER03.Text = "LEFT";
            }
            else
            {
                label15.Visible = false;
                CB_EDGEPAIRCHECK.Visible = false;

                RBTN_CALIPER00.Text = "CALIPER 00";
                RBTN_CALIPER01.Text = "CALIPER 01";
            }

            if (Main.DEFINE.OPEN_F == false)
            {
                if (Main.vision.CogCamBuf[m_CamNo].Width > 2000)
                {
                    M_ORIGIN_SIZE = M_ORIGIN_SIZE_S * 2;
                }
                else
                {
                    M_ORIGIN_SIZE = M_ORIGIN_SIZE_S;
                }
            }


            CB_TRAY_BlobMode.Checked = Main.AlignUnit[CamNo].TrayBlobMode;

            #region
            for (int i = 0; i < BTN_TOOLSET.Count; i++)
            {
                BTN_TOOLSET[i].Visible = false;
            }

            for (int i = 0; i < Main.DEFINE.Pattern_Max; i++)
            {
                RBTN_PAT[i].Visible = false;
            }

            BTN_TOOLSET[Main.DEFINE.M_CNLSEARCHTOOL].Visible = true;
            BTN_TOOLSET[Main.DEFINE.M_PMALIGNTOOL].Visible = true;

            // PJH_20221013_S
            //Main.AlignUnit[CamNo].m_PatTagNo = StageNo;
            Main.AlignUnit[CamNo].StageNo = StageNo;
            // PJH_20221013_E

            if (Main.BLOBINSPECTION_USE(CamNo))
            {
                CB_BLOB_MARK_USE.Visible = false;
                Inspect_Cnt.Visible = true;
                LB_BLOBINSPECT.Visible = true; LB_BLOB_INSPECT1.Visible = true; LB_BLOB_INSPECT2.Visible = true; LB_BLOB_INSPECT3.Visible = true;
            }
            else
            {
                Inspect_Cnt.Visible = false;
                LB_BLOBINSPECT.Visible = false; LB_BLOB_INSPECT1.Visible = false; LB_BLOB_INSPECT2.Visible = false; LB_BLOB_INSPECT3.Visible = false;
            }

            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                RBTN_PAT[i].Text = Main.AlignUnit[CamNo].PAT[StageNo, i].m_PatternName;
                RBTN_PAT[i].Visible = true;

                if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && CamNo == 0 && i == 1)   // 1CAM 1SHOT
                    RBTN_PAT[i].Visible = false;

                PT_AcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore;
                PT_GAcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].m_GACCeptScore;

                PT_Caliper_MarkUSE[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].Caliper_MarkUse;

                PT_Blob_MarkUSE[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].Blob_MarkUse;
                PT_Blob_CaliperUSE[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].Blob_CaliperUse;
                PT_Blob_InspCnt[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].m_Blob_InspCnt;

                PT_FindLine_MarkUSE[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLine_MarkUse;
                PT_Circle_MarkUSE[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].Circle_MarkUse;

                PT_TRAY_GUIDE_DISX[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_GUIDE_DISX;
                PT_TRAY_GUIDE_DISY[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_GUIDE_DISY;
                PT_TRAY_PITCH_DISX[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_PITCH_DISX;
                PT_TRAY_PITCH_DISY[i] = Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_PITCH_DISY;
            }

            if (Main.AlignUnit[CamNo].m_AlignName == "REEL_ALIGN_1" || Main.AlignUnit[CamNo].m_AlignName == "REEL_ALIGN_2" || Main.AlignUnit[CamNo].m_AlignName == "REEL_ALIGN_3" || Main.AlignUnit[CamNo].m_AlignName == "REEL_ALIGN_4" || Main.AlignUnit[CamNo].m_AlignName == "ART_PROBE")
            {
                RBTN_PAT[1].Visible = false;
            }

            if (Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY1" || Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY2")
            {
                RBTN_PAT[1].Visible = false;
                GB_TRAY.Visible = true;
            }
            else
            {
                PB_FOF_FPC.Visible = false;
                PB_TFOF_PANEL.Visible = false;
            }

            if ((Main.DEFINE.PROGRAM_TYPE == "FOF_PC7" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC8") & (Main.AlignUnit[CamNo].m_AlignName == "ACF_BLOB1_1" || Main.AlignUnit[CamNo].m_AlignName == "ACF_BLOB1_2" || Main.AlignUnit[CamNo].m_AlignName == "ACF_BLOB2_1" || Main.AlignUnit[CamNo].m_AlignName == "ACF_BLOB2_2"))
            {
                RBTN_PAT[0].Text = "ACF_BLOB_L";
                RBTN_PAT[1].Text = "ACF_BLOB_R";
                RBTN_PAT[2].Text = "BACK_UP_INSPECTION_L";
                RBTN_PAT[3].Text = "BACK_UP_INSPECTION_R";
            }

            if (Main.AlignUnit[CamNo].m_AlignName == "BACKUP_INSPECTION1" || Main.AlignUnit[CamNo].m_AlignName == "BACKUP_INSPECTION2")
            {
                RBTN_PAT[0].Text = "BACKUP_INSPECTION1_L";
                RBTN_PAT[1].Text = "BACKUP_INSPECTION1_R";
                RBTN_PAT[2].Text = "BACKUP_INSPECTION2_L";
                RBTN_PAT[3].Text = "BACKUP_INSPECTION2_R";
            }


            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    //                     PT_Pattern[i, j].Dispose();
                    //                     PT_Pattern[i, j] = new CogSearchMaxTool(Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern[j]);
                    PT_Pattern[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern[j];
                    PT_Pattern_USE[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern_USE[j];

                    //                     PT_GPattern[i, j].Dispose();
                    //                     PT_GPattern[i, j] = new CogPMAlignTool(Main.AlignUnit[CamNo].PAT[StageNo, i].GPattern[j]);
                    PT_GPattern[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, i].GPattern[j];
                }
            }
            #endregion

            #region BLOB Parameter 수정한거
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int j = 0; j < Main.DEFINE.BLOB_CNT_MAX; j++)
                {
                    PT_BlobTools[i, j].Dispose();
                    PT_BlobTools[i, j] = new CogBlobTool(Main.AlignUnit[CamNo].PAT[StageNo, i].BlobTools[j]);
                    PT_BlobPara[i, j].m_UseCheck = Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_UseCheck;

                    if (Main.ALIGNINSPECTION_USE(CamNo))
                    {
                        if (j < 2)
                            PT_BlobPara[i, j].m_UseCheck = true;
                        else
                            PT_BlobPara[i, j].m_UseCheck = false;
                    }

                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        PT_BlobPara[i, j].m_TargetToCenter[k] = new Main.DoublePoint();
                        PT_BlobPara[i, j].m_TargetToCenter[k].X = Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_TargetToCenter[k].X;
                        PT_BlobPara[i, j].m_TargetToCenter[k].Y = Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_TargetToCenter[k].Y;
                    }
                }
            }
            #endregion

            #region CALIPER PARAMETER
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int j = 0; j < Main.DEFINE.CALIPER_MAX; j++)
                {
                    PT_CaliperTools[i, j].Dispose();
                    PT_CaliperTools[i, j] = new CogCaliperTool(Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j]);
                    PT_CaliperTools[i, j].RunParams.EdgeMode = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].RunParams.EdgeMode;
                    PT_CaliPara[i, j].m_UseCheck = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_UseCheck;
                    // 210203 ATT
                    PT_CaliPara[i, j].m_bCOPMode = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_bCOPMode;
                    PT_CaliPara[i, j].m_nCOPROICnt = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_nCOPROICnt;
                    PT_CaliPara[i, j].m_nCOPROIOffset = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_nCOPROIOffset;

                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        PT_CaliPara[i, j].m_TargetToCenter[k] = new Main.DoublePoint();
                        PT_CaliPara[i, j].m_TargetToCenter[k].X = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_TargetToCenter[k].X;
                        PT_CaliPara[i, j].m_TargetToCenter[k].Y = Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_TargetToCenter[k].Y;
                    }

                    if (Main.AlignUnit[CamNo].m_AlignName == "CRD_PRE1" || Main.AlignUnit[CamNo].m_AlignName == "CRD_PRE2" || Main.AlignUnit[CamNo].m_AlignName == "CRD_PRE3" || Main.AlignUnit[CamNo].m_AlignName == "CRD_PRE4")
                    {
                        if (StageNo > 0) //1번 태크 부터 검사. 0번은 얼라인이여서 . 
                        {
                            PT_CaliperTools[i, j].RunParams.SingleEdgeScorers.Clear();
                            CogCaliperScorerPositionNeg nItem = new CogCaliperScorerPositionNeg();
                            PT_CaliperTools[i, j].RunParams.SingleEdgeScorers.Add(nItem);
                        }
                    }
                }
            }


            #endregion

            #region FINDLine PARAMETER
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                {
                    for (int j = 0; j < Main.DEFINE.FINDLINE_MAX; j++)
                    {
                        PT_FindLineTools[i, ii, j].Dispose();
                        PT_FindLineTools[i, ii, j] = new CogFindLineTool(Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j]);
                        PT_LineMaxTools[i, ii, j] = new CogLineMaxTool(Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j]);
                        PT_FindLinePara[i, ii, j].m_UseCheck = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_UseCheck;
                        PT_FindLinePara[i, ii, j].m_UsePairCheck = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_UsePairCheck;
                        PT_FindLinePara[i, ii, j].m_LinePosition = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_LinePosition;
                        PT_FindLinePara[i, ii, j].m_LineCaliperMethod = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_LineCaliperMethod;

                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            PT_FindLinePara[i, ii, j].m_TargetToCenter[k] = new Main.DoublePoint();
                            PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X;
                            PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y;
                            PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X2 = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X2;
                            PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y2 = Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y2;
                        }
                    }
                }
            }

            TRAY_POCKET_X = Main.AlignUnit[CamNo].m_Tray_Pocket_X;
            TRAY_POCKET_Y = Main.AlignUnit[CamNo].m_Tray_Pocket_Y;
            #endregion

            #region CIRCLE PARAMETER
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int j = 0; j < Main.DEFINE.CIRCLE_MAX; j++)
                {
                    PT_CircleTools[i, j].Dispose();
                    PT_CircleTools[i, j] = new CogFindCircleTool(Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j]);
                    PT_CirclePara[i, j].m_UseCheck = Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_UseCheck;
                    PT_CirclePara[i, j].m_CircleCaliperMethod = Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_CircleCaliperMethod;


                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        PT_CirclePara[i, j].m_TargetToCenter[k] = new Main.DoublePoint();
                        PT_CirclePara[i, j].m_TargetToCenter[k].X = Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].X;
                        PT_CirclePara[i, j].m_TargetToCenter[k].Y = Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].Y;
                    }
                }
            }
            #endregion



            //#region ATT Parameter
            //for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            //{
            //    //strParaName = "PATTERN SCORE";
            //    //CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore, PT_AcceptScore[i]);
            //    PT_AcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_ATTMarkScore;
            //    PT_AcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_ATTMarkScore;
            //    for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
            //    {
            //        //압흔검사 Mark Data
            //        PT_AkkonPara[TapNo].m_LeftPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_LeftPattern[j];
            //        PT_AkkonPara[TapNo].m_RightPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_RightPattern[j];

            //        //얼라인검사 Mark Data
            //        PT_AlignPara[TapNo].m_LeftPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_LeftPattern[j];
            //        PT_AlignPara[TapNo].m_RightPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_RightPattern[j];
            //    }
            //}
            //for (int i = 0; i < (int)Main.AlignTagData.DefaultParam.DEF_INSP_POS; i++)//Tab의 Left, Right
            //{
            //    for (int j = 0; j < (int)Main.AlignTagData.DefaultParam.DEF_TARGET_POS; j++)//FPC, Panel
            //    {
            //        PT_AlignPara[TapNo].m_AlignCaliperX[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_AlignCaliperX[i, j];
            //        PT_AlignPara[TapNo].m_AlignCaliperY[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_AlignCaliperY[i, j];
            //    }
            //}
            //PT_AlignPara[TapNo].m_nLeadCount = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.m_nLeadCount;
            //#endregion

            #region
            //NativeMethods.CallBackRegistry(cb);
            #endregion

            //   DistanceLine();
            UpdateATTParameter();
            Pattern_Change();
            RefreshAkkonRegion();
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                //LB_TOOLBLOCKEDIT_HIDE.Location = new System.Drawing.Point(905, 1);
                //LB_TOOLBLOCKEDIT_HIDE.Size = new System.Drawing.Size(610, 65);
                //LB_TOOLBLOCKEDIT_HIDE.Visible = true;
                LB_MARK_COMMENT.Text = "TEACH FOR CALIBRATION (NORMAL NOT USE)";
                LB_MARK_COMMENT.Visible = true;

                LB_CALIPER_COMMENT.Text = "TEACH FOR BEAM SIZE CHECK (NORMAL NOT USE)";
                LB_CALIPER_COMMENT.Visible = true;

                LB_FINDLINE_MARK_USE_HIDE.Location = new System.Drawing.Point(128, 128);
                LB_FINDLINE_MARK_USE_HIDE.Size = new System.Drawing.Size(123, 52);
                LB_FINDLINE_MARK_USE_HIDE.Visible = true;

                LB_FINDCIRCLE_MARK_USE_HIDE.Location = new System.Drawing.Point(128, 128);
                LB_FINDCIRCLE_MARK_USE_HIDE.Size = new System.Drawing.Size(123, 52);
                LB_FINDCIRCLE_MARK_USE_HIDE.Visible = true;

                TABC_MANU.TabPages[3].Text = "C-CUT_TEACH";
                TABC_MANU.TabPages[4].Text = "R-CUT_TEACH";

                FINDLINE_Change();
            }
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                LB_FINDLINE_MARK_USE_HIDE.Location = new System.Drawing.Point(128, 128);
                LB_FINDLINE_MARK_USE_HIDE.Size = new System.Drawing.Size(123, 52);
                LB_FINDLINE_MARK_USE_HIDE.Visible = true;

                LB_FINDCIRCLE_MARK_USE_HIDE.Location = new System.Drawing.Point(128, 128);
                LB_FINDCIRCLE_MARK_USE_HIDE.Size = new System.Drawing.Size(123, 52);
                LB_FINDCIRCLE_MARK_USE_HIDE.Visible = true;
            }

            BTN_DISNAME_01.BackColor = System.Drawing.Color.SkyBlue;
            BTN_DISNAME_01_Click(BTN_DISNAME_01, null);

            RBTN_PAT[0].Checked = true;

            DisplayFit(PT_CALIPER_SUB_Display);
            timer1.Enabled = true;
            timer3.Enabled = true;

            // 2022 1013 YSH Show Tab 
            MakeDisplay(Main.AlignUnit[CamNo].m_TabCount);

            // 200618 JHKIM 살림
            //TABC_MANU.TabPages[3].Text = "";
            //TABC_MANU.TabPages[4].Text = ""; // GVO R&D에서 사용하지 않는 TOOL은 숨김.
            //if (TABC_MANU.TabPages[3].Text == "")
            //    BTN_TOOL_03.Visible = false;
            //if (TABC_MANU.TabPages[4].Text == "")
            //    BTN_TOOL_04.Visible = false;
            //TABC_MANU.TabPages[3].Text = "FIND LINE";
            //TABC_MANU.TabPages[4].Text = "FIND CIRCLE"; // GVO R&D에서 사용하지 않는 TOOL은 숨김.
            ////if (TABC_MANU.TabPages[3].Text == "")
            //    BTN_TOOL_03.Visible = true;
            ////if (TABC_MANU.TabPages[4].Text == "")
            //    BTN_TOOL_04.Visible = true;

            DisplayFit(PT_Display01);
        }// Form_PatternTeach_Load

        private void MakeDisplay(int tabCount)
        {
            try
            {
                int controlWidth = this.panelTabSelect.Width / tabCount;
                System.Drawing.Point point = new System.Drawing.Point(0, 0);

                for (int i = 0; i < tabCount; i++)
                {
                    CtrlTabButton buttonControl = new CtrlTabButton(i);
                    buttonControl.SendEventHandler += new CtrlTabButton.SetTabNumberDelegate(ReceiveTabNumber);
                    buttonControl.Size = new System.Drawing.Size(controlWidth, this.panelTabSelect.Height);
                    buttonControl.Location = point;
                    this.panelTabSelect.Controls.Add(buttonControl);
                    point.X += controlWidth;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }

        }
        private void ReceiveTabNumber(bool selected, int tabNumber)
        {
            _buttonSeledted = selected;
            _tabNumber = tabNumber;
            TapNo = _tabNumber;
            UpdateATTParameter();
            Akkon_Change();
            Align_Change();
            RefreshAkkonRegion();
        }
        private void UpdateATTParameter()
        {
            #region ATT Parameter
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                //strParaName = "PATTERN SCORE";
                //CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore, PT_AcceptScore[i]);
                PT_AcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].ATTMarkScore;
                PT_AcceptScore[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.ATTMarkScore;
                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    //압흔검사 Mark Data
                    if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeftPattern[j] != null)
                        PT_AkkonPara[TapNo].LeftPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeftPattern[j];
                    if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].RightPattern[j] != null)
                    PT_AkkonPara[TapNo].RightPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].RightPattern[j];

                    //얼라인검사 Mark Data
                    if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.LeftPattern[j] != null)
                        PT_AlignPara[TapNo].LeftPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.LeftPattern[j];
                    if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.RightPattern[j] != null)
                        PT_AlignPara[TapNo].RightPattern[j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.RightPattern[j];
                }
            }
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)//Tab의 Left, Right
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)//FPC, Panel
                {
                    if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperX[i, j] != null)
                        PT_AlignPara[TapNo].AlignCaliperX[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperX[i, j];
                    if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperY[i, j] != null)
                        PT_AlignPara[TapNo].AlignCaliperY[i, j] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperY[i, j];
                }
            }
            PT_AlignPara[TapNo].LeadCount = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.LeadCount;
            #endregion
        }
        private void Form_PatternTeach_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
            timer3.Enabled = false;
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    PT_Pattern[i, j].Dispose();
                }
            }
            PT_BlobToolBlock.Dispose();
            PT_PMBlobTool.Dispose();
        }
        private void BTN_PAT_CHANGE_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }
        private void RBTN_PAT_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            int m_Number;
            m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 1, 1));
            if (TapNo == m_Number) return;

            nDistanceShow[TapNo] = false;
            TapNo = m_Number;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" || (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2" && m_CamNo == Main.DEFINE.CAM_SELECT_1ST_ALIGN))
            {
                RBTN_FINDLINE00.Checked = true;
                m_SelectFindLine = 0;
                m_LineSubNo = 0;
                CB_FINDLINE_SUBLINE.SelectedIndex = 0;
                TABC_MANU.SelectedIndex = M_TOOL_MODE = Main.DEFINE.M_FINDLINETOOL;
                FINDLINE_Change();
            }
            else
            {
                m_PatNo_Sub = 0;
                CB_SUB_PATTERN.SelectedIndex = 0;
                LightRadio[0].Checked = true;
                TABC_MANU.SelectedIndex = M_TOOL_MODE = Main.DEFINE.M_CNLSEARCHTOOL;
                Pattern_Change();
            }
        }
        private void LightCheck(int nM_TOOL_MODE)
        {
            if (!Main.AlignUnit[CamNo].LightUseCheck(TapNo))
            {
                int nTempPatNo = Main.DEFINE.OBJ_L;
                try
                {
                    if (TapNo == Main.DEFINE.OBJ_L && Main.AlignUnit[CamNo].LightUseCheck(Main.DEFINE.OBJ_R)) nTempPatNo = Main.DEFINE.OBJ_R;
                    if (TapNo == Main.DEFINE.OBJ_R && Main.AlignUnit[CamNo].LightUseCheck(Main.DEFINE.OBJ_L)) nTempPatNo = Main.DEFINE.OBJ_L;
                    if (TapNo == Main.DEFINE.TAR_L && Main.AlignUnit[CamNo].LightUseCheck(Main.DEFINE.TAR_R)) nTempPatNo = Main.DEFINE.TAR_R;
                    if (TapNo == Main.DEFINE.TAR_R && Main.AlignUnit[CamNo].LightUseCheck(Main.DEFINE.TAR_L)) nTempPatNo = Main.DEFINE.TAR_L;

                    Main.AlignUnit[CamNo].PAT[StageNo, nTempPatNo].SetAllLight(nM_TOOL_MODE);
                }
                catch
                {

                }
            }
        }
        private void Pattern_Change()
        {
            BTN_BackColor();
            m_CamNo = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo;
            LB_CAMCENTER.Text = "CenterX:" + Main.vision.IMAGE_CENTER_X[m_CamNo].ToString() + " ,";
            LB_CAMCENTER.Text += "CenterY:" + Main.vision.IMAGE_CENTER_Y[m_CamNo].ToString();
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            LABEL_MESSAGE(LB_MESSAGE1, "", System.Drawing.Color.Lime);
            Light_Select();
            LightCheck(M_TOOL_MODE);
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetAllLight(M_TOOL_MODE);
            PT_Display01.Image = Main.vision.CogCamBuf[m_CamNo];
            PT_DISPLAY_CONTROL.Resuloution = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CalX[0];
            // CUSTOM CROSS
            PT_DISPLAY_CONTROL.UseCustomCross = Main.vision.USE_CUSTOM_CROSS[m_CamNo];
            PT_DISPLAY_CONTROL.CustomCross = new PointF(Main.vision.CUSTOM_CROSS_X[m_CamNo], Main.vision.CUSTOM_CROSS_Y[m_CamNo]);
            DisplayClear();
            Main.DisplayRefresh(PT_Display01);
            //     if (BTN_DISNAME_01.BackColor.Name != "SkyBlue") CrossLine();
            if (PT_DISPLAY_CONTROL.CrossLineChecked) CrossLine();
            //--------------------CNLSEARCH-------------------------------------------
            #region CNLSEARCH
            m_RetiMode = 0;
            PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

            if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion.GetType().Name != "CogRectangle")
            {
                PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle();
            }

            PatMaxTrainRegion = new CogRectangle(PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);
            MarkORGPoint.X = PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationX;
            MarkORGPoint.Y = PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationY;

            if (PT_Pattern[TapNo, m_PatNo_Sub].SearchRegion == null)
            {
                PatMaxSearchRegion = new CogRectangle();
                PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
            }
            else
            {
                PatMaxSearchRegion = new CogRectangle(PT_Pattern[TapNo, m_PatNo_Sub].SearchRegion as CogRectangle);
            }

            for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
            {
                SUBPATTERN_LABELDISPLAY(PT_Pattern_USE[TapNo, i], i);
                DrawTrainedPattern(PT_SubDisplay[i], PT_Pattern[TapNo, i]);
            }

            if (m_PatNo_Sub == 0)
            {
                CB_SUBPAT_USE.Visible = false;
            }
            else
            {
                CB_SUBPAT_USE.Visible = true;
                CB_SUBPAT_USE.Checked = PT_Pattern_USE[TapNo, m_PatNo_Sub];
            }

            NUD_PAT_SCORE.Value = (decimal)PT_AcceptScore[TapNo];
            NUD_PAT_GSCORE.Value = (decimal)PT_GAcceptScore[TapNo];

            if (Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY1" || Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY2")
            {
                NUD_Initial_Flag = true;
                NUD_GUIDEDISX.Value = (decimal)PT_TRAY_GUIDE_DISX[TapNo];
                NUD_GUIDEDISY.Value = (decimal)PT_TRAY_GUIDE_DISY[TapNo];

                NUD_PITCHDISX.Value = (decimal)PT_TRAY_PITCH_DISX[TapNo];
                NUD_PITCHDISY.Value = (decimal)PT_TRAY_PITCH_DISY[TapNo];

                NUD_POCKETCOUNT_X_00.Value = TRAY_POCKET_X;
                NUD_POCKETCOUNT_Y_01.Value = TRAY_POCKET_Y;
                NUD_Initial_Flag = false;
            }

            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_PMAlign_Use == false)
            {
                label13.Visible = false;
                NUD_PAT_GSCORE.Visible = false;
            }
            #endregion
            //-----------------------------------------------------------------------
        }

        #region DRAW & REFRESH IMAGE
        private void Draw_Label(CogRecordDisplay nDisplay, string resultText, int index)
        {
            int i;
            CogGraphicLabel Label = new CogGraphicLabel();
            i = index;
            float nFontSize = 0;

            //            double nManuFont = 0;            
            //            if (Main.Status.MC_MODE == Main.DEFINE.MC_TEACHFORM) nManuFont = 0.5;

            double baseZoom = 0;
            if ((double)nDisplay.Width / nDisplay.Image.Width < (double)nDisplay.Height / nDisplay.Image.Height)
            {
                baseZoom = ((double)nDisplay.Width - 22) / nDisplay.Image.Width;
                nFontSize = (float)((nDisplay.Image.Width / Main.DEFINE.FontSize) * baseZoom);
            }
            else
            {
                baseZoom = ((double)nDisplay.Height - 22) / nDisplay.Image.Height;
                nFontSize = (float)((nDisplay.Image.Height / Main.DEFINE.FontSize) * baseZoom);
            }


            double nFontpitch = (nFontSize / nDisplay.Zoom);
            Label.Text = resultText;
            Label.Color = CogColorConstants.Cyan;
            Label.Font = new Font(Main.DEFINE.FontStyle, nFontSize);
            Label.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            Label.X = (nDisplay.Image.Width - (nDisplay.Image.Width / (nDisplay.Zoom / baseZoom))) / 2 - nDisplay.PanX;
            Label.Y = (nDisplay.Image.Height - (nDisplay.Image.Height / (nDisplay.Zoom / baseZoom))) / 2 - nDisplay.PanY + (i * nFontpitch);


            nDisplay.StaticGraphics.Add(Label as ICogGraphic, "Result Text");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshTeach();
        }
        delegate void dGrabRefresh(CogRecordDisplay nDisplay, ICogImage nImageBuf);
        public static void GrabDisRefresh_(CogRecordDisplay nDisplay, ICogImage nImageBuf)
        {
            if (nDisplay.InvokeRequired)
            {
                dGrabRefresh call = new dGrabRefresh(GrabDisRefresh_);
                nDisplay.Invoke(call, nDisplay, nImageBuf);
            }
            else
            {
                nDisplay.Image = nImageBuf;
            }
        }
        private void CrossLine()
        {
            PT_DISPLAY_CONTROL.CrossLine();
            //             CogLine mCogLine1 = new CogLine();
            //             CogLine mCogLine2 = new CogLine();
            //             mCogLine1.Color = CogColorConstants.Magenta;
            //             mCogLine2.Color = CogColorConstants.Magenta;
            //             mCogLine1.SetFromStartXYEndXY(0, (double)Main.vision.IMAGE_CENTER_Y[m_CamNo], (double)Main.vision.IMAGE_SIZE_X[m_CamNo], (double)Main.vision.IMAGE_CENTER_Y[m_CamNo]);
            //             PT_Display01.StaticGraphics.Add(mCogLine1 as ICogGraphic, "Find MarkerPos");
            // 
            //             mCogLine2.SetFromStartXYEndXY((double)Main.vision.IMAGE_CENTER_X[m_CamNo], 0, (double)Main.vision.IMAGE_CENTER_X[m_CamNo], (double)Main.vision.IMAGE_SIZE_Y[m_CamNo]);
            //             PT_Display01.StaticGraphics.Add(mCogLine2 as ICogGraphic, "Find MarkerPos");
        }
        private void RefreshTeach()
        {
            Main.vision.Grab_Flag_Start[m_CamNo] = true;
            GrabDisRefresh_(PT_Display01, Main.vision.CogCamBuf[m_CamNo]);
        }
        #endregion

        #region 조명조절관련
        private void BTN_LIGHT_UP_Click(object sender, EventArgs e)
        {
            if (TBAR_LIGHT.Maximum == TBAR_LIGHT.Value) return;
            TBAR_LIGHT.Value++;
        }
        private void BTN_LIGHT_DOWN_Click(object sender, EventArgs e)
        {
            if (TBAR_LIGHT.Minimum == TBAR_LIGHT.Value) return;
            TBAR_LIGHT.Value--;
        }
        private void RBTN_LIGHT_0_CheckedChanged(object sender, EventArgs e)
        {
            Light_Select();
        }
        private void TBAR_LIGHT_ValueChanged(object sender, EventArgs e)
        {
            Light_Change(m_SelectLight);
        }
        private void Light_Select()
        {
            bool nLightUse = false;
            for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
            {
                Light_Text[i].Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightValue[i, M_TOOL_MODE].ToString();
                LightRadio[i].Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_Light_Name[i];
                if (LightRadio[i].Checked)
                {
                    m_SelectLight = i;
                    LightRadio[i].BackColor = System.Drawing.Color.LawnGreen;
                }
                else
                {
                    LightRadio[i].BackColor = System.Drawing.Color.DarkGray;
                }

                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightCtrl[i] < 0)
                {
                    Light_Text[i].Visible = false;
                    LightRadio[i].Visible = false;
                }
                else
                {
                    Light_Text[i].Visible = true;
                    LightRadio[i].Visible = true;
                    TBAR_LIGHT.Visible = true;
                    BTN_LIGHT_UP.Visible = true;
                    BTN_LIGHT_DOWN.Visible = true;
                    nLightUse = true;
                }
            }
            if (!nLightUse)
            {
                TBAR_LIGHT.Visible = false;
                BTN_LIGHT_UP.Visible = false;
                BTN_LIGHT_DOWN.Visible = false;
            }
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightCtrl[m_SelectLight] >= 0)
                TBAR_LIGHT.Value = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightValue[m_SelectLight, M_TOOL_MODE];
        }
        private void Light_Change(int m_LightNum)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetLight(m_LightNum, TBAR_LIGHT.Value);
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightValue[m_LightNum, M_TOOL_MODE] = TBAR_LIGHT.Value;
            Light_Text[m_LightNum].Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_LightValue[m_LightNum, M_TOOL_MODE].ToString();
            //             if (M_TOOL_MODE == M_BLOBTOOL || M_TOOL_MODE == M_CALIPERTOOL || M_TOOL_MODE == M_FINDLINETOOL) 
            //                 RefreshDisplay2();
        }
        private void LB_LIGHT_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label TempLB = (Label)sender;
                int nNum;
                nNum = Convert.ToInt16(TempLB.Name.Substring(TempLB.Name.Length - 1, 1));
                Form_LightSet formLight = new Form_LightSet(CamNo, StageNo, TapNo, nNum);
                formLight.ShowDialog();
                formLight.Dispose();
                Light_Select();
            }
        }
        #endregion

        #region 버튼클릭이벤트들

        private void BTN_IMAGE_OPEN_Click(object sender, EventArgs e)
        {
            //             openFileDialog1.CheckFileExists = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (Main.vision.CogImgTool[m_CamNo] == null)
                    Main.vision.CogImgTool[m_CamNo] = new CogImageFileTool();
                Main.GetImageFile(Main.vision.CogImgTool[m_CamNo], openFileDialog1.FileName);
                Main.vision.CogCamBuf[m_CamNo] = Main.vision.CogImgTool[m_CamNo].OutputImage;

                if (Main.DEFINE.PROGRAM_TYPE.Substring(0, 3) == "ATT")
                {
                    try
                    {

                        Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanBuf = new Mat(openFileDialog1.FileName, ImreadModes.Grayscale);

                        if (Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanBuf.Depth() != (int)ImreadModes.Grayscale)
                            OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanBuf, Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                        Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanOriginalBuf = new Mat(openFileDialog1.FileName, ImreadModes.Grayscale);

                        if (Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanOriginalBuf.Depth() != (int)ImreadModes.Grayscale)
                            OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanOriginalBuf, Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanOriginalBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                        CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[m_CamNo].OutputImage as CogImage8Grey);
                        ICogImage8PixelMemory OriginImage8PixelMemory = CogConvertImage.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0,
                            Main.vision.CogImgTool[m_CamNo].OutputImage.Width, Main.vision.CogImgTool[m_CamNo].OutputImage.Height);
                        if (Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgDataATT == null
                            || Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols != Main.vision.CogImgTool[m_CamNo].OutputImage.Width
                            || Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows != Main.vision.CogImgTool[m_CamNo].OutputImage.Height)
                        {
                            Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgDataATT = new byte[Main.vision.CogImgTool[m_CamNo].OutputImage.Width * Main.vision.CogImgTool[m_CamNo].OutputImage.Height];
                            Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols = Main.vision.CogImgTool[m_CamNo].OutputImage.Width;
                            Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows = Main.vision.CogImgTool[m_CamNo].OutputImage.Height;
                            Main.AlignUnit[CamNo].PAT[0, TapNo].m_OrginalImgCols = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols;
                            Main.AlignUnit[CamNo].PAT[0, TapNo].m_OrginalImgRows = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows;
                        }
                        Marshal.Copy(OriginImage8PixelMemory.Scan0, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgDataATT, 0,
                            Main.vision.CogImgTool[m_CamNo].OutputImage.Width * Main.vision.CogImgTool[m_CamNo].OutputImage.Height);
                        OriginImage8PixelMemory.Dispose();


                        // ATT Initialize
                        if (Main.DEFINE.OPEN_F)
                        {
                            //Main.vision.IMAGE_SIZE_X[0] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                            //Main.vision.IMAGE_SIZE_Y[0] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows;
                            //Main.vision.IMAGE_SIZE_X[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                            //Main.vision.IMAGE_SIZE_Y[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows;
                        }

                        //Main.ATT_CreateDLLBuffer();
                        //Main.ATT_CreateImageBuffer();
                        //Main.ATT_CreateImageBuffer(CamNo, TapNo, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows);

                        cog_Display_Thumbnail.Image = Main.vision.CogCamBuf[m_CamNo];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            PT_Display01.Image = Main.vision.CogCamBuf[m_CamNo];
            DisplayClear();
            if (timer1.Enabled == true)
                timer1.Enabled = false;
            Main.DisplayRefresh(PT_Display01);
        }
        private void BTN_TOOL_SET_Click(object sender, EventArgs e)
        {
            Button TempBTN = (Button)sender;
            try
            {
                switch (TempBTN.Text)
                {
                    case "SEARCHMAX": //CogCNLSearch
                        PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        ToolTeach.TT_SearchMaxTool = PT_Pattern[TapNo, m_PatNo_Sub];
                        ToolTeach.m_ToolTextName = "CogSearchMaxTool";
                        break;

                    case "PMALIGN":
                        PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        ToolTeach.TT_PMAlign = PT_GPattern[TapNo, m_PatNo_Sub];
                        ToolTeach.m_ToolTextName = "CogPMAlignTool";
                        break;

                    case "BLOB":
                        RefreshDisplay2();
                        ToolTeach.TT_BlobTool = PT_BlobTools[TapNo, m_SelectBlob];
                        ToolTeach.m_ToolTextName = "CogBlobTool";
                        break;

                    case "CALIPER":
                        RefreshDisplay2();
                        ToolTeach.TT_CALTool = PT_CaliperTools[TapNo, m_SelectCaliper];
                        ToolTeach.m_ToolTextName = "CogCaliperTool";
                        break;

                    case "LINE":
                        RefreshDisplay2();
                        ToolTeach.TT_FindLine = PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine];
                        ToolTeach.m_ToolTextName = "CogFindLineTool";
                        break;

                    case "CIRCLE":
                        RefreshDisplay2();
                        ToolTeach.TT_FindCircle = PT_CircleTools[TapNo, m_SelectCircle];
                        ToolTeach.m_ToolTextName = "CogFindCircleTool";
                        break;
                }
                ToolTeach.m_AlignNo = CamNo;
                ToolTeach.m_PatTagNo = TapNo;
                ToolTeach.ShowDialog();
                if (TempBTN.Text == "SEARCHMAX" || TempBTN.Text == "PMALIGN") { CB_SUB_PATTERN_SelectionChangeCommitted(null, null); }
                if (TempBTN.Text == "CALIPER") { Caliper_Change(); }
                if (TempBTN.Text == "BLOB") { Blob_Change(); }
                if (TempBTN.Text == "FINDLINE") { FINDLINE_Change(); }
                if (TempBTN.Text == "CIRCLE") { Circle_Change(); }
            }
            catch
            {

            }
        }
        private void BTN_DISNAME_01_Click(object sender, EventArgs e)
        {
            Button TempBTN = (Button)sender;
            int m_Number;
            m_Number = TempBTN.TabIndex;

            if (TempBTN.BackColor.Name == "SkyBlue")
            {
                TempBTN.BackColor = Color.Plum;
                CrossLine();
            }
            else
            {
                TempBTN.BackColor = Color.SkyBlue;
                DisplayClear();
                nDistanceShow[TapNo] = false;
                LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Red);
            }
        }
        bool nPatternCopy = false;
        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            formMessage.LB_MESSAGE.Text = "Did You Check [APPLY]?";
            if (!formMessage.Visible)
            {
                formMessage.ShowDialog();
            }

            Form_Password formpassword = new Form_Password(false);
            formpassword.ShowDialog();

            if (!formpassword.LOGINOK)
            {
                nPatternCopy = false;
                formpassword.Dispose();
                return;
            }
            formpassword.Dispose();

            string strParaName = "";
            #region CNLSEARCH SAVE
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                strParaName = "PATTERN SCORE";
                CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore, PT_AcceptScore[i]);
                Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore = PT_AcceptScore[i];
                strParaName = "GPATTERN SCORE";
                CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].m_GACCeptScore, PT_GAcceptScore[i]);
                Main.AlignUnit[CamNo].PAT[StageNo, i].m_GACCeptScore = PT_GAcceptScore[i];

                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern[j] = new CogSearchMaxTool(PT_Pattern[i, j]);

                    Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern_USE[j] = PT_Pattern_USE[i, j];
                    if (j == 0) Main.AlignUnit[CamNo].PAT[StageNo, i].Pattern_USE[j] = true;

                    Main.AlignUnit[CamNo].PAT[StageNo, i].GPattern[j] = new CogPMAlignTool(PT_GPattern[i, j]);
                }
            }
            #endregion

            #region BLOB SAVE 수정한거
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                Main.AlignUnit[CamNo].PAT[StageNo, i].Blob_MarkUse = PT_Blob_MarkUSE[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].Blob_CaliperUse = PT_Blob_CaliperUSE[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].m_Blob_InspCnt = PT_Blob_InspCnt[i];
                for (int j = 0; j < Main.DEFINE.BLOB_CNT_MAX; j++)
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, i].BlobTools[j] = new CogBlobTool(PT_BlobTools[i, j]);
                    Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_UseCheck = PT_BlobPara[i, j].m_UseCheck;
                    Main.AlignUnit[CamNo].PAT[StageNo, i].m_Blob_InspCnt = PT_Blob_InspCnt[i];
                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_TargetToCenter[k].X = PT_BlobPara[i, j].m_TargetToCenter[k].X;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].BlobPara[j].m_TargetToCenter[k].Y = PT_BlobPara[i, j].m_TargetToCenter[k].Y;
                    }
                }
            }
            #endregion

            #region CALIPER SAVE
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                Main.AlignUnit[CamNo].PAT[StageNo, i].Caliper_MarkUse = PT_Caliper_MarkUSE[i];
                for (int j = 0; j < Main.DEFINE.CALIPER_MAX; j++)
                {
                    {
                        strParaName = PT_CaliperName[j] + " CALIPER USE";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_UseCheck, PT_CaliPara[i, j].m_UseCheck);
                        strParaName = PT_CaliperName[j] + " THRESHOLD";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].RunParams.ContrastThreshold, PT_CaliperTools[i, j].RunParams.ContrastThreshold);
                        strParaName = PT_CaliperName[j] + " DIRECTION";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].Region.Rotation, PT_CaliperTools[i, j].Region.Rotation);
                        strParaName = PT_CaliperName[j] + " POLARITY";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].RunParams.Edge0Polarity.ToString(), PT_CaliperTools[i, j].RunParams.Edge0Polarity.ToString());
                        strParaName = PT_CaliperName[j] + " PAIR USE";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j].RunParams.EdgeMode.ToString(), PT_CaliperTools[i, j].RunParams.EdgeMode.ToString());
                    }
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperTools[j] = new CogCaliperTool(PT_CaliperTools[i, j]);
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_UseCheck = PT_CaliPara[i, j].m_UseCheck;

                    Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_bCOPMode = PT_CaliPara[i, j].m_bCOPMode;
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_nCOPROICnt = PT_CaliPara[i, j].m_nCOPROICnt;
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_nCOPROIOffset = PT_CaliPara[i, j].m_nCOPROIOffset;

                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_TargetToCenter[k].X = PT_CaliPara[i, j].m_TargetToCenter[k].X;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CaliperPara[j].m_TargetToCenter[k].Y = PT_CaliPara[i, j].m_TargetToCenter[k].Y;
                    }
                }
            }
            #endregion

            #region FINDLine SAVE
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLine_MarkUse = PT_FindLine_MarkUSE[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_GUIDE_DISX = PT_TRAY_GUIDE_DISX[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_GUIDE_DISY = PT_TRAY_GUIDE_DISY[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_PITCH_DISX = PT_TRAY_PITCH_DISX[i];
                Main.AlignUnit[CamNo].PAT[StageNo, i].TRAY_PITCH_DISY = PT_TRAY_PITCH_DISY[i];

                for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                {
                    for (int j = 0; j < Main.DEFINE.FINDLINE_MAX; j++)
                    {
                        {
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " USE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_UseCheck, PT_FindLinePara[i, ii, j].m_UseCheck);
                        }

                        if (!Main.AlignUnit[CamNo].PAT[StageNo, i].m_UseLineMax)
                        {
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " THRESHOLD";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperRunParams.ContrastThreshold, PT_FindLineTools[i, ii, j].RunParams.CaliperRunParams.ContrastThreshold);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " DIRECTION";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperSearchDirection, PT_FindLineTools[i, ii, j].RunParams.CaliperSearchDirection);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " POLARITY";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperRunParams.Edge0Polarity.ToString(), PT_FindLineTools[i, ii, j].RunParams.CaliperRunParams.Edge0Polarity.ToString());
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " CALIPER COUNT";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.NumCalipers, PT_FindLineTools[i, ii, j].RunParams.NumCalipers);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " IGNORE COUNT";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.NumToIgnore, PT_FindLineTools[i, ii, j].RunParams.NumToIgnore);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " FILTER SIZE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperRunParams.FilterHalfSizeInPixels, PT_FindLineTools[i, ii, j].RunParams.CaliperRunParams.FilterHalfSizeInPixels);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " SEARCH LENGTH";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperSearchLength, PT_FindLineTools[i, ii, j].RunParams.CaliperSearchLength);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " PROJECTION LENGTH";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.CaliperProjectionLength, PT_FindLineTools[i, ii, j].RunParams.CaliperProjectionLength);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " LINE STARTX";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.ExpectedLineSegment.StartX, PT_FindLineTools[i, ii, j].RunParams.ExpectedLineSegment.StartX);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " LINE STARTY";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.ExpectedLineSegment.StartY, PT_FindLineTools[i, ii, j].RunParams.ExpectedLineSegment.StartY);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " LINE ENDX";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.ExpectedLineSegment.EndX, PT_FindLineTools[i, ii, j].RunParams.ExpectedLineSegment.EndX);
                            strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " LINE ENDY";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j].RunParams.ExpectedLineSegment.EndY, PT_FindLineTools[i, ii, j].RunParams.ExpectedLineSegment.EndY);
                        }
                        else
                        {
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " THRESHOLD";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.EdgeDetectionParams.ContrastThreshold, PT_LineMaxTools[i, ii, j].RunParams.EdgeDetectionParams.ContrastThreshold);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " DIRECTION";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.ExpectedLineNormal.Angle, PT_LineMaxTools[i, ii, j].RunParams.ExpectedLineNormal.Angle);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " POLARITY";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.Polarity.ToString(), PT_LineMaxTools[i, ii, j].RunParams.Polarity.ToString());
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " GRAD KERNEL SIZE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels, PT_LineMaxTools[i, ii, j].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " PROJECTION LENGTH";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.EdgeDetectionParams.ProjectionLengthInPixels, PT_LineMaxTools[i, ii, j].RunParams.EdgeDetectionParams.ProjectionLengthInPixels);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " ANGLE TOLERANCE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.EdgeAngleTolerance, PT_LineMaxTools[i, ii, j].RunParams.EdgeAngleTolerance);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " DIST TOLERANCE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.DistanceTolerance, PT_LineMaxTools[i, ii, j].RunParams.DistanceTolerance);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " LINE ANGLE TOLERANCE";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.LineAngleTolerance, PT_LineMaxTools[i, ii, j].RunParams.LineAngleTolerance);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " COVERAGE THRESHOLD";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.CoverageThreshold, PT_LineMaxTools[i, ii, j].RunParams.CoverageThreshold);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " LENGTH THRESHOLD";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].RunParams.LengthThreshold, PT_LineMaxTools[i, ii, j].RunParams.LengthThreshold);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " REGION CENTER X";
                            CheckChangedParams(CamNo, i, strParaName, (Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].Region as CogRectangleAffine).CenterX, (PT_LineMaxTools[i, ii, j].Region as CogRectangleAffine).CenterX);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " REGION CENTER Y";
                            CheckChangedParams(CamNo, i, strParaName, (Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].Region as CogRectangleAffine).CenterY, (PT_LineMaxTools[i, ii, j].Region as CogRectangleAffine).CenterY);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " REGION X LENGTH";
                            CheckChangedParams(CamNo, i, strParaName, (Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].Region as CogRectangleAffine).SideXLength, (PT_LineMaxTools[i, ii, j].Region as CogRectangleAffine).SideXLength);
                            strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " REGION Y LENGTH";
                            CheckChangedParams(CamNo, i, strParaName, (Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j].Region as CogRectangleAffine).SideYLength, (PT_LineMaxTools[i, ii, j].Region as CogRectangleAffine).SideYLength);
                        }
                        Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLineTools[ii, j] = new CogFindLineTool(PT_FindLineTools[i, ii, j]);
                        Main.AlignUnit[CamNo].PAT[StageNo, i].LineMaxTools[ii, j] = new CogLineMaxTool(PT_LineMaxTools[i, ii, j]);

                        Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_UseCheck = PT_FindLinePara[i, ii, j].m_UseCheck;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_UsePairCheck = PT_FindLinePara[i, ii, j].m_UsePairCheck;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_LinePosition = PT_FindLinePara[i, ii, j].m_LinePosition;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_LineCaliperMethod = PT_FindLinePara[i, ii, j].m_LineCaliperMethod;
                        for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                        {
                            if (j == 2 && k == Main.DEFINE.M_FINDLINETOOL)
                            {
                                if (!Main.AlignUnit[CamNo].PAT[StageNo, i].m_UseLineMax)
                                {
                                    strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " CENTER OFFSET X1";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X);
                                    strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " CENTER OFFSET Y1";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y);
                                    strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " CENTER OFFSET X2";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X2, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X2);
                                    strParaName = PT_FINDLineName[j] + " FINDLINE #" + ii.ToString() + " CENTER OFFSET Y2";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y2, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y2);
                                }
                                else
                                {
                                    strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " CENTER OFFSET X";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X);
                                    strParaName = PT_FINDLineName[j] + " LINEMAX #" + ii.ToString() + " CENTER OFFSET Y";
                                    CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y, PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y);
                                }
                            }

                            Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X = PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X;
                            Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y = PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y;

                            Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].X2 = PT_FindLinePara[i, ii, j].m_TargetToCenter[k].X2;
                            Main.AlignUnit[CamNo].PAT[StageNo, i].FINDLinePara[ii, j].m_TargetToCenter[k].Y2 = PT_FindLinePara[i, ii, j].m_TargetToCenter[k].Y2;
                        }
                    }
                }
            }
            #endregion

            #region CIRCLE SAVE
            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                Main.AlignUnit[CamNo].PAT[StageNo, i].Circle_MarkUse = PT_Circle_MarkUSE[i];
                for (int j = 0; j < Main.DEFINE.CIRCLE_MAX; j++)
                {
                    {
                        strParaName = "CIRCLE #" + j + " USE";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_UseCheck, PT_CirclePara[i, j].m_UseCheck);
                        strParaName = "CIRCLE #" + j + " THRESHOLD";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.CaliperRunParams.ContrastThreshold, PT_CircleTools[i, j].RunParams.CaliperRunParams.ContrastThreshold);
                        strParaName = "CIRCLE #" + j + " DIRECTION";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.CaliperSearchDirection.ToString(), PT_CircleTools[i, j].RunParams.CaliperSearchDirection.ToString());
                        strParaName = "CIRCLE #" + j + " POLARITY";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.CaliperRunParams.Edge0Polarity.ToString(), PT_CircleTools[i, j].RunParams.CaliperRunParams.Edge0Polarity.ToString());
                        strParaName = "CIRCLE #" + j + " CALIPER COUNT";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.NumCalipers, PT_CircleTools[i, j].RunParams.NumCalipers);
                        strParaName = "CIRCLE #" + j + " IGNORE COUNT";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.NumToIgnore, PT_CircleTools[i, j].RunParams.NumToIgnore);
                        strParaName = "CIRCLE #" + j + " SEARCH LENGTH";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.CaliperSearchLength, PT_CircleTools[i, j].RunParams.CaliperSearchLength);
                        strParaName = "CIRCLE #" + j + " PROJECTION LENGTH";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.CaliperProjectionLength, PT_CircleTools[i, j].RunParams.CaliperProjectionLength);
                        strParaName = "CIRCLE #" + j + " CIRCLE RADIUS";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.ExpectedCircularArc.Radius, PT_CircleTools[i, j].RunParams.ExpectedCircularArc.Radius);
                        strParaName = "CIRCLE #" + j + " CIRCLE MIDX";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.ExpectedCircularArc.MidpointX, PT_CircleTools[i, j].RunParams.ExpectedCircularArc.MidpointX);
                        strParaName = "CIRCLE #" + j + " CIRCLE MIDY";
                        CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j].RunParams.ExpectedCircularArc.MidpointY, PT_CircleTools[i, j].RunParams.ExpectedCircularArc.MidpointY);
                    }
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CircleTools[j] = new CogFindCircleTool(PT_CircleTools[i, j]);
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_UseCheck = PT_CirclePara[i, j].m_UseCheck;
                    Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_CircleCaliperMethod = PT_CirclePara[i, j].m_CircleCaliperMethod;

                    for (int k = 0; k < Main.DEFINE.M_TOOLMAXCOUNT; k++)
                    {
                        if (k == Main.DEFINE.M_FINDLINETOOL)
                        {
                            strParaName = "CIRCLE #" + j + " CENTER OFFSET X";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].X, PT_CirclePara[i, j].m_TargetToCenter[k].X);
                            strParaName = "CIRCLE #" + j + " CENTER OFFSET Y";
                            CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].Y, PT_CirclePara[i, j].m_TargetToCenter[k].Y);
                        }
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].X = PT_CirclePara[i, j].m_TargetToCenter[k].X;
                        Main.AlignUnit[CamNo].PAT[StageNo, i].CirclePara[j].m_TargetToCenter[k].Y = PT_CirclePara[i, j].m_TargetToCenter[k].Y;
                    }
                }
            }

            #endregion




            Main.AlignUnit[CamNo].m_Tray_Pocket_X = TRAY_POCKET_X;
            Main.AlignUnit[CamNo].m_Tray_Pocket_Y = TRAY_POCKET_Y;
            Main.AlignUnit[CamNo].TrayBlobMode = CB_TRAY_BlobMode.Checked;

            // CUSTOM CROSS
            Main.vision.USE_CUSTOM_CROSS[m_CamNo] = PT_DISPLAY_CONTROL.UseCustomCross;
            Main.vision.CUSTOM_CROSS_X[m_CamNo] = (int)PT_DISPLAY_CONTROL.CustomCross.X;
            Main.vision.CUSTOM_CROSS_Y[m_CamNo] = (int)PT_DISPLAY_CONTROL.CustomCross.Y;

            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_DISPLAY_CONTROL.CustomCross.X, PT_DISPLAY_CONTROL.CustomCross.Y,
                                           ref Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_dCustomCrossX, ref Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_dCustomCrossY);


            //// YSH ROI Data 있는 상태에서 해야함. ROI Data R/W 추가 이후 작업 예정
            //// StageNo, TapNo 명칭 재확인 필요..
            //if (!Main.AlignUnit[CamNo].PAT[0, TapNo].m_MatLineScanBuf.Empty())
            //{
            //    Main.ATT_CalcSliceOverlap(StageNo, TapNo);
            //}

            #region 압흔 및 얼라인 검사 

            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonBumpROIList = PT_AkkonPara[TapNo].AkkonBumpROIList;
            Main.AlignUnit[CamNo].PAT[StageNo, 0].LeadGroupInfo = LeadGroupInfo;


            for (int i = 0; i < Main.AlignUnit[CamNo].m_AlignPatMax[StageNo]; i++)
            {
                //strParaName = "PATTERN SCORE";
                //CheckChangedParams(CamNo, i, strParaName, Main.AlignUnit[CamNo].PAT[StageNo, i].m_ACCeptScore, PT_AcceptScore[i]);
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].ATTMarkScore = PT_AcceptScore[i];
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.ATTMarkScore = PT_AcceptScore[i];
                for (int j = 0; j < Main.DEFINE.SUBPATTERNMAX; j++)
                {
                    //압흔검사 Mark Data
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeftPattern[j] = PT_AkkonPara[TapNo].LeftPattern[j];
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].RightPattern[j] = PT_AkkonPara[TapNo].RightPattern[j];

                    //얼라인검사 Mark Data
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.LeftPattern[j] = PT_AlignPara[TapNo].LeftPattern[j];
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.RightPattern[j] = PT_AlignPara[TapNo].RightPattern[j];
                }
            }
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_INSP_POS; i++)//Tab의 Left, Right
            {
                for (int j = 0; j < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; j++)//FPC, Panel
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperX[i, j] = PT_AlignPara[TapNo].AlignCaliperX[i, j];
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.AlignCaliperY[i, j] = PT_AlignPara[TapNo].AlignCaliperY[i, j];
                }
            }
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AlignPara.LeadCount = PT_AlignPara[TapNo].LeadCount;

            #endregion

            Main.AlignUnit[CamNo].Save(StageNo);
            Main.AlignUnit[CamNo].Save_ATT(StageNo, TapNo);//2022 1014 YSH Tab별 Save
            Main.AlignUnit[CamNo].Load(StageNo);
            Main.AlignUnit[CamNo].Load_ATT(StageNo, TapNo);//2022 1014 YSH Tab별 Load
            #region Stage Pattern COPY
            if (Main.AlignUnit[CamNo].m_AlignName == "PBD")
            {
                if (Main.DEFINE.PROGRAM_TYPE == "OLB_PC2" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC4")
                {
                    string OrgName = "PBD", TarName = "PBD_STAGE";
                    for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                    {
                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_L].Pattern[i] = new CogSearchMaxTool(Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_L].Pattern[i]);
                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_R].Pattern[i] = new CogSearchMaxTool(Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_R].Pattern[i]);

                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_L].GPattern[i] = new CogPMAlignTool(Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_L].GPattern[i]);
                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_R].GPattern[i] = new CogPMAlignTool(Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_R].GPattern[i]);

                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_L].Pattern_USE[i] = Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_L].Pattern_USE[i];
                        Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_R].Pattern_USE[i] = Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_R].Pattern_USE[i];


                    }

                    for (int i = 0; i < Main.DEFINE.Light_PatMaxCount; i++)
                    {
                        for (int j = 0; j < Main.DEFINE.Light_ToolMaxCount; j++)
                        {
                            Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_L].m_LightValue[i, j] = Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_L].m_LightValue[i, j];
                            Main.AlignUnit[TarName].PAT[StageNo, Main.DEFINE.OBJ_R].m_LightValue[i, j] = Main.AlignUnit[OrgName].PAT[StageNo, Main.DEFINE.TAR_R].m_LightValue[i, j];
                        }
                    }
                    Main.AlignUnit[TarName].Save(StageNo);
                }
            }
            #endregion

            #region Pattern Tag COPY
            if (nPatternCopy)
            {
                string TempName = Main.AlignUnit[CamNo].m_AlignName;

                if (TempName == "PBD" || TempName == "PBD_STAGE" || TempName == "PBD_FOF" || TempName == "FPC_ALIGN")
                {
                    for (int i = 0; i < Main.AlignUnit[TempName].m_AlignPatTagMax; i++)
                    {
                        for (int j = 0; j < Main.AlignUnit[TempName].m_AlignPatMax[i]; j++)
                        {
                            Main.AlignUnit[TempName].PAT[i, j].m_ACCeptScore = Main.AlignUnit[TempName].PAT[StageNo, j].m_ACCeptScore;
                            Main.AlignUnit[TempName].PAT[i, j].m_GACCeptScore = Main.AlignUnit[TempName].PAT[StageNo, j].m_GACCeptScore;

                            for (int k = 0; k < Main.DEFINE.SUBPATTERNMAX; k++)
                            {
                                Main.AlignUnit[TempName].PAT[i, j].Pattern_USE[k] = Main.AlignUnit[TempName].PAT[StageNo, j].Pattern_USE[k];
                                Main.AlignUnit[TempName].PAT[i, j].Pattern[k] = new CogSearchMaxTool(Main.AlignUnit[TempName].PAT[StageNo, j].Pattern[k]);
                                Main.AlignUnit[TempName].PAT[i, j].GPattern[k] = new CogPMAlignTool(Main.AlignUnit[TempName].PAT[StageNo, j].GPattern[k]);
                            }
                            for (int k = 0; k < Main.DEFINE.PATTERNTAG_MAX; k++)
                            {
                                for (int ii = 0; ii < Main.DEFINE.Light_PatMaxCount; ii++)
                                {
                                    for (int a = 0; a < Main.DEFINE.Light_ToolMaxCount; a++)
                                    {
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_L].m_Light_Name = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_L].m_Light_Name;
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_R].m_Light_Name = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_R].m_Light_Name;
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_L].m_LightCtrl = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_L].m_LightCtrl;
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_R].m_LightCtrl = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_R].m_LightCtrl;
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_L].m_LightCH = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_L].m_LightCH;
                                        //                                     Main.AlignUnit[CamNo].PAT[k, Main.DEFINE.OBJ_R].m_LightCH = Main.AlignUnit[CamNo].PAT[StageNo, Main.DEFINE.OBJ_R].m_LightCH;
                                        //                                    Main.AlignUnit[TempName].PAT[k, Main.DEFINE.OBJ_L].m_LightValue[ii, a] = Main.AlignUnit[TempName].PAT[StageNo, Main.DEFINE.OBJ_L].m_LightValue[ii, a];
                                        Main.AlignUnit[TempName].PAT[k, j].m_LightValue[ii, a] = Main.AlignUnit[TempName].PAT[StageNo, j].m_LightValue[ii, a];
                                    }
                                }
                            }
                            //----------------------------------------------------------------------------------------------------------------------------------

                            //----------------------------------------------------------------------------------------------------------------------------------
                            //                         for (int jj = 0; jj < Main.DEFINE.Light_PatMaxCount; jj++)
                            //                         {
                            //                             for (int kk = 0; kk < Main.DEFINE.Light_ToolMaxCount; kk++)
                            //                             {
                            //                                 Main.AlignUnit[CamNo].PAT[i, j].m_LightValue[jj, kk] = Main.AlignUnit[CamNo].PAT[StageNo, j].m_LightValue[jj, kk];
                            //                             }
                            //                         }

                        }
                        Main.AlignUnit[CamNo].Save(i);
                    }

                }
                nPatternCopy = false;
            }
            #endregion


            timer1.Enabled = false;
            DisplayClear();
            this.Hide();
        }// BTN_SAVE_Click
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].Load(StageNo);
            Main.AlignUnit[CamNo].Load_ATT(StageNo, TapNo);//2022 1014 YSH Tab별 Load
            timer1.Enabled = false;
            BTN_PATTERN_COPY.Visible = false;
            DisplayClear();
            this.Hide();
        }

        #endregion

        #region 패턴 등록 관련
        private void BTN_PATTERN_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_PATTERN;
            BTN_BackColor(sender, e);
            DisplayClear();
            CrossLine();
            if (m_AkkonPatChangeFlag)
            {
                if (m_AkkonPatSelectPosFlag == false) //Left Mark
                {
                    if (PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                    {
                        PatMaxTrainRegion = new CogRectangle(PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);
                        PatMaxTrainRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 100, 100);

                        MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    }
                    else
                    {
                        PatMaxTrainRegion = PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle;
                        MarkORGPoint.SetCenterRotationSize(PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX,
                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY, 0, M_ORIGIN_SIZE);
                    }

                    ORGSizeFit();
                    PatMaxTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size; //| CogRectangleAffineDOFConstants.Rotation
                    PatMaxTrainRegion.Interactive = true;


                    CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                    PatternInfo.Add(PatMaxTrainRegion);
                    //            PatternInfo.Add(PatMaxORGPoint);
                    PatternInfo.Add(MarkORGPoint);

                    PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);

                }
                else//Right Mark
                {
                    if (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained == false)
                    {
                        PatMaxTrainRegion = new CogRectangle(PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);
                        PatMaxTrainRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 100, 100);
                        MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    }
                    else
                    {
                        PatMaxTrainRegion = PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle;
                        MarkORGPoint.SetCenterRotationSize(PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX,
                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY, 0, M_ORIGIN_SIZE);
                    }
                    PatMaxTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size; //| CogRectangleAffineDOFConstants.Rotation
                    PatMaxTrainRegion.Interactive = true;

                    ORGSizeFit();
                    CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                    PatternInfo.Add(PatMaxTrainRegion);
                    //            PatternInfo.Add(PatMaxORGPoint);
                    PatternInfo.Add(MarkORGPoint);

                    PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
                }
            }
            else
            {
                if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                {
                    if (PatMaxTrainRegion == null)
                        PatMaxTrainRegion = new CogRectangle(PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);

                    PatMaxTrainRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 100, 100);
                }

                PatMaxTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size; //| CogRectangleAffineDOFConstants.Rotation
                PatMaxTrainRegion.Interactive = true;


                //             if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                //                 PatMaxORGPoint.SetOriginLengthAspectRotationSkew(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], M_ORIGIN_SIZE, 1, 0, 0);
                // 
                //             PatMaxORGPoint.GraphicDOFEnable = CogCoordinateAxesDOFConstants.Position;
                //             PatMaxORGPoint.Interactive = true;

                if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                {
                    MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    ORGSizeFit();
                }
                CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                PatternInfo.Add(PatMaxTrainRegion);
                //            PatternInfo.Add(PatMaxORGPoint);
                PatternInfo.Add(MarkORGPoint);

                PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);

            }

        }

        private void CNLSearch_DrawOverlay()
        {
            CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
            PatternInfo.Add(PatMaxTrainRegion);
            //         PatternInfo.Add(PatMaxORGPoint);

            PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
        }

        private void BTN_BackColor(object sender, EventArgs e)
        {
            nDistanceShow[TapNo] = false;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Red);
            LABEL_MESSAGE(LB_MESSAGE1, "", System.Drawing.Color.Red);

            BTN_BackColor();
            Button TempBTN = (Button)sender;
            TempBTN.BackColor = System.Drawing.Color.LawnGreen;
        }

        private void BTN_BackColor()
        {
            BTN_PATTERN.BackColor = System.Drawing.Color.DarkGray;
            BTN_ORIGIN.BackColor = System.Drawing.Color.DarkGray;
            BTN_PATTERN_SEARCH_SET.BackColor = System.Drawing.Color.DarkGray;
        }

        private void BTN_PATTERN_ORIGIN_Click(object sender, EventArgs e)
        {
            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
            {
                //                 if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                //                     PatMaxORGPoint.SetOriginLengthAspectRotationSkew(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], M_ORIGIN_SIZE, 1, 0, 0);
                //                 PatMaxORGPoint.OriginX = PatMaxTrainRegion.CenterX;
                //                 PatMaxORGPoint.OriginY = PatMaxTrainRegion.CenterY;


                if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                {
                    MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    ORGSizeFit();

                }


                MarkORGPoint.X = PatMaxTrainRegion.CenterX;
                MarkORGPoint.Y = PatMaxTrainRegion.CenterY;
            }

        }
        private void BTN_ORIGIN_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_ORIGIN;
            //    PatMaxORGPoint.DisplayedXAxisLength = 50 * PT_Display01.Zoom;
            BTN_BackColor(sender, e);
        }
        private void BTN_PATTERN_SEARCH_SET_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_SEARCH;
            BTN_BackColor(sender, e);
            DisplayClear();

            if (m_AkkonPatChangeFlag)
            {
                if (m_AkkonPatSelectPosFlag == false)//Left Mark
                {
                    if (PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                        PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
                }
                else
                {
                    if (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained == false)
                        PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
                }
            }
            else
            {
                if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained == false)
                    PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
            }



            PatMaxSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
            PatMaxSearchRegion.Color = CogColorConstants.Orange;
            PatMaxSearchRegion.Interactive = true;

            CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();

            PatternInfo.Add(PatMaxSearchRegion);
            PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
            DisplayFit(PT_Display01);


        }
        private void BTN_PATTERN_SEARCH_SET_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PT_Pattern[TapNo, m_PatNo_Sub].SearchRegion = null;
                PatMaxSearchRegion = new CogRectangle();
                PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
                BTN_PATTERN_SEARCH_SET_Click(sender, null);
            }
        }
        private static void DisplayFit(CogRecordDisplay Display)
        {
            // Display.Fit(false);
            //   Display.AutoFitWithGraphics = false;
            Display.AutoFitWithGraphics = true;
            Display.Fit(true);
        }
        private CogImage8Grey CopyIMG(ICogImage IMG)
        {
            if (IMG == null)
                return new CogImage8Grey();

            CogImage8Grey returnIMG;

            returnIMG = new CogImage8Grey(IMG as CogImage8Grey);
            return returnIMG;


        }
        private void BTN_APPLY_Click(object sender, EventArgs e)
        {
            //             if ((!Main.machine.EngineerMode) && m_PatNo_Sub == 0)
            //             {
            //                 MessageBox.Show("\tNot Engineer Mode!\n   You Can Setting Only SubPattern.");
            //                 return;
            //             }
            try
            {
                if (m_AkkonPatChangeFlag)
                {
                    if (m_AkkonPatSelectPosFlag == false)//Left Mark
                    {
                        if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                        {
                            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                            {
                                //Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_LeftPattern[m_PatNo_Sub].Pattern.TrainImageMask = null;
                                //Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                                //Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].m_LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;
                                PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMask = null;
                                PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                                PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;
                            }

                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);

                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;

                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Train();
                            DrawTrainedATTPattern(PT_SubDisplay[m_PatNo_Sub], PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub]);
                            LABEL_MESSAGE(LB_MESSAGE, "Train OK", System.Drawing.Color.Lime);

                        }
                        if (m_RetiMode == M_SEARCH)
                        {
                            PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                        }
                    }
                    else//Right Mark
                    {
                        if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                        {
                            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                            {
                                PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMask = null;
                                PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                                PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;
                            }

                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);

                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;

                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Train();
                            DrawTrainedATTPattern(PT_SubDisplay[m_PatNo_Sub], PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub]);
                            LABEL_MESSAGE(LB_MESSAGE, "Train OK", System.Drawing.Color.Lime);

                        }
                        if (m_RetiMode == M_SEARCH)
                        {
                            PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                        }
                    }
                }
                else
                {

                    if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                    {
                        if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                        {
                            PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMask = null;
                            PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                            PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;

                            PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMask = null;
                            PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                            PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;
                        }

                        PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        //PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangleAffine(PatMaxTrainRegion);
                        PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);



                        PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                        PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;

                        PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Train();

                        DrawTrainedPattern(PT_SubDisplay[m_PatNo_Sub], PT_Pattern[TapNo, m_PatNo_Sub]);
                        LABEL_MESSAGE(LB_MESSAGE, "Train OK", System.Drawing.Color.Lime);

                        PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        //      PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangleAffine(PatMaxTrainRegion);
                        PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);
                        PT_GPattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                        PT_GPattern[TapNo, m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;
                        PT_GPattern[TapNo, m_PatNo_Sub].Pattern.Train();

                    }
                    if (m_RetiMode == M_SEARCH)
                    {
                        PT_Pattern[TapNo, m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                        PT_GPattern[TapNo, m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                    }
                }
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }

        }
        private void BTN_PATTERN_DELETE_Click(object sender, EventArgs e)
        {
            //             if ((!Main.machine.EngineerMode) && m_PatNo_Sub == 0)
            //             {
            //                 MessageBox.Show("\tNot Engineer Mode!\n   You Can Setting Only SubPattern.");
            //                 return;
            //             }
            DialogResult result = MessageBox.Show("Do you want to Delete Pattern Number: " + CB_SUB_PATTERN.Text + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                PT_Pattern[TapNo, m_PatNo_Sub].Pattern = new CogSearchMaxPattern();
                PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle();
                PT_GPattern[TapNo, m_PatNo_Sub].Pattern = new CogPMAlignPattern();
                //        DrawTrainedPattern(PT_SubDisplay_00, PT_Pattern[TapNo, m_PatNo_Sub]);
                DrawTrainedPattern(PT_SubDisplay[m_PatNo_Sub], PT_Pattern[TapNo, m_PatNo_Sub]);
            }
        }
        private void CB_SUB_PATTERN_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_PatNo_Sub = CB_SUB_PATTERN.SelectedIndex;
            if (m_PatNo_Sub == 0)
                BTN_MAINORIGIN_COPY.Visible = false;
            else
                BTN_MAINORIGIN_COPY.Visible = true;
            Pattern_Change();
        }
        public static void DrawTrainedPattern(CogRecordDisplay Display, CogSearchMaxTool TempPMAlignTool)
        {
            Main.DisplayClear(Display);

            CogSearchMaxTool PMAlignTool = new CogSearchMaxTool(TempPMAlignTool);
            if (PMAlignTool.Pattern.Trained)
            {
                Display.Image = PMAlignTool.Pattern.GetTrainedPatternImage();

                PMAlignTool.Pattern.TrainImageMaskOffsetX = 0;
                PMAlignTool.Pattern.TrainImageMaskOffsetY = 0;
                PMAlignTool.CurrentRecordEnable = CogSearchMaxCurrentRecordConstants.TrainImage | CogSearchMaxCurrentRecordConstants.TrainImageMask;
                Display.Record = PMAlignTool.CreateCurrentRecord();

                CogRectangle TrainRegion = new CogRectangle(PMAlignTool.Pattern.TrainRegion as CogRectangle);
                TrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position;
                TrainRegion.Interactive = false;

                CogCoordinateAxes ORGPoint = new CogCoordinateAxes();
                ORGPoint.LineStyle = CogGraphicLineStyleConstants.Dot;
                ORGPoint.Transform.TranslationX = PMAlignTool.Pattern.Origin.TranslationX;
                ORGPoint.Transform.TranslationY = PMAlignTool.Pattern.Origin.TranslationY;
                ORGPoint.GraphicDOFEnable = CogCoordinateAxesDOFConstants.Position;

                CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                PatternInfo.Add(TrainRegion);
                PatternInfo.Add(ORGPoint);

                Display.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);

                DisplayFit(Display);
            }
            else
            {
                Display.Image = null;
            }
        }

        public static void DrawTrainedATTPattern(CogRecordDisplay Display, CogPMAlignTool TempPMAlignTool)
        {

            Main.DisplayClear(Display);

            CogPMAlignTool PMAlignTool = new CogPMAlignTool(TempPMAlignTool);
            if (PMAlignTool.Pattern.Trained)
            {
                Display.Image = PMAlignTool.Pattern.GetTrainedPatternImage();

                PMAlignTool.Pattern.TrainImageMaskOffsetX = 0;
                PMAlignTool.Pattern.TrainImageMaskOffsetY = 0;
                PMAlignTool.CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainImageMask;

                Display.Record = PMAlignTool.CreateCurrentRecord();

                CogRectangle TrainRegion = new CogRectangle(PMAlignTool.Pattern.TrainRegion as CogRectangle);
                TrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position;
                TrainRegion.Interactive = false;

                CogCoordinateAxes ORGPoint = new CogCoordinateAxes();
                ORGPoint.LineStyle = CogGraphicLineStyleConstants.Dot;
                ORGPoint.Transform.TranslationX = PMAlignTool.Pattern.Origin.TranslationX;
                ORGPoint.Transform.TranslationY = PMAlignTool.Pattern.Origin.TranslationY;
                ORGPoint.GraphicDOFEnable = CogCoordinateAxesDOFConstants.Position;

                CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                PatternInfo.Add(TrainRegion);
                PatternInfo.Add(ORGPoint);

                Display.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);

                DisplayFit(Display);
            }
            else
            {
                Display.Image = null;
            }
        }
        private static CogMaskGraphic CreateMaskGraphic(string SelectedSpaceName, CogImage8Grey mask)
        {
            CogMaskGraphic cogMaskGraphic = new CogMaskGraphic();
            for (short index = 0; index < (short)256; ++index)
            {
                CogColorConstants cogColorConstants;
                CogMaskGraphicTransparencyConstants transparencyConstants;
                if (index < (short)64)
                {
                    cogColorConstants = CogColorConstants.DarkRed;
                    transparencyConstants = CogMaskGraphicTransparencyConstants.Half;
                }
                else if (index < (short)128)
                {
                    cogColorConstants = CogColorConstants.Yellow;
                    transparencyConstants = CogMaskGraphicTransparencyConstants.Half;
                }
                else if (index < (short)192)
                {
                    cogColorConstants = CogColorConstants.Red;
                    transparencyConstants = CogMaskGraphicTransparencyConstants.None;
                }
                else
                {
                    cogColorConstants = CogColorConstants.Yellow;
                    transparencyConstants = CogMaskGraphicTransparencyConstants.Full;
                }
                cogMaskGraphic.SetColorMap((byte)index, cogColorConstants);
                cogMaskGraphic.SetTransparencyMap((byte)index, transparencyConstants);
            }
            cogMaskGraphic.Image = mask;
            cogMaskGraphic.Color = CogColorConstants.None;
            if (SelectedSpaceName == "#")
            {
                ((ICogGraphic)cogMaskGraphic).SelectedSpaceName = "_TrainImage#";
            }
            return cogMaskGraphic;
        }
        private void CB_SUBPAT_USE_CheckedChanged(object sender, EventArgs e)
        {
            //  CB_SUBPAT_USE
            if (CB_SUBPAT_USE.Checked)
            {
                PT_Pattern_USE[TapNo, m_PatNo_Sub] = true;
                CB_SUBPAT_USE.BackColor = System.Drawing.Color.LawnGreen;

            }
            else
            {
                PT_Pattern_USE[TapNo, m_PatNo_Sub] = false;
                CB_SUBPAT_USE.BackColor = System.Drawing.Color.DarkGray;

            }
            SUBPATTERN_LABELDISPLAY(CB_SUBPAT_USE.Checked, m_PatNo_Sub);
        }
        private void SUBPATTERN_LABELDISPLAY(bool nUSE, int nPatSubNo)
        {
            if (nUSE)
            {
                LB_PATTERN[nPatSubNo].BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                LB_PATTERN[nPatSubNo].BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }
        private void NUD_PAT_SCORE_ValueChanged(object sender, EventArgs e)
        {
            PT_AcceptScore[TapNo] = (double)NUD_PAT_SCORE.Value;
            //             if (!(Main.DEFINE.PROGRAM_TYPE == "FOF_PC5" && Main.AlignUnit[CamNo].m_AlignName == "AOI_INSPECTION"))
            //             {
            //                 if ((!Main.machine.EngineerMode) && (double)NUD_PAT_SCORE.Value <= 0.75)
            //                 {
            //                     PT_AcceptScore[TapNo] = 0.75;
            //                 }
            //             }
        }
        private void NUD_PAT_GSCORE_ValueChanged(object sender, EventArgs e)
        {
            PT_GAcceptScore[TapNo] = (double)NUD_PAT_GSCORE.Value;
        }
        #endregion
        private void BTN_PATTERN_RUN_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshTeach(); //-> 확인후 삭제 할것. 
                LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Red);
                m_Timer.StartTimer();
                CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
                DisplayClear();

                switch (Convert.ToInt32(TABC_MANU.SelectedTab.Tag))
                {
                    case Main.DEFINE.M_CNLSEARCHTOOL: //CogCNLSearch
                        #region CNLSEARCH
                        Search_PATCNL();
                        #endregion
                        break;

                    case Main.DEFINE.M_BLOBTOOL: //CogBLOBTOOL
                        #region BLOBTOOL
                        RefreshDisplay2();
                        if (ThresValue_Sts)
                            Search_BLOB(false);
                        else
                            Search_BLOB(true);
                        #endregion
                        break;

                    case Main.DEFINE.M_CALIPERTOOL: //CogCALIPERTOOL
                        #region CALIPERTOOL
                        RefreshDisplay2();
                        if (ThresValue_Sts)
                            Search_Caliper(false);
                        else
                            Search_Caliper(true);
                        #endregion
                        break;

                    case Main.DEFINE.M_FINDLINETOOL: //CogFINDLineTOOL
                        #region COGFINDLine
                        RefreshDisplay2();
                        if (ThresValue_Sts)
                        {
                            Search_FindLine(false);
                            Search_Circle(false);
                        }
                        else
                        {
                            Search_FindLine(true);
                            Search_Circle(true);
                        }
                        #endregion
                        break;

                    case Main.DEFINE.M_FINDCIRCLETOOL:
                        #region CIRCLETOOL
                        RefreshDisplay2();
                        if (ThresValue_Sts)
                        {
                            Search_FindLine(false);
                            Search_Circle(false);
                        }
                        else
                        {
                            Search_FindLine(true);
                            Search_Circle(true);
                        }
                        #endregion
                        break;
                    case Main.DEFINE.M_AKKONTOOL:
                        RefreshDisplay2();
                        Search_Akkon(false);
                        break;
                    case Main.DEFINE.M_ALIGNINSPTOOL:
                        RefreshDisplay2();
                        if (nTeachMode == (int)ALIGN_INDEX.TEACH_MODE_MARK)
                        {
                            Search_AlignMark((ALIGN_INDEX)nInspectionPos);
                        }
                        else if (nTeachMode == (int)ALIGN_INDEX.TEACH_MODE_EDGE)
                        {
                            Search_AlignCaliper((ALIGN_INDEX)nInspectionPos);
                        }
                        break;
                }
                textBox1.Text = m_Timer.GetElapsedTime().ToString() + " ms";
                //    if (BTN_DISNAME_01.BackColor.Name != "SkyBlue") CrossLine();
                if (PT_DISPLAY_CONTROL.CrossLineChecked) CrossLine();
            }//try
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }

        }



        private void TABC_MANU_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //             if (TABC_MANU.SelectedIndex == Main.DEFINE.M_CALIPERTOOL)
            //             {
            //                 if (Main.AlignUnit[CamNo].m_AlignName != "")  //추후에 맞게  수정하도록
            //                     TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
            //             }
            //             if (TABC_MANU.SelectedIndex == Main.DEFINE.M_FINDLINETOOL)
            //             {
            //                 if (Main.AlignUnit[CamNo].m_AlignName != "")
            //                     TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
            //             }
            //             if (TABC_MANU.SelectedIndex == Main.DEFINE.M_FINDCIRCLETOOL)
            //             {
            //                 if (Main.AlignUnit[CamNo].m_AlignName != "")
            //                     TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
            //             }

            switch (TABC_MANU.SelectedIndex)
            {
                case Main.DEFINE.M_CNLSEARCHTOOL:
                    switch (Main.AlignUnit[CamNo].m_AlignName)
                    {
                        case "1st PREALIGN":
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDLINETOOL;
                            break;
                        default:
                            //TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
                            break;
                    }
                    break;


                case Main.DEFINE.M_BLOBTOOL:
                    switch (Main.AlignUnit[CamNo].m_AlignName)
                    {
                        case "IC_TRAY":
                            break;
                        case "ACF_BLOB":
                            break;
                        case "FOF_ACF_PRE":
                            break;
                        case "FOP_ACF_PRE":
                            break;
                        case "SCANNER HEAD CAM1":
                        case "ALIGN INSP CAM2":
                        case "ALIGN INSP CAM3":
                        case "ALIGN INSP CAM4":
                        case "1st PREALIGN":
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDLINETOOL;
                            break;
                        default:
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
                            break;
                    }
                    break;

                case Main.DEFINE.M_CALIPERTOOL:
                    switch (Main.AlignUnit[CamNo].m_AlignName)
                    {
                        case "SCANNER HEAD CAM1":
                        case "ALIGN INSP CAM2":
                        case "ALIGN INSP CAM3":
                        case "ALIGN INSP CAM4":
                            break;
                        case "1st PREALIGN":
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDLINETOOL;
                            break;
                        default:
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_CALIPERTOOL;
                            break;
                    }
                    break;

                case Main.DEFINE.M_FINDCIRCLETOOL:
                    switch (Main.AlignUnit[CamNo].m_AlignName)
                    {
                        case "1st PREALIGN":
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDLINETOOL;
                            break;
                        case "2nd PREALIGN":
                            TABC_MANU.SelectedIndex = Main.DEFINE.M_CNLSEARCHTOOL;
                            break;
                    }
                    break;

                default:
                    break;
            }
        }
        private void TABC_MANU_SelectedIndexChanged(object sender, EventArgs e)
        {
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            LABEL_MESSAGE(LB_MESSAGE1, "", System.Drawing.Color.Lime);

            M_TOOL_MODE = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);

            if (M_TOOL_MODE > 0 && M_TOOL_MODE < 5)
                return;

            if (m_AkkonPatChangeFlag && M_TOOL_MODE == 0)
            {
                for (int i = 0; i < BTN_TOOLSET.Count; i++) BTN_TOOLSET[i].Visible = false;
                BTN_TOOLSET[M_TOOL_MODE].Visible = true;
                return;
            }
            label67.Visible = false;
            LB_ATT_MOVE_PIXEL_COUNT.Visible = false;

            m_AkkonPatChangeFlag = false;
            for (int i = 0; i < BTN_TOOLSET.Count; i++) BTN_TOOLSET[i].Visible = false;
            BTN_TOOLSET[M_TOOL_MODE].Visible = true;
            if (M_TOOL_MODE == Main.DEFINE.M_CNLSEARCHTOOL) BTN_TOOLSET[Main.DEFINE.M_PMALIGNTOOL].Visible = true;

            Light_Select();
            LightCheck(M_TOOL_MODE);
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetAllLight(M_TOOL_MODE);
            DisplayClear();
            nDistanceShow[TapNo] = false;

            m_TABCHANGE_MODE = true;
            switch (M_TOOL_MODE)
            {
                case Main.DEFINE.M_CNLSEARCHTOOL:

                    break;

                case Main.DEFINE.M_BLOBTOOL:
                    CB_BLOB_MARK_USE.Checked = PT_Blob_MarkUSE[TapNo];
                    CB_BLOB_CALIPER_USE.Checked = PT_Blob_CaliperUSE[TapNo];
                    m_SelectBlob = 0;
                    CB_BLOB_COUNT.SelectedIndex = 0;
                    Inspect_Cnt.Value = PT_Blob_InspCnt[TapNo];
                    Blob_Change();
                    break;

                case Main.DEFINE.M_CALIPERTOOL:
                    CB_CALIPER_MARK_USE.Checked = PT_Caliper_MarkUSE[TapNo];
                    RBTN_CALIPER00.Checked = true;
                    m_SelectCaliper = 0;
                    Caliper_Change();
                    break;

                case Main.DEFINE.M_FINDLINETOOL:
                    CB_FINDLINE_MARK_USE.Checked = PT_FindLine_MarkUSE[TapNo];
                    RBTN_FINDLINE00.Checked = true;
                    m_SelectFindLine = 0;
                    FINDLINE_Change();
                    break;

                case Main.DEFINE.M_FINDCIRCLETOOL:
                    CB_CIRCLE_MARK_USE.Checked = PT_Circle_MarkUSE[TapNo];
                    RBTN_CIRCLE00.Checked = true;
                    m_SelectCircle = 0;
                    Circle_Change();
                    break;

                case Main.DEFINE.M_AKKONTOOL:
                    m_SelectAkkon = 0;
                    Akkon_Change();
                    break;

                case Main.DEFINE.M_ALIGNINSPTOOL:
                    m_SelectAkkon = 0;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_MARK.Visible = false;
                    Align_Change();
                    break;
            }
            m_TABCHANGE_MODE = false;
        }
        private void RefreshDisplay2()
        {
            try
            {
                CogImage8Grey nTempImage = new CogImage8Grey();
                nTempImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                bool TargetPosUse = false;
                switch (M_TOOL_MODE)
                {
                    case Main.DEFINE.M_BLOBTOOL:
                    case Main.DEFINE.M_CALIPERTOOL:
                    case Main.DEFINE.M_FINDLINETOOL:
                    case Main.DEFINE.M_FINDCIRCLETOOL:
                    case Main.DEFINE.M_AKKONTOOL:
                        if ((PT_Caliper_MarkUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_CALIPERTOOL)
                            || (PT_Blob_MarkUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_BLOBTOOL)
                            || (PT_FindLine_MarkUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_FINDLINETOOL)
                            || (PT_Circle_MarkUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_FINDCIRCLETOOL)
                            || (PT_Akkon_MarkUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_AKKONTOOL))
                        {
                            TargetPosUse = true;
                            LightCheck(Main.DEFINE.M_LIGHT_CNL);
                            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetAllLight(Main.DEFINE.M_LIGHT_CNL);
                            Main.SearchDelay(100);
                            if (!Search_PATCNL())
                            {
                                PatResult.TranslationX = 0;
                                PatResult.TranslationY = 0;
                                return;
                            }
                        }
                        else if ((PT_Blob_CaliperUSE[TapNo] && M_TOOL_MODE == Main.DEFINE.M_BLOBTOOL))
                        {
                            TargetPosUse = true;
                            LightCheck(Main.DEFINE.M_LIGHT_CALIPER);
                            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetAllLight(Main.DEFINE.M_LIGHT_CALIPER);
                            Main.SearchDelay(100);

                            if (!Search_Caliper(true))
                            {
                                PatResult.TranslationX = 0;
                                PatResult.TranslationY = 0;
                                return;
                            }
                        }
                        else
                        {
                            PatResult.TranslationX = 0;
                            PatResult.TranslationY = 0;
                        }
                        if (TargetPosUse)
                        {
                            LightCheck(M_TOOL_MODE);
                            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].SetAllLight(M_TOOL_MODE);
                            Main.SearchDelay(100);
                            //그랩이 되기전에 다음으로 넘어가기 때문에 넣음.
                            Main.vision.Grab_Flag_End[m_CamNo] = false;
                            Main.vision.Grab_Flag_Start[m_CamNo] = true;

                            while (!Main.vision.Grab_Flag_End[m_CamNo] && !Main.DEFINE.OPEN_F)
                            {
                                Main.SearchDelay(1);
                            }
                            nTempImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        }
                        if (M_TOOL_MODE == Main.DEFINE.M_BLOBTOOL)
                        {
                            for (int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
                                PT_BlobTools[TapNo, i].InputImage = nTempImage;
                        }
                        if (M_TOOL_MODE == Main.DEFINE.M_CALIPERTOOL)
                        {
                            for (int i = 0; i < Main.DEFINE.CALIPER_MAX; i++)
                                PT_CaliperTools[TapNo, i].InputImage = nTempImage;
                        }
                        if (M_TOOL_MODE == Main.DEFINE.M_FINDLINETOOL)
                        {
                            PT_FindLineTool.InputImage = nTempImage;
                            PT_LineMaxTool.InputImage = nTempImage;
                            for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                            {
                                for (int i = 0; i < Main.DEFINE.FINDLINE_MAX; i++)
                                {
                                    PT_FindLineTools[TapNo, ii, i].InputImage = nTempImage;
                                    PT_LineMaxTools[TapNo, ii, i].InputImage = nTempImage;
                                }
                            }

                            // JHKIM 호-직선 연계
                            PT_CircleTool.InputImage = nTempImage;
                        }
                        if (M_TOOL_MODE == Main.DEFINE.M_FINDCIRCLETOOL)
                        {
                            PT_CircleTool.InputImage = nTempImage;
                            for (int i = 0; i < Main.DEFINE.CIRCLE_MAX; i++)
                                PT_CircleTools[TapNo, i].InputImage = nTempImage;

                            // JHKIM 호-직선 연계
                            for (int ii = 0; ii < Main.DEFINE.SUBLINE_MAX; ii++)
                            {
                                for (int i = 0; i < Main.DEFINE.FINDLINE_MAX; i++)
                                {
                                    PT_FindLineTools[TapNo, ii, i].InputImage = nTempImage;
                                    PT_LineMaxTools[TapNo, ii, i].InputImage = nTempImage;
                                }
                            }
                        }
                        if (M_TOOL_MODE == Main.DEFINE.M_AKKONTOOL)
                        {
                            //for (int i = 0; i < Main.DEFINE.AKKON_MAX; i++)
                            //PT_AkkonPara[TapNo, i].img
                        }
                        break;
                }//switch

            }// try
            catch
            {

            }
        }
        private bool Search_PATCNL()
        {
            bool nRet = false;
            bool nRetSearch_CNL = false;
            bool nRetSearch_PMA = false;
            #region CNLSEARCH

            Main.vision.Grab_Flag_End[m_CamNo] = false;
            Main.vision.Grab_Flag_Start[m_CamNo] = true;

            while (!Main.vision.Grab_Flag_End[m_CamNo] && !Main.DEFINE.OPEN_F)
            {
                Main.SearchDelay(1);
            }

            //ATT Mark Search
            if (m_AkkonPatChangeFlag)
            {
                CogPMAlignTool PMAlignTool;

                if (m_AkkonPatSelectPosFlag == false)//Left Mark            
                    PMAlignTool = new CogPMAlignTool(PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub]);

                else // Right Mark
                    PMAlignTool = new CogPMAlignTool(PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub]);

                PMAlignTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PMAlignTool.Run();
                List<CogCompositeShape> ResultGraphic = new List<CogCompositeShape>();

                //Mark Search Run
                if (PMAlignTool.Results != null)
                {
                    if (PMAlignTool.Results.Count >= 1) nRetSearch_CNL = true;
                }
                if (nRetSearch_CNL)
                {
                    if (PMAlignTool.Results.Count >= 1)
                    {

                        if (PMAlignTool.Results.Count >= 1)
                        {
                            for (int j = 0; j < PMAlignTool.Results.Count; j++)
                            {
                                if (PMAlignTool.Results != null)
                                {
                                    ResultGraphic.Add(PMAlignTool.Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                                }
                            }
                        }
                        if (PMAlignTool.Results[0].Score >= PT_AcceptScore[TapNo])
                        {
                            LABEL_MESSAGE(LB_MESSAGE, "Mark OK! " + "Score: " + (PMAlignTool.Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Lime);
                        }
                        else
                        {
                            LABEL_MESSAGE(LB_MESSAGE, "Mark NG! " + "Score: " + (PMAlignTool.Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Red);
                        }
                        Draw_Label(PT_Display01, "Mark     X: " + (PMAlignTool.Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                        Draw_Label(PT_Display01, "Mark     Y: " + (PMAlignTool.Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                        nRet = true;

                        PatResult.TranslationX = PMAlignTool.Results[0].GetPose().TranslationX;
                        PatResult.TranslationY = PMAlignTool.Results[0].GetPose().TranslationY;

                        string X = "X: " + (PMAlignTool.Results[0].GetPose().TranslationX).ToString("0.000");
                        string Y = "Y: " + (PMAlignTool.Results[0].GetPose().TranslationY).ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE1, X + ", " + Y, System.Drawing.Color.Lime);

                        double tempDataX = 0, tempDataY = 0;


                        //Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PMAlignTool.Results[0].GetPose().TranslationX, PMAlignTool.Results[0].GetPose().TranslationY,
                        //                       ref tempDataX, ref tempDataY);

                        //string strLog = tempDataX.ToString("0.000") + "," + tempDataY.ToString("0.000");
                        //Save_SystemLog(strLog, Main.DEFINE.DATA);

                        for (int i = 0; i < ResultGraphic.Count; i++)
                        {
                            PT_Display01.StaticGraphics.Add(ResultGraphic[i] as ICogGraphic, "Mark");
                        }

                    }
                }
                else
                {
                    LABEL_MESSAGE(LB_MESSAGE, "Mark NG! ", System.Drawing.Color.Red);
                }
            }
            //기존부분
            else
            {
                PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                PT_Pattern[TapNo, m_PatNo_Sub].Run();
                List<CogCompositeShape> ResultGraphic = new List<CogCompositeShape>();

                if (PT_Pattern[TapNo, m_PatNo_Sub].Results != null)
                {
                    if (PT_Pattern[TapNo, m_PatNo_Sub].Results.Count >= 1) nRetSearch_CNL = true;
                }
                if (nRetSearch_CNL)
                {
                    if (PT_Pattern[TapNo, m_PatNo_Sub].Results.Count >= 1)
                    {

                        if (PT_Pattern[TapNo, m_PatNo_Sub].Results.Count >= 1)
                        {
                            for (int j = 0; j < PT_Pattern[TapNo, m_PatNo_Sub].Results.Count; j++)
                            {
                                if (PT_Pattern[TapNo, m_PatNo_Sub].Results != null)
                                {
                                    ResultGraphic.Add(PT_Pattern[TapNo, m_PatNo_Sub].Results[j].CreateResultGraphics(Cognex.VisionPro.SearchMax.CogSearchMaxResultGraphicConstants.MatchRegion | Cognex.VisionPro.SearchMax.CogSearchMaxResultGraphicConstants.Origin));
                                }
                            }
                        }
                        if (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].Score >= PT_AcceptScore[TapNo])
                        {
                            LABEL_MESSAGE(LB_MESSAGE, "Mark OK! " + "Score: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Lime);
                        }
                        else
                        {
                            LABEL_MESSAGE(LB_MESSAGE, "Mark NG! " + "Score: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Red);
                        }
                        Draw_Label(PT_Display01, "Mark     X: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                        Draw_Label(PT_Display01, "Mark     Y: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                        nRet = true;

                        PatResult.TranslationX = PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX;
                        PatResult.TranslationY = PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY;

                        string X = "X: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000");
                        string Y = "Y: " + (PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE1, X + ", " + Y, System.Drawing.Color.Lime);

                        double tempDataX = 0, tempDataY = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                               ref tempDataX, ref tempDataY);

                        string strLog = tempDataX.ToString("0.000") + "," + tempDataY.ToString("0.000");
                        Save_SystemLog(strLog, Main.DEFINE.DATA);

                    }
                }
                else
                {
                    LABEL_MESSAGE(LB_MESSAGE, "Mark NG! ", System.Drawing.Color.Red);
                }

                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_PMAlign_Use)
                {
                    PT_GPattern[TapNo, m_PatNo_Sub].Run();
                    //      PT_Display01.Record = PT_GPattern[TapNo, m_PatNo_Sub].CreateLastRunRecord();

                    if (PT_GPattern[TapNo, m_PatNo_Sub].Results != null)
                    {
                        if (PT_GPattern[TapNo, m_PatNo_Sub].Results.Count >= 1) nRetSearch_PMA = true;
                    }
                    if (nRetSearch_PMA)
                    {
                        ResultGraphic.Add(PT_GPattern[TapNo, m_PatNo_Sub].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.MatchFeatures | CogPMAlignResultGraphicConstants.Origin));

                        if (PT_GPattern[TapNo, m_PatNo_Sub].Results[0].Score >= PT_GAcceptScore[TapNo])
                        {
                            LABEL_MESSAGE(LB_MESSAGE, LB_MESSAGE.Text + "\n" + "GMark OK! " + "Score: " + PT_GPattern[TapNo, m_PatNo_Sub].Results[0].Score.ToString("0.000") + "%", System.Drawing.Color.Lime);
                        }
                        else
                        {
                            LABEL_MESSAGE(LB_MESSAGE, LB_MESSAGE.Text + "\n" + "GMark NG! " + "Score: " + PT_GPattern[TapNo, m_PatNo_Sub].Results[0].Score.ToString("0.000") + "%", System.Drawing.Color.Red);
                        }

                        Draw_Label(PT_Display01, "GMark  X: " + (PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000"), 3);
                        Draw_Label(PT_Display01, "GMark  Y: " + (PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000"), 4);

                        string X = "G X: " + (PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000");
                        string Y = "Y: " + (PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE1, LB_MESSAGE1.Text + "\n" + X + ", " + Y, System.Drawing.Color.Lime);

                        double tempDataX = 0, tempDataY = 0, tempDataX2 = 0, tempDataY2 = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                               ref tempDataX, ref tempDataY);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_GPattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                               ref tempDataX2, ref tempDataY2);

                        string strLog = tempDataX.ToString("0.000") + "," + tempDataY.ToString("0.000") + "," + tempDataX2.ToString("0.000") + "," + tempDataY2.ToString("0.000");
                        Save_SystemLog(strLog, Main.DEFINE.DATA);
                    }
                    else
                    {
                        LABEL_MESSAGE(LB_MESSAGE, LB_MESSAGE.Text + "\n" + "GMark NG! ", System.Drawing.Color.Red);
                    }
                }
                for (int i = 0; i < ResultGraphic.Count; i++)
                {
                    PT_Display01.StaticGraphics.Add(ResultGraphic[i] as ICogGraphic, "Mark");
                }
            }

            ////////////////수정할것 
            //       DisplayFit(PT_Display01);
            return nRet;
            #endregion
        }

        private bool Search_AlignMark(ALIGN_INDEX InsPos)
        {
            bool nRet = false;
            bool nRetSearch_CNL = false;
            List<CogCompositeShape> ResultGraphic = new List<CogCompositeShape>();
            Main.vision.Grab_Flag_End[m_CamNo] = false;
            Main.vision.Grab_Flag_Start[m_CamNo] = true;

            while (!Main.vision.Grab_Flag_End[m_CamNo] && !Main.DEFINE.OPEN_F)
            {
                Main.SearchDelay(1);
            }

            if (InsPos == ALIGN_INDEX.INSP_POS_LEFT)
            {
                PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Run();

                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results != null)
                {
                    if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                        nRetSearch_CNL = true;
                }

                if (nRetSearch_CNL)
                {
                    if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                    {
                        if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                        {
                            for (int j = 0; j < PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results.Count; j++)
                            {
                                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results != null)
                                    ResultGraphic.Add(PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                            }
                        }

                        if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].Score >= PT_AcceptScore[TapNo])
                            LABEL_MESSAGE(LB_MESSAGE, "Mark OK! " + "Score: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", Color.Lime);
                        else
                            LABEL_MESSAGE(LB_MESSAGE, "Mark NG! " + "Score: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", Color.Red);

                        Draw_Label(PT_Display01, "Mark     X: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                        Draw_Label(PT_Display01, "Mark     Y: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                        nRet = true;

                        PatResult.TranslationX = PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX;
                        PatResult.TranslationY = PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY;

                        string X = "X: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000");
                        string Y = "Y: " + (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE1, X + ", " + Y, Color.Lime);

                        double tempDataX = 0, tempDataY = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                               ref tempDataX, ref tempDataY);

                        string strLog = tempDataX.ToString("0.000") + "," + tempDataY.ToString("0.000");
                        Save_SystemLog(strLog, Main.DEFINE.DATA);

                    }
                }
                else
                {
                    LABEL_MESSAGE(LB_MESSAGE, "Mark NG! ", System.Drawing.Color.Red);
                }
            }
            else if (InsPos == ALIGN_INDEX.INSP_POS_RIGHT)
            {
                PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Run();

                if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results != null)
                {
                    if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                        nRetSearch_CNL = true;
                }
                if (nRetSearch_CNL)
                {
                    if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                    {
                        if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                        {
                            for (int j = 0; j < PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results.Count; j++)
                            {
                                if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results != null)
                                    ResultGraphic.Add(PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                            }
                        }

                        if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].Score >= PT_AcceptScore[TapNo])
                            LABEL_MESSAGE(LB_MESSAGE, "Mark OK! " + "Score: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Lime);
                        else
                            LABEL_MESSAGE(LB_MESSAGE, "Mark NG! " + "Score: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].Score * 100).ToString("0.000") + "%", System.Drawing.Color.Red);

                        Draw_Label(PT_Display01, "Mark     X: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                        Draw_Label(PT_Display01, "Mark     Y: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                        nRet = true;

                        PatResult.TranslationX = PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX;
                        PatResult.TranslationY = PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY;

                        string X = "X: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX).ToString("0.000");
                        string Y = "Y: " + (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY).ToString("0.000");

                        LABEL_MESSAGE(LB_MESSAGE1, X + ", " + Y, Color.Lime);

                        double tempDataX = 0, tempDataY = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                               ref tempDataX, ref tempDataY);

                        string strLog = tempDataX.ToString("0.000") + "," + tempDataY.ToString("0.000");
                        Save_SystemLog(strLog, Main.DEFINE.DATA);
                    }
                }
                else
                    LABEL_MESSAGE(LB_MESSAGE, "Mark NG! ", Color.Red);
            }

            for (int i = 0; i < ResultGraphic.Count; i++)
                PT_Display01.StaticGraphics.Add(ResultGraphic[i] as ICogGraphic, "Mark");

            return nRet;
        }
        /// <summary>
        /// Align Inspection Method
        /// </summary>
        /// <param name="InsPos"></param>
        /// <returns></returns>
        private bool Search_AlignCaliper(ALIGN_INDEX InsPos)
        {
            bool nRet = true;
            DisplayClear();
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                CogRectangleAffine RectAffine = new CogRectangleAffine();
                CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                CaliperTool.RunParams.FilterHalfSizeInPixels = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels;
                CaliperTool.RunParams.ContrastThreshold = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold;
                CaliperTool.RunParams.Edge0Polarity = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity;
                //ROI Tracking 체크 시 반영부분 추가 필요

                for (int i = 0; i < PTCaliperDividedRegion.Length; i++)
                {
                    CaliperTool.Region = PTCaliperDividedRegion[i];
                    CaliperTool.Run();

                    if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
                    {
                        resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    }
                    else
                    {
                        nRet = false;
                    }
                    //RectAffine.Color = CogColorConstants.Blue;
                    //PT_Display01.StaticGraphics.Add(RectAffine, "CALIPER");
                }
                PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
            }
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
            {
                CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                CaliperTool.RunParams.FilterHalfSizeInPixels = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels;
                CaliperTool.RunParams.ContrastThreshold = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold;
                CaliperTool.RunParams.Edge0Polarity = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity;
                CaliperTool.Region = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].Region;
                CaliperTool.Run();
                if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
                {
                    resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                }
                else
                {
                    nRet = false;
                }
            }
            return nRet;
        }
        public CogBlobTool BlobToolPairRun(CogBlobTool nSourceTool, int nDirection, out int nPlusMinus)
        {
            int TempPlusMinus = 1; ;
            CogBlobTool nCopyTool = new CogBlobTool();
            Main.Mutex_lock_BlobTool.WaitOne();
            try
            {
                nCopyTool = new CogBlobTool(nSourceTool);


                CogRectangle nTempRect = new CogRectangle();
                nTempRect.SetCenterWidthHeight(((CogRectangleAffine)nCopyTool.Region).CenterX, ((CogRectangleAffine)nCopyTool.Region).CenterY, ((CogRectangleAffine)nCopyTool.Region).SideXLength, ((CogRectangleAffine)nCopyTool.Region).SideYLength);

                CogRectangleAffine nBackUpRectAffine = new CogRectangleAffine((CogRectangleAffine)nCopyTool.Region);

                CogRectangle nBackUpRect = new CogRectangle(nTempRect);
                CogRectangle nSearchRect = new CogRectangle(nTempRect);
                // CogRectangle nBackUpRect = new CogRectangle((CogRectangle)nCopyTool.Region);
                // CogRectangle nSearchRect = new CogRectangle((CogRectangle)nCopyTool.Region);

                if (nDirection == Main.DEFINE.HEIGHT)
                { //-----------------------------------------------------------------------------------------+++++++++                        
                    nSearchRect.SetCenterWidthHeight(nBackUpRect.CenterX, nBackUpRect.CenterY - (nBackUpRect.Height / 4), nBackUpRect.Width, nBackUpRect.Height / 2);
                    nCopyTool.Region = new CogRectangle(nSearchRect);
                    nCopyTool.Run();
                    TempPlusMinus = -1;
                    //-----------------------------------------------------------------------------------------
                    if (nCopyTool.Results == null || nCopyTool.Results.GetBlobs().Count <= 0)
                    {
                        nSearchRect.SetCenterWidthHeight(nBackUpRect.CenterX, nBackUpRect.CenterY + (nBackUpRect.Height / 4), nBackUpRect.Width, nBackUpRect.Height / 2);
                        nCopyTool.Region = new CogRectangle(nSearchRect);
                        nCopyTool.Run();
                        TempPlusMinus = 1;
                    }
                }
                else //(nDirection == Main.DEFINE.WIDTH_)
                {
                    { //-----------------------------------------------------------------------------------------+++++++++                             
                        nSearchRect.SetCenterWidthHeight(nBackUpRect.CenterX - (nBackUpRect.Width / 4), nBackUpRect.CenterY, nBackUpRect.Width / 2, nBackUpRect.Height);
                        nCopyTool.Region = new CogRectangle(nSearchRect);
                        nCopyTool.Run();
                        TempPlusMinus = 1;
                        //-----------------------------------------------------------------------------------------
                        if (nCopyTool.Results == null || nCopyTool.Results.GetBlobs().Count <= 0)
                        {
                            nSearchRect.SetCenterWidthHeight(nBackUpRect.CenterX + (nBackUpRect.Width / 4), nBackUpRect.CenterY, nBackUpRect.Width / 2, nBackUpRect.Height);
                            nCopyTool.Region = new CogRectangle(nSearchRect);
                            nCopyTool.Run();
                            TempPlusMinus = -1;
                        }
                    }
                }
                if (nCopyTool.Results != null)
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[1].BlobToolResult = new CogBlobResults(PT_BlobTools[TapNo, 1].Results);
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[1].Pixel[Main.DEFINE.X] = 0;
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[1].Pixel[Main.DEFINE.Y] = 0;

                    List<Main.BlobResult> tempBlobResult = new List<Main.BlobResult>();
                    tempBlobResult.Add(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[1]);
                    Main.DrawOverlayBlobTool(PT_Display01, tempBlobResult);



                }
                //-----------------------------------------------------------------------------------------

                nBackUpRectAffine.SetCenterLengthsRotationSkew(nBackUpRect.CenterX, nBackUpRect.CenterY, nBackUpRect.Width, nBackUpRect.Height, 0, 0);
                nCopyTool.Region = new CogRectangleAffine(nBackUpRectAffine);
            }
            catch
            {

            }
            finally
            {
                Main.Mutex_lock_BlobTool.ReleaseMutex();
            }
            nPlusMinus = TempPlusMinus;
            return nCopyTool;
        }
        private bool Search_BLOB(bool nALLSEARCH)
        {
            bool nRet = true;
            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;

            if (nALLSEARCH)
            {
                nStartNum = 0;
                nLastNum = Main.DEFINE.BLOB_CNT_MAX;
            }
            else
            {
                nStartNum = m_SelectBlob;
                nLastNum = m_SelectBlob + 1;
            }

            for (int i = nStartNum; i < nLastNum; i++)
            {
                if (PT_BlobPara[TapNo, i].m_UseCheck)
                {
                    TempSelect = true;

                    if (PT_Blob_MarkUSE[TapNo])
                    {
                        (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterX = PatResult.TranslationX + PT_BlobPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterY = PatResult.TranslationY + PT_BlobPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }
                    if (PT_Blob_CaliperUSE[TapNo])
                    {
                        (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterX = PatResult.TranslationX + PT_BlobPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].X;
                        (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterY = PatResult.TranslationY + PT_BlobPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].Y;
                    }

                    PT_BlobTools[TapNo, i].InputImage = PT_BlobTools[TapNo, m_SelectBlob].InputImage;


                    //                     if (Main.ALIGNINSPECTION_USE(CamNo))
                    //                     {
                    //                         int nNum = 0;
                    //                         PT_BlobTools[TapNo, i] = BlobToolPairRun(PT_BlobTools[TapNo, i], i, out nNum);
                    //                     }

                    PT_BlobTools[TapNo, i].Run();
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[i].SearchRegion = new CogRectangleAffine(PT_BlobTools[TapNo, i].Region as CogRectangleAffine);
                    if (PT_BlobTools[TapNo, i].Results != null)
                    {
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[i].BlobToolResult = new CogBlobResults(PT_BlobTools[TapNo, i].Results);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[i].Pixel[Main.DEFINE.X] = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[i].Pixel[Main.DEFINE.Y] = 0;

                        List<Main.BlobResult> tempBlobResult = new List<Main.BlobResult>();
                        tempBlobResult.Add(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[i]);
                        Main.DrawOverlayBlobTool(PT_Display01, tempBlobResult);
                        nRet = false;
                    }

                }
            }
            if (!TempSelect)
            {
                LABEL_MESSAGE(LB_MESSAGE, "All Blob Not Use!!", System.Drawing.Color.Red);
                nRet = false;
            }

            LB_List.Items.Clear();
            string A = "";

            if (PT_BlobTools[TapNo, m_SelectBlob].Results != null && PT_BlobPara[TapNo, m_SelectBlob].m_UseCheck)
            {
                if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs().Count > 0)
                {
                    for (int i = 0; i < PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs().Count; i++)
                    {
                        A = "";
                        A = A + "  X =" + PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].CenterOfMassX.ToString("0");
                        A = A + "  Y =" + PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].CenterOfMassY.ToString("0");
                        A = A + "  Area =" + PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].Area.ToString();
                        LB_List.Items.Add(A);
                    }

                    if (Main.BLOBINSPECTION_USE(CamNo))
                    {
                        BlobMinMax_Control();
                        CogPointMarker MarkPoint = new CogPointMarker();
                        MarkPoint.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
                        MarkPoint.Color = CogColorConstants.Yellow;
                        MarkPoint.SizeInScreenPixels = 50;

                        if (m_SelectBlob < Main.DEFINE.BLOB_INSP_LIMIT_CNT)
                        {
                            if ((m_SelectBlob % 2) == 0)
                            {
                                MarkPoint.X = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[2, 0];
                                MarkPoint.Y = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[2, 1];
                                PT_Display01.StaticGraphics.Add(MarkPoint as ICogGraphic, "Search Region");
                            }
                            else
                            {
                                MarkPoint.X = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[2, 0];
                                MarkPoint.Y = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[3, 1];
                                PT_Display01.StaticGraphics.Add(MarkPoint as ICogGraphic, "Search Region");
                            }
                        }
                    }
                }
                PT_BLOB_SUB_Display.Image = PT_BlobTools[TapNo, m_SelectBlob].Results.CreateBlobImage();
                DisplayFit(PT_BLOB_SUB_Display);
            }
            else
            {
                Main.DisplayClear(PT_BLOB_SUB_Display);
                PT_BLOB_SUB_Display.Image = null;
            }
            return nRet;
        }
        private bool Search_Caliper(bool nALLSEARCH)
        {
            bool nRet = true;
            string strLog = "";
            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            double[] tempData = new double[2];
            double[] tempDataMark = new double[2];
            long tempYLength = new long();

            if (nALLSEARCH)
            {
                nStartNum = 0;
                nLastNum = Main.DEFINE.CALIPER_MAX;
            }
            else
            {
                nStartNum = m_SelectCaliper;
                nLastNum = m_SelectCaliper + 1;
            }

            for (int i = nStartNum; i < nLastNum; i++)
            {
                if (PT_CaliPara[TapNo, i].m_UseCheck)
                {
                    TempSelect = true;
                    int nTempPlusMinus = 1;

                    if (PT_Caliper_MarkUSE[TapNo])
                    {
                        (PT_CaliperTools[TapNo, i].Region as CogRectangleAffine).CenterX = PatResult.TranslationX + PT_CaliPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        (PT_CaliperTools[TapNo, i].Region as CogRectangleAffine).CenterY = PatResult.TranslationY + PT_CaliPara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }

                    if (Main.ALIGNINSPECTION_USE(CamNo))
                    {
                        PT_CaliperTools[TapNo, i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].CaliperToolPairRun(PT_CaliperTools[TapNo, i], out nTempPlusMinus);
                    }
                    else
                    {
                        PT_CaliperTools[TapNo, i].Run();
                    }

                    if (PT_CaliperTools[TapNo, i].Results != null && PT_CaliperTools[TapNo, i].Results.Count > 0)
                    {
                        for (int j = 0; j < PT_CaliperTools[TapNo, i].Results.Count; j++)
                        {
                            resultGraphics.Add(PT_CaliperTools[TapNo, i].Results[j].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                        }
                        PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                        //---------------------------------------------------------------------------------------------------------------------------------

                        #region COF_LENGTH
                        if (Main.AlignUnit[CamNo].m_AlignName == "COF_CUTTING_ALIGN1" || Main.AlignUnit[CamNo].m_AlignName == "COF_CUTTING_ALIGN2")
                        {
                            if (Main.GetCaliperDirection(Main.GetCaliperDirection(PT_CaliperTools[TapNo, i].Region.Rotation)) == Main.DEFINE.X)
                            {
                                // PatResult.TranslationX = PT_CaliperTools[TapNo, i].Results[0].Edge0.PositionX;
                            }
                            if (Main.GetCaliperDirection(Main.GetCaliperDirection(PT_CaliperTools[TapNo, i].Region.Rotation)) == Main.DEFINE.Y)
                            {
                                // PatResult.TranslationY = PT_CaliperTools[TapNo, i].Results[0].Edge0.PositionY;

                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(0, PT_CaliperTools[TapNo, i].Results[0].Edge0.PositionY,
                                ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                if (PT_Caliper_MarkUSE[TapNo])
                                {
                                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationX, PT_Pattern[TapNo, m_PatNo_Sub].Results[0].GetPose().TranslationY,
                                    ref tempDataMark[Main.DEFINE.X], ref tempDataMark[Main.DEFINE.Y]);
                                    tempYLength = (long)(Math.Abs(tempDataMark[Main.DEFINE.Y] - tempData[Main.DEFINE.Y]));
                                    LABEL_MESSAGE(LB_MESSAGE, "COF Y_LENGTH: " + tempYLength.ToString("00") + " um", System.Drawing.Color.Lime);
                                }
                            }
                        }
                        #endregion

                        #region BEAM_WIDTH
                        for (int j = 0; j < PT_CaliperTools[TapNo, i].Results.Count; j++)
                        {
                            if (PT_CaliperTools[TapNo, i].RunParams.EdgeMode == CogCaliperEdgeModeConstants.Pair
                                && PT_CaliperTools[TapNo, i].Results.Edges.Count > 1)
                            {
                                double dWidth = 0;
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2RScalar(PT_CaliperTools[TapNo, i].Results[0].Width, ref dWidth);
                                strLog += i.ToString() + " " + dWidth.ToString("0.000") + " ";
                            }
                        }
                        #endregion
                        //---------------------------------------------------------------------------------------------------------------------------------
                    }
                    else
                    {
                        nRet = false;
                        LABEL_MESSAGE(LB_MESSAGE, i.ToString("00") + " Caliper: Search NG! Check!!!", System.Drawing.Color.Red);
                    }
                }
            }

            LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);

            if (PT_CaliperTools[TapNo, m_SelectCaliper].Results != null && PT_CaliperTools[TapNo, m_SelectCaliper].Results.Count > 0 && PT_CaliPara[TapNo, m_SelectCaliper].m_UseCheck)
            {
                DrawLastRegionData(PT_CALIPER_SUB_Display, PT_CaliperTools[TapNo, m_SelectCaliper]);
            }
            else
            {
                Main.DisplayClear(PT_CALIPER_SUB_Display);
                PT_CALIPER_SUB_Display.Image = null;
            }
            if (!TempSelect)
            {
                LABEL_MESSAGE(LB_MESSAGE, "All Caliper Not Use!!", System.Drawing.Color.Red);
                nRet = false;
            }
            return nRet;
        }
        private bool Search_FindLine(bool nALLSEARCH)
        {
            bool nRet = true;
            ushort temp = 0;
            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;
            int nTargetCenterIdx = 0;

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            double[] tempData = new double[2];
            double[] tempDataMark = new double[2];
            string strLog = "";

            if (nALLSEARCH)
            {
                nStartNum = 0;
                nLastNum = Main.DEFINE.FINDLINE_MAX;
            }
            else
            {
                nStartNum = m_SelectFindLine;
                nLastNum = m_SelectFindLine + 1;
            }

            for (int i = nStartNum; i < nLastNum; i++)
            {
                if (PT_FindLinePara[TapNo, m_LineSubNo, i].m_UseCheck)
                {
                    temp |= PT_FindLinePara[TapNo, m_LineSubNo, i].m_LinePosition;

                    TempSelect = true;

                    if (PT_FindLine_MarkUSE[TapNo])
                    {
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                        {
                            (PT_LineMaxTools[TapNo, m_LineSubNo, i].Region as CogRectangleAffine).CenterX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                            (PT_LineMaxTools[TapNo, m_LineSubNo, i].Region as CogRectangleAffine).CenterY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                        }
                        else
                        {
                            PT_FindLineTools[TapNo, m_LineSubNo, i].RunParams.ExpectedLineSegment.StartX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                            PT_FindLineTools[TapNo, m_LineSubNo, i].RunParams.ExpectedLineSegment.StartY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;

                            PT_FindLineTools[TapNo, m_LineSubNo, i].RunParams.ExpectedLineSegment.EndX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X2;
                            PT_FindLineTools[TapNo, m_LineSubNo, i].RunParams.ExpectedLineSegment.EndY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y2;
                        }
                    }

                    if (i == 2) // Diag
                    {
                        continue;
                    }

                    if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                        PT_LineMaxTools[TapNo, m_LineSubNo, i].Run();
                    else
                        PT_FindLineTools[TapNo, m_LineSubNo, i].Run();

                    if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                    {
                        int nLineIdx = 0;

                        if (PT_LineMaxTools[TapNo, m_LineSubNo, i].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, i].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, i].Results[0].GetLine() != null)
                        {
                            for (int j = 0; j < PT_LineMaxTools[TapNo, m_LineSubNo, i].Results.Count; j++)
                            {
                                resultGraphics.Add(PT_LineMaxTools[TapNo, m_LineSubNo, i].Results[j].CreateResultGraphics(CogLineMaxResultGraphicConstants.FoundLine));
                            }
                            PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);

                            if ((nLastNum - nStartNum) < 2)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(i, PT_FindLinePara[TapNo, m_LineSubNo, i], PT_LineMaxTools[TapNo, m_LineSubNo, i], ref nLineIdx);

                                //// Horizontal Y Min Y Max
                                //if (i==0 && PT_LineMaxTools[TapNo, i].Results.Count > 1)
                                //{
                                //    for (int h = 1; h < PT_LineMaxTools[TapNo, i].Results.Count; h++)
                                //    {
                                //        if (PT_FindLinePara[TapNo, i].m_LineMaxHCond == Main.DEFINE.LINEMAX_H_YMIN)
                                //        {
                                //            // Search Y Min Index
                                //            if (PT_LineMaxTools[TapNo, i].Results[h].GetLine().Y < PT_LineMaxTools[TapNo, i].Results[nLineIdx].GetLine().Y)
                                //            {
                                //                nLineIdx = h;
                                //            }
                                //        }
                                //        else if (PT_FindLinePara[TapNo, i].m_LineMaxHCond == Main.DEFINE.LINEMAX_H_YMAX)
                                //        { 
                                //            // Search Y Max Index
                                //            if (PT_LineMaxTools[TapNo, i].Results[h].GetLine().Y > PT_LineMaxTools[TapNo, i].Results[nLineIdx].GetLine().Y)
                                //            {
                                //                nLineIdx = h;
                                //            }
                                //        }
                                //    }
                                //}
                                //// Horizontal Y Min Y Max
                                //else if (i==1 && PT_LineMaxTools[TapNo, i].Results.Count > 1)
                                //{
                                //    for (int v = 1; v < PT_LineMaxTools[TapNo, i].Results.Count; v++)
                                //    {
                                //        if (PT_FindLinePara[TapNo, i].m_LineMaxVCond == Main.DEFINE.LINEMAX_V_XMIN)
                                //        {
                                //            // Search X Min Index
                                //            if (PT_LineMaxTools[TapNo, i].Results[v].GetLine().X < PT_LineMaxTools[TapNo, i].Results[nLineIdx].GetLine().X)
                                //            {
                                //                nLineIdx = v;
                                //            }
                                //        }
                                //        else if (PT_FindLinePara[TapNo, i].m_LineMaxVCond == Main.DEFINE.LINEMAX_V_XMAX)
                                //        {
                                //            // Search X Max Index
                                //            if (PT_LineMaxTools[TapNo, i].Results[v].GetLine().X > PT_LineMaxTools[TapNo, i].Results[nLineIdx].GetLine().X)
                                //            {
                                //                nLineIdx = v;
                                //            }
                                //        }
                                //    }
                                //}

                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineMaxTools[TapNo, m_LineSubNo, i].Results[nLineIdx].GetLineSegment().StartX, PT_LineMaxTools[TapNo, m_LineSubNo, i].Results[nLineIdx].GetLineSegment().StartY,
                                           ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "L1 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                            }
                        }
                        else
                        {
                            nRet = false;
                            LABEL_MESSAGE(LB_MESSAGE, i.ToString("00") + " LineMax: Search NG! Check!!!", System.Drawing.Color.Red);
                            LABEL_MESSAGE(LB_MESSAGE1, i.ToString("00") + PT_LineMaxTools[TapNo, m_LineSubNo, i].RunStatus.Exception.Message, System.Drawing.Color.Red);
                        }
                    }
                    else
                    {
                        if (PT_FindLineTools[TapNo, m_LineSubNo, i].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, i].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, i].Results.GetLine() != null)
                        {
                            for (int j = 0; j < PT_FindLineTools[TapNo, m_LineSubNo, i].Results.Count; j++)
                            {
                                resultGraphics.Add(PT_FindLineTools[TapNo, m_LineSubNo, i].Results[j].CreateResultGraphics(CogFindLineResultGraphicConstants.CaliperEdge | CogFindLineResultGraphicConstants.DataPoint));
                            }
                            PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                            //---------------------------------------------------------------------------------------------------------------------------------
                            //                         if (Main.GetCaliperDirection(Main.GetCaliperDirection(PT_CaliperTools[TapNo, i].Region.Rotation)) == Main.DEFINE.X)
                            //                         {
                            //                             PatResult.TranslationX = PT_CaliperTools[TapNo, i].Results[0].Edge0.PositionX;
                            //                         }
                            //                         if (Main.GetCaliperDirection(Main.GetCaliperDirection(PT_CaliperTools[TapNo, i].Region.Rotation)) == Main.DEFINE.Y)
                            //                         {
                            //                             PatResult.TranslationY = PT_CaliperTools[TapNo, i].Results[0].Edge0.PositionY;
                            //                         }
                            //---------------------------------------------------------------------------------------------------------------------------------

                            if ((nLastNum - nStartNum) < 2)
                            {
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_FindLineTools[TapNo, m_LineSubNo, i].Results.GetLineSegment().StartX, PT_FindLineTools[TapNo, m_LineSubNo, i].Results.GetLineSegment().StartY,
                                           ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "L1 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                            }
                        }
                        else
                        {
                            nRet = false;
                            LABEL_MESSAGE(LB_MESSAGE, i.ToString("00") + " FindLine: Search NG! Check!!!", System.Drawing.Color.Red);
                        }
                    }
                }
            }

            //LABEL_MESSAGE(LB_MESSAGE1, "Line Comb : " + temp.ToString("00"), System.Drawing.Color.Blue);

            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
            {
                if ((nLastNum - nStartNum) >= 3)
                {
                    if ((PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[0].GetLine() != null)
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[0].GetLine() != null))
                    {
                        int nLineIdx1 = 0, nLineIdx2 = 0;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum], ref nLineIdx1);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum + 1, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum + 1], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1], ref nLineIdx2);

                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[0].LineA = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[nLineIdx1].GetLine();
                        PT_LineLineCrossPoints[0].LineB = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[nLineIdx2].GetLine();
                        PT_LineLineCrossPoints[0].Run();
                        if (PT_LineLineCrossPoints[0].Intersects)
                        {
                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                nRet = true;

                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[0].X, PT_LineLineCrossPoints[0].Y,
                                    ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "P1 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000") + "\n";
                                LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);

                                ////////////////////////////////
                                if (PT_FindLinePara[TapNo, m_LineSubNo, 2].m_UseCheck)
                                {
                                    // Position correction
                                    {
                                        (PT_LineMaxTools[TapNo, m_LineSubNo, 2].Region as CogRectangleAffine).CenterX = PT_LineLineCrossPoints[0].X + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X;
                                        (PT_LineMaxTools[TapNo, m_LineSubNo, 2].Region as CogRectangleAffine).CenterY = PT_LineLineCrossPoints[0].Y + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y;
                                    }

                                    PT_LineMaxTools[TapNo, m_LineSubNo, 2].Run();

                                    if (PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[0].GetLine() != null)
                                    {
                                        if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                                        {
                                            strLog += "Angle : " + (PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[0].GetLine().Rotation * Main.DEFINE.degree).ToString("0.00");
                                            LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);
                                        }

                                        for (int j = 0; j < PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results.Count; j++)
                                        {
                                            resultGraphics.Add(PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[j].CreateResultGraphics(CogLineMaxResultGraphicConstants.FoundLine));
                                        }
                                        PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                                    }
                                    else
                                    {
                                        nRet = false;
                                        LABEL_MESSAGE(LB_MESSAGE, 2.ToString("00") + " FindLine: Search NG! Check!!!", System.Drawing.Color.Red);
                                    }
                                }
                            }
                        }
                    }

                    // X, 대각 교점
                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1"
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[0].GetLine() != null)
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results[0].GetLine() != null))
                    {
                        int nLineIdx1 = 0, nLineIdx2 = 0;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum], ref nLineIdx1);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum + 2, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum + 2], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2], ref nLineIdx2);

                        PT_LineLineCrossPoints[1] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[1].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[1].LineA = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[nLineIdx1].GetLine();
                        PT_LineLineCrossPoints[1].LineB = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results[nLineIdx2].GetLine();
                        PT_LineLineCrossPoints[1].Run();
                        if (PT_LineLineCrossPoints[1].Intersects)
                        {
                            if (PT_LineLineCrossPoints[1].X >= 0 && PT_LineLineCrossPoints[1].X <= PT_LineLineCrossPoints[1].InputImage.Width && PT_LineLineCrossPoints[1].Y >= 0 && PT_LineLineCrossPoints[1].Y <= PT_LineLineCrossPoints[1].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[1].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[1].X, PT_LineLineCrossPoints[1].Y,
                                   ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "P2 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                            }
                        }
                    }

                    // Y, 대각 교점
                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1"
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[0].GetLine() != null)
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results[0].GetLine() != null))
                    {
                        int nLineIdx1 = 0, nLineIdx2 = 0;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum + 1, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum + 1], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1], ref nLineIdx1);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum + 2, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum + 2], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2], ref nLineIdx2);

                        PT_LineLineCrossPoints[2] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[2].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[2].LineA = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[nLineIdx1].GetLine();
                        PT_LineLineCrossPoints[2].LineB = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 2].Results[nLineIdx2].GetLine();
                        PT_LineLineCrossPoints[2].Run();
                        if (PT_LineLineCrossPoints[2].Intersects)
                        {
                            if (PT_LineLineCrossPoints[2].X >= 0 && PT_LineLineCrossPoints[2].X <= PT_LineLineCrossPoints[2].InputImage.Width && PT_LineLineCrossPoints[2].Y >= 0 && PT_LineLineCrossPoints[2].Y <= PT_LineLineCrossPoints[2].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[2].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[2].X, PT_LineLineCrossPoints[2].Y,
                                   ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog = "P3 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);
                            }
                        }
                    }
                }
                else if ((nLastNum - nStartNum) >= 2)
                {
                    if ((PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[0].GetLine() != null)
                        && (PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[0].GetLine() != null))
                    {
                        int nLineIdx1 = 0, nLineIdx2 = 0;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum], ref nLineIdx1);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(nStartNum + 1, PT_FindLinePara[TapNo, m_LineSubNo, nStartNum + 1], PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1], ref nLineIdx2);


                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[0].LineA = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum].Results[nLineIdx1].GetLine();
                        PT_LineLineCrossPoints[0].LineB = PT_LineMaxTools[TapNo, m_LineSubNo, nStartNum + 1].Results[nLineIdx2].GetLine();
                        PT_LineLineCrossPoints[0].Run();
                        if (PT_LineLineCrossPoints[0].Intersects)
                        {
                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                            }
                        }
                    }
                }

                if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineX)
                {
                    if (PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results[0].GetLine() != null)
                    {
                        int nLineIdx = 0;
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(0, PT_FindLinePara[TapNo, m_LineSubNo, 0], PT_LineMaxTools[TapNo, m_LineSubNo, 0], ref nLineIdx);

                        PT_LineMaxTools[TapNo, m_LineSubNo, 0].LastRunRecordDiagEnable = CogLineMaxLastRunRecordDiagConstants.InputImageByReference;
                        PT_LineMaxTools[TapNo, m_LineSubNo, 0].LastRunRecordEnable = CogLineMaxLastRunRecordConstants.FoundLines;
                        Display.SetGraphics(PT_Display01, PT_LineMaxTools[TapNo, m_LineSubNo, 0].CreateLastRunRecord(), "RESULT");
                        strLog = "Line X : " + PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results[nLineIdx].GetLine().X.ToString("0.000") + ", " + PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results[nLineIdx].GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
                else if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineY)
                {
                    int nLineIdx = 0;
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(1, PT_FindLinePara[TapNo, m_LineSubNo, 1], PT_LineMaxTools[TapNo, m_LineSubNo, 1], ref nLineIdx);

                    if (PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results[0].GetLine() != null)
                    {
                        PT_LineMaxTools[TapNo, m_LineSubNo, 1].LastRunRecordDiagEnable = CogLineMaxLastRunRecordDiagConstants.InputImageByReference;
                        PT_LineMaxTools[TapNo, m_LineSubNo, 1].LastRunRecordEnable = CogLineMaxLastRunRecordConstants.FoundLines;
                        Display.SetGraphics(PT_Display01, PT_LineMaxTools[TapNo, m_LineSubNo, 1].CreateLastRunRecord(), "RESULT");
                        strLog = "Line Y : " + PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results[nLineIdx].GetLine().X.ToString("0.000") + ", " + PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results[nLineIdx].GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
                else if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineDiag)
                {
                    int nLineIdx = 0;
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(2, PT_FindLinePara[TapNo, m_LineSubNo, 2], PT_LineMaxTools[TapNo, m_LineSubNo, 2], ref nLineIdx);

                    if (PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[0].GetLine() != null)
                    {
                        PT_LineMaxTools[TapNo, m_LineSubNo, 2].LastRunRecordDiagEnable = CogLineMaxLastRunRecordDiagConstants.InputImageByReference;
                        PT_LineMaxTools[TapNo, m_LineSubNo, 2].LastRunRecordEnable = CogLineMaxLastRunRecordConstants.FoundLines;
                        Display.SetGraphics(PT_Display01, PT_LineMaxTools[TapNo, m_LineSubNo, 2].CreateLastRunRecord(), "RESULT");
                        strLog = "Line D : " + PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[nLineIdx].GetLine().X.ToString("0.000") + ", " + PT_LineMaxTools[TapNo, m_LineSubNo, 2].Results[nLineIdx].GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
            }
            else
            {
                if ((nLastNum - nStartNum) >= 3)
                {
                    // X, Y 교점
                    if ((PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine() != null)
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine() != null))
                    {
                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[0].LineA = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine();
                        PT_LineLineCrossPoints[0].LineB = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine();
                        PT_LineLineCrossPoints[0].Run();
                        if (PT_LineLineCrossPoints[0].Intersects)
                        {
                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                //DoublePoint Temp = new DoublePoint();
                                //Temp.X = FINDLineResults[0].Pixel[DEFINE.X] = Pixel[DEFINE.X] = PixelFindLine[DEFINE.X] = (LineLineTool.X);
                                //Temp.Y = FINDLineResults[0].Pixel[DEFINE.Y] = Pixel[DEFINE.Y] = PixelFindLine[DEFINE.Y] = (LineLineTool.Y);
                                //FINDLineResults[0].CrossPointList.Add(Temp);
                                //LABEL_MESSAGE(LB_MESSAGE, "P1 : " + PT_LineLineCrossPoints[0].X.ToString("0.00") + ", " + PT_LineLineCrossPoints[0].Y.ToString("0.00"), System.Drawing.Color.Green);
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[0].X, PT_LineLineCrossPoints[0].Y,
                                    ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "P1 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000") + "\n";
                                LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);

                                ////////////////////////////////
                                if (PT_FindLinePara[TapNo, m_LineSubNo, 2].m_UseCheck)
                                {
                                    // Position correction
                                    {
                                        PT_FindLineTools[TapNo, m_LineSubNo, 2].RunParams.ExpectedLineSegment.StartX = PT_LineLineCrossPoints[0].X + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X;
                                        PT_FindLineTools[TapNo, m_LineSubNo, 2].RunParams.ExpectedLineSegment.StartY = PT_LineLineCrossPoints[0].Y + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y;

                                        PT_FindLineTools[TapNo, m_LineSubNo, 2].RunParams.ExpectedLineSegment.EndX = PT_LineLineCrossPoints[0].X + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X2;
                                        PT_FindLineTools[TapNo, m_LineSubNo, 2].RunParams.ExpectedLineSegment.EndY = PT_LineLineCrossPoints[0].Y + PT_FindLinePara[TapNo, m_LineSubNo, 2].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y2;
                                    }

                                    PT_FindLineTools[TapNo, m_LineSubNo, 2].Run();

                                    if (PT_FindLineTools[TapNo, m_LineSubNo, 2].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.GetLine() != null)
                                    {
                                        if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                                        {
                                            strLog += "Angle : " + (PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.GetLine().Rotation * Main.DEFINE.degree).ToString("0.00");
                                            LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);
                                        }

                                        for (int j = 0; j < PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.Count; j++)
                                        {
                                            resultGraphics.Add(PT_FindLineTools[TapNo, m_LineSubNo, 2].Results[j].CreateResultGraphics(CogFindLineResultGraphicConstants.CaliperEdge | CogFindLineResultGraphicConstants.DataPoint));
                                        }
                                        PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                                    }
                                    else
                                    {
                                        nRet = false;
                                        LABEL_MESSAGE(LB_MESSAGE, 2.ToString("00") + " FindLine: Search NG! Check!!!", System.Drawing.Color.Red);
                                    }
                                }
                            }
                        }
                    }

                    // X, 대각 교점
                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1"
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine() != null)
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.GetLine() != null))
                    {
                        PT_LineLineCrossPoints[1] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[1].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[1].LineA = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine();
                        PT_LineLineCrossPoints[1].LineB = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.GetLine();
                        PT_LineLineCrossPoints[1].Run();
                        if (PT_LineLineCrossPoints[1].Intersects)
                        {
                            if (PT_LineLineCrossPoints[1].X >= 0 && PT_LineLineCrossPoints[1].X <= PT_LineLineCrossPoints[1].InputImage.Width && PT_LineLineCrossPoints[1].Y >= 0 && PT_LineLineCrossPoints[1].Y <= PT_LineLineCrossPoints[1].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[1].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                //DoublePoint Temp = new DoublePoint();
                                //Temp.X = FINDLineResults[0].Pixel[DEFINE.X] = Pixel[DEFINE.X] = PixelFindLine[DEFINE.X] = (LineLineTool.X);
                                //Temp.Y = FINDLineResults[0].Pixel[DEFINE.Y] = Pixel[DEFINE.Y] = PixelFindLine[DEFINE.Y] = (LineLineTool.Y);
                                //FINDLineResults[0].CrossPointList.Add(Temp);
                                //LABEL_MESSAGE(LB_MESSAGE, "P2 : " + PT_LineLineCrossPoints[1].X.ToString("0.00") + ", " + PT_LineLineCrossPoints[1].Y.ToString("0.00"), System.Drawing.Color.Green);
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[1].X, PT_LineLineCrossPoints[1].Y,
                                   ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog += "P2 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                            }
                        }
                    }

                    // Y, 대각 교점
                    if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1"
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine() != null)
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.GetLine() != null))
                    {
                        PT_LineLineCrossPoints[2] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[2].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[2].LineA = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine();
                        PT_LineLineCrossPoints[2].LineB = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 2].Results.GetLine();
                        PT_LineLineCrossPoints[2].Run();
                        if (PT_LineLineCrossPoints[2].Intersects)
                        {
                            if (PT_LineLineCrossPoints[2].X >= 0 && PT_LineLineCrossPoints[2].X <= PT_LineLineCrossPoints[2].InputImage.Width && PT_LineLineCrossPoints[2].Y >= 0 && PT_LineLineCrossPoints[2].Y <= PT_LineLineCrossPoints[2].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[2].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                //DoublePoint Temp = new DoublePoint();
                                //Temp.X = FINDLineResults[0].Pixel[DEFINE.X] = Pixel[DEFINE.X] = PixelFindLine[DEFINE.X] = (LineLineTool.X);
                                //Temp.Y = FINDLineResults[0].Pixel[DEFINE.Y] = Pixel[DEFINE.Y] = PixelFindLine[DEFINE.Y] = (LineLineTool.Y);
                                //FINDLineResults[0].CrossPointList.Add(Temp);
                                //LABEL_MESSAGE(LB_MESSAGE, "P3 : " + PT_LineLineCrossPoints[2].X.ToString("0.00") + ", " + PT_LineLineCrossPoints[2].Y.ToString("0.00"), System.Drawing.Color.Green);
                                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(PT_LineLineCrossPoints[2].X, PT_LineLineCrossPoints[2].Y,
                                   ref tempData[Main.DEFINE.X], ref tempData[Main.DEFINE.Y]);
                                strLog = "P3 : " + tempData[Main.DEFINE.X].ToString("0.000") + ", " + tempData[Main.DEFINE.Y].ToString("0.000");
                                LABEL_MESSAGE(LB_MESSAGE1, strLog, System.Drawing.Color.Green);
                            }
                        }
                    }

                }
                else if ((nLastNum - nStartNum) >= 2)
                {
                    if ((PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine() != null)
                        && (PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine() != null))
                    {
                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        PT_LineLineCrossPoints[0].LineA = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum].Results.GetLine();
                        PT_LineLineCrossPoints[0].LineB = PT_FindLineTools[TapNo, m_LineSubNo, nStartNum + 1].Results.GetLine();
                        PT_LineLineCrossPoints[0].Run();
                        if (PT_LineLineCrossPoints[0].Intersects)
                        {
                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                            {
                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                nRet = true;
                                //DoublePoint Temp = new DoublePoint();
                                //Temp.X = FINDLineResults[0].Pixel[DEFINE.X] = Pixel[DEFINE.X] = PixelFindLine[DEFINE.X] = (LineLineTool.X);
                                //Temp.Y = FINDLineResults[0].Pixel[DEFINE.Y] = Pixel[DEFINE.Y] = PixelFindLine[DEFINE.Y] = (LineLineTool.Y);
                                //FINDLineResults[0].CrossPointList.Add(Temp);
                            }
                        }
                    }
                }

                if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineX)
                {
                    if (PT_FindLineTools[TapNo, m_LineSubNo, 0].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.GetLine() != null)
                    {
                        PT_FindLineTools[TapNo, m_LineSubNo, 0].LastRunRecordDiagEnable = CogFindLineLastRunRecordDiagConstants.InputImageByReference;
                        PT_FindLineTools[TapNo, m_LineSubNo, 0].LastRunRecordEnable = CogFindLineLastRunRecordConstants.BestFitLine;
                        Display.SetGraphics(PT_Display01, PT_FindLineTools[TapNo, m_LineSubNo, 0].CreateLastRunRecord(), "RESULT");
                        strLog = "Line X : " + PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.GetLine().X.ToString("0.000") + ", " + PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
                else if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineY)
                {
                    if (PT_FindLineTools[TapNo, m_LineSubNo, 1].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.GetLine() != null)
                    {
                        PT_FindLineTools[TapNo, m_LineSubNo, 1].LastRunRecordDiagEnable = CogFindLineLastRunRecordDiagConstants.InputImageByReference;
                        PT_FindLineTools[TapNo, m_LineSubNo, 1].LastRunRecordEnable = CogFindLineLastRunRecordConstants.BestFitLine;
                        Display.SetGraphics(PT_Display01, PT_FindLineTools[TapNo, m_LineSubNo, 1].CreateLastRunRecord(), "RESULT");
                        strLog = "Line Y : " + PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.GetLine().X.ToString("0.000") + ", " + PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
                else if ((Main.AlignUnitTag.FindLineConstants)temp == Main.AlignUnitTag.FindLineConstants.LineDiag)
                {
                    if (PT_FindLineTools[TapNo, m_LineSubNo, 2].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.GetLine() != null)
                    {
                        PT_FindLineTools[TapNo, m_LineSubNo, 2].LastRunRecordDiagEnable = CogFindLineLastRunRecordDiagConstants.InputImageByReference;
                        PT_FindLineTools[TapNo, m_LineSubNo, 2].LastRunRecordEnable = CogFindLineLastRunRecordConstants.BestFitLine;
                        Display.SetGraphics(PT_Display01, PT_FindLineTools[TapNo, m_LineSubNo, 2].CreateLastRunRecord(), "RESULT");
                        strLog = "Line D : " + PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.GetLine().X.ToString("0.000") + ", " + PT_FindLineTools[TapNo, m_LineSubNo, 2].Results.GetLine().Y.ToString("0.000");
                        LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);
                    }
                }
            }

            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax &&
                PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].Results.Count > 0 && PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck)
            {
                DrawFINDLineLastRegionData(PT_FINDLINE_SUB_Display, PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine]);
            }
            else if (PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].Results.Count > 0 && PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck)
            {
                DrawFINDLineLastRegionData(PT_FINDLINE_SUB_Display, PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine]);
            }
            else
            {
                Main.DisplayClear(PT_FINDLINE_SUB_Display);
                PT_FINDLINE_SUB_Display.Image = null;
            }
            if (!TempSelect)
            {
                LABEL_MESSAGE(LB_MESSAGE, "All FindLine Not Use!!", System.Drawing.Color.Red);
                nRet = false;
            }
            return nRet;
        }
        private bool Search_Circle(bool nALLSEARCH)
        {
            bool nRet = true;

            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            double[] tempData = new double[2];
            double[] tempDataMark = new double[2];

            if (nALLSEARCH)
            {
                nStartNum = 0;
                nLastNum = Main.DEFINE.CIRCLE_MAX;
            }
            else
            {
                nStartNum = m_SelectCircle;
                nLastNum = m_SelectCircle + 1;
            }

            for (int i = nStartNum; i < nLastNum; i++)
            {
                if (PT_CirclePara[TapNo, i].m_UseCheck)
                {
                    TempSelect = true;

                    if (PT_Circle_MarkUSE[TapNo])
                    {
                        PT_CircleTools[TapNo, i].RunParams.ExpectedCircularArc.CenterX = PatResult.TranslationX + PT_CirclePara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        PT_CircleTools[TapNo, i].RunParams.ExpectedCircularArc.CenterY = PatResult.TranslationY + PT_CirclePara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;

                    }

                    // Position correction
                    {
                        PT_CircleTools[TapNo, i].RunParams.ExpectedCircularArc.CenterX = PT_LineLineCrossPoints[0].X + PT_CirclePara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X;
                        PT_CircleTools[TapNo, i].RunParams.ExpectedCircularArc.CenterY = PT_LineLineCrossPoints[0].Y + PT_CirclePara[TapNo, i].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y;
                    }

                    PT_CircleTools[TapNo, i].Run();

                    if (PT_CircleTools[TapNo, i].Results != null && PT_CircleTools[TapNo, i].Results.Count > 0 && PT_CircleTools[TapNo, i].Results.GetCircle() != null
                        )
                    {
                        for (int j = 0; j < PT_CircleTools[TapNo, i].Results.Count; j++)
                        {
                            resultGraphics.Add(PT_CircleTools[TapNo, i].Results[j].CreateResultGraphics(CogFindCircleResultGraphicConstants.CaliperEdge | CogFindCircleResultGraphicConstants.DataPoint));
                        }
                        CogPointMarker nCircleCenter = new CogPointMarker();
                        nCircleCenter.Color = CogColorConstants.Purple;
                        nCircleCenter.SetCenterRotationSize(PT_CircleTools[TapNo, i].Results.GetCircle().CenterX, PT_CircleTools[TapNo, i].Results.GetCircle().CenterY, 0, 20);
                        resultGraphics.Add(nCircleCenter);
                        PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2RScalar(PT_CircleTools[TapNo, i].Results.GetCircle().Radius, ref tempData[0]);
                        LABEL_MESSAGE(LB_MESSAGE, "Circle : " + tempData[0].ToString("0.000") + "R", System.Drawing.Color.Green);
                    }
                    else
                    {
                        nRet = false;
                        LABEL_MESSAGE(LB_MESSAGE, i.ToString("00") + " Circle: Search NG! Check!!!", System.Drawing.Color.Red);
                    }
                }
            }

            if (PT_CircleTools[TapNo, m_SelectCircle].Results != null && PT_CircleTools[TapNo, m_SelectCircle].Results.Count > 0 && PT_CircleTools[TapNo, m_SelectCircle].Results.GetCircle() != null && PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck)
            {
                DrawLastRegionData(PT_CIRCLE_SUB_Display, PT_CircleTools[TapNo, m_SelectCircle]);

            }
            else
            {
                Main.DisplayClear(PT_CIRCLE_SUB_Display);
                PT_CIRCLE_SUB_Display.Image = null;
            }
            if (!TempSelect)
            {
                //LABEL_MESSAGE(LB_MESSAGE, "All Circle Not Use!!", System.Drawing.Color.Red);
                nRet = false;
            }
            return nRet;
        }

        private bool Search_Akkon(bool nALLSEARCH)
        {
            bool nRet = true;
            bool TempSelect = false;
            string strLog = "";
            int nStartNum = 0;
            int nLastNum = 0;
            string strROI = "";

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();

            if (nALLSEARCH)
            {
                nStartNum = 0;
                nLastNum = Main.DEFINE.AKKON_MAX;
            }
            else
            {
                nStartNum = m_SelectAkkon;
                nLastNum = m_SelectAkkon + 1;
            }

            PT_AkkonPara[TapNo].UseCheckAkkonInspection = true;
            Main.sw.Start();
   
            if (PT_AkkonPara[TapNo].UseCheckAkkonInspection)
            {
                TempSelect = true;
                int nTempPlusMinus = 1;

                if (PT_Akkon_MarkUSE[TapNo])
                {
                    for (int j = 0; j < PT_AkkonPara[TapNo].AkkonBumpROIList.Count; j++)
                    {
                        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }
                }


                ////YSH
                ////Image Resize
                //////////////////////////////////////////////////////////////////////////////////////////////////////
                //CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[m_CamNo].OutputImage as CogImage8Grey);
                //Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(CogConvertImage.ToBitmap()); //CogImage8Grey -> Mat (RGB)
                //Cv2.CvtColor(src, src, ColorConversionCodes.RGB2GRAY);  // RGB -> Gray
                //Cv2.Resize(src, src, new OpenCvSharp.Size(0, 0), Imgresizeratio, Imgresizeratio); //임의로 ratio 0.6설정
                ////Mat -> btye[]
                //byte[] bytes2;
                //Cv2.ImEncode(".bmp", src, out bytes2);
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgDataATT = bytes2;
                //// ATT 이미지 버퍼 재설정
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols = src.Cols;
                //Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows = src.Rows;

                //String strPath;
                //strPath = String.Format("D:\\Image_Resize.bmp");
                //Cv2.ImWrite(strPath, src);

                ////정식으로는 프로그램 실행 및 Buffer할당 시에만 동작함. 현재는 임의로 검사하기전에 동작. 해당 함수 소요시간은 T/T 제외가능
                //Main.ATT_CreateImageBuffer(CamNo, TapNo, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols, Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows);

                // ATT Initialize
                if (Main.DEFINE.OPEN_F)
                {
                    //Main.vision.IMAGE_SIZE_X[0] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                    //Main.vision.IMAGE_SIZE_Y[0] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgRows;
                    //2022 1004 YSH
                    //Main.vision.IMAGE_SIZE_X[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgCols;    // Main.DEFINE.LINE_PAGE_LENGTH;
                    //Main.vision.IMAGE_SIZE_Y[1] = Main.AlignUnit[CamNo].PAT[0, TapNo].m_imgRows;
                }

                // 0 COF, 1 COG, 2 FOG
                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[0].AkkonInspectionParameter.s_nPanelInfo == 0)
                    Main.DEFINE.ImageResizeRatio = (float)0.5;
                else if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[0].AkkonInspectionParameter.s_nPanelInfo == 1)
                    Main.DEFINE.ImageResizeRatio = (float)1.0;
                else if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[0].AkkonInspectionParameter.s_nPanelInfo == 2)
                    Main.DEFINE.ImageResizeRatio = (float)0.6;

                //2022 1004 YSH
                //Resize 0.5 사용시 Result 이미지 이상출력
                Main.DEFINE.ImageResizeRatio = (float)0.6;
                Main.ATT_CreateDLLBuffer();
                Main.ATT_CreateImageBuffer();


                //ATT Mark search 
                double dX = 0, dY = 0, dTeachT = 0, dRotT = 0;
                OpenCvSharp.Point2d pntCenter = new Point2d();
                OpenCvSharp.Point2d pntdXY = new Point2d();
                pntCenter.X = 0; pntCenter.Y = 0;

                bool bLeftMarkCheck = false;
                bool bRightMarkCheck = false;
                PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Run();
                PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Run();

                if (PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results != null)
                {
                    if (PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                        bLeftMarkCheck = true;
                }
                if (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results != null)
                {
                    if (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                        bRightMarkCheck = true;
                }

                if (bLeftMarkCheck && bRightMarkCheck)
                {
                    //추후 Score 기능 추가 예정 - YSH        
                    dX = (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2
                    - (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX) / 2;

                    dY = (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2
                    - (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY) / 2;

                    double dRotDx = PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX - PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX;
                    double dRotDy = PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY - PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY;
                    dRotT = OpenCvSharp.Cv2.FastAtan2((float)dRotDy, (float)dRotDx);
                    if (dRotT > 180) dRotT -= 360;

                    //float a = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY);
                    //float b = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX);

                    dTeachT = OpenCvSharp.Cv2.FastAtan2((float)(PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY),
                        (float)(PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX));
                    if (dTeachT > 180.0) dTeachT -= 360.0;


                    dRotT -= dTeachT;
                    pntCenter.X = (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2;
                    pntCenter.Y = (PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2;

                    pntdXY.X = dX;
                    pntdXY.Y = dY;
                }
                else
                {
                    LABEL_MESSAGE(LB_MESSAGE, "Mark Search NG! ", Color.Red);
                }

                Cv2.Resize(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanOriginalBuf, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf,
                    new OpenCvSharp.Size(0, 0), Main.DEFINE.ImageResizeRatio, Main.DEFINE.ImageResizeRatio);
                byte[] bytes2 = new byte[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Cols * Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Rows];
                Cv2.ImEncode(".bmp", Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf, out bytes2);
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgDataATT = new byte[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Cols * Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Rows];
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgCols = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Cols;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgRows = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Rows;
                Main.strtmp[0] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();



                //압흔 Parameter 갱신부분 추가 필요 - YSH



                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                Main.sw.Start();
                // ROI Resize
                int[][] nLeadPoint = new int[PT_AkkonPara[TapNo].AkkonBumpROIList.Count][];
                OpenCvSharp.Point[] ptPos = new OpenCvSharp.Point[4];
                for (int j = 0; j < PT_AkkonPara[TapNo].AkkonBumpROIList.Count; j++)
                {
                    nLeadPoint[j] = new int[8];

                    nLeadPoint[j][0] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerOriginX);  //LeftTop
                    nLeadPoint[j][1] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerOriginY);  //LeftTop

                    nLeadPoint[j][2] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerXX);  //RightTop
                    nLeadPoint[j][3] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerXY);  //RightTop

                    nLeadPoint[j][4] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerOppositeX);  //RightBottom
                    nLeadPoint[j][5] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerOppositeY);  //RightBottom

                    nLeadPoint[j][6] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerYX);  //LeftBottom
                    nLeadPoint[j][7] = (int)(PT_AkkonPara[TapNo].AkkonBumpROIList[j].CornerYY);  //LeftBottom

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
                    //PT_AkkonPara[TapNo, i].m_AkkonBumpROI[j] = tempRectAffine;

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
                bool bReadRoi = Main.ATT_SendROI(CamNo, TapNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    return false;
                }



                // ATT RUN
                bool bReady = Main.ATT_ReadyToInsp(CamNo, StageNo, TapNo, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[0]);

                // 자동 계산 overlap 확인
                LB_ATT_SLICE_OVERLAP.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_nOverlap.ToString();

                if (bReady)
                {
                    Main.isFormTeaching = true;
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonResult[0].AkkonResultArray = null;
                    Main.ATT_InspectByTap(CamNo, StageNo, TapNo);
                }

            }
            
    
            //LABEL_MESSAGE(LB_MESSAGE, strLog, System.Drawing.Color.Green);

            //if (PT_CaliperTools[TapNo, m_SelectCaliper].Results != null && PT_CaliperTools[TapNo, m_SelectCaliper].Results.Count > 0 && PT_CaliPara[TapNo, m_SelectCaliper].m_UseCheck)
            //{
            //    DrawLastRegionData(PT_CALIPER_SUB_Display, PT_CaliperTools[TapNo, m_SelectCaliper]);
            //}
            //else
            //{
            //    Main.DisplayClear(PT_CALIPER_SUB_Display);
            //    PT_CALIPER_SUB_Display.Image = null;
            //}
            //if (!TempSelect)
            //{
            //    LABEL_MESSAGE(LB_MESSAGE, "All Caliper Not Use!!", System.Drawing.Color.Red);
            //    nRet = false;
            //}
            return nRet;
        }

        public static void ShowAkkonResultImage(CogImage24PlanarColor cogResultImage)
        {
            PT_Display01.Image = cogResultImage;
            _bATTResult = true;
        }

        #region BLOB
        private void Blob_Change()
        {
            m_PatchangeFlag = true;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            RefreshDisplay2();
            BLOB_TBAR_THRES.Value = PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.HardFixedThreshold;
            NUD_MinPixel.Value = (decimal)PT_BlobTools[TapNo, m_SelectBlob].RunParams.ConnectivityMinPixels;
            CB_POLARITY_BLOB.SelectedIndex = Convert.ToInt16(PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.Polarity);  //CogBlobSegmentationPolarityConstants.DarkBlobs;
            CB_BLOB_USE.Checked = PT_BlobPara[TapNo, m_SelectBlob].m_UseCheck;
            CB_BLOB_MARK_USE.Checked = PT_Blob_MarkUSE[TapNo];
            CB_BLOB_CALIPER_USE.Checked = PT_Blob_CaliperUSE[TapNo];
            Inspect_Cnt.Value = PT_Blob_InspCnt[TapNo];
            LB_List.Items.Clear();

            Main.DisplayClear(PT_BLOB_SUB_Display);
            PT_BLOB_SUB_Display.Image = null;
            DrawBlobRegion();
            m_PatchangeFlag = false;
        }
        private void DrawBlobRegion()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_BLOBTOOL)
            {
                DisplayClear();
                BlobTrainRegion = new CogRectangleAffine(PT_BlobTools[TapNo, m_SelectBlob].Region as CogRectangleAffine);
                if (PT_Blob_MarkUSE[TapNo])
                {
                    BlobTrainRegion.CenterX = PatResult.TranslationX + PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                    BlobTrainRegion.CenterY = PatResult.TranslationY + PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                }
                if (PT_Blob_CaliperUSE[TapNo])
                {
                    BlobTrainRegion.CenterX = PatResult.TranslationX + PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].X;
                    BlobTrainRegion.CenterY = PatResult.TranslationY + PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].Y;
                }
                BlobTrainRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                BlobTrainRegion.Interactive = true;

                CogGraphicInteractiveCollection BlobInfo = new CogGraphicInteractiveCollection();
                BlobInfo.Add(BlobTrainRegion);
                PT_Display01.InteractiveGraphics.AddList(BlobInfo, "BLOB_INFO", false);
                Main.DisplayFit(PT_Display01);

            }
        }
        private void CB_BLOB_USE_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_BLOB_USE.Checked)
            {
                CB_BLOB_USE.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_BLOB_USE.BackColor = System.Drawing.Color.DarkGray;
            }

        }
        private void CB_BLOB_USE_Click(object sender, EventArgs e)
        {
            if (CB_BLOB_USE.Checked)
            {
                PT_BlobPara[TapNo, m_SelectBlob].m_UseCheck = true;
            }
            else
            {
                PT_BlobPara[TapNo, m_SelectBlob].m_UseCheck = false;
            }
        }
        private void BlobMinMax_Control()
        {
            /////2/////
            //0//////1//
            /////3/////

            double[] VertexValue = new double[4];
            int[,] VertexArray = new int[4, 2];

            int POS_I = 0, POS_J = 1;
            int POS_X = 0, POS_Y = 1;
            int MIN_X = 0, MAX_X = 1, MIN_Y = 2, MAX_Y = 3;
            if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs().Count > 0)
            {

                for (int i = 0; i < PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs().Count; i++)
                {
                    for (int j = 0; j < PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertices().Length / 2; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            VertexValue[MIN_X] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j);
                            VertexValue[MAX_X] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j);
                            VertexValue[MIN_Y] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j);
                            VertexValue[MAX_Y] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j);
                        }
                        if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j) < VertexValue[MIN_X])
                        {
                            VertexValue[MIN_X] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j);
                            VertexArray[MIN_X, POS_I] = i;
                            VertexArray[MIN_X, POS_J] = j;
                        }
                        if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j) > VertexValue[MAX_X])
                        {
                            VertexValue[MAX_X] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexX(j);
                            VertexArray[MAX_X, POS_I] = i;
                            VertexArray[MAX_X, POS_J] = j;
                        }

                        if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j) < VertexValue[MIN_Y])
                        {
                            VertexValue[MIN_Y] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j);
                            VertexArray[MIN_Y, POS_I] = i;
                            VertexArray[MIN_Y, POS_J] = j;
                        }
                        if (PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j) > VertexValue[MAX_Y])
                        {
                            VertexValue[MAX_Y] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[i].GetBoundary().GetVertexY(j);
                            VertexArray[MAX_Y, POS_I] = i;
                            VertexArray[MAX_Y, POS_J] = j;
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[i, POS_X] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[VertexArray[i, POS_I]].GetBoundary().GetVertexX(VertexArray[i, POS_J]);
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].BlobResults[m_SelectBlob].VertexResults[i, POS_Y] = PT_BlobTools[TapNo, m_SelectBlob].Results.GetBlobs()[VertexArray[i, POS_I]].GetBoundary().GetVertexY(VertexArray[i, POS_J]);
                }
            }
        }

        bool nCheckBoxFlag = false;
        private void BLOB_MARK_USE_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            if (TempBTN.Checked)
            {
                TempBTN.BackColor = System.Drawing.Color.GreenYellow;
                PT_Blob_MarkUSE[TapNo] = true;
                if (CB_BLOB_CALIPER_USE.Checked)
                {
                    CB_BLOB_CALIPER_USE.Checked = false;
                    nCheckBoxFlag = true;
                }
            }
            else
            {
                TempBTN.BackColor = System.Drawing.Color.White;
                PT_Blob_MarkUSE[TapNo] = false;

            }
            if (!nCheckBoxFlag && !m_TABCHANGE_MODE)
            {
                RefreshDisplay2();
                DrawBlobRegion();
            }
            nCheckBoxFlag = false;
        }
        private void CB_BLOB_CALIPER_USE_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            if (TempBTN.Checked)
            {
                TempBTN.BackColor = System.Drawing.Color.GreenYellow;
                PT_Blob_CaliperUSE[TapNo] = true;

                if (CB_BLOB_MARK_USE.Checked)
                {
                    CB_BLOB_MARK_USE.Checked = false;
                    nCheckBoxFlag = true;
                }
            }
            else
            {
                TempBTN.BackColor = System.Drawing.Color.White;
                PT_Blob_CaliperUSE[TapNo] = false;
            }
            if (!nCheckBoxFlag && !m_TABCHANGE_MODE)
            {
                RefreshDisplay2();
                DrawBlobRegion();
            }
            nCheckBoxFlag = false;
        }
        private void CB_BLOB_COUNT_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_SelectBlob = CB_BLOB_COUNT.SelectedIndex;
            if (!m_TABCHANGE_MODE)
            {
                Blob_Change();
            }
        }
        private void CB_POLARITY_BLOB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.Polarity = (CogBlobSegmentationPolarityConstants)CB_POLARITY_BLOB.SelectedIndex;
        }
        private void NUD_MinPixel_Click(object sender, EventArgs e)
        {
            PT_BlobTools[TapNo, m_SelectBlob].RunParams.ConnectivityMinPixels = (int)NUD_MinPixel.Value;
            if (!m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_BLOBTOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void Inspect_Cnt_ValueChanged(object sender, EventArgs e)
        {
            PT_Blob_InspCnt[TapNo] = (int)Inspect_Cnt.Value; //= Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_Blob_InspCnt

            for (int i = 0; i < Main.DEFINE.BLOB_INSP_LIMIT_CNT; i++)
                PT_BlobPara[TapNo, i].m_UseCheck = false;

            if (PT_Blob_InspCnt[TapNo] != 0)
            {
                for (int i = 0; i < 2 * PT_Blob_InspCnt[TapNo]; i++)
                    PT_BlobPara[TapNo, i].m_UseCheck = true;
            }


        }

        private void BLOB_TBAR_THRES_ValueChanged(object sender, EventArgs e)
        {
            PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.HardFixedThreshold = BLOB_TBAR_THRES.Value;
            BLOB_LB_THRES.Text = BLOB_TBAR_THRES.Value.ToString();
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_BLOBTOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BLOB_BTN_THRES_UP_Click(object sender, EventArgs e)
        {
            if (BLOB_TBAR_THRES.Maximum == BLOB_TBAR_THRES.Value) return;

            BLOB_TBAR_THRES.Value++;
        }
        private void BLOB_BTN_THRES_DN_Click(object sender, EventArgs e)
        {
            if (BLOB_TBAR_THRES.Minimum == BLOB_TBAR_THRES.Value) return;

            BLOB_TBAR_THRES.Value--;
        }
        private void BTN_BLOB_Click(object sender, EventArgs e)
        {
            Blob_Change();
        }
        private void BLOB_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (PT_Blob_MarkUSE[TapNo])
                {
                    PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X = BlobTrainRegion.CenterX - PatResult.TranslationX;
                    PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y = BlobTrainRegion.CenterY - PatResult.TranslationY;
                }
                if (PT_Blob_CaliperUSE[TapNo])
                {
                    PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].X = BlobTrainRegion.CenterX - PatResult.TranslationX;
                    PT_BlobPara[TapNo, m_SelectBlob].m_TargetToCenter[Main.DEFINE.M_CALIPERTOOL].Y = BlobTrainRegion.CenterY - PatResult.TranslationY;
                }
                PT_BlobTools[TapNo, m_SelectBlob].Region = new CogRectangleAffine(BlobTrainRegion);
                PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.HardFixedThreshold = BLOB_TBAR_THRES.Value;
                PT_BlobTools[TapNo, m_SelectBlob].RunParams.ConnectivityMinPixels = (int)NUD_MinPixel.Value;
                PT_BlobTools[TapNo, m_SelectBlob].RunParams.SegmentationParams.Polarity = (CogBlobSegmentationPolarityConstants)CB_POLARITY_BLOB.SelectedIndex;
                LABEL_MESSAGE(LB_MESSAGE, "Register OK", System.Drawing.Color.Lime);
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }
            Main.DisplayFit(PT_Display01);
        }
        private void BTN_BLOBCOPY_Click(object sender, EventArgs e)
        {
            //             if (!Main.machine.EngineerMode)
            //             {
            //                 MessageBox.Show("Not Engineer Mode!!!");
            //                 return;
            //             }
            //             if(BlobTrainRegion.Equals(PT_BlobTools[TapNo, 0]))
            //             {
            //                 for(int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
            //                 {
            //                     try
            //                     {
            //                         PT_BlobTools[TapNo, i].Region = new CogRectangle(BlobTrainRegion);
            //                         PT_BlobTools[TapNo, i].RunParams.SegmentationParams.HardFixedThreshold = BLOB_TBAR_THRES.Value;
            //                         PT_BlobTools[TapNo, i].RunParams.ConnectivityMinPixels = (int)NUD_MinPixel.Value;
            //                         PT_BlobTools[TapNo, i].RunParams.SegmentationParams.Polarity = (CogBlobSegmentationPolarityConstants)CB_POLARITY_BLOB.SelectedIndex;
            //                         LABEL_MESSAGE(LB_MESSAGE, "Register OK", System.Drawing.Color.Lime);
            // 
            //                         if (Main.BLOBINSPECTION_USE(CamNo))
            //                         {
            //                             if (m_SelectBlob == 0 || m_SelectBlob == 2 || m_SelectBlob == 4)
            //                             {
            //                                 PT_BlobTools[TapNo, m_SelectBlob + 1].Region = new CogRectangle(BlobTrainRegion);
            //                                 PT_BlobTools[TapNo, m_SelectBlob + 1].RunParams.SegmentationParams.HardFixedThreshold = BLOB_TBAR_THRES.Value;
            //                                 PT_BlobTools[TapNo, m_PatNo_Blob + 1].RunParams.ConnectivityMinPixels = (int)NUD_MinPixel.Value;
            //                                 PT_BlobTools[TapNo, m_PatNo_Blob + 1].RunParams.SegmentationParams.Polarity = (CogBlobSegmentationPolarityConstants)CB_POLARITY_BLOB.SelectedIndex;
            //                             }
            //                         }
            //                     }
            //                     catch (System.Exception ex)
            //                     {
            //                         LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            //                     }
            //                     Main.DisplayFit(PT_Display02);
            //                 }
            //             }
        }
        #endregion

        #region CALIPER 관련
        private void Caliper_Change()
        {
            m_PatchangeFlag = true;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            RefreshDisplay2();

            CB_DIRECTION.SelectedIndex = Main.GetCaliperDirection(PT_CaliperTools[TapNo, m_SelectCaliper].Region.Rotation);
            TBAR_THRES.Value = Convert.ToInt16(PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.ContrastThreshold);
            CB_POLARITY_CALIPER.SelectedIndex = Convert.ToInt16(PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Polarity) - 1;
            CB_CALIPER_USE.Checked = PT_CaliPara[TapNo, m_SelectCaliper].m_UseCheck;

            if (Main.GetCaliperPairMode(PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.EdgeMode))
                CB_EDGEPAIRCHECK.Checked = true;
            else
                CB_EDGEPAIRCHECK.Checked = false;

            CB_COP_MODE_CHECK.Checked = PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode;
            if (PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode)
            {
                label52.Visible = true; LB_DIVIDE_COUNT.Visible = true; BTN_DIVIDECNT_UP.Visible = true; BTN_DIVIDECNT_DOWN.Visible = true;
                label53.Visible = true; LB_DIVIDE_OFFSET.Visible = true; BTN_DIVIDEOFFSET_UP.Visible = true; BTN_DIVIDEOFFSET_DOWN.Visible = true;

                LB_DIVIDE_COUNT.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt.ToString();
                LB_DIVIDE_OFFSET.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset.ToString();
            }
            else
            {
                label52.Visible = false; LB_DIVIDE_COUNT.Visible = false; BTN_DIVIDECNT_UP.Visible = false; BTN_DIVIDECNT_DOWN.Visible = false;
                label53.Visible = false; LB_DIVIDE_OFFSET.Visible = false; BTN_DIVIDEOFFSET_UP.Visible = false; BTN_DIVIDEOFFSET_DOWN.Visible = false;
            }
            //PTCaliperRegion.Changed += new CogChangedEventHandler(PT_COP_Caliper_Redraw);

            Main.DisplayClear(PT_CALIPER_SUB_Display);
            PT_CALIPER_SUB_Display.Image = null;
            DrawCaliperRegion();
            m_PatchangeFlag = false;
            if (PT_DISPLAY_CONTROL.CrossLineChecked) CrossLine();
        }
        private void DrawCaliperRegion()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_CALIPERTOOL)
            {
                DisplayClear();
                PTCaliperRegion = new CogRectangleAffine(PT_CaliperTools[TapNo, m_SelectCaliper].Region);
                if (PT_Caliper_MarkUSE[TapNo])
                {
                    PTCaliperRegion.CenterX = PatResult.TranslationX + PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                    PTCaliperRegion.CenterY = PatResult.TranslationY + PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                }
                PTCaliperRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                PTCaliperRegion.Interactive = true;
                PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);

                if (PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode && PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt > 0)
                {
                    PTCaliperRegion.GraphicDOFEnable |= CogRectangleAffineDOFConstants.Skew;

                    PTCaliperDividedRegion = new CogRectangleAffine[PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt];

                    double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * 2));
                    double dNewY = PTCaliperRegion.CenterY;

                    for (int i = 0; i < PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt; i++)
                    {
                        PTCaliperDividedRegion[i] = new CogRectangleAffine(PT_CaliperTools[TapNo, m_SelectCaliper].Region);

                        double dX = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Cos(PTCaliperRegion.Rotation);
                        double dY = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Sin(PTCaliperRegion.Rotation);

                        PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt;
                        PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                        PT_Display01.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
                    }
                }

                Main.DisplayFit(PT_Display01);
            }
        }

        private void PT_COP_Caliper_Redraw(Object sender, EventArgs e)
        {
            double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * 2));
            double dNewY = PTCaliperRegion.CenterY;

            for (int i = 0; i < PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt; i++)
            {
                PTCaliperDividedRegion[i] = new CogRectangleAffine(PT_CaliperTools[TapNo, m_SelectCaliper].Region);

                double dX = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Cos(PTCaliperRegion.Rotation);
                double dY = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Sin(PTCaliperRegion.Rotation);

                PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt;
                PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                PT_Display01.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
            }
        }

        private void RBTN_CALIPER_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }
        private void BTN_CALIPER_CHANGE_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            int m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2));

            if (TempBTN.Checked)
            {
                m_SelectCaliper = m_Number;
                Caliper_Change();
            }
        }
        private void CB_CALIPER_MARKUSE_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            if (TempBTN.Checked)
            {
                TempBTN.BackColor = System.Drawing.Color.GreenYellow;
                PT_Caliper_MarkUSE[TapNo] = true;
            }
            else
            {
                TempBTN.BackColor = System.Drawing.Color.White;
                PT_Caliper_MarkUSE[TapNo] = false;
            }

            if (!m_TABCHANGE_MODE)
            {
                RefreshDisplay2();
                DrawCaliperRegion();
            }
        }
        public static void DrawLastRegionData(CogRecordDisplay Display, CogCaliperTool CaliperTool)
        {
            try
            {
                Main.DisplayClear(Display);

                CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.TransformedRegionPixels;
                CaliperTool.LastRunRecordEnable = CogCaliperLastRunRecordConstants.FilteredProjectionGraph | CogCaliperLastRunRecordConstants.Edges2; //ProjectionGraph

                for (int i = 0; i < CaliperTool.CreateLastRunRecord().SubRecords.Count; i++)
                {
                    if (CaliperTool.CreateLastRunRecord().SubRecords[i].Annotation == "RegionData")
                        Display.Record = CaliperTool.CreateLastRunRecord().SubRecords[i];
                }
                //                  Display.Record = CaliperTool.CreateLastRunRecord();                
                //                  CogAffineTransformTool Copytool = new CogAffineTransformTool();
                //                  Copytool.InputImage = CaliperTool.InputImage;
                //                  Copytool.Region = CaliperTool.Region;               
                //                  Copytool.Run();
                //                  Display.Image = Copytool.OutputImage;
                DisplayFit(Display);
            }
            catch
            {

            }

        }
        private void CALIPER_PAIR_SET()
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {

            }
            else
            {
                double MaxSize = 100;
                switch (Main.GetCaliperDirection(Main.GetCaliperDirection(PT_CaliperTools[TapNo, m_SelectCaliper].Region.Rotation)))
                {
                    case Main.DEFINE.X:
                        MaxSize = PT_CaliperTools[TapNo, m_SelectCaliper].Region.SideXLength;
                        MaxSize = 5; // 길이고정 17.01.13
                        break;
                    case Main.DEFINE.Y:
                        MaxSize = PT_CaliperTools[TapNo, m_SelectCaliper].Region.SideYLength;
                        MaxSize = 12; // 길이고정 17.01.13
                        break;
                    default:
                        break;
                }
                //            MaxSize = MaxSize / 2;
                //            MaxSize = 5; // 길이고정 17.01.13
                PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Position = Convert.ToInt16(-MaxSize);
                PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge1Position = Convert.ToInt16(+MaxSize);
            }

            Main.SetCaliperPairPolarity(PT_CaliperTools[TapNo, m_SelectCaliper]);
        }
        private void BTN_CALIPER_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (PTCaliperRegion != null)
                {
                    if (PT_Caliper_MarkUSE[TapNo])
                    {
                        PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X = PTCaliperRegion.CenterX - PatResult.TranslationX;
                        PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y = PTCaliperRegion.CenterY - PatResult.TranslationY;
                    }

                    PT_CaliperTools[TapNo, m_SelectCaliper].Region = new CogRectangleAffine(PTCaliperRegion);
                    PT_CaliperTools[TapNo, m_SelectCaliper].Region.Rotation = Main.SetCaliperDirection(CB_DIRECTION.SelectedIndex);
                    PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.ContrastThreshold = TBAR_THRES.Value;
                    PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_POLARITY_CALIPER.SelectedIndex + 1);
                    if (Main.GetCaliperPairMode(PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.EdgeMode))
                        CALIPER_PAIR_SET();
                    else
                        PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Position = 0;

                    if (PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode && PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt > 0)
                    {
                        DisplayClear();
                        PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
                        PTCaliperRegion.GraphicDOFEnable |= CogRectangleAffineDOFConstants.Skew;

                        PTCaliperDividedRegion = new CogRectangleAffine[PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt];

                        double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * 2));
                        double dNewY = PTCaliperRegion.CenterY;

                        for (int i = 0; i < PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt; i++)
                        {
                            PTCaliperDividedRegion[i] = new CogRectangleAffine(PT_CaliperTools[TapNo, m_SelectCaliper].Region);

                            double dX = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Cos(PTCaliperRegion.Rotation);
                            double dY = PTCaliperRegion.SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt * i * Math.Sin(PTCaliperRegion.Rotation);

                            PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt;
                            PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                            PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                            PT_Display01.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
                        }
                    }

                    LABEL_MESSAGE(LB_MESSAGE, "Register OK", System.Drawing.Color.Lime);
                }
                else
                    LABEL_MESSAGE(LB_MESSAGE, "Select!!! Caliper", System.Drawing.Color.Red);
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }

            Main.DisplayFit(PT_Display01);
        }
        private void TBAR_THRES_ValueChanged(object sender, EventArgs e)
        {
            PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.ContrastThreshold = TBAR_THRES.Value;
            LB_THRES.Text = TBAR_THRES.Value.ToString();
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_CALIPERTOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BTN_THRES_UP_Click(object sender, EventArgs e)
        {
            if (TBAR_THRES.Maximum == TBAR_THRES.Value) return;
            TBAR_THRES.Value++;
        }
        private void BTN_THRES_DN_Click(object sender, EventArgs e)
        {
            if (TBAR_THRES.Minimum == TBAR_THRES.Value) return;
            TBAR_THRES.Value--;
        }
        private void CB_POLARITY_CALIPER_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_POLARITY_CALIPER.SelectedIndex + 1);
        }
        private void CB_DIRECTION_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_CaliperTools[TapNo, m_SelectCaliper].Region.Rotation = Main.SetCaliperDirection(CB_DIRECTION.SelectedIndex);
            if (!m_TABCHANGE_MODE)
            {
                DrawCaliperRegion();
            }
        }
        private void CB_USECHECK_Click(object sender, EventArgs e)
        {
            if (CB_CALIPER_USE.Checked)
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_UseCheck = true;
            }
            else
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_UseCheck = false;
            }
        }
        private void CB_USECHECK_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_CALIPER_USE.Checked)
            {

                CB_CALIPER_USE.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_CALIPER_USE.BackColor = System.Drawing.Color.DarkGray;
            }
        }
        private void CB_EDGEPAIRCHECK_Click(object sender, EventArgs e)
        {
            if (CB_EDGEPAIRCHECK.Checked)
            {
                //                PT_CaliPara[TapNo, m_SelectCaliper].m_UsePairCheck = true;
                PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                CALIPER_PAIR_SET();
            }
            else
            {
                //                PT_CaliPara[TapNo, m_SelectCaliper].m_UsePairCheck = false;
                PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.Edge0Position = 0;
            }
        }
        private void CB_EDGEPAIRCHECK_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_EDGEPAIRCHECK.Checked)
            {
                CB_EDGEPAIRCHECK.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_EDGEPAIRCHECK.BackColor = System.Drawing.Color.DarkGray;
            }
        }
        #endregion

        #region FINDLine 관련
        private void FINDLINE_Change()
        {
            m_PatchangeFlag = true;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            m_CamNo = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo;
            Light_Select();
            RefreshDisplay2();

            PT_FindLineTool = new CogFindLineTool(PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine]);
            PT_LineMaxTool = new CogLineMaxTool(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine]);
            PT_FindLineTool.RunParams.Changed += new Cognex.VisionPro.CogChangedEventHandler(PT_LineSegment_Change);
            PT_LineMaxTool.RunParams.ExpectedLineNormal.Changed += new Cognex.VisionPro.CogChangedEventHandler(PT_LineSegment_Change);
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
            {
                // Direction
                label26.Visible = true; BTN_FINDLINE_REVERSE.Visible = false;
                // Caliper Count
                label20.Visible = false; LB_FINDLINE_CNT.Visible = false; BTN_FINDLINE_CNT_UP.Visible = false; BTN_FINDLINE_CNT_DN.Visible = false;
                // Ignore Count
                label24.Visible = false; NUD_IGNORE_CNT.Visible = false;
                // Filter Half Size
                label28.Visible = false; NUD_FILTERHALFSIZE.Visible = false;
                // Caliper Method
                label48.Visible = false; RBTN_CALIPER_METHOD_SCORE.Visible = false; RBTN_CALIPER_METHOD_POS.Visible = false;

                label37.Visible = true; NUD_ANGLE_TOLERANCE.Visible = true;
                label39.Visible = true; NUD_DIST_TOLERANCE.Visible = true;
                //label40.Visible = true; NUD_MAX_LINENUM.Visible = true; label40.Location = new System.Drawing.Point(267, 255); NUD_MAX_LINENUM.Location = new System.Drawing.Point(368, 256);
                label41.Visible = true; NUD_LINE_ANGLE_TOL.Visible = true;
                label42.Visible = true; NUD_COVERAGE_THRES.Visible = true;
                label43.Visible = true; NUD_LENGTH_THRES.Visible = true;
                label44.Visible = true; NUD_GRADIENT_KERNEL_SIZE.Visible = true; label44.Location = new System.Drawing.Point(267, 169); NUD_GRADIENT_KERNEL_SIZE.Location = new System.Drawing.Point(368, 169);
                label45.Visible = true; NUD_PROJECTION_LENGTH.Visible = true; label45.Location = new System.Drawing.Point(267, 213); NUD_PROJECTION_LENGTH.Location = new System.Drawing.Point(368, 214);
                NUD_LINE_NORMAL_ANGLE.Visible = true; NUD_LINE_NORMAL_ANGLE.Location = new System.Drawing.Point(368, 85);

                try
                {
                    TBAR_FINDLINE_THRES.Value = Convert.ToInt16(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.ContrastThreshold);
                    CB_FINDLINE_POLARITY.SelectedIndex = Convert.ToInt16(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.Polarity) - 1;    // CogLineMaxPolarityConstants
                    NUD_LINE_NORMAL_ANGLE.Value = (decimal)(int)(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.ExpectedLineNormal.Angle * Main.DEFINE.degree);
                    NUD_GRADIENT_KERNEL_SIZE.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels;
                    NUD_PROJECTION_LENGTH.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.ProjectionLengthInPixels;
                    NUD_MAX_LINENUM.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.MaxNumLines;
                    CB_FINDLINE_USE.Checked = PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck;
                    NUD_ANGLE_TOLERANCE.Value = (decimal)(int)(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeAngleTolerance * Main.DEFINE.degree);
                    NUD_DIST_TOLERANCE.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.DistanceTolerance;
                    NUD_LINE_ANGLE_TOL.Value = (decimal)(int)(PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.LineAngleTolerance * Main.DEFINE.degree);
                    NUD_COVERAGE_THRES.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CoverageThreshold;
                    NUD_LENGTH_THRES.Value = (decimal)PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.LengthThreshold;

                    if (PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.MaxNumLines > 1)
                    {
                        //label46.Visible = true; RBTN_HORICON_YMIN.Visible = true; RBTN_HORICON_YMAX.Visible = true;
                        //label47.Visible = true; RBTN_VERTICON_XMIN.Visible = true; RBTN_VERTICON_XMAX.Visible = true;

                        //RBTN_LINEMAX_H_COND[PT_FindLinePara[TapNo, m_SelectFindLine].m_LineMaxHCond].Checked = true;
                        //RBTN_LINEMAX_V_COND[PT_FindLinePara[TapNo, m_SelectFindLine].m_LineMaxVCond].Checked = true;
                    }
                    else
                    {
                        //label46.Visible = false; RBTN_HORICON_YMIN.Visible = false; RBTN_HORICON_YMAX.Visible = false;
                        //label47.Visible = false; RBTN_VERTICON_XMIN.Visible = false; RBTN_VERTICON_XMAX.Visible = false;
                    }
                }
                catch (System.ArgumentException)
                {

                }
            }
            else
            {
                // Direction
                label26.Visible = true; BTN_FINDLINE_REVERSE.Visible = true;
                // Caliper Count
                label20.Visible = true; LB_FINDLINE_CNT.Visible = true; BTN_FINDLINE_CNT_UP.Visible = true; BTN_FINDLINE_CNT_DN.Visible = true;
                // Ignore Count
                label24.Visible = true; NUD_IGNORE_CNT.Visible = true;
                // Filter Half Size
                label28.Visible = true; NUD_FILTERHALFSIZE.Visible = true;
                // Caliper Method
                label48.Visible = true; RBTN_CALIPER_METHOD_SCORE.Visible = true; RBTN_CALIPER_METHOD_POS.Visible = true;
                label48.Location = new System.Drawing.Point(267, 383); RBTN_CALIPER_METHOD_SCORE.Location = new System.Drawing.Point(367, 382); RBTN_CALIPER_METHOD_POS.Location = new System.Drawing.Point(505, 382);

                label37.Visible = false; NUD_ANGLE_TOLERANCE.Visible = false;
                label39.Visible = false; NUD_DIST_TOLERANCE.Visible = false;
                //label40.Visible = false; NUD_MAX_LINENUM.Visible = false;
                label41.Visible = false; NUD_LINE_ANGLE_TOL.Visible = false;
                label42.Visible = false; NUD_COVERAGE_THRES.Visible = false;
                label43.Visible = false; NUD_LENGTH_THRES.Visible = false;
                label44.Visible = false; NUD_GRADIENT_KERNEL_SIZE.Visible = false;
                label45.Visible = false; NUD_PROJECTION_LENGTH.Visible = false;
                NUD_LINE_NORMAL_ANGLE.Visible = false;

                try
                {
                    TBAR_FINDLINE_THRES.Value = Convert.ToInt16(PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.ContrastThreshold);
                    CB_FINDLINE_POLARITY.SelectedIndex = Convert.ToInt16(PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge0Polarity) - 1;
                    LB_FINDLINE_CNT.Text = PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.NumCalipers.ToString();
                    CB_FINDLINE_USE.Checked = PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck;
                    CB_FINDLINE_PAIR_USE.Checked = PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck;
                    NUD_FILTERHALFSIZE.Value = (decimal)PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.FilterHalfSizeInPixels;
                    NUD_IGNORE_CNT.Value = (decimal)PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.NumToIgnore;
                    if (PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck == true)
                    {
                        CB_FINDLINE_1_POLARITY.SelectedIndex = Convert.ToInt16(PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge1Polarity) - 1;
                    }

                    if (PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod == Main.DEFINE.CLP_METHOD_SCORE)
                    {
                        RBTN_CALIPER_METHOD_SCORE.Checked = true;
                    }
                    else if (PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod == Main.DEFINE.CLP_METHOD_POS)
                    {
                        RBTN_CALIPER_METHOD_POS.Checked = true;
                    }
                }
                catch (System.ArgumentException)
                {

                }
            }

            if (m_SelectFindLine >= 2)
            {
                CB_FINDLINE_SUBLINE.Enabled = false;
                CB_FINDLINE_SUBLINE.SelectedIndex = m_LineSubNo = 0;
            }
            else
                CB_FINDLINE_SUBLINE.Enabled = true;

            PT_DISPLAY_CONTROL.Resuloution = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CalX[0];
            Main.DisplayClear(PT_FINDLINE_SUB_Display);
            PT_FINDLINE_SUB_Display.Image = null;
            DrawFINDLineRegion();
            m_PatchangeFlag = false;
            PT_DISPLAY_CONTROL.DisplayFit();
            timer2.Enabled = true;
        }
        private void DrawFINDLineRegion()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            {
                DisplayClear();
                if (PT_FindLine_MarkUSE[TapNo])
                {
                    if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                    {
                        (PT_LineMaxTool.Region as CogRectangleAffine).CenterX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        (PT_LineMaxTool.Region as CogRectangleAffine).CenterY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }
                    else
                    {
                        PT_FindLineTool.RunParams.ExpectedLineSegment.StartX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        PT_FindLineTool.RunParams.ExpectedLineSegment.StartY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;

                        PT_FindLineTool.RunParams.ExpectedLineSegment.EndX = PatResult.TranslationX + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X2;
                        PT_FindLineTool.RunParams.ExpectedLineSegment.EndY = PatResult.TranslationY + PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y2;
                    }
                }

                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                {
                    PT_LineMaxTool.CurrentRecordEnable = CogLineMaxCurrentRecordConstants.All;
                    (PT_LineMaxTool.Region as CogRectangleAffine).GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size;
                    (PT_LineMaxTool.Region as CogRectangleAffine).Interactive = true;
                    //PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
                    PT_Display01.Record = PT_LineMaxTool.CreateCurrentRecord();
                }
                else
                {
                    PT_FindLineTool.CurrentRecordEnable = CogFindLineCurrentRecordConstants.All;
                    PT_Display01.Record = PT_FindLineTool.CreateCurrentRecord();
                }
                Main.DisplayFit(PT_Display01);
            }
        }
        private void RBTN_Button_Color_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }
        private void RBTN_FINDLINE_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            if (TempBTN.Name == "RBTN_FINDLINE_CIRCLE") // 200624 JHKIM 원호 추가
            {
                TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDCIRCLETOOL;
                Circle_Change();
            }
            else
            {
                int m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2));

                if (TempBTN.Checked)
                {
                    m_SelectFindLine = m_Number;
                    FINDLINE_Change();
                }
            }
        }
        private void CB_FINDLINE_MARK_USE_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            if (TempBTN.Checked)
            {
                TempBTN.BackColor = System.Drawing.Color.GreenYellow;
                PT_FindLine_MarkUSE[TapNo] = true;
            }
            else
            {
                TempBTN.BackColor = System.Drawing.Color.White;
                PT_FindLine_MarkUSE[TapNo] = false;
            }
            if (!m_TABCHANGE_MODE)
            {
                RefreshDisplay2();
                DrawFINDLineRegion();
            }
        }
        public static void DrawFINDLineLastRegionData(CogRecordDisplay Display, CogFindLineTool FINDLineTool)
        {
            try
            {
                Main.DisplayClear(Display);
                CogFindLineTool tempTool = new CogFindLineTool(FINDLineTool);

                tempTool.LastRunRecordDiagEnable = CogFindLineLastRunRecordDiagConstants.All;
                tempTool.LastRunRecordEnable = CogFindLineLastRunRecordConstants.FilteredProjectionGraph | CogFindLineLastRunRecordConstants.BestFitLine;
                Display.Record = tempTool.CreateLastRunRecord();
                DisplayFit(Display);
            }
            catch
            {

            }
        }
        public static void DrawFINDLineLastRegionData(CogRecordDisplay Display, CogLineMaxTool LineMaxTool)
        {
            try
            {
                Main.DisplayClear(Display);
                CogLineMaxTool tempTool = new CogLineMaxTool(LineMaxTool);

                tempTool.LastRunRecordDiagEnable = CogLineMaxLastRunRecordDiagConstants.All;
                tempTool.LastRunRecordEnable = CogLineMaxLastRunRecordConstants.All;
                Display.Record = tempTool.CreateLastRunRecord();
                DisplayFit(Display);
            }
            catch
            {

            }

        }
        private void BTN_FINDLINE_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                {
                    if (PT_FindLine_MarkUSE[TapNo])
                    {
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X = (PT_LineMaxTool.Region as CogRectangleAffine).CenterX - PatResult.TranslationX;
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y = (PT_LineMaxTool.Region as CogRectangleAffine).CenterY - PatResult.TranslationY;
                    }

                    if (m_SelectFindLine == 2 && PT_FindLinePara[TapNo, m_LineSubNo, 0].m_UseCheck == true && PT_FindLinePara[TapNo, m_LineSubNo, 1].m_UseCheck)
                    {
                        PT_LineMaxTools[TapNo, m_LineSubNo, 0].Run();
                        PT_LineMaxTools[TapNo, m_LineSubNo, 1].Run();

                        int nLineIdx1 = 0, nLineIdx2 = 0;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(0, PT_FindLinePara[TapNo, m_LineSubNo, 0], PT_LineMaxTools[TapNo, m_LineSubNo, 0], ref nLineIdx1);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(1, PT_FindLinePara[TapNo, m_LineSubNo, 1], PT_LineMaxTools[TapNo, m_LineSubNo, 1], ref nLineIdx2);

                        if ((PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results[0].GetLine() != null)
                            && (PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results != null && PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results.Count > 0 && PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results[0].GetLine() != null))
                        {
                            PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                            PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                            PT_LineLineCrossPoints[0].LineA = PT_LineMaxTools[TapNo, m_LineSubNo, 0].Results[nLineIdx1].GetLine();
                            PT_LineLineCrossPoints[0].LineB = PT_LineMaxTools[TapNo, m_LineSubNo, 1].Results[nLineIdx2].GetLine();
                            PT_LineLineCrossPoints[0].Run();
                            if (PT_LineLineCrossPoints[0].Intersects)
                            {
                                if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                                {
                                    Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X = (PT_LineMaxTool.Region as CogRectangleAffine).CenterX - PT_LineLineCrossPoints[0].X;
                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y = (PT_LineMaxTool.Region as CogRectangleAffine).CenterY - PT_LineLineCrossPoints[0].Y;
                                }
                            }
                        }
                    }

                    PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine] = new CogLineMaxTool(PT_LineMaxTool);

                    try
                    {
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.ContrastThreshold = TBAR_FINDLINE_THRES.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.Polarity = (CogLineMaxPolarityConstants)(CB_FINDLINE_POLARITY.SelectedIndex + 1);
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.ExpectedLineNormal.Angle = (double)NUD_LINE_NORMAL_ANGLE.Value * Main.DEFINE.radian;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.GradientKernelSizeInPixels = (int)NUD_GRADIENT_KERNEL_SIZE.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.ProjectionLengthInPixels = (int)NUD_PROJECTION_LENGTH.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.MaxNumLines = (int)NUD_MAX_LINENUM.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeAngleTolerance = (double)NUD_ANGLE_TOLERANCE.Value * Main.DEFINE.radian;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.DistanceTolerance = (int)NUD_DIST_TOLERANCE.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.LineAngleTolerance = (double)NUD_LINE_ANGLE_TOL.Value * Main.DEFINE.radian;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CoverageThreshold = (double)NUD_COVERAGE_THRES.Value;
                        PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.LengthThreshold = (int)NUD_LENGTH_THRES.Value;

                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck = CB_FINDLINE_USE.Checked;
                    }
                    catch (System.ArgumentException)
                    {

                    }

                    LABEL_MESSAGE(LB_MESSAGE, "LineMax Register OK", System.Drawing.Color.Lime);
                }   // LineMaxTool
                else if (PT_FindLineTools != null)
                {
                    if (PT_FindLine_MarkUSE[TapNo])
                    {
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X = PT_FindLineTool.RunParams.ExpectedLineSegment.StartX - PatResult.TranslationX;
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y = PT_FindLineTool.RunParams.ExpectedLineSegment.StartY - PatResult.TranslationY;

                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X2 = PT_FindLineTool.RunParams.ExpectedLineSegment.EndX - PatResult.TranslationX;
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y2 = PT_FindLineTool.RunParams.ExpectedLineSegment.EndY - PatResult.TranslationY;
                    }

                    if (m_SelectFindLine == 2 && PT_FindLinePara[TapNo, m_LineSubNo, 0].m_UseCheck == true && PT_FindLinePara[TapNo, m_LineSubNo, 1].m_UseCheck)
                    {
                        PT_FindLineTools[TapNo, m_LineSubNo, 0].Run();
                        PT_FindLineTools[TapNo, m_LineSubNo, 1].Run();

                        if ((PT_FindLineTools[TapNo, m_LineSubNo, 0].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.GetLine() != null)
                            && (PT_FindLineTools[TapNo, m_LineSubNo, 1].Results != null && PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.Count > 0 && PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.GetLine() != null))
                        {
                            PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                            PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                            PT_LineLineCrossPoints[0].LineA = PT_FindLineTools[TapNo, m_LineSubNo, 0].Results.GetLine();
                            PT_LineLineCrossPoints[0].LineB = PT_FindLineTools[TapNo, m_LineSubNo, 1].Results.GetLine();
                            PT_LineLineCrossPoints[0].Run();
                            if (PT_LineLineCrossPoints[0].Intersects)
                            {
                                if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                                {
                                    Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X = PT_FindLineTool.RunParams.ExpectedLineSegment.StartX - PT_LineLineCrossPoints[0].X;
                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y = PT_FindLineTool.RunParams.ExpectedLineSegment.StartY - PT_LineLineCrossPoints[0].Y;

                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X2 = PT_FindLineTool.RunParams.ExpectedLineSegment.EndX - PT_LineLineCrossPoints[0].X;
                                    PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y2 = PT_FindLineTool.RunParams.ExpectedLineSegment.EndY - PT_LineLineCrossPoints[0].Y;
                                }
                            }
                        }
                    }

                    PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine] = new CogFindLineTool(PT_FindLineTool);

                    try
                    {
                        PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.ContrastThreshold = TBAR_FINDLINE_THRES.Value;
                        PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_FINDLINE_POLARITY.SelectedIndex + 1);
                        PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.NumCalipers = Convert.ToInt16(LB_FINDLINE_CNT.Text);
                        PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.FilterHalfSizeInPixels = (int)NUD_FILTERHALFSIZE.Value;
                        PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.NumToIgnore = (int)NUD_IGNORE_CNT.Value;
                        if (PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck == true)
                            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge1Polarity = (CogCaliperPolarityConstants)(CB_FINDLINE_1_POLARITY.SelectedIndex + 1);

                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck = CB_FINDLINE_USE.Checked;
                        PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck = CB_FINDLINE_PAIR_USE.Checked;

                        if (RBTN_CALIPER_METHOD_SCORE.Checked == true)
                        {
                            PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod = Main.DEFINE.CLP_METHOD_SCORE;
                            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                            CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                            scorer.Enabled = true;
                            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                        }
                        else if (RBTN_CALIPER_METHOD_POS.Checked == true)
                        {
                            PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod = Main.DEFINE.CLP_METHOD_POS;
                            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                            CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                            scorer.Enabled = true;
                            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                        }
                    }
                    catch (System.ArgumentException)
                    {

                    }

                    LABEL_MESSAGE(LB_MESSAGE, "FindLine Register OK", System.Drawing.Color.Lime);
                }   // PT_FineLineTools != null
                else
                    LABEL_MESSAGE(LB_MESSAGE, "Select!!! FINDLine", System.Drawing.Color.Red);
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }

            Main.DisplayFit(PT_Display01);
        }

        #region
        private void TBAR_FINDLINE_THRES_ValueChanged(object sender, EventArgs e)
        {
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.EdgeDetectionParams.ContrastThreshold = TBAR_FINDLINE_THRES.Value;
            else
                PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.ContrastThreshold = TBAR_FINDLINE_THRES.Value;
            LB_FINDLINE_THRES.Text = TBAR_FINDLINE_THRES.Value.ToString();
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BTN_FINDLINE_THRES_UP_Click(object sender, EventArgs e)
        {
            if (TBAR_FINDLINE_THRES.Maximum == TBAR_FINDLINE_THRES.Value) return;

            TBAR_FINDLINE_THRES.Value++;
        }
        private void BTN_FINDLINE_THRES_DN_Click(object sender, EventArgs e)
        {
            if (TBAR_FINDLINE_THRES.Minimum == TBAR_FINDLINE_THRES.Value) return;

            TBAR_FINDLINE_THRES.Value--;
        }
        private void NUD_GUIDEDISX_ValueChanged(object sender, EventArgs e)
        {
            PT_TRAY_GUIDE_DISX[TapNo] = Convert.ToInt32(NUD_GUIDEDISX.Value);
            if (!NUD_Initial_Flag) FirstPocketPos.X = PT_TRAY_GUIDE_DISX[TapNo];
        }
        private void NUD_GUIDEDISY_ValueChanged(object sender, EventArgs e)
        {
            PT_TRAY_GUIDE_DISY[TapNo] = Convert.ToInt32(NUD_GUIDEDISY.Value);
            if (!NUD_Initial_Flag) FirstPocketPos.Y = PT_TRAY_GUIDE_DISY[TapNo];
        }
        private void NUD_PITCHDISX_ValueChanged(object sender, EventArgs e)
        {
            PT_TRAY_PITCH_DISX[TapNo] = Convert.ToInt32(NUD_PITCHDISX.Value);
            if (!NUD_Initial_Flag) X_PocketPitchPos.X = FirstPocketPos.X + PT_TRAY_PITCH_DISX[TapNo];
        }
        private void NUD_PITCHDISY_ValueChanged(object sender, EventArgs e)
        {
            PT_TRAY_PITCH_DISY[TapNo] = Convert.ToInt32(NUD_PITCHDISY.Value);
            if (!NUD_Initial_Flag) Y_PocketPitchPos.Y = FirstPocketPos.Y + PT_TRAY_PITCH_DISY[TapNo];
        }
        private void PT_LineSegment_Change(Object sender, EventArgs e)
        {
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
            {
                NUD_LINE_NORMAL_ANGLE.Value = (decimal)(int)(PT_LineMaxTool.RunParams.ExpectedLineNormal.Angle * Main.DEFINE.degree);
            }
        }
        private void CB_FINDLINE_POLARITY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                PT_LineMaxTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.Polarity = (CogLineMaxPolarityConstants)(CB_FINDLINE_POLARITY.SelectedIndex + 1);
            else
                PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_FINDLINE_POLARITY.SelectedIndex + 1);
        }
        private void CB_FINDLINE_1_POLARITY_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge1Polarity = (CogCaliperPolarityConstants)(CB_FINDLINE_1_POLARITY.SelectedIndex + 1);
        }
        private void CB_FINDLINE_USE_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_FINDLINE_USE.Checked)
            {
                CB_FINDLINE_USE.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_FINDLINE_USE.BackColor = System.Drawing.Color.DarkGray;
            }
        }
        private void CB_FINDLINE_USE_Click(object sender, EventArgs e)
        {
            if (CB_FINDLINE_USE.Checked)
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck = true;
            }
            else
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UseCheck = false;
            }
        }
        private void CB_FINDLINE_PAIR_USE_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_FINDLINE_PAIR_USE.Checked)
            {
                CB_FINDLINE_1_POLARITY.Enabled = true;
                PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                CB_FINDLINE_PAIR_USE.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_FINDLINE_1_POLARITY.Enabled = false;
                PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                CB_FINDLINE_PAIR_USE.BackColor = System.Drawing.Color.DarkGray;
            }
        }
        private void CB_FINDLINE_PAIR_USE_Click(object sender, EventArgs e)
        {
            if (CB_FINDLINE_PAIR_USE.Checked)
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck = true;
            }
            else
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_UsePairCheck = false;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge0Position = (double)CB_FINDLINE_POSITION.Value / -2;
            PT_FindLineTools[TapNo, m_LineSubNo, m_SelectFindLine].RunParams.CaliperRunParams.Edge1Position = (double)CB_FINDLINE_POSITION.Value / 2;

            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BTN_FINDLINE_REVERSE_Click(object sender, EventArgs e)
        {
            //      PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.CaliperSearchDirection *= (-1);
            PT_FindLineTool.RunParams.CaliperSearchDirection *= (-1);
            DrawFINDLineRegion();
        }
        private void NUD_IGNORE_CNT_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //  PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.NumToIgnore = (int)NUD_IGNORE_CNT.Value;
                PT_FindLineTool.RunParams.NumToIgnore = (int)NUD_IGNORE_CNT.Value;
            }
            catch (System.ArgumentException)
            {

            }
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void NUD_FILTERHALFSIZE_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //     PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.CaliperRunParams.FilterHalfSizeInPixels = (int)NUD_FILTERHALFSIZE.Value;
                PT_FindLineTool.RunParams.CaliperRunParams.FilterHalfSizeInPixels = (int)NUD_FILTERHALFSIZE.Value;
            }
            catch (System.ArgumentException)
            {

            }
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BTN_FINDLINE_CNT_UP_Click(object sender, EventArgs e)
        {
            try
            {
                // PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.NumCalipers++;
                // LB_FINDLINE_CNT.Text = PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.NumCalipers.ToString();

                PT_FindLineTool.RunParams.NumCalipers++;
                LB_FINDLINE_CNT.Text = PT_FindLineTool.RunParams.NumCalipers.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DrawFINDLineRegion();
        }
        private void BTN_FINDLINE_CNT_DN_Click(object sender, EventArgs e)
        {
            try
            {
                // PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.NumCalipers--;
                // LB_FINDLINE_CNT.Text = PT_FindLineTools[TapNo, m_SelectFindLine].RunParams.NumCalipers.ToString();

                PT_FindLineTool.RunParams.NumCalipers--;
                LB_FINDLINE_CNT.Text = PT_FindLineTool.RunParams.NumCalipers.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DrawFINDLineRegion();
        }
        #endregion
        #endregion

        #region CIRCLE
        private void RBTN_CIRCLE_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Name != "RBTN_CIRCLE00") // 200624 JHKIM 원호 추가
            {
                TABC_MANU.SelectedIndex = Main.DEFINE.M_FINDLINETOOL;
                FINDLINE_Change();
            }
            else
            {
                int m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2));

                if (TempBTN.Checked)
                {
                    m_SelectCircle = m_Number;
                    m_PatchangeFlag = true;
                    Circle_Change();

                    CB_CIRCLE_USE.Checked = PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck;
                    m_PatchangeFlag = false;
                }
            }
        }
        private void Circle_Change()
        {
            m_PatchangeFlag = true;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            RefreshDisplay2();
            PT_CircleTool = new CogFindCircleTool(PT_CircleTools[TapNo, m_SelectCircle]);
            PT_CircleTool.RunParams.Changed += new Cognex.VisionPro.CogChangedEventHandler(PT_Circle_params_Change);


            CB_CIRCLE_USE.Checked = PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck;

            CB_DIRECTION_CIR.SelectedIndex = Convert.ToInt16(PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperSearchDirection);
            TBAR_THRES_CIR.Value = Convert.ToInt16(PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.ContrastThreshold);
            CB_POLARITY_CIR.SelectedIndex = Convert.ToInt16(PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.Edge0Polarity) - 1;
            LB_CIRCLE_CNT.Text = PT_CircleTools[TapNo, m_SelectCircle].RunParams.NumCalipers.ToString();
            NUD_CIRCLE_IGNCNT.Value = (decimal)PT_CircleTools[TapNo, m_SelectCircle].RunParams.NumToIgnore;
            LB_SEARCH_CIR.Text = PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperSearchLength.ToString();
            LB_PROJECTION_CIR.Text = PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperProjectionLength.ToString();
            LB_RADIUS_CIR.Text = PT_CircleTools[TapNo, m_SelectCircle].RunParams.ExpectedCircularArc.Radius.ToString();

            if (PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod == Main.DEFINE.CLP_METHOD_SCORE)
            {
                RBTN_CIR_CALIPER_METHOD_SCORE.Checked = true;
            }
            else if (PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod == Main.DEFINE.CLP_METHOD_POS)
            {
                RBTN_CIR_CALIPER_METHOD_POS.Checked = true;
            }

            PT_CIRCLE_SUB_Display.Image = null;
            Main.DisplayClear(PT_CIRCLE_SUB_Display);
            DrawCircleRegion();
            m_PatchangeFlag = false;
        }
        private void DrawCircleRegion()
        {
            if (TABC_MANU.SelectedIndex == Main.DEFINE.M_FINDCIRCLETOOL)
            {
                DisplayClear();
                if (PT_Circle_MarkUSE[TapNo])
                {
                    PT_CircleTool.RunParams.ExpectedCircularArc.CenterX = PatResult.TranslationX + PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                    PT_CircleTool.RunParams.ExpectedCircularArc.CenterY = PatResult.TranslationY + PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                }
                PT_CircleTool.RunParams.ExpectedCircularArc.Color = CogColorConstants.Purple;
                PT_CircleTool.RunParams.ExpectedCircularArc.DragColor = CogColorConstants.Purple;
                PT_Display01.Record = PT_CircleTool.CreateCurrentRecord();
                Main.DisplayFit(PT_Display01);
            }
        }
        public static void DrawLastRegionData(CogRecordDisplay Display, CogFindCircleTool CircleTool)
        {
            try
            {
                Main.DisplayClear(Display);

                for (int i = 0; i < CircleTool.CreateLastRunRecord().SubRecords.Count; i++)
                {
                    if (CircleTool.CreateLastRunRecord().SubRecords[i].Annotation == "RegionData_Caliper0")
                        Display.Record = CircleTool.CreateLastRunRecord().SubRecords[i];
                }
                Main.DisplayFit(Display);
            }
            catch
            {

            }

        }
        private void PT_Circle_params_Change(Object sender, EventArgs e)
        {
            LB_SEARCH_CIR.Text = PT_CircleTool.RunParams.CaliperSearchLength.ToString();
            LB_PROJECTION_CIR.Text = PT_CircleTool.RunParams.CaliperProjectionLength.ToString();
            LB_RADIUS_CIR.Text = PT_CircleTool.RunParams.ExpectedCircularArc.Radius.ToString();
        }
        private void BTN_CIRCLE_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (PT_CircleTool != null)
                {
                    if (PT_Circle_MarkUSE[TapNo])
                    {
                        PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X = PT_CircleTool.RunParams.ExpectedCircularArc.CenterX - PatResult.TranslationX;
                        PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y = PT_CircleTool.RunParams.ExpectedCircularArc.CenterY - PatResult.TranslationY;
                    }

                    if (PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck)
                    {
                        if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_UseLineMax)
                        {
                            for (int k = 0; k < Main.DEFINE.SUBLINE_MAX; k++)
                            {
                                if (PT_FindLinePara[TapNo, k, 0].m_UseCheck && PT_FindLinePara[TapNo, k, 1].m_UseCheck)
                                {
                                    PT_LineMaxTools[TapNo, k, 0].Run();
                                    PT_LineMaxTools[TapNo, k, 1].Run();

                                    int nLineIdx1 = 0, nLineIdx2 = 0;

                                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(0, PT_FindLinePara[TapNo, k, 0], PT_LineMaxTools[TapNo, k, 0], ref nLineIdx1);
                                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].GetLineMaxIndex(1, PT_FindLinePara[TapNo, k, 1], PT_LineMaxTools[TapNo, k, 1], ref nLineIdx2);

                                    if ((PT_LineMaxTools[TapNo, k, 0].Results != null && PT_LineMaxTools[TapNo, k, 0].Results.Count > 0 && PT_LineMaxTools[TapNo, k, 0].Results[0].GetLine() != null)
                                        && (PT_LineMaxTools[TapNo, k, 1].Results != null && PT_LineMaxTools[TapNo, k, 1].Results.Count > 0 && PT_LineMaxTools[TapNo, k, 1].Results[0].GetLine() != null))
                                    {
                                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                                        PT_LineLineCrossPoints[0].LineA = PT_LineMaxTools[TapNo, k, 0].Results[nLineIdx1].GetLine();
                                        PT_LineLineCrossPoints[0].LineB = PT_LineMaxTools[TapNo, k, 1].Results[nLineIdx2].GetLine();
                                        PT_LineLineCrossPoints[0].Run();
                                        if (PT_LineLineCrossPoints[0].Intersects)
                                        {
                                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                                            {
                                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                                PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X = PT_CircleTool.RunParams.ExpectedCircularArc.CenterX - PT_LineLineCrossPoints[0].X;
                                                PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y = PT_CircleTool.RunParams.ExpectedCircularArc.CenterY - PT_LineLineCrossPoints[0].Y;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int k = 0; k < Main.DEFINE.SUBLINE_MAX; k++)
                            {
                                if (PT_FindLinePara[TapNo, k, 0].m_UseCheck && PT_FindLinePara[TapNo, k, 1].m_UseCheck)
                                {
                                    PT_FindLineTools[TapNo, k, 0].Run();
                                    PT_FindLineTools[TapNo, k, 1].Run();

                                    if ((PT_FindLineTools[TapNo, k, 0].Results != null && PT_FindLineTools[TapNo, k, 0].Results.Count > 0 && PT_FindLineTools[TapNo, k, 0].Results.GetLine() != null)
                                        && (PT_FindLineTools[TapNo, k, 1].Results != null && PT_FindLineTools[TapNo, k, 1].Results.Count > 0 && PT_FindLineTools[TapNo, k, 1].Results.GetLine() != null))
                                    {
                                        PT_LineLineCrossPoints[0] = new CogIntersectLineLineTool();
                                        PT_LineLineCrossPoints[0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                                        PT_LineLineCrossPoints[0].LineA = PT_FindLineTools[TapNo, k, 0].Results.GetLine();
                                        PT_LineLineCrossPoints[0].LineB = PT_FindLineTools[TapNo, k, 1].Results.GetLine();
                                        PT_LineLineCrossPoints[0].Run();
                                        if (PT_LineLineCrossPoints[0].Intersects)
                                        {
                                            if (PT_LineLineCrossPoints[0].X >= 0 && PT_LineLineCrossPoints[0].X <= PT_LineLineCrossPoints[0].InputImage.Width && PT_LineLineCrossPoints[0].Y >= 0 && PT_LineLineCrossPoints[0].Y <= PT_LineLineCrossPoints[0].InputImage.Height)
                                            {
                                                Display.SetGraphics(PT_Display01, PT_LineLineCrossPoints[0].CreateLastRunRecord(), "RESULT");

                                                PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].X = PT_CircleTool.RunParams.ExpectedCircularArc.CenterX - PT_LineLineCrossPoints[0].X;
                                                PT_CirclePara[TapNo, m_SelectCircle].m_TargetToCenter[Main.DEFINE.M_FINDLINETOOL].Y = PT_CircleTool.RunParams.ExpectedCircularArc.CenterY - PT_LineLineCrossPoints[0].Y;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    PT_CircleTools[TapNo, m_SelectCircle] = new CogFindCircleTool(PT_CircleTool);
                    PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.ContrastThreshold = TBAR_THRES_CIR.Value;
                    PT_CircleTools[TapNo, m_SelectCircle].RunParams.NumCalipers = Convert.ToInt16(LB_CIRCLE_CNT.Text);
                    PT_CircleTools[TapNo, m_SelectCircle].RunParams.NumToIgnore = (int)NUD_CIRCLE_IGNCNT.Value;
                    PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperSearchDirection = (CogFindCircleSearchDirectionConstants)CB_DIRECTION_CIR.SelectedIndex;
                    PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_POLARITY_CIR.SelectedIndex + 1);

                    if (RBTN_CIR_CALIPER_METHOD_SCORE.Checked == true)
                    {
                        PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod = Main.DEFINE.CLP_METHOD_SCORE;
                        PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                        CogCaliperScorerContrast scorer = new CogCaliperScorerContrast();
                        scorer.Enabled = true;
                        PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                    }
                    else if (RBTN_CIR_CALIPER_METHOD_POS.Checked == true)
                    {
                        PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod = Main.DEFINE.CLP_METHOD_POS;
                        PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.SingleEdgeScorers.Clear();
                        CogCaliperScorerPosition scorer = new CogCaliperScorerPosition();
                        scorer.Enabled = true;
                        PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.SingleEdgeScorers.Add(scorer);
                    }

                    LABEL_MESSAGE(LB_MESSAGE, "Register OK", System.Drawing.Color.Lime);
                }
                else
                    LABEL_MESSAGE(LB_MESSAGE, "Select!!! Circle", System.Drawing.Color.Red);
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }

            Main.DisplayFit(PT_Display01);
        }
        private void CB_CIRCLE_USE_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_CIRCLE_USE.Checked)
            {
                CB_CIRCLE_USE.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_CIRCLE_USE.BackColor = System.Drawing.Color.DarkGray;
            }
        }
        private void CB_CIRCLE_USE_Click(object sender, EventArgs e)
        {
            if (CB_CIRCLE_USE.Checked)
            {
                PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck = true;
            }
            else
            {
                PT_CirclePara[TapNo, m_SelectCircle].m_UseCheck = false;
            }
        }
        private void TBAR_THRES_CIR_ValueChanged(object sender, EventArgs e)
        {
            PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.ContrastThreshold = TBAR_THRES_CIR.Value;
            LB_THRES_CIR.Text = TBAR_THRES_CIR.Value.ToString();
            if (!m_PatchangeFlag && TABC_MANU.SelectedIndex == Main.DEFINE.M_FINDCIRCLETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }
        private void BTN_THRES_CIR_UP_Click(object sender, EventArgs e)
        {
            if (TBAR_THRES_CIR.Maximum == TBAR_THRES_CIR.Value) return;
            TBAR_THRES_CIR.Value++;
        }
        private void BTN_THRES_CIR_DN_Click(object sender, EventArgs e)
        {
            if (TBAR_THRES_CIR.Minimum == TBAR_THRES_CIR.Value) return;
            TBAR_THRES_CIR.Value--;
        }
        private void CB_DIRECTION_CIR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperSearchDirection = (CogFindCircleSearchDirectionConstants)CB_DIRECTION_CIR.SelectedIndex;
            PT_CircleTool.RunParams.CaliperSearchDirection = (CogFindCircleSearchDirectionConstants)CB_DIRECTION_CIR.SelectedIndex;
            //DrawCircleRegion();
        }
        private void CB_POLARITY_CIR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PT_CircleTools[TapNo, m_SelectCircle].RunParams.CaliperRunParams.Edge0Polarity = (CogCaliperPolarityConstants)(CB_POLARITY_CIR.SelectedIndex + 1);
        }

        private void CB_CIRCLE_MARK_USE_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            if (TempBTN.Checked)
            {
                TempBTN.BackColor = System.Drawing.Color.GreenYellow;
                PT_Circle_MarkUSE[TapNo] = true;
            }
            else
            {
                TempBTN.BackColor = System.Drawing.Color.White;
                PT_Circle_MarkUSE[TapNo] = false;
            }
            if (!m_TABCHANGE_MODE)
            {
                RefreshDisplay2();
                DrawCircleRegion();
            }
        }
        #region Move
        private void BTN_SEARCH_CIR_UP_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_PLUS, M_SEARCHLEGNTH);
        }
        private void BTN_SEARCH_CIR_DN_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_MINUS, M_SEARCHLEGNTH);
        }
        private void BTN_PROJECTION_CIR_UP_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_PLUS, M_PROJECTION);
        }
        private void BTN_PROJECTION_CIR_DN_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_MINUS, M_PROJECTION);
        }
        private void BTN_RADIUS_CIR_UP_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_PLUS, M_RADIUS);
        }
        private void BTN_RADIUS_CIR_DN_Click(object sender, EventArgs e)
        {
            BTN_CIRCLE_MOVE(M_MINUS, M_RADIUS);
        }
        private void BTN_CIRCLE_MOVE(int nValue, int nMode)
        {
            if (nMode == M_SEARCHLEGNTH)
            {
                if (nValue == M_MINUS && PT_CircleTool.RunParams.CaliperSearchLength < 10)
                {
                    PT_CircleTool.RunParams.CaliperSearchLength = 10;
                }
                else
                {
                    PT_CircleTool.RunParams.CaliperSearchLength += nValue;
                }

            }
            if (nMode == M_PROJECTION)
            {
                if (nValue == M_MINUS && PT_CircleTool.RunParams.CaliperProjectionLength < 10)
                {
                    PT_CircleTool.RunParams.CaliperProjectionLength = 10;
                }
                else
                {
                    PT_CircleTool.RunParams.CaliperProjectionLength += nValue;
                }
            }
            if (nMode == M_RADIUS)
            {
                if (nValue == M_MINUS && PT_CircleTool.RunParams.ExpectedCircularArc.Radius < 10)
                {
                    PT_CircleTool.RunParams.ExpectedCircularArc.Radius = 10;
                }
                else
                {
                    PT_CircleTool.RunParams.ExpectedCircularArc.Radius += nValue;
                }
                LB_RADIUS_CIR.Text = PT_CircleTool.RunParams.ExpectedCircularArc.Radius.ToString(); //이 파라미터는 changed에서 안들어감 버그인듯. 다른건들어감
            }
            DrawCircleRegion();
        }
        #endregion

        #endregion

        #region ATT 압흔검사 Parameter Setting
        private void Akkon_Change()
        {
            m_PatchangeFlag = true;
            LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Lime);
            RefreshDisplay2();
            //YSH
            //링크 되어있어, 객체 전체를 넘겨주진 못함... 해당부분 수정 하려면 DLL도 수정 필요..추후 개선 예정(Main_ATT.cs)
            //필요한 객체만 Set 진행
            Main.ATTInspParam = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter;
            Main.ATTInspOption = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption;
            Main.ATTInspFilter = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter;
            Main.ATTDrawOption = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonDrawOption;
            PT_AkkonPara[TapNo].AkkonBumpROIList = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonBumpROIList;
            PT_AkkonPara[TapNo].LeadGroupCount = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeadGroupCount;
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].LeadGroupInfo[m_SelectAkkon] != null)
                LeadGroupInfo = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].LeadGroupInfo;
            for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
            {
                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeftPattern[i] != null)
                    PT_AkkonPara[TapNo].LeftPattern[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].LeftPattern[i];

                if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].RightPattern[i] != null)
                    PT_AkkonPara[TapNo].RightPattern[i] = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].RightPattern[i];
            }

            CB_ATT_INSP_TYPE.SelectedIndex = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_nInspType;
            CB_ATT_PANEL_TYPE.SelectedIndex = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nIsFlexible;
            CB_ATT_TARGET_TYPE.SelectedIndex = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nPanelInfo;
            CB_ATT_FILTER_TYPE.SelectedIndex = (int)Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eFilterType;
            CB_ATT_FILTER_DIR.SelectedIndex = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nFilterDir;
            CB_ATT_THRES_MODE.SelectedIndex = (int)Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eThMode;
            CB_ATT_SHADOW_DIR.SelectedIndex = (int)Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eShadowDir;
            CB_ATT_PEAK_PROP.SelectedIndex = (int)Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_ePeakProp;
            CB_ATT_STREN_BASE.SelectedIndex = (int)Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eStrengthBase;

            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_bLogTrace == true)
                CB_ATT_USE_LOG_TRACE.Checked = true;
            else
                CB_ATT_USE_LOG_TRACE.Checked = false;

            if (CB_ATT_TARGET_TYPE.SelectedIndex == 1)  //COG
            {
                label65.Visible = true;
                LB_ATT_EXTRE_LEAD_DISP.Visible = true;
            }
            else
            {
                label65.Visible = false;
                LB_ATT_EXTRE_LEAD_DISP.Visible = false;
            }

            LB_ATT_SLICE_OVERLAP.Enabled = false;
            label67.Visible = true;
            LB_ATT_MOVE_PIXEL_COUNT.Visible = true;
            LB_ATT_THRES_WEIGHT.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight.ToString("0.00");
            LB_ATT_PEAK_THRES.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak.ToString();
            LB_ATT_STREN_SCALE_FACTOR.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor.ToString("0.00");
            LB_ATT_SLICE_OVERLAP.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_nOverlap.ToString("");
            LB_ATT_STD_DEV.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStdDevLeadJudge.ToString("0.00");
            LB_ATT_MIN_SZ_FILTER.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize.ToString("0.00");
            LB_ATT_MAX_SZ_FILTER.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize.ToString("0.00");
            LB_ATT_GRP_DIST.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance.ToString("0.00");
            LB_ATT_STRN_FILTER.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold.ToString("0.00");
            LB_ATT_WIDTH_CUT.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nWidthCut.ToString();
            LB_ATT_HEIGHT_CUT.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nHeightCut.ToString();
            LB_ATT_BW_RATIO.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio.ToString("0.00");
            LB_ATT_EXTRE_LEAD_DISP.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nExtraLead.ToString("");
            LB_ATT_MOVE_PIXEL_COUNT.Text = nMovePixelCount.ToString();
            LB_ATT_COUNT.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeCount.ToString();
            LB_ATT_LENGTH.Text = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeLength.ToString();

            m_PatchangeFlag = false;
            if (PT_DISPLAY_CONTROL.CrossLineChecked) CrossLine();
        }
        #endregion

        #region ATT 얼라인검사 Parameter Setting
        private void Align_Change()
        {
            LB_ALIGNRESULT.Location = new System.Drawing.Point(456, 438);

            if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
            {
                RBTN_ALIGN_INSPOS_LEFT.BackColor = System.Drawing.Color.LawnGreen;
                RBTN_ALIGN_INSPOS_RIGHT.BackColor = System.Drawing.Color.DarkGray;
            }
            else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
            {
                RBTN_ALIGN_INSPOS_LEFT.BackColor = System.Drawing.Color.DarkGray;
                RBTN_ALIGN_INSPOS_RIGHT.BackColor = System.Drawing.Color.LawnGreen;
            }

            if (nTeachMode == (int)ALIGN_INDEX.TEACH_MODE_MARK)
            {
                //Mark Teach 일 경우 Align Pos UI는 visible = false 동작
                label73.Visible = false;
                RBTN_ALIGN_TARPOS_PANEL.Visible = false;
                RBTN_ALIGNPOS_X.Visible = false;
                RBTN_ALIGNPOS_Y.Visible = false;
                PANEL_AT_CALIPER.Visible = false;
                PANEL_AT_MARK.Visible = true;
                PANEL_AT_MARK.Location = new System.Drawing.Point(9, 96);
                RBTN_ALIGN_TEACH_MARK.BackColor = Color.LawnGreen;
                RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;

                for (int i = 0; i < Main.DEFINE.SUBPATTERNMAX; i++)
                {
                    if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
                    {
                        if (PT_AlignPara[TapNo].LeftPattern[i] != null)
                            DrawTrainedATTPattern(AM_SubDisplay[i], PT_AlignPara[TapNo].LeftPattern[i]);
                    }
                    else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
                    {
                        if (PT_AlignPara[TapNo].RightPattern[i] != null)
                            DrawTrainedATTPattern(AM_SubDisplay[i], PT_AlignPara[TapNo].RightPattern[i]);
                    }
                }
            }
            else if (nTeachMode == (int)ALIGN_INDEX.TEACH_MODE_EDGE)
            {
                label73.Visible = true;
                RBTN_ALIGN_TARPOS_PANEL.Visible = true;
                RBTN_ALIGNPOS_X.Visible = true;
                RBTN_ALIGNPOS_Y.Visible = true;
                PANEL_AT_CALIPER.Visible = true;
                PANEL_AT_CALIPER.Location = new System.Drawing.Point(9, 96);
                PANEL_AT_MARK.Visible = false;
                RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                RBTN_ALIGN_TEACH_EDGE.BackColor = Color.LawnGreen;
                if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
                {
                    RBTN_ALIGNPOS_X.BackColor = Color.LawnGreen;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    LB_ALIGN_LEAD_COUNT.Text = PT_AlignPara[TapNo].LeadCount.ToString();
                    LB_ALIGN_FILTER_SIZE.Text = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels.ToString();
                    LB_ALIGN_EDGE_THRESHOLD.Text = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold.ToString();
                    if (PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.LawnGreen;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
                        CaliperPol = CogCaliperPolarityConstants.DarkToLight;
                    }
                    else if (PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark)
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.LawnGreen;
                        CaliperPol = CogCaliperPolarityConstants.LightToDark;
                    }
                    else
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
                        CaliperPol = CogCaliperPolarityConstants.DontCare;
                    }

                }
                else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
                {
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.LawnGreen;
                    LB_ALIGN_FILTER_SIZE.Text = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels.ToString();
                    LB_ALIGN_EDGE_THRESHOLD.Text = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold.ToString();
                    if (PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity == CogCaliperPolarityConstants.DarkToLight)
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.LawnGreen;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
                        CaliperPol = CogCaliperPolarityConstants.DarkToLight;
                    }
                    else if (PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity == CogCaliperPolarityConstants.LightToDark)
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.LawnGreen;
                        CaliperPol = CogCaliperPolarityConstants.LightToDark;
                    }
                    else
                    {
                        RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                        RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
                        CaliperPol = CogCaliperPolarityConstants.DontCare;
                    }
                }
            }

            if (nTargetPos == (int)ALIGN_INDEX.TARGET_POS_FPC)
            {
                RBTN_ALIGN_TARPOS_FPC.BackColor = Color.LawnGreen;
                RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.DarkGray;
            }
            else if (nTargetPos == (int)ALIGN_INDEX.TARGET_POS_PANEL)
            {
                RBTN_ALIGN_TARPOS_FPC.BackColor = Color.DarkGray;
                RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.LawnGreen;
            }
        }
        #endregion

        #region MOVE_SIZE_LBMSSAGE
        private void BTN_MOVE_Click(object sender, EventArgs e)
        {
            double nMoveDataX = 0, nMoveDataY = 0; //공통으로 쓸수 있도록 코딩.

            int nMode = 0;
            nMode = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);
            try
            {
                Button TempBTN = (Button)sender;
                switch (TempBTN.Text.ToUpper().Trim())
                {
                    case "LEFT":
                        nMoveDataX = -nMovePixelCount;
                        nMoveDataY = 0;
                        break;

                    case "RIGHT":
                        nMoveDataX = nMovePixelCount;
                        nMoveDataY = 0;
                        break;

                    case "UP":
                        nMoveDataX = 0;
                        nMoveDataY = -nMovePixelCount;
                        break;

                    case "DOWN":
                        nMoveDataX = 0;
                        nMoveDataY = nMovePixelCount;
                        break;
                }

                nMoveDataX /= PT_Display01.Zoom;
                nMoveDataY /= PT_Display01.Zoom;

                if (nMode == Main.DEFINE.M_CNLSEARCHTOOL)
                {
                    if (m_RetiMode == M_PATTERN) { PatMaxTrainRegion.X += nMoveDataX; PatMaxTrainRegion.Y += nMoveDataY; }
                    if (m_RetiMode == M_SEARCH) { PatMaxSearchRegion.X += nMoveDataX; PatMaxSearchRegion.Y += nMoveDataY; }
                    if (m_RetiMode == M_ORIGIN) { MarkORGPoint.X += nMoveDataX; MarkORGPoint.Y += nMoveDataY; }
                }
                if (nMode == Main.DEFINE.M_BLOBTOOL)
                {
                    BlobTrainRegion.CenterX += nMoveDataX;
                    BlobTrainRegion.CenterY += nMoveDataY;
                }
                if (nMode == Main.DEFINE.M_CALIPERTOOL)
                {
                    PTCaliperRegion.CenterX += nMoveDataX;
                    PTCaliperRegion.CenterY += nMoveDataY;
                }
                if (nMode == Main.DEFINE.M_FINDLINETOOL)
                {
                    PT_FindLineTool.RunParams.ExpectedLineSegment.StartX += nMoveDataX;
                    PT_FindLineTool.RunParams.ExpectedLineSegment.EndX += nMoveDataX;

                    PT_FindLineTool.RunParams.ExpectedLineSegment.StartY += nMoveDataY;
                    PT_FindLineTool.RunParams.ExpectedLineSegment.EndY += nMoveDataY;
                }
                if (nMode == Main.DEFINE.M_FINDCIRCLETOOL)
                {
                    PT_CircleTool.RunParams.ExpectedCircularArc.CenterX += nMoveDataX;
                    PT_CircleTool.RunParams.ExpectedCircularArc.CenterY += nMoveDataY;

                }
                if (nMode == Main.DEFINE.M_AKKONTOOL)
                {
                    //PTAkkonRegion.CenterX += nMoveDataX;
                    //PTAkkonRegion.CenterY += nMoveDataY;
                    //DG_AKKON_ROI_LIST.SelectAll();
                    foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                    {
                        if (bGroupModeFlag)
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CenterX += nMoveDataX;
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CenterY += nMoveDataY;

                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                        }
                        else
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterX += nMoveDataX;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterY += nMoveDataY;

                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                        }
                    }
                }

            }
            catch
            {

            }
        }
        private void BTN_SIZE_Click(object sender, EventArgs e)
        {
            double nMoveDataX = 0, nMoveDataY = 0; //공통으로 쓸수 있도록 코딩.

            int nMode = 0;
            nMode = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);
            try
            {
                Button TempBTN = (Button)sender;
                switch (TempBTN.Text.ToUpper())
                {
                    case "X_DEC":
                        nMoveDataX = -nMovePixelCount;
                        nMoveDataY = 0;
                        break;

                    case "X_INC":
                        nMoveDataX = nMovePixelCount;
                        nMoveDataY = 0;
                        break;

                    case "Y_DEC":
                        nMoveDataX = 0;
                        nMoveDataY = -nMovePixelCount;
                        break;

                    case "Y_INC":
                        nMoveDataX = 0;
                        nMoveDataY = nMovePixelCount;
                        break;
                }

                if (nMode == Main.DEFINE.M_CNLSEARCHTOOL)
                {
                    if (m_RetiMode == M_PATTERN) { PatMaxTrainRegion.SetCenterWidthHeight(PatMaxTrainRegion.CenterX, PatMaxTrainRegion.CenterY, PatMaxTrainRegion.Width += nMoveDataX, PatMaxTrainRegion.Height += nMoveDataY); }
                    if (m_RetiMode == M_SEARCH) { PatMaxSearchRegion.SetCenterWidthHeight(PatMaxSearchRegion.CenterX, PatMaxSearchRegion.CenterY, PatMaxSearchRegion.Width += nMoveDataX, PatMaxSearchRegion.Height += nMoveDataY); }
                }

                if (nMode == Main.DEFINE.M_BLOBTOOL)
                {
                    BlobTrainRegion.SetCenterLengthsRotationSkew(BlobTrainRegion.CenterX, BlobTrainRegion.CenterY, BlobTrainRegion.SideXLength += nMoveDataX, BlobTrainRegion.SideYLength += nMoveDataY, BlobTrainRegion.Rotation, BlobTrainRegion.Skew);
                }

                if (nMode == Main.DEFINE.M_CALIPERTOOL)
                {
                    PTCaliperRegion.SideXLength += nMoveDataX;
                    PTCaliperRegion.SideYLength += nMoveDataY;
                }

                if (nMode == Main.DEFINE.M_FINDLINETOOL)
                {
                    PT_FindLineTool.RunParams.CaliperProjectionLength += nMoveDataX;
                    PT_FindLineTool.RunParams.CaliperSearchLength += nMoveDataY;
                }

                if (nMode == Main.DEFINE.M_AKKONTOOL)
                {
                    //PTAkkonRegion.SideXLength += nMoveDataX;
                    //PTAkkonRegion.SideYLength += nMoveDataY;

                    foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                    {
                        if (bGroupModeFlag)
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].SideXLength += nMoveDataX;
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].SideYLength += nMoveDataY;

                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data)].Value = (Convert.ToInt32(data) + 1).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                        }
                        else
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideXLength += nMoveDataX;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideYLength += nMoveDataY;

                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data)].Value = (Convert.ToInt32(data) + 1).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYY.ToString("0.0") + ")";
                        }
                    }
                }

                PSizeLabel();
            }
            catch
            {
            }
        }
        private void BTN_SIZE_INPUT(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                double nSizeDataX = 0, nSizeDataY = 0; //공통으로 쓸수 있도록 코딩.
                double nMinSizeX = 0, nMinSizeY = 0;
                double nInputMinSizeX = 2, nInputMinSizeY = 2;
                int nMode = 0;
                nMode = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);
                try
                {

                    if (nMode == Main.DEFINE.M_CNLSEARCHTOOL)
                    {
                        if (m_RetiMode == M_PATTERN)
                        {
                            nSizeDataX = PatMaxTrainRegion.Width;
                            nSizeDataY = PatMaxTrainRegion.Height;
                        }
                        if (m_RetiMode == M_SEARCH)
                        {
                            nSizeDataX = PatMaxSearchRegion.Width;
                            nSizeDataY = PatMaxSearchRegion.Height;
                        }
                    }

                    if (nMode == Main.DEFINE.M_BLOBTOOL)
                    {
                        nSizeDataX = BlobTrainRegion.SideXLength;
                        nSizeDataY = BlobTrainRegion.SideYLength;
                    }

                    if (nMode == Main.DEFINE.M_CALIPERTOOL)
                    {
                        nSizeDataX = PTCaliperRegion.SideXLength;
                        nSizeDataY = PTCaliperRegion.SideYLength;
                        nInputMinSizeX = nMinSizeX = PT_CaliperTools[TapNo, m_SelectCaliper].RunParams.FilterHalfSizeInPixels * 2 + 2.5;
                    }

                    if (nMode == Main.DEFINE.M_FINDLINETOOL)
                    {
                        nSizeDataX = PT_FindLineTool.RunParams.CaliperProjectionLength;
                        nSizeDataY = PT_FindLineTool.RunParams.CaliperSearchLength;
                        nInputMinSizeY = nMinSizeY = (PT_FindLineTool.RunParams.CaliperRunParams.FilterHalfSizeInPixels * 2 + 2.5);
                    }
                    if (nMode == Main.DEFINE.M_FINDCIRCLETOOL)
                    {
                        nSizeDataX = PT_CircleTool.RunParams.CaliperProjectionLength;
                        nSizeDataY = PT_CircleTool.RunParams.CaliperSearchLength;
                        nInputMinSizeY = nMinSizeY = (PT_CircleTool.RunParams.CaliperRunParams.FilterHalfSizeInPixels * 2 + 2.5);
                    }

                    Button TempBTN = (Button)sender;
                    switch (TempBTN.Text.ToUpper())
                    {
                        case "X_DEC":
                        case "X_INC":
                            Form_KeyPad form_keypad = new Form_KeyPad(nInputMinSizeX, 50000, nSizeDataX, "X AREA SIZE", 1);
                            form_keypad.ShowDialog();
                            if (form_keypad.m_data > nMinSizeX) nSizeDataX = form_keypad.m_data;

                            break;
                        case "Y_DEC":
                        case "Y_INC":

                            Form_KeyPad form_keypad1 = new Form_KeyPad(nInputMinSizeY, 50000, nSizeDataY, "Y AREA SIZE", 1);
                            form_keypad1.ShowDialog();
                            if (form_keypad1.m_data > nMinSizeY) nSizeDataY = form_keypad1.m_data;
                            break;
                    }

                    if (nMode == Main.DEFINE.M_CNLSEARCHTOOL)
                    {
                        if (m_RetiMode == M_PATTERN) { PatMaxTrainRegion.SetCenterWidthHeight(PatMaxTrainRegion.CenterX, PatMaxTrainRegion.CenterY, nSizeDataX, nSizeDataY); }
                        if (m_RetiMode == M_SEARCH) { PatMaxSearchRegion.SetCenterWidthHeight(PatMaxSearchRegion.CenterX, PatMaxSearchRegion.CenterY, nSizeDataX, nSizeDataY); }
                    }

                    if (nMode == Main.DEFINE.M_BLOBTOOL)
                    {
                        BlobTrainRegion.SetCenterLengthsRotationSkew(BlobTrainRegion.CenterX, BlobTrainRegion.CenterY, nSizeDataX, nSizeDataY, BlobTrainRegion.Rotation, BlobTrainRegion.Skew);
                    }

                    if (nMode == Main.DEFINE.M_CALIPERTOOL)
                    {
                        PTCaliperRegion.SideXLength = nSizeDataX;
                        PTCaliperRegion.SideYLength = nSizeDataY;
                    }

                    if (nMode == Main.DEFINE.M_FINDLINETOOL)
                    {
                        PT_FindLineTool.RunParams.CaliperProjectionLength = nSizeDataX;
                        PT_FindLineTool.RunParams.CaliperSearchLength = nSizeDataY;
                    }
                    if (nMode == Main.DEFINE.M_FINDCIRCLETOOL)
                    {
                        PT_CircleTool.RunParams.CaliperProjectionLength = nSizeDataX;
                        PT_CircleTool.RunParams.CaliperSearchLength = nSizeDataY;
                    }
                    PSizeLabel();
                }
                catch
                {

                }
            }
        }
        private void ORGSizeFit()
        {
            try
            {
                int nZoomSize = 1;
                //----------------------------------------------------------------------
                nZoomSize = (int)(PT_Display01.Zoom * M_ORIGIN_SIZE);
                if (nZoomSize < 1)
                    MarkORGPoint.SizeInScreenPixels = M_ORIGIN_SIZE;
                else
                    MarkORGPoint.SizeInScreenPixels = nZoomSize;
                //----------------------------------------------------------------------
                nZoomSize = (int)(PT_Display01.Zoom * nCrossSize);
                if (MarkPoint[TapNo, 0] != null && MarkPoint[TapNo, 1] != null)
                {
                    if (nZoomSize < 1)
                    {
                        MarkPoint[TapNo, 0].SizeInScreenPixels = nCrossSize;
                        MarkPoint[TapNo, 1].SizeInScreenPixels = nCrossSize;
                    }
                    else
                    {
                        MarkPoint[TapNo, 0].SizeInScreenPixels = nZoomSize;
                        MarkPoint[TapNo, 1].SizeInScreenPixels = nZoomSize;
                    }
                }
            }
            catch
            {

            }
            //----------------------------------------------------------------------
        }
        private void PSizeLabel()
        {
            int nMode = 0;
            nMode = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);

            if (nMode == Main.DEFINE.M_CNLSEARCHTOOL)
            {
                if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN) { LABEL_MESSAGE(LB_MESSAGE1, "X:" + PatMaxTrainRegion.Width.ToString("0.0") + " , " + "Y:" + PatMaxTrainRegion.Height.ToString("0.0"), System.Drawing.Color.GreenYellow); }
                if (m_RetiMode == M_SEARCH) { LABEL_MESSAGE(LB_MESSAGE1, "X:" + PatMaxSearchRegion.Width.ToString("0.0") + " , " + "Y:" + PatMaxSearchRegion.Height.ToString("0.0"), System.Drawing.Color.GreenYellow); }
            }

            if (nMode == Main.DEFINE.M_BLOBTOOL)
            {
                LABEL_MESSAGE(LB_MESSAGE1, "X:" + BlobTrainRegion.SideXLength.ToString("0.0") + " , " + "Y:" + BlobTrainRegion.SideYLength.ToString("0.0"), System.Drawing.Color.GreenYellow);
            }

            if (nMode == Main.DEFINE.M_CALIPERTOOL)
            {
                LABEL_MESSAGE(LB_MESSAGE1, "X:" + PTCaliperRegion.SideXLength.ToString("0.0") + " , " + "Y:" + PTCaliperRegion.SideYLength.ToString("0.0"), System.Drawing.Color.GreenYellow);
            }
            if (nMode == Main.DEFINE.M_FINDLINETOOL)
            {
                LABEL_MESSAGE(LB_MESSAGE1, "X:" + PT_FindLineTool.RunParams.CaliperProjectionLength.ToString("0.0") + " , " + "Y:" + PT_FindLineTool.RunParams.CaliperSearchLength.ToString("0.0"), System.Drawing.Color.GreenYellow);
            }
        }
        private void LABEL_MESSAGE(Label nlabel, string nText, Color nColor)
        {
            nlabel.ForeColor = nColor;
            nlabel.Text = nText;
        }

        #region Distance
        private void DistanceLine()
        {
            for (int i = 0; i < Main.DEFINE.Pattern_Max; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    MarkPoint[i, j] = new CogPointMarker();
                    MarkPoint[i, j].LineStyle = CogGraphicLineStyleConstants.Dot;
                    if (j == 0)
                    {
                        MarkPoint[i, j].Color = CogColorConstants.Green;
                        MarkPoint[i, j].SelectedColor = CogColorConstants.Green;
                    }
                    else
                    {
                        MarkPoint[i, j].Color = CogColorConstants.Red;
                        MarkPoint[i, j].SelectedColor = CogColorConstants.Red;
                    }
                    MarkPoint[i, j].GraphicDOFEnable = CogPointMarkerDOFConstants.All;
                    MarkPoint[i, j].Interactive = true;
                    MarkPoint[i, j].SizeInScreenPixels = nCrossSize;
                    MarkPoint[i, j].X = (double)Main.vision.IMAGE_CENTER_X[Main.AlignUnit[CamNo].PAT[StageNo, i].m_CamNo] + (50 * j);
                    MarkPoint[i, j].Y = (double)Main.vision.IMAGE_CENTER_Y[Main.AlignUnit[CamNo].PAT[StageNo, i].m_CamNo];
                }
            }


        }
        private void PT_Display_DoubleClick(object sender, EventArgs e)
        {
            CogDisplay TempLB = (CogDisplay)sender;
            try
            {
                int nNum;
                nNum = Convert.ToInt16(TempLB.Name.Substring(TempLB.Name.Length - 1, 1));
                if (nNum == 2)
                {
                    bool nMarkUse = false;
                    if (M_TOOL_MODE == Main.DEFINE.M_BLOBTOOL)
                        if (PT_Blob_MarkUSE[TapNo]) nMarkUse = true;
                    if (M_TOOL_MODE == Main.DEFINE.M_CALIPERTOOL)
                        if (PT_Caliper_MarkUSE[TapNo] || PT_Blob_CaliperUSE[TapNo]) nMarkUse = true;
                    if (M_TOOL_MODE == Main.DEFINE.M_FINDLINETOOL)
                        if (PT_FindLine_MarkUSE[TapNo]) nMarkUse = true;

                    if (nMarkUse)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            MarkPoint[TapNo, j].X = (double)Main.vision.IMAGE_CENTER_X[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo] + (50 * j) - PatResult.TranslationX;
                            MarkPoint[TapNo, j].Y = (double)Main.vision.IMAGE_CENTER_Y[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo] - PatResult.TranslationY;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            MarkPoint[TapNo, j].X = (double)Main.vision.IMAGE_CENTER_X[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo] + (50 * j);
                            MarkPoint[TapNo, j].Y = (double)Main.vision.IMAGE_CENTER_Y[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_CamNo];
                        }
                    }
                }
                TempLB.InteractiveGraphics.Add(MarkPoint[TapNo, 0] as ICogGraphicInteractive, "Distance", false);
                TempLB.InteractiveGraphics.Add(MarkPoint[TapNo, 1] as ICogGraphicInteractive, "Distance", false);
                nDistanceShow[TapNo] = true;
            }
            catch
            {

            }
        }
        private void PT_Display_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CogDisplay TempLB = (CogDisplay)sender;
                try
                {
                    if (nDistanceShow[TapNo])
                    {
                        nDistance.InputImage = TempLB.Image;

                        double nStartX = 0, nStartY = 0;
                        double nEndX = 10, nEndY = 10;

                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(MarkPoint[TapNo, 0].X, MarkPoint[TapNo, 0].Y, ref nStartX, ref nStartY);
                        Main.AlignUnit[CamNo].PAT[StageNo, TapNo].V2R(MarkPoint[TapNo, 1].X, MarkPoint[TapNo, 1].Y, ref nEndX, ref nEndY);

                        nDistance.StartX = nStartX;
                        nDistance.StartY = nStartY;

                        nDistance.EndX = nEndX;
                        nDistance.EndY = nEndY;
                        nDistance.Run();
                        LABEL_MESSAGE(LB_MESSAGE, nDistance.Distance.ToString("0.0") + " um" + " , " + (Main.DEFINE.degree * nDistance.Angle).ToString("0.000") + " Deg", System.Drawing.Color.Red);

                        nDistance.StartX = MarkPoint[TapNo, 0].X;
                        nDistance.StartY = MarkPoint[TapNo, 0].Y;

                        nDistance.EndX = MarkPoint[TapNo, 1].X;
                        nDistance.EndY = MarkPoint[TapNo, 1].Y;
                        nDistance.Run();
                        LABEL_MESSAGE(LB_MESSAGE, LB_MESSAGE.Text + " , " + nDistance.Distance.ToString("0.0") + " Pixel", System.Drawing.Color.Red);
                    }
                    PSizeLabel();
                }
                catch
                {
                    LABEL_MESSAGE(LB_MESSAGE, "", System.Drawing.Color.Red);
                }
            }
        }
        #endregion


        private void LB_CAMCENTER_DoubleClick(object sender, EventArgs e)
        {
            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
            {
                //                 PatMaxORGPoint.OriginX = Main.vision.IMAGE_CENTER_X[m_CamNo];
                //                 PatMaxORGPoint.OriginY = Main.vision.IMAGE_CENTER_Y[m_CamNo];

                MarkORGPoint.X = Main.vision.IMAGE_CENTER_X[m_CamNo];
                MarkORGPoint.Y = Main.vision.IMAGE_CENTER_Y[m_CamNo];

            }
        }
        private void PT_SubDisplay_00_Click_1(object sender, EventArgs e)
        {
            CogRecordDisplay TempNum = (CogRecordDisplay)sender;
            int n_SubNo;
            n_SubNo = Convert.ToInt16(TempNum.Name.Substring(TempNum.Name.Length - 2, 2));
            CB_SUB_PATTERN.SelectedIndex = n_SubNo;
            CB_SUB_PATTERN_SelectionChangeCommitted(null, null);
        }
        private void BTN_MAINORIGIN_COPY_Click(object sender, EventArgs e)
        {
            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
            {
                bool SearchResult = false;
                if (PT_Pattern[TapNo, 0].Pattern.Trained == false)
                {
                    MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    ORGSizeFit();
                }
                else
                {
                    PT_Pattern[TapNo, 0].Run();
                    if (PT_Pattern[TapNo, 0].Results != null)
                    {
                        if (PT_Pattern[TapNo, 0].Results.Count >= 1) SearchResult = true;
                    }
                    if (SearchResult)
                    {
                        MarkORGPoint.X = PatResult.TranslationX;  //PT_Pattern[TapNo, 0].Pattern.Origin.TranslationX;
                        MarkORGPoint.Y = PatResult.TranslationY; // PT_Pattern[TapNo, 0].Pattern.Origin.TranslationY;
                    }
                }

            }
        }
        private void LB_PATTERN_08_Click(object sender, EventArgs e)
        {
            Label TempNum = (Label)sender;
            int n_SubNo;
            n_SubNo = Convert.ToInt16(TempNum.Name.Substring(TempNum.Name.Length - 2, 2));

            if (PT_Pattern_USE[TapNo, n_SubNo])
            {
                PT_Pattern_USE[TapNo, n_SubNo] = false;
                SUBPATTERN_LABELDISPLAY(PT_Pattern_USE[TapNo, n_SubNo], n_SubNo);
            }
            else
            {
                PT_Pattern_USE[TapNo, n_SubNo] = true;
                SUBPATTERN_LABELDISPLAY(PT_Pattern_USE[TapNo, n_SubNo], n_SubNo);
            }

            if (m_PatNo_Sub == n_SubNo)
                CB_SUBPAT_USE.Checked = PT_Pattern_USE[TapNo, m_PatNo_Sub];
        }
        private void PT_Display01_Changed(object sender, CogChangedEventArgs e)
        {
            if (Main.Status.MC_MODE == Main.DEFINE.MC_TEACHFORM)
            {
                if (PT_Display01.Zoom != ZoomBackup)
                {
                    ZoomBackup = PT_Display01.Zoom;
                    ORGSizeFit();
                }
            }
        }
        private void BTN_PATTERN_MASK_Click(object sender, EventArgs e)
        {
            if (PT_Pattern[TapNo, m_PatNo_Sub].Pattern.Trained)
            {
                //                 PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                //                 PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(PT_Pattern[TapNo, m_PatNo_Sub].Pattern.TrainImage);
                PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(PT_GPattern[TapNo, m_PatNo_Sub].Pattern.TrainImage);

                FormPatternMask.BackUpSearchMaxTool = PT_Pattern[TapNo, m_PatNo_Sub];
                FormPatternMask.BackUpPMAlignTool = PT_GPattern[TapNo, m_PatNo_Sub];
                FormPatternMask.ShowDialog();

                PT_Pattern[TapNo, m_PatNo_Sub] = FormPatternMask.BackUpSearchMaxTool;
                PT_GPattern[TapNo, m_PatNo_Sub] = FormPatternMask.BackUpPMAlignTool;

                DrawTrainedPattern(PT_SubDisplay[m_PatNo_Sub], PT_Pattern[TapNo, m_PatNo_Sub]);
            }
        }
        private void BTN_PATTERN_SCORE_Click(object sender, EventArgs e)
        {
            //             bool nResult = false;
            //             Form_Password formpassword = new Form_Password();
            //             formpassword.ShowDialog();
            //             nResult = formpassword.LOGINOK;
            //             formpassword.Dispose();
            // 
            //             if (nResult)
            //             {
            //                 if (Main.machine.EngineerMode)
            //                 {
            //                     Main.machine.EngineerMode = false;
            //                     BTN_Engineer.BackColor = System.Drawing.Color.DarkGray;
            //                 }
            //                 else
            //                 {
            //                     Main.machine.EngineerMode = true;
            //                     BTN_Engineer.BackColor = System.Drawing.Color.LawnGreen;
            //                 }
            //             }
        }
        private void LB_RECTANGLE_Click(object sender, EventArgs e)
        {
            if (M_TOOL_MODE == Main.DEFINE.M_BLOBTOOL)
            {
                BlobTrainRegion.Rotation = 0;
                BlobTrainRegion.SetCenterLengthsRotationSkew(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 200, 200, 0, 0);
            }
        }
        private void BTN_PATTERN_COPY_Click(object sender, EventArgs e)
        {
            //             Form_Password formpassword = new Form_Password(false);
            //             formpassword.ShowDialog();
            // 
            //             if (!formpassword.LOGINOK)
            //             {
            //                 formpassword.Dispose();
            //                 return;
            //             }
            //             formpassword.Dispose();

            //nPatternCopy = true;
            //BTN_SAVE_Click(null, null);

            for (int i = 1; i < Main.recipe.m_nTabCount; i++) //임시 copy 기능 YSH
            {
                Main.AlignUnit[CamNo].PAT[StageNo, i] = Main.AlignUnit[CamNo].PAT[0, 0].ShallowCopy(); //첫번째 인덱스를 모두 복사   
                Main.AlignUnit[CamNo].Save(StageNo);
                Main.AlignUnit[CamNo].Save_ATT(StageNo, i);//2022 1014 YSH Tab별 Save
                Main.AlignUnit[CamNo].Load(StageNo);
                Main.AlignUnit[CamNo].Load_ATT(StageNo, i);//2022 1014 YSH Tab별 Load
            }

        }

        #region FPC_TRAY_NACHI
        private void BTN_FPC_SEARCH_ALL_Click(CogRecordDisplay Display)
        {
            m_Timer.StartTimer();
            try
            {
                //   BTN_INTERSECTION_RUN_Click(null , null);
                Main.DisplayClear(Display);
                DrawPocketPoint(Display);
                CogRectangle nBackUp_SearchRegion = new CogRectangle();
                CogRectangle nSearchRegion = new CogRectangle();
                List<CogCompositeShape> ResultGraphic = new List<CogCompositeShape>();
                List<CogRectangle> ResultSearchRegion = new List<CogRectangle>();

                List<string> nMessageList = new List<string>();
                string[] nMessage = new string[2];
                List<CogColorConstants> nColorList = new List<CogColorConstants>();

                List<double> nPosXs = new List<double>();
                List<double> nPosYs = new List<double>();

                int PoketNum = 0;
                int nCount_OK = 0;
                int nGCount_OK = 0;
                bool[] Mark_ret = new bool[TRAY_POCKET_X * TRAY_POCKET_Y];
                bool[] GMark_ret = new bool[TRAY_POCKET_X * TRAY_POCKET_Y];

                int nTempPatNo_Sub = 0;

                nTempPatNo_Sub = m_PatNo_Sub;

                PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                PT_GPattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                nBackUp_SearchRegion = new CogRectangle(PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle);

                if (MarkerPointList.Count == TRAY_POCKET_X * TRAY_POCKET_Y)
                {
                    for (int nX = 0; nX < TRAY_POCKET_X; nX++)
                    {
                        for (int nY = 0; nY < TRAY_POCKET_Y; nY++)
                        {
                            PoketNum = (nX * TRAY_POCKET_Y) + nY;
                            //---------------------------------------------------------------------------------------------------------------------------------
                            (PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).SetCenterWidthHeight(MarkerPointList[PoketNum].X, MarkerPointList[PoketNum].Y,
                                (PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Width, (PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Height);

                            PT_Pattern[TapNo, nTempPatNo_Sub].Run();
                            if (PT_Pattern[TapNo, nTempPatNo_Sub].Results != null)
                            {
                                if (PT_Pattern[TapNo, nTempPatNo_Sub].Results.Count > 0)
                                {
                                    if (PT_Pattern[TapNo, nTempPatNo_Sub].Results[0].Score >= PT_AcceptScore[TapNo])
                                    {
                                        nMessage[0] = "P" + PoketNum.ToString() + "->  " + (PT_Pattern[TapNo, nTempPatNo_Sub].Results[0].Score * 100).ToString("0.00");
                                        nMessageList.Add(nMessage[0]);
                                        nPosXs.Add((PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).X);
                                        nPosYs.Add((PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Y);
                                        nColorList.Add(CogColorConstants.Green);

                                        nCount_OK++;
                                        Mark_ret[PoketNum] = true;
                                        ResultGraphic.Add(PT_Pattern[TapNo, nTempPatNo_Sub].Results[0].CreateResultGraphics(Cognex.VisionPro.SearchMax.CogSearchMaxResultGraphicConstants.MatchRegion | Cognex.VisionPro.SearchMax.CogSearchMaxResultGraphicConstants.Origin));
                                    }
                                }
                            }

                            nSearchRegion = new CogRectangle(PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle);
                            ResultSearchRegion.Add(nSearchRegion);
                            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_PMAlign_Use)
                            {
                                (PT_GPattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).SetCenterWidthHeight(MarkerPointList[PoketNum].X, MarkerPointList[PoketNum].Y,
                                                                                                        (PT_GPattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Width, (PT_GPattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Height);
                                PT_GPattern[TapNo, nTempPatNo_Sub].Run();

                                if (PT_GPattern[TapNo, nTempPatNo_Sub].Results != null)
                                {
                                    float nFontSize = 0;
                                    nFontSize = (float)((Display.Image.Height / Main.DEFINE.FontSize) * Display.Zoom) + (float)(8 / Display.Zoom);

                                    if (PT_GPattern[TapNo, nTempPatNo_Sub].Results.Count > 0)
                                    {
                                        if (PT_GPattern[TapNo, nTempPatNo_Sub].Results[0].Score >= PT_GAcceptScore[TapNo])
                                        {
                                            nMessage[1] = "G:" + PoketNum.ToString() + "->  " + (PT_GPattern[TapNo, nTempPatNo_Sub].Results[0].Score * 100).ToString("0.00");
                                            nMessageList.Add(nMessage[1]);
                                            nPosXs.Add((PT_GPattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).X);
                                            nPosYs.Add((PT_GPattern[TapNo, nTempPatNo_Sub].SearchRegion as CogRectangle).Y + nFontSize);
                                            nColorList.Add(CogColorConstants.Green);

                                            nGCount_OK++;
                                            GMark_ret[PoketNum] = true;
                                            ResultGraphic.Add(PT_GPattern[TapNo, nTempPatNo_Sub].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.MatchFeatures | CogPMAlignResultGraphicConstants.Origin));
                                        }
                                    }

                                }
                            }
                            //---------------------------------------------------------------------------------------------------------------------------------                        

                        }
                    }
                }

                Main.DrawOverlayMessage(PT_Display01, nMessageList, nColorList, nPosXs, nPosYs);

                for (int i = 0; i < ResultGraphic.Count; i++)
                {
                    Display.StaticGraphics.Add(ResultGraphic[i] as ICogGraphic, "Mark");
                }
                for (int i = 0; i < ResultSearchRegion.Count; i++)
                {
                    Display.StaticGraphics.Add(ResultSearchRegion[i] as ICogGraphic, "Search Region");
                }
                PT_Pattern[TapNo, nTempPatNo_Sub].SearchRegion = new CogRectangle(nBackUp_SearchRegion);
            }
            catch
            {

            }
            textBox1.Text = m_Timer.GetElapsedTime().ToString();
        }
        private void BTN_READ_COUNT_Click(object sender, EventArgs e)
        {
            if (Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY1" || Main.AlignUnit[CamNo].m_AlignName == "FPC_TRAY2")
            {
                TRAY_POCKET_X = (short)(PLCDataTag.RData[Main.AlignUnit[CamNo].ALIGN_UNIT_ADDR + Main.DEFINE.PLC_TRAY_COUNT_X]);
                TRAY_POCKET_Y = (short)(PLCDataTag.RData[Main.AlignUnit[CamNo].ALIGN_UNIT_ADDR + Main.DEFINE.PLC_TRAY_COUNT_Y]);
                if (TRAY_POCKET_X == 0 && TRAY_POCKET_Y == 0)
                {
                    //                    LB_PIXELDIS.Text = "X:" + TRAY_POCKET_X.ToString() +" ,Y:"+ TRAY_POCKET_Y.ToString(); 
                    /*                    TRAY_POCKET_X = TRAY_POCKET_Y = 1;*/
                }

                NUD_POCKETCOUNT_X_00.Value = TRAY_POCKET_X;
                NUD_POCKETCOUNT_Y_01.Value = TRAY_POCKET_Y;
            }
        }
        private void NUD_POCKETCOUNT_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nTempBTN = (NumericUpDown)sender;
            int m_Number;
            m_Number = Convert.ToInt16(nTempBTN.Name.Substring(nTempBTN.Name.Length - 2, 2));

            if (m_Number == 0) TRAY_POCKET_X = Convert.ToInt32(nTempBTN.Value);
            if (m_Number == 1) TRAY_POCKET_Y = Convert.ToInt32(nTempBTN.Value);
            if (!NUD_Initial_Flag)
                BTN_FPC_SEARCH_ALL_Click(PT_Display01);
        }
        private void DrawPocketPoint(CogRecordDisplay Display)
        {
            double pitchX = PT_TRAY_PITCH_DISX[TapNo];
            double pitchY = PT_TRAY_PITCH_DISY[TapNo];
            Main.DoublePoint FirstPoint = new Main.DoublePoint();
            List<CogGraphicLabel> nLabel = new List<CogGraphicLabel>();
            CogGraphicLabel nTempLabel = new CogGraphicLabel();

            MarkerPointList.Clear();
            nLabel.Clear();
            int PoketNum = 0;
            for (int nY = 0; nY < TRAY_POCKET_Y; nY++)
            {
                for (int nX = 0; nX < TRAY_POCKET_X; nX++)
                {

                    PoketNum = (nY * TRAY_POCKET_X) + nX;
                    //                     FirstPoint.X = LineEdge_CircleList[Main.DEFINE.FINDLINE_CONNER_NUM].CenterX + PT_TRAY_GUIDE_DISX[TapNo] + (nX * pitchX);
                    //                     FirstPoint.Y = LineEdge_CircleList[Main.DEFINE.FINDLINE_CONNER_NUM].CenterY + PT_TRAY_GUIDE_DISY[TapNo] + (nY * pitchY);

                    FirstPoint.X = PT_TRAY_GUIDE_DISX[TapNo] + (nX * pitchX);
                    FirstPoint.Y = PT_TRAY_GUIDE_DISY[TapNo] + (nY * pitchY);

                    CogPointMarker Marker = new CogPointMarker();
                    //                     FirstPoint = RotationChange(LineEdge_CircleList[Main.DEFINE.FINDLINE_CONNER_NUM].CenterX, LineEdge_CircleList[Main.DEFINE.FINDLINE_CONNER_NUM].CenterY, FirstPoint, Angle);

                    Marker.X = FirstPoint.X;
                    Marker.Y = FirstPoint.Y;


                    Marker.GraphicDOFEnable = CogPointMarkerDOFConstants.All;
                    Marker.SizeInScreenPixels = 80; //화면에 표시 되는 + 모양 크기 .
                    MarkerPointList.Add(Marker);


                    nTempLabel.Text = PoketNum.ToString();
                    nTempLabel.X = Marker.X;
                    nTempLabel.Y = Marker.Y;

                    nLabel.Add(nTempLabel);

                }
            }

            for (int i = 0; i < TRAY_POCKET_X * TRAY_POCKET_Y; i++)
                Display.InteractiveGraphics.Add(MarkerPointList[i] as ICogGraphicInteractive, "FINDLINE_" + i.ToString(), false);

        }
        private void BTN_FPC_SEARCH_ALL_Click(object sender, EventArgs e)
        {
            if (TABC_MANU.SelectedIndex != Main.DEFINE.M_BLOBTOOL)
                BTN_FPC_SEARCH_ALL_Click(PT_Display01);
            else
                BTN_FPC_BLOB_SEARCH_ALL_Click(PT_Display01);

            DisplayFit(PT_Display01);
        }
        private void BTN_FIRST_POS_REG_Click(object sender, EventArgs e)
        {
            PT_TRAY_GUIDE_DISX[TapNo] = FirstPocketPos.X;
            PT_TRAY_GUIDE_DISY[TapNo] = FirstPocketPos.Y;
            PT_TRAY_PITCH_DISX[TapNo] = X_PocketPitchPos.X - FirstPocketPos.X;
            PT_TRAY_PITCH_DISY[TapNo] = Y_PocketPitchPos.Y - FirstPocketPos.Y;

            NUD_Initial_Flag = true;
            if (PT_TRAY_PITCH_DISX[TapNo] < 0) X_PocketPitchPos.Rotation = 0 * Main.DEFINE.radian;
            else X_PocketPitchPos.Rotation = 180 * Main.DEFINE.radian * -1;
            if (PT_TRAY_PITCH_DISY[TapNo] < 0) Y_PocketPitchPos.Rotation = 90 * Main.DEFINE.radian;
            else Y_PocketPitchPos.Rotation = 90 * Main.DEFINE.radian * -1;
            NUD_GUIDEDISX.Value = (decimal)PT_TRAY_GUIDE_DISX[TapNo];
            NUD_GUIDEDISY.Value = (decimal)PT_TRAY_GUIDE_DISY[TapNo];
            NUD_PITCHDISX.Value = (decimal)PT_TRAY_PITCH_DISX[TapNo];
            NUD_PITCHDISY.Value = (decimal)PT_TRAY_PITCH_DISY[TapNo];
            NUD_Initial_Flag = false;
        }

        private void DisplayClear()
        {
            PT_DISPLAY_CONTROL.DisplayClear();
        }
        private void BTN_FIRST_POS_SHOW_Click(object sender, EventArgs e)
        {
            DisplayClear();
            FirstPocketPos.X = PT_TRAY_GUIDE_DISX[TapNo];
            FirstPocketPos.Y = PT_TRAY_GUIDE_DISY[TapNo];

            if (PT_TRAY_PITCH_DISX[TapNo] < 0) X_PocketPitchPos.Rotation = 0 * Main.DEFINE.radian;
            else X_PocketPitchPos.Rotation = 180 * Main.DEFINE.radian * -1;
            if (PT_TRAY_PITCH_DISY[TapNo] < 0) Y_PocketPitchPos.Rotation = 90 * Main.DEFINE.radian;
            else Y_PocketPitchPos.Rotation = 90 * Main.DEFINE.radian * -1;

            X_PocketPitchPos.X = PT_TRAY_GUIDE_DISX[TapNo] + PT_TRAY_PITCH_DISX[TapNo];
            X_PocketPitchPos.Y = PT_TRAY_GUIDE_DISY[TapNo];

            Y_PocketPitchPos.X = PT_TRAY_GUIDE_DISX[TapNo];
            Y_PocketPitchPos.Y = PT_TRAY_GUIDE_DISY[TapNo] + PT_TRAY_PITCH_DISY[TapNo];

            CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
            PatternInfo.Add(FirstPocketPos);
            PatternInfo.Add(X_PocketPitchPos);
            PatternInfo.Add(Y_PocketPitchPos);
            PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);

            if (Main.DEFINE.PROGRAM_TYPE == "FOF_PC1") PB_FOF_FPC.Visible = true;
            if (Main.DEFINE.PROGRAM_TYPE == "TFOF_PC1") PB_TFOF_PANEL.Visible = true;
        }
        private void BTN_FPC_BLOB_SEARCH_ALL_Click(CogRecordDisplay Display)
        {
            m_Timer.StartTimer();
            try
            {
                Main.DisplayClear(Display);
                DrawPocketPoint(Display);

                CogRectangleAffine BlobSearchRegion = new CogRectangleAffine();
                List<CogRectangleAffine> BlobTrainRegion = new List<CogRectangleAffine>();

                List<CogRectangleAffine> nBlobSearchRegion = new List<CogRectangleAffine>(); //BLOB 설정영역  
                List<CogPolygon> ResultBoundary = new List<CogPolygon>();   // BLOB 찾은결과 경계 영역

                double[] BlobArea = new double[Main.DEFINE.BLOB_CNT_MAX];
                double Score = new double();

                List<string> nMessageList = new List<string>();
                string[] nMessage = new string[2];
                CogColorConstants nColor;
                List<CogColorConstants> nColorList = new List<CogColorConstants>();

                List<double> nPosXs = new List<double>();
                List<double> nPosYs = new List<double>();

                int PoketNum = 0;
                int nCount_OK = 0;
                bool[] Mark_ret = new bool[TRAY_POCKET_X * TRAY_POCKET_Y];

                int nTempPatNo_Sub = 0;
                nTempPatNo_Sub = m_PatNo_Sub;

                double pitchX = PT_TRAY_PITCH_DISX[TapNo];
                double pitchY = PT_TRAY_PITCH_DISY[TapNo];


                for (int i = 0; i < Main.DEFINE.BLOB_CNT_MAX; i++)
                {
                    if (PT_BlobPara[TapNo, i].m_UseCheck)
                    {
                        BlobTrainRegion.Add(new CogRectangleAffine(PT_BlobTools[TapNo, i].Region as CogRectangleAffine));
                    }
                }
                BlobSearchRegion = new CogRectangleAffine(PT_BlobTools[TapNo, m_SelectBlob].Region as CogRectangleAffine);

                LB_List.Items.Clear();

                PT_BlobTools[TapNo, 0].InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                if (MarkerPointList.Count == TRAY_POCKET_X * TRAY_POCKET_Y)
                {
                    for (int nY = 0; nY < TRAY_POCKET_Y; nY++)
                    {
                        for (int nX = 0; nX < TRAY_POCKET_X; nX++)
                        {
                            PoketNum = (nY * TRAY_POCKET_X) + nX;

                            for (int i = 0; i < 1; i++)
                            {
                                BlobArea[i] = new double();
                                if (PT_BlobPara[TapNo, i].m_UseCheck)
                                {


                                    //                                    PT_BlobTools[TapNo, i].InputImage = PT_BlobTools[TapNo, i].InputImage;

                                    //  BlobSearchRegion = new CogRectangleAffine(PT_BlobTools[TapNo, i].Region as CogRectangleAffine);

                                    (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterX = MarkerPointList[PoketNum].X;
                                    (PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterY = MarkerPointList[PoketNum].Y;

                                    //                                     BlobSearchRegion.CenterX = PT_TRAY_GUIDE_DISX[TapNo] + (nX * pitchX);
                                    //                                     BlobSearchRegion.CenterY = PT_TRAY_GUIDE_DISY[TapNo] + (nY * pitchY);
                                    // 
                                    //                                     BlobSearchRegion.SetCenterLengthsRotationSkew(PT_TRAY_GUIDE_DISX[TapNo] + (nX * pitchX),PT_TRAY_GUIDE_DISY[TapNo] + (nY * pitchY), BlobSearchRegion.SideXLength, BlobSearchRegion.SideYLength, BlobSearchRegion.Rotation, BlobSearchRegion.Skew);


                                    //                                     BlobSearchRegion.CenterX = PT_TRAY_GUIDE_DISX[TapNo] + (nX * Main.AlignUnit[CamNo].PAT[StageNo, TapNo].TRAY_PITCH_DISX);
                                    //                                     BlobSearchRegion.CenterY = PT_TRAY_GUIDE_DISY[TapNo] + (nY * Main.AlignUnit[CamNo].PAT[StageNo, TapNo].TRAY_PITCH_DISY);

                                    //                                     BlobSearchRegion.CenterX = BlobTrainRegion[i].CenterX + (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].TRAY_PITCH_DISX * (nX));
                                    //                                     BlobSearchRegion.CenterY = BlobTrainRegion[i].CenterY + (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].TRAY_PITCH_DISY * (nY));
                                    //     PT_BlobTools[TapNo, i].Region = new CogRectangleAffine(BlobSearchRegion);
                                    //    PT_BlobTools[TapNo, i].Region = BlobSearchRegion;

                                    PT_BlobTools[TapNo, i].Run();
                                    if (PT_BlobTools[TapNo, i].Results != null)
                                    {
                                        if (PT_BlobTools[TapNo, i].Results.GetBlobs().Count <= 0)
                                        {
                                            int GetBlobsCount = 1;
                                            GetBlobsCount = PT_BlobTools[TapNo, i].Results.GetBlobs().Count;
                                            // 
                                            for (int j = 0; j < PT_BlobTools[TapNo, i].Results.GetBlobs().Count; j++) //PMBlobResults[i].BlobToolResult.GetBlobs().Count
                                            {
                                                ResultBoundary.Add(PT_BlobTools[TapNo, i].Results.GetBlobs()[j].GetBoundary());  //--BLOB RESULTS BOUNDARY
                                                //   BlobArea[i] += PT_BlobTools[TapNo, i].Results.GetBlobs()[j].Area;
                                            }

                                            //                                             Score = 100 - ((BlobArea[i] / BlobSearchRegion.Area) * 100);
                                            nMessage[0] = "B " + PoketNum.ToString();// +"->  " + "NG" + " " + Score.ToString("0.0");
                                            Mark_ret[PoketNum] = false;
                                            nColor = CogColorConstants.Red;
                                        }
                                        else
                                        {
                                            for (int j = 0; j < PT_BlobTools[TapNo, i].Results.GetBlobs().Count; j++) //PMBlobResults[i].BlobToolResult.GetBlobs().Count
                                            {
                                                ResultBoundary.Add(PT_BlobTools[TapNo, i].Results.GetBlobs()[j].GetBoundary());  //--BLOB RESULTS BOUNDARY
                                                //   BlobArea[i] += PT_BlobTools[TapNo, i].Results.GetBlobs()[j].Area;
                                            }
                                            Score = 100;
                                            nMessage[0] = "B " + PoketNum.ToString();// +"->  " + "OK" + " " + Score.ToString("0.0");
                                            Mark_ret[PoketNum] = true;
                                            nCount_OK++;
                                            nColor = CogColorConstants.Green;
                                        }
                                        nMessageList.Add(nMessage[0]);
                                        nColorList.Add(nColor);
                                        nPosXs.Add((PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterX);
                                        nPosYs.Add((PT_BlobTools[TapNo, i].Region as CogRectangleAffine).CenterY);



                                        //   nBlobSearchRegion.Add(PT_BlobTools[TapNo, i].Region as CogRectangleAffine);      //------------------------BLOB SEARCH AREA 
                                    }
                                    Display.StaticGraphics.Add(PT_BlobTools[TapNo, i].Region as ICogGraphic, "Search Region");
                                }
                            }
                        }
                    }
                }
                PT_BlobTools[TapNo, m_SelectBlob].Region = new CogRectangleAffine(BlobSearchRegion as CogRectangleAffine);


                Main.DrawOverlayMessage(Display, nMessageList, nColorList, nPosXs, nPosYs);

                //------------------------BLOB RESULT BOUNDARY-----------------------------------
                for (int i = 0; i < ResultBoundary.Count; i++)
                {
                    ResultBoundary[i].Color = CogColorConstants.Green;
                    Display.StaticGraphics.Add(ResultBoundary[i] as ICogGraphic, "BLOB Region");
                }
            }
            catch
            {

            }
            textBox1.Text = m_Timer.GetElapsedTime().ToString();
        }


        #endregion

        #endregion

        private void BTN_CIRCLE_CNT_UP_Click(object sender, EventArgs e)
        {
            try
            {
                PT_CircleTool.RunParams.NumCalipers++;
                LB_CIRCLE_CNT.Text = PT_CircleTool.RunParams.NumCalipers.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCircleRegion();
        }

        private void BTN_CIRCLE_CNT_DN_Click(object sender, EventArgs e)
        {
            try
            {
                PT_CircleTool.RunParams.NumCalipers--;
                LB_CIRCLE_CNT.Text = PT_CircleTool.RunParams.NumCalipers.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCircleRegion();
        }

        private void NUD_CIRCLE_IGNCNT_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                PT_CircleTool.RunParams.NumToIgnore = (int)NUD_CIRCLE_IGNCNT.Value;
            }
            catch (System.ArgumentException)
            {

            }
            if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDCIRCLETOOL)
            {
                ThresValue_Sts = true;
                BTN_PATTERN_RUN_Click(null, null);
                ThresValue_Sts = false;
            }
        }

        private void NUD_LINE_NORMAL_ANGLE_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.ExpectedLineNormal.Angle = (double)NUD_LINE_NORMAL_ANGLE.Value * Main.DEFINE.radian;

            //if (!m_PatchangeFlag && !m_TABCHANGE_MODE && Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_FINDLINETOOL)
            //{
            //    ThresValue_Sts = true;
            //    BTN_PATTERN_RUN_Click(null, null);
            //    ThresValue_Sts = false;
            //}
        }

        private void NUD_GRADIENT_KERNEL_SIZE_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.EdgeDetectionParams.GradientKernelSizeInPixels = (int)NUD_GRADIENT_KERNEL_SIZE.Value;

            if (NUD_PROJECTION_LENGTH.Value < NUD_GRADIENT_KERNEL_SIZE.Value)
                NUD_PROJECTION_LENGTH.Value = NUD_GRADIENT_KERNEL_SIZE.Value;
        }

        private void NUD_PROJECTION_LENGTH_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.EdgeDetectionParams.ProjectionLengthInPixels = (int)NUD_PROJECTION_LENGTH.Value;
            if (NUD_PROJECTION_LENGTH.Value < NUD_GRADIENT_KERNEL_SIZE.Value)
                NUD_GRADIENT_KERNEL_SIZE.Value = NUD_PROJECTION_LENGTH.Value;
        }

        private void NUD_MAX_LINENUM_ValueChanged(object sender, EventArgs e)
        {
            // 9.1에서 Multiple line 지원 안함...
            PT_LineMaxTool.RunParams.MaxNumLines = (int)NUD_MAX_LINENUM.Value;

            //if (PT_LineMaxTool.RunParams.MaxNumLines > 1)
            //{
            //    label46.Visible = true; RBTN_HORICON_YMIN.Visible = true; RBTN_HORICON_YMAX.Visible = true;
            //    label47.Visible = true; RBTN_VERTICON_XMIN.Visible = true; RBTN_VERTICON_XMAX.Visible = true;

            //    try
            //    {
            //        RBTN_LINEMAX_H_COND[PT_FindLinePara[TapNo, m_SelectFindLine].m_LineMaxHCond].Checked = true;
            //        RBTN_LINEMAX_V_COND[PT_FindLinePara[TapNo, m_SelectFindLine].m_LineMaxVCond].Checked = true;
            //    }
            //    catch (System.ArgumentException)
            //    {

            //    }
            //}
            //else
            //{
            //    label46.Visible = false; RBTN_HORICON_YMIN.Visible = false; RBTN_HORICON_YMAX.Visible = false;
            //    label47.Visible = false; RBTN_VERTICON_XMIN.Visible = false; RBTN_VERTICON_XMAX.Visible = false;
            //}
        }

        private void NUD_ANGLE_TOLERANCE_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.EdgeAngleTolerance = (double)NUD_ANGLE_TOLERANCE.Value * Main.DEFINE.radian;
        }

        private void NUD_DIST_TOLERANCE_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.DistanceTolerance = (int)NUD_DIST_TOLERANCE.Value;
        }

        private void NUD_LINE_ANGLE_TOL_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.LineAngleTolerance = (double)NUD_LINE_ANGLE_TOL.Value * Main.DEFINE.radian;
        }

        private void NUD_COVERAGE_THRES_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.CoverageThreshold = (double)NUD_COVERAGE_THRES.Value;
        }

        private void NUD_LENGTH_THRES_ValueChanged(object sender, EventArgs e)
        {
            PT_LineMaxTool.RunParams.LengthThreshold = (double)NUD_LENGTH_THRES.Value;
        }

        private void RBTN_LINEMAX_CONDITION_Clicked(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            if (TempBTN.Name == "RBTN_HORICON_YMIN")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineMaxHCond = Main.DEFINE.LINEMAX_H_YMIN;
            }
            else if (TempBTN.Name == "RBTN_HORICON_YMAX")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineMaxHCond = Main.DEFINE.LINEMAX_H_YMAX;

            }
            else if (TempBTN.Name == "RBTN_VERTICON_XMIN")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineMaxVCond = Main.DEFINE.LINEMAX_V_XMIN;

            }
            else if (TempBTN.Name == "RBTN_VERTICON_XMAX")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineMaxVCond = Main.DEFINE.LINEMAX_V_XMAX;

            }
        }

        private void RBTN_CALIPER_METHOD_Clicked(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            if (TempBTN.Name == "RBTN_CALIPER_METHOD_SCROE")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod = Main.DEFINE.CLP_METHOD_SCORE;
            }
            else if (TempBTN.Name == "RBTN_CALIPER_METHOD_POS")
            {
                PT_FindLinePara[TapNo, m_LineSubNo, m_SelectFindLine].m_LineCaliperMethod = Main.DEFINE.CLP_METHOD_POS;
            }
            else if (TempBTN.Name == "RBTN_CIR_CALIPER_METHOD_SCROE")
            {
                PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod = Main.DEFINE.CLP_METHOD_SCORE;
            }
            else if (TempBTN.Name == "RBTN_CIR_CALIPER_METHOD_POS")
            {
                PT_CirclePara[TapNo, m_SelectCircle].m_CircleCaliperMethod = Main.DEFINE.CLP_METHOD_POS;
            }
        }

        private void RBTN_CALIPER_METHOD_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }

        private void CB_FINDLINE_SUBLINE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_LineSubNo = CB_FINDLINE_SUBLINE.SelectedIndex;

            FINDLINE_Change();
        }

        private void CheckChangedParams(int nAlignUnit, int nCamUnit, string ParaName, bool oldPara, bool newPara)
        {
            string strLog = "CAM" + nAlignUnit.ToString();

            if (nCamUnit == Main.DEFINE.CAM_SELECT_ALIGN)
                strLog += " ALIGN ";
            else if (nCamUnit == Main.DEFINE.CAM_SELECT_INSPECT)
                strLog += " INSPECTION ";

            if (oldPara != newPara)
            {
                strLog += ParaName + " [" + oldPara.ToString() + "] ▶▷▶ [" + newPara.ToString() + "]";
                Save_SystemLog(strLog, Main.DEFINE.CHANGEPARA);
            }
        }

        private void CheckChangedParams(int nAlignUnit, int nCamUnit, string ParaName, int oldPara, int newPara)
        {
            string strLog = "CAM" + nAlignUnit.ToString();

            if (nCamUnit == Main.DEFINE.CAM_SELECT_ALIGN)
                strLog += " ALIGN ";
            else if (nCamUnit == Main.DEFINE.CAM_SELECT_INSPECT)
                strLog += " INSPECTION ";

            if (oldPara != newPara)
            {
                strLog += ParaName + " [" + oldPara + "] ▶▷▶ [" + newPara + "]";
                Save_SystemLog(strLog, Main.DEFINE.CHANGEPARA);
            }
        }

        private void CheckChangedParams(int nAlignUnit, int nCamUnit, string ParaName, double oldPara, double newPara)
        {
            string strLog = "CAM" + nAlignUnit.ToString();

            if (nCamUnit == Main.DEFINE.CAM_SELECT_ALIGN)
                strLog += " ALIGN ";
            else if (nCamUnit == Main.DEFINE.CAM_SELECT_INSPECT)
                strLog += " INSPECTION ";

            if (oldPara != newPara)
            {
                strLog += ParaName + " [" + oldPara.ToString("0.0000") + "] ▶▷▶ [" + newPara.ToString("0.0000") + "]";
                Save_SystemLog(strLog, Main.DEFINE.CHANGEPARA);
            }
        }

        private void CheckChangedParams(int nAlignUnit, int nCamUnit, string ParaName, string oldPara, string newPara)
        {
            string strLog = "CAM" + nAlignUnit.ToString();

            if (nCamUnit == Main.DEFINE.CAM_SELECT_ALIGN)
                strLog += " ALIGN ";
            else if (nCamUnit == Main.DEFINE.CAM_SELECT_INSPECT)
                strLog += " INSPECTION ";

            if (oldPara != newPara)
            {
                strLog += ParaName + " [" + oldPara + "] ▶▷▶ [" + newPara + "]";
                Save_SystemLog(strLog, Main.DEFINE.CHANGEPARA);
            }
        }

        object syncLock_Log = new object();
        private void Save_SystemLog(string nMessage, string nType)
        {
            string nFolder;
            string nFileName = "";
            nFolder = Main.LogdataPath + DateTime.Now.ToString("yyyyMMdd") + "\\";
            if (!Directory.Exists(Main.LogdataPath)) Directory.CreateDirectory(Main.LogdataPath);
            if (!Directory.Exists(nFolder)) Directory.CreateDirectory(nFolder);

            string Date;
            Date = DateTime.Now.ToString("[MM_dd HH:mm:ss:fff] ");

            lock (syncLock_Log)
            {
                try
                {
                    switch (nType)
                    {
                        case Main.DEFINE.CHANGEPARA:
                            nFileName = "ChangePara.txt";
                            nMessage = Date + nMessage;
                            break;
                        case Main.DEFINE.DATA:
                            nFileName = "Data.csv";
                            nMessage = Date + nMessage;
                            break;
                    }

                    StreamWriter SW = new StreamWriter(nFolder + nFileName, true, Encoding.Unicode);
                    SW.WriteLine(nMessage);
                    SW.Close();
                }
                catch
                {

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (PT_DISPLAY_CONTROL.CrossLineChecked) CrossLine();
            timer2.Enabled = false;
        }

        private void LB_SEARCH_CIR_Click(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(10, 10000, PT_CircleTool.RunParams.CaliperSearchLength, "CALIPER SEARCH LENGTH", 1))
                {
                    form_keypad.ShowDialog();
                    PT_CircleTool.RunParams.CaliperSearchLength = form_keypad.m_data;
                }
                DrawCircleRegion();
            }
        }

        private void LB_PROJECTION_CIR_Click(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(10, 10000, PT_CircleTool.RunParams.CaliperProjectionLength, "CALIPER PROJECTION LENGTH", 1))
                {
                    form_keypad.ShowDialog();
                    PT_CircleTool.RunParams.CaliperProjectionLength = form_keypad.m_data;
                }
                DrawCircleRegion();
            }
        }

        private void LB_RADIUS_CIR_Click(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1")
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(10, 10000, PT_CircleTool.RunParams.ExpectedCircularArc.Radius, "EXPECED CIRCULAR_ARC RADIUS", 1))
                {
                    form_keypad.ShowDialog();
                    PT_CircleTool.RunParams.ExpectedCircularArc.Radius = form_keypad.m_data;
                    LB_RADIUS_CIR.Text = PT_CircleTool.RunParams.ExpectedCircularArc.Radius.ToString(); //이 파라미터는 changed에서 안들어감 버그인듯. 다른건들어감
                }
                DrawCircleRegion();
            }
        }

        private void BTN_DIVIDECNT_UP_Click(object sender, EventArgs e)
        {
            if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt < 0) PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt = 0;
            try
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt++;
                if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt >= 10)
                    PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt = 10;
                LB_DIVIDE_COUNT.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCaliperRegion();
        }

        private void BTN_DIVIDECNT_DOWN_Click(object sender, EventArgs e)
        {
            if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt < 0) PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt = 0;
            try
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt--;
                if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt < 0)
                    PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt = 0;
                LB_DIVIDE_COUNT.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCaliperRegion();
        }

        private void BTN_DIVIDEOFFSET_UP_Click(object sender, EventArgs e)
        {
            if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset < 0) PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset = 0;
            try
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset++;
                if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset >= 10)
                    PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset = 10;
                LB_DIVIDE_OFFSET.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCaliperRegion();
        }

        private void BTN_DIVIDEOFFSET_DOWN_Click(object sender, EventArgs e)
        {
            if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset < 0) PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset = 0;
            try
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset--;
                if (PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset < 0)
                    PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset = 0;
                LB_DIVIDE_OFFSET.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset.ToString();
            }
            catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            DrawCaliperRegion();
        }

        private void CB_COP_MODE_CHECK_Click(object sender, EventArgs e)
        {
            if (CB_COP_MODE_CHECK.Checked)
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode = true;
                label52.Visible = true; LB_DIVIDE_COUNT.Visible = true; BTN_DIVIDECNT_UP.Visible = true; BTN_DIVIDECNT_DOWN.Visible = true;
                label53.Visible = true; LB_DIVIDE_OFFSET.Visible = true; BTN_DIVIDEOFFSET_UP.Visible = true; BTN_DIVIDEOFFSET_DOWN.Visible = true;

                LB_DIVIDE_COUNT.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROICnt.ToString();
                LB_DIVIDE_OFFSET.Text = PT_CaliPara[TapNo, m_SelectCaliper].m_nCOPROIOffset.ToString();
            }
            else
            {
                PT_CaliPara[TapNo, m_SelectCaliper].m_bCOPMode = false;
                label52.Visible = false; LB_DIVIDE_COUNT.Visible = false; BTN_DIVIDECNT_UP.Visible = false; BTN_DIVIDECNT_DOWN.Visible = false;
                label53.Visible = false; LB_DIVIDE_OFFSET.Visible = false; BTN_DIVIDEOFFSET_UP.Visible = false; BTN_DIVIDEOFFSET_DOWN.Visible = false;
            }
        }

        private void CB_COP_MODE_CHECK_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_COP_MODE_CHECK.Checked)
            {
                CB_COP_MODE_CHECK.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                CB_COP_MODE_CHECK.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        private void RBTN_AKKON00_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;
            if (TempBTN.Checked)
                TempBTN.BackColor = System.Drawing.Color.LawnGreen;
            else
                TempBTN.BackColor = System.Drawing.Color.DarkGray;
        }

        private void RBTN_AKKON00_Click(object sender, EventArgs e)
        {
            //RadioButton TempBTN = (RadioButton)sender;
            //int m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2));

            //if (TempBTN.Checked)
            {
                //m_SelectCaliper = m_Number;
                Akkon_Change();
                RefreshAkkonRegion();
            }
        }

        private void DrawAkkonRegion()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_AKKONTOOL)
            {
                DisplayClear();
                //PTAkkonRegion = new CogRectangleAffine(PT_CaliperTools[TapNo, m_SelectCaliper].Region);
                PTAkkonRegion = new CogRectangleAffine();

                if (PT_Akkon_MarkUSE[TapNo])
                {
                    PTAkkonRegion.CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                    PTAkkonRegion.CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                }

                PTAkkonRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                PTAkkonRegion.Interactive = true;
                PT_Display01.InteractiveGraphics.Add(PTAkkonRegion, "AKKON", false);

                Main.DisplayFit(PT_Display01);
            }
        }

        private void BTN_AKKON_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (PTAkkonRegion != null)
                {
                    if (PT_Akkon_MarkUSE[TapNo])
                    {
                        PTAkkonRegion.CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        PTAkkonRegion.CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }

                    CogRectangleAffine tempRectAffine = new CogRectangleAffine(PTAkkonRegion);
                    PT_AkkonPara[TapNo].AkkonBumpROIList.Add(tempRectAffine);

                    LABEL_MESSAGE(LB_MESSAGE, "Register OK", System.Drawing.Color.Lime);

                    RefreshAkkonRegion();

                    if (PT_Akkon_MarkUSE[TapNo])
                    {
                        PTAkkonRegion.CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        PTAkkonRegion.CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }
                    PTAkkonRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    PTAkkonRegion.Interactive = true;
                    PT_Display01.InteractiveGraphics.Add(PTAkkonRegion, "AKKON", false);
                }
                else
                    LABEL_MESSAGE(LB_MESSAGE, "Select!!! Akkon", System.Drawing.Color.Red);
            }
            catch (System.Exception ex)
            {
                LABEL_MESSAGE(LB_MESSAGE, ex.Message, System.Drawing.Color.Red);
            }
        }

        void InitAkkonDataGrid()
        {
            DataGridView tempdataGridView = new DataGridView();

            tempdataGridView = DG_AKKON_ROI_LIST;

            tempdataGridView.RowCount = PT_AkkonPara[TapNo].AkkonBumpROIList.Count;

            System.Windows.Forms.DataGridViewCellStyle[] dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle[tempdataGridView.RowCount];
            for (int i = 0; i < tempdataGridView.RowCount; i++)
            {
                dataGridViewCellStyle[i] = new DataGridViewCellStyle();
                if (i % 2 == 0)
                    dataGridViewCellStyle[i].BackColor = System.Drawing.Color.Bisque;
                else
                    dataGridViewCellStyle[i].BackColor = System.Drawing.Color.LightCyan;

                tempdataGridView.Rows[i].DefaultCellStyle = dataGridViewCellStyle[i];
                tempdataGridView.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void RefreshAkkonRegion()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_AKKONTOOL)
            {
                DisplayClear();
                DG_AKKON_ROI_LIST.Rows.Clear();
                if (bGroupModeFlag)
                {
                    DG_AKKON_ROI_LIST.RowCount = LeadGroupInfo[nSelectGroupNumber].LeadCount;

                    //현재 선택된 Group 번호에 해당하는 ROI View
                    for (int i = 0; i < LeadGroupInfo[nSelectGroupNumber].LeadCount; i++)
                    {
                        if (GroupListLeadData[nSelectGroupNumber].Count == 0)
                            continue;

                        GroupListLeadData[nSelectGroupNumber][i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        GroupListLeadData[nSelectGroupNumber][i].Interactive = false;
                        PT_Display01.InteractiveGraphics.Add(GroupListLeadData[nSelectGroupNumber][i], "AKKON", false);

                        DG_AKKON_ROI_LIST[0, i].Value = (i + 1).ToString();
                        DG_AKKON_ROI_LIST[1, i].Value = "(" + GroupListLeadData[nSelectGroupNumber][i].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][i].CornerOriginY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[2, i].Value = "(" + GroupListLeadData[nSelectGroupNumber][i].CornerXX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][i].CornerXY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[3, i].Value = "(" + GroupListLeadData[nSelectGroupNumber][i].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][i].CornerOppositeY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[4, i].Value = "(" + GroupListLeadData[nSelectGroupNumber][i].CornerYX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][i].CornerYY.ToString("0.0") + ")";
                    }
                }
                else
                {
                    DG_AKKON_ROI_LIST.RowCount = PT_AkkonPara[TapNo].AkkonBumpROIList.Count;

                    for (int i = 0; i < PT_AkkonPara[TapNo].AkkonBumpROIList.Count; i++)
                    {
                        if (PT_Akkon_MarkUSE[TapNo])
                        {
                            PT_AkkonPara[TapNo].AkkonBumpROIList[i].CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[i].CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                        }

                        PT_AkkonPara[TapNo].AkkonBumpROIList[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        PT_AkkonPara[TapNo].AkkonBumpROIList[i].Interactive = false;
                        PT_Display01.InteractiveGraphics.Add(PT_AkkonPara[TapNo].AkkonBumpROIList[i], "AKKON", false);

                        DG_AKKON_ROI_LIST[0, i].Value = (i + 1).ToString();
                        DG_AKKON_ROI_LIST[1, i].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerOriginX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerOriginY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[2, i].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerXX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerXY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[3, i].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerOppositeX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerOppositeY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[4, i].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerYX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[i].CornerYY.ToString("0.0") + ")";
                    }
                }


                Main.DisplayFit(PT_Display01);
            }
        }

        private void RefreshAkkonResult()
        {
            if (Convert.ToInt32(TABC_MANU.SelectedTab.Tag) == Main.DEFINE.M_AKKONTOOL)
            {
                DisplayClear();
                DG_AKKON_RESULT.Rows.Clear();
                DG_AKKON_RESULT.RowCount = Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo].Length;

                for (int i = 0; i < Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo].Length; i++)
                {
                    DG_AKKON_RESULT[0, i].Value = (i + 1).ToString();
                    DG_AKKON_RESULT[1, i].Value = Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo][i].s_nNumBlobs.ToString();
                    DG_AKKON_RESULT[2, i].Value = Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo][i].s_fLength.ToString("0.000");
                    DG_AKKON_RESULT[3, i].Value = Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo][i].s_fAvgStrength.ToString("0.000");
                    DG_AKKON_RESULT[4, i].Value = Main.AlignUnit[CamNo].PAT[0, TapNo].AkkonResult[0].AkkonResultArray[TapNo][i].s_bJudgement.ToString();
                }

                TAB_ATT_LIST.SelectedIndex = 1;

                Main.DisplayFit(PT_Display01);
            }
        }

        private void BTN_AKKON_ROI_SKEW_Click(object sender, EventArgs e)
        {
            double dSkewUnit = 0.001;

            int nMode = 0;
            nMode = Convert.ToInt32(TABC_MANU.SelectedTab.Tag);
            try
            {
                Button TempBTN = (Button)sender;
                switch (TempBTN.Name.Substring(TempBTN.Name.Length - 4, 4))
                {
                    case "_CCW":
                        dSkewUnit *= -1;
                        break;

                    case "W_CW":
                        dSkewUnit *= 1;
                        break;

                    case "ZERO":
                        PTAkkonRegion.Skew = 0;
                        break;
                }

                dSkewUnit /= PT_Display01.Zoom;

                if (nMode == Main.DEFINE.M_AKKONTOOL)
                {
                    foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                    {
                        if (bGroupModeFlag)
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].Skew += dSkewUnit;

                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data)].Value = (Convert.ToInt32(data) + 1).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data)].Value = "(" + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                        }
                        else
                        {
                            string data = row.Cells[0].Value.ToString(); // row의 컬럼
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Skew += dSkewUnit;


                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                            PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;
                            PT_Display01.InteractiveGraphics.Add(PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)], "AKKON", false);

                            DG_AKKON_ROI_LIST[0, Convert.ToInt32(data)].Value = (Convert.ToInt32(data) + 1).ToString();
                            DG_AKKON_ROI_LIST[1, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[2, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[3, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeY.ToString("0.0") + ")";
                            DG_AKKON_ROI_LIST[4, Convert.ToInt32(data)].Value = "(" + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYX.ToString("0.0") + "," + PT_AkkonPara[TapNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYY.ToString("0.0") + ")";
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void BTN_AKKON_LOAD_ROI_Click(object sender, EventArgs e)
        {
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                int count = 0;
                int lineCount = File.ReadAllLines(openFileDialog1.FileName).Length;
                int[][] nLeadPoint = new int[lineCount][];
                while (!sr.EndOfStream)
                {
                    string currentline = sr.ReadLine();
                    //string[] tabs = currentline.Split('\t');
                    string[] tabs = currentline.Split(' ');

                    nLeadPoint[count] = new int[8];
                    for (int i = 0; i < 8; i++)
                    {
                        nLeadPoint[count][i] = Convert.ToInt32(tabs[i]);
                    }

                    CogRectangleAffine tempRectAffine = new CogRectangleAffine();
                    tempRectAffine.SetOriginCornerXCornerY(nLeadPoint[count][0], nLeadPoint[count][1], nLeadPoint[count][2], nLeadPoint[count][3], nLeadPoint[count][6], nLeadPoint[count][7]);
                    PT_AkkonPara[TapNo].AkkonBumpROIList.Add(tempRectAffine);

                    count++;
                }
                sr.Close();

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[0].AkkonBumpROIList = PT_AkkonPara[TapNo].AkkonBumpROIList;

                TAB_ATT_LIST.SelectedIndex = 0;

                RefreshAkkonRegion();

                bool bReadRoi = Main.ATT_SendROI(CamNo, TapNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    return;
                }
            }
        }

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

        public static void AkkonResultProcess(int nCamNo, int nStageNo, int nTapNo, bool bSliceInsp, int nError)
        {
            if (nError == 0)
            {
                //m_rstImage = new Mat(m_vvReadMats[nStageNo][nTapNo].Size(), MatType.CV_8UC3);
                if (bSliceInsp == false)
                {
                    //DLL에서 검사결과 받아옴
                    Main.ATT_GetResult(nCamNo, nStageNo, nTapNo);

                    WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].AkkonResultArray.Length, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].AkkonResultArray);
                    //String strPath;
                    //strPath = String.Format("D:\\CS ATT_Result_Image.bmp");
                    //Cv2.ImWrite(strPath, Main.AlignUnit[nStageNo].PAT[0, nTapNo].m_imgOverlay);


                    PT_Display01.Image = Main.AlignUnit[nStageNo].PAT[0, nTapNo].m_imgOverlay;

                    _bATTResult = true;
                    // 결과 이미지 저장해서 보기
                    //CogImageFileBMP imagecontrol = new CogImageFileBMP();
                    //string fileName = "D:\\MacronDllTrace\\Output.bmp";
                    //try
                    //{
                    //    imagecontrol.Open(fileName, Cognex.VisionPro.ImageFile.CogImageFileModeConstants.Write);
                    //    imagecontrol.Append(Main.AlignUnit[nStageNo].PAT[0, nTapNo].m_imgOverlay);
                    //    imagecontrol.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
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

                //    WriteLeadInfo(nStageNo, nTapNo, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult.Length, Main.AlignUnit[nStageNo].PAT[0, nTapNo].AkkonResult[0].m_AkkonResult);

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

        private void CB_ATT_INSP_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_nInspType = CB_ATT_INSP_TYPE.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_PANEL_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nIsFlexible = CB_ATT_PANEL_TYPE.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_TARGET_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nPanelInfo = CB_ATT_TARGET_TYPE.SelectedIndex;

            // default parameter 변경
            if (CB_ATT_TARGET_TYPE.SelectedIndex == 0) // COF
            {
                CB_ATT_FILTER_TYPE.SelectedIndex = 3;
                CB_ATT_FILTER_TYPE_SelectionChangeCommitted(null, null);

                CB_ATT_PEAK_PROP.SelectedIndex = 0;
                CB_ATT_PEAK_PROP_SelectionChangeCommitted(null, null);

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight = 2;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor = 1;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak = 70;

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize = 15;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance = 3;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                CB_ATT_STREN_BASE.SelectedIndex = 0;
                CB_ATT_STREN_BASE_SelectionChangeCommitted(null, null);
            }
            else if (CB_ATT_TARGET_TYPE.SelectedIndex == 1) // COG
            {
                CB_ATT_FILTER_TYPE.SelectedIndex = 4;
                CB_ATT_FILTER_TYPE_SelectionChangeCommitted(null, null);

                CB_ATT_PEAK_PROP.SelectedIndex = 1;
                CB_ATT_PEAK_PROP_SelectionChangeCommitted(null, null);

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight = 1.5;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.2;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak = 70;

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize = 0;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize = 100;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance = 2;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio = -100;

                CB_ATT_STREN_BASE.SelectedIndex = 1;
                CB_ATT_STREN_BASE_SelectionChangeCommitted(null, null);
            }
            else // FOG
            {
                CB_ATT_FILTER_TYPE.SelectedIndex = 0;
                CB_ATT_FILTER_TYPE_SelectionChangeCommitted(null, null);

                CB_ATT_PEAK_PROP.SelectedIndex = 1;
                CB_ATT_PEAK_PROP_SelectionChangeCommitted(null, null);

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight = 4;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.5;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak = 70;

                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize = 30;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance = 5;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                CB_ATT_STREN_BASE.SelectedIndex = 1;
                CB_ATT_STREN_BASE_SelectionChangeCommitted(null, null);
            }
            Akkon_Change();
        }

        private void CB_ATT_FILTER_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eFilterType = (EN_MVFILTERTYPE_WRAP)CB_ATT_FILTER_TYPE.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_FILTER_DIR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nFilterDir = CB_ATT_FILTER_DIR.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_THRES_MODE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eThMode = (EN_THMODE_WRAP)CB_ATT_THRES_MODE.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_SHADOW_DIR_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eShadowDir = (EN_SHADOWDIR_WRAP)CB_ATT_SHADOW_DIR.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_PEAK_PROP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_ePeakProp = (EN_PEAK_PROP_WRAP)CB_ATT_PEAK_PROP.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_STREN_BASE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_eStrengthBase = (EN_STRENGTH_BASE_WRAP)CB_ATT_STREN_BASE.SelectedIndex;
            Akkon_Change();
        }

        private void CB_ATT_USE_LOG_TRACE_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_ATT_USE_LOG_TRACE.Checked)
            {
                CB_ATT_USE_LOG_TRACE.BackColor = System.Drawing.Color.LawnGreen;
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_bLogTrace = true;
            }
            else
            {
                CB_ATT_USE_LOG_TRACE.BackColor = System.Drawing.Color.DarkGray;
            }
            Akkon_Change();
        }

        private void CB_ATT_USE_LOG_TRACE_Click(object sender, EventArgs e)
        {
            if (CB_ATT_USE_LOG_TRACE.Checked)
            {
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_bLogTrace = true;
            }
            else
            {
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionOption.s_bLogTrace = false;
            }
            Akkon_Change();
        }

        private void LB_ATT_THRES_WEIGHT_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight, "THRESHOLD WEIGHT", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fThWeight = form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_PEAK_THRES_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 255, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak, "PEAK THRESHOLD", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nThPeak = (int)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_STREN_SCALE_FACTOR_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor, "STRENGTH SCALE FACTOR", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_SLICE_OVERLAP_Click(object sender, EventArgs e)
        {

        }

        private void LB_ATT_STD_DEV_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStdDevLeadJudge, "LEAD JUDGE STANDARD DEVIATION", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStdDevLeadJudge = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_MIN_SZ_FILTER_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1000, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize, "AKKON MIN SIZE FILTER (um)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMinSize = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_MAX_SZ_FILTER_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1000, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize, "AKKON MAX SIZE FILTER (um)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fMaxSize = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_GRP_DIST_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance, "AKKON GROUP DISTANCE (pixel)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fGroupingDistance = form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_STRN_FILTER_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold, "STRENGTH FILTER (%)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_fStrengthThreshold = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_WIDTH_CUT_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nWidthCut, "AKKON WIDTH CUT (pixel)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nWidthCut = (int)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_HEIGHT_CUT_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nHeight, "AKKON HEIGHT CUT (pixel)", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_nHeightCut = (int)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_BW_RATIO_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(-100, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio, "AKKON BW RATIO", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionFilter.s_fBWRatio = (float)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_EXTRE_LEAD_DISP_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nExtraLead, "EXTRA LEAD DISPLAY", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].AkkonInspectionParameter.s_nExtraLead = (int)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void BTN_AKKON_CLEAR_ROI_Click(object sender, EventArgs e)
        {
            if (bGroupModeFlag)
            {
                GroupListLeadData[nSelectGroupNumber].Clear();
            }
            else
            {
                PT_AkkonPara[TapNo].AkkonBumpROIList.Clear();
                TAB_ATT_LIST.SelectedIndex = 0;
            }

            RefreshAkkonRegion();

            int[][] nLeadPoint = new int[0][];

            bool bReadRoi = Main.ATT_SendROI(CamNo, TapNo, nLeadPoint); // stage, tab 별로 ROI 전송

            if (bReadRoi == false)
            {
                MessageBox.Show("Can't Read ROI File!!");
                return;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (_bATTResult == true)
            {
                _bATTResult = false;

                RefreshAkkonResult();
            }
        }

        private void cog_Display_Thumbnail_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cog_Display_Thumbnail.GetType())
            {
                Cognex.VisionPro.CogRecordDisplay thumbnailDisplay = (Cognex.VisionPro.CogRecordDisplay)sender;
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;
                System.Drawing.Point mousePos = new System.Drawing.Point(x, y); //프로그램 내 좌표

                System.Drawing.Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당

                System.Drawing.Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)


                this.Text = x.ToString() + ", " + y.ToString() +

                    "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();


                double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

                double panPointX = (double)PT_Display01.Image.Width * ratio;
                if (PT_Display01.Zoom > 0 && PT_Display01.Zoom < 0.2)
                {
                    PT_Display01.Zoom = 0.5;
                }
                panPointX = (PT_Display01.Image.Width / 2) - panPointX;
                PT_Display01.PanX = panPointX;


                Thumbnail_MoveFlag = true;
                //if (((MouseEventArgs)e).Button == MouseButtons.Left)
                //{
                //    //do something                    
                //}

                //if (((MouseEventArgs)e).Button == MouseButtons.Right)
                //{
                //    //do something

                //}
            }
        }

        private void cog_Display_Thumbnail_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == cog_Display_Thumbnail.GetType() && Thumbnail_MoveFlag)
            {
                Cognex.VisionPro.CogRecordDisplay thumbnailDisplay = (Cognex.VisionPro.CogRecordDisplay)sender;
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;
                System.Drawing.Point mousePos = new System.Drawing.Point(x, y); //프로그램 내 좌표

                System.Drawing.Point mousePosPtoClient = thumbnailDisplay.PointToClient(mousePos);  //picbox 내 좌표, 해당 좌표 할당

                System.Drawing.Point mousePosPtoScreen = thumbnailDisplay.PointToScreen(mousePos);  //스크린 내 좌표 (좌우 스크린 합친듯?)


                this.Text = x.ToString() + ", " + y.ToString() +

                    "//, " + mousePosPtoClient.X.ToString() + ", " + mousePosPtoClient.Y.ToString() + "//width : " + thumbnailDisplay.Width.ToString();


                double ratio = (double)mousePosPtoClient.X / (double)thumbnailDisplay.Width;

                double panPointX = (double)PT_Display01.Image.Width * ratio;
                if (PT_Display01.Zoom > 0 && PT_Display01.Zoom < 0.2)
                {
                    PT_Display01.Zoom = 0.5;
                }
                panPointX = (PT_Display01.Image.Width / 2) - panPointX;
                PT_Display01.PanX = panPointX;



                //if (((MouseEventArgs)e).Button == MouseButtons.Left)
                //{
                //    //do something                    
                //}

                //if (((MouseEventArgs)e).Button == MouseButtons.Right)
                //{
                //    //do something

                //}
            }
        }

        private void cog_Display_Thumbnail_MouseUp(object sender, MouseEventArgs e)
        {
            Thumbnail_MoveFlag = false;
        }

        private void BTN_AKKON_LEFT_MARK_Click(object sender, EventArgs e)
        {
            m_AkkonPatChangeFlag = true;
            m_AkkonPatSelectPosFlag = false;
            TABC_MANU.SelectedIndex = M_TOOL_MODE = 0;

            DrawTrainedATTPattern(PT_SubDisplay[m_PatNo_Sub], PT_AkkonPara[TapNo].LeftPattern[m_PatNo_Sub]);
        }

        private void BTN_AKKON_RIGHT_MARK_Click(object sender, EventArgs e)
        {
            m_AkkonPatChangeFlag = true;
            m_AkkonPatSelectPosFlag = true;
            TABC_MANU.SelectedIndex = M_TOOL_MODE = 0;

            DrawTrainedATTPattern(PT_SubDisplay[m_PatNo_Sub], PT_AkkonPara[TapNo].RightPattern[m_PatNo_Sub]);
        }

        private void LB_ATT_MOVE_PIXEL_COUNT_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 50000, nMovePixelCount, "Input Move Pixel Count", 1))
            {
                form_keypad.ShowDialog();
                nMovePixelCount = (int)form_keypad.m_data;
                LB_ATT_MOVE_PIXEL_COUNT.Text = nMovePixelCount.ToString();
            }

        }

        private void BTN_AKKON_GROUP_Click(object sender, EventArgs e)
        {
            //버튼UI 재 정리
            bGroupModeFlag = !bGroupModeFlag;
            if (bGroupModeFlag)
            {
                GroupListLeadData.Clear();
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
                panel7.Location = new System.Drawing.Point(506, 5);
                //진입 시 첫번째 Group 정보가 표시되도록 고정
                nSelectGroupNumber = 0;
                //Group데이터가 없을 경우 Default로 1개 생성 YSH
                if (PT_AkkonPara[TapNo].LeadGroupCount == 0)
                {
                    PT_AkkonPara[TapNo].LeadGroupCount = 1;
                    LeadGroupInfo[0].LeadCount = 1;
                    LeadGroupInfo[0].LeadPitch = 1;
                    NEW_ROI_CREATE();
                    GroupListLeadData.Add(new List<CogRectangleAffine>());
                    GroupListLeadData[nSelectGroupNumber].Add(cogRectNewROI);
                }
                else
                {
                    int nCount = 0;
                    CB_ATT_GROUP_NO.Items.Clear();
                    //Group별 Lead Data 생성
                    for (int i = 0; i < PT_AkkonPara[TapNo].LeadGroupCount; i++)
                    {
                        if (PT_AkkonPara[TapNo].AkkonBumpROIList.Count == 0)
                            continue;

                        GroupListLeadData.Add(new List<CogRectangleAffine>());
                        CB_ATT_GROUP_NO.Items.Add(i + 1);
                        //Group 별 Lead 개수만큼 지정
                        for (int j = 0; j < LeadGroupInfo[i].LeadCount; j++)
                        {
                            GroupListLeadData[i].Add(PT_AkkonPara[TapNo].AkkonBumpROIList[nCount]);
                            nCount++;
                        }
                    }

                }
                LB_ATT_GROUP_COUNT.Text = PT_AkkonPara[TapNo].LeadGroupCount.ToString();
                CB_ATT_GROUP_NO.Text = (nSelectGroupNumber + 1).ToString();
                LB_ATT_LEAD_COUNT.Text = LeadGroupInfo[nSelectGroupNumber].LeadCount.ToString();
                LB_ATT_LEAD_PITCH.Text = LeadGroupInfo[nSelectGroupNumber].LeadPitch.ToString();
                RefreshAkkonRegion();
            }
            else
            {
                panel4.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = false;
            }


        }

        private void LB_ATT_GROUP_COUNT_Click(object sender, EventArgs e)
        {
            int GroupTotalCount = 1;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, Main.DEFINE.MAX_LEAD_GROUP_COUNT, GroupTotalCount, "Input Group Total Count", 1))
            {
                form_keypad.ShowDialog();
                GroupTotalCount = (int)form_keypad.m_data;
                LB_ATT_GROUP_COUNT.Text = GroupTotalCount.ToString();
                CB_ATT_GROUP_NO.Items.Clear();
                PT_AkkonPara[TapNo].LeadGroupCount = GroupTotalCount;

                GroupListLeadData.Clear();
                LeadGroupInfo.Initialize();
                for (int i = 0; i < PT_AkkonPara[TapNo].LeadGroupCount; i++)
                {
                    GroupListLeadData.Add(new List<CogRectangleAffine>());
                }

                for (int i = 0; i < GroupTotalCount; i++)
                {
                    //Default Value
                    LeadGroupInfo[nSelectGroupNumber].LeadCount = 1;
                    LeadGroupInfo[nSelectGroupNumber].LeadPitch = 1;
                    CB_ATT_GROUP_NO.Items.Add(i + 1);
                }

                RefreshAkkonRegion();
            }
        }

        private void CB_ATT_GROUP_NO_SelectedIndexChanged(object sender, EventArgs e)
        {
            nSelectGroupNumber = Convert.ToInt32(CB_ATT_GROUP_NO.SelectedItem.ToString());
            nSelectGroupNumber -= 1;
            //선택한 Index에 맞는 ROI 표시
            LB_ATT_LEAD_COUNT.Text = LeadGroupInfo[nSelectGroupNumber].LeadCount.ToString();
            LB_ATT_LEAD_PITCH.Text = LeadGroupInfo[nSelectGroupNumber].LeadPitch.ToString();
            RefreshAkkonRegion();
        }

        private void BTN_ATT_ROI_CREATE_Click(object sender, EventArgs e)
        {
            DisplayClear();
            NEW_ROI_CREATE();
        }

        private void BTN_ATT_FIRSTLEAD_REGISTER_Click(object sender, EventArgs e)
        {
            //ROI List의 마지막에 추가
            GroupListLeadData[nSelectGroupNumber].Add(cogRectNewROI);
            DG_AKKON_ROI_LIST.Rows.Add(GroupListLeadData[nSelectGroupNumber].Count.ToString(), "(" + GroupListLeadData[nSelectGroupNumber].Last().CornerOriginX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber].Last().CornerOriginY.ToString("0.0") + ")",
                "(" + GroupListLeadData[nSelectGroupNumber].Last().CornerXX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber].Last().CornerXY.ToString("0.0") + ")",
                "(" + GroupListLeadData[nSelectGroupNumber].Last().CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber].Last().CornerOppositeY.ToString("0.0") + ")",
                "(" + GroupListLeadData[nSelectGroupNumber].Last().CornerYX.ToString("0.0") + "," + GroupListLeadData[nSelectGroupNumber].Last().CornerYY.ToString("0.0") + ")");

            DisplayClear();
            cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
            cogRectNewROI.Interactive = false;
            PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);

        }

        private void NEW_ROI_CREATE()
        {
            if (PT_Display01.Image == null) return;
            cogRectNewROI = new CogRectangleAffine();
            cogRectNewROI.SetCenterLengthsRotationSkew(500, 500, 100, 500, 0, 0);
            cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
            cogRectNewROI.Interactive = true;
            cogRectNewROI.SetCenterLengthsRotationSkew((PT_Display01.Image.Width / 2 - PT_Display01.PanX), (PT_Display01.Image.Height / 2 - PT_Display01.PanY),
                cogRectNewROI.SideXLength, cogRectNewROI.SideYLength, cogRectNewROI.Rotation, cogRectNewROI.Skew);

            PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
        }
        private void LB_ATT_LEAD_PITCH_Click(object sender, EventArgs e)
        {
            double LeadPitch = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, LeadPitch, "Input Lead Pitch(㎛)", 1))
            {
                form_keypad.ShowDialog();

                LeadPitch = (int)form_keypad.m_data;
                LB_ATT_LEAD_PITCH.Text = LeadPitch.ToString();

                LeadGroupInfo[nSelectGroupNumber].LeadPitch = LeadPitch;

            }
        }

        private void BTN_AKKON_CLONE_HOR_Click(object sender, EventArgs e)
        {
            bCloneROIDir = Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL);
        }

        private void BTN_AKKON_CLONE_VER_Click(object sender, EventArgs e)
        {
            bCloneROIDir = Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL);
        }

        private void BTN_ATT_ROI_COPY_Click(object sender, EventArgs e)
        {
            //ROI Data가 한개도 없을 경우 예외처리
            if (GroupListLeadData[nSelectGroupNumber].Count == 0)
            {
                MessageBox.Show("Empty ROI Data");
                return;
            }
            ExecueAutoROI();
        }
        private void ExecueAutoROI()
        {
            int nSelectIndex = 0;

            //현재 선택된 Rows 중 맨 마지막 Index 찾기
            foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                nSelectIndex = Convert.ToInt32(row.Cells[0].Value); // row의 컬럼

            CogRectangleAffine cogTempRectAffine;
            double dNewCenterX, dNewCenterY;
            nSelectIndex += -1;

            for (int i = 1; i < LeadGroupInfo[nSelectGroupNumber].LeadCount + 1; ++i)
            {
                dNewCenterX = GroupListLeadData[nSelectGroupNumber][nSelectIndex].CenterX;
                dNewCenterY = GroupListLeadData[nSelectGroupNumber][nSelectIndex].CenterY;

                if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL))
                    dNewCenterY += (LeadGroupInfo[nSelectGroupNumber].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                else if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL))
                    dNewCenterX += (LeadGroupInfo[nSelectGroupNumber].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                else
                    continue;

                cogTempRectAffine = new CogRectangleAffine(GroupListLeadData[nSelectGroupNumber][nSelectIndex]);
                cogTempRectAffine.CenterX = dNewCenterX;
                cogTempRectAffine.CenterY = dNewCenterY;

                GroupListLeadData[nSelectGroupNumber].Add(cogTempRectAffine);
            }


            RefreshAkkonRegion();
        }

        private void LB_ATT_LEAD_COUNT_Click(object sender, EventArgs e)
        {
            int LeadCount = 0;
            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, LeadCount, "Input Lead Pitch(㎛)", 1))
            {
                form_keypad.ShowDialog();

                LeadCount = (int)form_keypad.m_data;
                LB_ATT_LEAD_COUNT.Text = LeadCount.ToString();

                LeadGroupInfo[nSelectGroupNumber].LeadCount = LeadCount;
            }
        }

        private void RBTN_ALIGN_INSPOS_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            switch (TempBTN.Text)
            {
                case "LEFT":
                    nInspectionPos = (int)ALIGN_INDEX.INSP_POS_LEFT;
                    break;
                case "RIGHT":
                    nInspectionPos = (int)ALIGN_INDEX.INSP_POS_RIGHT;
                    break;
            }
            Align_Change();
        }

        private void RBTN_ALIGNPOS_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            switch (TempBTN.Text)
            {
                case "X":
                    nAlignPos = (int)ALIGN_INDEX.ALIGN_POS_X;
                    break;
                case "Y":
                    nAlignPos = (int)ALIGN_INDEX.ALIGN_POS_Y;
                    break;
            }
            Align_Change();
        }

        private void RBTN_ALIGN_TEACH_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            switch (TempBTN.Text)
            {
                case "MARK":
                    nTeachMode = (int)ALIGN_INDEX.TEACH_MODE_MARK;
                    break;
                case "EDGE":
                    nTeachMode = (int)ALIGN_INDEX.TEACH_MODE_EDGE;
                    break;
            }
            Align_Change();
        }

        private void RBTN_ALIGN_TARPOS_Click(object sender, EventArgs e)
        {
            RadioButton TempBTN = (RadioButton)sender;

            switch (TempBTN.Text)
            {
                case "FPC":
                    nTargetPos = (int)ALIGN_INDEX.TARGET_POS_FPC;
                    break;
                case "PANEL":
                    nTargetPos = (int)ALIGN_INDEX.TARGET_POS_PANEL;
                    break;
            }
            Align_Change();
        }

        private void BTN_AM_MARK_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_PATTERN;
            BTN_BackColor(sender, e);
            DisplayClear();
            CrossLine();

            if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
            {
                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                {
                    if (PatMaxTrainRegion == null)
                        PatMaxTrainRegion = new CogRectangle(PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);

                    PatMaxTrainRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 100, 100);
                }

                PatMaxTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
                PatMaxTrainRegion.Interactive = true;

                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                {
                    MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    ORGSizeFit();
                }

                CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                PatternInfo.Add(PatMaxTrainRegion);
                PatternInfo.Add(MarkORGPoint);

                PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
            }
            else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
            {
                if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained == false)
                {
                    if (PatMaxTrainRegion == null)
                        PatMaxTrainRegion = new CogRectangle(PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainRegion as CogRectangle);

                    PatMaxTrainRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 100, 100);
                }

                PatMaxTrainRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
                PatMaxTrainRegion.Interactive = true;

                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                {
                    MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                    ORGSizeFit();
                }

                CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();
                PatternInfo.Add(PatMaxTrainRegion);
                PatternInfo.Add(MarkORGPoint);

                PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
            }

        }

        private void BTN_AM_ORIGIN_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_ORIGIN;
            BTN_BackColor(sender, e);
        }

        private void BTN_AM_MASK_Click(object sender, EventArgs e)
        {
            if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
            {
                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained)
                {
                    PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImage);

                    FormPatternMask.BackUpSearchMaxTool = PT_Pattern[TapNo, m_PatNo_Sub];
                    FormPatternMask.BackUpPMAlignTool = PT_GPattern[TapNo, m_PatNo_Sub];
                    FormPatternMask.ShowDialog();

                    PT_Pattern[TapNo, m_PatNo_Sub] = FormPatternMask.BackUpSearchMaxTool;

                    DrawTrainedPattern(AM_SubDisplay[m_PatNo_Sub], PT_Pattern[TapNo, m_PatNo_Sub]);
                }
            }
            else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
            {
                if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained)
                {
                    PT_Pattern[TapNo, m_PatNo_Sub].InputImage = CopyIMG(PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImage);

                    FormPatternMask.BackUpSearchMaxTool = PT_Pattern[TapNo, m_PatNo_Sub];
                    FormPatternMask.BackUpPMAlignTool = PT_GPattern[TapNo, m_PatNo_Sub];
                    FormPatternMask.ShowDialog();

                    PT_Pattern[TapNo, m_PatNo_Sub] = FormPatternMask.BackUpSearchMaxTool;

                    DrawTrainedPattern(AM_SubDisplay[m_PatNo_Sub], PT_Pattern[TapNo, m_PatNo_Sub]);
                }
            }
        }

        private void BTN_AM_ORIGIN_MARK_CENTER_Click(object sender, EventArgs e)
        {
            if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
            {
                if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
                {
                    if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                    {
                        MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                        ORGSizeFit();
                    }

                    MarkORGPoint.X = PatMaxTrainRegion.CenterX;
                    MarkORGPoint.Y = PatMaxTrainRegion.CenterY;
                }

                else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
                {
                    if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained == false)
                    {
                        MarkORGPoint.SetCenterRotationSize(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], 0, M_ORIGIN_SIZE);
                        ORGSizeFit();
                    }

                    MarkORGPoint.X = PatMaxTrainRegion.CenterX;
                    MarkORGPoint.Y = PatMaxTrainRegion.CenterY;
                }
            }
        }

        private void BTN_AM_SEARCH_AREA_Click(object sender, EventArgs e)
        {
            m_RetiMode = M_SEARCH;
            BTN_BackColor(sender, e);
            DisplayClear();

            if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
            {
                if (PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Trained == false)
                    PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
            }
            else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
            {
                if (PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Trained == false)
                    PatMaxSearchRegion.SetCenterWidthHeight(Main.vision.IMAGE_CENTER_X[m_CamNo], Main.vision.IMAGE_CENTER_Y[m_CamNo], Main.vision.IMAGE_SIZE_X[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA, Main.vision.IMAGE_SIZE_Y[m_CamNo] - Main.DEFINE.DEFAULT_SEARCH_AREA);
            }

            PatMaxSearchRegion.GraphicDOFEnable = CogRectangleDOFConstants.Position | CogRectangleDOFConstants.Size;
            PatMaxSearchRegion.Color = CogColorConstants.Orange;
            PatMaxSearchRegion.Interactive = true;

            CogGraphicInteractiveCollection PatternInfo = new CogGraphicInteractiveCollection();

            PatternInfo.Add(PatMaxSearchRegion);
            PT_Display01.InteractiveGraphics.AddList(PatternInfo, "PATTERN_INFO", false);
            DisplayFit(PT_Display01);
        }

        private void BTN_AM_DELETE_Click(object sender, EventArgs e)
        {

        }

        private void BTN_AM_APPLY_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_RetiMode == M_PATTERN || m_RetiMode == M_ORIGIN)
                {
                    if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
                    {
                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMask = null;
                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;

                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);

                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;

                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].Pattern.Train();
                        DrawTrainedATTPattern(AM_SubDisplay[m_PatNo_Sub], PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub]);
                        LABEL_MESSAGE(LB_MESSAGE, "Train OK", System.Drawing.Color.Lime);
                    }
                    else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
                    {
                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMask = null;
                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetX = 0;
                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImageMaskOffsetY = 0;

                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.TrainRegion = new CogRectangle(PatMaxTrainRegion);

                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX = MarkORGPoint.X;
                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY = MarkORGPoint.Y;

                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].Pattern.Train();
                        DrawTrainedATTPattern(AM_SubDisplay[m_PatNo_Sub], PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub]);
                        LABEL_MESSAGE(LB_MESSAGE, "Train OK", Color.Lime);
                    }
                }
                if (m_RetiMode == M_SEARCH)
                {
                    if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_LEFT)
                        PT_AlignPara[TapNo].LeftPattern[m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                    else if (nInspectionPos == (int)ALIGN_INDEX.INSP_POS_RIGHT)
                        PT_AlignPara[TapNo].RightPattern[m_PatNo_Sub].SearchRegion = new CogRectangle(PatMaxSearchRegion);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void LB_ALIGN_LEAD_COUNT_Click(object sender, EventArgs e)
        {
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, PT_AlignPara[TapNo].LeadCount, "Input lead  Count", 1))
                {
                    form_keypad.ShowDialog();
                    PT_AlignPara[TapNo].LeadCount = (int)form_keypad.m_data;
                    LB_ALIGN_LEAD_COUNT.Text = PT_AlignPara[TapNo].LeadCount.ToString();
                }
            }
        }

        private void LB_ALIGN_FILTER_SIZE_Click(object sender, EventArgs e)
        {
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 21, PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels, "Input Filter Size", 1))
                {
                    form_keypad.ShowDialog();
                    PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels = (int)form_keypad.m_data;
                    LB_ALIGN_FILTER_SIZE.Text = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels.ToString();
                }
            }
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 21, PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels, "Input Filter Size", 1))
                {
                    form_keypad.ShowDialog();
                    PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels = (int)form_keypad.m_data;
                    LB_ALIGN_FILTER_SIZE.Text = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels.ToString();
                }
            }

        }

        private void RBTN_DARK_TO_BRIGHT_Click(object sender, EventArgs e)
        {
            RadioButton TempRBut = (RadioButton)sender;
            TempRBut.BackColor = Color.LawnGreen;
            RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;

            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
                PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CogCaliperPolarityConstants.DarkToLight;

            CaliperPol = CogCaliperPolarityConstants.DarkToLight;
        }

        private void RBTN_BRIGHT_TO_DARK_Click(object sender, EventArgs e)
        {
            RadioButton TempRBut = (RadioButton)sender;
            TempRBut.BackColor = Color.LawnGreen;
            RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;

            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
                PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;

            CaliperPol = CogCaliperPolarityConstants.LightToDark;
        }

        private void CB_ALIGN_ROI_TRACKING_Click(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;

            if (TempBTN.Checked)
                bAlignROITracking = true;
            else
                bAlignROITracking = false;
        }

        private void RBTN_ALIGN_EDGE_APPLY_Click(object sender, EventArgs e)
        {
            DisplayClear();
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                int nTotalLeadCount = Convert.ToInt32(LB_ALIGN_LEAD_COUNT.Text) * 2;
                PT_AlignPara[TapNo].LeadCount = Convert.ToInt32(LB_ALIGN_LEAD_COUNT.Text);
                PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels = Convert.ToInt32(LB_ALIGN_FILTER_SIZE.Text);
                PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold = Convert.ToInt32(LB_ALIGN_EDGE_THRESHOLD.Text);
                PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CaliperPol;

                if (PT_AlignPara[TapNo].LeadCount > 0)
                {
                    PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
                    PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].Region = PTCaliperRegion;

                    PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];

                    double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (nTotalLeadCount * 2));
                    double dNewY = PTCaliperRegion.CenterY;

                    for (int i = 0; i < nTotalLeadCount; i++)
                    {
                        PTCaliperDividedRegion[i] = new CogRectangleAffine(PTCaliperRegion);

                        double dX = PTCaliperRegion.SideXLength / nTotalLeadCount * i * Math.Cos(PTCaliperRegion.Rotation);
                        double dY = PTCaliperRegion.SideXLength / nTotalLeadCount * i * Math.Sin(PTCaliperRegion.Rotation);

                        PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / nTotalLeadCount;
                        PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                        if (i % 2 == 0) //좌측부분 ROI
                            PTCaliperDividedRegion[i].Rotation = PTCaliperDividedRegion[i].Rotation - 3.14;
                        
                        PT_Display01.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
                    }
                }
            }
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
            {
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.FilterHalfSizeInPixels = Convert.ToInt32(LB_ALIGN_FILTER_SIZE.Text);
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold = Convert.ToInt32(LB_ALIGN_EDGE_THRESHOLD.Text);
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.Edge0Polarity = CaliperPol;
                PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].Region = PTCaliperRegion;
                PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
            }
        }

        private void RBTN_ALIGN_EDGE_SHOWROI_Click(object sender, EventArgs e)
        {
            DisplayClear();
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                PTCaliperRegion = new CogRectangleAffine(PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].Region);
                if (bAlignROITracking)
                {
                    //PTCaliperRegion.CenterX = PatResult.TranslationX + PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                    //PTCaliperRegion.CenterY = PatResult.TranslationY + PT_CaliPara[TapNo, m_SelectCaliper].m_TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                }
                PTCaliperRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                PTCaliperRegion.Interactive = true;
                PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
            }
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
            {
                PTCaliperRegion = new CogRectangleAffine(PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].Region);
                PTCaliperRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Rotation | CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                PTCaliperRegion.Interactive = true;
                PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
            }

        }

        private void LB_ALIGN_EDGE_THRESHOLD_Click(object sender, EventArgs e)
        {
            if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_X)
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold, "Input Threshold", 1))
                {
                    form_keypad.ShowDialog();
                    PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold = (int)form_keypad.m_data;
                    LB_ALIGN_EDGE_THRESHOLD.Text = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, nTargetPos].RunParams.ContrastThreshold.ToString();
                }
            }
            else if (nAlignPos == (int)ALIGN_INDEX.ALIGN_POS_Y)
            {
                using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold, "Input Threshold", 1))
                {
                    form_keypad.ShowDialog();
                    PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold = (int)form_keypad.m_data;
                    LB_ALIGN_EDGE_THRESHOLD.Text = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, nTargetPos].RunParams.ContrastThreshold.ToString();
                }
            }
        }

        private void RBTN_ALIGN_INSPECTION_TEST_Click(object sender, EventArgs e)
        {
            DisplayClear();
            LB_ALIGNRESULT.Items.Clear();
            AlignResult.AlignResultClear();
            string strResult;
            #region X Align Insepection
            CogRectangleAffine[] PTCaliperDividedRegion;
            int nTotalLeadCount = PT_AlignPara[TapNo].LeadCount * 2;
            PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            Point2d CaliperPos = new Point2d();
            #region X Caliper Search
            //i = FPC = 0,
            //i = PANEL = 1,
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; i++)
            {
                if (PT_AlignPara[TapNo].LeadCount > 0)
                {
                    double dNewX = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.CenterX - (PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.SideXLength / 2) + (PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.SideXLength / (nTotalLeadCount * 2));
                    double dNewY = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.CenterY;

                    //ROI Division
                    for (int j = 0; j < nTotalLeadCount; j++)
                    {
                        //ROI Tracking 추가 필요

                        PTCaliperDividedRegion[j] = new CogRectangleAffine(PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region);

                        double dX = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.SideXLength / nTotalLeadCount * j * Math.Cos(PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.Rotation);
                        double dY = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.SideXLength / nTotalLeadCount * j * Math.Sin(PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].Region.Rotation);

                        PTCaliperDividedRegion[j].SideXLength = PTCaliperDividedRegion[j].SideXLength / nTotalLeadCount;
                        PTCaliperDividedRegion[j].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[j].CenterY = dNewY + dY;

                        if (j % 2 == 0) //좌측부분 ROI
                        {
                            PTCaliperDividedRegion[j].Rotation = PTCaliperDividedRegion[j].Rotation - 3.14;
                        }

                        //Caliper Search
                        //CaliperTool = PT_AlignPara[TapNo].m_AlignCaliperX[nInspectionPos, i];
                        CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                        CaliperTool.RunParams.FilterHalfSizeInPixels = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].RunParams.FilterHalfSizeInPixels;
                        CaliperTool.RunParams.ContrastThreshold = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].RunParams.ContrastThreshold;
                        CaliperTool.RunParams.Edge0Polarity = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, i].RunParams.Edge0Polarity;
                        CaliperTool.Region = PTCaliperDividedRegion[j];
                        CaliperTool.Run();

                        if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)               //Caliper Search OK
                        {
                            resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                            CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                            CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;

                            if (j % 2 == 0) 
                                AlignResult.LeftEdgePointList[nInspectionPos, i].Add(CaliperPos);        //Left Edge
                            else 
                                AlignResult.RightEdgePointList[nInspectionPos, i].Add(CaliperPos);       //Right Edge
                        }
                        else                                                                            //Caliper Search NG
                        {
                            CaliperPos.X = 0;
                            CaliperPos.Y = 0;

                            if (j % 2 == 0)
                                AlignResult.LeftEdgePointList[nInspectionPos, i].Add(CaliperPos);        //Left Edge
                            else
                                AlignResult.RightEdgePointList[nInspectionPos, i].Add(CaliperPos);       //Right Edge
                        }
                    }
                }
            }

            PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
            #endregion

            #region X Caliper Data Summary
            //Caliper Data 1차 정리
            //한쪽 Caliper Search NG일 경우 동일선상의 반대편 Caliper도 0으로 통일
            CaliperPos.X = 0;
            CaliperPos.Y = 0;
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; i++)
            {
                for (int j = 0; j < PT_AlignPara[TapNo].LeadCount; j++)
                {
                    if (AlignResult.LeftEdgePointList[nInspectionPos, i][j] == CaliperPos ||
                        AlignResult.RightEdgePointList[nInspectionPos, i][j] == CaliperPos)
                    {
                        if (i == 0)
                        {
                            AlignResult.LeftEdgePointList[nInspectionPos, i + 1][j] = CaliperPos;
                            AlignResult.RightEdgePointList[nInspectionPos, i + 1][j] = CaliperPos;
                        }
                        else
                        {
                            AlignResult.LeftEdgePointList[nInspectionPos, i - 1][j] = CaliperPos;
                            AlignResult.RightEdgePointList[nInspectionPos, i - 1][j] = CaliperPos;
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
            cogFPCLineTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            cogPanelLineTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            cogCenterLineTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            cogIntersectPoint_FPC.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            cogIntersectPoint_Panel.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
            cogDistancePoint.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);

            cogFPCLineTool.OutputColor = CogColorConstants.Purple;
            cogPanelLineTool.OutputColor = CogColorConstants.Orange;

            cogCenterLineTool.Line.X = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC].Region.CornerOriginX;
            cogCenterLineTool.Line.Y = (PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC].Region.CornerYY
                + PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL].Region.CornerOriginY) / 2;
            cogCenterLineTool.Line.Rotation = 0;
            cogCenterLineTool.Run();

            PT_Display01.StaticGraphics.Add(cogCenterLineTool.Line as ICogGraphic, "CenterLine");

            //Caliper 개수만큼 반복
            for (int i = 0; i < AlignResult.LeftEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC].Count; i++)
            {
                //object, [FPC]  -> Panel 각도로 통일 
                if (AlignResult.LeftEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC][i].X > 0 && AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC][i].X > 0)
                {
                    cogFPCLineTool.Line.X = (AlignResult.LeftEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC][i].X + AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC][i].X) / 2;
                    cogFPCLineTool.Line.Y = AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_FPC][i].Y;
                    cogFPCLineTool.Line.Rotation = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL].Region.Skew + 1.57;
                    cogFPCLineTool.Run();
                    PT_Display01.StaticGraphics.Add(cogFPCLineTool.Line as ICogGraphic, "FPCLine");
                    cogIntersectPoint_FPC.LineA = cogCenterLineTool.GetOutputLine();
                    cogIntersectPoint_FPC.LineB = cogFPCLineTool.GetOutputLine();
                    cogIntersectPoint_FPC.Run();
                }

                //object, [Panel] -> Panel 각도로 통일
                if (AlignResult.LeftEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL][i].X > 0 && AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL][i].X > 0)
                {
                    cogPanelLineTool.Line.X = (AlignResult.LeftEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL][i].X + AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL][i].X) / 2;
                    cogPanelLineTool.Line.Y = AlignResult.RightEdgePointList[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL][i].Y;
                    cogPanelLineTool.Line.Rotation = PT_AlignPara[TapNo].AlignCaliperX[nInspectionPos, (int)ALIGN_INDEX.TARGET_POS_PANEL].Region.Skew + 1.57;
                    cogPanelLineTool.Run();
                    PT_Display01.StaticGraphics.Add(cogPanelLineTool.Line as ICogGraphic, "PanelLine");
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

            double dAvergeX;
            //Align X 값이 한개도 없을 때
            if (DistanceToPoint.Count == 0)
            {
                AlignResult.AlignGapXRealList.Add(0);
                AlignResult.AlignGapYRealList.Add(0);
                strResult = "X Align Search Fail";
                LB_ALIGNRESULT.Items.Add(strResult);
                return;
            }

            if (DistanceToPoint.Count == 1)
                dAvergeX = DistanceToPoint[0];
            else if (DistanceToPoint.Count == 2)
                dAvergeX = (DistanceToPoint[0] + DistanceToPoint[1]) / 2;
            else
            {
                DistanceToPoint.Sort();
                DistanceToPoint.RemoveAt(0); //Min 삭제
                DistanceToPoint.RemoveAt(DistanceToPoint.Count - 1);//Max 삭제
                dAvergeX = DistanceToPoint.Average();
            }

            //Panel기준 FPC가 좌측에 위치할 때, 부호 - [Panel기준]
            if (cogIntersectPoint_FPC.X < cogIntersectPoint_Panel.X)
                dAvergeX = dAvergeX * -1;

            AlignResult.AlignGapXRealList.Add(dAvergeX * (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
            strResult = "X Align Result : " + AlignResult.AlignGapXRealList[0].ToString("0.000") + "um";
            LB_ALIGNRESULT.Items.Add(strResult);
            #endregion

            #endregion

            #region Y Align Inspection

            #region Y Caliper Search
            //i = FPC = 0,
            //i = PANEL = 1,
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; i++)
            {
                CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                CaliperTool.RunParams.FilterHalfSizeInPixels = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, i].RunParams.FilterHalfSizeInPixels;
                CaliperTool.RunParams.ContrastThreshold = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, i].RunParams.ContrastThreshold;
                CaliperTool.RunParams.Edge0Polarity = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, i].RunParams.Edge0Polarity;
                CaliperTool.Region = PT_AlignPara[TapNo].AlignCaliperY[nInspectionPos, i].Region;
                CaliperTool.Run();

                if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
                {
                    resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                    CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                    CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;
                    AlignResult.YEdgePointList[nInspectionPos].Add(CaliperPos);
                }
                else
                {
                    //Caliper Search NG
                    AlignResult.AlignGapYRealList.Add(0);
                    strResult = "Y Align Search Fail";
                    LB_ALIGNRESULT.Items.Add(strResult);
                    break;
                }
            }
            #region Y Align Calculate
            double dYAlignDistance;
            dYAlignDistance = Math.Abs(AlignResult.YEdgePointList[nInspectionPos][0].Y - AlignResult.YEdgePointList[nInspectionPos][1].Y);
            dYAlignDistance = dYAlignDistance * ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
            AlignResult.AlignGapYRealList.Add(dYAlignDistance);
            strResult = "Y Align Result : " + AlignResult.AlignGapYRealList[0].ToString("0.000") + "um";
            LB_ALIGNRESULT.Items.Add(strResult);
            #endregion

            #endregion



            #endregion

        }

        private void BTN_ATT_AUTO_SORT_Click(object sender, EventArgs e)
        {
            if (GroupListLeadData[nSelectGroupNumber].Count == 0)
                return;

            if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL))
                AlignROIGapHorizontal();
            else if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL))
                AlignROIGapVertical();
        }

        private void AlignROIGapHorizontal()
        {
            bool isFirstCheck = false;
            int leftIndex = 0, rightIndex = 0, checkCount = 0;
            float deltaX = 0, deltaY = 0;

            CogRadian deltaAngle = 0;
            CogRadian firstAngle = 0;
            CogRadian lastAngle = 0;
            
            for (int i = 0; i < GroupListLeadData[nSelectGroupNumber].Count; i++)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (!isFirstCheck)
                    {
                        isFirstCheck = true;
                        leftIndex = i;
                    }
                    else
                        rightIndex = i;

                    checkCount++;
                }                                      
            }

            if (leftIndex == rightIndex)
            {
                Console.WriteLine("Left and Right Bump Index is Same!");
                return;
            }

            deltaX = (float)(GroupListLeadData[nSelectGroupNumber][rightIndex].CenterX - GroupListLeadData[nSelectGroupNumber][leftIndex].CenterX / (float)(checkCount - 1));
            deltaY = (float)(GroupListLeadData[nSelectGroupNumber][rightIndex].CenterY - GroupListLeadData[nSelectGroupNumber][leftIndex].CenterY / (float)(checkCount - 1));
            LeadGroupInfo[nSelectGroupNumber].LeadPitch = deltaX;
            firstAngle = GroupListLeadData[nSelectGroupNumber][leftIndex].Skew;
            lastAngle = GroupListLeadData[nSelectGroupNumber][rightIndex].Skew;
            deltaAngle = (lastAngle.Value - firstAngle.Value) / (float)(checkCount - 1);
            isFirstCheck = false;
            checkCount = 0;

            double newCenterX, newCenterY;
            CogRadian newSkew;

            for (int i = 0; i < GroupListLeadData[nSelectGroupNumber].Count; i++)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (!isFirstCheck)
                        isFirstCheck = true;
                    else
                    {
                        CogRadian pitchAngle = deltaAngle.Value * i;

                        newCenterX = GroupListLeadData[nSelectGroupNumber][leftIndex].CenterX + (deltaX * checkCount);
                        newCenterY = GroupListLeadData[nSelectGroupNumber][leftIndex].CenterY + (deltaY * checkCount);
                        newSkew = GroupListLeadData[nSelectGroupNumber][leftIndex].Skew + pitchAngle.Value;
                        GroupListLeadData[nSelectGroupNumber][i].CenterX = newCenterX;
                        GroupListLeadData[nSelectGroupNumber][i].CenterY = newCenterY;
                        GroupListLeadData[nSelectGroupNumber][i].Skew = newSkew.Value;
                    }

                    checkCount++;
                }
            }

            RefreshAkkonRegion();
        }
        private void AlignROIGapVertical()
        {

        }

        private void BTN_AKKON_ORIGINAL_IMAGE_Click(object sender, EventArgs e)
        {
            //resize된 이미지 표시용도
            //한번 검사한 이후론 resize됨.
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf != null)
            {
                byte[] bytes2 = new byte[Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Cols * Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Rows];
                bytes2 = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.ToBytes(".bmp");
                Cv2.ImEncode(".bmp", Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf, out bytes2);
                //byte[] bytes2 = null;

                //Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf);
                //bitmap.Save(@"D:\tlqkf.jpeg");
                //MemoryStream stream = new MemoryStream();
                ////bitmap.Save(stream, bitmap.RawFormat);
                //bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);


                //bytes2 = stream.ToArray();
                //bytes2 = JASUtility.ImageHelper.ConvertGray8BitImageToArray(bitmap);


                PT_Display01.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(bytes2,
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Width, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanBuf.Height);
            }
        }

        private void BTN_AKKON_RESULT_IMAGE_Click(object sender, EventArgs e)
        {
            //압흔결과 이미지 표시용도
            if(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgOverlay != null)
            {
                PT_Display01.Image = Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_imgOverlay;
            }
        }

        private void BTN_AKKON_TEACH_IMAGE_Click(object sender, EventArgs e)
        {
            //원본 이미지 표시 용도
            if (Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanOriginalBuf != null)
            {
                PT_Display01.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanOriginalBuf.ToBytes(),
                    Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanOriginalBuf.Width, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].m_MatLineScanOriginalBuf.Height);
            }
        }

        private void BTN_AKKON_PARAMETER_Click(object sender, EventArgs e)
        {
            b_ParameterMode = !b_ParameterMode;

            if(b_ParameterMode)
            {
                panel5.Visible = false;
                panel4.Visible = false;
                panel9.Visible = true;
                panel9.Location = new System.Drawing.Point(3, 473);
            }
            else
            {
                panel5.Visible = true;
                panel4.Visible = true;
                panel9.Visible = false;
            }
        }

        private void LB_ATT_COUNT_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeCount, "AKKON COUNT", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeCount = (int)form_keypad.m_data;
            }
            Akkon_Change();
        }

        private void LB_ATT_LENGTH_Click(object sender, EventArgs e)
        {
            using (Form_KeyPad form_keypad = new Form_KeyPad(0, 1000, Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeLength, "AKKON LENGTH", 1))
            {
                form_keypad.ShowDialog();
                Main.AlignUnit[CamNo].PAT[StageNo, TapNo].AkkonPara[m_SelectAkkon].JudgeLength = (double)form_keypad.m_data;
            }
            Akkon_Change();
        }
    }
}
