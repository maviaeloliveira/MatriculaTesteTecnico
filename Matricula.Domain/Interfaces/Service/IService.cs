using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matricula.Domain.Interfaces.Service
{
    public interface IService<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<T> GetById(int? id);
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(int? id);
    }
}
