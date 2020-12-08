using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class AdminManagemenStore : System.Web.UI.Page
    {
        private static StoreServiceSoapClient client = new StoreServiceSoapClient();
        private static int page = 1;
        private static Store[] stores;
        private static int storesnum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                page = 1;
                if (Session["Admin"].ToString() == "admin")
                {
                    stores = client.GetAllStores(out storesnum);
                    if(storesnum == 0)
                    {
                        Label1.Text = "未查询到注册的商店信息";
                    }
                    else
                    {
                        this.ID.Text = stores[page - 1].ID.ToString();
                        this.Name.Text = stores[page - 1].Name;
                        this.Phone.Text = stores[page - 1].Phone;
                        this.Email.Text = stores[page - 1].Email;
                        Label1.Text = string.Format("共查询到{0}条商店信息，当前是第{1}条", storesnum, page);
                    }
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("Index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (page > 1)
            {
                page--;
                this.ID.Text = stores[page - 1].ID.ToString();
                this.Name.Text = stores[page - 1].Name;
                this.Phone.Text = stores[page - 1].Phone;
                this.Email.Text = stores[page - 1].Email;
                Label1.Text = string.Format("共查询到{0}条商店信息，当前是第{1}条", storesnum, page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (page < storesnum)
            {
                page++;
                this.ID.Text = stores[page - 1].ID.ToString();
                this.Name.Text = stores[page - 1].Name;
                this.Phone.Text = stores[page - 1].Phone;
                this.Email.Text = stores[page - 1].Email;
                Label1.Text = string.Format("共查询到{0}条商店信息，当前是第{1}条", storesnum, page);
            }
        }
    }
}