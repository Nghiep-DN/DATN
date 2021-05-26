using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Entities
{
    public class AppUser:IdentityUser<Guid> //khoa chinh cho toan bo ctrinh
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public List<Cart> Carts { get; set; }

        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }


    }
}
