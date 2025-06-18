using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingDbAccess _traySensorReadingDbAccess;
        private readonly ITrayService _trayService;
       

        public TraySensorReadingService(
            ITraySensorReadingDbAccess traySensorReadingDbAccess,
            ITrayService trayService)
        {
            _traySensorReadingDbAccess = traySensorReadingDbAccess;
            _trayService = trayService;
        }

        public async Task Insert(TraySensorReading reading)
        {
            // Fetch the last tray Id
            Tray lastTray = await _trayService.GetLastId();
            reading.Tray = lastTray;

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
