using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public static class DeleteField
{
    [McpServerTool(Name = "delete_field"), Description("Delete an IP entity field by identifier.")]
    public static string Execute(IFieldService service) => throw new NotImplementedException();
}
