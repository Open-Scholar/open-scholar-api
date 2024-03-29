﻿using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IBookSellerRepository : IBaseRepository<BookSeller>
    {
        Task<List<BookSeller>> GetAllWithUserAsync();
        Task<BookSeller> GetByUserIdAsync(string userId);
    }
}
