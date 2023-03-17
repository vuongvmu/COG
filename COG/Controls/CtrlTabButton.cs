using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG.Controls
{
    public partial class CtrlTabButton : UserControl
    {
        private int _tabNumber = -1;

        public CtrlTabButton(int index)
        {
            InitializeComponent();

            InitializeUI(_tabNumber = index);
        }

        private void InitializeUI(int index)
        {
            chkTabButton.BackColor = Color.DarkGray;
            this.chkTabButton.Text = "TAB " + (index + 1).ToString();
            this.chkTabButton.Font = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        }

        public delegate void SetTabNumberDelegate(bool selected, int tabNumber);
        public event SetTabNumberDelegate SendEventHandler;

        private void chkTabButton_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkTabButton.Checked)
            //{
            //    Console.WriteLine("Tab Index : " + _tabNumber.ToString());
            //    SendEventHandler(chkTabButton.Checked, _tabNumber);
            //    chkTabButton.BackColor = SystemColors.ControlDark;
            //}
            //else 
            //{
            //    Console.WriteLine("Tab Index : " + _tabNumber.ToString());
            //    SendEventHandler(chkTabButton.Checked, _tabNumber);
            //    chkTabButton.BackColor = SystemColors.Control;
            //}

            Console.WriteLine("Tab Index : " + _tabNumber.ToString());
            SendEventHandler(chkTabButton.Checked, _tabNumber);
            //chkTabButton.BackColor = SystemColors.ControlDark;

            //선택한 버튼 외 색상 초기화 동작 필요
        }

        public void SetButtonStatus(bool isSelected)
        {
            if (isSelected)
                this.chkTabButton.BackColor = SystemColors.ControlDark;
            else
                this.chkTabButton.BackColor = Color.DarkGray;
        }
    }
}
