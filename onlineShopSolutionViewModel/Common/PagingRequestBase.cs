using System;
using System.Collections.Generic;
using System.Text;

namespace onlineShopSolution.ViewModel.Common
{
    /// <summary>
    /// dùng chung, vì tất cả các phân trang đều có 2 tham số này
    /// </summary>
  public  class PagingRequestBase
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }
}
