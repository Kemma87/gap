using AutoMapper;
using DataAccess.Contracts;
using DataAccess.Models;
using Insurance.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsuranceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.InsuranceRepository.GetAllInsurancesAsync();
            var listOfInsurances = _mapper.Map<IEnumerable<InsuranceReturnDto>>(result);
            return Ok(listOfInsurances);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string userId, InsuranceCreationDto insurance)
        {
            var insuranceToCreate = _mapper.Map<InsurancePolicy>(insurance);
            await _unitOfWork.InsuranceRepository.AddAsync(insuranceToCreate);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string userId, int id)
        {
            var insurance = await _unitOfWork.InsuranceRepository.GetByIdAsync(id);

            if (insurance == null)
            {
                throw new ArgumentException($"No Insurance found for the Id: {id}");
            }

            _unitOfWork.InsuranceRepository.Delete(insurance);
            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
