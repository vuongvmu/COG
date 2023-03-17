using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COG.Class
{
    public class InspectionResult
    {
        public enum eInspectionResult
        {
            NG,
            OK,
        }

        public class AkkonInspectionResult
        {
            private string _inspectionTime = DateTime.Now.ToString();
            public string InspectionTime
            {
                get { return _inspectionTime; }
                set { _inspectionTime = value; }
            }

            private string _panelID = "Empty";
            public string PanelID
            {
                get { return _panelID; }
                set { _panelID = value; }
            }

            private int _tabNumber = 0;
            public int TabNumber
            {
                get { return _tabNumber; }
                set { _tabNumber = value; }
            }

            private eInspectionResult _judge = eInspectionResult.OK;
            public eInspectionResult Judge
            {
                get { return _judge; }
                set { _judge = value; }
            }

            private int _akkonCount = 0;
            public int AkkonCount
            {
                get { return _akkonCount; }
                set { _akkonCount = value; }
            }

            private double _length = 0.0;
            public double Length
            {
                get { return _length; }
                set { _length = value; }
            }

            public static string HistoryName = "AkkonHistory";
            //public static List<string> CSVHeader = new List<string> { "InspectionTime", "PanelID", "TabNumber", "Judge", "AkkonCount", "Lenght" };
            public static List<string> CSVHeader = new List<string> { "Time", "Panel ID", "Tab", "Judge", "Count", "Lenght" };
        }

        public class AlignInspectionResult
        {
            private string _inspectionTime = DateTime.Now.ToString();
            public string InspectionTime
            {
                get { return _inspectionTime; }
                set { _inspectionTime = value; }
            }

            private string _panelID = "Empty";
            public string PanelID
            {
                get { return _panelID; }
                set { _panelID = value; }
            }

            private int _tabNumber = 0;
            public int TabNumber
            {
                get { return _tabNumber; }
                set { _tabNumber = value; }
            }

            private eInspectionResult _judge = eInspectionResult.OK;
            public eInspectionResult Judge
            {
                get { return _judge; }
                set { _judge = value; }
            }

            private double _leftAlignX = 0.0;
            public double LeftAlignX
            {
                get { return _leftAlignX; }
                set { _leftAlignX = value; }
            }

            private double _leftAlignY = 0.0;
            public double LeftAlignY
            {
                get { return _leftAlignY; }
                set { _leftAlignY = value; }
            }

            private double _rightAlignX = 0.0;
            public double RightAlignX
            {
                get { return _rightAlignX; }
                set { _rightAlignX = value; }
            }

            private double _rightAlignY = 0.0;
            public double RightAlignY
            {
                get { return _rightAlignY; }
                set { _rightAlignY = value; }
            }

            private double _centerAlignX = 0.0;
            public double CenterAlignX
            {
                get { return _centerAlignX; }
                set { _centerAlignX = value; }
            }

            public static string HistoryName = "AlignHistory";
            public static List<string> CSVHeader = new List<string> { "Time", "Panel ID", "Tab", "Judge", "LX", "LY", "RX", "RY", "CX" };
        }

        public class PreAlignInspectionResult
        {
            public string InspectionTime { get; set; } = DateTime.Now.ToString();

            public string PanelID { get; set; } = string.Empty;

            public int StageNumber { get; set; } = 0;

            public double X { get; set; } = 0.0;

            public double Y { get; set; } = 0.0;

            public double T { get; set; } = 0.0;
        }

        public class TrendResult
        {
            private string _inspectionTime = DateTime.Now.ToString();
            public string InspectionTime
            {
                get { return _inspectionTime; }
                set { _inspectionTime = value; }
            }

            //public static string TrendName = "Trend";
            public static string TrendName = "Align";
            public static List<string> CSVHeader = new List<string> { "Align Time", "Cell ID", "FBT STG", "Vibration", "Result", "Stage", "LX", "LY", "CX", "RX", "RY" };
        }

        public class BlobInspectionResult
        {
            private string _inspectionTime = DateTime.Now.ToString();
            public string InspectionTime
            {
                get { return _inspectionTime; }
                set { _inspectionTime = value; }
            }

            private string _productID = "";
            public string ProductID
            {
                get { return _productID; }
                set { _productID = value; }
            }

            private int _tabNumber = 0;
            public int TabNumber
            {
                get { return _tabNumber; }
                set { _tabNumber = value; }
            }

            private eInspectionResult _judge = eInspectionResult.OK;
            public eInspectionResult Judge
            {
                get { return _judge; }
                set { _judge = value; }
            }

            public static string HistoryName = "BlobHistory";
            public static List<string> CSVHeader = new List<string> { "Time", "Product ID", "Tab", "Judge"};
        }

        public class CGMSInspectionResult
        {
            public int No { get; set; } = 0;

            public eInspectionResult Judge { get; set; } = eInspectionResult.OK;

            public int ParticleCount { get; set; } = 0;

            public double Dimension { get; set; } = 0.0;

            public int ShortCount { get; set; } = 0;

            public static string HistoryName = "CGMSHistory";
            public static List<string> CSVHeader = new List<string> { "No", "Result", "Particle Count", "Dimension", "Short Count"};
        }
    }
}
