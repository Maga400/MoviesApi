using Microsoft.VisualBasic;
using MoviesApi.Services.Concretes;

namespace MoviesApi.Services
{
    public class BackgroundWorkerService : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroundWorkerService> _logger;
        private Timer _timer;
        private readonly RandomMoviesService _randomMoviesService = new RandomMoviesService();
        public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
             await _randomMoviesService.GetRandomMovies();

            //return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _logger.LogInformation("Background work is being performed at: {time}", DateTimeOffset.Now);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}


