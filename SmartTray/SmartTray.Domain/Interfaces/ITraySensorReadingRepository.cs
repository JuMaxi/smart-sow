using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingRepository
    {
        public Task Insert(TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll(int trayId, int userId);
        public Task<TraySensorReading> GetLatest(int trayId, int userId);
    }
}
