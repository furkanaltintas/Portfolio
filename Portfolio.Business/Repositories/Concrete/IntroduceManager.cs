using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Business.Services.Github;
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

    public async Task<IDataResult<IntroduceGetDto>> GetIntroduceAsync()
    {
        var introduce = await Repository
            .GetRepository<Introduce>()
            .GetAsync();

        if (introduce is null)
            return new ErrorDataResult<IntroduceGetDto>($"");

        introduce.ProjectCount = await GitHubApiCount();
        var introduceGetDto = Mapper.Map<IntroduceGetDto>(introduce);
        return new SuccessDataResult<IntroduceGetDto>(introduceGetDto);
    }

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

    private async Task<short> GitHubApiCount()
    {
        return await _githubApiService.GetRepoCountAsync("furkanaltintas");
    }
}