using Matricula.Application.Interfaces;
using Matricula.Domain.Interfaces.Service;
using System.Timers;

namespace Matricula.API.HostedService
{
    /// <summary>
    /// Usei essa estratégia pois a interface IHostedService usa o tipo Singleton para a criação do objeto 
    /// e com isso gera erro ao tentar usar as outras interfaces cadastradas do tipo scoped.
    /// </summary>
    public class ProcessImportHostedService : BackgroundService, IDisposable
    {
        private bool isRunning = false;
        private IServiceProvider _serviceProvider { get; }
        private readonly IConfiguracaoSistemaService _configuracaoSistemaService;
        private System.Timers.Timer timer;

        public ProcessImportHostedService(IConfiguracaoSistemaService configuracaoSistemaService, IServiceProvider serviceProvider)
        {
            _configuracaoSistemaService = configuracaoSistemaService;
            _serviceProvider = serviceProvider;

        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            timer = new System.Timers.Timer();
            //Primeira execução só espera 1 segundo. No finally do método OnTimedEvent altero para ficar o valor normal de espera para execução.
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler((object sender, ElapsedEventArgs e) => OnTimedEvent(stoppingToken));
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();
        }

        private async void OnTimedEvent(CancellationToken cancellationToken)
        {
            if (!isRunning)
            {
                isRunning = true;

                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        IServiceProvider serviceProvider = scope.ServiceProvider;
                        var service = serviceProvider.GetRequiredService<IProcessImportService>();
                        await service.Execute(cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    
                    GC.Collect();
                    isRunning = false;
                    timer.Interval = _configuracaoSistemaService.TempoDeExecucaoEmMilisegundos;
                    timer.Start();
                }
            }
        }
    }
}
