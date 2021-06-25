using onlineShopSolution.Data.Enum;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.System.Utilities.Slides
{
    public interface ISlideService
    {
        Task<List<SlideViewModel>> GetAll();
        Task<PagedResult<SlideViewModel>> GetPaging(SlidePagingRequest request);
        Task<int> Created(SlideCreateRequest request);
        Task<int> DeleteSlide(int id);
    }
}
