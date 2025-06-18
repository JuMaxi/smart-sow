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

        public TrayController(
            ITrayService trayService,
            ITrayMapper trayMapper)
        {
            _trayService = trayService;
            _trayMapper = trayMapper;
        }

        // This method saves the tray to the database
        [HttpPost]
        public async Task Insert(TrayRequest trayRequest)
        {
            await _trayService.Insert(_trayMapper.ConvertFromRequest(trayRequest));
        }

        // This method fetch the tray by id from the database
        [HttpGet("{id}")]
        public async Task<TrayResponse> GetById([FromRoute] int id)
        {
            Tray tray = await _trayService.GetById(id);

            return _trayMapper.ConvertToResponse(tray);
        }

        // This method fetch all the trays from the database
        [HttpGet]
        public async Task<List<TrayResponse>> GetAll()
        {
            List<Tray> trays = await _trayService.GetAll();

            return _trayMapper.ConvertListToResponse(trays);
        }
    }
}
