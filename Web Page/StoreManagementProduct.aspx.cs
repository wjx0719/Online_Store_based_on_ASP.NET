using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.ProductService;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreManagementProduct : System.Web.UI.Page
    {
        private static int page = 1;
        private int productsnum;
        StoreServiceSoapClient storeclient;
        ProductServiceSoapClient productclient;
        Product[] products;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                storeclient = new StoreServiceSoapClient();
                productclient = new ProductServiceSoapClient();
                Store store = storeclient.GetStoreInfo(Session["Name"].ToString());
                products = productclient.GetProductsInfoForStore(store.ID,out productsnum);
                if(productsnum == 0)
                {
                    Label1.Text = "未查询到商品信息";
                }
                else
                {
                    this.Name.Text = products[page - 1].Name;
                    this.Price.Text = "￥" + products[page - 1].Price.ToString();
                    this.Description.Text = products[page - 1].Description;
                    this.Image.ImageUrl = "./ProductImg/ID_" + products[page - 1].ID.ToString() + ".jpg";
                    Label1.Text = string.Format("共查询到{0}件商品，当前是第{1}件", productsnum, page);
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreNewProduct.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(page > 1)
            {
                page--;
                Response.Redirect("StoreManagementProduct.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(page < productsnum)
            {
                page++;
                Response.Redirect("StoreManagementProduct.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreModifyProduct.aspx?page=" + page.ToString());
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            productclient.DeleteProduct(products[page - 1].ID);
            Response.Redirect("StoreManagementProduct.aspx");
        }
    }
}