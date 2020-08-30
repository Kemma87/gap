using DataAccess.Contracts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _dataContext.Users
                .Include(p => p.Person).ThenInclude(x => x.Country)
                .Include(p => p.Roles)
                .Include(p => p.Person).ThenInclude(x => x.Gender).FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return null;
            }

            bool isValidUser = VerifyUser(user, password);

            if (!isValidUser)
            {
                return null;
            }

            return user;
        }

        public async Task<User> CreateAsync(User user, string password)
        {
            GeneratePasswordHash(user, password);

            await _dataContext.Users.AddAsync(user);

            return user;
        }

        public async Task<bool> ResetPasswordAsync(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
            {
                return false;
            }

            GeneratePasswordHash(user, password);

            _dataContext.Users.Update(user);

            return true;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            return await _dataContext.Users.AnyAsync(x => x.Username == username);
        }

        private void GeneratePasswordHash(User user, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            };
        }

        private bool VerifyUser(User user, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(user.PasswordSalt))
            {
                user.PasswordSalt = hmac.Key;
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            };
        }

        public async Task<User> GetUserDetailsByIdAsync(int id)
        {
            var user = await _dataContext.Users
                 .Include(p => p.Person).ThenInclude(x => x.Country)
                 .Include(p => p.Roles)
                 .Include(p => p.Person).ThenInclude(x => x.Gender).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
