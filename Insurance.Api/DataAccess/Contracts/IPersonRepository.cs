using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IPersonRepository: IRepository<Person>
    {
        Task<ICollection<InsurancePolicy>> GetInsurnacesByPersonIdAsync(int personId);
        Task AddPersonInsuranceAsync(int personId, int insuranceId);
        Task DeletePersonInsuranceAsync(int personId, int insuranceId);
        Task<bool> HasPersonInsuranceAsync(int personId, int insuranceId);
    }
}
