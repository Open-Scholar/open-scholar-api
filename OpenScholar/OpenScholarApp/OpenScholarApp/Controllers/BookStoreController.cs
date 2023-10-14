using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.BookStoreExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookStoreController : BaseController
    {
        private readonly IBookStoreService _bookStoreService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookStoreController(IBookStoreService bookStoreService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _bookStoreService = bookStoreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookStore([FromBody] AddBookStoreDto bookStoreDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return BadRequest("User not found.");
                }

                var response = await _bookStoreService.CreateBookStoreAsync(bookStoreDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                // Log the exception here.
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookStoreById(int id)
        {
            try
            {
                var response = await _bookStoreService.GetBookStoreByIdAsync(id);
                return Response(response);
            }
            catch (BookStoreNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookStores()
        {
            try
            {
                var response = await _bookStoreService.GetAllBookStoresAsync();
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookStore(int id, [FromBody] UpdateBookStoreDto updatedBookStoreDto)
        {
            try
            {
                var response = await _bookStoreService.UpdateBookStoreAsync(id, updatedBookStoreDto);
                return Response(response);
            }
            catch (BookStoreNotFoundException ex)
            {
                return NotFound($"There is no such book store to update {ex.Message}");
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookStore(int id)
        {
            try
            {
                var response = await _bookStoreService.DeleteBookStoreAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
