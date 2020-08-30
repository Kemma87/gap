using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IInsuranceRepository InsuranceRepository { get;  }
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        IPersonRepository PersonRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        Task CommitAsync();
    }
}
