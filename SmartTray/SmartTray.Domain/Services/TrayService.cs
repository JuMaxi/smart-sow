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

        public async Task Insert(Tray tray, TraySettings settings)
        {
            settings.Tray = tray;
            await _trayRepository.Insert(tray);
        }

        public async Task<Tray> GetById(int id, int userId)
        {
            return await _trayRepository.GetById(id, userId);
            
        }

        public async Task<List<Tray>> GetAll(int userId)
        {
            return await _trayRepository.GetAll(userId);
        }


        //public async Task Deacivate(int id)
        //{ 
        //    var tray = await _growthSettingsRepository.GetById(id);
        //    tray.Active = false;
        //    await _growthSettingsRepository.Update(tray);
        //}
    }
}
