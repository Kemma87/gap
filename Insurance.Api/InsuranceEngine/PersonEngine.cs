using AutoMapper;
using DataAccess.Contracts;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using System.Collections.Generic;
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
    }
}
