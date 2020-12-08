using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;

namespace Web_Page
{
    public partial class CustomerSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Name"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    CustomerServiceSoapClient Client = new CustomerServiceSoapClient();
                    Customer customer = Client.GetCustomerInfo(Session["Name"].ToString());
                    this.Email.Text = customer.Email;
                    this.Address.Text = customer.Address;
                    this.Phone.Text = customer.Phone;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(this.Phone.Text == "" || this.Email.Text == "" || this.Address.Text == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'CustomerSetting.aspx';</script>");
            }
            else
            {
                CustomerServiceSoapClient client = new CustomerServiceSoapClient();
                client.UpdateCustomerAddress(Session["Name"].ToString(), this.Address.Text);
                client.UpdateCustomerEmail(Session["Name"].ToString(), this.Email.Text);
                client.UpdateCustomerPhone(Session["Name"].ToString(), this.Phone.Text);
                Response.Write("<script language=javascript>alert('修改成功');window.location = 'CustomerSetting.aspx';</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            CustomerServiceSoapClient Client = new CustomerServiceSoapClient();
            if(Client.CustomerLogin(Session["Name"].ToString(), this.OldPassword.Text) == false)
            {
                Response.Write("<script language=javascript>alert('原密码不正确');window.location = 'CustomerSetting.aspx';</script>");
            }
            else if(this.NewPassword.Text == "")
            {
                Response.Write("<script language=javascript>alert('未输入新密码');window.location = 'CustomerSetting.aspx';</script>");
            }
            else if(this.NewPassword.Text != this.NewPassword1.Text)
            {
                Response.Write("<script language=javascript>alert('两次输入的密码不一致');window.location = 'CustomerSetting.aspx';</script>");
            }
            else
            {
                Client.UpdateCustomerPassword(Session["Name"].ToString(), this.NewPassword.Text);
            }
        }
    }
}