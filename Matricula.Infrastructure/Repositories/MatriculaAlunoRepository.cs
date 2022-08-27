using Matricula.Domain.Entities;
using Matricula.Domain.Interfaces.Repository;
using Matricula.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Infrastructure.Repositories
{
    public class MatriculaAlunoRepository : Repository<MatriculaAluno>, IMatriculaAlunoRepository
    {
        public MatriculaAlunoRepository(ApplicationDbContext contexto) : base(contexto)
        {
        }

        public async Task<List<MatriculaAluno>> GetMatriculaPorAluno(string nome)
        {
            return await _context.MatriculaAluno
             .AsNoTracking()
             .Where(c => c.Aluno.Nome.StartsWith(nome))
             .Include(c=> c.Aluno)
             .ToListAsync();
        }

        public async Task<List<MatriculaAluno>> GetMatriculas()
        {
            return await _context.MatriculaAluno
             .AsNoTracking()
             .Include(c => c.Aluno)
             .OrderByDescending(c=> c.DataMatricula)
             .ToListAsync();
        }
    }
}
