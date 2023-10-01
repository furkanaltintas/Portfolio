using Microsoft.AspNetCore.Identity;
using Portfolio.Entities.Concrete;

namespace Portfolio.Web.Validations;

public class PasswordValidator : IPasswordValidator<User>
{
    public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string? password)
    {
        var errors = new List<IdentityError>();
        if (password!.ToLower().Contains(user.UserName!.ToLower())) // Eğer ki içinde böyle bir data var ise
        {
            errors.Add(new() { Code = "PasswordContainUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
        }

        if (password!.ToLower().Contains(user.Email!.ToLower()))
        {
            errors.Add(new() { Code = "PasswordContainEmail", Description = "Şifre alanı e-posta adresi içeremez" });
        }

        if (errors.Any()) // Eğer herhangi bir if içerisine girmişse, errors içerisinde hata var ise
        {
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        return Task.FromResult(IdentityResult.Success);
    }
}