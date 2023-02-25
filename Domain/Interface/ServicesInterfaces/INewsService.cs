using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.ServicesInterfaces
{
    public interface INewsService 
    {

        Task AddNews(News news);

        Task UpdateNews(News news);

        Task<List<News>> GetActiveNews();

    }
}
