using Aplication.Interfaces.Messaging;

namespace Worker.FinanceService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEnrollmentConsumerService _consumerService;

        public Worker(ILogger<Worker> logger, IEnrollmentConsumerService consumerService)
        {
            _logger = logger;
            _consumerService = consumerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                await _consumerService.StartConsumerLoop();

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
