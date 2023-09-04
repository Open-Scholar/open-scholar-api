using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Repositories.Implementations
{

    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly OpenScholarDbContext _context;

        public BookRepository(OpenScholarDbContext context) : base(context)
        {
            _context = context;
        }
    }



    //public class BookRepository : IBookRepository
    //{

    //    private readonly OpenScholarDbContext _openScholarDbContext;

    //    public BookRepository(OpenScholarDbContext openScholarDbContext)
    //    {
    //        _openScholarDbContext = openScholarDbContext;
    //    }

    //    public async Task Add(Book entity)
    //    {
    //        _openScholarDbContext.Books.Add(entity);
    //        await _openScholarDbContext.SaveChangesAsync();
    //    }

    //    public async Task Delete(Book entity)
    //    {
    //        _openScholarDbContext.Books.Remove(entity);
    //        await _openScholarDbContext.SaveChangesAsync();
    //    }

    //    public async Task<List<Book>> GetAll()
    //    {
    //        return await _openScholarDbContext.Books
    //            .ToListAsync();
    //    }

    //    public async Task<Book> GetById(int id)
    //    {
    //        return await _openScholarDbContext.Books
    //            .SingleOrDefaultAsync(a => a.Id == id);
    //    }

    //    public async Task Update(Book entity)
    //    {
    //        _openScholarDbContext.Update(entity);
    //        await _openScholarDbContext.SaveChangesAsync();
    //    }
    //}
}
