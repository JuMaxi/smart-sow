﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.DTO;
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
        readonly ITraySettingsMapper _traySettings;
        readonly ITraySensorReadingService _sensorReadingService;

        public TrayController(
            ITrayService trayService,
            ITrayMapper trayMapper,
            ITraySettingsMapper traySettings,
            ITraySensorReadingService sensorReadingService)
        {
            _trayService = trayService;
            _trayMapper = trayMapper;
            _traySettings = traySettings;
            _sensorReadingService = sensorReadingService;
        }

        // This method is returning the user Id once it is authenticated. The claimtypes is a dictionary and I am using the key NameIdentifier
        private int GetUserId() => Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        // This method saves the tray to the database
        [Authorize]
        [HttpPost]
        public async Task Insert(TrayRequest trayRequest)
        {
            await _trayService.Insert(_trayMapper.ConvertToTray(trayRequest), GetUserId());
        }

        // This method fetch the tray by trayId from the database. It requires the user to be logged in
        [Authorize]
        [HttpGet("{trayId}")]
        public async Task<TrayResponse> GetById([FromRoute] int trayId)
        {
            Tray tray = await _trayService.GetById(trayId, GetUserId());

            TrayResponse trayResponse = _trayMapper.ConvertToResponse(tray);

            return trayResponse;
        }

        // This method fetch the tray by trayId from the database. It requires the user to be logged in
        [HttpGet("{trayId}/arduino")]
        public async Task<TrayInitialConfigurationResponse> GetByIdToArduino([FromRoute] int trayId, string token)
        {
            Tray tray = await _trayService.GetByIdAndToken(trayId, token);
            TraySensorReadingDTO readingsDTO = await _sensorReadingService.ReturnSensorReadingsCalculations(tray);

            TrayInitialConfigurationResponse settingsResponse = _traySettings.ConvertToResponse(tray.Settings, readingsDTO);
            return settingsResponse;
        }

        // This method fetch all the trays from the database. It requires the user to be logged in
        [Authorize]
        [HttpGet]
        public async Task<List<TrayResponse>> GetAll()
        {
            List<Tray> trays = await _trayService.GetAll(GetUserId());

            return _trayMapper.ConvertToResponseList(trays);
        }

        // This method updates the tray and its settings. It requires the user to be logged in
        [Authorize]
        [HttpPut("{trayId}")]
        public async Task Update([FromRoute] int trayId, TrayRequest trayRequest)
        {
            Tray tray = _trayMapper.ConvertToTray(trayRequest);
            tray.Id = trayId;
            await _trayService.Update(tray, GetUserId());
        }

        // This method update the tray status from active to inactive. It requires the user to be logged in
        [Authorize]
        [HttpPut("deactivate/{trayId}")]
        public async Task Deactivate([FromRoute] int trayId)
        {
            await _trayService.Deactivate(trayId, GetUserId());
        }
    }
}
