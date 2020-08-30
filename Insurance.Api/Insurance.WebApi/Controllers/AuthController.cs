using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFound = await _userEngine.LoginAsync(userForLogin);

            if (userFound == null)
            {
                return Unauthorized();
            }

            return Ok(userFound);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> AddUser(UserAddDto user)
        {
           var userCreated = await _userEngine.AddUserAsync(user);
            return CreatedAtRoute("GetUser", new { Controller = "Auth", id = userCreated.Id }, userCreated);
        }
    }
}
