using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.AdminApp.Controllers
{
    public class SlideController : Controller
    {
        private readonly ISlideApiClient _slideApiClient;

        public SlideController(ISlideApiClient slideApiClient)
        {
            _slideApiClient = slideApiClient;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> loadData(string keyword, int pageIndex = 1, int pageSize = 5)
        {
            var request = new SlidePagingRequest()
            {
                Keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
            var feedback = await _slideApiClient.GetPaging(request);
            return Json(new { data = feedback, status = true });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm]SlideCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(request);
            }
            var result = await _slideApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Create slide successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Create slide unsuccessfully.");
            return View(request);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{


        //    var slide = await _slideApiClient.GetById(id);
        //    var editVm = new SlideUpdateRequest()
        //    {
        //        Id = slide.Id,
        //        Description = slide.Description,
        //        SortOrder = slide.SortOrder,
        //        Name = slide.Name,


        //    };
        //    return View(editVm);
        //}

        //[HttpPost]
        //[Consumes("multipart/form-data")]
        //public async Task<IActionResult> Edit([FromForm] SlideUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View(request);

        //    var result = await _slideApiClient.Update(request);
        //    if (result)
        //    {
        //        TempData["result"] = "Update product successfully.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Update product unsuccessfully.");
        //    return View(request);
        //}

        public async Task<JsonResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var feedback = await _slideApiClient.DeleteSlide(id);
                return Json(new { status = 200, message = "success", dataId = id });
            }
            return Json(new { status = 500, message = "error" });
        }

    }
}
