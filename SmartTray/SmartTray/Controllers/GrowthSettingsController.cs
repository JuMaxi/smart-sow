using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.API.Models.Responses;
using SmartTray.Domain.Interfaces;
using SmartTray.Domain.Models;

namespace SmartTray.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrowthSettingsController : ControllerBase
    {
        readonly IGrowthSettingsService _growthSettingsService;
        readonly IGrowthSettingsMapper _growthSettingsMapper;

        public GrowthSettingsController(
            IGrowthSettingsService growthSettingsService,
            IGrowthSettingsMapper growthSettingsMapper)
        {
            _growthSettingsService = growthSettingsService;
            _growthSettingsMapper = growthSettingsMapper;
        }

        [HttpPost]
        public async Task Insert(GrowthSettingsRequest settingsRequest)
        {
           await _growthSettingsService.Insert(_growthSettingsMapper.ConvertFromRequest(settingsRequest));
        }

        [HttpGet("{id}")]
        public async Task<GrowthSettingsResponse> GetById([FromRoute] int id)
        {
            GrowthSettings settings = await _growthSettingsService.GetById(id);

            return _growthSettingsMapper.ConvertToResponse(settings);
        }
    }
}
