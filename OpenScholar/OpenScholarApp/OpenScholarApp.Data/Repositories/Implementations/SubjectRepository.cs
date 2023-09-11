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
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public SubjectRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
