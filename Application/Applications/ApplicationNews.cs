using Application.Interfaces;
using Domain.Interface;
using Domain.Interface.ServicesInterfaces;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class ApplicationNews : IApplicationNews
    {


        private readonly INews _news;
        private readonly INewsService _newsService;

        public ApplicationNews(INews news, INewsService newsService)
        {
            _news = news;
            _newsService = newsService;
        }


        public async Task<List<News>> GetAll()
        {
            return await _news.GetAll();
        }

        public async Task<News> GetById(int Id)
        {
            return await _news.GetById(Id);
        }

        public async Task Add(News Entity)
        {
            await _news.Add(Entity);
        }

        public async Task Update(News Entity)
        {
            await _news.Update(Entity);
        }


        public async Task Delete(News Entity)
        {
            await _news.Delete(Entity);
        }








        public async Task<List<News>> GetActiveNews()
        {
            return await _newsService.GetActiveNews();
        }
        public async Task AddNews(News news)
        {
            await _newsService.AddNews(news);
        }
        public async Task UpdateNews(News news)
        {
            await _newsService.UpdateNews(news);
        }
    }
}
