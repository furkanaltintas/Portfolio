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
	private readonly IMapper _mapper;
	private readonly IRepository _repository;
	private readonly IGithubApiService _githubApiService;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;

	public Service(
		IServiceProvider serviceProvider,
		IMapper mapper,
		IRepository repository,
		IGithubApiService githubApiService,
		UserManager<User> userManager,
		SignInManager<User> signInManager)
	{
		_serviceProvider = serviceProvider;
		_mapper = mapper;
		_repository = repository;
		_githubApiService = githubApiService;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	private T GetService<T>(T service) where T : class
	{
		return _serviceProvider.GetService<T>() ?? service;
	}

	public IAboutService AboutService => GetService(new AboutManager(_repository, _mapper));
	public IContactService ContactService => GetService(new ContactManager(_repository, _mapper));
	public IIntroduceService IntroduceService => GetService(new IntroduceManager(_repository, _mapper, _githubApiService));
	public IMenuService MenuService => GetService(new MenuManager(_repository, _mapper));
	public IResumeService ResumeService => GetService(new ResumeManager(_repository, _mapper));
	public ISkillService SkillService => GetService(new SkillManager(_repository, _mapper));
	public ISocialMediaService SocialMediaService => GetService(new SocialMediaManager(_repository, _mapper));
	public ISpecializationService SpecializationService => GetService(new SpecializationManager(_repository, _mapper));
	public ITestimonialService TestimonialService => GetService(new TestimonialManager(_repository, _mapper));
	public IUserService UserService => GetService(new UserManager(_userManager, _signInManager, _mapper));
}