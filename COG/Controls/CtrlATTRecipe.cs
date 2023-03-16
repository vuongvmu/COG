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
    public partial class CtrlATTRecipe : UserControl
    {
        //private string _previousSelectedProjectName;
        //private int _selectedModelNo;

        public CtrlATTRecipe()
        {
            InitializeComponent();
        }

        private void CtrlATTRecipe_Load(object sender, EventArgs e)
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
            lblPanelSizeXValue.Text = Main.recipe.m_dPanelSizeX.ToString();
            lblMarkToMarkDistanceXValue.Text = Main.recipe.m_dMarkToMarkDistance.ToString();
            lblTabWidthValue.Text = Main.recipe.m_dTabWidth.ToString();
            lblPanelToTabDistanceXValue.Text = Main.recipe.m_dPanelToTabDistance.ToString();

            lblTabDistance1.Text = Main.recipe.m_dTabDistance1.ToString();
            lblTabDistance2.Text = Main.recipe.m_dTabDistance2.ToString();
            lblTabDistance3.Text = Main.recipe.m_dTabDistance3.ToString();
            lblTabDistance4.Text = Main.recipe.m_dTabDistance4.ToString();
            lblTabDistance5.Text = Main.recipe.m_dTabDistance5.ToString();

            lblAlignToleranceX.Text = Main.AlignUnit[0].m_AlignTolX.ToString();
            lblAlignToleranceY.Text = Main.AlignUnit[0].m_AlignTolY.ToString();
            lblAlignToleranceCX.Text = Main.AlignUnit[0].m_AlignTolCX.ToString();

            lblAlignStandardValue.Text = Main.AlignUnit[0].m_AlignStandardY.ToString();
        }

        private void LoadSettings()
        {
            lblPanelSizeXValue.Text = Settings.Instance().Recipe.ATT.SampleInfo.PanelSizeX.ToString();
            lblMarkToMarkDistanceXValue.Text = Settings.Instance().Recipe.ATT.SampleInfo.MarkToMarkDistance.ToString();
            lblTabWidthValue.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabWidth.ToString();
            lblPanelToTabDistanceXValue.Text = Settings.Instance().Recipe.ATT.SampleInfo.PanelEdgeToFirstTabDistance.ToString();

            lblTabDistance1.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabToTabDistance1.ToString();
            lblTabDistance2.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabToTabDistance2.ToString();
            lblTabDistance3.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabToTabDistance3.ToString();
            lblTabDistance4.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabToTabDistance4.ToString();
            lblTabDistance5.Text = Settings.Instance().Recipe.ATT.SampleInfo.TabToTabDistance5.ToString();

            lblAlignToleranceX.Text = Main.AlignUnit[0].m_AlignTolX.ToString();
            lblAlignToleranceY.Text = Main.AlignUnit[0].m_AlignTolY.ToString();
            lblAlignToleranceCX.Text = Main.AlignUnit[0].m_AlignTolCX.ToString();

            lblAlignStandardValue.Text = Main.AlignUnit[0].m_AlignStandardY.ToString();
        }

        private void DataUpdate()
        {
            bool bDataChageCheck = false;

            double.TryParse(lblPanelSizeXValue.Text, out Main.recipe.m_dPanelSizeX);
            double.TryParse(lblMarkToMarkDistanceXValue.Text, out Main.recipe.m_dMarkToMarkDistance);
            double.TryParse(lblTabWidthValue.Text, out Main.recipe.m_dTabWidth);
            double.TryParse(lblPanelToTabDistanceXValue.Text, out Main.recipe.m_dPanelToTabDistance);

            double.TryParse(lblTabDistance1.Text, out Main.recipe.m_dTabDistance1);
            double.TryParse(lblTabDistance2.Text, out Main.recipe.m_dTabDistance2);
            double.TryParse(lblTabDistance3.Text, out Main.recipe.m_dTabDistance3);
            double.TryParse(lblTabDistance4.Text, out Main.recipe.m_dTabDistance4);
            double.TryParse(lblTabDistance5.Text, out Main.recipe.m_dTabDistance5);

            if (bDataChageCheck)
                Main.AlignUnitPat_Initial();

            double.TryParse(lblAlignToleranceX.Text, out Main.AlignUnit[0].m_AlignTolX);
            double.TryParse(lblAlignToleranceY.Text, out Main.AlignUnit[0].m_AlignTolY);
            double.TryParse(lblAlignToleranceCX.Text, out Main.AlignUnit[0].m_AlignTolCX);

            double.TryParse(lblAlignStandardValue.Text, out Main.AlignUnit[0].m_AlignStandardY);
        }

        #region Label Click Event
        private void lblPanelSizeXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblMarkToMarkDistanceXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabWidthValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblPanelToTabDistanceXValue_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabDistance1_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabDistance2_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabDistance3_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabDistance4_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
        }

        private void lblTabDistance5_Click(object sender, EventArgs e)
        {
            SetLabelDoubleData(sender);
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
        }
    }
}
