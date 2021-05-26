using onlineShopSolution.Data.Entities;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using onlineShopSolution.Utilities;
using onlineShopSolution.ViewModel.Common;

namespace onlineShopSolution.Application.Contacts
{
    public class ContactService : IContactService
    {
        private readonly OnlineShopDbContext _context;
        public ContactService(OnlineShopDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateFeedback(FeedbackRequest request)
        {
                try
                {
                    var feedback = new Contact()
                    {
                        Name=request.Name,
                        Email=request.Email,
                        PhoneNumber=request.PhoneNumber,
                        Message=request.Message,
                    };
                    _context.Contacts.Add(feedback);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
        }

        public async Task<int> DeleteFeedback(int id)
        {
            var feedbackId = await _context.Contacts.FindAsync(id);
            if (feedbackId == null)
            {
                throw new onlineShopNotFoundException($"Cannot find a feedbackId: { id }");
            }
            _context.Contacts.Remove(feedbackId);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<FeedbackViewModel>> GetAll()
        {
            var query = from c in _context.Contacts
                        select c;
            return await query.Select(x=>new FeedbackViewModel()
            {
                Id=x.Id,
                Email=x.Email,
                Name=x.Name,
                PhoneNumber=x.PhoneNumber,
                Message=x.Message,
                Status=x.Status
            }).ToListAsync();
        }

        public async Task<PagedResult<FeedbackViewModel>> GetPaging(FeedbackPagingRequest request)
        {
            var query = from c in _context.Contacts
                        select c;
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.Name.Contains(request.Keyword)||x.PhoneNumber.Contains(request.Keyword)||x.Email.Contains(request.Keyword));

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.pageIndex - 1) * request.pageSize)
                .Take(request.pageSize)
                .Select(x => new FeedbackViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                   Email=x.Email,
                   PhoneNumber=x.PhoneNumber,
                   Message=x.PhoneNumber
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<FeedbackViewModel>()
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
