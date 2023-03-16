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
    public partial class FormSelectTeaching : Form
    {
        private enum SelectType { PreAling =0, Akkon = 1, AlignInp}
        public FormSelectTeaching()
        {
         
            InitializeComponent();
            this.Size = new System.Drawing.Size(SystemInformation.PrimaryMonitorSize.Width, SystemInformation.PrimaryMonitorSize.Height);
           
        }
        //public Form_PatternTeach PatternTeach = new Form_PatternTeach();
        private void BTN_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BTN_SelectTeaching_Click(object sender, EventArgs e)
        {
            Button btnSelect = (Button)sender;
            int nSelectIndex = Convert.ToInt32(btnSelect.Tag.ToString());
            switch(nSelectIndex)
            {
                case (int)SelectType.PreAling:
                    using (Form_PatternTeach PatternTeach = new Form_PatternTeach())
                    {
                        PatternTeach.m_ToolShow = false;
                        PatternTeach.CamNo = 0;
                        PatternTeach.StageNo = 0;
                        PatternTeach.ShowDialog();
                    }
                    break;
                case (int)SelectType.Akkon:
                    using (Form_AkkonTeaching AkkonTeaching = new Form_AkkonTeaching(0))
                    {
                        AkkonTeaching.IsnStageNo = 0;
                        AkkonTeaching.IsnCamNo = 0;
                        AkkonTeaching.ShowDialog();
                    }
                    break;
                case (int)SelectType.AlignInp:
                    using (Form_AkkonTeaching AkkonTeaching = new Form_AkkonTeaching(1))
                    {
                        AkkonTeaching.IsnStageNo = 0;
                        AkkonTeaching.IsnCamNo = 0;
                        AkkonTeaching.ShowDialog();
                    }
                    break;
            }
        }
    }
}
