using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface IContactApiClient
    {
        Task<ApiResult<bool>> CreateFeedback(FeedbackRequest request);
        Task<List<FeedbackViewModel>> GetAll();
        Task<PagedResult<FeedbackViewModel>> GetPaging(FeedbackPagingRequest request);
    }
}
