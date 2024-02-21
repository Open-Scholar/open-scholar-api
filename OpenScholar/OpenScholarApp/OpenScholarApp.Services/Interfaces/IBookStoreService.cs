using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookStoreService
    {
        Task<Response<List<BookStoreDto>>> GetAllBookStoresAsync();
        Task<Response<BookStoreDto>> GetBookStoreAsync(string userId);
        Task<Response> CreateBookStoreAsync(AddBookStoreDto addDto, string userId);
        Task<Response> UpdateBookStoreAsync(string userId, UpdateBookStoreDto updateDto);
        Task<Response> DeleteBookStoreAsync(int id);
    }
}
