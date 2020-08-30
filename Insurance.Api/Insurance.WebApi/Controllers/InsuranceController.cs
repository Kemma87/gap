using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Authorize(Roles = "Administrator, CustomerService")]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceEngine _insuranceEngine;

        public InsuranceController(IInsuranceEngine insuranceEngine)
        {
            _insuranceEngine = insuranceEngine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listOfInsurances = await _insuranceEngine.GetAllInsurancesAsync();
            return Ok(listOfInsurances);
        }

        [HttpGet("{id}", Name = "GetInsurance")]
        public async Task<IActionResult> GetById(string username, int id)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            var insurance = await _insuranceEngine.GetAllInsurancesByIdAsync(id);

            if (insurance == null)
            {
                throw new ArgumentException($"No Insurance found for the Id: {id}");
            }

            return Ok(insurance);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string username, InsuranceCreationDto insurance)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            var insuranceCreated = await _insuranceEngine.AddAsync(insurance);
            return CreatedAtRoute("GetInsurance", new { Controller = "Insurance", id = insuranceCreated.Id }, insuranceCreated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string username, int id)
        {
            if (username != User.FindFirst(ClaimTypes.Name).Value)
            {
                return Unauthorized();
            }

            var result = await _insuranceEngine.DeleteAsync(id);

            if (!result)
            {
                throw new ArgumentException($"No Insurance found for the Id: {id}");
            }            

            return Ok();
        }
    }
}
