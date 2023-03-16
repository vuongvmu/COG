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
    public partial class CtrlTeachROIJog : UserControl
    {
        private eTeachingItem _inspectionItem = eTeachingItem.Mark;// = eTeachType.AutoFocus;

        public CtrlTeachROIJog()
        {
            InitializeComponent();
        }

        //private eSkewType _skewType = eSkewType.CCW;
        //private eMoveDirection _directionMove = eMoveDirection.UP;
        //private eSizeDirection _directionSize = eSizeDirection.IncreaseUpDown;
        private eJogType _jogType = eJogType.Move;
        private eJogTarget _jogTarget = eJogTarget.Mark;

        public enum eSkewType
        {
            CCW,
            Zero,
            CW,
        }

        public enum eMoveDirection
        {
            Up,
            Down,
            Left,
            Right,
        }

        public enum eSizeDirection
        {
            IncreaseUpDown,     //Increase UpDown
            DecreaseUpDown,     //Decrease UpDown    
            IncreaseLeftRight,  //Increase LeftRight
            DecreaseLeftRight,  //Decrease LeftRight
        }

        public enum eJogType
        {
            Move,
            Size,
        }

        public enum eJogTarget
        {
            Mark,
            Origin,
        }

        private void CtrlTeachROIJog_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            rdoMove.Checked = true;
            rdoMark.Checked = true;
        }

        private void btnSelectSkew_Click(object sender, EventArgs e)
        {
            SendEventHandler(sender);
        }

        public void btnDirectionMove_Click(object sender, EventArgs e)
        {
            SendEventHandler(sender);
        }

        private void btnDirectionSize_Click(object sender, EventArgs e)
        {
            SendEventHandler(sender);
        }

        private void rdoSelectMoveSize_CheckedChanged(object sender, EventArgs e)
        {
            SelectMoveSize(sender);
        }

        private void SelectMoveSize(object sender)
        {
            RadioButton btn = sender as RadioButton;

            _jogType = (eJogType)Enum.Parse(typeof(eJogType), btn.Text.Replace(" ", ""));

            switch(_jogType)
            {
                case eJogType.Move:
                    ClickMove();
                    break;

                case eJogType.Size:
                    ClickSize();
                    break;

                default:
                    break;
            }

            if (btn.Checked && btn.Text.Replace(" ", "") == _jogType.ToString())
                btn.BackColor = Color.LimeGreen;
            else
                btn.BackColor = Color.DarkGray;
        }

        private void ClickMove()
        {
            pnlDirectionMove.Visible = true;
            pnlDirectionSize.Visible = false;
        }

        private void ClickSize()
        {
            pnlDirectionMove.Visible = false;
            pnlDirectionSize.Visible = true;
        }

        private void rdoSelectMarkOrigin_CheckedChanged(object sender, EventArgs e)
        {
            SelectMarkOrigin(sender);
        }

        private void SelectMarkOrigin(object sender)
        {
            RadioButton btn = sender as RadioButton;

            _jogTarget = (eJogTarget)Enum.Parse(typeof(eJogTarget), btn.Text.Replace(" ", ""));

            switch(_jogTarget)
            {
                case eJogTarget.Mark:
                    ClickMark();
                    break;

                case eJogTarget.Origin:
                    ClickOrigin();
                    break;

                default:
                    break;
            }

            if (btn.Checked && btn.Text.Replace(" ", "") == _jogTarget.ToString())
                btn.BackColor = Color.LimeGreen;
            else
                btn.BackColor = Color.DarkGray;
        }

        private void ClickMark()
        {

        }

        private void ClickOrigin()
        {

        }

        private void lblJogScale_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void SetLabelIntegerData(object sender)
        {
            Label lbl = sender as Label;
            int outputData = 0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = Convert.ToInt32(formKeyPad.m_data);
            lbl.Text = outputData.ToString();
        }

        public delegate void SendClickEventDelegate(object sender);
        public event SendClickEventDelegate SendEventHandler;
    }
}
