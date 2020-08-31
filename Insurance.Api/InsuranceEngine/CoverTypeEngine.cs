using AutoMapper;
using DataAccess.Contracts;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class CoverTypeEngine : ICoverTypeEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverTypeEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CoverTypeDto>> GetAllCoverTypesAsync()
        {
            var result = await _unitOfWork.CoverTypeRepository.GetAllAsync();
            return _mapper.Map<List<CoverTypeDto>>(result);
        }
    }
}
