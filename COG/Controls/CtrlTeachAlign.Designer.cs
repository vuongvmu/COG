namespace COG.Controls
{
    partial class CtrlTeachAlign
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
            this.tlpTeachAlign = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEdgeParameter = new System.Windows.Forms.TableLayoutPanel();
            this.chkROITracking = new System.Windows.Forms.CheckBox();
            this.lblLeadCount = new System.Windows.Forms.Label();
            this.lblLeadCountValue = new System.Windows.Forms.Label();
            this.btnROIShow = new System.Windows.Forms.Button();
            this.lblEdgePolarity = new System.Windows.Forms.Label();
            this.lblEdgeThresholdValue = new System.Windows.Forms.Label();
            this.lblEdgeThreshold = new System.Windows.Forms.Label();
            this.lblFilterSize = new System.Windows.Forms.Label();
            this.lblFilterSizeValue = new System.Windows.Forms.Label();
            this.tlpEdgePolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoLightToDark = new System.Windows.Forms.RadioButton();
            this.rdoDarkToLight = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnAlignTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpROIPosition = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEdgePosition = new System.Windows.Forms.TableLayoutPanel();
            this.rdoEdgeX = new System.Windows.Forms.RadioButton();
            this.rdoEdgeY = new System.Windows.Forms.RadioButton();
            this.tlpAlignPosition = new System.Windows.Forms.TableLayoutPanel();
            this.rdoAlignRight = new System.Windows.Forms.RadioButton();
            this.rdoAlignLeft = new System.Windows.Forms.RadioButton();
            this.tlpTargetObject = new System.Windows.Forms.TableLayoutPanel();
            this.rdoPanel = new System.Windows.Forms.RadioButton();
            this.rdoFPC = new System.Windows.Forms.RadioButton();
            this.lblAlignPosition = new System.Windows.Forms.Label();
            this.lblTargetObject = new System.Windows.Forms.Label();
            this.lblEdgePosition = new System.Windows.Forms.Label();
            this.tlpTeachAlign.SuspendLayout();
            this.tlpEdgeParameter.SuspendLayout();
            this.tlpEdgePolarity.SuspendLayout();
            this.tlpROIPosition.SuspendLayout();
            this.tlpEdgePosition.SuspendLayout();
            this.tlpAlignPosition.SuspendLayout();
            this.tlpTargetObject.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachAlign
            // 
            this.tlpTeachAlign.ColumnCount = 1;
            this.tlpTeachAlign.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachAlign.Controls.Add(this.tlpEdgeParameter, 0, 1);
            this.tlpTeachAlign.Controls.Add(this.tlpROIPosition, 0, 0);
            this.tlpTeachAlign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachAlign.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachAlign.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachAlign.Name = "tlpTeachAlign";
            this.tlpTeachAlign.RowCount = 2;
            this.tlpTeachAlign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTeachAlign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpTeachAlign.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTeachAlign.Size = new System.Drawing.Size(800, 700);
            this.tlpTeachAlign.TabIndex = 288;
            // 
            // tlpEdgeParameter
            // 
            this.tlpEdgeParameter.ColumnCount = 3;
            this.tlpEdgeParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpEdgeParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEdgeParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpEdgeParameter.Controls.Add(this.chkROITracking, 0, 1);
            this.tlpEdgeParameter.Controls.Add(this.lblLeadCount, 0, 2);
            this.tlpEdgeParameter.Controls.Add(this.lblLeadCountValue, 1, 2);
            this.tlpEdgeParameter.Controls.Add(this.btnROIShow, 1, 7);
            this.tlpEdgeParameter.Controls.Add(this.lblEdgePolarity, 0, 3);
            this.tlpEdgeParameter.Controls.Add(this.lblEdgeThresholdValue, 1, 5);
            this.tlpEdgeParameter.Controls.Add(this.lblEdgeThreshold, 0, 5);
            this.tlpEdgeParameter.Controls.Add(this.lblFilterSize, 0, 4);
            this.tlpEdgeParameter.Controls.Add(this.lblFilterSizeValue, 1, 4);
            this.tlpEdgeParameter.Controls.Add(this.tlpEdgePolarity, 1, 3);
            this.tlpEdgeParameter.Controls.Add(this.btnApply, 1, 8);
            this.tlpEdgeParameter.Controls.Add(this.btnAlignTest, 2, 7);
            this.tlpEdgeParameter.Controls.Add(this.btnSave, 2, 8);
            this.tlpEdgeParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdgeParameter.Location = new System.Drawing.Point(0, 210);
            this.tlpEdgeParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEdgeParameter.Name = "tlpEdgeParameter";
            this.tlpEdgeParameter.RowCount = 9;
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpEdgeParameter.Size = new System.Drawing.Size(800, 490);
            this.tlpEdgeParameter.TabIndex = 0;
            // 
            // chkROITracking
            // 
            this.chkROITracking.AutoSize = true;
            this.chkROITracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkROITracking.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.chkROITracking.Location = new System.Drawing.Point(5, 52);
            this.chkROITracking.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.chkROITracking.Name = "chkROITracking";
            this.chkROITracking.Size = new System.Drawing.Size(312, 43);
            this.chkROITracking.TabIndex = 1;
            this.chkROITracking.Text = "Use ROI Tracking";
            this.chkROITracking.UseVisualStyleBackColor = true;
            // 
            // lblLeadCount
            // 
            this.lblLeadCount.AutoSize = true;
            this.lblLeadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLeadCount.Location = new System.Drawing.Point(9, 101);
            this.lblLeadCount.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblLeadCount.Name = "lblLeadCount";
            this.lblLeadCount.Size = new System.Drawing.Size(302, 43);
            this.lblLeadCount.TabIndex = 0;
            this.lblLeadCount.Text = "LEAD COUNT";
            this.lblLeadCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeadCountValue
            // 
            this.lblLeadCountValue.AutoSize = true;
            this.lblLeadCountValue.BackColor = System.Drawing.Color.White;
            this.lblLeadCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadCountValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblLeadCountValue.Location = new System.Drawing.Point(329, 101);
            this.lblLeadCountValue.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblLeadCountValue.Name = "lblLeadCountValue";
            this.lblLeadCountValue.Size = new System.Drawing.Size(222, 43);
            this.lblLeadCountValue.TabIndex = 7;
            this.lblLeadCountValue.Text = "0";
            this.lblLeadCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadCountValue.Click += new System.EventHandler(this.lblLeadCountValue_Click);
            // 
            // btnROIShow
            // 
            this.btnROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnROIShow.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnROIShow.Location = new System.Drawing.Point(323, 395);
            this.btnROIShow.Name = "btnROIShow";
            this.btnROIShow.Size = new System.Drawing.Size(234, 43);
            this.btnROIShow.TabIndex = 198;
            this.btnROIShow.Text = "SHOW ROI";
            this.btnROIShow.UseVisualStyleBackColor = false;
            this.btnROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // lblEdgePolarity
            // 
            this.lblEdgePolarity.AutoSize = true;
            this.lblEdgePolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgePolarity.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEdgePolarity.Location = new System.Drawing.Point(9, 150);
            this.lblEdgePolarity.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblEdgePolarity.Name = "lblEdgePolarity";
            this.lblEdgePolarity.Size = new System.Drawing.Size(302, 92);
            this.lblEdgePolarity.TabIndex = 4;
            this.lblEdgePolarity.Text = "EDGE POLARITY";
            this.lblEdgePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgeThresholdValue
            // 
            this.lblEdgeThresholdValue.AutoSize = true;
            this.lblEdgeThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblEdgeThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblEdgeThresholdValue.Location = new System.Drawing.Point(329, 297);
            this.lblEdgeThresholdValue.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblEdgeThresholdValue.Name = "lblEdgeThresholdValue";
            this.lblEdgeThresholdValue.Size = new System.Drawing.Size(222, 43);
            this.lblEdgeThresholdValue.TabIndex = 9;
            this.lblEdgeThresholdValue.Text = "0";
            this.lblEdgeThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEdgeThresholdValue.Click += new System.EventHandler(this.lblEdgeThresholdValue_Click);
            // 
            // lblEdgeThreshold
            // 
            this.lblEdgeThreshold.AutoSize = true;
            this.lblEdgeThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgeThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgeThreshold.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEdgeThreshold.Location = new System.Drawing.Point(9, 297);
            this.lblEdgeThreshold.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblEdgeThreshold.Name = "lblEdgeThreshold";
            this.lblEdgeThreshold.Size = new System.Drawing.Size(302, 43);
            this.lblEdgeThreshold.TabIndex = 3;
            this.lblEdgeThreshold.Text = "EDGE THRESHOLD";
            this.lblEdgeThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterSize
            // 
            this.lblFilterSize.AutoSize = true;
            this.lblFilterSize.BackColor = System.Drawing.Color.Silver;
            this.lblFilterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblFilterSize.Location = new System.Drawing.Point(9, 248);
            this.lblFilterSize.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblFilterSize.Name = "lblFilterSize";
            this.lblFilterSize.Size = new System.Drawing.Size(302, 43);
            this.lblFilterSize.TabIndex = 2;
            this.lblFilterSize.Text = "FILTER SIZE";
            this.lblFilterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterSizeValue
            // 
            this.lblFilterSizeValue.AutoSize = true;
            this.lblFilterSizeValue.BackColor = System.Drawing.Color.White;
            this.lblFilterSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterSizeValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblFilterSizeValue.Location = new System.Drawing.Point(329, 248);
            this.lblFilterSizeValue.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lblFilterSizeValue.Name = "lblFilterSizeValue";
            this.lblFilterSizeValue.Size = new System.Drawing.Size(222, 43);
            this.lblFilterSizeValue.TabIndex = 8;
            this.lblFilterSizeValue.Text = "0";
            this.lblFilterSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFilterSizeValue.Click += new System.EventHandler(this.lblFilterSizeValue_Click);
            // 
            // tlpEdgePolarity
            // 
            this.tlpEdgePolarity.ColumnCount = 1;
            this.tlpEdgePolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.Controls.Add(this.rdoLightToDark, 0, 1);
            this.tlpEdgePolarity.Controls.Add(this.rdoDarkToLight, 0, 0);
            this.tlpEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdgePolarity.Location = new System.Drawing.Point(320, 147);
            this.tlpEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEdgePolarity.Name = "tlpEdgePolarity";
            this.tlpEdgePolarity.RowCount = 2;
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpEdgePolarity.Size = new System.Drawing.Size(240, 98);
            this.tlpEdgePolarity.TabIndex = 199;
            // 
            // rdoLightToDark
            // 
            this.rdoLightToDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLightToDark.AutoSize = true;
            this.rdoLightToDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLightToDark.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoLightToDark.Location = new System.Drawing.Point(3, 52);
            this.rdoLightToDark.Name = "rdoLightToDark";
            this.rdoLightToDark.Size = new System.Drawing.Size(234, 43);
            this.rdoLightToDark.TabIndex = 6;
            this.rdoLightToDark.TabStop = true;
            this.rdoLightToDark.Tag = "";
            this.rdoLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLightToDark.UseVisualStyleBackColor = false;
            this.rdoLightToDark.CheckedChanged += new System.EventHandler(this.rdoSetEdgePolarity_CheckedChanged);
            // 
            // rdoDarkToLight
            // 
            this.rdoDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoDarkToLight.AutoSize = true;
            this.rdoDarkToLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoDarkToLight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoDarkToLight.Location = new System.Drawing.Point(3, 3);
            this.rdoDarkToLight.Name = "rdoDarkToLight";
            this.rdoDarkToLight.Size = new System.Drawing.Size(234, 43);
            this.rdoDarkToLight.TabIndex = 5;
            this.rdoDarkToLight.TabStop = true;
            this.rdoDarkToLight.Tag = "";
            this.rdoDarkToLight.Text = "DARK ▶ LIGHT";
            this.rdoDarkToLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoDarkToLight.UseVisualStyleBackColor = false;
            this.rdoDarkToLight.CheckedChanged += new System.EventHandler(this.rdoSetEdgePolarity_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(323, 444);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(234, 43);
            this.btnApply.TabIndex = 198;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnAlignTest
            // 
            this.btnAlignTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnAlignTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlignTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAlignTest.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnAlignTest.Location = new System.Drawing.Point(563, 395);
            this.btnAlignTest.Name = "btnAlignTest";
            this.btnAlignTest.Size = new System.Drawing.Size(234, 43);
            this.btnAlignTest.TabIndex = 198;
            this.btnAlignTest.Text = "ALIGN TEST";
            this.btnAlignTest.UseVisualStyleBackColor = false;
            this.btnAlignTest.Click += new System.EventHandler(this.btnAlignTest_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(563, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(234, 43);
            this.btnSave.TabIndex = 198;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpROIPosition
            // 
            this.tlpROIPosition.ColumnCount = 3;
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpROIPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpROIPosition.Controls.Add(this.tlpEdgePosition, 2, 1);
            this.tlpROIPosition.Controls.Add(this.tlpAlignPosition, 0, 1);
            this.tlpROIPosition.Controls.Add(this.tlpTargetObject, 1, 1);
            this.tlpROIPosition.Controls.Add(this.lblAlignPosition, 0, 0);
            this.tlpROIPosition.Controls.Add(this.lblTargetObject, 1, 0);
            this.tlpROIPosition.Controls.Add(this.lblEdgePosition, 2, 0);
            this.tlpROIPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpROIPosition.Location = new System.Drawing.Point(0, 0);
            this.tlpROIPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpROIPosition.Name = "tlpROIPosition";
            this.tlpROIPosition.RowCount = 2;
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpROIPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpROIPosition.Size = new System.Drawing.Size(800, 210);
            this.tlpROIPosition.TabIndex = 0;
            // 
            // tlpEdgePosition
            // 
            this.tlpEdgePosition.ColumnCount = 2;
            this.tlpEdgePosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePosition.Controls.Add(this.rdoEdgeX, 0, 0);
            this.tlpEdgePosition.Controls.Add(this.rdoEdgeY, 1, 0);
            this.tlpEdgePosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEdgePosition.Location = new System.Drawing.Point(532, 84);
            this.tlpEdgePosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEdgePosition.Name = "tlpEdgePosition";
            this.tlpEdgePosition.RowCount = 1;
            this.tlpEdgePosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEdgePosition.Size = new System.Drawing.Size(268, 126);
            this.tlpEdgePosition.TabIndex = 151;
            // 
            // rdoEdgeX
            // 
            this.rdoEdgeX.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoEdgeX.BackColor = System.Drawing.Color.DarkGray;
            this.rdoEdgeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoEdgeX.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoEdgeX.ForeColor = System.Drawing.Color.Black;
            this.rdoEdgeX.Location = new System.Drawing.Point(3, 3);
            this.rdoEdgeX.Name = "rdoEdgeX";
            this.rdoEdgeX.Size = new System.Drawing.Size(128, 120);
            this.rdoEdgeX.TabIndex = 0;
            this.rdoEdgeX.TabStop = true;
            this.rdoEdgeX.Text = "X";
            this.rdoEdgeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEdgeX.UseVisualStyleBackColor = false;
            this.rdoEdgeX.CheckedChanged += new System.EventHandler(this.rdoSetEdgeType_CheckedChanged);
            // 
            // rdoEdgeY
            // 
            this.rdoEdgeY.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoEdgeY.BackColor = System.Drawing.Color.DarkGray;
            this.rdoEdgeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoEdgeY.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoEdgeY.Location = new System.Drawing.Point(137, 3);
            this.rdoEdgeY.Name = "rdoEdgeY";
            this.rdoEdgeY.Size = new System.Drawing.Size(128, 120);
            this.rdoEdgeY.TabIndex = 1;
            this.rdoEdgeY.TabStop = true;
            this.rdoEdgeY.Text = "Y";
            this.rdoEdgeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEdgeY.UseVisualStyleBackColor = false;
            this.rdoEdgeY.CheckedChanged += new System.EventHandler(this.rdoSetEdgeType_CheckedChanged);
            // 
            // tlpAlignPosition
            // 
            this.tlpAlignPosition.ColumnCount = 2;
            this.tlpAlignPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlignPosition.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlignPosition.Controls.Add(this.rdoAlignRight, 0, 0);
            this.tlpAlignPosition.Controls.Add(this.rdoAlignLeft, 0, 0);
            this.tlpAlignPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAlignPosition.Location = new System.Drawing.Point(0, 84);
            this.tlpAlignPosition.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAlignPosition.Name = "tlpAlignPosition";
            this.tlpAlignPosition.RowCount = 1;
            this.tlpAlignPosition.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAlignPosition.Size = new System.Drawing.Size(266, 126);
            this.tlpAlignPosition.TabIndex = 0;
            // 
            // rdoAlignRight
            // 
            this.rdoAlignRight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAlignRight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoAlignRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAlignRight.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoAlignRight.ForeColor = System.Drawing.Color.Black;
            this.rdoAlignRight.Location = new System.Drawing.Point(136, 3);
            this.rdoAlignRight.Name = "rdoAlignRight";
            this.rdoAlignRight.Size = new System.Drawing.Size(127, 120);
            this.rdoAlignRight.TabIndex = 142;
            this.rdoAlignRight.Tag = "0";
            this.rdoAlignRight.Text = "RIGHT";
            this.rdoAlignRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAlignRight.UseVisualStyleBackColor = false;
            this.rdoAlignRight.CheckedChanged += new System.EventHandler(this.rdoSetAlignPosition_CheckedChanged);
            // 
            // rdoAlignLeft
            // 
            this.rdoAlignLeft.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAlignLeft.BackColor = System.Drawing.Color.DarkGray;
            this.rdoAlignLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAlignLeft.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoAlignLeft.ForeColor = System.Drawing.Color.Black;
            this.rdoAlignLeft.Location = new System.Drawing.Point(3, 3);
            this.rdoAlignLeft.Name = "rdoAlignLeft";
            this.rdoAlignLeft.Size = new System.Drawing.Size(127, 120);
            this.rdoAlignLeft.TabIndex = 141;
            this.rdoAlignLeft.Tag = "0";
            this.rdoAlignLeft.Text = "LEFT";
            this.rdoAlignLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAlignLeft.UseVisualStyleBackColor = false;
            this.rdoAlignLeft.CheckedChanged += new System.EventHandler(this.rdoSetAlignPosition_CheckedChanged);
            // 
            // tlpTargetObject
            // 
            this.tlpTargetObject.ColumnCount = 2;
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTargetObject.Controls.Add(this.rdoPanel, 0, 0);
            this.tlpTargetObject.Controls.Add(this.rdoFPC, 0, 0);
            this.tlpTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTargetObject.Location = new System.Drawing.Point(266, 84);
            this.tlpTargetObject.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTargetObject.Name = "tlpTargetObject";
            this.tlpTargetObject.RowCount = 1;
            this.tlpTargetObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTargetObject.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tlpTargetObject.Size = new System.Drawing.Size(266, 126);
            this.tlpTargetObject.TabIndex = 1;
            // 
            // rdoPanel
            // 
            this.rdoPanel.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoPanel.BackColor = System.Drawing.Color.DarkGray;
            this.rdoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoPanel.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoPanel.ForeColor = System.Drawing.Color.Black;
            this.rdoPanel.Location = new System.Drawing.Point(136, 3);
            this.rdoPanel.Name = "rdoPanel";
            this.rdoPanel.Size = new System.Drawing.Size(127, 120);
            this.rdoPanel.TabIndex = 143;
            this.rdoPanel.Tag = "0";
            this.rdoPanel.Text = "PANEL";
            this.rdoPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoPanel.UseVisualStyleBackColor = false;
            this.rdoPanel.CheckedChanged += new System.EventHandler(this.rdoSetTargetObject_CheckedChanged);
            // 
            // rdoFPC
            // 
            this.rdoFPC.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoFPC.BackColor = System.Drawing.Color.DarkGray;
            this.rdoFPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoFPC.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.rdoFPC.ForeColor = System.Drawing.Color.Black;
            this.rdoFPC.Location = new System.Drawing.Point(3, 3);
            this.rdoFPC.Name = "rdoFPC";
            this.rdoFPC.Size = new System.Drawing.Size(127, 120);
            this.rdoFPC.TabIndex = 142;
            this.rdoFPC.Tag = "0";
            this.rdoFPC.Text = "FPC";
            this.rdoFPC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoFPC.UseVisualStyleBackColor = false;
            this.rdoFPC.CheckedChanged += new System.EventHandler(this.rdoSetTargetObject_CheckedChanged);
            // 
            // lblAlignPosition
            // 
            this.lblAlignPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlignPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlignPosition.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblAlignPosition.Location = new System.Drawing.Point(6, 3);
            this.lblAlignPosition.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblAlignPosition.Name = "lblAlignPosition";
            this.lblAlignPosition.Size = new System.Drawing.Size(254, 78);
            this.lblAlignPosition.TabIndex = 140;
            this.lblAlignPosition.Text = "ALIGN POSITION";
            this.lblAlignPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetObject
            // 
            this.lblTargetObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetObject.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTargetObject.Location = new System.Drawing.Point(272, 3);
            this.lblTargetObject.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblTargetObject.Name = "lblTargetObject";
            this.lblTargetObject.Size = new System.Drawing.Size(254, 78);
            this.lblTargetObject.TabIndex = 149;
            this.lblTargetObject.Text = "TARGET OBJECT";
            this.lblTargetObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgePosition
            // 
            this.lblEdgePosition.AutoSize = true;
            this.lblEdgePosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEdgePosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEdgePosition.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblEdgePosition.Location = new System.Drawing.Point(538, 3);
            this.lblEdgePosition.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.lblEdgePosition.Name = "lblEdgePosition";
            this.lblEdgePosition.Size = new System.Drawing.Size(256, 78);
            this.lblEdgePosition.TabIndex = 150;
            this.lblEdgePosition.Text = "EDGE POSITION";
            this.lblEdgePosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlTeachAlign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeachAlign);
            this.Name = "CtrlTeachAlign";
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.CtrlTeachAlign_Load);
            this.tlpTeachAlign.ResumeLayout(false);
            this.tlpEdgeParameter.ResumeLayout(false);
            this.tlpEdgeParameter.PerformLayout();
            this.tlpEdgePolarity.ResumeLayout(false);
            this.tlpEdgePolarity.PerformLayout();
            this.tlpROIPosition.ResumeLayout(false);
            this.tlpROIPosition.PerformLayout();
            this.tlpEdgePosition.ResumeLayout(false);
            this.tlpAlignPosition.ResumeLayout(false);
            this.tlpTargetObject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpTeachAlign;
        private System.Windows.Forms.TableLayoutPanel tlpEdgeParameter;
        private System.Windows.Forms.CheckBox chkROITracking;
        private System.Windows.Forms.Label lblLeadCount;
        private System.Windows.Forms.Label lblFilterSize;
        private System.Windows.Forms.Label lblEdgeThreshold;
        private System.Windows.Forms.Label lblEdgePolarity;
        private System.Windows.Forms.Label lblLeadCountValue;
        private System.Windows.Forms.Label lblFilterSizeValue;
        private System.Windows.Forms.Label lblEdgeThresholdValue;
        private System.Windows.Forms.RadioButton rdoDarkToLight;
        private System.Windows.Forms.RadioButton rdoLightToDark;
        private System.Windows.Forms.TableLayoutPanel tlpROIPosition;
        private System.Windows.Forms.TableLayoutPanel tlpEdgePosition;
        private System.Windows.Forms.RadioButton rdoEdgeX;
        private System.Windows.Forms.RadioButton rdoEdgeY;
        private System.Windows.Forms.Label lblAlignPosition;
        private System.Windows.Forms.Label lblTargetObject;
        private System.Windows.Forms.Label lblEdgePosition;
        private System.Windows.Forms.TableLayoutPanel tlpAlignPosition;
        private System.Windows.Forms.RadioButton rdoAlignRight;
        private System.Windows.Forms.RadioButton rdoAlignLeft;
        private System.Windows.Forms.TableLayoutPanel tlpTargetObject;
        private System.Windows.Forms.RadioButton rdoPanel;
        private System.Windows.Forms.RadioButton rdoFPC;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnROIShow;
        private System.Windows.Forms.Button btnAlignTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpEdgePolarity;
    }
}
