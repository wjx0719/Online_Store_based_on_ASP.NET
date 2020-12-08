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
    /// StoreService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class StoreService : System.Web.Services.WebService
    {

        [WebMethod]
        public void StoreRegister(Store store)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("insert into [dbo].[store] (Name,Password,Phone,Email) values('{0}','{1}','{2}','{3}')", store.Name, store.Password, store.Phone, store.Email);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public bool StoreLogin(string name, string password)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[store] where Name = '{0}'", name);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            bool flag = false;
            while (sdr.Read())
            {
                if (sdr["Password"].ToString() == password)
                {
                    flag = true;
                }
            }
            con.Close();
            return flag;
        }

        [WebMethod]
        public Store GetStoreInfo(string name)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[store] where Name = '{0}'", name);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Store store = new Store();
            while (sdr.Read())
            {
                store.ID = int.Parse(sdr["ID"].ToString());
                store.Name = sdr["Name"].ToString();
                store.Password = sdr["Password"].ToString();
                store.Email = sdr["Email"].ToString();
                store.Phone = sdr["Phone"].ToString();
            }
            con.Close();
            if(store.Name == null)
            {
                return null;
            }
            else
            {
                return store;
            }
        }

        [WebMethod]
        public Store GetStoreInfoWithID(int id)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[store] where ID = '{0}'", id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Store store = new Store();
            while (sdr.Read())
            {
                store.ID = int.Parse(sdr["ID"].ToString());
                store.Name = sdr["Name"].ToString();
                store.Password = sdr["Password"].ToString();
                store.Email = sdr["Email"].ToString();
                store.Phone = sdr["Phone"].ToString();
            }
            con.Close();
            if (store.Name == null)
            {
                return null;
            }
            else
            {
                return store;
            }
        }

        [WebMethod]
        public Store[] GetAllStores(out int storesnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[store]");
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Store[] stores = new Store[100];
            storesnum = 0;
            while (sdr.Read())
            {
                stores[storesnum] = new Store();
                stores[storesnum].ID = int.Parse(sdr["ID"].ToString());
                stores[storesnum].Name = sdr["Name"].ToString();
                stores[storesnum].Password = sdr["Password"].ToString();
                stores[storesnum].Email = sdr["Email"].ToString();
                stores[storesnum].Phone = sdr["Phone"].ToString();
                storesnum++;
            }
            con.Close();
            return stores;
        }

        [WebMethod]
        public void UpdateStoreEmail(string name, string email)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[store] set Email = '{0}' where Name = '{1}'", email, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateStorePhone(string name, string phone)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[store] set Phone = '{0}' where Name = '{1}'", phone, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateStorePassword(string name, string password)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[store] set Password = '{0}' where Name = '{1}'", password, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}
