using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class TraySettingsRepository : ITraySettingsRepository
    {
        private readonly SmartTrayDbContext _dbContext;

        public TraySettingsRepository(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(TraySettings settings)
        {
            await _dbContext.AddAsync(settings);
            await _dbContext.SaveChangesAsync();
        }
        
        // Fetch settings by tray Id
        public async Task<TraySettings> GetById(int trayId)
        {
            return await _dbContext.TraySettings.Where(s => s.Tray.Id == trayId).FirstOrDefaultAsync();
        }

        public async Task Update(TraySettings settings)
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
