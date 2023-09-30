using Microsoft.AspNetCore.Razor.TagHelpers;
using Portfolio.Business.Repositories.Abstract;
using Portfolio.Core.Helpers;
using Portfolio.Web.Helpers;
using System.Text;

namespace Portfolio.Web.TagHelpers
{
    [HtmlTargetElement("my-icon-name")]
    public class IconNameTagHelper : TagHelper
    {
        private readonly IService _service;

        public IconNameTagHelper(IService service)
        {
            _service = service;
        }

        [HtmlAttributeName("entity-name")]
        public string entityName { get; set; } = null!;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var newEntityName = DtoNameRemoveHelper.DtoNameRemove(entityName);

            var result = await _service.MenuService.GetMenuAsync(newEntityName);

            StringBuilder stringBuilder = new();

            if (result.IsSuccess)
            {
                stringBuilder.Append($@"
                    <h4 class='subtitle scroll-animation' data-animation='fade_from_bottom'>
                        <i class='{result.Data.IconName}'></i> {result.Data.Slug}
                    </h4>
                ");
            }
            else
            {
                stringBuilder.Append($@"
                    <h4 class='subtitle scroll-animation' data-animation='fade_from_bottom'>
                        <i class='lar la-hata'></i> Hata İsim Atanamadı
                    </h4>
                ");
            }


            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}