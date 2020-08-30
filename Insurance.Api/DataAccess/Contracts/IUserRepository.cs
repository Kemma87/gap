using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> CreateAsync(User user, string password);
        Task<User> LoginAsync(string username, string password);
        Task<bool> UserExistsAsync(string username);
    }
}
