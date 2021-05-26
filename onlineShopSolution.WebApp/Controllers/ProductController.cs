using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.ViewModel.Catalog.Products;
using onlineShopSolution.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
          
            var product = await _productApiClient.GetById(id, culture);
            return View(new ProductDetailViewModel()
            {
                Product = product,
                //Category = await _categoryApiClient.GetById(culture, id),
                ProductImages = await _productApiClient.GetListImages(id),
                RelatedProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts)
            }); 
        }
        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {

            var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                pageIndex = page,
                LanguageId = culture,
                pageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            }); 
        
        }

        //public async Task<IActionResult> GetRelatedProduct()
        //{
        //    string culture = CultureInfo.CurrentCulture.Name;
        //    var viewModel = new ProductDetailViewModel
        //    {
        //        RelatedProducts = await _productApiClient.GetLatestProducts(culture, SystemConstants.ProductSettings.NumberOfLatestProducts)
        //    };

        //    return PartialView("_relatedProductPartial",viewModel);
        //}

    }
}
