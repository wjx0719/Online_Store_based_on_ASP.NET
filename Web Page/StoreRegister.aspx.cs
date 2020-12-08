using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreRegister : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            StoreServiceSoapClient Client = new StoreServiceSoapClient();
            if (this.Name.Value == "" || this.Password.Value == "" || this.Phone.Value == "" || this.Email.Value == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'StoreRegister.aspx';</script>");
            }
            else if (Client.GetStoreInfo(this.Name.Value) != null)
            {
                Response.Write("<script language=javascript>alert('用户名重复，请换一个店铺名注册');window.location = 'StoreRegister.aspx';</script>");
            }
            else if (this.Password.Value != this.Password1.Value)
            {
                Response.Write("<script language=javascript>alert('两次输入密码不同，请重新输入');window.location = 'StoreRegister.aspx';</script>");
            }
            else
            {
                Store store = new Store();
                store.Name = this.Name.Value;
                store.Password = this.Password.Value;
                store.Phone = this.Phone.Value;
                store.Email = this.Email.Value;
                Client.StoreRegister(store);
                Session.Remove("Name");
                Session["Name"] = this.Name.Value;
                Response.Redirect("StoreInfo.aspx");
            }
        }
    }
}