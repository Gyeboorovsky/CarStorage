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
public class BodyTypeController : BaseApiController
{
    private readonly IBodyTypeService _bodyTypeService;
    public BodyTypeController(IBodyTypeService bodyTypeService)
    {
        _bodyTypeService = bodyTypeService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _bodyTypeService.GetAllAsync());
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _bodyTypeService.GetAsync(id));
        });
    }

    [HttpPost]
    public async Task<IActionResult> AddBodyType([FromBody] BodyType entity)
    {
        return await HandleRequest(async () =>
        {
            return Ok(await _bodyTypeService.AddBodyType(entity));
        });
    }
}
