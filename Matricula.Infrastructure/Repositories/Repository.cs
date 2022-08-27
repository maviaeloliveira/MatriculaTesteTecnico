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
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public Repository(ApplicationDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<IQueryable<T>> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
