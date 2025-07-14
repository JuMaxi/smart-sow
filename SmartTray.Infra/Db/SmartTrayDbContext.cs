using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Models;

namespace SmartTray.Infra.Db
{
    public class SmartTrayDbContext : DbContext
    {
        public SmartTrayDbContext(DbContextOptions<SmartTrayDbContext> options) : base(options) { }

        // Insert the tables to my database
        public DbSet<TraySettings> TraySettings { get; set; }
        public DbSet<TraySensorReading> TraySensorReadings { get; set; }
        public DbSet<Tray> Trays { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This line scans the code for mappings and apply them
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SmartTrayDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
