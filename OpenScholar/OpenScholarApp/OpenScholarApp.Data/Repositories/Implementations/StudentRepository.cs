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
    public class StudentRepository : IStudentRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public StudentRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(Student entity)
        {
            _openScholarDbContext.Students.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(Student entity)
        {
            _openScholarDbContext.Students.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _openScholarDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetById(int id)
        {
            return await _openScholarDbContext.Students.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Student entity)
        {
            _openScholarDbContext.Students.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
