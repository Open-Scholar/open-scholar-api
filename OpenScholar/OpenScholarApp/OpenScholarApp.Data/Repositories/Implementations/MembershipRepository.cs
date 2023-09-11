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
    public class MembershipRepository : BaseRepository<ApplicationUser> ,IMembershipRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

         public MembershipRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
