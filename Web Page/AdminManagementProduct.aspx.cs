using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.ProductService;

namespace Web_Page
{
    public partial class AdminManagementProduct : System.Web.UI.Page
    {
        private static ProductServiceSoapClient client = new ProductServiceSoapClient();
        private static int page = 1;
        private static int productsnum;
        private static Product[] products;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                page = 1;
                if (Session["Admin"].ToString() == "admin")
                {
                    products = client.GetAllProducts(out productsnum);
                    if (productsnum == 0)
                    {
                        Label1.Text = "未查询到商品信息";
                    }
                    else
                    {
                        this.ProductID.Text = products[page - 1].ID.ToString();
                        this.Name.Text = products[page - 1].Name;
                        this.Price.Text = "￥" + products[page - 1].Price.ToString();
                        this.Description.Text = products[page - 1].Description;
                        this.StoreID.Text = products[page - 1].StoreID.ToString();
                        this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                        this.Viewtimes.Text = products[page - 1].ViewTimes.ToString();
                        Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
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
                this.ProductID.Text = products[page - 1].ID.ToString();
                this.Name.Text = products[page - 1].Name;
                this.Price.Text = "￥" + products[page - 1].Price.ToString();
                this.Description.Text = products[page - 1].Description;
                this.StoreID.Text = products[page - 1].StoreID.ToString();
                this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                this.Viewtimes.Text = products[page - 1].ViewTimes.ToString();
                Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (page < productsnum)
            {
                page++;
                this.ProductID.Text = products[page - 1].ID.ToString();
                this.Name.Text = products[page - 1].Name;
                this.Price.Text = "￥" + products[page - 1].Price.ToString();
                this.Description.Text = products[page - 1].Description;
                this.StoreID.Text = products[page - 1].StoreID.ToString();
                this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                this.Viewtimes.Text = products[page - 1].ViewTimes.ToString();
                Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
            }
        }
    }
}