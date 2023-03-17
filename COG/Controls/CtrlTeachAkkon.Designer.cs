namespace COG.Controls
{
    partial class CtrlTeachAkkon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTeachAkkon));
            this.tlpTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpAkkonDataGridView = new System.Windows.Forms.TableLayoutPanel();
            this.tabAkkonData = new System.Windows.Forms.TabControl();
            this.tpAkkonROI = new System.Windows.Forms.TabPage();
            this.dgvAkkonROI = new System.Windows.Forms.DataGridView();
            this.COL_00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COL_04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAkkonResult = new System.Windows.Forms.TabPage();
            this.dgvAkkonResult = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpAkkonDataShow = new System.Windows.Forms.TableLayoutPanel();
            this.rdoAkkonResult = new System.Windows.Forms.RadioButton();
            this.rdoAkkonROI = new System.Windows.Forms.RadioButton();
            this.tlpSetParameter = new System.Windows.Forms.TableLayoutPanel();
            this.pnlShowSelectParameter = new System.Windows.Forms.Panel();
            this.pnlEngineerParameter = new System.Windows.Forms.Panel();
            this.tlpParameter = new System.Windows.Forms.TableLayoutPanel();
            this.lblStrengthFilterValue = new System.Windows.Forms.Label();
            this.lblStrengthFilter = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblCountValue = new System.Windows.Forms.Label();
            this.lblMinSizeFilter = new System.Windows.Forms.Label();
            this.lblMaxSizeFilter = new System.Windows.Forms.Label();
            this.lblGroupDistance = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWidthCut = new System.Windows.Forms.Label();
            this.lblHeightCut = new System.Windows.Forms.Label();
            this.lblBWRatio = new System.Windows.Forms.Label();
            this.lblExtraLeadDisplay = new System.Windows.Forms.Label();
            this.lblMinSizeFilterValue = new System.Windows.Forms.Label();
            this.lblMaxSizeFilterValue = new System.Windows.Forms.Label();
            this.lblGroupDistanceValue = new System.Windows.Forms.Label();
            this.lblLengthValue = new System.Windows.Forms.Label();
            this.lblWidthCutValue = new System.Windows.Forms.Label();
            this.lblHeightCutValue = new System.Windows.Forms.Label();
            this.lblBWRatioValue = new System.Windows.Forms.Label();
            this.lblExtraLeadDisplayValue = new System.Windows.Forms.Label();
            this.lblDimple = new System.Windows.Forms.Label();
            this.lblDimpleNGCountValue = new System.Windows.Forms.Label();
            this.lblAlarm = new System.Windows.Forms.Label();
            this.lblAlarmCapacity = new System.Windows.Forms.Label();
            this.lblAlarmNGCount = new System.Windows.Forms.Label();
            this.lblAlarmCapacityValue = new System.Windows.Forms.Label();
            this.lblAlarmNGCountValue = new System.Windows.Forms.Label();
            this.lblDimpleThresholdValue = new System.Windows.Forms.Label();
            this.lblDimpleNGCount = new System.Windows.Forms.Label();
            this.lblDimpleThreshold = new System.Windows.Forms.Label();
            this.chkUseDimple = new System.Windows.Forms.CheckBox();
            this.pnlGroup = new System.Windows.Forms.Panel();
            this.tlpGroup = new System.Windows.Forms.TableLayoutPanel();
            this.btnROIShow = new System.Windows.Forms.Button();
            this.lblGroupCount = new System.Windows.Forms.Label();
            this.lblGroupCountValue = new System.Windows.Forms.Label();
            this.cmbGroupNumber = new System.Windows.Forms.ComboBox();
            this.lblGroupNumber = new System.Windows.Forms.Label();
            this.lblROIWidth = new System.Windows.Forms.Label();
            this.lblROIWidthValue = new System.Windows.Forms.Label();
            this.lblROIHeight = new System.Windows.Forms.Label();
            this.lblROIHeightValue = new System.Windows.Forms.Label();
            this.lblLeadCount = new System.Windows.Forms.Label();
            this.lblLeadCountValue = new System.Windows.Forms.Label();
            this.lblLeadPitch = new System.Windows.Forms.Label();
            this.lblLeadPitchValue = new System.Windows.Forms.Label();
            this.lblFirstLead = new System.Windows.Forms.Label();
            this.btnROICreate = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblCloneROI = new System.Windows.Forms.Label();
            this.tlpCloneROI = new System.Windows.Forms.TableLayoutPanel();
            this.rdoCopyHorizontal = new System.Windows.Forms.RadioButton();
            this.rdoCopyVertical = new System.Windows.Forms.RadioButton();
            this.btnCopyROI = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlMakerParameter = new System.Windows.Forms.Panel();
            this.tlpMakerParameter = new System.Windows.Forms.TableLayoutPanel();
            this.cmbFilterDirection = new System.Windows.Forms.ComboBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.cmbStrengthBase = new System.Windows.Forms.ComboBox();
            this.cmbTargetType = new System.Windows.Forms.ComboBox();
            this.cmbPeakProperty = new System.Windows.Forms.ComboBox();
            this.cmbPanelType = new System.Windows.Forms.ComboBox();
            this.cmbShadowDirection = new System.Windows.Forms.ComboBox();
            this.lblInspectionType = new System.Windows.Forms.Label();
            this.lblThresholdWeightValue = new System.Windows.Forms.Label();
            this.lblPeakThreshold = new System.Windows.Forms.Label();
            this.lblThresholdWeight = new System.Windows.Forms.Label();
            this.lblFilterDirection = new System.Windows.Forms.Label();
            this.lblFilterType = new System.Windows.Forms.Label();
            this.lblTargetType = new System.Windows.Forms.Label();
            this.lblPanelType = new System.Windows.Forms.Label();
            this.lblShadowDirection = new System.Windows.Forms.Label();
            this.lblPeakProperty = new System.Windows.Forms.Label();
            this.lblStrengthBase = new System.Windows.Forms.Label();
            this.lblLogTrace = new System.Windows.Forms.Label();
            this.lblThresholdMode = new System.Windows.Forms.Label();
            this.lblStrengthScaleFactor = new System.Windows.Forms.Label();
            this.lblSliceOverlap = new System.Windows.Forms.Label();
            this.lblPeakThresholdValue = new System.Windows.Forms.Label();
            this.lblStrengthScaleFactorValue = new System.Windows.Forms.Label();
            this.lblSliceOverlapValue = new System.Windows.Forms.Label();
            this.lblStandardDeviationValue = new System.Windows.Forms.Label();
            this.lblStandardDeviation = new System.Windows.Forms.Label();
            this.cmbInspectionType = new System.Windows.Forms.ComboBox();
            this.cmbThresholdMode = new System.Windows.Forms.ComboBox();
            this.chkLogTraceUseCheck = new System.Windows.Forms.CheckBox();
            this.pnlSelectParameter = new System.Windows.Forms.Panel();
            this.tlpSelectParameter = new System.Windows.Forms.TableLayoutPanel();
            this.rdoBump = new System.Windows.Forms.RadioButton();
            this.rdoGroup = new System.Windows.Forms.RadioButton();
            this.rdoMakerParmeter = new System.Windows.Forms.RadioButton();
            this.rdoEngineerParmeter = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAkkonTest = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.rdoOption = new System.Windows.Forms.RadioButton();
            this.pnlOption = new System.Windows.Forms.Panel();
            this.tlpOption = new System.Windows.Forms.TableLayoutPanel();
            this.chkUseAlarm = new System.Windows.Forms.CheckBox();
            this.tlpTeach.SuspendLayout();
            this.tlpAkkonDataGridView.SuspendLayout();
            this.tabAkkonData.SuspendLayout();
            this.tpAkkonROI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkkonROI)).BeginInit();
            this.tpAkkonResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkkonResult)).BeginInit();
            this.tlpAkkonDataShow.SuspendLayout();
            this.tlpSetParameter.SuspendLayout();
            this.pnlShowSelectParameter.SuspendLayout();
            this.pnlEngineerParameter.SuspendLayout();
            this.tlpParameter.SuspendLayout();
            this.pnlGroup.SuspendLayout();
            this.tlpGroup.SuspendLayout();
            this.tlpCloneROI.SuspendLayout();
            this.pnlMakerParameter.SuspendLayout();
            this.tlpMakerParameter.SuspendLayout();
            this.pnlSelectParameter.SuspendLayout();
            this.tlpSelectParameter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlOption.SuspendLayout();
            this.tlpOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpTeach
            // 
            this.tlpTeach.ColumnCount = 1;
            this.tlpTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Controls.Add(this.tlpAkkonDataGridView, 0, 1);
            this.tlpTeach.Controls.Add(this.tlpSetParameter, 0, 3);
            this.tlpTeach.Controls.Add(this.tableLayoutPanel1, 0, 5);
            this.tlpTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpTeach.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeach.Name = "tlpTeach";
            this.tlpTeach.RowCount = 7;
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpTeach.Size = new System.Drawing.Size(800, 900);
            this.tlpTeach.TabIndex = 288;
            // 
            // tlpAkkonDataGridView
            // 
            this.tlpAkkonDataGridView.ColumnCount = 1;
            this.tlpAkkonDataGridView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAkkonDataGridView.Controls.Add(this.tabAkkonData, 0, 0);
            this.tlpAkkonDataGridView.Controls.Add(this.tlpAkkonDataShow, 0, 1);
            this.tlpAkkonDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAkkonDataGridView.Location = new System.Drawing.Point(0, 30);
            this.tlpAkkonDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAkkonDataGridView.Name = "tlpAkkonDataGridView";
            this.tlpAkkonDataGridView.RowCount = 2;
            this.tlpAkkonDataGridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAkkonDataGridView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpAkkonDataGridView.Size = new System.Drawing.Size(800, 273);
            this.tlpAkkonDataGridView.TabIndex = 293;
            // 
            // tabAkkonData
            // 
            this.tabAkkonData.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabAkkonData.Controls.Add(this.tpAkkonROI);
            this.tabAkkonData.Controls.Add(this.tpAkkonResult);
            this.tabAkkonData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAkkonData.ItemSize = new System.Drawing.Size(0, 1);
            this.tabAkkonData.Location = new System.Drawing.Point(0, 0);
            this.tabAkkonData.Margin = new System.Windows.Forms.Padding(0);
            this.tabAkkonData.Name = "tabAkkonData";
            this.tabAkkonData.SelectedIndex = 0;
            this.tabAkkonData.Size = new System.Drawing.Size(800, 243);
            this.tabAkkonData.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabAkkonData.TabIndex = 292;
            // 
            // tpAkkonROI
            // 
            this.tpAkkonROI.Controls.Add(this.dgvAkkonROI);
            this.tpAkkonROI.Location = new System.Drawing.Point(4, 5);
            this.tpAkkonROI.Margin = new System.Windows.Forms.Padding(0);
            this.tpAkkonROI.Name = "tpAkkonROI";
            this.tpAkkonROI.Size = new System.Drawing.Size(792, 234);
            this.tpAkkonROI.TabIndex = 0;
            this.tpAkkonROI.Text = "tabPage1";
            this.tpAkkonROI.UseVisualStyleBackColor = true;
            // 
            // dgvAkkonROI
            // 
            this.dgvAkkonROI.AllowUserToAddRows = false;
            this.dgvAkkonROI.AllowUserToDeleteRows = false;
            this.dgvAkkonROI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAkkonROI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.COL_00,
            this.COL_01,
            this.COL_02,
            this.COL_03,
            this.COL_04});
            this.dgvAkkonROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAkkonROI.Location = new System.Drawing.Point(0, 0);
            this.dgvAkkonROI.Margin = new System.Windows.Forms.Padding(0);
            this.dgvAkkonROI.Name = "dgvAkkonROI";
            this.dgvAkkonROI.ReadOnly = true;
            this.dgvAkkonROI.RowTemplate.Height = 23;
            this.dgvAkkonROI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAkkonROI.Size = new System.Drawing.Size(792, 234);
            this.dgvAkkonROI.TabIndex = 0;
            this.dgvAkkonROI.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAkkonROI_CellClick);
            // 
            // COL_00
            // 
            this.COL_00.FillWeight = 110F;
            this.COL_00.HeaderText = "No.";
            this.COL_00.Name = "COL_00";
            this.COL_00.ReadOnly = true;
            this.COL_00.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_00.Width = 70;
            // 
            // COL_01
            // 
            this.COL_01.FillWeight = 140F;
            this.COL_01.HeaderText = "LeftTop";
            this.COL_01.Name = "COL_01";
            this.COL_01.ReadOnly = true;
            this.COL_01.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_01.Width = 140;
            // 
            // COL_02
            // 
            this.COL_02.FillWeight = 140F;
            this.COL_02.HeaderText = "RightTop";
            this.COL_02.Name = "COL_02";
            this.COL_02.ReadOnly = true;
            this.COL_02.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_02.Width = 140;
            // 
            // COL_03
            // 
            this.COL_03.FillWeight = 140F;
            this.COL_03.HeaderText = "RightBottom";
            this.COL_03.Name = "COL_03";
            this.COL_03.ReadOnly = true;
            this.COL_03.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COL_03.Width = 140;
            // 
            // COL_04
            // 
            this.COL_04.FillWeight = 140F;
            this.COL_04.HeaderText = "LeftBottom";
            this.COL_04.Name = "COL_04";
            this.COL_04.ReadOnly = true;
            this.COL_04.Width = 140;
            // 
            // tpAkkonResult
            // 
            this.tpAkkonResult.Controls.Add(this.dgvAkkonResult);
            this.tpAkkonResult.Location = new System.Drawing.Point(4, 5);
            this.tpAkkonResult.Margin = new System.Windows.Forms.Padding(0);
            this.tpAkkonResult.Name = "tpAkkonResult";
            this.tpAkkonResult.Size = new System.Drawing.Size(792, 234);
            this.tpAkkonResult.TabIndex = 1;
            this.tpAkkonResult.Text = "tabPage2";
            this.tpAkkonResult.UseVisualStyleBackColor = true;
            // 
            // dgvAkkonResult
            // 
            this.dgvAkkonResult.AllowUserToAddRows = false;
            this.dgvAkkonResult.AllowUserToDeleteRows = false;
            this.dgvAkkonResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAkkonResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvAkkonResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAkkonResult.Location = new System.Drawing.Point(0, 0);
            this.dgvAkkonResult.Name = "dgvAkkonResult";
            this.dgvAkkonResult.ReadOnly = true;
            this.dgvAkkonResult.RowTemplate.Height = 23;
            this.dgvAkkonResult.Size = new System.Drawing.Size(792, 234);
            this.dgvAkkonResult.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Count";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Length";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Strength";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 140;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Judgement";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // tlpAkkonDataShow
            // 
            this.tlpAkkonDataShow.ColumnCount = 2;
            this.tlpAkkonDataShow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAkkonDataShow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAkkonDataShow.Controls.Add(this.rdoAkkonResult, 0, 0);
            this.tlpAkkonDataShow.Controls.Add(this.rdoAkkonROI, 0, 0);
            this.tlpAkkonDataShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAkkonDataShow.Location = new System.Drawing.Point(0, 243);
            this.tlpAkkonDataShow.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAkkonDataShow.Name = "tlpAkkonDataShow";
            this.tlpAkkonDataShow.RowCount = 1;
            this.tlpAkkonDataShow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAkkonDataShow.Size = new System.Drawing.Size(800, 30);
            this.tlpAkkonDataShow.TabIndex = 293;
            // 
            // rdoAkkonResult
            // 
            this.rdoAkkonResult.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAkkonResult.BackColor = System.Drawing.Color.DarkGray;
            this.rdoAkkonResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAkkonResult.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoAkkonResult.ForeColor = System.Drawing.Color.Black;
            this.rdoAkkonResult.Location = new System.Drawing.Point(400, 0);
            this.rdoAkkonResult.Margin = new System.Windows.Forms.Padding(0);
            this.rdoAkkonResult.Name = "rdoAkkonResult";
            this.rdoAkkonResult.Size = new System.Drawing.Size(400, 30);
            this.rdoAkkonResult.TabIndex = 144;
            this.rdoAkkonResult.Tag = "0";
            this.rdoAkkonResult.Text = "AKKON INSPECTION RESULT";
            this.rdoAkkonResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAkkonResult.UseVisualStyleBackColor = false;
            this.rdoAkkonResult.CheckedChanged += new System.EventHandler(this.rdoSetAkkonDataShow_CheckedChanged);
            // 
            // rdoAkkonROI
            // 
            this.rdoAkkonROI.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoAkkonROI.BackColor = System.Drawing.Color.DarkGray;
            this.rdoAkkonROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoAkkonROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoAkkonROI.ForeColor = System.Drawing.Color.Black;
            this.rdoAkkonROI.Location = new System.Drawing.Point(0, 0);
            this.rdoAkkonROI.Margin = new System.Windows.Forms.Padding(0);
            this.rdoAkkonROI.Name = "rdoAkkonROI";
            this.rdoAkkonROI.Size = new System.Drawing.Size(400, 30);
            this.rdoAkkonROI.TabIndex = 143;
            this.rdoAkkonROI.Tag = "0";
            this.rdoAkkonROI.Text = "LEAD ROI LIST";
            this.rdoAkkonROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoAkkonROI.UseVisualStyleBackColor = false;
            this.rdoAkkonROI.CheckedChanged += new System.EventHandler(this.rdoSetAkkonDataShow_CheckedChanged);
            // 
            // tlpSetParameter
            // 
            this.tlpSetParameter.ColumnCount = 1;
            this.tlpSetParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Controls.Add(this.pnlShowSelectParameter, 0, 1);
            this.tlpSetParameter.Controls.Add(this.pnlSelectParameter, 0, 0);
            this.tlpSetParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSetParameter.Location = new System.Drawing.Point(0, 333);
            this.tlpSetParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSetParameter.Name = "tlpSetParameter";
            this.tlpSetParameter.RowCount = 2;
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpSetParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSetParameter.Size = new System.Drawing.Size(800, 429);
            this.tlpSetParameter.TabIndex = 0;
            // 
            // pnlShowSelectParameter
            // 
            this.pnlShowSelectParameter.Controls.Add(this.pnlEngineerParameter);
            this.pnlShowSelectParameter.Controls.Add(this.pnlGroup);
            this.pnlShowSelectParameter.Controls.Add(this.pnlOption);
            this.pnlShowSelectParameter.Controls.Add(this.pnlMakerParameter);
            this.pnlShowSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShowSelectParameter.Location = new System.Drawing.Point(3, 63);
            this.pnlShowSelectParameter.Name = "pnlShowSelectParameter";
            this.pnlShowSelectParameter.Size = new System.Drawing.Size(794, 363);
            this.pnlShowSelectParameter.TabIndex = 5;
            // 
            // pnlEngineerParameter
            // 
            this.pnlEngineerParameter.Controls.Add(this.tlpParameter);
            this.pnlEngineerParameter.Location = new System.Drawing.Point(274, 3);
            this.pnlEngineerParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlEngineerParameter.Name = "pnlEngineerParameter";
            this.pnlEngineerParameter.Size = new System.Drawing.Size(246, 180);
            this.pnlEngineerParameter.TabIndex = 3;
            this.pnlEngineerParameter.Visible = false;
            // 
            // tlpParameter
            // 
            this.tlpParameter.ColumnCount = 5;
            this.tlpParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpParameter.Controls.Add(this.lblStrengthFilterValue, 1, 4);
            this.tlpParameter.Controls.Add(this.lblStrengthFilter, 0, 4);
            this.tlpParameter.Controls.Add(this.lblCount, 0, 0);
            this.tlpParameter.Controls.Add(this.lblCountValue, 1, 0);
            this.tlpParameter.Controls.Add(this.lblMinSizeFilter, 0, 1);
            this.tlpParameter.Controls.Add(this.lblMaxSizeFilter, 0, 2);
            this.tlpParameter.Controls.Add(this.lblGroupDistance, 0, 3);
            this.tlpParameter.Controls.Add(this.lblLength, 3, 0);
            this.tlpParameter.Controls.Add(this.lblWidthCut, 3, 1);
            this.tlpParameter.Controls.Add(this.lblHeightCut, 3, 2);
            this.tlpParameter.Controls.Add(this.lblBWRatio, 3, 3);
            this.tlpParameter.Controls.Add(this.lblExtraLeadDisplay, 3, 4);
            this.tlpParameter.Controls.Add(this.lblMinSizeFilterValue, 1, 1);
            this.tlpParameter.Controls.Add(this.lblMaxSizeFilterValue, 1, 2);
            this.tlpParameter.Controls.Add(this.lblGroupDistanceValue, 1, 3);
            this.tlpParameter.Controls.Add(this.lblLengthValue, 4, 0);
            this.tlpParameter.Controls.Add(this.lblWidthCutValue, 4, 1);
            this.tlpParameter.Controls.Add(this.lblHeightCutValue, 4, 2);
            this.tlpParameter.Controls.Add(this.lblBWRatioValue, 4, 3);
            this.tlpParameter.Controls.Add(this.lblExtraLeadDisplayValue, 4, 4);
            this.tlpParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpParameter.Name = "tlpParameter";
            this.tlpParameter.RowCount = 8;
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpParameter.Size = new System.Drawing.Size(246, 180);
            this.tlpParameter.TabIndex = 0;
            // 
            // lblStrengthFilterValue
            // 
            this.lblStrengthFilterValue.BackColor = System.Drawing.Color.White;
            this.lblStrengthFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthFilterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrengthFilterValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStrengthFilterValue.Location = new System.Drawing.Point(60, 88);
            this.lblStrengthFilterValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthFilterValue.Name = "lblStrengthFilterValue";
            this.lblStrengthFilterValue.Size = new System.Drawing.Size(60, 22);
            this.lblStrengthFilterValue.TabIndex = 27;
            this.lblStrengthFilterValue.Text = "0";
            this.lblStrengthFilterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStrengthFilterValue.Click += new System.EventHandler(this.lblStrengthFilterValue_Click);
            // 
            // lblStrengthFilter
            // 
            this.lblStrengthFilter.BackColor = System.Drawing.Color.DarkGray;
            this.lblStrengthFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrengthFilter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStrengthFilter.Location = new System.Drawing.Point(0, 88);
            this.lblStrengthFilter.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthFilter.Name = "lblStrengthFilter";
            this.lblStrengthFilter.Size = new System.Drawing.Size(60, 22);
            this.lblStrengthFilter.TabIndex = 18;
            this.lblStrengthFilter.Text = "STRENGTH FILTER(%)";
            this.lblStrengthFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCount.Location = new System.Drawing.Point(0, 0);
            this.lblCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(60, 22);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "COUNT";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCountValue
            // 
            this.lblCountValue.BackColor = System.Drawing.Color.White;
            this.lblCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCountValue.Location = new System.Drawing.Point(60, 0);
            this.lblCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblCountValue.Name = "lblCountValue";
            this.lblCountValue.Size = new System.Drawing.Size(60, 22);
            this.lblCountValue.TabIndex = 9;
            this.lblCountValue.Text = "0";
            this.lblCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCountValue.Click += new System.EventHandler(this.lblCountValue_Click);
            // 
            // lblMinSizeFilter
            // 
            this.lblMinSizeFilter.BackColor = System.Drawing.Color.DarkGray;
            this.lblMinSizeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinSizeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinSizeFilter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMinSizeFilter.Location = new System.Drawing.Point(0, 22);
            this.lblMinSizeFilter.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinSizeFilter.Name = "lblMinSizeFilter";
            this.lblMinSizeFilter.Size = new System.Drawing.Size(60, 22);
            this.lblMinSizeFilter.TabIndex = 10;
            this.lblMinSizeFilter.Text = "MIN SIZE FILTER(um)";
            this.lblMinSizeFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxSizeFilter
            // 
            this.lblMaxSizeFilter.BackColor = System.Drawing.Color.DarkGray;
            this.lblMaxSizeFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSizeFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSizeFilter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSizeFilter.Location = new System.Drawing.Point(0, 44);
            this.lblMaxSizeFilter.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSizeFilter.Name = "lblMaxSizeFilter";
            this.lblMaxSizeFilter.Size = new System.Drawing.Size(60, 22);
            this.lblMaxSizeFilter.TabIndex = 11;
            this.lblMaxSizeFilter.Text = "MAX SIZE FILTER(um)";
            this.lblMaxSizeFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGroupDistance
            // 
            this.lblGroupDistance.BackColor = System.Drawing.Color.DarkGray;
            this.lblGroupDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupDistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupDistance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupDistance.Location = new System.Drawing.Point(0, 66);
            this.lblGroupDistance.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupDistance.Name = "lblGroupDistance";
            this.lblGroupDistance.Size = new System.Drawing.Size(60, 22);
            this.lblGroupDistance.TabIndex = 12;
            this.lblGroupDistance.Text = "GROUP DISTANCE(px)";
            this.lblGroupDistance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLength
            // 
            this.lblLength.BackColor = System.Drawing.Color.DarkGray;
            this.lblLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLength.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLength.Location = new System.Drawing.Point(123, 0);
            this.lblLength.Margin = new System.Windows.Forms.Padding(0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(60, 22);
            this.lblLength.TabIndex = 14;
            this.lblLength.Text = "LENGTH";
            this.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWidthCut
            // 
            this.lblWidthCut.BackColor = System.Drawing.Color.DarkGray;
            this.lblWidthCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWidthCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWidthCut.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWidthCut.Location = new System.Drawing.Point(123, 22);
            this.lblWidthCut.Margin = new System.Windows.Forms.Padding(0);
            this.lblWidthCut.Name = "lblWidthCut";
            this.lblWidthCut.Size = new System.Drawing.Size(60, 22);
            this.lblWidthCut.TabIndex = 13;
            this.lblWidthCut.Text = "WIDTH CUT(px)";
            this.lblWidthCut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeightCut
            // 
            this.lblHeightCut.BackColor = System.Drawing.Color.DarkGray;
            this.lblHeightCut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeightCut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeightCut.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeightCut.Location = new System.Drawing.Point(123, 44);
            this.lblHeightCut.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeightCut.Name = "lblHeightCut";
            this.lblHeightCut.Size = new System.Drawing.Size(60, 22);
            this.lblHeightCut.TabIndex = 15;
            this.lblHeightCut.Text = "HEIGHT CUT(px)";
            this.lblHeightCut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBWRatio
            // 
            this.lblBWRatio.BackColor = System.Drawing.Color.DarkGray;
            this.lblBWRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBWRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBWRatio.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBWRatio.Location = new System.Drawing.Point(123, 66);
            this.lblBWRatio.Margin = new System.Windows.Forms.Padding(0);
            this.lblBWRatio.Name = "lblBWRatio";
            this.lblBWRatio.Size = new System.Drawing.Size(60, 22);
            this.lblBWRatio.TabIndex = 16;
            this.lblBWRatio.Text = "BW RATIO";
            this.lblBWRatio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExtraLeadDisplay
            // 
            this.lblExtraLeadDisplay.BackColor = System.Drawing.Color.DarkGray;
            this.lblExtraLeadDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExtraLeadDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExtraLeadDisplay.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblExtraLeadDisplay.Location = new System.Drawing.Point(123, 88);
            this.lblExtraLeadDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.lblExtraLeadDisplay.Name = "lblExtraLeadDisplay";
            this.lblExtraLeadDisplay.Size = new System.Drawing.Size(60, 22);
            this.lblExtraLeadDisplay.TabIndex = 17;
            this.lblExtraLeadDisplay.Text = "EXTRA LEAD DISPLAY";
            this.lblExtraLeadDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinSizeFilterValue
            // 
            this.lblMinSizeFilterValue.BackColor = System.Drawing.Color.White;
            this.lblMinSizeFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinSizeFilterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinSizeFilterValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMinSizeFilterValue.Location = new System.Drawing.Point(60, 22);
            this.lblMinSizeFilterValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMinSizeFilterValue.Name = "lblMinSizeFilterValue";
            this.lblMinSizeFilterValue.Size = new System.Drawing.Size(60, 22);
            this.lblMinSizeFilterValue.TabIndex = 19;
            this.lblMinSizeFilterValue.Text = "0";
            this.lblMinSizeFilterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinSizeFilterValue.Click += new System.EventHandler(this.lblMinSizeFilterValue_Click);
            // 
            // lblMaxSizeFilterValue
            // 
            this.lblMaxSizeFilterValue.BackColor = System.Drawing.Color.White;
            this.lblMaxSizeFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxSizeFilterValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxSizeFilterValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaxSizeFilterValue.Location = new System.Drawing.Point(60, 44);
            this.lblMaxSizeFilterValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblMaxSizeFilterValue.Name = "lblMaxSizeFilterValue";
            this.lblMaxSizeFilterValue.Size = new System.Drawing.Size(60, 22);
            this.lblMaxSizeFilterValue.TabIndex = 20;
            this.lblMaxSizeFilterValue.Text = "0";
            this.lblMaxSizeFilterValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxSizeFilterValue.Click += new System.EventHandler(this.lblMaxSizeFilterValue_Click);
            // 
            // lblGroupDistanceValue
            // 
            this.lblGroupDistanceValue.BackColor = System.Drawing.Color.White;
            this.lblGroupDistanceValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupDistanceValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupDistanceValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupDistanceValue.Location = new System.Drawing.Point(60, 66);
            this.lblGroupDistanceValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupDistanceValue.Name = "lblGroupDistanceValue";
            this.lblGroupDistanceValue.Size = new System.Drawing.Size(60, 22);
            this.lblGroupDistanceValue.TabIndex = 21;
            this.lblGroupDistanceValue.Text = "0";
            this.lblGroupDistanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGroupDistanceValue.Click += new System.EventHandler(this.lblGroupDistanceValue_Click);
            // 
            // lblLengthValue
            // 
            this.lblLengthValue.BackColor = System.Drawing.Color.White;
            this.lblLengthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLengthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLengthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLengthValue.Location = new System.Drawing.Point(183, 0);
            this.lblLengthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLengthValue.Name = "lblLengthValue";
            this.lblLengthValue.Size = new System.Drawing.Size(63, 22);
            this.lblLengthValue.TabIndex = 22;
            this.lblLengthValue.Text = "0";
            this.lblLengthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLengthValue.Click += new System.EventHandler(this.lblLengthValue_Click);
            // 
            // lblWidthCutValue
            // 
            this.lblWidthCutValue.BackColor = System.Drawing.Color.White;
            this.lblWidthCutValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWidthCutValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWidthCutValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblWidthCutValue.Location = new System.Drawing.Point(183, 22);
            this.lblWidthCutValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblWidthCutValue.Name = "lblWidthCutValue";
            this.lblWidthCutValue.Size = new System.Drawing.Size(63, 22);
            this.lblWidthCutValue.TabIndex = 23;
            this.lblWidthCutValue.Text = "0";
            this.lblWidthCutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWidthCutValue.Click += new System.EventHandler(this.lblWidthCutValue_Click);
            // 
            // lblHeightCutValue
            // 
            this.lblHeightCutValue.BackColor = System.Drawing.Color.White;
            this.lblHeightCutValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeightCutValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeightCutValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeightCutValue.Location = new System.Drawing.Point(183, 44);
            this.lblHeightCutValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblHeightCutValue.Name = "lblHeightCutValue";
            this.lblHeightCutValue.Size = new System.Drawing.Size(63, 22);
            this.lblHeightCutValue.TabIndex = 24;
            this.lblHeightCutValue.Text = "0";
            this.lblHeightCutValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeightCutValue.Click += new System.EventHandler(this.lblHeightCutValue_Click);
            // 
            // lblBWRatioValue
            // 
            this.lblBWRatioValue.BackColor = System.Drawing.Color.White;
            this.lblBWRatioValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBWRatioValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBWRatioValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblBWRatioValue.Location = new System.Drawing.Point(183, 66);
            this.lblBWRatioValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblBWRatioValue.Name = "lblBWRatioValue";
            this.lblBWRatioValue.Size = new System.Drawing.Size(63, 22);
            this.lblBWRatioValue.TabIndex = 25;
            this.lblBWRatioValue.Text = "0";
            this.lblBWRatioValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBWRatioValue.Click += new System.EventHandler(this.lblBWRatioValue_Click);
            // 
            // lblExtraLeadDisplayValue
            // 
            this.lblExtraLeadDisplayValue.BackColor = System.Drawing.Color.White;
            this.lblExtraLeadDisplayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExtraLeadDisplayValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExtraLeadDisplayValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblExtraLeadDisplayValue.Location = new System.Drawing.Point(183, 88);
            this.lblExtraLeadDisplayValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblExtraLeadDisplayValue.Name = "lblExtraLeadDisplayValue";
            this.lblExtraLeadDisplayValue.Size = new System.Drawing.Size(63, 22);
            this.lblExtraLeadDisplayValue.TabIndex = 26;
            this.lblExtraLeadDisplayValue.Text = "0";
            this.lblExtraLeadDisplayValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExtraLeadDisplayValue.Click += new System.EventHandler(this.lblExtraLeadDisplayValue_Click);
            // 
            // lblDimple
            // 
            this.lblDimple.BackColor = System.Drawing.Color.DarkGray;
            this.lblDimple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimple.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimple.Location = new System.Drawing.Point(0, 40);
            this.lblDimple.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimple.Name = "lblDimple";
            this.lblDimple.Size = new System.Drawing.Size(61, 20);
            this.lblDimple.TabIndex = 18;
            this.lblDimple.Text = "DIMPLE";
            this.lblDimple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDimpleNGCountValue
            // 
            this.lblDimpleNGCountValue.BackColor = System.Drawing.Color.White;
            this.lblDimpleNGCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleNGCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleNGCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimpleNGCountValue.Location = new System.Drawing.Point(61, 40);
            this.lblDimpleNGCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleNGCountValue.Name = "lblDimpleNGCountValue";
            this.lblDimpleNGCountValue.Size = new System.Drawing.Size(61, 20);
            this.lblDimpleNGCountValue.TabIndex = 27;
            this.lblDimpleNGCountValue.Text = "0";
            this.lblDimpleNGCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDimpleNGCountValue.Click += new System.EventHandler(this.lblDimpleNGCountValue_Click);
            // 
            // lblAlarm
            // 
            this.lblAlarm.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarm.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarm.Location = new System.Drawing.Point(0, 120);
            this.lblAlarm.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarm.Name = "lblAlarm";
            this.lblAlarm.Size = new System.Drawing.Size(61, 20);
            this.lblAlarm.TabIndex = 18;
            this.lblAlarm.Text = "ALARM";
            this.lblAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmCapacity
            // 
            this.lblAlarmCapacity.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlarmCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmCapacity.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarmCapacity.Location = new System.Drawing.Point(61, 100);
            this.lblAlarmCapacity.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmCapacity.Name = "lblAlarmCapacity";
            this.lblAlarmCapacity.Size = new System.Drawing.Size(61, 20);
            this.lblAlarmCapacity.TabIndex = 18;
            this.lblAlarmCapacity.Text = "NG CAPACITY";
            this.lblAlarmCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmNGCount
            // 
            this.lblAlarmNGCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblAlarmNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmNGCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarmNGCount.Location = new System.Drawing.Point(122, 100);
            this.lblAlarmNGCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmNGCount.Name = "lblAlarmNGCount";
            this.lblAlarmNGCount.Size = new System.Drawing.Size(61, 20);
            this.lblAlarmNGCount.TabIndex = 18;
            this.lblAlarmNGCount.Text = "NG COUNT";
            this.lblAlarmNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAlarmCapacityValue
            // 
            this.lblAlarmCapacityValue.BackColor = System.Drawing.Color.White;
            this.lblAlarmCapacityValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmCapacityValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmCapacityValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarmCapacityValue.Location = new System.Drawing.Point(61, 120);
            this.lblAlarmCapacityValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmCapacityValue.Name = "lblAlarmCapacityValue";
            this.lblAlarmCapacityValue.Size = new System.Drawing.Size(61, 20);
            this.lblAlarmCapacityValue.TabIndex = 27;
            this.lblAlarmCapacityValue.Text = "0";
            this.lblAlarmCapacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarmCapacityValue.Click += new System.EventHandler(this.lblAlarmCapacityValue_Click);
            // 
            // lblAlarmNGCountValue
            // 
            this.lblAlarmNGCountValue.BackColor = System.Drawing.Color.White;
            this.lblAlarmNGCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlarmNGCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlarmNGCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblAlarmNGCountValue.Location = new System.Drawing.Point(122, 120);
            this.lblAlarmNGCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmNGCountValue.Name = "lblAlarmNGCountValue";
            this.lblAlarmNGCountValue.Size = new System.Drawing.Size(61, 20);
            this.lblAlarmNGCountValue.TabIndex = 27;
            this.lblAlarmNGCountValue.Text = "0";
            this.lblAlarmNGCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlarmNGCountValue.Click += new System.EventHandler(this.lblAlarmNGCountValue_Click);
            // 
            // lblDimpleThresholdValue
            // 
            this.lblDimpleThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblDimpleThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimpleThresholdValue.Location = new System.Drawing.Point(122, 40);
            this.lblDimpleThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleThresholdValue.Name = "lblDimpleThresholdValue";
            this.lblDimpleThresholdValue.Size = new System.Drawing.Size(61, 20);
            this.lblDimpleThresholdValue.TabIndex = 27;
            this.lblDimpleThresholdValue.Text = "0";
            this.lblDimpleThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDimpleThresholdValue.Click += new System.EventHandler(this.lblDimpleThresholdValue_Click);
            // 
            // lblDimpleNGCount
            // 
            this.lblDimpleNGCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblDimpleNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleNGCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimpleNGCount.Location = new System.Drawing.Point(61, 20);
            this.lblDimpleNGCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleNGCount.Name = "lblDimpleNGCount";
            this.lblDimpleNGCount.Size = new System.Drawing.Size(61, 20);
            this.lblDimpleNGCount.TabIndex = 18;
            this.lblDimpleNGCount.Text = "NG COUNT";
            this.lblDimpleNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDimpleThreshold
            // 
            this.lblDimpleThreshold.BackColor = System.Drawing.Color.DarkGray;
            this.lblDimpleThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDimpleThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDimpleThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblDimpleThreshold.Location = new System.Drawing.Point(122, 20);
            this.lblDimpleThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblDimpleThreshold.Name = "lblDimpleThreshold";
            this.lblDimpleThreshold.Size = new System.Drawing.Size(61, 20);
            this.lblDimpleThreshold.TabIndex = 18;
            this.lblDimpleThreshold.Text = "THRESHOLD";
            this.lblDimpleThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkUseDimple
            // 
            this.chkUseDimple.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUseDimple.AutoSize = true;
            this.chkUseDimple.BackColor = System.Drawing.Color.DarkGray;
            this.chkUseDimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseDimple.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkUseDimple.Location = new System.Drawing.Point(183, 40);
            this.chkUseDimple.Margin = new System.Windows.Forms.Padding(0);
            this.chkUseDimple.Name = "chkUseDimple";
            this.chkUseDimple.Size = new System.Drawing.Size(63, 20);
            this.chkUseDimple.TabIndex = 47;
            this.chkUseDimple.Text = "On";
            this.chkUseDimple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseDimple.UseVisualStyleBackColor = false;
            this.chkUseDimple.CheckedChanged += new System.EventHandler(this.chkUseDimple_CheckedChanged);
            // 
            // pnlGroup
            // 
            this.pnlGroup.Controls.Add(this.tlpGroup);
            this.pnlGroup.Location = new System.Drawing.Point(0, 0);
            this.pnlGroup.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGroup.Name = "pnlGroup";
            this.pnlGroup.Size = new System.Drawing.Size(256, 183);
            this.pnlGroup.TabIndex = 0;
            this.pnlGroup.Visible = false;
            // 
            // tlpGroup
            // 
            this.tlpGroup.ColumnCount = 5;
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpGroup.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpGroup.Controls.Add(this.btnROIShow, 0, 6);
            this.tlpGroup.Controls.Add(this.lblGroupCount, 0, 0);
            this.tlpGroup.Controls.Add(this.lblGroupCountValue, 1, 0);
            this.tlpGroup.Controls.Add(this.cmbGroupNumber, 4, 0);
            this.tlpGroup.Controls.Add(this.lblGroupNumber, 3, 0);
            this.tlpGroup.Controls.Add(this.lblROIWidth, 0, 1);
            this.tlpGroup.Controls.Add(this.lblROIWidthValue, 1, 1);
            this.tlpGroup.Controls.Add(this.lblROIHeight, 3, 1);
            this.tlpGroup.Controls.Add(this.lblROIHeightValue, 4, 1);
            this.tlpGroup.Controls.Add(this.lblLeadCount, 0, 2);
            this.tlpGroup.Controls.Add(this.lblLeadCountValue, 1, 2);
            this.tlpGroup.Controls.Add(this.lblLeadPitch, 3, 2);
            this.tlpGroup.Controls.Add(this.lblLeadPitchValue, 4, 2);
            this.tlpGroup.Controls.Add(this.lblFirstLead, 0, 3);
            this.tlpGroup.Controls.Add(this.btnROICreate, 1, 3);
            this.tlpGroup.Controls.Add(this.btnRegister, 3, 3);
            this.tlpGroup.Controls.Add(this.lblCloneROI, 0, 4);
            this.tlpGroup.Controls.Add(this.tlpCloneROI, 1, 4);
            this.tlpGroup.Controls.Add(this.btnCopyROI, 3, 4);
            this.tlpGroup.Controls.Add(this.btnSort, 4, 4);
            this.tlpGroup.Controls.Add(this.btnDelete, 1, 6);
            this.tlpGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGroup.Location = new System.Drawing.Point(0, 0);
            this.tlpGroup.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGroup.Name = "tlpGroup";
            this.tlpGroup.RowCount = 7;
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGroup.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGroup.Size = new System.Drawing.Size(256, 183);
            this.tlpGroup.TabIndex = 1;
            // 
            // btnROIShow
            // 
            this.btnROIShow.BackColor = System.Drawing.Color.DarkGray;
            this.btnROIShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnROIShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnROIShow.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnROIShow.Location = new System.Drawing.Point(0, 132);
            this.btnROIShow.Margin = new System.Windows.Forms.Padding(0);
            this.btnROIShow.Name = "btnROIShow";
            this.btnROIShow.Size = new System.Drawing.Size(63, 51);
            this.btnROIShow.TabIndex = 293;
            this.btnROIShow.Text = "SHOW ROI";
            this.btnROIShow.UseVisualStyleBackColor = false;
            this.btnROIShow.Click += new System.EventHandler(this.btnROIShow_Click);
            // 
            // lblGroupCount
            // 
            this.lblGroupCount.AutoSize = true;
            this.lblGroupCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblGroupCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupCount.Location = new System.Drawing.Point(0, 0);
            this.lblGroupCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupCount.Name = "lblGroupCount";
            this.lblGroupCount.Size = new System.Drawing.Size(63, 22);
            this.lblGroupCount.TabIndex = 1;
            this.lblGroupCount.Text = "GROUP COUNT";
            this.lblGroupCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGroupCountValue
            // 
            this.lblGroupCountValue.AutoSize = true;
            this.lblGroupCountValue.BackColor = System.Drawing.Color.White;
            this.lblGroupCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupCountValue.Location = new System.Drawing.Point(63, 0);
            this.lblGroupCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupCountValue.Name = "lblGroupCountValue";
            this.lblGroupCountValue.Size = new System.Drawing.Size(63, 22);
            this.lblGroupCountValue.TabIndex = 8;
            this.lblGroupCountValue.Text = "0";
            this.lblGroupCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblGroupCountValue.Click += new System.EventHandler(this.lblGroupCountValue_Click);
            // 
            // cmbGroupNumber
            // 
            this.cmbGroupNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbGroupNumber.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGroupNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbGroupNumber.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbGroupNumber.FormattingEnabled = true;
            this.cmbGroupNumber.IntegralHeight = false;
            this.cmbGroupNumber.ItemHeight = 22;
            this.cmbGroupNumber.Location = new System.Drawing.Point(192, 0);
            this.cmbGroupNumber.Margin = new System.Windows.Forms.Padding(0);
            this.cmbGroupNumber.Name = "cmbGroupNumber";
            this.cmbGroupNumber.Size = new System.Drawing.Size(64, 28);
            this.cmbGroupNumber.TabIndex = 26;
            this.cmbGroupNumber.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbGroupNumber.SelectedIndexChanged += new System.EventHandler(this.cmbGroupNumber_SelectedIndexChanged);
            // 
            // lblGroupNumber
            // 
            this.lblGroupNumber.AutoSize = true;
            this.lblGroupNumber.BackColor = System.Drawing.Color.DarkGray;
            this.lblGroupNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupNumber.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupNumber.Location = new System.Drawing.Point(129, 0);
            this.lblGroupNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lblGroupNumber.Name = "lblGroupNumber";
            this.lblGroupNumber.Size = new System.Drawing.Size(63, 22);
            this.lblGroupNumber.TabIndex = 9;
            this.lblGroupNumber.Text = "GROUP No.";
            this.lblGroupNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIWidth
            // 
            this.lblROIWidth.AutoSize = true;
            this.lblROIWidth.BackColor = System.Drawing.Color.DarkGray;
            this.lblROIWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIWidth.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblROIWidth.Location = new System.Drawing.Point(0, 22);
            this.lblROIWidth.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIWidth.Name = "lblROIWidth";
            this.lblROIWidth.Size = new System.Drawing.Size(63, 22);
            this.lblROIWidth.TabIndex = 10;
            this.lblROIWidth.Text = "ROI WIDTH(㎛)";
            this.lblROIWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIWidthValue
            // 
            this.lblROIWidthValue.AutoSize = true;
            this.lblROIWidthValue.BackColor = System.Drawing.Color.White;
            this.lblROIWidthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIWidthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIWidthValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblROIWidthValue.Location = new System.Drawing.Point(63, 22);
            this.lblROIWidthValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIWidthValue.Name = "lblROIWidthValue";
            this.lblROIWidthValue.Size = new System.Drawing.Size(63, 22);
            this.lblROIWidthValue.TabIndex = 16;
            this.lblROIWidthValue.Text = "0";
            this.lblROIWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblROIWidthValue.Click += new System.EventHandler(this.lblROIWidthValue_Click);
            // 
            // lblROIHeight
            // 
            this.lblROIHeight.AutoSize = true;
            this.lblROIHeight.BackColor = System.Drawing.Color.DarkGray;
            this.lblROIHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIHeight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblROIHeight.Location = new System.Drawing.Point(129, 22);
            this.lblROIHeight.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIHeight.Name = "lblROIHeight";
            this.lblROIHeight.Size = new System.Drawing.Size(63, 22);
            this.lblROIHeight.TabIndex = 11;
            this.lblROIHeight.Text = "ROI HEIGHT(㎛)";
            this.lblROIHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblROIHeightValue
            // 
            this.lblROIHeightValue.AutoSize = true;
            this.lblROIHeightValue.BackColor = System.Drawing.Color.White;
            this.lblROIHeightValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblROIHeightValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblROIHeightValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblROIHeightValue.Location = new System.Drawing.Point(192, 22);
            this.lblROIHeightValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblROIHeightValue.Name = "lblROIHeightValue";
            this.lblROIHeightValue.Size = new System.Drawing.Size(64, 22);
            this.lblROIHeightValue.TabIndex = 17;
            this.lblROIHeightValue.Text = "0";
            this.lblROIHeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblROIHeightValue.Click += new System.EventHandler(this.lblROIHeightValue_Click);
            // 
            // lblLeadCount
            // 
            this.lblLeadCount.AutoSize = true;
            this.lblLeadCount.BackColor = System.Drawing.Color.DarkGray;
            this.lblLeadCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadCount.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLeadCount.Location = new System.Drawing.Point(0, 44);
            this.lblLeadCount.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadCount.Name = "lblLeadCount";
            this.lblLeadCount.Size = new System.Drawing.Size(63, 22);
            this.lblLeadCount.TabIndex = 14;
            this.lblLeadCount.Text = "LEAD COUNT";
            this.lblLeadCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeadCountValue
            // 
            this.lblLeadCountValue.AutoSize = true;
            this.lblLeadCountValue.BackColor = System.Drawing.Color.White;
            this.lblLeadCountValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadCountValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadCountValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLeadCountValue.Location = new System.Drawing.Point(63, 44);
            this.lblLeadCountValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadCountValue.Name = "lblLeadCountValue";
            this.lblLeadCountValue.Size = new System.Drawing.Size(63, 22);
            this.lblLeadCountValue.TabIndex = 19;
            this.lblLeadCountValue.Text = "0";
            this.lblLeadCountValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadCountValue.Click += new System.EventHandler(this.lblLeadCountValue_Click);
            // 
            // lblLeadPitch
            // 
            this.lblLeadPitch.AutoSize = true;
            this.lblLeadPitch.BackColor = System.Drawing.Color.DarkGray;
            this.lblLeadPitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadPitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadPitch.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLeadPitch.Location = new System.Drawing.Point(129, 44);
            this.lblLeadPitch.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadPitch.Name = "lblLeadPitch";
            this.lblLeadPitch.Size = new System.Drawing.Size(63, 22);
            this.lblLeadPitch.TabIndex = 13;
            this.lblLeadPitch.Text = "LEAD PITCH(㎛)";
            this.lblLeadPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLeadPitchValue
            // 
            this.lblLeadPitchValue.AutoSize = true;
            this.lblLeadPitchValue.BackColor = System.Drawing.Color.White;
            this.lblLeadPitchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeadPitchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLeadPitchValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLeadPitchValue.Location = new System.Drawing.Point(192, 44);
            this.lblLeadPitchValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblLeadPitchValue.Name = "lblLeadPitchValue";
            this.lblLeadPitchValue.Size = new System.Drawing.Size(64, 22);
            this.lblLeadPitchValue.TabIndex = 18;
            this.lblLeadPitchValue.Text = "0";
            this.lblLeadPitchValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeadPitchValue.Click += new System.EventHandler(this.lblLeadPitchValue_Click);
            // 
            // lblFirstLead
            // 
            this.lblFirstLead.AutoSize = true;
            this.lblFirstLead.BackColor = System.Drawing.Color.DarkGray;
            this.lblFirstLead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFirstLead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFirstLead.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblFirstLead.Location = new System.Drawing.Point(0, 66);
            this.lblFirstLead.Margin = new System.Windows.Forms.Padding(0);
            this.lblFirstLead.Name = "lblFirstLead";
            this.lblFirstLead.Size = new System.Drawing.Size(63, 22);
            this.lblFirstLead.TabIndex = 12;
            this.lblFirstLead.Text = "FIRST LEAD";
            this.lblFirstLead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnROICreate
            // 
            this.btnROICreate.BackColor = System.Drawing.Color.DarkGray;
            this.btnROICreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnROICreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnROICreate.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnROICreate.Location = new System.Drawing.Point(63, 66);
            this.btnROICreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnROICreate.Name = "btnROICreate";
            this.btnROICreate.Size = new System.Drawing.Size(63, 22);
            this.btnROICreate.TabIndex = 198;
            this.btnROICreate.Text = "ROI CREATE";
            this.btnROICreate.UseVisualStyleBackColor = false;
            this.btnROICreate.Click += new System.EventHandler(this.btnROICreate_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DarkGray;
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRegister.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(129, 66);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(63, 22);
            this.btnRegister.TabIndex = 198;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblCloneROI
            // 
            this.lblCloneROI.AutoSize = true;
            this.lblCloneROI.BackColor = System.Drawing.Color.DarkGray;
            this.lblCloneROI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCloneROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCloneROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblCloneROI.Location = new System.Drawing.Point(0, 88);
            this.lblCloneROI.Margin = new System.Windows.Forms.Padding(0);
            this.lblCloneROI.Name = "lblCloneROI";
            this.lblCloneROI.Size = new System.Drawing.Size(63, 22);
            this.lblCloneROI.TabIndex = 15;
            this.lblCloneROI.Text = "CLONE ROI";
            this.lblCloneROI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpCloneROI
            // 
            this.tlpCloneROI.ColumnCount = 2;
            this.tlpCloneROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCloneROI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCloneROI.Controls.Add(this.rdoCopyHorizontal, 0, 0);
            this.tlpCloneROI.Controls.Add(this.rdoCopyVertical, 1, 0);
            this.tlpCloneROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCloneROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.tlpCloneROI.Location = new System.Drawing.Point(63, 88);
            this.tlpCloneROI.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCloneROI.Name = "tlpCloneROI";
            this.tlpCloneROI.RowCount = 1;
            this.tlpCloneROI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCloneROI.Size = new System.Drawing.Size(63, 22);
            this.tlpCloneROI.TabIndex = 27;
            // 
            // rdoCopyHorizontal
            // 
            this.rdoCopyHorizontal.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCopyHorizontal.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCopyHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCopyHorizontal.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCopyHorizontal.ForeColor = System.Drawing.Color.Black;
            this.rdoCopyHorizontal.Image = ((System.Drawing.Image)(resources.GetObject("rdoCopyHorizontal.Image")));
            this.rdoCopyHorizontal.Location = new System.Drawing.Point(0, 0);
            this.rdoCopyHorizontal.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCopyHorizontal.Name = "rdoCopyHorizontal";
            this.rdoCopyHorizontal.Size = new System.Drawing.Size(31, 22);
            this.rdoCopyHorizontal.TabIndex = 142;
            this.rdoCopyHorizontal.Tag = "0";
            this.rdoCopyHorizontal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCopyHorizontal.UseVisualStyleBackColor = false;
            this.rdoCopyHorizontal.CheckedChanged += new System.EventHandler(this.rdoSetROICopyType_CheckedChanged);
            // 
            // rdoCopyVertical
            // 
            this.rdoCopyVertical.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoCopyVertical.BackColor = System.Drawing.Color.DarkGray;
            this.rdoCopyVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoCopyVertical.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoCopyVertical.ForeColor = System.Drawing.Color.Black;
            this.rdoCopyVertical.Image = ((System.Drawing.Image)(resources.GetObject("rdoCopyVertical.Image")));
            this.rdoCopyVertical.Location = new System.Drawing.Point(31, 0);
            this.rdoCopyVertical.Margin = new System.Windows.Forms.Padding(0);
            this.rdoCopyVertical.Name = "rdoCopyVertical";
            this.rdoCopyVertical.Size = new System.Drawing.Size(32, 22);
            this.rdoCopyVertical.TabIndex = 142;
            this.rdoCopyVertical.Tag = "0";
            this.rdoCopyVertical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoCopyVertical.UseVisualStyleBackColor = false;
            this.rdoCopyVertical.CheckedChanged += new System.EventHandler(this.rdoSetROICopyType_CheckedChanged);
            // 
            // btnCopyROI
            // 
            this.btnCopyROI.BackColor = System.Drawing.Color.DarkGray;
            this.btnCopyROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCopyROI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCopyROI.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnCopyROI.Location = new System.Drawing.Point(129, 88);
            this.btnCopyROI.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopyROI.Name = "btnCopyROI";
            this.btnCopyROI.Size = new System.Drawing.Size(63, 22);
            this.btnCopyROI.TabIndex = 198;
            this.btnCopyROI.Text = "ROI COPY";
            this.btnCopyROI.UseVisualStyleBackColor = false;
            this.btnCopyROI.Click += new System.EventHandler(this.btnCopyROI_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.Color.DarkGray;
            this.btnSort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSort.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnSort.Location = new System.Drawing.Point(192, 88);
            this.btnSort.Margin = new System.Windows.Forms.Padding(0);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(64, 22);
            this.btnSort.TabIndex = 290;
            this.btnSort.Text = "AUTO SORT";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkGray;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Location = new System.Drawing.Point(63, 132);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 51);
            this.btnDelete.TabIndex = 198;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // pnlMakerParameter
            // 
            this.pnlMakerParameter.Controls.Add(this.tlpMakerParameter);
            this.pnlMakerParameter.Location = new System.Drawing.Point(539, 4);
            this.pnlMakerParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMakerParameter.Name = "pnlMakerParameter";
            this.pnlMakerParameter.Size = new System.Drawing.Size(248, 179);
            this.pnlMakerParameter.TabIndex = 2;
            this.pnlMakerParameter.Visible = false;
            // 
            // tlpMakerParameter
            // 
            this.tlpMakerParameter.ColumnCount = 5;
            this.tlpMakerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMakerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMakerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tlpMakerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMakerParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMakerParameter.Controls.Add(this.cmbFilterDirection, 1, 4);
            this.tlpMakerParameter.Controls.Add(this.cmbFilterType, 1, 3);
            this.tlpMakerParameter.Controls.Add(this.cmbStrengthBase, 4, 2);
            this.tlpMakerParameter.Controls.Add(this.cmbTargetType, 1, 2);
            this.tlpMakerParameter.Controls.Add(this.cmbPeakProperty, 4, 1);
            this.tlpMakerParameter.Controls.Add(this.cmbPanelType, 1, 1);
            this.tlpMakerParameter.Controls.Add(this.cmbShadowDirection, 4, 0);
            this.tlpMakerParameter.Controls.Add(this.lblInspectionType, 0, 0);
            this.tlpMakerParameter.Controls.Add(this.lblThresholdWeightValue, 1, 5);
            this.tlpMakerParameter.Controls.Add(this.lblPeakThreshold, 0, 6);
            this.tlpMakerParameter.Controls.Add(this.lblThresholdWeight, 0, 5);
            this.tlpMakerParameter.Controls.Add(this.lblFilterDirection, 0, 4);
            this.tlpMakerParameter.Controls.Add(this.lblFilterType, 0, 3);
            this.tlpMakerParameter.Controls.Add(this.lblTargetType, 0, 2);
            this.tlpMakerParameter.Controls.Add(this.lblPanelType, 0, 1);
            this.tlpMakerParameter.Controls.Add(this.lblShadowDirection, 3, 0);
            this.tlpMakerParameter.Controls.Add(this.lblPeakProperty, 3, 1);
            this.tlpMakerParameter.Controls.Add(this.lblStrengthBase, 3, 2);
            this.tlpMakerParameter.Controls.Add(this.lblLogTrace, 3, 3);
            this.tlpMakerParameter.Controls.Add(this.lblThresholdMode, 3, 4);
            this.tlpMakerParameter.Controls.Add(this.lblStrengthScaleFactor, 3, 5);
            this.tlpMakerParameter.Controls.Add(this.lblSliceOverlap, 3, 6);
            this.tlpMakerParameter.Controls.Add(this.lblPeakThresholdValue, 1, 6);
            this.tlpMakerParameter.Controls.Add(this.lblStrengthScaleFactorValue, 4, 5);
            this.tlpMakerParameter.Controls.Add(this.lblSliceOverlapValue, 4, 6);
            this.tlpMakerParameter.Controls.Add(this.lblStandardDeviationValue, 1, 7);
            this.tlpMakerParameter.Controls.Add(this.lblStandardDeviation, 0, 7);
            this.tlpMakerParameter.Controls.Add(this.cmbInspectionType, 1, 0);
            this.tlpMakerParameter.Controls.Add(this.cmbThresholdMode, 4, 4);
            this.tlpMakerParameter.Controls.Add(this.chkLogTraceUseCheck, 4, 3);
            this.tlpMakerParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMakerParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpMakerParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMakerParameter.Name = "tlpMakerParameter";
            this.tlpMakerParameter.RowCount = 8;
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMakerParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMakerParameter.Size = new System.Drawing.Size(248, 179);
            this.tlpMakerParameter.TabIndex = 0;
            // 
            // cmbFilterDirection
            // 
            this.cmbFilterDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilterDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFilterDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbFilterDirection.FormattingEnabled = true;
            this.cmbFilterDirection.IntegralHeight = false;
            this.cmbFilterDirection.Location = new System.Drawing.Point(61, 88);
            this.cmbFilterDirection.Margin = new System.Windows.Forms.Padding(0);
            this.cmbFilterDirection.Name = "cmbFilterDirection";
            this.cmbFilterDirection.Size = new System.Drawing.Size(61, 28);
            this.cmbFilterDirection.TabIndex = 149;
            this.cmbFilterDirection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbFilterDirection.SelectionChangeCommitted += new System.EventHandler(this.cmbFilterDirection_SelectionChangeCommitted);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbFilterType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbFilterType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.IntegralHeight = false;
            this.cmbFilterType.Location = new System.Drawing.Point(61, 66);
            this.cmbFilterType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(61, 28);
            this.cmbFilterType.TabIndex = 147;
            this.cmbFilterType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbFilterType.SelectionChangeCommitted += new System.EventHandler(this.cmbFilterType_SelectionChangeCommitted);
            // 
            // cmbStrengthBase
            // 
            this.cmbStrengthBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStrengthBase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStrengthBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStrengthBase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbStrengthBase.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbStrengthBase.FormattingEnabled = true;
            this.cmbStrengthBase.IntegralHeight = false;
            this.cmbStrengthBase.Location = new System.Drawing.Point(186, 44);
            this.cmbStrengthBase.Margin = new System.Windows.Forms.Padding(0);
            this.cmbStrengthBase.Name = "cmbStrengthBase";
            this.cmbStrengthBase.Size = new System.Drawing.Size(62, 28);
            this.cmbStrengthBase.TabIndex = 146;
            this.cmbStrengthBase.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbStrengthBase.SelectionChangeCommitted += new System.EventHandler(this.cmbStrengthBase_SelectionChangeCommitted);
            // 
            // cmbTargetType
            // 
            this.cmbTargetType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbTargetType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbTargetType.FormattingEnabled = true;
            this.cmbTargetType.IntegralHeight = false;
            this.cmbTargetType.Location = new System.Drawing.Point(61, 44);
            this.cmbTargetType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbTargetType.Name = "cmbTargetType";
            this.cmbTargetType.Size = new System.Drawing.Size(61, 28);
            this.cmbTargetType.TabIndex = 145;
            this.cmbTargetType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbTargetType.SelectionChangeCommitted += new System.EventHandler(this.cmbTargetType_SelectionChangeCommitted);
            // 
            // cmbPeakProperty
            // 
            this.cmbPeakProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPeakProperty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPeakProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeakProperty.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPeakProperty.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbPeakProperty.FormattingEnabled = true;
            this.cmbPeakProperty.IntegralHeight = false;
            this.cmbPeakProperty.Location = new System.Drawing.Point(186, 22);
            this.cmbPeakProperty.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPeakProperty.Name = "cmbPeakProperty";
            this.cmbPeakProperty.Size = new System.Drawing.Size(62, 28);
            this.cmbPeakProperty.TabIndex = 144;
            this.cmbPeakProperty.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbPeakProperty.SelectionChangeCommitted += new System.EventHandler(this.cmbPeakProperty_SelectionChangeCommitted);
            // 
            // cmbPanelType
            // 
            this.cmbPanelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPanelType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPanelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPanelType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbPanelType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbPanelType.FormattingEnabled = true;
            this.cmbPanelType.IntegralHeight = false;
            this.cmbPanelType.Location = new System.Drawing.Point(61, 22);
            this.cmbPanelType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbPanelType.Name = "cmbPanelType";
            this.cmbPanelType.Size = new System.Drawing.Size(61, 28);
            this.cmbPanelType.TabIndex = 143;
            this.cmbPanelType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbPanelType.SelectionChangeCommitted += new System.EventHandler(this.cmbPanelType_SelectionChangeCommitted);
            // 
            // cmbShadowDirection
            // 
            this.cmbShadowDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbShadowDirection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbShadowDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShadowDirection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbShadowDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbShadowDirection.FormattingEnabled = true;
            this.cmbShadowDirection.IntegralHeight = false;
            this.cmbShadowDirection.Location = new System.Drawing.Point(186, 0);
            this.cmbShadowDirection.Margin = new System.Windows.Forms.Padding(0);
            this.cmbShadowDirection.Name = "cmbShadowDirection";
            this.cmbShadowDirection.Size = new System.Drawing.Size(62, 28);
            this.cmbShadowDirection.TabIndex = 142;
            this.cmbShadowDirection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbShadowDirection.SelectionChangeCommitted += new System.EventHandler(this.cmbShadowDirection_SelectionChangeCommitted);
            // 
            // lblInspectionType
            // 
            this.lblInspectionType.BackColor = System.Drawing.Color.DarkGray;
            this.lblInspectionType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInspectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInspectionType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblInspectionType.Location = new System.Drawing.Point(0, 0);
            this.lblInspectionType.Margin = new System.Windows.Forms.Padding(0);
            this.lblInspectionType.Name = "lblInspectionType";
            this.lblInspectionType.Size = new System.Drawing.Size(61, 22);
            this.lblInspectionType.TabIndex = 3;
            this.lblInspectionType.Text = "INSPECTION TYPE";
            this.lblInspectionType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThresholdWeightValue
            // 
            this.lblThresholdWeightValue.BackColor = System.Drawing.Color.White;
            this.lblThresholdWeightValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThresholdWeightValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThresholdWeightValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblThresholdWeightValue.Location = new System.Drawing.Point(61, 110);
            this.lblThresholdWeightValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblThresholdWeightValue.Name = "lblThresholdWeightValue";
            this.lblThresholdWeightValue.Size = new System.Drawing.Size(61, 22);
            this.lblThresholdWeightValue.TabIndex = 28;
            this.lblThresholdWeightValue.Text = "0";
            this.lblThresholdWeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThresholdWeightValue.Click += new System.EventHandler(this.lblThresholdWeightValue_Click);
            // 
            // lblPeakThreshold
            // 
            this.lblPeakThreshold.BackColor = System.Drawing.Color.DarkGray;
            this.lblPeakThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeakThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPeakThreshold.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPeakThreshold.Location = new System.Drawing.Point(0, 132);
            this.lblPeakThreshold.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeakThreshold.Name = "lblPeakThreshold";
            this.lblPeakThreshold.Size = new System.Drawing.Size(61, 22);
            this.lblPeakThreshold.TabIndex = 29;
            this.lblPeakThreshold.Text = "PEAK THRESHOLD";
            this.lblPeakThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThresholdWeight
            // 
            this.lblThresholdWeight.BackColor = System.Drawing.Color.DarkGray;
            this.lblThresholdWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThresholdWeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThresholdWeight.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblThresholdWeight.Location = new System.Drawing.Point(0, 110);
            this.lblThresholdWeight.Margin = new System.Windows.Forms.Padding(0);
            this.lblThresholdWeight.Name = "lblThresholdWeight";
            this.lblThresholdWeight.Size = new System.Drawing.Size(61, 22);
            this.lblThresholdWeight.TabIndex = 30;
            this.lblThresholdWeight.Text = "THRESHOLD WEIGHT";
            this.lblThresholdWeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterDirection
            // 
            this.lblFilterDirection.BackColor = System.Drawing.Color.DarkGray;
            this.lblFilterDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilterDirection.Location = new System.Drawing.Point(0, 88);
            this.lblFilterDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilterDirection.Name = "lblFilterDirection";
            this.lblFilterDirection.Size = new System.Drawing.Size(61, 22);
            this.lblFilterDirection.TabIndex = 31;
            this.lblFilterDirection.Text = "FILTER DIRECTION";
            this.lblFilterDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFilterType
            // 
            this.lblFilterType.BackColor = System.Drawing.Color.DarkGray;
            this.lblFilterType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFilterType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilterType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilterType.Location = new System.Drawing.Point(0, 66);
            this.lblFilterType.Margin = new System.Windows.Forms.Padding(0);
            this.lblFilterType.Name = "lblFilterType";
            this.lblFilterType.Size = new System.Drawing.Size(61, 22);
            this.lblFilterType.TabIndex = 32;
            this.lblFilterType.Text = "FILTER TYPE";
            this.lblFilterType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetType
            // 
            this.lblTargetType.BackColor = System.Drawing.Color.DarkGray;
            this.lblTargetType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTargetType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTargetType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblTargetType.Location = new System.Drawing.Point(0, 44);
            this.lblTargetType.Margin = new System.Windows.Forms.Padding(0);
            this.lblTargetType.Name = "lblTargetType";
            this.lblTargetType.Size = new System.Drawing.Size(61, 22);
            this.lblTargetType.TabIndex = 33;
            this.lblTargetType.Text = "TARGET TYPE";
            this.lblTargetType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelType
            // 
            this.lblPanelType.BackColor = System.Drawing.Color.DarkGray;
            this.lblPanelType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanelType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPanelType.Location = new System.Drawing.Point(0, 22);
            this.lblPanelType.Margin = new System.Windows.Forms.Padding(0);
            this.lblPanelType.Name = "lblPanelType";
            this.lblPanelType.Size = new System.Drawing.Size(61, 22);
            this.lblPanelType.TabIndex = 34;
            this.lblPanelType.Text = "PANEL TYPE";
            this.lblPanelType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShadowDirection
            // 
            this.lblShadowDirection.BackColor = System.Drawing.Color.DarkGray;
            this.lblShadowDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShadowDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblShadowDirection.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblShadowDirection.Location = new System.Drawing.Point(125, 0);
            this.lblShadowDirection.Margin = new System.Windows.Forms.Padding(0);
            this.lblShadowDirection.Name = "lblShadowDirection";
            this.lblShadowDirection.Size = new System.Drawing.Size(61, 22);
            this.lblShadowDirection.TabIndex = 35;
            this.lblShadowDirection.Text = "SHADOW DIRECTION";
            this.lblShadowDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeakProperty
            // 
            this.lblPeakProperty.BackColor = System.Drawing.Color.DarkGray;
            this.lblPeakProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeakProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPeakProperty.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPeakProperty.Location = new System.Drawing.Point(125, 22);
            this.lblPeakProperty.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeakProperty.Name = "lblPeakProperty";
            this.lblPeakProperty.Size = new System.Drawing.Size(61, 22);
            this.lblPeakProperty.TabIndex = 36;
            this.lblPeakProperty.Text = "PEAK PROPERTY";
            this.lblPeakProperty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStrengthBase
            // 
            this.lblStrengthBase.BackColor = System.Drawing.Color.DarkGray;
            this.lblStrengthBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrengthBase.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStrengthBase.Location = new System.Drawing.Point(125, 44);
            this.lblStrengthBase.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthBase.Name = "lblStrengthBase";
            this.lblStrengthBase.Size = new System.Drawing.Size(61, 22);
            this.lblStrengthBase.TabIndex = 38;
            this.lblStrengthBase.Text = "STRENGTH BASE";
            this.lblStrengthBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLogTrace
            // 
            this.lblLogTrace.BackColor = System.Drawing.Color.DarkGray;
            this.lblLogTrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLogTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogTrace.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogTrace.Location = new System.Drawing.Point(125, 66);
            this.lblLogTrace.Margin = new System.Windows.Forms.Padding(0);
            this.lblLogTrace.Name = "lblLogTrace";
            this.lblLogTrace.Size = new System.Drawing.Size(61, 22);
            this.lblLogTrace.TabIndex = 37;
            this.lblLogTrace.Text = "LOG TRACE";
            this.lblLogTrace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThresholdMode
            // 
            this.lblThresholdMode.BackColor = System.Drawing.Color.DarkGray;
            this.lblThresholdMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblThresholdMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblThresholdMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblThresholdMode.Location = new System.Drawing.Point(125, 88);
            this.lblThresholdMode.Margin = new System.Windows.Forms.Padding(0);
            this.lblThresholdMode.Name = "lblThresholdMode";
            this.lblThresholdMode.Size = new System.Drawing.Size(61, 22);
            this.lblThresholdMode.TabIndex = 39;
            this.lblThresholdMode.Text = "THRESHOLD MODE";
            this.lblThresholdMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStrengthScaleFactor
            // 
            this.lblStrengthScaleFactor.BackColor = System.Drawing.Color.DarkGray;
            this.lblStrengthScaleFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthScaleFactor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrengthScaleFactor.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStrengthScaleFactor.Location = new System.Drawing.Point(125, 110);
            this.lblStrengthScaleFactor.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthScaleFactor.Name = "lblStrengthScaleFactor";
            this.lblStrengthScaleFactor.Size = new System.Drawing.Size(61, 22);
            this.lblStrengthScaleFactor.TabIndex = 40;
            this.lblStrengthScaleFactor.Text = "STRENGTH SCALE FACTOR";
            this.lblStrengthScaleFactor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSliceOverlap
            // 
            this.lblSliceOverlap.BackColor = System.Drawing.Color.DarkGray;
            this.lblSliceOverlap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSliceOverlap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSliceOverlap.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSliceOverlap.Location = new System.Drawing.Point(125, 132);
            this.lblSliceOverlap.Margin = new System.Windows.Forms.Padding(0);
            this.lblSliceOverlap.Name = "lblSliceOverlap";
            this.lblSliceOverlap.Size = new System.Drawing.Size(61, 22);
            this.lblSliceOverlap.TabIndex = 41;
            this.lblSliceOverlap.Text = "SLICE OVERLAP";
            this.lblSliceOverlap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPeakThresholdValue
            // 
            this.lblPeakThresholdValue.BackColor = System.Drawing.Color.White;
            this.lblPeakThresholdValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPeakThresholdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPeakThresholdValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblPeakThresholdValue.Location = new System.Drawing.Point(61, 132);
            this.lblPeakThresholdValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeakThresholdValue.Name = "lblPeakThresholdValue";
            this.lblPeakThresholdValue.Size = new System.Drawing.Size(61, 22);
            this.lblPeakThresholdValue.TabIndex = 43;
            this.lblPeakThresholdValue.Text = "0";
            this.lblPeakThresholdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPeakThresholdValue.Click += new System.EventHandler(this.lblPeakThresholdValue_Click);
            // 
            // lblStrengthScaleFactorValue
            // 
            this.lblStrengthScaleFactorValue.BackColor = System.Drawing.Color.White;
            this.lblStrengthScaleFactorValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStrengthScaleFactorValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStrengthScaleFactorValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStrengthScaleFactorValue.Location = new System.Drawing.Point(186, 110);
            this.lblStrengthScaleFactorValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStrengthScaleFactorValue.Name = "lblStrengthScaleFactorValue";
            this.lblStrengthScaleFactorValue.Size = new System.Drawing.Size(62, 22);
            this.lblStrengthScaleFactorValue.TabIndex = 44;
            this.lblStrengthScaleFactorValue.Text = "0";
            this.lblStrengthScaleFactorValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStrengthScaleFactorValue.Click += new System.EventHandler(this.lblStrengthScaleFactorValue_Click);
            // 
            // lblSliceOverlapValue
            // 
            this.lblSliceOverlapValue.BackColor = System.Drawing.Color.White;
            this.lblSliceOverlapValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSliceOverlapValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSliceOverlapValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblSliceOverlapValue.Location = new System.Drawing.Point(186, 132);
            this.lblSliceOverlapValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblSliceOverlapValue.Name = "lblSliceOverlapValue";
            this.lblSliceOverlapValue.Size = new System.Drawing.Size(62, 22);
            this.lblSliceOverlapValue.TabIndex = 45;
            this.lblSliceOverlapValue.Text = "0";
            this.lblSliceOverlapValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSliceOverlapValue.Click += new System.EventHandler(this.lblSliceOverlapValue_Click);
            // 
            // lblStandardDeviationValue
            // 
            this.lblStandardDeviationValue.BackColor = System.Drawing.Color.White;
            this.lblStandardDeviationValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandardDeviationValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStandardDeviationValue.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStandardDeviationValue.Location = new System.Drawing.Point(61, 154);
            this.lblStandardDeviationValue.Margin = new System.Windows.Forms.Padding(0);
            this.lblStandardDeviationValue.Name = "lblStandardDeviationValue";
            this.lblStandardDeviationValue.Size = new System.Drawing.Size(61, 25);
            this.lblStandardDeviationValue.TabIndex = 46;
            this.lblStandardDeviationValue.Text = "0";
            this.lblStandardDeviationValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStandardDeviationValue.Click += new System.EventHandler(this.lblStandardDeviationValue_Click);
            // 
            // lblStandardDeviation
            // 
            this.lblStandardDeviation.BackColor = System.Drawing.Color.DarkGray;
            this.lblStandardDeviation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStandardDeviation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStandardDeviation.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.lblStandardDeviation.Location = new System.Drawing.Point(0, 154);
            this.lblStandardDeviation.Margin = new System.Windows.Forms.Padding(0);
            this.lblStandardDeviation.Name = "lblStandardDeviation";
            this.lblStandardDeviation.Size = new System.Drawing.Size(61, 25);
            this.lblStandardDeviation.TabIndex = 42;
            this.lblStandardDeviation.Text = "STANDARD DEVIATION";
            this.lblStandardDeviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbInspectionType
            // 
            this.cmbInspectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbInspectionType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbInspectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInspectionType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbInspectionType.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbInspectionType.FormattingEnabled = true;
            this.cmbInspectionType.IntegralHeight = false;
            this.cmbInspectionType.Location = new System.Drawing.Point(61, 0);
            this.cmbInspectionType.Margin = new System.Windows.Forms.Padding(0);
            this.cmbInspectionType.Name = "cmbInspectionType";
            this.cmbInspectionType.Size = new System.Drawing.Size(61, 28);
            this.cmbInspectionType.TabIndex = 141;
            this.cmbInspectionType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbInspectionType.SelectionChangeCommitted += new System.EventHandler(this.cmbInspectionType_SelectionChangeCommitted);
            // 
            // cmbThresholdMode
            // 
            this.cmbThresholdMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbThresholdMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbThresholdMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThresholdMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbThresholdMode.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cmbThresholdMode.FormattingEnabled = true;
            this.cmbThresholdMode.IntegralHeight = false;
            this.cmbThresholdMode.Location = new System.Drawing.Point(186, 88);
            this.cmbThresholdMode.Margin = new System.Windows.Forms.Padding(0);
            this.cmbThresholdMode.Name = "cmbThresholdMode";
            this.cmbThresholdMode.Size = new System.Drawing.Size(62, 28);
            this.cmbThresholdMode.TabIndex = 148;
            this.cmbThresholdMode.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmb_DrawItem);
            this.cmbThresholdMode.SelectionChangeCommitted += new System.EventHandler(this.cmbThresholdMode_SelectionChangeCommitted);
            // 
            // chkLogTraceUseCheck
            // 
            this.chkLogTraceUseCheck.BackColor = System.Drawing.Color.Silver;
            this.chkLogTraceUseCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLogTraceUseCheck.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkLogTraceUseCheck.Location = new System.Drawing.Point(192, 66);
            this.chkLogTraceUseCheck.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.chkLogTraceUseCheck.Name = "chkLogTraceUseCheck";
            this.chkLogTraceUseCheck.Size = new System.Drawing.Size(56, 22);
            this.chkLogTraceUseCheck.TabIndex = 150;
            this.chkLogTraceUseCheck.Text = "USE CHECK";
            this.chkLogTraceUseCheck.UseVisualStyleBackColor = false;
            this.chkLogTraceUseCheck.CheckedChanged += new System.EventHandler(this.chkLogTraceUseCheck_CheckedChanged);
            // 
            // pnlSelectParameter
            // 
            this.pnlSelectParameter.Controls.Add(this.tlpSelectParameter);
            this.pnlSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelectParameter.Name = "pnlSelectParameter";
            this.pnlSelectParameter.Size = new System.Drawing.Size(800, 60);
            this.pnlSelectParameter.TabIndex = 2;
            // 
            // tlpSelectParameter
            // 
            this.tlpSelectParameter.ColumnCount = 5;
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSelectParameter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSelectParameter.Controls.Add(this.rdoBump, 0, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoGroup, 0, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoMakerParmeter, 3, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoEngineerParmeter, 2, 0);
            this.tlpSelectParameter.Controls.Add(this.rdoOption, 4, 0);
            this.tlpSelectParameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectParameter.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectParameter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectParameter.Name = "tlpSelectParameter";
            this.tlpSelectParameter.RowCount = 1;
            this.tlpSelectParameter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectParameter.Size = new System.Drawing.Size(800, 60);
            this.tlpSelectParameter.TabIndex = 0;
            // 
            // rdoBump
            // 
            this.rdoBump.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoBump.BackColor = System.Drawing.Color.DarkGray;
            this.rdoBump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoBump.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoBump.Location = new System.Drawing.Point(160, 0);
            this.rdoBump.Margin = new System.Windows.Forms.Padding(0);
            this.rdoBump.Name = "rdoBump";
            this.rdoBump.Size = new System.Drawing.Size(160, 60);
            this.rdoBump.TabIndex = 3;
            this.rdoBump.TabStop = true;
            this.rdoBump.Text = "BUMP";
            this.rdoBump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoBump.UseVisualStyleBackColor = false;
            this.rdoBump.CheckedChanged += new System.EventHandler(this.rdoParameterType_CheckedChanged);
            // 
            // rdoGroup
            // 
            this.rdoGroup.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoGroup.BackColor = System.Drawing.Color.DarkGray;
            this.rdoGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoGroup.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoGroup.Location = new System.Drawing.Point(0, 0);
            this.rdoGroup.Margin = new System.Windows.Forms.Padding(0);
            this.rdoGroup.Name = "rdoGroup";
            this.rdoGroup.Size = new System.Drawing.Size(160, 60);
            this.rdoGroup.TabIndex = 0;
            this.rdoGroup.TabStop = true;
            this.rdoGroup.Text = "GROUP";
            this.rdoGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoGroup.UseVisualStyleBackColor = false;
            this.rdoGroup.CheckedChanged += new System.EventHandler(this.rdoParameterType_CheckedChanged);
            // 
            // rdoMakerParmeter
            // 
            this.rdoMakerParmeter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMakerParmeter.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMakerParmeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMakerParmeter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoMakerParmeter.Location = new System.Drawing.Point(480, 0);
            this.rdoMakerParmeter.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMakerParmeter.Name = "rdoMakerParmeter";
            this.rdoMakerParmeter.Size = new System.Drawing.Size(160, 60);
            this.rdoMakerParmeter.TabIndex = 1;
            this.rdoMakerParmeter.TabStop = true;
            this.rdoMakerParmeter.Text = "MAKER\r\nPARAMETER";
            this.rdoMakerParmeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMakerParmeter.UseVisualStyleBackColor = false;
            this.rdoMakerParmeter.CheckedChanged += new System.EventHandler(this.rdoParameterType_CheckedChanged);
            // 
            // rdoEngineerParmeter
            // 
            this.rdoEngineerParmeter.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoEngineerParmeter.BackColor = System.Drawing.Color.DarkGray;
            this.rdoEngineerParmeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoEngineerParmeter.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoEngineerParmeter.Location = new System.Drawing.Point(320, 0);
            this.rdoEngineerParmeter.Margin = new System.Windows.Forms.Padding(0);
            this.rdoEngineerParmeter.Name = "rdoEngineerParmeter";
            this.rdoEngineerParmeter.Size = new System.Drawing.Size(160, 60);
            this.rdoEngineerParmeter.TabIndex = 2;
            this.rdoEngineerParmeter.TabStop = true;
            this.rdoEngineerParmeter.Text = "ENGINEER\r\nPARAMETER";
            this.rdoEngineerParmeter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoEngineerParmeter.UseVisualStyleBackColor = false;
            this.rdoEngineerParmeter.CheckedChanged += new System.EventHandler(this.rdoParameterType_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnAkkonTest, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 792);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 78);
            this.tableLayoutPanel1.TabIndex = 294;
            // 
            // btnAkkonTest
            // 
            this.btnAkkonTest.BackColor = System.Drawing.Color.DarkGray;
            this.btnAkkonTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAkkonTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAkkonTest.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnAkkonTest.Location = new System.Drawing.Point(599, 0);
            this.btnAkkonTest.Margin = new System.Windows.Forms.Padding(0);
            this.btnAkkonTest.Name = "btnAkkonTest";
            this.btnAkkonTest.Size = new System.Drawing.Size(201, 78);
            this.btnAkkonTest.TabIndex = 291;
            this.btnAkkonTest.Text = "AKKON TEST";
            this.btnAkkonTest.UseVisualStyleBackColor = false;
            this.btnAkkonTest.Click += new System.EventHandler(this.btnAkkonTest_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.DarkGray;
            this.btnApply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnApply.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btnApply.Location = new System.Drawing.Point(0, 0);
            this.btnApply.Margin = new System.Windows.Forms.Padding(0);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(198, 78);
            this.btnApply.TabIndex = 198;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // rdoOption
            // 
            this.rdoOption.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoOption.BackColor = System.Drawing.Color.DarkGray;
            this.rdoOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoOption.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.rdoOption.Location = new System.Drawing.Point(640, 0);
            this.rdoOption.Margin = new System.Windows.Forms.Padding(0);
            this.rdoOption.Name = "rdoOption";
            this.rdoOption.Size = new System.Drawing.Size(160, 60);
            this.rdoOption.TabIndex = 1;
            this.rdoOption.TabStop = true;
            this.rdoOption.Text = "OPTION";
            this.rdoOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoOption.UseVisualStyleBackColor = false;
            this.rdoOption.CheckedChanged += new System.EventHandler(this.rdoParameterType_CheckedChanged);
            // 
            // pnlOption
            // 
            this.pnlOption.Controls.Add(this.tlpOption);
            this.pnlOption.Location = new System.Drawing.Point(274, 197);
            this.pnlOption.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(246, 166);
            this.pnlOption.TabIndex = 292;
            // 
            // tlpOption
            // 
            this.tlpOption.ColumnCount = 4;
            this.tlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOption.Controls.Add(this.lblDimple, 0, 2);
            this.tlpOption.Controls.Add(this.lblDimpleNGCount, 1, 1);
            this.tlpOption.Controls.Add(this.lblDimpleNGCountValue, 1, 2);
            this.tlpOption.Controls.Add(this.lblDimpleThreshold, 2, 1);
            this.tlpOption.Controls.Add(this.lblDimpleThresholdValue, 2, 2);
            this.tlpOption.Controls.Add(this.chkUseDimple, 3, 2);
            this.tlpOption.Controls.Add(this.lblAlarmNGCount, 2, 5);
            this.tlpOption.Controls.Add(this.lblAlarmCapacity, 1, 5);
            this.tlpOption.Controls.Add(this.lblAlarm, 0, 6);
            this.tlpOption.Controls.Add(this.lblAlarmNGCountValue, 2, 6);
            this.tlpOption.Controls.Add(this.lblAlarmCapacityValue, 1, 6);
            this.tlpOption.Controls.Add(this.chkUseAlarm, 3, 6);
            this.tlpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOption.Location = new System.Drawing.Point(0, 0);
            this.tlpOption.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOption.Name = "tlpOption";
            this.tlpOption.RowCount = 8;
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpOption.Size = new System.Drawing.Size(246, 166);
            this.tlpOption.TabIndex = 0;
            // 
            // chkUseAlarm
            // 
            this.chkUseAlarm.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUseAlarm.AutoSize = true;
            this.chkUseAlarm.BackColor = System.Drawing.Color.DarkGray;
            this.chkUseAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUseAlarm.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.chkUseAlarm.Location = new System.Drawing.Point(183, 120);
            this.chkUseAlarm.Margin = new System.Windows.Forms.Padding(0);
            this.chkUseAlarm.Name = "chkUseAlarm";
            this.chkUseAlarm.Size = new System.Drawing.Size(63, 20);
            this.chkUseAlarm.TabIndex = 47;
            this.chkUseAlarm.Text = "On";
            this.chkUseAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkUseAlarm.UseVisualStyleBackColor = false;
            this.chkUseAlarm.CheckedChanged += new System.EventHandler(this.chkUseAlarm_CheckedChanged);
            // 
            // CtrlTeachAkkon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpTeach);
            this.Name = "CtrlTeachAkkon";
            this.Size = new System.Drawing.Size(800, 900);
            this.Load += new System.EventHandler(this.CtrlTeachAkkon_Load);
            this.tlpTeach.ResumeLayout(false);
            this.tlpAkkonDataGridView.ResumeLayout(false);
            this.tabAkkonData.ResumeLayout(false);
            this.tpAkkonROI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkkonROI)).EndInit();
            this.tpAkkonResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAkkonResult)).EndInit();
            this.tlpAkkonDataShow.ResumeLayout(false);
            this.tlpSetParameter.ResumeLayout(false);
            this.pnlShowSelectParameter.ResumeLayout(false);
            this.pnlEngineerParameter.ResumeLayout(false);
            this.tlpParameter.ResumeLayout(false);
            this.pnlGroup.ResumeLayout(false);
            this.tlpGroup.ResumeLayout(false);
            this.tlpGroup.PerformLayout();
            this.tlpCloneROI.ResumeLayout(false);
            this.pnlMakerParameter.ResumeLayout(false);
            this.tlpMakerParameter.ResumeLayout(false);
            this.pnlSelectParameter.ResumeLayout(false);
            this.tlpSelectParameter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlOption.ResumeLayout(false);
            this.tlpOption.ResumeLayout(false);
            this.tlpOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTeach;
        private System.Windows.Forms.TableLayoutPanel tlpSetParameter;
        private System.Windows.Forms.TableLayoutPanel tlpSelectParameter;
        private System.Windows.Forms.RadioButton rdoGroup;
        private System.Windows.Forms.RadioButton rdoMakerParmeter;
        private System.Windows.Forms.RadioButton rdoEngineerParmeter;
        private System.Windows.Forms.Panel pnlSelectParameter;
        private System.Windows.Forms.DataGridView dgvAkkonROI;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_00;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_01;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_02;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_03;
        private System.Windows.Forms.DataGridViewTextBoxColumn COL_04;
        private System.Windows.Forms.DataGridView dgvAkkonResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TableLayoutPanel tlpAkkonDataGridView;
        private System.Windows.Forms.TabControl tabAkkonData;
        private System.Windows.Forms.TabPage tpAkkonROI;
        private System.Windows.Forms.TabPage tpAkkonResult;
        private System.Windows.Forms.TableLayoutPanel tlpAkkonDataShow;
        private System.Windows.Forms.RadioButton rdoAkkonResult;
        private System.Windows.Forms.RadioButton rdoAkkonROI;
        private System.Windows.Forms.Panel pnlGroup;
        private System.Windows.Forms.TableLayoutPanel tlpGroup;
        private System.Windows.Forms.Label lblGroupCount;
        private System.Windows.Forms.Label lblGroupCountValue;
        private System.Windows.Forms.ComboBox cmbGroupNumber;
        private System.Windows.Forms.Label lblGroupNumber;
        private System.Windows.Forms.Label lblROIWidth;
        private System.Windows.Forms.Label lblROIWidthValue;
        private System.Windows.Forms.Label lblROIHeight;
        private System.Windows.Forms.Label lblROIHeightValue;
        private System.Windows.Forms.Label lblLeadCount;
        private System.Windows.Forms.Label lblLeadCountValue;
        private System.Windows.Forms.Label lblLeadPitch;
        private System.Windows.Forms.Label lblLeadPitchValue;
        private System.Windows.Forms.Label lblFirstLead;
        private System.Windows.Forms.Button btnROICreate;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblCloneROI;
        private System.Windows.Forms.TableLayoutPanel tlpCloneROI;
        private System.Windows.Forms.RadioButton rdoCopyHorizontal;
        private System.Windows.Forms.RadioButton rdoCopyVertical;
        private System.Windows.Forms.Button btnCopyROI;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Panel pnlMakerParameter;
        private System.Windows.Forms.TableLayoutPanel tlpMakerParameter;
        private System.Windows.Forms.ComboBox cmbFilterDirection;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.ComboBox cmbStrengthBase;
        private System.Windows.Forms.ComboBox cmbTargetType;
        private System.Windows.Forms.ComboBox cmbPeakProperty;
        private System.Windows.Forms.ComboBox cmbPanelType;
        private System.Windows.Forms.ComboBox cmbShadowDirection;
        private System.Windows.Forms.Label lblInspectionType;
        private System.Windows.Forms.Label lblThresholdWeightValue;
        private System.Windows.Forms.Label lblPeakThreshold;
        private System.Windows.Forms.Label lblThresholdWeight;
        private System.Windows.Forms.Label lblFilterDirection;
        private System.Windows.Forms.Label lblFilterType;
        private System.Windows.Forms.Label lblTargetType;
        private System.Windows.Forms.Label lblPanelType;
        private System.Windows.Forms.Label lblShadowDirection;
        private System.Windows.Forms.Label lblPeakProperty;
        private System.Windows.Forms.Label lblStrengthBase;
        private System.Windows.Forms.Label lblLogTrace;
        private System.Windows.Forms.Label lblThresholdMode;
        private System.Windows.Forms.Label lblStrengthScaleFactor;
        private System.Windows.Forms.Label lblSliceOverlap;
        private System.Windows.Forms.Label lblPeakThresholdValue;
        private System.Windows.Forms.Label lblStrengthScaleFactorValue;
        private System.Windows.Forms.Label lblSliceOverlapValue;
        private System.Windows.Forms.Label lblStandardDeviationValue;
        private System.Windows.Forms.Label lblStandardDeviation;
        private System.Windows.Forms.ComboBox cmbInspectionType;
        private System.Windows.Forms.ComboBox cmbThresholdMode;
        private System.Windows.Forms.CheckBox chkLogTraceUseCheck;
        private System.Windows.Forms.Panel pnlEngineerParameter;
        private System.Windows.Forms.TableLayoutPanel tlpParameter;
        private System.Windows.Forms.Label lblStrengthFilterValue;
        private System.Windows.Forms.Label lblStrengthFilter;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblCountValue;
        private System.Windows.Forms.Label lblMinSizeFilter;
        private System.Windows.Forms.Label lblMaxSizeFilter;
        private System.Windows.Forms.Label lblGroupDistance;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblWidthCut;
        private System.Windows.Forms.Label lblHeightCut;
        private System.Windows.Forms.Label lblBWRatio;
        private System.Windows.Forms.Label lblExtraLeadDisplay;
        private System.Windows.Forms.Label lblMinSizeFilterValue;
        private System.Windows.Forms.Label lblMaxSizeFilterValue;
        private System.Windows.Forms.Label lblGroupDistanceValue;
        private System.Windows.Forms.Label lblLengthValue;
        private System.Windows.Forms.Label lblWidthCutValue;
        private System.Windows.Forms.Label lblHeightCutValue;
        private System.Windows.Forms.Label lblBWRatioValue;
        private System.Windows.Forms.Label lblExtraLeadDisplayValue;
        private System.Windows.Forms.RadioButton rdoBump;
        private System.Windows.Forms.Button btnAkkonTest;
        private System.Windows.Forms.Button btnROIShow;
        private System.Windows.Forms.Label lblDimple;
        private System.Windows.Forms.Label lblDimpleNGCountValue;
        private System.Windows.Forms.Label lblAlarm;
        private System.Windows.Forms.Label lblAlarmCapacity;
        private System.Windows.Forms.Label lblAlarmNGCount;
        private System.Windows.Forms.Label lblAlarmCapacityValue;
        private System.Windows.Forms.Label lblAlarmNGCountValue;
        private System.Windows.Forms.Label lblDimpleThresholdValue;
        private System.Windows.Forms.Label lblDimpleNGCount;
        private System.Windows.Forms.Label lblDimpleThreshold;
        private System.Windows.Forms.CheckBox chkUseDimple;
        private System.Windows.Forms.Panel pnlShowSelectParameter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdoOption;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.TableLayoutPanel tlpOption;
        private System.Windows.Forms.CheckBox chkUseAlarm;
    }
}
