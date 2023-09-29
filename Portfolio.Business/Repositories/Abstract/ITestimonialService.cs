using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface ITestimonialService
{
    Task<IDataResult<List<TestimonialGetAllDto>>> GetAllTestimonialAsync();
    Task<IDataResult<List<TestimonialGetAllDto>>> GetAllActiveTestimonialAsync();

    Task<IResult> DeleteTestimonialAsync(int id);
}