using Matricula.Domain.Entities;
using Matricula.Domain.Interfaces.Repository;
using Matricula.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Infrastructure.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext contexto) : base(contexto)
        {
        }
    }
}
