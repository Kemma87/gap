using AutoMapper;
using DataAccess.Contracts;
using DataAccess.Models;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class InsuranceEngine : IInsuranceEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsuranceEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InsuranceReturnDto> AddAsync(InsuranceCreationDto insurance)
        {
            var insuranceToCreate = _mapper.Map<InsurancePolicy>(insurance);
            await _unitOfWork.InsuranceRepository.AddAsync(insuranceToCreate);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<InsuranceReturnDto>(insuranceToCreate);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var insurance = await _unitOfWork.InsuranceRepository.GetByIdAsync(id);

            if (insurance == null)
            {
                return false;
            }

            _unitOfWork.InsuranceRepository.Delete(insurance);
            await _unitOfWork.CommitAsync();

            return true;
        }

        public async Task<IEnumerable<InsuranceReturnDto>> GetAllInsurancesAsync()
        {
            var result = await _unitOfWork.InsuranceRepository.GetAllInsurancesAsync();
            return _mapper.Map<IEnumerable<InsuranceReturnDto>>(result);
        }

        public async Task<InsuranceReturnDto> GetAllInsurancesByIdAsync(int id)
        {
            var insurance = await _unitOfWork.InsuranceRepository.GetAllInsurancesByIdAsync(id);
            return _mapper.Map<InsuranceReturnDto>(insurance);
        }
    }
}
