using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Context
{
    public class OpenScholarDbContext : IdentityDbContext<ApplicationUser>
    {
        public OpenScholarDbContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //Main Users
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        //User Types
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BookSeller> BookSellers { get; set; }

        //Items
        public DbSet<Book> Books { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AcademicMaterial> AcademicMaterials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
