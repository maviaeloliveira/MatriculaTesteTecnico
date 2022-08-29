using Matricula.Application.Exceptions;
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
        private static int tempoDeExecucaoEmSegudos = 600;

        public void AlterarTempoDeExecucao(int segundos)
        {
            if (segundos <= 0)
                throw new BusinessException("Informe um valor válido");

            tempoDeExecucaoEmSegudos = segundos;
        }
        public int TempoDeExecucaoEmMilisegundos
        {
            get{
                return 1000 * tempoDeExecucaoEmSegudos;
            }        
            
        }
    }
}
