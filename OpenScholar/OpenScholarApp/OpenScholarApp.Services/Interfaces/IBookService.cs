using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<Response<List<BookDto>>> GetAllBookAsync();
        Task<Response<BookDto>> GetBookByIdAsync(int id);
        Task<Response> CreateBookAsync(AddBookDto addDto, string userId);
        Task<Response> UpdateBookAsync(int id, UpdateBookDto updateDto);
        Task<Response> DeleteBookAsync(int id);
    }

}
