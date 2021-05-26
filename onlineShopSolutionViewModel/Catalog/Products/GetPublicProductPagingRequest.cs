using onlineShopSolution.ViewModel.Common;

namespace onlineShopSolution.ViewModel.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; } // ? có thể null
    }
}
