using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COG.Class.MOTION;
using COG.Class;

namespace COG.Controls
{
    public partial class CtrlMotionParameterCommon : UserControl
    {
        private eAxis _axis = eAxis.None;
        public CtrlMotionParameterCommon(eAxis axis)
        {
            InitializeComponent();
            SetAxis(axis);
        }

        private void SetAxis(eAxis axis)
        {
            _axis = axis;
        }

        public void SetDisplayParameter(eTeachingPosition teachingPosition)
        {
            lblJogLowSpeedValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogLowSpeed.ToString();
            lblJogHighSpeedValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogHighSpeed.ToString();
            lblMoveToleranceValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MoveTolerance.ToString();

            lblNegativeLimitValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.PositiveSWLimit.ToString();
            lblPositiveLimitValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.NegativeSWLimit.ToString();
            lblHomingTimeOutValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.HomingTimeOut.ToString();
        }

        public void SetParameter(eTeachingPosition teachingPosition)
        {
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogLowSpeed = Convert.ToDouble(lblJogLowSpeedValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogHighSpeed = Convert.ToDouble(lblJogHighSpeedValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MoveTolerance = Convert.ToDouble(lblMoveToleranceValue.Text);

            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.PositiveSWLimit = Convert.ToDouble(lblNegativeLimitValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.NegativeSWLimit = Convert.ToDouble(lblPositiveLimitValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.HomingTimeOut = Convert.ToDouble(lblHomingTimeOutValue.Text);
        }

        private void Value_Changed(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void SetLabelDoubleData(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double inputData = formKeyPad.m_data;

            Label label = (Label)sender;
            label.Text = inputData.ToString();
        }
    }
}
