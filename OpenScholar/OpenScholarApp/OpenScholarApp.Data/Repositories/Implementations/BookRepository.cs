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
    public class BookRepository : IBookRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public BookRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public Task Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
