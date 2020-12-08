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
    /// CustomerService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]

    public class CustomerService : System.Web.Services.WebService
    {
        [WebMethod]
        public void CustomerRegister(Customer customer)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("insert into [dbo].[customer] (Name,Password,Phone,Email,Address) values('{0}','{1}','{2}','{3}','{4}')",customer.Name,customer.Password,customer.Phone,customer.Email,customer.Address);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public bool CustomerLogin(string name,string password)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[customer] where Name = '{0}'",name);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            bool flag = false;
            while(sdr.Read())
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
        public Customer GetCustomerInfo(string name)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[customer] where Name = '{0}'", name);
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Customer customer = new Customer();
            while (sdr.Read())
            {
                customer.ID = int.Parse(sdr["ID"].ToString());
                customer.Name = sdr["Name"].ToString();
                customer.Password = sdr["Password"].ToString();
                customer.Email = sdr["Email"].ToString();
                customer.Phone = sdr["Phone"].ToString();
                customer.Address = sdr["Address"].ToString();
            }
            con.Close();
            if(customer.Name == null)
            {
                return null;
            }
            else
            {
                return customer;
            }
        }

        [WebMethod]
        public Customer GetCustomerInfoWithID(int id)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[customer] where ID = '{0}'", id.ToString());
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Customer customer = new Customer();
            while (sdr.Read())
            {
                customer.ID = int.Parse(sdr["ID"].ToString());
                customer.Name = sdr["Name"].ToString();
                customer.Password = sdr["Password"].ToString();
                customer.Email = sdr["Email"].ToString();
                customer.Phone = sdr["Phone"].ToString();
                customer.Address = sdr["Address"].ToString();
            }
            con.Close();
            if (customer.Name == null)
            {
                return null;
            }
            else
            {
                return customer;
            }
        }

        [WebMethod]
        public Customer[] GetAllCustomers(out int customersnum)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("select * from [dbo].[customer]");
            SqlCommand comm = new SqlCommand(sql, con);
            SqlDataReader sdr = comm.ExecuteReader();
            Customer[] customers = new Customer[100];
            customersnum = 0;
            while (sdr.Read())
            {
                customers[customersnum] = new Customer();
                customers[customersnum].ID = int.Parse(sdr["ID"].ToString());
                customers[customersnum].Name = sdr["Name"].ToString();
                customers[customersnum].Password = sdr["Password"].ToString();
                customers[customersnum].Email = sdr["Email"].ToString();
                customers[customersnum].Phone = sdr["Phone"].ToString();
                customers[customersnum].Address = sdr["Address"].ToString();
                customersnum++;
            }
            con.Close();
            return customers;
        }

        [WebMethod]
        public void UpdateCustomerEmail(string name,string email)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[customer] set Email = '{0}' where Name = '{1}'", email, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateCustomerPhone(string name, string phone)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[customer] set Phone = '{0}' where Name = '{1}'", phone, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateCustomerAddress(string name, string address)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[customer] set Address = '{0}' where Name = '{1}'", address, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }

        [WebMethod]
        public void UpdateCustomerPassword(string name, string password)
        {
            SqlConnection con = new SqlConnection(SQLtool.strcon);
            con.Open();
            string sql = string.Format("update [dbo].[customer] set Password = '{0}' where Name = '{1}'", password, name);
            SqlCommand comm = new SqlCommand(sql, con);
            comm.ExecuteNonQuery();
            con.Close();
        }
    }
}
