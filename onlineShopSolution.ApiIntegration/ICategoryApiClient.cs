using onlineShopSolution.ViewModel.Catalog.Categories;
using onlineShopSolution.ViewModel.Catalog.Products;
using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<PagedResult<CategoryViewModel>> GetPagings(GetManageCategoryPagingRequest request);
        Task<List<CategoryViewModel>> GetAll(string languageId);
        Task<CategoryViewModel> GetById(string languageId, int id);
        Task<bool> Create(CategoryCreateRequest request);
        Task<bool> Update(CategoryViewModel request);
        Task<bool> DeleteCategory(int id);
    }
}
