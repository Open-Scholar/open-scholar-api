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
    public class FacultyRepository : IFacultyRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public FacultyRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(Faculty entity)
        {
            _openScholarDbContext.Faculties.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(Faculty entity)
        {
            _openScholarDbContext.Faculties.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<Faculty>> GetAll()
        {
            return await _openScholarDbContext.Faculties.ToListAsync();
        }

        public async Task<Faculty> GetById(int id)
        {
            return await _openScholarDbContext.Faculties.SingleOrDefaultAsync(x => x.FacultyId == id);
        }

        public async Task Update(Faculty entity)
        {
            _openScholarDbContext.Faculties.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
