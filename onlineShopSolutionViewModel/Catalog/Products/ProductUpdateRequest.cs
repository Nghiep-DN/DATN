using Microsoft.AspNetCore.Http;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    /// <summary>
    /// khi thay đổi Product nên thay đổi các trường cơ bản này(ở ProductTranslation), các trường khác giữ nguyên
    /// </summary>
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool? IsFeatured { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        public IFormFile ThumbnailImage { get; set; }


    }
}
