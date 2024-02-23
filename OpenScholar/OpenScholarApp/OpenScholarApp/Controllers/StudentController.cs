using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/students")]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentDto studentDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _studentService.CreateStudentAsync(studentDto, userId);
                return Response(response); 
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _studentService.GetStudent(userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/api/allstudents")]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var response = await _studentService.GetAllStudentsAsync();
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentDto updatedStudentDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _studentService.UpdateStudentAsync(userId, updatedStudentDto);
                return Response(response); 
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
                var response = await _studentService.DeleteStudentAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
