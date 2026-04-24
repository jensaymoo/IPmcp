using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class ListField(IFieldService service)
{
    [McpServerTool(Name = "list_field"), Description("List all IP entity fields.")]
    public string Execute() => throw new NotImplementedException();
}
