using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookRatingService
    {
        Task<Response<List<BookRatingDto>>> GetAllBookRatingsAsync();
        Task<Response<BookRatingDto>> GetBookRatingByIdAsync(int id);
        Task<Response> CreateBookRatingAsync(AddBookRatingDto addDto, string userId, int bookId);
        Task<Response> UpdateBookRatingAsync(UpdateBookRatingDto updateDto, int id, int bookId);
        Task<Response> DeleteBookRatingAsync(int id);
    }
}
