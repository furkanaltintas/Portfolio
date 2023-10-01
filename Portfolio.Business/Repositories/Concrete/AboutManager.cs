using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Core.Aspects.Autofac.Caching;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class AboutManager : BaseManager, IAboutService
{
    public AboutManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> CreateAboutAsync(AboutCreateDto aboutCreateDto)
    {
        if (aboutCreateDto is null)
            return new ErrorResult();

        var about = Mapper.Map<About>(aboutCreateDto);
        await Repository.GetRepository<About>().AddAsync(about);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<About>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteAboutAsync(int id)
    {
        var about = await Repository.GetRepository<About>().GetAsync(a => a.Id.Equals(id));

        if (about is null)
            return new ErrorResult($"");

        Repository.GetRepository<About>().Delete(about);
        await Repository.SaveAsync();
        return new SuccessResult(Messages<About>.GenericMessage.TDeleted);
    }

    // Ön yüz ve Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<AboutGetDto>> GetAboutAsync()
    {
        var about = await Repository
            .GetRepository<About>()
            .GetAsync(a => a.IsActive);

        if (about is null)
            return new ErrorDataResult<AboutGetDto>();

        var aboutGetDto = Mapper.Map<AboutGetDto>(about);

        return new SuccessDataResult<AboutGetDto>(aboutGetDto);
    }

    // Admin tarafı için yazıldı
    [CacheAspect]
    public async Task<IDataResult<AboutGetDto>> GetAboutByIdAsync(int id)
    {
        var about = await Repository
            .GetRepository<About>().GetAsync(a => a.Id.Equals(id));

        if (about is null)
            return new ErrorDataResult<AboutGetDto>();

        var aboutGetDto = Mapper.Map<AboutGetDto>(about);

        return new SuccessDataResult<AboutGetDto>(aboutGetDto);
    }

    public async Task<IResult> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto)
    {
        if (aboutUpdateDto == null)
            return new ErrorResult();

        var about = Mapper.Map<About>(aboutUpdateDto);
        await Repository.GetRepository<About>().UpdateAsync(about);
        return new SuccessResult(Messages<About>.GenericMessage.TUpdated);
    }
}