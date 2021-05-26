using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Contacts
{
    public class FeedbackPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
