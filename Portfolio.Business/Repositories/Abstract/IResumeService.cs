using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract
{
    public interface IResumeService
    {
        Task<IDataResult<List<ResumeGetAllDto>>> GetAllActiveResumeAsync();
        Task<IDataResult<List<ResumeGetAllDto>>> GetAllResumeAsync();
        Task<IDataResult<ResumeGetDto>> GetResumeByIdAsync(int id);


        Task<IResult> CreateResumeAsync(ResumeCreateDto resumeCreateDto);
        Task<IResult> UpdateResumeAsync(ResumeUpdateDto resumeUpdateDto);
        Task<IResult> DeleteResumeAsync(int id);
    }
}