using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;

namespace Web_Page
{
    public partial class CustomerLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CustomerServiceSoapClient client = new CustomerServiceSoapClient();
            bool flag = client.CustomerLogin(this.Name.Value, this.Password.Value);
            if (flag == false)
            {
                Response.Write("<script language=javascript>alert('密码错误或用户名不存在');window.location = 'Customerlogin.aspx';</script>");
            }
            else
            {
                Session.Remove("Name");
                Session["Name"] = this.Name.Value;
                Response.Redirect("CustomerInfo.aspx");
            }
        }
    }
}