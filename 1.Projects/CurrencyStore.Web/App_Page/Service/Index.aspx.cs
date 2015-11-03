using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Service.Interface;
using CurrencyStore.Utility;
using CurrencyStore.Utility.Extension;
using CurrencyStore.Web.App_Class;

namespace CurrencyStore.Web.App_Page.Service
{
    public partial class Index : ServiceBasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
        }

        public string GetLeftMenuHtml()
        {
            StringBuilder result = new StringBuilder();

            IUserService service = ServiceFactory.GetService<IUserService>();

            var allPermissionList = service.GetList_Permission();
            var userPermissionList = (from item in service.GetList_RolePermission(this.CurrentUser.RoleId) select item.PermCode).ToList();

            foreach (var one in from item in allPermissionList where item.PermParentId == 0 && item.PermContent != "-" orderby item.PermCode ascending select item)
            {
                if (userPermissionList.AnyIn(from child in allPermissionList where child.PermParentId == one.PkId select child.PermCode))
                {
                    result.Append("<div title=\"{0}\" iconcss=\"menu-icon\">".FormatWith(one.PermName));
                    result.Append("<ul class=\"nlist\">");

                    foreach (var two in from item in allPermissionList where item.PermParentId == one.PkId && item.PermContent != "-" orderby item.PermCode ascending select item)
                    {
                        if (userPermissionList.Where(obj => obj == two.PermCode).Count() == 1)
                        {
                            result.Append("<li><a href=\"javascript:f_addTab('{0}','{1}','{2}')\">{3}</a></li>".FormatWith(two.PermCode, two.PermName, two.PermContent.Replace("{UserId}", this.UserId), two.PermName));
                        }
                    }

                    result.Append("</ul>");
                    result.Append("</div>");
                }
            }

            return result.ToString();
        }
    }
}