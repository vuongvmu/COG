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
    public partial class Form_Melsec : Form
    {
        public Form_Melsec()
        {
            InitializeComponent();
            Allocate_Array();
        }
        Form_CMD formCmd = new Form_CMD();
        Label[] nLavel_UNIT = new Label[Main.DEFINE.AlignUnit_Max];

        Label[] nLavel = new Label[PLCDataTag.ReadSize];
        Label[] nLavel_Dis = new Label[PLCDataTag.ReadSize];
        private List<Label> nLavel_Mode = new List<Label>();
        public void Form_Melsec_Load(object sender, EventArgs e)
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" || Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                LABEL_0_99.Text = "D" + PLCDataTag.BASE_RW_ADDR.ToString() + " (VISION)";
                LABEL_100_199.Text = "D" + (PLCDataTag.BASE_MAIN_PC_RW_ADDR + Main.DEFINE.L_PC_DATA_OFFSET).ToString() + " (PC)";
                LABEL_200_299.Text = "D" + (PLCDataTag.BASE_RW_ADDR + Main.DEFINE.PLC_READ_OFFSET).ToString() + " (PLC)";
                LABEL_300_399.Text = "D" + (PLCDataTag.BASE_RW_ADDR + Main.DEFINE.PLC_READ_OFFSET + 100).ToString() + " (PLC)";
                LABEL_400_499.Text = "D" + (PLCDataTag.BASE_RW_ADDR + Main.DEFINE.PLC_READ_OFFSET + 200).ToString() + " (PLC)";

                return;
            }

            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {
                nLavel_UNIT[i].Text = Main.AlignUnit[i].m_AlignName;
            }

            if (Main.DEFINE.PROGRAM_TYPE == "FOF_PC3")
            {
                //                 label843.Text = label620.Text = label659.Text = "PANEL Length(L)";
                //                 label862.Text = label621.Text = label660.Text = "PANEL Length(H)";
                // 
                //                 label863.Text = label710.Text = label650.Text = "FPC Length(L)";
                //                 label864.Text = label711.Text = label651.Text = "FPC Length(H)";
            }


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
            formCmd.Hide();
            this.Hide();

            FormMain.Instance().InterfaceForm.ShowCCLineInterface();
        }

        private void Allocate_Array()
        {
            if (Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC1" || Main.DEFINE.PROGRAM_TYPE == "QD_LPA_PC2")
            {
                Point pointt;

                Label lTempLabel = new Label();
                lTempLabel = LABEL_0_99;
                pointt = LABEL_0_99.Location;

                for (int i = 0; i < PLCDataTag.ReadSize; i++)
                {
                    nLavel_Dis[i] = new Label();

                    if (i > 399 && i < 500)
                    {
                        if (i == 400)
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 399));
                    }
                    else if (i > 299 && i < 400)
                    /*                if (i > 299 && i < 400)*/
                    {
                        if (i == 300)
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 299));
                    }
                    else if (i > 199 && i < 300)
                    {
                        if (i == 200)
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 199));
                    }
                    else if (i > 99 && i < 200)
                    {
                        if (i == 100)
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 99));
                    }
                    else
                    {
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i + 1));
                    }

                    nLavel_Dis[i].Location = pointt;
                    nLavel_Dis[i].Size = new Size(70, 18);

                    nLavel_Dis[i].AutoSize = false;
                    nLavel_Dis[i].BorderStyle = BorderStyle.None;
                    //                 if((i%10) == 0)
                    //                     nLavel_Dis[i].BackColor = Color.DarkGray;
                    //                 else
                    nLavel_Dis[i].BackColor = Color.DarkGray;
                    nLavel_Dis[i].Font = new Font("맑은 고딕", 12F);
                    nLavel_Dis[i].TextAlign = ContentAlignment.TopCenter;
                    nLavel_Dis[i].Tag = i;
                    Controls.Add(nLavel_Dis[i]);
                }


                pointt = lTempLabel.Location;
                pointt.X = lTempLabel.Location.X + 70;

                for (int i = 0; i < PLCDataTag.ReadSize; i++)
                {
                    nLavel[i] = new Label();

                    if (i > 399 && i < 500) //     399  , 600
                    {
                        if (i == 400) //400
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 399)); //399
                    }
                    else if (i > 299 && i < 400) //     399  , 600
                                                 //if (i > 299 && i < 400) //     399  , 600
                    {
                        if (i == 300) //400
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 299)); //399
                    }
                    else if (i > 199 && i < 300) //     399  , 600
                    {
                        if (i == 200) //400
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 199)); //399
                    }
                    else if (i > 99 && i < 200) //    199   , 400
                    {
                        if (i == 100) //200
                            pointt.X = pointt.X + (lTempLabel.Size.Width * 1) + 1;
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i - 99)); //199
                    }
                    else
                    {
                        pointt.Y = lTempLabel.Location.Y + ((lTempLabel.Size.Height + 1) * (i + 1));
                    }


                    nLavel[i].Location = pointt;
                    nLavel[i].TabIndex = i;
                    nLavel[i].Size = new Size(145, 18);
                    nLavel[i].AutoSize = false;
                    nLavel[i].BorderStyle = BorderStyle.None;
                    nLavel[i].BackColor = Color.LightGray;
                    nLavel[i].Font = new Font("맑은 고딕", 12F);
                    nLavel[i].TextAlign = ContentAlignment.TopCenter;
                    nLavel[i].Click += new System.EventHandler(BTN_TEACH_Click);
                    nLavel[i].Tag = i;
                    Controls.Add(nLavel[i]);
                }

                for (int i = 0; i < PLCDataTag.ReadSize; i++)
                {
                    int nNum;
                    nNum = i + 1;
                    string nLabel = "label" + nNum.ToString();
                    Label TempLabel = (Label)this.Controls[nLabel];

                    #region Address Mode
                    if (((i >= 128 && i <= 143) && (i % 2 == 0))    // Inspection Result
                        || i == 220 || i == 308 || i == 310 || i == 312 || i == 400 || i == 402 || i == 424 || i == 426)
                        TempLabel.Text = "L";
                    else if (((i >= 128 && i <= 143) && (i % 2 == 1))
                        || i == 221 || i == 309 || i == 311 || i == 313 || i == 401 || i == 403 || i == 425 || i == 427)
                        TempLabel.Text = "H";
                    else if ((i >= 222 && i < 232) || (i >= 242 && i < 252) || (i >= 280 && i < 290) || (i >= 404 && i < 414))
                        TempLabel.Text = "A";
                    else
                        TempLabel.Text = "";
                    #endregion  // Address Mode

                    nLavel_Mode.Add(TempLabel);

                    
                    nLabel = "labelcmd" + nNum.ToString();
                    TempLabel = (Label)this.Controls[nLabel];

                    #region Address Description
                    if (i == 10)          // D320010
                        TempLabel.Text = "VISION ALIVE";
                    else if(i == 128)     // D300128
                        TempLabel.Text = "INSP POINT1";
                    else if (i == 130)     // D300130
                        TempLabel.Text = "INSP POINT2";
                    else if (i == 132)     // D300132
                        TempLabel.Text = "INSP POINT3";
                    else if (i == 134)     // D300134
                        TempLabel.Text = "INSP POINT4";
                    else if (i == 136)     // D300136
                        TempLabel.Text = "INSP POINT5";
                    else if (i == 138)     // D300138
                        TempLabel.Text = "INSP POINT6";
                    else if (i == 140)     // D300140
                        TempLabel.Text = "INSP POINT7";
                    else if (i == 142)     // D300142
                        TempLabel.Text = "INSP POINT8";
                    else if (i == 210)    // D330010
                        TempLabel.Text = "PLC ALIVE";
                    else if (i == 220)    // D330020
                        TempLabel.Text = "CUR MODEL NO";
                    else if (i == 222)    // D330022
                        TempLabel.Text = "MODEL NAME";
                    else if (i == 242)    // D330042
                        TempLabel.Text = "CUR CELL ID";
                    else if (i == 280)    // D330080
                        TempLabel.Text = "CUR MODULE ID";
                    else if (i == 300)    // D330100
                        TempLabel.Text = "TIME CHG YEAR";
                    else if (i == 301)
                        TempLabel.Text = "TIME CHG MNTH";
                    else if (i == 302)
                        TempLabel.Text = "TIME CHG DAY";
                    else if (i == 303)
                        TempLabel.Text = "TIME CHG HOUR";
                    else if (i == 304)
                        TempLabel.Text = "TIME CHG MIN";
                    else if (i == 305)
                        TempLabel.Text = "TIME CHG SEC";
                    else if (i == 306)
                        TempLabel.Text = "RUN MODE";
                    else if (i == 308)
                        TempLabel.Text = "PANEL X SIZE";
                    else if (i == 310)
                        TempLabel.Text = "PANEL Y SIZE";
                    else if (i == 312)
                        TempLabel.Text = "PNL THICKNESS";
                    else if (i == 400)    // D330200
                        TempLabel.Text = "TAR MODEL NO";
                    else if (i == 402)
                        TempLabel.Text = "CPY MODEL NO";
                    else if (i == 404)
                        TempLabel.Text = "MODEL NAME";
                    else if (i == 424)
                        TempLabel.Text = "DEL MODEL NO";
                    else if (i == 426)
                        TempLabel.Text = "CHG MODEL NO";
                    else
                        TempLabel.Text = "";
                    #endregion  // Address Description

                    if (i < 100)
                        nLavel_Dis[i].Text = (PLCDataTag.BASE_RW_ADDR + i).ToString();
                    else if (i < 200)
                        nLavel_Dis[i].Text = (PLCDataTag.BASE_MAIN_PC_RW_ADDR + Main.DEFINE.L_PC_DATA_OFFSET + i - 100).ToString();
                    else
                        nLavel_Dis[i].Text = (PLCDataTag.BASE_RW_ADDR + Main.DEFINE.PLC_READ_OFFSET + i - 200).ToString();
                }

                return;
            }
            
            Point point;
            int m_Number;
            Label nTempLabel = new Label();
            nTempLabel = LABEL_0_99;
            point = LABEL_0_99.Location;

            for (int i = 0; i < PLCDataTag.ReadSize; i++)
            {

                nLavel_Dis[i] = new Label();

                if (i > 399 && i < 500)
                {
                if (i == 400)
                    point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 399));
                }
                else if (i > 299 && i < 400)
/*                if (i > 299 && i < 400)*/
                {
                    if (i == 300)
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 299));
                }
                else if (i > 199 && i < 300)
                {
                    if (i == 200)
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 199));
                }
                else if (i > 99 && i < 200)
                {
                    if (i == 100)
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 99));
                }
                else
                {
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i + 1));
                }

                nLavel_Dis[i].Location = point;
                nLavel_Dis[i].Size = new Size(70, 18);

                m_Number = i;

                nLavel_Dis[i].Text = (PLCDataTag.BASE_RW_ADDR + m_Number).ToString();
                nLavel_Dis[i].AutoSize = false;
                nLavel_Dis[i].BorderStyle = BorderStyle.None;
                //                 if((i%10) == 0)
                //                     nLavel_Dis[i].BackColor = Color.DarkGray;
                //                 else
                nLavel_Dis[i].BackColor = Color.DarkGray;
                nLavel_Dis[i].Font = new Font("맑은 고딕", 12F);
                nLavel_Dis[i].TextAlign = ContentAlignment.TopCenter;
                nLavel_Dis[i].Tag = i;
                Controls.Add(nLavel_Dis[i]);
            }

#if true
            point = nTempLabel.Location;
            point.X = nTempLabel.Location.X + 70;

            for (int i = 0; i < PLCDataTag.ReadSize; i++)
            {

                nLavel[i] = new Label();

                if (i > 399 && i < 500) //     399  , 600
                {
                    if (i == 400) //400
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 399)); //399
                }
                else if (i > 299 && i < 400) //     399  , 600
                //if (i > 299 && i < 400) //     399  , 600
                {
                    if (i == 300) //400
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 299)); //399
                }
                else if (i > 199 && i < 300) //     399  , 600
                {
                    if (i == 200) //400
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 199)); //399
                }
                else if (i > 99 && i < 200) //    199   , 400
                {
                    if (i == 100) //200
                        point.X = point.X + (nTempLabel.Size.Width * 1) + 1;
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i - 99)); //199
                }
                else
                {
                    point.Y = nTempLabel.Location.Y + ((nTempLabel.Size.Height + 1) * (i + 1));
                }


                nLavel[i].Location = point;
                nLavel[i].TabIndex = i;
                nLavel[i].Size = new Size(145, 18);
                nLavel[i].AutoSize = false;
                nLavel[i].BorderStyle = BorderStyle.None;
                nLavel[i].BackColor = Color.LightGray;
                nLavel[i].Font = new Font("맑은 고딕", 12F);
                nLavel[i].TextAlign = ContentAlignment.TopCenter;
                nLavel[i].Click += new System.EventHandler(BTN_TEACH_Click);
                nLavel[i].Tag = i;
                Controls.Add(nLavel[i]);

            }
#endif
            for (int i = 0; i < Main.DEFINE.AlignUnit_Max; i++)
            {

                nLavel_UNIT[i] = new Label();
                nLavel_UNIT[i].Size = new Size(170, 189);

                point.X = LABEL_300_399.Location.X + LABEL_300_399.Size.Width + 2;
                point.Y = LABEL_300_399.Location.Y + ((i + 1) * 190) + (LABEL_300_399.Size.Height + 1);

                point.X = LABEL_400_499.Location.X + LABEL_400_499.Size.Width + 2;
                point.Y = LABEL_400_499.Location.Y + ((i + 1) * 190) + (LABEL_400_499.Size.Height + 1);

                nLavel_UNIT[i].Location = point;

                nLavel_UNIT[i].TabIndex = i;
                nLavel_UNIT[i].AutoSize = false;
                nLavel_UNIT[i].BorderStyle = BorderStyle.None;
                nLavel_UNIT[i].BackColor = Color.WhiteSmoke;
                nLavel_UNIT[i].Font = new Font("맑은 고딕", 12F);
                nLavel_UNIT[i].TextAlign = ContentAlignment.MiddleCenter;
                nLavel_UNIT[i].Tag = i;
                Controls.Add(nLavel_UNIT[i]);
            }

            for (int i = 0; i < PLCDataTag.ReadSize; i++)
            {
                int nNum;
                nNum = i + 1;
                string nLabel = "label" + nNum.ToString();
                Label TempLabel = (Label)this.Controls[nLabel];
                nLavel_Mode.Add(TempLabel);
            }
        }
        private void MemDisplay()
        {
            string nMode;
            int m_Number;

            for (int i = 0; i < PLCDataTag.ReadSize; i++)
            {
                nMode = nLavel_Mode[i].Text;

                m_Number = i;

                if (nMode == "L")
                {
                    int ndata;
                    ndata = (PLCDataTag.RData[m_Number + 1] << 16 | PLCDataTag.RData[m_Number] & 0x0000ffff);
                    nLavel[i].Text = ndata.ToString();
                }
                else if (nMode == "A")
                {
                    char m_CharData;
                    long dataNum;
                    string m_strData;

                    dataNum = PLCDataTag.RData[m_Number] & 0x00ff;
                    m_CharData = Convert.ToChar(dataNum);
                    m_strData = m_CharData.ToString();

                    dataNum = (PLCDataTag.RData[m_Number] >> 8) & 0x00ff;
                    m_CharData = Convert.ToChar(dataNum);
                    m_strData += m_CharData.ToString();

                    nLavel[i].Text = m_strData;
                    nLavel[i].Font = new Font("맑은 고딕", 11F);
                }
                else
                {
                    Int16 ndata;
                    ndata = PLCDataTag.RData[m_Number];
                    nLavel[i].Text = ndata.ToString();
                }
                if (nMode == "H")
                {
                    nLavel[i].Text = "--";
                }
            }
        }
        public void Form_Melsec_Load()
        {
            timer1.Enabled = true;
        }
        private void Form_Melsec_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            formCmd.Show();
        }
    }
}
