using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Application.Interfaces
{
    public interface IProcessImportService : IDisposable
    {
        Task Execute(CancellationToken stoppingToken);
    }
}
