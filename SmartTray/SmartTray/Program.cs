using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using SmartTray.API.Mappers;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Services;
using SmartTray.Infra.Db;
using SmartTray.Infra.DbAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// The Dependency Injection to the interfaces/models
builder.Services.AddTransient<IGrowthSettingsService, GrowthSettingsService>();
builder.Services.AddTransient<IGrowthSettingsDbAccess, GrowthSettingsDbAccess>();
builder.Services.AddTransient<IGrowthSettingsMapper, GrowthSettingsMapper>();
builder.Services.AddTransient<ITraySensorReadingService, TraySensorReadingService>();
builder.Services.AddTransient<ITraySensorReadingDbAccess, TraySensorReadingDbAccess>();
builder.Services.AddTransient<ITraySensorReadingMapper, TraySensorReadingMapper>();
builder.Services.AddTransient<ITrayService, TrayService>();
builder.Services.AddTransient<ITrayDbAccess, TrayDbAccess>();
builder.Services.AddTransient<ITrayMapper, TrayMapper>();


// The connection to the database
builder.Services.AddDbContext<SmartTrayDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("SmartTray")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles(new DefaultFilesOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "www"))
});

// Server static files (folder with HTML, JS files)
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "www"))
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
