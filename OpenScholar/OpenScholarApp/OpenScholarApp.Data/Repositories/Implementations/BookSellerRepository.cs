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
    public class BookSellerRepository : IBookSellerRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookSellerRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(BookSeller entity)
        {
            _openScholarDbContext.BookSellers.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(BookSeller entity)
        {
            _openScholarDbContext.BookSellers.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<BookSeller>> GetAll()
        {
            return await _openScholarDbContext.BookSellers.ToListAsync();
        }

        public async Task<BookSeller> GetById(int id)
        {
            return await _openScholarDbContext.BookSellers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(BookSeller entity)
        {
            _openScholarDbContext.BookSellers.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
