using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Context
{
    public class OpenScholarDbContext : IdentityDbContext<ApplicationUser>
    {
        public OpenScholarDbContext(DbContextOptions options) : base(options) { }
       
        //Users
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
        public DbSet<Blabla> Blabla { get; set; }
        public DbSet<Student3> TestStudents3 { get; set; }
        public DbSet<Student2> TestStudents2 { get; set; }


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
