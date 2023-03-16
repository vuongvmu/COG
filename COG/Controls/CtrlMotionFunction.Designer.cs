namespace COG.Controls
{
    partial class CtrlMotionFunction
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
            this.pnlMoveTargetPosition = new System.Windows.Forms.Panel();
            this.btnMoveTargetPosition = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.tlpServoStatus = new System.Windows.Forms.TableLayoutPanel();
            this.btnServoOff = new System.Windows.Forms.Button();
            this.btnServoOn = new System.Windows.Forms.Button();
            this.pnlAxisStatus = new System.Windows.Forms.Panel();
            this.lblAxisStatus = new System.Windows.Forms.Label();
            this.pnlTargetPosition = new System.Windows.Forms.Panel();
            this.lblTargetPosition = new System.Windows.Forms.Label();
            this.tlpSensorStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblNegativeLimit = new System.Windows.Forms.Label();
            this.lblPositiveLimit = new System.Windows.Forms.Label();
            this.pnlAxisName = new System.Windows.Forms.Panel();
            this.lblAxisName = new System.Windows.Forms.Label();
            this.pnlOffset = new System.Windows.Forms.Panel();
            this.lblOffset = new System.Windows.Forms.Label();
            this.pnlCurrentPosition = new System.Windows.Forms.Panel();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.tlpJog = new System.Windows.Forms.TableLayoutPanel();
            this.btnJogUp = new System.Windows.Forms.Button();
            this.btnJogLeft = new System.Windows.Forms.Button();
            this.btnJogRight = new System.Windows.Forms.Button();
            this.btnJogDown = new System.Windows.Forms.Button();
            this.btnJogStop = new System.Windows.Forms.Button();
            this.tlpJogScaleMode = new System.Windows.Forms.TableLayoutPanel();
            this.btnJogScaleValue = new System.Windows.Forms.Button();
            this.lblJogScale = new System.Windows.Forms.Label();
            this.tlpRepeatMode = new System.Windows.Forms.TableLayoutPanel();
            this.btnRepeatStart = new System.Windows.Forms.Button();
            this.btnRepeatStop = new System.Windows.Forms.Button();
            this.lblRepeatRemain = new System.Windows.Forms.Label();
            this.lblRepeatCount = new System.Windows.Forms.Label();
            this.lblRepeatStart = new System.Windows.Forms.Label();
            this.lblRepeatTarget = new System.Windows.Forms.Label();
            this.lblRepeatStartPosition = new System.Windows.Forms.Label();
            this.lblRepeatTargetPosition = new System.Windows.Forms.Label();
            this.tlpMotionOperation.SuspendLayout();
            this.pnlMoveTargetPosition.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.tlpServoStatus.SuspendLayout();
            this.pnlAxisStatus.SuspendLayout();
            this.pnlTargetPosition.SuspendLayout();
            this.tlpSensorStatus.SuspendLayout();
            this.pnlAxisName.SuspendLayout();
            this.pnlOffset.SuspendLayout();
            this.pnlCurrentPosition.SuspendLayout();
            this.tlpJog.SuspendLayout();
            this.tlpJogScaleMode.SuspendLayout();
            this.tlpRepeatMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMotionOperation
            // 
            this.tlpMotionOperation.ColumnCount = 1;
            this.tlpMotionOperation.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMotionOperation.Controls.Add(this.pnlMoveTargetPosition, 0, 8);
            this.tlpMotionOperation.Controls.Add(this.pnlHome, 0, 7);
            this.tlpMotionOperation.Controls.Add(this.tlpServoStatus, 0, 6);
            this.tlpMotionOperation.Controls.Add(this.pnlAxisStatus, 0, 5);
            this.tlpMotionOperation.Controls.Add(this.pnlTargetPosition, 0, 1);
            this.tlpMotionOperation.Controls.Add(this.tlpSensorStatus, 0, 4);
            this.tlpMotionOperation.Controls.Add(this.pnlAxisName, 0, 0);
            this.tlpMotionOperation.Controls.Add(this.pnlOffset, 0, 2);
            this.tlpMotionOperation.Controls.Add(this.pnlCurrentPosition, 0, 3);
            this.tlpMotionOperation.Controls.Add(this.tlpJog, 0, 9);
            this.tlpMotionOperation.Controls.Add(this.tlpJogScaleMode, 0, 10);
            this.tlpMotionOperation.Controls.Add(this.tlpRepeatMode, 0, 11);
            this.tlpMotionOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionOperation.Location = new System.Drawing.Point(0, 0);
            this.tlpMotionOperation.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMotionOperation.Name = "tlpMotionOperation";
            this.tlpMotionOperation.RowCount = 12;
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMotionOperation.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpMotionOperation.Size = new System.Drawing.Size(200, 720);
            this.tlpMotionOperation.TabIndex = 0;
            // 
            // pnlMoveTargetPosition
            // 
            this.pnlMoveTargetPosition.Controls.Add(this.btnMoveTargetPosition);
            this.pnlMoveTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMoveTargetPosition.Location = new System.Drawing.Point(3, 323);
            this.pnlMoveTargetPosition.Name = "pnlMoveTargetPosition";
            this.pnlMoveTargetPosition.Size = new System.Drawing.Size(194, 34);
            this.pnlMoveTargetPosition.TabIndex = 14;
            // 
            // btnMoveTargetPosition
            // 
            this.btnMoveTargetPosition.BackColor = System.Drawing.Color.DarkGray;
            this.btnMoveTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnMoveTargetPosition.Location = new System.Drawing.Point(0, 0);
            this.btnMoveTargetPosition.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveTargetPosition.Name = "btnMoveTargetPosition";
            this.btnMoveTargetPosition.Size = new System.Drawing.Size(194, 34);
            this.btnMoveTargetPosition.TabIndex = 2;
            this.btnMoveTargetPosition.Text = "Move Target Position";
            this.btnMoveTargetPosition.UseVisualStyleBackColor = false;
            this.btnMoveTargetPosition.Click += new System.EventHandler(this.btnMoveTargetPosition_Click);
            // 
            // pnlHome
            // 
            this.pnlHome.Controls.Add(this.btnHome);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(3, 283);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Size = new System.Drawing.Size(194, 34);
            this.pnlHome.TabIndex = 12;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.DarkGray;
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Margin = new System.Windows.Forms.Padding(0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(194, 34);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tlpServoStatus
            // 
            this.tlpServoStatus.ColumnCount = 3;
            this.tlpServoStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpServoStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpServoStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpServoStatus.Controls.Add(this.btnServoOff, 0, 0);
            this.tlpServoStatus.Controls.Add(this.btnServoOn, 2, 0);
            this.tlpServoStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServoStatus.Location = new System.Drawing.Point(3, 243);
            this.tlpServoStatus.Name = "tlpServoStatus";
            this.tlpServoStatus.RowCount = 1;
            this.tlpServoStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServoStatus.Size = new System.Drawing.Size(194, 34);
            this.tlpServoStatus.TabIndex = 10;
            // 
            // btnServoOff
            // 
            this.btnServoOff.BackColor = System.Drawing.Color.DarkGray;
            this.btnServoOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnServoOff.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnServoOff.Location = new System.Drawing.Point(0, 0);
            this.btnServoOff.Margin = new System.Windows.Forms.Padding(0);
            this.btnServoOff.Name = "btnServoOff";
            this.btnServoOff.Size = new System.Drawing.Size(87, 34);
            this.btnServoOff.TabIndex = 0;
            this.btnServoOff.Text = "OFF";
            this.btnServoOff.UseVisualStyleBackColor = false;
            this.btnServoOff.Click += new System.EventHandler(this.btnServoOff_Click);
            // 
            // btnServoOn
            // 
            this.btnServoOn.BackColor = System.Drawing.Color.DarkGray;
            this.btnServoOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnServoOn.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnServoOn.Location = new System.Drawing.Point(107, 0);
            this.btnServoOn.Margin = new System.Windows.Forms.Padding(0);
            this.btnServoOn.Name = "btnServoOn";
            this.btnServoOn.Size = new System.Drawing.Size(87, 34);
            this.btnServoOn.TabIndex = 1;
            this.btnServoOn.Text = "ON";
            this.btnServoOn.UseVisualStyleBackColor = false;
            this.btnServoOn.Click += new System.EventHandler(this.btnServoOn_Click);
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
            this.lblAxisStatus.BackColor = System.Drawing.Color.Silver;
            this.lblAxisStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisStatus.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisStatus.Location = new System.Drawing.Point(0, 0);
            this.lblAxisStatus.Margin = new System.Windows.Forms.Padding(3);
            this.lblAxisStatus.Name = "lblAxisStatus";
            this.lblAxisStatus.Size = new System.Drawing.Size(194, 34);
            this.lblAxisStatus.TabIndex = 1;
            this.lblAxisStatus.Text = "Done";
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
            this.lblTargetPosition.BackColor = System.Drawing.Color.White;
            this.lblTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTargetPosition.Location = new System.Drawing.Point(0, 0);
            this.lblTargetPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblTargetPosition.Name = "lblTargetPosition";
            this.lblTargetPosition.Size = new System.Drawing.Size(194, 34);
            this.lblTargetPosition.TabIndex = 1;
            this.lblTargetPosition.Text = "0.0";
            this.lblTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTargetPosition.Click += new System.EventHandler(this.lblTargetPosition_Click);
            // 
            // tlpSensorStatus
            // 
            this.tlpSensorStatus.ColumnCount = 3;
            this.tlpSensorStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpSensorStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSensorStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpSensorStatus.Controls.Add(this.lblNegativeLimit, 0, 0);
            this.tlpSensorStatus.Controls.Add(this.lblPositiveLimit, 2, 0);
            this.tlpSensorStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSensorStatus.Location = new System.Drawing.Point(3, 163);
            this.tlpSensorStatus.Name = "tlpSensorStatus";
            this.tlpSensorStatus.RowCount = 1;
            this.tlpSensorStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSensorStatus.Size = new System.Drawing.Size(194, 34);
            this.tlpSensorStatus.TabIndex = 4;
            // 
            // lblNegativeLimit
            // 
            this.lblNegativeLimit.BackColor = System.Drawing.Color.Silver;
            this.lblNegativeLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNegativeLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNegativeLimit.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblNegativeLimit.Location = new System.Drawing.Point(3, 3);
            this.lblNegativeLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblNegativeLimit.Name = "lblNegativeLimit";
            this.lblNegativeLimit.Size = new System.Drawing.Size(81, 28);
            this.lblNegativeLimit.TabIndex = 0;
            this.lblNegativeLimit.Text = "-";
            this.lblNegativeLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPositiveLimit
            // 
            this.lblPositiveLimit.BackColor = System.Drawing.Color.Silver;
            this.lblPositiveLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPositiveLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPositiveLimit.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPositiveLimit.Location = new System.Drawing.Point(109, 3);
            this.lblPositiveLimit.Margin = new System.Windows.Forms.Padding(3);
            this.lblPositiveLimit.Name = "lblPositiveLimit";
            this.lblPositiveLimit.Size = new System.Drawing.Size(82, 28);
            this.lblPositiveLimit.TabIndex = 1;
            this.lblPositiveLimit.Text = "+";
            this.lblPositiveLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlAxisName
            // 
            this.pnlAxisName.Controls.Add(this.lblAxisName);
            this.pnlAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAxisName.Location = new System.Drawing.Point(3, 3);
            this.pnlAxisName.Name = "pnlAxisName";
            this.pnlAxisName.Size = new System.Drawing.Size(194, 34);
            this.pnlAxisName.TabIndex = 5;
            // 
            // lblAxisName
            // 
            this.lblAxisName.BackColor = System.Drawing.Color.Silver;
            this.lblAxisName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAxisName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAxisName.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAxisName.Location = new System.Drawing.Point(0, 0);
            this.lblAxisName.Margin = new System.Windows.Forms.Padding(3);
            this.lblAxisName.Name = "lblAxisName";
            this.lblAxisName.Size = new System.Drawing.Size(194, 34);
            this.lblAxisName.TabIndex = 0;
            this.lblAxisName.Text = "AxisName";
            this.lblAxisName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblOffset.BackColor = System.Drawing.Color.White;
            this.lblOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOffset.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblOffset.Location = new System.Drawing.Point(0, 0);
            this.lblOffset.Margin = new System.Windows.Forms.Padding(3);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(194, 34);
            this.lblOffset.TabIndex = 2;
            this.lblOffset.Text = "0.0";
            this.lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOffset.Click += new System.EventHandler(this.lblOffset_Click);
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
            this.lblCurrentPosition.BackColor = System.Drawing.Color.Silver;
            this.lblCurrentPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCurrentPosition.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(194, 34);
            this.lblCurrentPosition.TabIndex = 3;
            this.lblCurrentPosition.Text = "0.0";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpJog
            // 
            this.tlpJog.ColumnCount = 5;
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.Controls.Add(this.btnJogUp, 2, 0);
            this.tlpJog.Controls.Add(this.btnJogLeft, 0, 2);
            this.tlpJog.Controls.Add(this.btnJogRight, 4, 2);
            this.tlpJog.Controls.Add(this.btnJogDown, 2, 4);
            this.tlpJog.Controls.Add(this.btnJogStop, 2, 2);
            this.tlpJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJog.Location = new System.Drawing.Point(3, 363);
            this.tlpJog.Name = "tlpJog";
            this.tlpJog.RowCount = 5;
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpJog.Size = new System.Drawing.Size(194, 154);
            this.tlpJog.TabIndex = 11;
            // 
            // btnJogUp
            // 
            this.btnJogUp.BackColor = System.Drawing.Color.DarkGray;
            this.btnJogUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogUp.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogUp.Location = new System.Drawing.Point(67, 0);
            this.btnJogUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogUp.Name = "btnJogUp";
            this.btnJogUp.Size = new System.Drawing.Size(58, 46);
            this.btnJogUp.TabIndex = 0;
            this.btnJogUp.Text = "▲";
            this.btnJogUp.UseVisualStyleBackColor = false;
            this.btnJogUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogUp_MouseDown);
            this.btnJogUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogUp_MouseUp);
            // 
            // btnJogLeft
            // 
            this.btnJogLeft.BackColor = System.Drawing.Color.DarkGray;
            this.btnJogLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogLeft.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogLeft.Location = new System.Drawing.Point(0, 53);
            this.btnJogLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogLeft.Name = "btnJogLeft";
            this.btnJogLeft.Size = new System.Drawing.Size(58, 46);
            this.btnJogLeft.TabIndex = 1;
            this.btnJogLeft.Text = "◀";
            this.btnJogLeft.UseVisualStyleBackColor = false;
            this.btnJogLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogLeft_MouseDown);
            this.btnJogLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogLeft_MouseUp);
            // 
            // btnJogRight
            // 
            this.btnJogRight.BackColor = System.Drawing.Color.DarkGray;
            this.btnJogRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogRight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogRight.Location = new System.Drawing.Point(134, 53);
            this.btnJogRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogRight.Name = "btnJogRight";
            this.btnJogRight.Size = new System.Drawing.Size(60, 46);
            this.btnJogRight.TabIndex = 2;
            this.btnJogRight.Text = "▶";
            this.btnJogRight.UseVisualStyleBackColor = false;
            this.btnJogRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogRight_MouseDown);
            this.btnJogRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogRight_MouseUp);
            // 
            // btnJogDown
            // 
            this.btnJogDown.BackColor = System.Drawing.Color.DarkGray;
            this.btnJogDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogDown.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogDown.Location = new System.Drawing.Point(67, 106);
            this.btnJogDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogDown.Name = "btnJogDown";
            this.btnJogDown.Size = new System.Drawing.Size(58, 48);
            this.btnJogDown.TabIndex = 3;
            this.btnJogDown.Text = "▼";
            this.btnJogDown.UseVisualStyleBackColor = false;
            this.btnJogDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogDown_MouseDown);
            this.btnJogDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogDown_MouseUp);
            // 
            // btnJogStop
            // 
            this.btnJogStop.BackColor = System.Drawing.Color.DarkGray;
            this.btnJogStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogStop.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogStop.Location = new System.Drawing.Point(67, 53);
            this.btnJogStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogStop.Name = "btnJogStop";
            this.btnJogStop.Size = new System.Drawing.Size(58, 46);
            this.btnJogStop.TabIndex = 4;
            this.btnJogStop.Text = "■";
            this.btnJogStop.UseVisualStyleBackColor = false;
            this.btnJogStop.Click += new System.EventHandler(this.btnJogStop_Click);
            // 
            // tlpJogScaleMode
            // 
            this.tlpJogScaleMode.ColumnCount = 2;
            this.tlpJogScaleMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpJogScaleMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpJogScaleMode.Controls.Add(this.btnJogScaleValue, 1, 0);
            this.tlpJogScaleMode.Controls.Add(this.lblJogScale, 0, 0);
            this.tlpJogScaleMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpJogScaleMode.Location = new System.Drawing.Point(3, 523);
            this.tlpJogScaleMode.Name = "tlpJogScaleMode";
            this.tlpJogScaleMode.RowCount = 1;
            this.tlpJogScaleMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpJogScaleMode.Size = new System.Drawing.Size(194, 34);
            this.tlpJogScaleMode.TabIndex = 15;
            // 
            // btnJogScaleValue
            // 
            this.btnJogScaleValue.BackColor = System.Drawing.Color.Silver;
            this.btnJogScaleValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnJogScaleValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnJogScaleValue.Location = new System.Drawing.Point(116, 0);
            this.btnJogScaleValue.Margin = new System.Windows.Forms.Padding(0);
            this.btnJogScaleValue.Name = "btnJogScaleValue";
            this.btnJogScaleValue.Size = new System.Drawing.Size(78, 34);
            this.btnJogScaleValue.TabIndex = 2001;
            this.btnJogScaleValue.Text = "0";
            this.btnJogScaleValue.UseVisualStyleBackColor = false;
            this.btnJogScaleValue.Click += new System.EventHandler(this.btnJogScaleValue_Click);
            // 
            // lblJogScale
            // 
            this.lblJogScale.BackColor = System.Drawing.Color.Silver;
            this.lblJogScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogScale.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblJogScale.Location = new System.Drawing.Point(3, 3);
            this.lblJogScale.Margin = new System.Windows.Forms.Padding(3);
            this.lblJogScale.Name = "lblJogScale";
            this.lblJogScale.Size = new System.Drawing.Size(110, 28);
            this.lblJogScale.TabIndex = 2002;
            this.lblJogScale.Text = "Scale";
            this.lblJogScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogScale.Click += new System.EventHandler(this.lblJogScale_Click);
            // 
            // tlpRepeatMode
            // 
            this.tlpRepeatMode.ColumnCount = 2;
            this.tlpRepeatMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRepeatMode.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRepeatMode.Controls.Add(this.btnRepeatStart, 0, 3);
            this.tlpRepeatMode.Controls.Add(this.btnRepeatStop, 1, 3);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatRemain, 1, 2);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatCount, 0, 2);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatStart, 0, 0);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatTarget, 1, 0);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatStartPosition, 0, 1);
            this.tlpRepeatMode.Controls.Add(this.lblRepeatTargetPosition, 1, 1);
            this.tlpRepeatMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRepeatMode.Location = new System.Drawing.Point(3, 563);
            this.tlpRepeatMode.Name = "tlpRepeatMode";
            this.tlpRepeatMode.RowCount = 4;
            this.tlpRepeatMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRepeatMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRepeatMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRepeatMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpRepeatMode.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRepeatMode.Size = new System.Drawing.Size(194, 154);
            this.tlpRepeatMode.TabIndex = 16;
            // 
            // btnRepeatStart
            // 
            this.btnRepeatStart.BackColor = System.Drawing.Color.DarkGray;
            this.btnRepeatStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRepeatStart.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnRepeatStart.Location = new System.Drawing.Point(0, 114);
            this.btnRepeatStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepeatStart.Name = "btnRepeatStart";
            this.btnRepeatStart.Size = new System.Drawing.Size(97, 40);
            this.btnRepeatStart.TabIndex = 1;
            this.btnRepeatStart.Text = "Scan Start";
            this.btnRepeatStart.UseVisualStyleBackColor = false;
            this.btnRepeatStart.Click += new System.EventHandler(this.btnRepeatStart_Click);
            // 
            // btnRepeatStop
            // 
            this.btnRepeatStop.BackColor = System.Drawing.Color.DarkGray;
            this.btnRepeatStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRepeatStop.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnRepeatStop.Location = new System.Drawing.Point(97, 114);
            this.btnRepeatStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepeatStop.Name = "btnRepeatStop";
            this.btnRepeatStop.Size = new System.Drawing.Size(97, 40);
            this.btnRepeatStop.TabIndex = 2;
            this.btnRepeatStop.Text = "Scan Stop";
            this.btnRepeatStop.UseVisualStyleBackColor = false;
            // 
            // lblRepeatRemain
            // 
            this.lblRepeatRemain.BackColor = System.Drawing.Color.Silver;
            this.lblRepeatRemain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatRemain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatRemain.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatRemain.Location = new System.Drawing.Point(100, 79);
            this.lblRepeatRemain.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatRemain.Name = "lblRepeatRemain";
            this.lblRepeatRemain.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatRemain.TabIndex = 1;
            this.lblRepeatRemain.Text = "0 / 0";
            this.lblRepeatRemain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatCount
            // 
            this.lblRepeatCount.BackColor = System.Drawing.Color.White;
            this.lblRepeatCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatCount.Location = new System.Drawing.Point(3, 79);
            this.lblRepeatCount.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatCount.Name = "lblRepeatCount";
            this.lblRepeatCount.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatCount.TabIndex = 2;
            this.lblRepeatCount.Text = "0";
            this.lblRepeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRepeatCount.Click += new System.EventHandler(this.lblOffset_Click);
            // 
            // lblRepeatStart
            // 
            this.lblRepeatStart.BackColor = System.Drawing.Color.Silver;
            this.lblRepeatStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatStart.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatStart.Location = new System.Drawing.Point(3, 3);
            this.lblRepeatStart.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatStart.Name = "lblRepeatStart";
            this.lblRepeatStart.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatStart.TabIndex = 1;
            this.lblRepeatStart.Text = "Cur Pos";
            this.lblRepeatStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatTarget
            // 
            this.lblRepeatTarget.BackColor = System.Drawing.Color.Silver;
            this.lblRepeatTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatTarget.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatTarget.Location = new System.Drawing.Point(100, 3);
            this.lblRepeatTarget.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatTarget.Name = "lblRepeatTarget";
            this.lblRepeatTarget.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatTarget.TabIndex = 1;
            this.lblRepeatTarget.Text = "Length";
            this.lblRepeatTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatStartPosition
            // 
            this.lblRepeatStartPosition.BackColor = System.Drawing.Color.Silver;
            this.lblRepeatStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatStartPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatStartPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatStartPosition.Location = new System.Drawing.Point(3, 41);
            this.lblRepeatStartPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatStartPosition.Name = "lblRepeatStartPosition";
            this.lblRepeatStartPosition.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatStartPosition.TabIndex = 1;
            this.lblRepeatStartPosition.Text = "0.0";
            this.lblRepeatStartPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatTargetPosition
            // 
            this.lblRepeatTargetPosition.BackColor = System.Drawing.Color.White;
            this.lblRepeatTargetPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatTargetPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatTargetPosition.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblRepeatTargetPosition.Location = new System.Drawing.Point(100, 41);
            this.lblRepeatTargetPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatTargetPosition.Name = "lblRepeatTargetPosition";
            this.lblRepeatTargetPosition.Size = new System.Drawing.Size(91, 32);
            this.lblRepeatTargetPosition.TabIndex = 2;
            this.lblRepeatTargetPosition.Text = "0.0";
            this.lblRepeatTargetPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRepeatTargetPosition.Click += new System.EventHandler(this.lblOffset_Click);
            // 
            // CtrlMotionFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpMotionOperation);
            this.Name = "CtrlMotionFunction";
            this.Size = new System.Drawing.Size(200, 720);
            this.tlpMotionOperation.ResumeLayout(false);
            this.pnlMoveTargetPosition.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.tlpServoStatus.ResumeLayout(false);
            this.pnlAxisStatus.ResumeLayout(false);
            this.pnlTargetPosition.ResumeLayout(false);
            this.tlpSensorStatus.ResumeLayout(false);
            this.pnlAxisName.ResumeLayout(false);
            this.pnlOffset.ResumeLayout(false);
            this.pnlCurrentPosition.ResumeLayout(false);
            this.tlpJog.ResumeLayout(false);
            this.tlpJogScaleMode.ResumeLayout(false);
            this.tlpRepeatMode.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMotionOperation;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Label lblTargetPosition;
        private System.Windows.Forms.Label lblAxisName;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.TableLayoutPanel tlpSensorStatus;
        private System.Windows.Forms.Panel pnlTargetPosition;
        private System.Windows.Forms.Label lblNegativeLimit;
        private System.Windows.Forms.Label lblPositiveLimit;
        private System.Windows.Forms.Panel pnlAxisName;
        private System.Windows.Forms.Panel pnlOffset;
        private System.Windows.Forms.Panel pnlCurrentPosition;
        private System.Windows.Forms.TableLayoutPanel tlpServoStatus;
        private System.Windows.Forms.Button btnServoOff;
        private System.Windows.Forms.Button btnServoOn;
        private System.Windows.Forms.Panel pnlAxisStatus;
        private System.Windows.Forms.Label lblAxisStatus;
        private System.Windows.Forms.TableLayoutPanel tlpJog;
        private System.Windows.Forms.Button btnJogUp;
        private System.Windows.Forms.Button btnJogLeft;
        private System.Windows.Forms.Button btnJogRight;
        private System.Windows.Forms.Button btnJogDown;
        private System.Windows.Forms.Button btnJogStop;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel pnlMoveTargetPosition;
        private System.Windows.Forms.Button btnMoveTargetPosition;
        private System.Windows.Forms.TableLayoutPanel tlpJogScaleMode;
        private System.Windows.Forms.Button btnJogScaleValue;
        private System.Windows.Forms.Label lblJogScale;
        private System.Windows.Forms.TableLayoutPanel tlpRepeatMode;
        private System.Windows.Forms.Label lblRepeatRemain;
        private System.Windows.Forms.Label lblRepeatCount;
        private System.Windows.Forms.Button btnRepeatStop;
        private System.Windows.Forms.Button btnRepeatStart;
        private System.Windows.Forms.Label lblRepeatStart;
        private System.Windows.Forms.Label lblRepeatTarget;
        private System.Windows.Forms.Label lblRepeatStartPosition;
        private System.Windows.Forms.Label lblRepeatTargetPosition;
    }
}
