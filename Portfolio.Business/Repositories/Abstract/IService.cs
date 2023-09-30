namespace Portfolio.Business.Repositories.Abstract;

public interface IService
{
    IAboutService AboutService { get; }
    IContactService ContactService { get; }
    IIntroduceService IntroduceService { get; }
    IMenuService MenuService { get; }
    IResumeService ResumeService { get; }
    ISpecializationService SpecializationService { get; }
    ISkillService SkillService { get; }
    ISocialMediaService SocialMediaService { get; }
    ITestimonialService TestimonialService { get; }
    IUserService UserService { get; }
}