using InsuranceEngine.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationEngine _locationEngine;

        public LocationController(ILocationEngine locationEngine)
        {
            _locationEngine = locationEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfLocations = await _locationEngine.GetAllLocationsAsync();
            return Ok(listOfLocations);
        }
    }
}
