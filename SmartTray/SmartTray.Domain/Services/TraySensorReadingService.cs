using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingRepository _traySensorReadingRepository;
        private readonly ITrayService _trayService;
       

        public TraySensorReadingService(
            ITraySensorReadingRepository traySensorReadingDbAccess,
            ITrayService trayService)
        {
            _traySensorReadingRepository = traySensorReadingDbAccess;
            _trayService = trayService;
        }

        public async Task Insert(TraySensorReading reading)
        {
            // Fetch the last tray Id
            Tray lastTray = await _trayService.GetLastId();
            reading.Tray = lastTray;

            await _traySensorReadingRepository.Insert(reading);
        }

        public async Task<TraySensorReading> GetById(int id)
        {
            return await _traySensorReadingRepository.GetById(id);
        }

        public async Task<List<TraySensorReading>> GetAll()
        {
            return await _traySensorReadingRepository.GetAll();
        }
    }
}
