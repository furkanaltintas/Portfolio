using Microsoft.AspNetCore.Identity;
using Portfolio.Entities.Concrete;

namespace Portfolio.Web.Validations;

public class UserValidator : IUserValidator<User>
{
    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        var errors = new List<IdentityError>();

        var isDigit = int.TryParse(user.UserName![0].ToString(), out _);
        // isDigit true olursa kullanıcı adının ilk karakteri sayısal bir değerdir anlamına gelir.

        if (isDigit)
        {
            errors.Add(new()
            {
                Code = "UserNameContainFirstLetterDigit",
                Description = "Kullanıcı Adının ilk karakteri sayısal bir karakter içeremez"
            });
        }

        if (errors.Any())
        {
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}