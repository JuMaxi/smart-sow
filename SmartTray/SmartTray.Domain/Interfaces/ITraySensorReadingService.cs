using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingService
    {
        public Task Insert(int trayId, int userId, string token, TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll(int trayId, int userId);
        public Task<TraySensorReading> GetLatest(int trayId, int userId);
        public Task<TraySensorReadingDTO> CalculateLightTime(int trayId, int userId);
    }
}
