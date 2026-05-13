using AutoMapper;
using Portfolio.Contracts.Categories;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoriesResponse>();
            CreateMap<Category, GetCategoryByIdResponse>();
            CreateMap<Category, CreateCategoryResponse>();
            CreateMap<Category, UpdateCategoryResponse>();

            CreateMap<CreateCategoryRequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateCategoryRequest, Category>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Projects, opt => opt.Ignore());
        }
    }
}
