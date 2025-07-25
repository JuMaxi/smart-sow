﻿using SmartTray.Domain.DTO;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Interfaces
{
    public interface ITraySensorReadingService
    {
        public Task Insert(int trayId, string token, TraySensorReading reading);
        public Task<List<TraySensorReading>> GetAll(int trayId, int userId);
        public Task<TraySensorReading> GetLatest(int trayId, int userId);
        public Task<TraySensorReadingDTO> CalculateLightTime(Tray tray, TraySensorReading latest);
        public Task<TraySensorReadingDTO> ReturnSensorReadingsCalculations(Tray tray);
    }
}
