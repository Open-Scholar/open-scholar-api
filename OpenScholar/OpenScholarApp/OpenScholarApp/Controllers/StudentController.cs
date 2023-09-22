using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;

namespace OpenScholarApp.Controllers
{
    [Route("api/students")]
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(IStudentService studentService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentDto studentDto)
        {
            try
            {
                var response = await _studentService.CreateStudentAsync(studentDto);
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            try
            {
                var response = await _studentService.GetStudentByIdAsync(id);
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var response = await _studentService.GetAllStudentsAsync();
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromBody] UpdateStudentDto updatedStudentDto)
        {
            try
            {
                var response = await _studentService.UpdateStudentAsync(id, updatedStudentDto);
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(string id)
        {
            try
            {
                var response = await _studentService.DeleteStudentAsync(id);
                return Response(response); // Use the base controller's Response method
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
