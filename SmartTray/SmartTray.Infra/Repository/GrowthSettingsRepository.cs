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
        
        public async Task<GrowthSettings> GetById(int id)
        {
            return await _dbContext.Settings.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(GrowthSettings settings)
        {
            _dbContext.Settings.Update(settings);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _dbContext.Settings.Remove(await GetById(id));
            await _dbContext.SaveChangesAsync();
        }
    }
}
