using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Generics
{
    public interface IGenericApplication<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
