using System.ComponentModel;
using IPmcp.App.Services.Fields;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class UpdateField(IFieldService service)
{
    [McpServerTool(Name = "update_field", Title = "Update Field", ReadOnly = false, Idempotent = false, Destructive = true),
     Description("Update an existing IP entity field.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
