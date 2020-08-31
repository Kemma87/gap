using AutoMapper;
using DataAccess.Contracts;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class PersonEngine : IPersonEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PersonInsuranceDto>> GetInsurancesByPersonAsync(int personId)
        {
            var insurances = await _unitOfWork.PersonRepository.GetInsurnacesByPersonIdAsync(personId);
            var dtoInsurances = _mapper.Map<List<PersonInsuranceDto>>(insurances);

            return dtoInsurances;
        }

        public async Task<List<PersonDto>> GetAllPersonsAsync()
        {
            var result = await _unitOfWork.PersonRepository.GetAllAsync();
            return _mapper.Map<List<PersonDto>>(result);
        }

        public async Task AddPersonInsuranceAsync(int personId, int insuranceId)
        {
            var hasInsurance = await _unitOfWork.PersonRepository.HasPersonInsuranceAsync(personId, insuranceId);

            if (hasInsurance)
            {
                throw new ArgumentException("This person already has this insurance");
            }

            await _unitOfWork.PersonRepository.AddPersonInsuranceAsync(personId, insuranceId);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePersonInsuranceAsync(int personId, int insuranceId)
        {
            var hasInsurance = await _unitOfWork.PersonRepository.HasPersonInsuranceAsync(personId, insuranceId);

            if (!hasInsurance)
            {
                throw new ArgumentException("No person with insurance was found");
            }

            await _unitOfWork.PersonRepository.DeletePersonInsuranceAsync(personId, insuranceId);
            await _unitOfWork.CommitAsync();
        }
    }
}
