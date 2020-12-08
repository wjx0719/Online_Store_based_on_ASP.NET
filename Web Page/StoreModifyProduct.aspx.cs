using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.ProductService;
using Web_Page.StoreService;

namespace Web_Page
{
    public partial class StoreModifyProduct : System.Web.UI.Page
    {
        int page;
        Product[] products;
        StoreServiceSoapClient storeclient = new StoreServiceSoapClient();
        ProductServiceSoapClient productclient = new ProductServiceSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Name"] == null || Request.QueryString["page"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    page = int.Parse(Request.QueryString["page"]);
                    Store store = storeclient.GetStoreInfo(Session["Name"].ToString());
                    products = productclient.GetProductsInfoForStore(store.ID, out int productsnum);
                    this.Name.Value = products[page - 1].Name;
                    this.Price.Value = products[page - 1].Price.ToString();
                    this.Description.Value = products[page - 1].Description;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            page = int.Parse(Request.QueryString["page"]);
            Store store = storeclient.GetStoreInfo(Session["Name"].ToString());
            products = productclient.GetProductsInfoForStore(store.ID, out int productsnum);
            if (this.Name.Value == "" || this.Price.Value == "" || this.Description.Value == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'StoreNewProduct.aspx';</script>");
            }
            else
            {
                productclient.UpdateProductName(products[page - 1].ID, this.Name.Value);
                productclient.UpdateProductPrice(products[page - 1].ID, int.Parse(this.Price.Value));
                productclient.UpdateProductDescription(products[page - 1].ID, this.Description.Value);
                if(FileUpload1.HasFile)
                {
                    if (Path.GetExtension(FileUpload1.PostedFile.FileName) != ".jpg")
                    {
                        Response.Write("<script language=javascript>alert('图片格式不正确');window.location = 'StoreNewProduct.aspx';</script>");
                    }
                    else
                    {
                        int id = products[page - 1].ID;
                        string filepath = "./ProductImg/ID_" + id.ToString() + ".png";
                        FileUpload1.SaveAs(Server.MapPath(filepath));
                    }
                }
                Response.Redirect("StoreManagementProduct.aspx");
            }
        }
    }
}