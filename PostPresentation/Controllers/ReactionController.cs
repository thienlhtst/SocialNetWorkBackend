using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;

namespace PostPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _reactionService;

        public ReactionController(IReactionService reactionService)
        {
            _reactionService=reactionService;
        }

        [HttpPost("{accountname}")]
        public async Task<IActionResult> CreateReaction(string accountname, string postOrCommentId)
        {
            var result = await _reactionService.CreateReaction(accountname, postOrCommentId);
            return Ok(result);
        }

        [HttpDelete("{accountname}")]
        public async Task<IActionResult> DeleteReaction(string accountname, string postOrCommentId)
        {
            var result = await _reactionService.RemoveReaction(accountname, postOrCommentId);
            return Ok(result);
        }
    }
}