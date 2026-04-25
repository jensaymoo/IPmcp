using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class GetField(IFieldService service)
{
    [McpServerTool(Name = "get_field", Title = "Get Field", ReadOnly = true, Idempotent = true, Destructive = false),
     Description("Read a single IP entity field by identifier.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
