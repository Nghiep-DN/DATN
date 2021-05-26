using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.System;
using onlineShopSolution.ViewModel.System.Users;
using System;
using System.Threading.Tasks;

namespace onlineShopSolution.ApiIntegration
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest registerRequest);
        Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request);
        Task<ApiResult<UserViewModel>> GetById(Guid id);
        Task<ApiResult<bool>> Delete(Guid id);
        Task<ApiResult<bool>> RoleAssign(Guid id,RoleAssignRequest request);
    }
}
