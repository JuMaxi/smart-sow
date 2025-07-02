using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingRepository _traySensorReadingRepository;

        public TraySensorReadingService(
            ITraySensorReadingRepository traySensorReadingDbAccess,
            ITrayRepository trayRepository)
        {
            _traySensorReadingRepository = traySensorReadingDbAccess;
        }

        public async Task Insert(TraySensorReading reading)
        {
            await _traySensorReadingRepository.Insert(reading);
        }

        public async Task<List<TraySensorReading>> GetAll(int trayId)
        {
            return await _traySensorReadingRepository.GetAll(trayId);
        }
    }
}
