using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    /// <summary>
    /// khi thay đổi Product nên thay đổi các trường cơ bản này(ở ProductTranslation), các trường khác giữ nguyên
    /// </summary>
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        [Display(Name="Tên")]
        public string Name { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [Display(Name = "Chi tiết")]
        public string Details { get; set; }
        [Display(Name = "Nổi bật")]
        public bool? IsFeatured { get; set; }
        [Display(Name = "SEO Des")]
        public string SeoDescription { get; set; }
        [Display(Name = "SEO Ti")]
        public string SeoTitle { get; set; }
        [Display(Name = "SEO Al")]
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        [Display(Name = "Ảnh")]
        public IFormFile ThumbnailImage { get; set; }


    }
}
