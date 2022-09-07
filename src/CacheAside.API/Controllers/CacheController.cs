using CacheAside.Application;
using CacheAside.Domain.Enums;
using CacheAside.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheAside.API.Controllers
{
    [ApiController]
    [Route("api/cache")]
    public class CacheController : ControllerBase
    {
        private readonly IAdapterKeyService _service;

        public CacheController(IAdapterKeyService service)
        {
            _service = service;
        }

        [HttpGet("{key}")]
        public async Task<AdapterKey> GetItemFromCache(string key)
        {
            return await _service.GetCacheAsync(key, CancellationToken.None);
        }        

        [HttpPost()]
        public async Task<ActionResult> AddItemToCache(AdapterKey adapterKey)
        {
            await _service.AddCacheAsync(adapterKey, CancellationToken.None);
            return Ok();
        }
    }
}
