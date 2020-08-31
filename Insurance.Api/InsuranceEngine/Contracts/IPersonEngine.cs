using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface IPersonEngine
    {
        Task<List<PersonInsuranceDto>> GetInsurancesByPersonAsync(int personId);
        Task<List<PersonDto>> GetAllPersonsAsync();
    }
}
