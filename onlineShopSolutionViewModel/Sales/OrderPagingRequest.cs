using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Sales
{
    public class OrderPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
