using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.Application.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var languages = await _languageService.GetAll();
            return Ok(languages);
        }
    }
}
