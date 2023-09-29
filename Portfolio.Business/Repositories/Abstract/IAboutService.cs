using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract
{
    public interface IAboutService
    {
        Task<IDataResult<AboutGetDto>> GetAboutAsync();
        Task<IDataResult<AboutGetDto>> GetAboutByIdAsync(int id);

        Task<IResult> CreateAboutAsync(AboutCreateDto aboutCreateDto);
        Task<IResult> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto);
        Task<IResult> DeleteAboutAsync(int id);
    }
}