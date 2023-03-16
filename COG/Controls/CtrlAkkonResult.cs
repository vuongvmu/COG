using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using COG.Class;
using static COG.Class.InspectionResult;

namespace COG.Controls
{
    public partial class CtrlAkkonResult : UserControl
    {
        public CtrlAkkonResult()
        {
            InitializeComponent();
        }

        private delegate void UpdateAkkonInspectionHistoryDelegate(List<AkkonInspectionResult> akkonHistory, bool isUpdate);
        public void UpdateAkkonInspectionHistory(List<AkkonInspectionResult> akkonHistory, bool isUpdate)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateAkkonInspectionHistoryDelegate callback = UpdateAkkonInspectionHistory;
                    BeginInvoke(callback, akkonHistory, isUpdate);
                    return;
                }

                dgvAkkonHistory.Rows.Clear();

                if (isUpdate)
                {
                    foreach (AkkonInspectionResult item in akkonHistory)
                    {
                        string inspectionTime = item.InspectionTime.ToString();
                        string panelID = item.PanelID;
                        string tabNumber = item.TabNumber.ToString();
                        string judge = item.Judge.ToString();
                        string akkonCount = item.AkkonCount.ToString();
                        string lenght = item.Length.ToString();

                        string[] row = { inspectionTime, panelID, tabNumber, judge, akkonCount, lenght };
                        dgvAkkonHistory.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
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

            dgvAkkonHistory.Enabled = isActive;
        }

        public DataTable GetDataTable()
        {
            try
            {
                DataTable dt = new DataTable();

                for (int index = 0; index < dgvAkkonHistory.Columns.Count; index++)
                    dt.Columns.Add(dgvAkkonHistory.Columns[index].Name, dgvAkkonHistory.Columns[index].ValueType);

                for (int index = 0; index < dgvAkkonHistory.Rows.Count; index++)
                {
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dr[i] = dgvAkkonHistory.Columns;
                    }

                    dt.Rows.Add(dr);
                }
                return (DataTable)dgvAkkonHistory.DataSource;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
                return null;
            }
        }
    }
}
