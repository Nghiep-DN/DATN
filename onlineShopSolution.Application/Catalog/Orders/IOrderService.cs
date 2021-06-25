using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Orders
{
    public interface IOrderService
    {
        //web
        Task<bool> Checkout(CheckoutRequest request);
        //admin
        Task<OrderViewModel> GetDetail(int id);
        Task<PagedResult<OrderViewModel>> GetPaging(OrderPagingRequest request);
        Task<int> Delete(int id);
    }
}
