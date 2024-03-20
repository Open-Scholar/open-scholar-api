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

        #region DbSets

        //User Types
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
        public DbSet<BookSeller> BookSellers { get; set; }
        public DbSet<FacultyAcc> FacultyAccounts { get; set; }
        public DbSet<UniversityAcc> UniversityAccounts { get; set; }

        //Items
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AcademicMaterial> AcademicMaterials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicComment> TopicComments { get; set; }
        public DbSet<DocumentFile> DocumentFiles { get; set; }
        public DbSet<TopicLike> TopicLikes { get; set; }
        public DbSet<TopicCommentLike> TopicCommentLikes { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region AccountManagement
            
            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.AccountType)
                      .IsRequired();

                entity.Property(e => e.IsAccountVerified)
                      .IsRequired();

                entity.Property(e => e.IsProfileCreated)
                      .IsRequired();

                entity.Property(e => e.PhotoUrl)
                      .IsRequired(false);

                entity.HasMany(e => e.Students)
                      .WithOne(s => s.User)
                      .HasForeignKey(s => s.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Professors)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.BookStores)
                      .WithOne(b => b.User)
                      .HasForeignKey(b => b.Id)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.BookSellers)
                      .WithOne(b => b.User)
                      .HasForeignKey(b => b.Id)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.BirthDate)
                      .IsRequired();

                entity.Property(e => e.FieldOFStudies)
                      .HasMaxLength(200);

                entity.Property(e => e.StudentStatus)
                      .IsRequired();

                entity.Property(e => e.StudentIndexNumber)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasMaxLength(1000)
                      .IsRequired(false);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.Students)
                      .HasForeignKey("ApplicationUserId")
                      .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Student>()
                    .HasOne(s => s.University)
                    .WithMany(u => u.Students)
                    .HasForeignKey(s => s.UniversityId);

                modelBuilder.Entity<Student>()
                    .HasOne(s => s.Faculty)
                    .WithMany(f => f.Students)
                    .HasForeignKey(s => s.FacultyId);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.BirthDate)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(20)
                      .IsRequired(false);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000)
                      .IsRequired(false);

                entity.Property(e => e.Expertise)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.Professors)
                      .HasForeignKey("ApplicationUserId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BookSeller>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Adress)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(e => e.ContactEmail)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(20)
                      .IsRequired(false);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000)
                      .IsRequired(false);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.BookSellers)
                      .HasForeignKey("ApplicationUserId")
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.BusinessName)
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.Adress)
                      .IsRequired()
                      .HasMaxLength(300);

                entity.Property(e => e.RegistrationNumber)
                      .IsRequired();

                entity.Property(e => e.TaxNumber)
                      .IsRequired();

                entity.Property(e => e.ContactEmail)
                      .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                      .HasMaxLength(20)
                      .IsRequired(false);

                entity.Property(e => e.Description)
                      .HasMaxLength(1000)
                      .IsRequired(false);

                entity.HasOne(e => e.User)
                      .WithMany(u => u.BookStores)
                      .HasForeignKey("ApplicationUserId")
                      .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region ItemsManagement

            modelBuilder.Entity<University>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.Property(u => u.Name)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.HasMany(u => u.Faculties)
                      .WithOne(f => f.University)
                      .HasForeignKey(f => f.UniversityId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Name)
                      .IsRequired()
                      .HasMaxLength(255);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Title)
                      .IsRequired()
                      .HasMaxLength(255);

                entity.Property(t => t.Description);

                entity.Property(t => t.CreatedDate)
                      .IsRequired();

                entity.Property(t => t.EditedAt);

                entity.HasOne(t => t.User)
                      .WithMany() 
                      .HasForeignKey(t => t.UserId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(t => t.Faculty)
                      .WithMany(f => f.Topics) 
                      .HasForeignKey(t => t.FacultyId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasMany(t => t.Comments)
                      .WithOne(c => c.Topic)
                      .HasForeignKey(c => c.TopicId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<TopicComment>(entity =>
            {
                entity.HasKey(tc => tc.Id);

                entity.Property(tc => tc.Comment)
                      .IsRequired();

                entity.Property(tc => tc.CreatedAt)
                      .IsRequired();

                entity.Property(tc => tc.UpdatedAt);

                entity.HasOne(tc => tc.User)
                      .WithMany() 
                      .HasForeignKey(tc => tc.UserId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(tc => tc.Topic)
                      .WithMany(t => t.Comments)
                      .HasForeignKey(tc => tc.TopicId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<TopicLike>(entity =>
            {
                entity.HasKey(tl => tl.Id);

                entity.HasOne(tl => tl.User)
                      .WithMany(u => u.TopicLikes) 
                      .HasForeignKey(tl => tl.UserId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(tl => tl.Topic)
                      .WithMany(t => t.Likes) 
                      .HasForeignKey(tl => tl.TopicId);
            });

            modelBuilder.Entity<TopicCommentLike>(entity =>
            {
                entity.HasKey(tcl => tcl.Id);

                entity.HasOne(tcl => tcl.User)
                      .WithMany(u => u.TopicCommentLikes) 
                      .HasForeignKey(tcl => tcl.UserId)
                      .OnDelete(DeleteBehavior.Cascade); 

                entity.HasOne(tcl => tcl.TopicComment)
                      .WithMany(tc => tc.Likes) 
                      .HasForeignKey(tcl => tcl.TopicCommentId);
            });

            modelBuilder.Entity<UserConnection>(entity =>
            {
                entity.HasKey(uc => uc.Id);

                entity.HasOne<ApplicationUser>() 
                      .WithMany() 
                      .HasForeignKey(uc => uc.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(uc => uc.UserId).HasDatabaseName("IDX_UserConnection_UserId");
                entity.HasIndex(uc => uc.ConnectionId).HasDatabaseName("IDX_UserConnection_ConnectionId");
            });

            modelBuilder.Entity<UserNotification>(entity =>
            { entity.HasKey(uc => uc.Id);

                entity.Property(n => n.Message)
                      .IsRequired()
                      .HasMaxLength(500); 

                entity.Property(n => n.IsRead)
                      .IsRequired(); 

                entity.Property(n => n.CreatedAt)
                      .IsRequired(); 

                entity.Property(n => n.NotificationType)
                      .IsRequired()
                      .HasMaxLength(50); 

                entity.HasOne(n => n.User)
                      .WithMany(u => u.UserNotifications) 
                      .HasForeignKey(n => n.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.Property(n => n.ReferenceId).IsRequired(false);

                entity.HasIndex(n => n.UserId);
                entity.HasIndex(n => n.IsRead);

            });
            #endregion

            #region Seeding Data for unis and fax
            modelBuilder.Entity<University>().HasData(
                new University { Id = 1, Name = "Goce Delčev University of Štip" },
                new University { Id = 2, Name = "Ss. Cyril and Methodius University of Skopje" },
                new University { Id = 3, Name = "Mother Teresa University in Skopje" },
                new University { Id = 4, Name = "Clement of Ohrid University of Bitola" },
                new University { Id = 5, Name = "State University of Tetova" },
                new University { Id = 6, Name = "University of Information Science and Technology \"St. Paul The Apostle\"" },
                new University { Id = 7, Name = "International Balkan University" },
                new University { Id = 8, Name = "South East European University" },
                new University { Id = 9, Name = "Euro-Balkan University" },
                new University { Id = 10, Name = "European University" },
                new University { Id = 11, Name = "FON University" },
                new University { Id = 12, Name = "International Vision University" }
                );

            // Starting Faculty ID
            int facultyId = 1;

            // Faculties for "Goce Delčev University of Štip" (UniversityId = 1)
            var facultiesForUniversity1 = new[]
            {
              "Art Academy", "Academy of Music", "Film Academy", "Faculty of Agriculture",
              "Faculty of Mechanical Engineering", "Faculty of Electrical Engineering",
              "Faculty of Technology", "Faculty of Computer Science",
              "Faculty of Natural and Technical Sciences", "Faculty of Medical Sciences",
              "Faculty of Economics", "Faculty of Law", "Faculty of Philology",
              "Faculty of Educational Sciences", "Faculty of Tourism and Business Logistics"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 1, Name = name });

            // Faculties for "Ss. Cyril and Methodius University of Skopje" (UniversityId = 2)
            var facultiesForUniversity2 = new[]
            {
              "Blaze Koneski Faculty of Philology", "Faculty of Agricultural Sciences and Food", "Faculty of Architecture",
              "Faculty of Civil Engineering", "Faculty of Computer Science and Engineering", "Faculty of Dentistry",
              "Faculty of Design and Technologies of Furniture and Interior", "Faculty of Dramatic Arts",
              "Faculty of Economics", "Faculty of Electrical Engineering and Information Technologies", "Faculty of Fine Arts",
              "Faculty of Forestry", "Faculty of Mechanical Engineering", "Faculty of Medicine", "Faculty of Music",
              "Faculty of Natural Sciences and Mathematics", "Faculty of Pharmacy", "Faculty of Philosophy",
              "Faculty of Physical Education, Sport and Health", "Faculty of Technology and Metallurgy",
              "Faculty of Veterinary Medicine", "Iustinianus Primus Faculty of Law", "St. Kliment Ohridski Faculty of Pedagogy",
              "St. Clement of Ohrid Faculty of Theology in Skopje"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 2, Name = name });

            // Faculties for "Mother Teresa University in Skopje" (UniversityId = 3)
            var facultiesForUniversity3 = new[]
            {
              "Fakultetin e shkencave Teknike / Факултет за технички науки",
              "Fakulteti i Shkencave të Informatikës / Факултет за информатички науки",
              "Fakulteti i Shkencave Teknologjike / Факултет за технолошки науки",
              "Fakulteti i Shkencave Sociale / Факултет за социјални науки",
              "Fakulteti i Ndërtimtarisë dhe Arkitekturës / Факултет за градежништво и архитектура"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 3, Name = name });

            // Faculties for "Clement of Ohrid University of Bitola" (UniversityId = 4)
            var facultiesForUniversity4 = new[]
            {
              "SCIENTIFIC INSTITUTE FOR TOBACCO - PRILEP",
              "FACULTY OF INFORMATION AND COMMUNICATION TECHNOLOGIES - BITOLA",
              "FACULTY OF VETERINARY - BITOLA", "HIGH MEDICINE SCHOOL - BITOLA",
              "FACULTY OF TECHNOLOGY AND TECHNICAL SCIENCE - VELES", "FACULTY OF LAW - KICEVO",
              "FACULTY OF SECURITY - SKOPJE", "FACULTY OF TOURISM AND HOSPITALITY - OHRID",
              "FACULTY OF EDUCATION - BITOLA", "FACULTY OF TECHNICAL SCIENCES - BITOLA",
              "FACULTY OF BIOTECHNICAL SCIENCES - BITOLA", "FACULTY OF ECONOMICS - PRILEP"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 4, Name = name });

            var facultiesForUniversity5 = new[]
{
              "Faculty of Agriculture and Biotechnology",
              "Faculty of Applied Sciences",
              "Faculty of Arts",
              "Faculty of Business Administration",
              "Faculty of Economics",
              "Faculty of Food Technology and Nutrition",
              "Faculty of Law",
              "Faculty of Medical Sciences",
              "Faculty of Natural Sciences and Mathematics",
              "Faculty of Philology",
              "Faculty of Pedagogy",
              "Faculty of Philosophy",
              "Faculty of Physical Education"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 5, Name = name });

            // Faculties for "University of Information Science and Technology 'St. Paul The Apostle'" (UniversityId = 6)
            var facultiesForUniversity6 = new[]
            {
              "Faculty of Communication Networks and Security (CNS)",
              "Faculty of Computer Science and Engineering (CSE)",
              "Faculty of Information Systems, Visualization, Multimedia and Animation (ISVMA)",
              "Faculty of Applied Information Technology, Machine Intelligence and Robotics (AITMR)",
              "Faculty of Information and Communication Science (ICS)"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 6, Name = name });

            // Faculties for "International Balkan University" (UniversityId = 7)
            var facultiesForUniversity7 = new[]
            {
              "FACULTY OF ECONOMICS AND ADMINISTRATIVE SCIENCES",
              "FACULTY OF ENGINEERING",
              "FACULTY OF LAW",
              "FACULTY OF DENTAL MEDICINE",
              "FACULTY OF EDUCATION",
              "FACULTY OF HUMANITIES AND SOCIAL SCIENCES",
              "FACULTY OF ART AND DESIGN",
                // Skipping detailed listings like "MASTER PROGRAMS", "DOCTORAL STUDIES", etc., for brevity
            }
            .Select(name => new { Id = facultyId++, UniversityId = 7, Name = name });

            // Faculties for "South East European University" (UniversityId = 8)
            var facultiesForUniversity8 = new[]
            {
              "FACULTY OF BUSINESS AND ECONOMICS",
              "FACULTY OF LAW",
              "FACULTY OF LANGUAGES, CULTURES AND COMMUNICATION",
              "FACULTY OF CONTEMPORARY SOCIAL SCIENCES",
              "FACULTY OF CONTEMPORARY SCIENCES AND TECHNOLOGIES",
              "FACULTY OF HEALTH SCIENCES"
            }
            .Select(name => new { Id = facultyId++, UniversityId = 8, Name = name });

            // Faculties for "Euro-Balkan University" (UniversityId = 9)
            var facultiesForUniversity9 = new[]
            {
              "Faculty of Cultural Studies", "Faculty of Global Studies", "Tourism Faculty",
              "Faculty of Applied Arts", "Faculty of Southeast European Studies"
            }
            .Select(name => new Faculty { Id = facultyId++, UniversityId = 9, Name = name });

            // Faculties for "European University" (UniversityId = 10)
            var facultiesForUniversity10 = new[]
            {
              "Faculty of Dentistry", "Faculty of Detectives and Criminology",
              "Faculty of Art and Design", "Faculty of Informatics",
              "Faculty of Economics", "Faculty of Law"
            }
            .Select(name => new Faculty { Id = facultyId++, UniversityId = 10, Name = name });

            // Faculties for "FON University" (UniversityId = 11)
            var facultiesForUniversity11 = new[]
            {
              "Law and Political Science", "Economics", "Communication and IT",
              "Design and Multimedia", "Applied Foreign Languages",
              "Detectives and Security", "Sports Management", "Architecture"
            }
            .Select(name => new Faculty { Id = facultyId++, UniversityId = 11, Name = name });

            // Faculties for "International Vision University" (UniversityId = 12)
            var facultiesForUniversity12 = new[]
            {
              "Faculty of Law", "Faculty of Economics", "faculty of Architecture",
              "Faculty of Social Sciences - PDR Department", "Faculty of Social Sciences - Department of Psychology",
              "Faculty of Engineering and Architecture - Department of Civil Engineering",
              "Faculty of Engineering and Architecture - Department of Architecture",
              "Faculty of Engineering and Architecture - Department of Computer Engineering",
              "Faculty of Informatics"
            }
            .Select(name => new Faculty { Id = facultyId++, UniversityId = 12, Name = name });

            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity1.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity2.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity3.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity4.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity5.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity6.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity7.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity8.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity9.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity10.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity11.ToArray());
            modelBuilder.Entity<Faculty>().HasData(facultiesForUniversity12.ToArray());
            #endregion

        }
    }
}
