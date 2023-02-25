using Domain.Interface;
using Entitites.Entities;
using Infrastructure.Configurations;
using Infrastructure.Repository.Generics;

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
    }
}
