using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TrayService : ITrayService
    {
        private readonly ITrayDbAccess _trayDbAccess;

        public TrayService(ITrayDbAccess trayDbAccess)
        {
            _trayDbAccess = trayDbAccess;
        }

        public async Task Insert(Tray tray)
        {
            await _trayDbAccess.Insert(tray);
        }

        public async Task<Tray> GetById(int id)
        {
            return await _trayDbAccess.GetById(id);
        }

        public async Task<List<Tray>> GetAll()
        {
            return await _trayDbAccess.GetAll();
        }
    }
}
