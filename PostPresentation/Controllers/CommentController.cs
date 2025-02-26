using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;
using PostApplication.ViewModel.CommentViewModel;

namespace PostPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService=commentService;
        }

        [HttpGet("{parentid}")]
        public async Task<IActionResult> GetAllCommentbyParentId(string parentid, string AccountName)
        {
            var result = await _commentService.GetAllCommentbyParentId(parentid, AccountName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] RequestCreateCommentVM request)
        {
            var result = await _commentService.CreateComment(request);
            return Ok(result);
        }
    }
}