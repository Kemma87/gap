using InsuranceEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoverTypeController : ControllerBase
    {
        private readonly ICoverTypeEngine _coverTypeEngine;

        public CoverTypeController(ICoverTypeEngine coverTypeEngine)
        {
            _coverTypeEngine = coverTypeEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfcoverTypes = await _coverTypeEngine.GetAllCoverTypesAsync();
            return Ok(listOfcoverTypes);
        }
    }
}
