using AutoMapper;
using Blog.Contracts.Comments;
using Blog.Domain.Entities;

namespace Blog.Application.Common.Mappings
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, GetCommentsResponse>();
            CreateMap<Comment, CreateCommentResponse>();
            CreateMap<Comment, UpdateCommentResponse>();

            CreateMap<CreateCommentRequest, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.IsApproved, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<UpdateCommentRequest, Comment>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.PostId, opt => opt.Ignore())
                    .ForMember(dest => dest.AuthorId, opt => opt.Ignore())
                    .ForMember(dest => dest.IsApproved, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                    .ForMember(dest => dest.Post, opt => opt.Ignore());
        }
    }
}
