using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.FormVisionTeach;

namespace COG.Controls
{
    public partial class CtrlInspectionItem : UserControl
    {
        private eTeachingItem _inspectionItem = eTeachingItem.Mark;

        public CtrlInspectionItem(eTeachingItem inspectionItem)
        {
            InitializeComponent();

            _inspectionItem = inspectionItem;
        }

        private void CtrlInspectionItem_Load(object sender, EventArgs e)
        {
            InitializeUI(_inspectionItem);
        }

        private void InitializeUI(eTeachingItem inspectionItem)
        {
            chkInspectionItem.Text = inspectionItem.ToString().ToUpper();
            chkInspectionItem.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
        }

        public delegate void SetInspectionItemDelegate(eTeachingItem inspectionItem, object obj);
        public event SetInspectionItemDelegate SendEventHandler;

        public void ShowInspectionItem(bool isSelected)
        {
            if (isSelected)
                this.chkInspectionItem.BackColor = Color.LimeGreen;
            else
                this.chkInspectionItem.BackColor = Color.DarkGray;
        }

        public void SetInspectionItem(bool isSelected)
        {
            try
            {
                //if (chkInspectionItem.CheckState == CheckState.Checked)
                //    this.chkInspectionItem.BackColor = Color.LimeGreen;
                //else
                //    this.chkInspectionItem.BackColor = Color.DarkGray;

                if (isSelected)
                {
                    chkInspectionItem.Checked = true;
                    this.chkInspectionItem.BackColor = Color.LimeGreen;
                }
                else
                {
                    chkInspectionItem.Checked = false;
                    this.chkInspectionItem.BackColor = Color.DarkGray;
                }


                //if (this.chkInspectionItem.Checked)
                //    this.chkInspectionItem.BackColor = Color.LimeGreen;
                //else
                //    this.chkInspectionItem.BackColor = Color.DarkGray;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void chkInspectionItem_CheckedChanged(object sender, EventArgs e)
        {
            //SendEventHandler(_inspectionItem, sender);
        }

        private void chkInspectionItem_Click(object sender, EventArgs e)
        {
            SendEventHandler(_inspectionItem, sender);
        }
    }
}
