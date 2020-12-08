using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Page
{
    public partial class AdminLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(this.Name.Value == "admin" && this.Password.Value == "123456")
            {
                Session.Remove("Admin");
                Session["Admin"] = "admin";
                Response.Redirect("AdminManagementCustomer.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('管理员名称不正确或密码错误');window.location = 'Adminlogin.aspx';</script>");
            }
        }
    }
}