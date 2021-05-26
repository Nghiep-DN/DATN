using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }

        // sản phẩm nổi bật ?
        public bool? IsFeatured { get; set; }


        // lien ket toi bang trung gian ProductInCategory
        public List<ProductInCategory> ProductInCategories { set; get; }

        //lien ket toi bang OrderDetail
        public List<OrderDetail> OrderDetails { set; get; }

        public List<ProductTranslation> ProductTranslations { set; get; }
        public List<ProductImage> ProductImages { set; get; }

        public List<Cart> Carts { set; get; }

    }
}
