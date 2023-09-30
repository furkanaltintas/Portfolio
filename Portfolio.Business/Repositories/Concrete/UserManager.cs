using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.Concrete.Error;
using Portfolio.Core.Utilities.Results.Concrete.Success;
using Portfolio.Entities.Concrete;
using Portfolio.Entities.DTOs;

namespace Portfolio.Business.Repositories.Concrete
{
    public class UserManager : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

		public UserManager(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
			_signInManager = signInManager;
		}

		public async Task<IDataResult<UserGetDto>> GetUserAsync()
        {
            var user = await _userManager.Users.FirstOrDefaultAsync();

            if(user is null)
                return new ErrorDataResult<UserGetDto>();

            var userGetDto = _mapper.Map<UserGetDto>(user);
            return new SuccessDataResult<UserGetDto>(userGetDto);
        }

		public async Task<IResult> UserLoginAsync(UserLoginDto userLoginDto)
		{
            var hasUser = await _userManager.FindByNameAsync(userLoginDto.Username); // Böyle bir kullanıcı var mı ?

            if (hasUser is null)
                return new ErrorResult("Email veya şifre yanlış");

            var signInResult = await _signInManager.PasswordSignInAsync(
                hasUser,
                userLoginDto.Password,
                userLoginDto.RememberMe,
                true); // Kullanıcı 3 kere yanlış giriş yaptığında sistemi belli bir süre kilitleme yarıyor.

            if (signInResult.IsLockedOut) // Kilitleme mekanizması devreye girdi ise
                return new ErrorResult("3 dakika boyunca giriş yapamazsınız");

            if(!signInResult.Succeeded) // İşlem başarısız ise
            {
                var count = await _userManager.GetAccessFailedCountAsync(hasUser);
                // Hatalı giriş sayısını tutar

                return new ErrorResult($@"
                        Email veya şifre yanlış.
                        Başarısız giriş sayısı {count}");
            }

            return new SuccessResult();
		}

        public async Task UserLogoutAsync()
        {
			await _signInManager.SignOutAsync();
		}
	}
}
