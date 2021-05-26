using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.ViewModel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.AdminApp.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryApiClient _categoryApiClient;
        public CategoryController(ICategoryApiClient categoryApiClient)
        {
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Index()
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var request = new GetManageCategoryPagingRequest()
            {
                LanguageId = languageId
            };
            //var data = await _categoryApiClient.GetPagings(request);
            var categories = await _categoryApiClient.GetAll(languageId);
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateRequest request)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            var rq = new CategoryCreateRequest()
            {
                LanguageId = languageId,
                Name = request.Name,
                SeoAlias = request.SeoAlias,
                SeoDescription = request.SeoDescription,
                SeoTitle = request.SeoTitle
            };
            var result = await _categoryApiClient.Create(rq);
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return Content(str, "application/json; charset=utf-8");
        }

        public async Task<JsonResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var cate = await _categoryApiClient.DeleteCategory(id);
                return Json(new { status = 200, message = "success", dataId = id });
            }
            return Json(new { status = 500, message = "error" });
        }

        public async Task<JsonResult> GetDetail(int id)
        {
            var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            if (ModelState.IsValid)
            {
                var cate = await _categoryApiClient.GetById(languageId,id);
                return Json(new { status = 200, message = "success", data = cate });
            }
            return Json(new { status = 500, message = "error" });
        }

        [HttpPost]
        public async Task<IActionResult> SaveData([FromForm] CategoryViewModel request)
        {
            
            int statusCode=0;
            string message="";

            if (request.Id == 0)
            {
                var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
                var rq = new CategoryCreateRequest()
                {
                    LanguageId = languageId,
                    Name = request.Name,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoTitle = request.SeoTitle
                };
                var rs = await _categoryApiClient.Create(rq);

                statusCode = 201;
                message = "Add successfully";
            }
            else
            {
                var languageId = HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
                var rq = new CategoryViewModel()
                {
                    Id=request.Id,
                    LanguageId = languageId,
                    Name = request.Name,
                    SeoAlias = request.SeoAlias,
                    SeoDescription = request.SeoDescription,
                    SeoTitle = request.SeoTitle
                };
                var rs = await _categoryApiClient.Update(rq);

                statusCode = 200;
                message = "Update successfully";
            }
            return Json(new {status=statusCode,message=message });
        }

    }
}