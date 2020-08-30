using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRolesRepository: IRepository<Role>
    {
        Task<ICollection<Role>> GetRolesByUserId(int userId);
    }
}
