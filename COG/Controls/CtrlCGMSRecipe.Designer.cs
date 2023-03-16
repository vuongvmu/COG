namespace COG.Controls
{
    partial class CtrlCGMSRecipe
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
            this.tlpRecipe = new System.Windows.Forms.TableLayoutPanel();
            this.picSampleImage = new System.Windows.Forms.PictureBox();
            this.tlpRecipeData = new System.Windows.Forms.TableLayoutPanel();
            this.grpMaterialData = new System.Windows.Forms.GroupBox();
            this.tlpSampleDimension = new System.Windows.Forms.TableLayoutPanel();
            this.lblPatternToPatternDistanceYValue = new System.Windows.Forms.Label();
            this.lblPatternToPatternDistanceY = new System.Windows.Forms.Label();
            this.lblPatternSizeY = new System.Windows.Forms.Label();
            this.lblPatternToPatternDistanceXValue = new System.Windows.Forms.Label();
            this.lblMarkToPatternDistanceY = new System.Windows.Forms.Label();
            this.lblMarkToPatternDistanceYValue = new System.Windows.Forms.Label();
            this.lblPatternToPatternDistanceX = new System.Windows.Forms.Label();
            this.lblMarkToPatternDistanceXValue = new System.Windows.Forms.Label();
            this.lblPatternSizeYValue = new System.Windows.Forms.Label();
            this.lblMarkToPatternDistanceX = new System.Windows.Forms.Label();
            this.grpStandardValue = new System.Windows.Forms.GroupBox();
            this.lblAlignStandardValue = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.grpTolerance = new System.Windows.Forms.GroupBox();
            this.lblAlignToleranceX = new System.Windows.Forms.Label();
            this.lblAlignToleranceY = new System.Windows.Forms.Label();
            this.lblAlignToleranceCX = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpMaterialMatrix = new System.Windows.Forms.GroupBox();
            this.tlpMaterialMatrix = new System.Windows.Forms.TableLayoutPanel();
            this.lblScanRowCount = new System.Windows.Forms.Label();
            this.lblScanColumnCount = new System.Windows.Forms.Label();
            this.lblScanRow = new System.Windows.Forms.Label();
            this.lblScanColumn = new System.Windows.Forms.Label();
            this.tlpRecipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).BeginInit();
            this.tlpRecipeData.SuspendLayout();
            this.grpMaterialData.SuspendLayout();
            this.tlpSampleDimension.SuspendLayout();
            this.grpStandardValue.SuspendLayout();
            this.grpTolerance.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpMaterialMatrix.SuspendLayout();
            this.tlpMaterialMatrix.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRecipe
            // 
            this.tlpRecipe.BackColor = System.Drawing.Color.Silver;
            this.tlpRecipe.ColumnCount = 2;
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRecipe.Controls.Add(this.picSampleImage, 0, 0);
            this.tlpRecipe.Controls.Add(this.tlpRecipeData, 1, 0);
            this.tlpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipe.Location = new System.Drawing.Point(0, 0);
            this.tlpRecipe.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipe.Name = "tlpRecipe";
            this.tlpRecipe.RowCount = 1;
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipe.Size = new System.Drawing.Size(1024, 640);
            this.tlpRecipe.TabIndex = 45;
            // 
            // picSampleImage
            // 
            this.picSampleImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSampleImage.Image = global::COG.Properties.Resources.CGMS_Recipe;
            this.picSampleImage.Location = new System.Drawing.Point(3, 3);
            this.picSampleImage.Name = "picSampleImage";
            this.picSampleImage.Size = new System.Drawing.Size(403, 634);
            this.picSampleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSampleImage.TabIndex = 0;
            this.picSampleImage.TabStop = false;
            // 
            // tlpRecipeData
            // 
            this.tlpRecipeData.ColumnCount = 2;
            this.tlpRecipeData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRecipeData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpRecipeData.Controls.Add(this.grpMaterialData, 0, 0);
            this.tlpRecipeData.Controls.Add(this.grpStandardValue, 1, 1);
            this.tlpRecipeData.Controls.Add(this.grpTolerance, 0, 1);
            this.tlpRecipeData.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tlpRecipeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipeData.Location = new System.Drawing.Point(409, 0);
            this.tlpRecipeData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipeData.Name = "tlpRecipeData";
            this.tlpRecipeData.RowCount = 3;
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeData.Size = new System.Drawing.Size(615, 640);
            this.tlpRecipeData.TabIndex = 2;
            // 
            // grpMaterialData
            // 
            this.grpMaterialData.Controls.Add(this.tlpSampleDimension);
            this.grpMaterialData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialData.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpMaterialData.Location = new System.Drawing.Point(3, 3);
            this.grpMaterialData.Name = "grpMaterialData";
            this.grpMaterialData.Size = new System.Drawing.Size(363, 378);
            this.grpMaterialData.TabIndex = 40;
            this.grpMaterialData.TabStop = false;
            this.grpMaterialData.Text = "Material Data";
            // 
            // tlpSampleDimension
            // 
            this.tlpSampleDimension.ColumnCount = 2;
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpSampleDimension.Controls.Add(this.lblPatternToPatternDistanceYValue, 1, 4);
            this.tlpSampleDimension.Controls.Add(this.lblPatternToPatternDistanceY, 0, 4);
            this.tlpSampleDimension.Controls.Add(this.lblPatternSizeY, 0, 0);
            this.tlpSampleDimension.Controls.Add(this.lblPatternToPatternDistanceXValue, 1, 3);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToPatternDistanceY, 0, 2);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToPatternDistanceYValue, 1, 2);
            this.tlpSampleDimension.Controls.Add(this.lblPatternToPatternDistanceX, 0, 3);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToPatternDistanceXValue, 1, 1);
            this.tlpSampleDimension.Controls.Add(this.lblPatternSizeYValue, 1, 0);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToPatternDistanceX, 0, 1);
            this.tlpSampleDimension.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSampleDimension.Location = new System.Drawing.Point(3, 28);
            this.tlpSampleDimension.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSampleDimension.Name = "tlpSampleDimension";
            this.tlpSampleDimension.RowCount = 5;
            this.tlpSampleDimension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSampleDimension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSampleDimension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSampleDimension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSampleDimension.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpSampleDimension.Size = new System.Drawing.Size(357, 347);
            this.tlpSampleDimension.TabIndex = 38;
            // 
            // lblPatternToPatternDistanceYValue
            // 
            this.lblPatternToPatternDistanceYValue.BackColor = System.Drawing.Color.White;
            this.lblPatternToPatternDistanceYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternToPatternDistanceYValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternToPatternDistanceYValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPatternToPatternDistanceYValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPatternToPatternDistanceYValue.Location = new System.Drawing.Point(252, 282);
            this.lblPatternToPatternDistanceYValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternToPatternDistanceYValue.Name = "lblPatternToPatternDistanceYValue";
            this.lblPatternToPatternDistanceYValue.Size = new System.Drawing.Size(102, 59);
            this.lblPatternToPatternDistanceYValue.TabIndex = 39;
            this.lblPatternToPatternDistanceYValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatternToPatternDistanceYValue.Click += new System.EventHandler(this.lblPatternToPatternDistanceYValue_Click);
            // 
            // lblPatternToPatternDistanceY
            // 
            this.lblPatternToPatternDistanceY.AutoSize = true;
            this.lblPatternToPatternDistanceY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternToPatternDistanceY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternToPatternDistanceY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPatternToPatternDistanceY.Location = new System.Drawing.Point(3, 282);
            this.lblPatternToPatternDistanceY.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternToPatternDistanceY.Name = "lblPatternToPatternDistanceY";
            this.lblPatternToPatternDistanceY.Size = new System.Drawing.Size(243, 59);
            this.lblPatternToPatternDistanceY.TabIndex = 38;
            this.lblPatternToPatternDistanceY.Text = "E [mm]\r\nDistance Y between materials";
            this.lblPatternToPatternDistanceY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatternSizeY
            // 
            this.lblPatternSizeY.AutoSize = true;
            this.lblPatternSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternSizeY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPatternSizeY.Location = new System.Drawing.Point(3, 6);
            this.lblPatternSizeY.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternSizeY.Name = "lblPatternSizeY";
            this.lblPatternSizeY.Size = new System.Drawing.Size(243, 57);
            this.lblPatternSizeY.TabIndex = 1;
            this.lblPatternSizeY.Text = "A [mm]\r\nMaterial Height";
            this.lblPatternSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatternToPatternDistanceXValue
            // 
            this.lblPatternToPatternDistanceXValue.BackColor = System.Drawing.Color.White;
            this.lblPatternToPatternDistanceXValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternToPatternDistanceXValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternToPatternDistanceXValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPatternToPatternDistanceXValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPatternToPatternDistanceXValue.Location = new System.Drawing.Point(252, 213);
            this.lblPatternToPatternDistanceXValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternToPatternDistanceXValue.Name = "lblPatternToPatternDistanceXValue";
            this.lblPatternToPatternDistanceXValue.Size = new System.Drawing.Size(102, 57);
            this.lblPatternToPatternDistanceXValue.TabIndex = 37;
            this.lblPatternToPatternDistanceXValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatternToPatternDistanceXValue.Click += new System.EventHandler(this.lblPatternToPatternDistanceXValue_Click);
            // 
            // lblMarkToPatternDistanceY
            // 
            this.lblMarkToPatternDistanceY.AutoSize = true;
            this.lblMarkToPatternDistanceY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToPatternDistanceY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToPatternDistanceY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMarkToPatternDistanceY.Location = new System.Drawing.Point(3, 144);
            this.lblMarkToPatternDistanceY.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToPatternDistanceY.Name = "lblMarkToPatternDistanceY";
            this.lblMarkToPatternDistanceY.Size = new System.Drawing.Size(243, 57);
            this.lblMarkToPatternDistanceY.TabIndex = 3;
            this.lblMarkToPatternDistanceY.Text = "C [mm]\r\nMark to Pattern Distance Y";
            this.lblMarkToPatternDistanceY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkToPatternDistanceYValue
            // 
            this.lblMarkToPatternDistanceYValue.BackColor = System.Drawing.Color.White;
            this.lblMarkToPatternDistanceYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToPatternDistanceYValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToPatternDistanceYValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarkToPatternDistanceYValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkToPatternDistanceYValue.Location = new System.Drawing.Point(252, 144);
            this.lblMarkToPatternDistanceYValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToPatternDistanceYValue.Name = "lblMarkToPatternDistanceYValue";
            this.lblMarkToPatternDistanceYValue.Size = new System.Drawing.Size(102, 57);
            this.lblMarkToPatternDistanceYValue.TabIndex = 36;
            this.lblMarkToPatternDistanceYValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkToPatternDistanceYValue.Click += new System.EventHandler(this.lblMarkToPatternDistanceYValue_Click);
            // 
            // lblPatternToPatternDistanceX
            // 
            this.lblPatternToPatternDistanceX.AutoSize = true;
            this.lblPatternToPatternDistanceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternToPatternDistanceX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternToPatternDistanceX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPatternToPatternDistanceX.Location = new System.Drawing.Point(3, 213);
            this.lblPatternToPatternDistanceX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternToPatternDistanceX.Name = "lblPatternToPatternDistanceX";
            this.lblPatternToPatternDistanceX.Size = new System.Drawing.Size(243, 57);
            this.lblPatternToPatternDistanceX.TabIndex = 4;
            this.lblPatternToPatternDistanceX.Text = "D [mm]\r\nDistance Y between materials";
            this.lblPatternToPatternDistanceX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkToPatternDistanceXValue
            // 
            this.lblMarkToPatternDistanceXValue.BackColor = System.Drawing.Color.White;
            this.lblMarkToPatternDistanceXValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToPatternDistanceXValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToPatternDistanceXValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarkToPatternDistanceXValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkToPatternDistanceXValue.Location = new System.Drawing.Point(252, 75);
            this.lblMarkToPatternDistanceXValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToPatternDistanceXValue.Name = "lblMarkToPatternDistanceXValue";
            this.lblMarkToPatternDistanceXValue.Size = new System.Drawing.Size(102, 57);
            this.lblMarkToPatternDistanceXValue.TabIndex = 35;
            this.lblMarkToPatternDistanceXValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkToPatternDistanceXValue.Click += new System.EventHandler(this.lblMarkToPatternDistanceXValue_Click);
            // 
            // lblPatternSizeYValue
            // 
            this.lblPatternSizeYValue.BackColor = System.Drawing.Color.White;
            this.lblPatternSizeYValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPatternSizeYValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPatternSizeYValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPatternSizeYValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPatternSizeYValue.Location = new System.Drawing.Point(252, 6);
            this.lblPatternSizeYValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPatternSizeYValue.Name = "lblPatternSizeYValue";
            this.lblPatternSizeYValue.Size = new System.Drawing.Size(102, 57);
            this.lblPatternSizeYValue.TabIndex = 34;
            this.lblPatternSizeYValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPatternSizeYValue.Click += new System.EventHandler(this.lblPatternSizeYValue_Click);
            // 
            // lblMarkToPatternDistanceX
            // 
            this.lblMarkToPatternDistanceX.AutoSize = true;
            this.lblMarkToPatternDistanceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToPatternDistanceX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToPatternDistanceX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMarkToPatternDistanceX.Location = new System.Drawing.Point(3, 75);
            this.lblMarkToPatternDistanceX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToPatternDistanceX.Name = "lblMarkToPatternDistanceX";
            this.lblMarkToPatternDistanceX.Size = new System.Drawing.Size(243, 57);
            this.lblMarkToPatternDistanceX.TabIndex = 2;
            this.lblMarkToPatternDistanceX.Text = "B [mm]\r\nMark to Pattern Distance X";
            this.lblMarkToPatternDistanceX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpStandardValue
            // 
            this.grpStandardValue.Controls.Add(this.lblAlignStandardValue);
            this.grpStandardValue.Controls.Add(this.label67);
            this.grpStandardValue.Controls.Add(this.label66);
            this.grpStandardValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStandardValue.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpStandardValue.Location = new System.Drawing.Point(372, 387);
            this.grpStandardValue.Name = "grpStandardValue";
            this.grpStandardValue.Size = new System.Drawing.Size(240, 122);
            this.grpStandardValue.TabIndex = 43;
            this.grpStandardValue.TabStop = false;
            this.grpStandardValue.Text = "Standard Value";
            // 
            // lblAlignStandardValue
            // 
            this.lblAlignStandardValue.BackColor = System.Drawing.Color.White;
            this.lblAlignStandardValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlignStandardValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlignStandardValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAlignStandardValue.Location = new System.Drawing.Point(140, 54);
            this.lblAlignStandardValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblAlignStandardValue.Name = "lblAlignStandardValue";
            this.lblAlignStandardValue.Size = new System.Drawing.Size(73, 40);
            this.lblAlignStandardValue.TabIndex = 260;
            this.lblAlignStandardValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlignStandardValue.Click += new System.EventHandler(this.lblAlignStandardValue_Click);
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Silver;
            this.label67.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(149, 24);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(60, 30);
            this.label67.TabIndex = 261;
            this.label67.Text = "Y(um)";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Silver;
            this.label66.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label66.Location = new System.Drawing.Point(2, 55);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(134, 30);
            this.label66.TabIndex = 262;
            this.label66.Text = "Align Value";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpTolerance
            // 
            this.grpTolerance.Controls.Add(this.lblAlignToleranceX);
            this.grpTolerance.Controls.Add(this.lblAlignToleranceY);
            this.grpTolerance.Controls.Add(this.lblAlignToleranceCX);
            this.grpTolerance.Controls.Add(this.label60);
            this.grpTolerance.Controls.Add(this.label61);
            this.grpTolerance.Controls.Add(this.label62);
            this.grpTolerance.Controls.Add(this.label59);
            this.grpTolerance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpTolerance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpTolerance.ForeColor = System.Drawing.Color.Black;
            this.grpTolerance.Location = new System.Drawing.Point(3, 387);
            this.grpTolerance.Name = "grpTolerance";
            this.grpTolerance.Size = new System.Drawing.Size(363, 122);
            this.grpTolerance.TabIndex = 42;
            this.grpTolerance.TabStop = false;
            this.grpTolerance.Text = "Tolerance";
            // 
            // lblAlignToleranceX
            // 
            this.lblAlignToleranceX.BackColor = System.Drawing.Color.White;
            this.lblAlignToleranceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlignToleranceX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlignToleranceX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAlignToleranceX.Location = new System.Drawing.Point(137, 55);
            this.lblAlignToleranceX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblAlignToleranceX.Name = "lblAlignToleranceX";
            this.lblAlignToleranceX.Size = new System.Drawing.Size(73, 40);
            this.lblAlignToleranceX.TabIndex = 258;
            this.lblAlignToleranceX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlignToleranceX.Click += new System.EventHandler(this.lblAlignToleranceX_Click);
            // 
            // lblAlignToleranceY
            // 
            this.lblAlignToleranceY.BackColor = System.Drawing.Color.White;
            this.lblAlignToleranceY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlignToleranceY.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlignToleranceY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAlignToleranceY.Location = new System.Drawing.Point(213, 55);
            this.lblAlignToleranceY.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblAlignToleranceY.Name = "lblAlignToleranceY";
            this.lblAlignToleranceY.Size = new System.Drawing.Size(73, 40);
            this.lblAlignToleranceY.TabIndex = 257;
            this.lblAlignToleranceY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlignToleranceY.Click += new System.EventHandler(this.lblAlignToleranceY_Click);
            // 
            // lblAlignToleranceCX
            // 
            this.lblAlignToleranceCX.BackColor = System.Drawing.Color.White;
            this.lblAlignToleranceCX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlignToleranceCX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblAlignToleranceCX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAlignToleranceCX.Location = new System.Drawing.Point(289, 55);
            this.lblAlignToleranceCX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblAlignToleranceCX.Name = "lblAlignToleranceCX";
            this.lblAlignToleranceCX.Size = new System.Drawing.Size(73, 40);
            this.lblAlignToleranceCX.TabIndex = 256;
            this.lblAlignToleranceCX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAlignToleranceCX.Click += new System.EventHandler(this.lblAlignToleranceCX_Click);
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Silver;
            this.label60.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(295, 24);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(69, 30);
            this.label60.TabIndex = 255;
            this.label60.Text = "CX(um)";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label61
            // 
            this.label61.BackColor = System.Drawing.Color.Silver;
            this.label61.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(220, 25);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(57, 30);
            this.label61.TabIndex = 254;
            this.label61.Text = "Y(um)";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.Color.Silver;
            this.label62.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label62.ForeColor = System.Drawing.Color.Black;
            this.label62.Location = new System.Drawing.Point(148, 24);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(60, 30);
            this.label62.TabIndex = 253;
            this.label62.Text = "X(um)";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.Color.Silver;
            this.label59.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(5, 57);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(133, 30);
            this.label59.TabIndex = 252;
            this.label59.Text = "Align Tolerance";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grpMaterialMatrix, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(369, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(246, 384);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // grpMaterialMatrix
            // 
            this.grpMaterialMatrix.Controls.Add(this.tlpMaterialMatrix);
            this.grpMaterialMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialMatrix.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpMaterialMatrix.Location = new System.Drawing.Point(3, 3);
            this.grpMaterialMatrix.Name = "grpMaterialMatrix";
            this.grpMaterialMatrix.Size = new System.Drawing.Size(240, 166);
            this.grpMaterialMatrix.TabIndex = 41;
            this.grpMaterialMatrix.TabStop = false;
            this.grpMaterialMatrix.Text = "Material Matrix";
            // 
            // tlpMaterialMatrix
            // 
            this.tlpMaterialMatrix.ColumnCount = 2;
            this.tlpMaterialMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMaterialMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMaterialMatrix.Controls.Add(this.lblScanRowCount, 1, 0);
            this.tlpMaterialMatrix.Controls.Add(this.lblScanColumnCount, 1, 1);
            this.tlpMaterialMatrix.Controls.Add(this.lblScanRow, 0, 0);
            this.tlpMaterialMatrix.Controls.Add(this.lblScanColumn, 0, 1);
            this.tlpMaterialMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMaterialMatrix.Location = new System.Drawing.Point(3, 28);
            this.tlpMaterialMatrix.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMaterialMatrix.Name = "tlpMaterialMatrix";
            this.tlpMaterialMatrix.RowCount = 2;
            this.tlpMaterialMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMaterialMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMaterialMatrix.Size = new System.Drawing.Size(234, 135);
            this.tlpMaterialMatrix.TabIndex = 40;
            // 
            // lblScanRowCount
            // 
            this.lblScanRowCount.BackColor = System.Drawing.Color.White;
            this.lblScanRowCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanRowCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScanRowCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblScanRowCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScanRowCount.Location = new System.Drawing.Point(120, 6);
            this.lblScanRowCount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblScanRowCount.Name = "lblScanRowCount";
            this.lblScanRowCount.Size = new System.Drawing.Size(111, 55);
            this.lblScanRowCount.TabIndex = 38;
            this.lblScanRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanRowCount.Click += new System.EventHandler(this.lblScanRowCount_Click);
            // 
            // lblScanColumnCount
            // 
            this.lblScanColumnCount.BackColor = System.Drawing.Color.White;
            this.lblScanColumnCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanColumnCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScanColumnCount.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblScanColumnCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScanColumnCount.Location = new System.Drawing.Point(120, 73);
            this.lblScanColumnCount.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblScanColumnCount.Name = "lblScanColumnCount";
            this.lblScanColumnCount.Size = new System.Drawing.Size(111, 56);
            this.lblScanColumnCount.TabIndex = 40;
            this.lblScanColumnCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanColumnCount.Click += new System.EventHandler(this.lblScanColumnCount_Click);
            // 
            // lblScanRow
            // 
            this.lblScanRow.AutoSize = true;
            this.lblScanRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScanRow.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanRow.Location = new System.Drawing.Point(3, 6);
            this.lblScanRow.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblScanRow.Name = "lblScanRow";
            this.lblScanRow.Size = new System.Drawing.Size(111, 55);
            this.lblScanRow.TabIndex = 38;
            this.lblScanRow.Text = "Row";
            this.lblScanRow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScanColumn
            // 
            this.lblScanColumn.AutoSize = true;
            this.lblScanColumn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblScanColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScanColumn.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanColumn.Location = new System.Drawing.Point(3, 73);
            this.lblScanColumn.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblScanColumn.Name = "lblScanColumn";
            this.lblScanColumn.Size = new System.Drawing.Size(111, 56);
            this.lblScanColumn.TabIndex = 39;
            this.lblScanColumn.Text = "Column";
            this.lblScanColumn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlCGMSRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpRecipe);
            this.Name = "CtrlCGMSRecipe";
            this.Size = new System.Drawing.Size(1024, 640);
            this.Load += new System.EventHandler(this.CtrlCGMSRecipe_Load);
            this.tlpRecipe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).EndInit();
            this.tlpRecipeData.ResumeLayout(false);
            this.grpMaterialData.ResumeLayout(false);
            this.tlpSampleDimension.ResumeLayout(false);
            this.tlpSampleDimension.PerformLayout();
            this.grpStandardValue.ResumeLayout(false);
            this.grpTolerance.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpMaterialMatrix.ResumeLayout(false);
            this.tlpMaterialMatrix.ResumeLayout(false);
            this.tlpMaterialMatrix.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRecipe;
        private System.Windows.Forms.PictureBox picSampleImage;
        private System.Windows.Forms.TableLayoutPanel tlpRecipeData;
        private System.Windows.Forms.GroupBox grpMaterialData;
        private System.Windows.Forms.TableLayoutPanel tlpSampleDimension;
        private System.Windows.Forms.Label lblPatternToPatternDistanceYValue;
        private System.Windows.Forms.Label lblPatternToPatternDistanceY;
        private System.Windows.Forms.Label lblPatternSizeY;
        private System.Windows.Forms.Label lblPatternToPatternDistanceXValue;
        private System.Windows.Forms.Label lblMarkToPatternDistanceY;
        private System.Windows.Forms.Label lblMarkToPatternDistanceYValue;
        private System.Windows.Forms.Label lblPatternToPatternDistanceX;
        private System.Windows.Forms.Label lblMarkToPatternDistanceXValue;
        private System.Windows.Forms.Label lblPatternSizeYValue;
        private System.Windows.Forms.Label lblMarkToPatternDistanceX;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpMaterialMatrix;
        private System.Windows.Forms.TableLayoutPanel tlpMaterialMatrix;
        private System.Windows.Forms.Label lblScanRowCount;
        private System.Windows.Forms.Label lblScanColumnCount;
        private System.Windows.Forms.Label lblScanRow;
        private System.Windows.Forms.Label lblScanColumn;
        private System.Windows.Forms.GroupBox grpStandardValue;
        private System.Windows.Forms.Label lblAlignStandardValue;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.GroupBox grpTolerance;
        private System.Windows.Forms.Label lblAlignToleranceX;
        private System.Windows.Forms.Label lblAlignToleranceY;
        private System.Windows.Forms.Label lblAlignToleranceCX;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label59;
    }
}
