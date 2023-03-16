namespace COG.Controls
{
    partial class CtrlMotionOperation
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpMotionOperation = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMotionOperation = new System.Windows.Forms.Panel();
            this.pnlCaption = new System.Windows.Forms.Panel();
            this.tlpCaption = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRepeat = new System.Windows.Forms.Panel();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.pnlJogScale = new System.Windows.Forms.Panel();
            this.lblJogScale = new System.Windows.Forms.Label();
            this.pnlServo = new System.Windows.Forms.Panel();
            this.lblServo = new System.Windows.Forms.Label();
            this.pnlAxisStatus = new System.Windows.Forms.Panel();
            this.lblAxisStatus = new System.Windows.Forms.Label();
            this.pnlTargetPosition = new System.Windows.Forms.Panel();
            this.lblTargetPosition = new System.Windows.Forms.Label();
            this.pnlAxisName = new System.Windows.Forms.Panel();
            this.lblAxis = new System.Windows.Forms.Label();
            this.pnlOffset = new System.Windows.Forms.Panel();
            this.lblOffset = new System.Windows.Forms.Label();
            this.pnlCurrentPosition = new System.Windows.Forms.Panel();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.pnlSensor = new System.Windows.Forms.Panel();
            this.lblSensor = new System.Windows.Forms.Label();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblHome = new System.Windows.Forms.Label();
            this.pnlMoveTo = new System.Windows.Forms.Panel();
            this.lblMoveTo = new System.Windows.Forms.Label();
            this.pnlJog = new System.Windows.Forms.Panel();
            this.lblJog = new System.Windows.Forms.Label();
            this.tlpMotionOperation.SuspendLayout();
            this.pnlCaption.SuspendLayout();
            this.tlpCaption.SuspendLayout();
            this.pnlRepeat.SuspendLayout();
            this.pnlJogScale.SuspendLayout();
            this.pnlServo.SuspendLayout();
            this.pnlAxisStatus.SuspendLayout();
            this.pnlTargetPosition.SuspendLayout();
            this.pnlAxisName.SuspendLayout();
            this.pnlOffset.SuspendLayout();
            this.pnlCurrentPosition.SuspendLayout();
            this.pnlSensor.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.pnlMoveTo.SuspendLayout();
            this.pnlJog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionOperation
            // 
            this.tlpMotionOperation.ColumnCount = 2;
            this.tlpMotionOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMotionOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionOperation.Controls.Add(this.pnlMotionOperation, 1, 0);
            this.tlpMotionOperation.Controls.Add(this.pnlCaption, 0, 0);
            this.tlpMotionOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionOperation.Location = new System.Drawing.Point(0, 0);
            this.tlpMotionOperation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionOperation.Name = "tlpMotionOperation";
            this.tlpMotionOperation.RowCount = 1;
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionOperation.Size = new System.Drawing.Size(800, 720);
            this.tlpMotionOperation.TabIndex = 1;
            // 
            // pnlMotionOperation
            // 
            this.pnlMotionOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMotionOperation.Location = new System.Drawing.Point(200, 0);
            this.pnlMotionOperation.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMotionOperation.Name = "pnlMotionOperation";
            this.pnlMotionOperation.Size = new System.Drawing.Size(600, 720);
            this.pnlMotionOperation.TabIndex = 0;
            // 
            // pnlCaption
            // 
            this.pnlCaption.Controls.Add(this.tlpCaption);
            this.pnlCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCaption.Location = new System.Drawing.Point(0, 0);
            this.pnlCaption.Margin = new System.Windows.Forms.Padding(0);
            this.pnlCaption.Name = "pnlCaption";
            this.pnlCaption.Size = new System.Drawing.Size(200, 720);
            this.pnlCaption.TabIndex = 1;
            // 
            // tlpCaption
            // 
            this.tlpCaption.ColumnCount = 1;
            this.tlpCaption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCaption.Controls.Add(this.pnlRepeat, 0, 11);
            this.tlpCaption.Controls.Add(this.pnlJogScale, 0, 10);
            this.tlpCaption.Controls.Add(this.pnlServo, 0, 6);
            this.tlpCaption.Controls.Add(this.pnlAxisStatus, 0, 5);
            this.tlpCaption.Controls.Add(this.pnlTargetPosition, 0, 1);
            this.tlpCaption.Controls.Add(this.pnlAxisName, 0, 0);
            this.tlpCaption.Controls.Add(this.pnlOffset, 0, 2);
            this.tlpCaption.Controls.Add(this.pnlCurrentPosition, 0, 3);
            this.tlpCaption.Controls.Add(this.pnlSensor, 0, 4);
            this.tlpCaption.Controls.Add(this.pnlHome, 0, 7);
            this.tlpCaption.Controls.Add(this.pnlMoveTo, 0, 8);
            this.tlpCaption.Controls.Add(this.pnlJog, 0, 9);
            this.tlpCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCaption.Location = new System.Drawing.Point(0, 0);
            this.tlpCaption.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCaption.Name = "tlpCaption";
            this.tlpCaption.RowCount = 12;
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCaption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpCaption.Size = new System.Drawing.Size(200, 720);
            this.tlpCaption.TabIndex = 1;
            // 
            // pnlRepeat
            // 
            this.pnlRepeat.Controls.Add(this.lblRepeat);
            this.pnlRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRepeat.Location = new System.Drawing.Point(3, 563);
            this.pnlRepeat.Name = "pnlRepeat";
            this.pnlRepeat.Size = new System.Drawing.Size(194, 154);
            this.pnlRepeat.TabIndex = 16;
            // 
            // lblRepeat
            // 
            this.lblRepeat.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeat.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeat.Location = new System.Drawing.Point(0, 0);
            this.lblRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(194, 154);
            this.lblRepeat.TabIndex = 3;
            this.lblRepeat.Text = "Repeat";
            this.lblRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlJogScale
            // 
            this.pnlJogScale.Controls.Add(this.lblJogScale);
            this.pnlJogScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJogScale.Location = new System.Drawing.Point(3, 523);
            this.pnlJogScale.Name = "pnlJogScale";
            this.pnlJogScale.Size = new System.Drawing.Size(194, 34);
            this.pnlJogScale.TabIndex = 15;
            // 
            // lblJogScale
            // 
            this.lblJogScale.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblJogScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogScale.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblJogScale.Location = new System.Drawing.Point(0, 0);
            this.lblJogScale.Margin = new System.Windows.Forms.Padding(0);
            this.lblJogScale.Name = "lblJogScale";
            this.lblJogScale.Size = new System.Drawing.Size(194, 34);
            this.lblJogScale.TabIndex = 3;
            this.lblJogScale.Text = "Jog Scale";
            this.lblJogScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlServo
            // 
            this.pnlServo.Controls.Add(this.lblServo);
            this.pnlServo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlServo.Location = new System.Drawing.Point(3, 243);
            this.pnlServo.Name = "pnlServo";
            this.pnlServo.Size = new System.Drawing.Size(194, 34);
            this.pnlServo.TabIndex = 11;
            // 
            // lblServo
            // 
            this.lblServo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblServo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblServo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblServo.Location = new System.Drawing.Point(0, 0);
            this.lblServo.Margin = new System.Windows.Forms.Padding(0);
            this.lblServo.Name = "lblServo";
            this.lblServo.Size = new System.Drawing.Size(194, 34);
            this.lblServo.TabIndex = 3;
            this.lblServo.Text = "Servo On/Off";
            this.lblServo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAxisStatus
            // 
            this.pnlAxisStatus.Controls.Add(this.lblAxisStatus);
            this.pnlAxisStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAxisStatus.Location = new System.Drawing.Point(3, 203);
            this.pnlAxisStatus.Name = "pnlAxisStatus";
            this.pnlAxisStatus.Size = new System.Drawing.Size(194, 34);
            this.pnlAxisStatus.TabIndex = 9;
            // 
            // lblAxisStatus
            // 
            this.lblAxisStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAxisStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisStatus.Location = new System.Drawing.Point(0, 0);
            this.lblAxisStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblAxisStatus.Name = "lblAxisStatus";
            this.lblAxisStatus.Size = new System.Drawing.Size(194, 34);
            this.lblAxisStatus.TabIndex = 1;
            this.lblAxisStatus.Text = "Axis Status";
            this.lblAxisStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTargetPosition
            // 
            this.pnlTargetPosition.Controls.Add(this.lblTargetPosition);
            this.pnlTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTargetPosition.Location = new System.Drawing.Point(3, 43);
            this.pnlTargetPosition.Name = "pnlTargetPosition";
            this.pnlTargetPosition.Size = new System.Drawing.Size(194, 34);
            this.pnlTargetPosition.TabIndex = 6;
            // 
            // lblTargetPosition
            // 
            this.lblTargetPosition.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTargetPosition.Location = new System.Drawing.Point(0, 0);
            this.lblTargetPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblTargetPosition.Name = "lblTargetPosition";
            this.lblTargetPosition.Size = new System.Drawing.Size(194, 34);
            this.lblTargetPosition.TabIndex = 1;
            this.lblTargetPosition.Text = "Target Position";
            this.lblTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAxisName
            // 
            this.pnlAxisName.Controls.Add(this.lblAxis);
            this.pnlAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAxisName.Location = new System.Drawing.Point(3, 3);
            this.pnlAxisName.Name = "pnlAxisName";
            this.pnlAxisName.Size = new System.Drawing.Size(194, 34);
            this.pnlAxisName.TabIndex = 5;
            // 
            // lblAxis
            // 
            this.lblAxis.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblAxis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxis.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxis.Location = new System.Drawing.Point(0, 0);
            this.lblAxis.Margin = new System.Windows.Forms.Padding(0);
            this.lblAxis.Name = "lblAxis";
            this.lblAxis.Size = new System.Drawing.Size(194, 34);
            this.lblAxis.TabIndex = 0;
            this.lblAxis.Text = "Axis";
            this.lblAxis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlOffset
            // 
            this.pnlOffset.Controls.Add(this.lblOffset);
            this.pnlOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOffset.Location = new System.Drawing.Point(3, 83);
            this.pnlOffset.Name = "pnlOffset";
            this.pnlOffset.Size = new System.Drawing.Size(194, 34);
            this.pnlOffset.TabIndex = 7;
            // 
            // lblOffset
            // 
            this.lblOffset.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOffset.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblOffset.Location = new System.Drawing.Point(0, 0);
            this.lblOffset.Margin = new System.Windows.Forms.Padding(0);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(194, 34);
            this.lblOffset.TabIndex = 2;
            this.lblOffset.Text = "Offset";
            this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCurrentPosition
            // 
            this.pnlCurrentPosition.Controls.Add(this.lblCurrentPosition);
            this.pnlCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCurrentPosition.Location = new System.Drawing.Point(3, 123);
            this.pnlCurrentPosition.Name = "pnlCurrentPosition";
            this.pnlCurrentPosition.Size = new System.Drawing.Size(194, 34);
            this.pnlCurrentPosition.TabIndex = 8;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPosition.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentPosition.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(194, 34);
            this.lblCurrentPosition.TabIndex = 3;
            this.lblCurrentPosition.Text = "Current Position";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSensor
            // 
            this.pnlSensor.Controls.Add(this.lblSensor);
            this.pnlSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSensor.Location = new System.Drawing.Point(3, 163);
            this.pnlSensor.Name = "pnlSensor";
            this.pnlSensor.Size = new System.Drawing.Size(194, 34);
            this.pnlSensor.TabIndex = 10;
            // 
            // lblSensor
            // 
            this.lblSensor.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSensor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSensor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSensor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSensor.Location = new System.Drawing.Point(0, 0);
            this.lblSensor.Margin = new System.Windows.Forms.Padding(0);
            this.lblSensor.Name = "lblSensor";
            this.lblSensor.Size = new System.Drawing.Size(194, 34);
            this.lblSensor.TabIndex = 3;
            this.lblSensor.Text = "Sensor";
            this.lblSensor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.lblHome);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(3, 283);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(194, 34);
            this.pnlHome.TabIndex = 12;
            // 
            // lblHome
            // 
            this.lblHome.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHome.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblHome.Location = new System.Drawing.Point(0, 0);
            this.lblHome.Margin = new System.Windows.Forms.Padding(0);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(194, 34);
            this.lblHome.TabIndex = 3;
            this.lblHome.Text = "Home";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMoveTo
            // 
            this.pnlMoveTo.Controls.Add(this.lblMoveTo);
            this.pnlMoveTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoveTo.Location = new System.Drawing.Point(3, 323);
            this.pnlMoveTo.Name = "pnlMoveTo";
            this.pnlMoveTo.Size = new System.Drawing.Size(194, 34);
            this.pnlMoveTo.TabIndex = 13;
            // 
            // lblMoveTo
            // 
            this.lblMoveTo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblMoveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMoveTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveTo.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMoveTo.Location = new System.Drawing.Point(0, 0);
            this.lblMoveTo.Margin = new System.Windows.Forms.Padding(0);
            this.lblMoveTo.Name = "lblMoveTo";
            this.lblMoveTo.Size = new System.Drawing.Size(194, 34);
            this.lblMoveTo.TabIndex = 3;
            this.lblMoveTo.Text = "Move To";
            this.lblMoveTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlJog
            // 
            this.pnlJog.Controls.Add(this.lblJog);
            this.pnlJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJog.Location = new System.Drawing.Point(3, 363);
            this.pnlJog.Name = "pnlJog";
            this.pnlJog.Size = new System.Drawing.Size(194, 154);
            this.pnlJog.TabIndex = 14;
            // 
            // lblJog
            // 
            this.lblJog.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblJog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJog.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblJog.Location = new System.Drawing.Point(0, 0);
            this.lblJog.Margin = new System.Windows.Forms.Padding(0);
            this.lblJog.Name = "lblJog";
            this.lblJog.Size = new System.Drawing.Size(194, 154);
            this.lblJog.TabIndex = 3;
            this.lblJog.Text = "Jog";
            this.lblJog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlMotionOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpMotionOperation);
            this.Name = "CtrlMotionOperation";
            this.Size = new System.Drawing.Size(800, 720);
            this.Load += new System.EventHandler(this.CtrlMotionOperation_Load);
            this.tlpMotionOperation.ResumeLayout(false);
            this.pnlCaption.ResumeLayout(false);
            this.tlpCaption.ResumeLayout(false);
            this.pnlRepeat.ResumeLayout(false);
            this.pnlJogScale.ResumeLayout(false);
            this.pnlServo.ResumeLayout(false);
            this.pnlAxisStatus.ResumeLayout(false);
            this.pnlTargetPosition.ResumeLayout(false);
            this.pnlAxisName.ResumeLayout(false);
            this.pnlOffset.ResumeLayout(false);
            this.pnlCurrentPosition.ResumeLayout(false);
            this.pnlSensor.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.pnlMoveTo.ResumeLayout(false);
            this.pnlJog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionOperation;
        private System.Windows.Forms.Panel pnlMotionOperation;
        private System.Windows.Forms.Panel pnlCaption;
        private System.Windows.Forms.TableLayoutPanel tlpCaption;
        private System.Windows.Forms.Panel pnlJogScale;
        private System.Windows.Forms.Label lblJogScale;
        private System.Windows.Forms.Panel pnlServo;
        private System.Windows.Forms.Label lblServo;
        private System.Windows.Forms.Panel pnlAxisStatus;
        private System.Windows.Forms.Label lblAxisStatus;
        private System.Windows.Forms.Panel pnlTargetPosition;
        private System.Windows.Forms.Label lblTargetPosition;
        private System.Windows.Forms.Panel pnlAxisName;
        private System.Windows.Forms.Label lblAxis;
        private System.Windows.Forms.Panel pnlOffset;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Panel pnlCurrentPosition;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Panel pnlSensor;
        private System.Windows.Forms.Label lblSensor;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel pnlMoveTo;
        private System.Windows.Forms.Label lblMoveTo;
        private System.Windows.Forms.Panel pnlJog;
        private System.Windows.Forms.Label lblJog;
        private System.Windows.Forms.Panel pnlRepeat;
        private System.Windows.Forms.Label lblRepeat;
    }
}
