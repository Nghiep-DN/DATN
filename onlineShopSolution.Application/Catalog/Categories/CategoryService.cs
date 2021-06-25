using onlineShopSolution.Data.Entities;
using onlineShopSolution.ViewModel.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using onlineShopSolution.Utilities.Constants;
using onlineShopSolution.Utilities;
using onlineShopSolution.ViewModel.Common;

namespace onlineShopSolution.Application.Catalog.Categories
{

    public class CategoryService : ICategoryService

    {
        private readonly OnlineShopDbContext _context;

        public CategoryService(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryCreateRequest request)
        {
            var languages = _context.Languages;
            var translations = new List<CategoryTranslation>();
            foreach (var language in languages)
            {
                if (language.Id == request.LanguageId)
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = request.Name,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoTitle = request.SeoTitle,
                        LanguageId = request.LanguageId
                    });
                }
                else
                {
                    translations.Add(new CategoryTranslation()
                    {
                        Name = SystemConstants.CategoryConstants.NA,
                        SeoDescription = SystemConstants.CategoryConstants.NA,
                        SeoAlias = SystemConstants.CategoryConstants.NA,
                        SeoTitle = SystemConstants.CategoryConstants.NA,
                        LanguageId = language.Id
                    });
                }
              
            }
            var category = new Category()
            {
                IsShowOnHome = request.IsShowOnHome,
                CategoryTranslations=translations
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<int> DeleteCategory(int id)
        {
            var cateId = await _context.Categories.FindAsync(id);
            if (cateId == null)
            {
                throw new onlineShopNotFoundException($"Cannot find a categoryId: { id }");
            }
            _context.Categories.Remove(cateId);
            return await _context.SaveChangesAsync();

        }

        public async Task<List<CategoryViewModel>> GetAll(string languageId)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            return await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                SeoAlias=x.ct.SeoAlias,
                SeoDescription=x.ct.SeoDescription,
                SeoTitle=x.ct.SeoTitle,
                IsShowOnHome=x.c.IsShowOnHome
                
            }).ToListAsync();

        }
        public async Task<CategoryViewModel> GetById(string languageId, int id)
        {
            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId && c.Id == id
                        select new { c, ct };
            return await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name,
                ParentId = x.c.ParentId,
                SeoDescription=x.ct.SeoDescription,
                SeoAlias=x.ct.SeoAlias,
                SeoTitle=x.ct.SeoTitle
            }).FirstOrDefaultAsync();
        }

        public async Task<int> Update(CategoryViewModel request)
        {
            var category = await _context.Categories.FindAsync(request.Id);
           
            var cateTranslations = await _context.CategoryTranslations.FirstOrDefaultAsync(x => x.CategoryId == request.Id && x.LanguageId==request.LanguageId);

            if(category==null || cateTranslations == null)
            {
              throw new  onlineShopNotFoundException($"Cannot find a category with id: {request.Id}");
            }


            cateTranslations.Name = request.Name;
            cateTranslations.SeoDescription = request.SeoDescription;
            cateTranslations.SeoAlias = request.SeoAlias;
            cateTranslations.SeoTitle = request.SeoTitle;
            category.IsShowOnHome = request.IsShowOnHome;
            //dùng cái nào thì thêm sau 
             
            return await _context.SaveChangesAsync(); 
        }
        public async Task<PagedResult<CategoryViewModel>> GetPaging(GetManageCategoryPagingRequest request)
        {

            var query = from c in _context.Categories
                        join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId ==request.LanguageId
                        select new { c, ct };

            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.ct.Name.Contains(request.Keyword));


            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new CategoryViewModel()
                {
                    Id = x.c.Id,
                    Name = x.ct.Name,
                    LanguageId = x.ct.LanguageId,
                    SeoAlias = x.ct.SeoAlias,
                    SeoDescription = x.ct.SeoDescription,
                    SeoTitle = x.ct.SeoTitle,
                  
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<CategoryViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Items = data
            };
            return pagedResult;
        }


    }
}
