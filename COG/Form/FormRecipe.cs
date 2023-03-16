using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormRecipe : Form
    {
        public CtrlATTRecipe ATTRecipeControl = null;
        public CtrlCGMSRecipe CGMSRecipeControl = null;

        private int _selectedModelNo;
        private string _previousSelectedProjectName;

        public FormRecipe(int selectedModelNumber)
        {
            InitializeComponent();
            _selectedModelNo = selectedModelNumber;
        }

        private void FormRecipe_Load(object sender, EventArgs e)
        {
            InitialzeUI();
            SetProjectName();
#if CGMS
            CGMSRecipeControl.LoadData();
#endif
#if ATT
            ATTRecipeControl.LoadData();
#endif
        }

        private void InitialzeUI()
        {
#if CGMS
            this.Size = new Size(1210, 700);
#endif
#if ATT
            this.Size = new Size(1210, 800);
#endif
            AddControl();
        }

        private void AddControl()
        {
#if CGMS
            CGMSRecipeControl = new CtrlCGMSRecipe();
            CGMSRecipeControl.Dock = DockStyle.Fill;
            this.pnlRecipe.Controls.Add(CGMSRecipeControl);
#endif
#if ATT
            ATTRecipeControl = new CtrlATTRecipe();
            ATTRecipeControl.Dock = DockStyle.Fill;
            this.pnlRecipe.Controls.Add(ATTRecipeControl);
#endif
        }

        private void SetProjectName()
        {
            _previousSelectedProjectName = Main.ProjectName;
            Main.ProjectName = _selectedModelNo.ToString("D3");
        }

        #region Form Save & Exit
        private void btnSave_Click(object sender, EventArgs e)
        {
            Main.ProjectName = _previousSelectedProjectName;
#if CGMS
            CGMSRecipeControl.Save();
#endif
#if ATT
            ATTRecipeControl.Save();
#endif
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            //Main.ProjectName = _previousSelectedProjectName;
            Main.Recipe_Initial();
            this.Close();
        }
#endregion
    }
}
