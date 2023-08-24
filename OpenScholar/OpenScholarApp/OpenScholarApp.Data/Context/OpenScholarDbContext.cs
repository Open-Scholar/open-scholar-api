using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.IdentityModels;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Context
{
    //public class OpenScholarDbContext : DbContext
    public class OpenScholarDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        //public DbSet<Applikc>

        public OpenScholarDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AcademicMaterial> AcademicMaterials { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BookSeller> BookSellers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Students
            modelBuilder.Entity<Student>()
                .Property(x => x.FirstName)
                .IsRequired();
        }
    }
}
