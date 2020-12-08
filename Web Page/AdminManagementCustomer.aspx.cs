using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;

namespace Web_Page
{
    public partial class AdminManagementCustomer : System.Web.UI.Page
    {
        private static CustomerServiceSoapClient client = new CustomerServiceSoapClient();
        private static int page = 1;
        private static Customer[] customers;
        private static int customersnum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                page = 1;
                if (Session["Admin"].ToString() == "admin")
                {
                    customers = client.GetAllCustomers(out customersnum);
                    if(customersnum == 0)
                    {
                        Label1.Text = "未查询到注册的顾客信息";
                    }
                    else
                    {
                        this.ID.Text = customers[page - 1].ID.ToString();
                        this.Name.Text = customers[page - 1].Name;
                        this.Phone.Text = customers[page - 1].Phone;
                        this.Email.Text = customers[page - 1].Email;
                        this.Address.Text = customers[page - 1].Address;
                        Label1.Text = string.Format("共查询到{0}条顾客信息，当前是第{1}条", customersnum, page);
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
            if(page > 1)
            {
                page--;
                this.ID.Text = customers[page - 1].ID.ToString();
                this.Name.Text = customers[page - 1].Name;
                this.Phone.Text = customers[page - 1].Phone;
                this.Email.Text = customers[page - 1].Email;
                this.Address.Text = customers[page - 1].Address;
                Label1.Text = string.Format("共查询到{0}条顾客信息，当前是第{1}条", customersnum, page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(page < customersnum)
            {
                page++;
                this.ID.Text = customers[page - 1].ID.ToString();
                this.Name.Text = customers[page - 1].Name;
                this.Phone.Text = customers[page - 1].Phone;
                this.Email.Text = customers[page - 1].Email;
                this.Address.Text = customers[page - 1].Address;
                Label1.Text = string.Format("共查询到{0}条顾客信息，当前是第{1}条", customersnum, page);
            }
        }
    }
}