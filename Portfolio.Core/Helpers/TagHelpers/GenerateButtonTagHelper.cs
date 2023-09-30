using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Portfolio.Core.Helpers.TagHelpers;

[HtmlTargetElement("my-button")]
public class GenerateButtonTagHelper : TagHelper
{
    [HtmlAttributeName("button-link")]
    public string Link { get; set; } = null!;

    [HtmlAttributeName("button-color")]
    public string Color { get; set; } = null!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.SetAttribute("style", "width:100%;");
        output.Attributes.SetAttribute("href", Link);
        output.Attributes.SetAttribute("class", $"btn {Color} mt-1");
    }
}