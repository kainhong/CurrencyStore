using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyStore.Collector;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.BatchInsert
{
    public partial class frmMain : Form
    {
        private frmChart ChartForm { get; set; }
        private IList<Batcher> BatcherList;
        private int TargetCurrencyCount;
        private DateTime StartTime { get; set; }
        private int LastSecondCount { get; set; }
        private int MaxSecondCount { get; set; }

        public frmMain()
        {
            InitializeComponent();

            this.ChartForm = new frmChart();

            this.btnStartInsert.Enabled = false;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.btnInit.Enabled = false;
            this.btnStartInsert.Enabled = true;

            this.txtClientCount.Enabled = false;
            this.txtCurrencyCount.Enabled = false;
            this.txtDay.Enabled = false;
            this.txtBatchCount.Enabled = false;
            this.cbInsertCurrencyImage.Enabled = false;

            int clientCount = this.txtClientCount.Text.Trim().ToInt();
            int currencyCount = this.txtCurrencyCount.Text.Trim().ToInt();
            int day = this.txtDay.Text.Trim().ToInt();
            int batchCount = this.txtBatchCount.Text.Trim().ToInt();
            bool isInsertCurrencyImage = this.cbInsertCurrencyImage.Checked;
            this.TargetCurrencyCount = clientCount * currencyCount * day;

            SourceData.Create(isInsertCurrencyImage);
            DataCounter.Reset();

            this.LastSecondCount = 0;
            this.MaxSecondCount = 0;

            this.BatcherList = new List<Batcher>();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < clientCount; i++)
                {
                    Batcher client = new Batcher(batchCount, currencyCount * day);

                    this.BatcherList.Add(client);

                    this.BeginInvoke(new EventHandler((a, b) =>
                    { this.lblRealClientCount.Text = this.BatcherList.Count.ToString(); })).AsyncWaitHandle.WaitOne(10);
                }
            });
        }

        private void btnStartInsert_Click(object sender, EventArgs e)
        {
            this.StartTime = DateTime.Now;
            this.timerRefresh.Enabled = true;
            this.btnStartInsert.Enabled = false;

            this.ChartForm.Reset();

            Task.Factory.StartNew(() =>
            {
                Parallel.ForEach<Batcher>(this.BatcherList, obj => obj.Insert());
            });
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            this.ChartForm.Show();
            this.ChartForm.RefreshChart();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            int realCurrencyCount = DataCounter.CurrencyCount;
            TimeSpan totalTime = DateTime.Now - this.StartTime;
            int currentSecondCount = realCurrencyCount - this.LastSecondCount;
            int avgSecondCount = (int)Math.Ceiling(realCurrencyCount / totalTime.TotalSeconds);
            this.LastSecondCount = realCurrencyCount;

            if (currentSecondCount > this.MaxSecondCount)
            {
                this.MaxSecondCount = currentSecondCount;
            }

            this.lblTotalCostTimeValue.Text = totalTime.ToString();
            this.lblRealInsertDataCountValue.Text = realCurrencyCount.ToString();
            this.lblCurrentSecondInsertCountValue.Text = currentSecondCount.ToString();
            this.lblAvgPerSecondInsertCountValue.Text = avgSecondCount.ToString();
            this.lblMaxPerSecondInsertCountValue.Text = this.MaxSecondCount.ToString();

            this.ChartForm.AddCount(currentSecondCount, avgSecondCount);

            if (realCurrencyCount >= this.TargetCurrencyCount)
            {
                this.timerRefresh.Enabled = false;
                this.btnInit.Enabled = true;

                this.txtClientCount.Enabled = true;
                this.txtCurrencyCount.Enabled = true;
                this.txtDay.Enabled = true;
                this.txtBatchCount.Enabled = true;
                this.cbInsertCurrencyImage.Enabled = true;
            }
        }

        private void timerMemoryClear_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
