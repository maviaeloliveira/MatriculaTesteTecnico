using Matricula.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Interfaces.Repository
{
    public interface IMatriculaAlunoRepository : IRepository<MatriculaAluno>
    {
        public Task<List<MatriculaAluno>> GetMatriculaPorAluno(string nome);
        public Task<List<MatriculaAluno>> GetMatriculas();
    }
}
