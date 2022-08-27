using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Interfaces.Service
{
    public interface IConfiguracaoSistemaService
    {
        public void AlterarTempoDeExecucao(int valor);

        public int RetornarTempoDeExecucao();
    }
}
