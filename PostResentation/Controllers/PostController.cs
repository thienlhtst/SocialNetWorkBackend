
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;
using PostApplication.ViewModel.PostViewModel;
using PostCore.Entities;
using PostCore.InterfaceRepositories;

namespace PostResentation.Controllers
{
    public class PostController : ControllerBase
    {
        private readonly IGenericService<Posts> _genericService;
        private readonly IPostService _postService;

        public PostController(IGenericService<Posts> genericService, IPostService postService)
        {
            _genericService = genericService;
            _postService = postService;
        }

        [HttpGet("post/getAll")]
        public async Task<IActionResult> GetAll() {
            List<Posts> result = await _genericService.GetAll();
            return Ok(result);
        }

        [HttpPost("post/create")]
        public async Task<IActionResult> Create([FromBody] CreatePostViewModel request)
        {
            var result = await _postService.Create(request);
            return Ok(result);
        }

        [HttpPut("post/update")]
        public async Task<IActionResult> Update([FromBody] UpdatePostViewModel request) {
            var result = await _postService.Update(request);
            return Ok(result);
        }

        [HttpDelete("post/delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _genericService.Delete(id);
            return Ok(result);
        }

        [HttpGet("post/getById{id}")]
        public async Task<IActionResult> GetById(string id) {
            var result = await _genericService.GetById(id);
            return Ok(result);
        }
    }
}
