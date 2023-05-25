using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStorage.API.Infrastructure;

public class BaseApiController : ControllerBase
{
    protected async Task<IActionResult> HandleRequest(Func<Task<IActionResult>> action)
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
