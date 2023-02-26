

namespace Domain.Interface.Generics
{
    public interface IGenerics<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int Id);
        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity );

    }
}
