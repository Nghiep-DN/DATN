using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using onlineShopSolution.Data.Entities;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.System.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IConfiguration _config;
        private readonly OnlineShopDbContext _context;

        public LanguageService(IConfiguration config,OnlineShopDbContext context)
        {

            _config = config;
            _context = context;
        }
        public async Task<ApiResult<List<LanguageViewModel>>> GetAll()
        {
            var languages= await _context.Languages.Select(x=>new LanguageViewModel()
            {
                Id=x.Id,
                Name=x.Name,
                IsDefault = x.IsDefault
            }).ToListAsync();

            return new ApiSuccessResult<List<LanguageViewModel>>(languages);
        }
      
      
      
    }
}
