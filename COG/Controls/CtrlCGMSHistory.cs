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
    public partial class CtrlCGMSHistory : UserControl
    {
        public List<CtrlCGMSResult> CGMSResultControlList = new List<CtrlCGMSResult>();
        public List<CtrlLogViewer> CGMSLogViewerControlList = new List<CtrlLogViewer>();

        public CtrlCGMSHistory()
        {
            InitializeComponent();
        }

        private void CtrlCGMSHistory_Load(object sender, EventArgs e)
        {
            AddControl();
        }

        private void AddControl()
        {
            TabPage tp = null;

            // PJH_TEST_20230306_S
            for (int unitIndex = 0; unitIndex < Main.DEFINE.PJH_TEST_UNIT_COUNT; unitIndex++)
            {
                string tempText = string.Empty;
                if (unitIndex == 0)
                    tempText = "PREALIGN1 - CAM1";
                else if (unitIndex == 1)
                    tempText = "STAGE1 - CAM2";
                // PJH_TEST_20230306_E

                string pageName = tempText;
                tp = new TabPage(pageName);
                tp.BackColor = Color.Silver;

                // Create TableLayoutPanel
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.Dock = DockStyle.Fill;
                tlp.RowStyles.Clear();
                tlp.ColumnStyles.Clear();

                tlp.RowCount = 1;
                tlp.ColumnCount = 2;

                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / tlp.RowCount));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / tlp.ColumnCount));

                // Create contents in TableLayoutPanel
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                CtrlCGMSResult resultControl = new CtrlCGMSResult();
                tlp.Controls.Add(resultControl, 0, 0);
                resultControl.Dock = DockStyle.Fill;
                CGMSResultControlList.Add(resultControl);

                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                CtrlLogViewer logViewerControl = new CtrlLogViewer();
                tlp.Controls.Add(logViewerControl, 1, 0);
                logViewerControl.Dock = DockStyle.Fill;
                CGMSLogViewerControlList.Add(logViewerControl);

                // Add Controls in TabPages
                tp.Controls.Add(tlp);
                tabCGMSHistory.TabPages.Add(tp);
            }
        }
    }
}
