using Domain.Interface;
using Entitites.Entities;
using Infrastructure.Configurations;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class NewsRepository : GenericRepository<News>, INews
    {

        private readonly DataContext _context;
        public NewsRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<News>> ListNews(Expression<Func<News, bool>> expressionNews)
        {
            return await _context.News.Where(expressionNews).AsNoTracking().ToListAsync();
        }
    }
}
