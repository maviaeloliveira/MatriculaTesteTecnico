using Matricula.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAlunoRepository alunoRepository { get; }
        IMatriculaAlunoRepository matriculaAlunoRepository { get; }

        void Commit();
    }
}
