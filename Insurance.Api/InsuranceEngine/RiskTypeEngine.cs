using AutoMapper;
using DataAccess.Contracts;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class RiskTypeEngine: IRiskTypeEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskTypeEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RiskTypeDto>> GetAllRiskTypesAsync()
        {
            var result = await _unitOfWork.RiskTypeRepository.GetAllAsync();
            return _mapper.Map<List<RiskTypeDto>>(result);
        }
    }
}
