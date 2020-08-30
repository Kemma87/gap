using AutoMapper;
using DataAccess.Models;
using Insurance.WebApi.Dto;

namespace Insurance.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InsuranceCreationDto, InsurancePolicy>();
            CreateMap<InsurancePolicy, InsuranceReturnDto>();
        }
    }
}
