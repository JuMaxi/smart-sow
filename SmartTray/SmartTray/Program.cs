using Microsoft.EntityFrameworkCore;
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


// The connection to the database
string connectionString = builder.Configuration.GetValue<string>("ConnectionStringDBContext");
builder.Services.AddDbContext<SmartTrayDbContext>(DB => DB.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
