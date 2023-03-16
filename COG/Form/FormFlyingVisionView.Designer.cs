namespace COG
{
    partial class FormFlyingVisionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFlyingVisionView));
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay2 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay3 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay4 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay5 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay6 = new Cognex.VisionPro.Display.CogDisplay();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGrabStart = new System.Windows.Forms.Button();
            this.btnGrabStop = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpMain.Size = new System.Drawing.Size(1574, 724);
            this.tlpMain.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cogDisplay6, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1568, 672);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(3, 21);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(516, 312);
            this.cogDisplay1.TabIndex = 0;
            // 
            // cogDisplay2
            // 
            this.cogDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay2.DoubleTapZoomCycleLength = 2;
            this.cogDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay2.Location = new System.Drawing.Point(525, 21);
            this.cogDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay2.MouseWheelSensitivity = 1D;
            this.cogDisplay2.Name = "cogDisplay2";
            this.cogDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay2.OcxState")));
            this.cogDisplay2.Size = new System.Drawing.Size(516, 312);
            this.cogDisplay2.TabIndex = 1;
            // 
            // cogDisplay3
            // 
            this.cogDisplay3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay3.DoubleTapZoomCycleLength = 2;
            this.cogDisplay3.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay3.Location = new System.Drawing.Point(1047, 21);
            this.cogDisplay3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay3.MouseWheelSensitivity = 1D;
            this.cogDisplay3.Name = "cogDisplay3";
            this.cogDisplay3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay3.OcxState")));
            this.cogDisplay3.Size = new System.Drawing.Size(518, 312);
            this.cogDisplay3.TabIndex = 2;
            // 
            // cogDisplay4
            // 
            this.cogDisplay4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay4.DoubleTapZoomCycleLength = 2;
            this.cogDisplay4.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay4.Location = new System.Drawing.Point(3, 357);
            this.cogDisplay4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay4.MouseWheelSensitivity = 1D;
            this.cogDisplay4.Name = "cogDisplay4";
            this.cogDisplay4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay4.OcxState")));
            this.cogDisplay4.Size = new System.Drawing.Size(516, 312);
            this.cogDisplay4.TabIndex = 3;
            // 
            // cogDisplay5
            // 
            this.cogDisplay5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay5.DoubleTapZoomCycleLength = 2;
            this.cogDisplay5.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay5.Location = new System.Drawing.Point(525, 357);
            this.cogDisplay5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay5.MouseWheelSensitivity = 1D;
            this.cogDisplay5.Name = "cogDisplay5";
            this.cogDisplay5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay5.OcxState")));
            this.cogDisplay5.Size = new System.Drawing.Size(516, 312);
            this.cogDisplay5.TabIndex = 4;
            // 
            // cogDisplay6
            // 
            this.cogDisplay6.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay6.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay6.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisplay6.DoubleTapZoomCycleLength = 2;
            this.cogDisplay6.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay6.Location = new System.Drawing.Point(1047, 357);
            this.cogDisplay6.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay6.MouseWheelSensitivity = 1D;
            this.cogDisplay6.Name = "cogDisplay6";
            this.cogDisplay6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay6.OcxState")));
            this.cogDisplay6.Size = new System.Drawing.Size(518, 312);
            this.cogDisplay6.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel2.Controls.Add(this.btnGrabStart, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGrabStop, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 681);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1568, 40);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnGrabStart
            // 
            this.btnGrabStart.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGrabStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabStart.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGrabStart.Location = new System.Drawing.Point(1105, 3);
            this.btnGrabStart.Name = "btnGrabStart";
            this.btnGrabStart.Size = new System.Drawing.Size(227, 34);
            this.btnGrabStart.TabIndex = 104;
            this.btnGrabStart.Text = "Grab Start";
            this.btnGrabStart.UseVisualStyleBackColor = false;
            this.btnGrabStart.Click += new System.EventHandler(this.btnGrabStart_Click);
            // 
            // btnGrabStop
            // 
            this.btnGrabStop.BackColor = System.Drawing.Color.SkyBlue;
            this.btnGrabStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGrabStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabStop.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGrabStop.Location = new System.Drawing.Point(1338, 3);
            this.btnGrabStop.Name = "btnGrabStop";
            this.btnGrabStop.Size = new System.Drawing.Size(227, 34);
            this.btnGrabStop.TabIndex = 105;
            this.btnGrabStop.Text = "Grab Stop";
            this.btnGrabStop.UseVisualStyleBackColor = false;
            this.btnGrabStop.Click += new System.EventHandler(this.btnGrabStop_Click);
            // 
            // Form_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 724);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form_Test";
            this.Text = "FlyingVision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Test_FormClosed);
            this.Load += new System.EventHandler(this.Form_Test_Load);
            this.tlpMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay2;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay3;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay4;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay5;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnGrabStart;
        private System.Windows.Forms.Button btnGrabStop;
    }
}