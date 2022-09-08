using CacheAside.Application;
using CacheAside.Application.Providers;
using CacheAside.Domain.Enums;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CacheAside.ConsoleRunner
{
    public class ConsoleApp
    {
        private readonly ILogger<ConsoleApp> _logger;
        private readonly IAdapterKeyService _adapterKeyService;

        public ConsoleApp(ILogger<ConsoleApp> logger,
            IAdapterKeyService adapterKeyService)
        {
            _logger = logger;
            _adapterKeyService = adapterKeyService;
        }

        public void Run()
        {
            _logger.LogInformation($"[{DateTime.UtcNow}] Starting the load test");
            const int ITEMS_NUMBER = 100000;
            var sw = new Stopwatch();
            sw.Start();
            try
            {
                Parallel.For(0, ITEMS_NUMBER, number =>
                {
                    var phoneNumberKey = PhoneNumberProvider.GetRandom(false);
                    var result = _adapterKeyService.GetRelatedKey(phoneNumberKey, ValueTypeEnum.External, CancellationToken.None).Result;
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Error during test: {ex.Message} | {ex.GetType().Name}");
            }
            sw.Stop();
            _logger.LogInformation($"[{DateTime.UtcNow}] Load tests finished in {sw.ElapsedMilliseconds} ms with {ITEMS_NUMBER/(sw.ElapsedMilliseconds/1000)} item/s");
        }
    }
}
