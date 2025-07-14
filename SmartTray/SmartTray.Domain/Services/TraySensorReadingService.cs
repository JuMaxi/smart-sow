using SmartTray.Domain.DTO;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Domain.Services
{
    public class TraySensorReadingService : ITraySensorReadingService
    {
        private readonly ITraySensorReadingRepository _traySensorReadingRepository;
        private readonly ITrayRepository _trayRepository;

        public TraySensorReadingService(
            ITraySensorReadingRepository traySensorReadingDbAccess,
            ITrayRepository trayRepository)
        {
            _traySensorReadingRepository = traySensorReadingDbAccess;
            _trayRepository = trayRepository;
        }

        // Insert new sensor readings (arduino) from the sensors to the database
        public async Task Insert(int trayId, string token, TraySensorReading reading)
        {
            Tray tray = await _trayRepository.GetByIdAndToken(trayId, token);

            // Check if token corresponds to the tray token, if so, insert into database.
            if (tray.Token == token)
            {
                // The FK to the tray
                reading.Tray = tray;

                await _traySensorReadingRepository.Insert(reading);
            }
        }

        // Fetching all sensors readings to the user/tray
        public async Task<List<TraySensorReading>> GetAll(int trayId, int userId)
        {
            return await _traySensorReadingRepository.GetAll(trayId, userId);
        }

        // Fetching the lastest sensors readings
        public async Task<TraySensorReading> GetLatest(int trayId, int userId)
        {
            return await _traySensorReadingRepository.GetLatest(trayId, userId);
        }

        // Fetching the day sensors readings
        public async Task<List<TraySensorReading>> GetDayReadings(int trayId, int userId, DateTime? date)
        {   
            // In case date be null, get always the current day
            if (date == null)
            {
                date = DateTime.UtcNow;
            }

            return await _traySensorReadingRepository.GetDayReadings(trayId, userId, date);
        }

        // Calculate total daily minutes uv light 
        public async Task<TraySensorReadingDTO> CalculateLightTime(Tray tray, TraySensorReading latest)
        {
            // The target solar daily hours from tray settings
            int targetSolarLight = tray.Settings.DailySolarHours;

            // The target solar daily hours converted to minutes
            int targetSolarLightMinutes = targetSolarLight * 60;

            // Get the daily readings
            List<TraySensorReading> dailyReadings = await GetDayReadings(latest.Tray.Id, tray.User.Id, latest.Date);

            // Calculate the span time minutes between readings
            int spanTimeMinutes = dailyReadings[0].Date.Minute - dailyReadings[1].Date.Minute;

            // Artificial light means the UV leds were turned on and there are no sun light. It is the artificial light time in minutes
            int artificialLightMinutes = 0;

            // Sun light, means natural light, no Uv leds turned on. Represented by a integer great than 0. It is the solar light time in minutes
            int solarLightMinutes = 0;

            // This variable will store the total of uv light the tray had till the last reading. Each time the conditions below are true add spanTime to it
            int minutes = 0;

            // For each Uv sensor reading on the day readings
            foreach (TraySensorReading reading in dailyReadings)
            {
                // If UV > 0 it means there are sun light
                if (reading.UV > 0)
                {
                    solarLightMinutes += spanTimeMinutes;
                    minutes += spanTimeMinutes;
                }
                else
                {
                    // If the Uv leds are on, it means there are no sun light, so the tray is suplied with artificial light
                    if (reading.UvLedsOn == true)
                    {
                        artificialLightMinutes += spanTimeMinutes;
                        minutes += spanTimeMinutes;
                    }
                }

            }

            // Find how many light min is missing to the tray complet the target min
            int remainingMinutes = targetSolarLightMinutes - minutes;

            // Populating the DTO with the relevant information to call the end point to the chart in the front end via js
            TraySensorReadingDTO ligthData = new()
            {
                DailyLightMinutes = minutes,
                ArtificialLightMinutes = artificialLightMinutes,
                SolarLightMinutes = solarLightMinutes,
                RemainingLightMinutes = remainingMinutes
            };
  
            return ligthData;
        }

        // Convert the humidity setting to a number that the humidity sensor works with
        private int InterpretHumiditySetting(int humidity)
        {
            if (humidity == 1)
            {
                return 2700;
            }

            if (humidity == 2)
            {
                return 2500;
            }

            if (humidity == 3)
            {
                return 2100;
            }

            return humidity;
        }

        // This function is calling the functions to calculate time of uv light and interpret humidity setting
        public async Task<TraySensorReadingDTO> ReturnSensorReadingsCalculations(Tray tray)
        {
            // Fetch the latest sensor readings from the database
            TraySensorReading latest = await GetLatest(tray.Id, tray.User.Id);

            TraySensorReadingDTO readingsData = await CalculateLightTime(tray, latest);

            readingsData.Humidity = InterpretHumiditySetting((int)tray.Settings.Humidity);

            return readingsData;
        }
    }
}
