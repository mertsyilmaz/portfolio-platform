using AutoMapper;
using Blog.Contracts.Categories;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetCategoriesResponse>();
            CreateMap<Category, CreateCategoryResponse>();
            CreateMap<Category, UpdateCategoryResponse>();

            CreateMap<CreateCategoryRequest, Category>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

            CreateMap<UpdateCategoryRequest, Category>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Posts, opt => opt.Ignore());
        }
    }
}
