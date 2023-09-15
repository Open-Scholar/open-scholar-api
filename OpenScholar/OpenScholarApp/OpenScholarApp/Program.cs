using OpenScholarApp.Helpers.DIContainer;
using OpenScholarApp.Helpers.Extensions;
using OpenScholarApp.Mappers.MapperConfig;
using OpenScholarApp.Shared.Settings;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.GetSection("AppSettings");
//builder.Services.Configure<AppSettings>(appSettings);
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddDbContext(appSettings)
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
