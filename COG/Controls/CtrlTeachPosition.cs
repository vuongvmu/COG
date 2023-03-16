using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COG.Class;
using COG.Class.MOTION;

namespace COG.Controls
{
    public partial class CtrlTeachPosition : UserControl
    {
        private eTeachingPosition _teachingPosition = eTeachingPosition.Standby;
        //private CtrlTeachMotion tt = new CtrlTeachMotion(eAxis.Axis_X);

        public CtrlTeachPosition(eTeachingPosition teachingPosition)
        {
            InitializeComponent();

            _teachingPosition = teachingPosition;
        }

        private void CtrlTeachPosition_Load(object sender, EventArgs e)
        {
            InitializeUI(_teachingPosition);
        }

        private void InitializeUI(eTeachingPosition teachingPosition)
        {
            //_teachingPosition = teachingPosition;
            chkTeachingPosition.Text = teachingPosition.ToString().ToUpper().Replace("_", "\r\n");
        }

        public delegate void SetTeachingListDelegate(eTeachingPosition teachingPosition);
        public event SetTeachingListDelegate SendEventHandler;

        public void SetButtonStatus(bool isSelected)
        {
            if (isSelected)
            {
                this.chkTeachingPosition.BackColor = Color.LimeGreen;
                TeachingPosition.Instance().SelectedTeachingPosition = _teachingPosition;
            }
            else
                this.chkTeachingPosition.BackColor = Color.Silver;
        }

        private void chkTeachingPosition_CheckedChanged(object sender, EventArgs e)
        {
            SendEventHandler(_teachingPosition);
        }
    }
}
