using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TrayService : ITrayService
    {
        private readonly ITrayRepository _trayRepository;
        private readonly IUserRepository _userRepository;

        public TrayService(
            ITrayRepository trayRepository,
            IUserRepository userRepository)
        {
            _trayRepository = trayRepository;
            _userRepository = userRepository;
        }

        public async Task Insert(Tray tray, int userId)
        {
            // Fetching the user from database. Need to make it, for not creating a new user while inserting the tray into database
            User user = await _userRepository.GetById(userId);
            tray.User = user;

            // Generating randon Token to the tray
            tray.Token = HashingHelper.GetRandonToken();

            // Needs to store the date as UTC for working properly with postgres
            tray.Settings.RegisterDate = DateTime.UtcNow;

            await _trayRepository.Insert(tray);
        }

        public async Task<Tray> GetByIdAndToken(int trayId, string token)
        {
            return await _trayRepository.GetByIdAndToken(trayId, token);
        }

        public async Task<Tray> GetById(int trayId, int userId)
        {
            return await _trayRepository.GetById(trayId, userId);
        }

        public async Task<List<Tray>> GetAll(int userId)
        {
            return await _trayRepository.GetAll(userId);
        }

        public async Task Update(Tray tray, int userId)
        {
            // Fecth the tray from data base. Needs to make it for not creating a new tray while updating
            Tray toUpdate = await _trayRepository.GetById(tray.Id, userId);

            // Needs to store the date as UTC for working properly with postgres
            tray.Settings.RegisterDate = DateTime.UtcNow;

            toUpdate.Name = tray.Name;
            toUpdate.CropType = tray.CropType;
            toUpdate.SowingDate = tray.SowingDate;
            toUpdate.Settings = tray.Settings;

            await _trayRepository.Update(toUpdate);
        }

        public async Task Deactivate(int trayId, int userId)
        {
            // Fecth the tray from data base. Needs to make it for not creating a new tray while updating
            Tray tray = await _trayRepository.GetById(trayId, userId);

            if (tray != null)
            {
                // The default status is 1, active. Change to status 0 Inative.
                tray.Status = 0;

                await _trayRepository.UpdateStatus(tray);
            }
        }
    }
}
