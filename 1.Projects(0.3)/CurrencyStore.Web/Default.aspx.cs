using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CurrencyStore.Common;
using CurrencyStore.Repository;
using CurrencyStore.Repository.MySql;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
namespace CurrencyStore.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var item = new CurrencyStore.Repository.MySql.UserInfoRepository();
            //var i = item as IUserInfoRepository;
            //var v = (i.ToString());

            //ServiceFactory.Contianer.RegisterType(typeof(IUserInfoRepository), typeof(UserInfoRepository));

            var s = ServiceFactory.GetService<CurrencyStore.Repository.IUserInfoRepository>();

            Response.Redirect("~/App_Page/Service/Login.aspx");
        }
    }
}