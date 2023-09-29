using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface ISpecializationService
{
    Task<IDataResult<List<SpecializationGetAllDto>>> GetAllSpecializationAsync();
    Task<IDataResult<List<SpecializationGetAllDto>>> GetAllActiveSpecializationAsync();

    Task<IResult> CreateSpecializationAsync(SpecializationCreateDto serviceCreateDto);
    Task<IResult> UpdateSpecializationAsync(SpecializationUpdateDto serviceUpdateDto);
    Task<IResult> DeleteSpecializationAsync(int id);
}