using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        IInsuranceRepository InsuranceRepository { get;  }
        Task CommitAsync();
    }
}
