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
using CurrencyStore.DataPackage;

namespace CurrencyStore.Client
{
    public partial class frmMain : Form
    {
        private HashSet<string> DeviceNumberList;
        private IList<CurrencyTerminal> ClientList;
        private string DeviceNumberIndex;
        private DateTime StartTime = DateTime.Now;
        private bool IsSending = false;
        private int TargetClientCount;
        private int TargetHeartbeatCount;
        private int TargetLoginCount;
        private int TargetBlacklistQueryCount;
        private int TargetBlacklistDownloadCount;
        private int TargetCurrencyCount;
        private int LastSencodCount;
        private int MaxSecondCount;

        public frmMain()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.btnStart.Enabled = false;
            this.btnClose.Enabled = false;
            this.rbHeartbeat.Enabled = false;
            this.rbLogin.Enabled = false;
            this.rbBlacklist.Enabled = false;
            this.rbCurrency.Enabled = false;
            this.btnSendData.Enabled = false;
            this.btnRefresh.Enabled = false;

            this.cbbDeviceNumberRule.SelectedIndex = 0;

            this.DeviceNumberIndex = this.GetDeviceNumberIndex();
        }

        private void btnCreateDevice_Click(object sender, EventArgs e)
        {
            this.CreateDeviceNumber();

            this.btnStart.Enabled = true;
            this.btnRefresh.Enabled = true;

            MessageBox.Show("设备创建完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.TargetClientCount = this.txtClientCount.Text.Trim().ToInt();

            btnClose_Click(null, null);

            this.btnCreateDevice.Enabled = false;
            this.btnStart.Enabled = false;
            this.txtServerAddress.Enabled = false;
            this.txtServerPort.Enabled = false;
            this.txtClientCount.Enabled = false;
            this.txtCurrencyCount.Enabled = false;
            this.txtDay.Enabled = false;
            this.txtTimeOut.Enabled = false;
            this.cbFixedSendSpeed.Enabled = false;

            this.ClientList = new List<CurrencyTerminal>();

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < this.txtClientCount.Text.Trim().ToInt(); i++)
                {
                    CurrencyTerminal client = new CurrencyTerminal(this.txtServerAddress.Text.Trim(), this.txtServerPort.Text.Trim().ToInt());

                    client.DeviceNumber = this.DeviceNumberList.ElementAtOrDefault(i);
                    client.DeviceNumberHex = client.DeviceNumber.GetDeviceNumberHex();
                    client.TargetReconnectCount = this.txtReconnectCount.Text.Trim().ToInt();
                    client.TargetCurrencyCount = this.txtCurrencyCount.Text.Trim().ToInt() * this.txtDay.Text.Trim().ToInt();
                    client.TargetDayCount = this.txtDay.Text.Trim().ToInt();
                    client.TargetSingleDayCurrencyCount = this.txtCurrencyCount.Text.Trim().ToInt();
                    client.TimeOut = this.txtTimeOut.Text.Trim().ToInt();
                    client.FixedSendSpeed = this.cbFixedSendSpeed.Checked;

                    client.Reset();
                    client.Connect();

                    this.ClientList.Add(client);

                    this.BeginInvoke(new EventHandler((a, b) =>
                    { this.lblRealClientCount.Text = this.ClientList.Count.ToString(); }));

                    Thread.Sleep(5);
                }

                this.BeginInvoke(new EventHandler((a, b) =>
                {
                    this.btnClose.Enabled = true;
                    this.rbHeartbeat.Enabled = true;
                    this.rbLogin.Enabled = true;
                    this.rbBlacklist.Enabled = true;
                    this.rbCurrency.Enabled = true;
                    this.btnSendData.Enabled = true;
                }));                
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.IsSending = false;

            if (this.ClientList != null && this.ClientList.Count > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    foreach (CurrencyTerminal ct in this.ClientList)
                    {
                        ct.Close();

                        Thread.Sleep(5);
                    }
                });
            }

            this.btnCreateDevice.Enabled = true;
            this.btnStart.Enabled = true;
            this.btnClose.Enabled = false;
            this.btnSendData.Enabled = false;

            this.lblRealClientCount.Text = "0";

            this.txtServerAddress.Enabled = true;
            this.txtServerPort.Enabled = true;
            this.txtClientCount.Enabled = true;
            this.txtCurrencyCount.Enabled = true;
            this.txtDay.Enabled = true;
            this.txtTimeOut.Enabled = true;
            this.cbFixedSendSpeed.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            float R = 7.0f;

            this.lvClientList.Items.Clear();

            DataCounter.ClearConnectedClient();

            if (this.ClientList != null && this.ClientList.Count > 0)
            {
                Task.Factory.StartNew(() =>
                {
                    int maxX = this.panelStatus.Width;
                    int maxY = this.panelStatus.Height;

                    int maxXCout = (int)(maxX / R);
                    int maxYCout = (int)(maxY / R);

                    if (maxXCout == 0)
                    {
                        return;
                    }

                    this.BeginInvoke(new EventHandler((ob, ca) =>
                    {
                        for (int p = 0; p < this.ClientList.Count; p++)
                        {
                            CurrencyTerminal client = this.ClientList[p];

                            XListViewItem lviClient = new XListViewItem(client.DeviceNumber, client.RealConnectCount, "",
                                client.TimeOutCount, client.SendHeartbeatCount, client.SendLoginCount,
                                client.DownloadBlacklistCount, client.SendCurrencyCount, client.ConnectMessage);

                            float drawX = p % maxXCout * R;
                            float drawY = p / maxXCout * R;

                            if (client != null)
                            {
                                using (Graphics g = Graphics.FromHwnd(this.panelStatus.Handle))
                                {
                                    if (client.IsConnected && client.IsRecieveNormal)
                                    {
                                        lviClient.DeviceStatus = "工作中";
                                        lviClient.ForeColor = Color.Green;

                                        g.FillEllipse(Brushes.Green, drawX, drawY, R, R);

                                        DataCounter.AddConnectedClient();
                                    }
                                    else if (client.IsConnected)
                                    {
                                        lviClient.DeviceStatus = "已连接";
                                        lviClient.ForeColor = Color.Blue;

                                        g.FillEllipse(Brushes.Blue, drawX, drawY, R, R);

                                        DataCounter.AddConnectedClient();
                                    }
                                    else if (!client.IsConnected)
                                    {
                                        lviClient.DeviceStatus = "未连接";
                                        lviClient.ForeColor = Color.Red;

                                        g.FillEllipse(Brushes.Red, drawX, drawY, R, R);
                                    }
                                    else
                                    {
                                        lviClient.DeviceStatus = "未知";
                                        lviClient.ForeColor = Color.Black;

                                        g.FillEllipse(Brushes.Black, drawX, drawY, R, R);
                                    }
                                    g.Save();

                                    this.lvClientList.Items.Add(lviClient);
                                }
                            }
                        }
                    }));
                });
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            this.rbHeartbeat.Enabled = false;
            this.rbLogin.Enabled = false;
            this.rbBlacklist.Enabled = false;
            this.rbCurrency.Enabled = false;

            DataCounter.Reset();

            this.TargetHeartbeatCount = this.TargetClientCount * 1;
            this.TargetLoginCount = this.TargetClientCount * 1;
            this.TargetBlacklistQueryCount = this.TargetClientCount * 1;
            this.TargetBlacklistDownloadCount = 0;
            this.TargetCurrencyCount = this.TargetClientCount * this.txtCurrencyCount.Text.Trim().ToInt() * this.txtDay.Text.Trim().ToInt();
            this.LastSencodCount = 0;
            this.MaxSecondCount = 0;

            if (this.ClientList != null && this.ClientList.Count > 0)
            {
                this.IsSending = true;
                this.StartTime = DateTime.Now;
                this.btnSendData.Enabled = false;

                if (this.rbHeartbeat.Checked)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Parallel.ForEach<CurrencyTerminal>(ClientList, obj => obj.SendHeartbeat());
                    });
                }

                if (this.rbLogin.Checked)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Parallel.ForEach<CurrencyTerminal>(ClientList, obj => obj.SendLogin());
                    });
                }

                if (this.rbBlacklist.Checked)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Parallel.ForEach<CurrencyTerminal>(ClientList, obj => obj.SendBlacklist());
                    });
                }

                if (this.rbCurrency.Checked)
                {
                    Task.Factory.StartNew(() =>
                    {
                        Parallel.ForEach<CurrencyTerminal>(ClientList, obj => obj.RestartSendCurrency());
                    });
                }
            }
        }

        private void timerMemoryClear_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void timerTotalCount_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke(new EventHandler((a, b) =>
            {
                TimeSpan costTime = DateTime.Now.Subtract(this.StartTime).Add(new TimeSpan(0, 0, 1));
                int totalSecond = (int)Math.Truncate(costTime.TotalSeconds > 1 ? costTime.TotalSeconds : 1);

                int connectedClientCount = DataCounter.ConnectedClientCount;
                int targetCount = 0;
                int realCount = 0;
                int remainingCount = 0;
                int currentCount = 0;
                int avgCount = 0;

                if (this.TargetClientCount > 0)
                {
                    this.lblTotalConnectedCount.Text = "点钞机连接成功：" + connectedClientCount.ToString() + " (" + (connectedClientCount / (float)this.TargetClientCount).ToString("P") + ")";
                }

                if (this.IsSending)
                {
                    if (this.TargetBlacklistDownloadCount == 0)
                    {
                        this.TargetBlacklistDownloadCount = this.TargetClientCount * DataCounter.SingleBlacklistDownloadCount;
                    }

                    if (this.rbHeartbeat.Checked)
                    {
                        targetCount = this.TargetHeartbeatCount;
                        realCount = DataCounter.HeartbetaCount;
                    }

                    if (this.rbLogin.Checked)
                    {
                        targetCount = this.TargetLoginCount;
                        realCount = DataCounter.LoginCount;
                    }

                    if (this.rbBlacklist.Checked)
                    {
                        targetCount = this.TargetBlacklistQueryCount + this.TargetBlacklistDownloadCount;
                        realCount = DataCounter.BlacklistQueryCount + DataCounter.RealBlacklistDownloadCount;
                    }

                    if (this.rbCurrency.Checked)
                    {
                        targetCount = this.TargetCurrencyCount;
                        realCount = DataCounter.CurrencyCount;
                    }

                    remainingCount = targetCount - realCount;
                    currentCount = realCount - this.LastSencodCount;
                    avgCount = realCount / totalSecond;
                    this.LastSencodCount = realCount;

                    if (currentCount > this.MaxSecondCount)
                    {
                        this.MaxSecondCount = currentCount;
                    }

                    this.lblSendCount.Text = "已发数据：" + realCount.ToString();
                    this.lblRemainingCount.Text = "剩余数据：" + remainingCount.ToString();

                    this.lblCostTime.Text = "发送耗时：" + costTime.ToString(@"hh\:mm\:ss");
                    this.lblRemainingTime.Text = "剩余时间：" + new TimeSpan(0, 0, remainingCount / (avgCount > 1 ? avgCount : 1)).ToString(@"hh\:mm\:ss");

                    this.lblCurrentSecondCount.Text = "当前每秒发送：" + currentCount.ToString();
                    this.lblAvgSecondCount.Text = "平均每秒发送：" + avgCount.ToString();
                    this.lblMaxSecondCount.Text = "最大每秒发送：" + this.MaxSecondCount.ToString();

                    if (realCount == targetCount)
                    {
                        this.IsSending = false;
                        this.rbHeartbeat.Enabled = true;
                        this.rbLogin.Enabled = true;
                        this.rbBlacklist.Enabled = true;
                        this.rbCurrency.Enabled = true;
                        this.btnSendData.Enabled = true;
                    }
                }

                Application.DoEvents();
            }));
        }

        private void CreateDeviceNumber()
        {
            int deviceCount = this.txtClientCount.Text.Trim().ToInt();

            //规律
            if (this.cbbDeviceNumberRule.SelectedIndex == 0)
            {
                this.DeviceNumberList = new HashSet<string>();

                int startIndex = int.Parse(this.DeviceNumberIndex + "00000000");

                do
                {
                    startIndex += 1;

                    string deviceNumber = "ABCD" + startIndex.ToString();

                    this.DeviceNumberList.Add(deviceNumber);

                } while (this.DeviceNumberList.Count < deviceCount);
            }

            //随机
            if (this.cbbDeviceNumberRule.SelectedIndex == 1)
            {
                Random objRandom = new Random();

                this.DeviceNumberList = new HashSet<string>();

                IList<char> charList = new List<char>();

                for (int i = 48; i <= 57; i++)
                {
                    charList.Add((char)i);
                }

                for (int i = 65; i <= 90; i++)
                {
                    charList.Add((char)i);
                }

                do
                {
                    string deviceNumber =
                        charList[objRandom.Next(0, charList.Count)].ToString() +
                        charList[objRandom.Next(0, charList.Count)].ToString() +
                        charList[objRandom.Next(0, charList.Count)].ToString() +
                        charList[objRandom.Next(0, charList.Count)].ToString() +
                        objRandom.Next(100000000, 999999999);

                    this.DeviceNumberList.Add(deviceNumber);

                } while (this.DeviceNumberList.Count < deviceCount);
            }
        }

        private string GetDeviceNumberIndex()
        {
            int result = 0;

            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName.Contains("CurrencyStore.Client"))
                {
                    result += 1;
                }
            }

            return result.ToString();
        }
    }
}
