using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Web.TagHelpers
{
    [HtmlTargetElement("custom-button")]
    public class CustomButtonTagHelper : TagHelper
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// Sadece yolu yazın. Örnek: /admin/menu
        /// </summary>
        public string Href { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string buttonText = Status ? "UnDelete" : "Delete";

            var htmlContent = $@"
                    <a href='{Href}/{(Status ? "undelete" : "delete")}/{Id}' class='btn btn-sm btn-danger'>{buttonText}</a>";

            output.Content.SetHtmlContent(htmlContent);
        }
    }
}
