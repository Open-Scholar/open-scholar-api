using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBookRatingRepository : IBaseRepository<BookRating>
    {
        Task<List<BookRating>> GetAllWithUserAndBookAsync();
    }
}
