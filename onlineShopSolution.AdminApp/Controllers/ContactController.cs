using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.AdminApp.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactApiClient _contactApiClient;
        public ContactController(IContactApiClient contactApiClient)
        {
          _contactApiClient=contactApiClient;
        }
        public ActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 5)
        //{
        //    var request = new FeedbackPagingRequest()
        //    {
        //        Keyword = keyword,
        //        pageIndex = pageIndex,
        //        pageSize = pageSize
        //    };
        //    var feedback = await _contactApiClient.GetPaging(request);
        //    return View(feedback);
        //}
        [HttpGet]
        public async Task<IActionResult> loadData(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new FeedbackPagingRequest()
            {
                Keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var feedback = await _contactApiClient.GetPaging(request);
            return Json(new { data = feedback, status = true });
        }

        public async Task<JsonResult> DeleteFeedback(int id)
        {
            if (ModelState.IsValid)
            {
                var feedback = await _contactApiClient.DeleteFeedback(id);
                return Json(new { status = 200, message = "success", dataId = id });
            }
            return Json(new { status = 500, message = "error" });
        }
        public async Task<JsonResult> GetDetail(int id)
        {
            if (ModelState.IsValid)
            {
                var feedback = await _contactApiClient.GetDetail(id);
                return Json(new { status = true, message = "success", data = feedback });
            }
            return Json(new { status = 500, message = "error" });
        }
    }
}
