using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;
using Web_Page.ProductService;
using Web_Page.StoreService;
using Web_Page.OrderService;

namespace Web_Page
{
    public partial class CustomerShopping : System.Web.UI.Page
    {
        private static int page = 1;
        private static int productsnum;
        private static ProductServiceSoapClient productclient;
        private static ProductService.Product[] products;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                page = 1;
                if (Session["Name"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    productclient = new ProductServiceSoapClient();
                    products = productclient.GetAllProducts(out productsnum);
                    if (productsnum == 0)
                    {
                        Label1.Text = "未查询到商品信息";
                    }
                    else
                    {
                        this.Name.Text = products[page - 1].Name;
                        this.Price.Text = "￥" + products[page - 1].Price.ToString();
                        this.Description.Text = products[page - 1].Description;
                        this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                        productclient.AddViewTimes(products[page - 1].ID);
                        Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
                    }
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
            if (page > 1)
            {
                page--;
                this.Name.Text = products[page - 1].Name;
                this.Price.Text = "￥" + products[page - 1].Price.ToString();
                this.Description.Text = products[page - 1].Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                productclient.AddViewTimes(products[page - 1].ID);
                Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (page < productsnum)
            {
                page++;
                this.Name.Text = products[page - 1].Name;
                this.Price.Text = "￥" + products[page - 1].Price.ToString();
                this.Description.Text = products[page - 1].Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                productclient.AddViewTimes(products[page - 1].ID);
                Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            products = productclient.GetProductsInfoWithName(this.Search.Value, out productsnum);
            page = 1;
            if (productsnum == 0)
            {
                Label1.Text = "未查询到商品信息";
                this.Name.Text = "";
                this.Price.Text = "";
                this.Description.Text = "";
                this.Image.ImageUrl = "";
            }
            else
            {
                this.Name.Text = products[page - 1].Name;
                this.Price.Text = "￥" + products[page - 1].Price.ToString();
                this.Description.Text = products[page - 1].Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                productclient.AddViewTimes(products[page - 1].ID);
                Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            CustomerServiceSoapClient customerclient = new CustomerServiceSoapClient();
            OrderServiceSoapClient orderclient = new OrderServiceSoapClient();
            CustomerService.Customer customer = customerclient.GetCustomerInfo(Session["Name"].ToString());
            orderclient.OrderRegister(products[page - 1].ID,customer.ID, products[page - 1].StoreID);
            Response.Redirect("CustomerManagementOrder.aspx");
        }
    }
}