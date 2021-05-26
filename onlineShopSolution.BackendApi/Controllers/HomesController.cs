using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.Contacts;
using onlineShopSolution.ViewModel.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : Controller
    {
        private readonly IContactService _contactService;
        public HomesController(IContactService contactService)
        {

           _contactService=contactService;
        }
        [HttpPost("Feedback")]
        public async Task<IActionResult> CreateFeedback(FeedbackRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool res = await _contactService.CreateFeedback(request);
            if (!res)
            {
                return BadRequest();
            }
            return Ok(new {IsSuccessed=true,data=res });
        }
    }
}
