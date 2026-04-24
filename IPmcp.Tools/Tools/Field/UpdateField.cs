using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public static class UpdateField
{
    [McpServerTool(Name = "update_field"), Description("Update an existing IP entity field.")]
    public static string Execute(IFieldService service) => throw new NotImplementedException();
}
