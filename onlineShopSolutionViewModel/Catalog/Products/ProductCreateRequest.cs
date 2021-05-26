using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        //[Required(ErrorMessage = "Price required input.")]
        public decimal Price { get; set; }
       // [Required(ErrorMessage = "Original price required input.")]
        public decimal OriginalPrice { get; set; }
        [Display(Name= "Inventory")]
        public int Stock { get; set; }
        //[Required(ErrorMessage = "Name required input.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool IsFeatured { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
       // [Required(ErrorMessage = "File required input.")]
        public IFormFile ThumbnailImage { get; set; }
    }
}
