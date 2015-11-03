using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CurrencyStore.BatchInsert
{
    public partial class frmChart : Form
    {
        private List<KeyValuePair<int, int>> CountValue { get; set; }

        public frmChart()
        {
            InitializeComponent();

            this.InitializeChart();

            this.CountValue = new List<KeyValuePair<int, int>>();
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            this.chartLine.Series.Add(this.SetSeriesStyle("当前每秒插入", 0));
            this.chartLine.Series.Add(this.SetSeriesStyle("平均每秒插入", 1));
        }

        private void frmChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();

            e.Cancel = true;
        }
        
        private void InitializeChart()
        {
            #region 设置图表的属性
            //图表的背景色
            this.chartLine.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            this.chartLine.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            this.chartLine.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            this.chartLine.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            this.chartLine.BorderlineWidth = 2;
            //图表边框的皮肤
            this.chartLine.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion

            #region 设置图表的标题
            Title title = new Title()
            {
                //标题内容
                Text = "多曲线图演示",
                //标题的字体
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                //标题字体颜色
                ForeColor = Color.FromArgb(26, 59, 105),
                //标题阴影颜色
                ShadowColor = Color.FromArgb(32, 0, 0, 0),
                //标题阴影偏移量
                ShadowOffset = 3
            };

            //this.chartLine.Titles.Add(title);
            #endregion

            #region 设置图表区属性
            //图表区的名字
            ChartArea chartArea = new ChartArea("Default")
            {
                //背景色
                BackColor = Color.FromArgb(64, 165, 191, 228),
                //背景渐变方式
                BackGradientStyle = GradientStyle.TopBottom,
                //渐变和阴影的辅助背景色
                BackSecondaryColor = Color.White,
                //边框颜色
                BorderColor = Color.FromArgb(64, 64, 64, 64),
                //阴影颜色
                ShadowColor = Color.Transparent
            };

            //设置X轴和Y轴线条的颜色和宽度
            chartArea.AxisX.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.LineWidth = 1;
            chartArea.AxisY.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.LineWidth = 1;

            //设置X轴和Y轴的标题
            chartArea.AxisX.Title = "时间";//横坐标标题
            chartArea.AxisY.Title = "数据量";//纵坐标标题

            chartArea.AxisX.IntervalOffsetType = DateTimeIntervalType.Seconds;

            //设置图表区网格横纵线条的颜色和宽度
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisX.MajorGrid.LineWidth = 1;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(64, 64, 64, 64);
            chartArea.AxisY.MajorGrid.LineWidth = 1;

            chartLine.ChartAreas.Add(chartArea);
            #endregion

            #region 图例及图例的位置
            Legend legend = new Legend()
            {
                Alignment = StringAlignment.Center,
                Docking = Docking.Bottom
            };

            this.chartLine.Legends.Add(legend);
            #endregion
        }

        private Series SetSeriesStyle(string name, int index)
        {
            Series series = new Series(name);

            //Series的类型
            series.ChartType = SeriesChartType.FastLine;
            //Series的边框颜色
            series.BorderColor = Color.FromArgb(180, 26, 59, 105);
            //线条宽度
            series.BorderWidth = 1;
            //线条阴影颜色
            series.ShadowColor = Color.Black;
            //阴影宽度
            series.ShadowOffset = 0;
            //是否显示数据说明
            series.IsVisibleInLegend = true;
            //线条上数据点上是否有数据显示
            series.IsValueShownAsLabel = false;
            //线条上的数据点标志类型
            series.MarkerStyle = MarkerStyle.Circle;
            //线条数据点的大小
            series.MarkerSize = 0;
            //线条颜色
            switch (index)
            {
                case 0:
                    series.Color = Color.FromArgb(220, 65, 140, 240);
                    break;
                case 1:
                    series.Color = Color.FromArgb(220, 224, 64, 10);
                    break;
                case 2:
                    series.Color = Color.FromArgb(220, 120, 150, 20);
                    break;
            }
            return series;
        }

        public void Reset()
        {
            this.CountValue.Clear();
        }

        public void RefreshChart()
        {
            this.chartLine.Series["当前每秒插入"].Points.Clear();
            this.chartLine.Series["平均每秒插入"].Points.Clear();

            foreach (KeyValuePair<int, int> kvp in this.CountValue)
            {
                this.chartLine.Series["当前每秒插入"].Points.AddY(kvp.Key);
                this.chartLine.Series["平均每秒插入"].Points.AddY(kvp.Value);
            }
        }

        public void AddCount(int currentCount, int avgCount)
        {
            this.CountValue.Add(new KeyValuePair<int, int>(currentCount, avgCount));
        }
    }
}
