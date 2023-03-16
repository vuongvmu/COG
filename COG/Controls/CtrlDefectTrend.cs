using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace COG.Controls
{
    public partial class CtrlDefectTrend : UserControl
    {
        private int _stageNo = -1;
        private int _camNo = -1;
        private int _row = -1;
        private int _col = -1;

        public CtrlGraph_Line ParticleGraphControl = null;
        public CtrlGraph_Line ShortGraphControl = null;
        public CtrlGraph_Line DimensionGraphControl = null;

        private enum eCount
        {
            Twenty = 20,
            Fifty = 50,
            Hundred = 100
        }

        public enum eResultType
        {
            Particle,
            Short,
            Dimension
        }

        public CtrlDefectTrend()
        {
            InitializeComponent();
        }

        private void CtrlDefectTrend_Load(object sender, EventArgs e)
        {
            AddControl();
        }

        private void AddControl()
        {
            ParticleGraphControl = new CtrlGraph_Line();
            ParticleGraphControl.Dock = DockStyle.Fill;
            this.pnlChartParticle.Controls.Add(ParticleGraphControl);

            ShortGraphControl = new CtrlGraph_Line();
            ShortGraphControl.Dock = DockStyle.Fill;
            this.pnlChartShort.Controls.Add(ShortGraphControl);

            DimensionGraphControl = new CtrlGraph_Line();
            DimensionGraphControl.Dock = DockStyle.Fill;
            this.pnlChartDimension.Controls.Add(DimensionGraphControl);
        }

        private void cmbStageNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _stageNo = cmbStageNo.SelectedIndex;
        }

        private void cmbCamNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _camNo = cmbCamNo.SelectedIndex;
        }

        private void cmbRowNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _row = cmbRowNo.SelectedIndex;
        }

        private void cmbColNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _col = cmbColNo.SelectedIndex;
        }

        private void btnTwenty_Click(object sender, EventArgs e)
        {
            UpdateChart(_row, _col, eCount.Twenty);
        }

        private void btnFifty_Click(object sender, EventArgs e)
        {
            UpdateChart(_row, _col, eCount.Fifty);
        }

        private void btnHundred_Click(object sender, EventArgs e)
        {
            UpdateChart(_row, _col, eCount.Hundred);
        }

        private void UpdateChart(int row, int col, eCount count)
        {
            if (_stageNo < 0 || _camNo < 0)
                return;

            if (_row < 0 || _col < 0)
                return;

            ParseDataList(LoadDataFromCSV(), count);
        }

        private Tuple<string[], List<string[]>> LoadDataFromCSV(string filePath = "")
        {
            // 임시 파일 처리
            string temp = Directory.GetCurrentDirectory() + @"\Log\CGMS_Stage1_Cam1.csv";

            return JASUtility.CSVHelper.ReadData(temp);
        }

        private void ParseDataList(Tuple<string[], List<string[]>> inputData, eCount count)
        {
            List<string[]> tab1 = new List<string[]>();
            List<string[]> tab2 = new List<string[]>();
            List<string[]> tab3 = new List<string[]>();
            List<string[]> tab4 = new List<string[]>();
            List<string[]> tab5 = new List<string[]>();

            int[,] datas = new int[5, 5];

            foreach (var item in SetRangeAndSort(inputData, (int)count))
            {
                int startIndex = 4;
                int range = 3;
                int interval = 5;

                tab1.Add(item.ToList().GetRange(startIndex, range).ToArray());
                startIndex += interval;

                tab2.Add(item.ToList().GetRange(startIndex, range).ToArray());
                startIndex += interval;

                tab3.Add(item.ToList().GetRange(startIndex, range).ToArray());
                startIndex += interval;

                tab4.Add(item.ToList().GetRange(startIndex, range).ToArray());
                startIndex += interval;

                tab5.Add(item.ToList().GetRange(startIndex, range).ToArray());
            }

            //if (tabNumber == 0)
            //{
            //    ParticleGraphControl.UpdateTrendData(tab1, eResultType.Particle);
            //    ShortGraphControl.UpdateTrendData(tab1, eResultType.Short);
            //    DimensionGraphControl.UpdateTrendData(tab1, eResultType.Dimension);
            //}
            //else if (tabNumber == 1)
            //{
            //    GraphControl_X.UpdateTrendData(tab2, eAlignType.Align_X);
            //    GraphControl_Y.UpdateTrendData(tab2, eAlignType.Align_Y);
            //}
            //else if (tabNumber == 2)
            //{
            //    GraphControl_X.UpdateTrendData(tab3, eAlignType.Align_X);
            //    GraphControl_Y.UpdateTrendData(tab3, eAlignType.Align_Y);
            //}
            //else if (tabNumber == 3)
            //{
            //    GraphControl_X.UpdateTrendData(tab4, eAlignType.Align_X);
            //    GraphControl_Y.UpdateTrendData(tab4, eAlignType.Align_Y);
            //}
            //else if (tabNumber == 4)
            //{
            //    GraphControl_X.UpdateTrendData(tab5, eAlignType.Align_X);
            //    GraphControl_Y.UpdateTrendData(tab5, eAlignType.Align_Y);
            //}
            //else
            //    return;
        }

        private List<string[]> SetRangeAndSort(Tuple<string[], List<string[]>> inputData, int count)
        {
            if (inputData == null)
                return null;

            string[] header = inputData.Item1;
            List<string[]> contents = inputData.Item2;
            List<string[]> readData = new List<string[]>();

            contents.Reverse();

            int numberOfLoop = 0;
            foreach (var item in contents)
            {
                if (numberOfLoop < (int)count)
                {
                    readData.Add(item);
                    numberOfLoop++;
                }
            }

            readData.Reverse();

            return readData;
        }

        
    }
}
