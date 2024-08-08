using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface IUsers
    {
        Task<Users> CreateUsers(Users users);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUsersById(int Usersid);
        Task<Users> UpdateUsers(int Usersid, Users users);
        Task DeleteUsers(int Usersid);


    }
}
