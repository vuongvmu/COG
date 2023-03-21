using COG.Class;
using COG.Class.MOTION;
using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormSystem : Form
    {
        public Action CloseEventDelegate;

        public CtrlInspectionItem InspecionItemControl = null;
        public List<CtrlInspectionItem> InspectionItemControlList = new List<CtrlInspectionItem>();

        public FormSystem()
        {
            InitializeComponent();
        }

        private void FormSetup_Load(object sender, EventArgs e)
        {
            InitalizeUI();
            UpdateUI();
            LoadSettings();
        }

        private void InitalizeUI()
        {
            MakeTeachingItemListControl();
            MakeAutoRunListControl();

#if CGMS
            pnlATTOption.Visible = false;
#endif
#if ATT
            pnlATTOption.Visible = true;
#endif
            // Save Image Extension
            foreach (eImageExtension extension in Enum.GetValues(typeof(eImageExtension)))
            {
                cmbSaveOKImageExtension.Items.Add(extension.ToString());
                cmbSaveNGImageExtension.Items.Add(extension.ToString());
            }
        }

        #region Make Inspection Item
        private void MakeTeachingItemListControl()
        {
            tlpInspectionItemList.RowStyles.Clear();
            tlpInspectionItemList.ColumnStyles.Clear();

            tlpInspectionItemList.RowCount = 1;
            // PJH_20230210_AF 제거_S
            //tlpInspectionItemList.ColumnCount = Enum.GetValues(typeof(eTeachingItem)).Length;
            tlpInspectionItemList.ColumnCount = Enum.GetValues(typeof(eTeachingItem)).Length - 1;
            // PJH_20230210_AF 제거_E

            for (int rowIndex = 0; rowIndex < tlpInspectionItemList.RowCount; rowIndex++)
                tlpInspectionItemList.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlpInspectionItemList.RowCount)));

            for (int columnIndex = 0; columnIndex < tlpInspectionItemList.ColumnCount; columnIndex++)
                tlpInspectionItemList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / tlpInspectionItemList.ColumnCount)));

            foreach (eTeachingItem inspectionItem in Enum.GetValues(typeof(eTeachingItem)))
            {
                switch (inspectionItem)
                {
                    //case eTeachingItem.AutoFocus:
                    //    // PJH_20230210_AF 제거_S
                    //    InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                    //    InspectionItemControlList.Add(InspecionItemControl);
                    //    InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                    //    this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem, 0);
                    //    InspecionItemControl.Dock = DockStyle.Fill;
                    //    // PJH_20230210_AF 제거_E
                    //    break;

                    case eTeachingItem.Mark:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);
                        break;

#if ATT
                    case eTeachingItem.Align:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);

                        //lbl.Text = inspectionItem.ToString();
                        //this.tlpAutoRunOptionData.Controls.Add(lbl, (int)inspectionItem - 1, 0);
                        break;

                    case eTeachingItem.Akkon:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);

                        //lbl.Text = inspectionItem.ToString();
                        //this.tlpAutoRunOptionData.Controls.Add(lbl, (int)inspectionItem - 1, 0);
                        break;
#endif

#if CGMS
                    case eTeachingItem.Particle:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);
                        break;

                    case eTeachingItem.Measure:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);
                        break;

                    case eTeachingItem.Short:
                        InspecionItemControl = new CtrlInspectionItem(inspectionItem);
                        InspectionItemControlList.Add(InspecionItemControl);
                        InspecionItemControl.Dock = DockStyle.Fill;
                        InspecionItemControl.SendEventHandler += new CtrlInspectionItem.SetInspectionItemDelegate(ReceiveTeachingItem);

                        this.tlpInspectionItemList.Controls.Add(InspecionItemControl, (int)inspectionItem - 1, 0);
                        break;
#endif
                    default:
                        break;
                }
            }
        }

        private void ReceiveTeachingItem(eTeachingItem inspectionItem, object sender)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Text.ToLower().Contains("mark"))
                Settings.Instance().Operation.UseMark = chk.Checked;
#if ATT
            if (chk.Text.ToLower().Contains("align"))
                Settings.Instance().Operation.UseAlign = chk.Checked;
            else if (chk.Text.ToLower().Contains("akkon"))
                Settings.Instance().Operation.UseAkkon = chk.Checked;
            else { }
#endif

#if CGMS
            if (chk.Text.ToLower().Contains("measure"))
                Settings.Instance().Operation.UseMeasure = chk.Checked;
            else if (chk.Text.ToLower().Contains("particle"))
                Settings.Instance().Operation.UseParticle = chk.Checked;
            else if (chk.Text.ToLower().Contains("short"))
                Settings.Instance().Operation.UseShort = chk.Checked;
            else { }
#endif
            if (chk.Checked)
                chk.BackColor = Color.LimeGreen;
            else
                chk.BackColor = Color.DarkGray;
        }
        #endregion

        private void MakeAutoRunListControl()
        {
            tlpAutoRunOptionData.RowStyles.Clear();
            tlpAutoRunOptionData.ColumnStyles.Clear();

            tlpAutoRunOptionData.RowCount = 2;
            // PJH_20230210_AF 제거_S
            //tlpInspectionItemList.ColumnCount = Enum.GetValues(typeof(eTeachingItem)).Length;
            tlpAutoRunOptionData.ColumnCount = Enum.GetValues(typeof(eTeachingItem)).Length - 1;
            // PJH_20230210_AF 제거_E

            for (int rowIndex = 0; rowIndex < tlpAutoRunOptionData.RowCount; rowIndex++)
                tlpAutoRunOptionData.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlpAutoRunOptionData.RowCount)));

            for (int columnIndex = 0; columnIndex < tlpInspectionItemList.ColumnCount; columnIndex++)
                tlpAutoRunOptionData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / tlpAutoRunOptionData.ColumnCount)));

            foreach (eTeachingItem inspectionItem in Enum.GetValues(typeof(eTeachingItem)))
            {
                switch (inspectionItem)
                {
#if ATT
                    case eTeachingItem.Align:
                        this.tlpAutoRunOptionData.Controls.Add(CreateLabel(inspectionItem.ToString()), (int)inspectionItem - 1, 0);
                        this.tlpAutoRunOptionData.Controls.Add(CreateCheckBox(inspectionItem.ToString()), (int)inspectionItem - 1, 1);
                        break;

                    case eTeachingItem.Akkon:
                        this.tlpAutoRunOptionData.Controls.Add(CreateLabel(inspectionItem.ToString()), (int)inspectionItem - 1, 0);
                        this.tlpAutoRunOptionData.Controls.Add(CreateCheckBox(inspectionItem.ToString()), (int)inspectionItem - 1, 1);
                        break;
#endif
#if CGMS
                    case eTeachingItem.Particle:
                        this.tlpAutoRunOptionData.Controls.Add(CreateLabel(inspectionItem.ToString().ToUpper()), (int)inspectionItem - 1, 0);
                        this.tlpAutoRunOptionData.Controls.Add(CreateCheckBox(inspectionItem.ToString()), (int)inspectionItem - 1, 1);
                        break;

                    case eTeachingItem.Measure:
                        this.tlpAutoRunOptionData.Controls.Add(CreateLabel(inspectionItem.ToString().ToUpper()), (int)inspectionItem - 1, 0);
                        this.tlpAutoRunOptionData.Controls.Add(CreateCheckBox(inspectionItem.ToString()), (int)inspectionItem - 1, 1);
                        break;

                    case eTeachingItem.Short:
                        this.tlpAutoRunOptionData.Controls.Add(CreateLabel(inspectionItem.ToString().ToUpper()), (int)inspectionItem - 1, 0);
                        this.tlpAutoRunOptionData.Controls.Add(CreateCheckBox(inspectionItem.ToString()), (int)inspectionItem - 1, 1);
                        break;
#endif
                    default:
                        break;
                }
            }
        }

        private Label CreateLabel(string name)
        {
            Label lbl = new Label();

            lbl.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = name.ToString().ToUpper();
            lbl.Dock = DockStyle.Fill;

            return lbl;
        }

        private List<CheckBox> _autoRunCheckBoxList = new List<CheckBox>();

        private CheckBox CreateCheckBox(string name)
        {
            CheckBox chk = new CheckBox();

            chk.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            chk.Appearance = Appearance.Button;
            chk.CheckedChanged += Chk_CheckedChanged;
            chk.Name = "lbl" + name.ToString();
            chk.Text = name.ToString()/*.ToUpper()*/;
            chk.TextAlign = ContentAlignment.MiddleCenter;
            chk.Dock = DockStyle.Fill;

            _autoRunCheckBoxList.Add(chk);

            return chk;
        }

        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;

#if ATT
            if (chk.Text.ToLower().Contains("align"))
                Settings.Instance().Operation.IsJudgeAlign = chk.Checked;
            else if (chk.Text.ToLower().Contains("akkon"))
                Settings.Instance().Operation.IsJudgeAkkon = chk.Checked;
            else { }
#endif

#if CGMS
            if (chk.Text.ToLower().Contains("measure"))
                Settings.Instance().Operation.IsJudgeMesure = chk.Checked;
            else if (chk.Text.ToLower().Contains("particle"))
                Settings.Instance().Operation.IsJudgeParticle = chk.Checked;
            else if (chk.Text.ToLower().Contains("short"))
                Settings.Instance().Operation.IsJudgeShort = chk.Checked;
            else { }
#endif
            if (chk.Checked)
            {
                chk.BackColor = Color.LimeGreen;
                chk.Text = "ON";
            }
            else
            {
                chk.BackColor = Color.DarkGray;
                chk.Text = "OFF";
            }
        }

        #region Write Label Data ( Double )
        private void lblInputDoubleData_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void SetLabelDoubleData(object sender)
        {
            Label lbl = sender as Label;
            double outputData = 0.0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = formKeyPad.m_data;
            lbl.Text = outputData.ToString();
        }
        #endregion

        #region Write Label Data ( Integer )
        private void lblInputIntegerData_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void SetLabelIntegerData(object sender)
        {
            Label lbl = sender as Label;
            int outputData = 0;

            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            outputData = Convert.ToInt32(formKeyPad.m_data);

            if (lbl.Name.ToLower().Contains("savecapacity"))
            {
                if (outputData > 90)
                    outputData = 90;
            }

            lbl.Text = outputData.ToString();
        }
        #endregion

        #region Write Label Data ( String )
        private void lblInputStringData_Click(object sender, EventArgs e)
        {
            SetLabelStringData(sender);
        }

        private void SetLabelStringData(object sender)
        {
            Label lbl = sender as Label;
            string outputData = "";

            Form_KeyBoard formKeyBoard = new Form_KeyBoard();
            formKeyBoard.ShowDialog();

            if (formKeyBoard.m_ResultString != "")
                outputData = formKeyBoard.m_ResultString;
            else
                outputData = "";

            lbl.Text = outputData.ToString();
        }
        #endregion

        #region Image Save Option
        private void cmbSaveOKImageExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetImageExtension(sender);
        }

        private void cmbSaveNGImageExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetImageExtension(sender);
        }

        private void chkSaveOKImage_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
            ActivateComboBox();
        }

        private void chkSaveNGImage_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
            ActivateComboBox();
        }

        private void SetImageExtension(object sender)
        {
            ComboBox cmb = sender as ComboBox;

            if (cmb.Name.ToLower().Contains("ok"))
            {

            }
            else
            {

            }
        }
        #endregion

        #region ATT Option
        private void chkDrawCenter_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }

        private void chkDrawContour_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }

        private void chkDrawLength_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }

        private void chkRMSAkkonParameterSet_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckChanged(sender);
        }
        #endregion

        private void SetCheckChanged(object sender)
        {
            CheckBox chk = sender as CheckBox;

            if (chk.Checked)
                chk.BackColor = Color.LimeGreen;
            else
                chk.BackColor = Color.DarkGray;
        }

        private void ActivateComboBox()
        {
            if (chkSaveOKImage.Checked)
                cmbSaveOKImageExtension.Enabled = true;
            else
                cmbSaveOKImageExtension.Enabled = false;

            if (chkSaveNGImage.Checked)
                cmbSaveNGImageExtension.Enabled = true;
            else
                cmbSaveNGImageExtension.Enabled = false;
        }

        #region Draw ComboBox
        private void cmb_DrawItem(object sender, DrawItemEventArgs e)
        {
            DrawComboboxCenterAlign(sender, e);
        }

        private void DrawComboboxCenterAlign(object sender, DrawItemEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            if (cmb != null)
            {
                e.DrawBackground();

                if (e.Index >= 0)
                {
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    Brush brush = new SolidBrush(cmb.ForeColor);

                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    e.Graphics.DrawString(cmb.Items[e.Index].ToString(), cmb.Font, brush, e.Bounds, sf);
                }
            }
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            UpdateData();
            Main.SystemSave();

            SaveSettings();
            Settings.Instance().Operation.Save();
        }
        #endregion

        private void UpdateUI()
        {
            Main.SystemLoad();

            // Vision Setting
            lblPreAlignCamToLineScanCamDistanceX.Text = Main.machine.CameraDistanceX.ToString("F2");
            lblPreAlignCamToLineScanCamDistanceY.Text = Main.machine.CameraDistanceY.ToString("F2");

            // LineScan Axis Setting
            if (Main.machine.LineScanAxis == eAxis.Axis_X)
                rdoLineScanAxisX.Checked = true;
            else if (Main.machine.LineScanAxis == eAxis.Axis_Y)
                rdoLineScanAxisY.Checked = true;
            else { }

            // PreAlign Tolerance
            lblPreAlignReferenceX.Text = Main.machine.PreAlignReferenceX.ToString("F2");
            lblPreAlignReferenceY.Text = Main.machine.PreAlignReferenceY.ToString("F2");
            lblPreAlignReferenceT.Text = Main.machine.PreAlignReferenceT.ToString("F2");
            lblPreAlignToleranceX.Text = Main.machine.PreAlignToleranceX.ToString("F2");
            lblPreAlignToleranceY.Text = Main.machine.PreAlignToleranceY.ToString("F2");
            lblPreAlignToleranceT.Text = Main.machine.PreAlignToleranceT.ToString("F2");

            // ATT Option
            chkDrawCenter.Checked = Main.machine.IsDrawCenter;
            chkDrawContour.Checked = Main.machine.IsDrawContour;
            chkDrawLength.Checked = Main.machine.IsDrawlength;
            chkRMSAkkonParameterSet.Checked = Main.machine.IsRMSAkkonParameterSet;

            // Save Image
            chkSaveOKImage.Checked = Main.machine.IsSaveOKImage;
            if (chkSaveOKImage.Checked)
                cmbSaveOKImageExtension.Enabled = true;
            else
                cmbSaveOKImageExtension.Enabled = false;
            for (int i = 0; i < cmbSaveOKImageExtension.Items.Count; i++)
            {
                eImageExtension type = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbSaveOKImageExtension.Items[i] as string);
                if (type == Main.machine.SaveOKImageExtension)
                    cmbSaveOKImageExtension.SelectedIndex = i;
            }
            chkSaveNGImage.Checked = Main.machine.IsSaveNGImage;
            if (chkSaveNGImage.Checked)
                cmbSaveNGImageExtension.Enabled = true;
            else
                cmbSaveNGImageExtension.Enabled = false;
            for (int i = 0; i < cmbSaveNGImageExtension.Items.Count; i++)
            {
                eImageExtension type = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbSaveNGImageExtension.Items[i] as string);
                if (type == Main.machine.SaveNGImageExtension)
                    cmbSaveNGImageExtension.SelectedIndex = i;
            }

            // Data Store
            lblImageSaveDurationValue.Text = Main.machine.ImageSaveDuration.ToString();

            // Auto Run Option
            //chkForcePreAlign.Checked = Main.machine.IsForcePrealign;
            //chkForceAlign.Checked = Main.machine.IsForceAlign;
            //chkForceAkkon.Checked = Main.machine.IsForceAkkon;

            // Alarm Setting
            //lblAlarmCapacityValue.Text = Main.machine.m_nCheckPanelCapacity.ToString();
            //lblAlarmNGCountValue.Text = Main.machine.m_nNGCount.ToString();
        }

        private void LoadSettings()
        {
            #region Vision Setting
            lblPreAlignCamToLineScanCamDistanceX.Text = Settings.Instance().Operation.PreAlignCamToLineScanCamDistanceX.ToString();
            lblPreAlignCamToLineScanCamDistanceY.Text = Settings.Instance().Operation.PreAlignCamToLineScanCamDistanceY.ToString();
            #endregion

            if (Settings.Instance().Operation.LineScannerAxis == eAxis.Axis_X)
                rdoLineScanAxisX.Checked = true;
            else if (Settings.Instance().Operation.LineScannerAxis == eAxis.Axis_Y)
                rdoLineScanAxisY.Checked = true;
            else { }

            #region PreAlign Tolerance
            lblPreAlignReferenceX.Text = Settings.Instance().Operation.PreAlignReferenceX.ToString("F2");
            lblPreAlignReferenceY.Text = Settings.Instance().Operation.PreAlignReferenceY.ToString("F2");
            lblPreAlignReferenceT.Text = Settings.Instance().Operation.PreAlignReferenceT.ToString("F2");
            lblPreAlignToleranceX.Text = Settings.Instance().Operation.PreAlignToleranceX.ToString("F2");
            lblPreAlignToleranceY.Text = Settings.Instance().Operation.PreAlignToleranceY.ToString("F2");
            lblPreAlignToleranceT.Text = Settings.Instance().Operation.PreAlignToleranceT.ToString("F2");
            #endregion

            #region Image Save Option
            lblImageSaveDurationValue.Text = Settings.Instance().Operation.ImageSaveDurtaion.ToString();
            lblDataSaveCapacityValue.Text = Settings.Instance().Operation.DataSaveCapacity.ToString();

            chkSaveOKImage.Checked = Settings.Instance().Operation.IsSaveOKImage;
            for (int index = 0; index < cmbSaveOKImageExtension.Items.Count; index++)
            {
                if (cmbSaveOKImageExtension.Items[index] as string == Settings.Instance().Operation.SaveOKImageExtension.ToString())
                    cmbSaveOKImageExtension.SelectedIndex = index;
            }
            chkSaveNGImage.Checked = Settings.Instance().Operation.IsSaveNGImage;
            for (int index = 0; index < cmbSaveNGImageExtension.Items.Count; index++)
            {
                if (cmbSaveNGImageExtension.Items[index] as string == Settings.Instance().Operation.SaveNGImageExtension.ToString())
                    cmbSaveNGImageExtension.SelectedIndex = index;
            }
            #endregion

            #region Inspection Option
            foreach (eTeachingItem inspectionItem in Enum.GetValues(typeof(eTeachingItem)))
            {
                switch (inspectionItem)
                {
                    case eTeachingItem.Mark:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseMark);
                        break;
#if ATT
                    case eTeachingItem.Align:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseAlign);
                        break;

                    case eTeachingItem.Akkon:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseAkkon);
                        break;
#endif
#if CGMS
                    case eTeachingItem.Particle:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseParticle);
                        break;

                    case eTeachingItem.Measure:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseMeasure);
                        break;

                    case eTeachingItem.Short:
                        InspectionItemControlList[(int)inspectionItem - 1].SetInspectionItem(Settings.Instance().Operation.UseShort);
                        break;
#endif
                    default:
                        break;
                }
            }
            #endregion

            #region AutoRun Option
            foreach (eTeachingItem inspectionItem in Enum.GetValues(typeof(eTeachingItem)))
            {
                switch (inspectionItem)
                {
#if ATT
                    case eTeachingItem.Align:
                        if (Settings.Instance().Operation.IsJudgeAlign)
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = true;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "ON";
                        }
                        else
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = false;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "OFF";
                        }
                        break;

                    case eTeachingItem.Akkon:
                        if (Settings.Instance().Operation.IsJudgeAkkon)
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = true;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "ON";
                        }
                        else
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = false;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "OFF";
                        }
                        break;
#endif
#if CGMS
                    case eTeachingItem.Particle:
                        if (Settings.Instance().Operation.IsJudgeParticle)
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = true;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "ON";
                        }
                        else
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = false;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "OFF";
                        }
                        break;

                    case eTeachingItem.Measure:
                        if (Settings.Instance().Operation.IsJudgeMesure)
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = true;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "ON";
                        }
                        else
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = false;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "OFF";
                        }
                        break;

                    case eTeachingItem.Short:
                        if (Settings.Instance().Operation.IsJudgeShort)
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = true;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "ON";
                        }
                        else
                        {
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Checked = false;
                            _autoRunCheckBoxList[(int)inspectionItem - 2].Text = "OFF";
                        }
                        break;
#endif
                    default:
                        break;
                }
            }
            #endregion

            #region ATT Option
            chkDrawCenter.Checked = Settings.Instance().Operation.IsDrawCenter;
            chkDrawContour.Checked = Settings.Instance().Operation.IsDrawContour;
            chkDrawLength.Checked = Settings.Instance().Operation.IsDrawLength;
            chkRMSAkkonParameterSet.Checked = Settings.Instance().Operation.IsRMSAkkonParameterSet;
            #endregion
        }

        private void UpdateData()
        {
            // Vision Setting
            Main.machine.CameraDistanceX = Convert.ToDouble(lblPreAlignCamToLineScanCamDistanceX.Text);
            Main.machine.CameraDistanceY = Convert.ToDouble(lblPreAlignCamToLineScanCamDistanceY.Text);

            if (rdoLineScanAxisX.Checked)
                Main.machine.LineScanAxis = eAxis.Axis_X;
            else if (rdoLineScanAxisY.Checked)
                Main.machine.LineScanAxis = eAxis.Axis_Y;
            else { }

            // PreAlign Tolerance
            Main.machine.PreAlignReferenceX = Convert.ToDouble(lblPreAlignReferenceX.Text);
            Main.machine.PreAlignReferenceY = Convert.ToDouble(lblPreAlignReferenceY.Text);
            Main.machine.PreAlignReferenceT = Convert.ToDouble(lblPreAlignReferenceT.Text);
            Main.machine.PreAlignToleranceX = Convert.ToDouble(lblPreAlignToleranceX.Text);
            Main.machine.PreAlignToleranceY = Convert.ToDouble(lblPreAlignToleranceY.Text);
            Main.machine.PreAlignToleranceT = Convert.ToDouble(lblPreAlignToleranceT.Text);

            // UI options according to inspection option settings
            if (Main.machine.UseAkkon)
                pnlATTOption.Enabled = true;
            else
                pnlATTOption.Enabled = false;

            // ATT Option
            Main.machine.IsDrawCenter = chkDrawCenter.Checked;
            Main.machine.IsDrawContour = chkDrawContour.Checked;
            Main.machine.IsDrawlength = chkDrawLength.Checked;
            Main.machine.IsRMSAkkonParameterSet = chkRMSAkkonParameterSet.Checked;

            // Auto Run Option
            //Main.machine.IsForcePrealign = chkForcePreAlign.Checked;
            //Main.machine.IsForceAlign = chkForceAlign.Checked;
            //Main.machine.IsForceAkkon = chkForceAkkon.Checked;

            // Alarm Setting
            //Main.machine.m_nCheckPanelCapacity = Convert.ToInt32(lblAlarmCapacityValue.Text);
            //Main.machine.m_nNGCount = Convert.ToInt32(lblAlarmNGCountValue.Text);

            // Save Image
            // Main.machine.IsAutoSaveImage = chkAutoSaveImage.Checked;
            // Main.machine.AutoSaveImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbAutoSaveImageExtension.SelectedItem as string);
            // Main.machine.IsTeachSaveImage = chkTeachSaveImage.Checked;
            // Main.machine.TeachSaveImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbTeachSaveImageExtension.SelectedItem as string);

            // // Data Store
            // Main.machine.ImageSavePeriod = Convert.ToInt32(lblImageSavePeriodValue.Text);
            //// Main.machine.ImageSaveCapacity = Convert.ToInt32(lblImageSaveCapacityValue.Text);
            // Main.machine.LogSavePeriod = Convert.ToInt32(lblLogSavePeriodValue.Text);

            // Motion
            //Main.machine.MotionIPAddress = lblMotionIPAddressValue.Text;
            //Main.machine.MotionPort = Convert.ToInt32(lblMotionPortValue.Text);

            //// PLC
            //Main.machine.PLCIPAddress = lblPLCIPAddressValue.Text;
            //Main.machine.PLCPort = Convert.ToInt32(lblPLCPortValue.Text);

            //// Auto Focus
            //Main.machine.AutoFocusCOMPort = cmbAutoFocusComPort.Text;
            //Main.machine.AutoFocusBaudRate = Convert.ToInt32(cmbAutoFocusBaudRate.Text);

            //// Light
            //Main.machine.LightCOMPort = cmbLightComPort.Text;
            //Main.machine.LightBaudRate = Convert.ToInt32(cmbLightBaudRate.Text);
        }

        private void SaveSettings()
        {
            // Device
            //Settings.Instance().Operation.MotionIPAddress = Settings.Instance().Operation.MotionIPAddress;
            //Settings.Instance().Operation.MotionPortNumber = Settings.Instance().Operation.MotionPortNumber;

            //Settings.Instance().Operation.PLCIPAddress = Settings.Instance().Operation.PLCIPAddress;
            //Settings.Instance().Operation.PLCPortNumber = Settings.Instance().Operation.PLCPortNumber;

            //Settings.Instance().Operation.AutoFocusCOMPort = Settings.Instance().Operation.AutoFocusCOMPort;
            //Settings.Instance().Operation.AutoFocusBaudRate = Settings.Instance().Operation.AutoFocusBaudRate;

            //Settings.Instance().Operation.LightCOMPort = Settings.Instance().Operation.LightCOMPort;
            //Settings.Instance().Operation.LightBaudRate = Settings.Instance().Operation.LightBaudRate;

#region Vision Setting
            Settings.Instance().Operation.PreAlignCamToLineScanCamDistanceX = Convert.ToDouble(lblPreAlignCamToLineScanCamDistanceX.Text);
            Settings.Instance().Operation.PreAlignCamToLineScanCamDistanceY = Convert.ToDouble(lblPreAlignCamToLineScanCamDistanceY.Text);
            #endregion

            if (rdoLineScanAxisX.Checked)
                Settings.Instance().Operation.LineScannerAxis = eAxis.Axis_X;
            else if (rdoLineScanAxisY.Checked)
                Settings.Instance().Operation.LineScannerAxis = eAxis.Axis_Y;
            else { }

            #region PreAlign Tolerance
            Settings.Instance().Operation.PreAlignReferenceX = Convert.ToDouble(lblPreAlignReferenceX.Text);
            Settings.Instance().Operation.PreAlignReferenceY = Convert.ToDouble(lblPreAlignReferenceY.Text);
            Settings.Instance().Operation.PreAlignReferenceT = Convert.ToDouble(lblPreAlignReferenceT.Text);
            Settings.Instance().Operation.PreAlignToleranceX = Convert.ToDouble(lblPreAlignToleranceX.Text);
            Settings.Instance().Operation.PreAlignToleranceY = Convert.ToDouble(lblPreAlignToleranceY.Text);
            Settings.Instance().Operation.PreAlignToleranceT = Convert.ToDouble(lblPreAlignToleranceT.Text);
#endregion

#region Option
            // Data Store Option
            //Settings.Instance().Operation.ImageSavePath = Settings.Instance().Operation.ImageSavePath;
            Settings.Instance().Operation.ImageSaveDurtaion = Convert.ToInt32(lblImageSaveDurationValue.Text);
            //Settings.Instance().Operation.LogSavePath = Settings.Instance().Operation.LogSavePath;
            //Settings.Instance().Operation.LogSaveDuration = Settings.Instance().Operation.LogSaveDuration
            Settings.Instance().Operation.DataSaveCapacity = Settings.Instance().Operation.DataSaveCapacity;

            // Image Save Option
            Settings.Instance().Operation.IsSaveOKImage = chkSaveOKImage.Checked;
            Settings.Instance().Operation.SaveOKImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbSaveOKImageExtension.SelectedItem as string);
            Settings.Instance().Operation.IsSaveNGImage = chkSaveNGImage.Checked;
            Settings.Instance().Operation.SaveNGImageExtension = (eImageExtension)Enum.Parse(typeof(eImageExtension), cmbSaveNGImageExtension.SelectedItem as string);
#endregion

#region ATT Option
            Settings.Instance().Operation.IsDrawCenter = chkDrawCenter.Checked;
            Settings.Instance().Operation.IsDrawContour = chkDrawContour.Checked;
            Settings.Instance().Operation.IsDrawLength = chkDrawLength.Checked;
            Settings.Instance().Operation.IsRMSAkkonParameterSet = chkRMSAkkonParameterSet.Checked;
#endregion
        }

        private void FormSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CloseEventDelegate != null)
                CloseEventDelegate();
        }

#region Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            Main.SystemLoad();
            this.Close();
        }
        #endregion

        private eAxis _linescanAxis = eAxis.Axis_Y;
        private void rdoSetLineScanAxis_CheckedChanged(object sender, EventArgs e)
        {
            SetSelectLineScanAxis(sender);
        }

        private void SetSelectLineScanAxis(object sender)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked)
            {
                if (btn.Name.ToLower().Contains("x"))
                    SetLineScanAxis(eAxis.Axis_X);
                else if (btn.Name.ToLower().Contains("y"))
                    SetLineScanAxis(eAxis.Axis_Y);
                else { }

                btn.BackColor = Color.LimeGreen;
            }
            else
                btn.BackColor = Color.DarkGray;
        }

        private void SetLineScanAxis(eAxis axis)
        {
            _linescanAxis = axis;
        }
    }
}
