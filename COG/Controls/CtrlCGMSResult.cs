using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static COG.Class.InspectionResult;
using System.Reflection;
using JASUtility;
using COG.Class;

namespace COG.Controls
{
    public partial class CtrlCGMSResult : UserControl
    {
        public CtrlCGMSResult()
        {
            InitializeComponent();
        }

        private void CtrlCGMSHistory_Load(object sender, EventArgs e)
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            // 동작 안되네...
            dgvCGMSHistory.CurrentCell = null;
            dgvCGMSHistory.ClearSelection();

            //dgvCGMSHistory.EnableHeadersVisualStyles = false;
            //dgvCGMSHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        }

        private delegate void UpdateCGMSInspectionHistoryDelegate(List<CGMSInspectionResult> cgmsHistory, bool isUpdate);
        public void UpdateCGMSInspectionHistory(List<CGMSInspectionResult> cgmsHistory, bool isUpdate)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UpdateCGMSInspectionHistoryDelegate callback = UpdateCGMSInspectionHistory;
                    BeginInvoke(callback, cgmsHistory, isUpdate);
                    return;
                }

                //dgvCGMSHistory.Rows.Clear();
             
                if (isUpdate)
                {
                    UpdateCGMSInspection(cgmsHistory);
                    WriteCGMS_CSV(cgmsHistory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void UpdateCGMSInspection(List<CGMSInspectionResult> cgmsHistory)
        {
            int rowCount = dgvCGMSHistory.Rows.Count;
            // 일단 이렇게함
            if (rowCount >= 6) dgvCGMSHistory.Rows.Clear();
            foreach (CGMSInspectionResult item in cgmsHistory)
            {
                string no = item.No.ToString();
                string result = item.Judge.ToString();
                string particleCount = item.ParticleCount.ToString();
                string dimension = item.Dimension.ToString("F3");
                string shortCount = item.ShortCount.ToString();

                string[] row = { no, result, particleCount, dimension, shortCount };
                dgvCGMSHistory.Rows.Add(row);

                if (result == eInspectionResult.NG.ToString())
                    dgvCGMSHistory.Rows[rowCount].DefaultCellStyle.BackColor = Color.Red;

                rowCount++;
            }
        }

        private void WriteCGMS_CSV(List<CGMSInspectionResult> cgmsHistory)
        {
            string tempPath;
            tempPath = Main.DEFINE.SYS_DATADIR + Main.DEFINE.LOG_DATADIR + DateTime.Now.ToString("yyyyMMdd") + "\\" + Main.DEFINE.INSPECTIONLOG_CSVDIR + "Inspection Data.csv";
            CSVHelper.Initialize(tempPath);
            CSVHelper.WriteHeader(InspectionResult.CGMSInspectionResult.HistoryName, InspectionResult.CGMSInspectionResult.CSVHeader);

            List<string> historyItems = new List<string>();

            foreach (var item in cgmsHistory)
            {
                historyItems.Add(item.No.ToString());
                historyItems.Add(item.Judge.ToString());
                historyItems.Add(item.ParticleCount.ToString());
                historyItems.Add(item.Dimension.ToString());
                historyItems.Add(item.ShortCount.ToString());
                CSVHelper.WriteData(InspectionResult.AkkonInspectionResult.HistoryName, historyItems);
            }
        }
    }
}
