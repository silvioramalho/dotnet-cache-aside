using CacheAside.Application;
using CacheAside.Domain.Enums;
using CacheAside.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CacheAside.API.Controllers
{
    [ApiController]
    [Route("api/adapter")]
    public class HomeController : ControllerBase
    {
        private readonly IAdapterKeyService _service;

        public HomeController(IAdapterKeyService service)
        {
            _service = service;
        }

        [HttpGet("key")]
        public async Task<string> GetRelatedKey(string key)
        {
            return await _service.GetRelatedKey(key, ValueTypeEnum.Internal,CancellationToken.None);
        }
    }
}
