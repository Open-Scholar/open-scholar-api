using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookSellerService
    {
        Task<Response<List<BookSellerDto>>> GetAllBookSellersAsync();
        Task<Response<BookSellerDto>> GetBookSellerByIdAsync(int id);
        Task<Response> CreateBookSellerAsync(AddBookSellerDto addDto, string userId);
        Task<Response> UpdateBookSellerAsync(int id, UpdateBookSellerDto updateDto);
        Task<Response> DeleteBookSellerAsync(int id);
    }
}
