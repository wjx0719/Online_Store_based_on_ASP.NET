using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Services
{
    public class Store
    {
        int id;
        string name;
        string password;
        string phone;
        string email;

        public int ID { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
    }
}