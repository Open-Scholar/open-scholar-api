using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookSellerService
    {
        Task<Response<List<BookSellerDto>>> GetAllBookSellersAsync();
        Task<Response<BookSellerDto>> GetBookSellerAsync(string userId);
        Task<Response> CreateBookSellerAsync(AddBookSellerDto addDto, string userId);
        Task<Response> UpdateBookSellerAsync(string userId, UpdateBookSellerDto updateDto);
        Task<Response> DeleteBookSellerAsync(int id);
    }
}
