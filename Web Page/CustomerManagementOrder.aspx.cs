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
    public partial class CustomerManagementOrder : System.Web.UI.Page
    {
        private static int page = 1;
        private static int ordersnum;
        private static OrderServiceSoapClient orderclient = new OrderServiceSoapClient();
        private static CustomerServiceSoapClient customerclient = new CustomerServiceSoapClient();
        private static ProductServiceSoapClient productclient = new ProductServiceSoapClient();
        private static StoreServiceSoapClient storeclient = new StoreServiceSoapClient();
        private static Order[] orders;

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
                    Customer customer = customerclient.GetCustomerInfo(Session["Name"].ToString());
                    orders = orderclient.GetOrderInfoForCustomer(customer.ID,out ordersnum);
                    if (ordersnum == 0)
                    {
                        Label1.Text = "未查询到订单信息";
                        Button4.Visible = false;
                    }
                    else
                    {
                        Product product = productclient.GetProductInfo(orders[page - 1].ProductID);
                        Store store = storeclient.GetStoreInfoWithID(orders[page - 1].StoreID);
                        this.Name.Text = product.Name;
                        this.Price.Text = "￥" + product.Price.ToString();
                        this.Description.Text = product.Description;
                        this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                        this.Phone.Text = store.Phone;
                        this.Email.Text = store.Email;
                        this.State.Text = orders[page - 1].State;
                        if(orders[page - 1].State == "未支付")
                        {
                            Button4.Visible = true;
                            Button4.Text = "删除订单";
                        }
                        else if(orders[page - 1].State == "已支付")
                        {
                            Button4.Visible = true;
                            Button4.Text = "确认收货";
                        }
                        else if(orders[page - 1].State == "已收货")
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
                Store store = storeclient.GetStoreInfoWithID(orders[page - 1].StoreID);
                this.Name.Text = product.Name;
                this.Price.Text = "￥" + product.Price.ToString();
                this.Description.Text = product.Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                this.Phone.Text = store.Phone;
                this.Email.Text = store.Email;
                this.State.Text = orders[page - 1].State;
                if (orders[page - 1].State == "未支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "删除订单";
                }
                else if (orders[page - 1].State == "已支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "确认收货";
                }
                else if (orders[page - 1].State == "已收货")
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
                Store store = storeclient.GetStoreInfoWithID(orders[page - 1].StoreID);
                this.Name.Text = product.Name;
                this.Price.Text = "￥" + product.Price.ToString();
                this.Description.Text = product.Description;
                this.Image.ImageUrl = "./ProductImg/ID_" + product.ID.ToString() + ".jpg";
                this.Phone.Text = store.Phone;
                this.Email.Text = store.Email;
                this.State.Text = orders[page - 1].State;
                if (orders[page - 1].State == "未支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "删除订单";
                }
                else if (orders[page - 1].State == "已支付")
                {
                    Button4.Visible = true;
                    Button4.Text = "确认收货";
                }
                else if (orders[page - 1].State == "已收货")
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
                orderclient.DeleteOrder(orders[page - 1].ID);
                Response.Redirect("CustomerManagementOrder.aspx");
            }
            else if (orders[page - 1].State == "已支付")
            {
                orderclient.UpdateOrderState(orders[page - 1].ID,"已收货");
                Response.Redirect("CustomerManagementOrder.aspx");
            }
        }
    }
}