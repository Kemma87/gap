using InsuranceEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonEngine _personEngine;

        public PersonController(IPersonEngine personEngine)
        {
            _personEngine = personEngine;
        }

        [HttpGet("{personId}/insurances")]
        public async Task<IActionResult> GetAllInsurances([FromQuery] string username, int personId)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            var personInsurances = await _personEngine.GetInsurancesByPersonAsync(personId);
            return Ok(personInsurances);
        }

        [HttpPost("{personId}/insurance/{insuranceId}")]
        public async Task<IActionResult> AddPersonToInsurnace([FromQuery] string username, int personId, int insuranceId)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            await _personEngine.AddPersonInsuranceAsync(personId, insuranceId);
            return Ok();
        }

        [HttpDelete("{personId}/insurance/{insuranceId}")]
        public async Task<IActionResult> DeletePersonToInsurnace([FromQuery] string username, int personId, int insuranceId)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            await _personEngine.DeletePersonInsuranceAsync(personId, insuranceId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfPersons = await _personEngine.GetAllPersonsAsync();
            return Ok(listOfPersons);
        }
    }
}
