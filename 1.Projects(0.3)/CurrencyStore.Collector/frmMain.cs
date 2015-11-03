using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Collector
{
    public partial class frmMain : Form
    {
        private CurrencyCollector CurrentCollector { get; set; }
        private int LastSecondCurrencyCount { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            int serverPort = this.txtServerPort.Text.Trim().ToInt();

            this.CurrentCollector = new CurrencyCollector();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (this.CurrentCollector != null)
            {
                int terminalCount = this.CurrentCollector.TerminalCount;
                int heartbeatCount = this.CurrentCollector.HeartbeatCount;
                int loginCount = this.CurrentCollector.LoginCount;
                int blacklistQueryCount = this.CurrentCollector.BlacklistQueryCount;
                int blacklistDownloadCount = this.CurrentCollector.BlacklistDownloadCount;
                int currencyCount = this.CurrentCollector.CurrencyCount;
                int perSecondCurrencyCount = currencyCount - this.LastSecondCurrencyCount;

                this.LastSecondCurrencyCount = currencyCount;

                this.lblStatus.Text = ("连接终端：{0}" + Environment.NewLine + Environment.NewLine +
                                       "心跳：{1}" + Environment.NewLine + Environment.NewLine +
                                       "登录：{2}" + Environment.NewLine + Environment.NewLine +
                                       "黑名单查询：{3}" + Environment.NewLine + Environment.NewLine +
                                       "黑名单下载：{4}" + Environment.NewLine + Environment.NewLine +
                                       "纸币：{5} -- {6}").FormatWith(terminalCount, heartbeatCount, loginCount, blacklistQueryCount, blacklistDownloadCount, currencyCount, perSecondCurrencyCount);
            }
        }
    }
}
