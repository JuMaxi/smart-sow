using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingRepository _traySensorReadingRepository;
        private readonly ITrayRepository _trayRepository;

        public TraySensorReadingService(
            ITraySensorReadingRepository traySensorReadingDbAccess,
            ITrayRepository trayRepository)
        {
            _traySensorReadingRepository = traySensorReadingDbAccess;
            _trayRepository = trayRepository;
        }

        // Insert new sensor readings (arduino) from the sensors to the database
        public async Task Insert(int trayId, int userId, string token, TraySensorReading reading)
        {
            Tray tray = await _trayRepository.GetById(trayId, userId);

            // Check if token corresponds to the tray token, if so, insert into database.
            if (tray.Token == token)
            {
                // The FK to the tray
                reading.Tray = tray;

                await _traySensorReadingRepository.Insert(reading);
            }
        }

        // Fetching all sensors readinds to the user/tray
        public async Task<List<TraySensorReading>> GetAll(int trayId, int userId)
        {
            return await _traySensorReadingRepository.GetAll(trayId, userId);
        }

        //Fetching the last sensors readings
        public async Task<TraySensorReading> GetLatest(int trayId, int userId)
        {
            return await _traySensorReadingRepository.GetLatest(trayId, userId);
        }
    }
}
