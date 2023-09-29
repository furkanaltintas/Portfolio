using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface IMenuHeaderService
{
    IDataResult<MenuHeaderGetDto> MenuHeaderGetAsync();
}