using Domain.Interface;
using Domain.Interface.ServicesInterfaces;
using Entitites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicesNews : INewsService
    {

        private readonly INews _news;

        public ServicesNews(INews news)
        {
            _news = news;
        }


        public async Task AddNews(News news)
        {
            var validateTitle = news.ValidateProperties(news.Title, "Title");
            var validateInformations = news.ValidateProperties(news.Information, "Information");


            if(validateTitle && validateInformations)
            {
                news.UpdateData = DateTime.Now;
                news.RegisterData = DateTime.Now;
                news.Active = true;
                await _news.Add(news);
            }


        }

      

        public async Task UpdateNews(News news)
        {
            var validateTitle = news.ValidateProperties(news.Title, "Title");
            var validateInformations = news.ValidateProperties(news.Information, "Information");


            if (validateTitle && validateInformations)
            {
                news.UpdateData = DateTime.Now;
                news.RegisterData = DateTime.Now;
                news.Active = true;
                await _news.Update(news);
            }
        }

        public async Task<List<News>> GetActiveNews()
        {
            return await _news.ListNews(n => n.Active);
        }


    }
}
