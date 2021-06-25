using System.Threading.Tasks;
using onlineShopSolution.Application.System.Utilities.Slides;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ViewModel.Utilities.Slides;

namespace onlineShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SlidesController : ControllerBase
    {
        private readonly ISlideService _slideService;

        public SlidesController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var slides = await _slideService.GetAll();
            return Ok(slides);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetPaging([FromQuery] SlidePagingRequest request)
        {
            var slide = await _slideService.GetPaging(request);
            return Ok(slide);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Created([FromForm]SlideCreateRequest request)
        {
            var slides = await _slideService.Created(request);
            return Ok(new {dataId=slides});
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _slideService.DeleteSlide(id);
            return Ok(new { status = 200, message = "Success.", dataId = id });
        }

    }
}