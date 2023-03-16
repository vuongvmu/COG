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
    public partial class CtrlMotionParameter : UserControl
    {
        private eAxis _axis = eAxis.None;
        private CtrlMotionParameterVariable _variableParamControl = null;
        private CtrlMotionParameterCommon _commonParamControl = null;

        public CtrlMotionParameter(eAxis axis)
        {
            InitializeComponent();
            SetAxis(axis);
        }

        private void SetAxis(eAxis axis)
        {
            _axis = axis;
        }

        private void CtrlTeachMotion_Load(object sender, EventArgs e)
        {
            InitializeUI(_axis);
            AddControl();
            SetDisplayParameter(TeachingPosition.Instance().SelectedTeachingPosition);
        }

        private void InitializeUI(eAxis axis)
        {
            grpMotionParameter.Text = axis.ToString().ToUpper().Replace("_", " ") + " SET-UP";
        }

        private void AddControl()
        {
            _variableParamControl = new CtrlMotionParameterVariable(_axis);
            _variableParamControl.Dock = DockStyle.Fill;
            tlpMotionParameter.Controls.Add(_variableParamControl, 0, 0);

            _commonParamControl = new CtrlMotionParameterCommon(_axis);
            _commonParamControl.Dock = DockStyle.Fill;
            tlpMotionParameter.Controls.Add(_commonParamControl, 0, 1);

        }

        public void SetDisplayParameter(eTeachingPosition teachingPosition)
        {
            _variableParamControl.SetDisplayParameter(teachingPosition);
            _commonParamControl.SetDisplayParameter(teachingPosition);
            //lblJogLowSpeedValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogLowSpeed.ToString();
            //lblJogHighSpeedValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogHighSpeed.ToString();
            //lblMovingTimeOutValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MovingTimeOut.ToString();

            //lblVelocityValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Velocity.ToString();
            //lblAccelerationTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Acceleration.ToString();
            //lblDecelerationTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Deceleration.ToString();

            //lblNegativeLimitValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.PositiveSWLimit.ToString();
            //lblPositiveLimitValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.NegativeSWLimit.ToString();
            //lblMoveToleranceValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MoveTolerance.ToString();

            //lblAfterWaitTimeValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.AfterWaitTime.ToString();
            //lblHomingTimeOutValue.Text = Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.HomingTimeOut.ToString();
        }

        public void SetParameter(eTeachingPosition teachingPosition)
        {
            _variableParamControl.SetParameter(teachingPosition);
            _commonParamControl.SetParameter(teachingPosition);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogLowSpeed = Convert.ToDouble(lblJogLowSpeedValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.JogHighSpeed = Convert.ToDouble(lblJogHighSpeedValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MovingTimeOut = Convert.ToDouble(lblMovingTimeOutValue.Text);

            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Velocity = Convert.ToDouble(lblVelocityValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Acceleration = Convert.ToDouble(lblAccelerationTimeValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.Deceleration = Convert.ToDouble(lblDecelerationTimeValue.Text);

            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.PositiveSWLimit = Convert.ToDouble(lblNegativeLimitValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.NegativeSWLimit = Convert.ToDouble(lblPositiveLimitValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.MoveTolerance = Convert.ToDouble(lblMoveToleranceValue.Text);

            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.AfterWaitTime = Convert.ToDouble(lblAfterWaitTimeValue.Text);
            //Main.TeachingPositionList[(int)teachingPosition].UnitPositionList[(int)_axis].MotionProperty.HomingTimeOut = Convert.ToDouble(lblHomingTimeOutValue.Text);
        }

        //private void Value_Changed(object sender, EventArgs e)
        //{
        //    SetLabelDoubleData(sender);
        //}

        //private void SetLabelDoubleData(object sender)
        //{
        //    Form_KeyPad formKeyPad = new Form_KeyPad();
        //    formKeyPad.ShowDialog();

        //    double inputData = formKeyPad.m_data;

        //    Label label = (Label)sender;
        //    label.Text = inputData.ToString();
        //}
    }
}
