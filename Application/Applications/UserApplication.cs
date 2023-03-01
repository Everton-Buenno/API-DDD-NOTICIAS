using Application.Interfaces;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class UserApplication : IUserApplication
    {


        private readonly IUser _user;

        public UserApplication(IUser user)
        {
            _user = user;
        }

        public async Task<bool> AddUser(string email, string password, int age, string cell)
        {
            return await _user.AddUser(email, password, age, cell);
        }

        public async Task<bool> ExistsUser(string email, string password)
        {
            return await _user.ExistsUser(email, password);
        }

        public async Task<string> ReturnUserId(string email)
        {
            return await _user.ReturnUserId(email);
        }
    }
}
