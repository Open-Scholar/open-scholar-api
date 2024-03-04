using OpenScholarApp.Helpers.DIContainer;
using OpenScholarApp.Helpers.Extensions;
using OpenScholarApp.Mappers.MapperConfig;
using OpenScholarApp.SignalR;

var builder = WebApplication.CreateBuilder(args);
var appSettings = builder.Configuration.GetSection("AppSettings");
builder.Configuration.AddEnvironmentVariables();
builder.Services.AddSignalR(); //dodadeno za singalR
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly)
    .AddPostgreSqlDbContext(appSettings) // => FOR POSTRESQL DB //.AddMSSQLDbContext(appSettings) // => For MS SQL DB
    .AddAuthentication()
    .AddJWT(appSettings)
    .AddIdentity()
    .AddCors()
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
//app.UseCors(builder =>
//    {
//        builder
//        .AllowAnyOrigin()
//        .AllowAnyMethod()
//        .AllowAnyHeader();
//        .AllowCredentials(); // dodadeno za signalR
//    });
app.MapControllers();
app.MapHub<NotificationHub>("/NotificationsHub"); //dodadeno za singalR
app.Run();
