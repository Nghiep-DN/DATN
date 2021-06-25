using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.ViewModel.Sales;
using onlineShopSolution.ViewModel.SendMail;
using onlineShopSolution.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Controllers
{
    public class CheckoutController : BaseController
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendMailApiClient _sendMailApiClient;
        public CheckoutController(IProductApiClient productApiClient, IOrderApiClient orderApiClient, IUserApiClient userApiClient, IHttpContextAccessor httpContextAccessor, ISendMailApiClient sendMailApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
            _httpContextAccessor = httpContextAccessor;
            _userApiClient = userApiClient;
            _sendMailApiClient = sendMailApiClient;
        }

        public IActionResult CheckOut()
        {
            return View(GetCheckoutViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckoutViewModel request)
        {
            //var userId = await _userApiClient.GetById(request.CheckoutModel.UserId);

            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailViewModel>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailViewModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckoutRequest()
            {
                
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                Email = request.CheckoutModel.Email,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            //TODO: Add to API

            var result = await _orderApiClient.CreatedOrder(checkoutRequest);
            //var result = true;
            if (result.IsSuccessed)
            {
                var session = HttpContext.Session.GetString(SystemConstants.CartSession);

                //await HttpContext.SignOutAsync(
                //     CookieAuthenticationDefaults.AuthenticationScheme);
                //HttpContext.Session.Remove("Token");
                //HttpContext.Session.Remove(session);
               

               

                MailContent content = new MailContent
                {
                    To = "esinfarm@gmail.com",
                    Subject = "Đơn đặt hàng mới",
                    Body = "<p><strong>Đơn đặt hàng mới</strong></p>",
                    Name = "<p>"+ checkoutRequest.Name.ToString() + "</p>",
                    Address = checkoutRequest.Address.ToString(),
                    PhoneNumber = checkoutRequest.PhoneNumber.ToString(),
                };

                await _sendMailApiClient.SendMail(content);
                //await HttpContext.Response.WriteAsync("Send mail success");
                TempData["SuccessMsg"] = "Cảm ơn! Bạn đã đặt hàng thành công.";
                return View(model);
                //return View(checkoutRequest);
            }
            ModelState.AddModelError("", "Bạn đặt hàng chưa thành công.");
            // return View(request);
            return View(model);

        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
        }
    }
}
