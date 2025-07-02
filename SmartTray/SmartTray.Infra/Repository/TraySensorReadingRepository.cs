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

        public async Task<TraySensorReading> GetById(int id)
        {
            return await _dbContext.TraySensorReadings.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        // Fetch all readings
        public async Task<List<TraySensorReading>> GetAll()
        {
            return await _dbContext.TraySensorReadings.ToListAsync();
        }

        // Fetch readings by day?
        // Fetch reading by hour?
        // Fetch readings by month?
    }
}
