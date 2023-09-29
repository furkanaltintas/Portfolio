using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface IIntroduceService
{
    Task<IDataResult<IntroduceGetDto>> GetIntroduceAsync();
    Task<IDataResult<IntroduceGetDto>> GetIntroduceByIdAsync(int id);


    Task<IResult> CreateIntroduceAsync(IntroduceCreateDto introduceCreateDto);
    Task<IResult> UpdateIntroduceAsync(IntroduceGetDto introduceGetDto);
    Task<IResult> DeleteIntroduceAsync(int id);
}