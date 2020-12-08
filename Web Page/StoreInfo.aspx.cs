using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                StoreServiceSoapClient client = new StoreServiceSoapClient();
                Store store = client.GetStoreInfo(Session["Name"].ToString());
                this.ID.Text = store.ID.ToString();
                this.Name.Text = store.Name;
                this.Phone.Text = store.Phone;
                this.Email.Text = store.Email;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }
    }
}