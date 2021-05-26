using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.Contacts
{
    public interface IContactService
    {
        Task<bool> CreateFeedback(FeedbackRequest request);
        Task<List<FeedbackViewModel>> GetAll();
        Task<PagedResult<FeedbackViewModel>> GetPaging(FeedbackPagingRequest request);
        Task<int> DeleteFeedback(int id);
    }
}
