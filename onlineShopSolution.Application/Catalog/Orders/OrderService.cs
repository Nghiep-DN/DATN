using onlineShopSolution.Data.Entities;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Orders
{
    public class OrderService : IOrderService
    {
        private readonly OnlineShopDbContext _context;
        public OrderService(OnlineShopDbContext context)
        {
            _context = context;
        }
        //public async Task<bool> Checkout(CheckoutRequest request)
        //{
        //    //  var languages = _context.Languages;

        //    //try
        //    //{
        //        var order = new Order()
        //        {
        //            Id=1,
        //            UserId= new Guid("4D78A60A-2DB4-4E79-872D-0D5DF839EA03"),
        //            ShipName = request.Name,
        //            ShipAddress = request.Address,
        //            ShipEmail = request.Email,
        //            ShipPhoneNumber = request.PhoneNumber,
        //            OrderDate = DateTime.Now,
        //            Status=Data.Enums.OrderStatus.Confirmed,
        //            //  OrderDetails = orderDetail,

        //        };

        //        _context.Orders.Add(order);
        //       // await _context.SaveChangesAsync();
        //    try { 

        //        foreach (var item in request.OrderDetails)
        //        {
        //            _context.OrderDetails.Add(new OrderDetail()
        //            {
        //                OrderId = order.Id,
        //                ProductId = item.ProductId,
        //                Quantity = item.Quantity,

        //            });
        //        await _context.SaveChangesAsync();
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        return false;
        //    }
        //}

        public async Task<bool> Checkout(CheckoutRequest request)
        {
           
            try
            {
                foreach (var item in request.OrderDetails)
                {
                    _context.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = await CreatedOrder(request),
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                   

                    });
                    await _context.SaveChangesAsync();
                }
              


                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private async Task<int> CreatedOrder(CheckoutRequest request)
        {
            try
            {
                var order = new Order()
                {
                    //Id = 1,
                    UserId = new Guid("1C3B7225-2EC3-4CAE-99AB-08D8E090DBE4"),
                    ShipName = request.Name,
                    ShipAddress = request.Address,
                    ShipEmail = request.Email,
                    ShipPhoneNumber = request.PhoneNumber,
                    OrderDate = DateTime.Now,
                    Status = Data.Enums.OrderStatus.Confirmed,
                    //  OrderDetails = orderDetail,
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order.Id;
            }
            catch(Exception e)
            {
                return 500;
            }
          
        }

    }
}
