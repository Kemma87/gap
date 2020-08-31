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
        ILocationRepository LocationRepository { get; }
        ICoverTypeRepository CoverTypeRepository { get; }
        IRiskTypeRepository RiskTypeRepository { get; }
        Task CommitAsync();
    }
}
