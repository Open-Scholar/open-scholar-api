using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Services.Implementations;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.UserServices.Implementations;
using OpenScholarApp.Services.UserServices.Interfaces;

namespace OpenScholarApp.Helpers.DIContainer
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbCotext(IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<OpenScholarDbContext>(x => x.UseSqlServer(connectionString)); // => for MSSQL
            services.AddDbContext<OpenScholarDbContext>(x => x.UseNpgsql(connectionString));  // => for PostgreSQL
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IProfessorRepository, ProfessorRepository>();
            services.AddTransient<IAcademicMaterialRepository, AcademicMaterialRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IUniversityRepository, UniversityRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookSellerRepository, BookSellerRepository>();
            services.AddTransient<IBookStoreRepository, BookStoreRepository>();
            services.AddTransient<IBookRatingRepository, BookRatingRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ITopicCommentRepository, TopicCommentRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<ITokenService, JWTService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IProfessorService, ProfessorService>();
            services.AddTransient<IBookStoreService, BookStoreService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRatingService, BookRatingService>();
        }
    }
}
