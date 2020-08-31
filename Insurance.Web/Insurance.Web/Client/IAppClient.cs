using Insurance.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Web.Client
{
    public interface IAppClient
    {
        Task<List<InsuranceModel>> GetInsurancesAsync();
        Task<List<string>> GetRolesByUserIdAsync(int id);
        Task<string> LoginAsync(LoginModel login);
        Task DeleteInsuranceAsync(int id);
    }
}
