namespace Matricula.API.HostedService
{
    public class ProcessImportHostedService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecutaLogica, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void ExecutaLogica(object state)
        {

        }
    }
}
