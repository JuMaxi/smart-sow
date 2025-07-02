using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TrayService : ITrayService
    {
        private readonly ITrayRepository _trayRepository;

        public TrayService(ITrayRepository trayDbAccess)
        {
            _trayRepository = trayDbAccess;
        }

        public async Task Insert(Tray tray)
        {
            await _trayRepository.Insert(tray);
        }

        public async Task<Tray> GetLastId()
        {
            return await _trayRepository.GetLastId();
        }

        public async Task<Tray> GetById(int id)
        {
            return await _trayRepository.GetById(id);
        }

        public async Task<List<Tray>> GetAll()
        {
            return await _trayRepository.GetAll();
        }
    }
}
