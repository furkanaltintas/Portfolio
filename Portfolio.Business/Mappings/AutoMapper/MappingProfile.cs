using AutoMapper;
using Portfolio.Business.Extensions;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Mappings.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Özellik verilmediğinde iş yapar
        MapperExtensions.MapperProfileExpression<About>(this, new[]
            {
                // Source, Destination, Reverse
                new MapProfileSourceAndDestination(typeof(About), typeof(AboutGetDto),  true),
                new MapProfileSourceAndDestination(typeof(About), typeof(AboutCreateDto), true),
                new MapProfileSourceAndDestination(typeof(About), typeof(AboutUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(Contact), typeof(ContactGetAllDto), true),

                new MapProfileSourceAndDestination(typeof(Introduce), typeof(IntroduceGetDto), true),
                new MapProfileSourceAndDestination(typeof(IntroduceUpdateDto), typeof(IntroduceGetDto), true),
                new MapProfileSourceAndDestination(typeof(Introduce), typeof(IntroduceCreateDto), true),
                new MapProfileSourceAndDestination(typeof(Introduce), typeof(IntroduceUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(Specialization), typeof(SpecializationGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(Specialization), typeof(SpecializationCreateDto), true),
                new MapProfileSourceAndDestination(typeof(Specialization), typeof(SpecializationUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(Skill), typeof(SkillGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(Skill), typeof(SkillGetDto), true),
                new MapProfileSourceAndDestination(typeof(Skill), typeof(SkillCreateDto), true),
                new MapProfileSourceAndDestination(typeof(Skill), typeof(SkillUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(SocialMedia), typeof(SocialMediaGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(SocialMedia), typeof(SocialMediaCreateDto), true),
                new MapProfileSourceAndDestination(typeof(SocialMedia), typeof(SocialMediaUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(Testimonial), typeof(TestimonialGetAllDto), true),

                new MapProfileSourceAndDestination(typeof(Menu), typeof(MenuGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(MenuGetAllDto), typeof(MenuUpdateDto), true),
                new MapProfileSourceAndDestination(typeof(Menu), typeof(MenuGetDto), true),
                new MapProfileSourceAndDestination(typeof(Menu), typeof(MenuCreateDto), true),
                new MapProfileSourceAndDestination(typeof(Menu), typeof(MenuUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(Resume), typeof(ResumeGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(Resume), typeof(ResumeGetDto), true),
                new MapProfileSourceAndDestination(typeof(Resume), typeof(ResumeCreateDto), true),
                new MapProfileSourceAndDestination(typeof(Resume), typeof(ResumeUpdateDto), true),

                new MapProfileSourceAndDestination(typeof(MenuHeader), typeof(MenuHeaderGetAllDto), true),
                new MapProfileSourceAndDestination(typeof(MenuHeader), typeof(MenuHeaderGetDto), true),

            });


        // CreateMap<About, AboutGetDto>().ReverseMap();
        // CreateMap<About, AboutCreateDto>().ReverseMap();
        // CreateMap<About, AboutUpdateDto>().ReverseMap();
    }
}