using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class ListField(IFieldService service)
{
    [McpServerTool(Name = "list_field", Title = "List Fields", ReadOnly = true, Idempotent = true, Destructive = false),
     Description("List all IP entity fields.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
