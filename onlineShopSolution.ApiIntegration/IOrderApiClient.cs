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
        //client
        Task<bool> Create(CheckoutRequest request);
        Task<ApiResult<bool>> CreatedOrder(CheckoutRequest request);
        //admin
        Task<bool> Delete(int id);
        Task<OrderViewModel> GetDetail(int id);
        Task<PagedResult<OrderViewModel>> GetPaging(OrderPagingRequest request);
    }
}
