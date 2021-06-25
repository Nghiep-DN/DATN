using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.ViewModel.Catalog.Products;
using onlineShopSolution.ViewModel.Contacts;
using onlineShopSolution.WebApp.Models;

namespace onlineShopSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly IContactApiClient _contactApiClient;

        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient, IProductApiClient productApiClient, ICategoryApiClient categoryApiClient, IContactApiClient contactApiClient)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
            _contactApiClient = contactApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int? categoryId, int pageIndex = 1, int pageSize = 6)
        {
            var culture = CultureInfo.CurrentCulture.Name;

          
            var request = new GetManageProductPagingRequest()
            {
                LanguageId=culture,
                Keyword = keyword,
                pageIndex = pageIndex,
                pageSize = pageSize,
                CategoryId = categoryId
            };
            var data = await _productApiClient.GetPagings(request);
            ViewBag.Keyword = keyword;

            var categories = await _categoryApiClient.GetAll(culture);
            ViewBag.Categories = categories.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = categoryId.HasValue && categoryId.Value == x.Id
            });

           
             var viewModel = new HomeViewModel
            {
                Slides = await _slideApiClient.GetAll(),
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(culture, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LatestProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts),
                RelevantProducts = data,
               

            };
           
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

      
        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var request = new FeedbackRequest()
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Message = model.Message
            };

            var result = await _contactApiClient.CreateFeedback(request);

            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Feedback successfully";
                return View(model);
            }
            ModelState.AddModelError("", "Feedback  unsuccessfully.");
            return View(request);
        }
        public IActionResult News()
        {

            return View();
        }

    }
}
