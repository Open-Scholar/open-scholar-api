using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public StudentRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<List<Student>> GetAllWithUserAsync()
        {
            return await _openScholarDbContext.Students.Include(s => s.User).ToListAsync();
        }
    }
}
