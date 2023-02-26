using Application.Interfaces.Generics;
using Entitites.Entities;

namespace Application.Interfaces
{
    public interface IApplicationNews : IGenericApplication<News>
    {

        Task AddNews(News news);

        Task UpdateNews(News news);

        Task<List<News>> GetActiveNews();


    }
}
