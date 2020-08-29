using DataAccess.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InsuranceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.InsuranceRepository.GetAllInsurancesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var result = await _unitOfWork.InsuranceRepository.GetAllInsurancesAsync();
            return Ok(result);
        }
    }
}
