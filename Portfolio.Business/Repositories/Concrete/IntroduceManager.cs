using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Business.Services.Github;
using Portfolio.Core.Aspects.Autofac.Caching;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class IntroduceManager : BaseManager, IIntroduceService
{
    private readonly IGithubApiService _githubApiService;
    public IntroduceManager(IRepository repository, IMapper mapper, IGithubApiService githubApiService) : base(repository, mapper)
    {
        _githubApiService = githubApiService;
    }

    [CacheRemoveAspect("IIntroduceService.Get")]
    public async Task<IResult> CreateIntroduceAsync(IntroduceCreateDto introduceCreateDto)
    {
        if (introduceCreateDto is null)
            return new ErrorResult();

        var introduce = Mapper.Map<Introduce>(introduceCreateDto);
        await Repository.GetRepository<Introduce>().AddAsync(introduce);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Introduce>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteIntroduceAsync(int id)
    {
        var introduce = await Repository
            .GetRepository<Introduce>()
            .GetAsync(i => i.Id.Equals(id));

        if (introduce is null)
            return new ErrorResult($"");

        Repository.GetRepository<Introduce>().Delete(introduce);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Introduce>.GenericMessage.TDeleted);
    }

    // Ön yüz ve Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<IntroduceGetDto>> GetIntroduceAsync()
    {
        var introduce = await Repository
            .GetRepository<Introduce>()
            .GetAsync();

        if (introduce is null)
            return new ErrorDataResult<IntroduceGetDto>($"");

        var introduceGetDto = Mapper.Map<IntroduceGetDto>(introduce);
        return new SuccessDataResult<IntroduceGetDto>(introduceGetDto);
    }

    [CacheAspect]
    public async Task<IDataResult<IntroduceGetDto>> GetIntroduceByIdAsync(int id)
    {
        var introduce = await Repository
            .GetRepository<Introduce>()
            .GetAsync(i => i.Id.Equals(id));

        introduce.ProjectCount = await GitHubApiCount();
        if (introduce is null)
            return new ErrorDataResult<IntroduceGetDto>($"");

        var introduceGetDto = Mapper.Map<IntroduceGetDto>(introduce);
        return new SuccessDataResult<IntroduceGetDto>(introduceGetDto);
    }

    public async Task<IResult> UpdateIntroduceAsync(IntroduceGetDto introduceGetDto)
    {
        if (introduceGetDto == null)
            return new ErrorResult();

        var introduce = Mapper.Map<Introduce>(introduceGetDto);
        introduce.ProjectCount = await GitHubApiCount();

        await Repository.GetRepository<Introduce>().UpdateAsync(introduce);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<Introduce>.GenericMessage.TUpdated);
    }


    // GitHub Repo Çekme Sistemi
    [CacheAspect(120)]
    public async Task<short> GitHubApiCount()
    {
        return await _githubApiService.GetRepoCountAsync("furkanaltintas");
    }
}