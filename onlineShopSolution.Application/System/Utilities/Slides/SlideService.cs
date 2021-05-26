using Microsoft.EntityFrameworkCore;
using onlineShopSolution.Data.Entities;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.System.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly OnlineShopDbContext _context;
        public SlideService( OnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<SlideViewModel>>GetAll()
        {
            var slides = await _context.Slides.OrderBy(x=>x.SortOrder).Select(x => new SlideViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                Image=x.Image,
                Url=x.Url,
           
            }).ToListAsync();

            return  slides;
        }

    }
}
