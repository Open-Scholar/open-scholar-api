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
    public class AcademicMaterialRepository : IAcademicMaterialRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public AcademicMaterialRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task Add(AcademicMaterial entity)
        {
            _openScholarDbContext.AcademicMaterials.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(AcademicMaterial entity)
        {
            _openScholarDbContext.AcademicMaterials.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public Task<List<AcademicMaterial>> GetAll()
        {
            return _openScholarDbContext.AcademicMaterials.ToListAsync();
        }

        public async Task<AcademicMaterial> GetById(int id)
        {
            return await _openScholarDbContext.AcademicMaterials
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task Update(AcademicMaterial entity)
        {
            _openScholarDbContext.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
