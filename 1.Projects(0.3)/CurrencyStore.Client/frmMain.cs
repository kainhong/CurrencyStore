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

        public frmMain()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.btnStart.Enabled = false;
            this.btnClose.Enabled = false;
            this.btnRefresh.Enabled = false;
            this.btnSendData.Enabled = false;
            this.cbAutoRefresh.Enabled = false;

            this.timerRefresh.Enabled = this.cbAutoRefresh.Checked;

            this.cbbDeviceNumberRule.SelectedIndex = 0;

            this.DeviceNumberIndex = this.GetDeviceNumberIndex();
        }

        private void btnCreateDevice_Click(object sender, EventArgs e)
        {
            this.CreateDeviceNumber();

            this.btnStart.Enabled = true;
            this.btnRefresh.Enabled = true;
            this.cbAutoRefresh.Enabled = true;

            MessageBox.Show("设备创建完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.TargetClientCount = this.txtClientCount.Text.Trim().ToInt();

            btnClose_Click(null, null);

            this.btnCreateDevice.Enabled = false;
            this.btnStart.Enabled = false;
            this.btnClose.Enabled = true;
            this.btnSendData.Enabled = true;

            this.txtServerAddress.Enabled = false;
            this.txtServerPort.Enabled = false;
            this.txtClientCount.Enabled = false;
            this.txtCurrencyCount.Enabled = false;
            this.txtDay.Enabled = false;
            this.txtSendInterval.Enabled = false;
            this.txtTimeOut.Enabled = false;

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
                    client.SendInterval = this.txtSendInterval.Text.Trim().ToInt();
                    client.TimeOut = this.txtTimeOut.Text.Trim().ToInt();

                    client.Reset();
                    client.Connect();

                    this.ClientList.Add(client);

                    this.BeginInvoke(new EventHandler((a, b) =>
                    { this.lblRealClientCount.Text = this.ClientList.Count.ToString(); })).AsyncWaitHandle.WaitOne(10);

                    Thread.Sleep(5);
                }
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
            this.txtSendInterval.Enabled = true;
            this.txtTimeOut.Enabled = true;
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
            DataCounter.Reset();

            this.TargetHeartbeatCount = this.TargetClientCount * 1;
            this.TargetLoginCount = this.TargetClientCount * 1;
            this.TargetBlacklistQueryCount = this.TargetClientCount * 1;
            this.TargetBlacklistDownloadCount = 0;
            this.TargetCurrencyCount = this.TargetClientCount * this.txtCurrencyCount.Text.Trim().ToInt() * this.txtDay.Text.Trim().ToInt();

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

        private void cbAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            this.timerRefresh.Enabled = this.cbAutoRefresh.Checked;
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void timerMemoryClear_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void timerTotalCount_Tick(object sender, EventArgs e)
        {
            this.BeginInvoke(new EventHandler((a, b) =>
            {
                int connectedClientCount = DataCounter.ConnectedClientCount;

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

                    int realHeartbeatCount = DataCounter.HeartbetaCount;
                    int realLoginCount = DataCounter.LoginCount;
                    int realBlacklistCount = DataCounter.BlacklistQueryCount + DataCounter.RealBlacklistDownloadCount;
                    int realCurrencyCount = DataCounter.CurrencyCount;

                    this.lblTotalHeartbeatCount.Text = realHeartbeatCount.ToString();
                    this.lblTotalLoginCount.Text = realLoginCount.ToString();
                    this.lblTotalBlacklistCount.Text = realBlacklistCount.ToString();
                    this.lblTotalCurrencyCount.Text = realCurrencyCount.ToString();

                    TimeSpan costTime = DateTime.Now.Subtract(this.StartTime);
                    double totalSecond = costTime.TotalSeconds > 1 ? costTime.TotalSeconds : 1;

                    this.lblCostTime.Text = "耗时：" + costTime.ToString();

                    if (this.rbHeartbeat.Checked)
                    {
                        this.lblPerSecondAvgCount.Text = "平均每秒发送数据包：" + Math.Ceiling(realHeartbeatCount / totalSecond).ToString();

                        if (realHeartbeatCount == this.TargetHeartbeatCount)
                        {
                            this.IsSending = false;
                            this.btnSendData.Enabled = true;
                        }
                    }

                    if (this.rbLogin.Checked)
                    {
                        this.lblPerSecondAvgCount.Text = "平均每秒发送数据包：" + Math.Ceiling(realLoginCount / totalSecond).ToString();

                        if (realLoginCount == this.TargetLoginCount)
                        {
                            this.IsSending = false;
                            this.btnSendData.Enabled = true;
                        }
                    }

                    if (this.rbBlacklist.Checked)
                    {
                        this.lblPerSecondAvgCount.Text = "平均每秒发送数据包：" + Math.Ceiling(realBlacklistCount / totalSecond).ToString();

                        if (realBlacklistCount == this.TargetBlacklistQueryCount + this.TargetBlacklistDownloadCount)
                        {
                            this.IsSending = false;
                            this.btnSendData.Enabled = true;
                        }
                    }

                    if (this.rbCurrency.Checked)
                    {
                        this.lblPerSecondAvgCount.Text = "平均每秒发送数据包：" + Math.Ceiling(realCurrencyCount / totalSecond).ToString();

                        if (realCurrencyCount == this.TargetCurrencyCount)
                        {
                            this.IsSending = false;
                            this.btnSendData.Enabled = true;
                        }
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
