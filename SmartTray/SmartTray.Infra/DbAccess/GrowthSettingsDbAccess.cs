using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class GrowthSettingsDbAccess : IGrowthSettingsDbAccess
    {
        private readonly SmartTrayDbContext _dbContext;

        public GrowthSettingsDbAccess(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(GrowthSettings settings)
        {
            await _dbContext.AddAsync(settings);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
