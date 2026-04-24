using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public static class ReadField
{
    [McpServerTool(Name = "read_field"), Description("Read a single IP entity field by identifier.")]
    public static string Execute(IFieldService service) => throw new NotImplementedException();
}
