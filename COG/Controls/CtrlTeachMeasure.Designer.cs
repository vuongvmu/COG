namespace COG.Controls
{
    partial class CtrlTeachMeasure
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
            this.tlpTeachMeasure = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMeasureType = new System.Windows.Forms.TableLayoutPanel();
            this.lblMeasureType = new System.Windows.Forms.Label();
            this.tlpSearchType = new System.Windows.Forms.TableLayoutPanel();
            this.rdoMeasureCircle = new System.Windows.Forms.RadioButton();
            this.rdoMeasureLine = new System.Windows.Forms.RadioButton();
            this.pnlMeasureParameter = new System.Windows.Forms.Panel();
            this.pnlMeasureCircle = new System.Windows.Forms.Panel();
            this.tlpMeasureCircle = new System.Windows.Forms.TableLayoutPanel();
            this.cmbCirclePointSelect = new System.Windows.Forms.ComboBox();
            this.lblCircleCount = new System.Windows.Forms.Label();
            this.lblCirclePointValue = new System.Windows.Forms.Label();
            this.btnCircleApply = new System.Windows.Forms.Button();
            this.lblCircleProjectionLength = new System.Windows.Forms.Label();
            this.lblCircleSearchLength = new System.Windows.Forms.Label();
            this.lblCircleIgnoreNumber = new System.Windows.Forms.Label();
            this.lblCircleCaliperNumber = new System.Windows.Forms.Label();
            this.lblCircleEdgePolarity = new System.Windows.Forms.Label();
            this.tlpCircleEdgePolarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCircleEdgeLightToDark = new System.Windows.Forms.RadioButton();
            this.rdoCircleEdgeDarkToLight = new System.Windows.Forms.RadioButton();
            this.lblCircleProjectionLengthValue = new System.Windows.Forms.Label();
            this.lblCircleSearchLengthValue = new System.Windows.Forms.Label();
            this.lblCircleCaliperNumberValue = new System.Windows.Forms.Label();
            this.lblCircleIgnoreNumberValue = new System.Windows.Forms.Label();
            this.lblCircleSearchDirection = new System.Windows.Forms.Label();
            this.lblCircleContrast = new System.Windows.Forms.Label();
            this.lblCircleContrastValue = new System.Windows.Forms.Label();
            this.tlpCircleSearchDirection = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCircleSearchOutward = new System.Windows.Forms.RadioButton();
            this.rdoCircleSearchInward = new System.Windows.Forms.RadioButton();
            this.btnCircleMeasureTest = new System.Windows.Forms.Button();
            this.chkCircleMeasureROITracking = new System.Windows.Forms.CheckBox();
            this.btnCircleROIShow = new System.Windows.Forms.Button();
            this.pnlMeasureLine = new System.Windows.Forms.Panel();
            this.tlpMeasureLine = new System.Windows.Forms.TableLayoutPanel();
            this.lblLineCount = new System.Windows.Forms.Label();
            this.lblLinePointValue = new System.Windows.Forms.Label();
            this.lblLineEdgeThreshold = new System.Windows.Forms.Label();
            this.lblLineFilterSize = new System.Windows.Forms.Label();
            this.lblLine1EdgeFilterSizeValue = new System.Windows.Forms.Label();
            this.lblLinePoint1 = new System.Windows.Forms.Label();
            this.lblLine2EdgeThresholdValue = new System.Windows.Forms.Label();
            this.lblLine2EdgeFilterSizeValue = new System.Windows.Forms.Label();
            this.lblLine1EdgeThresholdValue = new System.Windows.Forms.Label();
            this.lblLinePoint2 = new System.Windows.Forms.Label();
            this.lblLineEdgePolarity = new System.Windows.Forms.Label();
            this.tlpLinePoint1Polarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoLine1EdgeLightToDark = new System.Windows.Forms.RadioButton();
            this.rdoLine1EdgeDarkToLight = new System.Windows.Forms.RadioButton();
            this.tlpLinePoint2Polarity = new System.Windows.Forms.TableLayoutPanel();
            this.rdoLine2EdgeLightToDark = new System.Windows.Forms.RadioButton();
            this.rdoLine2EdgeDarkToLight = new System.Windows.Forms.RadioButton();
            this.cmbLinePointSelect = new System.Windows.Forms.ComboBox();
            this.btnLineApply = new System.Windows.Forms.Button();
            this.btnLineMeasureTest = new System.Windows.Forms.Button();
            this.chkLineMeasureROITracking = new System.Windows.Forms.CheckBox();
            this.btnLineROIShow = new System.Windows.Forms.Button();
            this.tlpTeachMeasure.SuspendLayout();
            this.tlpMeasureType.SuspendLayout();
            this.tlpSearchType.SuspendLayout();
            this.pnlMeasureParameter.SuspendLayout();
            this.pnlMeasureCircle.SuspendLayout();
            this.tlpMeasureCircle.SuspendLayout();
            this.tlpCircleEdgePolarity.SuspendLayout();
            this.tlpCircleSearchDirection.SuspendLayout();
            this.pnlMeasureLine.SuspendLayout();
            this.tlpMeasureLine.SuspendLayout();
            this.tlpLinePoint1Polarity.SuspendLayout();
            this.tlpLinePoint2Polarity.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeachMeasure
            // 
            this.tlpTeachMeasure.ColumnCount = 1;
            this.tlpTeachMeasure.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachMeasure.Controls.Add(this.tlpMeasureType, 0, 1);
            this.tlpTeachMeasure.Controls.Add(this.pnlMeasureParameter, 0, 3);
            this.tlpTeachMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachMeasure.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachMeasure.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachMeasure.Name = "tlpTeachMeasure";
            this.tlpTeachMeasure.RowCount = 7;
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTeachMeasure.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeachMeasure.Size = new System.Drawing.Size(800, 900);
            this.tlpTeachMeasure.TabIndex = 289;
            // 
            // tlpMeasureType
            // 
            this.tlpMeasureType.ColumnCount = 1;
            this.tlpMeasureType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMeasureType.Controls.Add(this.lblMeasureType, 0, 0);
            this.tlpMeasureType.Controls.Add(this.tlpSearchType, 0, 1);
            this.tlpMeasureType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMeasureType.Location = new System.Drawing.Point(0, 30);
            this.tlpMeasureType.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMeasureType.Name = "tlpMeasureType";
            this.tlpMeasureType.RowCount = 2;
            this.tlpMeasureType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMeasureType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMeasureType.Size = new System.Drawing.Size(800, 60);
            this.tlpMeasureType.TabIndex = 0;
            // 
            // lblMeasureType
            // 
            this.lblMeasureType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMeasureType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeasureType.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblMeasureType.Location = new System.Drawing.Point(0, 0);
            this.lblMeasureType.Margin = new System.Windows.Forms.Padding(0);
            this.lblMeasureType.Name = "lblMeasureType";
            this.lblMeasureType.Size = new System.Drawing.Size(800, 30);
            this.lblMeasureType.TabIndex = 141;
            this.lblMeasureType.Text = "MEASURE TYPE";
            this.lblMeasureType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSearchType
            // 
            this.tlpSearchType.ColumnCount = 2;
            this.tlpSearchType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSearchType.Controls.Add(this.rdoMeasureCircle, 0, 0);
            this.tlpSearchType.Controls.Add(this.rdoMeasureLine, 0, 0);
            this.tlpSearchType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearchType.Location = new System.Drawing.Point(0, 30);
            this.tlpSearchType.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSearchType.Name = "tlpSearchType";
            this.tlpSearchType.RowCount = 1;
            this.tlpSearchType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearchType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpSearchType.Size = new System.Drawing.Size(800, 30);
            this.tlpSearchType.TabIndex = 142;
            // 
            // rdoMeasureCircle
            // 
            this.rdoMeasureCircle.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMeasureCircle.AutoSize = true;
            this.rdoMeasureCircle.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMeasureCircle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMeasureCircle.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMeasureCircle.Location = new System.Drawing.Point(400, 0);
            this.rdoMeasureCircle.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMeasureCircle.Name = "rdoMeasureCircle";
            this.rdoMeasureCircle.Size = new System.Drawing.Size(400, 30);
            this.rdoMeasureCircle.TabIndex = 8;
            this.rdoMeasureCircle.TabStop = true;
            this.rdoMeasureCircle.Tag = "2";
            this.rdoMeasureCircle.Text = "CIRCLE";
            this.rdoMeasureCircle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMeasureCircle.UseVisualStyleBackColor = false;
            this.rdoMeasureCircle.CheckedChanged += new System.EventHandler(this.rdoSetMeasureType_CheckedChanged);
            // 
            // rdoMeasureLine
            // 
            this.rdoMeasureLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMeasureLine.AutoSize = true;
            this.rdoMeasureLine.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMeasureLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMeasureLine.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMeasureLine.Location = new System.Drawing.Point(0, 0);
            this.rdoMeasureLine.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMeasureLine.Name = "rdoMeasureLine";
            this.rdoMeasureLine.Size = new System.Drawing.Size(400, 30);
            this.rdoMeasureLine.TabIndex = 7;
            this.rdoMeasureLine.TabStop = true;
            this.rdoMeasureLine.Tag = "2";
            this.rdoMeasureLine.Text = "LINE";
            this.rdoMeasureLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMeasureLine.UseVisualStyleBackColor = false;
            this.rdoMeasureLine.CheckedChanged += new System.EventHandler(this.rdoSetMeasureType_CheckedChanged);
            // 
            // pnlMeasureParameter
            // 
            this.pnlMeasureParameter.Controls.Add(this.pnlMeasureCircle);
            this.pnlMeasureParameter.Controls.Add(this.pnlMeasureLine);
            this.pnlMeasureParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMeasureParameter.Location = new System.Drawing.Point(0, 120);
            this.pnlMeasureParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMeasureParameter.Name = "pnlMeasureParameter";
            this.pnlMeasureParameter.Size = new System.Drawing.Size(800, 612);
            this.pnlMeasureParameter.TabIndex = 292;
            // 
            // pnlMeasureCircle
            // 
            this.pnlMeasureCircle.Controls.Add(this.tlpMeasureCircle);
            this.pnlMeasureCircle.Location = new System.Drawing.Point(423, 3);
            this.pnlMeasureCircle.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMeasureCircle.Name = "pnlMeasureCircle";
            this.pnlMeasureCircle.Size = new System.Drawing.Size(377, 609);
            this.pnlMeasureCircle.TabIndex = 297;
            // 
            // tlpMeasureCircle
            // 
            this.tlpMeasureCircle.ColumnCount = 4;
            this.tlpMeasureCircle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureCircle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureCircle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureCircle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureCircle.Controls.Add(this.cmbCirclePointSelect, 2, 0);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleCount, 0, 0);
            this.tlpMeasureCircle.Controls.Add(this.lblCirclePointValue, 1, 0);
            this.tlpMeasureCircle.Controls.Add(this.btnCircleApply, 0, 9);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleProjectionLength, 0, 3);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleSearchLength, 0, 4);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleIgnoreNumber, 2, 6);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleCaliperNumber, 0, 6);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleEdgePolarity, 0, 5);
            this.tlpMeasureCircle.Controls.Add(this.tlpCircleEdgePolarity, 1, 5);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleProjectionLengthValue, 1, 3);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleSearchLengthValue, 1, 4);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleCaliperNumberValue, 1, 6);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleIgnoreNumberValue, 3, 6);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleSearchDirection, 2, 5);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleContrast, 2, 3);
            this.tlpMeasureCircle.Controls.Add(this.lblCircleContrastValue, 3, 3);
            this.tlpMeasureCircle.Controls.Add(this.tlpCircleSearchDirection, 3, 5);
            this.tlpMeasureCircle.Controls.Add(this.btnCircleMeasureTest, 3, 9);
            this.tlpMeasureCircle.Controls.Add(this.chkCircleMeasureROITracking, 1, 7);
            this.tlpMeasureCircle.Controls.Add(this.btnCircleROIShow, 0, 7);
            this.tlpMeasureCircle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMeasureCircle.Location = new System.Drawing.Point(0, 0);
            this.tlpMeasureCircle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMeasureCircle.Name = "tlpMeasureCircle";
            this.tlpMeasureCircle.RowCount = 10;
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureCircle.Size = new System.Drawing.Size(377, 609);
            this.tlpMeasureCircle.TabIndex = 292;
            // 
            // cmbCirclePointSelect
            // 
            this.cmbCirclePointSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCirclePointSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCirclePointSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCirclePointSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbCirclePointSelect.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbCirclePointSelect.FormattingEnabled = true;
            this.cmbCirclePointSelect.Location = new System.Drawing.Point(194, 1);
            this.cmbCirclePointSelect.Margin = new System.Windows.Forms.Padding(6, 1, 6, 0);
            this.cmbCirclePointSelect.Name = "cmbCirclePointSelect";
            this.cmbCirclePointSelect.Size = new System.Drawing.Size(82, 28);
            this.cmbCirclePointSelect.TabIndex = 264;
            this.cmbCirclePointSelect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbCirclePointSelect.SelectedIndexChanged += new System.EventHandler(this.cmbMeasurePointIndex_SelectedIndexChanged);
            // 
            // lblCircleCount
            // 
            this.lblCircleCount.AutoSize = true;
            this.lblCircleCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleCount.Location = new System.Drawing.Point(0, 0);
            this.lblCircleCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleCount.Name = "lblCircleCount";
            this.lblCircleCount.Size = new System.Drawing.Size(94, 30);
            this.lblCircleCount.TabIndex = 201;
            this.lblCircleCount.Text = "MEASURE COUNT";
            this.lblCircleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCirclePointValue
            // 
            this.lblCirclePointValue.AutoSize = true;
            this.lblCirclePointValue.BackColor = System.Drawing.Color.White;
            this.lblCirclePointValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCirclePointValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCirclePointValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCirclePointValue.Location = new System.Drawing.Point(94, 0);
            this.lblCirclePointValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCirclePointValue.Name = "lblCirclePointValue";
            this.lblCirclePointValue.Size = new System.Drawing.Size(94, 30);
            this.lblCirclePointValue.TabIndex = 8;
            this.lblCirclePointValue.Text = "0";
            this.lblCirclePointValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCirclePointValue.Click += new System.EventHandler(this.lblSetMeasurePointValue_Click);
            // 
            // btnCircleApply
            // 
            this.btnCircleApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnCircleApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCircleApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCircleApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCircleApply.Location = new System.Drawing.Point(0, 541);
            this.btnCircleApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnCircleApply.Name = "btnCircleApply";
            this.btnCircleApply.Size = new System.Drawing.Size(94, 68);
            this.btnCircleApply.TabIndex = 198;
            this.btnCircleApply.Text = "APPLY";
            this.btnCircleApply.UseVisualStyleBackColor = false;
            this.btnCircleApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblCircleProjectionLength
            // 
            this.lblCircleProjectionLength.AutoSize = true;
            this.lblCircleProjectionLength.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleProjectionLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleProjectionLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleProjectionLength.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleProjectionLength.Location = new System.Drawing.Point(0, 120);
            this.lblCircleProjectionLength.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleProjectionLength.Name = "lblCircleProjectionLength";
            this.lblCircleProjectionLength.Size = new System.Drawing.Size(94, 60);
            this.lblCircleProjectionLength.TabIndex = 203;
            this.lblCircleProjectionLength.Text = "PROJECTION\r\nLENGTH";
            this.lblCircleProjectionLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleSearchLength
            // 
            this.lblCircleSearchLength.AutoSize = true;
            this.lblCircleSearchLength.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleSearchLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleSearchLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleSearchLength.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleSearchLength.Location = new System.Drawing.Point(0, 180);
            this.lblCircleSearchLength.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleSearchLength.Name = "lblCircleSearchLength";
            this.lblCircleSearchLength.Size = new System.Drawing.Size(94, 60);
            this.lblCircleSearchLength.TabIndex = 3;
            this.lblCircleSearchLength.Text = "SEARCH LENGTH";
            this.lblCircleSearchLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleIgnoreNumber
            // 
            this.lblCircleIgnoreNumber.AutoSize = true;
            this.lblCircleIgnoreNumber.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleIgnoreNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleIgnoreNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleIgnoreNumber.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleIgnoreNumber.Location = new System.Drawing.Point(188, 361);
            this.lblCircleIgnoreNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleIgnoreNumber.Name = "lblCircleIgnoreNumber";
            this.lblCircleIgnoreNumber.Size = new System.Drawing.Size(94, 60);
            this.lblCircleIgnoreNumber.TabIndex = 4;
            this.lblCircleIgnoreNumber.Text = "IGNORE COUNT";
            this.lblCircleIgnoreNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleCaliperNumber
            // 
            this.lblCircleCaliperNumber.AutoSize = true;
            this.lblCircleCaliperNumber.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleCaliperNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleCaliperNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleCaliperNumber.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleCaliperNumber.Location = new System.Drawing.Point(0, 361);
            this.lblCircleCaliperNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleCaliperNumber.Name = "lblCircleCaliperNumber";
            this.lblCircleCaliperNumber.Size = new System.Drawing.Size(94, 60);
            this.lblCircleCaliperNumber.TabIndex = 3;
            this.lblCircleCaliperNumber.Text = "CALIPER COUNT";
            this.lblCircleCaliperNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleEdgePolarity
            // 
            this.lblCircleEdgePolarity.AutoSize = true;
            this.lblCircleEdgePolarity.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleEdgePolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleEdgePolarity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleEdgePolarity.Location = new System.Drawing.Point(0, 240);
            this.lblCircleEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleEdgePolarity.Name = "lblCircleEdgePolarity";
            this.lblCircleEdgePolarity.Size = new System.Drawing.Size(94, 121);
            this.lblCircleEdgePolarity.TabIndex = 2;
            this.lblCircleEdgePolarity.Text = "EDGE POLARITY";
            this.lblCircleEdgePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCircleEdgePolarity
            // 
            this.tlpCircleEdgePolarity.ColumnCount = 1;
            this.tlpCircleEdgePolarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleEdgePolarity.Controls.Add(this.rdoCircleEdgeLightToDark, 0, 1);
            this.tlpCircleEdgePolarity.Controls.Add(this.rdoCircleEdgeDarkToLight, 0, 0);
            this.tlpCircleEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCircleEdgePolarity.Location = new System.Drawing.Point(94, 240);
            this.tlpCircleEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCircleEdgePolarity.Name = "tlpCircleEdgePolarity";
            this.tlpCircleEdgePolarity.RowCount = 2;
            this.tlpCircleEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleEdgePolarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCircleEdgePolarity.Size = new System.Drawing.Size(94, 121);
            this.tlpCircleEdgePolarity.TabIndex = 199;
            // 
            // rdoCircleEdgeLightToDark
            // 
            this.rdoCircleEdgeLightToDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCircleEdgeLightToDark.AutoSize = true;
            this.rdoCircleEdgeLightToDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCircleEdgeLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCircleEdgeLightToDark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCircleEdgeLightToDark.Location = new System.Drawing.Point(0, 60);
            this.rdoCircleEdgeLightToDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCircleEdgeLightToDark.Name = "rdoCircleEdgeLightToDark";
            this.rdoCircleEdgeLightToDark.Size = new System.Drawing.Size(94, 61);
            this.rdoCircleEdgeLightToDark.TabIndex = 6;
            this.rdoCircleEdgeLightToDark.TabStop = true;
            this.rdoCircleEdgeLightToDark.Tag = "2";
            this.rdoCircleEdgeLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoCircleEdgeLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCircleEdgeLightToDark.UseVisualStyleBackColor = false;
            this.rdoCircleEdgeLightToDark.CheckedChanged += new System.EventHandler(this.rdoSetCircleEdgePolarity_CheckedChanged);
            // 
            // rdoCircleEdgeDarkToLight
            // 
            this.rdoCircleEdgeDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCircleEdgeDarkToLight.AutoSize = true;
            this.rdoCircleEdgeDarkToLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCircleEdgeDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCircleEdgeDarkToLight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCircleEdgeDarkToLight.Location = new System.Drawing.Point(0, 0);
            this.rdoCircleEdgeDarkToLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCircleEdgeDarkToLight.Name = "rdoCircleEdgeDarkToLight";
            this.rdoCircleEdgeDarkToLight.Size = new System.Drawing.Size(94, 60);
            this.rdoCircleEdgeDarkToLight.TabIndex = 5;
            this.rdoCircleEdgeDarkToLight.TabStop = true;
            this.rdoCircleEdgeDarkToLight.Tag = "1";
            this.rdoCircleEdgeDarkToLight.Text = "DARK ▶ LIGHT";
            this.rdoCircleEdgeDarkToLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCircleEdgeDarkToLight.UseVisualStyleBackColor = false;
            this.rdoCircleEdgeDarkToLight.CheckedChanged += new System.EventHandler(this.rdoSetCircleEdgePolarity_CheckedChanged);
            // 
            // lblCircleProjectionLengthValue
            // 
            this.lblCircleProjectionLengthValue.AutoSize = true;
            this.lblCircleProjectionLengthValue.BackColor = System.Drawing.Color.White;
            this.lblCircleProjectionLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleProjectionLengthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleProjectionLengthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleProjectionLengthValue.Location = new System.Drawing.Point(94, 120);
            this.lblCircleProjectionLengthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleProjectionLengthValue.Name = "lblCircleProjectionLengthValue";
            this.lblCircleProjectionLengthValue.Size = new System.Drawing.Size(94, 60);
            this.lblCircleProjectionLengthValue.TabIndex = 266;
            this.lblCircleProjectionLengthValue.Text = "5";
            this.lblCircleProjectionLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCircleProjectionLengthValue.Click += new System.EventHandler(this.lblCircleProjectionLengthValue_Click);
            // 
            // lblCircleSearchLengthValue
            // 
            this.lblCircleSearchLengthValue.AutoSize = true;
            this.lblCircleSearchLengthValue.BackColor = System.Drawing.Color.White;
            this.lblCircleSearchLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleSearchLengthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleSearchLengthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleSearchLengthValue.Location = new System.Drawing.Point(94, 180);
            this.lblCircleSearchLengthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleSearchLengthValue.Name = "lblCircleSearchLengthValue";
            this.lblCircleSearchLengthValue.Size = new System.Drawing.Size(94, 60);
            this.lblCircleSearchLengthValue.TabIndex = 266;
            this.lblCircleSearchLengthValue.Text = "5";
            this.lblCircleSearchLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCircleSearchLengthValue.Click += new System.EventHandler(this.lblCircleSearchLengthValue_Click);
            // 
            // lblCircleCaliperNumberValue
            // 
            this.lblCircleCaliperNumberValue.AutoSize = true;
            this.lblCircleCaliperNumberValue.BackColor = System.Drawing.Color.White;
            this.lblCircleCaliperNumberValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleCaliperNumberValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleCaliperNumberValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleCaliperNumberValue.Location = new System.Drawing.Point(94, 361);
            this.lblCircleCaliperNumberValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleCaliperNumberValue.Name = "lblCircleCaliperNumberValue";
            this.lblCircleCaliperNumberValue.Size = new System.Drawing.Size(94, 60);
            this.lblCircleCaliperNumberValue.TabIndex = 266;
            this.lblCircleCaliperNumberValue.Text = "5";
            this.lblCircleCaliperNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCircleCaliperNumberValue.Click += new System.EventHandler(this.lblCircleCaliperNumberValue_Click);
            // 
            // lblCircleIgnoreNumberValue
            // 
            this.lblCircleIgnoreNumberValue.AutoSize = true;
            this.lblCircleIgnoreNumberValue.BackColor = System.Drawing.Color.White;
            this.lblCircleIgnoreNumberValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleIgnoreNumberValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleIgnoreNumberValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleIgnoreNumberValue.Location = new System.Drawing.Point(282, 361);
            this.lblCircleIgnoreNumberValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleIgnoreNumberValue.Name = "lblCircleIgnoreNumberValue";
            this.lblCircleIgnoreNumberValue.Size = new System.Drawing.Size(95, 60);
            this.lblCircleIgnoreNumberValue.TabIndex = 266;
            this.lblCircleIgnoreNumberValue.Text = "5";
            this.lblCircleIgnoreNumberValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCircleIgnoreNumberValue.Click += new System.EventHandler(this.lblCircleIgnoreNumberValue_Click);
            // 
            // lblCircleSearchDirection
            // 
            this.lblCircleSearchDirection.AutoSize = true;
            this.lblCircleSearchDirection.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleSearchDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleSearchDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleSearchDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleSearchDirection.Location = new System.Drawing.Point(188, 240);
            this.lblCircleSearchDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleSearchDirection.Name = "lblCircleSearchDirection";
            this.lblCircleSearchDirection.Size = new System.Drawing.Size(94, 121);
            this.lblCircleSearchDirection.TabIndex = 3;
            this.lblCircleSearchDirection.Text = "SEARCH DIRECTION";
            this.lblCircleSearchDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleContrast
            // 
            this.lblCircleContrast.AutoSize = true;
            this.lblCircleContrast.BackColor = System.Drawing.Color.DarkGray;
            this.lblCircleContrast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleContrast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleContrast.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleContrast.Location = new System.Drawing.Point(188, 120);
            this.lblCircleContrast.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleContrast.Name = "lblCircleContrast";
            this.lblCircleContrast.Size = new System.Drawing.Size(94, 60);
            this.lblCircleContrast.TabIndex = 203;
            this.lblCircleContrast.Text = "CONTRAST";
            this.lblCircleContrast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCircleContrastValue
            // 
            this.lblCircleContrastValue.AutoSize = true;
            this.lblCircleContrastValue.BackColor = System.Drawing.Color.White;
            this.lblCircleContrastValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCircleContrastValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCircleContrastValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCircleContrastValue.Location = new System.Drawing.Point(282, 120);
            this.lblCircleContrastValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCircleContrastValue.Name = "lblCircleContrastValue";
            this.lblCircleContrastValue.Size = new System.Drawing.Size(95, 60);
            this.lblCircleContrastValue.TabIndex = 266;
            this.lblCircleContrastValue.Text = "5";
            this.lblCircleContrastValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCircleContrastValue.Click += new System.EventHandler(this.lblCircleContrastValue_Click);
            // 
            // tlpCircleSearchDirection
            // 
            this.tlpCircleSearchDirection.ColumnCount = 1;
            this.tlpCircleSearchDirection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleSearchDirection.Controls.Add(this.rdoCircleSearchOutward, 0, 1);
            this.tlpCircleSearchDirection.Controls.Add(this.rdoCircleSearchInward, 0, 0);
            this.tlpCircleSearchDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCircleSearchDirection.Location = new System.Drawing.Point(282, 240);
            this.tlpCircleSearchDirection.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCircleSearchDirection.Name = "tlpCircleSearchDirection";
            this.tlpCircleSearchDirection.RowCount = 2;
            this.tlpCircleSearchDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleSearchDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCircleSearchDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCircleSearchDirection.Size = new System.Drawing.Size(95, 121);
            this.tlpCircleSearchDirection.TabIndex = 199;
            // 
            // rdoCircleSearchOutward
            // 
            this.rdoCircleSearchOutward.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCircleSearchOutward.AutoSize = true;
            this.rdoCircleSearchOutward.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCircleSearchOutward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCircleSearchOutward.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCircleSearchOutward.Location = new System.Drawing.Point(0, 60);
            this.rdoCircleSearchOutward.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCircleSearchOutward.Name = "rdoCircleSearchOutward";
            this.rdoCircleSearchOutward.Size = new System.Drawing.Size(95, 61);
            this.rdoCircleSearchOutward.TabIndex = 6;
            this.rdoCircleSearchOutward.TabStop = true;
            this.rdoCircleSearchOutward.Tag = "2";
            this.rdoCircleSearchOutward.Text = "OUTWARD";
            this.rdoCircleSearchOutward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCircleSearchOutward.UseVisualStyleBackColor = false;
            this.rdoCircleSearchOutward.CheckedChanged += new System.EventHandler(this.rdoSetCircleSearchDirction_CheckedChaged);
            // 
            // rdoCircleSearchInward
            // 
            this.rdoCircleSearchInward.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCircleSearchInward.AutoSize = true;
            this.rdoCircleSearchInward.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCircleSearchInward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCircleSearchInward.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCircleSearchInward.Location = new System.Drawing.Point(0, 0);
            this.rdoCircleSearchInward.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCircleSearchInward.Name = "rdoCircleSearchInward";
            this.rdoCircleSearchInward.Size = new System.Drawing.Size(95, 60);
            this.rdoCircleSearchInward.TabIndex = 5;
            this.rdoCircleSearchInward.TabStop = true;
            this.rdoCircleSearchInward.Tag = "1";
            this.rdoCircleSearchInward.Text = "INWARD";
            this.rdoCircleSearchInward.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCircleSearchInward.UseVisualStyleBackColor = false;
            this.rdoCircleSearchInward.CheckedChanged += new System.EventHandler(this.rdoSetCircleSearchDirction_CheckedChaged);
            // 
            // btnCircleMeasureTest
            // 
            this.btnCircleMeasureTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnCircleMeasureTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCircleMeasureTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCircleMeasureTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCircleMeasureTest.Location = new System.Drawing.Point(282, 541);
            this.btnCircleMeasureTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnCircleMeasureTest.Name = "btnCircleMeasureTest";
            this.btnCircleMeasureTest.Size = new System.Drawing.Size(95, 68);
            this.btnCircleMeasureTest.TabIndex = 198;
            this.btnCircleMeasureTest.Text = "MEASURE TEST";
            this.btnCircleMeasureTest.UseVisualStyleBackColor = false;
            this.btnCircleMeasureTest.Click += new System.EventHandler(this.btnMeasureTest_Click);
            // 
            // chkCircleMeasureROITracking
            // 
            this.chkCircleMeasureROITracking.AutoSize = true;
            this.chkCircleMeasureROITracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkCircleMeasureROITracking.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkCircleMeasureROITracking.Location = new System.Drawing.Point(94, 421);
            this.chkCircleMeasureROITracking.Margin = new System.Windows.Forms.Padding(0);
            this.chkCircleMeasureROITracking.Name = "chkCircleMeasureROITracking";
            this.chkCircleMeasureROITracking.Size = new System.Drawing.Size(94, 60);
            this.chkCircleMeasureROITracking.TabIndex = 299;
            this.chkCircleMeasureROITracking.Text = "ROI Tracking";
            this.chkCircleMeasureROITracking.UseVisualStyleBackColor = true;
            this.chkCircleMeasureROITracking.CheckedChanged += new System.EventHandler(this.chkROITracking_CheckedChanged);
            // 
            // btnCircleROIShow
            // 
            this.btnCircleROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnCircleROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCircleROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCircleROIShow.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCircleROIShow.Location = new System.Drawing.Point(0, 421);
            this.btnCircleROIShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnCircleROIShow.Name = "btnCircleROIShow";
            this.btnCircleROIShow.Size = new System.Drawing.Size(94, 60);
            this.btnCircleROIShow.TabIndex = 265;
            this.btnCircleROIShow.Text = "SHOW ROI";
            this.btnCircleROIShow.UseVisualStyleBackColor = false;
            this.btnCircleROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // pnlMeasureLine
            // 
            this.pnlMeasureLine.Controls.Add(this.tlpMeasureLine);
            this.pnlMeasureLine.Location = new System.Drawing.Point(2, 3);
            this.pnlMeasureLine.Name = "pnlMeasureLine";
            this.pnlMeasureLine.Size = new System.Drawing.Size(379, 609);
            this.pnlMeasureLine.TabIndex = 293;
            // 
            // tlpMeasureLine
            // 
            this.tlpMeasureLine.ColumnCount = 4;
            this.tlpMeasureLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMeasureLine.Controls.Add(this.lblLineCount, 0, 0);
            this.tlpMeasureLine.Controls.Add(this.lblLinePointValue, 1, 0);
            this.tlpMeasureLine.Controls.Add(this.lblLineEdgeThreshold, 0, 5);
            this.tlpMeasureLine.Controls.Add(this.lblLineFilterSize, 0, 4);
            this.tlpMeasureLine.Controls.Add(this.lblLine1EdgeFilterSizeValue, 1, 4);
            this.tlpMeasureLine.Controls.Add(this.lblLinePoint1, 1, 3);
            this.tlpMeasureLine.Controls.Add(this.lblLine2EdgeThresholdValue, 2, 5);
            this.tlpMeasureLine.Controls.Add(this.lblLine2EdgeFilterSizeValue, 2, 4);
            this.tlpMeasureLine.Controls.Add(this.lblLine1EdgeThresholdValue, 1, 5);
            this.tlpMeasureLine.Controls.Add(this.lblLinePoint2, 2, 3);
            this.tlpMeasureLine.Controls.Add(this.lblLineEdgePolarity, 0, 6);
            this.tlpMeasureLine.Controls.Add(this.tlpLinePoint1Polarity, 1, 6);
            this.tlpMeasureLine.Controls.Add(this.tlpLinePoint2Polarity, 2, 6);
            this.tlpMeasureLine.Controls.Add(this.cmbLinePointSelect, 2, 0);
            this.tlpMeasureLine.Controls.Add(this.btnLineApply, 0, 9);
            this.tlpMeasureLine.Controls.Add(this.btnLineMeasureTest, 3, 9);
            this.tlpMeasureLine.Controls.Add(this.chkLineMeasureROITracking, 1, 7);
            this.tlpMeasureLine.Controls.Add(this.btnLineROIShow, 0, 7);
            this.tlpMeasureLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMeasureLine.Location = new System.Drawing.Point(0, 0);
            this.tlpMeasureLine.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMeasureLine.Name = "tlpMeasureLine";
            this.tlpMeasureLine.RowCount = 10;
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMeasureLine.Size = new System.Drawing.Size(379, 609);
            this.tlpMeasureLine.TabIndex = 290;
            // 
            // lblLineCount
            // 
            this.lblLineCount.AutoSize = true;
            this.lblLineCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblLineCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLineCount.Location = new System.Drawing.Point(0, 0);
            this.lblLineCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineCount.Name = "lblLineCount";
            this.lblLineCount.Size = new System.Drawing.Size(94, 30);
            this.lblLineCount.TabIndex = 201;
            this.lblLineCount.Text = "MEASURE COUNT";
            this.lblLineCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLinePointValue
            // 
            this.lblLinePointValue.AutoSize = true;
            this.lblLinePointValue.BackColor = System.Drawing.Color.White;
            this.lblLinePointValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLinePointValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLinePointValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLinePointValue.Location = new System.Drawing.Point(94, 0);
            this.lblLinePointValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLinePointValue.Name = "lblLinePointValue";
            this.lblLinePointValue.Size = new System.Drawing.Size(94, 30);
            this.lblLinePointValue.TabIndex = 8;
            this.lblLinePointValue.Text = "0";
            this.lblLinePointValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLinePointValue.Click += new System.EventHandler(this.lblSetMeasurePointValue_Click);
            // 
            // lblLineEdgeThreshold
            // 
            this.lblLineEdgeThreshold.AutoSize = true;
            this.lblLineEdgeThreshold.BackColor = System.Drawing.Color.DarkGray;
            this.lblLineEdgeThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineEdgeThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineEdgeThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLineEdgeThreshold.Location = new System.Drawing.Point(0, 240);
            this.lblLineEdgeThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineEdgeThreshold.Name = "lblLineEdgeThreshold";
            this.lblLineEdgeThreshold.Size = new System.Drawing.Size(94, 60);
            this.lblLineEdgeThreshold.TabIndex = 3;
            this.lblLineEdgeThreshold.Text = "EDGE THRESHOLD";
            this.lblLineEdgeThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLineFilterSize
            // 
            this.lblLineFilterSize.AutoSize = true;
            this.lblLineFilterSize.BackColor = System.Drawing.Color.DarkGray;
            this.lblLineFilterSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineFilterSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineFilterSize.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLineFilterSize.Location = new System.Drawing.Point(0, 180);
            this.lblLineFilterSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineFilterSize.Name = "lblLineFilterSize";
            this.lblLineFilterSize.Size = new System.Drawing.Size(94, 60);
            this.lblLineFilterSize.TabIndex = 2;
            this.lblLineFilterSize.Text = "FILTER SIZE";
            this.lblLineFilterSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine1EdgeFilterSizeValue
            // 
            this.lblLine1EdgeFilterSizeValue.AutoSize = true;
            this.lblLine1EdgeFilterSizeValue.BackColor = System.Drawing.Color.White;
            this.lblLine1EdgeFilterSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine1EdgeFilterSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine1EdgeFilterSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLine1EdgeFilterSizeValue.Location = new System.Drawing.Point(94, 180);
            this.lblLine1EdgeFilterSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine1EdgeFilterSizeValue.Name = "lblLine1EdgeFilterSizeValue";
            this.lblLine1EdgeFilterSizeValue.Size = new System.Drawing.Size(94, 60);
            this.lblLine1EdgeFilterSizeValue.TabIndex = 8;
            this.lblLine1EdgeFilterSizeValue.Text = "5";
            this.lblLine1EdgeFilterSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine1EdgeFilterSizeValue.Click += new System.EventHandler(this.lblLineEdgeFilterSizeValue_Click);
            // 
            // lblLinePoint1
            // 
            this.lblLinePoint1.AutoSize = true;
            this.lblLinePoint1.BackColor = System.Drawing.Color.DarkGray;
            this.lblLinePoint1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLinePoint1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLinePoint1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLinePoint1.Location = new System.Drawing.Point(94, 120);
            this.lblLinePoint1.Margin = new System.Windows.Forms.Padding(0);
            this.lblLinePoint1.Name = "lblLinePoint1";
            this.lblLinePoint1.Size = new System.Drawing.Size(94, 60);
            this.lblLinePoint1.TabIndex = 203;
            this.lblLinePoint1.Text = "POINT 1";
            this.lblLinePoint1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLine2EdgeThresholdValue
            // 
            this.lblLine2EdgeThresholdValue.AutoSize = true;
            this.lblLine2EdgeThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblLine2EdgeThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine2EdgeThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine2EdgeThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLine2EdgeThresholdValue.Location = new System.Drawing.Point(188, 240);
            this.lblLine2EdgeThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine2EdgeThresholdValue.Name = "lblLine2EdgeThresholdValue";
            this.lblLine2EdgeThresholdValue.Size = new System.Drawing.Size(94, 60);
            this.lblLine2EdgeThresholdValue.TabIndex = 9;
            this.lblLine2EdgeThresholdValue.Text = "5";
            this.lblLine2EdgeThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine2EdgeThresholdValue.Click += new System.EventHandler(this.lblLineEdgeThresholdValue_Click);
            // 
            // lblLine2EdgeFilterSizeValue
            // 
            this.lblLine2EdgeFilterSizeValue.AutoSize = true;
            this.lblLine2EdgeFilterSizeValue.BackColor = System.Drawing.Color.White;
            this.lblLine2EdgeFilterSizeValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine2EdgeFilterSizeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine2EdgeFilterSizeValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLine2EdgeFilterSizeValue.Location = new System.Drawing.Point(188, 180);
            this.lblLine2EdgeFilterSizeValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine2EdgeFilterSizeValue.Name = "lblLine2EdgeFilterSizeValue";
            this.lblLine2EdgeFilterSizeValue.Size = new System.Drawing.Size(94, 60);
            this.lblLine2EdgeFilterSizeValue.TabIndex = 8;
            this.lblLine2EdgeFilterSizeValue.Text = "5";
            this.lblLine2EdgeFilterSizeValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine2EdgeFilterSizeValue.Click += new System.EventHandler(this.lblLineEdgeFilterSizeValue_Click);
            // 
            // lblLine1EdgeThresholdValue
            // 
            this.lblLine1EdgeThresholdValue.AutoSize = true;
            this.lblLine1EdgeThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblLine1EdgeThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLine1EdgeThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLine1EdgeThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLine1EdgeThresholdValue.Location = new System.Drawing.Point(94, 240);
            this.lblLine1EdgeThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLine1EdgeThresholdValue.Name = "lblLine1EdgeThresholdValue";
            this.lblLine1EdgeThresholdValue.Size = new System.Drawing.Size(94, 60);
            this.lblLine1EdgeThresholdValue.TabIndex = 9;
            this.lblLine1EdgeThresholdValue.Text = "5";
            this.lblLine1EdgeThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLine1EdgeThresholdValue.Click += new System.EventHandler(this.lblLineEdgeThresholdValue_Click);
            // 
            // lblLinePoint2
            // 
            this.lblLinePoint2.AutoSize = true;
            this.lblLinePoint2.BackColor = System.Drawing.Color.DarkGray;
            this.lblLinePoint2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLinePoint2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLinePoint2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLinePoint2.Location = new System.Drawing.Point(188, 120);
            this.lblLinePoint2.Margin = new System.Windows.Forms.Padding(0);
            this.lblLinePoint2.Name = "lblLinePoint2";
            this.lblLinePoint2.Size = new System.Drawing.Size(94, 60);
            this.lblLinePoint2.TabIndex = 203;
            this.lblLinePoint2.Text = "POINT 2";
            this.lblLinePoint2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLineEdgePolarity
            // 
            this.lblLineEdgePolarity.AutoSize = true;
            this.lblLineEdgePolarity.BackColor = System.Drawing.Color.DarkGray;
            this.lblLineEdgePolarity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineEdgePolarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineEdgePolarity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLineEdgePolarity.Location = new System.Drawing.Point(0, 300);
            this.lblLineEdgePolarity.Margin = new System.Windows.Forms.Padding(0);
            this.lblLineEdgePolarity.Name = "lblLineEdgePolarity";
            this.lblLineEdgePolarity.Size = new System.Drawing.Size(94, 121);
            this.lblLineEdgePolarity.TabIndex = 4;
            this.lblLineEdgePolarity.Text = "EDGE POLARITY";
            this.lblLineEdgePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLinePoint1Polarity
            // 
            this.tlpLinePoint1Polarity.ColumnCount = 1;
            this.tlpLinePoint1Polarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint1Polarity.Controls.Add(this.rdoLine1EdgeLightToDark, 0, 1);
            this.tlpLinePoint1Polarity.Controls.Add(this.rdoLine1EdgeDarkToLight, 0, 0);
            this.tlpLinePoint1Polarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLinePoint1Polarity.Location = new System.Drawing.Point(94, 300);
            this.tlpLinePoint1Polarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLinePoint1Polarity.Name = "tlpLinePoint1Polarity";
            this.tlpLinePoint1Polarity.RowCount = 2;
            this.tlpLinePoint1Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint1Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint1Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLinePoint1Polarity.Size = new System.Drawing.Size(94, 121);
            this.tlpLinePoint1Polarity.TabIndex = 199;
            // 
            // rdoLine1EdgeLightToDark
            // 
            this.rdoLine1EdgeLightToDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLine1EdgeLightToDark.AutoSize = true;
            this.rdoLine1EdgeLightToDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoLine1EdgeLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLine1EdgeLightToDark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoLine1EdgeLightToDark.Location = new System.Drawing.Point(0, 60);
            this.rdoLine1EdgeLightToDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLine1EdgeLightToDark.Name = "rdoLine1EdgeLightToDark";
            this.rdoLine1EdgeLightToDark.Size = new System.Drawing.Size(94, 61);
            this.rdoLine1EdgeLightToDark.TabIndex = 6;
            this.rdoLine1EdgeLightToDark.TabStop = true;
            this.rdoLine1EdgeLightToDark.Tag = "2";
            this.rdoLine1EdgeLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoLine1EdgeLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLine1EdgeLightToDark.UseVisualStyleBackColor = false;
            this.rdoLine1EdgeLightToDark.CheckedChanged += new System.EventHandler(this.rdoSetLineEdgePolarity_CheckedChanged);
            // 
            // rdoLine1EdgeDarkToLight
            // 
            this.rdoLine1EdgeDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLine1EdgeDarkToLight.AutoSize = true;
            this.rdoLine1EdgeDarkToLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoLine1EdgeDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLine1EdgeDarkToLight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoLine1EdgeDarkToLight.Location = new System.Drawing.Point(0, 0);
            this.rdoLine1EdgeDarkToLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLine1EdgeDarkToLight.Name = "rdoLine1EdgeDarkToLight";
            this.rdoLine1EdgeDarkToLight.Size = new System.Drawing.Size(94, 60);
            this.rdoLine1EdgeDarkToLight.TabIndex = 5;
            this.rdoLine1EdgeDarkToLight.TabStop = true;
            this.rdoLine1EdgeDarkToLight.Tag = "1";
            this.rdoLine1EdgeDarkToLight.Text = "DARK ▶ LIGHT";
            this.rdoLine1EdgeDarkToLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLine1EdgeDarkToLight.UseVisualStyleBackColor = false;
            this.rdoLine1EdgeDarkToLight.CheckedChanged += new System.EventHandler(this.rdoSetLineEdgePolarity_CheckedChanged);
            // 
            // tlpLinePoint2Polarity
            // 
            this.tlpLinePoint2Polarity.ColumnCount = 1;
            this.tlpLinePoint2Polarity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint2Polarity.Controls.Add(this.rdoLine2EdgeLightToDark, 0, 1);
            this.tlpLinePoint2Polarity.Controls.Add(this.rdoLine2EdgeDarkToLight, 0, 0);
            this.tlpLinePoint2Polarity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLinePoint2Polarity.Location = new System.Drawing.Point(188, 300);
            this.tlpLinePoint2Polarity.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLinePoint2Polarity.Name = "tlpLinePoint2Polarity";
            this.tlpLinePoint2Polarity.RowCount = 2;
            this.tlpLinePoint2Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint2Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpLinePoint2Polarity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLinePoint2Polarity.Size = new System.Drawing.Size(94, 121);
            this.tlpLinePoint2Polarity.TabIndex = 199;
            // 
            // rdoLine2EdgeLightToDark
            // 
            this.rdoLine2EdgeLightToDark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLine2EdgeLightToDark.AutoSize = true;
            this.rdoLine2EdgeLightToDark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoLine2EdgeLightToDark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLine2EdgeLightToDark.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoLine2EdgeLightToDark.Location = new System.Drawing.Point(0, 60);
            this.rdoLine2EdgeLightToDark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLine2EdgeLightToDark.Name = "rdoLine2EdgeLightToDark";
            this.rdoLine2EdgeLightToDark.Size = new System.Drawing.Size(94, 61);
            this.rdoLine2EdgeLightToDark.TabIndex = 6;
            this.rdoLine2EdgeLightToDark.TabStop = true;
            this.rdoLine2EdgeLightToDark.Tag = "2";
            this.rdoLine2EdgeLightToDark.Text = "LIGHT ▶ DARK";
            this.rdoLine2EdgeLightToDark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLine2EdgeLightToDark.UseVisualStyleBackColor = false;
            this.rdoLine2EdgeLightToDark.CheckedChanged += new System.EventHandler(this.rdoSetLineEdgePolarity_CheckedChanged);
            // 
            // rdoLine2EdgeDarkToLight
            // 
            this.rdoLine2EdgeDarkToLight.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoLine2EdgeDarkToLight.AutoSize = true;
            this.rdoLine2EdgeDarkToLight.BackColor = System.Drawing.Color.DarkGray;
            this.rdoLine2EdgeDarkToLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoLine2EdgeDarkToLight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoLine2EdgeDarkToLight.Location = new System.Drawing.Point(0, 0);
            this.rdoLine2EdgeDarkToLight.Margin = new System.Windows.Forms.Padding(0);
            this.rdoLine2EdgeDarkToLight.Name = "rdoLine2EdgeDarkToLight";
            this.rdoLine2EdgeDarkToLight.Size = new System.Drawing.Size(94, 60);
            this.rdoLine2EdgeDarkToLight.TabIndex = 5;
            this.rdoLine2EdgeDarkToLight.TabStop = true;
            this.rdoLine2EdgeDarkToLight.Tag = "1";
            this.rdoLine2EdgeDarkToLight.Text = "DARK ▶ LIGHT";
            this.rdoLine2EdgeDarkToLight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoLine2EdgeDarkToLight.UseVisualStyleBackColor = false;
            this.rdoLine2EdgeDarkToLight.CheckedChanged += new System.EventHandler(this.rdoSetLineEdgePolarity_CheckedChanged);
            // 
            // cmbLinePointSelect
            // 
            this.cmbLinePointSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLinePointSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLinePointSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinePointSelect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbLinePointSelect.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbLinePointSelect.FormattingEnabled = true;
            this.cmbLinePointSelect.Location = new System.Drawing.Point(194, 1);
            this.cmbLinePointSelect.Margin = new System.Windows.Forms.Padding(6, 1, 6, 0);
            this.cmbLinePointSelect.Name = "cmbLinePointSelect";
            this.cmbLinePointSelect.Size = new System.Drawing.Size(82, 28);
            this.cmbLinePointSelect.TabIndex = 265;
            this.cmbLinePointSelect.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbLinePointSelect.SelectedIndexChanged += new System.EventHandler(this.cmbMeasurePointIndex_SelectedIndexChanged);
            // 
            // btnLineApply
            // 
            this.btnLineApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnLineApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLineApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLineApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnLineApply.Location = new System.Drawing.Point(0, 541);
            this.btnLineApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnLineApply.Name = "btnLineApply";
            this.btnLineApply.Size = new System.Drawing.Size(94, 68);
            this.btnLineApply.TabIndex = 198;
            this.btnLineApply.Text = "APPLY";
            this.btnLineApply.UseVisualStyleBackColor = false;
            this.btnLineApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnLineMeasureTest
            // 
            this.btnLineMeasureTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnLineMeasureTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLineMeasureTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLineMeasureTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnLineMeasureTest.Location = new System.Drawing.Point(282, 541);
            this.btnLineMeasureTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnLineMeasureTest.Name = "btnLineMeasureTest";
            this.btnLineMeasureTest.Size = new System.Drawing.Size(97, 68);
            this.btnLineMeasureTest.TabIndex = 198;
            this.btnLineMeasureTest.Text = "MEASURE TEST";
            this.btnLineMeasureTest.UseVisualStyleBackColor = false;
            this.btnLineMeasureTest.Click += new System.EventHandler(this.btnMeasureTest_Click);
            // 
            // chkLineMeasureROITracking
            // 
            this.chkLineMeasureROITracking.AutoSize = true;
            this.chkLineMeasureROITracking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLineMeasureROITracking.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkLineMeasureROITracking.Location = new System.Drawing.Point(94, 421);
            this.chkLineMeasureROITracking.Margin = new System.Windows.Forms.Padding(0);
            this.chkLineMeasureROITracking.Name = "chkLineMeasureROITracking";
            this.chkLineMeasureROITracking.Size = new System.Drawing.Size(94, 60);
            this.chkLineMeasureROITracking.TabIndex = 298;
            this.chkLineMeasureROITracking.Text = "ROI Tracking";
            this.chkLineMeasureROITracking.UseVisualStyleBackColor = true;
            this.chkLineMeasureROITracking.CheckedChanged += new System.EventHandler(this.chkROITracking_CheckedChanged);
            // 
            // btnLineROIShow
            // 
            this.btnLineROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnLineROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLineROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLineROIShow.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnLineROIShow.Location = new System.Drawing.Point(0, 421);
            this.btnLineROIShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnLineROIShow.Name = "btnLineROIShow";
            this.btnLineROIShow.Size = new System.Drawing.Size(94, 60);
            this.btnLineROIShow.TabIndex = 198;
            this.btnLineROIShow.Text = "SHOW ROI";
            this.btnLineROIShow.UseVisualStyleBackColor = false;
            this.btnLineROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // CtrlTeachMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeachMeasure);
            this.Name = "CtrlTeachMeasure";
            this.Size = new System.Drawing.Size(800, 900);
            this.Load += new System.EventHandler(this.CtrlTeachMeasure_Load);
            this.tlpTeachMeasure.ResumeLayout(false);
            this.tlpMeasureType.ResumeLayout(false);
            this.tlpSearchType.ResumeLayout(false);
            this.tlpSearchType.PerformLayout();
            this.pnlMeasureParameter.ResumeLayout(false);
            this.pnlMeasureCircle.ResumeLayout(false);
            this.tlpMeasureCircle.ResumeLayout(false);
            this.tlpMeasureCircle.PerformLayout();
            this.tlpCircleEdgePolarity.ResumeLayout(false);
            this.tlpCircleEdgePolarity.PerformLayout();
            this.tlpCircleSearchDirection.ResumeLayout(false);
            this.tlpCircleSearchDirection.PerformLayout();
            this.pnlMeasureLine.ResumeLayout(false);
            this.tlpMeasureLine.ResumeLayout(false);
            this.tlpMeasureLine.PerformLayout();
            this.tlpLinePoint1Polarity.ResumeLayout(false);
            this.tlpLinePoint1Polarity.PerformLayout();
            this.tlpLinePoint2Polarity.ResumeLayout(false);
            this.tlpLinePoint2Polarity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeachMeasure;
        private System.Windows.Forms.TableLayoutPanel tlpMeasureType;
        private System.Windows.Forms.Label lblMeasureType;
        private System.Windows.Forms.TableLayoutPanel tlpSearchType;
        private System.Windows.Forms.RadioButton rdoMeasureCircle;
        private System.Windows.Forms.RadioButton rdoMeasureLine;
        private System.Windows.Forms.Panel pnlMeasureParameter;
        private System.Windows.Forms.Panel pnlMeasureCircle;
        private System.Windows.Forms.TableLayoutPanel tlpMeasureCircle;
        private System.Windows.Forms.CheckBox chkCircleMeasureROITracking;
        private System.Windows.Forms.ComboBox cmbCirclePointSelect;
        private System.Windows.Forms.Label lblCircleCount;
        private System.Windows.Forms.Label lblCirclePointValue;
        private System.Windows.Forms.Button btnCircleApply;
        private System.Windows.Forms.Label lblCircleProjectionLength;
        private System.Windows.Forms.Label lblCircleSearchLength;
        private System.Windows.Forms.Label lblCircleIgnoreNumber;
        private System.Windows.Forms.Label lblCircleCaliperNumber;
        private System.Windows.Forms.Label lblCircleEdgePolarity;
        private System.Windows.Forms.TableLayoutPanel tlpCircleEdgePolarity;
        private System.Windows.Forms.RadioButton rdoCircleEdgeLightToDark;
        private System.Windows.Forms.RadioButton rdoCircleEdgeDarkToLight;
        private System.Windows.Forms.Label lblCircleProjectionLengthValue;
        private System.Windows.Forms.Label lblCircleSearchLengthValue;
        private System.Windows.Forms.Label lblCircleCaliperNumberValue;
        private System.Windows.Forms.Label lblCircleIgnoreNumberValue;
        private System.Windows.Forms.Button btnCircleROIShow;
        private System.Windows.Forms.Button btnCircleMeasureTest;
        private System.Windows.Forms.Label lblCircleSearchDirection;
        private System.Windows.Forms.Label lblCircleContrast;
        private System.Windows.Forms.Label lblCircleContrastValue;
        private System.Windows.Forms.TableLayoutPanel tlpCircleSearchDirection;
        private System.Windows.Forms.RadioButton rdoCircleSearchOutward;
        private System.Windows.Forms.RadioButton rdoCircleSearchInward;
        private System.Windows.Forms.Panel pnlMeasureLine;
        private System.Windows.Forms.TableLayoutPanel tlpMeasureLine;
        private System.Windows.Forms.Label lblLineCount;
        private System.Windows.Forms.Label lblLinePointValue;
        private System.Windows.Forms.Label lblLineEdgeThreshold;
        private System.Windows.Forms.Label lblLineFilterSize;
        private System.Windows.Forms.Label lblLine1EdgeFilterSizeValue;
        private System.Windows.Forms.Label lblLinePoint1;
        private System.Windows.Forms.Label lblLine2EdgeThresholdValue;
        private System.Windows.Forms.Label lblLine2EdgeFilterSizeValue;
        private System.Windows.Forms.Label lblLine1EdgeThresholdValue;
        private System.Windows.Forms.Label lblLinePoint2;
        private System.Windows.Forms.Label lblLineEdgePolarity;
        private System.Windows.Forms.TableLayoutPanel tlpLinePoint1Polarity;
        private System.Windows.Forms.RadioButton rdoLine1EdgeLightToDark;
        private System.Windows.Forms.RadioButton rdoLine1EdgeDarkToLight;
        private System.Windows.Forms.TableLayoutPanel tlpLinePoint2Polarity;
        private System.Windows.Forms.RadioButton rdoLine2EdgeLightToDark;
        private System.Windows.Forms.RadioButton rdoLine2EdgeDarkToLight;
        private System.Windows.Forms.ComboBox cmbLinePointSelect;
        private System.Windows.Forms.Button btnLineApply;
        private System.Windows.Forms.Button btnLineROIShow;
        private System.Windows.Forms.Button btnLineMeasureTest;
        private System.Windows.Forms.CheckBox chkLineMeasureROITracking;
    }
}
