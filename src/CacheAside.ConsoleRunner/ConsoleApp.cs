using Microsoft.Extensions.Logging;

namespace CacheAside.ConsoleRunner
{
    public class ConsoleApp
    {
        private readonly ILogger<ConsoleApp> _logger;

        public ConsoleApp(ILogger<ConsoleApp> logger
            )
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Starting the load test");

            try
            {
                Console.WriteLine("Running!!!!!");
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    $"Error during test: {ex.Message} | {ex.GetType().Name}");
            }

            _logger.LogInformation("Load tests finished.");
        }
    }
}
