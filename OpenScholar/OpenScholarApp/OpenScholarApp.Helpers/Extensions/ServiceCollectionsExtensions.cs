using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Helpers.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static MembershipBuilder AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<OpenScholarDbContext>(options => options.UseSqlServer(connectionString)); // for MS sql database
                                                                                                            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString)); // for sqlite database

            return new(services, configuration);
        }
        public static MembershipBuilder AddIdentity(this MembershipBuilder builder)
        {
            builder.IdentityBuilder = builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<OpenScholarDbContext>()
                .AddDefaultTokenProviders();



            return builder;
        }
        public static MembershipBuilder AddAuthentication(this MembershipBuilder builder)
        {
            builder.AuthenticationBuilder = builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            return builder;
        }
        public static MembershipBuilder AddJWT(this MembershipBuilder builder)
        {
            builder.AuthenticationBuilder.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
            });

            return builder;
        }
        //public static MembershipBuilder AddBackgroundServices(this MembershipBuilder builder)
        //{
        //    builder.Services.AddCoursesBackgroundService();
        //    return builder;
        //}
        //public static MembershipBuilder AddConfigurationOptions(this MembershipBuilder builder)
        //{
        //    builder.Services.Configure<MeterGramApiOptions>(builder.Configuration.GetSection("MeterGramApi"));
        //    return builder;
        //}
    }

    public class MembershipBuilder
    {
        public IServiceCollection Services { get; set; }
        public IConfiguration Configuration { get; }
        public IdentityBuilder IdentityBuilder { get; set; }
        public AuthenticationBuilder AuthenticationBuilder { get; set; }

        public MembershipBuilder(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }
    }
}
}
