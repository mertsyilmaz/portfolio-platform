using AutoMapper;
using Portfolio.Contracts.Architectures;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class ArchitectureMappingProfile : Profile
    {
        public ArchitectureMappingProfile()
        {
            CreateMap<Architecture, GetArchitecturesResponse>();
            CreateMap<Architecture, GetArchitectureByIdResponse>();
            CreateMap<Architecture, CreateArchitectureResponse>();
            CreateMap<Architecture, UpdateArchitectureResponse>();

            CreateMap<CreateArchitectureRequest, Architecture>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateArchitectureRequest, Architecture>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Projects, opt => opt.Ignore());
        }
    }
}
