using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        List<DataTask> tasks = new List<DataTask>();
        private void button1_Click(object sender, EventArgs e)
        {
            var len = (int)numericUpDown1.Value;
            var port = Convert.ToInt32(txtPort.Text);
            for (int i = 0; i < len; i++)
            {
                var task = new DataTask(txtIP.Text, port);
                task.Connect();
                tasks.Add(task);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var len = (int)numericUpDown2.Value;
            foreach (var item in tasks)
            {
                item.Start(len);
            }
            txtLog.Text += "Started\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in tasks)
            {
                item.Close();
            }
            txtLog.Text += "Stoped\r\n";
        }
    }
}
