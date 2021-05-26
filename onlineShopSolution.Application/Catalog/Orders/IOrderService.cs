using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Orders
{
    public interface IOrderService
    {
        Task<bool> Checkout(CheckoutRequest request);
    }
}
