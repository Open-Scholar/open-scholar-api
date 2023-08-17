using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Context
{
    public class OpenScholarDbContext : DbContext
    {
        public OpenScholarDbContext(DbContextOptions<OpenScholarDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestCase>()
                .Property(x => x.TestUserName)
                .IsRequired();

            modelBuilder.Entity<TestCase>()
                .Property(x => x.TestPassword)
                .IsRequired();

        }
    }
}
