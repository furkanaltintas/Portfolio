using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Core.Helpers.TagHelpers
{
    public class UserRoleNamesTagHelper : TagHelper
    {
        //public string UserId { get; set; } = null!;

        //private readonly UserManager<AppUser> _userManager;

        //public UserRoleNamesTagHelper(UserManager<AppUser> userManager)
        //{
        //    _userManager = userManager;
        //}

        //public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //var user = await _userManager.FindByIdAsync(UserId);
        //var userRoles = await _userManager.GetRolesAsync(user!);

        //var stringBuilder = new StringBuilder();

        //userRoles.ToList().ForEach(role =>
        //{
        //    stringBuilder.AppendLine(@$"<span class='badge bg-danger'>{role.ToLower()}</span>");
        //});

        //  output.Content.SetHtmlContent(stringBuilder.ToString());
        //}
    }
}