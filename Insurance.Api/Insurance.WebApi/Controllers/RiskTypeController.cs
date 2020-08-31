using InsuranceEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    [Route("api/[controller]")]
    [ApiController]
    public class RiskTypeController : ControllerBase
    {
        private readonly IRiskTypeEngine _riskTypeEngine;

        public RiskTypeController(IRiskTypeEngine riskTypeEngine)
        {
            _riskTypeEngine = riskTypeEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfRiskTypes = await _riskTypeEngine.GetAllRiskTypesAsync();
            return Ok(listOfRiskTypes);
        }
    }
}
