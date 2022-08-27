using Matricula.Domain.Interfaces;
using Matricula.Domain.Interfaces.Repository;
using Matricula.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AlunoRepository _alunoRepository;
        private MatriculaAlunoRepository _matriculaAlunoRepository;

        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public IAlunoRepository alunoRepository
        {
            get
            {
                return _alunoRepository = _alunoRepository ?? new AlunoRepository(_context);
            }
        }

        public IMatriculaAlunoRepository matriculaAlunoRepository
        {
            get
            {
                return _matriculaAlunoRepository = _matriculaAlunoRepository ?? new MatriculaAlunoRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
