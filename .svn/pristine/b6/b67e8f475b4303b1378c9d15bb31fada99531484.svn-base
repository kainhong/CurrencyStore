using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CurrencyStore.BatchInsert
{
    public class XListViewItem : ListViewItem
    {
        public XListViewItem(string batch, string costTime)
        {
            this.Text = batch;
            this.SubItems.Add(new ListViewSubItem() { Name = "CostTime", Text = costTime });
        }
        public string Batch
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        public string CostTime
        {
            get { return this.SubItems["CostTime"].Text; }
            set { this.SubItems["CostTime"].Text = value; }
        }
    }
}
