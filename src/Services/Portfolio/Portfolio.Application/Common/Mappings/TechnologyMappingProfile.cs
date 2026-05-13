using AutoMapper;
using Portfolio.Contracts.Technologies;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class TechnologyMappingProfile : Profile
    {
        public TechnologyMappingProfile()
        {
            CreateMap<Technology, GetTechnologiesResponse>();
            CreateMap<Technology, GetTechnologyByIdResponse>();
            CreateMap<Technology, CreateTechnologyResponse>();
            CreateMap<Technology, UpdateTechnologyResponse>();

            CreateMap<CreateTechnologyRequest, Technology>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateTechnologyRequest, Technology>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Projects, opt => opt.Ignore());
        }
    }
}
