using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_Page.CustomerService;
using Web_Page.StoreService;
using Web_Page.OrderService;
using Web_Page.ProductService;

namespace Web_Page
{
    public partial class StoreManagementOrder : System.Web.UI.Page
    {
        private static OrderServiceSoapClient orderclient = new OrderServiceSoapClient();
        private static CustomerServiceSoapClient customerclient = new CustomerServiceSoapClient();
        private static ProductServiceSoapClient productclient = new ProductServiceSoapClient();
        private static StoreServiceSoapClient storeclient = new StoreServiceSoapClient();
        private static Order[] orders;
        private static int page = 1;
        private static int ordersnum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                page = 1;
                if (Session["Name"] == null)
                {
                    Response.Redirect("Index.aspx");
                }
                else
                {
                    Store store = storeclient.GetStoreInfo(Session["Name"].ToString());
                    orders = orderclient.GetOrderInfoForStore(store.ID, out ordersnum);
                    if (ordersnum == 0)
                    {
                        Label1.Text = "未查询到订单信息";
                        Button4.Visible = false;
                    }
                    else
                    {
                        Product product = productclient.GetProductInfo(orders[page - 1].ProductID);
                        Customer customer = customerclient.GetCustomerInfoWithID(orders[page - 1].CustomerID);
                        this.Name.Text = product.Name;
                        this.Price.Text = "￥" + product.Price.ToString();
                        this.Description.Text = product.Description;
                        this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                        this.CustomerName.Text = customer.Name;
                        this.Phone.Text = customer.Phone;
                        this.Email.Text = customer.Email;
                        this.Address.Text = customer.Address;
                        this.State.Text = orders[page - 1].State;
                        if (orders[page - 1].State == "未支付")
                        {
                            Button4.Visible = true;
                            Button4.Text = "确认支付";
                        }
                        else if (orders[page - 1].State == "已收货" || orders[page - 1].State == "已支付")
                        {
                            Button4.Visible = false;
                        }
                        Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个", ordersnum, page);
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
                Product product = productclient.GetProductInfo(orders[page - 1].ProductID);
                Customer customer = customerclient.GetCustomerInfoWithID(orders[page - 1].CustomerID);
                this.Name.Text = product.Name;
                this.Price.Text = "￥" + product.Price.ToString();
                this.Description.Text = product.Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                this.CustomerName.Text = customer.Name;
                this.Phone.Text = customer.Phone;
                this.Email.Text = customer.Email;
                this.Address.Text = customer.Address;
                this.State.Text = orders[page - 1].State;
                if (orders[page - 1].State == "未支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "确认支付";
                }
                else if (orders[page - 1].State == "已收货" || orders[page - 1].State == "已支付")
                {
                    Button4.Visible = false;
                }
                Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个", ordersnum, page);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (page < ordersnum)
            {
                page++;
                Product product = productclient.GetProductInfo(orders[page - 1].ProductID);
                Customer customer = customerclient.GetCustomerInfoWithID(orders[page - 1].CustomerID);
                this.Name.Text = product.Name;
                this.Price.Text = "￥" + product.Price.ToString();
                this.Description.Text = product.Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                this.CustomerName.Text = customer.Name;
                this.Phone.Text = customer.Phone;
                this.Email.Text = customer.Email;
                this.Address.Text = customer.Address;
                this.State.Text = orders[page - 1].State;
                if (orders[page - 1].State == "未支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "确认支付";
                }
                else if (orders[page - 1].State == "已收货" || orders[page - 1].State == "已支付")
                {
                    Button4.Visible = false;
                }
                Label1.Text = string.Format("共查询到{0}个订单，当前是第{1}个", ordersnum, page);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (orders[page - 1].State == "未支付")
            {
                orderclient.UpdateOrderState(orders[page - 1].ID, "已支付");
            }
            Response.Redirect("StoreManagementOrder.aspx");
        }
    }
}