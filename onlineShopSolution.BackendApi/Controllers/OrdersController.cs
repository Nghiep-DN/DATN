using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.Catalog.Orders;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
       // [Authorize]
        public async Task<IActionResult> Create(CheckoutRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool res = await _orderService.Checkout(request);
            if (!res)
            {
                return BadRequest();
            }


            // var product = await _productService.GetById(productId, request.LanguageId);

            //return CreatedAtAction(nameof(GetById), new { id = productId }, product);
            return Ok (new{ IsSuccessed=true, data =res }); ;
        }
    }
}
