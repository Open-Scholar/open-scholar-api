using OpenScholarApp.Helpers.DIContainer;
using OpenScholarApp.Helpers.Extensions;
using OpenScholarApp.Mappers.MapperConfig;
using OpenScholarApp.SignalR;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonSettings(builder);
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Configuration.AddEnvironmentVariables();
builder.Host.UseSerilogConfiguration();
builder.Services.AddSignalR();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
                .AddAutoMapper(typeof(AutoMapperProfile).Assembly)
                .AddPostgreSqlDbContext(appSettings)
                .AddAuthentication()
                .AddJWT(appSettings)
                .AddIdentity()
                .AddCors()
                .AddHostedServices()
                .AddSwager();

builder.Services.AddSingleton<INotificationService, NotificationService>();
DependencyInjectionHelper.InjectRepositories(builder.Services);
DependencyInjectionHelper.InjectServices(builder.Services);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CORSPolicy");
app.MapControllers();
app.MapHub<NotificationHub>("/NotificationsHub");
app.Run();