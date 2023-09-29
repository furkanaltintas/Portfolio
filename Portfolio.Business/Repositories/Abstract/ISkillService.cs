using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface ISkillService
{
    Task<IDataResult<List<SkillGetAllDto>>> GetAllSkillAsync();
    Task<IDataResult<List<SkillGetAllDto>>> GetAllActiveSkillAsync();
    Task<IDataResult<SkillGetDto>> GetSkillByIdAsync(int id);

    Task<IResult> CreateSkillAsync(SkillCreateDto skillCreateDto);
    Task<IResult> UpdateSkillAsync(SkillUpdateDto skillUpdateDto);
    Task<IResult> DeleteSkillAsync(int id);
}