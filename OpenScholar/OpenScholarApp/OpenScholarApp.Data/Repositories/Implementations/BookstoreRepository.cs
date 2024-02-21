﻿using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class BookStoreRepository : BaseRepository<BookStore>, IBookStoreRepository
    { 
        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookStoreRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<BookStore>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.BookStores.Include(s => s.User).ToListAsync();
        }

        public async Task<BookStore> GetByUserIdAsync(string userId)
        {
            return await _openScholarDbContext.BookStores
                        .FirstOrDefaultAsync(s => s.User != null && s.User.Id == userId);
        }
    }
}
