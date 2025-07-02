using Microsoft.EntityFrameworkCore;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;
using SmartTray.Infra.Db;

namespace SmartTray.Infra.DbAccess
{
    public class TraySensorReadingRepository : ITraySensorReadingRepository
    {
        private readonly SmartTrayDbContext _dbContext;

        public TraySensorReadingRepository(SmartTrayDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Insert(TraySensorReading reading)
        {
            await _dbContext.AddAsync(reading);
            await _dbContext.SaveChangesAsync();
        }

        // Fetch all tray readings
        public async Task<List<TraySensorReading>> GetAll(int trayId)
        {
            return await _dbContext.TraySensorReadings.Where(t => t.Tray.Id == trayId).ToListAsync();
        }

        // Fetch last reading

        // Future implementation
        // Fetch readings by day?
        // Fetch reading by hour?
        // Fetch readings by month?
    }
}
