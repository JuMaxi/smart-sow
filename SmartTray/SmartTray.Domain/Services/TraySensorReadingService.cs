using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingDbAccess _traySensorReadingDbAccess;

        public TraySensorReadingService(ITraySensorReadingDbAccess traySensorReadingDbAccess)
        {
            _traySensorReadingDbAccess = traySensorReadingDbAccess;
        }

        public async Task Insert(TraySensorReading reading)
        {
            await _traySensorReadingDbAccess.Insert(reading);
        }

        public async Task<TraySensorReading> GetById(int id)
        {
            return await _traySensorReadingDbAccess.GetById(id);
        }

        public async Task<List<TraySensorReading>> GetAll()
        {
            return await _traySensorReadingDbAccess.GetAll();
        }
    }
}
