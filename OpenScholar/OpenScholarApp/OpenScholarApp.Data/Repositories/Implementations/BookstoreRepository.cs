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
    public class BookStoreRepository : IBookStoreRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookStoreRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(BookStore entity)
        {
            _openScholarDbContext.BookStores.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(BookStore entity)
        {
            _openScholarDbContext.BookStores.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<BookStore>> GetAll()
        {
            return await _openScholarDbContext.BookStores.ToListAsync();
        }

        public async Task<BookStore> GetById(int id)
        {
            return await _openScholarDbContext.BookStores.SingleOrDefaultAsync(x => x.BookStoreId == id); 
        }

        public async Task Update(BookStore entity)
        {
            _openScholarDbContext.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
