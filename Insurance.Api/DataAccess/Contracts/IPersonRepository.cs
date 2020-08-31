using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IPersonRepository: IRepository<Person>
    {
        Task<ICollection<InsurancePolicy>> GetInsurnacesByPersonIdAsync(int personId);
    }
}
