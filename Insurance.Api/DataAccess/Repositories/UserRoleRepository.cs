using DataAccess.Contracts;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class UserRoleRepository: Repository<UserRoles>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
