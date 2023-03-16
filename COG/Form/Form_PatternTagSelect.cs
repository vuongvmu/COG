using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class Form_PatternTagSelect : Form
    {
        public Form_PatternTeach PatternTeach = new Form_PatternTeach();
        private List<Button> BTN_UNIT = new List<Button>();
        public int m_AlignNo;

        public Form_PatternTagSelect()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
            Allocate_Array();
        }

        private void Allocate_Array()
        {
            for (int i = 0; i < 4; i++)
            {
                string nTempName; 
                nTempName = "BTN_PATTERN_TAG_" + i.ToString("00");
                Button nType1 = (Button)this.Controls[nTempName];
                BTN_UNIT.Add(nType1);
            }
        }

        private void Form_PatternTagSelect_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Main.AlignUnit[m_AlignNo].m_AlignPatTagMax; i++)
            {
                BTN_UNIT[i].Visible = true;
                BTN_UNIT[i].Text = "STAGE " + (i+1).ToString();
                if (Main.AlignUnit[m_AlignNo].m_AlignPatTagMax == 1)
                    BTN_UNIT[i].Text = Main.AlignUnit[m_AlignNo].m_AlignName;
            }

            if (Main.AlignUnit[m_AlignNo].m_AlignName == "FBD_FPC")
            {
                BTN_UNIT[0].Text = "FBD_FPC_ALIGN";
                BTN_UNIT[1].Text = "FBD_FPC_BLOB";
            }
            if ((Main.DEFINE.PROGRAM_TYPE == "FOF_PC3" || Main.DEFINE.PROGRAM_TYPE == "FOF_PC4") && (Main.AlignUnit[m_AlignNo].m_AlignName == "PBD1" || Main.AlignUnit[m_AlignNo].m_AlignName == "PBD2"))
            {
                BTN_UNIT[0].Text = "FOP_MODE";
                BTN_UNIT[1].Text = "FOF_MODE";
            }

            if (Main.AlignUnit[m_AlignNo].m_AlignName == "CRD_PRE1" || Main.AlignUnit[m_AlignNo].m_AlignName == "CRD_PRE2" || Main.AlignUnit[m_AlignNo].m_AlignName == "CRD_PRE3" || Main.AlignUnit[m_AlignNo].m_AlignName == "CRD_PRE4")
            {
                BTN_UNIT[0].Text = "CRD_PRE_FRONT";
                BTN_UNIT[1].Text = "CRD_PRE_REAR";
            }
            if (Main.AlignUnit[m_AlignNo].m_AlignName == "UPPER_INSPECT")
            {
                BTN_UNIT[0].Text = "FRONT_INSPECT";
                BTN_UNIT[1].Text = "REAR_INSPECT";
            }
            if (Main.AlignUnit[m_AlignNo].m_AlignName == "LOW_INSPECT")
            {
                BTN_UNIT[0].Text = "FRONT_INSPECT";
                BTN_UNIT[1].Text = "REAR_INSPECT";
            }
        }

        private void BTN_PATTERN_TAG_Click(object sender, EventArgs e)
        {
            Button TempBTN = (Button)sender;
            int m_Number;
            m_Number = Convert.ToInt16(TempBTN.Name.Substring(TempBTN.Name.Length - 2, 2));

            PatternTeach.m_ToolShow = false;

            // PJH_20221013_S
            //PatternTeach.m_AlignNo = m_AlignNo;
            //PatternTeach.m_PatTagNo = m_Number;
            PatternTeach.CamNo = m_AlignNo;
            PatternTeach.StageNo = m_Number;
            // PJH_20221013_E
            PatternTeach.ShowDialog();
        }
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < BTN_UNIT.Count; i++)
            {
                BTN_UNIT[i].Visible = false;
            }
            // PJH_20221013_S
            //Main.AlignUnit[m_AlignNo].m_PatTagNo = 0;
            Main.AlignUnit[m_AlignNo].StageNo = 0;
            // PJH_20221013_E
            this.Hide();
        }



    }
}
