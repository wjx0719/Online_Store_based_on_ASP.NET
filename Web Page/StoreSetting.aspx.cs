using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreSetting : System.Web.UI.Page
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
                    StoreServiceSoapClient client = new StoreServiceSoapClient();
                    Store store = client.GetStoreInfo(Session["Name"].ToString());
                    this.Email.Text = store.Email;
                    this.Phone.Text = store.Phone;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Phone.Text == "" || this.Email.Text == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'StoreSetting.aspx';</script>");
            }
            else
            {
                StoreServiceSoapClient client = new StoreServiceSoapClient();
                client.UpdateStoreEmail(Session["Name"].ToString(), this.Email.Text);
                client.UpdateStorePhone(Session["Name"].ToString(), this.Phone.Text);
                Response.Write("<script language=javascript>alert('修改成功');window.location = StoreSetting.aspx';</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            StoreServiceSoapClient client = new StoreServiceSoapClient();
            if (client.StoreLogin(Session["Name"].ToString(), this.OldPassword.Text) == false)
            {
                Response.Write("<script language=javascript>alert('原密码不正确');window.location = 'StoreSetting.aspx';</script>");
            }
            else if (this.NewPassword.Text == "")
            {
                Response.Write("<script language=javascript>alert('未输入新密码');window.location = 'StoreSetting.aspx';</script>");
            }
            else if (this.NewPassword.Text != this.NewPassword1.Text)
            {
                Response.Write("<script language=javascript>alert('两次输入的密码不一致');window.location = 'StoreSetting.aspx';</script>");
            }
            else
            {
                client.UpdateStorePassword(Session["Name"].ToString(), this.NewPassword.Text);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }
    }
}