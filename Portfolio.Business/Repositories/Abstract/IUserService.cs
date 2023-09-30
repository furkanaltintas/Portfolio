using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Abstract;

public interface IUserService
{
	Task<IDataResult<UserGetDto>> GetUserAsync();

	Task<IResult> UserLoginAsync(UserLoginDto userLoginDto);
	Task UserLogoutAsync();
}