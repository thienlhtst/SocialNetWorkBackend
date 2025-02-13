using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCore.InterfaceRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);

        Task<int> CreateRange(List<T> entities);

        Task<T> Update(T entity);

        Task<int> Delete(T entity);

        Task<int> DeleteRange(List<T> entities);

        Task<T> GetById(string id);

        Task<List<T>> GetAll();
    }
}
