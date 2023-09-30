using Microsoft.AspNetCore.Identity;

namespace Portfolio.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateUserName),
                Description = $@"{userName} daha önce başka bir kullanıcı tarafından alınmıştır"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError
            {
                Code = nameof(DuplicateEmail),
                Description = $@"{email} e-posta adresi daha önce sisteme kaydolmuştur"
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $@"Şifre en az 6 karakter olmalıdır"
            };
        }
    }
}