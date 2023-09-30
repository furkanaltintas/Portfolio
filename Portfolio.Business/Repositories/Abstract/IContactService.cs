using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface IContactService
{
    Task<IDataResult<List<ContactGetAllDto>>> GetAllContactAsync();


    Task<IResult> CreateContactAsync(ContactCreateDto contactCreateDto);
    Task<IResult> DeleteContactAsync(int id);


    Task<bool> HasContactAsync();
}