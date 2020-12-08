using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;

namespace Web_Page
{
    public partial class CustomerCenter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Name"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                CustomerServiceSoapClient client = new CustomerServiceSoapClient();
                Customer customer = client.GetCustomerInfo(Session["Name"].ToString());
                this.ID.Text = customer.ID.ToString();
                this.Name.Text = customer.Name;
                this.Phone.Text = customer.Phone;
                this.Email.Text = customer.Email;
                this.Address.Text = customer.Address;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }
    }
}