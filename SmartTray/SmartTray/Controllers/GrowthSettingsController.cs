using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Mappers;
using SmartTray.API.Models.Requests;
using SmartTray.Domain.Interfaces;

namespace SmartTray.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrowthSettingsController : ControllerBase
    {
        readonly IGrowthSettingsService _growthSettingsService;
        readonly IGrowthSettingsMapper _growthSettingsMapper;

        public GrowthSettingsController(IGrowthSettingsService growthSettingsService, IGrowthSettingsMapper growthSettingsMapper)
        {
            _growthSettingsService = growthSettingsService;
            _growthSettingsMapper = growthSettingsMapper;
        }

        [HttpPost]
        public async Task Insert(GrowthSettingsRequest settingsRequest)
        {

        }
    }
}
