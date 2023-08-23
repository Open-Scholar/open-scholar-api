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
    public class UniversityRepository : IUniversityRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

        public UniversityRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(University entity)
        {
            _openScholarDbContext.Universities.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(University entity)
        {
            _openScholarDbContext.Universities.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<University>> GetAll()
        {
            return await _openScholarDbContext.Universities.ToListAsync();
        }

        public async Task<University> GetById(int id)
        {
            return await _openScholarDbContext.Universities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(University entity)
        {
            _openScholarDbContext.Universities.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
