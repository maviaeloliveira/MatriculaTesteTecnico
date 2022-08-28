using Matricula.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Application.Services
{
    public class ConfiguracaoSistemaService : IConfiguracaoSistemaService
    {
        private static int tempoDeExecucaoEmSegudos = 60;

        public void AlterarTempoDeExecucao(int valor)
        {
            tempoDeExecucaoEmSegudos = valor;
        }
        public int RetornarTempoDeExecucao()
        {
            
            return 1000 * tempoDeExecucaoEmSegudos;
        }
    }
}
