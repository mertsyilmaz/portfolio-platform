using AutoMapper;
using CV.Contracts.Certificates;
using CV.Contracts.Educations;
using CV.Contracts.Experiences;
using CV.Contracts.Hobbies;
using CV.Contracts.Languages;
using CV.Contracts.PersonalInfos;
using CV.Contracts.Skills;
using CV.Contracts.SocialLinks;
using CV.Domain.Entities;

namespace CV.Application.Common.Mappings
{
    public class CvMappingProfile : Profile
    {
        public CvMappingProfile()
        {
            CreateMap<Certificate, CreateCertificateResponse>();
            CreateMap<Certificate, GetCertificatesResponse>();
            CreateMap<Certificate, GetCertificateByIdResponse>();
            CreateMap<Certificate, UpdateCertificateResponse>();
            CreateMap<CreateCertificateRequest, Certificate>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc)));
            CreateMap<UpdateCertificateRequest, Certificate>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IssuedDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.IssuedDate, DateTimeKind.Utc)));

            CreateMap<Education, CreateEducationResponse>();
            CreateMap<Education, GetEducationsResponse>();
            CreateMap<Education, GetEducationByIdResponse>();
            CreateMap<Education, UpdateEducationResponse>();
            CreateMap<CreateEducationRequest, Education>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? (DateTime?)DateTime.SpecifyKind(src.EndDate.Value, DateTimeKind.Utc) : null));
            CreateMap<UpdateEducationRequest, Education>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? (DateTime?)DateTime.SpecifyKind(src.EndDate.Value, DateTimeKind.Utc) : null));

            CreateMap<Experience, CreateExperienceResponse>();
            CreateMap<Experience, GetExperienceResponse>();
            CreateMap<Experience, GetExperienceByIdResponse>();
            CreateMap<Experience, UpdateExperienceResponse>();
            CreateMap<CreateExperienceRequest, Experience>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? (DateTime?)DateTime.SpecifyKind(src.EndDate.Value, DateTimeKind.Utc) : null));
            CreateMap<UpdateExperienceRequest, Experience>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.StartDate, DateTimeKind.Utc)))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate.HasValue ? (DateTime?)DateTime.SpecifyKind(src.EndDate.Value, DateTimeKind.Utc) : null));

            CreateMap<Hobby, CreateHobbyResponse>();
            CreateMap<Hobby, GetHobbiesResponse>();
            CreateMap<Hobby, GetHobbyByIdResponse>();
            CreateMap<Hobby, UpdateHobbyResponse>();
            CreateMap<CreateHobbyRequest, Hobby>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<UpdateHobbyRequest, Hobby>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<Language, CreateLanguageResponse>();
            CreateMap<Language, GetLanguagesResponse>();
            CreateMap<Language, GetLanguageByIdResponse>();
            CreateMap<Language, UpdateLanguageResponse>();
            CreateMap<CreateLanguageRequest, Language>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<UpdateLanguageRequest, Language>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<PersonalInfo, CreatePersonalInfoResponse>();
            CreateMap<PersonalInfo, GetPersonalInfoResponse>();
            CreateMap<PersonalInfo, UpdatePersonalInfoResponse>();
            CreateMap<CreatePersonalInfoRequest, PersonalInfo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<UpdatePersonalInfoRequest, PersonalInfo>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            CreateMap<Skill, CreateSkillResponse>();
            CreateMap<Skill, GetSkillsResponse>();
            CreateMap<Skill, GetSkillByIdResponse>();
            CreateMap<Skill, UpdateSkillResponse>();
            CreateMap<CreateSkillRequest, Skill>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<UpdateSkillRequest, Skill>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<SocialLink, CreateSocialLinkResponse>();
            CreateMap<SocialLink, GetSocialLinksResponse>();
            CreateMap<SocialLink, GetSocialLinkByIdResponse>();
            CreateMap<SocialLink, UpdateSocialLinkResponse>();
            CreateMap<CreateSocialLinkRequest, SocialLink>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
            CreateMap<UpdateSocialLinkRequest, SocialLink>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
