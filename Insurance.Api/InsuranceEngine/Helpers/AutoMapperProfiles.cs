using AutoMapper;
using DataAccess.Models;
using InsuranceEngine.Dtos;

namespace InsuranceEngine.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InsuranceCreationDto, InsurancePolicy>();
            CreateMap<InsurancePolicy, InsuranceReturnDto>();
            CreateMap<UserAddDto, Person>();
            CreateMap<UserAddDto, User>()
              .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<User, UserReturnDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Person.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Person.LastName))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Person.Address))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Person.Country.Name))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Person.Gender.Name));
        }
    }
}
