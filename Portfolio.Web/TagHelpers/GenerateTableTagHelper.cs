using Microsoft.AspNetCore.Razor.TagHelpers;
using Portfolio.Core.Utilities.Data.Html;
using Portfolio.Web.Generators;

namespace Portfolio.Web.TagHelpers;

[HtmlTargetElement("my-table")]
public class GenerateTableTagHelper : TagHelper
{
    [HtmlAttributeName("data")]
    public List<object> Data { get; set; } = null!;

    [HtmlAttributeName("table-color")]
    public string TableColor { get; set; } = null!;

    [HtmlAttributeName("table-button-link")]
    public TableData? TableData { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        object objectType = Data.First();
        //var entity = TableGenerator.Entity(itemTypeName!); // Tablo çekmeye yarıyor

        var table = HtmlGenericTable.HtmlTable(Data, objectType, TableColor, TableData);

        output.Content.SetHtmlContent(table);
        base.Process(context, output);
    }
}