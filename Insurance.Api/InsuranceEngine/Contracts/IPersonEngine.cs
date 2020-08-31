using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface IPersonEngine
    {
        Task<List<PersonInsuranceDto>> GetInsurancesByPersonAsync(int personId);
        Task AddPersonInsuranceAsync(int personId, int insuranceId);
        Task DeletePersonInsuranceAsync(int personId, int insuranceId);
        Task<List<PersonDto>> GetAllPersonsAsync();
    }
}
