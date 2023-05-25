using CarStorage.API.Infrastructure;
using CarStorage.DAL.DataModel;
using CarStorage.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStorage.API.Controllers;

//[Authorize]
[EnableCors("CarRentWeb")]
[Route("api/[controller]")]
public class VehicleController : BaseApiController
{
    private readonly IVehicleService _vehicleService;
    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _vehicleService.GetAllAsync());
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _vehicleService.GetAsync(id));
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddVehicle([FromBody] Vehicle entity)
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _vehicleService.AddVehicle(entity));
        });
    }
}
