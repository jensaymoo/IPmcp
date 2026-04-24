using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public static class ListField
{
    [McpServerTool(Name = "list_field"), Description("List all IP entity fields.")]
    public static string Execute(IFieldService service) => throw new NotImplementedException();
}
