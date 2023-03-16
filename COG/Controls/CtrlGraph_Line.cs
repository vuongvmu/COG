﻿using System;
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

namespace COG.Controls
{
    public partial class CtrlGraph_Line : UserControl
    {
        //public CtrlAkkonHistory AkkonHistoryControl = null;
        public enum eChartContents
        {
            Akkon,
            Align,
        }

        private RectangleF _drawChartRectangle = new RectangleF();
        private int _axisXInterval = 80;
        private int _axisYInterval = 30;
        private int _percentCount = 4;//X축 레이블 Count
        private int _resultCount = 2;//Y축 레이블 Count
        private int _xRectInterval = 30;//Form의 우측 끝부분 부터 _DrawChartRect와의 거리
        private int _yRectInterval = 20;//Form의 하단부터 _DrawChartRect와의 거리
        public System.Windows.Forms.DataVisualization.Charting.Series Chart1;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart2;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart3;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart4;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart5;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart6;
        public System.Windows.Forms.DataVisualization.Charting.Series Chart7;
        public CtrlGraph_Line()
        {
            InitializeComponent();
        }

        //private void CtrlGraph_Load(object sender, EventArgs e)
        //{
        //    //CreateObject();
        //}

        //private void CreateObject()
        //{
        //    AkkonHistoryControl = new CtrlAkkonHistory();
        //}

        public void ClearChart()
        {
            chart1.Series.Clear();
        }

        public void UpdateTrendData(List<string[]> readData, CtrlAlignTrend.eAlignType alignType)
        {
            chart1.Series.Clear();

            switch (alignType)
            {
                case CtrlAlignTrend.eAlignType.Align_X:
                    System.Windows.Forms.DataVisualization.Charting.Series Chart1 = chart1.Series.Add("Lx");
                    System.Windows.Forms.DataVisualization.Charting.Series Chart3 = chart1.Series.Add("Rx");
                    System.Windows.Forms.DataVisualization.Charting.Series Chart5 = chart1.Series.Add("Cx");

                    Chart1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    Chart1.Color = Color.Red;
                    Chart3.Color = Color.Blue;
                    Chart5.Color = Color.Purple;

                    for (int i = 0; i < readData.Count; i++)
                    {
                        double Lx = Convert.ToDouble(readData[i][0]);
                        double Rx = Convert.ToDouble(readData[i][2]);
                        double Cx = Convert.ToDouble(readData[i][4]);

                        Chart1.Points.AddXY(i, Lx);
                        Chart3.Points.AddXY(i, Rx);
                        Chart5.Points.AddXY(i, Cx);
                    }

                    break;

                case CtrlAlignTrend.eAlignType.Align_Y:
                    System.Windows.Forms.DataVisualization.Charting.Series Chart2 = chart1.Series.Add("Ly");
                    System.Windows.Forms.DataVisualization.Charting.Series Chart4 = chart1.Series.Add("Ry");

                    Chart2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    Chart2.Color = Color.Green;
                    Chart4.Color = Color.Yellow;

                    for (int i = 0; i < readData.Count; i++)
                    {
                        double Ly = Convert.ToDouble(readData[i][1]);
                        double Ry = Convert.ToDouble(readData[i][3]);

                        Chart2.Points.AddXY(i, Ly);
                        Chart4.Points.AddXY(i, Ry);
                    }

                    break;

                default:
                    break;
            }
        }

        public void UpdateTrendData(List<string[]> readData, CtrlDefectTrend.eResultType resultType)
        {

        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            //DrawChart();
        }

        private void DrawChart()
        {
            try
            {
                using (Graphics g = pnlChart.CreateGraphics())
                {
                    g.Clear(SystemColors.Control);

                    DrawBaseLine(g);

                    SetDrawChartRect();

                    //DrawRatioRectangle(g);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private Font GetFontStyle(int fontSize, FontStyle fontStyle)
        {
            Font font = new Font("맑은 고딕", fontSize, fontStyle);

            return font;
        }

        private void SetDrawChartRect()
        {
            _drawChartRectangle = new RectangleF(_axisXInterval, _axisYInterval, (pnlChart.Width - _axisXInterval - _xRectInterval) - _xRectInterval, pnlChart.Height - _axisYInterval);
        }

        private void DrawRatioRectangle(Graphics g)
        {
            try
            {
                //DataTable dt = AkkonHistoryControl.GetDataTable();
                //if (dt == null)
                //    return;

                //Y축에서 그래프간의 간격
                float rectInterval = (float)(_drawChartRectangle.Height - _axisYInterval) / 7;

                float okRectTop = _drawChartRectangle.Y + (float)rectInterval * 1;
                float ngRectTop = _drawChartRectangle.Y + (float)rectInterval * 3;
                float warningRectTop = _drawChartRectangle.Y + (float)rectInterval * 5;

                
                /*
                //OK, NG, WARNING 그래프 길이(나중에 가져와야할 값)
                float ok = (float)(Status.Instance().OkCount / (float)Status.Instance().TotalCount) * (float)100;
                float ng = (float)(Status.Instance().NgCount / (float)Status.Instance().TotalCount) * (float)100;
                float warning = (float)(Status.Instance().WarningCount / (float)Status.Instance().TotalCount) * (float)100;

                //OK
                g.FillRectangle(new SolidBrush(Color.MediumSeaGreen), new RectangleF(_drawChartRectangle.X, okRectTop, GetRatioPosition(ok, _drawChartRectangle.Width), rectInterval));
                //OK Graph수치 값
                string okPercentString = (Convert.ToDouble((double)Status.Instance().OkCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float okPercentRectTop = _drawChartRectangle.Y + (float)rectInterval + ((float)rectInterval / 2);
                float okPercentHeight = g.MeasureString(okPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF okPercentPoint = new PointF(_drawChartRectangle.X + GetRatioPosition(ok, _drawChartRectangle.Width), okPercentRectTop - (okPercentHeight / 2));
                g.DrawString(okPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, okPercentPoint);

                //NG
                g.FillRectangle(new SolidBrush(Color.Red), new RectangleF(_drawChartRectangle.X, ngRectTop, GetRatioPosition(ng, _drawChartRectangle.Width), rectInterval));
                //NG Graph수치 값
                string ngPercentString = (Convert.ToDouble((double)Status.Instance().NgCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float ngPercentRectTop = _drawChartRectangle.Y + (float)rectInterval * 3 + ((float)rectInterval / 2);
                float ngPercentHeight = g.MeasureString(ngPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF ngPercentPoint = new PointF(_drawChartRectangle.X + GetRatioPosition(ng, _drawChartRectangle.Width), ngPercentRectTop - (ngPercentHeight / 2));
                g.DrawString(ngPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, ngPercentPoint);

                //Warning
                g.FillRectangle(new SolidBrush(Color.Orange), new RectangleF(_drawChartRectangle.X, warningRectTop, GetRatioPosition(warning, _drawChartRectangle.Width), rectInterval));
                //Warning Graph수치 값
                string warningPercentString = (Convert.ToDouble((double)Status.Instance().WarningCount / (double)Status.Instance().TotalCount) * 100).ToString("F2") + "%";
                float warningPercentRectTop = _drawChartRectangle.Y + (float)rectInterval * 5 + ((float)rectInterval / 2);
                float warningPercentHeight = g.MeasureString(warningPercentString, GetFontStyle(7, FontStyle.Bold)).Height;
                PointF warningPercentPoint = new PointF(_drawChartRectangle.X + GetRatioPosition(warning, _drawChartRectangle.Width), warningPercentRectTop - (warningPercentHeight / 2));
                g.DrawString(warningPercentString, GetFontStyle(7, FontStyle.Bold), Brushes.Black, warningPercentPoint);
                /**/
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }

        private float GetRatioPosition(float ratio, float length)//그래프의 비율 구하기
        {
            float pos = (float)length / 100 * ratio;
            return pos;
        }

        private void DrawBaseLine(Graphics g)
        {
            try
            {
                g.DrawString("Time", GetFontStyle(10, FontStyle.Bold), Brushes.Black, new PointF(pnlChart.Width / 2, pnlChart.Height - 6));
                //for (int i = 0; i < _count; i++)
                //{
                //    double Lx = Convert.ToDouble(_readData.Item2[i][4]);
                //    double Ly = Convert.ToDouble(_readData.Item2[i][5]);
                //    double Rx = Convert.ToDouble(_readData.Item2[i][6]);
                //    double Ry = Convert.ToDouble(_readData.Item2[i][7]);
                //    double Cx = Convert.ToDouble(_readData.Item2[i][8]);
                //}

                //g.DrawLine(pen, new PointF(_axisXInterval, pnlChart.Height - _axisYInterval), new PointF(pnlChart.Width - _xRectInterval, pnlChart.Height - _axisYInterval));
                //g.DrawLine(pen, new PointF(_axisXInterval, _yRectInterval), new PointF(_axisXInterval, pnlChart.Height - _axisYInterval));
                //g.DrawString("Time", GetFontStyle(10, FontStyle.Bold), Brushes.Black, new PointF(pnlChart.Width / 2, pnlChart.Height - 6));
            }
            catch (Exception ex)
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name.ToString() + " : " + ex.Message);
            }
        }
        public void Initialize(eChartContents contents)
        {
            switch (contents)
            {
                case eChartContents.Akkon:
                    Chart1 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart1 = chart1.Series.Add("Count");
                    //= chart1.Series.Add("Count");
                    Chart2 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart2 = chart1.Series.Add("Length");

                    Chart1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    Chart1.Color = Color.Blue;
                    Chart2.Color = Color.Purple;
                    break;
                case eChartContents.Align:
                    Chart3 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart3 = chart1.Series.Add("Lx");
                    Chart4 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart4 = chart1.Series.Add("Ly");
                    Chart5 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart5 = chart1.Series.Add("Rx");
                    Chart6 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart6 = chart1.Series.Add("Ry");
                    Chart7 = new System.Windows.Forms.DataVisualization.Charting.Series();
                    Chart7 = chart1.Series.Add("Cx");

                    Chart3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    Chart7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                    Chart3.Color = Color.Red;
                    Chart4.Color = Color.Green;
                    Chart5.Color = Color.Blue;
                    Chart6.Color = Color.Yellow;
                    Chart7.Color = Color.Purple;
                    break;
                default:
                    break;
            }
          

        
        }
        public void DrawChart(eChartContents contents, List<object> obj)
        {
            //chart1.Series.Clear();

            List<InspectionResult.AkkonInspectionResult> akkonList = new List<InspectionResult.AkkonInspectionResult>();
            List<InspectionResult.AlignInspectionResult> alignList = new List<InspectionResult.AlignInspectionResult>();

            switch (contents)
            {
                case eChartContents.Akkon:
                    akkonList = obj.Cast<InspectionResult.AkkonInspectionResult>().ToList();

                   

                    foreach (var item in akkonList)
                    {
                        Chart1.Points.AddXY(item.InspectionTime.Substring(5), item.AkkonCount);
                        Chart2.Points.AddXY(item.InspectionTime.Substring(5), item.Length);
                    }
                    break;
                case eChartContents.Align:
                    alignList = obj.Cast<InspectionResult.AlignInspectionResult>().ToList();

                   

                    foreach (var item in alignList)
                    {
                        Chart3.Points.AddXY(item.InspectionTime.Substring(5), item.LeftAlignX);
                        Chart4.Points.AddXY(item.InspectionTime.Substring(5), item.LeftAlignY);
                        Chart5.Points.AddXY(item.InspectionTime.Substring(5), item.RightAlignX);
                        Chart6.Points.AddXY(item.InspectionTime.Substring(5), item.RightAlignY);
                        Chart7.Points.AddXY(item.InspectionTime.Substring(5), item.CenterAlignX);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
