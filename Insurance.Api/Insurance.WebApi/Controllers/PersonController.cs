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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfPersons = await _personEngine.GetAllPersonsAsync();
            return Ok(listOfPersons);
        }
    }
}
