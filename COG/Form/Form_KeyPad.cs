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
    public partial class Form_KeyPad : Form
    {
        public Form_KeyPad(double nLow = 0, double nHigh = 10000, double nCurData =0, string DlgName = " ", int nMode = 0)
        {
            InitializeComponent();
            m_low = nLow;
            m_high = nHigh;
            m_data = m_curdata = nCurData;
            DlgStr = DlgName;
            this.Text = DlgStr;
            iMode = nMode;

            //2023 0201 YSH - IP 주소 입력용 모드
            if (iMode == 2)
            {
                BT_MINUS.Visible = false;
            }
        }
        private  int iMode;
        private  double m_low;
        private  double m_high;
        public  double m_data;
        public bool bOK = true;
        private  double m_curdata;
        private  string m_DisplayStr= "";
        private  string DlgStr = "";
        public string m_strData;
      
        private void Form_KeyPad_Load(object sender, EventArgs e)
        {

            LB_DISPLAY.Text = m_data.ToString();
        }

        private void DataUpdate()
        {
            LB_DISPLAY.Text = m_DisplayStr;
        }

        private void BTN_NUM_Click(object sender, EventArgs e)
        {
            Button TempBTN = (Button)sender;
            int m_Number;
            m_Number = TempBTN.TabIndex;
            m_DisplayStr = m_DisplayStr + m_Number.ToString();
            DataUpdate();
        }

        private void BT_CL_Click(object sender, EventArgs e)
        {
            m_DisplayStr = "";
            DataUpdate();
        }

        private void BT_DOT_Click(object sender, EventArgs e)
        {
            m_DisplayStr = m_DisplayStr + ".";
            DataUpdate();
        }

        private void BT_MINUS_Click(object sender, EventArgs e)
        {
            m_DisplayStr = "-" + m_DisplayStr;
            DataUpdate();
        }

        private void BT_ENT_Click(object sender, EventArgs e)
        {
            if (iMode == 2)//2023 0201 YSH - IP 주소 입력용 모드
            {           
                string[] arrStr = m_DisplayStr.Split('.');
                bool bRes = true;
                //1. 입력한 숫자가 4개의 Unit이 아닐 경우
                if (arrStr.Length != 4)
                    bRes = false;

                //2. 각 숫자가 4자리 이상 또는 없을경우
                foreach (string str in arrStr)
                {
                    if((str.Length > 3) || (str.Length == 0))
                    {
                        bRes = false;
                        break;
                    }
                }

                if(bRes == false)
                {
                    MessageBox.Show("Input IP Address Error");
                    m_DisplayStr = "";
                    m_strData = m_DisplayStr;
                    return;
                }
                else
                  m_strData = m_DisplayStr;

            }

            else
            {
                Double.TryParse(m_DisplayStr, out m_data); //String에 소수점이 있더라도 Double로 변환 가능 한 함수. -진욱-    
                if (m_data < m_low || m_data > m_high)
                {
                    string nMessage;
                    nMessage = "Input Data Range: " + m_low + " ~ " + m_high;
                    MessageBox.Show(nMessage);
                    m_data = m_curdata;
                    LB_DISPLAY.Text = m_data.ToString();
                    m_DisplayStr = "";
                    return;
                }
            }
            if (iMode == 1)
            {
                BT_MINUS.Visible = true;
            }
            this.Close();
        }

        private void BT_BACK_Click(object sender, EventArgs e)
        {
            if (m_DisplayStr.Length > 0)
            {
                m_DisplayStr = m_DisplayStr.Substring(0, m_DisplayStr.Length - 1);
                DataUpdate();
            }
        }

        private void BT_CANCEL_Click(object sender, EventArgs e)
        {
            m_data = m_curdata;
            bOK = false;
            if (iMode == 1)
            {
                BT_MINUS.Visible = true;
            }
            this.Close();
        }
    }
}
