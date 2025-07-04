using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingService
    {
        public Task Insert(int trayId, int userId, string token, TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll(int trayId, int userId);
    }
}
