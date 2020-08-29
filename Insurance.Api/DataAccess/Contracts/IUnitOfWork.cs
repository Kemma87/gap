using DataAccess.Models;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<InsurancePolicy> InsurancePolicies { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        Task CommitAsync();
    }
}
