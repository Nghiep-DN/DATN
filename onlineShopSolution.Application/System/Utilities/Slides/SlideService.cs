using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using onlineShopSolution.Application.Common;
using onlineShopSolution.Data.Entities;
using onlineShopSolution.Utilities;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace onlineShopSolution.Application.System.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        private readonly OnlineShopDbContext _context;
        public SlideService( OnlineShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> Created(SlideCreateRequest request)
        {
            var slide = new Slide()
            {
                Name = request.Name,
                Description = request.Description,
                SortOrder = request.SortOrder,
                Image = await this.SaveFile(request.ThumbnailImage),
                Url = "#",
                
            };
            //Save image
            //if (request.ThumbnailImage != null)
            //{
            //    slide.Image = new List<ProductImage>()
            //    {
            //        new ProductImage()
            //        {
            //            Caption = "Thumbnail image",
            //            DateCreated = DateTime.Now,
            //            FileSize = request.ThumbnailImage.Length,
            //            ImagePath = await this.SaveFile(request.ThumbnailImage),
            //            IsDefault = true,
            //            SortOrder = 1
            //        }
            //    };
            //}
            _context.Slides.Add(slide);
            await _context.SaveChangesAsync();
            return slide.Id;
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


        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<PagedResult<SlideViewModel>> GetPaging(SlidePagingRequest request)
        {
            var query = from c in _context.Slides
                        select c;
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword) );

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new SlideViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Image = x.Image,
                    SortOrder = x.SortOrder,
                    Url = x.Url,
                    Status=Data.Enum.Status.Active

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<SlideViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.pageSize,
                PageIndex = request.pageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> DeleteSlide(int id)
        {
            var slide = await _context.Slides.FindAsync(id);
            if (slide == null)
            {
                throw new onlineShopNotFoundException($"Cannot find a SlideId: { id }");
            }
            _context.Slides.Remove(slide);
            return await _context.SaveChangesAsync();
        }
    }
}
