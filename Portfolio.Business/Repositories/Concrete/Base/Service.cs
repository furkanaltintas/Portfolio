using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Services.Github;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;

namespace Portfolio.Business.Repositories.Concrete.Base;

public class Service : IService
{
    private readonly IServiceProvider _serviceProvider;

    public Service(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private T GetService<T>() where T : class
    {
        //return _serviceProvider.GetService<T>() ?? service;
        return _serviceProvider.GetService<T>()!;
    }

    public IAboutService AboutService => GetService<IAboutService>();
    public IContactService ContactService => GetService<IContactService>();
    public IIntroduceService IntroduceService => GetService<IIntroduceService>();
    public IMenuService MenuService => GetService<IMenuService>();
    public IResumeService ResumeService => GetService<IResumeService>();
    public ISkillService SkillService => GetService<ISkillService>();
    public ISocialMediaService SocialMediaService => GetService<ISocialMediaService>();
    public ISpecializationService SpecializationService => GetService<ISpecializationService>();
    public ITestimonialService TestimonialService => GetService<ITestimonialService>();
    public IUserService UserService => GetService<IUserService>();
    // GetService(new UserManager(_userManager, _signInManager, _mapper));
    // GetService<IUserService>() bu iki yöntem de kullanılabilinir
}