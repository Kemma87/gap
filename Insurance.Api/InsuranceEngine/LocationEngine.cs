using AutoMapper;
using DataAccess.Contracts;
using InsuranceEngine.Contracts;
using InsuranceEngine.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceEngine
{
    public class LocationEngine : ILocationEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LocationEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> GetAllLocationsAsync()
        {
            var result = await _unitOfWork.LocationRepository.GetAllAsync();
            return _mapper.Map<List<LocationDto>>(result);
        }
    }
}
