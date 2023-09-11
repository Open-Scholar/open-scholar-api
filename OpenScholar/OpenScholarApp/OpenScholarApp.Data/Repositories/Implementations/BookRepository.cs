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
}
