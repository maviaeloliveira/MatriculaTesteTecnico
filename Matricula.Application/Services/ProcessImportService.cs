using Matricula.Application.Interfaces;
using Matricula.Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Application.Services
{
    public class ProcessImportService : IProcessImportService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessImportService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public async Task Execute(CancellationToken stoppingToken)
        {
            var matriculaAlunoAleatorio = _serviceProvider.GetRequiredService<IMatriculaAlunoService>();

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(2000);
                matriculaAlunoAleatorio.AddMatriculaAlunoAleatorio();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
