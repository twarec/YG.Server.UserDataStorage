using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.ComponentModel.DataAnnotations;
using YG.Server.UserDataStorage.Controllers.Models;
using YG.Server.UserDataStorage.DataBase.Models;
using YG.Server.UserDataStorage.Services;

namespace YG.Server.UserDataStorage.Controllers;

[ApiController]
[Route("UserDataStorage/[controller]")]
[ApiExplorerSettings(GroupName = "UserDataStorage")]
public class RootController(IRootService rootService) : ControllerBase
{
    [HttpGet("Id/{id}")]
    [ProducesResponseType(typeof(Root), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetFromIdAsync([FromRoute, Required] string id)
    {
        var result = await rootService.GetAsync(id);
        if(result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("Range/All")]
    [ProducesResponseType(typeof(IEnumerable<Root>), 200)]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await rootService.GetAllAsync());
    }

    [HttpGet("Range")]
    [ProducesResponseType(typeof(IEnumerable<Root>), 200)]
    public async Task<IActionResult> GetRangeAsync([FromQuery, Required] int offset, [FromQuery, Required] int count)
    {
        return Ok(await rootService.GetRangeAsync(offset, count));
    }

    [HttpPost]
    [ProducesResponseType(typeof(Root), 200)]
    public async Task<IActionResult> AddAsync([FromBody, Required] RootCreateData data)
    {
        var result = await rootService.CreateAsync(data.ToDataBase());
        return Ok(result);
    } 
}
