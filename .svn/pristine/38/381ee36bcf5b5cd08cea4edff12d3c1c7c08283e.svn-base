using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.Communication;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Currency_Info_Import : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool tipShow = false;

            if (this.fuDataFile1.HasFile)
            {
                if (this.fuDataFile1.PostedFile.ContentLength > 0)
                {
                    string fileName = this.SaveDataFile(this.fuDataFile1);

                    if (fileName.IsNotNullOrEmpty())
                    {
                        UploadResult result = this.ImportDataFile(fileName, this.cbIgnoreAlreadyUpload1.Checked);

                        this.SetUploadResult(result, this.tdDataUploadResult1);

                        tipShow = true;
                    }
                }

                else
                {
                    this.tdDataUploadResult1.InnerHtml = "请选择有效的数据文件";
                }
            }

            else
            {
                this.tdDataUploadResult1.InnerHtml = String.Empty;
            }

            /**/

            if (this.fuDataFile2.HasFile)
            {
                if (this.fuDataFile2.PostedFile.ContentLength > 0)
                {

                    string fileName = this.SaveDataFile(this.fuDataFile2);

                    if (fileName.IsNotNullOrEmpty())
                    {
                        UploadResult result = this.ImportDataFile(fileName, this.cbIgnoreAlreadyUpload2.Checked);

                        this.SetUploadResult(result, this.tdDataUploadResult2);

                        tipShow = true;
                    }
                }

                else
                {
                    this.tdDataUploadResult2.InnerText = "请选择有效的数据文件";
                }
            }

            else
            {
                this.tdDataUploadResult2.InnerHtml = String.Empty;
            }

            /**/

            if (this.fuDataFile3.HasFile)
            {
                if (this.fuDataFile3.PostedFile.ContentLength > 0)
                {
                    string fileName = this.SaveDataFile(this.fuDataFile3);

                    if (fileName.IsNotNullOrEmpty())
                    {
                        UploadResult result = this.ImportDataFile(fileName, this.cbIgnoreAlreadyUpload3.Checked);

                        this.SetUploadResult(result, this.tdDataUploadResult3);

                        tipShow = true;
                    }
                }

                else
                {
                    this.tdDataUploadResult3.InnerText = "请选择有效的数据文件";
                }
            }

            else
            {
                this.tdDataUploadResult3.InnerHtml = String.Empty;
            }

            /**/

            if (this.fuDataFile4.HasFile)
            {
                if (this.fuDataFile4.PostedFile.ContentLength > 0)
                {
                    string fileName = this.SaveDataFile(this.fuDataFile4);

                    if (fileName.IsNotNullOrEmpty())
                    {
                        UploadResult result = this.ImportDataFile(fileName, this.cbIgnoreAlreadyUpload4.Checked);

                        this.SetUploadResult(result, this.tdDataUploadResult4);

                        tipShow = true;
                    }
                }

                else
                {
                    this.tdDataUploadResult4.InnerText = "请选择有效的数据文件";
                }
            }

            else
            {
                this.tdDataUploadResult4.InnerHtml = String.Empty;
            }

            /**/

            if (this.fuDataFile5.HasFile)
            {
                if (this.fuDataFile5.PostedFile.ContentLength > 0)
                {

                    string fileName = this.SaveDataFile(this.fuDataFile5);

                    if (fileName.IsNotNullOrEmpty())
                    {
                        UploadResult result = this.ImportDataFile(fileName, this.cbIgnoreAlreadyUpload5.Checked);

                        this.SetUploadResult(result, this.tdDataUploadResult5);

                        tipShow = true;
                    }
                }

                else
                {
                    this.tdDataUploadResult5.InnerText = "请选择有效的数据文件";
                }
            }

            else
            {
                this.tdDataUploadResult5.InnerHtml = String.Empty;
            }

            if (tipShow)
            {
                this.JscriptMsg("数据上传成功", null, "Success");
            }

            else
            {
                this.JscriptMsg("至少上传一个文件", null, "Error");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.SetSubmitKey();
        }

        private string SaveDataFile(FileUpload fuDataFile)
        {
            string result = null;

            HttpPostedFile file = fuDataFile.PostedFile;

            string uploadFolder = FileHelper.ConvertPath("~/App_File/Import/");
            string fileName = FileHelper.GetFileNamebyGuid(FileHelper.GetFileExtensionName(file.FileName));

            if (file.SaveFile(uploadFolder, fileName))
            {
                result = uploadFolder + fileName;
            }


            return result;
        }

        private UploadResult ImportDataFile(string fileName, bool isIgnoreAlreadyUpload)
        {
            UploadResult result = new UploadResult();

            using (CurrencyFileReader fileReader = new CurrencyFileReader(fileName))
            {
                FileHeader fileHeader = fileReader.FileHeader;
                IEnumerable<CurrencyInfo> dataList = fileReader.Read(isIgnoreAlreadyUpload).ToList();

                /**/

                IDeviceService deviceService = ServiceFactory.GetService<IDeviceService>();

                bool deviceExists = deviceService.CheckExists_Info(new DeviceInfo() { DeviceNumber = fileHeader.MachineSN });

                result.FileType = fileHeader.FileType;
                result.DeviceNumber = fileHeader.MachineSN;
                result.DeviceStatus = deviceExists ? "已入库" : "未入库";

                if (!deviceExists)
                {
                    DeviceInfo deviceInfo = new DeviceInfo()
                    {
                        OrgId = 0,
                        ModelCode = 0,
                        KindCode = 0,
                        DeviceNumber = fileHeader.MachineSN,
                        SoftwareVersion = fileHeader.SoftVersion,
                        OnLineTime = DateTime.Now,
                        DeviceStatus = 1,
                    };

                    deviceService.Save_Info(deviceInfo);
                }

                /**/

                result.TotalCount = fileHeader.SumRecords;
                result.AlreadyUploadCount = fileHeader.UploadRecord;

                if (isIgnoreAlreadyUpload)
                {
                    result.ShouldSaveCount = result.TotalCount - result.AlreadyUploadCount;
                }

                else
                {
                    result.ShouldSaveCount = result.TotalCount;
                }

                /**/

                ICurrencyService currencyService = ServiceFactory.GetService<ICurrencyService>();

                int bufferCount = 500;
                int maxCount = dataList.Count();
                List<CurrencyInfo> buffer = null;

                for (int i = 0; i <= maxCount / bufferCount; i++)
                {
                    buffer = dataList.Skip(i * bufferCount).Take(bufferCount).ToList();

                    if (buffer.Count() > 0)
                    {
                        currencyService.BatchSave_Info(buffer);
                    }
                }

                result.SuccessSaveCount = maxCount;
            }

            return result;
        }

        private void SetUploadResult(UploadResult objUploadResult, HtmlTableCell td)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<table><tr style=\"text-align: center;\">");
            sb.Append("<th style=\"width: 80px\">文件类型</th>");
            sb.Append("<th style=\"width: 200px\">设备号码</th>");
            sb.Append("<th style=\"width: 80px\">总记录数</th>");
            sb.Append("<th style=\"width: 80px\">已上传数</th>");
            sb.Append("<th style=\"width: 80px\">应该保存</th>");
            sb.Append("<th style=\"width: 80px\">成功保存</th>");
            sb.Append("</tr>");
            sb.Append("<tr style=\"text-align: center; color: Blue;\">");
            sb.Append("<td>{FileType}</td>");
            sb.Append("<td>{DeviceNumber}&nbsp;({DeviceStatus})</td>");
            sb.Append("<td>{TotalCount}</td>");
            sb.Append("<td>{AlreadyUploadCount}</td>");
            sb.Append("<td>{ShouldSaveCount}</td>");
            sb.Append("<td>{SuccessSaveCount}</td>");
            sb.Append("</tr></table>");

            sb.Replace("{FileType}", objUploadResult.FileType);
            sb.Replace("{DeviceNumber}", objUploadResult.DeviceNumber);
            sb.Replace("{DeviceStatus}", objUploadResult.DeviceStatus);
            sb.Replace("{TotalCount}", objUploadResult.TotalCount.ToString());
            sb.Replace("{AlreadyUploadCount}", objUploadResult.AlreadyUploadCount.ToString());
            sb.Replace("{ShouldSaveCount}", objUploadResult.ShouldSaveCount.ToString());
            sb.Replace("{SuccessSaveCount}", objUploadResult.SuccessSaveCount.ToString());

            td.InnerHtml = sb.ToString();
        }

        private class UploadResult
        {
            public string FileType { get; set; }
            public string DeviceNumber { get; set; }
            public string DeviceStatus { get; set; }
            public int TotalCount { get; set; }
            public int AlreadyUploadCount { get; set; }
            public int ShouldSaveCount { get; set; }
            public int SuccessSaveCount { get; set; }

            public UploadResult()
            {
                this.FileType = String.Empty;
                this.DeviceNumber = String.Empty;
                this.DeviceStatus = String.Empty;
                this.TotalCount = 0;
                this.AlreadyUploadCount = 0;
                this.ShouldSaveCount = 0;
                this.SuccessSaveCount = 0;
            }
        }
    }
}