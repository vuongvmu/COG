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
    public partial class CtrlTeachJog : UserControl
    {
        public CtrlTeachJog()
        {
            InitializeComponent();
        }

        private eSkewType _skewType = eSkewType.btnSkewCCW;
        private eDirectionMove _directionMove = eDirectionMove.UP;
        private eDirectionSize _directionSize = eDirectionSize.btnSizeIncreaseUpDown;
        private eJogType _jogType = eJogType.Move;
        private eJogTarget _jogTarget = eJogTarget.Mark;

        public enum eSkewType
        {
            btnSkewCCW,
            btnSkewZero,
            btnSkewCW,
        }

        public enum eDirectionMove
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
        }

        public enum eDirectionSize
        {
            btnSizeIncreaseUpDown,      //Increase UpDown
            btnSizeDecreaseUpDown,    //Decrease UpDown    
            btnSizeDecreaseLeftRight,    //Decrease LeftRight
            btnSizeIncreaseLeftRight,   //Increase LeftRight
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

        private void btnSelectSkew_Click(object sender, EventArgs e)
        {
            SelectDirectionSkew(sender);
        }

        private void SelectDirectionSkew(object sender)
        {
            Button btn = sender as Button;

            _skewType = (eSkewType)Enum.Parse(typeof(eSkewType), btn.Name.Replace(" ", ""));

            switch (_skewType)
            {
                case eSkewType.btnSkewCCW:
                    ClickSkewCCW();
                    break;

                case eSkewType.btnSkewZero:
                    ClickSkewZero();
                    break;

                case eSkewType.btnSkewCW:
                    ClickSkewCW();
                    break;

                default:
                    break;
            }
        }

        private void ClickSkewCCW()
        {

        }

        private void ClickSkewZero()
        {

        }

        private void ClickSkewCW()
        {

        }

        private void btnDirectionMove_Click(object sender, EventArgs e)
        {
            SelectDirectionMove(sender);
        }

        private void SelectDirectionMove(object sender)
        {
            Button btn = sender as Button;

            _directionMove = (eDirectionMove)Enum.Parse(typeof(eDirectionMove), btn.Text.Replace(" ", ""));

            switch (_directionMove)
            {
                case eDirectionMove.UP:
                    ClickMoveUp();
                    break;

                case eDirectionMove.DOWN:
                    ClickMoveDown();
                    break;

                case eDirectionMove.LEFT:
                    ClickMoveLeft();
                    break;

                case eDirectionMove.RIGHT:
                    ClickMoveRight();
                    break;

                default:
                    break;
            }
        }

        private void ClickMoveUp()
        {

        }

        private void ClickMoveDown()
        {

        }

        private void ClickMoveLeft()
        {

        }

        private void ClickMoveRight()
        {

        }
        private void btnDirectionSize_Click(object sender, EventArgs e)
        {
            SelectDirectionSize(sender);
        }


        private void SelectDirectionSize(object sender)
        {
            Button btn = sender as Button;

            _directionSize = (eDirectionSize)Enum.Parse(typeof(eDirectionSize), btn.Name.Replace(" ", ""));

            switch(_directionSize)
            {
                case eDirectionSize.btnSizeIncreaseUpDown:
                    ClickIncreaseUpDown();
                    break;

                case eDirectionSize.btnSizeDecreaseUpDown:
                    ClickDecreaseUpDown();
                    break;

                case eDirectionSize.btnSizeDecreaseLeftRight:
                    ClickDecreaseLeftRight();
                    break;

                case eDirectionSize.btnSizeIncreaseLeftRight:
                    ClickIncreaseLeftRight();
                    break;

                default:
                    break;

            }
        }

        private void ClickIncreaseUpDown()
        {

        }
        private void ClickDecreaseUpDown()
        {

        }
        private void ClickDecreaseLeftRight()
        {

        }
        private void ClickIncreaseLeftRight()
        {

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
                btn.BackColor = Color.DarkRed;
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
                btn.BackColor = Color.DarkRed;
            else
                btn.BackColor = Color.DarkGray;
        }

        private void ClickMark()
        {

        }

        private void ClickOrigin()
        {

        }

        private void nudMovePixel_Click(object sender, EventArgs e)
        {
            int nMovePixelCount = Convert.ToInt32(nudMovePixel.Value);

            using (Form_KeyPad form_keypad = new Form_KeyPad(1, 10000, nMovePixelCount, "Input Move Pixel Count", 1))
            {
                form_keypad.ShowDialog();
                nMovePixelCount = (int)form_keypad.m_data;
                nudMovePixel.Value = Convert.ToInt32(nMovePixelCount.ToString());
            }
        }

    }
}
