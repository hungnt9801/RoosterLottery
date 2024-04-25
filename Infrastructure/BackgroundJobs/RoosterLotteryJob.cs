using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RoosterLottery.Infrastructure.ADO;
using System.ComponentModel;
using System.Data;

namespace RoosterLottery.Infrastructure.BackgroundJobs
{
    public class BackgroundJobService : IHostedService
    {
        private readonly ILogger<BackgroundJobService> _logger;
        private readonly IDataAccessService _dataAccessService;

        public BackgroundJobService(ILogger<BackgroundJobService> logger, IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background job started.");

            // Start your background task here
            Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Background job is running.");

                    SqlParameter[] parameters =
{
                    };
                    var result = _dataAccessService.ExecuteStoredProcedure<int>("DialOpenLottery", parameters);

                    int delayTime = 60 - DateTime.Now.Minute + 1;
                    await Task.Delay(TimeSpan.FromMinutes(delayTime), cancellationToken);
                }
            }, cancellationToken);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Background job stopped.");
            return Task.CompletedTask;
        }
    }
}
