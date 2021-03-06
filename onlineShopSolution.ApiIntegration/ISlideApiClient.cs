using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface ISlideApiClient
    {
        Task<List<SlideViewModel>> GetAll();
        Task<PagedResult<SlideViewModel>> GetPaging(SlidePagingRequest request);
        Task<bool> Create(SlideCreateRequest request);
        Task<bool> DeleteSlide(int id);
    }
}
