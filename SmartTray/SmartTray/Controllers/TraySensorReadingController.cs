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
            await _traySensorReadingService.Insert(_traySensorReadingMapper.ConvertFromRequest(readingRequest));
        }

        // This method fetch the readings by id from the database
        [HttpGet("{id}")]
        public async Task<TraySensorReadingResponse> GetById([FromRoute] int id)
        {
            TraySensorReading reading = await _traySensorReadingService.GetById(id);

            return _traySensorReadingMapper.ConvertToResponse(reading);
        }

        // This method fetch all the readings from the database
        [HttpGet]
        public async Task<List<TraySensorReadingResponse>> GetAll()
        {
            List<TraySensorReading> readings = await _traySensorReadingService.GetAll();

            return _traySensorReadingMapper.ConvertListToResponse(readings);
        }

    }
}
