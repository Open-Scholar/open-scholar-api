using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Services.Implementations;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.UserServices.Implementations;
using OpenScholarApp.Services.UserServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Helpers.DIContainer
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbCotext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OpenScholarDbContext>(x => x.UseSqlServer(connectionString));
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
            services.AddTransient<IMembershipRepository, MembershipRepository>();
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IMembershipService, MembershipService>();
            services.AddTransient<ITokenService, JWTService>();
        }
    }
}
