using Domain.Interface.Generics;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface INews : IGenerics<News>
    {
        Task<List<News>> ListNews(Expression<Func<News, bool>> expressionNews);

    }
}
