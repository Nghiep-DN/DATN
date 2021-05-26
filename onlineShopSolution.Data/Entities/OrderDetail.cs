using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Entities
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //lien ket 1 1 voi Order
        public Order Order { set; get; }

        //lien ket 1 1 voi bang Product
        public Product Product { set; get; }

    }
}
