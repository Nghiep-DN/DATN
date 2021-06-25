using onlineShopSolution.ViewModel.Utilities.Slides;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using onlineShopSolution.ViewModel.Common;
using System.IO;
using onlineShopSolution.Utilities.Constants;
using System.Net.Http.Headers;
using System;

namespace onlineShopSolution.ApiIntegration
{
    public class SlideApiClient : BaseApiClient, ISlideApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public SlideApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(SlideCreateRequest request)
        {
       
                var sessions = _httpContextAccessor
                    .HttpContext
                    .Session
                    .GetString(SystemConstants.AppSettings.Token);

                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

                var requestContent = new MultipartFormDataContent();

                if (request.ThumbnailImage != null)
                {
                    byte[] data;
                    using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                    {
                        data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                    }
                    ByteArrayContent bytes = new ByteArrayContent(data);
                    requestContent.Add(bytes, "ThumbnailImage", request.ThumbnailImage.FileName);
                }

                requestContent.Add(new StringContent(request.Name.ToString()), "name");
                requestContent.Add(new StringContent(request.Description.ToString()), "description");
                requestContent.Add(new StringContent(request.SortOrder.ToString()), "SortOrder");
              
                requestContent.Add(new StringContent(request.Status.ToString()), "Status");


                var response = await client.PostAsync($"/api/slides/", requestContent);
                return response.IsSuccessStatusCode;
            
        }

        public async Task<List<SlideViewModel>> GetAll()
        {
            return await GetListAsync<SlideViewModel>("/api/slides");
        }

        public async Task<PagedResult<SlideViewModel>> GetPaging(SlidePagingRequest request)
        {
            var data = await GetAsync<PagedResult<SlideViewModel>>($"/api/slides/paging?pageIndex={request.pageIndex}" +
                 $"&pageSize={request.pageSize}" +
                 $"&keyword={request.Keyword}");
            return data;
        }
        public async Task<bool> DeleteSlide(int id)
        {
            return await Delete("/api/slides/" + id);
        }
    }
}