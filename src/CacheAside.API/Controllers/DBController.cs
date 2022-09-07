using CacheAside.Application;
using CacheAside.Domain.Enums;
using CacheAside.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheAside.API.Controllers
{
    [ApiController]
    [Route("api/db")]
    public class DBController : ControllerBase
    {
        private readonly IAdapterKeyService _service;

        public DBController(IAdapterKeyService service)
        {
            _service = service;
        }


        [HttpGet("key")]
        public async Task<IEnumerable<AdapterKey>> GetItemsFromDb(string key)
        {
            return await _service.GetDbListAsync(key, CancellationToken.None);
        }

        [HttpPost()]
        public async Task<ActionResult> AddItemToDb(AdapterKey adapterKey)
        {
            await _service.AddDbAsync(adapterKey, CancellationToken.None);
            return Ok();
        }

    }
}
