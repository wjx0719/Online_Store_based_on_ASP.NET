using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;

namespace Web_Page
{
    public partial class CustomerRegister : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CustomerServiceSoapClient Client = new CustomerServiceSoapClient();
            if(this.Name.Value == "" || this.Password.Value == "" || this.Phone.Value == "" || this.Email.Value == "" || this.Address.Value == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'CustomerRegister.aspx';</script>");
            }
            else if(Client.GetCustomerInfo(this.Name.Value) != null)
            {
                Response.Write("<script language=javascript>alert('用户名重复，请换一个用户名注册');window.location = 'CustomerRegister.aspx';</script>");
            }
            else if (this.Password.Value != this.Password1.Value)
            {
                Response.Write("<script language=javascript>alert('两次输入密码不同，请重新输入');window.location = 'CustomerRegister.aspx';</script>");
            }
            else
            {
                Customer customer = new Customer();
                customer.Name = this.Name.Value;
                customer.Password = this.Password.Value.Trim();
                customer.Phone = this.Phone.Value;
                customer.Email = this.Email.Value;
                customer.Address = this.Address.Value;
                Client.CustomerRegister(customer);
                Session.Remove("Name");
                Session["Name"] = this.Name.Value;
                Response.Redirect("CustomerInfo.aspx");
            }
        }
    }
}