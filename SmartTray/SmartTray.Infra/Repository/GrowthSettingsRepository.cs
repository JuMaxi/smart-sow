using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class GrowthSettingsRepository : IGrowthSettingsRepository
    {
        private readonly SmartTrayDbContext _dbContext;

        public GrowthSettingsRepository(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(GrowthSettings settings)
        {
            await _dbContext.AddAsync(settings);
            await _dbContext.SaveChangesAsync();
        }
        
        // Change this method to get settings by tray Id
        public async Task<GrowthSettings> GetById(int id)
        {
            return await _dbContext.TraySettings.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(GrowthSettings settings)
        {
            _dbContext.TraySettings.Update(settings);
            await _dbContext.SaveChangesAsync();
        }

        // Change this method to get settings by tray Id
        public async Task Delete(int id)
        {
            _dbContext.TraySettings.Remove(await GetById(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
