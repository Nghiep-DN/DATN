using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Entities
{

    // bang trung gian de tao khoa nhieu vs nhieu
    public class ProductInCategory
    {
        public int ProductId { get; set; }
        public Product Product { set; get; }
        public int CategoryId { get; set; }
        public Category Category { set; get; }
    }
}
