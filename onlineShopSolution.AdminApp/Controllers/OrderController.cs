using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.AdminApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderApiClient _orderApiClient;
        public OrderController(IOrderApiClient orderApiClient)
        {
            _orderApiClient = orderApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> loadData(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new OrderPagingRequest()
            {
                Keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var order = await _orderApiClient.GetPaging(request);
            return Json(new { data = order, status = true });
        }

        public async Task<JsonResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var order = await _orderApiClient.Delete(id);
                return Json(new { status = 200, message = "success", dataId = id });
            }
            return Json(new { status = 500, message = "error" });
        }
        public async Task<JsonResult> GetDetail(int id)
        {
            if (ModelState.IsValid)
            {
                var order = await _orderApiClient.GetDetail(id);
                return Json(new { status = true, message = "success", data = order });
            }
            return Json(new { status = 500, message = "error" });
        }
        //public JsonResult UpdateStatus(Data.Enums.OrderStatus stt)
        //{
        //    var status = _orderApiClient.UpdateStatus(stt)
        //    return Json(new { });
        //}
    }
}
