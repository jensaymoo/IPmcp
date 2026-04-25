using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class AddField(IFieldService service)
{
    [McpServerTool(Name = "add_field", Title = "Add Field", ReadOnly = false, Idempotent = false, Destructive = false),
     Description("Create a new IP entity field.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
