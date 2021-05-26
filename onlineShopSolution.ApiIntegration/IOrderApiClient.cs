using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface IOrderApiClient
    {
        Task<bool> Create(CheckoutRequest request);
        Task<ApiResult<bool>> CreatedOrder(CheckoutRequest request);
    }
}
