namespace COG.Controls
{
    partial class CtrlTeachROIJog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlTeachROIJog));
            this.pnlTeachJog = new System.Windows.Forms.Panel();
            this.tlpTeachJog = new System.Windows.Forms.TableLayoutPanel();
            this.pnlDirection = new System.Windows.Forms.Panel();
            this.pnlDirectionMove = new System.Windows.Forms.Panel();
            this.tlpDirectionMove = new System.Windows.Forms.TableLayoutPanel();
            this.lblMove = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.pnlDirectionSize = new System.Windows.Forms.Panel();
            this.tlpDirectionSize = new System.Windows.Forms.TableLayoutPanel();
            this.lblSize = new System.Windows.Forms.Label();
            this.btnSizeIncreaseUpDown = new System.Windows.Forms.Button();
            this.btnSizeDecreaseUpDown = new System.Windows.Forms.Button();
            this.btnSizeDecreaseLeftRight = new System.Windows.Forms.Button();
            this.btnSizeIncreaseLeftRight = new System.Windows.Forms.Button();
            this.pnlSelectJog = new System.Windows.Forms.Panel();
            this.tlpSelectJog = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMovePixel = new System.Windows.Forms.TableLayoutPanel();
            this.lblJogScale = new System.Windows.Forms.Label();
            this.lblMovePixel = new System.Windows.Forms.Label();
            this.tlpMoveSize = new System.Windows.Forms.TableLayoutPanel();
            this.rdoSize = new System.Windows.Forms.RadioButton();
            this.rdoMove = new System.Windows.Forms.RadioButton();
            this.tlpMarkOrigin = new System.Windows.Forms.TableLayoutPanel();
            this.rdoOrigin = new System.Windows.Forms.RadioButton();
            this.rdoMark = new System.Windows.Forms.RadioButton();
            this.pnlSkew = new System.Windows.Forms.Panel();
            this.tlpSkew = new System.Windows.Forms.TableLayoutPanel();
            this.btnSkewCW = new System.Windows.Forms.Button();
            this.btnSkewZero = new System.Windows.Forms.Button();
            this.btnSkewCCW = new System.Windows.Forms.Button();
            this.pnlTeachJog.SuspendLayout();
            this.tlpTeachJog.SuspendLayout();
            this.pnlDirection.SuspendLayout();
            this.pnlDirectionMove.SuspendLayout();
            this.tlpDirectionMove.SuspendLayout();
            this.pnlDirectionSize.SuspendLayout();
            this.tlpDirectionSize.SuspendLayout();
            this.pnlSelectJog.SuspendLayout();
            this.tlpSelectJog.SuspendLayout();
            this.tlpMovePixel.SuspendLayout();
            this.tlpMoveSize.SuspendLayout();
            this.tlpMarkOrigin.SuspendLayout();
            this.pnlSkew.SuspendLayout();
            this.tlpSkew.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTeachJog
            // 
            this.pnlTeachJog.Controls.Add(this.tlpTeachJog);
            this.pnlTeachJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachJog.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachJog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeachJog.Name = "pnlTeachJog";
            this.pnlTeachJog.Size = new System.Drawing.Size(505, 291);
            this.pnlTeachJog.TabIndex = 0;
            // 
            // tlpTeachJog
            // 
            this.tlpTeachJog.ColumnCount = 3;
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpTeachJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTeachJog.Controls.Add(this.pnlDirection, 1, 0);
            this.tlpTeachJog.Controls.Add(this.pnlSelectJog, 2, 0);
            this.tlpTeachJog.Controls.Add(this.pnlSkew, 0, 0);
            this.tlpTeachJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachJog.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachJog.Name = "tlpTeachJog";
            this.tlpTeachJog.RowCount = 1;
            this.tlpTeachJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachJog.Size = new System.Drawing.Size(505, 291);
            this.tlpTeachJog.TabIndex = 0;
            // 
            // pnlDirection
            // 
            this.pnlDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDirection.Controls.Add(this.pnlDirectionMove);
            this.pnlDirection.Controls.Add(this.pnlDirectionSize);
            this.pnlDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDirection.Location = new System.Drawing.Point(101, 0);
            this.pnlDirection.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDirection.Name = "pnlDirection";
            this.pnlDirection.Size = new System.Drawing.Size(303, 291);
            this.pnlDirection.TabIndex = 11;
            // 
            // pnlDirectionMove
            // 
            this.pnlDirectionMove.Controls.Add(this.tlpDirectionMove);
            this.pnlDirectionMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDirectionMove.Location = new System.Drawing.Point(0, 0);
            this.pnlDirectionMove.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDirectionMove.Name = "pnlDirectionMove";
            this.pnlDirectionMove.Size = new System.Drawing.Size(301, 289);
            this.pnlDirectionMove.TabIndex = 4;
            // 
            // tlpDirectionMove
            // 
            this.tlpDirectionMove.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpDirectionMove.ColumnCount = 3;
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.Controls.Add(this.lblMove, 1, 1);
            this.tlpDirectionMove.Controls.Add(this.btnMoveUp, 1, 0);
            this.tlpDirectionMove.Controls.Add(this.btnMoveDown, 1, 2);
            this.tlpDirectionMove.Controls.Add(this.btnMoveLeft, 0, 1);
            this.tlpDirectionMove.Controls.Add(this.btnMoveRight, 2, 1);
            this.tlpDirectionMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDirectionMove.Location = new System.Drawing.Point(0, 0);
            this.tlpDirectionMove.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDirectionMove.Name = "tlpDirectionMove";
            this.tlpDirectionMove.RowCount = 3;
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionMove.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDirectionMove.Size = new System.Drawing.Size(301, 289);
            this.tlpDirectionMove.TabIndex = 0;
            // 
            // lblMove
            // 
            this.lblMove.AutoSize = true;
            this.lblMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMove.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMove.Image = ((System.Drawing.Image)(resources.GetObject("lblMove.Image")));
            this.lblMove.Location = new System.Drawing.Point(102, 98);
            this.lblMove.Margin = new System.Windows.Forms.Padding(0);
            this.lblMove.Name = "lblMove";
            this.lblMove.Size = new System.Drawing.Size(96, 92);
            this.lblMove.TabIndex = 6;
            this.lblMove.Text = "MOVE";
            this.lblMove.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.BackColor = System.Drawing.Color.DarkGray;
            this.btnMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveUp.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUp.Image")));
            this.btnMoveUp.Location = new System.Drawing.Point(102, 3);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(96, 92);
            this.btnMoveUp.TabIndex = 7;
            this.btnMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveUp.UseVisualStyleBackColor = false;
            this.btnMoveUp.Click += new System.EventHandler(this.btnDirectionMove_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.BackColor = System.Drawing.Color.DarkGray;
            this.btnMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveDown.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDown.Image")));
            this.btnMoveDown.Location = new System.Drawing.Point(102, 193);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(96, 93);
            this.btnMoveDown.TabIndex = 8;
            this.btnMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveDown.UseVisualStyleBackColor = false;
            this.btnMoveDown.Click += new System.EventHandler(this.btnDirectionMove_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.BackColor = System.Drawing.Color.DarkGray;
            this.btnMoveLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveLeft.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveLeft.Image")));
            this.btnMoveLeft.Location = new System.Drawing.Point(3, 98);
            this.btnMoveLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(96, 92);
            this.btnMoveLeft.TabIndex = 9;
            this.btnMoveLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveLeft.UseVisualStyleBackColor = false;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnDirectionMove_Click);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.BackColor = System.Drawing.Color.DarkGray;
            this.btnMoveRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMoveRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMoveRight.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRight.Image")));
            this.btnMoveRight.Location = new System.Drawing.Point(201, 98);
            this.btnMoveRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(97, 92);
            this.btnMoveRight.TabIndex = 10;
            this.btnMoveRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMoveRight.UseVisualStyleBackColor = false;
            this.btnMoveRight.Click += new System.EventHandler(this.btnDirectionMove_Click);
            // 
            // pnlDirectionSize
            // 
            this.pnlDirectionSize.Controls.Add(this.tlpDirectionSize);
            this.pnlDirectionSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDirectionSize.Location = new System.Drawing.Point(0, 0);
            this.pnlDirectionSize.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDirectionSize.Name = "pnlDirectionSize";
            this.pnlDirectionSize.Size = new System.Drawing.Size(301, 289);
            this.pnlDirectionSize.TabIndex = 10;
            // 
            // tlpDirectionSize
            // 
            this.tlpDirectionSize.ColumnCount = 3;
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.Controls.Add(this.lblSize, 1, 1);
            this.tlpDirectionSize.Controls.Add(this.btnSizeIncreaseUpDown, 1, 0);
            this.tlpDirectionSize.Controls.Add(this.btnSizeDecreaseUpDown, 1, 2);
            this.tlpDirectionSize.Controls.Add(this.btnSizeDecreaseLeftRight, 0, 1);
            this.tlpDirectionSize.Controls.Add(this.btnSizeIncreaseLeftRight, 2, 1);
            this.tlpDirectionSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDirectionSize.Location = new System.Drawing.Point(0, 0);
            this.tlpDirectionSize.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDirectionSize.Name = "tlpDirectionSize";
            this.tlpDirectionSize.RowCount = 3;
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpDirectionSize.Size = new System.Drawing.Size(301, 289);
            this.tlpDirectionSize.TabIndex = 0;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSize.Image = ((System.Drawing.Image)(resources.GetObject("lblSize.Image")));
            this.lblSize.Location = new System.Drawing.Point(100, 96);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(100, 96);
            this.lblSize.TabIndex = 6;
            this.lblSize.Text = "SIZE";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // btnSizeIncreaseUpDown
            // 
            this.btnSizeIncreaseUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.btnSizeIncreaseUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSizeIncreaseUpDown.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSizeIncreaseUpDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeIncreaseUpDown.Image")));
            this.btnSizeIncreaseUpDown.Location = new System.Drawing.Point(100, 0);
            this.btnSizeIncreaseUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeIncreaseUpDown.Name = "btnSizeIncreaseUpDown";
            this.btnSizeIncreaseUpDown.Size = new System.Drawing.Size(100, 96);
            this.btnSizeIncreaseUpDown.TabIndex = 7;
            this.btnSizeIncreaseUpDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSizeIncreaseUpDown.UseVisualStyleBackColor = false;
            this.btnSizeIncreaseUpDown.Click += new System.EventHandler(this.btnDirectionSize_Click);
            // 
            // btnSizeDecreaseUpDown
            // 
            this.btnSizeDecreaseUpDown.BackColor = System.Drawing.Color.DarkGray;
            this.btnSizeDecreaseUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSizeDecreaseUpDown.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSizeDecreaseUpDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeDecreaseUpDown.Image")));
            this.btnSizeDecreaseUpDown.Location = new System.Drawing.Point(100, 192);
            this.btnSizeDecreaseUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeDecreaseUpDown.Name = "btnSizeDecreaseUpDown";
            this.btnSizeDecreaseUpDown.Size = new System.Drawing.Size(100, 97);
            this.btnSizeDecreaseUpDown.TabIndex = 8;
            this.btnSizeDecreaseUpDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSizeDecreaseUpDown.UseVisualStyleBackColor = false;
            this.btnSizeDecreaseUpDown.Click += new System.EventHandler(this.btnDirectionSize_Click);
            // 
            // btnSizeDecreaseLeftRight
            // 
            this.btnSizeDecreaseLeftRight.BackColor = System.Drawing.Color.DarkGray;
            this.btnSizeDecreaseLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSizeDecreaseLeftRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSizeDecreaseLeftRight.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeDecreaseLeftRight.Image")));
            this.btnSizeDecreaseLeftRight.Location = new System.Drawing.Point(0, 96);
            this.btnSizeDecreaseLeftRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeDecreaseLeftRight.Name = "btnSizeDecreaseLeftRight";
            this.btnSizeDecreaseLeftRight.Size = new System.Drawing.Size(100, 96);
            this.btnSizeDecreaseLeftRight.TabIndex = 9;
            this.btnSizeDecreaseLeftRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSizeDecreaseLeftRight.UseVisualStyleBackColor = false;
            this.btnSizeDecreaseLeftRight.Click += new System.EventHandler(this.btnDirectionSize_Click);
            // 
            // btnSizeIncreaseLeftRight
            // 
            this.btnSizeIncreaseLeftRight.BackColor = System.Drawing.Color.DarkGray;
            this.btnSizeIncreaseLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSizeIncreaseLeftRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSizeIncreaseLeftRight.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeIncreaseLeftRight.Image")));
            this.btnSizeIncreaseLeftRight.Location = new System.Drawing.Point(200, 96);
            this.btnSizeIncreaseLeftRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnSizeIncreaseLeftRight.Name = "btnSizeIncreaseLeftRight";
            this.btnSizeIncreaseLeftRight.Size = new System.Drawing.Size(101, 96);
            this.btnSizeIncreaseLeftRight.TabIndex = 10;
            this.btnSizeIncreaseLeftRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSizeIncreaseLeftRight.UseVisualStyleBackColor = false;
            this.btnSizeIncreaseLeftRight.Click += new System.EventHandler(this.btnDirectionSize_Click);
            // 
            // pnlSelectJog
            // 
            this.pnlSelectJog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelectJog.Controls.Add(this.tlpSelectJog);
            this.pnlSelectJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSelectJog.Location = new System.Drawing.Point(404, 0);
            this.pnlSelectJog.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSelectJog.Name = "pnlSelectJog";
            this.pnlSelectJog.Size = new System.Drawing.Size(101, 291);
            this.pnlSelectJog.TabIndex = 9;
            // 
            // tlpSelectJog
            // 
            this.tlpSelectJog.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpSelectJog.ColumnCount = 1;
            this.tlpSelectJog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSelectJog.Controls.Add(this.tlpMovePixel, 0, 1);
            this.tlpSelectJog.Controls.Add(this.tlpMoveSize, 0, 0);
            this.tlpSelectJog.Controls.Add(this.tlpMarkOrigin, 0, 2);
            this.tlpSelectJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSelectJog.Location = new System.Drawing.Point(0, 0);
            this.tlpSelectJog.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSelectJog.Name = "tlpSelectJog";
            this.tlpSelectJog.RowCount = 3;
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSelectJog.Size = new System.Drawing.Size(99, 289);
            this.tlpSelectJog.TabIndex = 1;
            // 
            // tlpMovePixel
            // 
            this.tlpMovePixel.ColumnCount = 1;
            this.tlpMovePixel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.Controls.Add(this.lblJogScale, 0, 1);
            this.tlpMovePixel.Controls.Add(this.lblMovePixel, 0, 0);
            this.tlpMovePixel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMovePixel.Location = new System.Drawing.Point(3, 98);
            this.tlpMovePixel.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMovePixel.Name = "tlpMovePixel";
            this.tlpMovePixel.RowCount = 2;
            this.tlpMovePixel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMovePixel.Size = new System.Drawing.Size(93, 92);
            this.tlpMovePixel.TabIndex = 8;
            // 
            // lblJogScale
            // 
            this.lblJogScale.AutoSize = true;
            this.lblJogScale.BackColor = System.Drawing.Color.White;
            this.lblJogScale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJogScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJogScale.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.lblJogScale.Location = new System.Drawing.Point(9, 55);
            this.lblJogScale.Margin = new System.Windows.Forms.Padding(9);
            this.lblJogScale.Name = "lblJogScale";
            this.lblJogScale.Size = new System.Drawing.Size(75, 28);
            this.lblJogScale.TabIndex = 8;
            this.lblJogScale.Text = "1";
            this.lblJogScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblJogScale.Click += new System.EventHandler(this.lblJogScale_Click);
            // 
            // lblMovePixel
            // 
            this.lblMovePixel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMovePixel.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMovePixel.Location = new System.Drawing.Point(0, 0);
            this.lblMovePixel.Margin = new System.Windows.Forms.Padding(0);
            this.lblMovePixel.Name = "lblMovePixel";
            this.lblMovePixel.Size = new System.Drawing.Size(93, 46);
            this.lblMovePixel.TabIndex = 7;
            this.lblMovePixel.Text = "Move Pixel";
            this.lblMovePixel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMoveSize
            // 
            this.tlpMoveSize.ColumnCount = 1;
            this.tlpMoveSize.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.Controls.Add(this.rdoSize, 0, 1);
            this.tlpMoveSize.Controls.Add(this.rdoMove, 0, 0);
            this.tlpMoveSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMoveSize.Location = new System.Drawing.Point(3, 3);
            this.tlpMoveSize.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMoveSize.Name = "tlpMoveSize";
            this.tlpMoveSize.RowCount = 2;
            this.tlpMoveSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMoveSize.Size = new System.Drawing.Size(93, 92);
            this.tlpMoveSize.TabIndex = 6;
            // 
            // rdoSize
            // 
            this.rdoSize.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoSize.BackColor = System.Drawing.Color.DarkGray;
            this.rdoSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoSize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoSize.Location = new System.Drawing.Point(0, 46);
            this.rdoSize.Margin = new System.Windows.Forms.Padding(0);
            this.rdoSize.Name = "rdoSize";
            this.rdoSize.Size = new System.Drawing.Size(93, 46);
            this.rdoSize.TabIndex = 6;
            this.rdoSize.TabStop = true;
            this.rdoSize.Text = "Size";
            this.rdoSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoSize.UseVisualStyleBackColor = false;
            this.rdoSize.CheckedChanged += new System.EventHandler(this.rdoSelectMoveSize_CheckedChanged);
            // 
            // rdoMove
            // 
            this.rdoMove.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMove.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMove.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoMove.Location = new System.Drawing.Point(0, 0);
            this.rdoMove.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMove.Name = "rdoMove";
            this.rdoMove.Size = new System.Drawing.Size(93, 46);
            this.rdoMove.TabIndex = 5;
            this.rdoMove.TabStop = true;
            this.rdoMove.Text = "Move";
            this.rdoMove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMove.UseVisualStyleBackColor = false;
            this.rdoMove.CheckedChanged += new System.EventHandler(this.rdoSelectMoveSize_CheckedChanged);
            // 
            // tlpMarkOrigin
            // 
            this.tlpMarkOrigin.ColumnCount = 1;
            this.tlpMarkOrigin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkOrigin.Controls.Add(this.rdoOrigin, 0, 1);
            this.tlpMarkOrigin.Controls.Add(this.rdoMark, 0, 0);
            this.tlpMarkOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMarkOrigin.Location = new System.Drawing.Point(3, 193);
            this.tlpMarkOrigin.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMarkOrigin.Name = "tlpMarkOrigin";
            this.tlpMarkOrigin.RowCount = 2;
            this.tlpMarkOrigin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkOrigin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMarkOrigin.Size = new System.Drawing.Size(93, 93);
            this.tlpMarkOrigin.TabIndex = 7;
            // 
            // rdoOrigin
            // 
            this.rdoOrigin.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoOrigin.BackColor = System.Drawing.Color.DarkGray;
            this.rdoOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoOrigin.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoOrigin.Location = new System.Drawing.Point(0, 46);
            this.rdoOrigin.Margin = new System.Windows.Forms.Padding(0);
            this.rdoOrigin.Name = "rdoOrigin";
            this.rdoOrigin.Size = new System.Drawing.Size(93, 47);
            this.rdoOrigin.TabIndex = 7;
            this.rdoOrigin.TabStop = true;
            this.rdoOrigin.Text = "Origin";
            this.rdoOrigin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoOrigin.UseVisualStyleBackColor = false;
            this.rdoOrigin.CheckedChanged += new System.EventHandler(this.rdoSelectMarkOrigin_CheckedChanged);
            // 
            // rdoMark
            // 
            this.rdoMark.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdoMark.BackColor = System.Drawing.Color.DarkGray;
            this.rdoMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdoMark.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoMark.Location = new System.Drawing.Point(0, 0);
            this.rdoMark.Margin = new System.Windows.Forms.Padding(0);
            this.rdoMark.Name = "rdoMark";
            this.rdoMark.Size = new System.Drawing.Size(93, 46);
            this.rdoMark.TabIndex = 6;
            this.rdoMark.TabStop = true;
            this.rdoMark.Text = "Mark";
            this.rdoMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rdoMark.UseVisualStyleBackColor = false;
            this.rdoMark.CheckedChanged += new System.EventHandler(this.rdoSelectMarkOrigin_CheckedChanged);
            // 
            // pnlSkew
            // 
            this.pnlSkew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSkew.Controls.Add(this.tlpSkew);
            this.pnlSkew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSkew.Location = new System.Drawing.Point(0, 0);
            this.pnlSkew.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSkew.Name = "pnlSkew";
            this.pnlSkew.Size = new System.Drawing.Size(101, 291);
            this.pnlSkew.TabIndex = 3;
            // 
            // tlpSkew
            // 
            this.tlpSkew.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tlpSkew.ColumnCount = 1;
            this.tlpSkew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSkew.Controls.Add(this.btnSkewCW, 0, 2);
            this.tlpSkew.Controls.Add(this.btnSkewZero, 0, 1);
            this.tlpSkew.Controls.Add(this.btnSkewCCW, 0, 0);
            this.tlpSkew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSkew.Location = new System.Drawing.Point(0, 0);
            this.tlpSkew.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSkew.Name = "tlpSkew";
            this.tlpSkew.RowCount = 3;
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpSkew.Size = new System.Drawing.Size(99, 289);
            this.tlpSkew.TabIndex = 0;
            // 
            // btnSkewCW
            // 
            this.btnSkewCW.BackColor = System.Drawing.Color.DarkGray;
            this.btnSkewCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSkewCW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSkewCW.Image = ((System.Drawing.Image)(resources.GetObject("btnSkewCW.Image")));
            this.btnSkewCW.Location = new System.Drawing.Point(3, 193);
            this.btnSkewCW.Margin = new System.Windows.Forms.Padding(0);
            this.btnSkewCW.Name = "btnSkewCW";
            this.btnSkewCW.Size = new System.Drawing.Size(93, 93);
            this.btnSkewCW.TabIndex = 5;
            this.btnSkewCW.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSkewCW.UseVisualStyleBackColor = false;
            this.btnSkewCW.Click += new System.EventHandler(this.btnSelectSkew_Click);
            // 
            // btnSkewZero
            // 
            this.btnSkewZero.BackColor = System.Drawing.Color.DarkGray;
            this.btnSkewZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSkewZero.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSkewZero.Image = ((System.Drawing.Image)(resources.GetObject("btnSkewZero.Image")));
            this.btnSkewZero.Location = new System.Drawing.Point(3, 98);
            this.btnSkewZero.Margin = new System.Windows.Forms.Padding(0);
            this.btnSkewZero.Name = "btnSkewZero";
            this.btnSkewZero.Size = new System.Drawing.Size(93, 92);
            this.btnSkewZero.TabIndex = 4;
            this.btnSkewZero.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSkewZero.UseVisualStyleBackColor = false;
            this.btnSkewZero.Click += new System.EventHandler(this.btnSelectSkew_Click);
            // 
            // btnSkewCCW
            // 
            this.btnSkewCCW.BackColor = System.Drawing.Color.DarkGray;
            this.btnSkewCCW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSkewCCW.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSkewCCW.Image = ((System.Drawing.Image)(resources.GetObject("btnSkewCCW.Image")));
            this.btnSkewCCW.Location = new System.Drawing.Point(3, 3);
            this.btnSkewCCW.Margin = new System.Windows.Forms.Padding(0);
            this.btnSkewCCW.Name = "btnSkewCCW";
            this.btnSkewCCW.Size = new System.Drawing.Size(93, 92);
            this.btnSkewCCW.TabIndex = 3;
            this.btnSkewCCW.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSkewCCW.UseVisualStyleBackColor = false;
            this.btnSkewCCW.Click += new System.EventHandler(this.btnSelectSkew_Click);
            // 
            // CtrlTeachROIJog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.pnlTeachJog);
            this.Name = "CtrlTeachROIJog";
            this.Size = new System.Drawing.Size(505, 291);
            this.Load += new System.EventHandler(this.CtrlTeachROIJog_Load);
            this.pnlTeachJog.ResumeLayout(false);
            this.tlpTeachJog.ResumeLayout(false);
            this.pnlDirection.ResumeLayout(false);
            this.pnlDirectionMove.ResumeLayout(false);
            this.tlpDirectionMove.ResumeLayout(false);
            this.tlpDirectionMove.PerformLayout();
            this.pnlDirectionSize.ResumeLayout(false);
            this.tlpDirectionSize.ResumeLayout(false);
            this.tlpDirectionSize.PerformLayout();
            this.pnlSelectJog.ResumeLayout(false);
            this.tlpSelectJog.ResumeLayout(false);
            this.tlpMovePixel.ResumeLayout(false);
            this.tlpMovePixel.PerformLayout();
            this.tlpMoveSize.ResumeLayout(false);
            this.tlpMarkOrigin.ResumeLayout(false);
            this.pnlSkew.ResumeLayout(false);
            this.tlpSkew.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTeachJog;
        private System.Windows.Forms.TableLayoutPanel tlpTeachJog;
        private System.Windows.Forms.TableLayoutPanel tlpSelectJog;
        private System.Windows.Forms.TableLayoutPanel tlpDirectionMove;
        private System.Windows.Forms.Label lblMove;
        private System.Windows.Forms.RadioButton rdoMove;
        private System.Windows.Forms.TableLayoutPanel tlpMoveSize;
        private System.Windows.Forms.RadioButton rdoSize;
        private System.Windows.Forms.TableLayoutPanel tlpMovePixel;
        private System.Windows.Forms.Label lblMovePixel;
        private System.Windows.Forms.Panel pnlDirectionSize;
        private System.Windows.Forms.TableLayoutPanel tlpDirectionSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Panel pnlSkew;
        private System.Windows.Forms.Panel pnlSelectJog;
        private System.Windows.Forms.Panel pnlDirectionMove;
        private System.Windows.Forms.Panel pnlDirection;
        private System.Windows.Forms.Button btnSkewCCW;
        private System.Windows.Forms.Button btnSkewCW;
        private System.Windows.Forms.Button btnSkewZero;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnSizeIncreaseUpDown;
        private System.Windows.Forms.Button btnSizeDecreaseUpDown;
        private System.Windows.Forms.Button btnSizeDecreaseLeftRight;
        private System.Windows.Forms.Button btnSizeIncreaseLeftRight;
        private System.Windows.Forms.Button btnMoveUp;
        public System.Windows.Forms.TableLayoutPanel tlpMarkOrigin;
        public System.Windows.Forms.TableLayoutPanel tlpSkew;
        public System.Windows.Forms.RadioButton rdoOrigin;
        public System.Windows.Forms.RadioButton rdoMark;
        public System.Windows.Forms.Label lblJogScale;
    }
}
