using JASUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class
{
    public class CSVManager
    {
        private static CSVManager _instance = null;
        public static CSVManager Instance()
        {
            if (_instance == null)
                _instance = new CSVManager();

            return _instance;
        }

        public void AddResult(InspectionResult.AkkonInspectionResult akkonHistory)
        {
            List<string> historyItems = new List<string>();

            historyItems.Add(akkonHistory.InspectionTime.ToString());
            historyItems.Add(akkonHistory.PanelID);
            historyItems.Add(akkonHistory.TabNumber.ToString());
            historyItems.Add(akkonHistory.Judge.ToString());
            historyItems.Add(akkonHistory.AkkonCount.ToString());
            historyItems.Add(akkonHistory.Length.ToString());

            CSVHelper.WriteData(InspectionResult.AkkonInspectionResult.HistoryName, historyItems);
        }

        public void AddResult(InspectionResult.AlignInspectionResult alignHistory)
        {
            List<string> historyItems = new List<string>();

            historyItems.Add(alignHistory.InspectionTime.ToString());
            historyItems.Add(alignHistory.PanelID);
            historyItems.Add(alignHistory.TabNumber.ToString());
            historyItems.Add(alignHistory.Judge.ToString());
            historyItems.Add(alignHistory.LeftAlignX.ToString());
            historyItems.Add(alignHistory.LeftAlignY.ToString());
            historyItems.Add(alignHistory.RightAlignX.ToString());
            historyItems.Add(alignHistory.RightAlignY.ToString());
            historyItems.Add(alignHistory.CenterAlignX.ToString());

            CSVHelper.WriteData(InspectionResult.AlignInspectionResult.HistoryName, historyItems);
        }
    }
}
