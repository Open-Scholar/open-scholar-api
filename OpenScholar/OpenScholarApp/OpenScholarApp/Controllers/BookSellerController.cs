using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookSellerController : BaseController
    {
        private readonly IBookSellerService _bookSellerService;

        public BookSellerController(IBookSellerService bookSellerService)
        {
            _bookSellerService = bookSellerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookSeller([FromBody] AddBookSellerDto bookSellerDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _bookSellerService.CreateBookSellerAsync(bookSellerDto, userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBookSeller()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _bookSellerService.GetBookSellerAsync(userId);
                return Response(response);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("/api/allsellers")]
        public async Task<IActionResult> GetAllBookSellers()
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

        [HttpPut]
        public async Task<IActionResult> UpdateBookSeller([FromBody] UpdateBookSellerDto updatedBookSellerDto)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                    return BadRequest("User not found.");

                var response = await _bookSellerService.UpdateBookSellerAsync(userId, updatedBookSellerDto);
                return Response(response);
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
