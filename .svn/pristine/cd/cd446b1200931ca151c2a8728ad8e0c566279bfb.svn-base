using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;

namespace CurrencyStore.DataInit
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            this.btnInit.Enabled = false;

            Task.Factory.StartNew(this.InitData);
        }

        private void InitData()
        {
            IBasicService basicService = ServiceFactory.GetService<IBasicService>();
            IDeviceService deviceService = ServiceFactory.GetService<IDeviceService>();

            int orgCount = this.txtOrgCount.Text.Trim().ToInt();
            int relevanceDeviceCount = this.txtRelevanceDeviceCount.Text.Trim().ToInt();
            int deviceGroup = this.txtDeviceGroup.Text.Trim().ToInt();
            int perGroupOrgCount = orgCount / deviceGroup;

            this.BeginInvoke(new EventHandler((a, b) =>
            {
                this.pbFinish.Minimum = 0;
                this.pbFinish.Maximum = orgCount * relevanceDeviceCount;
                this.pbFinish.Value = 0;
            })).AsyncWaitHandle.WaitOne(10);

            for (int i = 1; i <= deviceGroup; i++)
            {
                int deviceIndex = 0;

                for (int j = 1; j <= perGroupOrgCount; j++)
                {
                    int orgId = (i - 1) * perGroupOrgCount + j;

                    BasicOrganization org = new BasicOrganization()
                    {
                        OrgNumber = "ORG" + orgId.ToString().PadLeft(4, '0'),
                        OrgName = "网点机构" + orgId.ToString().PadLeft(4, '0'),
                        OrgAddress = "网点机构" + orgId.ToString().PadLeft(4, '0'),
                        OrgParentId = 0
                    };

                    basicService.Save_Organization(org);

                    org.OrgFullPath = org.OrgParentId.ToString().GetOrgFullPath() + "[" + org.PkId + "]";

                    basicService.Save_Organization(org);

                    for (int k = 1; k <= relevanceDeviceCount; k++)
                    {
                        deviceIndex += 1;

                        string deviceNumber = "ABCD" + (int.Parse(i + "00000000") + deviceIndex).ToString();

                        DeviceInfo device = new DeviceInfo()
                        {
                            DeviceNumber = deviceNumber,
                            SoftwareVersion = "000000",
                            RegisterIp = "127.0.0.1",
                            KindCode = 1,
                            ModelCode = 1,
                            OrgId = org.PkId,
                            OnLineTime = DateTime.Now,
                            DeviceStatus = 1
                        };

                        deviceService.Save_Info(device);

                        this.BeginInvoke(new EventHandler((a, b) => { this.pbFinish.PerformStep(); }));
                    }
                }
            }

            this.BeginInvoke(new EventHandler((a, b) => { this.btnInit.Enabled = true; }));

            MessageBox.Show("数据初始化完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
