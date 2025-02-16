using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;
using PostApplication.ViewModel.MediaViewModel;
using PostCore.Entities;

namespace PostPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IGenericService<Media> _genericService;
        private readonly IMediaService _mediaService;

        public MediaController(IGenericService<Media> genericService, IMediaService mediaService)
        {
            _genericService = genericService;
            _mediaService = mediaService;
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetAll() {
            var result = await _genericService.GetAll();
            return Ok(result);
        }

    }
}
