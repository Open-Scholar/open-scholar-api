using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.TopicDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.TopicExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : BaseController
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromBody] AddTopicDto topicDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicService.CreateTopicAsync(topicDto, userId);
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
                var response = await _topicService.GetAllTopicsAsync();
                return Response(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("paged-with-filters")]
        public async Task<IActionResult> GetAllPaged2([FromQuery] int pageNumber = 1,
                                                      [FromQuery] int pageSize = 10,
                                                      [FromQuery] int? facultyId = null,
                                                      [FromQuery] int? universityId = null,
                                                      [FromQuery] bool? isMostPopular = false)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found!");

                pageNumber = Math.Max(pageNumber, 1);
                pageSize = Math.Max(pageSize, 1);
                var response = await _topicService.GetAllTopicsFilteredAsync(userId, facultyId, universityId, isMostPopular, pageNumber, pageSize);
                return Ok(response);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicService.GetTopicByIdAsync(id, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTopic(int id, [FromBody] UpdateTopicDto updatedTopicDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicService.UpdateTopicAsync(id, userId, updatedTopicDto);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");

                var response = await _topicService.DeleteTopicAsync(id, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
