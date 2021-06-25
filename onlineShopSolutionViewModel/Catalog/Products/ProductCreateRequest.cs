using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        //[Required(ErrorMessage = "Price required input.")]
        [Display(Name="Giá bán")]
        public decimal Price { get; set; }
        // [Required(ErrorMessage = "Original price required input.")]
        [Display(Name = "Giá nhập")]
        public decimal OriginalPrice { get; set; }
        [Display(Name= "Số lượng")]
        public int Stock { get; set; }
        //[Required(ErrorMessage = "Name required input.")]
        [Display(Name = "Tên")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Chi tiết")]
        public string Details { get; set; }
        [Display(Name = "Nổi bật")]
        public bool IsFeatured { get; set; }
        [Display(Name = "SEO De")]
        public string SeoDescription { get; set; }
        [Display(Name = "SEO Ti")]
        public string SeoTitle { get; set; }
        [Display(Name = "SEO Al")]
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        // [Required(ErrorMessage = "File required input.")]
        [Display(Name = "Ảnh")]
        public IFormFile ThumbnailImage { get; set; }
    }
}
