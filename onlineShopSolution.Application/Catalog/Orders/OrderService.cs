using onlineShopSolution.Data.Entities;
using onlineShopSolution.Utilities;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> Delete(int id)
        {
            var orderId = await _context.Orders.FindAsync(id);
            if (orderId == null)
            {
                throw new onlineShopNotFoundException($"Cannot find a orderId: { id }");
            }
            _context.Orders.Remove(orderId);
            return await _context.SaveChangesAsync();
        }

        public async Task<OrderViewModel> GetDetail(int id)
        {
            //var query = from o in _context.Orders
            //            join od in _context.OrderDetails on o.Id equals od.OrderId
            //            join p in _context.Products on od.ProductId equals p.Id into ppic
            //            from pic in ppic.odp()
            //            join c in _context.Categories on pic.CategoryId equals c.Id into picc
            //            from c in picc.DefaultIfEmpty()
            //            join pi in _context.ProductImages on p.Id equals pi.ProductId into ppi
            //            from pi in ppi.DefaultIfEmpty()
            //            where pt.LanguageId == request.LanguageId && pi.IsDefault == true
            //            select new { p, pt, pic, pi };


            // var product = await _context.Products.FindAsync(id);
            var order = await _context.Orders.FindAsync(id);
       
            var orderViewModel = new OrderViewModel()
            {
                Id = order.Id,
                ShipName = order.ShipName,
                ShipEmail = order.ShipEmail,
                ShipPhoneNumber = order.ShipPhoneNumber,
                ShipAddress = order.ShipAddress,
                OrderDate = order.OrderDate,
                Status = order.Status
            };
            return orderViewModel;
        }

        public async Task<PagedResult<OrderViewModel>> GetPaging(OrderPagingRequest request)
        {
            var query = from c in _context.Orders
                        select c;
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ShipName.Contains(request.Keyword) || x.ShipPhoneNumber.Contains(request.Keyword) || x.ShipEmail.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new OrderViewModel()
                {
                    Id = x.Id,
                    ShipName = x.ShipName,
                    ShipEmail = x.ShipEmail,
                    ShipPhoneNumber = x.ShipPhoneNumber,
                    ShipAddress = x.ShipAddress
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<OrderViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Items = data
            };
            return pagedResult;
        }
        // order được tạo bởi khách hàng
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
            catch (Exception e)
            {
                return 500;
            }

        }

    }
}
