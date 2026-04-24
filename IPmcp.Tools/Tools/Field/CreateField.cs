using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public static class CreateField
{
    [McpServerTool(Name = "create_field"), Description("Create a new IP entity field.")]
    public static string Execute(IFieldService service) => throw new NotImplementedException();
}
