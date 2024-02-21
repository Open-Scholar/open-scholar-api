using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.TopicCommentLikeDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicCommentLikeController : BaseController
    {
        private readonly ITopicCommentLikeService _topicCommentLikeService;

        public TopicCommentLikeController(ITopicCommentLikeService topicCommentLikeService)
        {
            _topicCommentLikeService = topicCommentLikeService;
        }
        [HttpPost]
        public async Task<IActionResult> AddRemoveTopicCommentLike([FromBody] AddRemoveTopicCommentLikeDto topicCommentDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicCommentLikeService.CreateRemoveTopicCommentLikeAsync(userId, topicCommentDto);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int topicCommentId)
        {
            try
            {
                var response = await _topicCommentLikeService.GetAllTopicCommentLikesAsync(topicCommentId);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicCommentLikeById([FromQuery] int topicCommentLikeId)
        {
            try
            {
                var response = await _topicCommentLikeService.GetTopicCommentLikeByIdAsync(topicCommentLikeId);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
