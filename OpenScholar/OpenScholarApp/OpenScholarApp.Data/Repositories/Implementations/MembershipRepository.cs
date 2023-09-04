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
    public class MembershipRepository : IMembershipRepository
    {

        private readonly OpenScholarDbContext _openScholarDbContext;

         public MembershipRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }


        public async Task Add(ApplicationUser entity)
        {
            _openScholarDbContext.ApplicationUsers.Add(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task Delete(ApplicationUser entity)
        {
            _openScholarDbContext.ApplicationUsers.Remove(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _openScholarDbContext.ApplicationUsers.ToListAsync();
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            return await _openScholarDbContext.ApplicationUsers.SingleOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task Update(ApplicationUser entity)
        {
            _openScholarDbContext.ApplicationUsers.Update(entity);
            await _openScholarDbContext.SaveChangesAsync();
        }
    }
}
