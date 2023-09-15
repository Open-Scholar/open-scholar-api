using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Domain.Entities;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace OpenScholarApp.Helpers.Extensions
{
    public static class ServiceCollectionsExtensions
    {

        public class ConfigBuilder
        {
            public IServiceCollection Services { get; set; }
            public IConfiguration Configuration { get; }
            public IdentityBuilder IdentityBuilder { get; set; }
            public AuthenticationBuilder AuthenticationBuilder { get; set; }

            public ConfigBuilder(IServiceCollection services, IConfiguration configuration)
            {
                Services = services;
                Configuration = configuration;
            }
        }

        public static ConfigBuilder AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<OpenScholarDbContext>(options =>
                options.UseSqlServer(connectionString));

            return new(services, configuration);
        }

        public static ConfigBuilder AddSwager(this ConfigBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme, e.g" +
                    "\"bearer {token} \"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            return builder;
        }

        public static ConfigBuilder AddIdentity(this ConfigBuilder builder)
        {
            builder.IdentityBuilder = builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            }).AddEntityFrameworkStores<OpenScholarDbContext>()
              .AddDefaultTokenProviders();
            return builder;
        }

        public static ConfigBuilder AddCors(this ConfigBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed((hosts) => true));
            });
            return builder;
        }

        public static ConfigBuilder AddAuthentication(this ConfigBuilder builder)
        {
            builder.AuthenticationBuilder = builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            });
            return builder;
        }

        public static ConfigBuilder AddJWT(this ConfigBuilder builder, IConfiguration configuration)
        {
            var Token = configuration.GetSection("Token").Value;
            builder.AuthenticationBuilder.AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Token)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return builder;
        }
    }
}
