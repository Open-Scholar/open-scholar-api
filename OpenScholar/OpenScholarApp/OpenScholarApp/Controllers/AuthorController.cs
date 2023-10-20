using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.AuthorExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorController(IAuthorService authorService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AddAuthorDto author)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _authorService.CreateAuthorAsync(author, userId);
                return Response(response);
            }
            catch (AuthorDataException e)
            {
                return BadRequest(e.Message);
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
                var response = await _authorService.GetAllAuthorsAsync();
                return Response(response);
            }
            catch (AuthorDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _authorService.DeleteAuthorAsync(id, userId);
                return Response(response);
            }
            catch (AuthorDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto updatedAuthorDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _authorService.UpdateAuthorAsync(id, updatedAuthorDto, userId);
                return Response(response);
            }
            catch (AuthorDataException e)
            {
                return BadRequest(e.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                    return BadRequest("User Not found");
                var response = await _authorService.DeleteAuthorAsync(id, userId);
                return Response(response);
            }
            catch (AuthorDataException e)
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
