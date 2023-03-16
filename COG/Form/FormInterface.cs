using COG.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COG
{
    public partial class FormInterface : Form
    {
        public CtrlInterfaceCCLink CCLinkControl = null;
        private List<CtrlInterfaceCCLink> _cclinkControlList = new List<CtrlInterfaceCCLink>();
        private List<Dictionary<string, string>> _cclinkDictionary = new List<Dictionary<string, string>>();

        // CCLink
        private enum eDataType
        {
            BX,
            BY,
            WR,
            WW,
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public FormInterface()
        {
            InitializeComponent();
        }

        private void FormInterface_Load(object sender, EventArgs e)
        {
            Main.ProgerssBar_Unit(Main.formProgressBar, 2, true, 0);

            if (!LoadData())
                return;

            AddControls();
            InitializeUI();

            Main.ProgerssBar_Unit(Main.formProgressBar, 2, true, 2);
        }

        #region Initailze UI
        private void InitializeUI()
        {
            pnlCCLink.Dock = DockStyle.Fill;
            pnlMelsec.Dock = DockStyle.Fill;

            rdoCCLink.Checked = true;
        }

        public void ShowCCLineInterface()
        {
            rdoCCLink.Checked = true;
        }

        private void rdoShowInterface_CheckedChanged(object sender, EventArgs e)
        {
            SetShowInterface(sender);
        }

        private void SetShowInterface(object sender)
        {
            RadioButton rdo = sender as RadioButton;

            if (rdo.Checked)
            {
                rdo.BackColor = Color.LimeGreen;

                if (rdo.Text.ToLower().Contains("cclink"))
                    ShowCCLink();
                else if (rdo.Text.ToLower().Contains("melsec"))
                {
                    ShowMelsec();
                    Form_Melsec tt = new Form_Melsec();
                    tt.ShowDialog();
                }
                else { }

                
            }
            else
                rdo.BackColor = Color.DarkGray;
        }

        private void ShowCCLink()
        {
            pnlCCLink.Visible = true;
            pnlMelsec.Visible = false;
        }

        private void ShowMelsec()
        {
            pnlCCLink.Visible = false;
            pnlMelsec.Visible = true;
        }
        #endregion

        #region Load Data
        private bool LoadData()
        {
            bool isSuccess = true;

            // CCLink
            if (CheckExistFile())
            {
                foreach (eDataType dataType in Enum.GetValues(typeof(eDataType)))
                {
                    _cclinkDictionary.Add(new Dictionary<string, string>());
                    LoadCCLinkData(dataType);
                }
            }
            else
                isSuccess = false;


            // Melsec
            //for (int i = 0; i < PLCDataTag.ReadSize; i++)
            //{

            //}

            return isSuccess;
        }

        private bool CheckExistFile()
        {
            string fileName = "InfIoMapCaps_ATT";
            string filePath = Main.InterfacePath + fileName + ".dat";

            if (File.Exists(filePath))
                return true;
            else
            {
                MessageBox.Show("Failed to read file");
                return false;
            }
        }

        private void LoadCCLinkData(eDataType dataType)
        {
            string fileName = "InfIoMapCaps_ATT";
            string filePath = Main.InterfacePath + fileName + ".dat";
            string name = "";
            string caption = "";

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] stringArray = line.Split(',');

                    foreach (string readData in stringArray)
                    {
                        if (readData.Equals(dataType.ToString()))
                        {
                            string data = stringArray[1].Replace("\t", "");
                            int startIndex = data.IndexOf("[");
                            int endIndex = data.LastIndexOf("]");

                            name = data.Substring(startIndex, endIndex);
                            caption = data.Substring(endIndex + 2);
                            _cclinkDictionary[(int)dataType].Add(name, caption);
                        }
                    }
                }
            }
        }
        #endregion

        private void AddControls()
        {
            // Create TableLayoutPanel - CCLink
            if (_cclinkDictionary.Count <= 0)
                return;

            tlpCCLink.RowStyles.Clear();
            tlpCCLink.ColumnStyles.Clear();

            tlpCCLink.RowCount = 1;
            tlpCCLink.ColumnCount = Enum.GetValues(typeof(eDataType)).Length;

            for (int rowIndex = 0; rowIndex < tlpCCLink.RowCount; rowIndex++)
                tlpCCLink.RowStyles.Add(new RowStyle(SizeType.Percent, (float)(100 / tlpCCLink.RowCount)));

            for (int columnIndex = 0; columnIndex < tlpCCLink.ColumnCount; columnIndex++)
                tlpCCLink.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)(100 / tlpCCLink.ColumnCount)));

            foreach (eDataType dataType in Enum.GetValues(typeof(eDataType)))
            {
                CCLinkControl = new CtrlInterfaceCCLink(dataType.ToString(), _cclinkDictionary[(int)dataType]);
                _cclinkControlList.Add(CCLinkControl);
                CCLinkControl.Dock = DockStyle.Fill;

                this.tlpCCLink.Controls.Add(CCLinkControl, (int)dataType, 0);
            }

            // Create - Melsec

        }

        #region Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            this.Close();
        }
        #endregion
    }
}
