using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Services.Helpers.Implementations;
using OpenScholarApp.Services.Helpers.Interaces;
using OpenScholarApp.Services.Implementations;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.StorageServices;
using OpenScholarApp.Services.StorageServices.S3Bucket;
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
            services.AddTransient<IFacultyAccRepository, FacultyAccRepository>();
            services.AddTransient<IUniversityAccRepository, UniversityAccRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookSellerRepository, BookSellerRepository>();
            services.AddTransient<IBookStoreRepository, BookStoreRepository>();
            services.AddTransient<IBookRatingRepository, BookRatingRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<ITopicRepository, TopicRepository>();
            services.AddTransient<ITopicCommentRepository, TopicCommentRepository>();
            services.AddTransient<ITopicLikeRepository, TopicLikeRepository>();
            services.AddTransient<ITopicCommentLikeRepository, TopicCommentLikeRepository>();
            services.AddTransient<IDocumentFileRepository, DocumentFileRepository>();
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<IUniversityRepository, UniversityRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IConnectionManagerRepository, ConnectionManagerRepository>();
            services.AddTransient<IUserNotificationRepository, UserNotificationRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<ITokenService, JWTService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IProfessorService, ProfessorService>();
            services.AddTransient<IBookStoreService, BookStoreService>();
            services.AddTransient<IBookSellerService, BookSellerService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookRatingService, BookRatingService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<ITopicCommentService, TopicCommentService>();
            services.AddTransient<ITopicLikeService, TopicLikeService>();
            services.AddTransient<ITopicCommentLikeService, TopicCommentLikeService>();
            services.AddTransient<IDocumentFileService, DocumentFileService>();
            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IUniversityService, UniversityService>();
            services.AddScoped<IBlobService, BlobService>();
            services.AddTransient<IUserHelperService, UserHelperService>();
            services.AddTransient<IUserNotificationService, UserNotificationService>();
            services.AddTransient<IS3FileService, S3FileService>();
            services.AddTransient<IFileService, FileService>();
        }
    }
}
