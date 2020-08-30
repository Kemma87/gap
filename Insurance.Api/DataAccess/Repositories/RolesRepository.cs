using DataAccess.Contracts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class RolesRepository : Repository<Role>, IRolesRepository
    {
        private readonly DataContext _dataContext;

        public RolesRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ICollection<Role>> GetRolesByUserId(int userId)
        {
            return await (from userRole in _dataContext.UserRoles
                            join role in _dataContext.Roles on userRole.RoleId equals role.Id
                            where userRole.UserId == userId
                            select role).ToListAsync();
        }
    }
}
