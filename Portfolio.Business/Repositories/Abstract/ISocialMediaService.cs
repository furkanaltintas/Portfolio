using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface ISocialMediaService
{
    Task<IDataResult<List<SocialMediaGetAllDto>>> GetAllSocialMediaAsync();

    Task<IResult> CreateSocialMediaAsync(SocialMediaCreateDto socialMediaCreateDto);
    Task<IResult> UpdateSocialMediaAsync(SocialMediaUpdateDto socialMediaUpdateDto);
    Task<IResult> DeleteSocialMediaAsync(int id);
}