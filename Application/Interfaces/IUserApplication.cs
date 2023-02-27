using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserApplication
    {
        Task<bool> AddUser(string email, string password, int age, string cell);
        Task<bool> ExistsUser(string email, string password);
    }
}
