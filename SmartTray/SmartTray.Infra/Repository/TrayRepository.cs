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
            await _dbContext.AddAsync(tray);
            await _dbContext.SaveChangesAsync();
        }

        // Fetch tray by trayId and userId
        public async Task<Tray> GetById(int id, int userId)
        {
            return await _dbContext.Trays.Where(t => t.Id == id && t.User.Id == userId).FirstOrDefaultAsync();
        }

        // Fetch all user trays
        public async Task<List<Tray>> GetAll(int userId)
        {
            return await _dbContext.Trays.Where(u => u.User.Id == userId).ToListAsync();
        }
    }
}
