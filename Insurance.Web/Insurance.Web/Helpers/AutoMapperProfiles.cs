using AutoMapper;
using Insurance.Web.Models;

namespace Insurance.Web.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<InsuranceModel, InsuranceNewEditModel>()
                .ForMember(dest => dest.RiskTypeId, opt => opt.MapFrom(src => src.RiskType.Id))
                .ForMember(dest => dest.CoverTypeId, opt => opt.MapFrom(src => src.CoverType.Id))
                .ForMember(dest => dest.LocationId, opt => opt.MapFrom(src => src.Location.Id));
        }
    }
}
