using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.UniversityAccDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityAccController : BaseController
    {
        private readonly IUniversityAccService _universityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UniversityAccController(IUniversityAccService universityService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _universityService = universityService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUniversity([FromBody] AddUniversityAccDto universityDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return BadRequest("User not found.");
                }

                var response = await _universityService.CreateUniversityAsync(universityDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniversityById(int id)
        {
            try
            {
                var response = await _universityService.GetUniversityByIdAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUniversities()
        {
            try
            {
                var response = await _universityService.GetAllUniversitiesAsync();
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUniversity(int id, [FromBody] UpdateUniversityAccDto updatedUniversityDto)
        {
            try
            {
                var response = await _universityService.UpdateUniversityAsync(id, updatedUniversityDto);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            try
            {
                var response = await _universityService.DeleteUniversityAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
