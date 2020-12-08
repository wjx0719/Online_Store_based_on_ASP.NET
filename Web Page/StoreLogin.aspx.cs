using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StoreServiceSoapClient client = new StoreServiceSoapClient();
            bool flag = client.StoreLogin(this.Name.Value, this.Password.Value);
            if(flag)
            {
                Session.Remove("Name");
                Session["Name"] = this.Name.Value;
                Response.Redirect("StoreInfo.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('密码错误或店铺名不存在');window.location = 'Storelogin.aspx';</script>");
            }
        }
    }
}