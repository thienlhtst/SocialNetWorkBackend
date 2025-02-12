using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;
using PostApplication.ViewModel.PostViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;

namespace PostResentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IGenericService<Posts> _genericService;
        private readonly IPostService _postService;

        public PostController(IGenericService<Posts> genericService, IPostService postService)
        {
            _genericService = genericService;
            _postService = postService;
        }

        [HttpGet("getList")]
        public async Task<IActionResult> GetAll() {
            List<Posts> result = await _genericService.GetAll();
            return Ok(result);
        }

        [HttpPost("addNew")]
        public async Task<IActionResult> Create([FromBody] CreatePostViewModel request)
        {
            var result = await _postService.Create(request);
            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Update(UpdatePostViewModel request) {
            var result = await _postService.Update(request);
            return Ok(result);
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _genericService.Delete(id);
            return Ok(result);
        }

        [HttpGet("getById{id}")]
        public async Task<IActionResult> GetById(string id) {
            var result = await _genericService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getByAccountName")]
        public async Task<IActionResult> SearchByAccount(string accountName) {
            var result = await _postService.GetListByAccountName(accountName);
            return Ok(result);
        }

        [HttpGet("getRelated")]
        public async Task<IActionResult> GetMeme() {
            var result = await _postService.GetListPostRelatedToAll();
            return Ok(result);
        }
    }
}
