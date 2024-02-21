using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.TopicCommentDto;
using OpenScholarApp.Services.Implementations;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicCommentController : BaseController
    {
        private readonly ITopicCommentService _topicCommentService;

        public TopicCommentController(ITopicCommentService topicCommentService)
        {
            _topicCommentService = topicCommentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopicComment([FromBody] AddTopicCommentDto topicCommentDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _topicCommentService.CreateTopicCommentAsync(topicCommentDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _topicCommentService.GetAllTopicCommentsAsync();
                return Ok(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetAllPaged([FromQuery] int topicId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                // Ensure pageNumber and pageSize are positive values
                pageNumber = Math.Max(pageNumber, 1);
                pageSize = Math.Max(pageSize, 1);

                var response = await _topicCommentService.GetAllTopicCommentsPagedAsync(pageNumber, pageSize, topicId);
                return Ok(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicCommentById(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _topicCommentService.GetTopicCommentByIdAsync(id, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopicComment(int id, [FromBody] UpdateTopicCommentDto updatedTopicCommentDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _topicCommentService.UpdateTopicCommentAsync(id, userId, updatedTopicCommentDto);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopicComment(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _topicCommentService.DeleteTopicCommentAsync(id, userId);
                return Response(response);
            }
            catch (TopicDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
