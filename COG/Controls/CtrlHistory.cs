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
using static COG.Class.InspectionResult;
using System.Reflection;
using System.IO;
using JASUtility;

namespace COG.Controls
{
    public partial class CtrlHistory : UserControl
    {
        private List<AkkonInspectionResult> _akkonResultList = new List<AkkonInspectionResult>();
        private List<AlignInspectionResult> _alignResultList = new List<AlignInspectionResult>();

        private eResultType _resultType = eResultType.Akkon;

        public enum eResultType
        {
            Align,
            Akkon,
            Blob,
        }

        public CtrlHistory(eResultType resultType)
        {
            InitializeComponent();

            _resultType = resultType;
        }

        private void CtrlHistory_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            InitializeUI();
        }

        private void InitializeUI()
        {
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dgvHistory.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHistory.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHistory.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvHistory.MultiSelect = false;
        }

        private void InitializeDataGridView()
        {
            try
            {
                switch (_resultType)
                {
                    case eResultType.Align:
                        GetCSVData(CSVHelper.GetCsvPath(InspectionResult.AlignInspectionResult.HistoryName));
                        break;

                    case eResultType.Akkon:
                        GetCSVData(CSVHelper.GetCsvPath(InspectionResult.AkkonInspectionResult.HistoryName));
                        break;

                    case eResultType.Blob:
                        GetCSVData(CSVHelper.GetCsvPath(InspectionResult.BlobInspectionResult.HistoryName));
                        break;

                    default:
                        break;
                }
                
                DataSourceGridView();
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private void DataSourceGridView()
        {
            dgvHistory.DataSource = GetDataTable();
        }

        private DataTable GetDataTable()
        {
            DataTable dt = new DataTable();

            CreateColumn(dt);
            CreateRow(dt);

            return dt;
        }

        private void CreateColumn(DataTable dt)
        {
            for (int index = 0; index < AkkonInspectionResult.CSVHeader.Count; index++)
                dt.Columns.Add(AkkonInspectionResult.CSVHeader[index]);

            for (int index = 0; index < AlignInspectionResult.CSVHeader.Count; index++)
                dt.Columns.Add(AlignInspectionResult.CSVHeader[index]);
        }

        private void CreateRow(DataTable dt)
        {
            for (int index = 0; index < _akkonResultList.Count; index++)
            {
                dt.Rows.Add(new string[] { _akkonResultList[index].InspectionTime.ToString(),
                                            _akkonResultList[index].PanelID,
                                            _akkonResultList[index].TabNumber.ToString(),
                                            _akkonResultList[index].Judge.ToString(),
                                            _akkonResultList[index].AkkonCount.ToString(),
                                            _akkonResultList[index].Length.ToString()});
            }

            for (int index = 0; index < _alignResultList.Count; index++)
            {
                dt.Rows.Add(new string[] { _alignResultList[index].InspectionTime.ToString(),
                                            _alignResultList[index].PanelID,
                                            _alignResultList[index].TabNumber.ToString(),
                                            _alignResultList[index].Judge.ToString(),
                                            _alignResultList[index].LeftAlignX.ToString(),
                                            _alignResultList[index].LeftAlignY.ToString(),
                                            _alignResultList[index].RightAlignX.ToString(),
                                            _alignResultList[index].RightAlignY.ToString(),
                                            _alignResultList[index].CenterAlignX.ToString()});
            }
        }

        private void GetCSVData(string fileName)
        {
            try
            {
                using (var sr = new StreamReader(fileName, Encoding.Default, true))
                {
                    while (!sr.EndOfStream)
                    {
                        string array = sr.ReadLine();
                        string[] values = array.Split(',');

                        if (values[0].Contains("Time"))
                            continue;

                        AkkonInspectionResult t1 = new AkkonInspectionResult();
                        _akkonResultList.Add(SetData(t1, values));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private AkkonInspectionResult SetData(AkkonInspectionResult akkonResult, string[] values)
        {
            try
            {
                akkonResult.InspectionTime = values[0];
                akkonResult.PanelID = values[1];
                akkonResult.TabNumber = Convert.ToInt16(values[2]);
                akkonResult.Judge = (eInspectionResult)Enum.Parse(typeof(eInspectionResult), values[3]);
                akkonResult.AkkonCount = Convert.ToInt16(values[4]);
                akkonResult.Length = Convert.ToDouble(values[5]);

                return akkonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
                return null;
            }
        }

        private AlignInspectionResult SetData(AlignInspectionResult alignResult, string[] values)
        {
            try
            {
                alignResult.InspectionTime = values[0];
                alignResult.PanelID = values[1];
                alignResult.TabNumber = Convert.ToInt16(values[2]);
                alignResult.Judge = (eInspectionResult)Enum.Parse(typeof(eInspectionResult), values[3]);
                alignResult.LeftAlignX = Convert.ToInt16(values[4]);
                alignResult.LeftAlignY = Convert.ToDouble(values[5]);
                alignResult.RightAlignX = Convert.ToInt16(values[6]);
                alignResult.RightAlignY = Convert.ToInt16(values[7]);
                alignResult.CenterAlignX = Convert.ToInt16(values[8]);

                return alignResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
                return null;
            }
        }

        private BlobInspectionResult SetData(BlobInspectionResult blobResult, string[] values)
        {
            try
            {
                blobResult.InspectionTime = values[0];
                blobResult.ProductID = values[1];
                blobResult.TabNumber = Convert.ToInt16(values[2]);
                blobResult.Judge = (eInspectionResult)Enum.Parse(typeof(eInspectionResult), values[3]);

                return blobResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
                return null;
            }
        }
    }
}
