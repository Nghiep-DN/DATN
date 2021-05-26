using onlineShopSolution.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }

        // lien ket toi bang trung gian ProductInCategory
        public List<ProductInCategory> ProductInCategories { set; get; }

        /// <summary>
        /// lien ket toi bang trung gian CategoryTranslations
        /// </summary>
        public List<CategoryTranslation> CategoryTranslations { set; get; }


    }
}
