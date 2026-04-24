using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class UpdateField(IFieldService service)
{
    [McpServerTool(Name = "update_field"), Description("Update an existing IP entity field.")]
    public string Execute() => throw new NotImplementedException();
}
