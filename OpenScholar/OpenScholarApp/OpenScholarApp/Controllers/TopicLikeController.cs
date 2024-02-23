using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.TopicLikeDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicLikeController : BaseController
    {
        private readonly ITopicLikeService _topicLikeService;

        public TopicLikeController(ITopicLikeService topicLikeService)
        {
            _topicLikeService = topicLikeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRemoveTopicLike([FromBody] AddRemoveTopicLikeDto topicLikeDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicLikeService.CreateRemoveTopicLikeAsync(userId, topicLikeDto);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int topicId)
        {
            try
            {
                var response = await _topicLikeService.GetAllTopicLikesAsync(topicId);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopiLikecById(int topicId)
        {
            try
            {
                var response = await _topicLikeService.GetTopicLikeByIdAsync(topicId);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
