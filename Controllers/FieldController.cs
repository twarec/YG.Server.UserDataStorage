using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using YG.Server.UserDataStorage.DataBase.Models;
using YG.Server.UserDataStorage.Services;

namespace YG.Server.UserDataStorage.Controllers
{
    [ApiController]
    [Route("UserDataStorage/[controller]")]
    public class FieldController(IFieldService fieldService) : ControllerBase
    {
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SetAsync([FromRoute, Required] int id, [FromQuery, Required] string value)
        {
            var result = await fieldService.SetAsync(id, value);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync([FromRoute, Required] int id)
        {
            var result = await fieldService.GetAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Range/All")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await fieldService.GetAllAsync());
        }

        [HttpGet("Range")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetRangeAsync([FromQuery, Required] int offset, [FromQuery, Required] int count)
        {
            return Ok(await fieldService.GetRangeAsync(offset, count));
        }

        [HttpGet("Key/{key}/Range/All")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetAllAsync([FromRoute, Required] string key)
        {
            return Ok(await fieldService.GetAllAsync(key));
        }

        [HttpGet("Key/{key}/Range")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetRangeAsync([FromRoute, Required] string key, [FromQuery, Required] int offset, [FromQuery, Required] int count)
        {
            return Ok(await fieldService.GetRangeAsync(offset, count, key));
        }

        [HttpPut("Root/Id/{rootId}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SetAsync([FromRoute, Required] int rootId, [FromQuery, Required] string key, [FromQuery, Required] string value)
        {
            var result = await fieldService.SetAsync(rootId, key, value) ?? await fieldService.CreateAsync(rootId, key, value);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Root/Id/{rootId}/Range/All")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetAllFromRootAsync([FromRoute, Required] int rootId)
        {
            return Ok(await fieldService.GetAllFromRootAsync(rootId));
        }

        [HttpGet("Root/Id/{rootId}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFromRootAsync([FromRoute, Required] int rootId, [FromQuery, Required] string key)
        {
            var result = await fieldService.GetFromRootAsync(rootId, key);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Root/Id/{rootId}/Range")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetRangeFromRootAsync([FromQuery, Required] int offset, [FromQuery, Required] int count, [FromRoute, Required] int rootId)
        {
            return Ok(await fieldService.GetRangeFromRootAsync(offset, count, rootId));
        }

        [HttpPut("Root/Key/{rootKey}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SetAsync([FromRoute, Required] string rootKey, [FromQuery, Required] string key, [FromQuery, Required] string value)
        {
            var result = await fieldService.SetAsync(rootKey, key, value) ?? await fieldService.CreateAsync(rootKey, key, value);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Root/Key/{rootKey}")]
        [ProducesResponseType(typeof(Field), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFromRootAsync([FromRoute, Required] string rootKey, [FromQuery, Required] string key)
        {
            var result = await fieldService.GetFromRootAsync(rootKey, key);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("Root/Key/{rootKey}/Range/All")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetAllFromRootAsync([FromRoute, Required] string rootKey)
        {
            return Ok(await fieldService.GetAllFromRootAsync(rootKey));
        }

        [HttpGet("Root/Key/{rootKey}/Range")]
        [ProducesResponseType(typeof(IEnumerable<Field>), 200)]
        public async Task<IActionResult> GetRangeFromRootAsync([FromQuery, Required] int offset, [FromQuery, Required] int count, [FromRoute, Required] string rootKey)
        {
            return Ok(await fieldService.GetRangeFromRootAsync(offset, count, rootKey));
        }

    }
}
