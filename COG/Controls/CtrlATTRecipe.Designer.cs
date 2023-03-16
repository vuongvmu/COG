namespace COG.Controls
{
    partial class CtrlATTRecipe
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
            this.lblPanelSizeX = new System.Windows.Forms.Label();
            this.lblPanelToTabDistanceXValue = new System.Windows.Forms.Label();
            this.lblTabWidth = new System.Windows.Forms.Label();
            this.lblTabWidthValue = new System.Windows.Forms.Label();
            this.lblPanelToTabDistanceX = new System.Windows.Forms.Label();
            this.lblMarkToMarkDistanceXValue = new System.Windows.Forms.Label();
            this.lblPanelSizeXValue = new System.Windows.Forms.Label();
            this.lblMarkToMarkDistanceX = new System.Windows.Forms.Label();
            this.lblTab1Distance = new System.Windows.Forms.Label();
            this.lblTabDistance1 = new System.Windows.Forms.Label();
            this.lblTab2Distance = new System.Windows.Forms.Label();
            this.lblTab3Distance = new System.Windows.Forms.Label();
            this.lblTab4Distance = new System.Windows.Forms.Label();
            this.lblTab5Distance = new System.Windows.Forms.Label();
            this.lblTabDistance2 = new System.Windows.Forms.Label();
            this.lblTabDistance3 = new System.Windows.Forms.Label();
            this.lblTabDistance4 = new System.Windows.Forms.Label();
            this.lblTabDistance5 = new System.Windows.Forms.Label();
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
            this.tlpRecipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).BeginInit();
            this.tlpRecipeData.SuspendLayout();
            this.grpMaterialData.SuspendLayout();
            this.tlpSampleDimension.SuspendLayout();
            this.grpStandardValue.SuspendLayout();
            this.grpTolerance.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRecipe
            // 
            this.tlpRecipe.BackColor = System.Drawing.Color.Silver;
            this.tlpRecipe.ColumnCount = 2;
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
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
            this.picSampleImage.Image = global::COG.Properties.Resources.ATT_Recipe;
            this.picSampleImage.Location = new System.Drawing.Point(3, 3);
            this.picSampleImage.Name = "picSampleImage";
            this.picSampleImage.Size = new System.Drawing.Size(506, 634);
            this.picSampleImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSampleImage.TabIndex = 0;
            this.picSampleImage.TabStop = false;
            // 
            // tlpRecipeData
            // 
            this.tlpRecipeData.ColumnCount = 1;
            this.tlpRecipeData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipeData.Controls.Add(this.grpMaterialData, 0, 0);
            this.tlpRecipeData.Controls.Add(this.grpStandardValue, 0, 2);
            this.tlpRecipeData.Controls.Add(this.grpTolerance, 0, 1);
            this.tlpRecipeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipeData.Location = new System.Drawing.Point(512, 0);
            this.tlpRecipeData.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRecipeData.Name = "tlpRecipeData";
            this.tlpRecipeData.RowCount = 3;
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRecipeData.Size = new System.Drawing.Size(512, 640);
            this.tlpRecipeData.TabIndex = 2;
            // 
            // grpMaterialData
            // 
            this.grpMaterialData.Controls.Add(this.tlpSampleDimension);
            this.grpMaterialData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaterialData.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpMaterialData.Location = new System.Drawing.Point(3, 3);
            this.grpMaterialData.Name = "grpMaterialData";
            this.grpMaterialData.Size = new System.Drawing.Size(506, 378);
            this.grpMaterialData.TabIndex = 40;
            this.grpMaterialData.TabStop = false;
            this.grpMaterialData.Text = "Material Data";
            // 
            // tlpSampleDimension
            // 
            this.tlpSampleDimension.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpSampleDimension.ColumnCount = 4;
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpSampleDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSampleDimension.Controls.Add(this.lblPanelSizeX, 0, 0);
            this.tlpSampleDimension.Controls.Add(this.lblPanelToTabDistanceXValue, 1, 3);
            this.tlpSampleDimension.Controls.Add(this.lblTabWidth, 0, 2);
            this.tlpSampleDimension.Controls.Add(this.lblTabWidthValue, 1, 2);
            this.tlpSampleDimension.Controls.Add(this.lblPanelToTabDistanceX, 0, 3);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToMarkDistanceXValue, 1, 1);
            this.tlpSampleDimension.Controls.Add(this.lblPanelSizeXValue, 1, 0);
            this.tlpSampleDimension.Controls.Add(this.lblMarkToMarkDistanceX, 0, 1);
            this.tlpSampleDimension.Controls.Add(this.lblTab1Distance, 2, 0);
            this.tlpSampleDimension.Controls.Add(this.lblTabDistance1, 3, 0);
            this.tlpSampleDimension.Controls.Add(this.lblTab2Distance, 2, 1);
            this.tlpSampleDimension.Controls.Add(this.lblTab3Distance, 2, 2);
            this.tlpSampleDimension.Controls.Add(this.lblTab4Distance, 2, 3);
            this.tlpSampleDimension.Controls.Add(this.lblTab5Distance, 2, 4);
            this.tlpSampleDimension.Controls.Add(this.lblTabDistance2, 3, 1);
            this.tlpSampleDimension.Controls.Add(this.lblTabDistance3, 3, 2);
            this.tlpSampleDimension.Controls.Add(this.lblTabDistance4, 3, 3);
            this.tlpSampleDimension.Controls.Add(this.lblTabDistance5, 3, 4);
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
            this.tlpSampleDimension.Size = new System.Drawing.Size(500, 347);
            this.tlpSampleDimension.TabIndex = 38;
            // 
            // lblPanelSizeX
            // 
            this.lblPanelSizeX.AutoSize = true;
            this.lblPanelSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanelSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelSizeX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanelSizeX.Location = new System.Drawing.Point(5, 8);
            this.lblPanelSizeX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPanelSizeX.Name = "lblPanelSizeX";
            this.lblPanelSizeX.Size = new System.Drawing.Size(165, 55);
            this.lblPanelSizeX.TabIndex = 1;
            this.lblPanelSizeX.Text = "Panel X Size\r\n[mm]";
            this.lblPanelSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPanelToTabDistanceXValue
            // 
            this.lblPanelToTabDistanceXValue.BackColor = System.Drawing.Color.White;
            this.lblPanelToTabDistanceXValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanelToTabDistanceXValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelToTabDistanceXValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPanelToTabDistanceXValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPanelToTabDistanceXValue.Location = new System.Drawing.Point(178, 215);
            this.lblPanelToTabDistanceXValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPanelToTabDistanceXValue.Name = "lblPanelToTabDistanceXValue";
            this.lblPanelToTabDistanceXValue.Size = new System.Drawing.Size(67, 55);
            this.lblPanelToTabDistanceXValue.TabIndex = 37;
            this.lblPanelToTabDistanceXValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPanelToTabDistanceXValue.Click += new System.EventHandler(this.lblPanelToTabDistanceXValue_Click);
            // 
            // lblTabWidth
            // 
            this.lblTabWidth.AutoSize = true;
            this.lblTabWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabWidth.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTabWidth.Location = new System.Drawing.Point(5, 146);
            this.lblTabWidth.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabWidth.Name = "lblTabWidth";
            this.lblTabWidth.Size = new System.Drawing.Size(165, 55);
            this.lblTabWidth.TabIndex = 3;
            this.lblTabWidth.Text = "X0 [mm]\r\nTab Width";
            this.lblTabWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTabWidthValue
            // 
            this.lblTabWidthValue.BackColor = System.Drawing.Color.White;
            this.lblTabWidthValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabWidthValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabWidthValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabWidthValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabWidthValue.Location = new System.Drawing.Point(178, 146);
            this.lblTabWidthValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabWidthValue.Name = "lblTabWidthValue";
            this.lblTabWidthValue.Size = new System.Drawing.Size(67, 55);
            this.lblTabWidthValue.TabIndex = 36;
            this.lblTabWidthValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabWidthValue.Click += new System.EventHandler(this.lblTabWidthValue_Click);
            // 
            // lblPanelToTabDistanceX
            // 
            this.lblPanelToTabDistanceX.AutoSize = true;
            this.lblPanelToTabDistanceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanelToTabDistanceX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelToTabDistanceX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanelToTabDistanceX.Location = new System.Drawing.Point(5, 215);
            this.lblPanelToTabDistanceX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPanelToTabDistanceX.Name = "lblPanelToTabDistanceX";
            this.lblPanelToTabDistanceX.Size = new System.Drawing.Size(165, 55);
            this.lblPanelToTabDistanceX.TabIndex = 4;
            this.lblPanelToTabDistanceX.Text = "X1 [mm]\r\nPanel Edge to First Tab Distance";
            this.lblPanelToTabDistanceX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMarkToMarkDistanceXValue
            // 
            this.lblMarkToMarkDistanceXValue.BackColor = System.Drawing.Color.White;
            this.lblMarkToMarkDistanceXValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToMarkDistanceXValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToMarkDistanceXValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblMarkToMarkDistanceXValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMarkToMarkDistanceXValue.Location = new System.Drawing.Point(178, 77);
            this.lblMarkToMarkDistanceXValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToMarkDistanceXValue.Name = "lblMarkToMarkDistanceXValue";
            this.lblMarkToMarkDistanceXValue.Size = new System.Drawing.Size(67, 55);
            this.lblMarkToMarkDistanceXValue.TabIndex = 35;
            this.lblMarkToMarkDistanceXValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMarkToMarkDistanceXValue.Click += new System.EventHandler(this.lblMarkToMarkDistanceXValue_Click);
            // 
            // lblPanelSizeXValue
            // 
            this.lblPanelSizeXValue.BackColor = System.Drawing.Color.White;
            this.lblPanelSizeXValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPanelSizeXValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelSizeXValue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblPanelSizeXValue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPanelSizeXValue.Location = new System.Drawing.Point(178, 8);
            this.lblPanelSizeXValue.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblPanelSizeXValue.Name = "lblPanelSizeXValue";
            this.lblPanelSizeXValue.Size = new System.Drawing.Size(67, 55);
            this.lblPanelSizeXValue.TabIndex = 34;
            this.lblPanelSizeXValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPanelSizeXValue.Click += new System.EventHandler(this.lblPanelSizeXValue_Click);
            // 
            // lblMarkToMarkDistanceX
            // 
            this.lblMarkToMarkDistanceX.AutoSize = true;
            this.lblMarkToMarkDistanceX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMarkToMarkDistanceX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMarkToMarkDistanceX.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMarkToMarkDistanceX.Location = new System.Drawing.Point(5, 77);
            this.lblMarkToMarkDistanceX.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblMarkToMarkDistanceX.Name = "lblMarkToMarkDistanceX";
            this.lblMarkToMarkDistanceX.Size = new System.Drawing.Size(165, 55);
            this.lblMarkToMarkDistanceX.TabIndex = 2;
            this.lblMarkToMarkDistanceX.Text = "Mark To Mark Distance\r\n[mm]\r\n";
            this.lblMarkToMarkDistanceX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTab1Distance
            // 
            this.lblTab1Distance.AutoSize = true;
            this.lblTab1Distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTab1Distance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab1Distance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTab1Distance.Location = new System.Drawing.Point(253, 8);
            this.lblTab1Distance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTab1Distance.Name = "lblTab1Distance";
            this.lblTab1Distance.Size = new System.Drawing.Size(165, 55);
            this.lblTab1Distance.TabIndex = 38;
            this.lblTab1Distance.Text = "X2(1) [mm]\r\nTab To Tab Distance";
            this.lblTab1Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTabDistance1
            // 
            this.lblTabDistance1.BackColor = System.Drawing.Color.White;
            this.lblTabDistance1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabDistance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabDistance1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabDistance1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabDistance1.Location = new System.Drawing.Point(426, 8);
            this.lblTabDistance1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabDistance1.Name = "lblTabDistance1";
            this.lblTabDistance1.Size = new System.Drawing.Size(69, 55);
            this.lblTabDistance1.TabIndex = 39;
            this.lblTabDistance1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabDistance1.Click += new System.EventHandler(this.lblTabDistance1_Click);
            // 
            // lblTab2Distance
            // 
            this.lblTab2Distance.AutoSize = true;
            this.lblTab2Distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTab2Distance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab2Distance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTab2Distance.Location = new System.Drawing.Point(253, 77);
            this.lblTab2Distance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTab2Distance.Name = "lblTab2Distance";
            this.lblTab2Distance.Size = new System.Drawing.Size(165, 55);
            this.lblTab2Distance.TabIndex = 38;
            this.lblTab2Distance.Text = "X2(2) [mm]\r\nTab To Tab Distance";
            this.lblTab2Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTab3Distance
            // 
            this.lblTab3Distance.AutoSize = true;
            this.lblTab3Distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTab3Distance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab3Distance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTab3Distance.Location = new System.Drawing.Point(253, 146);
            this.lblTab3Distance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTab3Distance.Name = "lblTab3Distance";
            this.lblTab3Distance.Size = new System.Drawing.Size(165, 55);
            this.lblTab3Distance.TabIndex = 38;
            this.lblTab3Distance.Text = "X2(3) [mm]\r\nTab To Tab Distance";
            this.lblTab3Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTab4Distance
            // 
            this.lblTab4Distance.AutoSize = true;
            this.lblTab4Distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTab4Distance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab4Distance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTab4Distance.Location = new System.Drawing.Point(253, 215);
            this.lblTab4Distance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTab4Distance.Name = "lblTab4Distance";
            this.lblTab4Distance.Size = new System.Drawing.Size(165, 55);
            this.lblTab4Distance.TabIndex = 38;
            this.lblTab4Distance.Text = "X2(4) [mm]\r\nTab To Tab Distance";
            this.lblTab4Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTab5Distance
            // 
            this.lblTab5Distance.AutoSize = true;
            this.lblTab5Distance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTab5Distance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTab5Distance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTab5Distance.Location = new System.Drawing.Point(253, 284);
            this.lblTab5Distance.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTab5Distance.Name = "lblTab5Distance";
            this.lblTab5Distance.Size = new System.Drawing.Size(165, 55);
            this.lblTab5Distance.TabIndex = 38;
            this.lblTab5Distance.Text = "X2(5) [mm]\r\nTab To Tab Distance";
            this.lblTab5Distance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTabDistance2
            // 
            this.lblTabDistance2.BackColor = System.Drawing.Color.White;
            this.lblTabDistance2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabDistance2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabDistance2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabDistance2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabDistance2.Location = new System.Drawing.Point(426, 77);
            this.lblTabDistance2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabDistance2.Name = "lblTabDistance2";
            this.lblTabDistance2.Size = new System.Drawing.Size(69, 55);
            this.lblTabDistance2.TabIndex = 39;
            this.lblTabDistance2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabDistance2.Click += new System.EventHandler(this.lblTabDistance2_Click);
            // 
            // lblTabDistance3
            // 
            this.lblTabDistance3.BackColor = System.Drawing.Color.White;
            this.lblTabDistance3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabDistance3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabDistance3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabDistance3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabDistance3.Location = new System.Drawing.Point(426, 146);
            this.lblTabDistance3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabDistance3.Name = "lblTabDistance3";
            this.lblTabDistance3.Size = new System.Drawing.Size(69, 55);
            this.lblTabDistance3.TabIndex = 39;
            this.lblTabDistance3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabDistance3.Click += new System.EventHandler(this.lblTabDistance3_Click);
            // 
            // lblTabDistance4
            // 
            this.lblTabDistance4.BackColor = System.Drawing.Color.White;
            this.lblTabDistance4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabDistance4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabDistance4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabDistance4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabDistance4.Location = new System.Drawing.Point(426, 215);
            this.lblTabDistance4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabDistance4.Name = "lblTabDistance4";
            this.lblTabDistance4.Size = new System.Drawing.Size(69, 55);
            this.lblTabDistance4.TabIndex = 39;
            this.lblTabDistance4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabDistance4.Click += new System.EventHandler(this.lblTabDistance4_Click);
            // 
            // lblTabDistance5
            // 
            this.lblTabDistance5.BackColor = System.Drawing.Color.White;
            this.lblTabDistance5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTabDistance5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTabDistance5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblTabDistance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTabDistance5.Location = new System.Drawing.Point(426, 284);
            this.lblTabDistance5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblTabDistance5.Name = "lblTabDistance5";
            this.lblTabDistance5.Size = new System.Drawing.Size(69, 55);
            this.lblTabDistance5.TabIndex = 39;
            this.lblTabDistance5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTabDistance5.Click += new System.EventHandler(this.lblTabDistance5_Click);
            // 
            // grpStandardValue
            // 
            this.grpStandardValue.Controls.Add(this.lblAlignStandardValue);
            this.grpStandardValue.Controls.Add(this.label67);
            this.grpStandardValue.Controls.Add(this.label66);
            this.grpStandardValue.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpStandardValue.Location = new System.Drawing.Point(3, 515);
            this.grpStandardValue.Name = "grpStandardValue";
            this.grpStandardValue.Size = new System.Drawing.Size(224, 102);
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
            this.lblAlignStandardValue.Location = new System.Drawing.Point(140, 46);
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
            this.label67.Location = new System.Drawing.Point(149, 16);
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
            this.label66.Location = new System.Drawing.Point(2, 47);
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
            this.grpTolerance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.grpTolerance.ForeColor = System.Drawing.Color.Black;
            this.grpTolerance.Location = new System.Drawing.Point(3, 387);
            this.grpTolerance.Name = "grpTolerance";
            this.grpTolerance.Size = new System.Drawing.Size(383, 102);
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
            this.lblAlignToleranceX.Location = new System.Drawing.Point(138, 49);
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
            this.lblAlignToleranceY.Location = new System.Drawing.Point(214, 49);
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
            this.lblAlignToleranceCX.Location = new System.Drawing.Point(290, 49);
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
            this.label60.Location = new System.Drawing.Point(296, 18);
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
            this.label61.Location = new System.Drawing.Point(221, 19);
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
            this.label62.Location = new System.Drawing.Point(149, 18);
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
            this.label59.Location = new System.Drawing.Point(6, 51);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(133, 30);
            this.label59.TabIndex = 252;
            this.label59.Text = "Align Tolerance";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlATTRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.tlpRecipe);
            this.Name = "CtrlATTRecipe";
            this.Size = new System.Drawing.Size(1024, 640);
            this.Load += new System.EventHandler(this.CtrlATTRecipe_Load);
            this.tlpRecipe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSampleImage)).EndInit();
            this.tlpRecipeData.ResumeLayout(false);
            this.grpMaterialData.ResumeLayout(false);
            this.tlpSampleDimension.ResumeLayout(false);
            this.tlpSampleDimension.PerformLayout();
            this.grpStandardValue.ResumeLayout(false);
            this.grpTolerance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRecipe;
        private System.Windows.Forms.PictureBox picSampleImage;
        private System.Windows.Forms.TableLayoutPanel tlpRecipeData;
        private System.Windows.Forms.GroupBox grpMaterialData;
        private System.Windows.Forms.TableLayoutPanel tlpSampleDimension;
        private System.Windows.Forms.Label lblPanelSizeX;
        private System.Windows.Forms.Label lblPanelToTabDistanceXValue;
        private System.Windows.Forms.Label lblTabWidth;
        private System.Windows.Forms.Label lblTabWidthValue;
        private System.Windows.Forms.Label lblPanelToTabDistanceX;
        private System.Windows.Forms.Label lblMarkToMarkDistanceXValue;
        private System.Windows.Forms.Label lblPanelSizeXValue;
        private System.Windows.Forms.Label lblMarkToMarkDistanceX;
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
        private System.Windows.Forms.Label lblTab1Distance;
        private System.Windows.Forms.Label lblTabDistance1;
        private System.Windows.Forms.Label lblTab2Distance;
        private System.Windows.Forms.Label lblTab3Distance;
        private System.Windows.Forms.Label lblTab4Distance;
        private System.Windows.Forms.Label lblTab5Distance;
        private System.Windows.Forms.Label lblTabDistance2;
        private System.Windows.Forms.Label lblTabDistance3;
        private System.Windows.Forms.Label lblTabDistance4;
        private System.Windows.Forms.Label lblTabDistance5;
    }
}
