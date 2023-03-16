namespace COG
{
    partial class FormVisionTeach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVisionTeach));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpVisionTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpDisplay = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAddtional = new System.Windows.Forms.Panel();
            this.cogDisplayThumbnail = new Cognex.VisionPro.CogRecordDisplay();
            this.tlpHistogram = new System.Windows.Forms.TableLayoutPanel();
            this.chkHistogram = new System.Windows.Forms.CheckBox();
            this.chartHistogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpFormFunction = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTeach = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTeachingItem = new System.Windows.Forms.TableLayoutPanel();
            this.chkShowROIJog = new System.Windows.Forms.CheckBox();
            this.tlpTeachFunction = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCommon = new System.Windows.Forms.TableLayoutPanel();
            this.tlpUnit = new System.Windows.Forms.TableLayoutPanel();
            this.btnMotionPopup = new System.Windows.Forms.Button();
            this.lblStageCam = new System.Windows.Forms.Label();
            this.tlpLoadImage = new System.Windows.Forms.TableLayoutPanel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnGrabStop = new System.Windows.Forms.Button();
            this.btnGrabStart = new System.Windows.Forms.Button();
            this.pnlTeach = new System.Windows.Forms.Panel();
            this.pnlTeachMark = new System.Windows.Forms.Panel();
            this.pnlTeachAlign = new System.Windows.Forms.Panel();
            this.pnlTeachAkkon = new System.Windows.Forms.Panel();
            this.pnlTeachParticle = new System.Windows.Forms.Panel();
            this.pnlTeachMeasure = new System.Windows.Forms.Panel();
            this.pnlTeachShort = new System.Windows.Forms.Panel();
            this.pnlTeachLineScan = new System.Windows.Forms.Panel();
            this.tlpBasicFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.JASDiplayControl = new JAS.Controls.Display.Display();
            this.tlpVisionTeach.SuspendLayout();
            this.tlpDisplay.SuspendLayout();
            this.pnlAddtional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayThumbnail)).BeginInit();
            this.tlpHistogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).BeginInit();
            this.tlpFormFunction.SuspendLayout();
            this.tlpTeach.SuspendLayout();
            this.tlpTeachFunction.SuspendLayout();
            this.tlpCommon.SuspendLayout();
            this.tlpUnit.SuspendLayout();
            this.tlpLoadImage.SuspendLayout();
            this.pnlTeach.SuspendLayout();
            this.tlpBasicFunction.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpVisionTeach
            // 
            this.tlpVisionTeach.ColumnCount = 2;
            this.tlpVisionTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVisionTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpVisionTeach.Controls.Add(this.tlpDisplay, 0, 0);
            this.tlpVisionTeach.Controls.Add(this.tlpFormFunction, 1, 0);
            this.tlpVisionTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpVisionTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpVisionTeach.Margin = new System.Windows.Forms.Padding(0);
            this.tlpVisionTeach.Name = "tlpVisionTeach";
            this.tlpVisionTeach.RowCount = 1;
            this.tlpVisionTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpVisionTeach.Size = new System.Drawing.Size(1080, 857);
            this.tlpVisionTeach.TabIndex = 0;
            // 
            // tlpDisplay
            // 
            this.tlpDisplay.ColumnCount = 1;
            this.tlpDisplay.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDisplay.Controls.Add(this.pnlAddtional, 0, 1);
            this.tlpDisplay.Controls.Add(this.JASDiplayControl, 0, 0);
            this.tlpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDisplay.Location = new System.Drawing.Point(0, 0);
            this.tlpDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDisplay.Name = "tlpDisplay";
            this.tlpDisplay.RowCount = 2;
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDisplay.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpDisplay.Size = new System.Drawing.Size(540, 857);
            this.tlpDisplay.TabIndex = 287;
            // 
            // pnlAddtional
            // 
            this.pnlAddtional.Controls.Add(this.cogDisplayThumbnail);
            this.pnlAddtional.Controls.Add(this.tlpHistogram);
            this.pnlAddtional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddtional.Location = new System.Drawing.Point(0, 685);
            this.pnlAddtional.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAddtional.Name = "pnlAddtional";
            this.pnlAddtional.Size = new System.Drawing.Size(540, 172);
            this.pnlAddtional.TabIndex = 0;
            // 
            // cogDisplayThumbnail
            // 
            this.cogDisplayThumbnail.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayThumbnail.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayThumbnail.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayThumbnail.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayThumbnail.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayThumbnail.DoubleTapZoomCycleLength = 2;
            this.cogDisplayThumbnail.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayThumbnail.Location = new System.Drawing.Point(9, 13);
            this.cogDisplayThumbnail.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayThumbnail.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayThumbnail.MouseWheelSensitivity = 1D;
            this.cogDisplayThumbnail.Name = "cogDisplayThumbnail";
            this.cogDisplayThumbnail.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayThumbnail.OcxState")));
            this.cogDisplayThumbnail.Size = new System.Drawing.Size(170, 115);
            this.cogDisplayThumbnail.TabIndex = 281;
            this.cogDisplayThumbnail.Visible = false;
            this.cogDisplayThumbnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cogDisplayThumbnail_MouseDown);
            this.cogDisplayThumbnail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cogDisplayThumbnail_MouseUp);
            this.cogDisplayThumbnail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cogDisplayThumbnail_MouseMove);
            // 
            // tlpHistogram
            // 
            this.tlpHistogram.ColumnCount = 2;
            this.tlpHistogram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpHistogram.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHistogram.Controls.Add(this.chkHistogram, 0, 0);
            this.tlpHistogram.Controls.Add(this.chartHistogram, 0, 0);
            this.tlpHistogram.Location = new System.Drawing.Point(220, 13);
            this.tlpHistogram.Margin = new System.Windows.Forms.Padding(0);
            this.tlpHistogram.Name = "tlpHistogram";
            this.tlpHistogram.RowCount = 1;
            this.tlpHistogram.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHistogram.Size = new System.Drawing.Size(231, 102);
            this.tlpHistogram.TabIndex = 282;
            this.tlpHistogram.Visible = false;
            // 
            // chkHistogram
            // 
            this.chkHistogram.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkHistogram.AutoSize = true;
            this.chkHistogram.BackColor = System.Drawing.Color.DarkGray;
            this.chkHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkHistogram.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.chkHistogram.Location = new System.Drawing.Point(187, 3);
            this.chkHistogram.Name = "chkHistogram";
            this.chkHistogram.Size = new System.Drawing.Size(41, 96);
            this.chkHistogram.TabIndex = 268;
            this.chkHistogram.Text = "HISTOGRAM";
            this.chkHistogram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkHistogram.UseVisualStyleBackColor = false;
            this.chkHistogram.CheckedChanged += new System.EventHandler(this.chkHistogram_CheckedChanged);
            // 
            // chartHistogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHistogram.ChartAreas.Add(chartArea1);
            this.chartHistogram.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartHistogram.Legends.Add(legend1);
            this.chartHistogram.Location = new System.Drawing.Point(3, 3);
            this.chartHistogram.Name = "chartHistogram";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartHistogram.Series.Add(series1);
            this.chartHistogram.Size = new System.Drawing.Size(178, 96);
            this.chartHistogram.TabIndex = 1;
            this.chartHistogram.Text = "chart1";
            // 
            // tlpFormFunction
            // 
            this.tlpFormFunction.ColumnCount = 1;
            this.tlpFormFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.Controls.Add(this.tlpTeach, 0, 0);
            this.tlpFormFunction.Controls.Add(this.tlpBasicFunction, 0, 1);
            this.tlpFormFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFormFunction.Location = new System.Drawing.Point(540, 0);
            this.tlpFormFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpFormFunction.Name = "tlpFormFunction";
            this.tlpFormFunction.RowCount = 2;
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFormFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpFormFunction.Size = new System.Drawing.Size(540, 857);
            this.tlpFormFunction.TabIndex = 2;
            // 
            // tlpTeach
            // 
            this.tlpTeach.ColumnCount = 2;
            this.tlpTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpTeach.Controls.Add(this.tlpTeachingItem, 1, 0);
            this.tlpTeach.Controls.Add(this.tlpTeachFunction, 0, 0);
            this.tlpTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeach.Location = new System.Drawing.Point(0, 0);
            this.tlpTeach.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeach.Name = "tlpTeach";
            this.tlpTeach.RowCount = 1;
            this.tlpTeach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeach.Size = new System.Drawing.Size(540, 717);
            this.tlpTeach.TabIndex = 3;
            // 
            // tlpTeachingItem
            // 
            this.tlpTeachingItem.ColumnCount = 1;
            this.tlpTeachingItem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachingItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachingItem.Location = new System.Drawing.Point(400, 0);
            this.tlpTeachingItem.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachingItem.Name = "tlpTeachingItem";
            this.tlpTeachingItem.RowCount = 1;
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 637F));
            this.tlpTeachingItem.Size = new System.Drawing.Size(140, 717);
            this.tlpTeachingItem.TabIndex = 0;
            // 
            // chkShowROIJog
            // 
            this.chkShowROIJog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShowROIJog.AutoSize = true;
            this.chkShowROIJog.BackColor = System.Drawing.Color.DarkGray;
            this.chkShowROIJog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkShowROIJog.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.chkShowROIJog.Location = new System.Drawing.Point(3, 3);
            this.chkShowROIJog.Name = "chkShowROIJog";
            this.chkShowROIJog.Size = new System.Drawing.Size(134, 134);
            this.chkShowROIJog.TabIndex = 204;
            this.chkShowROIJog.Text = "ROI JOG";
            this.chkShowROIJog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShowROIJog.UseVisualStyleBackColor = false;
            this.chkShowROIJog.CheckedChanged += new System.EventHandler(this.chkShowROIJog_CheckedChanged);
            // 
            // tlpTeachFunction
            // 
            this.tlpTeachFunction.ColumnCount = 1;
            this.tlpTeachFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTeachFunction.Controls.Add(this.tlpCommon, 0, 0);
            this.tlpTeachFunction.Controls.Add(this.pnlTeach, 0, 1);
            this.tlpTeachFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTeachFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpTeachFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTeachFunction.Name = "tlpTeachFunction";
            this.tlpTeachFunction.RowCount = 2;
            this.tlpTeachFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpTeachFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpTeachFunction.Size = new System.Drawing.Size(400, 717);
            this.tlpTeachFunction.TabIndex = 3;
            // 
            // tlpCommon
            // 
            this.tlpCommon.ColumnCount = 1;
            this.tlpCommon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCommon.Controls.Add(this.tlpUnit, 0, 0);
            this.tlpCommon.Controls.Add(this.tlpLoadImage, 0, 1);
            this.tlpCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCommon.Location = new System.Drawing.Point(0, 0);
            this.tlpCommon.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCommon.Name = "tlpCommon";
            this.tlpCommon.RowCount = 2;
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCommon.Size = new System.Drawing.Size(400, 71);
            this.tlpCommon.TabIndex = 2;
            // 
            // tlpUnit
            // 
            this.tlpUnit.ColumnCount = 2;
            this.tlpUnit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66F));
            this.tlpUnit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpUnit.Controls.Add(this.btnMotionPopup, 0, 0);
            this.tlpUnit.Controls.Add(this.lblStageCam, 0, 0);
            this.tlpUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUnit.Location = new System.Drawing.Point(0, 0);
            this.tlpUnit.Margin = new System.Windows.Forms.Padding(0);
            this.tlpUnit.Name = "tlpUnit";
            this.tlpUnit.RowCount = 1;
            this.tlpUnit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUnit.Size = new System.Drawing.Size(400, 35);
            this.tlpUnit.TabIndex = 287;
            // 
            // btnMotionPopup
            // 
            this.btnMotionPopup.BackColor = System.Drawing.Color.DarkGray;
            this.btnMotionPopup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMotionPopup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMotionPopup.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnMotionPopup.Location = new System.Drawing.Point(266, 0);
            this.btnMotionPopup.Margin = new System.Windows.Forms.Padding(0);
            this.btnMotionPopup.Name = "btnMotionPopup";
            this.btnMotionPopup.Size = new System.Drawing.Size(134, 35);
            this.btnMotionPopup.TabIndex = 295;
            this.btnMotionPopup.Text = "MOTION";
            this.btnMotionPopup.UseVisualStyleBackColor = false;
            this.btnMotionPopup.Click += new System.EventHandler(this.btnMotionPopup_Click);
            // 
            // lblStageCam
            // 
            this.lblStageCam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStageCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStageCam.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.lblStageCam.Location = new System.Drawing.Point(3, 3);
            this.lblStageCam.Margin = new System.Windows.Forms.Padding(3);
            this.lblStageCam.Name = "lblStageCam";
            this.lblStageCam.Size = new System.Drawing.Size(260, 29);
            this.lblStageCam.TabIndex = 294;
            this.lblStageCam.Text = "STAGE : / CAM :";
            this.lblStageCam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpLoadImage
            // 
            this.tlpLoadImage.ColumnCount = 3;
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpLoadImage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoadImage.Controls.Add(this.btnLoadImage, 0, 0);
            this.tlpLoadImage.Controls.Add(this.btnGrabStop, 0, 0);
            this.tlpLoadImage.Controls.Add(this.btnGrabStart, 0, 0);
            this.tlpLoadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoadImage.Location = new System.Drawing.Point(0, 35);
            this.tlpLoadImage.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLoadImage.Name = "tlpLoadImage";
            this.tlpLoadImage.RowCount = 1;
            this.tlpLoadImage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoadImage.Size = new System.Drawing.Size(400, 36);
            this.tlpLoadImage.TabIndex = 2;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.DarkGray;
            this.btnLoadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoadImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoadImage.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.Location = new System.Drawing.Point(266, 0);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(134, 36);
            this.btnLoadImage.TabIndex = 201;
            this.btnLoadImage.Text = "LOAD IMAGE";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnGrabStop
            // 
            this.btnGrabStop.BackColor = System.Drawing.Color.DarkGray;
            this.btnGrabStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStop.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrabStop.Location = new System.Drawing.Point(133, 0);
            this.btnGrabStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnGrabStop.Name = "btnGrabStop";
            this.btnGrabStop.Size = new System.Drawing.Size(133, 36);
            this.btnGrabStop.TabIndex = 200;
            this.btnGrabStop.Text = "GRAB STOP";
            this.btnGrabStop.UseVisualStyleBackColor = false;
            this.btnGrabStop.Click += new System.EventHandler(this.btnGrabStop_Click);
            // 
            // btnGrabStart
            // 
            this.btnGrabStart.BackColor = System.Drawing.Color.DarkGray;
            this.btnGrabStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrabStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStart.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnGrabStart.Location = new System.Drawing.Point(0, 0);
            this.btnGrabStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnGrabStart.Name = "btnGrabStart";
            this.btnGrabStart.Size = new System.Drawing.Size(133, 36);
            this.btnGrabStart.TabIndex = 199;
            this.btnGrabStart.Text = "GRAB START";
            this.btnGrabStart.UseVisualStyleBackColor = false;
            this.btnGrabStart.Click += new System.EventHandler(this.btnGrabStart_Click);
            // 
            // pnlTeach
            // 
            this.pnlTeach.Controls.Add(this.pnlTeachMark);
            this.pnlTeach.Controls.Add(this.pnlTeachAlign);
            this.pnlTeach.Controls.Add(this.pnlTeachAkkon);
            this.pnlTeach.Controls.Add(this.pnlTeachParticle);
            this.pnlTeach.Controls.Add(this.pnlTeachMeasure);
            this.pnlTeach.Controls.Add(this.pnlTeachShort);
            this.pnlTeach.Controls.Add(this.pnlTeachLineScan);
            this.pnlTeach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeach.Location = new System.Drawing.Point(0, 71);
            this.pnlTeach.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTeach.Name = "pnlTeach";
            this.pnlTeach.Size = new System.Drawing.Size(400, 646);
            this.pnlTeach.TabIndex = 0;
            // 
            // pnlTeachMark
            // 
            this.pnlTeachMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachMark.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachMark.Name = "pnlTeachMark";
            this.pnlTeachMark.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachMark.TabIndex = 0;
            // 
            // pnlTeachAlign
            // 
            this.pnlTeachAlign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachAlign.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachAlign.Name = "pnlTeachAlign";
            this.pnlTeachAlign.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachAlign.TabIndex = 1;
            // 
            // pnlTeachAkkon
            // 
            this.pnlTeachAkkon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachAkkon.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachAkkon.Name = "pnlTeachAkkon";
            this.pnlTeachAkkon.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachAkkon.TabIndex = 2;
            // 
            // pnlTeachParticle
            // 
            this.pnlTeachParticle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachParticle.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachParticle.Name = "pnlTeachParticle";
            this.pnlTeachParticle.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachParticle.TabIndex = 0;
            // 
            // pnlTeachMeasure
            // 
            this.pnlTeachMeasure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachMeasure.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachMeasure.Name = "pnlTeachMeasure";
            this.pnlTeachMeasure.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachMeasure.TabIndex = 0;
            // 
            // pnlTeachShort
            // 
            this.pnlTeachShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachShort.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachShort.Name = "pnlTeachShort";
            this.pnlTeachShort.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachShort.TabIndex = 1;
            // 
            // pnlTeachLineScan
            // 
            this.pnlTeachLineScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTeachLineScan.Location = new System.Drawing.Point(0, 0);
            this.pnlTeachLineScan.Name = "pnlTeachLineScan";
            this.pnlTeachLineScan.Size = new System.Drawing.Size(400, 646);
            this.pnlTeachLineScan.TabIndex = 3;
            // 
            // tlpBasicFunction
            // 
            this.tlpBasicFunction.ColumnCount = 4;
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlpBasicFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBasicFunction.Controls.Add(this.btnSave, 2, 0);
            this.tlpBasicFunction.Controls.Add(this.chkShowROIJog, 0, 0);
            this.tlpBasicFunction.Controls.Add(this.btnExit, 3, 0);
            this.tlpBasicFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBasicFunction.Location = new System.Drawing.Point(0, 717);
            this.tlpBasicFunction.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBasicFunction.Name = "tlpBasicFunction";
            this.tlpBasicFunction.RowCount = 1;
            this.tlpBasicFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBasicFunction.Size = new System.Drawing.Size(540, 140);
            this.tlpBasicFunction.TabIndex = 294;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGray;
            this.btnSave.BackgroundImage = global::COG.Properties.Resources.SAVE1;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(263, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 134);
            this.btnSave.TabIndex = 204;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkGray;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(403, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 134);
            this.btnExit.TabIndex = 291;
            this.btnExit.Text = "EXIT";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // JASDiplayControl
            // 
            this.JASDiplayControl.BackColor = System.Drawing.Color.DarkGray;
            this.JASDiplayControl.CustomCross = ((System.Drawing.PointF)(resources.GetObject("JASDiplayControl.CustomCross")));
            this.JASDiplayControl.DisplayManuConstants = ((JAS.Controls.Display.DisplayEnableConstants)((((((((((JAS.Controls.Display.DisplayEnableConstants.DisplayFit | JAS.Controls.Display.DisplayEnableConstants.Undo) 
            | JAS.Controls.Display.DisplayEnableConstants.Delete) 
            | JAS.Controls.Display.DisplayEnableConstants.TouchMove0) 
            | JAS.Controls.Display.DisplayEnableConstants.PointToPoint1) 
            | JAS.Controls.Display.DisplayEnableConstants.LineToLine2) 
            | JAS.Controls.Display.DisplayEnableConstants.Arc3Points) 
            | JAS.Controls.Display.DisplayEnableConstants.Square5) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossLine6) 
            | JAS.Controls.Display.DisplayEnableConstants.CrossCustom)));
            this.JASDiplayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JASDiplayControl.Image = null;
            this.JASDiplayControl.Location = new System.Drawing.Point(0, 0);
            this.JASDiplayControl.Margin = new System.Windows.Forms.Padding(0);
            this.JASDiplayControl.Name = "JASDiplayControl";
            this.JASDiplayControl.Resuloution = 1D;
            this.JASDiplayControl.Size = new System.Drawing.Size(540, 685);
            this.JASDiplayControl.TabIndex = 279;
            this.JASDiplayControl.UseCustomCross = false;
            // 
            // FormVisionTeach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1080, 857);
            this.ControlBox = false;
            this.Controls.Add(this.tlpVisionTeach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormVisionTeach";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormVisionTeach_Load);
            this.tlpVisionTeach.ResumeLayout(false);
            this.tlpDisplay.ResumeLayout(false);
            this.pnlAddtional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayThumbnail)).EndInit();
            this.tlpHistogram.ResumeLayout(false);
            this.tlpHistogram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistogram)).EndInit();
            this.tlpFormFunction.ResumeLayout(false);
            this.tlpTeach.ResumeLayout(false);
            this.tlpTeachFunction.ResumeLayout(false);
            this.tlpCommon.ResumeLayout(false);
            this.tlpUnit.ResumeLayout(false);
            this.tlpLoadImage.ResumeLayout(false);
            this.pnlTeach.ResumeLayout(false);
            this.tlpBasicFunction.ResumeLayout(false);
            this.tlpBasicFunction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpVisionTeach;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TableLayoutPanel tlpTeachingItem;
        private System.Windows.Forms.Panel pnlTeachAkkon;
        private System.Windows.Forms.Panel pnlTeachAlign;
        private System.Windows.Forms.Panel pnlTeachMark;
        private System.Windows.Forms.Panel pnlTeachLineScan;
        private System.Windows.Forms.Panel pnlTeachParticle;
        private System.Windows.Forms.Panel pnlTeachMeasure;
        private System.Windows.Forms.Panel pnlTeachShort;
        private System.Windows.Forms.TableLayoutPanel tlpFormFunction;
        private System.Windows.Forms.TableLayoutPanel tlpDisplay;
        public Cognex.VisionPro.CogRecordDisplay cogDisplayThumbnail;
        private System.Windows.Forms.TableLayoutPanel tlpCommon;
        private System.Windows.Forms.TableLayoutPanel tlpLoadImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnGrabStop;
        private System.Windows.Forms.Button btnGrabStart;
        public JAS.Controls.Display.Display JASDiplayControl;
        private System.Windows.Forms.Panel pnlAddtional;
        private System.Windows.Forms.TableLayoutPanel tlpHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistogram;
        private System.Windows.Forms.CheckBox chkHistogram;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlTeach;
        private System.Windows.Forms.TableLayoutPanel tlpUnit;
        private System.Windows.Forms.Button btnMotionPopup;
        private System.Windows.Forms.Label lblStageCam;
        public System.Windows.Forms.CheckBox chkShowROIJog;
        private System.Windows.Forms.TableLayoutPanel tlpBasicFunction;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpTeach;
        private System.Windows.Forms.TableLayoutPanel tlpTeachFunction;
    }
}