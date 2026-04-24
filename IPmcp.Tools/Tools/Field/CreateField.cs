using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class CreateField(IFieldService service)
{
    [McpServerTool(Name = "create_field"), Description("Create a new IP entity field.")]
    public string Execute() => throw new NotImplementedException();
}
