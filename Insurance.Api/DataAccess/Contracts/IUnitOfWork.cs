using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IInsuranceRepository InsuranceRepository { get;  }
        IUserRepository UserRepository { get; }
        IRolesRepository RolesRepository { get; }
        Task CommitAsync();
    }
}
