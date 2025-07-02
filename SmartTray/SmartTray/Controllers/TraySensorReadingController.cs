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
    public class TraySensorReadingController : ControllerBase
    {
        readonly ITraySensorReadingService _traySensorReadingService;
        readonly ITraySensorReadingMapper _traySensorReadingMapper;

        public TraySensorReadingController(
            ITraySensorReadingService traySensorReadingService,
            ITraySensorReadingMapper traySensorReadingMapper)
        {
            _traySensorReadingService = traySensorReadingService;
            _traySensorReadingMapper = traySensorReadingMapper;
        }

        // This method saves the readings from the sensor to the database
        [HttpPost]
        public async Task Insert(TraySensorReadingRequest readingRequest)
        {
            await _traySensorReadingService.Insert(_traySensorReadingMapper.ConvertToTraySensorReading(readingRequest));
        }

        // This method fetch all the tray readings from the database
        [HttpGet("{trayId}")]
        public async Task<List<TraySensorReadingResponse>> GetAll([FromRoute] int trayId)
        {
            List<TraySensorReading> readings = await _traySensorReadingService.GetAll(trayId);

            return _traySensorReadingMapper.ConvertToResponseList(readings);
        }

    }
}
