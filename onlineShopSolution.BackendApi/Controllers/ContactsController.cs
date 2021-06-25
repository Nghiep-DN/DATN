using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.Contacts;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(
            IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var feedback = await _contactService.GetAll();
            return Ok(new {status=200,message="Success.",data= feedback });
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] FeedbackPagingRequest request)
        {
            var feedback = await _contactService.GetPaging(request);
            return Ok(feedback);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _contactService.DeleteFeedback(id);
            return Ok(new { status = 200, message = "Success.", dataId = id });
        }
        [HttpGet("getDetail/{id}")]
        public async Task<IActionResult> getDetail(int id)
        {
            var feedback = await _contactService.GetDetail(id);
            return Ok(feedback);
        }
    }
}
