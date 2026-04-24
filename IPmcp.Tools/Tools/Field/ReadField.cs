using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class ReadField(IFieldService service)
{
    [McpServerTool(Name = "read_field"), Description("Read a single IP entity field by identifier.")]
    public string Execute() => throw new NotImplementedException();
}
