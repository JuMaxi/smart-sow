using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
        readonly ITraySettingsMapper _settingsMapper;

        public TrayController(
            ITrayService trayService,
            ITrayMapper trayMapper,
            ITraySettingsMapper settingsMapper)
        {
            _trayService = trayService;
            _trayMapper = trayMapper;
            _settingsMapper = settingsMapper;
        }
        // This method is returning the user Id once it is authenticated. The claimtypes is a dictionary and I am using the key NameIdentifier
        private int GetUserId() => Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        // This method saves the tray to the database
        [Authorize]
        [HttpPost]
        public async Task Insert(TrayRequest trayRequest)
        {
            TraySettings settings = _settingsMapper.ConvertToGrowthSettings(trayRequest.settings);
            await _trayService.Insert(_trayMapper.ConvertToTray(trayRequest), settings, GetUserId());
        }

        // This method fetch the tray by trayId from the database. It requires the user to be logged in
        [Authorize]
        [HttpGet("{trayId}")]
        public async Task<TrayResponse> GetById([FromRoute] int trayId)
        {
            Tray tray = await _trayService.GetById(trayId, GetUserId());

            return _trayMapper.ConvertToResponse(tray);
        }

        // This method fetch all the trays from the database. It requires the user to be logged in
        [Authorize]
        [HttpGet]
        public async Task<List<TrayResponse>> GetAll()
        {
            List<Tray> trays = await _trayService.GetAll(GetUserId());

            return _trayMapper.ConvertToResponseList(trays);
        }
    }
}
