using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using CurrencyStore.Common.ExtensionMethod;

namespace CurrencyStore.Web.App_Class
{
    public static class WebControlExtension
    {
        public static void AddOrgSelector(this TextBox target, string userId)
        {
            target.Attributes["onfocus"] = "openDialog('网点机构搜索', 'Basic_Org_Search.aspx?UserId={0}', 750, 400)".FormatWith(userId);
        }

        public static void AddDeviceSelector(this TextBox target)
        {

        }

        public static void AddDateTimeSelector(this TextBox target)
        {
            target.Attributes["onfocus"] = "WdatePicker({dateFmt:'yyyy-MM-dd'})";
        }
    }
}