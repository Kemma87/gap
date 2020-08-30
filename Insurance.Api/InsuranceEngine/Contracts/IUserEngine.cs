using InsuranceEngine.Dtos;
using System.Threading.Tasks;

namespace InsuranceEngine.Contracts
{
    public interface IUserEngine
    {
        Task<UserReturnDto> LoginAsync(UserForLoginDto login);
    }
}
