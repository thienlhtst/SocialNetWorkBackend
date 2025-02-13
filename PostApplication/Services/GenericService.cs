using PostApplication.Interfaces;
using PostCore.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostApplication.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(string id)
        {
            var check = await _repository.GetById(id);
            if (check == null) {
                return -1;
            }
            return await _repository.Delete(check);
        }

        public async Task<List<T>> GetAll()
        {
            List<T> result = await _repository.GetAll();
            return result;
        }

        public async Task<T> GetById(string id)
        {
            var result = await _repository.GetById(id);
            if (result == null) { 
                return null;
            }
            return result;
        }
    }
}
