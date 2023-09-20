using OpenScholarApp.Helpers.DIContainer;
using OpenScholarApp.Helpers.Extensions;
using OpenScholarApp.Mappers.MapperConfig;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
    .AddPostgreSqlDbContext(appSettings) // FOR POSTRESQL DB
    //.AddMSSQLDbContext(appSettings) //=> For MS SQL DB
    .AddAuthentication()
    .AddJWT(appSettings)
    .AddIdentity()
    .AddCors()
    .AddSwager();

DependencyInjectionHelper.InjectRepositories(builder.Services);
DependencyInjectionHelper.InjectServices(builder.Services);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
}

app.MapControllers();

app.Run();
