using Microsoft.AspNetCore.Mvc;
using SmartTray.API.Models.Requests;
using SmartTray.Domain.Interfaces;

namespace SmartTray.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrowthSettingsController : ControllerBase
    {
        readonly IGrowthSettingsService _growthSettingsService;

        public GrowthSettingsController(IGrowthSettingsService growthSettingsService)
        {
            _growthSettingsService = growthSettingsService;
        }

        [HttpPost]
        public async Task Insert(GrowthSettingsRequest settingsRequest)
        {

        }
    }
}
