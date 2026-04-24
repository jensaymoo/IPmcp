using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class DeleteField(IFieldService service)
{
    [McpServerTool(Name = "delete_field"), Description("Delete an IP entity field by identifier.")]
    public string Execute() => throw new NotImplementedException();
}
