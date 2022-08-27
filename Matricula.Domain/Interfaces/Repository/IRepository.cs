using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Interfaces.Repository
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> Get();
        Task<T> GetById(int? id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
