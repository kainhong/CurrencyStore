using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Common;
using CurrencyStore.Common.ExtensionMethod;
using CurrencyStore.DataConvert;
using CurrencyStore.Entity;
using CurrencyStore.Services.Interface;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Basic_Dict_List : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            foreach (GridViewRow objGVR in this.gvList.Rows)
            {
                if (objGVR.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cbSelect = objGVR.FindControl("cbSelect") as CheckBox;

                    if (cbSelect != null && cbSelect.Checked)
                    {
                        int dictId = this.gvList.DataKeys[objGVR.RowIndex]["PkId"].ToString().ToInt();

                        service.Delete_Dictionary(dictId);
                    }
                }
            }

            this.JscriptMsg("数据删除成功", null, "Success");

            BasicConvert.ClearCache();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.BindDictList();

            this.SetSubmitKey();
        }

        private void BindDictList()
        {
            IBasicService service = ServiceFactory.GetService<IBasicService>();

            this.gvList.DataSource = (from item in service.GetList_Dictionary() where item.DictKind == this.Kind.ToInt() select item).ToList();
            this.gvList.DataBind();
        }
    }
}