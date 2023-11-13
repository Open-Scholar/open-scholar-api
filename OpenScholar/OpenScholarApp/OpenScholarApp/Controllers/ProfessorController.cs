using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.ProfessorDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.ProfessorExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : BaseController
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfessor([FromBody] AddProfessorDto professorDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return BadRequest("User not found.");
                }

                var response = await _professorService.CreateProfessorAsync(professorDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById(int id)
        {
            try
            {
                var response = await _professorService.GetProfessorByIdAsync(id);
                return Response(response);
            }
            catch(ProfessorNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfessors()
        {
            try
            {
                var response = await _professorService.GetAllProfessorsAsync();
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, [FromBody] UpdateProfessorDto updatedProfessorDto)
        {
            try
            {
                var response = await _professorService.UpdateProfessorAsync(id, updatedProfessorDto);
                return Response(response);
            }
            catch(ProfessorNotFoundException ex)
            {
                return NotFound($"There is no such Professor to update {ex.Message}");
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var response = await _professorService.DeleteProfessorAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
