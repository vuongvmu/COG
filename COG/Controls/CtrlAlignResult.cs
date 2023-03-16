using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COG.Class;
using System.Reflection;
using static COG.Class.InspectionResult;

namespace COG.Controls
{
    public partial class CtrlAlignResult : UserControl
    {
        public CtrlAlignResult()
        {
            InitializeComponent();
        }

        private delegate void UpdateAlignInspectionHistoryDelegate(List<AlignInspectionResult> alignHistory, bool isUpdate);
        public void UpdateAlignInspectionHistory(List<AlignInspectionResult> alignHistory, bool isUpdate)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAlignInspectionHistoryDelegate callback = UpdateAlignInspectionHistory;
                    BeginInvoke(callback, alignHistory, isUpdate);
                    return;
                }

                //dgvAlignHistory.Rows.Clear();

                if (isUpdate)
                {
                    foreach (AlignInspectionResult item in alignHistory)
                    {
                        string inspectionTime = item.InspectionTime.ToString();
                        string panelID = item.PanelID;
                        string tabNumber = item.TabNumber.ToString();
                        string judge = item.Judge.ToString();
                        string leftAlignX = item.LeftAlignX.ToString("F2");
                        string leftAlignY = item.LeftAlignY.ToString("F2");
                        string rightAlignX =  item.RightAlignX.ToString("F2");
                        string rightAlignY =  item.RightAlignY.ToString("F2");
                        string centerAlignX =  item.CenterAlignX.ToString("F2");

                        string[] row = { inspectionTime, panelID, tabNumber, judge, leftAlignX, leftAlignY, rightAlignX, rightAlignY, centerAlignX };
                        dgvAlignHistory.Rows.Add(row);

                        int tt = dgvAlignHistory.GetCellCount(DataGridViewElementStates.Selected);
                        if (tt < 0) { }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + err.Message);
            }
        }

        private delegate void ActiveDataGridViewDelegate(bool isActive);
        public void ActiveDataGridView(bool isActive)
        {
            if (this.InvokeRequired)
            {
                ActiveDataGridViewDelegate callback = ActiveDataGridView;
                BeginInvoke(callback, isActive);
                return;
            }

            dgvAlignHistory.Enabled = isActive;
        }
    }
}
