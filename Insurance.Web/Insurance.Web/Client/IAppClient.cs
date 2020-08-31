using Insurance.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Web.Client
{
    public interface IAppClient
    {
        Task<List<InsuranceModel>> GetInsurancesAsync();
        Task<InsuranceModel> GetInsuranceByIdAsync(int id);
        Task<List<InsuranceModel>> GetInsuranceByPersonAsync(int personId);
        Task<List<string>> GetRolesByUserIdAsync(int id);
        Task<string> LoginAsync(LoginModel login);
        Task<List<LocationModel>> GetAllLocationsAsync();
        Task<List<RiskTypeModel>> GetAllRiskTypesAsync();
        Task<List<CoverTypeModel>> GetAllCoverTypesAsync();
        Task<List<PersonModel>> GetAllPersonsAsync();
        Task AddInsuranceAsync(InsuranceNewEditModel insurance);
        Task UpdateInsuranceAsync(InsuranceModel insurance);
        Task DeleteInsuranceAsync(int id);
        Task AddPersonInsuranceAsync(int personId, int insuranceId);
        Task RemovePersonInsuranceAsync(int personId, int insuranceId);
    }
}
