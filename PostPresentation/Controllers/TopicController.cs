using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostApplication.Interfaces;
using PostApplication.ViewModel.TopicViewModel;

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

        [HttpGet("getUser")]
        public async Task<IActionResult> GetAllTopicUser(string AccountName)
        {
            var result = await _topicServices.GetAllTopicbyUser(AccountName);
            return Ok(result);
        }

        [HttpGet("getPost")]
        public async Task<IActionResult> GetAllTopicPost()
        {
            var result = await _topicServices.GetAllPost();
            return Ok(result);
        }

        [HttpPost("CreateTopic")]
        public async Task<IActionResult> CreateTopic([FromBody] List<RequestCreateTopicVM> request)
        {
            var result = await _topicServices.CreateTopic(request);
            return Ok(result);
        }

        [HttpPost("CreateTopicUser")]
        public async Task<IActionResult> CreateTopicUser([FromBody] List<RequestCreateTopicUserVM> request)
        {
            var result = await _topicServices.CreateTopicUser(request);
            return Ok(result);
        }
    }
}