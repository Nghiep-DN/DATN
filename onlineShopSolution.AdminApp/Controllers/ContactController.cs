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
            return Json(new { data = feedback.Items, status = true });
        }

        //    public async Task<JsonResult> Index()
        //    {

        //        //var data = await _categoryApiClient.GetPagings(request);
        //        var categories = await _contactApiClient.GetAll();
        //        var objResponse1 =
        //JsonConvert.DeserializeObject<List<FeedbackViewModel>>(categories.ToList());
        //        return Json(categories);
        //    }
    }
}
