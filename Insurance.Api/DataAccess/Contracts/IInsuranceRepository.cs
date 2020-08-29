using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IInsuranceRepository: IRepository<InsurancePolicy>
    {
        Task<IEnumerable<InsurancePolicy>> GetAllInsurancesAsync();
    }
}
