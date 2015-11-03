using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CurrencyStore.DataPackage;

namespace CurrencyStore.Client
{
    public class XListViewItem : ListViewItem
    {
        public XListViewItem(string deviceNumber, int connectCount, string deviceStatus, int timeOutCount, int heartbeatCount, int loginCount, int blacklistCount, int currencyCount, string connectMessage)
        {
            this.Text = deviceNumber;
            this.SubItems.Add(new ListViewSubItem() { Name = "ConnectCount", Text = connectCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "DeviceStatus", Text = deviceStatus });
            this.SubItems.Add(new ListViewSubItem() { Name = "TimeOutCount", Text = timeOutCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "HeartbeatCount", Text = heartbeatCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "LoginCount", Text = loginCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "BlacklistCount", Text = blacklistCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "CurrencyCount", Text = currencyCount.ToString() });
            this.SubItems.Add(new ListViewSubItem() { Name = "ConnectMessage", Text = connectMessage });
        }
        public string DeviceNumber
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string ConnectCount
        {
            get { return this.SubItems["ConnectCount"].Text; }
            set { this.SubItems["ConnectCount"].Text = value; }
        }
        public string DeviceStatus
        {
            get { return this.SubItems["DeviceStatus"].Text; }
            set { this.SubItems["DeviceStatus"].Text = value; }
        }
        public int TimeOutCount
        {
            get { return this.SubItems["TimeOutCount"].Text.ToInt(); }
            set { this.SubItems["TimeOutCount"].Text = value.ToString(); }
        }
        public int HeartbeatCount
        {
            get { return this.SubItems["HeartbeatCount"].Text.ToInt(); }
            set { this.SubItems["HeartbeatCount"].Text = value.ToString(); }
        }
        public int BlacklistCount
        {
            get { return this.SubItems["BlacklistCount"].Text.ToInt(); }
            set { this.SubItems["BlacklistCount"].Text = value.ToString(); }
        }
        public int LoginCount
        {
            get { return this.SubItems["LoginCount"].Text.ToInt(); }
            set { this.SubItems["LoginCount"].Text = value.ToString(); }
        }
        public int CurrencyCount
        {
            get { return this.SubItems["CurrencyCount"].Text.ToInt(); }
            set { this.SubItems["CurrencyCount"].Text = value.ToString(); }
        }
        public string ConnectMessage
        {
            get { return this.SubItems["ConnectMessage"].Text; }
            set { this.SubItems["ConnectMessage"].Text = value; }
        }
    }
}
