using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.Catalog.Orders;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Globalization;
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


        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] OrderPagingRequest request)
        {
            var od = await _orderService.GetPaging(request);
            return Ok(od);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var od = await _orderService.Delete(id);
            return Ok(new { status = 200, message = "Success.", dataId = id });
        }
        [HttpGet("getDetail/{id}")]
        public async Task<IActionResult> getDetail(int id)
        {
            var od = await _orderService.GetDetail(id);
            return Ok(od);
        }

    //    DateTime fromDate = new DateTime();

    //            if (CheckDate(grossProfitFrom))
    //            {
    //                fromDate = DateTime.ParseExact(grossProfitFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    //            }


    //private bool CheckDate(String date)
    //    {
    //        try
    //        {
    //            DateTime dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    }
}
