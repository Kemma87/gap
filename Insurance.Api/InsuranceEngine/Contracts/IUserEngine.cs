using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface IUserEngine
    {
        Task<UserReturnDto> LoginAsync(UserForLoginDto login);
        Task<ICollection<string>> GetRolesByUserIdAsync(int userId);
        Task<UserReturnDto> AddUserAsync(UserAddDto user);
    }
}
