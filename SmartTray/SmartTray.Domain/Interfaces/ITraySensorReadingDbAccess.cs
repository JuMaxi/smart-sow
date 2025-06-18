using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingDbAccess
    {
        public Task Insert(TraySensorReading reading);
        public Task<TraySensorReading> GetById(int id);
        public Task<List<TraySensorReading>> GetAll();
    }
}
