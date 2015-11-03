using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Utility.File;

namespace CurrencyStore.DuplicateDataClear
{
    public partial class frmMain : Form
    {
        private string SetttingFilePath = Application.StartupPath + @"\Setting.config";
        private string DataFilePath { get; set; }
        private string SaveFilePath { get; set; }
        private string DataFileType { get; set; }
        private string ExportDate { get; set; }
        private string BankCode { get; set; }
        private string RecordNumber { get; set; }
        private string BusinessType { get; set; }
        private string FormatVersion { get; set; }
        private string FilePostfix { get; set; }
        private string DeviceNumber { get; set; }
        private bool FilterDuplicateData { get; set; }
        private string SaveFileFullPath { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.btnConvert.Enabled = false;

            this.BindParameter();
        }

        private void btnChooseDataFilePath_Click(object sender, EventArgs e)
        {
            if (this.fbdDataFilePath.ShowDialog() == DialogResult.OK)
            {
                this.DataFilePath = this.txtDataFilePath.Text = this.fbdDataFilePath.SelectedPath;

                this.SaveFileFullPath = null;
            }
        }

        private void btnChooseSaveFilePath_Click(object sender, EventArgs e)
        {
            if (this.fbdSaveFilePath.ShowDialog() == DialogResult.OK)
            {
                this.SaveFilePath = this.txtSaveFilePath.Text = this.fbdSaveFilePath.SelectedPath;

                this.SaveFileFullPath = null;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.DataFileType = this.txtDataFileType.Text.Trim();

            Task.Factory.StartNew(this.BindFileList);

            FileHelper.CreateDirectory(this.SaveFilePath, true);
        }

        private void btnSaveParameter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定执行该操作吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.SaveParameter();

                MessageBox.Show("参数保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (!FileHelper.CheckDirectoryExists(this.DataFilePath))
            {
                MessageBox.Show("数据文件路径不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!FileHelper.CheckDirectoryExists(this.SaveFilePath))
            {
                MessageBox.Show("保存文件路径不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.SaveParameter();

            this.ExportDate = this.dtpExportDate.Value.ToString("yyyyMMdd");
            this.BankCode = this.txtBankCode.Text.Trim();
            this.RecordNumber = this.txtRecordNumber.Text.Trim();
            this.BusinessType = this.cbbBusinessType.SelectedItem.ToString();
            this.FormatVersion = this.txtFormatVersion.Text.Trim();
            this.FilePostfix = this.txtFilePostfix.Text.Trim();
            this.DeviceNumber = this.txtDeviceNumber.Text.Trim();
            this.FilterDuplicateData = this.cbFilterDuplicateData.Checked;

            this.SetControlStatus(false);

            this.CreateSaveFileFolder();

            Task.Factory.StartNew(() => { this.ConvertData(); });
        }

        private void lbViewResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (FileHelper.CheckDirectoryExists(this.SaveFileFullPath))
            {
                System.Diagnostics.Process.Start("Explorer.exe", this.SaveFileFullPath);
            }
        }

        private void BindParameter()
        {
            if (FileHelper.CheckFileExists(this.SetttingFilePath))
            {

                DataSet ds = new DataSet();
                ds.ReadXml(this.SetttingFilePath);

                DataTable dt = ds.Tables["Parameter"];

                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr["ParameterKey"].ToString())
                    {
                        case "BankCode":
                            this.txtBankCode.Text = dr["ParameterValue"].ToString();
                            break;

                        case "RecordNumber":
                            this.txtRecordNumber.Text = dr["ParameterValue"].ToString();
                            break;

                        case "BusinessType":
                            this.cbbBusinessType.SelectedItem = dr["ParameterValue"].ToString();
                            break;

                        case "FormatVersion":
                            this.txtFormatVersion.Text = dr["ParameterValue"].ToString();
                            break;

                        case "FilePostfix":
                            this.txtFilePostfix.Text = dr["ParameterValue"].ToString();
                            break;

                        case "DeviceNumber":
                            this.txtDeviceNumber.Text = dr["ParameterValue"].ToString();
                            break;

                        case "DataFilePath":
                            this.DataFilePath = this.txtDataFilePath.Text = dr["ParameterValue"].ToString();
                            break;

                        case "SaveFilePath":
                            this.SaveFilePath = this.txtSaveFilePath.Text = dr["ParameterValue"].ToString();
                            break;
                    }
                }
            }

            else
            {
                this.cbbBusinessType.SelectedIndex = 0;

                this.SaveParameter();
            }
        }

        private void SaveParameter()
        {
            DataTable dt = new DataTable();

            dt.TableName = "Parameter";

            dt.Columns.Add("ParameterKey", typeof(string));
            dt.Columns.Add("ParameterValue", typeof(string));

            dt.Rows.Add("BankCode", this.txtBankCode.Text.Trim());
            dt.Rows.Add("RecordNumber", this.txtRecordNumber.Text.Trim());
            dt.Rows.Add("BusinessType", this.cbbBusinessType.SelectedItem.ToString());
            dt.Rows.Add("FormatVersion", this.txtFormatVersion.Text.Trim());
            dt.Rows.Add("FilePostfix", this.txtFilePostfix.Text.Trim());
            dt.Rows.Add("DeviceNumber", this.txtDeviceNumber.Text.Trim());
            dt.Rows.Add("DataFilePath", this.DataFilePath);
            dt.Rows.Add("SaveFilePath", this.SaveFilePath);

            DataSet ds = new DataSet("DataStore");
            ds.Tables.Add(dt);

            ds.WriteXml(this.SetttingFilePath, XmlWriteMode.WriteSchema);
        }

        private void BindFileList()
        {
            this.BeginInvoke(new EventHandler((a, b) =>
            {
                this.lvFileList.Items.Clear();

                DataTable fileList = FileHelper.GetFileList(this.DataFilePath, this.DataFileType.IsNotNullOrEmpty() ? this.DataFileType.Split(',') : null);

                if (fileList.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到任何数据文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                foreach (DataRow dr in fileList.Rows)
                {
                    this.lvFileList.Items.Add(new XListViewItem(dr["FileName"].ToString(), dr["FileSize"].ToString(), null, null, null, null, null));
                }

                this.pbCompletProgress.Minimum = 0;
                this.pbCompletProgress.Maximum = fileList.Rows.Count;
                this.pbCompletProgress.Value = 0;

                this.btnConvert.Enabled = this.pbCompletProgress.Maximum > 0;
            }));
        }

        private void CreateSaveFileFolder()
        {
            this.SaveFileFullPath = this.SaveFilePath + @"\{0}_{1}".FormatWith(this.ExportDate, this.BankCode);

            FileHelper.CreateDirectory(this.SaveFileFullPath, true);
        }

        private void ConvertData()
        {
            DataConverter dc = new DataConverter()
            {
                DataFilePath = this.DataFilePath,
                SaveFileFullPath = this.SaveFileFullPath,
                ExportDate = this.ExportDate,
                BankCode = this.BankCode,
                RecordNumber = this.RecordNumber,
                BusinessType = this.BusinessType,
                FormatVersion = this.FormatVersion,
                FilePostfix = this.FilePostfix,
                DeviceNumber = this.DeviceNumber,
                FilterDuplicateData = this.FilterDuplicateData
            };

            XListViewItem xlvi = null;
            DataConverter.ConvertResult result = null;

            this.BeginInvoke(new EventHandler((a, b) =>
            {
                foreach (ListViewItem lvi in this.lvFileList.Items)
                {
                    xlvi = lvi as XListViewItem;

                    dc.SourceFile = xlvi.Text;

                    try
                    {
                        result = dc.Convert();

                        if (result != null)
                        {
                            xlvi.DeviceNumber = result.DeviceNumber;
                            xlvi.CollectDate = result.CollectDate;
                            xlvi.BeforeCount = result.BeforeCount.ToString();
                            xlvi.AfterCount = result.AfterCount.ToString();
                            xlvi.TargetFile = result.TargetFile;

                            xlvi.ForeColor = Color.Green;
                        }
                    }

                    catch 
                    {
                        xlvi.ForeColor = Color.Red;
                    }
                    
                    this.pbCompletProgress.PerformStep();
                }

                this.SetControlStatus(true);

                MessageBox.Show("数据转换完成", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }));

            /**/
        }

        private void SetControlStatus(bool enable)
        {
            this.btnChooseDataFilePath.Enabled = enable;
            this.btnChooseSaveFilePath.Enabled = enable;
            this.gbParameterSetting.Enabled = enable;
            this.btnConvert.Enabled = enable;
            this.cbFilterDuplicateData.Enabled = enable;
            this.lbViewResult.Enabled = enable;
        }
    }
}
