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
    /// OrderService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class OrderService : System.Web.Services.WebService
    {

        [WebMethod]
        public void OrderRegister(int productid,int customerid,int storeid)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("insert into [dbo].[order] (ProductID,CustomerID,StoreID,State) values('{0}','{1}','{2}','{3}'); select @@IDENTITY", productid, customerid, storeid,"未支付");
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            sdr.Read();
            int id = Convert.ToInt32(sdr[0]);
            con.Close();
        }

        [WebMethod]
        public Order[] GetOrderInfoForCustomer(int customerid, out int ordersnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[order] where CustomerID = '{0}'", customerid.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Order[] orders = new Order[100];
            ordersnum = 0;
            while (sdr.Read())
            {
                orders[ordersnum] = new Order();
                orders[ordersnum].ID = int.Parse(sdr["ID"].ToString());
                orders[ordersnum].ProductID = int.Parse(sdr["ProductID"].ToString());
                orders[ordersnum].CustomerID = int.Parse(sdr["CustomerID"].ToString());
                orders[ordersnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                orders[ordersnum].State = sdr["State"].ToString();
                ordersnum++;
            }
            return orders;
        }

        [WebMethod]
        public Order[] GetOrderInfoForStore(int storeid, out int ordersnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[order] where StoreID = '{0}'", storeid.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Order[] orders = new Order[100];
            ordersnum = 0;
            while (sdr.Read())
            {
                orders[ordersnum] = new Order();
                orders[ordersnum].ID = int.Parse(sdr["ID"].ToString());
                orders[ordersnum].ProductID = int.Parse(sdr["ProductID"].ToString());
                orders[ordersnum].CustomerID = int.Parse(sdr["CustomerID"].ToString());
                orders[ordersnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                orders[ordersnum].State = sdr["State"].ToString();
                ordersnum++;
            }
            return orders;
        }

        [WebMethod]
        public Order[] GetAllOrders(out int ordersnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[order]");
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Order[] orders = new Order[100];
            ordersnum = 0;
            while (sdr.Read())
            {
                orders[ordersnum] = new Order();
                orders[ordersnum].ID = int.Parse(sdr["ID"].ToString());
                orders[ordersnum].ProductID = int.Parse(sdr["ProductID"].ToString());
                orders[ordersnum].CustomerID = int.Parse(sdr["CustomerID"].ToString());
                orders[ordersnum].StoreID = int.Parse(sdr["StoreID"].ToString());
                orders[ordersnum].State = sdr["State"].ToString();
                ordersnum++;
            }
            return orders;
        }

        [WebMethod]
        public void UpdateOrderState(int id,string state)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[order] set state = '{0}' where id = '{1}'", state, id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void DeleteOrder(int id)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("delete [dbo].[order] where id = '{0}'", id);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}
