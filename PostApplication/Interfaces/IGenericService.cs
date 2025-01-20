using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<int> Delete(string id);
    }
}
