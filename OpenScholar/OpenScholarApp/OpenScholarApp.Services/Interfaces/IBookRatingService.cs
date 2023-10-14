using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookRatingService
    {
        Task<Response<List<BookRatingDto>>> GetAllBookRatingsAsync();
        Task<Response<BookRatingDto>> GetBookRatingByIdAsync(int id);
        Task<Response> CreateBookRatingAsync(AddBookRatingDto addDto, string userId);
        Task<Response> UpdateBookRatingAsync(int id, UpdateBookRatingDto updateDto);
        Task<Response> DeleteBookRatingAsync(int id);
    }
}
