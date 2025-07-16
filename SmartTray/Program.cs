using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SmartTray.API.Mappers;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Services;
using SmartTray.Infra.Db;
using SmartTray.Infra.DbAccess;
using Microsoft.AspNetCore.StaticFiles;

string GetConnectionString(IConfiguration config)
{
    var connectionStringFromEnvironmentVariable = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (string.IsNullOrEmpty(connectionStringFromEnvironmentVariable))
        return config.GetConnectionString("SmartTray")!;

    var match = Regex.Match(connectionStringFromEnvironmentVariable, @"postgres://(.*):(.*)@(.*):(.*)/(.*)");
    return $"Server={match.Groups[3]};Port={match.Groups[4]};User Id={match.Groups[1]};Password={match.Groups[2]};Database={match.Groups[5]};sslmode=Prefer;Trust Server Certificate=true";
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The Dependency Injection to the interfaces/services/repository
builder.Services.AddTransient<ITraySettingsService, TraySettingsService>();
builder.Services.AddTransient<ITraySettingsRepository, TraySettingsRepository>();
builder.Services.AddTransient<ITraySettingsMapper, TraySettingsMapper>();
builder.Services.AddTransient<ITraySensorReadingService, TraySensorReadingService>();
builder.Services.AddTransient<ITraySensorReadingRepository, TraySensorReadingRepository>();
builder.Services.AddTransient<ITraySensorReadingMapper, TraySensorReadingMapper>();
builder.Services.AddTransient<ITrayService, TrayService>();
builder.Services.AddTransient<ITrayRepository, TrayRepository>();
builder.Services.AddTransient<ITrayMapper, TrayMapper>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserMapper, UserMapper>();

// Enabling autentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        opts.SlidingExpiration = true;
        opts.Cookie.IsEssential = true;
        opts.Cookie.SameSite = SameSiteMode.Strict;
        opts.LoginPath = "/user.html";
    });



// The connection to the database
builder.Services.AddDbContext<SmartTrayDbContext>(options => options.UseNpgsql(GetConnectionString(builder.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Using this to have the /file.html after the port 7134
app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "www"))
});


var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".webp"] = "image/webp";

// Server static files (folder with HTML, JS files)
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "www")),

    ContentTypeProvider = provider
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
