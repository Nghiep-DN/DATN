using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.ViewModel.Sales;
using onlineShopSolution.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IUserApiClient _userApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient,IUserApiClient userApiClient, IHttpContextAccessor httpContextAccessor)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
            _httpContextAccessor = httpContextAccessor;
            _userApiClient = userApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int id,string languageId)
        {
            var product =await _productApiClient.GetById(id,languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                //lay ra dang string =>sau chuyen JsonConvert.DeserializeObject<List<CartItemViewModel>>
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }
           

            //neu TH: co sp trong gio thi sl = sl+1
            int quantity = 1;
            if (currentCart.Any(x => x.ProductId == id))
            {
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            }
            var cartItem = new CartItemViewModel()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Price=product.Price,
                Quantity=quantity
            };
        
            currentCart.Add(cartItem);
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart)); //chuyen qua string
            return Ok(currentCart);
        }
        [HttpGet]
        public IActionResult GetListCartItem()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public  IActionResult UpdateCart(int id, int quantity)
        {
           
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
            {
                //lay ra dang string =>sau chuyen JsonConvert.DeserializeObject<List<CartItemViewModel>>
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            }


            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }
            
            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart)); //chuyen qua string
            return Ok(currentCart);
        }
        public IActionResult CheckOut()
        {
            var model = GetCheckoutViewModel();
            return View(model) ;
        }

        //public IActionResult CheckOut()
        //{

        //    return View(GetCheckoutViewModel());
        //}

        //[HttpPost]
        //public async Task<IActionResult> CheckOut(CheckoutViewModel request)
        //{
        //    //var userId = await _userApiClient.GetById(request.CheckoutModel.UserId);

        //    var model = GetCheckoutViewModel();
        //    var orderDetails = new List<OrderDetailViewModel>();
        //    foreach (var item in model.CartItems)
        //    {
        //        orderDetails.Add(new OrderDetailViewModel()
        //        {
        //            ProductId = item.ProductId,
        //            Quantity = item.Quantity
        //        });
        //    }
        //    var checkoutRequest = new CheckoutRequest()
        //    {
        //        //UserId=userId.ResultObj.Id,
        //        Address = request.CheckoutModel.Address,
        //        Name = request.CheckoutModel.Name,
        //        Email = request.CheckoutModel.Email,
        //        PhoneNumber = request.CheckoutModel.PhoneNumber,
        //        OrderDetails = orderDetails
        //    };
        //    //TODO: Add to API

        //     var result = await _orderApiClient.CreatedOrder(checkoutRequest);
        //    //var result = true;
        //    if (result.IsSuccessed)
        //    {
        //        TempData["SuccessMsg"] = "Order puschased successful";
        //        return View(model);
        //        //return View(checkoutRequest);
        //    }
        //    ModelState.AddModelError("", "Order puschased unsuccessfully.");
        //   // return View(request);
        //    return View(model);

        //}

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
