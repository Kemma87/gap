using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserEngine _userEngine;

        public AuthController(IUserEngine userEngine)
        {
            _userEngine = userEngine;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFound = await _userEngine.LoginAsync(userForLogin);

            if (userFound == null)
            {
                return Unauthorized();
            }

            return Ok(userFound);
        }
    }
}
