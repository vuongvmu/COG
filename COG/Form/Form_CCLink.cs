#define BP_INSPECTION_PC1_MODE
//#define BP_INSPECTION_PC2_MODE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace COG
{
    public partial class Form_CCLink : Form
    {
        public Form_CCLink()
        {
            InitializeComponent();
            Allocate_Array();
            //FillCaption();
        }

        private Form_Melsec FormMelsec = new Form_Melsec();
        
        private List<CheckBox> lstLblStatBX = new List<CheckBox>();
        private List<CheckBox> lstLblStatBY = new List<CheckBox>();
        private List<Label> lstLblStatWR = new List<Label>();
        private List<Label> lstLblStatWW = new List<Label>();
        private List<Label> lstLblStatDR = new List<Label>();
        private List<Label> lstLblStatDW = new List<Label>();
        private List<Label> lstLblCaptBX = new List<Label>();
        private List<Label> lstLblCaptBY = new List<Label>();
        private List<Label> lstLblCaptWR = new List<Label>();
        private List<Label> lstLblCaptWW = new List<Label>();

#if BP_INSPECTION_PC1_MODE
        private string[] strCaptionBX = new string[(Main.DEFINE.CCLINK_BX_MAX_NUM + Main.DEFINE.CCLINK_BYI_MAX_NUM) * 16];
        private string[] strCaptionBY = new string[Main.DEFINE.CCLINK_BYO_MAX_NUM * 16];
        private string[] strCaptionWR = new string[Main.DEFINE.CCLINK_WR_MAX_NUM * 16];
        private string[] strCaptionWW = new string[Main.DEFINE.CCLINK_WW_MAX_NUM * 16];
#elif BP_INSPECTION_PC2_MODE
        private string[] strCaptionBX = new string[(Main.DEFINE.CCLINK2_BX_MAX_NUM + Main.DEFINE.CCLINK2_BYI_MAX_NUM) * 16];
        private string[] strCaptionBY = new string[Main.DEFINE.CCLINK2_BYO_MAX_NUM * 16];
        private string[] strCaptionWR = new string[Main.DEFINE.CCLINK2_WR_MAX_NUM * 16];
        private string[] strCaptionWW = new string[Main.DEFINE.CCLINK2_WW_MAX_NUM * 16];
#endif

        private int m_iCurPageBX = 0;
        private int m_iCurPageBY = 0;
        private int m_iCurPageWR = 0;
        private int m_iCurPageWW = 0;

        public void Form_CCLink_Load(object sender, EventArgs e)
        {
            Read_Interface_Data();
            ViewCaptBit();
            ViewCaptWord();
        }

        public void Form_CCLink_Load()
        {
            timer1.Enabled = true;
        }

        private void BTN_TEACH_Click(object sender, EventArgs e)
        {
            Label TempBTN = (Label)sender;
            int m_Number;
            m_Number = TempBTN.TabIndex;

            int nAddress;
            int nValue;

            Form_KeyPad form_keypad = new Form_KeyPad();
            form_keypad.ShowDialog();

            nValue = Convert.ToInt16(form_keypad.m_data);
            nAddress = PLCDataTag.BASE_RW_ADDR + m_Number;

            Main.WriteDevice(nAddress, nValue);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MemDisplay();
            Application.DoEvents();
        }
        public void BTN_EXIT_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Hide();
        }
        private void Allocate_Array()
        {
            string strName = "";
            CheckBox tempCB;
            Label tempLabel;

            for (int i = 0; i < 16; i++)
            {
                strName = "LB_IN_BIT_STAT" + (i + 1).ToString("00");
                tempCB = (CheckBox)this.Controls[strName];
                lstLblStatBX.Add(tempCB);

                strName = "LB_OUT_BIT_STAT" + (i + 1).ToString("00");
                tempCB = (CheckBox)this.Controls[strName];
                lstLblStatBY.Add(tempCB);

                strName = "LB_IN_WORD_STAT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblStatWR.Add(tempLabel);

                strName = "LB_OUT_WORD_STAT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblStatWW.Add(tempLabel);

                strName = "LB_IN_BIT_CAPT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblCaptBX.Add(tempLabel);

                strName = "LB_OUT_BIT_CAPT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblCaptBY.Add(tempLabel);

                strName = "LB_IN_WORD_CAPT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblCaptWR.Add(tempLabel);

                strName = "LB_OUT_WORD_CAPT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblCaptWW.Add(tempLabel);
            }

            for (int i = 0; i < 8; i++)
            {
                strName = "LB_IN_DWORD_STAT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblStatDR.Add(tempLabel);

                strName = "LB_OUT_DWORD_STAT" + (i + 1).ToString();
                tempLabel = (Label)this.Controls[strName];
                lstLblStatDW.Add(tempLabel);
            }
        }

        private void ViewStatBit()
        {
            if (Main.DEFINE.OPEN_F == true) return;

            bool bStat = false;
            int iAddrBX = 0;
            int iAddrBYI = 0;

            int iBXMax = Main.DEFINE.CCLINK_BX_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iBXMax = Main.DEFINE.CCLINK2_BX_MAX_NUM;
            
            if (m_iCurPageBX < iBXMax)
            {
                iAddrBX = 1000 + m_iCurPageBX * 16;

                // PLC Input
                for (int i = 0; i < 16; i++)
                {
                    bStat = Main.CCLink_IsBit((ushort)(iAddrBX + i));
                    {
                        if (lstLblStatBX[i].Checked != bStat)
                        {
                            lstLblStatBX[i].Checked = bStat;
                        }
                    }
                }
            }
            else
            {
                iAddrBYI = 2000 + (m_iCurPageBX - iBXMax) * 16;
                
                // PC Input
                for (int i = 0; i < 16; i++)
                {
                    bStat = Main.CCLink_IsBit((ushort)(iAddrBYI + i));
                    {
                        if (lstLblStatBX[i].Checked != bStat)
                        {
                            lstLblStatBX[i].Checked = bStat;
                        }
                    }
                }
            }

            int iAddrBYO = 3000 + m_iCurPageBY * 16;

            // Output
            for (int i = 0; i < 16; i++)
            {
                bStat = Main.CCLink_IsBit((ushort)(iAddrBYO + i));
                {
                    if (lstLblStatBY[i].Checked != bStat)
                    {
                        lstLblStatBY[i].Checked = bStat;
                    }
                }
            }
        }

        private void ViewStatWord()
        {
            if (Main.DEFINE.OPEN_F == true) return;

            short siData = 0;
            long lData = 0;
            string strData = "";

            // Input (Word)
            for (int i = 0; i < 16; i++)
            {
                siData = Main.CCLink_ReadWord((ushort)(4000 + i));
                {
                    strData = siData.ToString();
                    if (lstLblStatWR[i].Text != strData)
                    {
                        lstLblStatWR[i].Text = strData;
                    }
                }
            }

            // Input (DWord)
            for (int i = 0; i < 8; i++)
            {
                lData = Main.CCLink_ReadDWord((ushort)(4000 + i * 2));
                {
                    strData = lData.ToString();
                    if (lstLblStatDR[i].Text != strData)
                    {
                        lstLblStatDR[i].Text = strData;
                    }
                }
            }

            // Output (Word)
            for (int i = 0; i < 16; i++)
            {
                siData = Main.CCLink_ReadWord((ushort)(5000 + i));
                {
                    strData = siData.ToString();
                    if (lstLblStatWW[i].Text != strData)
                    {
                        lstLblStatWW[i].Text = strData;
                    }
                }
            }

            // Output (DWord)
            for (int i = 0; i < 8; i++)
            {
                lData = Main.CCLink_ReadDWord((ushort)(5000 + i * 2));
                {
                    strData = lData.ToString();
                    if (lstLblStatDW[i].Text != strData)
                    {
                        lstLblStatDW[i].Text = strData;
                    }
                }
            }
        }

        private void ViewCaptBit()
        {
            int iAddrBX = m_iCurPageBX * 16;
            int iAddrBY = m_iCurPageBY * 16;

            for (int i = 0; i < 16; i++)
            {
                lstLblCaptBX[i].Text = strCaptionBX[iAddrBX + i];
            }
            for (int i = 0; i < 16; i++)
            {
                lstLblCaptBY[i].Text = strCaptionBY[iAddrBY + i];
            }
        }

        private void ViewCaptWord()
        {
            int iAddrBX = m_iCurPageWR * 16;
            int iAddrBY = m_iCurPageWW * 16;

            for (int i = 0; i < 16; i++)
            {
                lstLblCaptWR[i].Text = strCaptionWR[iAddrBX + i];
            }
            for (int i = 0; i < 16; i++)
            {
                lstLblCaptWW[i].Text = strCaptionWW[iAddrBY + i];
            }
        }

        private void MemDisplay()
        {
            ViewStatBit();
            ViewStatWord();
        }

        private void SendDataBit(int iIdx)
        {
            ushort iReady = Main.DEFINE.CCLINK_IN_AUTO_READY;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iReady = Main.DEFINE.CCLINK2_IN_AUTO_READY;

            if (Main.CCLink_IsBit(iReady))
            {
                return;
            }

            int iAddrBY = 3000 + m_iCurPageBY * 16;
            bool bStat = false;

            bStat = Main.CCLink_IsBit((ushort)(iAddrBY + iIdx));
            {
                Main.CCLink_PutBit((ushort)(iAddrBY + iIdx), !bStat);
            }
        }

        private void BTN_PREV_BIT_IN_Click(object sender, EventArgs e)
        {
            int iBXMax = Main.DEFINE.CCLINK_BX_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iBXMax = Main.DEFINE.CCLINK2_BX_MAX_NUM;

            m_iCurPageBX--;
            if (m_iCurPageBX < 0) m_iCurPageBX = 0;

            if (m_iCurPageBX > iBXMax - 1)
                LABEL_INPUT_BIT.Text = "INPUT BIT (PC)";
            else
                LABEL_INPUT_BIT.Text = "INPUT BIT (PLC)";

            ViewCaptBit();
        }

        private void BTN_NEXT_BIT_IN_Click(object sender, EventArgs e)
        {
            int iBXMax = Main.DEFINE.CCLINK_BX_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iBXMax = Main.DEFINE.CCLINK2_BX_MAX_NUM;

            int iBYMax = Main.DEFINE.CCLINK_BYI_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iBYMax = Main.DEFINE.CCLINK2_BYI_MAX_NUM;

            m_iCurPageBX++;
            if (m_iCurPageBX > (iBXMax + iBYMax) - 1) m_iCurPageBX = (iBXMax + iBYMax) - 1;

            if (m_iCurPageBX > iBXMax - 1)
                LABEL_INPUT_BIT.Text = "INPUT BIT (PC)";
            else
                LABEL_INPUT_BIT.Text = "INPUT BIT (PLC)";

            ViewCaptBit();
        }

        private void BTN_PREV_BIT_OUT_Click(object sender, EventArgs e)
        {
            m_iCurPageBY--;
            if (m_iCurPageBY < 0) m_iCurPageBY = 0;

            ViewCaptBit();
        }

        private void BTN_NEXT_BIT_OUT_Click(object sender, EventArgs e)
        {
            int iBYMax = Main.DEFINE.CCLINK_BYO_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iBYMax = Main.DEFINE.CCLINK2_BYO_MAX_NUM;

            m_iCurPageBY++;
            if (m_iCurPageBY > iBYMax - 1) m_iCurPageBY = iBYMax - 1;

            ViewCaptBit();
        }

        private void BTN_PREV_WORD_IN_Click(object sender, EventArgs e)
        {
            m_iCurPageWR--;
            if (m_iCurPageWR < 0) m_iCurPageWR = 0;

            ViewCaptWord();
        }

        private void BTN_NEXT_WORD_IN_Click(object sender, EventArgs e)
        {
            int iWRMax = Main.DEFINE.CCLINK_WR_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iWRMax = Main.DEFINE.CCLINK2_WR_MAX_NUM;

            m_iCurPageWR++;
            if (m_iCurPageWR > iWRMax - 1) m_iCurPageWR = iWRMax - 1;

            ViewCaptWord();
        }

        private void BTN_PREV_WORD_OUT_Click(object sender, EventArgs e)
        {
            m_iCurPageWW--;
            if (m_iCurPageWW < 0) m_iCurPageWW = 0;

            ViewCaptWord();
        }

        private void BTN_NEXT_WORD_OUT_Click(object sender, EventArgs e)
        {
            int iWWMax = Main.DEFINE.CCLINK_WW_MAX_NUM;
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
                iWWMax = Main.DEFINE.CCLINK2_WW_MAX_NUM;

            m_iCurPageWW++;
            if (m_iCurPageWW > iWWMax - 1) m_iCurPageWW = iWWMax - 1;

            ViewCaptWord();
        }

        private void LB_OUT_BIT_STAT_Click(object sender, EventArgs e)
        {
            CheckBox TempBTN = (CheckBox)sender;
            int iIdx = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2)) - 1;

            if (iIdx < 0 || iIdx > 15) return;

            SendDataBit(iIdx);
        }

#region CAPTION
        private void FillCaption()
        {
#region 5588
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" && Main.DEFINE.UNIT_TYPE == "5588")
            {
                //[X9E0]
                strCaptionBX[0] = "[X9E0] IN_ALIVE";
                strCaptionBX[1] = "[X9E1] IN_AUTO_READY";
                strCaptionBX[2] = "[X9E2] IN_AUTO_RUN";
                strCaptionBX[3] = "[X9E3] IN_ERROR";
                strCaptionBX[4] = "[X9E4] IN_WARNING";
                strCaptionBX[5] = "[X9E5] IN_PM_MODE";
                strCaptionBX[6] = "[X9E6] IN_1CYCLE_MODE";
                strCaptionBX[7] = "[X9E7] IN_EMERGENCY_STOP";
                strCaptionBX[8] = "[X9E8] IN_DOOR_LOCK";
                strCaptionBX[9] = "[X9E9] IN_1009";
                strCaptionBX[10] = "[X9EA] IN_1010";
                strCaptionBX[11] = "[X9EB] IN_ERROR_RESET";
                strCaptionBX[12] = "[X9EC] IN_1012";
                strCaptionBX[13] = "[X9ED] IN_1013";
                strCaptionBX[14] = "[X9EE] IN_1014";
                strCaptionBX[15] = "[X9EF] IN_1015";

                //[X9F0]
                strCaptionBX[16] = "[X9F0] IN_LOC_PPID_COPY_REQ";
                strCaptionBX[17] = "[X9F1] IN_LOC_PPID_DELETE_REQ";
                strCaptionBX[18] = "[X9F2] IN_LOC_PPID_BODY_CHANGE_REQ";
                strCaptionBX[19] = "[X9F3] IN_LOC_PPID_MODEL_CHANGE_REQ";
                strCaptionBX[20] = "[X9F4] IN_LOC_ECM_CHANGE_REQ";
                strCaptionBX[21] = "[X9F5] IN_1021";
                strCaptionBX[22] = "[X9F6] IN_1022";
                strCaptionBX[23] = "[X9F7] IN_1023";
                strCaptionBX[24] = "[X9F8] IN_RMT_PPID_CREATE_REQ";
                strCaptionBX[25] = "[X9F9] IN_RMT_PPID_DELETE_REQ";
                strCaptionBX[26] = "[X9FA] IN_RMT_PPID_BODY_CHANGE_REQ";
                strCaptionBX[27] = "[X9FB] IN_RMT_PPID_BODY_SEARCH_REQ";
                strCaptionBX[28] = "[X9FC] IN_1028";
                strCaptionBX[29] = "[X9FD] IN_TIME_CHANGE_REQ";
                strCaptionBX[30] = "[X9FE] IN_STAGE1_INIT_REQ";
                strCaptionBX[31] = "[X9FF] IN_STAGE2_INIT_REQ";

                //[Y900]
                strCaptionBX[32] = "[Y900] IN_PC_ALIVE";
                strCaptionBX[33] = "[Y901] IN_PC_AUTO_READY";
                strCaptionBX[34] = "[Y902] IN_PC_AUTO_RUN";
                strCaptionBX[35] = "[Y903] IN_PC_ERROR";
                strCaptionBX[36] = "[Y904] IN_PC_WARNING";
                strCaptionBX[37] = "[Y905] IN_PC_PM_MODE";
                strCaptionBX[38] = "[Y906] IN_PC_1CYCLE_MODE";
                strCaptionBX[39] = "[Y907] IN_2007";
                strCaptionBX[40] = "[Y908] IN_PC_MOTOR_BUSY";
                strCaptionBX[41] = "[Y909] IN_PC_LASER_BUSY";
                strCaptionBX[42] = "[Y90A] IN_2010";
                strCaptionBX[43] = "[Y90B] IN_2011";
                strCaptionBX[44] = "[Y90C] IN_2012";
                strCaptionBX[45] = "[Y90D] IN_2013";
                strCaptionBX[46] = "[Y90E] IN_PC_ERROR_RESET";
                strCaptionBX[47] = "[Y90F] IN_PC_BUZZER_OFF";

                //[Y910]             
                strCaptionBX[48] = "[Y910] IN_PC_LOC_PPID_COPY_COMP";
                strCaptionBX[49] = "[Y911] IN_PC_LOC_PPID_DELETE_COMP";
                strCaptionBX[50] = "[Y912] IN_PC_LOC_PPID_BODY_CHANGE_COMP";
                strCaptionBX[51] = "[Y913] IN_PC_LOC_PPID_MODEL_CHANGE_COMP";
                strCaptionBX[52] = "[Y914] IN_PC_LOC_ECM_CHANGE_COMP";
                strCaptionBX[53] = "[Y915] IN_2021";
                strCaptionBX[54] = "[Y916] IN_2022";
                strCaptionBX[55] = "[Y917] IN_2023";
                strCaptionBX[56] = "[Y918] IN_PC_RMT_PPID_CREATE_COMP";
                strCaptionBX[57] = "[Y919] IN_PC_RMT_PPID_DELETE_COMP";
                strCaptionBX[58] = "[Y91A] IN_PC_RMT_PPID_BODY_CHANGE_COMP";
                strCaptionBX[59] = "[Y91B] IN_PC_RMT_PPID_BODY_SEARCH_COMP";
                strCaptionBX[60] = "[Y91C] IN_2028";
                strCaptionBX[61] = "[Y91D] IN_PC_TIME_CHANGE_COMP";
                strCaptionBX[62] = "[Y91E] IN_PC_STAGE1_INIT_COMP";
                strCaptionBX[63] = "[Y91F] IN_PC_STAGE2_INIT_COMP";

                //[Y920]
                strCaptionBX[64] = "[Y920] IN_STAGE1_CMD_READY";
                strCaptionBX[65] = "[Y921] IN_STAGE1_CMD_BUSY";
                strCaptionBX[66] = "[Y922] IN_STAGE1_PWR_CHK_BUSY";
                strCaptionBX[67] = "[Y923] IN_2035";
                strCaptionBX[68] = "[Y924] IN_2036";
                strCaptionBX[69] = "[Y925] IN_2037";
                strCaptionBX[70] = "[Y926] IN_2038";
                strCaptionBX[71] = "[Y927] IN_2039";
                strCaptionBX[72] = "[Y928] IN_STAGE1_LOAD_POS";
                strCaptionBX[73] = "[Y929] IN_STAGE1_CUT_COMP";
                strCaptionBX[74] = "[Y92A] IN_STAGE1_INSP_COMP";
                strCaptionBX[75] = "[Y92B] IN_STAGE1_REMOVE_POS";
                strCaptionBX[76] = "[Y92C] IN_STAGE1_UNLOAD_POS";
                strCaptionBX[77] = "[Y92D] IN_STAGE1_CLEAN_POS";
                strCaptionBX[78] = "[Y92E] IN_STAGE1_REJECT_POS";
                strCaptionBX[79] = "[Y92F] IN_2047";

                //[Y930]
                strCaptionBX[80] = "[Y930] IN_STAGE1_LOAD_POS_MOVE_COMP";
                strCaptionBX[81] = "[Y931] IN_STAGE1_CUT_RUN_COMP";
                strCaptionBX[82] = "[Y932] IN_STAGE1_INSP_RUN_COMP";
                strCaptionBX[83] = "[Y933] IN_STAGE1_REMOVE_POS_MOVE_COMP";
                strCaptionBX[84] = "[Y934] IN_STAGE1_UNLOAD_POS_MOVE_COMP";
                strCaptionBX[85] = "[Y935] IN_STAGE1_CLEAN_POS_MOVE_COMP";
                strCaptionBX[86] = "[Y936] IN_STAGE1_REJECT_POS_MOVE_COMP";
                strCaptionBX[87] = "[Y937] IN_2055";
                strCaptionBX[88] = "[Y938] IN_2056";
                strCaptionBX[89] = "[Y939] IN_2057";
                strCaptionBX[90] = "[Y93A] IN_2058";
                strCaptionBX[91] = "[Y93B] IN_2059";
                strCaptionBX[92] = "[Y93C] IN_2060";
                strCaptionBX[93] = "[Y93D] IN_2061";
                strCaptionBX[94] = "[Y93E] IN_2062";
                strCaptionBX[95] = "[Y93F] IN_2063";

                //[Y940]
                strCaptionBX[96] = "[Y940] IN_STAGE2_CMD_READY";
                strCaptionBX[97] = "[Y941] IN_STAGE2_CMD_BUSY";
                strCaptionBX[98] = "[Y942] IN_STAGE2_PWR_CHK_BUSY";
                strCaptionBX[99] = "[Y943] IN_2067";
                strCaptionBX[100] = "[Y944] IN_2068";
                strCaptionBX[101] = "[Y945] IN_2069";
                strCaptionBX[102] = "[Y946] IN_2070";
                strCaptionBX[103] = "[Y947] IN_2071";
                strCaptionBX[104] = "[Y948] IN_STAGE2_LOAD_POS";
                strCaptionBX[105] = "[Y949] IN_STAGE2_CUT_COMP";
                strCaptionBX[106] = "[Y94A] IN_STAGE2_INSP_COMP";
                strCaptionBX[107] = "[Y94B] IN_STAGE2_REMOVE_POS";
                strCaptionBX[108] = "[Y94C] IN_STAGE2_UNLOAD_POS";
                strCaptionBX[109] = "[Y94D] IN_STAGE2_CLEAN_POS";
                strCaptionBX[110] = "[Y94E] IN_STAGE2_REJECT_POS";
                strCaptionBX[111] = "[Y94F] IN_2079";

                //[Y950]              
                strCaptionBX[112] = "[Y950] IN_STAGE2_LOAD_POS_MOVE_COMP";
                strCaptionBX[113] = "[Y951] IN_STAGE2_CUT_RUN_COMP";
                strCaptionBX[114] = "[Y952] IN_STAGE2_INSP_RUN_COMP";
                strCaptionBX[115] = "[Y953] IN_STAGE2_REMOVE_POS_MOVE_COMP";
                strCaptionBX[116] = "[Y954] IN_STAGE2_UNLOAD_POS_MOVE_COMP";
                strCaptionBX[117] = "[Y955] IN_STAGE2_CLEAN_POS_MOVE_COMP";
                strCaptionBX[118] = "[Y956] IN_STAGE2_REJECT_POS_MOVE_COMP";
                strCaptionBX[119] = "[Y957] IN_2087";
                strCaptionBX[120] = "[Y958] IN_2088";
                strCaptionBX[121] = "[Y959] IN_2089";
                strCaptionBX[122] = "[Y95A] IN_2090";
                strCaptionBX[123] = "[Y95B] IN_2091";
                strCaptionBX[124] = "[Y95C] IN_2092";
                strCaptionBX[125] = "[Y95D] IN_2093";
                strCaptionBX[126] = "[Y95E] IN_2094";
                strCaptionBX[127] = "[Y95F] IN_2095";

                //[Y960]              
                strCaptionBX[128] = "[Y960] IN_2096";
                strCaptionBX[129] = "[Y961] IN_2097";
                strCaptionBX[130] = "[Y962] IN_2098";
                strCaptionBX[131] = "[Y963] IN_2099";
                strCaptionBX[132] = "[Y964] IN_2100";
                strCaptionBX[133] = "[Y965] IN_2101";
                strCaptionBX[134] = "[Y966] IN_2102";
                strCaptionBX[135] = "[Y967] IN_2103";
                strCaptionBX[136] = "[Y968] IN_2104";
                strCaptionBX[137] = "[Y969] IN_2105";
                strCaptionBX[138] = "[Y96A] IN_2106";
                strCaptionBX[139] = "[Y96B] IN_2107";
                strCaptionBX[140] = "[Y96C] IN_SCALE_BAR_AIR_BLW_X";
                strCaptionBX[141] = "[Y96D] IN_SCALE_BAR_AIR_BLW_Y1_Y2";
                strCaptionBX[142] = "[Y96E] IN_SCALE_BAR_AIR_BLW_Y3";
                strCaptionBX[143] = "[Y96F] IN_SCALE_BAR_AIR_BLW_Y4";

                //[Y970]              
                strCaptionBX[144] = "[Y970] IN_2112";
                strCaptionBX[145] = "[Y971] IN_2113";
                strCaptionBX[146] = "[Y972] IN_2114";
                strCaptionBX[147] = "[Y973] IN_2115";
                strCaptionBX[148] = "[Y974] IN_PWR_CHK_FWD_SOURCE";
                strCaptionBX[149] = "[Y975] IN_PWR_CHK_FWD_SCANNER";
                strCaptionBX[150] = "[Y976] IN_PWR_CHK_FAN_PWR_SOURCE";
                strCaptionBX[151] = "[Y977] IN_PWR_CHK_FAN_PWR_SCANNER";
                strCaptionBX[152] = "[Y978] IN_LASER_OPTIC_OPEN";
                strCaptionBX[153] = "[Y979] IN_LASER_INTERLOCK_ON";
                strCaptionBX[154] = "[Y97A] IN_2122";
                strCaptionBX[155] = "[Y97B] IN_2123";
                strCaptionBX[156] = "[Y97C] IN_2124";
                strCaptionBX[157] = "[Y97D] IN_2125";
                strCaptionBX[158] = "[Y97E] IN_2126";
                strCaptionBX[159] = "[Y97F] IN_2127";

                //[Y980]              
                strCaptionBX[160] = "[Y980] IN_CAM1_SCALE_HEAD_AIR_BLW";
                strCaptionBX[161] = "[Y981] IN_CAM2_SCALE_HEAD_AIR_BLW";
                strCaptionBX[162] = "[Y982] IN_CAM3_SCALE_HEAD_AIR_BLW";
                strCaptionBX[163] = "[Y983] IN_CAM4_SCALE_HEAD_AIR_BLW";
                strCaptionBX[164] = "[Y984] IN_2132";
                strCaptionBX[165] = "[Y985] IN_2133";
                strCaptionBX[166] = "[Y986] IN_2134";
                strCaptionBX[167] = "[Y987] IN_2135";
                strCaptionBX[168] = "[Y988] IN_SCANNER_SUCTION_CUP_BLW";
                strCaptionBX[169] = "[Y989] IN_LASER_GAS_GENR_BLW";
                strCaptionBX[170] = "[Y98A] IN_CAM1_LENS_BLW";
                strCaptionBX[171] = "[Y98B] IN_CAM2_LENS_BLW";
                strCaptionBX[172] = "[Y98C] IN_CAM3_LENS_BLW";
                strCaptionBX[173] = "[Y98D] IN_2141";
                strCaptionBX[174] = "[Y98E] IN_2142";
                strCaptionBX[175] = "[Y98F] IN_SCANNER_Z_BRAKE";

                //[Y990]              
                strCaptionBX[176] = "[Y990] IN_WORK_TABLE_LEFT_LIGHT_FWD";
                strCaptionBX[177] = "[Y991] IN_WORK_TABLE_RIGHT_LIGHT_FWD";
                strCaptionBX[178] = "[Y992] IN_WORK_TABLE_SCALE_AIR_BLW";
                strCaptionBX[179] = "[Y993] IN_WORK_TABLE_POINT_AIR_BLW";
                strCaptionBX[180] = "[Y994] IN_2148";
                strCaptionBX[181] = "[Y995] IN_2149";
                strCaptionBX[182] = "[Y996] IN_2150";
                strCaptionBX[183] = "[Y997] IN_2151";
                strCaptionBX[184] = "[Y998] IN_2152";
                strCaptionBX[185] = "[Y999] IN_2153";
                strCaptionBX[186] = "[Y99A] IN_2154";
                strCaptionBX[187] = "[Y99B] IN_2155";
                strCaptionBX[188] = "[Y99C] IN_2156";
                strCaptionBX[189] = "[Y99D] IN_2157";
                strCaptionBX[190] = "[Y99E] IN_2158";
                strCaptionBX[191] = "[Y99F] IN_2159";

                //[Y9A0]              
                strCaptionBX[192] = "[Y9A0] IN_STAGE1_FINE_ALIGN_MODE";
                strCaptionBX[193] = "[Y9A1] IN_STAGE1_INSPECTION_MODE";
                strCaptionBX[194] = "[Y9A2] IN_STAGE1_R_CUT_MODE";
                strCaptionBX[195] = "[Y9A3] IN_STAGE1_C_CUT_MODE";
                strCaptionBX[196] = "[Y9A4] IN_STAGE1_SHAPE_CUT_MODE";
                strCaptionBX[197] = "[Y9A5] IN_STAGE1_ROUND_CAM_SELECT";
                strCaptionBX[198] = "[Y9A6] IN_STAGE1_PAD_CAM_SELECT";
                strCaptionBX[199] = "[Y9A7] IN_STAGE1_BEAM_SZ_CHK_REQ";
                strCaptionBX[200] = "[Y9A8] IN_STAGE1_CAM_LIVE_REQ";
                strCaptionBX[201] = "[Y9A9] IN_STAGE1_CAM_FREEZE_REQ";
                strCaptionBX[202] = "[Y9AA] IN_STAGE1_CAM_GRAB_REQ";
                strCaptionBX[203] = "[Y9AB] IN_STAGE1_CAM_FORCE_GRAB_REQ";
                strCaptionBX[204] = "[Y9AC] IN_STAGE1_CAM_CALIB_REQ";
                strCaptionBX[205] = "[Y9AD] IN_2173";
                strCaptionBX[206] = "[Y9AE] IN_STAGE1_CAM_RCS_REQ";
                strCaptionBX[207] = "[Y9AF] IN_STAGE1_MOVE_COMP";

                //[Y9B0]              
                strCaptionBX[208] = "[Y9B0] IN_STAGE1_CAM1_SEARCH_REQ_X";
                strCaptionBX[209] = "[Y9B1] IN_2177";
                strCaptionBX[210] = "[Y9B2] IN_2178";
                strCaptionBX[211] = "[Y9B3] IN_STAGE1_CAM1_SEARCH_REQ_Y";
                strCaptionBX[212] = "[Y9B4] IN_2180";
                strCaptionBX[213] = "[Y9B5] IN_2181";
                strCaptionBX[214] = "[Y9B6] IN_2182";
                strCaptionBX[215] = "[Y9B7] IN_2183";
                strCaptionBX[216] = "[Y9B8] IN_STAGE1_CAM2_SEARCH_REQ_X";
                strCaptionBX[217] = "[Y9B9] IN_2185";
                strCaptionBX[218] = "[Y9BA] IN_2186";
                strCaptionBX[219] = "[Y9BB] IN_STAGE1_CAM2_SEARCH_REQ_Y";
                strCaptionBX[220] = "[Y9BC] IN_2188";
                strCaptionBX[221] = "[Y9BD] IN_2189";
                strCaptionBX[222] = "[Y9BE] IN_2190";
                strCaptionBX[223] = "[Y9BF] IN_2191";

                //[Y9C0]              
                strCaptionBX[224] = "[Y9C0] IN_STAGE2_FINE_ALIGN_MODE";
                strCaptionBX[225] = "[Y9C1] IN_STAGE2_INSPECTION_MODE";
                strCaptionBX[226] = "[Y9C2] IN_STAGE2_R_CUT_MODE";
                strCaptionBX[227] = "[Y9C3] IN_STAGE2_C_CUT_MODE";
                strCaptionBX[228] = "[Y9C4] IN_STAGE2_SHAPE_CUT_MODE";
                strCaptionBX[229] = "[Y9C5] IN_STAGE2_ROUND_CAM_SELECT";
                strCaptionBX[230] = "[Y9C6] IN_STAGE2_PAD_CAM_SELECT";
                strCaptionBX[231] = "[Y9C7] IN_STAGE2_BEAM_SZ_CHK_REQ";
                strCaptionBX[232] = "[Y9C8] IN_STAGE2_CAM_LIVE_REQ";
                strCaptionBX[233] = "[Y9C9] IN_STAGE2_CAM_FREEZE_REQ";
                strCaptionBX[234] = "[Y9CA] IN_STAGE2_CAM_GRAB_REQ";
                strCaptionBX[235] = "[Y9CB] IN_STAGE2_CAM_FORCE_GRAB_REQ";
                strCaptionBX[236] = "[Y9CC] IN_STAGE2_CAM_CALIB_REQ";
                strCaptionBX[237] = "[Y9CD] IN_2205";
                strCaptionBX[238] = "[Y9CE] IN_STAGE2_CAM_RCS_REQ";
                strCaptionBX[239] = "[Y9CF] IN_STAGE2_MOVE_COMP";

                //[Y9D0]              
                strCaptionBX[240] = "[Y9D0] IN_STAGE2_CAM1_SEARCH_REQ_X";
                strCaptionBX[241] = "[Y9D1] IN_2209";
                strCaptionBX[242] = "[Y9D2] IN_2210";
                strCaptionBX[243] = "[Y9D3] IN_STAGE2_CAM1_SEARCH_REQ_Y";
                strCaptionBX[244] = "[Y9D4] IN_2212";
                strCaptionBX[245] = "[Y9D5] IN_2213";
                strCaptionBX[246] = "[Y9D6] IN_2214";
                strCaptionBX[247] = "[Y9D7] IN_2215";
                strCaptionBX[248] = "[Y9D8] IN_STAGE2_CAM2_SEARCH_REQ_X";
                strCaptionBX[249] = "[Y9D9] IN_2217";
                strCaptionBX[250] = "[Y9DA] IN_2218";
                strCaptionBX[251] = "[Y9DB] IN_STAGE2_CAM2_SEARCH_REQ_Y";
                strCaptionBX[252] = "[Y9DC] IN_2220";
                strCaptionBX[253] = "[Y9DD] IN_2221";
                strCaptionBX[254] = "[Y9DE] IN_2222";
                strCaptionBX[255] = "[Y9DF] IN_2223";

                //[Y9E0]
                strCaptionBY[0] = "[Y9E0] OUT_ALIVE";
                strCaptionBY[1] = "[Y9E1] OUT_AUTO_READY";
                strCaptionBY[2] = "[Y9E2] OUT_AUTO_RUN";
                strCaptionBY[3] = "[Y9E3] OUT_ERROR";
                strCaptionBY[4] = "[Y9E4] OUT_WARNING";
                strCaptionBY[5] = "[Y9E5] OUT_PM_MODE";
                strCaptionBY[6] = "[Y9E6] OUT_1CYCLE_MODE";
                strCaptionBY[7] = "[Y9E7] OUT_3007";
                strCaptionBY[8] = "[Y9E8] OUT_VISION_BUSY";
                strCaptionBY[9] = "[Y9E9] OUT_3009";
                strCaptionBY[10] = "[Y9EA] OUT_3020";
                strCaptionBY[11] = "[Y9EB] OUT_3011";
                strCaptionBY[12] = "[Y9EC] OUT_3012";
                strCaptionBY[13] = "[Y9ED] OUT_3013";
                strCaptionBY[14] = "[Y9EE] OUT_3014";
                strCaptionBY[15] = "[Y9EF] OUT_BUZZER_OFF";

                //[Y9F0]             
                strCaptionBY[16] = "[Y9F0] OUT_LOC_PPID_COPY_COMP";
                strCaptionBY[17] = "[Y9F1] OUT_LOC_PPID_DELETE_COMP";
                strCaptionBY[18] = "[Y9F2] OUT_LOC_PPID_BODY_CHANGE_COMP";
                strCaptionBY[19] = "[Y9F3] OUT_LOC_PPID_MODEL_CHANGE_COMP";
                strCaptionBY[20] = "[Y9F4] OUT_LOC_ECM_CHANGE_COMP";
                strCaptionBY[21] = "[Y9F5] OUT_3021";
                strCaptionBY[22] = "[Y9F6] OUT_3022";
                strCaptionBY[23] = "[Y9F7] OUT_3023";
                strCaptionBY[24] = "[Y9F8] OUT_RMT_PPID_CREATE_COMP";
                strCaptionBY[25] = "[Y9F9] OUT_RMT_PPID_DELETE_COMP";
                strCaptionBY[26] = "[Y9FA] OUT_RMT_PPID_BODY_CHANGE_COMP";
                strCaptionBY[27] = "[Y9FB] OUT_RMT_PPID_BODY_SEARCH_COMP";
                strCaptionBY[28] = "[Y9FC] OUT_3028";
                strCaptionBY[29] = "[Y9FD] OUT_TIME_CHANGE_COMP";
                strCaptionBY[30] = "[Y9FE] OUT_STAGE1_INIT_COMP";
                strCaptionBY[31] = "[Y9FF] OUT_STAGE2_INIT_COMP";

                //[YA00]            
                strCaptionBY[32] = "[YA00] OUT_STAGE1_CAM_FORCE_GRAB_COMP";
                strCaptionBY[33] = "[YA01] OUT_STAGE1_CAM_FORCE_GRAB_CANCEL";
                strCaptionBY[34] = "[YA02] OUT_STAGE1_CAM_RCS_COMP";
                strCaptionBY[35] = "[YA03] OUT_STAGE1_CAM_RCS_CANCEL";
                strCaptionBY[36] = "[YA04] OUT_3036";
                strCaptionBY[37] = "[YA05] OUT_3037";
                strCaptionBY[38] = "[YA06] OUT_3038";
                strCaptionBY[39] = "[YA07] OUT_STAGE1_BEAM_SZ_CHK_COMP";
                strCaptionBY[40] = "[YA08] OUT_STAGE1_CAM_LIVE_COMP";
                strCaptionBY[41] = "[YA09] OUT_STAGE1_CAM_FREEZE_COMP";
                strCaptionBY[42] = "[YA0A] OUT_STAGE1_CAM_GRAB_COMP";
                strCaptionBY[43] = "[YA0B] OUT_3043";
                strCaptionBY[44] = "[YA0C] OUT_STAGE1_CAM_CALIB_COMP";
                strCaptionBY[45] = "[YA0D] OUT_STAGE1_CAM_CALIB_FAIL";
                strCaptionBY[46] = "[YA0E] OUT_3045";
                strCaptionBY[47] = "[YA0F] OUT_STAGE1_MOVE_REQ";

                //[YA10]            
                strCaptionBY[48] = "[YA10] OUT_STAGE1_CAM1_SEARCH_COMP_X";
                strCaptionBY[49] = "[YA11] OUT_STAGE1_CAM1_RESULT_OK_X";
                strCaptionBY[50] = "[YA12] OUT_STAGE1_CAM1_SEARCH_COMP_Y";
                strCaptionBY[51] = "[YA13] OUT_STAGE1_CAM1_RESULT_OK_Y";
                strCaptionBY[52] = "[YA14] OUT_STAGE1_CAM1_RESULT_OK_C_R";
                strCaptionBY[53] = "[YA15] OUT_STAGE1_CAM1_PANEL_LIMIT";
                strCaptionBY[54] = "[YA16] OUT_STAGE1_CAM1_INSP_CAM_NG";
                strCaptionBY[55] = "[YA17] OUT_3055";
                strCaptionBY[56] = "[YA18] OUT_STAGE1_CAM2_SEARCH_COMP_X";
                strCaptionBY[57] = "[YA19] OUT_STAGE1_CAM2_RESULT_OK_X";
                strCaptionBY[58] = "[YA1A] OUT_STAGE1_CAM2_SEARCH_COMP_Y";
                strCaptionBY[59] = "[YA1B] OUT_STAGE1_CAM2_RESULT_OK_Y";
                strCaptionBY[60] = "[YA1C] OUT_STAGE1_CAM2_RESULT_OK_C_R";
                strCaptionBY[61] = "[YA1D] OUT_STAGE1_CAM2_PANEL_LIMIT";
                strCaptionBY[62] = "[YA1E] OUT_STAGE1_CAM2_INSP_CAM_NG";
                strCaptionBY[63] = "[YA1F] OUT_3063";

                //[YA20]             
                strCaptionBY[64] = "[YA20] OUT_STAGE2_CAM_FORCE_GRAB_COMP";
                strCaptionBY[65] = "[YA21] OUT_STAGE2_CAM_FORCE_GRAB_CANCEL";
                strCaptionBY[66] = "[YA22] OUT_STAGE2_CAM_RCS_COMP";
                strCaptionBY[67] = "[YA23] OUT_STAGE2_CAM_RCS_CANCEL";
                strCaptionBY[68] = "[YA24] OUT_3068";
                strCaptionBY[69] = "[YA25] OUT_3069";
                strCaptionBY[70] = "[YA26] OUT_3070";
                strCaptionBY[71] = "[YA27] OUT_STAGE2_BEAM_SZ_CHK_COMP";
                strCaptionBY[72] = "[YA28] OUT_STAGE2_CAM_LIVE_COMP";
                strCaptionBY[73] = "[YA29] OUT_STAGE2_CAM_FREEZE_COMP";
                strCaptionBY[74] = "[YA2A] OUT_STAGE2_CAM_GRAB_COMP";
                strCaptionBY[75] = "[YA2B] OUT_3075";
                strCaptionBY[76] = "[YA2C] OUT_STAGE2_CAM_CALIB_COMP";
                strCaptionBY[77] = "[YA2D] OUT_STAGE2_CAM_CALIB_FAIL";
                strCaptionBY[78] = "[YA2E] OUT_3078";
                strCaptionBY[79] = "[YA2F] OUT_STAGE2_MOVE_REQ";

                //[YA30]             
                strCaptionBY[80] = "[YA30] OUT_STAGE2_CAM1_SEARCH_COMP_X";
                strCaptionBY[81] = "[YA31] OUT_STAGE2_CAM1_RESULT_OK_X";
                strCaptionBY[82] = "[YA32] OUT_STAGE2_CAM1_SEARCH_COMP_Y";
                strCaptionBY[83] = "[YA33] OUT_STAGE2_CAM1_RESULT_OK_Y";
                strCaptionBY[84] = "[YA34] OUT_STAGE2_CAM1_RESULT_OK_C_R";
                strCaptionBY[85] = "[YA35] OUT_STAGE2_CAM1_PANEL_LIMIT";
                strCaptionBY[86] = "[YA36] OUT_STAGE2_CAM1_INSP_CAM_NG";
                strCaptionBY[87] = "[YA37] OUT_3087";
                strCaptionBY[88] = "[YA38] OUT_STAGE2_CAM2_SEARCH_COMP_X";
                strCaptionBY[89] = "[YA39] OUT_STAGE2_CAM2_RESULT_OK_X";
                strCaptionBY[90] = "[YA3A] OUT_STAGE2_CAM2_SEARCH_COMP_Y";
                strCaptionBY[91] = "[YA3B] OUT_STAGE2_CAM2_RESULT_OK_Y";
                strCaptionBY[92] = "[YA3C] OUT_STAGE2_CAM2_RESULT_OK_C_R";
                strCaptionBY[93] = "[YA3D] OUT_STAGE2_CAM2_PANEL_LIMIT";
                strCaptionBY[94] = "[YA3E] OUT_STAGE2_CAM2_INSP_CAM_NG";
                strCaptionBY[95] = "[YA3F] OUT_3095";

                //[D1024]
                strCaptionWR[0] = "[WW18] WW_PANEL1_CELL_ID H";
                strCaptionWR[1] = "[WW19] WW_PANEL1_CELL_ID L";
                strCaptionWR[2] = "[WW1A] WW_PANEL1_CELL_ID_1 H";
                strCaptionWR[3] = "[WW1B] WW_PANEL1_CELL_ID_1 L";
                strCaptionWR[4] = "[WW1C] WW_PANEL1_CELL_ID_2 H";
                strCaptionWR[5] = "[WW1D] WW_PANEL1_CELL_ID_2 L";
                strCaptionWR[6] = "[WW1E] WW_PANEL1_CELL_ID_3 H";
                strCaptionWR[7] = "[WW1F] WW_PANEL1_CELL_ID_3 L";
                strCaptionWR[8] = "[WW20] WW_PANEL1_CELL_ID_4 H";
                strCaptionWR[9] = "[WW21] WW_PANEL1_CELL_ID_4 L";
                strCaptionWR[10] = "[WW22] WW_PANEL2_CELL_ID H";
                strCaptionWR[11] = "[WW23] WW_PANEL2_CELL_ID L";
                strCaptionWR[12] = "[WW24] WW_PANEL2_CELL_ID_1 H";
                strCaptionWR[13] = "[WW25] WW_PANEL2_CELL_ID_1 L";
                strCaptionWR[14] = "[WW26] WW_PANEL2_CELL_ID_2 H";
                strCaptionWR[15] = "[WW27] WW_PANEL2_CELL_ID_2 L";

                strCaptionWR[16] = "[WW28] WW_PANEL2_CELL_ID_3 H";
                strCaptionWR[17] = "[WW29] WW_PANEL2_CELL_ID_3 L";
                strCaptionWR[18] = "[WW2A] WW_PANEL2_CELL_ID_4 H";
                strCaptionWR[19] = "[WW2B] WW_PANEL2_CELL_ID_4 L";
                strCaptionWR[20] = "[WW2C] WW_CAM_CALIB_SELECT H";
                strCaptionWR[21] = "[WW2D] WW_CAM_CALIB_SELECT L";
                strCaptionWR[22] = "[WW2E] WW_CAM_CALIB_NO H";
                strCaptionWR[23] = "[WW2F] WW_CAM_CALIB_NO L";
                strCaptionWR[24] = "[WW30] WW_STAGE_X_CUR_POS H";
                strCaptionWR[25] = "[WW31] WW_STAGE_X_CUR_POS L";
                strCaptionWR[26] = "[WW32] WW_STAGE_Y_CUR_POS H";
                strCaptionWR[27] = "[WW33] WW_STAGE_Y_CUR_POS L";
                strCaptionWR[28] = "[WW34] WW_PANEL_CORNER_OFFSET H";
                strCaptionWR[29] = "[WW35] WW_PANEL_CORNER_OFFSET L";
                strCaptionWR[30] = "[WW36] WW_4030";
                strCaptionWR[31] = "[WW37] WW_4031";

                //[D1056]
                strCaptionWW[0] = "[WW38] WW_CAM1_SEARCH1_X H";
                strCaptionWW[1] = "[WW39] WW_CAM1_SEARCH1_X L";
                strCaptionWW[2] = "[WW3A] WW_CAM1_SEARCH1_Y H";
                strCaptionWW[3] = "[WW3B] WW_CAM1_SEARCH1_Y L";
                strCaptionWW[4] = "[WW3C] WW_CAM1_SEARCH1_R_T H";
                strCaptionWW[5] = "[WW3D] WW_CAM1_SEARCH1_R_T L";
                strCaptionWW[6] = "[WW3E] WW_CAM1_SEARCH1_SCORE H";
                strCaptionWW[7] = "[WW3F] WW_CAM1_SEARCH1_SCORE L";
                strCaptionWW[8] = "[WW40] WW_CAM1_SEARCH2_X H";
                strCaptionWW[9] = "[WW41] WW_CAM1_SEARCH2_X L";
                strCaptionWW[10] = "[WW42] WW_CAM1_SEARCH2_Y H";
                strCaptionWW[11] = "[WW43] WW_CAM1_SEARCH2_Y L";
                strCaptionWW[12] = "[WW44] WW_CAM1_SEARCH2_R_T H";
                strCaptionWW[13] = "[WW45] WW_CAM1_SEARCH2_R_T L";
                strCaptionWW[14] = "[WW46] WW_CAM1_SEARCH2_SCORE H";
                strCaptionWW[15] = "[WW47] WW_CAM1_SEARCH2_SCORE L";

                strCaptionWW[16] = "[WW48] WW_CAM1_SEARCH3_X H";
                strCaptionWW[17] = "[WW49] WW_CAM1_SEARCH3_X L";
                strCaptionWW[18] = "[WW4A] WW_CAM1_SEARCH3_Y H";
                strCaptionWW[19] = "[WW4B] WW_CAM1_SEARCH3_Y L";
                strCaptionWW[20] = "[WW4C] WW_CAM1_SEARCH3_R_T H";
                strCaptionWW[21] = "[WW4D] WW_CAM1_SEARCH3_R_T L";
                strCaptionWW[22] = "[WW4E] WW_CAM1_SEARCH3_SCORE H";
                strCaptionWW[23] = "[WW4F] WW_CAM1_SEARCH3_SCORE L";
                strCaptionWW[24] = "[WW50] WW_CAM2_SEARCH1_X H";
                strCaptionWW[25] = "[WW51] WW_CAM2_SEARCH1_X L";
                strCaptionWW[26] = "[WW52] WW_CAM2_SEARCH1_Y H";
                strCaptionWW[27] = "[WW53] WW_CAM2_SEARCH1_Y L";
                strCaptionWW[28] = "[WW54] WW_CAM2_SEARCH1_R_T H";
                strCaptionWW[29] = "[WW55] WW_CAM2_SEARCH1_R_T L";
                strCaptionWW[30] = "[WW56] WW_CAM2_SEARCH1_SCORE H";
                strCaptionWW[31] = "[WW57] WW_CAM2_SEARCH1_SCORE L";

                //[D1088]
                strCaptionWW[32] = "[WW58] WW_CAM2_SEARCH2_X H";
                strCaptionWW[33] = "[WW59] WW_CAM2_SEARCH2_X L";
                strCaptionWW[34] = "[WW5A] WW_CAM2_SEARCH2_Y H";
                strCaptionWW[35] = "[WW5B] WW_CAM2_SEARCH2_Y L";
                strCaptionWW[36] = "[WW5C] WW_CAM2_SEARCH2_R_T H";
                strCaptionWW[37] = "[WW5D] WW_CAM2_SEARCH2_R_T L";
                strCaptionWW[38] = "[WW5E] WW_CAM2_SEARCH2_SCORE H";
                strCaptionWW[39] = "[WW5F] WW_CAM2_SEARCH2_SCORE L";
                strCaptionWW[40] = "[WW60] WW_CAM2_SEARCH3_X H";
                strCaptionWW[41] = "[WW61] WW_CAM2_SEARCH3_X L";
                strCaptionWW[42] = "[WW62] WW_CAM2_SEARCH3_Y H";
                strCaptionWW[43] = "[WW63] WW_CAM2_SEARCH3_Y L";
                strCaptionWW[44] = "[WW64] WW_CAM2_SEARCH3_R_T H";
                strCaptionWW[45] = "[WW65] WW_CAM2_SEARCH3_R_T L";
                strCaptionWW[46] = "[WW66] WW_CAM2_SEARCH3_SCORE H";
                strCaptionWW[47] = "[WW67] WW_CAM2_SEARCH3_SCORE L";

                strCaptionWW[48] = "[WW68] WW_5068";
                strCaptionWW[49] = "[WW69] WW_5069";
                strCaptionWW[50] = "[WW6A] WW_CAM_CALIB_STG_MOVE_DIST_X H";
                strCaptionWW[51] = "[WW6B] WW_CAM_CALIB_STG_MOVE_DIST_X L";
                strCaptionWW[52] = "[WW6C] WW_CAM_CALIB_STG_MOVE_DIST_Y H";
                strCaptionWW[53] = "[WW6D] WW_CAM_CALIB_STG_MOVE_DIST_Y L";
                strCaptionWW[54] = "[WW6E] WW_CAM_CALIB_STG_MOVE_ANGLE_T H";
                strCaptionWW[55] = "[WW6F] WW_CAM_CALIB_STG_MOVE_ANGLE_T L";
                strCaptionWW[56] = "[WW70] WW_5070";
                strCaptionWW[57] = "[WW71] WW_5071";
                strCaptionWW[58] = "[WW72] WW_5072";
                strCaptionWW[59] = "[WW73] WW_5073";
                strCaptionWW[60] = "[WW74] WW_5074";
                strCaptionWW[61] = "[WW75] WW_5075";
                strCaptionWW[62] = "[WW76] WW_5076";
                strCaptionWW[63] = "[WW77] WW_5077";
            }
#endregion

#region 2755
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" && Main.DEFINE.UNIT_TYPE == "2755")
            {
                //[XA00]
                strCaptionBX[0] = "[XA00] IN_ALIVE";
                strCaptionBX[1] = "[XA01] IN_AUTO_READY";
                strCaptionBX[2] = "[XA02] IN_AUTO_RUN";
                strCaptionBX[3] = "[XA03] IN_ERROR";
                strCaptionBX[4] = "[XA04] IN_WARNING";
                strCaptionBX[5] = "[XA05] IN_PM_MODE";
                strCaptionBX[6] = "[XA06] IN_1CYCLE_MODE";
                strCaptionBX[7] = "[XA07] IN_EMERGENCY_STOP";
                strCaptionBX[8] = "[XA08] IN_DOOR_LOCK";
                strCaptionBX[9] = "[XA09] IN_1009";
                strCaptionBX[10] = "[XA0A] IN_1010";
                strCaptionBX[11] = "[XA0B] IN_ERROR_RESET";
                strCaptionBX[12] = "[XA0C] IN_1012";
                strCaptionBX[13] = "[XA0D] IN_1013";
                strCaptionBX[14] = "[XA0E] IN_1014";
                strCaptionBX[15] = "[XA0F] IN_1015";

                //[XA10]
                strCaptionBX[16] = "[XA10] IN_LOC_PPID_COPY_REQ";
                strCaptionBX[17] = "[XA11] IN_LOC_PPID_DELETE_REQ";
                strCaptionBX[18] = "[XA12] IN_LOC_PPID_BODY_CHANGE_REQ";
                strCaptionBX[19] = "[XA13] IN_LOC_PPID_MODEL_CHANGE_REQ";
                strCaptionBX[20] = "[XA14] IN_LOC_ECM_CHANGE_REQ";
                strCaptionBX[21] = "[XA15] IN_1021";
                strCaptionBX[22] = "[XA16] IN_1022";
                strCaptionBX[23] = "[XA17] IN_1023";
                strCaptionBX[24] = "[XA18] IN_RMT_PPID_CREATE_REQ";
                strCaptionBX[25] = "[XA19] IN_RMT_PPID_DELETE_REQ";
                strCaptionBX[26] = "[XA1A] IN_RMT_PPID_BODY_CHANGE_REQ";
                strCaptionBX[27] = "[XA1B] IN_RMT_PPID_BODY_SEARCH_REQ";
                strCaptionBX[28] = "[XA1C] IN_1028";
                strCaptionBX[29] = "[XA1D] IN_TIME_CHANGE_REQ";
                strCaptionBX[30] = "[XA1E] IN_STAGE1_INIT_REQ";
                strCaptionBX[31] = "[XA1F] IN_STAGE2_INIT_REQ";

                //[Y920]
                strCaptionBX[32] = "[Y920] IN_PC_ALIVE";
                strCaptionBX[33] = "[Y921] IN_PC_AUTO_READY";
                strCaptionBX[34] = "[Y922] IN_PC_AUTO_RUN";
                strCaptionBX[35] = "[Y923] IN_PC_ERROR";
                strCaptionBX[36] = "[Y924] IN_PC_WARNING";
                strCaptionBX[37] = "[Y925] IN_PC_PM_MODE";
                strCaptionBX[38] = "[Y926] IN_PC_1CYCLE_MODE";
                strCaptionBX[39] = "[Y927] IN_2007";
                strCaptionBX[40] = "[Y928] IN_PC_MOTOR_BUSY";
                strCaptionBX[41] = "[Y929] IN_PC_LASER_BUSY";
                strCaptionBX[42] = "[Y92A] IN_2010";
                strCaptionBX[43] = "[Y92B] IN_2011";
                strCaptionBX[44] = "[Y92C] IN_2012";
                strCaptionBX[45] = "[Y92D] IN_2013";
                strCaptionBX[46] = "[Y92E] IN_PC_ERROR_RESET";
                strCaptionBX[47] = "[Y92F] IN_PC_BUZZER_OFF";

                //[Y930]             
                strCaptionBX[48] = "[Y930] IN_PC_LOC_PPID_COPY_COMP";
                strCaptionBX[49] = "[Y931] IN_PC_LOC_PPID_DELETE_COMP";
                strCaptionBX[50] = "[Y932] IN_PC_LOC_PPID_BODY_CHANGE_COMP";
                strCaptionBX[51] = "[Y933] IN_PC_LOC_PPID_MODEL_CHANGE_COMP";
                strCaptionBX[52] = "[Y934] IN_PC_LOC_ECM_CHANGE_COMP";
                strCaptionBX[53] = "[Y935] IN_2021";
                strCaptionBX[54] = "[Y936] IN_2022";
                strCaptionBX[55] = "[Y937] IN_2023";
                strCaptionBX[56] = "[Y938] IN_PC_RMT_PPID_CREATE_COMP";
                strCaptionBX[57] = "[Y939] IN_PC_RMT_PPID_DELETE_COMP";
                strCaptionBX[58] = "[Y93A] IN_PC_RMT_PPID_BODY_CHANGE_COMP";
                strCaptionBX[59] = "[Y93B] IN_PC_RMT_PPID_BODY_SEARCH_COMP";
                strCaptionBX[60] = "[Y93C] IN_2028";
                strCaptionBX[61] = "[Y93D] IN_PC_TIME_CHANGE_COMP";
                strCaptionBX[62] = "[Y93E] IN_PC_STAGE1_INIT_COMP";
                strCaptionBX[63] = "[Y93F] IN_PC_STAGE2_INIT_COMP";

                //[Y940]
                strCaptionBX[64] = "[Y940] IN_STAGE1_CMD_READY";
                strCaptionBX[65] = "[Y941] IN_STAGE1_CMD_BUSY";
                strCaptionBX[66] = "[Y942] IN_STAGE1_PWR_CHK_BUSY";
                strCaptionBX[67] = "[Y943] IN_2035";
                strCaptionBX[68] = "[Y944] IN_2036";
                strCaptionBX[69] = "[Y945] IN_2037";
                strCaptionBX[70] = "[Y946] IN_2038";
                strCaptionBX[71] = "[Y947] IN_2039";
                strCaptionBX[72] = "[Y948] IN_STAGE1_LOAD_POS";
                strCaptionBX[73] = "[Y949] IN_STAGE1_CUT_COMP";
                strCaptionBX[74] = "[Y94A] IN_STAGE1_INSP_COMP";
                strCaptionBX[75] = "[Y94B] IN_STAGE1_REMOVE_POS";
                strCaptionBX[76] = "[Y94C] IN_STAGE1_UNLOAD_POS";
                strCaptionBX[77] = "[Y94D] IN_STAGE1_CLEAN_POS";
                strCaptionBX[78] = "[Y94E] IN_STAGE1_REJECT_POS";
                strCaptionBX[79] = "[Y94F] IN_2047";

                //[Y950]
                strCaptionBX[80] = "[Y950] IN_STAGE1_LOAD_POS_MOVE_COMP";
                strCaptionBX[81] = "[Y951] IN_STAGE1_CUT_RUN_COMP";
                strCaptionBX[82] = "[Y952] IN_STAGE1_INSP_RUN_COMP";
                strCaptionBX[83] = "[Y953] IN_STAGE1_REMOVE_POS_MOVE_COMP";
                strCaptionBX[84] = "[Y954] IN_STAGE1_UNLOAD_POS_MOVE_COMP";
                strCaptionBX[85] = "[Y955] IN_STAGE1_CLEAN_POS_MOVE_COMP";
                strCaptionBX[86] = "[Y956] IN_STAGE1_REJECT_POS_MOVE_COMP";
                strCaptionBX[87] = "[Y957] IN_2055";
                strCaptionBX[88] = "[Y958] IN_2056";
                strCaptionBX[89] = "[Y959] IN_2057";
                strCaptionBX[90] = "[Y95A] IN_2058";
                strCaptionBX[91] = "[Y95B] IN_2059";
                strCaptionBX[92] = "[Y95C] IN_2060";
                strCaptionBX[93] = "[Y95D] IN_2061";
                strCaptionBX[94] = "[Y95E] IN_2062";
                strCaptionBX[95] = "[Y95F] IN_2063";

                //[Y960]
                strCaptionBX[96] = "[Y960] IN_STAGE2_CMD_READY";
                strCaptionBX[97] = "[Y961] IN_STAGE2_CMD_BUSY";
                strCaptionBX[98] = "[Y962] IN_STAGE2_PWR_CHK_BUSY";
                strCaptionBX[99] = "[Y963] IN_2067";
                strCaptionBX[100] = "[Y964] IN_2068";
                strCaptionBX[101] = "[Y965] IN_2069";
                strCaptionBX[102] = "[Y966] IN_2070";
                strCaptionBX[103] = "[Y967] IN_2071";
                strCaptionBX[104] = "[Y968] IN_STAGE2_LOAD_POS";
                strCaptionBX[105] = "[Y969] IN_STAGE2_CUT_COMP";
                strCaptionBX[106] = "[Y96A] IN_STAGE2_INSP_COMP";
                strCaptionBX[107] = "[Y96B] IN_STAGE2_REMOVE_POS";
                strCaptionBX[108] = "[Y96C] IN_STAGE2_UNLOAD_POS";
                strCaptionBX[109] = "[Y96D] IN_STAGE2_CLEAN_POS";
                strCaptionBX[110] = "[Y96E] IN_STAGE2_REJECT_POS";
                strCaptionBX[111] = "[Y96F] IN_2079";

                //[Y970]              
                strCaptionBX[112] = "[Y970] IN_STAGE2_LOAD_POS_MOVE_COMP";
                strCaptionBX[113] = "[Y971] IN_STAGE2_CUT_RUN_COMP";
                strCaptionBX[114] = "[Y972] IN_STAGE2_INSP_RUN_COMP";
                strCaptionBX[115] = "[Y973] IN_STAGE2_REMOVE_POS_MOVE_COMP";
                strCaptionBX[116] = "[Y974] IN_STAGE2_UNLOAD_POS_MOVE_COMP";
                strCaptionBX[117] = "[Y975] IN_STAGE2_CLEAN_POS_MOVE_COMP";
                strCaptionBX[118] = "[Y976] IN_STAGE2_REJECT_POS_MOVE_COMP";
                strCaptionBX[119] = "[Y977] IN_2087";
                strCaptionBX[120] = "[Y978] IN_2088";
                strCaptionBX[121] = "[Y979] IN_2089";
                strCaptionBX[122] = "[Y97A] IN_2090";
                strCaptionBX[123] = "[Y97B] IN_2091";
                strCaptionBX[124] = "[Y97C] IN_2092";
                strCaptionBX[125] = "[Y97D] IN_2093";
                strCaptionBX[126] = "[Y97E] IN_2094";
                strCaptionBX[127] = "[Y97F] IN_2095";

                //[Y980]              
                strCaptionBX[128] = "[Y980] IN_2096";
                strCaptionBX[129] = "[Y981] IN_2097";
                strCaptionBX[130] = "[Y982] IN_2098";
                strCaptionBX[131] = "[Y983] IN_2099";
                strCaptionBX[132] = "[Y984] IN_2100";
                strCaptionBX[133] = "[Y985] IN_2101";
                strCaptionBX[134] = "[Y986] IN_2102";
                strCaptionBX[135] = "[Y987] IN_2103";
                strCaptionBX[136] = "[Y988] IN_2104";
                strCaptionBX[137] = "[Y989] IN_2105";
                strCaptionBX[138] = "[Y98A] IN_2106";
                strCaptionBX[139] = "[Y98B] IN_2107";
                strCaptionBX[140] = "[Y98C] IN_SCALE_BAR_AIR_BLW_X";
                strCaptionBX[141] = "[Y98D] IN_SCALE_BAR_AIR_BLW_Y1_Y2";
                strCaptionBX[142] = "[Y98E] IN_SCALE_BAR_AIR_BLW_Y3";
                strCaptionBX[143] = "[Y98F] IN_SCALE_BAR_AIR_BLW_Y4";

                //[Y990]              
                strCaptionBX[144] = "[Y990] IN_2112";
                strCaptionBX[145] = "[Y991] IN_2113";
                strCaptionBX[146] = "[Y992] IN_2114";
                strCaptionBX[147] = "[Y993] IN_2115";
                strCaptionBX[148] = "[Y994] IN_PWR_CHK_FWD_SOURCE";
                strCaptionBX[149] = "[Y995] IN_PWR_CHK_FWD_SCANNER";
                strCaptionBX[150] = "[Y996] IN_PWR_CHK_FAN_PWR_SOURCE";
                strCaptionBX[151] = "[Y997] IN_PWR_CHK_FAN_PWR_SCANNER";
                strCaptionBX[152] = "[Y998] IN_LASER_OPTIC_OPEN";
                strCaptionBX[153] = "[Y999] IN_LASER_INTERLOCK_ON";
                strCaptionBX[154] = "[Y99A] IN_2122";
                strCaptionBX[155] = "[Y99B] IN_2123";
                strCaptionBX[156] = "[Y99C] IN_2124";
                strCaptionBX[157] = "[Y99D] IN_2125";
                strCaptionBX[158] = "[Y99E] IN_2126";
                strCaptionBX[159] = "[Y99F] IN_2127";

                //[Y9A0]              
                strCaptionBX[160] = "[Y9A0] IN_CAM1_SCALE_HEAD_AIR_BLW";
                strCaptionBX[161] = "[Y9A1] IN_CAM2_SCALE_HEAD_AIR_BLW";
                strCaptionBX[162] = "[Y9A2] IN_CAM3_SCALE_HEAD_AIR_BLW";
                strCaptionBX[163] = "[Y9A3] IN_CAM4_SCALE_HEAD_AIR_BLW";
                strCaptionBX[164] = "[Y9A4] IN_2132";
                strCaptionBX[165] = "[Y9A5] IN_2133";
                strCaptionBX[166] = "[Y9A6] IN_2134";
                strCaptionBX[167] = "[Y9A7] IN_2135";
                strCaptionBX[168] = "[Y9A8] IN_SCANNER_SUCTION_CUP_BLW";
                strCaptionBX[169] = "[Y9A9] IN_LASER_GAS_GENR_BLW";
                strCaptionBX[170] = "[Y9AA] IN_CAM1_LENS_BLW";
                strCaptionBX[171] = "[Y9AB] IN_CAM2_LENS_BLW";
                strCaptionBX[172] = "[Y9AC] IN_CAM3_LENS_BLW";
                strCaptionBX[173] = "[Y9AD] IN_2141";
                strCaptionBX[174] = "[Y9AE] IN_2142";
                strCaptionBX[175] = "[Y9AF] IN_SCANNER_Z_BRAKE";

                //[Y9B0]              
                strCaptionBX[176] = "[Y9B0] IN_WORK_TABLE_LEFT_LIGHT_FWD";
                strCaptionBX[177] = "[Y9B1] IN_WORK_TABLE_RIGHT_LIGHT_FWD";
                strCaptionBX[178] = "[Y9B2] IN_WORK_TABLE_SCALE_AIR_BLW";
                strCaptionBX[179] = "[Y9B3] IN_WORK_TABLE_POINT_AIR_BLW";
                strCaptionBX[180] = "[Y9B4] IN_2148";
                strCaptionBX[181] = "[Y9B5] IN_2149";
                strCaptionBX[182] = "[Y9B6] IN_2150";
                strCaptionBX[183] = "[Y9B7] IN_2151";
                strCaptionBX[184] = "[Y9B8] IN_2152";
                strCaptionBX[185] = "[Y9B9] IN_2153";
                strCaptionBX[186] = "[Y9BA] IN_2154";
                strCaptionBX[187] = "[Y9BB] IN_2155";
                strCaptionBX[188] = "[Y9BC] IN_2156";
                strCaptionBX[189] = "[Y9BD] IN_2157";
                strCaptionBX[190] = "[Y9BE] IN_2158";
                strCaptionBX[191] = "[Y9BF] IN_2159";

                //[Y9C0]              
                strCaptionBX[192] = "[Y9C0] IN_STAGE1_FINE_ALIGN_MODE";
                strCaptionBX[193] = "[Y9C1] IN_STAGE1_INSPECTION_MODE";
                strCaptionBX[194] = "[Y9C2] IN_STAGE1_R_CUT_MODE";
                strCaptionBX[195] = "[Y9C3] IN_STAGE1_C_CUT_MODE";
                strCaptionBX[196] = "[Y9C4] IN_STAGE1_SHAPE_CUT_MODE";
                strCaptionBX[197] = "[Y9C5] IN_STAGE1_ROUND_CAM_SELECT";
                strCaptionBX[198] = "[Y9C6] IN_STAGE1_PAD_CAM_SELECT";
                strCaptionBX[199] = "[Y9C7] IN_STAGE1_BEAM_SZ_CHK_REQ";
                strCaptionBX[200] = "[Y9C8] IN_STAGE1_CAM_LIVE_REQ";
                strCaptionBX[201] = "[Y9C9] IN_STAGE1_CAM_FREEZE_REQ";
                strCaptionBX[202] = "[Y9CA] IN_STAGE1_CAM_GRAB_REQ";
                strCaptionBX[203] = "[Y9CB] IN_STAGE1_CAM_FORCE_GRAB_REQ";
                strCaptionBX[204] = "[Y9CC] IN_STAGE1_CAM_CALIB_REQ";
                strCaptionBX[205] = "[Y9CD] IN_2173";
                strCaptionBX[206] = "[Y9CE] IN_STAGE1_CAM_RCS_REQ";
                strCaptionBX[207] = "[Y9CF] IN_STAGE1_MOVE_COMP";

                //[Y9D0]              
                strCaptionBX[208] = "[Y9D0] IN_STAGE1_CAM1_SEARCH_REQ_X";
                strCaptionBX[209] = "[Y9D1] IN_2177";
                strCaptionBX[210] = "[Y9D2] IN_2178";
                strCaptionBX[211] = "[Y9D3] IN_STAGE1_CAM1_SEARCH_REQ_Y";
                strCaptionBX[212] = "[Y9D4] IN_2180";
                strCaptionBX[213] = "[Y9D5] IN_2181";
                strCaptionBX[214] = "[Y9D6] IN_2182";
                strCaptionBX[215] = "[Y9D7] IN_2183";
                strCaptionBX[216] = "[Y9D8] IN_STAGE1_CAM2_SEARCH_REQ_X";
                strCaptionBX[217] = "[Y9D9] IN_2185";
                strCaptionBX[218] = "[Y9DA] IN_2186";
                strCaptionBX[219] = "[Y9DB] IN_STAGE1_CAM2_SEARCH_REQ_Y";
                strCaptionBX[220] = "[Y9DC] IN_2188";
                strCaptionBX[221] = "[Y9DD] IN_2189";
                strCaptionBX[222] = "[Y9DE] IN_2190";
                strCaptionBX[223] = "[Y9DF] IN_2191";

                //[Y9E0]              
                strCaptionBX[224] = "[Y9E0] IN_STAGE2_FINE_ALIGN_MODE";
                strCaptionBX[225] = "[Y9E1] IN_STAGE2_INSPECTION_MODE";
                strCaptionBX[226] = "[Y9E2] IN_STAGE2_R_CUT_MODE";
                strCaptionBX[227] = "[Y9E3] IN_STAGE2_C_CUT_MODE";
                strCaptionBX[228] = "[Y9E4] IN_STAGE2_SHAPE_CUT_MODE";
                strCaptionBX[229] = "[Y9E5] IN_STAGE2_ROUND_CAM_SELECT";
                strCaptionBX[230] = "[Y9E6] IN_STAGE2_PAD_CAM_SELECT";
                strCaptionBX[231] = "[Y9E7] IN_STAGE2_BEAM_SZ_CHK_REQ";
                strCaptionBX[232] = "[Y9E8] IN_STAGE2_CAM_LIVE_REQ";
                strCaptionBX[233] = "[Y9E9] IN_STAGE2_CAM_FREEZE_REQ";
                strCaptionBX[234] = "[Y9EA] IN_STAGE2_CAM_GRAB_REQ";
                strCaptionBX[235] = "[Y9EB] IN_STAGE2_CAM_FORCE_GRAB_REQ";
                strCaptionBX[236] = "[Y9EC] IN_STAGE2_CAM_CALIB_REQ";
                strCaptionBX[237] = "[Y9ED] IN_2205";
                strCaptionBX[238] = "[Y9EE] IN_STAGE2_CAM_RCS_REQ";
                strCaptionBX[239] = "[Y9EF] IN_STAGE2_MOVE_COMP";

                //[Y9F0]              
                strCaptionBX[240] = "[Y9F0] IN_STAGE2_CAM1_SEARCH_REQ_X";
                strCaptionBX[241] = "[Y9F1] IN_2209";
                strCaptionBX[242] = "[Y9F2] IN_2210";
                strCaptionBX[243] = "[Y9F3] IN_STAGE2_CAM1_SEARCH_REQ_Y";
                strCaptionBX[244] = "[Y9F4] IN_2212";
                strCaptionBX[245] = "[Y9F5] IN_2213";
                strCaptionBX[246] = "[Y9F6] IN_2214";
                strCaptionBX[247] = "[Y9F7] IN_2215";
                strCaptionBX[248] = "[Y9F8] IN_STAGE2_CAM2_SEARCH_REQ_X";
                strCaptionBX[249] = "[Y9F9] IN_2217";
                strCaptionBX[250] = "[Y9FA] IN_2218";
                strCaptionBX[251] = "[Y9FB] IN_STAGE2_CAM2_SEARCH_REQ_Y";
                strCaptionBX[252] = "[Y9FC] IN_2220";
                strCaptionBX[253] = "[Y9FD] IN_2221";
                strCaptionBX[254] = "[Y9FE] IN_2222";
                strCaptionBX[255] = "[Y9FF] IN_2223";

                //[YA00]
                strCaptionBY[0] = "[YA00] OUT_ALIVE";
                strCaptionBY[1] = "[YA01] OUT_AUTO_READY";
                strCaptionBY[2] = "[YA02] OUT_AUTO_RUN";
                strCaptionBY[3] = "[YA03] OUT_ERROR";
                strCaptionBY[4] = "[YA04] OUT_WARNING";
                strCaptionBY[5] = "[YA05] OUT_PM_MODE";
                strCaptionBY[6] = "[YA06] OUT_1CYCLE_MODE";
                strCaptionBY[7] = "[YA07] OUT_3007";
                strCaptionBY[8] = "[YA08] OUT_VISION_BUSY";
                strCaptionBY[9] = "[YA09] OUT_3009";
                strCaptionBY[10] = "[YA0A] OUT_3020";
                strCaptionBY[11] = "[YA0B] OUT_3011";
                strCaptionBY[12] = "[YA0C] OUT_3012";
                strCaptionBY[13] = "[YA0D] OUT_3013";
                strCaptionBY[14] = "[YA0E] OUT_3014";
                strCaptionBY[15] = "[YA0F] OUT_BUZZER_OFF";

                //[YA10]             
                strCaptionBY[16] = "[YA10] OUT_LOC_PPID_COPY_COMP";
                strCaptionBY[17] = "[YA11] OUT_LOC_PPID_DELETE_COMP";
                strCaptionBY[18] = "[YA12] OUT_LOC_PPID_BODY_CHANGE_COMP";
                strCaptionBY[19] = "[YA13] OUT_LOC_PPID_MODEL_CHANGE_COMP";
                strCaptionBY[20] = "[YA14] OUT_LOC_ECM_CHANGE_COMP";
                strCaptionBY[21] = "[YA15] OUT_3021";
                strCaptionBY[22] = "[YA16] OUT_3022";
                strCaptionBY[23] = "[YA17] OUT_3023";
                strCaptionBY[24] = "[YA18] OUT_RMT_PPID_CREATE_COMP";
                strCaptionBY[25] = "[YA19] OUT_RMT_PPID_DELETE_COMP";
                strCaptionBY[26] = "[YA1A] OUT_RMT_PPID_BODY_CHANGE_COMP";
                strCaptionBY[27] = "[YA1B] OUT_RMT_PPID_BODY_SEARCH_COMP";
                strCaptionBY[28] = "[YA1C] OUT_3028";
                strCaptionBY[29] = "[YA1D] OUT_TIME_CHANGE_COMP";
                strCaptionBY[30] = "[YA1E] OUT_STAGE1_INIT_COMP";
                strCaptionBY[31] = "[YA1F] OUT_STAGE2_INIT_COMP";

                //[YA20]            
                strCaptionBY[32] = "[YA20] OUT_STAGE1_CAM_FORCE_GRAB_COMP";
                strCaptionBY[33] = "[YA21] OUT_STAGE1_CAM_FORCE_GRAB_CANCEL";
                strCaptionBY[34] = "[YA22] OUT_STAGE1_CAM_RCS_COMP";
                strCaptionBY[35] = "[YA23] OUT_STAGE1_CAM_RCS_CANCEL";
                strCaptionBY[36] = "[YA24] OUT_3036";
                strCaptionBY[37] = "[YA25] OUT_3037";
                strCaptionBY[38] = "[YA26] OUT_3038";
                strCaptionBY[39] = "[YA27] OUT_STAGE1_BEAM_SZ_CHK_COMP";
                strCaptionBY[40] = "[YA28] OUT_STAGE1_CAM_LIVE_COMP";
                strCaptionBY[41] = "[YA29] OUT_STAGE1_CAM_FREEZE_COMP";
                strCaptionBY[42] = "[YA2A] OUT_STAGE1_CAM_GRAB_COMP";
                strCaptionBY[43] = "[YA2B] OUT_3043";
                strCaptionBY[44] = "[YA2C] OUT_STAGE1_CAM_CALIB_COMP";
                strCaptionBY[45] = "[YA2D] OUT_STAGE1_CAM_CALIB_FAIL";
                strCaptionBY[46] = "[YA2E] OUT_3046";
                strCaptionBY[47] = "[YA2F] OUT_STAGE1_MOVE_REQ";

                //[YA30]            
                strCaptionBY[48] = "[YA30] OUT_STAGE1_CAM1_SEARCH_COMP_X";
                strCaptionBY[49] = "[YA31] OUT_STAGE1_CAM1_RESULT_OK_X";
                strCaptionBY[50] = "[YA32] OUT_STAGE1_CAM1_SEARCH_COMP_Y";
                strCaptionBY[51] = "[YA33] OUT_STAGE1_CAM1_RESULT_OK_Y";
                strCaptionBY[52] = "[YA34] OUT_STAGE1_CAM1_RESULT_OK_C_R";
                strCaptionBY[53] = "[YA35] OUT_STAGE1_CAM1_PANEL_LIMIT";
                strCaptionBY[54] = "[YA36] OUT_STAGE1_CAM1_INSP_CAM_NG";
                strCaptionBY[55] = "[YA37] OUT_3055";
                strCaptionBY[56] = "[YA38] OUT_STAGE1_CAM2_SEARCH_COMP_X";
                strCaptionBY[57] = "[YA39] OUT_STAGE1_CAM2_RESULT_OK_X";
                strCaptionBY[58] = "[YA3A] OUT_STAGE1_CAM2_SEARCH_COMP_Y";
                strCaptionBY[59] = "[YA3B] OUT_STAGE1_CAM2_RESULT_OK_Y";
                strCaptionBY[60] = "[YA3C] OUT_STAGE1_CAM2_RESULT_OK_C_R";
                strCaptionBY[61] = "[YA3D] OUT_STAGE1_CAM2_PANEL_LIMIT";
                strCaptionBY[62] = "[YA3E] OUT_STAGE1_CAM2_INSP_CAM_NG";
                strCaptionBY[63] = "[YA3F] OUT_3063";

                //[YA40]             
                strCaptionBY[64] = "[YA40] OUT_STAGE2_CAM_FORCE_GRAB_COMP";
                strCaptionBY[65] = "[YA41] OUT_STAGE2_CAM_FORCE_GRAB_CANCEL";
                strCaptionBY[66] = "[YA42] OUT_STAGE2_CAM_RCS_COMP";
                strCaptionBY[67] = "[YA43] OUT_STAGE2_CAM_RCS_CANCEL";
                strCaptionBY[68] = "[YA44] OUT_3068";
                strCaptionBY[69] = "[YA45] OUT_3069";
                strCaptionBY[70] = "[YA46] OUT_3070";
                strCaptionBY[71] = "[YA47] OUT_STAGE2_BEAM_SZ_CHK_COMP";
                strCaptionBY[72] = "[YA48] OUT_STAGE2_CAM_LIVE_COMP";
                strCaptionBY[73] = "[YA49] OUT_STAGE2_CAM_FREEZE_COMP";
                strCaptionBY[74] = "[YA4A] OUT_STAGE2_CAM_GRAB_COMP";
                strCaptionBY[75] = "[YA4B] OUT_3075";
                strCaptionBY[76] = "[YA4C] OUT_STAGE2_CAM_CALIB_COMP";
                strCaptionBY[77] = "[YA4D] OUT_STAGE2_CAM_CALIB_FAIL";
                strCaptionBY[78] = "[YA4E] OUT_3078";
                strCaptionBY[79] = "[YA4F] OUT_STAGE2_MOVE_REQ";

                //[YA50]             
                strCaptionBY[80] = "[YA50] OUT_STAGE1_CAM1_SEARCH_COMP_X";
                strCaptionBY[81] = "[YA51] OUT_STAGE1_CAM1_RESULT_OK_X";
                strCaptionBY[82] = "[YA52] OUT_STAGE1_CAM1_SEARCH_COMP_Y";
                strCaptionBY[83] = "[YA53] OUT_STAGE1_CAM1_RESULT_OK_Y";
                strCaptionBY[84] = "[YA54] OUT_STAGE1_CAM1_RESULT_OK_C_R";
                strCaptionBY[85] = "[YA55] OUT_STAGE1_CAM1_PANEL_LIMIT";
                strCaptionBY[86] = "[YA56] OUT_STAGE1_CAM1_INSP_CAM_NG";
                strCaptionBY[87] = "[YA57] OUT_3087";
                strCaptionBY[88] = "[YA58] OUT_STAGE1_CAM2_SEARCH_COMP_X";
                strCaptionBY[89] = "[YA59] OUT_STAGE1_CAM2_RESULT_OK_X";
                strCaptionBY[90] = "[YA5A] OUT_STAGE1_CAM2_SEARCH_COMP_Y";
                strCaptionBY[91] = "[YA5B] OUT_STAGE1_CAM2_RESULT_OK_Y";
                strCaptionBY[92] = "[YA5C] OUT_STAGE1_CAM2_RESULT_OK_C_R";
                strCaptionBY[93] = "[YA5D] OUT_STAGE1_CAM2_PANEL_LIMIT";
                strCaptionBY[94] = "[YA5E] OUT_STAGE1_CAM2_INSP_CAM_NG";
                strCaptionBY[95] = "[YA5F] OUT_3095";

                //[D1040]
                strCaptionWR[0] = "[WW28] WW_PANEL1_CELL_ID H";
                strCaptionWR[1] = "[WW29] WW_PANEL1_CELL_ID L";
                strCaptionWR[2] = "[WW2A] WW_PANEL1_CELL_ID_1 H";
                strCaptionWR[3] = "[WW2B] WW_PANEL1_CELL_ID_1 L";
                strCaptionWR[4] = "[WW2C] WW_PANEL1_CELL_ID_2 H";
                strCaptionWR[5] = "[WW2D] WW_PANEL1_CELL_ID_2 L";
                strCaptionWR[6] = "[WW2E] WW_PANEL1_CELL_ID_3 H";
                strCaptionWR[7] = "[WW2F] WW_PANEL1_CELL_ID_3 L";
                strCaptionWR[8] = "[WW30] WW_PANEL1_CELL_ID_4 H";
                strCaptionWR[9] = "[WW31] WW_PANEL1_CELL_ID_4 L";
                strCaptionWR[10] = "[WW32] WW_PANEL2_CELL_ID H";
                strCaptionWR[11] = "[WW33] WW_PANEL2_CELL_ID L";
                strCaptionWR[12] = "[WW34] WW_PANEL2_CELL_ID_1 H";
                strCaptionWR[13] = "[WW35] WW_PANEL2_CELL_ID_1 L";
                strCaptionWR[14] = "[WW36] WW_PANEL2_CELL_ID_2 H";
                strCaptionWR[15] = "[WW37] WW_PANEL2_CELL_ID_2 L";

                strCaptionWR[16] = "[WW38] WW_PANEL2_CELL_ID_3 H";
                strCaptionWR[17] = "[WW39] WW_PANEL2_CELL_ID_3 L";
                strCaptionWR[18] = "[WW3A] WW_PANEL2_CELL_ID_4 H";
                strCaptionWR[19] = "[WW3B] WW_PANEL2_CELL_ID_4 L";
                strCaptionWR[20] = "[WW3C] WW_CAM_CALIB_SELECT H";
                strCaptionWR[21] = "[WW3D] WW_CAM_CALIB_SELECT L";
                strCaptionWR[22] = "[WW3E] WW_CAM_CALIB_NO H";
                strCaptionWR[23] = "[WW3F] WW_CAM_CALIB_NO L";
                strCaptionWR[24] = "[WW40] WW_STAGE_X_CUR_POS H";
                strCaptionWR[25] = "[WW41] WW_STAGE_X_CUR_POS L";
                strCaptionWR[26] = "[WW42] WW_STAGE_Y_CUR_POS H";
                strCaptionWR[27] = "[WW43] WW_STAGE_Y_CUR_POS L";
                strCaptionWR[28] = "[WW44] WW_PANEL_CORNER_OFFSET H";
                strCaptionWR[29] = "[WW45] WW_PANEL_CORNER_OFFSET L";
                strCaptionWR[30] = "[WW46] WW_4030";
                strCaptionWR[31] = "[WW47] WW_4031";

                //[D1072]
                strCaptionWW[0] = "[WW48] WW_CAM1_SEARCH1_X H";
                strCaptionWW[1] = "[WW49] WW_CAM1_SEARCH1_X L";
                strCaptionWW[2] = "[WW4A] WW_CAM1_SEARCH1_Y H";
                strCaptionWW[3] = "[WW4B] WW_CAM1_SEARCH1_Y L";
                strCaptionWW[4] = "[WW4C] WW_CAM1_SEARCH1_R_T H";
                strCaptionWW[5] = "[WW4D] WW_CAM1_SEARCH1_R_T L";
                strCaptionWW[6] = "[WW4E] WW_CAM1_SEARCH1_SCORE H";
                strCaptionWW[7] = "[WW4F] WW_CAM1_SEARCH1_SCORE L";
                strCaptionWW[8] = "[WW50] WW_CAM1_SEARCH2_X H";
                strCaptionWW[9] = "[WW51] WW_CAM1_SEARCH2_X L";
                strCaptionWW[10] = "[WW52] WW_CAM1_SEARCH2_Y H";
                strCaptionWW[11] = "[WW53] WW_CAM1_SEARCH2_Y L";
                strCaptionWW[12] = "[WW54] WW_CAM1_SEARCH2_R_T H";
                strCaptionWW[13] = "[WW55] WW_CAM1_SEARCH2_R_T L";
                strCaptionWW[14] = "[WW56] WW_CAM1_SEARCH2_SCORE H";
                strCaptionWW[15] = "[WW57] WW_CAM1_SEARCH2_SCORE L";

                strCaptionWW[16] = "[WW58] WW_CAM1_SEARCH3_X H";
                strCaptionWW[17] = "[WW59] WW_CAM1_SEARCH3_X L";
                strCaptionWW[18] = "[WW5A] WW_CAM1_SEARCH3_Y H";
                strCaptionWW[19] = "[WW5B] WW_CAM1_SEARCH3_Y L";
                strCaptionWW[20] = "[WW5C] WW_CAM1_SEARCH3_R_T H";
                strCaptionWW[21] = "[WW5D] WW_CAM1_SEARCH3_R_T L";
                strCaptionWW[22] = "[WW5E] WW_CAM1_SEARCH3_SCORE H";
                strCaptionWW[23] = "[WW5F] WW_CAM1_SEARCH3_SCORE L";
                strCaptionWW[24] = "[WW60] WW_CAM2_SEARCH1_X H";
                strCaptionWW[25] = "[WW61] WW_CAM2_SEARCH1_X L";
                strCaptionWW[26] = "[WW62] WW_CAM2_SEARCH1_Y H";
                strCaptionWW[27] = "[WW63] WW_CAM2_SEARCH1_Y L";
                strCaptionWW[28] = "[WW64] WW_CAM2_SEARCH1_R_T H";
                strCaptionWW[29] = "[WW65] WW_CAM2_SEARCH1_R_T L";
                strCaptionWW[30] = "[WW66] WW_CAM2_SEARCH1_SCORE H";
                strCaptionWW[31] = "[WW67] WW_CAM2_SEARCH1_SCORE L";

                //[D1088]
                strCaptionWW[32] = "[WW68] WW_CAM2_SEARCH2_X H";
                strCaptionWW[33] = "[WW69] WW_CAM2_SEARCH2_X L";
                strCaptionWW[34] = "[WW6A] WW_CAM2_SEARCH2_Y H";
                strCaptionWW[35] = "[WW6B] WW_CAM2_SEARCH2_Y L";
                strCaptionWW[36] = "[WW6C] WW_CAM2_SEARCH2_R_T H";
                strCaptionWW[37] = "[WW6D] WW_CAM2_SEARCH2_R_T L";
                strCaptionWW[38] = "[WW6E] WW_CAM2_SEARCH2_SCORE H";
                strCaptionWW[39] = "[WW6F] WW_CAM2_SEARCH2_SCORE L";
                strCaptionWW[40] = "[WW70] WW_CAM2_SEARCH3_X H";
                strCaptionWW[41] = "[WW71] WW_CAM2_SEARCH3_X L";
                strCaptionWW[42] = "[WW72] WW_CAM2_SEARCH3_Y H";
                strCaptionWW[43] = "[WW73] WW_CAM2_SEARCH3_Y L";
                strCaptionWW[44] = "[WW74] WW_CAM2_SEARCH3_R_T H";
                strCaptionWW[45] = "[WW75] WW_CAM2_SEARCH3_R_T L";
                strCaptionWW[46] = "[WW76] WW_CAM2_SEARCH3_SCORE H";
                strCaptionWW[47] = "[WW77] WW_CAM2_SEARCH3_SCORE L";

                strCaptionWW[48] = "[WW78] WW_5068";
                strCaptionWW[49] = "[WW79] WW_5069";
                strCaptionWW[50] = "[WW7A] WW_CAM_CALIB_STAGE_MOVE_DIST_X H";
                strCaptionWW[51] = "[WW7B] WW_CAM_CALIB_STAGE_MOVE_DIST_X L";
                strCaptionWW[52] = "[WW7C] WW_CAM_CALIB_STAGE_MOVE_DIST_Y H";
                strCaptionWW[53] = "[WW7D] WW_CAM_CALIB_STAGE_MOVE_DIST_Y L";
                strCaptionWW[54] = "[WW7E] WW_CAM_CALIB_STAGE_MOVE_ANGLE_T H";
                strCaptionWW[55] = "[WW7F] WW_CAM_CALIB_STAGE_MOVE_ANGLE_T L";
                strCaptionWW[56] = "[WW80] WW_5070";
                strCaptionWW[57] = "[WW81] WW_5071";
                strCaptionWW[58] = "[WW82] WW_5072";
                strCaptionWW[59] = "[WW83] WW_5073";
                strCaptionWW[60] = "[WW84] WW_5074";
                strCaptionWW[61] = "[WW85] WW_5075";
                strCaptionWW[62] = "[WW86] WW_5076";
                strCaptionWW[63] = "[WW87] WW_5077";
            }
            #endregion
            #region 2755_PC2
            else if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                //[XBC0]
                strCaptionBX[0] = "[X6C0] IN_ALIVE";
                strCaptionBX[1] = "[X6C1] IN_AUTO_READY";
                strCaptionBX[2] = "[X6C2] IN_AUTO_RUN";
                strCaptionBX[3] = "[X6C3] IN_ERROR";
                strCaptionBX[4] = "[X6C4] IN_WARNING";
                strCaptionBX[5] = "[X6C5] IN_PM_MODE";
                strCaptionBX[6] = "[X6C6] IN_1CYCLE_MODE";
                strCaptionBX[7] = "[X6C7] IN_EMERGENCY_STOP";
                strCaptionBX[8] = "[X6C8] IN_DOOR_LOCK";
                strCaptionBX[9] = "[X6C9] IN_1009";
                strCaptionBX[10] = "[X6CA] IN_1010";
                strCaptionBX[11] = "[X6CB] IN_ERROR_RESET";
                strCaptionBX[12] = "[X6CC] IN_1012";
                strCaptionBX[13] = "[X6CD] IN_1013";
                strCaptionBX[14] = "[X6CE] IN_1014";
                strCaptionBX[15] = "[X6CF] IN_1015";

                //[XBD0]
                strCaptionBX[16] = "[X6D0] IN_LOC_PPID_COPY_REQ";
                strCaptionBX[17] = "[X6D1] IN_LOC_PPID_DELETE_REQ";
                strCaptionBX[18] = "[X6D2] IN_LOC_PPID_BODY_CHANGE_REQ";
                strCaptionBX[19] = "[X6D3] IN_LOC_PPID_MODEL_CHANGE_REQ";
                strCaptionBX[20] = "[X6D4] IN_LOC_ECM_CHANGE_REQ";
                strCaptionBX[21] = "[X6D5] IN_1021";
                strCaptionBX[22] = "[X6D6] IN_1022";
                strCaptionBX[23] = "[X6D7] IN_1023";
                strCaptionBX[24] = "[X6D8] IN_RMT_PPID_CREATE_REQ";
                strCaptionBX[25] = "[X6D9] IN_RMT_PPID_DELETE_REQ";
                strCaptionBX[26] = "[X6DA] IN_RMT_PPID_BODY_CHANGE_REQ";
                strCaptionBX[27] = "[X6DB] IN_RMT_PPID_BODY_SEARCH_REQ";
                strCaptionBX[28] = "[X6DC] IN_1028";
                strCaptionBX[29] = "[X6DD] IN_TIME_CHANGE_REQ";
                strCaptionBX[30] = "[X6DE] IN_1030";
                strCaptionBX[31] = "[X6DF] IN_1031";

                //[XBE0]
                strCaptionBX[32] = "[X6E0] IN_FIRST_ALIGN_CALIB_REQ";
                strCaptionBX[33] = "[X6E1] IN_PRE_ALIGN1_CALIB_REQ";
                strCaptionBX[34] = "[X6E2] IN_PRE_ALIGN2_CALIB_REQ";
                strCaptionBX[35] = "[X6E3] IN_FIRST_ALIGN_FORCE_GRAB_REQ";
                strCaptionBX[36] = "[X6E4] IN_PRE_ALIGN1_FORCE_GRAB_REQ";
                strCaptionBX[37] = "[X6E5] IN_PRE_ALIGN2_FORCE_GRAB_REQ";
                strCaptionBX[38] = "[X6E6] IN_1038";
                strCaptionBX[39] = "[X6E7] IN_1039";
                strCaptionBX[40] = "[X6E8] IN_1040";
                strCaptionBX[41] = "[X6E9] IN_1041";
                strCaptionBX[42] = "[X6EA] IN_1042";
                strCaptionBX[43] = "[X6EB] IN_1043";
                strCaptionBX[44] = "[X6EC] IN_1044";
                strCaptionBX[45] = "[X6ED] IN_1045";
                strCaptionBX[46] = "[X6EE] IN_FIRST_ALIGN_STG_MOVE_COMP";
                strCaptionBX[47] = "[X6EF] IN_PRE_ALIGN_STG_MOVE_COMP";

                //[XBF0]             
                strCaptionBX[48] = "[X6F0] IN_FIRST_ALIGN_SEARCH_REQ";
                strCaptionBX[49] = "[X6F1] IN_FIRST_ALIGN_RESULT_OK_CHK";
                strCaptionBX[50] = "[X6F2] IN_FIRST_ALIGN_RESULT_NG_CHK";
                strCaptionBX[51] = "[X6F3] IN_PRE_ALIGN1_SEARCH_REQ";
                strCaptionBX[52] = "[X6F4] IN_PRE_ALIGN1_RESULT_OK_CHK";
                strCaptionBX[53] = "[X6F5] IN_PRE_ALIGN1_RESULT_NG_CHK";
                strCaptionBX[54] = "[X6F6] IN_PRE_ALIGN2_SEARCH_REQ";
                strCaptionBX[55] = "[X6F7] IN_PRE_ALIGN2_RESULT_OK_CHK";
                strCaptionBX[56] = "[X6F8] IN_PRE_ALIGN2_RESULT_NG_CHK";
                strCaptionBX[57] = "[X6F9] IN_1057";
                strCaptionBX[58] = "[X6FA] IN_1058";
                strCaptionBX[59] = "[X6FB] IN_1059";
                strCaptionBX[60] = "[X6FC] IN_1060";
                strCaptionBX[61] = "[X6FD] IN_1061";
                strCaptionBX[62] = "[X6FE] IN_1062";
                strCaptionBX[63] = "[X6FF] IN_1063";
                
                //[YBC0]
                strCaptionBY[0] = "[Y6C0] OUT_ALIVE";
                strCaptionBY[1] = "[Y6C1] OUT_AUTO_READY";
                strCaptionBY[2] = "[Y6C2] OUT_AUTO_RUN";
                strCaptionBY[3] = "[Y6C3] OUT_ERROR";
                strCaptionBY[4] = "[Y6C4] OUT_WARNING";
                strCaptionBY[5] = "[Y6C5] OUT_PM_MODE";
                strCaptionBY[6] = "[Y6C6] OUT_1CYCLE_MODE";
                strCaptionBY[7] = "[Y6C7] OUT_3007";
                strCaptionBY[8] = "[Y6C8] OUT_VISION_BUSY";
                strCaptionBY[9] = "[Y6C9] OUT_3009";
                strCaptionBY[10] = "[Y6CA] OUT_3020";
                strCaptionBY[11] = "[Y6CB] OUT_3011";
                strCaptionBY[12] = "[Y6CC] OUT_3012";
                strCaptionBY[13] = "[Y6CD] OUT_3013";
                strCaptionBY[14] = "[Y6CE] OUT_3014";
                strCaptionBY[15] = "[Y6CF] OUT_BUZZER_OFF";

                //[YBD0]             
                strCaptionBY[16] = "[Y6D0] OUT_LOC_PPID_COPY_COMP";
                strCaptionBY[17] = "[Y6D1] OUT_LOC_PPID_DELETE_COMP";
                strCaptionBY[18] = "[Y6D2] OUT_LOC_PPID_BODY_CHANGE_COMP";
                strCaptionBY[19] = "[Y6D3] OUT_LOC_PPID_MODEL_CHANGE_COMP";
                strCaptionBY[20] = "[Y6D4] OUT_LOC_ECM_CHANGE_COMP";
                strCaptionBY[21] = "[Y6D5] OUT_3021";
                strCaptionBY[22] = "[Y6D6] OUT_3022";
                strCaptionBY[23] = "[Y6D7] OUT_3023";
                strCaptionBY[24] = "[Y6D8] OUT_RMT_PPID_CREATE_COMP";
                strCaptionBY[25] = "[Y6D9] OUT_RMT_PPID_DELETE_COMP";
                strCaptionBY[26] = "[Y6DA] OUT_RMT_PPID_BODY_CHANGE_COMP";
                strCaptionBY[27] = "[Y6DB] OUT_RMT_PPID_BODY_SEARCH_COMP";
                strCaptionBY[28] = "[Y6DC] OUT_3028";
                strCaptionBY[29] = "[Y6DD] OUT_TIME_CHANGE_COMP";
                strCaptionBY[30] = "[Y6DE] OUT_3030";
                strCaptionBY[31] = "[Y6DF] OUT_3031";

                //[YBE0]            
                strCaptionBY[32] = "[Y6E0] OUT_FIRST_ALIGN_CALIB_COMP";
                strCaptionBY[33] = "[Y6E1] OUT_PRE_ALIGN1_CALIB_COMP";
                strCaptionBY[34] = "[Y6E2] OUT_PRE_ALIGN2_CALIB_COMP";
                strCaptionBY[35] = "[Y6E3] OUT_FIRST_ALIGN_FORCE_GRAB_COMP";
                strCaptionBY[36] = "[Y6E4] OUT_PRE_ALIGN1_FORCE_GRAB_COMP";
                strCaptionBY[37] = "[Y6E5] OUT_PRE_ALIGN2_FORCE_GRAB_COMP";
                strCaptionBY[38] = "[Y6E6] OUT_3038";
                strCaptionBY[39] = "[Y6E7] OUT_3039";
                strCaptionBY[40] = "[Y6E8] OUT_3040";
                strCaptionBY[41] = "[Y6E9] OUT_3041";
                strCaptionBY[42] = "[Y6EA] OUT_3042";
                strCaptionBY[43] = "[Y6EB] OUT_3043";
                strCaptionBY[44] = "[Y6EC] OUT_3044";
                strCaptionBY[45] = "[Y6ED] OUT_3045";
                strCaptionBY[46] = "[Y6EE] OUT_FIRST_ALIGN_STG_MOVE_REQ";
                strCaptionBY[47] = "[Y6EF] OUT_PRE_ALIGN_STG_MOVE_REQ";

                //[YBF0]            
                strCaptionBY[48] = "[Y6F0] OUT_FIRST_ALIGN_SEARCH_COMP";
                strCaptionBY[49] = "[Y6F1] OUT_FIRST_ALIGN_RESULT_OK";
                strCaptionBY[50] = "[Y6F2] OUT_FIRST_ALIGN_RESULT_NG";
                strCaptionBY[51] = "[Y6F3] OUT_PRE_ALIGN1_SEARCH_COMP";
                strCaptionBY[52] = "[Y6F4] OUT_PRE_ALIGN1_RESULT_OK";
                strCaptionBY[53] = "[Y6F5] OUT_PRE_ALIGN1_RESULT_NG";
                strCaptionBY[54] = "[Y6F6] OUT_PRE_ALIGN2_SEARCH_COMP";
                strCaptionBY[55] = "[Y6F7] OUT_PRE_ALIGN2_RESULT_OK";
                strCaptionBY[56] = "[Y6F8] OUT_PRE_ALIGN2_RESULT_NG";
                strCaptionBY[57] = "[Y6F9] OUT_3057";
                strCaptionBY[58] = "[Y6FA] OUT_1ST_ALIGN_CROSS_ANGLE_NG";
                strCaptionBY[59] = "[Y6FB] OUT_1ST_ALIGN_VERTI_ANGLE_NG";
                strCaptionBY[60] = "[Y6FC] OUT_3060";
                strCaptionBY[61] = "[Y6FD] OUT_3061";
                strCaptionBY[62] = "[Y6FE] OUT_3062";
                strCaptionBY[63] = "[Y6FF] OUT_3063";

                //[D2136]
                strCaptionWR[0] = "[WW88] WW_PANEL1_CELL_ID H";
                strCaptionWR[1] = "[WW89] WW_PANEL1_CELL_ID L";
                strCaptionWR[2] = "[WW8A] WW_PANEL1_CELL_ID_1 H";
                strCaptionWR[3] = "[WW8B] WW_PANEL1_CELL_ID_1 L";
                strCaptionWR[4] = "[WW8C] WW_PANEL1_CELL_ID_2 H";
                strCaptionWR[5] = "[WW8D] WW_PANEL1_CELL_ID_2 L";
                strCaptionWR[6] = "[WW8E] WW_PANEL1_CELL_ID_3 H";
                strCaptionWR[7] = "[WW8F] WW_PANEL1_CELL_ID_3 L";
                strCaptionWR[8] = "[WW90] WW_PANEL1_CELL_ID_4 H";
                strCaptionWR[9] = "[WW91] WW_PANEL1_CELL_ID_4 L";
                strCaptionWR[10] = "[WW92] WW_PANEL1_CELL_ID_5 H";
                strCaptionWR[11] = "[WW93] WW_PANEL1_CELL_ID_5 L";
                strCaptionWR[12] = "[WW94] WW_PANEL1_CELL_ID_6 H";
                strCaptionWR[13] = "[WW95] WW_PANEL1_CELL_ID_6 L";
                strCaptionWR[14] = "[WW96] WW_PANEL1_CELL_ID_7 H";
                strCaptionWR[15] = "[WW97] WW_PANEL1_CELL_ID_7 L";

                strCaptionWR[16] = "[WW98] WW_FIRST_ALIGN_STAGE_X H";
                strCaptionWR[17] = "[WW99] WW_FIRST_ALIGN_STAGE_X L";
                strCaptionWR[18] = "[WW9A] WW_FIRST_ALIGN_STAGE_Y H";
                strCaptionWR[19] = "[WW9B] WW_FIRST_ALIGN_STAGE_Y L";
                strCaptionWR[20] = "[WW9C] WW_FIRST_ALIGN_STAGE_T H";
                strCaptionWR[21] = "[WW9D] WW_FIRST_ALIGN_STAGE_T L";
                strCaptionWR[22] = "[WW9E] WW_PRE_ALIGN_STAGE_X H";
                strCaptionWR[23] = "[WW9F] WW_PRE_ALIGN_STAGE_X L";
                strCaptionWR[24] = "[WWA0] WW_PRE_ALIGN_STAGE_Y H";
                strCaptionWR[25] = "[WWA1] WW_PRE_ALIGN_STAGE_Y L";
                strCaptionWR[26] = "[WWA2] WW_PRE_ALIGN_STAGE_T H";
                strCaptionWR[27] = "[WWA3] WW_PRE_ALIGN_STAGE_T L";
                strCaptionWR[28] = "[WWA4] WW_4028";
                strCaptionWR[29] = "[WWA5] WW_4029";
                strCaptionWR[30] = "[WWA6] WW_4030";
                strCaptionWR[31] = "[WWA7] WW_4031";

                //[D1136]
                strCaptionWW[0] = "[WW88] WW_FIRST_ALIGN_SEARCH_X H";
                strCaptionWW[1] = "[WW89] WW_FIRST_ALIGN_SEARCH_X L";
                strCaptionWW[2] = "[WW8A] WW_FIRST_ALIGN_SEARCH_Y H";
                strCaptionWW[3] = "[WW8B] WW_FIRST_ALIGN_SEARCH_Y L";
                strCaptionWW[4] = "[WW8C] WW_FIRST_ALIGN_SEARCH_R_T H";
                strCaptionWW[5] = "[WW8D] WW_FIRST_ALIGN_SEARCH_R_T L";
                strCaptionWW[6] = "[WW8E] WW_FIRST_ALIGN_SEARCH_SCORE H";
                strCaptionWW[7] = "[WW8F] WW_FIRST_ALIGN_SEARCH_SCORE L";
                strCaptionWW[8] = "[WW90] WW_PRE_ALIGN_SEARCH_X H";
                strCaptionWW[9] = "[WW91] WW_PRE_ALIGN_SEARCH_X L";
                strCaptionWW[10] = "[WW92] WW_PRE_ALIGN1_SEARCH_Y H";
                strCaptionWW[11] = "[WW93] WW_PRE_ALIGN1_SEARCH_Y L";
                strCaptionWW[12] = "[WW94] WW_PRE_ALIGN1_SEARCH_R_T H";
                strCaptionWW[13] = "[WW95] WW_PRE_ALIGN1_SEARCH_R_T L";
                strCaptionWW[14] = "[WW96] WW_PRE_ALIGN1_SEARCH_SCORE H";
                strCaptionWW[15] = "[WW97] WW_PRE_ALIGN1_SEARCH_SCORE L";

                strCaptionWW[16] = "[WW98] WW_PRE_ALIGN2_SEARCH_X H";
                strCaptionWW[17] = "[WW99] WW_PRE_ALIGN2_SEARCH_X L";
                strCaptionWW[18] = "[WW9A] WW_PRE_ALIGN2_SEARCH_Y H";
                strCaptionWW[19] = "[WW9B] WW_PRE_ALIGN2_SEARCH_Y L";
                strCaptionWW[20] = "[WW9C] WW_PRE_ALIGN2_SEARCH_R_T H";
                strCaptionWW[21] = "[WW9D] WW_PRE_ALIGN2_SEARCH_R_T L";
                strCaptionWW[22] = "[WW9E] WW_PRE_ALIGN2_SEARCH_SCORE H";
                strCaptionWW[23] = "[WW9F] WW_PRE_ALIGN2_SEARCH_SCORE L";
                strCaptionWW[24] = "[WWA0] WW_5024";
                strCaptionWW[25] = "[WWA1] WW_5025";
                strCaptionWW[26] = "[WWA2] WW_5026";
                strCaptionWW[27] = "[WWA3] WW_5027";
                strCaptionWW[28] = "[WWA4] WW_5028";
                strCaptionWW[29] = "[WWA5] WW_5029";
                strCaptionWW[30] = "[WWA6] WW_5030";
                strCaptionWW[31] = "[WWA7] WW_5031";

                strCaptionWW[32] = "[WWA8] WW_5032";
                strCaptionWW[33] = "[WWA9] WW_5033";
                strCaptionWW[34] = "[WWAA] WW_5034";
                strCaptionWW[35] = "[WWAB] WW_5035";
                strCaptionWW[36] = "[WWAC] WW_5036";
                strCaptionWW[37] = "[WWAD] WW_5037";
                strCaptionWW[38] = "[WWAE] WW_5038";
                strCaptionWW[39] = "[WWAF] WW_5039";
                strCaptionWW[40] = "[WWB0] WW_5040";
                strCaptionWW[41] = "[WWB1] WW_5041";
                strCaptionWW[42] = "[WWB2] WW_5042";
                strCaptionWW[43] = "[WWB3] WW_5043";
                strCaptionWW[44] = "[WWB4] WW_5044";
                strCaptionWW[45] = "[WWB5] WW_5045";
                strCaptionWW[46] = "[WWB6] WW_5046";
                strCaptionWW[47] = "[WWB7] WW_5047";

                strCaptionWW[48] = "[WWB8] WW_5048";
                strCaptionWW[49] = "[WWB9] WW_5049";
                strCaptionWW[50] = "[WWBA] WW_5050";
                strCaptionWW[51] = "[WWBB] WW_5051";
                strCaptionWW[52] = "[WWBC] WW_5052";
                strCaptionWW[53] = "[WWBD] WW_5053";
                strCaptionWW[54] = "[WWBE] WW_5054";
                strCaptionWW[55] = "[WWBF] WW_5055";
                strCaptionWW[56] = "[WWC0] WW_5056";
                strCaptionWW[57] = "[WWC1] WW_5057";
                strCaptionWW[58] = "[WWC2] WW_5058";
                strCaptionWW[59] = "[WWC3] WW_5059";
                strCaptionWW[60] = "[WWC4] WW_5060";
                strCaptionWW[61] = "[WWC5] WW_5061";
                strCaptionWW[62] = "[WWC6] WW_5062";
                strCaptionWW[63] = "[WWC7] WW_5063";
            }
            #endregion
        }
        #endregion

        private void LB_BIT_STAT_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox tempCB = (CheckBox)sender;

            if (tempCB.Checked)
            {
                tempCB.BackColor = System.Drawing.Color.LawnGreen;
            }
            else
            {
                tempCB.BackColor = System.Drawing.Color.DarkGray;
            }
        }

        private void BTN_SHOW_MELSEC_DATA_Click(object sender, EventArgs e)
        {
            try
            {
                FormMelsec.BTN_EXIT_Click(null, null);
                FormMelsec.Show();
                FormMelsec.Form_Melsec_Load();
            }
            catch
            {
                FormMelsec = new Form_Melsec();
            }
        }

        private void Read_Interface_Data()
        {
		// PJH_230213_CCLink도 시스템에 넣을까?
            string FileName = "InfIoMapCaps_ATT";
            string FilePath = Main.InterfacePath + FileName + ".dat";
            string ReplaceResult;
            int BXIndex = 0;
            int BYIndex = 0;
            int WRIndex = 0;
            int WWIndex = 0;

            if (File.Exists(FilePath))
            {
                string[] AllLines = File.ReadAllLines(FilePath);//한 라인씩 Read

                foreach (string strLine in AllLines)
                {
                    //각 Read한 라인에서 탐색
                    string[] arrStr = strLine.Split(',');

                    foreach (string str in arrStr)
                    {
                        if (str.Equals("BX"))
                        {
                            ReplaceResult = arrStr[1].Replace("\t", "");
                            strCaptionBX[BXIndex] = ReplaceResult;
                            BXIndex++;
                        }

                        else if (str.Equals("BY"))
                        {
                            ReplaceResult = arrStr[1].Replace("\t", "");
                            strCaptionBY[BYIndex] = ReplaceResult;
                            BYIndex++;
                        }

                        else if (str.Equals("WR"))
                        {
                            ReplaceResult = arrStr[1].Replace("\t", "");
                            strCaptionWR[WRIndex] = ReplaceResult;
                            WRIndex++;
                        }

                        else if (str.Equals("WW"))
                        {
                            ReplaceResult = arrStr[1].Replace("\t", "");
                            strCaptionWW[WWIndex] = ReplaceResult;
                            WWIndex++;
                        }
                    }

                }
            }

        }
    }
}
