using Domain.Interface;
using Entitites.Entities;
using Infrastructure.Configurations;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUser
    {

        private readonly DataContext _context;


        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(string email, string password, int age, string cell)
        {
            try
            {
                await _context.ApplicationUsers.AddAsync(new ApplicationUser
                {
                    Email = email,
                    PasswordHash = password,
                    Age = age,
                    Cell = cell
                });

                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }

        public async Task<bool> ExistsUser(string email, string password)
        {
            try
            {
                return await _context.ApplicationUsers.Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(password)).AsNoTracking().AnyAsync();



            }
            catch (Exception)
            {
                return false;
            }


            return true;
        }

        public async Task<string> ReturnUserId(string email)
        {
            try
            {
                var user = await _context.ApplicationUsers.Where(e => e.Email.Equals(email)).AsNoTracking().FirstOrDefaultAsync();
                if(user == null) { return ("Usuario Não Encontrado"); }    


                return user.Id;

            }
            catch (Exception)
            {
                return string.Empty;
            }

        }
    }
}
