using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationUser
    {
        Task<bool> AddUser(string email, string password, int age, string cell);
    }
}
