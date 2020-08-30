using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface IInsuranceEngine
    {
        Task<IEnumerable<InsuranceReturnDto>> GetAllInsurancesAsync();
        Task<InsuranceReturnDto> GetAllInsurancesByIdAsync(int id);
        Task<InsuranceReturnDto> AddAsync(InsuranceCreationDto insurance);
        Task<bool> DeleteAsync(int Id);
    }
}
