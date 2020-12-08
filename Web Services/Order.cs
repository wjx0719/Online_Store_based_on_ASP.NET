using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services
{
    public class Order
    {
        int id;
        int productID;
        int customerID;
        int storeid;
        string state;

        public int ID { get => id; set => id = value; }
        public int ProductID { get => productID; set => productID = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public int StoreID { get => storeid; set => storeid = value; }
        public string State { get => state; set => state = value; }
    }
}