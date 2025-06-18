using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class TrayDbAccess : ITrayDbAccess
    {
        private readonly SmartTrayDbContext _dbContext;

        public TrayDbAccess(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Insert(Tray tray)
        {
            await _dbContext.AddAsync(tray);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Tray> GetLastId()
        {
            return await _dbContext.Trays.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
        }

        public async Task<Tray> GetById(int id)
        {
            return await _dbContext.Trays.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        // Fetch all trays
        public async Task<List<Tray>> GetAll()
        {
            return await _dbContext.Trays.ToListAsync();
        }
    }
}
