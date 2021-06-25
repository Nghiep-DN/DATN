using onlineShopSolution.ViewModel.Catalog.Categories;
using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAll(string languageId);
        Task<CategoryViewModel> GetById(string languageId, int id);
        /// <summary>
        /// Tạo mới Category
        /// </summary>
        /// <param name="request"></param>
        /// <returns>categoryId</returns>
        Task<int> Create(CategoryCreateRequest request);
        Task<int> Update(CategoryViewModel request);
        Task<int> DeleteCategory(int id);
        Task<PagedResult<CategoryViewModel>> GetPaging(GetManageCategoryPagingRequest request);
    }
}
