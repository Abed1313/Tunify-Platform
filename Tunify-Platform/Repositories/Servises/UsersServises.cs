using Microsoft.EntityFrameworkCore;
using Tunify_Platform.data;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Repositories.Servises
{
    public class UsersServises : IUsers
    {
        private readonly TunifyDbContext _context;

        public UsersServises(TunifyDbContext context)
        {
            _context = context;
        }
        public async Task<Users> CreateUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return users;   
        }

        public async Task DeleteUsers(int Usersid)
        {
            var getUser = await GetUsersById(Usersid);
            _context.Users.Remove(getUser);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Users>> GetAllUsers()
        {
           var allUsers = await _context.Users.ToListAsync();
            return allUsers;
        }

        public async Task<Users> GetUsersById(int Usersid)
        {
            var userById =await _context.Users.FindAsync(Usersid);
            return userById;
        }

        public async Task<Users> UpdateUsers(int Usersid, Users users)
        {
            var ecsistingUsers = await _context.Users.FindAsync(Usersid);
            ecsistingUsers = users;
            await _context.SaveChangesAsync();
            return ecsistingUsers;

        }
    }
}
