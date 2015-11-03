using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Business;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.Common.File;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Basic_Logo : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                SystemParameter.CollectSystemName = this.txtSystemName.Text.Trim().IsNullOrEmpty() ? "纸币流通管理系统" : this.txtSystemName.Text.Trim();

                if ((sender as Button).CommandName == "Save")
                {
                    if (this.fuLogoPicture.HasFile && this.fuLogoPicture.PostedFile.ContentLength > 0)
                    {
                        HttpPostedFile file = fuLogoPicture.PostedFile;

                        string uploadFolder = FileHelper.ConvertPath("~/App_File/Upload/");
                        string fileName = FileHelper.GetFileNamebyGuid(FileHelper.GetFileExtensionName(file.FileName));

                        if (file.SaveFile(uploadFolder, fileName))
                        {
                            SystemParameter.SystemLogoPicture = fileName;
                        }
                    }
                }

                else
                {
                    SystemParameter.SystemLogoPicture = String.Empty;
                }

                SystemParameter.Save();

                this.JscriptMsg("数据保存成功", null, "Success");
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindLogo();

            this.SetSubmitKey();
        }

        private void BindLogo()
        {
            this.txtSystemName.Text = SystemParameter.CollectSystemName;

            if (SystemParameter.SystemLogoPicture.IsNotNullOrEmpty())
            {
                this.imgLogo.ImageUrl = "~/App_File/Upload/{0}".FormatWith(SystemParameter.SystemLogoPicture);
                this.imgLogo.Visible = true;
            }

            else
            {
                this.imgLogo.Visible = false;
            }
        }
    }
}