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
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public ProfessorRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(Professor entity)
        {
            _openScholarDbContext.Professors.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(Professor entity)
        {
            _openScholarDbContext.Professors.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<Professor>> GetAll()
        {
            return await _openScholarDbContext.Professors.ToListAsync();
        }

        public async Task<Professor> GetById(int id)
        {
            return await _openScholarDbContext.Professors.SingleAsync(p => p.ProfessorId == id);
        }

        public async Task Update(Professor entity)
        {
            _openScholarDbContext.Professors.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
