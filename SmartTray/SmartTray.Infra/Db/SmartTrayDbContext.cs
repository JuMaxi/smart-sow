using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Db
{
    public class SmartTrayDbContext : DbContext
    {
        public SmartTrayDbContext(DbContextOptions<SmartTrayDbContext> options) : base(options) { }

        // Insert the tables to my database
        public DbSet<GrowthSettings> Settings { get; set; }
        public DbSet<TraySensorReading> TraySensorReadings { get; set; }
    }
}
