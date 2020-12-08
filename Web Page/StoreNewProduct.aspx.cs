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
    public partial class StoreNewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Remove("Name");
            Response.Redirect("Index.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(this.Name.Value == "" || this.Price.Value == "" || this.Description.Value == "")
            {
                Response.Write("<script language=javascript>alert('信息未输入完全');window.location = 'StoreNewProduct.aspx';</script>");
            }
            else if(FileUpload1.HasFile == false)
            {
                Response.Write("<script language=javascript>alert('未上传图片');window.location = 'StoreNewProduct.aspx';</script>");
            }
            else if(Path.GetExtension(FileUpload1.PostedFile.FileName) != ".jpg")
            {
                Response.Write("<script language=javascript>alert('图片格式不正确');window.location = 'StoreNewProduct.aspx';</script>");
            }
            else
            {
                StoreServiceSoapClient storeclient = new StoreServiceSoapClient();
                Store store = storeclient.GetStoreInfo(Session["Name"].ToString());
                Product product = new Product();
                product.Name = this.Name.Value;
                product.Price = double.Parse(this.Price.Value);
                product.Description = this.Description.Value;
                product.StoreID = store.ID;
                ProductServiceSoapClient productclient = new ProductServiceSoapClient();
                int id = productclient.ProductRegister(product);
                string filepath = "./ProductImg/ID_" + id.ToString() + ".jpg";
                FileUpload1.SaveAs(Server.MapPath(filepath));
                Response.Redirect("StoreManagementProduct.aspx");
            }
        }
    }
}