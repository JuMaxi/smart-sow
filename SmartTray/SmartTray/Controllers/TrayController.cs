using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrayController : Controller
    {
        readonly ITrayService _trayService;
        readonly ITrayMapper _trayMapper;
        readonly IGrowthSettingsMapper _settingsMapper;

        public TrayController(
            ITrayService trayService,
            ITrayMapper trayMapper,
            IGrowthSettingsMapper settingsMapper)
        {
            _trayService = trayService;
            _trayMapper = trayMapper;
            _settingsMapper = settingsMapper;
        }

        // This method saves the tray to the database
        [HttpPost]
        public async Task Insert(TrayRequest trayRequest, GrowthSettingsRequest settingsRequest)
        {
            GrowthSettings settings = _settingsMapper.ConvertToGrowthSettings(settingsRequest);
            await _trayService.Insert(_trayMapper.ConvertToTray(trayRequest), settings);
        }

        // This method fetch the tray by id from the database
        [HttpGet("{id}")]
        public async Task<TrayResponse> GetById([FromRoute] int id)
        {
            Tray tray = await _trayService.GetById(id, GetUserId());

            return _trayMapper.ConvertToResponse(tray);
        }

        // This method fetch all the trays from the database
        [HttpGet]
        public async Task<List<TrayResponse>> GetAll()
        {
            List<Tray> trays = await _trayService.GetAll(GetUserId());

            return _trayMapper.ConvertToResponseList(trays);
        }

        private int GetUserId() => throw new NotImplementedException();
    }
}
