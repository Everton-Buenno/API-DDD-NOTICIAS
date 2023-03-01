using Application.Interfaces;
using Entitites.Entities;
using Entitites.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {

        private readonly IApplicationNews _applicationNews;


        public NewsController(IApplicationNews applicationNews)
        {
            _applicationNews = applicationNews;
        }


        [Authorize]
        [HttpGet("/api/ListNews")]
        public async Task<List<News>> ListNews()
        {
            return await _applicationNews.GetActiveNews();
        }


        [Authorize]
        [HttpPost("/api/AddNews")]
        public async Task<List<Notification>> AddNews(NewsDto news)
        {
            var News = new News();

            News.Title = news.Title;
            News.Information = news.Information;
            News.UserId = await GetCurrentUser();


            await _applicationNews.AddNews(News);


            return (News.Notifications);

        }



        [Authorize]
        [HttpPost("/api/UpdateNews")]
        public async Task<List<Notification>> UpdateNews(NewsDto news)
        {
            var News = await _applicationNews.GetById(news.NewsId);

            News.Title = news.Title;
            News.Information = news.Information;
            News.UserId = await GetCurrentUser();


            await _applicationNews.UpdateNews(News);


            return (News.Notifications);

        }

        [Authorize]
        [HttpPost("/api/DeleteNews")]
        public async Task<List<Notification>> DeleteNews(NewsDto news)
        {

           
            var News = await _applicationNews.GetById(news.NewsId);
            await _applicationNews.Delete(News);
            return (News.Notifications);

        }


        [Authorize]
        [HttpPost("/api/GetOneNews")]
        public async Task<News> GetOneNews(NewsDto news)
        {
            var News = await _applicationNews.GetById(news.NewsId);
            return News;

        }

        private async Task<string> GetCurrentUser()
        {
            /*if (User != null)
            {
                var user = User.FindFirst("Sub")?.Value;
                return user;

            }
            else
            {
                return string.Empty;
            }
            */

            var id = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return id;


        }
        

    }
}
