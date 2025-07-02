using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingRepository
    {
        public Task Insert(TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll();
    }
}
