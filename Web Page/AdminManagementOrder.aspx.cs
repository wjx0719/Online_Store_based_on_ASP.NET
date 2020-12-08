using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.OrderService;
using Web_Page.ProductService;

namespace Web_Page
{
    public partial class AdminManagementOrder : System.Web.UI.Page
    {
        private static OrderServiceSoapClient client = new OrderServiceSoapClient();
        private static int page = 1;
        private static int ordersnum;
        private static Order[] orders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Admin"].ToString() == "admin")
                {
                    page = 1;
                    orders = client.GetAllOrders(out ordersnum);
                    if (ordersnum == 0)
                    {
                        Label1.Text = "未查询到商品信息";
                    }
                    else
                    {
                        this.OrderID.Text = orders[page - 1].ID.ToString();
                        this.ProductID.Text = orders[page - 1].ProductID.ToString();
                        this.CustomerID.Text = orders[page - 1].CustomerID.ToString();
                        this.StoreID.Text = orders[page - 1].StoreID.ToString();
                        this.Image.ImageUrl = "./ProductImg/ID_" + orders[page - 1].ProductID.ToString() + ".jpg";
                        this.State.Text = orders[page - 1].State;
                        Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个",ordersnum, page);
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
                this.OrderID.Text = orders[page - 1].ID.ToString();
                this.ProductID.Text = orders[page - 1].ProductID.ToString();
                this.CustomerID.Text = orders[page - 1].CustomerID.ToString();
                this.StoreID.Text = orders[page - 1].StoreID.ToString();
                this.Image.ImageUrl = "./ProductImg/ID_" + orders[page - 1].ProductID.ToString() + ".jpg";
                this.State.Text = orders[page - 1].State;
                Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个", ordersnum, page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (page < ordersnum)
            {
                page++;
                this.OrderID.Text = orders[page - 1].ID.ToString();
                this.ProductID.Text = orders[page - 1].ProductID.ToString();
                this.CustomerID.Text = orders[page - 1].CustomerID.ToString();
                this.StoreID.Text = orders[page - 1].StoreID.ToString();
                this.Image.ImageUrl = "./ProductImg/ID_" + orders[page - 1].ProductID.ToString() + ".jpg";
                this.State.Text = orders[page - 1].State;
                Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个", ordersnum, page);
            }
        }
    }
}