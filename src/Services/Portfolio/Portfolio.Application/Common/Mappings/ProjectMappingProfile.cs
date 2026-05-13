using AutoMapper;
using Portfolio.Contracts.Projects;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<Project, CreateProjectResponse>();
            CreateMap<Project, UpdateProjectResponse>();
            CreateMap<Project, GetProjectsResponse>();
            CreateMap<Project, GetProjectByIdResponse>();

            CreateMap<CreateProjectRequest, Project>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Technologies, opt => opt.Ignore())
                .ForMember(dest => dest.Architectures, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore());

            CreateMap<UpdateProjectRequest, Project>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.Technologies, opt => opt.Ignore())
                .ForMember(dest => dest.Architectures, opt => opt.Ignore())
                .ForMember(dest => dest.Images, opt => opt.Ignore());
        }
    }
}
