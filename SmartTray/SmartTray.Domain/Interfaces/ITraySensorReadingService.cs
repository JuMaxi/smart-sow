using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingService
    {
        public Task Insert(TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll(int trayId);
    }
}
