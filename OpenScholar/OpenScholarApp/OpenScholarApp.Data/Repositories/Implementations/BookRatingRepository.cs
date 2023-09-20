using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BookRatingRepository : BaseRepository<BookRating>, IBookRatingRepository
    {
        private readonly OpenScholarDbContext _context;
        public BookRatingRepository(OpenScholarDbContext context): base(context)
        {
            _context = context;
        }

        //public async Task<BookRating> GetByUserIdAndBookIdAsync(string userId, int bookId)
        //{
        //    return await _context.BookRatings
        //.Include(br => br)
        //.Include(br => br.Book)
        //.FirstOrDefaultAsync(br => br.User.Id == userId && br.Book.BookId == bookId);
        //}
    }
}
