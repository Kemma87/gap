using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface ICoverTypeEngine
    {
        Task<List<CoverTypeDto>> GetAllCoverTypesAsync();
    }
}
