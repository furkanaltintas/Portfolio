using AutoMapper;
using Portfolio.Business.Constants;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Business.Repositories.Concrete.Base;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.DataAccess.Abstract;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete;

public class SocialMediaManager : BaseManager, ISocialMediaService
{
    public SocialMediaManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IResult> CreateSocialMediaAsync(SocialMediaCreateDto socialMediaCreateDto)
    {
        if (socialMediaCreateDto is null)
            return new ErrorResult();

        var socialMedia = Mapper.Map<SocialMedia>(socialMediaCreateDto);
        await Repository.GetRepository<SocialMedia>().AddAsync(socialMedia);
        await Repository.SaveAsync();

        return new SuccessResult(Messages<SocialMedia>.GenericMessage.TAdded);
    }

    public async Task<IResult> DeleteSocialMediaAsync(int id)
    {
        var socialMedia = await Repository.GetRepository<SocialMedia>().GetAsync(a => a.Id == id);

        if (socialMedia is null)
            return new ErrorResult($"");

        Repository.GetRepository<SocialMedia>().Delete(socialMedia);
        return new SuccessResult(Messages<SocialMedia>.GenericMessage.TDeleted);
    }

    public async Task<IDataResult<List<SocialMediaGetAllDto>>> GetAllSocialMediaAsync()
    {
        var socialMedias = await Repository
            .GetRepository<SocialMedia>()
            .GetAllAsync(a => a.IsActive);

        if (socialMedias.Count is 0)
            return new ErrorDataResult<List<SocialMediaGetAllDto>>();

        var socialMediaGetAllDtos = Mapper.Map<List<SocialMediaGetAllDto>>(socialMedias);

        return new SuccessDataResult<List<SocialMediaGetAllDto>>(socialMediaGetAllDtos);
    }

    public async Task<IResult> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto)
    {
        if (socialMediaUpdateDto == null)
            return new ErrorResult();

        var socialMedia = Mapper.Map<SocialMedia>(socialMediaUpdateDto);
        await Repository.GetRepository<SocialMedia>().UpdateAsync(socialMedia);
        return new SuccessResult(Messages<SocialMedia>.GenericMessage.TUpdated);
    }
}
