using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.Drawing.Imaging;

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
using static COG.Main;

namespace COG
{
    public partial class Form_AkkonTeaching : Form
    {
        enum MoveTye { Up = 0, Down = 1, Left = 2, Right = 3 };
        enum enumTab { Next, Prev }
        enum PanelType { COF = 0, COG = 1, FOG = 2 }
        enum enumInspectionType { Akkon = 0, AlignInsp = 1 }

        enum enumEdgePos { X = 0, Y }
        enum enumAlignInspPos {FPC =0, Panel=1 }
        enum enumAlignInspType { Mark =0, Edge}
        enum ROI_Direction
        {
            CLONE_ROI_DIR_HORIZONTAL = 0,
            CLONE_ROI_DIR_VERTICAL = 1
        }
        private enumInspectionType eInspType = new enumInspectionType();
        private enum ROIType { MarkLeft = 0, MarkRight = 1, Akkon }
        private ROIType enumROIType;
        private enumEdgePos eEdgePos = new enumEdgePos();
        private Main.eAuthority Authority;
        private enumAlignInspPos eAlignInsPos = new enumAlignInspPos();
        private enumAlignInspType eAlignInspType = new enumAlignInspType();

        private CogPMAlignTool[] TempMarkTool = new CogPMAlignTool[5];
        private List<CogDisplay> SubMarkDisplay;
        private CogRectangleAffine cogRectNewROI;
        private static CogRecordDisplay PT_Display01 = new CogRecordDisplay();
        private CogCaliperTool TempCaliperTool = new CogCaliperTool();
       
        private List<List<CogRectangleAffine>> GroupListLeadData = new List<List<CogRectangleAffine>>();
       

        private double m_nScore = 0.5;
        private double m_nLeadPitch = 1;
        private double m_nMarkScore = 0.5;

        private bool bJogOrigin = false;
        private bool bJogPatten = false;
        private bool Thumbnail_MoveFlag = false;
        private bool bGroupModeFlag = false;
        private bool PT_Akkon_MarkUSE = false;
        private bool bCloneROIDir = false;
        private bool bROIMove = true;

        private int m_nCamNo;
        private int m_nStageNo;
        private int m_nGroupCnt = 0;
        private int m_nGroupNo = 0;
        private int m_nTabNo = 0;
        private int m_nSubMarkIndex = 0;
        private int m_nROIWidth = 0;
        private int m_nROIHight = 0;
        private int m_nLeadCount = 1;

        private int m_nAlignLead;
        private static bool _bATTResult = false;
        public int IsnStageNo
        {
            set { m_nStageNo = value; }
        }
        public int IsnCamNo
        {
            set { m_nCamNo = value; }
        }

        public Form_AkkonTeaching(int InspType = 0)
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            eInspType = (enumInspectionType)InspType;

            enumROIType = new ROIType();
            PT_Display01 = PT_DISPLAY_CONTROL.CogDisplay00;
            Authority = Main.Instance().Authority;
            PT_DisplayToolbar01.Display = PT_Display01;
            PT_DisplayStatusBar01.Display = PT_Display01;
            btn_Move.BackColor = Color.Green;
            btn_Size.BackColor = Color.DarkGray;
            UIInit();

        }
        private void Form_AkkonTeaching_Load(object sender, EventArgs e)
        {
            SubMarkDisplay = new List<CogDisplay>();
            SubMarkDisplay.Add(cogSubDisplay01);
            SubMarkDisplay.Add(cogSubDisplay02);
            SubMarkDisplay.Add(cogSubDisplay03);
            SubMarkDisplay.Add(cogSubDisplay04);
            SubMarkDisplay.Add(cogSubDisplay05);
            if (eInspType == enumInspectionType.Akkon)
            {
                SetProperty();
                Lead_SetProperty();
                Akkon_init();
                Get_Akkon_Param();
                timer1.Enabled = true;
                if (PT_Display01.Image == null)
                {
                    LB_ShowTodo.Text = "[Akkon Teaching UI]\r\n\r\nOpen BMP Image for Akkon Teaching.\r\nClick 'FILE OPEN' and Select Image(.bmp) file.";
                }
                else
                {
                    LB_ShowTodo.Text = "[Akkon Teaching UI]\r\n\r\nImage load OK! \r\nStart Mark or Akkon Teaching.";
                }
				LB_ShowTodo.Location = new System.Drawing.Point(926, 750);  //Comment Label 위치 변경
            //shkang_e
            }
            else  //Align Inspection
            {
                AlignTag_SetProperty();

                //shkang_s
                if (PT_Display01.Image == null)
                {
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nOpen BMP Image for Align Inspection Teaching.\r\nClick 'FILE OPEN' and Select Image(.bmp) file.";
                }
                else
                {
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nImage load OK! \r\nStart Align Teaching! \r\n Select Inpection Position (Left or Right).";
                }
                LB_ShowTodo.Location = new System.Drawing.Point(926, 750);  //Comment Label 위치 변경
                //shkang_s
            }
        }
        private void UIInit()
        {
            if (eInspType == enumInspectionType.Akkon)
            {
                TAB_ATT_LIST.Visible = true;
                TAB_ATT_LIST.Enabled = true;
                panel_Mark.Visible = false;
                panel_Mark.Enabled = false;
                panel_AkkonParam.Visible = false;
                panel_AkkonParam.Enabled = false;
                panel_Akkon_ROI_Grup.Visible = false;
                panel_Akkon_ROI_Grup.Enabled = false;
                panel_MakerParam.Visible = false;
                panel_MakerParam.Enabled = false;
                BTN_AKKON_GROUP.Visible = false;
                BTN_AKKON_GROUP.Enabled = false;
                btn_ROI_Show.Visible = false;
                BTN_AKKON_LEFT_MARK.Visible = true;
                BTN_AKKON_LEFT_MARK.Enabled = true;
                BTN_AKKON_RIGHT_MARK.Visible = true;
                BTN_AKKON_RIGHT_MARK.Enabled = true;
                RBTN_AKKON00.Visible = true;
                RBTN_AKKON00.Enabled = true;
                BTN_AKKON_CLEAR_ROI.Visible = true;
                BTN_AKKON_APPLY.Visible = true;
                BTN_AKKON_LOAD_ROI.Visible = true;

                BTN_ROI_SKEW_CCW.Visible = false;
                BTN_ROI_SKEW_CCW.Enabled = false;
                BTN_ROI_SKEW_ZERO.Visible = false;
                BTN_ROI_SKEW_ZERO.Enabled = false;
                BTN_ROI_SKEW_CW.Visible = false;

                Panel_AlingInsp.Visible = false;
                Panel_AlingInsp.Enabled = false;
                PANEL_AT_CALIPER.Visible = false;
                PANEL_AT_CALIPER.Enabled = false;

                LB_ALIGN_LEAD_COUNT.Enabled = false;
                LB_ALIGN_FILTER_SIZE.Enabled = false;
                LB_ALIGN_EDGE_THRESHOLD.Enabled = false;
                RBTN_DARK_TO_BRIGHT.Enabled = false;
                RBTN_BRIGHT_TO_DARK.Enabled = false;
                RBTN_ALIGN_EDGE_SHOWROI.Enabled = false;
                RBTN_ALIGN_EDGE_APPLY.Enabled = false;
                RBTN_ALIGN_INSPECTION_TEST.Enabled = false;
                //shkang_s
                BTN_AKKON_ORIGINAL_IMAGE.Visible = false;
                BTN_AKKON_ORIGINAL_IMAGE.Enabled = false;
                BTN_AKKON_RESULT_IMAGE.Visible = false;
                BTN_AKKON_RESULT_IMAGE.Enabled = false;
                BTN_AKKON_TEACH_IMAGE.Visible = false;
                BTN_AKKON_TEACH_IMAGE.Enabled = false;
                BTN_AKKON_GROUP.Visible = false;
                BTN_AKKON_GROUP.Enabled = false;
                if (Authority == eAuthority.Operator)
                {
                    panel1.Visible = false;
                    btn_Maker_Parm.Visible = false;
                    btn_Maker_Parm.Enabled = false;
                    BTN_AKKON_PARAMETER.Visible = false;
                    BTN_AKKON_PARAMETER.Enabled = false;
                    BTN_AKKON_GROUP.Visible = false;
                    BTN_AKKON_GROUP.Enabled = false;
                }
                else if (Authority == eAuthority.Engineer)
                {
                    panel1.Visible = true;
                    btn_Maker_Parm.Visible = false;
                    btn_Maker_Parm.Enabled = false;
                    BTN_AKKON_PARAMETER.Visible = false;
                    BTN_AKKON_PARAMETER.Enabled = false;
                    BTN_AKKON_GROUP.Visible = false;
                    BTN_AKKON_GROUP.Enabled = false;
                }
                else
                {
                    panel1.Visible = true;
                    btn_Maker_Parm.Visible = false;
                    btn_Maker_Parm.Enabled = false;
                    BTN_AKKON_PARAMETER.Visible = false;
                    BTN_AKKON_PARAMETER.Enabled = false;
                    BTN_AKKON_GROUP.Visible = false;
                    BTN_AKKON_GROUP.Enabled = false;
                }
            }
            else
            {
                TAB_ATT_LIST.Visible = false;
                TAB_ATT_LIST.Enabled = false;
                BTN_AKKON_LEFT_MARK.Visible = false;
                BTN_AKKON_LEFT_MARK.Enabled = false;
                BTN_AKKON_RIGHT_MARK.Visible = false;
                BTN_AKKON_RIGHT_MARK.Enabled = false;
                RBTN_AKKON00.Visible = false;
                RBTN_AKKON00.Enabled = false;
                BTN_AKKON_CLEAR_ROI.Visible = false;
                BTN_AKKON_APPLY.Visible = false;
                BTN_AKKON_LOAD_ROI.Visible = false;
                panel_Mark.Visible = false;
                panel_Mark.Enabled = false;
                panel_AkkonParam.Visible = false;
                panel_AkkonParam.Enabled = false;
                panel_Akkon_ROI_Grup.Visible = false;
                panel_Akkon_ROI_Grup.Enabled = false;
                panel_MakerParam.Visible = false;
                panel_MakerParam.Enabled = false;
                BTN_AKKON_GROUP.Visible = false;
                BTN_AKKON_GROUP.Enabled = false;
                BTN_AKKON_PARAMETER.Visible = false;
                BTN_AKKON_PARAMETER.Enabled = false;
                btn_Maker_Parm.Visible = false;
                btn_Maker_Parm.Enabled = false;
                BTN_AKKON_ORIGINAL_IMAGE.Visible = false;
                BTN_AKKON_ORIGINAL_IMAGE.Enabled = false;
                BTN_AKKON_TEACH_IMAGE.Visible = false;
                BTN_AKKON_TEACH_IMAGE.Enabled = false;
                BTN_AKKON_RESULT_IMAGE.Visible = false;
                BTN_AKKON_RESULT_IMAGE.Enabled = false;
                CB_AKKON_MARK_USE.Visible = false;
                CB_AKKON_MARK_USE.Enabled = false;

                BTN_ROI_SKEW_CCW.Visible = false;
                BTN_ROI_SKEW_CCW.Enabled = false;
                BTN_ROI_SKEW_ZERO.Visible = false;
                BTN_ROI_SKEW_ZERO.Enabled = false;
                BTN_ROI_SKEW_CW.Visible = false;
                BTN_ROI_SKEW_CW.Enabled = false;
                Panel_AlingInsp.Visible = true;
                Panel_AlingInsp.Enabled = true;
                PANEL_AT_CALIPER.Visible = false;
                PANEL_AT_CALIPER.Enabled = false;
                Panel_AlingInsp.Location = new System.Drawing.Point(912, 58);
                PANEL_AT_CALIPER.Location = new System.Drawing.Point(914, 148);


                lab_Insp_Pos.Visible = true;
                RBTN_ALIGN_INSPOS_LEFT.Visible = true;
                RBTN_ALIGN_INSPOS_LEFT.Enabled = true;
                RBTN_ALIGN_INSPOS_RIGHT.Visible = true;
                RBTN_ALIGN_INSPOS_RIGHT.Enabled = true;
                lab_TeachMode.Visible = false;
                RBTN_ALIGN_TEACH_MARK.Visible = false;
                RBTN_ALIGN_TEACH_MARK.Enabled = false;
                RBTN_ALIGN_TEACH_EDGE.Visible = false;
                RBTN_ALIGN_TEACH_EDGE.Enabled = false;

                lab_AlingInsp_pos.Visible = false;
                RBTN_ALIGNPOS_X.Visible = false;
                RBTN_ALIGNPOS_X.Enabled = false;
                RBTN_ALIGNPOS_Y.Visible = false;
                RBTN_ALIGNPOS_Y.Enabled = false;

                lab_AlignInsp_Target_Pos.Visible = false;
                RBTN_ALIGN_TARPOS_FPC.Visible = false;
                RBTN_ALIGN_TARPOS_PANEL.Visible = false;

                LB_ALIGN_LEAD_COUNT.Enabled = true;
                LB_ALIGN_FILTER_SIZE.Enabled = true;
                LB_ALIGN_EDGE_THRESHOLD.Enabled = true;
                RBTN_DARK_TO_BRIGHT.Enabled = true;
                RBTN_BRIGHT_TO_DARK.Enabled = true;
                RBTN_ALIGN_EDGE_SHOWROI.Enabled = true;
                RBTN_ALIGN_EDGE_APPLY.Enabled = true;
                RBTN_ALIGN_INSPECTION_TEST.Enabled = true;
                eAlignInspType = new enumAlignInspType();
            }
        }
        private void Akkon_init()
        {
            RefreshAkkonRegion();
        }
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SelectROIType_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            enumROIType = (ROIType)Convert.ToInt32(btn.Tag.ToString());
            //shkang
            BTN_AKKON_ORIGINAL_IMAGE.Visible = false;
            BTN_AKKON_ORIGINAL_IMAGE.Enabled = false;
            BTN_AKKON_RESULT_IMAGE.Visible = false;
            BTN_AKKON_RESULT_IMAGE.Enabled = false;
            BTN_AKKON_TEACH_IMAGE.Visible = false;
            BTN_AKKON_TEACH_IMAGE.Enabled = false;
            switch (enumROIType)
            {
                case ROIType.MarkLeft:
                    BTN_AKKON_LEFT_MARK.BackColor = Color.Green;
                    BTN_AKKON_RIGHT_MARK.BackColor = Color.DarkGray;
                    RBTN_AKKON00.BackColor = Color.DarkGray;
                    TAB_ATT_LIST.Visible = false;
                    TAB_ATT_LIST.Enabled = false;
                    BTN_ROI_SKEW_CCW.Visible = false;
                    BTN_ROI_SKEW_CCW.Enabled = false;
                    BTN_ROI_SKEW_CW.Visible = false;
                    BTN_ROI_SKEW_CW.Enabled = false;
                    BTN_ROI_SKEW_ZERO.Visible = false;
                    BTN_ROI_SKEW_ZERO.Enabled = false;
                    BTN_ROIORIGN.Visible = false;
                    BTN_ROIMARK.Visible = false;
                    panel_Mark.Visible = true;
                    panel_Mark.Enabled = true;
                    bJogOrigin = false;
                    bJogPatten = true;
                    panel_Mark.Location = new System.Drawing.Point(910, 58);
                    panel_AkkonParam.Visible = false;
                    panel_AkkonParam.Enabled = false;
                    panel_Akkon_ROI_Grup.Visible = false;
                    panel_Akkon_ROI_Grup.Enabled = false;
                    panel_MakerParam.Visible = false;
                    panel_MakerParam.Enabled = false;
                    //shkang_s
                    BTN_AKKON_GROUP.Visible = false;
                    BTN_AKKON_GROUP.Enabled = false;
                    BTN_AKKON_PARAMETER.Visible = false;
                    BTN_AKKON_PARAMETER.Enabled = false;
                    btn_Maker_Parm.Visible = false;
                    btn_Maker_Parm.Enabled = false;
                    TempMarkTool = akkonParam[m_nTabNo].LeftPattern;
                    MarkTeachingInit();
                    //shkang_s
                    if (PT_Display01.Image == null)
                    {
                        LB_ShowTodo.Text = "[Mark Teaching - LEFT]\r\n\r\nNo Load Image! \r\nPlease Open Image(.bmp) file. ";
                    }
                    else
                    {
                        //if (SubMarkDisplay[m_nSubMarkIndex].Image == null)
                        //{
                        LB_ShowTodo.Text = "[Mark Teaching - LEFT]\r\n\r\nClick Number in Mark Index.\r\n(Main(1), Sub(2,3,4,5))";
                        //}
                    }
                    //shkang_e
                    break;
                case ROIType.MarkRight:
                    BTN_AKKON_LEFT_MARK.BackColor = Color.DarkGray;
                    BTN_AKKON_RIGHT_MARK.BackColor = Color.Green;
                    RBTN_AKKON00.BackColor = Color.DarkGray;
                    TAB_ATT_LIST.Visible = false;
                    TAB_ATT_LIST.Enabled = false;
                    BTN_ROI_SKEW_CCW.Visible = false;
                    BTN_ROI_SKEW_CCW.Enabled = false;
                    BTN_ROI_SKEW_CW.Visible = false;
                    BTN_ROI_SKEW_CW.Enabled = false;
                    BTN_ROI_SKEW_ZERO.Visible = false;
                    BTN_ROI_SKEW_ZERO.Enabled = false;
                    BTN_ROIORIGN.Visible = false;
                    BTN_ROIMARK.Visible = false;
                    panel_Mark.Visible = true;
                    panel_Mark.Enabled = true;
                    bJogOrigin = false;
                    bJogPatten = true;
                    panel_Mark.Location = new System.Drawing.Point(910, 58);
                    panel_AkkonParam.Visible = false;
                    panel_AkkonParam.Enabled = false;
                    panel_Akkon_ROI_Grup.Visible = false;
                    panel_Akkon_ROI_Grup.Enabled = false;
                    panel_MakerParam.Visible = false;
                    panel_MakerParam.Enabled = false;
                    //shkang_s
                    BTN_AKKON_GROUP.Visible = false;
                    BTN_AKKON_GROUP.Enabled = false;
                    BTN_AKKON_PARAMETER.Visible = false;
                    BTN_AKKON_PARAMETER.Enabled = false;
                    btn_Maker_Parm.Visible = false;
                    btn_Maker_Parm.Enabled = false;
                    TempMarkTool = akkonParam[m_nTabNo].RightPattern;
                    MarkTeachingInit();
                    //shkang_s
                    if (PT_Display01.Image == null)
                    {
                    	LB_ShowTodo.Text = "[Mark Teaching - RIGHT]\r\n\r\nNo Load Image! \r\nPlease Open Image(.bmp) file. ";
                    }
                    else
                    {
                        //if (SubMarkDisplay[m_nSubMarkIndex].Image == null)
                        //{
                        LB_ShowTodo.Text = "[Mark Teaching - RIGHT]\r\n\r\nClick Number in Mark Index.\r\n(Main(1), Sub(2,3,4,5))";
                        //}
                    }
                    //shkang_e
                    break;
                case ROIType.Akkon:
                    BTN_AKKON_LEFT_MARK.BackColor = Color.DarkGray;
                    BTN_AKKON_RIGHT_MARK.BackColor = Color.DarkGray;
                    RBTN_AKKON00.BackColor = Color.Green;
                    TAB_ATT_LIST.Visible = true;
                    TAB_ATT_LIST.Visible = true;
                    BTN_ROI_SKEW_CCW.Visible = false;
                    BTN_ROI_SKEW_CCW.Enabled = false;
                    BTN_ROI_SKEW_CW.Visible = false;
                    BTN_ROI_SKEW_CW.Enabled = false;
                    BTN_ROI_SKEW_ZERO.Visible = false;
                    BTN_ROI_SKEW_ZERO.Enabled = false;
                    BTN_ROIORIGN.Visible = false;
                    BTN_ROIMARK.Visible = false;
                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    btn_ROI_Show.Visible = false;
                    bJogOrigin = false;
                    bJogPatten = true;
                    TAB_ATT_LIST.Location = new System.Drawing.Point(910, 58);
                    panel_Akkon_ROI_Grup.Location = new System.Drawing.Point(910, 319);
                    panel_AkkonParam.Visible = false;
                    panel_AkkonParam.Enabled = false;
                    panel_Akkon_ROI_Grup.Visible = false;
                    panel_Akkon_ROI_Grup.Enabled = false;
                    panel_MakerParam.Visible = false;
                    panel_MakerParam.Enabled = false;
                    //shkang_s
                    BTN_AKKON_GROUP.Visible = true;
                    BTN_AKKON_GROUP.Enabled = true;
                    BTN_AKKON_PARAMETER.Visible = true;
                    BTN_AKKON_PARAMETER.Enabled = true;
                    btn_Maker_Parm.Visible = true;
                    btn_Maker_Parm.Enabled = true;
                    bGroupModeFlag = false;
                    AkkonTeachingUI_Init();
                    //shkang_s
                    if (PT_Display01.Image == null)
                    {
                        LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nNo Load Image! \r\nPlease Open Image(.bmp) file. ";
                    }
                    else
                    {
                        //if (SubMarkDisplay[m_nSubMarkIndex].Image == null)
                        //{
                        LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nAkkon Teaching Start!\r\nClick 'GROUP'";
                        //}
                    }
                    //shkang_e
                    break;
            }
        }
        private void AkkonTeachingUI_Init()
        {
            LBL_ATT_GROUP_NO.Visible = false; CB_ATT_GROUP_NO.Visible = false;
            LBL_ATT_ROI_WIDTH.Visible = false; LB_ATT_ROI_WIDTH.Visible = false;
            LBL_ATT_ROI_HEIGHT.Visible = false; LB_ATT_ROI_HEIGHT.Visible = false;
            LBL_ATT_FIRST_LEAD.Visible = false; BTN_ATT_ROI_CREATE.Visible = false;
            BTN_ATT_FIRSTLEAD_REGISTER.Visible = false; LBL_ATT_LEAD_COUNT.Visible = false;
            LB_ATT_LEAD_COUNT.Visible = false; LBL_ATT_LEAD_PITCH.Visible = false;
            LB_ATT_LEAD_PITCH.Visible = false; LBL_ATT_CLONE_ROI.Visible = false;
            BTN_AKKON_CLONE_HOR.Visible = false; BTN_AKKON_CLONE_VER.Visible = false;
            BTN_ATT_ROI_COPY.Visible = false; LBL_ATT_ADJUST.Visible = false;
            BTN_ATT_AUTO_SORT.Visible = false; btn_GropROIApply.Visible = false;
            btn_list_delete.Visible = false;
        }
        private void MarkTeachingInit()
        {
            //TempMarkTool = new CogPMAlignTool();

            BTN_PATTERN.Visible = false;
            BTN_SETMARK.Visible = false;
            BTN_MASKING.Visible = false;
            BTN_SEARCHROI.Visible = false;
            BTN_MARKAPPLY.Visible = false;
            Get_MarkParam();

        }
        private void Get_MarkParam()
        {
            for (int nSubCnt = 0; nSubCnt < 5; nSubCnt++)
            {
                SubMarkDisplay[nSubCnt].Image = null;
                if (TempMarkTool[nSubCnt] == null)
                    TempMarkTool[nSubCnt] = new CogPMAlignTool();
                if (TempMarkTool[nSubCnt].Pattern.Trained)
                {
                    SubMarkDisplay[nSubCnt].Image = (CogImage8Grey)TempMarkTool[nSubCnt].Pattern.GetTrainedPatternImage();
                }
            }
            CogPMAlignZoneAngle CogAngle = new CogPMAlignZoneAngle();
            CogAngle = TempMarkTool[m_nSubMarkIndex].RunParams.ZoneAngle;

            //NUD_PAT_SCORE.Value = (decimal)TempMarkTool[m_nSubMarkIndex].RunParams.AcceptThreshold;
            NUD_AngleMax.Value = (decimal)((CogAngle.High * 180) / Math.PI);
            NUD_AngleMin.Value = (decimal)((CogAngle.Low * 180) / Math.PI);
            if (eInspType == enumInspectionType.Akkon)
            {
                NUD_PAT_SCORE.Value = (decimal)akkonParam[m_nTabNo].ATTMarkScore * 100;
            }
            else
            {
                //추가 해야 함
                NUD_PAT_SCORE.Value = (decimal)70.0;
            }
        }
        private void MarkIndex_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            m_nSubMarkIndex = Convert.ToInt32(btn.Tag.ToString());
            BTN_PATTERN.Visible = true;
            BTN_MASKING.Visible = true;
            BTN_SEARCHROI.Visible = true;   //shkang - Search ROI만 수정할 수 있게 항상 VISIBLE
            switch (m_nSubMarkIndex)
            {
                case 0:
                    btn_Main_Mark.BackColor = Color.Green;
                    btn_SubMark1.BackColor = Color.DarkGray;
                    btn_SubMark2.BackColor = Color.DarkGray;
                    btn_SubMark3.BackColor = Color.DarkGray;
                    btn_SubMark4.BackColor = Color.DarkGray;
                    //shkang_s Teaching comment
                    if (enumROIType == ROIType.MarkLeft)
                        LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nMain Mark\r\nClick 'MARK ROI'";
                    else if (enumROIType == ROIType.MarkRight)
                        LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nMain Mark\r\nClick 'MARK ROI'";
                    break;
                case 1:
                    btn_Main_Mark.BackColor = Color.DarkGray;
                    btn_SubMark1.BackColor = Color.Green;
                    btn_SubMark2.BackColor = Color.DarkGray;
                    btn_SubMark3.BackColor = Color.DarkGray;
                    btn_SubMark4.BackColor = Color.DarkGray;
                    //shkang_s Teaching comment
                    if (enumROIType == ROIType.MarkLeft)
                        LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nSub Mark(2)\r\nClick 'MARK ROI'";
                    else if (enumROIType == ROIType.MarkRight)
                        LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nSub Mark(2)\r\nClick 'MARK ROI'";
                    break;
                case 2:
                    btn_Main_Mark.BackColor = Color.DarkGray;
                    btn_SubMark1.BackColor = Color.DarkGray;
                    btn_SubMark2.BackColor = Color.Green;
                    btn_SubMark3.BackColor = Color.DarkGray;
                    btn_SubMark4.BackColor = Color.DarkGray;
                    //shkang_s Teaching comment
                    if (enumROIType == ROIType.MarkLeft)
                        LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nSub Mark(3)\r\nClick 'MARK ROI'";
                    else if (enumROIType == ROIType.MarkRight)
                        LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nSub Mark(3)\r\nClick 'MARK ROI'";
                    break;
                case 3:
                    btn_Main_Mark.BackColor = Color.DarkGray;
                    btn_SubMark1.BackColor = Color.DarkGray;
                    btn_SubMark2.BackColor = Color.DarkGray;
                    btn_SubMark3.BackColor = Color.Green;
                    btn_SubMark4.BackColor = Color.DarkGray;
                    //shkang_s Teaching comment
                    if (enumROIType == ROIType.MarkLeft)
                        LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nSub Mark(4)\r\nClick 'MARK ROI'";
                    else if (enumROIType == ROIType.MarkRight)
                        LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nSub Mark(4)\r\nClick 'MARK ROI'";
                    break;
                case 4:
                    btn_Main_Mark.BackColor = Color.DarkGray;
                    btn_SubMark1.BackColor = Color.DarkGray;
                    btn_SubMark2.BackColor = Color.DarkGray;
                    btn_SubMark3.BackColor = Color.DarkGray;
                    btn_SubMark4.BackColor = Color.Green;
                    //shkang_s Teaching comment
                    if (enumROIType == ROIType.MarkLeft)
                        LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nSub Mark(5)\r\nClick 'MARK ROI'";
                    else if (enumROIType == ROIType.MarkRight)
                        LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nSub Mark(5)\r\nClick 'MARK ROI'";
                    break;
            }
        }

        private void BTN_PATTERN_Click(object sender, EventArgs e)
        {
            if (PT_Display01.Image == null) return;
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            BTN_ROIMARK.Visible = true;
            BTN_ROIORIGN.Visible = true;
            BTN_ROIMARK.BackColor = Color.Green;
            BTN_ROIORIGN.BackColor = Color.DarkGray;
            if (TempMarkTool[m_nSubMarkIndex].Pattern.Trained == false)
            {

                using (CogRectangle PatternRect = new CogRectangle())
                {
                    PatternRect.Interactive = true;

                    PatternRect.GraphicDOFEnable = CogRectangleDOFConstants.All;

                    PatternRect.SetCenterWidthHeight(PT_Display01.Image.Width / 2 - PT_Display01.PanX, PT_Display01.Image.Height / 2 - PT_Display01.PanY, 200, 200);
                    TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationX = PT_Display01.Image.Width / 2 - PT_Display01.PanX;
                    TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationY = PT_Display01.Image.Height / 2 - PT_Display01.PanY;
                    TempMarkTool[m_nSubMarkIndex].Pattern.TrainRegion = new CogRectangle(PatternRect);
                }
            }
            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion | CogPMAlignCurrentRecordConstants.PatternOrigin;
            Display.SetGraphics(PT_Display01, TempMarkTool[m_nSubMarkIndex].CreateCurrentRecord());
            BTN_SETMARK.Visible = true;
            bJogPatten = true;
            //shkang_s Teaching comment
            if (enumROIType == ROIType.MarkLeft)
                LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\n1. Move ROI and Origin in the area you want.\r\n2. Click 'Set Mark'";
            else if (enumROIType == ROIType.MarkRight)
                LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\n1. Move ROI and Origin in the area you want.\r\n2. Click 'Set Mark'";
            //shkang_e 
        }
        private void BTN_AkkonROI_Click(object sender, EventArgs e)
        {
            int SelectIndx = 0;
            ComboBox combo = new ComboBox();
            Button btn = new Button();
            Label lab = new Label();
            if (sender.GetType() == typeof(Button))
            {
                btn = (Button)sender;
                SelectIndx = Convert.ToInt32(btn.Tag.ToString());
            }
            else if (sender.GetType() == typeof(Label))
            {
                lab = (Label)sender;
                SelectIndx = Convert.ToInt32(lab.Tag.ToString());
            }
            else
            {
                combo = (ComboBox)sender;
                SelectIndx = Convert.ToInt32(combo.Tag.ToString());
            }
            switch (SelectIndx)
            {
                case 0: //Goup Count 
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, Main.DEFINE.MAX_LEAD_GROUP_COUNT, m_nGroupCnt, "Input Group Total Count", 1))
                    {
                        //shkang_s Comment
                        LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nEnter the 'Group Count' number to use.\r\nIf not used, Click 'Cancel'";
                        form_keypad.ShowDialog();

                        if (form_keypad.bOK)
                        {
                            m_nGroupCnt = (int)form_keypad.m_data;
                            LB_ATT_GROUP_COUNT.Text = m_nGroupCnt.ToString();
                            CB_ATT_GROUP_NO.Items.Clear();
                            if (akkonParam[m_nTabNo] == null)
                                SetProperty();
								
                            akkonParam[m_nTabNo].LeadGroupCount = m_nGroupCnt;

							if (mLeadGroupInfo == null)
                                Lead_SetProperty();
								
                            GroupListLeadData.Clear();
                            if (m_nGroupCnt != GroupListLeadData.Count)
                            {
                                if (akkonParam[m_nTabNo].LeadGroupCount <= 0)
                                    mLeadGroupInfo = new Main.LeadGroupInfo[m_nGroupCnt];

                                for (int i = 0; i < m_nGroupCnt; i++)
                                    GroupListLeadData.Add(new List<CogRectangleAffine>());
                            }
                        }

                    }
                    LBL_ATT_GROUP_NO.Visible = true;
                    CB_ATT_GROUP_NO.Visible = true;
                    LB_ATT_ROI_WIDTH.Visible = false;
                    LB_ATT_ROI_HEIGHT.Visible = false;
                    LBL_ATT_ROI_WIDTH.Visible = false;
                    LBL_ATT_ROI_HEIGHT.Visible = false;
                    LBL_ATT_FIRST_LEAD.Visible = false;
                    BTN_ATT_ROI_CREATE.Visible = false;
                    BTN_ATT_FIRSTLEAD_REGISTER.Visible = false;
                    LBL_ATT_LEAD_COUNT.Visible = false;
                    LB_ATT_LEAD_COUNT.Visible = false;
                    LBL_ATT_LEAD_PITCH.Visible = false;
                    LB_ATT_LEAD_PITCH.Visible = false;
                    LBL_ATT_CLONE_ROI.Visible = false;
                    BTN_AKKON_CLONE_HOR.Visible = false;
                    BTN_AKKON_CLONE_VER.Visible = false;
                    BTN_ATT_ROI_COPY.Visible = false;
                    LBL_ATT_ADJUST.Visible = false;
                    BTN_ATT_AUTO_SORT.Visible = false;
                    btn_GropROIApply.Visible = false;
                    GropROI_Init(akkonParam[m_nTabNo].LeadGroupCount);
                    //shkang_s
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nSelect Group Number.";
                    break;
                case 1: // Select Group No
                    //shkang_s
                    m_nGroupNo = combo.SelectedIndex;
                    if (GroupListLeadData[m_nGroupNo].Count != 0) //선택한 Group의 Data가 있을 경우 Teaching이 완료된 라벨은 다 DISPLAY.
                    {
                        LB_ATT_ROI_WIDTH.Visible = true;
                        LB_ATT_ROI_HEIGHT.Visible = true;
                        LBL_ATT_ROI_WIDTH.Visible = true;
                        LBL_ATT_ROI_HEIGHT.Visible = true;
                        LBL_ATT_FIRST_LEAD.Visible = true;
                        BTN_ATT_ROI_CREATE.Visible = true;
                        BTN_ATT_FIRSTLEAD_REGISTER.Visible = true;
                        LBL_ATT_LEAD_COUNT.Visible = true;
                        LB_ATT_LEAD_COUNT.Visible = true;
                        LBL_ATT_LEAD_PITCH.Visible = true;
                        LB_ATT_LEAD_PITCH.Visible = true;
                        LBL_ATT_CLONE_ROI.Visible = true;
                        BTN_AKKON_CLONE_HOR.Visible = true;
                        BTN_AKKON_CLONE_VER.Visible = true;
                        BTN_ATT_ROI_COPY.Visible = true;
                        LBL_ATT_ADJUST.Visible = true;
                        BTN_ATT_AUTO_SORT.Visible = true;
                        btn_GropROIApply.Visible = true;
                        btn_list_delete.Visible = true;
                        RefreshAkkonRegion();
                        if (cogRectNewROI == null)
                        {
                            cogRectNewROI = new CogRectangleAffine();
                            //GroupListLeadData[m_nGroupNo].Add(cogRectNewROI);
                        }
                        m_nROIWidth = (int)cogRectNewROI.SideXLength;
                        m_nROIHight = (int)cogRectNewROI.SideYLength;
                        LB_ATT_ROI_WIDTH.Text = m_nROIWidth.ToString();
                        LB_ATT_ROI_HEIGHT.Text = m_nROIHight.ToString();
                        LB_ATT_LEAD_COUNT.Text = mLeadGroupInfo[m_nGroupNo].LeadCount.ToString();
                        //shkang_s
                        LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nSet 'ROI WIDTH' and 'ROI HEIGHT' of FIRST LEAD.";
                    }
                    else
                    {
                        LBL_ATT_ROI_WIDTH.Visible = true;
                        LB_ATT_ROI_WIDTH.Visible = true;
                        LBL_ATT_ROI_HEIGHT.Visible = true;
                        LB_ATT_ROI_HEIGHT.Visible = true;
                        LBL_ATT_FIRST_LEAD.Visible = false;
                        BTN_ATT_ROI_CREATE.Visible = false;
                        BTN_ATT_FIRSTLEAD_REGISTER.Visible = false;
                        LBL_ATT_LEAD_COUNT.Visible = false;
                        LB_ATT_LEAD_COUNT.Visible = false;
                        LBL_ATT_LEAD_PITCH.Visible = false;
                        LB_ATT_LEAD_PITCH.Visible = false;
                        LBL_ATT_CLONE_ROI.Visible = false;
                        BTN_AKKON_CLONE_HOR.Visible = false;
                        BTN_AKKON_CLONE_VER.Visible = false;
                        BTN_ATT_ROI_COPY.Visible = false;
                        LBL_ATT_ADJUST.Visible = false;
                        BTN_ATT_AUTO_SORT.Visible = false;
                        btn_GropROIApply.Visible = false;
                        btn_list_delete.Visible = false;
                        RefreshAkkonRegion();
                        if (cogRectNewROI == null)
                        {
                            cogRectNewROI = new CogRectangleAffine();
                            //GroupListLeadData[m_nGroupNo].Add(cogRectNewROI);
                        }
                        m_nROIWidth = (int)cogRectNewROI.SideXLength;
                        m_nROIHight = (int)cogRectNewROI.SideYLength;
                        LB_ATT_ROI_WIDTH.Text = m_nROIWidth.ToString();
                        LB_ATT_ROI_HEIGHT.Text = m_nROIHight.ToString();
                        LB_ATT_LEAD_COUNT.Text = mLeadGroupInfo[m_nGroupNo].LeadCount.ToString();
                        //shkang_s
                        LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nSet 'ROI WIDTH' and 'ROI HEIGHT' of FIRST LEAD.";
                    }
                    break;
                case 2:// ROI Width
                    //shkang_s
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nEnter the ROI WIDTH\r\nUnit : ㎛\r\nRange : 1~2000";
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, m_nROIWidth, "Input ROI Width", 1))
                    {
                        form_keypad.ShowDialog();
                        //m_nROIWidth = 0;
                        m_nROIWidth = (int)form_keypad.m_data;
                        if (cogRectNewROI == null)
                            cogRectNewROI = new CogRectangleAffine();
                        cogRectNewROI.SideXLength = m_nROIWidth / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                        PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
                        BTN_ATT_FIRSTLEAD_REGISTER.Visible = true;
                        LB_ATT_ROI_WIDTH.Text = m_nROIWidth.ToString();
                    }
                    LBL_ATT_FIRST_LEAD.Visible = true;
                    BTN_ATT_ROI_CREATE.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nIf you set 'ROI HEIGHT', Click 'ROI CREATE'";
                    break;
                case 3:// ROI Height
                    //shkang_s
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nEnter the ROI HEIGHT\r\nUnit : ㎛\r\nRange : 1~2000";
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, m_nROIHight, "Input ROI Width", 1))
                    {
                        form_keypad.ShowDialog();
                        //m_nROIHight = 0;
                        m_nROIHight = (int)form_keypad.m_data;
                        if (cogRectNewROI != null)
                        {
                            PT_Display01.InteractiveGraphics.Clear();
                            PT_Display01.StaticGraphics.Clear();
                            cogRectNewROI.SideYLength = m_nROIHight / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
                            PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
                            BTN_ATT_FIRSTLEAD_REGISTER.Visible = true;
                            LB_ATT_ROI_HEIGHT.Text = m_nROIHight.ToString();
                        }
                    }
                    LBL_ATT_FIRST_LEAD.Visible = true;
                    BTN_ATT_ROI_CREATE.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nIf you set 'ROI WIDTH', Click 'ROI CREATE'";
                    break;
                case 4: // ROI Create
                    DG_AKKON_ROI_LIST.Rows.Clear();
                    PT_Display01.InteractiveGraphics.Clear();
                    PT_Display01.StaticGraphics.Clear();
                    NewROICreate();
                    BTN_ATT_FIRSTLEAD_REGISTER.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\n1. Move ROI and Set ROI Size, Angle on First Lead in Group.\r\n2. Click 'REGISTER'";
                    break;
                case 5: //ROI Register
                    if (GroupListLeadData.Count() == 0)
                    {
                        for (int nGroup = 0; nGroup < akkonParam[m_nTabNo].LeadGroupCount; nGroup++)
                            GroupListLeadData.Add(new List<CogRectangleAffine>());
                    }
                    GroupListLeadData[m_nGroupNo].Clear();
                    DG_AKKON_ROI_LIST.Rows.Clear();
                    GroupListLeadData[m_nGroupNo].Add(cogRectNewROI);
                    DG_AKKON_ROI_LIST.Rows.Add(GroupListLeadData[m_nGroupNo].Count.ToString(), "(" + GroupListLeadData[m_nGroupNo].Last().CornerOriginX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo].Last().CornerOriginY.ToString("0.0") + ")",
                        "(" + GroupListLeadData[m_nGroupNo].Last().CornerXX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo].Last().CornerXY.ToString("0.0") + ")",
                        "(" + GroupListLeadData[m_nGroupNo].Last().CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo].Last().CornerOppositeY.ToString("0.0") + ")",
                        "(" + GroupListLeadData[m_nGroupNo].Last().CornerYX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo].Last().CornerYY.ToString("0.0") + ")");
                    cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    cogRectNewROI.Interactive = false;
                    PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
                    LBL_ATT_LEAD_COUNT.Visible = true;
                    LB_ATT_LEAD_COUNT.Visible = true;
                    LBL_ATT_LEAD_PITCH.Visible = true;
                    LB_ATT_LEAD_PITCH.Visible = true;
                    PT_Display01.InteractiveGraphics.Clear();
                    PT_Display01.StaticGraphics.Clear();
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nROI Resister Complete!\r\n-> If you want to modify the ROI, Select ROI from the List and Use the 'Move Control' on the Right.\r\nSet Lead Count and Lead Pitch. ";
                    break;
                case 6://Lead Count
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nLEAD COUNT is The number of groups.\r\nInput the 'LEAD COUNT'\r\nUnit : ㎛\r\nRange : 1~5000";
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 5000, m_nLeadCount, "Input Lead Count", 1))
                    {
                        form_keypad.ShowDialog();
                        m_nLeadCount = (int)form_keypad.m_data;
                    }
                    LB_ATT_LEAD_COUNT.Text = m_nLeadCount.ToString();
                    mLeadGroupInfo[m_nGroupNo].LeadCount = m_nLeadCount;
                    LBL_ATT_CLONE_ROI.Visible = true;
                    BTN_AKKON_CLONE_HOR.Visible = true;
                    BTN_AKKON_CLONE_VER.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nLEAD COUNT input Completed!\r\nInput 'LEAD PITCH'\r\nIf input 'LEAD PITCH' completed, Select 'CLONE ROI' (Horizontal or Vertical)";
                    break;
                case 7:// Lead Pitch
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nLEAD PITCH is the interval between leads.\r\nInput the 'LEAD PITCH'\r\nUnit : ㎛\r\nRange : 1~2000";
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 2000, m_nLeadPitch, "Input Lead Pitch", 1))
                    {
                        form_keypad.ShowDialog();
                        m_nLeadPitch = (double)form_keypad.m_data;
                    }
                    LB_ATT_LEAD_PITCH.Text = m_nLeadPitch.ToString("F2");
                    mLeadGroupInfo[m_nGroupNo].LeadPitch = m_nLeadPitch;
                    LBL_ATT_CLONE_ROI.Visible = true;
                    BTN_AKKON_CLONE_HOR.Visible = true;
                    BTN_AKKON_CLONE_VER.Visible = true;
                    BTN_AKKON_CLONE_HOR.BackColor = Color.Green;
                    BTN_AKKON_CLONE_VER.BackColor = Color.White;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nLEAD PITCH input Completed!\r\nInput 'LEAD COUNT'\r\nIf input 'LEAD COUNT' completed, Select 'CLONE ROI' (Horizontal or Vertical)";
                    break;
                case 8:// Click Hor
                    BTN_AKKON_CLONE_HOR.BackColor = Color.Green;
                    BTN_AKKON_CLONE_VER.BackColor = Color.White;
                    bCloneROIDir = Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL);
                    BTN_ATT_ROI_COPY.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nSelect Direction : 'Horizontal'\r\nCheck the direction and Click 'ROI COPY'";
                    break;
                case 9: // Click Ver
                    BTN_AKKON_CLONE_HOR.BackColor = Color.White;
                    BTN_AKKON_CLONE_VER.BackColor = Color.Green;
                    bCloneROIDir = Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL);
                    BTN_ATT_ROI_COPY.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nSelect Direction : 'Vertical'\r\nCheck the direction and Click 'ROI COPY'";
                    break;
                case 10: // ROI Copy 
                         //GroupListLeadData[m_nGroupNo].Clear();
                         // GroupListLeadData[m_nGroupNo].Add(cogRectNewROI);
                    if (GroupListLeadData[m_nGroupNo].Count == 0)
                    {
                        MessageBox.Show("Empty ROI Data");
                        return;
                    }
                    ExecueAutoROI();
                    BTN_ATT_AUTO_SORT.Visible = true;
                    btn_GropROIApply.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nROI COPY Complete!\r\nSelect the Last Lead from the list and Move the ROI to the Last Lead in Group. Use 'Move Control' on the Right.\r\nIf ROI move complete, Click 'AUTO SORT'";
                    break;
                case 11://ROI Auto Sort
                    if (GroupListLeadData[m_nGroupNo].Count == 0)
                        return;

                    if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL))
                        AlignROIGapHorizontal();
                    else if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL))
                        AlignROIGapVertical();
                    btn_list_delete.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nAUTO SORT Complete! AUTO SORT lists ROI at equal intervals.\r\nIf there is an ROI you do not need, select the ROI number from the list and Click 'Delete'\r\nWhen Akkon Teaching is complete, Click 'APPLY' for Data apply";
                    break;
                case 12:// ROI Delete
                    ListDelete();
                    break;
                case 13:// Apply
                    AkkonROI_Apply();
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nAPPLY Complete!\r\nPlease Click 'SAVE' button to Save data.";
                    break;
                case 14: //ROI Show
                    RefreshAkkonRegion();
                    btn_GropROIApply.Visible = true;
                    btn_list_delete.Visible = true;
                    break;
            }
        }
        private void AkkonROI_Apply()
        {
            akkonParam[m_nTabNo].AkkonBumpROIList.Clear();
            akkonParam[m_nTabNo].LeadGroupCount = GroupListLeadData.Count();
            //for (int j = 0; j < akkonParam[m_nTabNo].LeadGroupCount; j++)
            //{
            //    for (int i = 0; i < mLeadGroupInfo[m_nTabNo].LeadCount; i++)
            //    {
            //        if (GroupListLeadData[j].Count != 0 && GroupListLeadData[j] != null)
            //            akkonParam[m_nTabNo].AkkonBumpROIList.Add(GroupListLeadData[j][i]);
            //        else
            //            break;
            //    }
            //}

            //shkang_s
            for (int j = 0; j < akkonParam[m_nTabNo].LeadGroupCount; j++)
            {
                for (int i = 0; i < mLeadGroupInfo[j].LeadCount; i++)
                {
                    if (GroupListLeadData[j].Count != 0)
                        akkonParam[m_nTabNo].AkkonBumpROIList.Add(GroupListLeadData[j][i]);
                    else
                        break;
                }
            }
            LB_ATT_LEAD_COUNT.Text = mLeadGroupInfo[m_nGroupNo].LeadCount.ToString();
        }
        private void ListDelete()
        {
            foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
            {
                int index = row.Index;
                DG_AKKON_ROI_LIST.Rows.RemoveAt(index);
                GroupListLeadData[m_nGroupNo].RemoveAt(index);
                mLeadGroupInfo[m_nGroupNo].LeadCount -= 1;
            }
            RefreshAkkonRegion();
        }
        private void AlignROIGapVertical()
        {
            bool bFirstCheck = false;
            int nTopIdx = 0, nBottomIdx = 0, nCheckedCnt = 0;
            float fDelta = 0;
            CogRadian rAngleDelta = 0;
            CogRadian rAngleFirst = 0, rAngleLast = 0;

            for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (!bFirstCheck)
                    {
                        bFirstCheck = true;
                        nTopIdx = i;
                    }
                    else
                        nBottomIdx = i;

                    nCheckedCnt++;
                }
            }

            if (nTopIdx == nBottomIdx)
            {
                Console.WriteLine("Top and Bottom Bump Index is Same!");
                return;
            }

            fDelta = ((float)(GroupListLeadData[m_nGroupNo][nBottomIdx].CenterY - GroupListLeadData[m_nGroupNo][nTopIdx].CenterY) / (float)(nCheckedCnt - 1));
            mLeadGroupInfo[m_nGroupNo].LeadPitch = fDelta;
            rAngleFirst = GroupListLeadData[m_nGroupNo][nTopIdx].Skew;
            rAngleLast = GroupListLeadData[m_nGroupNo][nBottomIdx].Skew;

            rAngleDelta = (rAngleLast.Value - rAngleFirst.Value) / (float)(nCheckedCnt - 1);
            bFirstCheck = false;
            nCheckedCnt = 0;

            double newCenterX, newCenterY;
            CogRadian newSkew;

            for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (!bFirstCheck)
                        bFirstCheck = true;
                    else
                    {
                        CogRadian pitchAngle = rAngleDelta.Value * i;

                        newCenterX = GroupListLeadData[m_nGroupNo][nTopIdx].CenterX;
                        newCenterY = GroupListLeadData[m_nGroupNo][nTopIdx].CenterY + (fDelta * nCheckedCnt);
                        newSkew = GroupListLeadData[m_nGroupNo][nTopIdx].Skew + pitchAngle.Value;
                        GroupListLeadData[m_nGroupNo][i].CenterX = newCenterX;
                        GroupListLeadData[m_nGroupNo][i].CenterY = newCenterY;
                        GroupListLeadData[m_nGroupNo][i].Skew = newSkew.Value;
                    }

                    nCheckedCnt++;
                }
            }

            RefreshAkkonRegion();
        }
        private void AlignROIGapHorizontal()
        {
            bool isFirstCheck = false;
            int leftIndex = 0, rightIndex = 0, checkCount = 0;
            float deltaX = 0, deltaY = 0;

            CogRadian deltaAngle = 0;
            CogRadian firstAngle = 0;
            CogRadian lastAngle = 0;
            // DG_AKKON_ROI_LIST.SelectAll();
            for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
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

            deltaX = ((float)(GroupListLeadData[m_nGroupNo][rightIndex].CenterX - GroupListLeadData[m_nGroupNo][leftIndex].CenterX) / (float)(checkCount - 1));
            deltaY = ((float)(GroupListLeadData[m_nGroupNo][rightIndex].CenterY - GroupListLeadData[m_nGroupNo][leftIndex].CenterY) / (float)(checkCount - 1));
            mLeadGroupInfo[m_nGroupNo].LeadPitch = deltaX;
            firstAngle = GroupListLeadData[m_nGroupNo][leftIndex].Skew;
            lastAngle = GroupListLeadData[m_nGroupNo][rightIndex].Skew;
            deltaAngle = (lastAngle.Value - firstAngle.Value) / (float)(checkCount - 1);
            isFirstCheck = false;
            checkCount = 0;

            double newCenterX, newCenterY;
            CogRadian newSkew;

            for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (!isFirstCheck)
                        isFirstCheck = true;
                    else
                    {
                        CogRadian pitchAngle = deltaAngle.Value * i;

                        newCenterX = GroupListLeadData[m_nGroupNo][leftIndex].CenterX + (deltaX * checkCount);
                        newCenterY = GroupListLeadData[m_nGroupNo][leftIndex].CenterY + (deltaY * checkCount);
                        newSkew = GroupListLeadData[m_nGroupNo][leftIndex].Skew + pitchAngle.Value;
                        GroupListLeadData[m_nGroupNo][i].CenterX = newCenterX;
                        GroupListLeadData[m_nGroupNo][i].CenterY = newCenterY;
                        GroupListLeadData[m_nGroupNo][i].Skew = newSkew.Value;
                    }

                    checkCount++;
                }
            }

            RefreshAkkonRegion();
        }
        private void ExecueAutoROI()
        {
            int nSelectIndex = 0;

            //현재 선택된 Rows 중 맨 마지막 Index 찾기
            //foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
            //    nSelectIndex = Convert.ToInt32(row.Cells[0].Value); // row의 컬럼
            nSelectIndex = 1;
            CogRectangleAffine cogTempRectAffine;
            double dNewCenterX, dNewCenterY;
            nSelectIndex += -1;
            //if (nSelectIndex > mLeadGroupInfo[m_nGroupNo].LeadCount)
            //    nSelectIndex = mLeadGroupInfo[m_nGroupNo].LeadCount-1; 
            for (int i = 0; i < mLeadGroupInfo[m_nGroupNo].LeadCount; ++i)
            {
                dNewCenterX = GroupListLeadData[m_nGroupNo][nSelectIndex].CenterX;
                dNewCenterY = GroupListLeadData[m_nGroupNo][nSelectIndex].CenterY;

                if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_VERTICAL))
                    dNewCenterY += (mLeadGroupInfo[m_nGroupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                else if (bCloneROIDir == Convert.ToBoolean(ROI_Direction.CLONE_ROI_DIR_HORIZONTAL))
                    dNewCenterX += (mLeadGroupInfo[m_nGroupNo].LeadPitch * (i) / (Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) / 1000);
                else
                    continue;

                cogTempRectAffine = new CogRectangleAffine(GroupListLeadData[m_nGroupNo][nSelectIndex]);
                cogTempRectAffine.CenterX = dNewCenterX;
                cogTempRectAffine.CenterY = dNewCenterY;
                if (i == 0)
                    GroupListLeadData[m_nGroupNo].Clear();
                //if (GroupListLeadData[m_nGroupNo][i] != null)
                //    GroupListLeadData[m_nGroupNo][i] = cogTempRectAffine;
                //else
                GroupListLeadData[m_nGroupNo].Add(cogTempRectAffine);
            }


            RefreshAkkonRegion();
        }
        private void Akkon_ROI_Theta_Jog(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int SelecIndex = Convert.ToInt32(btn.Tag.ToString());
            double dSkewUnit = Convert.ToDouble(LB_ATT_MOVE_PIXEL_COUNT.Text) / 1000;
            bool bZero = false;
            switch (SelecIndex)
            {
                case 0:
                    dSkewUnit *= -1;
                    break;
                case 1:
                    bZero = true;
                    break;
                case 2:
                    dSkewUnit *= 1;
                    break;
            }
            dSkewUnit /= PT_Display01.Zoom;
            int CellCount = DG_AKKON_ROI_LIST.GetCellCount(DataGridViewElementStates.Selected);
            if (CellCount > 0)
            {
                foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                {
                    if (bGroupModeFlag)
                    {
                        string data = row.Cells[0].Value.ToString(); // row의 컬럼
                        if (!bZero)
                            GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].Skew += dSkewUnit;
                        else
                            GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].Skew = 0;
                        GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].Interactive = false;
                        PT_Display01.InteractiveGraphics.Add(GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1], "AKKON", false);

                        DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                    }
                    else
                    {
                        string data = row.Cells[0].Value.ToString(); // row의 컬럼
                        if (!bZero)
                            akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Skew += dSkewUnit;
                        else
                            akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Skew = 0;

                        akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                        akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;
                        PT_Display01.InteractiveGraphics.Add(akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)], "AKKON", false);

                        DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                        DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOriginY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerXY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerOppositeY.ToString("0.0") + ")";
                        DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data)].CornerYY.ToString("0.0") + ")";
                    }
                }
            }
            else
            {
                if (cogRectNewROI != null)
                    cogRectNewROI.Skew += dSkewUnit;
            }
        }
        private void NewROICreate()
        {
            if (PT_Display01.Image == null) return;
            cogRectNewROI = new CogRectangleAffine();
            cogRectNewROI.SetCenterLengthsRotationSkew(500, 500, m_nROIWidth / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), m_nROIHight / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), 0, 0);
            cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
            cogRectNewROI.Interactive = true;
            cogRectNewROI.SetCenterLengthsRotationSkew((PT_Display01.Image.Width / 2 - PT_Display01.PanX), (PT_Display01.Image.Height / 2 - PT_Display01.PanY),
                cogRectNewROI.SideXLength, cogRectNewROI.SideYLength, cogRectNewROI.Rotation, cogRectNewROI.Skew);

            PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
        }
        private void RefreshAkkonRegion()
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            DG_AKKON_ROI_LIST.Rows.Clear();
            CogGraphicInteractiveCollection ROIGraphic = new CogGraphicInteractiveCollection();
            if (bGroupModeFlag)
            {
                DG_AKKON_ROI_LIST.RowCount = mLeadGroupInfo[m_nGroupNo].LeadCount;

                //현재 선택된 Group 번호에 해당하는 ROI View
                for (int i = 0; i < mLeadGroupInfo[m_nGroupNo].LeadCount; i++)
                {
                    if (GroupListLeadData[m_nGroupNo].Count == 0)
                        continue;

                    GroupListLeadData[m_nGroupNo][i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    GroupListLeadData[m_nGroupNo][i].Interactive = false;
                    ROIGraphic.Add(GroupListLeadData[m_nGroupNo][i]);
                    DG_AKKON_ROI_LIST[0, i].Value = (i + 1).ToString();
                    DG_AKKON_ROI_LIST[1, i].Value = "(" + GroupListLeadData[m_nGroupNo][i].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][i].CornerOriginY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[2, i].Value = "(" + GroupListLeadData[m_nGroupNo][i].CornerXX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][i].CornerXY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[3, i].Value = "(" + GroupListLeadData[m_nGroupNo][i].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][i].CornerOppositeY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[4, i].Value = "(" + GroupListLeadData[m_nGroupNo][i].CornerYX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][i].CornerYY.ToString("0.0") + ")";
                    CogGraphicLabel labROINo = new CogGraphicLabel();
                    labROINo.Color = CogColorConstants.Green;
                    labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                    labROINo.Text = "[" + (i + 1).ToString() + "]";
                    labROINo.X = (GroupListLeadData[m_nGroupNo][i].CornerOppositeX + GroupListLeadData[m_nGroupNo][i].CornerYX) / 2;
                    labROINo.Y = GroupListLeadData[m_nGroupNo][i].CornerYY + 40;
                    ROIGraphic.Add(labROINo);
                }
                PT_Display01.InteractiveGraphics.AddList(ROIGraphic, "ROI", false);
                ROIGraphic.Clear();
            }
            else
            {
                DG_AKKON_ROI_LIST.RowCount = akkonParam[m_nTabNo].AkkonBumpROIList.Count;

                for (int i = 0; i < akkonParam[m_nTabNo].AkkonBumpROIList.Count; i++)
                {
                    if (PT_Akkon_MarkUSE)
                    {
                        //akkonParam[m_nTabNo].AkkonBumpROIList[i].CenterX = PatResult.TranslationX + akkonParam[m_nTabNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                        //akkonParam[m_nTabNo].AkkonBumpROIList[i].CenterY = PatResult.TranslationY + akkonParam[m_nTabNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                    }

                    akkonParam[m_nTabNo].AkkonBumpROIList[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                    akkonParam[m_nTabNo].AkkonBumpROIList[i].Interactive = false;
                    ROIGraphic.Add(akkonParam[m_nTabNo].AkkonBumpROIList[i]);

                    DG_AKKON_ROI_LIST[0, i].Value = (i + 1).ToString();
                    DG_AKKON_ROI_LIST[1, i].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOriginX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOriginY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[2, i].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerXX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerXY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[3, i].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOppositeX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOppositeY.ToString("0.0") + ")";
                    DG_AKKON_ROI_LIST[4, i].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYY.ToString("0.0") + ")";
                    CogGraphicLabel labROINo = new CogGraphicLabel();
                    labROINo.Color = CogColorConstants.Green;
                    labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                    labROINo.Text = "[" + (i + 1).ToString() + "]";
                    labROINo.X = (akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOppositeX + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYX) / 2;
                    labROINo.Y = akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYY + 40;
                    ROIGraphic.Add(labROINo);
                }
                PT_Display01.InteractiveGraphics.AddList(ROIGraphic, "ROI", false);
                ROIGraphic.Clear();
            }
        }
        private void GropROI_Init(int nCount)
        {
            CB_ATT_GROUP_NO.Items.Clear();
            if (mLeadGroupInfo == null)
            {
                mLeadGroupInfo = new LeadGroupInfo[nCount];
                CB_ATT_GROUP_NO.Items.Clear();
                for (int nGoup = 0; nGoup < nCount; nGoup++)
                {
                    mLeadGroupInfo[nGoup] = new LeadGroupInfo();
                    CB_ATT_GROUP_NO.Items.Add((nGoup + 1).ToString());
                }

            }
            else if (mLeadGroupInfo[m_nGroupNo] == null)
            {
                CB_ATT_GROUP_NO.Items.Clear();
                for (int nGoup = 0; nGoup < nCount; nGoup++)
                {
                    mLeadGroupInfo[nGoup] = new LeadGroupInfo();
                    CB_ATT_GROUP_NO.Items.Add((nGoup + 1).ToString());
                }
            }
            else if (akkonParam[m_nTabNo].LeadGroupCount != nCount)
            {
                CB_ATT_GROUP_NO.Items.Clear();
                for (int nGoup = 0; nGoup < nCount; nGoup++)
                {
                    mLeadGroupInfo[nGoup] = new LeadGroupInfo();
                    CB_ATT_GROUP_NO.Items.Add((nGoup + 1).ToString());
                }
            }
            else
            {
                CB_ATT_GROUP_NO.Items.Clear();
                for (int nGoup = 0; nGoup < nCount; nGoup++)
                {
                    CB_ATT_GROUP_NO.Items.Add((nGoup + 1).ToString());
                }
            }
        }
        private void BTN_SETMARK_Click(object sender, EventArgs e)
        {

            TempMarkTool[m_nSubMarkIndex].Pattern.TrainImage = (CogImage8Grey)PT_Display01.Image;
            TempMarkTool[m_nSubMarkIndex].Pattern.Train();
            SubMarkDisplay[m_nSubMarkIndex].Image = TempMarkTool[m_nSubMarkIndex].Pattern.GetTrainedPatternImage();
            SubMarkDisplay[m_nSubMarkIndex].Fit();
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            BTN_SEARCHROI.Visible = true;
            BTN_ROIMARK.Visible = false;
            BTN_ROIORIGN.Visible = false;
            bJogOrigin = false;
            //shkang_s
            if (enumROIType == ROIType.MarkLeft)
                LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nMark Set Complete!\r\nClick 'Search ROI'";
            else if (enumROIType == ROIType.MarkRight)
                LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nMark Set Complete!\r\nClick 'Search ROI'";
            //shkang_e
        }

        private void BTN_SEARCHROI_Click(object sender, EventArgs e)
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            if (TempMarkTool[m_nSubMarkIndex].SearchRegion == null)
            {
                using (CogRectangle SearchRect = new CogRectangle())
                {
                    SearchRect.Interactive = true;
                    SearchRect.GraphicDOFEnable = CogRectangleDOFConstants.All;
                    SearchRect.SetCenterWidthHeight(PT_Display01.Image.Width / 2 - PT_Display01.PanX, PT_Display01.Image.Height / 2 - PT_Display01.PanY, 300, 300);
                    TempMarkTool[m_nSubMarkIndex].SearchRegion = new CogRectangle(SearchRect);
                }
            }
            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
            Display.SetGraphics(PT_Display01, TempMarkTool[m_nSubMarkIndex].CreateCurrentRecord());
            BTN_MARKAPPLY.Visible = true;
            bJogPatten = false;
            //shkang_s
            if (enumROIType == ROIType.MarkLeft)
                LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\nSet the ROI of inspecting Mark.\r\nClick 'Mark Test'";
            else if (enumROIType == ROIType.MarkRight)
                LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\nSet the ROI of inspecting Mark.\r\nClick 'Mark Test'";
            //shkang_e
        }

        private void BTN_MASKING_Click(object sender, EventArgs e)
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            using (Form_Mask PatternMask = new Form_Mask())
            {
                PatternMask._CogImage8Grey = (CogImage8Grey)PT_Display01.Image;
                PatternMask.IsCogPMAlignTool = TempMarkTool[m_nSubMarkIndex];
                PatternMask.ShowDialog();
            }
        }
        private void btn_ROIMove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Convert.ToInt32(btn.Tag.ToString()) == 0)
            {
                bROIMove = true;
                btn_Move.BackColor = Color.Green;
                btn_Size.BackColor = Color.DarkGray;
            }
            else
            {
                bROIMove = false;
                btn_Move.BackColor = Color.DarkGray;
                btn_Size.BackColor = Color.Green;
            }
        }
        private void BTN_IMAGE_OPEN_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.Filter = "Bmp File | *.bmp";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (Main.vision.CogImgTool[m_nCamNo] == null)
                    Main.vision.CogImgTool[m_nCamNo] = new CogImageFileTool();
                Main.GetImageFile(Main.vision.CogImgTool[m_nCamNo], openFileDialog1.FileName);
                Main.vision.CogCamBuf[m_nCamNo] = Main.vision.CogImgTool[m_nCamNo].OutputImage;

                if (Main.DEFINE.PROGRAM_TYPE.Substring(0, 3) == "ATT")
                {
                    try
                    {

                        Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanBuf = new Mat(openFileDialog1.FileName, ImreadModes.Grayscale);

                        if (Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanBuf.Depth() != (int)ImreadModes.Grayscale)
                            OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanBuf, Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                        Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanOriginalBuf = new Mat(openFileDialog1.FileName, ImreadModes.Grayscale);

                        if (Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanOriginalBuf.Depth() != (int)ImreadModes.Grayscale)
                            OpenCvSharp.Cv2.CvtColor(Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanOriginalBuf, Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_MatLineScanOriginalBuf, OpenCvSharp.ColorConversionCodes.BGR2GRAY);

                        CogImage8Grey CogConvertImage = new CogImage8Grey(Main.vision.CogImgTool[m_nCamNo].OutputImage as CogImage8Grey);
                        ICogImage8PixelMemory OriginImage8PixelMemory = CogConvertImage.Get8GreyPixelMemory(CogImageDataModeConstants.Read, 0, 0,
                            Main.vision.CogImgTool[m_nCamNo].OutputImage.Width, Main.vision.CogImgTool[m_nCamNo].OutputImage.Height);
                        if (Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgDataATT == null
                            || Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgCols != Main.vision.CogImgTool[m_nCamNo].OutputImage.Width
                            || Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgRows != Main.vision.CogImgTool[m_nCamNo].OutputImage.Height)
                        {
                            Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgDataATT = new byte[Main.vision.CogImgTool[m_nCamNo].OutputImage.Width * Main.vision.CogImgTool[m_nCamNo].OutputImage.Height];
                            Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgCols = Main.vision.CogImgTool[m_nCamNo].OutputImage.Width;
                            Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgRows = Main.vision.CogImgTool[m_nCamNo].OutputImage.Height;
                            Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_OrginalImgCols = Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgCols;
                            Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_OrginalImgRows = Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgRows;
                        }
                        Marshal.Copy(OriginImage8PixelMemory.Scan0, Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgDataATT, 0,
                            Main.vision.CogImgTool[m_nCamNo].OutputImage.Width * Main.vision.CogImgTool[m_nCamNo].OutputImage.Height);
                        OriginImage8PixelMemory.Dispose();
                        //PT_Display01.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(Main.AlignUnit[m_nCamNo].PAT[0, m_nTabNo].m_imgDataATT,
                        //                   Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Height);

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

                        cog_Display_Thumbnail.Image = Main.vision.CogCamBuf[m_nCamNo];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            PT_Display01.Image = Main.vision.CogCamBuf[m_nCamNo];

            Main.DisplayRefresh(PT_Display01);

            //shkang_s
            BTN_AKKON_ORIGINAL_IMAGE.Visible = false;
            BTN_AKKON_ORIGINAL_IMAGE.Enabled = false;
            BTN_AKKON_RESULT_IMAGE.Visible = false;
            BTN_AKKON_RESULT_IMAGE.Enabled = false;
            BTN_AKKON_TEACH_IMAGE.Visible = false;
            BTN_AKKON_TEACH_IMAGE.Enabled = false;
            //Teaching comment
            if (eInspType == 0) //Akkon UI
            {
                if (PT_Display01.Image != null)
                {
                    LB_ShowTodo.Text = "[Akkon Teaching UI]\r\n\r\nImage load OK! \r\nStart Mark or Akkon Teaching\r\nClick 'LEFT MARK'";
                }
                else
                {
                    LB_ShowTodo.Text = "[Akkon Teaching UI]\r\n\r\nImage load NG! \r\nClick 'File Open' and Select Image(.bmp) file ";
                }
            }
            else  //Align UI
            {
                if (PT_Display01.Image != null)
                {
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nImage load OK! \r\nStart Align Inspection Teaching!\r\nSelect 'INSPECTION POSITION'";
                }
                else
                {
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nImage load NG! \r\nClick 'File Open' and Select Image(.bmp) file ";
                }
            }
            //shkang_e
        }

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

        private void btn_MarkTest_Click_1(object sender, EventArgs e)
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            CogGraphicInteractiveCollection ResultOverly = new CogGraphicInteractiveCollection();
            if (PT_Display01.Image == null) return;
            if (TempMarkTool[m_nSubMarkIndex] == null || TempMarkTool[m_nSubMarkIndex].Pattern.Trained == false) return;
            TempMarkTool[m_nSubMarkIndex].InputImage = PT_Display01.Image;
            TempMarkTool[m_nSubMarkIndex].Run();
            if (TempMarkTool[m_nSubMarkIndex].Results.Count >= 1)
            {
                if (TempMarkTool[m_nSubMarkIndex].Results[0].Score >= m_nScore)
                {
                    Draw_Label(PT_Display01, "Mark     X: " + (TempMarkTool[m_nSubMarkIndex].Results[0].GetPose().TranslationX).ToString("0.000"), 1);
                    Draw_Label(PT_Display01, "Mark     Y: " + (TempMarkTool[m_nSubMarkIndex].Results[0].GetPose().TranslationY).ToString("0.000"), 2);
                    ResultOverly.Add(TempMarkTool[m_nSubMarkIndex].Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin));
                    PT_Display01.InteractiveGraphics.AddList(ResultOverly, "Result", false);
                }
                ResultOverly.Clear();

            }
            //shkang_s
            if (enumROIType == ROIType.MarkLeft)
                LB_ShowTodo.Text = "[Mark Teaching] - LEFT\r\n\r\n1. Checked the inspection Mark and Origin.\r\n2. Click the 'SAVE' button to save the Teaching parameter.";
            else if (enumROIType == ROIType.MarkRight)
                LB_ShowTodo.Text = "[Mark Teaching] - RIGHT\r\n\r\n1. Checked the inspection Mark and Origin.\r\n2. Click the 'SAVE' button to save the Teaching parameter.";
            //shkang_e
        }
        private void numericUpDown_Angle_ValueChange(object sender, EventArgs e)
        {
            NumericUpDown AngleMinMax = (NumericUpDown)sender;
            int nAngleMinMax = Convert.ToInt32(AngleMinMax.Tag.ToString());
            if (nAngleMinMax == 0)
                TempMarkTool[m_nSubMarkIndex].RunParams.ZoneAngle.High = Convert.ToDouble(AngleMinMax.Value) * Math.PI / 180;
            else
                TempMarkTool[m_nSubMarkIndex].RunParams.ZoneAngle.Low = Convert.ToDouble(AngleMinMax.Value) * Math.PI / 180;
        }

        private void btn_Mark_Complet_Click(object sender, EventArgs e)
        {
            panel_Mark.Visible = false;
            panel_Mark.Enabled = false;
            DG_AKKON_ROI_LIST.Visible = true;
        }
        private void ROI_JogMove_Click(object sender, EventArgs e)
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            Button btn = (Button)sender;
            int nMoveType = Convert.ToInt32(btn.Tag.ToString());
            int nMovePixel = Convert.ToInt32(LB_ATT_MOVE_PIXEL_COUNT.Text);
            int nJogMoveX = 0, nJogMoveY = 0;
            switch ((MoveTye)nMoveType)
            {
                case MoveTye.Up:
                    nJogMoveX = 0;
                    nJogMoveY = nMovePixel * (-1);
                    break;
                case MoveTye.Down:
                    nJogMoveX = 0;
                    nJogMoveY = nMovePixel * (1);
                    break;
                case MoveTye.Left:
                    nJogMoveX = nMovePixel * (-1);
                    nJogMoveY = 0;
                    break;
                case MoveTye.Right:
                    nJogMoveX = nMovePixel * (1);
                    nJogMoveY = 0;
                    break;
            }
            if (eInspType == enumInspectionType.Akkon)
            {
                if (ROIType.Akkon == enumROIType)
                {
                    CogGraphicInteractiveCollection ROIGraph = new CogGraphicInteractiveCollection();
                    int CellCount = DG_AKKON_ROI_LIST.GetCellCount(DataGridViewElementStates.Selected);
                    if (CellCount > 0)
                    {
                        foreach (DataGridViewRow row in DG_AKKON_ROI_LIST.SelectedRows)
                        {
                            string data = row.Cells[0].Value.ToString();
                            if (bROIMove == true)
                            {
                                if (bGroupModeFlag)
                                {
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CenterX += nJogMoveX;
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CenterY += nJogMoveY;
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;

                                    for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
                                    {
                                        GroupListLeadData[m_nGroupNo][i].Interactive = false;
                                        ROIGraph.Add(GroupListLeadData[m_nGroupNo][i]);
                                        CogGraphicLabel labROINo = new CogGraphicLabel();
                                        labROINo.Color = CogColorConstants.Green;
                                        labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                                        labROINo.Text = "[" + (i + 1).ToString() + "]";
                                        labROINo.X = (GroupListLeadData[m_nGroupNo][i].CornerOppositeX + GroupListLeadData[m_nGroupNo][i].CornerYX) / 2;
                                        labROINo.Y = GroupListLeadData[m_nGroupNo][i].CornerYY + 40;
                                        ROIGraph.Add(labROINo);
                                    }
                                    DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                                    DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                                    PT_Display01.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                                    ROIGraph.Clear();
                                }
                                else
                                {
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterX += nJogMoveX;
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CenterY += nJogMoveY;
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                                    for (int i = 0; i < DG_AKKON_ROI_LIST.RowCount; i++)
                                    {
                                        akkonParam[m_nTabNo].AkkonBumpROIList[i].Interactive = false;
                                        ROIGraph.Add(akkonParam[m_nTabNo].AkkonBumpROIList[i]);
                                        CogGraphicLabel labROINo = new CogGraphicLabel();
                                        labROINo.Color = CogColorConstants.Green;
                                        labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                                        labROINo.Text = "[" + (i + 1).ToString() + "]";
                                        labROINo.X = (akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOppositeX + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYX) / 2;
                                        labROINo.Y = akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYY + 40;
                                        ROIGraph.Add(labROINo);
                                    }


                                    DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                                    DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                                    PT_Display01.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                                    ROIGraph.Clear();
                                }
                            }
                            else
                            {
                                if (bGroupModeFlag)
                                {
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].SideXLength += nJogMoveX;
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].SideYLength += nJogMoveY;
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                                    GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].Interactive = false;
                                    for (int i = 0; i < GroupListLeadData[m_nGroupNo].Count; i++)
                                    {
                                        GroupListLeadData[m_nGroupNo][i].Interactive = false;
                                        ROIGraph.Add(GroupListLeadData[m_nGroupNo][i]);
                                        CogGraphicLabel labROINo = new CogGraphicLabel();
                                        labROINo.Color = CogColorConstants.Green;
                                        labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                                        labROINo.Text = "[" + (i + 1).ToString() + "]";
                                        labROINo.X = (GroupListLeadData[m_nGroupNo][i].CornerOppositeX + GroupListLeadData[m_nGroupNo][i].CornerYX) / 2;
                                        labROINo.Y = GroupListLeadData[m_nGroupNo][i].CornerYY + 40;
                                        ROIGraph.Add(labROINo);
                                    }

                                    PT_Display01.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                                    ROIGraph.Clear();

                                    DG_AKKON_ROI_LIST[0, Convert.ToInt32(data)-1].Value = (Convert.ToInt32(data)).ToString();
                                    DG_AKKON_ROI_LIST[1, Convert.ToInt32(data)-1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[2, Convert.ToInt32(data)-1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[3, Convert.ToInt32(data)-1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[4, Convert.ToInt32(data)-1].Value = "(" + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + GroupListLeadData[m_nGroupNo][Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                                }
                                else
                                {
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideXLength += nJogMoveX;
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].SideYLength += nJogMoveY;
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                                    akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].Interactive = false;
                                    for (int i = 0; i < DG_AKKON_ROI_LIST.RowCount; i++)
                                    {
                                        akkonParam[m_nTabNo].AkkonBumpROIList[i].Interactive = false;
                                        ROIGraph.Add(akkonParam[m_nTabNo].AkkonBumpROIList[i]);
                                        CogGraphicLabel labROINo = new CogGraphicLabel();
                                        labROINo.Color = CogColorConstants.Green;
                                        labROINo.Font = new Font(Main.DEFINE.FontStyle, 10);
                                        labROINo.Text = "[" + (i + 1).ToString() + "]";
                                        labROINo.X = (akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerOppositeX + akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYX) / 2;
                                        labROINo.Y = akkonParam[m_nTabNo].AkkonBumpROIList[i].CornerYY + 40;
                                        ROIGraph.Add(labROINo);
                                    }
                                    PT_Display01.InteractiveGraphics.AddList(ROIGraph, "ROI", false);
                                    ROIGraph.Clear();

                                    DG_AKKON_ROI_LIST[0, Convert.ToInt32(data) - 1].Value = (Convert.ToInt32(data)).ToString();
                                    DG_AKKON_ROI_LIST[1, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOriginY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[2, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerXY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[3, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerOppositeY.ToString("0.0") + ")";
                                    DG_AKKON_ROI_LIST[4, Convert.ToInt32(data) - 1].Value = "(" + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYX.ToString("0.0") + "," + akkonParam[m_nTabNo].AkkonBumpROIList[Convert.ToInt32(data) - 1].CornerYY.ToString("0.0") + ")";
                                }
                            }

                        }

                    }
                    else
                    {
                        if (bROIMove == true)
                        {
                            if (cogRectNewROI != null)
                            {
                                cogRectNewROI.CenterX += nJogMoveX;
                                cogRectNewROI.CenterY += nJogMoveY;
                                cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                                cogRectNewROI.Interactive = true;
                                PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
                            }
                        }
                        else
                        {
                            if (cogRectNewROI != null)
                            {
                                cogRectNewROI.SideXLength += nJogMoveX;
                                cogRectNewROI.SideYLength += nJogMoveY;
                                cogRectNewROI.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew;
                                cogRectNewROI.Interactive = true;
                                PT_Display01.InteractiveGraphics.Add(cogRectNewROI, "AKKON", false);
                            }
                        }
                    }
                }
                else
                {
                    if (bJogOrigin == false)
                    {
                        CogRectangle CogRect = new CogRectangle();

                        if (bJogPatten == true)
                        {
                            CogRect = (CogRectangle)TempMarkTool[m_nSubMarkIndex].Pattern.TrainRegion;
                            if (bROIMove)
                            {
                                CogRect.X += nJogMoveX;
                                CogRect.Y += nJogMoveY;
                            }
                            else
                            {
                                CogRect.Width += nJogMoveX;
                                CogRect.Height += nJogMoveY;
                            }
                            TempMarkTool[m_nSubMarkIndex].Pattern.TrainRegion = CogRect;
                            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                                | CogPMAlignCurrentRecordConstants.PatternOrigin;
                        }
                        else
                        {
                            CogRect = (CogRectangle)TempMarkTool[m_nSubMarkIndex].SearchRegion;
                            if (bROIMove)
                            {
                                CogRect.X += nJogMoveX;
                                CogRect.Y += nJogMoveY;
                            }
                            else
                            {
                                CogRect.Width += nJogMoveX;
                                CogRect.Height += nJogMoveY;
                            }
                            TempMarkTool[m_nSubMarkIndex].SearchRegion = CogRect;
                            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
                        }
                    }
                    else
                    {
                        TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationX += nJogMoveX;
                        TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationY += nJogMoveY;
                        TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                                | CogPMAlignCurrentRecordConstants.PatternOrigin;
                    }

                    Display.SetGraphics(PT_Display01, TempMarkTool[m_nSubMarkIndex].CreateCurrentRecord());
                }
            }
            else
            {
                if (eAlignInspType == enumAlignInspType.Mark)
                {
                    if (bJogOrigin == false)
                    {
                        CogRectangle CogRect = new CogRectangle();

                        if (bJogPatten == true)
                        {
                            CogRect = (CogRectangle)TempMarkTool[m_nSubMarkIndex].Pattern.TrainRegion;
                            if (bROIMove)
                            {
                                CogRect.X += nJogMoveX;
                                CogRect.Y += nJogMoveY;
                            }
                            else
                            {
                                CogRect.Width += nJogMoveX;
                                CogRect.Height += nJogMoveY;
                            }
                            TempMarkTool[m_nSubMarkIndex].Pattern.TrainRegion = CogRect;
                            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                                | CogPMAlignCurrentRecordConstants.PatternOrigin;
                        }
                        else
                        {
                            CogRect = (CogRectangle)TempMarkTool[m_nSubMarkIndex].SearchRegion;
                            if (bROIMove)
                            {
                                CogRect.X += nJogMoveX;
                                CogRect.Y += nJogMoveY;
                            }
                            else
                            {
                                CogRect.Width += nJogMoveX;
                                CogRect.Height += nJogMoveY;
                            }
                            TempMarkTool[m_nSubMarkIndex].SearchRegion = CogRect;
                            TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.InputImage | CogPMAlignCurrentRecordConstants.SearchRegion;
                        }
                    }
                    else
                    {
                        TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationX += nJogMoveX;
                        TempMarkTool[m_nSubMarkIndex].Pattern.Origin.TranslationY += nJogMoveY;
                        TempMarkTool[m_nSubMarkIndex].CurrentRecordEnable = CogPMAlignCurrentRecordConstants.TrainImage | CogPMAlignCurrentRecordConstants.TrainRegion
                                | CogPMAlignCurrentRecordConstants.PatternOrigin;
                    }

                    Display.SetGraphics(PT_Display01, TempMarkTool[m_nSubMarkIndex].CreateCurrentRecord());
                }
                else
                {
                    if (TempCaliperTool == null)
                    {
                        MessageBox.Show("Select Edge Poasition");
                        return;
                    }
                    CogRectangleAffine AlignROI = new CogRectangleAffine(TempCaliperTool.Region);
                    AlignROI.Interactive = true;
                   
                    if (bROIMove)
                    {
                        AlignROI.CenterX += nJogMoveX;
                        AlignROI.CenterY += nJogMoveY;
                    }
                    else
                    {
                        AlignROI.SideXLength += nJogMoveX;
                        AlignROI.SideYLength += nJogMoveY;
                    }
                    TempCaliperTool.Region = AlignROI;
                    TempCaliperTool.CurrentRecordEnable = CogCaliperCurrentRecordConstants.InputImage | CogCaliperCurrentRecordConstants.Region;
                    Display.SetGraphics(PT_Display01, TempCaliperTool.CreateCurrentRecord());
                }
          
            }

        }
        private void MarkMoveType(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int nType = Convert.ToInt32(btn.Tag.ToString());
            if (nType == 0)
            {
                BTN_ROIMARK.BackColor = Color.Green;
                BTN_ROIORIGN.BackColor = Color.DarkGray;
                bJogOrigin = false;
            }
            else
            {
                BTN_ROIMARK.BackColor = Color.DarkGray;
                BTN_ROIORIGN.BackColor = Color.Green;
                bJogOrigin = true;
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
                    PT_Display01.Zoom = 0.5;

                panPointX = (PT_Display01.Image.Width / 2) - panPointX;
                PT_Display01.PanX = panPointX;

                Thumbnail_MoveFlag = true;
            }
        }

        private void LB_ATT_MOVE_PIXEL_COUNT_Click_1(object sender, EventArgs e)
        {
            int nMovePixelCount = Convert.ToInt32(LB_ATT_MOVE_PIXEL_COUNT.Text);

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 50000, nMovePixelCount, "Input Move Pixel Count", 1))
            {
                form_keypad.ShowDialog();
                nMovePixelCount = (int)form_keypad.m_data;
                LB_ATT_MOVE_PIXEL_COUNT.Text = nMovePixelCount.ToString();
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
                    PT_Display01.Zoom = 0.5;

                panPointX = (PT_Display01.Image.Width / 2) - panPointX;
                PT_Display01.PanX = panPointX;
            }
        }

        private void cog_Display_Thumbnail_MouseUp(object sender, MouseEventArgs e)
        {
            Thumbnail_MoveFlag = false;
            //akkonParam[0] = AlignUnit[0].PAT[0, 0].AkkonPara;
            //_akkonParam[0] = akkonParam[0].Copy();
        }
        private Main.LeadGroupInfo[] mLeadGroupInfo;

        private AlignTagData[] alignTagData = new AlignTagData[DEFINE.TAB_NUM];
        private Main.AlignInspectionResult AlignResult = new Main.AlignInspectionResult();
        private void AlignTag_SetProperty()
        {
            alignTagData = new Main.AlignTagData[DEFINE.TAB_NUM];
            for (int nTabCnt = 0; nTabCnt < Main.DEFINE.TAP_UNIT_MAX; nTabCnt++)
            {
                alignTagData[nTabCnt] = new Main.AlignTagData();
                alignTagData[nTabCnt].SetParam(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, nTabCnt].AlignPara);
            }
            AlignResult.SetResult(AlignResult = new AlignInspectionResult());
        }
        private AkkonTagData[] akkonParam = new AkkonTagData[DEFINE.TAB_NUM];
        private AkkonTagData[] _akkonParam = new AkkonTagData[DEFINE.TAB_NUM];
        private void SetProperty()
        {
            akkonParam = new Main.AkkonTagData[DEFINE.TAB_NUM];
            mLeadGroupInfo = new Main.LeadGroupInfo[DEFINE.TAB_NUM];
            for (int nTabCnt = 0; nTabCnt < Main.DEFINE.TAP_UNIT_MAX; nTabCnt++)
            {
                akkonParam[nTabCnt] = new Main.AkkonTagData();
                akkonParam[nTabCnt].SetParam(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, nTabCnt].AkkonPara);
            }
        }
        private void Lead_SetProperty()
        {
            for (int GropCount = 0; GropCount < akkonParam[m_nTabNo].LeadGroupCount; GropCount++)
            {
                mLeadGroupInfo[GropCount] = new Main.LeadGroupInfo();
                mLeadGroupInfo[GropCount].SetParam(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].LeadGroupInfo[GropCount]);
            }
        }
        private void CB_AKKON_MARK_USE_CheckedChanged(object sender, EventArgs e)
        {
            PT_Akkon_MarkUSE = CB_AKKON_MARK_USE.Checked;
            if (PT_Akkon_MarkUSE)
            {

            }

        }

        private void BTN_AKKON_LOAD_ROI_Click(object sender, EventArgs e)
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.ReadOnlyChecked = true;
            mOpenFileDialog.Filter = "ROI.txt |*.txt";
            if (mOpenFileDialog.FileName != "")
            {
                FileStream fs = new FileStream(mOpenFileDialog.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                int count = 0;
                int lineCount = File.ReadAllLines(mOpenFileDialog.FileName).Length;
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
                    akkonParam[m_nTabNo].AkkonBumpROIList.Add(tempRectAffine);

                    count++;
                }
                sr.Close();

                Main.AlignUnit[m_nTabNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.AkkonBumpROIList = akkonParam[m_nTabNo].AkkonBumpROIList;

                TAB_ATT_LIST.SelectedIndex = 0;

                RefreshAkkonRegion();

                bool bReadRoi = Main.ATT_SendROI(m_nStageNo, m_nTabNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    return;
                }
            }
        }

        private void BTN_AKKON_CLEAR_ROI_Click(object sender, EventArgs e)
        {
            if (bGroupModeFlag)
            {
                GroupListLeadData[m_nGroupNo].Clear();
            }
            else
            {
                akkonParam[m_nTabNo].AkkonBumpROIList.Clear();
                TAB_ATT_LIST.SelectedIndex = 0;
            }

            RefreshAkkonRegion();

            int[][] nLeadPoint = new int[0][];

            bool bReadRoi = Main.ATT_SendROI(m_nStageNo, m_nTabNo, nLeadPoint); // stage, tab 별로 ROI 전송

            if (bReadRoi == false)
            {
                MessageBox.Show("Can't Read ROI File!!");
                return;
            }
        }
        private void Get_Akkon_Param()
        {

            // Maker Param
            CB_ATT_INSP_TYPE.SelectedIndex = akkonParam[m_nTabNo].AkkonInspectionOption.s_nInspType;
            CB_ATT_PANEL_TYPE.SelectedIndex = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nIsFlexible;
            CB_ATT_TARGET_TYPE.SelectedIndex = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nPanelInfo;
            CB_ATT_FILTER_TYPE.SelectedIndex = (int)akkonParam[m_nTabNo].AkkonInspectionParameter.s_eFilterType;
            CB_ATT_FILTER_DIR.SelectedIndex = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nFilterDir;
            CB_ATT_SHADOW_DIR.SelectedIndex = (int)akkonParam[m_nTabNo].AkkonInspectionParameter.s_eShadowDir;
            CB_ATT_PEAK_PROP.SelectedIndex = (int)akkonParam[m_nTabNo].AkkonInspectionParameter.s_ePeakProp;
            CB_ATT_STREN_BASE.SelectedIndex = (int)akkonParam[m_nTabNo].AkkonInspectionParameter.s_eStrengthBase;
            CB_ATT_THRES_MODE.SelectedIndex = (int)akkonParam[m_nTabNo].AkkonInspectionParameter.s_eThMode;
            CB_ATT_USE_LOG_TRACE.Checked = akkonParam[m_nTabNo].AkkonInspectionOption.s_bLogTrace;
            LB_ATT_THRES_WEIGHT.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight.ToString("F2");
            LB_ATT_PEAK_THRES.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak.ToString();
            LB_ATT_STD_DEV.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStdDevLeadJudge.ToString();
            LB_ATT_STREN_SCALE_FACTOR.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor.ToString("F2");
            LB_ATT_SLICE_OVERLAP.Text = akkonParam[m_nTabNo].AkkonInspectionOption.s_nOverlap.ToString("F2");
            ///Enginner Param  
            lb_Spec_Count.Text = akkonParam[m_nTabNo].JudgeCount.ToString();
            lb_Spec_Length.Text = akkonParam[m_nTabNo].JudgeLength.ToString("F2");
            LB_ATT_MIN_SZ_FILTER.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize.ToString("F2");
            LB_ATT_MAX_SZ_FILTER.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize.ToString("F2");
            LB_ATT_GRP_DIST.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance.ToString("F2");
            LB_ATT_STRN_FILTER.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold.ToString("F2");
            LB_ATT_WIDTH_CUT.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_nWidthCut.ToString();
            LB_ATT_HEIGHT_CUT.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_nHeightCut.ToString();
            LB_ATT_BW_RATIO.Text = akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio.ToString("F2");
            LB_ATT_EXTRE_LEAD_DISP.Text = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nExtraLead.ToString();
        }
        private void Grouping_Init()
        {
            LB_ATT_GROUP_COUNT.Text = akkonParam[m_nTabNo].LeadGroupCount.ToString();

			if (mLeadGroupInfo[m_nTabNo] == null)
                return;
				
            if (mLeadGroupInfo[m_nTabNo].LeadCount != 0)
            {
                GroupListLeadData.Clear();
                CB_ATT_GROUP_NO.Items.Clear();
                int nCount = 0;
                int nBumpCnt = 0;
                for (int GropCnt = 0; GropCnt < akkonParam[m_nTabNo].LeadGroupCount; GropCnt++)
                {
                    GroupListLeadData.Add(new List<CogRectangleAffine>());
                    nBumpCnt += mLeadGroupInfo[GropCnt].LeadCount;
                    for (int LeadCnt = 0; LeadCnt < mLeadGroupInfo[GropCnt].LeadCount; LeadCnt++)
                    {
                        if (akkonParam[m_nTabNo].AkkonBumpROIList.Count() < (nBumpCnt - 1))
                            break;
                        GroupListLeadData[GropCnt].Add(akkonParam[m_nTabNo].AkkonBumpROIList[nCount]);
                        nCount++;
                    }
                }
                RefreshAkkonRegion();
            }
        }
        private void BTN_AKKON_GROUP_Click(object sender, EventArgs e)
        {
            bGroupModeFlag = !bGroupModeFlag;
            //shkang
            BTN_AKKON_ORIGINAL_IMAGE.Visible = false;
            BTN_AKKON_ORIGINAL_IMAGE.Enabled = false;
            BTN_AKKON_RESULT_IMAGE.Visible = false;
            BTN_AKKON_RESULT_IMAGE.Enabled = false;
            BTN_AKKON_TEACH_IMAGE.Visible = false;
            BTN_AKKON_TEACH_IMAGE.Enabled = false;
            if (bGroupModeFlag == true)
            {
                TAB_ATT_LIST.Visible = true;
                TAB_ATT_LIST.Enabled = true;
                BTN_ROI_SKEW_CCW.Visible = true;
                BTN_ROI_SKEW_CCW.Enabled = true;
                BTN_ROI_SKEW_CW.Visible = true;
                BTN_ROI_SKEW_CW.Enabled = true;
                BTN_ROI_SKEW_ZERO.Visible = true;
                BTN_ROI_SKEW_ZERO.Enabled = true;
                BTN_ROIORIGN.Visible = false;
                BTN_ROIMARK.Visible = false;
                panel_Mark.Visible = false;
                panel_Mark.Enabled = false;
                bJogOrigin = false;
                bJogPatten = true;
                TAB_ATT_LIST.Location = new System.Drawing.Point(910, 58);
                panel_Akkon_ROI_Grup.Location = new System.Drawing.Point(910, 319);
                panel_AkkonParam.Visible = false;
                panel_AkkonParam.Enabled = false;
                panel_Akkon_ROI_Grup.Visible = true;
                panel_Akkon_ROI_Grup.Enabled = true;
                panel_MakerParam.Visible = false;
                panel_MakerParam.Enabled = false;
                AkkonTeachingUI_Init();
                Grouping_Init();
                //shkang
                LB_ShowTodo.Text = "[Akkon Teaching]\r\n\r\nClick Group Count.";
            }
            else
            {
                TAB_ATT_LIST.Visible = true;
                TAB_ATT_LIST.Enabled = true;
                BTN_ROI_SKEW_CCW.Visible = false;
                BTN_ROI_SKEW_CCW.Enabled = false;
                BTN_ROI_SKEW_CW.Visible = false;
                BTN_ROI_SKEW_CW.Enabled = false;
                BTN_ROI_SKEW_ZERO.Visible = false;
                BTN_ROI_SKEW_ZERO.Enabled = false;
                BTN_ROIORIGN.Visible = false;
                BTN_ROIMARK.Visible = false;
                panel_Mark.Visible = false;
                panel_Mark.Enabled = false;
                bJogOrigin = false;
                bJogPatten = true;
                TAB_ATT_LIST.Location = new System.Drawing.Point(910, 58);
                panel_Akkon_ROI_Grup.Location = new System.Drawing.Point(910, 319);
                panel_AkkonParam.Visible = false;
                panel_AkkonParam.Enabled = false;
                panel_Akkon_ROI_Grup.Visible = false;
                panel_Akkon_ROI_Grup.Enabled = false;
                panel_MakerParam.Visible = false;
                panel_MakerParam.Enabled = false;
                AkkonTeachingUI_Init();
            }
        }
        private void BTN_Akkon_Parameter_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int btnIndex = Convert.ToInt32(btn.Tag.ToString());
            if (btnIndex == 0)
            {
                panel_MakerParam.Location = new System.Drawing.Point(910, 319);
                panel_MakerParam.Visible = true;
                panel_MakerParam.Enabled = true;
                panel_AkkonParam.Visible = false;
                panel_AkkonParam.Enabled = false;
                //shkang
                LB_ShowTodo.Text = "[Akkon Maker Parmeter]\r\n\r\nSet Akkon Maker Parameter.\r\nChange Maker parameter data.\r\n[Warning!] Don't touch it unless it's Maker.";
            }
            else
            {
                panel_AkkonParam.Location = new System.Drawing.Point(910, 319);
                panel_AkkonParam.Visible = true;
                panel_AkkonParam.Enabled = true;
                panel_MakerParam.Visible = false;
                panel_MakerParam.Enabled = false;
                //shkang
                LB_ShowTodo.Text = "[Akkon Engineer Parmeter]\r\n\r\nSet Akkon Engineer Parameter.\r\nChange Engineer parameter data.\r\n[Warning!] Don't touch it unless it's Maker and Engineer.";
            }
        }
        private void BTN_MARKAPPLY_Click(object sender, EventArgs e)
        {
            if (eInspType == enumInspectionType.Akkon)
            {
                if (enumROIType == ROIType.MarkLeft)
                {
                    akkonParam[m_nTabNo].LeftPattern = TempMarkTool;
                    akkonParam[m_nTabNo].ATTMarkScore = m_nMarkScore;
                }
                else if (enumROIType == ROIType.MarkRight)
                    akkonParam[m_nTabNo].RightPattern = TempMarkTool;
            }
            else
            {
                if (enumROIType == ROIType.MarkLeft)
                {
                    alignTagData[m_nTabNo].LeftPattern = TempMarkTool;
                
                }
                else if (enumROIType == ROIType.MarkRight)
                    alignTagData[m_nTabNo].RightPattern = TempMarkTool;
            }
        }

        private void NUD_PAT_SCORE_ValueChanged(object sender, EventArgs e)
        {
            m_nMarkScore = (double)NUD_PAT_SCORE.Value / 100;
        }
        private void Set_Akkon_Engineer_Param_Click(object sender, EventArgs e)
        {
            Label lab = (Label)sender;
            int labIndex = Convert.ToInt32(lab.Tag.ToString());
            switch (labIndex)
            {
                case 0:// Spec akkon Count
                    int AkkonCnt = akkonParam[m_nTabNo].JudgeCount;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100, AkkonCnt, "Input Judge Akkon Count", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            AkkonCnt = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].JudgeCount = AkkonCnt;
                        lb_Spec_Count.Text = AkkonCnt.ToString();
                    }
                    break;
                case 1: //Spec Akkon Length
                    double Length = akkonParam[m_nTabNo].JudgeLength;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 3000.0, Length, "Input Judge Akkon Length Count", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            Length = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].JudgeLength = Length;
                        lb_Spec_Length.Text = Length.ToString("F2");
                    }
                    break;
                case 2:// Min Size
                    double MinSize = (double)akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, MinSize, "AKKON MIN SIZE FILTER (um)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            MinSize = (double)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize = (float)MinSize;
                        LB_ATT_MIN_SZ_FILTER.Text = MinSize.ToString("F2");
                    }
                    break;
                case 3:// Max Size
                    double MaxSize = (double)akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, MaxSize, "AKKON MAX SIZE FILTER(um)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            MaxSize = (double)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize = (float)MaxSize;
                        LB_ATT_MAX_SZ_FILTER.Text = MaxSize.ToString("F2");
                    }
                    break;
                case 4://Group Dist
                    double GroupDist = (double)akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, GroupDist, "AKKON GROUP DISTANCE (pixel)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            GroupDist = form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance = GroupDist;
                        LB_ATT_GRP_DIST.Text = GroupDist.ToString("F2");
                    }
                    break;
                case 5: //STRENGTH FILTER
                    float StrengthFilter = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, StrengthFilter, "STRENGTH FILTER (%)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            StrengthFilter = (float)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold = StrengthFilter;
                        LB_ATT_STRN_FILTER.Text = StrengthFilter.ToString("F2");
                    }
                    break;
                case 6://WIDTH_CUT
                    int nWidthCut = akkonParam[m_nTabNo].AkkonInspectionFilter.s_nWidthCut;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, nWidthCut, "AKKON WIDTH CUT (pixel)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            nWidthCut = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_nWidthCut = nWidthCut;
                        LB_ATT_WIDTH_CUT.Text = nWidthCut.ToString();
                    }
                    break;
                case 7://HEIGHT_CUT
                    int nHeightCut = akkonParam[m_nTabNo].AkkonInspectionFilter.s_nHeightCut;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, nHeightCut, "AKKON HEIGHT CUT (pixel)", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            nHeightCut = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_nHeightCut = nHeightCut;
                        LB_ATT_HEIGHT_CUT.Text = nHeightCut.ToString();
                    }
                    break;
                case 8://BW_RATIO
                    float Bw_Ratio = akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(-100.0, 100.0, Bw_Ratio, "AKKON BW RATIO", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            Bw_Ratio = (float)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio = Bw_Ratio;
                        LB_ATT_BW_RATIO.Text = Bw_Ratio.ToString("F2");
                    }
                    break;
                case 9://EXTRE_LEAD_DISP
                    int Extre_Lead_Disp = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nExtraLead;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 100.0, Extre_Lead_Disp, "EXTRA LEAD DISPLAY", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            Extre_Lead_Disp = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_nExtraLead = Extre_Lead_Disp;
                        LB_ATT_EXTRE_LEAD_DISP.Text = Extre_Lead_Disp.ToString();
                    }
                    break;
            }
        }
        private void Set_Maker_Parames_Changed(object sender, EventArgs e)
        {
            if (sender == null) return;
            ComboBox combo = new ComboBox();
            CheckBox chkbo = new CheckBox();
            Label lab = new Label();
            int SelectIndx;
            if (sender.GetType() == typeof(ComboBox))
            {
                combo = (ComboBox)sender;
                SelectIndx = Convert.ToInt32(combo.Tag.ToString());
            }
            else if (sender.GetType() == typeof(Label))
            {
                lab = (Label)sender;
                SelectIndx = Convert.ToInt32(lab.Tag.ToString());
            }
            else
            {
                chkbo = (CheckBox)sender;
                SelectIndx = Convert.ToInt32(chkbo.Tag.ToString());
            }
            switch (SelectIndx)
            {
                case 0://INSP_TYPE
                    akkonParam[m_nTabNo].AkkonInspectionOption.s_nInspType = combo.SelectedIndex;
                    break;
                case 1://PANEL_TYPE
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_nIsFlexible = combo.SelectedIndex;
                    break;
                case 2://ATT_TARGET_TYPE
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_nPanelInfo = combo.SelectedIndex;
                    if (combo.SelectedIndex == (int)PanelType.COF)
                    {
                        CB_ATT_FILTER_TYPE.SelectedIndex = 3;
                        Set_Maker_Parames_Changed(null, null);

                        CB_ATT_PEAK_PROP.SelectedIndex = 0;
                        Set_Maker_Parames_Changed(null, null);

                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight = 2;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = 1;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak = 70;

                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize = 15;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance = 3;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                        CB_ATT_STREN_BASE.SelectedIndex = 0;
                        Set_Maker_Parames_Changed(null, null);
                    }
                    else if (combo.SelectedIndex == (int)PanelType.COG)
                    {
                        CB_ATT_FILTER_TYPE.SelectedIndex = 4;
                        Set_Maker_Parames_Changed(null, null);

                        CB_ATT_PEAK_PROP.SelectedIndex = 1;
                        Set_Maker_Parames_Changed(null, null);

                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight = 1.5;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.2;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak = 70;

                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize = 0;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize = 100;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance = 2;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio = -100;

                        CB_ATT_STREN_BASE.SelectedIndex = 1;
                        Set_Maker_Parames_Changed(null, null);
                    }
                    else
                    {
                        CB_ATT_FILTER_TYPE.SelectedIndex = 0;
                        Set_Maker_Parames_Changed(null, null);

                        CB_ATT_PEAK_PROP.SelectedIndex = 1;
                        Set_Maker_Parames_Changed(null, null);

                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight = 4;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthThreshold = 50;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = (float)0.5;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak = 70;

                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMinSize = (float)2.5;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fMaxSize = 30;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fGroupingDistance = 5;
                        akkonParam[m_nTabNo].AkkonInspectionFilter.s_fBWRatio = (float)0.45;

                        CB_ATT_STREN_BASE.SelectedIndex = 1;
                        Set_Maker_Parames_Changed(null, null);
                    }
                    break;
                case 3://FILTER_TYPE
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_eFilterType = (EN_MVFILTERTYPE_WRAP)combo.SelectedIndex;
                    break;
                case 4://FILTER_DIR
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_nFilterDir = combo.SelectedIndex;
                    break;
                case 5://SHADOW_DIR
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_eShadowDir = (EN_SHADOWDIR_WRAP)combo.SelectedIndex;
                    break;
                case 6://PEAK_PROP
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_ePeakProp = (EN_PEAK_PROP_WRAP)combo.SelectedIndex;
                    break;
                case 7://STREN_BASE
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_eStrengthBase = (EN_STRENGTH_BASE_WRAP)combo.SelectedIndex;
                    break;
                case 8://THRES_MODE
                    akkonParam[m_nTabNo].AkkonInspectionParameter.s_eThMode = (EN_THMODE_WRAP)combo.SelectedIndex;
                    break;
                case 9:// Log Trace
                    akkonParam[m_nTabNo].AkkonInspectionOption.s_bLogTrace = chkbo.Checked;
                    break;
                case 10://THRES_WEIGHT
                    double ThresWeight = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, ThresWeight, "THRESHOLD WEIGHT", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            ThresWeight = form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fThWeight = ThresWeight;
                        LB_ATT_THRES_WEIGHT.Text = ThresWeight.ToString("F2");
                    }
                    break;
                case 11://PEAK_THRES
                    int PeakThres = akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 255, PeakThres, "PEAK THRESHOLD", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            PeakThres = (int)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_nThPeak = PeakThres;
                        LB_ATT_PEAK_THRES.Text = PeakThres.ToString();
                    }
                    break;
                case 12://STREN_SCALE_FACTOR
                    float Stren_Scale_factor = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 1, Stren_Scale_factor, "STRENGTH SCALE FACTOR", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            Stren_Scale_factor = (float)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStrengthScaleFactor = Stren_Scale_factor;
                        LB_ATT_STREN_SCALE_FACTOR.Text = Stren_Scale_factor.ToString("F2");
                    }
                    break;
                case 13://Over lap (X) -> Auto Calculation
                    break;
                case 14://LB_ATT_STD_DEV
                    float Std_Dev = akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStdDevLeadJudge;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0.01, 10, Std_Dev, "LEAD JUDGE STANDARD DEVIATION", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK == true)
                            Std_Dev = (float)form_keypad.m_data;
                        akkonParam[m_nTabNo].AkkonInspectionParameter.s_fStdDevLeadJudge = Std_Dev;
                        LB_ATT_STD_DEV.Text = Std_Dev.ToString("F2");
                    }
                    break;
            }
            Get_Akkon_Param();
        }

        private void BTN_SAVE_Click(object sender, EventArgs e)
        {
            using (Form_Message formMessage = new Form_Message(2))
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
                    formpassword.Dispose();
                    return;
                }
                formpassword.Dispose();
            }
            if (eInspType == enumInspectionType.Akkon)
            {
                for (int TabCnt = 0; TabCnt < DEFINE.TAP_UNIT_MAX; TabCnt++)
                {
                    for (int GropCnt = 0; GropCnt < akkonParam[m_nTabNo].LeadGroupCount; GropCnt++)
                    {
                        Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, TabCnt].LeadGroupInfo[GropCnt] = mLeadGroupInfo[GropCnt].Copy();
                    }
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, TabCnt].AkkonPara = akkonParam[TabCnt].Copy();
                    Main.AlignUnit[m_nCamNo].Save_ATT(m_nStageNo, TabCnt);//2022 1014 YSH Tab별 Save        }
                }
            }
            else
            {
                for (int TabCnt = 0; TabCnt < DEFINE.TAP_UNIT_MAX; TabCnt++)
                {
                   
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, TabCnt].AlignPara = alignTagData[TabCnt].Copy();
                    Main.AlignUnit[m_nCamNo].Save_ATT(m_nStageNo, TabCnt);//2022 1014 YSH Tab별 Save        }
                }
            }

        }
        private void SelectTab_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int SelectIndex = Convert.ToInt32(btn.Tag.ToString());

            if (SelectIndex == (int)enumTab.Next)
            {
                if (m_nTabNo >= (DEFINE.TAP_UNIT_MAX - 1))
                {
                    m_nTabNo = DEFINE.TAP_UNIT_MAX - 1;
                    btn_TabNo.Text = "Tab " + (m_nTabNo + 1).ToString();
                }
                else
                {
                    m_nTabNo += 1;
                    btn_TabNo.Text = "Tab " + (m_nTabNo + 1).ToString();
                }

            }
            else
            {
                if (m_nTabNo <= 0)
                {
                    m_nTabNo = 0;
                    btn_TabNo.Text = "Tab " + (m_nTabNo + 1).ToString();
                }
                else
                {
                    m_nTabNo -= 1;
                    btn_TabNo.Text = "Tab " + (m_nTabNo + 1).ToString();
                }
            }

            if (eInspType == enumInspectionType.Akkon)
            {
                UIInit();
                Akkon_init();
                Get_Akkon_Param();
            }
            else
            {
                UIInit();
            }

        }

        private void BTN_TEST_Click(object sender, EventArgs e)
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            if (eInspType == enumInspectionType.Akkon)
            {
                Search_Akkon(false);
                //shkang_s
                BTN_AKKON_ORIGINAL_IMAGE.Visible = true;
                BTN_AKKON_ORIGINAL_IMAGE.Enabled = true;
                BTN_AKKON_RESULT_IMAGE.Visible = true;
                BTN_AKKON_RESULT_IMAGE.Enabled = true;
                BTN_AKKON_TEACH_IMAGE.Visible = true;
                BTN_AKKON_TEACH_IMAGE.Enabled = true;
            }
            else
            {
                PT_Display01.InteractiveGraphics.Clear();
                PT_Display01.StaticGraphics.Clear();
                if (PT_Display01.Image == null) return;
                if (alignTagData[m_nTabNo].LeadCount <= 0) return;
                AlignInsption();
            }
        }
        private bool Search_Akkon(bool nALLSEARCH)
        {
            bool nRet = true;
            bool TempSelect = false;
            int nStartNum = 0;
            int nLastNum = 0;

            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            LABEL_MESSAGE(LB_MESSAGE1, "", Color.Red);
            //if (nALLSEARCH)
            //{
            //    nStartNum = 0;
            //    nLastNum = Main.DEFINE.AKKON_MAX;
            //}
            //else
            //{
            //    nStartNum = m_SelectAkkon;
            //    nLastNum = m_SelectAkkon + 1;
            //}

            akkonParam[m_nTabNo].UseCheckAkkonInspection = true;
            Main.sw.Start();

            if (akkonParam[m_nTabNo].UseCheckAkkonInspection)
            {
                TempSelect = true;

                //if (PT_Akkon_MarkUSE[TapNo])
                //{
                //    for (int j = 0; j < PT_AkkonPara[TapNo].AkkonBumpROIList.Count; j++)
                //    {
                //        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterX = PatResult.TranslationX + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].X;
                //        PT_AkkonPara[TapNo].AkkonBumpROIList[j].CenterY = PatResult.TranslationY + PT_AkkonPara[TapNo].TargetToCenter[Main.DEFINE.M_CNLSEARCHTOOL].Y;
                //    }
                //}


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
                if (akkonParam[m_nTabNo].AkkonInspectionParameter.s_nPanelInfo == 0)
                    Main.DEFINE.ImageResizeRatio = (float)0.6;
                else if (akkonParam[m_nTabNo].AkkonInspectionParameter.s_nPanelInfo == 1)
                    Main.DEFINE.ImageResizeRatio = (float)1.0;
                else if (akkonParam[m_nTabNo].AkkonInspectionParameter.s_nPanelInfo == 2)
                    Main.DEFINE.ImageResizeRatio = (float)0.6;

                //2022 1004 YSH
                //Resize 0.5 사용시 Result 이미지 이상출력
                //Main.DEFINE.ImageResizeRatio = (float)0.6;
                Main.ATT_CreateDLLBuffer();
                Main.ATT_CreateImageBuffer();


                //ATT Mark search 
                double dX = 0, dY = 0, dTeachT = 0, dRotT = 0;
                OpenCvSharp.Point2d pntCenter = new Point2d();
                OpenCvSharp.Point2d pntdXY = new Point2d();
                pntCenter.X = 0; pntCenter.Y = 0;

                bool bLeftMarkCheck = false;
                bool bRightMarkCheck = false;
                // 임시
                int m_PatNo_Sub = 0;
                akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].InputImage = PT_Display01.Image;
                akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].InputImage = PT_Display01.Image;

                akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Run();
                akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Run();

                if (akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results != null)
                {
                    if (akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results.Count >= 1)
                        bLeftMarkCheck = true;
                }
                if (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results != null)
                {
                    if (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results.Count >= 1)
                        bRightMarkCheck = true;
                }

                if (bLeftMarkCheck && bRightMarkCheck)
                {
                    //추후 Score 기능 추가 예정 - YSH        
                    dX = (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2
                    - (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX) / 2;

                    dY = (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2
                    - (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY) / 2;

                    double dRotDx = akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX - akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX;
                    double dRotDy = akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY - akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY;
                    dRotT = OpenCvSharp.Cv2.FastAtan2((float)dRotDy, (float)dRotDx);
                    if (dRotT > 180) dRotT -= 360;

                    //float a = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY);
                    //float b = (float)(PT_AkkonPara[TapNo].m_RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - PT_AkkonPara[TapNo].m_LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX);

                    dTeachT = OpenCvSharp.Cv2.FastAtan2((float)(akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationY - akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationY),
                        (float)(akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Pattern.Origin.TranslationX - akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Pattern.Origin.TranslationX));
                    if (dTeachT > 180.0) dTeachT -= 360.0;


                    dRotT -= dTeachT;
                    pntCenter.X = (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationX) / 2;
                    pntCenter.Y = (akkonParam[m_nTabNo].RightPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY + akkonParam[m_nTabNo].LeftPattern[m_PatNo_Sub].Results[0].GetPose().TranslationY) / 2;

                    pntdXY.X = dX;
                    pntdXY.Y = dY;
                }
                else
                {
                    LABEL_MESSAGE(LB_MESSAGE1, "Mark Search NG! ", Color.Red);
                }

                Cv2.Resize(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf,
                    new OpenCvSharp.Size(0, 0), Main.DEFINE.ImageResizeRatio, Main.DEFINE.ImageResizeRatio);
                byte[] bytes2 = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Rows];
                Cv2.ImEncode(".bmp", Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf, out bytes2);
                Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgDataATT = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Rows];
                Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgCols = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Cols;
                Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgRows = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Rows;
                Main.strtmp[0] = Main.sw.ElapsedMilliseconds.ToString();
                Main.sw.Stop();
                Main.sw.Reset();



                //압흔 Parameter 갱신부분 추가 필요 - YSH



                ////////////////////////////////////////////////////////////////////////////////////////////////////////
                Main.sw.Start();
                // ROI Resize
                int[][] nLeadPoint = new int[akkonParam[m_nTabNo].AkkonBumpROIList.Count][];
                OpenCvSharp.Point[] ptPos = new OpenCvSharp.Point[4];
                for (int j = 0; j < akkonParam[m_nTabNo].AkkonBumpROIList.Count; j++)
                {
                    nLeadPoint[j] = new int[8];

                    nLeadPoint[j][0] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerOriginX);  //LeftTop
                    nLeadPoint[j][1] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerOriginY);  //LeftTop

                    nLeadPoint[j][2] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerXX);  //RightTop
                    nLeadPoint[j][3] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerXY);  //RightTop

                    nLeadPoint[j][4] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerOppositeX);  //RightBottom
                    nLeadPoint[j][5] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerOppositeY);  //RightBottom

                    nLeadPoint[j][6] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerYX);  //LeftBottom
                    nLeadPoint[j][7] = (int)(akkonParam[m_nTabNo].AkkonBumpROIList[j].CornerYY);  //LeftBottom

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
                bool bReadRoi = Main.ATT_SendROI(m_nCamNo, m_nTabNo, nLeadPoint); // stage, tab 별로 ROI 전송

                if (bReadRoi == false)
                {
                    MessageBox.Show("Can't Read ROI File!!");
                    return false;
                }



                // ATT RUN
                bool bReady = Main.ATT_ReadyToInsp(m_nCamNo, m_nStageNo, m_nTabNo, akkonParam[m_nTabNo]);

                // 자동 계산 overlap 확인
                LB_ATT_SLICE_OVERLAP.Text = akkonParam[m_nTabNo].AkkonInspectionOption.s_nOverlap.ToString();

                if (bReady)
                {
                    Main.isFormTeaching = true;
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].bResulteTime = false;
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray = null;
                    Main.ATT_InspectByTap(m_nCamNo, m_nStageNo, m_nTabNo);
                }

            }
            return nRet;
        }
        private void LABEL_MESSAGE(Label nlabel, string nText, Color nColor)
        {
            nlabel.ForeColor = nColor;
            nlabel.Text = nText;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].bResulteTime == true)
            {
                Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].bResulteTime = false;
                ShowAkkonResultImage(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgOverlay);
                RefreshAkkonResult();
            }
        }
        public static void ShowAkkonResultImage(CogImage24PlanarColor cogResultImage)
        {
            PT_Display01.Image = cogResultImage;
            _bATTResult = true;
        }
        private void RefreshAkkonResult()
        {

            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            DG_AKKON_RESULT.Rows.Clear();
            DG_AKKON_RESULT.RowCount = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0].Length;

            for (int i = 0; i < Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0].Length; i++)
            {
                DG_AKKON_RESULT[0, i].Value = (i + 1).ToString();
                DG_AKKON_RESULT[1, i].Value = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0][i].s_nNumBlobs.ToString();
                DG_AKKON_RESULT[2, i].Value = (Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0][i].s_fLength / 1000).ToString("0.000");
                DG_AKKON_RESULT[3, i].Value = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0][i].s_fAvgStrength.ToString("0.000");
                DG_AKKON_RESULT[4, i].Value = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonResult.AkkonResultArray[0][i].s_bJudgement.ToString();
            }

            TAB_ATT_LIST.SelectedIndex = 1;

            Main.DisplayFit(PT_Display01);

        }

        private void BTN_AKKON_ORIGINAL_IMAGE_Click(object sender, EventArgs e)
        {
            if (Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf != null)
            {
                //byte[] bytes2 = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Rows];

                byte[] bytes = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Cols * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Rows];
                //Bitmap Data = new Bitmap(@"d:\134.bmp");
                //Mat TEST = BitmapConverter.ToMat(Data);

                byte[] Arr = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Width * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Height];

                Marshal.Copy(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Data, Arr, 0, Arr.Length);

                Bitmap bmp = new Bitmap(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                // Create a BitmapData and lock all pixels to be written 
                BitmapData bmpData = bmp.LockBits(
                                    new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
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

                Marshal.Copy(Arr, 0, bmpData.Scan0, Arr.Length);

                // Unlock the pixels
                bmp.UnlockBits(bmpData);



                //bytes2 = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.ToBytes(".bmp");
                //Cv2.ImEncode(".bmp", Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf, out bytes2);




                PT_Display01.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(Arr,
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanBuf.Height);
            }
        }

        private void BTN_AKKON_RESULT_IMAGE_Click(object sender, EventArgs e)
        {
            if (Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgOverlay != null)
            {
                PT_Display01.Image = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_imgOverlay;
            }
        }

        private void BTN_AKKON_TEACH_IMAGE_Click(object sender, EventArgs e)
        {
            if (Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf != null)
            {
                byte[] bytes = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Cols * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Rows];
                //Bitmap Data = new Bitmap(@"d:\134.bmp");
                //Mat TEST = BitmapConverter.ToMat(Data);

                byte[] Arr = new byte[Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Width * Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Height];

                Marshal.Copy(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Data, Arr, 0, Arr.Length);

                Bitmap bmp = new Bitmap(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

                // Create a BitmapData and lock all pixels to be written 
                BitmapData bmpData = bmp.LockBits(
                                    new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
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

                Marshal.Copy(Arr, 0, bmpData.Scan0, Arr.Length);

                // Unlock the pixels
                bmp.UnlockBits(bmpData);

                //// bytes = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.ToBytes(".bmp");
                ////Cv2.ImEncode(".bmp", Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf, out bytes);
                //Bitmap tmep = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf);
                ////System.Drawing.Imaging.BitmapData test =
                //Rectangle rect = new Rectangle(0, 0, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Height);
                //System.Drawing.Imaging.BitmapData bmpData =
                //    tmep.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                //    tmep.PixelFormat);
                //int bytess = Math.Abs(bmpData.Stride) * tmep.Height;
                //IntPtr ptr = bmpData.Scan0;
                //byte[] rgbValues = new byte[bytess];
                //Marshal.Copy(ptr, rgbValues, 0, bytess);



                PT_Display01.Image = Main._ClsImage.Convert8BitRawImageToCognexImage(Arr,
                    Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Width, Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].m_MatLineScanOriginalBuf.Height);
            }
        }
        private void btn_AlignInsp_Setting_Click(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            int btnIndex = Convert.ToInt32(btn.Tag.ToString());
            switch (btnIndex)
            {
                case 0: //Insposition Left
                    enumROIType = ROIType.MarkLeft;
                    RBTN_ALIGN_INSPOS_LEFT.BackColor = Color.Green;
                    RBTN_ALIGN_INSPOS_RIGHT.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TARPOS_FPC.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.DarkGray;

                    lab_AlignInsp_Target_Pos.Visible = true;
                    RBTN_ALIGN_TARPOS_FPC.Visible = true;
                    RBTN_ALIGN_TARPOS_PANEL.Visible = true;

                    lab_AlingInsp_pos.Visible = false;
                    lab_TeachMode.Visible = false;
                    RBTN_ALIGNPOS_X.Visible = false;
                    RBTN_ALIGNPOS_X.Enabled = false;
                    RBTN_ALIGN_TEACH_MARK.Visible = false;
                    RBTN_ALIGN_TEACH_MARK.Enabled = false;
                    RBTN_ALIGN_TEACH_EDGE.Visible = false;
                    RBTN_ALIGN_TEACH_EDGE.Enabled = false;
                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;
                    Align_MarkUI_Init();
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nInspection Position : LEFT\r\n\r\nSelect 'TARGET POSITION'";
                    break;
                case 1://Insposition Right
                    enumROIType = ROIType.MarkRight;
                    RBTN_ALIGN_INSPOS_LEFT.BackColor = Color.DarkGray;
                    RBTN_ALIGN_INSPOS_RIGHT.BackColor = Color.Green;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TARPOS_FPC.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.DarkGray;

                    lab_AlignInsp_Target_Pos.Visible = true;
                    RBTN_ALIGN_TARPOS_FPC.Visible = true;
                    RBTN_ALIGN_TARPOS_PANEL.Visible = true;

                    lab_AlingInsp_pos.Visible = false;
                    RBTN_ALIGNPOS_X.Visible = false;
                    RBTN_ALIGNPOS_X.Enabled = false;
                    RBTN_ALIGNPOS_Y.Visible = false;
                    RBTN_ALIGNPOS_Y.Enabled = false;

                    lab_TeachMode.Visible = false;
                    RBTN_ALIGN_TEACH_MARK.Visible = false;
                    RBTN_ALIGN_TEACH_MARK.Enabled = false;
                    RBTN_ALIGN_TEACH_EDGE.Visible = false;
                    RBTN_ALIGN_TEACH_EDGE.Enabled = false;
                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;
                    Align_MarkUI_Init();
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nInspection Position : RIGHT\r\n\r\nSelect 'TARGET POSITION'";
                    break;
                case 2:// Targeet Position FPC 
                    eAlignInsPos = enumAlignInspPos.FPC;
                    RBTN_ALIGN_TARPOS_FPC.BackColor = Color.Green;
                    RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;

                    lab_TeachMode.Visible = true;
                    RBTN_ALIGN_TEACH_MARK.Visible = true;
                    RBTN_ALIGN_TEACH_EDGE.Visible = true;
                    RBTN_ALIGN_TEACH_EDGE.Enabled = true;
                    RBTN_ALIGN_TEACH_MARK.Enabled = true;

                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;

                    lab_AlingInsp_pos.Visible = false;
                    RBTN_ALIGNPOS_X.Visible = false;
                    RBTN_ALIGNPOS_X.Enabled = false;
                    RBTN_ALIGNPOS_Y.Visible = false;
                    RBTN_ALIGNPOS_Y.Enabled = false;
					//shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nTarget Position : FPC\r\n\r\nSelect 'TEACH MODE'";
                    break;
                case 3:// Targeet Position Panel
                    eAlignInsPos = enumAlignInspPos.Panel;
                    RBTN_ALIGN_TARPOS_FPC.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TARPOS_PANEL.BackColor = Color.Green;
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;

                    lab_TeachMode.Visible = true;
                    RBTN_ALIGN_TEACH_MARK.Visible = true;
                    RBTN_ALIGN_TEACH_EDGE.Visible = true;
                    RBTN_ALIGN_TEACH_EDGE.Enabled = true;
                    RBTN_ALIGN_TEACH_MARK.Enabled = false;
                    
                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;

                    lab_AlingInsp_pos.Visible = false;
                    RBTN_ALIGNPOS_X.Visible = false;
                    RBTN_ALIGNPOS_X.Enabled = false;
                    RBTN_ALIGNPOS_Y.Visible = false;
                    RBTN_ALIGNPOS_Y.Enabled = false;
					//shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nTarget Position : PANEL\r\n\r\nSelect Teach Mode : 'EDGE'\r\n(Mark registered by Akkon Teaching is used as the PANEL Mark.)";
                    break;
                case 4:// Teach Mode Mark
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.Green;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.DarkGray;

                    panel_Mark.Visible = true;
                    panel_Mark.Enabled = true;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;
                    panel_Mark.Location = new System.Drawing.Point(909, 146);
                    lab_AlingInsp_pos.Visible = false;
                    RBTN_ALIGNPOS_X.Visible = false;
                    RBTN_ALIGNPOS_X.Enabled = false;
                    RBTN_ALIGNPOS_Y.Visible = false;
                    RBTN_ALIGNPOS_Y.Enabled = false;
                    eAlignInspType = enumAlignInspType.Mark;
					//shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nTeach Mode : MARK\r\n\r\nSelect Mark Index.\r\n(Main, Sub(2,3,4,5))";
                    break;
                case 5:// Teach Mode Edge
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_MARK.BackColor = Color.DarkGray;
                    RBTN_ALIGN_TEACH_EDGE.BackColor = Color.Green;
                    PANEL_AT_CALIPER.Location = new System.Drawing.Point(909, 146);
                    lab_AlingInsp_pos.Visible = true;
                    RBTN_ALIGNPOS_X.Visible = true;
                    RBTN_ALIGNPOS_X.Enabled = true;
                    RBTN_ALIGNPOS_Y.Visible = true;
                    RBTN_ALIGNPOS_Y.Enabled = true;
                    panel_Mark.Visible = false;
                    panel_Mark.Enabled = false;
                    PANEL_AT_CALIPER.Visible = false;
                    PANEL_AT_CALIPER.Enabled = false;
                    eAlignInspType = enumAlignInspType.Edge;
					//shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nTeach Mode : EDGE\r\n\r\nSelect 'ALIGN POSITION'";
                    break;
                case 6:// Align Position X
                    RBTN_ALIGNPOS_X.BackColor = Color.Green;
                    RBTN_ALIGNPOS_Y.BackColor = Color.DarkGray;
                    eEdgePos = enumEdgePos.X;
                    PANEL_AT_CALIPER.Visible = true;
                    PANEL_AT_CALIPER.Enabled = true;
                    LB_ALIGN_LEAD_COUNT.Enabled = true;
                    CB_ALIGN_ROI_TRACKING.Visible = false;  //임시
                    EdgeUI_Init();
					//shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nAlign Position : X\r\n\r\nInput 'LEAD COUNT'\r\nClick Text Label.";
                    break;
                case 7:// Align Position Y
                    RBTN_ALIGNPOS_X.BackColor = Color.DarkGray;
                    RBTN_ALIGNPOS_Y.BackColor = Color.Green;
                    eEdgePos = enumEdgePos.Y;
                    PANEL_AT_CALIPER.Visible = true;
                    PANEL_AT_CALIPER.Enabled = true;
                    LB_ALIGN_LEAD_COUNT.Enabled = false;
                    CB_ALIGN_ROI_TRACKING.Visible = false;  //임시
                    EdgeUI_Init();
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nAlign Position : Y\r\n\r\nClick 'Show ROI'\r\nY Align use always '1' Lead Count";
                    break;
            }
        }
        private void Align_MarkUI_Init()
        {
            BTN_ROI_SKEW_CCW.Visible = false;
            BTN_ROI_SKEW_CCW.Enabled = false;
            BTN_ROI_SKEW_CW.Visible = false;
            BTN_ROI_SKEW_CW.Enabled = false;
            BTN_ROI_SKEW_ZERO.Visible = false;
            BTN_ROI_SKEW_ZERO.Enabled = false;
            BTN_ROIORIGN.Visible = false;
            BTN_ROIMARK.Visible = false;
            bJogOrigin = false;
            bJogPatten = true;
            panel_MakerParam.Visible = false;
            panel_MakerParam.Enabled = false;
            if (enumROIType == ROIType.MarkLeft)
                TempMarkTool = alignTagData[m_nTabNo].LeftPattern;
            else
                TempMarkTool = alignTagData[m_nTabNo].RightPattern;
            MarkTeachingInit();
        }
        private void EdgeUI_Init()
        {
            if (eEdgePos == enumEdgePos.X)
            {
                lab_Edge_Polarty.Visible = false;
                RBTN_DARK_TO_BRIGHT.Visible = false;
                RBTN_BRIGHT_TO_DARK.Visible = false;
                lab_Filter_Size.Visible = false;
                LB_ALIGN_FILTER_SIZE.Visible = false;
                lab_EdgeThresHold.Visible = false;
                LB_ALIGN_EDGE_THRESHOLD.Visible = false;
                RBTN_ALIGN_EDGE_APPLY.Visible = false;
            }
            else
            {
                lab_Edge_Polarty.Visible = true;
                RBTN_DARK_TO_BRIGHT.Visible = true;
                RBTN_BRIGHT_TO_DARK.Visible = true;
                lab_Filter_Size.Visible = true;
                LB_ALIGN_FILTER_SIZE.Visible = true;
                lab_EdgeThresHold.Visible = true;
                LB_ALIGN_EDGE_THRESHOLD.Visible = true;
                RBTN_ALIGN_EDGE_APPLY.Visible = true;
            }
            Get_EdgeParms();
        }
        private void Get_EdgeParms()
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            if (eEdgePos == enumEdgePos.X)
            {
                lab_AlignInspLeadCnt.Visible = true;
                LB_ALIGN_LEAD_COUNT.Visible = true;
                LB_ALIGN_LEAD_COUNT.Text = alignTagData[m_nTabNo].LeadCount.ToString();
                TempCaliperTool = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)eAlignInsPos];
                m_nAlignLead = alignTagData[m_nTabNo].LeadCount;
                LB_ALIGN_LEAD_COUNT.Text = m_nAlignLead.ToString();
            }
            else
            {
                lab_AlignInspLeadCnt.Visible = true;
                LB_ALIGN_LEAD_COUNT.Visible = true;
                TempCaliperTool = alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, (int)eAlignInsPos];
                LB_ALIGN_LEAD_COUNT.Text = "1";   //Y align의 lead count 항상 1
            }
            if (TempCaliperTool == null)
                TempCaliperTool = new CogCaliperTool();
            LB_ALIGN_FILTER_SIZE.Text = TempCaliperTool.RunParams.FilterHalfSizeInPixels.ToString();
            LB_ALIGN_EDGE_THRESHOLD.Text = TempCaliperTool.RunParams.ContrastThreshold.ToString();
            CogCaliperPolarityConstants nPolarity = TempCaliperTool.RunParams.Edge0Polarity;
            if (nPolarity == CogCaliperPolarityConstants.DarkToLight)
            {
                RBTN_DARK_TO_BRIGHT.BackColor = Color.Green;
                RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
            }
            else if (nPolarity == CogCaliperPolarityConstants.LightToDark)
            {
                RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                RBTN_BRIGHT_TO_DARK.BackColor = Color.Green;
            }
            else
            {
                RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
            }
        }
        private void btnEdgeParams_Click(object sender, EventArgs e)
        {
            if (enumInspectionType.Akkon == eInspType) return; 
            RadioButton Rbtn;
            Label lab;
            CheckBox chk;
            Button btn;
            int SelectIndex;
            if(sender.GetType() == typeof(RadioButton))
            {
                
                Rbtn = (RadioButton)sender;
                SelectIndex = Convert.ToInt32(Rbtn.Tag.ToString());

            }
            else if (sender.GetType() == typeof(Button))
            {
                btn = (Button)sender;
                SelectIndex = Convert.ToInt32(btn.Tag.ToString());
            }
            else if (sender.GetType() == typeof(CheckBox))
            {
                chk = (CheckBox)sender;
                SelectIndex = Convert.ToInt32(chk.Tag.ToString());
            }
            else 
            {
                lab = (Label)sender;
                SelectIndex = Convert.ToInt32(lab.Tag.ToString());
            }
            switch (SelectIndex)
            {
                case 0://ROI
                    CaliperROI_Show();
                    RBTN_ALIGN_EDGE_APPLY.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nDisplay Caliper on Image. Move Target Position..\r\nSelect 'EDGE POLARITY'";
                    break;
                case 1:
                    using (Form_KeyPad form_keypad = new Form_KeyPad(0, 20, m_nAlignLead, "Input Sample Align Lead Count", 1))
                    {
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK)
                        {
                            m_nAlignLead = (int)form_keypad.m_data;

                        }
                        LB_ALIGN_LEAD_COUNT.Text = m_nAlignLead.ToString();
                        //shkang_s Teaching comment
                        LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nInput 'LEAD COUNT' Number.\r\nClick 'Show ROI' ";
                    }

                    if (RBTN_DARK_TO_BRIGHT.BackColor == Color.DarkGray && RBTN_BRIGHT_TO_DARK.BackColor == Color.DarkGray)
                    {
                        lab_Filter_Size.Visible = false;
                        LB_ALIGN_FILTER_SIZE.Visible = false;
                        lab_EdgeThresHold.Visible = false;
                        LB_ALIGN_EDGE_THRESHOLD.Visible = false;

                    }
                    else
                    {
                        lab_Filter_Size.Visible = true;
                        LB_ALIGN_FILTER_SIZE.Visible = true;
                        lab_EdgeThresHold.Visible = true;
                        LB_ALIGN_EDGE_THRESHOLD.Visible = true;
                    }
                    lab_Edge_Polarty.Visible = true;
                    RBTN_DARK_TO_BRIGHT.Visible = true;
                    RBTN_BRIGHT_TO_DARK.Visible = true;
                    break;
                case 2:
                    RBTN_DARK_TO_BRIGHT.BackColor = Color.Green;
                    RBTN_BRIGHT_TO_DARK.BackColor = Color.DarkGray;
                    Set_EdgePolarity(CogCaliperPolarityConstants.DarkToLight);
                    lab_Filter_Size.Visible = true;
                    LB_ALIGN_FILTER_SIZE.Visible = true;
                    lab_EdgeThresHold.Visible = true;
                    LB_ALIGN_EDGE_THRESHOLD.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nEdge Polarity : DARK->BRIGHT.\r\nClick 'FILTER SIZE'";
                    break;
                case 3:
                    RBTN_DARK_TO_BRIGHT.BackColor = Color.DarkGray;
                    RBTN_BRIGHT_TO_DARK.BackColor = Color.Green;
                    Set_EdgePolarity(CogCaliperPolarityConstants.LightToDark);
                    lab_Filter_Size.Visible = true;
                    LB_ALIGN_FILTER_SIZE.Visible = true;
                    lab_EdgeThresHold.Visible = true;
                    LB_ALIGN_EDGE_THRESHOLD.Visible = true;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nEdge Polarity : BRIGHT->DARK.\r\nClick 'FILTER SIZE'";
                    break;
                case 4:
                    int FilterSize = TempCaliperTool.RunParams.FilterHalfSizeInPixels;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 100, FilterSize, "InputFilterSize", 1))
                    {
                        //shkang_s Teaching comment
                        LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nInput 'FILTER SIZE'\r\nInput 1~100.";
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK)
                        {
                            FilterSize = (int)form_keypad.m_data;
                        }
                    }
                    LB_ALIGN_FILTER_SIZE.Text = FilterSize.ToString();
                    TempCaliperTool.RunParams.FilterHalfSizeInPixels = FilterSize;
                    //shkang_s Teaching comment
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nClick 'EDGE THRESHOLD'";
                    break;
                case 5:
                    double dThresholds = TempCaliperTool.RunParams.FilterHalfSizeInPixels;
                    using (Form_KeyPad form_keypad = new Form_KeyPad(1, 255, dThresholds, "InputFilterSize", 1))
                    {
                        //shkang_s Teaching comment
                        LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nInput 'EDGE THRESHOLD'\r\nInput 1~255.";
                        form_keypad.ShowDialog();
                        if (form_keypad.bOK)
                        {
                            dThresholds = (int)form_keypad.m_data;
                        }
                    }
                    LB_ALIGN_EDGE_THRESHOLD.Text = dThresholds.ToString();
                    TempCaliperTool.RunParams.ContrastThreshold = dThresholds;
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\nAll Parameter Set Complete.\r\nClick 'APPLY";
                    break;
                case 6:// Apply
                    PT_Display01.InteractiveGraphics.Clear();
                    PT_Display01.StaticGraphics.Clear();
                    AlignInsp_Apply();
                    LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\n'APPLY' Complete!\r\nCheck ROI Position and parameter.\r\nClick 'Align Inspection Test";
                    break;
                case 7:
                    if (eEdgePos == enumEdgePos.X)
                    {
                        CaliperX_Test();
                        LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\n\r\nCheck Align X Result.\r\nClick the 'SAVE' button to save data";
                    }
                    else
                    {
                        CaliperY_Test();
                        LB_ShowTodo.Text = "[Align Inspection Teaching UI]\r\n\r\n\r\nCheck Align Y Result.\r\nClick the 'SAVE' button to save data";
                    }
                    break;
            }
        }
        private void CaliperROI_Show()
        {

            PT_Display01.StaticGraphics.Clear();
            PT_Display01.InteractiveGraphics.Clear();
            CogRectangleAffine CaliperRegion = new CogRectangleAffine() ;
             CaliperRegion = new CogRectangleAffine(TempCaliperTool.Region);
       
            if (CaliperRegion.CenterX <= 70)
            {
                CaliperRegion.SetCenterLengthsRotationSkew((PT_Display01.Image.Width / 2 - PT_Display01.PanX), (PT_Display01.Image.Height / 2 - PT_Display01.PanY), 500, 500,0,0);
               // CaliperRegion.SetCenterLengthsRotationSkew(500, 500, CaliperRegion.SideXLength / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000),
               //  CaliperRegion.SideYLength / ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000), 0, 0);
            }
            CaliperRegion.GraphicDOFEnable = CogRectangleAffineDOFConstants.Position | CogRectangleAffineDOFConstants.Size | CogRectangleAffineDOFConstants.Skew | CogRectangleAffineDOFConstants.Rotation;
            CaliperRegion.Interactive = true;
            PT_Display01.InteractiveGraphics.Add(CaliperRegion, "CALIPER", false);
            TempCaliperTool.Region = CaliperRegion;


        }
        private void Set_EdgePolarity(CogCaliperPolarityConstants Polarity)
        {
            TempCaliperTool.RunParams.Edge0Polarity = Polarity;
        }
        private void AlignInsp_Apply()
        {
            if (PT_Display01.Image == null) return;
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            alignTagData[m_nTabNo].LeadCount = m_nAlignLead;
            if(eEdgePos == enumEdgePos.X)
                alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)eAlignInsPos] = TempCaliperTool;
            else
                alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, (int)eAlignInsPos] = TempCaliperTool;
            if (eEdgePos == enumEdgePos.X)
            {
                int nLeadCnt = m_nAlignLead * 2;
                CogRectangleAffine PTCaliperRegion = new CogRectangleAffine(TempCaliperTool.Region);
                

                if (alignTagData[m_nTabNo].LeadCount > 0)
                {
                    PT_Display01.InteractiveGraphics.Add(PTCaliperRegion, "CALIPER", false);
                    CogRectangleAffine[] PTCaliperDividedRegion = new CogRectangleAffine[nLeadCnt];

                    double dNewX = PTCaliperRegion.CenterX - (PTCaliperRegion.SideXLength / 2) + (PTCaliperRegion.SideXLength / (nLeadCnt * 2));
                    double dNewY = PTCaliperRegion.CenterY;

                    for (int i = 0; i < nLeadCnt; i++)
                    {
                        PTCaliperDividedRegion[i] = new CogRectangleAffine(PTCaliperRegion);

                        double dX = PTCaliperRegion.SideXLength / nLeadCnt * i * Math.Cos(PTCaliperRegion.Rotation);
                        double dY = PTCaliperRegion.SideXLength / nLeadCnt * i * Math.Sin(PTCaliperRegion.Rotation);

                        PTCaliperDividedRegion[i].SideXLength = PTCaliperDividedRegion[i].SideXLength / nLeadCnt;
                        PTCaliperDividedRegion[i].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[i].CenterY = dNewY + dY;

                        if (i % 2 == 0) //좌측부분 ROI
                            PTCaliperDividedRegion[i].Rotation = PTCaliperDividedRegion[i].Rotation - 3.14;

                        PTCaliperDividedRegion[i].GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                        PT_Display01.StaticGraphics.Add(PTCaliperDividedRegion[i], "CALIPER");
                    }
                }
            }
            else if(eEdgePos == enumEdgePos.Y)
            {
                PT_Display01.InteractiveGraphics.Add(alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, (int)eAlignInsPos].Region, "CALIPER", false);
            }
        }
        private void CaliperX_Test()
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            int nTotalLeadCount = m_nAlignLead * 2;
            CogRectangleAffine[]  PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            Point2d CaliperPos = new Point2d();
            #region X Caliper Search
           if (m_nLeadCount > 0)
           {
               double dNewX = (TempCaliperTool.Region.CenterX - TempCaliperTool.Region.SideXLength / 2) + TempCaliperTool.Region.SideXLength / (nTotalLeadCount * 2);
               double dNewY = TempCaliperTool.Region.CenterY;

               //ROI Division
               for (int j = 0; j < nTotalLeadCount; j++)
               {
                   //ROI Tracking 추가 필요

                   PTCaliperDividedRegion[j] = new CogRectangleAffine(TempCaliperTool.Region);

                   double dX = TempCaliperTool.Region.SideXLength / nTotalLeadCount * j * Math.Cos(TempCaliperTool.Region.Rotation);
                   double dY = TempCaliperTool.Region.SideXLength / nTotalLeadCount * j * TempCaliperTool.Region.Rotation;

                   PTCaliperDividedRegion[j].SideXLength = PTCaliperDividedRegion[j].SideXLength / nTotalLeadCount;
                   PTCaliperDividedRegion[j].CenterX = dNewX + dX;
                   PTCaliperDividedRegion[j].CenterY = dNewY + dY;

                    if (j % 2 == 0) //좌측부분 ROI
                    {
                        PTCaliperDividedRegion[j].Rotation = PTCaliperDividedRegion[j].Rotation - 3.14;
                        if (CogCaliperPolarityConstants.DarkToLight == TempCaliperTool.RunParams.Edge0Polarity)
                            CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                    }
                    else
                    {
                        if (CogCaliperPolarityConstants.DarkToLight == TempCaliperTool.RunParams.Edge0Polarity)
                            CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                    }

                    //Caliper Search
                    //CaliperTool = PT_AlignPara[TapNo].m_AlignCaliperX[nInspectionPos, i];
                    CaliperTool.InputImage = (CogImage8Grey)PT_Display01.Image;
                   //CaliperTool.InputImage = CopyIMG(Main.vision.CogCamBuf[m_CamNo]);
                   CaliperTool.RunParams.FilterHalfSizeInPixels =TempCaliperTool.RunParams.FilterHalfSizeInPixels;
                   CaliperTool.RunParams.ContrastThreshold = TempCaliperTool.RunParams.ContrastThreshold;
                   
                   CaliperTool.Region = PTCaliperDividedRegion[j];
                   CaliperTool.Run();

                   if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)               //Caliper Search OK
                   {
                       resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                   }
                   else                                                                            //Caliper Search NG
                   {
                       CaliperPos.X = 0;
                       CaliperPos.Y = 0;
                   }
               }
           }
            PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
            #endregion
        }
        private void CaliperY_Test()
        {
            PT_Display01.InteractiveGraphics.Clear();
            PT_Display01.StaticGraphics.Clear();
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            CaliperTool = TempCaliperTool;
            if (CaliperTool == null) return;
            if (PT_Display01.Image == null) return;

            CaliperTool.InputImage = (CogImage8Grey)PT_Display01.Image;
            CaliperTool.Run();

            if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
            {
                resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
            
            }
        }
        private bool Align_Mark_Search(ref double[] dTranslationLX, ref double[] dTranslationLY,ref double[] dTranslationRX, ref double[] dTranslationRY)
        {
            bool Res = true;
            try
            {
                CogPMAlignTool[] TmepLeftMarkTool = new CogPMAlignTool[2];
                CogPMAlignTool[] TmepRightMarkTool = new CogPMAlignTool[2];
                for(int i=0; i<2; i++)
                {
                    if (i == 0)
                    {
                        TmepLeftMarkTool[i] = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.LeftPattern[0];
                        TmepRightMarkTool[i] = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.RightPattern[0];
                    }
                    else
                    {

                        TmepLeftMarkTool[i] = alignTagData[m_nTabNo].LeftPattern[0];
                        TmepRightMarkTool[i] = alignTagData[m_nTabNo].RightPattern[0];
                    }
                    TmepLeftMarkTool[i].InputImage = (CogImage8Grey)PT_Display01.Image;
                    TmepRightMarkTool[i].Run();
                    if(TmepLeftMarkTool[i].Results.Count > 0)
                    {
                        dTranslationLX[i] =  TmepLeftMarkTool[i].Results[0].GetPose().TranslationX;
                        dTranslationLY[i] = TmepLeftMarkTool[i].Results[0].GetPose().TranslationY;
                    }
                    else
                    {
                        return false;
                    }
                    TmepRightMarkTool[i].InputImage = (CogImage8Grey)PT_Display01.Image;
                    TmepRightMarkTool[i].Run();
                    if (TmepRightMarkTool[i].Results.Count > 0)
                    {
                        dTranslationRX[i] = TmepRightMarkTool[i].Results[0].GetPose().TranslationX;
                        dTranslationRY[i] = TmepRightMarkTool[i].Results[0].GetPose().TranslationY;
                    }
                    else
                    {
                        return false;
                    }
                }
                Res = true;
            }
            catch
            {
                Res = false;
                return Res;
            }
            return Res;
        }
        private void ROI_Tracking(double[] dTranslationLX, double[] dTranslationLY, double[] dTranslationRX, double[] dTranslationRY, ref double[] MoveX, ref double[] MoveY )
        {
            double[] dRotT = new double[2];
           
       
            double dPanelOriginLX = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationX;
            double dPanelOriginLY = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.LeftPattern[0].Pattern.Origin.TranslationY;
            double dPanelOriginRX = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationX;
            double dPanelOriginRY = Main.AlignUnit[m_nCamNo].PAT[m_nStageNo, m_nTabNo].AkkonPara.RightPattern[0].Pattern.Origin.TranslationY;
            //추후 Score 기능 추가 예정 - YSH        
            double dPanelX = (dTranslationRX[0] + dTranslationLX[0]) / 2 - (dPanelOriginRX + dPanelOriginLX) / 2;
            double dPanelY = (dTranslationRY[0] + dTranslationLY[0]) / 2 - (dPanelOriginRY + dPanelOriginLY) / 2;
            MoveX[0] = dPanelX;
            MoveY[0] = dPanelY;
          
            double dFPCOriginLX = alignTagData[m_nTabNo].LeftPattern[0].Pattern.Origin.TranslationX;
            double dFPCOriginLY = alignTagData[m_nTabNo].LeftPattern[0].Pattern.Origin.TranslationY;
            double dFPCOriginRX = alignTagData[m_nTabNo].RightPattern[0].Pattern.Origin.TranslationX;
            double dFPCOriginRY = alignTagData[m_nTabNo].RightPattern[0].Pattern.Origin.TranslationY;
            //추후 Score 기능 추가 예정 - YSH        
            double dFPCX = (dTranslationRX[1] + dTranslationLX[1]) / 2 - (dPanelOriginRX + dPanelOriginLX) / 2;
            double dFPCY = (dTranslationRY[1] + dTranslationLY[1]) / 2 - (dPanelOriginRY + dPanelOriginLY) / 2;

            MoveX[1] = dFPCX;
            MoveY[1] = dFPCY;


        }
        private void AlignInsption()
        {

            LABEL_MESSAGE(LB_MESSAGE1, "", Color.Green);
          
            AlignResult.AlignResultClear();
            string strResult ="";
            #region X Align Insepection
            CogRectangleAffine[] PTCaliperDividedRegion;
            int nTotalLeadCount = alignTagData[m_nTabNo].LeadCount * 2;
            PTCaliperDividedRegion = new CogRectangleAffine[nTotalLeadCount];
            CogCaliperTool CaliperTool = new CogCaliperTool();
            CogGraphicInteractiveCollection resultGraphics = new CogGraphicInteractiveCollection();
            Point2d CaliperPos = new Point2d();
            #region X Caliper Search
            //i = FPC = 0,
            //i = PANEL = 1,
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; i++)
            {
                if (alignTagData[m_nTabNo].LeadCount > 0)
                {
                    double dNewX = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.CenterX - (alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.SideXLength / 2) + (alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.SideXLength / (nTotalLeadCount * 2));
                    double dNewY = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.CenterY;

                    //ROI Division
                    for (int j = 0; j < nTotalLeadCount; j++)
                    {
                        //ROI Tracking 추가 필요

                        PTCaliperDividedRegion[j] = new CogRectangleAffine(alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region);

                        double dX = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.SideXLength / nTotalLeadCount * j * Math.Cos(alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.Rotation);
                        double dY = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.SideXLength / nTotalLeadCount * j * Math.Sin(alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].Region.Rotation);

                        PTCaliperDividedRegion[j].SideXLength = PTCaliperDividedRegion[j].SideXLength / nTotalLeadCount;
                        PTCaliperDividedRegion[j].CenterX = dNewX + dX;
                        PTCaliperDividedRegion[j].CenterY = dNewY + dY;

                        if (j % 2 == 0) //좌측부분 ROI
                        {
                            PTCaliperDividedRegion[j].Rotation = PTCaliperDividedRegion[j].Rotation - 3.14;
                            if (CogCaliperPolarityConstants.DarkToLight == alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].RunParams.Edge0Polarity)
                                CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                        }
                        else
                        {
                            if (CogCaliperPolarityConstants.DarkToLight == alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].RunParams.Edge0Polarity)
                                CaliperTool.RunParams.Edge0Polarity = CogCaliperPolarityConstants.LightToDark;
                        }
                        //Caliper Search
                        //CaliperTool = PT_AlignPara[TapNo].m_AlignCaliperX[nInspectionPos, i];
                        CaliperTool.InputImage = (CogImage8Grey)PT_Display01.Image;
                        CaliperTool.RunParams.FilterHalfSizeInPixels = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].RunParams.FilterHalfSizeInPixels;
                        CaliperTool.RunParams.ContrastThreshold = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].RunParams.ContrastThreshold;

                       // CaliperTool.RunParams.Edge0Polarity = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, i].RunParams.Edge0Polarity;
                        CaliperTool.Region = PTCaliperDividedRegion[j];
                        CaliperTool.Run();

                         if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)               //Caliper Search OK
                        {
                            resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                            CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                            CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;

                            if (j % 2 == 0)
                                AlignResult.LeftEdgePointList[(int)enumROIType, i].Add(CaliperPos);        //Left Edge
                            else
                                AlignResult.RightEdgePointList[(int)enumROIType, i].Add(CaliperPos);       //Right Edge
                        }
                        else                                                                            //Caliper Search NG
                        {
                            CaliperPos.X = 0;
                            CaliperPos.Y = 0;

                            if (j % 2 == 0)
                                AlignResult.LeftEdgePointList[(int)enumROIType, i].Add(CaliperPos);        //Left Edge
                            else
                                AlignResult.RightEdgePointList[(int)enumROIType, i].Add(CaliperPos);       //Right Edge
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
                for (int j = 0; j < alignTagData[m_nTabNo].LeadCount; j++)
                {
                    if (AlignResult.LeftEdgePointList[(int)enumROIType, i][j] == CaliperPos ||
                        AlignResult.RightEdgePointList[(int)enumROIType, i][j] == CaliperPos)
                    {
                        if (i == 0)
                        {
                            AlignResult.LeftEdgePointList[(int)enumROIType, i + 1][j] = CaliperPos;
                            AlignResult.RightEdgePointList[(int)enumROIType, i + 1][j] = CaliperPos;
                        }
                        else
                        {
                            AlignResult.LeftEdgePointList[(int)enumROIType, i - 1][j] = CaliperPos;
                            AlignResult.RightEdgePointList[(int)enumROIType, i - 1][j] = CaliperPos;
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
            cogFPCLineTool.InputImage = (CogImage8Grey)PT_Display01.Image;
            cogPanelLineTool.InputImage = (CogImage8Grey)PT_Display01.Image; 
            cogCenterLineTool.InputImage = (CogImage8Grey)PT_Display01.Image;
            cogIntersectPoint_FPC.InputImage = (CogImage8Grey)PT_Display01.Image;
            cogIntersectPoint_Panel.InputImage = (CogImage8Grey)PT_Display01.Image;
            cogDistancePoint.InputImage = (CogImage8Grey)PT_Display01.Image;

            cogFPCLineTool.OutputColor = CogColorConstants.Purple;
            cogPanelLineTool.OutputColor = CogColorConstants.Orange;

            cogCenterLineTool.Line.X = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)enumAlignInspPos.FPC].Region.CornerOriginX;
            cogCenterLineTool.Line.Y = (alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)enumAlignInspPos.FPC].Region.CornerYY
                + alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)enumAlignInspPos.Panel].Region.CornerOriginY) / 2;
            cogCenterLineTool.Line.Rotation = 0;
            cogCenterLineTool.Run();

            PT_Display01.StaticGraphics.Add(cogCenterLineTool.Line as ICogGraphic, "CenterLine");

            //Caliper 개수만큼 반복
            for (int i = 0; i < AlignResult.LeftEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC].Count; i++)
            {
                //object, [FPC]  -> Panel 각도로 통일 
                if (AlignResult.LeftEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC][i].X > 0 && AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC][i].X > 0)
                {
                    cogFPCLineTool.Line.X = (AlignResult.LeftEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC][i].X + AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC][i].X) / 2;
                    cogFPCLineTool.Line.Y = AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.FPC][i].Y;
                    cogFPCLineTool.Line.Rotation = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)enumAlignInspPos.Panel].Region.Skew + 1.57;
                    cogFPCLineTool.Run();
                    PT_Display01.StaticGraphics.Add(cogFPCLineTool.Line as ICogGraphic, "FPCLine");
                    cogIntersectPoint_FPC.LineA = cogCenterLineTool.GetOutputLine();
                    cogIntersectPoint_FPC.LineB = cogFPCLineTool.GetOutputLine();
                    cogIntersectPoint_FPC.Run();
                }

                //object, [Panel] -> Panel 각도로 통일
                if (AlignResult.LeftEdgePointList[(int)enumROIType, (int)enumAlignInspPos.Panel][i].X > 0 && AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.Panel][i].X > 0)
                {
                    cogPanelLineTool.Line.X = (AlignResult.LeftEdgePointList[(int)enumROIType, (int)enumAlignInspPos.Panel][i].X + AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.Panel][i].X) / 2;
                    cogPanelLineTool.Line.Y = AlignResult.RightEdgePointList[(int)enumROIType, (int)enumAlignInspPos.Panel][i].Y;
                    cogPanelLineTool.Line.Rotation = alignTagData[m_nTabNo].AlignCaliperX[(int)enumROIType, (int)enumAlignInspPos.Panel].Region.Skew + 1.57;
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
                strResult += "X :Fail";
               // LB_ALIGNRESULT.Items.Add(strResult);
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
            strResult += "X : " + AlignResult.AlignGapXRealList[0].ToString("0.00") + "um";
          
            #endregion

            #endregion

            #region Y Align Inspection

            #region Y Caliper Search
            //i = FPC = 0,
            //i = PANEL = 1,
            for (int i = 0; i < (int)Main.AlignTagData.eDefaultParam.DEF_TARGET_POS; i++)
            {
                CaliperTool.InputImage = (CogImage8Grey)PT_Display01.Image;
                CaliperTool.RunParams.FilterHalfSizeInPixels = alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, i].RunParams.FilterHalfSizeInPixels;
                CaliperTool.RunParams.ContrastThreshold = alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, i].RunParams.ContrastThreshold;
                CaliperTool.RunParams.Edge0Polarity = alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, i].RunParams.Edge0Polarity;
                CaliperTool.Region = alignTagData[m_nTabNo].AlignCaliperY[(int)enumROIType, i].Region;
                CaliperTool.Run();

                if (CaliperTool.Results != null && CaliperTool.Results.Count > 0)
                {
                    resultGraphics.Add(CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.Edges));
                    PT_Display01.InteractiveGraphics.AddList(resultGraphics, "RESULT", false);
                    CaliperPos.X = CaliperTool.Results[0].Edge0.PositionX;
                    CaliperPos.Y = CaliperTool.Results[0].Edge0.PositionY;
                    AlignResult.YEdgePointList[(int)enumROIType].Add(CaliperPos);
                }
                else
                {
                    //Caliper Search NG
                    AlignResult.AlignGapYRealList.Add(0);
                    strResult += "Y: Fail";
                    break;
                }
            }
            #region Y Align Calculate
            double dYAlignDistance;
            dYAlignDistance = Math.Abs(AlignResult.YEdgePointList[(int)enumROIType][0].Y - AlignResult.YEdgePointList[(int)enumROIType][1].Y);
            dYAlignDistance = dYAlignDistance * ((Main.DEFINE.LINE_SCAN_PIXEL_SIZE / Main.DEFINE.CAM_LENS_SCALE) * 1000);
            AlignResult.AlignGapYRealList.Add(dYAlignDistance);
            strResult += " Y : " + AlignResult.AlignGapYRealList[0].ToString("0.00") + "um";
            #endregion
            LABEL_MESSAGE(LB_MESSAGE1, strResult, Color.Green);
            #endregion



            #endregion

        }

        private void BTN_MARKDELETE_Click(object sender, EventArgs e)
        {
            TempMarkTool[m_nSubMarkIndex].Pattern.Untrain();
            SubMarkDisplay[m_nSubMarkIndex].Image = null;
        }
    }
}