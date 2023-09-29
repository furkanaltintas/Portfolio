using Portfolio.Core.Utilities.Data.Html;
using Portfolio.Web.Helpers;
using System.Text;

namespace Portfolio.Web.Generators;

public static class HtmlGenericTable
{
    public static string HtmlTable<T>(List<T> data, object entity, string tableColor, TableData? tableData)
    {
        List<string> colors = new() { "primary", "secondary", "success", "danger", "warning", "info", "light", "dark" };

        StringBuilder stringBuilder = new();
        stringBuilder.Append($@"
    <div class=""row mt-3"">
        <div class=""col-lg-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <h5 class=""card-title"">{DtoNameRemoveHelper.DtoNameRemove(entity.GetType().Name)} Table</h5>
                    <div class=""table-responsive"">");

        string tableColorClass = !string.IsNullOrEmpty(tableColor) ? $"table-{tableColor}" : "";
        stringBuilder.Append($"<table class='table {tableColorClass} table-hover table-striped'>");

        // Tablo başlıklarını ekleme
        stringBuilder.Append("<tr>");
        foreach (var propertyInfo in entity.GetType().GetProperties())
            stringBuilder.Append($"<th>{propertyInfo.Name}</th>");

        if (tableData is not null)
            stringBuilder.Append("<th>Action</th>");

        stringBuilder.Append("</tr>");

        string id = string.Empty;
        foreach (var item in data) // Verileri tabloya ekleme
        {
            stringBuilder.Append("<tr>");
            foreach (var propertyInfo in entity.GetType().GetProperties()) // Propları tek tek dönüyoruz
            {
                var value = propertyInfo.GetValue(item);
                stringBuilder.Append($"<td>{value}</td>");
                id = propertyInfo.Name.Equals("Id") ? value!.ToString()! : id;
            }

            if (tableData is not null)
            {
                stringBuilder.Append("<td>");
                for (int i = 0; i < tableData.Button!.Count; i++)
                    stringBuilder.AppendLine($@"<a class='btn btn-{colors[i]} btn-sm' href='{tableData.Button[i].Link}/{id}'>{tableData.Button[i].Name}</a>");
                stringBuilder.Append("</td>");
            }

            stringBuilder.Append("</tr>");
        }

        stringBuilder.Append("</table>");
        stringBuilder.Append($@"
                    </div>
                </div>
            </div>
        </div>
    </div>");

        return stringBuilder.ToString();
    }
}