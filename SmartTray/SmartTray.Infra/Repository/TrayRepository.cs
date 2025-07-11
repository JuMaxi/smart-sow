using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class TrayRepository : ITrayRepository
    {
        private readonly SmartTrayDbContext _dbContext;

        public TrayRepository(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(Tray tray)
        {
            await _dbContext.Trays.AddAsync(tray);
            await _dbContext.TraySettings.AddAsync(tray.Settings);
            await _dbContext.SaveChangesAsync();
        }

        // Fetch tray by trayId and userId and join with settings table
        public async Task<Tray> GetById(int id, int userId)
        {
            return await _dbContext.Trays.Include(s => s.Settings)
                .Where(t => t.Id == id && t.User.Id == userId)
                .FirstOrDefaultAsync();
        }

        // Fetch tray by trayId and token and join with settings table. This method is used to fetch the data that arduino requires to have the tray settings from database
        public async Task<Tray> GetByIdAndToken(int trayId, string token)
        {
            return await _dbContext.Trays.Include(s => s.Settings)
                .Where(t => t.Id == trayId && t.Token == token)
                .FirstOrDefaultAsync();
        }

        // Fetch all user trays
        public async Task<List<Tray>> GetAll(int userId)
        {
            return await _dbContext.Trays.Where(u => u.User.Id == userId).ToListAsync();
        }

        // Update tray and settings tray
        public async Task Update(Tray tray)
        {
            _dbContext.Trays.Update(tray);
            _dbContext.TraySettings.Update(tray.Settings);
            await _dbContext.SaveChangesAsync();
        }

        // Update tray status (deactivate)
        public async Task UpdateStatus(Tray tray)
        {
            _dbContext.Trays.Update(tray);
            await _dbContext.SaveChangesAsync();
        }
    }
}
