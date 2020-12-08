using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services
{
    public class Product
    {
        int id;
        int storeID;
        string name;
        string description;
        double price;
        int viewtimes;

        public int ID { get => id; set => id = value; }
        public int StoreID { get => storeID; set => storeID = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public int ViewTimes { get => viewtimes; set => viewtimes = value; }
    }
}