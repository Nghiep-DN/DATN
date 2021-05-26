using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ViewModel.Catalog.ProductImages;
using onlineShopSolution.ViewModel.Catalog.Products;
using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface IProductApiClient
    {
        Task<PagedResult<ProductViewModel>> GetPagings(GetManageProductPagingRequest request);
        Task<bool> CreateProduct(ProductCreateRequest request);
        Task<bool> UpdateProduct(ProductUpdateRequest request);
        Task<bool> DeleteProduct(int id);
        // Task<ApiResult<ProductViewModel>> GetById(Guid id,string languageId);
        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);
        Task<ProductViewModel> GetById(int id, string languageId);
        Task<List<ProductViewModel>> GetFeaturedProducts(string languageId,int take);
        Task<List<ProductViewModel>> GetLatestProducts(string languageId,int take);
        Task<PagedResult<ProductViewModel>> GetRelevantProducts(GetManageProductPagingRequest request);
      
        Task<List<ProductImageViewModel>> GetListImages(int productId);
       
         Task<ProductImageViewModel> GetImageById(int imageId);
       
    }
}
