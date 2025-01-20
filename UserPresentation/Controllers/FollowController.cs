using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserApplication.Interfaces;
using UserApplication.ViewModel.FollowViewModel;
using UserCore.Entities;

namespace UserPresentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        private readonly IPushNotificationService _postNotificationService;

        public FollowController(IFollowService followService, IPushNotificationService pushNotificationService)
        {
            _followService=followService;
            _postNotificationService=pushNotificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _followService.Getall();
            return Ok(result);
        }

        [HttpPost("{follower}")]
        public async Task<IActionResult> RequestFollowTo(string follower)
        {
            var iduser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            RequestFollowVM requestFollow = new RequestFollowVM
            {
                Followee = iduser,
                Follower = follower
            };
            var result = await _followService.RequestFollowTo(requestFollow);
            await _postNotificationService.SendNotificationFollow(requestFollow);
            return Ok(result);
        }

        [HttpPut("{follower}")]
        public async Task<IActionResult> ResponseFollowPrivateUser(string follower)
        {
            var iduser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            RequestFollowVM requestFollow = new RequestFollowVM
            {
                Followee = iduser,
                Follower = follower
            };
            var result = await _followService.ResponseFollowPrivateUser(requestFollow);
            return Ok(result);
        }

        [HttpDelete("{follower}")]
        public async Task<IActionResult> RemoveFollowUser(string follower)
        {
            var iduser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            RequestFollowVM requestFollow = new RequestFollowVM
            {
                Followee = iduser,
                Follower = follower
            };
            var result = await _followService.RemoveFollowUser(requestFollow);
            return Ok(result);
        }

        [HttpDelete("DeleteFollowee/{followee}")]
        public async Task<IActionResult> DeleteFollowee(string followee)
        {
            var iduser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            RequestFollowVM requestFollow = new RequestFollowVM
            {
                Followee = followee,
                Follower = iduser
            };
            var result = await _followService.RemoveFolloweeUser(requestFollow);
            return Ok(result);
        }
    }
}