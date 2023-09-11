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
    public class AcademicMaterialRepository : BaseRepository<AcademicMaterial>, IAcademicMaterialRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public AcademicMaterialRepository(OpenScholarDbContext openScholarDbContext) : base(openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }
    }
}
