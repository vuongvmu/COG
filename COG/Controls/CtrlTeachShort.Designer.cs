﻿namespace COG.Controls
{
    partial class CtrlTeachShort
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
            this.tlpTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBlobParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblBeadCount = new System.Windows.Forms.Label();
            this.cmbBeadPointSelect = new System.Windows.Forms.ComboBox();
            this.lblBeadCountValue = new System.Windows.Forms.Label();
            this.btnSearchTest = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnFindPath = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnTrainROI = new System.Windows.Forms.Button();
            this.btnBlobTest = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkAutoCompute = new System.Windows.Forms.CheckBox();
            this.lblWidthValue = new System.Windows.Forms.Label();
            this.tlpBeadWidth = new System.Windows.Forms.TableLayoutPanel();
            this.lblBeadWidth = new System.Windows.Forms.Label();
            this.lblBeadWidthValue = new System.Windows.Forms.Label();
            this.tlpContrastThreshold = new System.Windows.Forms.TableLayoutPanel();
            this.lblTrainContrastThreshold = new System.Windows.Forms.Label();
            this.lblTrainContrastThresholdValue = new System.Windows.Forms.Label();
            this.tlpBeadPolarity = new System.Windows.Forms.TableLayoutPanel();
            this.lblPolarity = new System.Windows.Forms.Label();
            this.tlpPolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoBeadLight = new System.Windows.Forms.RadioButton();
            this.rdoBeadDark = new System.Windows.Forms.RadioButton();
            this.lblMaxResult = new System.Windows.Forms.Label();
            this.lblMaxWidthDeviation = new System.Windows.Forms.Label();
            this.lblMaxSkipCount = new System.Windows.Forms.Label();
            this.lblMaxResultValue = new System.Windows.Forms.Label();
            this.lblMaxWidthDeviationValue = new System.Windows.Forms.Label();
            this.lblMaxSkipCountValue = new System.Windows.Forms.Label();
            this.lblCaliperSpacing = new System.Windows.Forms.Label();
            this.lblSmoothingFactor = new System.Windows.Forms.Label();
            this.lblStepThreshold = new System.Windows.Forms.Label();
            this.lblCaliperSpacingValue = new System.Windows.Forms.Label();
            this.lblSmoothingFactorValue = new System.Windows.Forms.Label();
            this.lblContrastThreshold = new System.Windows.Forms.Label();
            this.lblContrastThresholdValue = new System.Windows.Forms.Label();
            this.lblAbsoluteDistance = new System.Windows.Forms.Label();
            this.lblAbsoluteDistanceValue = new System.Windows.Forms.Label();
            this.lblConsecutiveFallingCaliper = new System.Windows.Forms.Label();
            this.lblConsecutiveFallingCaliperValue = new System.Windows.Forms.Label();
            this.lblCoverage = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblCoverageValue = new System.Windows.Forms.Label();
            this.lblStepThresholdValue = new System.Windows.Forms.Label();
            this.tlpTeach.SuspendLayout();
            this.tlpBlobParameter.SuspendLayout();
            this.tlpBeadWidth.SuspendLayout();
            this.tlpContrastThreshold.SuspendLayout();
            this.tlpBeadPolarity.SuspendLayout();
            this.tlpPolarity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeach
            // 
            this.tlpTeach.ColumnCount = 1;
            this.tlpTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Controls.Add(this.tlpBlobParameter, 0, 1);
            this.tlpTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpTeach.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeach.Name = "tlpTeach";
            this.tlpTeach.RowCount = 2;
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Size = new System.Drawing.Size(800, 700);
            this.tlpTeach.TabIndex = 289;
            // 
            // tlpBlobParameter
            // 
            this.tlpBlobParameter.ColumnCount = 4;
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBlobParameter.Controls.Add(this.lblBeadCount, 0, 0);
            this.tlpBlobParameter.Controls.Add(this.cmbBeadPointSelect, 2, 0);
            this.tlpBlobParameter.Controls.Add(this.lblBeadCountValue, 1, 0);
            this.tlpBlobParameter.Controls.Add(this.btnSearchTest, 2, 9);
            this.tlpBlobParameter.Controls.Add(this.btnTrain, 1, 9);
            this.tlpBlobParameter.Controls.Add(this.btnFindPath, 0, 9);
            this.tlpBlobParameter.Controls.Add(this.btnFind, 1, 8);
            this.tlpBlobParameter.Controls.Add(this.btnTrainROI, 0, 8);
            this.tlpBlobParameter.Controls.Add(this.btnBlobTest, 3, 11);
            this.tlpBlobParameter.Controls.Add(this.btnApply, 0, 11);
            this.tlpBlobParameter.Controls.Add(this.chkAutoCompute, 0, 2);
            this.tlpBlobParameter.Controls.Add(this.lblWidthValue, 3, 7);
            this.tlpBlobParameter.Controls.Add(this.tlpBeadWidth, 1, 2);
            this.tlpBlobParameter.Controls.Add(this.tlpContrastThreshold, 2, 2);
            this.tlpBlobParameter.Controls.Add(this.tlpBeadPolarity, 3, 2);
            this.tlpBlobParameter.Controls.Add(this.lblMaxResult, 0, 3);
            this.tlpBlobParameter.Controls.Add(this.lblMaxWidthDeviation, 0, 4);
            this.tlpBlobParameter.Controls.Add(this.lblMaxSkipCount, 0, 5);
            this.tlpBlobParameter.Controls.Add(this.lblMaxResultValue, 1, 3);
            this.tlpBlobParameter.Controls.Add(this.lblMaxWidthDeviationValue, 1, 4);
            this.tlpBlobParameter.Controls.Add(this.lblMaxSkipCountValue, 1, 5);
            this.tlpBlobParameter.Controls.Add(this.lblCaliperSpacing, 0, 6);
            this.tlpBlobParameter.Controls.Add(this.lblSmoothingFactor, 0, 7);
            this.tlpBlobParameter.Controls.Add(this.lblStepThreshold, 2, 8);
            this.tlpBlobParameter.Controls.Add(this.lblCaliperSpacingValue, 1, 6);
            this.tlpBlobParameter.Controls.Add(this.lblSmoothingFactorValue, 1, 7);
            this.tlpBlobParameter.Controls.Add(this.lblContrastThreshold, 2, 3);
            this.tlpBlobParameter.Controls.Add(this.lblContrastThresholdValue, 3, 3);
            this.tlpBlobParameter.Controls.Add(this.lblAbsoluteDistance, 2, 4);
            this.tlpBlobParameter.Controls.Add(this.lblAbsoluteDistanceValue, 3, 4);
            this.tlpBlobParameter.Controls.Add(this.lblConsecutiveFallingCaliper, 2, 5);
            this.tlpBlobParameter.Controls.Add(this.lblConsecutiveFallingCaliperValue, 3, 5);
            this.tlpBlobParameter.Controls.Add(this.lblCoverage, 2, 6);
            this.tlpBlobParameter.Controls.Add(this.lblWidth, 2, 7);
            this.tlpBlobParameter.Controls.Add(this.lblCoverageValue, 3, 6);
            this.tlpBlobParameter.Controls.Add(this.lblStepThresholdValue, 3, 8);
            this.tlpBlobParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBlobParameter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpBlobParameter.Location = new System.Drawing.Point(0, 30);
            this.tlpBlobParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBlobParameter.Name = "tlpBlobParameter";
            this.tlpBlobParameter.RowCount = 12;
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333334F));
            this.tlpBlobParameter.Size = new System.Drawing.Size(800, 670);
            this.tlpBlobParameter.TabIndex = 290;
            // 
            // lblBeadCount
            // 
            this.lblBeadCount.AutoSize = true;
            this.lblBeadCount.BackColor = System.Drawing.Color.Silver;
            this.lblBeadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeadCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeadCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBeadCount.Location = new System.Drawing.Point(0, 0);
            this.lblBeadCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblBeadCount.Name = "lblBeadCount";
            this.lblBeadCount.Size = new System.Drawing.Size(200, 30);
            this.lblBeadCount.TabIndex = 200;
            this.lblBeadCount.Text = "BEAD COUNT";
            this.lblBeadCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbBeadPointSelect
            // 
            this.cmbBeadPointSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBeadPointSelect.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbBeadPointSelect.FormattingEnabled = true;
            this.cmbBeadPointSelect.Location = new System.Drawing.Point(400, 1);
            this.cmbBeadPointSelect.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.cmbBeadPointSelect.Name = "cmbBeadPointSelect";
            this.cmbBeadPointSelect.Size = new System.Drawing.Size(200, 28);
            this.cmbBeadPointSelect.TabIndex = 202;
            this.cmbBeadPointSelect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbBeadPointSelect.SelectedIndexChanged += new System.EventHandler(this.cmbBeadPointSelect_SelectedIndexChanged);
            // 
            // lblBeadCountValue
            // 
            this.lblBeadCountValue.AutoSize = true;
            this.lblBeadCountValue.BackColor = System.Drawing.Color.White;
            this.lblBeadCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeadCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeadCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBeadCountValue.Location = new System.Drawing.Point(200, 0);
            this.lblBeadCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblBeadCountValue.Name = "lblBeadCountValue";
            this.lblBeadCountValue.Size = new System.Drawing.Size(200, 30);
            this.lblBeadCountValue.TabIndex = 8;
            this.lblBeadCountValue.Text = "0";
            this.lblBeadCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBeadCountValue.Click += new System.EventHandler(this.lblBeadCountValue_Click);
            // 
            // btnSearchTest
            // 
            this.btnSearchTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnSearchTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearchTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearchTest.Location = new System.Drawing.Point(400, 507);
            this.btnSearchTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearchTest.Name = "btnSearchTest";
            this.btnSearchTest.Size = new System.Drawing.Size(200, 53);
            this.btnSearchTest.TabIndex = 214;
            this.btnSearchTest.Text = "SEARCH TEST";
            this.btnSearchTest.UseVisualStyleBackColor = false;
            this.btnSearchTest.Click += new System.EventHandler(this.btnSearchTest_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.BackColor = System.Drawing.Color.DarkGray;
            this.btnTrain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrain.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnTrain.Location = new System.Drawing.Point(200, 507);
            this.btnTrain.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(200, 53);
            this.btnTrain.TabIndex = 213;
            this.btnTrain.Text = "TRAIN";
            this.btnTrain.UseVisualStyleBackColor = false;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnFindPath
            // 
            this.btnFindPath.BackColor = System.Drawing.Color.DarkGray;
            this.btnFindPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFindPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFindPath.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnFindPath.Location = new System.Drawing.Point(0, 507);
            this.btnFindPath.Margin = new System.Windows.Forms.Padding(0);
            this.btnFindPath.Name = "btnFindPath";
            this.btnFindPath.Size = new System.Drawing.Size(200, 53);
            this.btnFindPath.TabIndex = 212;
            this.btnFindPath.Text = "FIND PATH";
            this.btnFindPath.UseVisualStyleBackColor = false;
            this.btnFindPath.Click += new System.EventHandler(this.btnFindPath_Click);
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.DarkGray;
            this.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFind.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnFind.Location = new System.Drawing.Point(200, 454);
            this.btnFind.Margin = new System.Windows.Forms.Padding(0);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(200, 53);
            this.btnFind.TabIndex = 211;
            this.btnFind.Text = "FIND";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnTrainROI
            // 
            this.btnTrainROI.BackColor = System.Drawing.Color.DarkGray;
            this.btnTrainROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTrainROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTrainROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnTrainROI.Location = new System.Drawing.Point(0, 454);
            this.btnTrainROI.Margin = new System.Windows.Forms.Padding(0);
            this.btnTrainROI.Name = "btnTrainROI";
            this.btnTrainROI.Size = new System.Drawing.Size(200, 53);
            this.btnTrainROI.TabIndex = 198;
            this.btnTrainROI.Text = "TRAIN ROI";
            this.btnTrainROI.UseVisualStyleBackColor = false;
            this.btnTrainROI.Click += new System.EventHandler(this.btnTrainROI_Click);
            // 
            // btnBlobTest
            // 
            this.btnBlobTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnBlobTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBlobTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBlobTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnBlobTest.Location = new System.Drawing.Point(600, 613);
            this.btnBlobTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlobTest.Name = "btnBlobTest";
            this.btnBlobTest.Size = new System.Drawing.Size(200, 57);
            this.btnBlobTest.TabIndex = 198;
            this.btnBlobTest.Text = "BEAD TEST";
            this.btnBlobTest.UseVisualStyleBackColor = false;
            this.btnBlobTest.Click += new System.EventHandler(this.btnBlobTest_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(0, 613);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(200, 57);
            this.btnApply.TabIndex = 198;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkAutoCompute
            // 
            this.chkAutoCompute.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoCompute.AutoSize = true;
            this.chkAutoCompute.BackColor = System.Drawing.Color.DarkGray;
            this.chkAutoCompute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkAutoCompute.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkAutoCompute.Location = new System.Drawing.Point(0, 83);
            this.chkAutoCompute.Margin = new System.Windows.Forms.Padding(0);
            this.chkAutoCompute.Name = "chkAutoCompute";
            this.chkAutoCompute.Size = new System.Drawing.Size(200, 106);
            this.chkAutoCompute.TabIndex = 209;
            this.chkAutoCompute.Text = "AUTO COMPUTE";
            this.chkAutoCompute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkAutoCompute.UseVisualStyleBackColor = false;
            this.chkAutoCompute.CheckedChanged += new System.EventHandler(this.chkAutoCompute_CheckedChanged);
            // 
            // lblWidthValue
            // 
            this.lblWidthValue.AutoSize = true;
            this.lblWidthValue.BackColor = System.Drawing.Color.White;
            this.lblWidthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWidthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWidthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWidthValue.Location = new System.Drawing.Point(600, 401);
            this.lblWidthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblWidthValue.Name = "lblWidthValue";
            this.lblWidthValue.Size = new System.Drawing.Size(200, 53);
            this.lblWidthValue.TabIndex = 9;
            this.lblWidthValue.Text = "0";
            this.lblWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWidthValue.Click += new System.EventHandler(this.lblWidthValue_Click);
            // 
            // tlpBeadWidth
            // 
            this.tlpBeadWidth.ColumnCount = 1;
            this.tlpBeadWidth.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadWidth.Controls.Add(this.lblBeadWidth, 0, 0);
            this.tlpBeadWidth.Controls.Add(this.lblBeadWidthValue, 0, 1);
            this.tlpBeadWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBeadWidth.Location = new System.Drawing.Point(200, 83);
            this.tlpBeadWidth.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBeadWidth.Name = "tlpBeadWidth";
            this.tlpBeadWidth.RowCount = 2;
            this.tlpBeadWidth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadWidth.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadWidth.Size = new System.Drawing.Size(200, 106);
            this.tlpBeadWidth.TabIndex = 210;
            // 
            // lblBeadWidth
            // 
            this.lblBeadWidth.AutoSize = true;
            this.lblBeadWidth.BackColor = System.Drawing.Color.Silver;
            this.lblBeadWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeadWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeadWidth.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBeadWidth.Location = new System.Drawing.Point(0, 0);
            this.lblBeadWidth.Margin = new System.Windows.Forms.Padding(0);
            this.lblBeadWidth.Name = "lblBeadWidth";
            this.lblBeadWidth.Size = new System.Drawing.Size(200, 53);
            this.lblBeadWidth.TabIndex = 201;
            this.lblBeadWidth.Text = "BEAD WIDTH";
            this.lblBeadWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBeadWidthValue
            // 
            this.lblBeadWidthValue.AutoSize = true;
            this.lblBeadWidthValue.BackColor = System.Drawing.Color.White;
            this.lblBeadWidthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBeadWidthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBeadWidthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBeadWidthValue.Location = new System.Drawing.Point(0, 53);
            this.lblBeadWidthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblBeadWidthValue.Name = "lblBeadWidthValue";
            this.lblBeadWidthValue.Size = new System.Drawing.Size(200, 53);
            this.lblBeadWidthValue.TabIndex = 9;
            this.lblBeadWidthValue.Text = "0";
            this.lblBeadWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBeadWidthValue.Click += new System.EventHandler(this.lblBeadWidthValue_Click);
            // 
            // tlpContrastThreshold
            // 
            this.tlpContrastThreshold.ColumnCount = 1;
            this.tlpContrastThreshold.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContrastThreshold.Controls.Add(this.lblTrainContrastThreshold, 0, 0);
            this.tlpContrastThreshold.Controls.Add(this.lblTrainContrastThresholdValue, 0, 1);
            this.tlpContrastThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContrastThreshold.Location = new System.Drawing.Point(400, 83);
            this.tlpContrastThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContrastThreshold.Name = "tlpContrastThreshold";
            this.tlpContrastThreshold.RowCount = 2;
            this.tlpContrastThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContrastThreshold.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpContrastThreshold.Size = new System.Drawing.Size(200, 106);
            this.tlpContrastThreshold.TabIndex = 210;
            // 
            // lblTrainContrastThreshold
            // 
            this.lblTrainContrastThreshold.AutoSize = true;
            this.lblTrainContrastThreshold.BackColor = System.Drawing.Color.Silver;
            this.lblTrainContrastThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrainContrastThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrainContrastThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTrainContrastThreshold.Location = new System.Drawing.Point(0, 0);
            this.lblTrainContrastThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrainContrastThreshold.Name = "lblTrainContrastThreshold";
            this.lblTrainContrastThreshold.Size = new System.Drawing.Size(200, 53);
            this.lblTrainContrastThreshold.TabIndex = 201;
            this.lblTrainContrastThreshold.Text = "CONTRAST THRESHOLD";
            this.lblTrainContrastThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrainContrastThresholdValue
            // 
            this.lblTrainContrastThresholdValue.AutoSize = true;
            this.lblTrainContrastThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblTrainContrastThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTrainContrastThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrainContrastThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTrainContrastThresholdValue.Location = new System.Drawing.Point(0, 53);
            this.lblTrainContrastThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrainContrastThresholdValue.Name = "lblTrainContrastThresholdValue";
            this.lblTrainContrastThresholdValue.Size = new System.Drawing.Size(200, 53);
            this.lblTrainContrastThresholdValue.TabIndex = 9;
            this.lblTrainContrastThresholdValue.Text = "0";
            this.lblTrainContrastThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTrainContrastThresholdValue.Click += new System.EventHandler(this.lblTrainContrastThresholdValue_Click);
            // 
            // tlpBeadPolarity
            // 
            this.tlpBeadPolarity.ColumnCount = 1;
            this.tlpBeadPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadPolarity.Controls.Add(this.lblPolarity, 0, 0);
            this.tlpBeadPolarity.Controls.Add(this.tlpPolarity, 0, 1);
            this.tlpBeadPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBeadPolarity.Location = new System.Drawing.Point(600, 83);
            this.tlpBeadPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBeadPolarity.Name = "tlpBeadPolarity";
            this.tlpBeadPolarity.RowCount = 2;
            this.tlpBeadPolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadPolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBeadPolarity.Size = new System.Drawing.Size(200, 106);
            this.tlpBeadPolarity.TabIndex = 210;
            // 
            // lblPolarity
            // 
            this.lblPolarity.AutoSize = true;
            this.lblPolarity.BackColor = System.Drawing.Color.Silver;
            this.lblPolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPolarity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPolarity.Location = new System.Drawing.Point(0, 0);
            this.lblPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblPolarity.Name = "lblPolarity";
            this.lblPolarity.Size = new System.Drawing.Size(200, 53);
            this.lblPolarity.TabIndex = 201;
            this.lblPolarity.Text = "POLARITY";
            this.lblPolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpPolarity
            // 
            this.tlpPolarity.ColumnCount = 2;
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Controls.Add(this.rdoBeadLight, 0, 0);
            this.tlpPolarity.Controls.Add(this.rdoBeadDark, 0, 0);
            this.tlpPolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPolarity.Location = new System.Drawing.Point(0, 53);
            this.tlpPolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPolarity.Name = "tlpPolarity";
            this.tlpPolarity.RowCount = 1;
            this.tlpPolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPolarity.Size = new System.Drawing.Size(200, 53);
            this.tlpPolarity.TabIndex = 208;
            // 
            // rdoBeadLight
            // 
            this.rdoBeadLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBeadLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoBeadLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoBeadLight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoBeadLight.ForeColor = System.Drawing.Color.Black;
            this.rdoBeadLight.Location = new System.Drawing.Point(100, 0);
            this.rdoBeadLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoBeadLight.Name = "rdoBeadLight";
            this.rdoBeadLight.Size = new System.Drawing.Size(100, 53);
            this.rdoBeadLight.TabIndex = 143;
            this.rdoBeadLight.Tag = "0";
            this.rdoBeadLight.Text = "LIGHT";
            this.rdoBeadLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBeadLight.UseVisualStyleBackColor = false;
            this.rdoBeadLight.CheckedChanged += new System.EventHandler(this.rdoSetBeadPolarity_CheckedChanged);
            // 
            // rdoBeadDark
            // 
            this.rdoBeadDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBeadDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoBeadDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoBeadDark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoBeadDark.ForeColor = System.Drawing.Color.Black;
            this.rdoBeadDark.Location = new System.Drawing.Point(0, 0);
            this.rdoBeadDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoBeadDark.Name = "rdoBeadDark";
            this.rdoBeadDark.Size = new System.Drawing.Size(100, 53);
            this.rdoBeadDark.TabIndex = 142;
            this.rdoBeadDark.Tag = "0";
            this.rdoBeadDark.Text = "DARK";
            this.rdoBeadDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBeadDark.UseVisualStyleBackColor = false;
            this.rdoBeadDark.CheckedChanged += new System.EventHandler(this.rdoSetBeadPolarity_CheckedChanged);
            // 
            // lblMaxResult
            // 
            this.lblMaxResult.AutoSize = true;
            this.lblMaxResult.BackColor = System.Drawing.Color.Silver;
            this.lblMaxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxResult.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxResult.Location = new System.Drawing.Point(0, 189);
            this.lblMaxResult.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxResult.Name = "lblMaxResult";
            this.lblMaxResult.Size = new System.Drawing.Size(200, 53);
            this.lblMaxResult.TabIndex = 201;
            this.lblMaxResult.Text = "MAX RESULT";
            this.lblMaxResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxWidthDeviation
            // 
            this.lblMaxWidthDeviation.AutoSize = true;
            this.lblMaxWidthDeviation.BackColor = System.Drawing.Color.Silver;
            this.lblMaxWidthDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWidthDeviation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxWidthDeviation.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxWidthDeviation.Location = new System.Drawing.Point(0, 242);
            this.lblMaxWidthDeviation.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxWidthDeviation.Name = "lblMaxWidthDeviation";
            this.lblMaxWidthDeviation.Size = new System.Drawing.Size(200, 53);
            this.lblMaxWidthDeviation.TabIndex = 201;
            this.lblMaxWidthDeviation.Text = "MAX WIDTH DEVIATION";
            this.lblMaxWidthDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxSkipCount
            // 
            this.lblMaxSkipCount.AutoSize = true;
            this.lblMaxSkipCount.BackColor = System.Drawing.Color.Silver;
            this.lblMaxSkipCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSkipCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSkipCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSkipCount.Location = new System.Drawing.Point(0, 295);
            this.lblMaxSkipCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSkipCount.Name = "lblMaxSkipCount";
            this.lblMaxSkipCount.Size = new System.Drawing.Size(200, 53);
            this.lblMaxSkipCount.TabIndex = 201;
            this.lblMaxSkipCount.Text = "MAX SKP COUNT";
            this.lblMaxSkipCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxResultValue
            // 
            this.lblMaxResultValue.AutoSize = true;
            this.lblMaxResultValue.BackColor = System.Drawing.Color.White;
            this.lblMaxResultValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxResultValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxResultValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxResultValue.Location = new System.Drawing.Point(200, 189);
            this.lblMaxResultValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxResultValue.Name = "lblMaxResultValue";
            this.lblMaxResultValue.Size = new System.Drawing.Size(200, 53);
            this.lblMaxResultValue.TabIndex = 9;
            this.lblMaxResultValue.Text = "0";
            this.lblMaxResultValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxResultValue.Click += new System.EventHandler(this.lblMaxResultValue_Click);
            // 
            // lblMaxWidthDeviationValue
            // 
            this.lblMaxWidthDeviationValue.AutoSize = true;
            this.lblMaxWidthDeviationValue.BackColor = System.Drawing.Color.White;
            this.lblMaxWidthDeviationValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxWidthDeviationValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxWidthDeviationValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxWidthDeviationValue.Location = new System.Drawing.Point(200, 242);
            this.lblMaxWidthDeviationValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxWidthDeviationValue.Name = "lblMaxWidthDeviationValue";
            this.lblMaxWidthDeviationValue.Size = new System.Drawing.Size(200, 53);
            this.lblMaxWidthDeviationValue.TabIndex = 9;
            this.lblMaxWidthDeviationValue.Text = "0";
            this.lblMaxWidthDeviationValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxWidthDeviationValue.Click += new System.EventHandler(this.lblMaxWidthDeviationValue_Click);
            // 
            // lblMaxSkipCountValue
            // 
            this.lblMaxSkipCountValue.AutoSize = true;
            this.lblMaxSkipCountValue.BackColor = System.Drawing.Color.White;
            this.lblMaxSkipCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSkipCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSkipCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSkipCountValue.Location = new System.Drawing.Point(200, 295);
            this.lblMaxSkipCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSkipCountValue.Name = "lblMaxSkipCountValue";
            this.lblMaxSkipCountValue.Size = new System.Drawing.Size(200, 53);
            this.lblMaxSkipCountValue.TabIndex = 9;
            this.lblMaxSkipCountValue.Text = "0";
            this.lblMaxSkipCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxSkipCountValue.Click += new System.EventHandler(this.lblMaxSkipCountValue_Click);
            // 
            // lblCaliperSpacing
            // 
            this.lblCaliperSpacing.AutoSize = true;
            this.lblCaliperSpacing.BackColor = System.Drawing.Color.Silver;
            this.lblCaliperSpacing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaliperSpacing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaliperSpacing.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCaliperSpacing.Location = new System.Drawing.Point(0, 348);
            this.lblCaliperSpacing.Margin = new System.Windows.Forms.Padding(0);
            this.lblCaliperSpacing.Name = "lblCaliperSpacing";
            this.lblCaliperSpacing.Size = new System.Drawing.Size(200, 53);
            this.lblCaliperSpacing.TabIndex = 201;
            this.lblCaliperSpacing.Text = "CALIPER SPACING";
            this.lblCaliperSpacing.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSmoothingFactor
            // 
            this.lblSmoothingFactor.AutoSize = true;
            this.lblSmoothingFactor.BackColor = System.Drawing.Color.Silver;
            this.lblSmoothingFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSmoothingFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSmoothingFactor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSmoothingFactor.Location = new System.Drawing.Point(0, 401);
            this.lblSmoothingFactor.Margin = new System.Windows.Forms.Padding(0);
            this.lblSmoothingFactor.Name = "lblSmoothingFactor";
            this.lblSmoothingFactor.Size = new System.Drawing.Size(200, 53);
            this.lblSmoothingFactor.TabIndex = 201;
            this.lblSmoothingFactor.Text = "SMOOTING FACTOR";
            this.lblSmoothingFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStepThreshold
            // 
            this.lblStepThreshold.AutoSize = true;
            this.lblStepThreshold.BackColor = System.Drawing.Color.Silver;
            this.lblStepThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepThreshold.Location = new System.Drawing.Point(400, 454);
            this.lblStepThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblStepThreshold.Name = "lblStepThreshold";
            this.lblStepThreshold.Size = new System.Drawing.Size(200, 53);
            this.lblStepThreshold.TabIndex = 201;
            this.lblStepThreshold.Text = "STEP THRESHOLD";
            this.lblStepThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCaliperSpacingValue
            // 
            this.lblCaliperSpacingValue.AutoSize = true;
            this.lblCaliperSpacingValue.BackColor = System.Drawing.Color.White;
            this.lblCaliperSpacingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCaliperSpacingValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaliperSpacingValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCaliperSpacingValue.Location = new System.Drawing.Point(200, 348);
            this.lblCaliperSpacingValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCaliperSpacingValue.Name = "lblCaliperSpacingValue";
            this.lblCaliperSpacingValue.Size = new System.Drawing.Size(200, 53);
            this.lblCaliperSpacingValue.TabIndex = 9;
            this.lblCaliperSpacingValue.Text = "0";
            this.lblCaliperSpacingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCaliperSpacingValue.Click += new System.EventHandler(this.lblCaliperSpacingValue_Click);
            // 
            // lblSmoothingFactorValue
            // 
            this.lblSmoothingFactorValue.AutoSize = true;
            this.lblSmoothingFactorValue.BackColor = System.Drawing.Color.White;
            this.lblSmoothingFactorValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSmoothingFactorValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSmoothingFactorValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSmoothingFactorValue.Location = new System.Drawing.Point(200, 401);
            this.lblSmoothingFactorValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblSmoothingFactorValue.Name = "lblSmoothingFactorValue";
            this.lblSmoothingFactorValue.Size = new System.Drawing.Size(200, 53);
            this.lblSmoothingFactorValue.TabIndex = 9;
            this.lblSmoothingFactorValue.Text = "0";
            this.lblSmoothingFactorValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSmoothingFactorValue.Click += new System.EventHandler(this.lblSmoothingFactorValue_Click);
            // 
            // lblContrastThreshold
            // 
            this.lblContrastThreshold.AutoSize = true;
            this.lblContrastThreshold.BackColor = System.Drawing.Color.Silver;
            this.lblContrastThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContrastThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrastThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblContrastThreshold.Location = new System.Drawing.Point(400, 189);
            this.lblContrastThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblContrastThreshold.Name = "lblContrastThreshold";
            this.lblContrastThreshold.Size = new System.Drawing.Size(200, 53);
            this.lblContrastThreshold.TabIndex = 201;
            this.lblContrastThreshold.Text = "CONTRAST THRESHOLD";
            this.lblContrastThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContrastThresholdValue
            // 
            this.lblContrastThresholdValue.AutoSize = true;
            this.lblContrastThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblContrastThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContrastThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblContrastThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblContrastThresholdValue.Location = new System.Drawing.Point(600, 189);
            this.lblContrastThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblContrastThresholdValue.Name = "lblContrastThresholdValue";
            this.lblContrastThresholdValue.Size = new System.Drawing.Size(200, 53);
            this.lblContrastThresholdValue.TabIndex = 9;
            this.lblContrastThresholdValue.Text = "0";
            this.lblContrastThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblContrastThresholdValue.Click += new System.EventHandler(this.lblContrastThresholdValue_Click);
            // 
            // lblAbsoluteDistance
            // 
            this.lblAbsoluteDistance.AutoSize = true;
            this.lblAbsoluteDistance.BackColor = System.Drawing.Color.Silver;
            this.lblAbsoluteDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAbsoluteDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAbsoluteDistance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAbsoluteDistance.Location = new System.Drawing.Point(400, 242);
            this.lblAbsoluteDistance.Margin = new System.Windows.Forms.Padding(0);
            this.lblAbsoluteDistance.Name = "lblAbsoluteDistance";
            this.lblAbsoluteDistance.Size = new System.Drawing.Size(200, 53);
            this.lblAbsoluteDistance.TabIndex = 201;
            this.lblAbsoluteDistance.Text = "ABSOLUTE DISTANCE";
            this.lblAbsoluteDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbsoluteDistanceValue
            // 
            this.lblAbsoluteDistanceValue.AutoSize = true;
            this.lblAbsoluteDistanceValue.BackColor = System.Drawing.Color.White;
            this.lblAbsoluteDistanceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAbsoluteDistanceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAbsoluteDistanceValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAbsoluteDistanceValue.Location = new System.Drawing.Point(600, 242);
            this.lblAbsoluteDistanceValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAbsoluteDistanceValue.Name = "lblAbsoluteDistanceValue";
            this.lblAbsoluteDistanceValue.Size = new System.Drawing.Size(200, 53);
            this.lblAbsoluteDistanceValue.TabIndex = 9;
            this.lblAbsoluteDistanceValue.Text = "0";
            this.lblAbsoluteDistanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAbsoluteDistanceValue.Click += new System.EventHandler(this.lblAbsoluteDistanceValue_Click);
            // 
            // lblConsecutiveFallingCaliper
            // 
            this.lblConsecutiveFallingCaliper.AutoSize = true;
            this.lblConsecutiveFallingCaliper.BackColor = System.Drawing.Color.Silver;
            this.lblConsecutiveFallingCaliper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsecutiveFallingCaliper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConsecutiveFallingCaliper.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblConsecutiveFallingCaliper.Location = new System.Drawing.Point(400, 295);
            this.lblConsecutiveFallingCaliper.Margin = new System.Windows.Forms.Padding(0);
            this.lblConsecutiveFallingCaliper.Name = "lblConsecutiveFallingCaliper";
            this.lblConsecutiveFallingCaliper.Size = new System.Drawing.Size(200, 53);
            this.lblConsecutiveFallingCaliper.TabIndex = 201;
            this.lblConsecutiveFallingCaliper.Text = "CONSECUTIVE FALLING CALIPER";
            this.lblConsecutiveFallingCaliper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblConsecutiveFallingCaliperValue
            // 
            this.lblConsecutiveFallingCaliperValue.AutoSize = true;
            this.lblConsecutiveFallingCaliperValue.BackColor = System.Drawing.Color.White;
            this.lblConsecutiveFallingCaliperValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConsecutiveFallingCaliperValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConsecutiveFallingCaliperValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblConsecutiveFallingCaliperValue.Location = new System.Drawing.Point(600, 295);
            this.lblConsecutiveFallingCaliperValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblConsecutiveFallingCaliperValue.Name = "lblConsecutiveFallingCaliperValue";
            this.lblConsecutiveFallingCaliperValue.Size = new System.Drawing.Size(200, 53);
            this.lblConsecutiveFallingCaliperValue.TabIndex = 9;
            this.lblConsecutiveFallingCaliperValue.Text = "0";
            this.lblConsecutiveFallingCaliperValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConsecutiveFallingCaliperValue.Click += new System.EventHandler(this.lblConsecutiveFallingCaliperValue_Click);
            // 
            // lblCoverage
            // 
            this.lblCoverage.AutoSize = true;
            this.lblCoverage.BackColor = System.Drawing.Color.Silver;
            this.lblCoverage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoverage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCoverage.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCoverage.Location = new System.Drawing.Point(400, 348);
            this.lblCoverage.Margin = new System.Windows.Forms.Padding(0);
            this.lblCoverage.Name = "lblCoverage";
            this.lblCoverage.Size = new System.Drawing.Size(200, 53);
            this.lblCoverage.TabIndex = 201;
            this.lblCoverage.Text = "CONVERAGE";
            this.lblCoverage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.BackColor = System.Drawing.Color.Silver;
            this.lblWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWidth.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWidth.Location = new System.Drawing.Point(400, 401);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(200, 53);
            this.lblWidth.TabIndex = 201;
            this.lblWidth.Text = "WIDTH";
            this.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCoverageValue
            // 
            this.lblCoverageValue.AutoSize = true;
            this.lblCoverageValue.BackColor = System.Drawing.Color.White;
            this.lblCoverageValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCoverageValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCoverageValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCoverageValue.Location = new System.Drawing.Point(600, 348);
            this.lblCoverageValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCoverageValue.Name = "lblCoverageValue";
            this.lblCoverageValue.Size = new System.Drawing.Size(200, 53);
            this.lblCoverageValue.TabIndex = 9;
            this.lblCoverageValue.Text = "0";
            this.lblCoverageValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCoverageValue.Click += new System.EventHandler(this.lblCoverageValue_Click);
            // 
            // lblStepThresholdValue
            // 
            this.lblStepThresholdValue.AutoSize = true;
            this.lblStepThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblStepThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStepThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStepThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStepThresholdValue.Location = new System.Drawing.Point(600, 454);
            this.lblStepThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStepThresholdValue.Name = "lblStepThresholdValue";
            this.lblStepThresholdValue.Size = new System.Drawing.Size(200, 53);
            this.lblStepThresholdValue.TabIndex = 9;
            this.lblStepThresholdValue.Text = "0";
            this.lblStepThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStepThresholdValue.Click += new System.EventHandler(this.lblStepThresholdValue_Click);
            // 
            // CtrlTeachShort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeach);
            this.Name = "CtrlTeachShort";
            this.Size = new System.Drawing.Size(800, 700);
            this.Load += new System.EventHandler(this.CtrlTeachBead_Load);
            this.tlpTeach.ResumeLayout(false);
            this.tlpBlobParameter.ResumeLayout(false);
            this.tlpBlobParameter.PerformLayout();
            this.tlpBeadWidth.ResumeLayout(false);
            this.tlpBeadWidth.PerformLayout();
            this.tlpContrastThreshold.ResumeLayout(false);
            this.tlpContrastThreshold.PerformLayout();
            this.tlpBeadPolarity.ResumeLayout(false);
            this.tlpBeadPolarity.PerformLayout();
            this.tlpPolarity.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tlpTeach;
        private System.Windows.Forms.Label lblBeadCount;
        private System.Windows.Forms.Label lblBeadCountValue;
        private System.Windows.Forms.ComboBox cmbBeadPointSelect;
        private System.Windows.Forms.TableLayoutPanel tlpBlobParameter;
        private System.Windows.Forms.Button btnTrainROI;
        private System.Windows.Forms.Button btnBlobTest;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tlpPolarity;
        private System.Windows.Forms.RadioButton rdoBeadLight;
        private System.Windows.Forms.RadioButton rdoBeadDark;
        private System.Windows.Forms.Label lblTrainContrastThresholdValue;
        private System.Windows.Forms.Label lblBeadWidth;
        private System.Windows.Forms.CheckBox chkAutoCompute;
        private System.Windows.Forms.Label lblTrainContrastThreshold;
        private System.Windows.Forms.Label lblStepThreshold;
        private System.Windows.Forms.Label lblBeadWidthValue;
        private System.Windows.Forms.Label lblWidthValue;
        private System.Windows.Forms.Label lblMaxResult;
        private System.Windows.Forms.Label lblMaxResultValue;
        private System.Windows.Forms.Label lblMaxWidthDeviation;
        private System.Windows.Forms.Label lblMaxWidthDeviationValue;
        private System.Windows.Forms.Label lblPolarity;
        private System.Windows.Forms.Label lblMaxSkipCount;
        private System.Windows.Forms.Label lblMaxSkipCountValue;
        private System.Windows.Forms.TableLayoutPanel tlpBeadWidth;
        private System.Windows.Forms.TableLayoutPanel tlpContrastThreshold;
        private System.Windows.Forms.TableLayoutPanel tlpBeadPolarity;
        private System.Windows.Forms.Label lblCaliperSpacing;
        private System.Windows.Forms.Label lblSmoothingFactor;
        private System.Windows.Forms.Label lblCaliperSpacingValue;
        private System.Windows.Forms.Label lblSmoothingFactorValue;
        private System.Windows.Forms.Label lblContrastThreshold;
        private System.Windows.Forms.Label lblContrastThresholdValue;
        private System.Windows.Forms.Label lblAbsoluteDistance;
        private System.Windows.Forms.Label lblAbsoluteDistanceValue;
        private System.Windows.Forms.Label lblConsecutiveFallingCaliper;
        private System.Windows.Forms.Label lblConsecutiveFallingCaliperValue;
        private System.Windows.Forms.Label lblCoverage;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblCoverageValue;
        private System.Windows.Forms.Label lblStepThresholdValue;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnFindPath;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnSearchTest;
    }
}
