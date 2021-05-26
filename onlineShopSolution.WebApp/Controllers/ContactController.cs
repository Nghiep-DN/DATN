using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using onlineShopSolution.ApiIntegration;
using onlineShopSolution.ViewModel.Contacts;
using onlineShopSolution.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
      
        private readonly IContactApiClient _contactApiClient;
        public ContactController(ILogger<ContactController> logger, IContactApiClient contactApiClient)
        {
            _logger = logger;
            _contactApiClient = contactApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var model = new FeedbackRequest()
            {
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Message = request.Message
            };

            var result = await _contactApiClient.CreateFeedback(model);

            if (result.IsSuccessed)
            {
                TempData["SuccessMsg"] = "Feedback successfully";
                return View(model);
            }
            ModelState.AddModelError("", "Feedback  unsuccessfully.");
            return View(request);
        }

    }
}
