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
    public partial class CtrlMotionParameterVariable : UserControl
    {
        private eAxis _axis = eAxis.None;
        public CtrlMotionParameterVariable(eAxis axis)
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
            lblVelocityValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Velocity.ToString();
            lblAccelerationTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Acceleration.ToString();
            lblDecelerationTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Deceleration.ToString();

            lblMovingTimeOutValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MovingTimeOut.ToString();
            lblAfterWaitTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.AfterWaitTime.ToString();
        }

        public void SetParameter(eTeachingPosition teachingPosition)
        {
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Velocity = Convert.ToDouble(lblVelocityValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Acceleration = Convert.ToDouble(lblAccelerationTimeValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Deceleration = Convert.ToDouble(lblDecelerationTimeValue.Text);

            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MovingTimeOut = Convert.ToDouble(lblMovingTimeOutValue.Text);
            Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.AfterWaitTime = Convert.ToDouble(lblAfterWaitTimeValue.Text);
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
