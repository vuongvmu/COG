using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG.Controls
{
    public partial class CtrlCGMSRecipe : UserControl
    {
        //private string _previousSelectedProjectName;
        //private int _selectedModelNo;
        private bool _isRedrawNavigator = false;

        public CtrlCGMSRecipe()
        {
            InitializeComponent();
        }

        private void CtrlCGMSRecipe_Load(object sender, EventArgs e)
        {
            //SetProjectName();
            LoadData();
        }

        //private void SetProjectName()
        //{
        //    _previousSelectedProjectName = Main.ProjectName;
        //    Main.ProjectName = _selectedModelNo.ToString("D3");
        //}

        public void LoadData()
        {
            Main.Recipe_Initial();
            Main.Model_Initial();
            Main.RecipeDataLoad();
            Main.SystemLoad();
            UpdateUI();
        }

        private void UpdateUI()
        {
            lblPatternSizeYValue.Text = Main.recipe.m_PatternYSize.ToString();
            lblMarkToPatternDistanceXValue.Text = Main.recipe.m_MarkToPatternXDistance.ToString();
            lblMarkToPatternDistanceYValue.Text = Main.recipe.m_MarkToPatternYDistance.ToString();
            lblPatternToPatternDistanceXValue.Text = Main.recipe.m_PatternToPatternXDistance.ToString();
            lblPatternToPatternDistanceYValue.Text = Main.recipe.m_PatternToPatternYDistance.ToString();

            lblScanRowCount.Text = Main.recipe.m_nScanCount.ToString();
            lblScanColumnCount.Text = Main.recipe.m_nTabCount.ToString();

            lblAlignToleranceX.Text = Main.AlignUnit[0].m_AlignTolX.ToString();
            lblAlignToleranceY.Text = Main.AlignUnit[0].m_AlignTolY.ToString();
            lblAlignToleranceCX.Text = Main.AlignUnit[0].m_AlignTolCX.ToString();
            lblAlignStandardValue.Text = Main.AlignUnit[0].m_AlignStandardY.ToString();
        }

        private void LoadSettings()
        {
            lblPatternSizeYValue.Text = Settings.Instance().Recipe.CGMS.SampleInfo.PatternSizeY.ToString();
            lblMarkToPatternDistanceXValue.Text = Settings.Instance().Recipe.CGMS.SampleInfo.MarkToPatternDistanceX.ToString();
            lblMarkToPatternDistanceYValue.Text = Settings.Instance().Recipe.CGMS.SampleInfo.PatternToPatternDistanceX.ToString();
            lblPatternToPatternDistanceXValue.Text = Settings.Instance().Recipe.CGMS.SampleInfo.PatternToPatternDistanceY.ToString();

            lblScanRowCount.Text = Settings.Instance().Recipe.CGMS.GrabMatrix.Row.ToString();
            lblScanColumnCount.Text = Settings.Instance().Recipe.CGMS.GrabMatrix.Column.ToString();

            lblAlignToleranceX.Text = Main.AlignUnit[0].m_AlignTolX.ToString();
            lblAlignToleranceY.Text = Main.AlignUnit[0].m_AlignTolY.ToString();
            lblAlignToleranceCX.Text = Main.AlignUnit[0].m_AlignTolCX.ToString();
            lblAlignStandardValue.Text = Main.AlignUnit[0].m_AlignStandardY.ToString();
        }

        private void DataUpdate()
        {
            bool bDataChageCheck = false;

            double.TryParse(lblPatternSizeYValue.Text, out Main.recipe.m_PatternYSize);
            double.TryParse(lblMarkToPatternDistanceXValue.Text, out Main.recipe.m_MarkToPatternXDistance);
            double.TryParse(lblMarkToPatternDistanceYValue.Text, out Main.recipe.m_MarkToPatternYDistance);
            double.TryParse(lblPatternToPatternDistanceXValue.Text, out Main.recipe.m_PatternToPatternXDistance);
            double.TryParse(lblPatternToPatternDistanceYValue.Text, out Main.recipe.m_PatternToPatternYDistance);

            //현재 입력한 값이랑 기존 데이터랑 상이할 경우 업데이트 진행
            if (Convert.ToInt32(lblScanRowCount.Text) != Main.recipe.m_nScanCount)
            {
                int.TryParse(lblScanRowCount.Text, out Main.recipe.m_nScanCount);
                _isRedrawNavigator = true;

                bDataChageCheck = true;
            }

            if (Convert.ToInt32(lblScanColumnCount.Text) != Main.recipe.m_nTabCount)
            {
                int.TryParse(lblScanColumnCount.Text, out Main.recipe.m_nTabCount);
                _isRedrawNavigator = true;

                bDataChageCheck = true;
            }

            if (bDataChageCheck)
                Main.AlignUnitPat_Initial();

            double.TryParse(lblAlignToleranceX.Text, out Main.AlignUnit[0].m_AlignTolX);
            double.TryParse(lblAlignToleranceY.Text, out Main.AlignUnit[0].m_AlignTolY);
            double.TryParse(lblAlignToleranceCX.Text, out Main.AlignUnit[0].m_AlignTolCX);
            double.TryParse(lblAlignStandardValue.Text, out Main.AlignUnit[0].m_AlignStandardY);
        }

        #region Label Click Event
        private void lblPatternSizeYValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblMarkToPatternDistanceXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblMarkToPatternDistanceYValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblPatternToPatternDistanceXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblPatternToPatternDistanceYValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblScanRowCount_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void lblScanColumnCount_Click(object sender, EventArgs e)
        {
            SetLabelIntegerData(sender);
        }

        private void lblAlignToleranceX_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblAlignToleranceY_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblAlignToleranceCX_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblAlignStandardValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }
        #endregion

        private void SetLabelIntegerData(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            int outputData = (int)formKeyPad.m_data;

            Label labelButton = sender as Label;

            labelButton.Text = outputData.ToString();
        }

        private void SetLabelDoubleData(object sender)
        {
            Form_KeyPad formKeyPad = new Form_KeyPad();
            formKeyPad.ShowDialog();

            double outputData = formKeyPad.m_data;

            Label labelButton = sender as Label;

            labelButton.Text = outputData.ToString("F3");
        }

        public void Save()
        {
            DataUpdate();
            Main.SystemSave();
            Main.RecipeDataSave();
            //Main.ProjectName = _previousSelectedProjectName;
            Main.Recipe_Initial();

            if (_isRedrawNavigator)
            {
                FormMain.Instance().CGMSViewerControl.RedrawNavigator();
                _isRedrawNavigator = false;
            }
        }
    }
}
