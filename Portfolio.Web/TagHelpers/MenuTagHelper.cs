using Microsoft.AspNetCore.Razor.TagHelpers;
using Portfolio.Core.Entities.Enums;
using Portfolio.Entities.DTOs;
using System.Text;

namespace Portfolio.Web.TagHelpers
{
    [HtmlTargetElement("my-menu")]
    public class MenuTagHelper : TagHelper
    {
        [HtmlAttributeName("menu-value")]
        public MenuGetAllDto MenuGetAllDto { get; set; } = null!;

        [HtmlAttributeName("menu-type")]
        public MenuTypeEnum MenuType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new();

            object? value = MenuType switch
            {
                MenuTypeEnum.SideBarMenu => stringBuilder.Append($@"<i class='{MenuGetAllDto.IconName.ToLower()}'></i> <span>{MenuGetAllDto.Header}</span>"),
                MenuTypeEnum.SmallMenu => stringBuilder.Append($@"<span>{MenuGetAllDto.Header}</span> <i class='{MenuGetAllDto.IconName}'></i>"),
                _ => null
            };

            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
