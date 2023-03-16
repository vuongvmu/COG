namespace COG.Controls
{
    partial class CtrlMotionRepeat
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
            this.grpMotionRepeat = new System.Windows.Forms.GroupBox();
            this.tlpMotionRepeat = new System.Windows.Forms.TableLayoutPanel();
            this.lblEndPositionValue = new System.Windows.Forms.Label();
            this.lblStartPositionValue = new System.Windows.Forms.Label();
            this.lblActualPositionValue = new System.Windows.Forms.Label();
            this.lblDecelationValue = new System.Windows.Forms.Label();
            this.lblDecelation = new System.Windows.Forms.Label();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblAccelationValue = new System.Windows.Forms.Label();
            this.lblActualPosition = new System.Windows.Forms.Label();
            this.lblAccelation = new System.Windows.Forms.Label();
            this.lblStartPosition = new System.Windows.Forms.Label();
            this.lblEndPosition = new System.Windows.Forms.Label();
            this.lblRepeatCount = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemainRepeat = new System.Windows.Forms.Label();
            this.lblRepeatCountValue = new System.Windows.Forms.Label();
            this.lblVelocityValue = new System.Windows.Forms.Label();
            this.grpMotionRepeat.SuspendLayout();
            this.tlpMotionRepeat.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMotionRepeat
            // 
            this.grpMotionRepeat.Controls.Add(this.tlpMotionRepeat);
            this.grpMotionRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMotionRepeat.Font = new System.Drawing.Font("맑은 고딕", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.grpMotionRepeat.Location = new System.Drawing.Point(0, 0);
            this.grpMotionRepeat.Name = "grpMotionRepeat";
            this.grpMotionRepeat.Size = new System.Drawing.Size(484, 347);
            this.grpMotionRepeat.TabIndex = 0;
            this.grpMotionRepeat.TabStop = false;
            this.grpMotionRepeat.Text = "groupBox1";
            // 
            // tlpMotionRepeat
            // 
            this.tlpMotionRepeat.ColumnCount = 2;
            this.tlpMotionRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionRepeat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMotionRepeat.Controls.Add(this.lblEndPositionValue, 1, 5);
            this.tlpMotionRepeat.Controls.Add(this.lblStartPositionValue, 1, 4);
            this.tlpMotionRepeat.Controls.Add(this.lblActualPositionValue, 1, 3);
            this.tlpMotionRepeat.Controls.Add(this.lblDecelationValue, 1, 2);
            this.tlpMotionRepeat.Controls.Add(this.lblDecelation, 0, 2);
            this.tlpMotionRepeat.Controls.Add(this.lblVelocity, 0, 0);
            this.tlpMotionRepeat.Controls.Add(this.lblVelocityValue, 1, 0);
            this.tlpMotionRepeat.Controls.Add(this.lblAccelationValue, 1, 1);
            this.tlpMotionRepeat.Controls.Add(this.lblActualPosition, 0, 3);
            this.tlpMotionRepeat.Controls.Add(this.lblAccelation, 0, 1);
            this.tlpMotionRepeat.Controls.Add(this.lblStartPosition, 0, 4);
            this.tlpMotionRepeat.Controls.Add(this.lblEndPosition, 0, 5);
            this.tlpMotionRepeat.Controls.Add(this.lblRepeatCount, 0, 6);
            this.tlpMotionRepeat.Controls.Add(this.btnStart, 0, 7);
            this.tlpMotionRepeat.Controls.Add(this.btnStop, 1, 7);
            this.tlpMotionRepeat.Controls.Add(this.tableLayoutPanel1, 1, 6);
            this.tlpMotionRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMotionRepeat.Location = new System.Drawing.Point(3, 29);
            this.tlpMotionRepeat.Name = "tlpMotionRepeat";
            this.tlpMotionRepeat.RowCount = 8;
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMotionRepeat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMotionRepeat.Size = new System.Drawing.Size(478, 315);
            this.tlpMotionRepeat.TabIndex = 2;
            // 
            // lblEndPositionValue
            // 
            this.lblEndPositionValue.AutoSize = true;
            this.lblEndPositionValue.BackColor = System.Drawing.Color.White;
            this.lblEndPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndPositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndPositionValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblEndPositionValue.Location = new System.Drawing.Point(242, 198);
            this.lblEndPositionValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblEndPositionValue.Name = "lblEndPositionValue";
            this.lblEndPositionValue.Size = new System.Drawing.Size(233, 33);
            this.lblEndPositionValue.TabIndex = 15;
            this.lblEndPositionValue.Text = "label6";
            this.lblEndPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEndPositionValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // lblStartPositionValue
            // 
            this.lblStartPositionValue.AutoSize = true;
            this.lblStartPositionValue.BackColor = System.Drawing.Color.White;
            this.lblStartPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartPositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartPositionValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblStartPositionValue.Location = new System.Drawing.Point(242, 159);
            this.lblStartPositionValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartPositionValue.Name = "lblStartPositionValue";
            this.lblStartPositionValue.Size = new System.Drawing.Size(233, 33);
            this.lblStartPositionValue.TabIndex = 14;
            this.lblStartPositionValue.Text = "label5";
            this.lblStartPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStartPositionValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // lblActualPositionValue
            // 
            this.lblActualPositionValue.AutoSize = true;
            this.lblActualPositionValue.BackColor = System.Drawing.Color.Silver;
            this.lblActualPositionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActualPositionValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActualPositionValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblActualPositionValue.Location = new System.Drawing.Point(242, 120);
            this.lblActualPositionValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblActualPositionValue.Name = "lblActualPositionValue";
            this.lblActualPositionValue.Size = new System.Drawing.Size(233, 33);
            this.lblActualPositionValue.TabIndex = 13;
            this.lblActualPositionValue.Text = "label4";
            this.lblActualPositionValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDecelationValue
            // 
            this.lblDecelationValue.AutoSize = true;
            this.lblDecelationValue.BackColor = System.Drawing.Color.White;
            this.lblDecelationValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDecelationValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDecelationValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblDecelationValue.Location = new System.Drawing.Point(242, 81);
            this.lblDecelationValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblDecelationValue.Name = "lblDecelationValue";
            this.lblDecelationValue.Size = new System.Drawing.Size(233, 33);
            this.lblDecelationValue.TabIndex = 12;
            this.lblDecelationValue.Text = "label3";
            this.lblDecelationValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDecelationValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // lblDecelation
            // 
            this.lblDecelation.BackColor = System.Drawing.Color.Silver;
            this.lblDecelation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDecelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDecelation.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblDecelation.Location = new System.Drawing.Point(3, 81);
            this.lblDecelation.Margin = new System.Windows.Forms.Padding(3);
            this.lblDecelation.Name = "lblDecelation";
            this.lblDecelation.Size = new System.Drawing.Size(233, 33);
            this.lblDecelation.TabIndex = 5;
            this.lblDecelation.Text = "Decelation";
            this.lblDecelation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVelocity
            // 
            this.lblVelocity.BackColor = System.Drawing.Color.Silver;
            this.lblVelocity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVelocity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVelocity.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblVelocity.Location = new System.Drawing.Point(3, 3);
            this.lblVelocity.Margin = new System.Windows.Forms.Padding(3);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(233, 33);
            this.lblVelocity.TabIndex = 1;
            this.lblVelocity.Text = "Velocity";
            this.lblVelocity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccelationValue
            // 
            this.lblAccelationValue.AutoSize = true;
            this.lblAccelationValue.BackColor = System.Drawing.Color.White;
            this.lblAccelationValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccelationValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccelationValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccelationValue.Location = new System.Drawing.Point(242, 42);
            this.lblAccelationValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblAccelationValue.Name = "lblAccelationValue";
            this.lblAccelationValue.Size = new System.Drawing.Size(233, 33);
            this.lblAccelationValue.TabIndex = 3;
            this.lblAccelationValue.Text = "label2";
            this.lblAccelationValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccelationValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // lblActualPosition
            // 
            this.lblActualPosition.BackColor = System.Drawing.Color.Silver;
            this.lblActualPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblActualPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActualPosition.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblActualPosition.Location = new System.Drawing.Point(3, 120);
            this.lblActualPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblActualPosition.Name = "lblActualPosition";
            this.lblActualPosition.Size = new System.Drawing.Size(233, 33);
            this.lblActualPosition.TabIndex = 0;
            this.lblActualPosition.Text = "Current Position";
            this.lblActualPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccelation
            // 
            this.lblAccelation.BackColor = System.Drawing.Color.Silver;
            this.lblAccelation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAccelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAccelation.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAccelation.Location = new System.Drawing.Point(3, 42);
            this.lblAccelation.Margin = new System.Windows.Forms.Padding(3);
            this.lblAccelation.Name = "lblAccelation";
            this.lblAccelation.Size = new System.Drawing.Size(233, 33);
            this.lblAccelation.TabIndex = 4;
            this.lblAccelation.Text = "Accelation";
            this.lblAccelation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartPosition
            // 
            this.lblStartPosition.BackColor = System.Drawing.Color.Silver;
            this.lblStartPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStartPosition.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblStartPosition.Location = new System.Drawing.Point(3, 159);
            this.lblStartPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblStartPosition.Name = "lblStartPosition";
            this.lblStartPosition.Size = new System.Drawing.Size(233, 33);
            this.lblStartPosition.TabIndex = 7;
            this.lblStartPosition.Text = "Start Position";
            this.lblStartPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEndPosition
            // 
            this.lblEndPosition.BackColor = System.Drawing.Color.Silver;
            this.lblEndPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEndPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEndPosition.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblEndPosition.Location = new System.Drawing.Point(3, 198);
            this.lblEndPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblEndPosition.Name = "lblEndPosition";
            this.lblEndPosition.Size = new System.Drawing.Size(233, 33);
            this.lblEndPosition.TabIndex = 8;
            this.lblEndPosition.Text = "End Position";
            this.lblEndPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatCount
            // 
            this.lblRepeatCount.BackColor = System.Drawing.Color.Silver;
            this.lblRepeatCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblRepeatCount.Location = new System.Drawing.Point(3, 237);
            this.lblRepeatCount.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatCount.Name = "lblRepeatCount";
            this.lblRepeatCount.Size = new System.Drawing.Size(233, 33);
            this.lblRepeatCount.TabIndex = 9;
            this.lblRepeatCount.Text = "Repeat Count";
            this.lblRepeatCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.DarkGray;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(3, 276);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(233, 36);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.DarkGray;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(242, 276);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(233, 36);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblRemainRepeat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRepeatCountValue, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(242, 237);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(233, 33);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // lblRemainRepeat
            // 
            this.lblRemainRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemainRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemainRepeat.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblRemainRepeat.Location = new System.Drawing.Point(119, 3);
            this.lblRemainRepeat.Margin = new System.Windows.Forms.Padding(3);
            this.lblRemainRepeat.Name = "lblRemainRepeat";
            this.lblRemainRepeat.Size = new System.Drawing.Size(111, 27);
            this.lblRemainRepeat.TabIndex = 17;
            this.lblRemainRepeat.Text = "label8";
            this.lblRemainRepeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRepeatCountValue
            // 
            this.lblRepeatCountValue.AutoSize = true;
            this.lblRepeatCountValue.BackColor = System.Drawing.Color.White;
            this.lblRepeatCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRepeatCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRepeatCountValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblRepeatCountValue.Location = new System.Drawing.Point(3, 3);
            this.lblRepeatCountValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblRepeatCountValue.Name = "lblRepeatCountValue";
            this.lblRepeatCountValue.Size = new System.Drawing.Size(110, 27);
            this.lblRepeatCountValue.TabIndex = 16;
            this.lblRepeatCountValue.Text = "label7";
            this.lblRepeatCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRepeatCountValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // lblVelocityValue
            // 
            this.lblVelocityValue.BackColor = System.Drawing.Color.White;
            this.lblVelocityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVelocityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVelocityValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblVelocityValue.Location = new System.Drawing.Point(242, 3);
            this.lblVelocityValue.Margin = new System.Windows.Forms.Padding(3);
            this.lblVelocityValue.Name = "lblVelocityValue";
            this.lblVelocityValue.Size = new System.Drawing.Size(233, 33);
            this.lblVelocityValue.TabIndex = 2;
            this.lblVelocityValue.Text = "label1";
            this.lblVelocityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVelocityValue.Click += new System.EventHandler(this.SetValue_Click);
            // 
            // CtrlMotionRepeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.grpMotionRepeat);
            this.Name = "CtrlMotionRepeat";
            this.Size = new System.Drawing.Size(484, 347);
            this.Load += new System.EventHandler(this.CtrlMotion_Load);
            this.grpMotionRepeat.ResumeLayout(false);
            this.tlpMotionRepeat.ResumeLayout(false);
            this.tlpMotionRepeat.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMotionRepeat;
        private System.Windows.Forms.TableLayoutPanel tlpMotionRepeat;
        private System.Windows.Forms.Label lblActualPosition;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblDecelation;
        private System.Windows.Forms.Label lblAccelationValue;
        private System.Windows.Forms.Label lblAccelation;
        private System.Windows.Forms.Label lblRepeatCountValue;
        private System.Windows.Forms.Label lblEndPositionValue;
        private System.Windows.Forms.Label lblStartPositionValue;
        private System.Windows.Forms.Label lblActualPositionValue;
        private System.Windows.Forms.Label lblDecelationValue;
        private System.Windows.Forms.Label lblStartPosition;
        private System.Windows.Forms.Label lblEndPosition;
        private System.Windows.Forms.Label lblRepeatCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblRemainRepeat;
        private System.Windows.Forms.Label lblVelocityValue;
    }
}
