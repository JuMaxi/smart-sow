using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TrayService : ITrayService
    {
        private readonly ITrayRepository _trayRepository;
        private readonly IUserRepository _userRepository;

        public TrayService(
            ITrayRepository trayDbAccess,
            IUserRepository userRepository)
        {
            _trayRepository = trayDbAccess;
            _userRepository = userRepository;
        }

        public async Task Insert(Tray tray, TraySettings settings, int userId)
        {
            User user = await _userRepository.GetById(userId);
            tray.User = user;
            settings.RegisterDate = DateTime.UtcNow;
            tray.Settings = settings;
            await _trayRepository.Insert(tray);
        }

        public async Task<Tray> GetById(int trayId, int userId)
        {
            return await _trayRepository.GetById(trayId, userId);
            
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
