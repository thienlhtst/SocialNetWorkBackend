using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;

namespace PostPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicServices _topicServices;

        public TopicController(ITopicServices topicServices)
        {
            _topicServices=topicServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopic()
        {
            var result = await _topicServices.GetAllTopic();
            return Ok(result);
        }
    }
}