using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface ILocationEngine
    {
        Task<List<LocationDto>> GetAllLocationsAsync();
    }
}
