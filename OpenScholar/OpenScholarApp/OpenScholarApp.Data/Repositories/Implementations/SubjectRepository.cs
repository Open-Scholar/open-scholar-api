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
    public class SubjectRepository : ISubjectRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public SubjectRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(Subject entity)
        {
            _openScholarDbContext.Subjects.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(Subject entity)
        {
            _openScholarDbContext.Subjects.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAll()
        {
            return await _openScholarDbContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetById(int id)
        {
            return await _openScholarDbContext.Subjects.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Subject entity)
        {
            _openScholarDbContext.Subjects.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
