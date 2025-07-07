using Microsoft.EntityFrameworkCore;
using Npgsql.TypeMapping;
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
        public async Task<List<TraySensorReading>> GetAll(int trayId, int userId)
        {
            return await _dbContext.TraySensorReadings
                .Where(t => t.Tray.Id == trayId && t.Tray.User.Id == userId)
                .ToListAsync();
        }

        // Fetch latest readings
        public async Task<TraySensorReading> GetLatest(int trayId, int userId)
        {
            return await _dbContext.TraySensorReadings.
                Where(t => t.Tray.Id == trayId && t.Tray.User.Id == userId)
                .OrderByDescending(d => d.Date).Take(1).FirstOrDefaultAsync();
        }

        // Fetch day readings
        public async Task<List<TraySensorReading>> GetDayReadings(int trayId, int userId, DateTime? date)
        {
            // Making sure it will take all day readings, regardless of the time
            DateTime startDate = DateTime.SpecifyKind(date.Value.Date, DateTimeKind.Utc);
            DateTime endDate = DateTime.SpecifyKind(startDate.AddDays(1), DateTimeKind.Utc);

            var result = await _dbContext.TraySensorReadings
                .Where(t => t.Tray.Id == trayId &&
                    t.Tray.User.Id == userId &&
                    t.Date >= startDate &&
                    t.Date < endDate)
                .OrderByDescending(d => d.Date)
                .ToListAsync();
            return result;
        }

        // Future implementation
        // Fetch reading by hour?
        // Fetch readings by month?
    }
}
