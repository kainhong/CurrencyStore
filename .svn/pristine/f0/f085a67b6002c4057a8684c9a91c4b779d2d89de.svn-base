using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.DuplicateDataClear
{
    public class XListViewItem : ListViewItem
    {
        public XListViewItem(string sourceFile, string fileSize, string deviceNumber, string collectDate, string beforeCount, string afterCount, string targetFile)
        {
            this.Text = sourceFile;
            this.SubItems.Add(new ListViewSubItem() { Name = "FileSize", Text = fileSize });
            this.SubItems.Add(new ListViewSubItem() { Name = "DeviceNumber", Text = deviceNumber });
            this.SubItems.Add(new ListViewSubItem() { Name = "CollectDate", Text = collectDate });
            this.SubItems.Add(new ListViewSubItem() { Name = "BeforeCount", Text = beforeCount });
            this.SubItems.Add(new ListViewSubItem() { Name = "AfterCount", Text = afterCount });
            this.SubItems.Add(new ListViewSubItem() { Name = "TargetFile", Text = targetFile });
        }
        public string FileSize
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string DeviceNumber
        {
            get { return this.SubItems["DeviceNumber"].Text; }
            set { this.SubItems["DeviceNumber"].Text = value; }
        }
        public string CollectDate
        {
            get { return this.SubItems["CollectDate"].Text; }
            set { this.SubItems["CollectDate"].Text = value; }
        }
        public string BeforeCount
        {
            get { return this.SubItems["BeforeCount"].Text; }
            set { this.SubItems["BeforeCount"].Text = value; }
        }
        public string AfterCount
        {
            get { return this.SubItems["AfterCount"].Text; }
            set { this.SubItems["AfterCount"].Text = value; }
        }
        public string TargetFile
        {
            get { return this.SubItems["TargetFile"].Text; }
            set { this.SubItems["TargetFile"].Text = value; }
        }
    }
}
