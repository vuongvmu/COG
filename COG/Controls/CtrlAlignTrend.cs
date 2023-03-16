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
using System.IO;

namespace COG.Controls
{
    //public delegate void MyEventHander(bool isSelected);
    //public class Publisher
    //{
    //    public event MyEventHander MyEvent;
    //    public void Do(bool tt)
    //    {
    //        if (MyEvent == null)
    //            return;

    //        if (tt)
    //            MyEvent(tt);
    //    }
    //}
    

    //public class DoOrder
    //{
    //    public event EventHandler OnOderReply;
    //    public class OrderReplyEventArgs : EventArgs
    //    {
    //        public bool ook;
    //    }
    //    public void testEvent()
    //    {
    //        OrderReplyEventArgs arg = new OrderReplyEventArgs();
    //        arg.ook = true;
    //        this.OnOderReply(this, arg);
    //    }
    //}

    public partial class CtrlAlignTrend : UserControl
    {
        public List<CtrlTabButton> tabButtonList = new List<CtrlTabButton>();
        public CtrlGraph_Line GraphControl_X = null;
        public CtrlGraph_Line GraphControl_Y = null;

        private int _tabNumber = -1;
        private bool _isAll = false;

        private enum eCount
        {
            Twenty = 20,
            Fifty = 50,
            Hundred = 100
        }

        public enum eAlignType
        {
            Align_X,
            Align_Y
        }

        public CtrlAlignTrend()
        {
            InitializeComponent();
        }

        private void CtrlTrend_Load(object sender, EventArgs e)
        {
            AddControl();
        }
        
        public void MakeDisplay(int tabCount)
        {
            try
            {
                int controlWidth = this.pnlTabButton.Width / tabCount;
                Point point = new Point(0, 0);

                for (int i = 0; i < tabCount; i++)
                {
                    CtrlTabButton buttonControl = new CtrlTabButton(i);
                    buttonControl.SendEventHandler += new CtrlTabButton.SetTabNumberDelegate(ReceiveTabNumber);
                    buttonControl.Size = new Size(controlWidth, this.pnlTabButton.Height);
                    buttonControl.Location = point;
                    this.pnlTabButton.Controls.Add(buttonControl);
                    point.X += controlWidth;

                    tabButtonList.Add(buttonControl);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        
        private void ReceiveTabNumber(bool selected, int tabNumber)
        {
            if (_tabNumber != tabNumber)
            {
                GraphControl_X.ClearChart();
                GraphControl_Y.ClearChart();
                _tabNumber = tabNumber;

                foreach (var item in tabButtonList)
                    item.SetButtonStatus(false);

                tabButtonList[tabNumber].SetButtonStatus(true);
            }
        }


        private void AddControl()
        {
            GraphControl_X = new CtrlGraph_Line();
            GraphControl_X.Dock = DockStyle.Fill;
            this.pnlChartAlignX.Controls.Add(GraphControl_X);

            GraphControl_Y = new CtrlGraph_Line();
            GraphControl_Y.Dock = DockStyle.Fill;
            this.pnlChartAlignY.Controls.Add(GraphControl_Y);
        }

        private void btnThity_Click(object sender, EventArgs e)
        {
            UpdateChart(_tabNumber, eCount.Twenty);
        }

        private void btnFifty_Click(object sender, EventArgs e)
        {
            UpdateChart(_tabNumber, eCount.Fifty);
        }

        private void btnHundred_Click(object sender, EventArgs e)
        {
            UpdateChart(_tabNumber, eCount.Hundred);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAll.Checked)
            //{
            //    _isAll = true;
            //    _buttonSeledted = true;

            //    GraphControl_X.ClearChart();
            //    GraphControl_Y.ClearChart();
            //}
            //else
            //{
            //    _isAll = false;
            //    _buttonSeledted = false;

            //    GraphControl_X.ClearChart();
            //    GraphControl_Y.ClearChart();
            //}
        }

        private void UpdateChart(int tabNumber, eCount count)
        {
            if (tabNumber < 0)
                return;

            ParseDataList(LoadDataFromCSV(), tabNumber, count);
        }

        private Tuple<string[], List<string[]>> LoadDataFromCSV(string filePath = "")
        {
            // 임시 파일 처리
            string temp = Directory.GetCurrentDirectory() + @"\Log\AlignInspection_Stage1_Top.csv";

            return JASUtility.CSVHelper.ReadData(temp);
        }

        private void ParseDataList(Tuple<string[], List<string[]>> inputData, int tabNumber, eCount count)
        {
            if (!_isAll)
            {
                List<string[]> tab1 = new List<string[]>();
                List<string[]> tab2 = new List<string[]>();
                List<string[]> tab3 = new List<string[]>();
                List<string[]> tab4 = new List<string[]>();
                List<string[]> tab5 = new List<string[]>();

                foreach (var item in SetRangeAndSort(inputData, (int)count))
                {
                    int startIndex = 4;
                    int range = 5;
                    int interval = 7;

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

                if (tabNumber == 0)
                {
                    GraphControl_X.UpdateTrendData(tab1, eAlignType.Align_X);
                    GraphControl_Y.UpdateTrendData(tab1, eAlignType.Align_Y);
                }
                else if (tabNumber == 1)
                {
                    GraphControl_X.UpdateTrendData(tab2, eAlignType.Align_X);
                    GraphControl_Y.UpdateTrendData(tab2, eAlignType.Align_Y);
                }
                else if (tabNumber == 2)
                {
                    GraphControl_X.UpdateTrendData(tab3, eAlignType.Align_X);
                    GraphControl_Y.UpdateTrendData(tab3, eAlignType.Align_Y);
                }
                else if (tabNumber == 3)
                {
                    GraphControl_X.UpdateTrendData(tab4, eAlignType.Align_X);
                    GraphControl_Y.UpdateTrendData(tab4, eAlignType.Align_Y);
                }
                else if (tabNumber == 4)
                {
                    GraphControl_X.UpdateTrendData(tab5, eAlignType.Align_X);
                    GraphControl_Y.UpdateTrendData(tab5, eAlignType.Align_Y);
                }
                else
                    return;
            }
            else
            {
                List<string[]> allTab = new List<string[]>();
                foreach (var item in SetRangeAndSort(inputData, (int)count))
                {
                    int startIndex = 4;
                    int range = 5;
                    int interval = 7;

                    allTab.Add(item.ToList().GetRange(startIndex, range).ToArray());
                    startIndex += interval;

                    allTab.Add(item.ToList().GetRange(startIndex, range).ToArray());
                    startIndex += interval;

                    allTab.Add(item.ToList().GetRange(startIndex, range).ToArray());
                    startIndex += interval;

                    allTab.Add(item.ToList().GetRange(startIndex, range).ToArray());
                    startIndex += interval;

                    allTab.Add(item.ToList().GetRange(startIndex, range).ToArray());
                }

                GraphControl_X.UpdateTrendData(allTab, eAlignType.Align_X);
                GraphControl_Y.UpdateTrendData(allTab, eAlignType.Align_Y);
            }
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
