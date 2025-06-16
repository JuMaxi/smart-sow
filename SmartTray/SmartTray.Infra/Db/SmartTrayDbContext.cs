using Microsoft.EntityFrameworkCore;

namespace SmartTray.Infra.Db
{
    public class SmartTrayDbContext : DbContext
    {
        public SmartTrayDbContext(DbContextOptions<SmartTrayDbContext> options) : base(options) { }

        // Insert the tables to my database
        //public DbSet<MyClass> MyTable { get; set; }
    }
}
