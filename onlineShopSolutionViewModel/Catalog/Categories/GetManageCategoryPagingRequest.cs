﻿using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Catalog.Categories
{
    public class GetManageCategoryPagingRequest:PagingRequestBase
    {
        public string LanguageId { get; set; }
    }
}
