using System.Security.Claims;
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
    public class TraySensorReadingController : ControllerBase
    {
        readonly ITraySensorReadingService _traySensorReadingService;
        readonly ITraySensorReadingMapper _traySensorReadingMapper;

        // This method is returning the user Id once it is authenticated. The claimtypes is a dictionary and I am using the key NameIdentifier
        private int GetUserId() => Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public TraySensorReadingController(
            ITraySensorReadingService traySensorReadingService,
            ITraySensorReadingMapper traySensorReadingMapper)
        {
            _traySensorReadingService = traySensorReadingService;
            _traySensorReadingMapper = traySensorReadingMapper;
        }

        // This method saves the readings from the sensor to the database
        // Don't need javascript to call this endpoint, because it is the data from the sensor that goes to the database
        [HttpPost("{trayId}")]
        public async Task Insert([FromRoute] int trayId, [FromQuery] string token, TraySensorReadingRequest readingRequest)
        {
            TraySensorReading readings = _traySensorReadingMapper.ConvertToTraySensorReading(readingRequest);

            await _traySensorReadingService.Insert(trayId, GetUserId(), token, readings);
        }

        // This method fetch all the tray readings from the database
        [Authorize]
        [HttpGet("{trayId}")]
        public async Task<List<TraySensorReadingResponse>> GetAll([FromRoute] int trayId)
        {
            List<TraySensorReading> readings = await _traySensorReadingService.GetAll(trayId, GetUserId());

            return _traySensorReadingMapper.ConvertToResponseList(readings);
        }

        // This method fetch the last sensors readings from database
        [Authorize]
        [HttpGet("{trayId}/latest")]
        public async Task<TraySensorReadingResponse> GetLatest([FromRoute] int trayId)
        {
            TraySensorReading latest = await _traySensorReadingService.GetLatest(trayId, GetUserId());

            return _traySensorReadingMapper.ConvertToResponse(latest);
        }

        // This method fetch daily readings from database. If the day is null, gets the current day
        [Authorize]
        [HttpGet("{trayId}/daily-uv-time")]
        public async Task<TraySensorReadingDTOResponse> GetLightHours([FromRoute] int trayId)
        {
            DateTime date = DateTime.Today.AddDays(-1);

            TraySensorReadingDTO latest = await _traySensorReadingService.CalculateHoursUV(trayId, GetUserId(), date);

            return _traySensorReadingMapper.ConvertToDTOResponse(latest);

        }
    }
}
