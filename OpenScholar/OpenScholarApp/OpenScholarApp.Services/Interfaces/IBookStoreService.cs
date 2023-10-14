using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookStoreService
    {
        Task<Response<List<BookStoreDto>>> GetAllBookStoresAsync();
        Task<Response<BookStoreDto>> GetBookStoreByIdAsync(int id);
        Task<Response> CreateBookStoreAsync(AddBookStoreDto addDto, string userId);
        Task<Response> UpdateBookStoreAsync(int id, UpdateBookStoreDto updateDto);
        Task<Response> DeleteBookStoreAsync(int id);
    }
}
