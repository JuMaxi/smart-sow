using Microsoft.EntityFrameworkCore;
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
        
        public async Task<GrowthSettings> GetById(int id)
        {
            return await _dbContext.Settings.Where(s => s.Id == id).FirstOrDefaultAsync();
        }
    }
}
