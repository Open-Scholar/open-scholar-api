using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using OpenScholarApp.Shared.CustomExceptions.BookSellerExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookSellerController : BaseController
    {
        private readonly IBookSellerService _bookSellerService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookSellerController(IBookSellerService bookSellerService, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _bookSellerService = bookSellerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookSeller([FromBody] AddBookSellerDto bookSellerDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return BadRequest("User not found.");
                }

                var response = await _bookSellerService.CreateBookSellerAsync(bookSellerDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookSellerById(int id)
        {
            try
            {
                var response = await _bookSellerService.GetBookSellerByIdAsync(id);
                return Response(response);
            }
            catch (BookSellerNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookSeller()
        {
            try
            {
                var response = await _bookSellerService.GetAllBookSellersAsync();
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookSeller(int id, [FromBody] UpdateBookSellerDto updatedBookSellerDto)
        {
            try
            {
                var response = await _bookSellerService.UpdateBookSellerAsync(id, updatedBookSellerDto);
                return Response(response);
            }
            catch (BookSellerNotFoundException ex)
            {
                return NotFound($"There is no such book store to update {ex.Message}");
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookSeller(int id)
        {
            try
            {
                var response = await _bookSellerService.DeleteBookSellerAsync(id);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
