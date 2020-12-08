using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace Web_Services
{
    /// <summary>
    /// ProductService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        [WebMethod]
        public int ProductRegister(Product product)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("insert into [dbo].[product] (StoreId,Name,Description,Price) values('{0}','{1}','{2}','{3}'); select @@IDENTITY", product.StoreID,product.Name,product.Description,product.Price);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            sdr.Read();
            int id = Convert.ToInt32(sdr[0]);
            con.Close();
            return id;
        }

        [WebMethod]
        public Product GetProductInfo(int productid)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[product] where id = '{0}'", productid.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Product product = new Product();
            while (sdr.Read())
            {
                product.ID = int.Parse(sdr["ID"].ToString());
                product.StoreID = int.Parse(sdr["StoreID"].ToString());
                product.Name = sdr["Name"].ToString();
                product.Price = double.Parse(sdr["Price"].ToString());
                product.Description = sdr["Description"].ToString();
                product.ViewTimes = int.Parse(sdr["ViewTimes"].ToString());
            }
            return product;
        }

        [WebMethod]
        public Product[] GetProductsInfoForStore(int storeid,out int productsnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[product] where StoreID = '{0}'", storeid.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Product[] products = new Product[100];
            productsnum = 0;
            while(sdr.Read())
            {
                products[productsnum] = new Product();
                products[productsnum].ID = int.Parse(sdr["ID"].ToString());
                products[productsnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                products[productsnum].Name = sdr["Name"].ToString();
                products[productsnum].Price = double.Parse(sdr["Price"].ToString());
                products[productsnum].Description = sdr["Description"].ToString();
                products[productsnum].ViewTimes = int.Parse(sdr["ViewTimes"].ToString());
                productsnum++;
            }
            return products;
        }

        [WebMethod]
        public Product[] GetAllProducts(out int productsnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[product]");
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Product[] products = new Product[100];
            for (int i = 0; i < 100; i++)
            {
                products[i] = null;
            }
            productsnum = 0;
            while (sdr.Read())
            {
                products[productsnum] = new Product();
                products[productsnum].ID = int.Parse(sdr["ID"].ToString());
                products[productsnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                products[productsnum].Name = sdr["Name"].ToString();
                products[productsnum].Price = double.Parse(sdr["Price"].ToString());
                products[productsnum].Description = sdr["Description"].ToString();
                products[productsnum].ViewTimes = int.Parse(sdr["ViewTimes"].ToString());
                productsnum++;
            }
            return products;
        }

        [WebMethod]
        public Product[] GetProductsInfoWithName(string name,out int productsnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[product] where Name like '%{0}%'", name);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Product[] products = new Product[100];
            for (int i = 0; i < 100; i++)
            {
                products[i] = null;
            }
            productsnum = 0;
            while (sdr.Read())
            {
                products[productsnum] = new Product();
                products[productsnum].ID = int.Parse(sdr["ID"].ToString());
                products[productsnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                products[productsnum].Name = sdr["Name"].ToString();
                products[productsnum].Price = double.Parse(sdr["Price"].ToString());
                products[productsnum].Description = sdr["Description"].ToString();
                products[productsnum].ViewTimes = int.Parse(sdr["ViewTimes"].ToString());
                productsnum++;
            }
            return products;
        }

        [WebMethod]
        public void UpdateProductName(int id, string name)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[product] set Name = '{0}' where id = '{1}'", name, id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateProductDescription(int id, string description)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[product] set Description = '{0}' where id = '{1}'", description, id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateProductPrice(int id, double price)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[product] set Price = '{0}' where id = '{1}'", price, id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void AddViewTimes(int id)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[product] set Viewtimes = Viewtimes + 1 where id = '{0}'", id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void DeleteProduct(int id)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("delete [dbo].[product] where id = '{0}'",id);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}
