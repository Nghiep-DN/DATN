﻿using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Catalog.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LanguageId { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
    }
}
