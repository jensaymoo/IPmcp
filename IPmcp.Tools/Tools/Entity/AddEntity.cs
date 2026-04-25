using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class AddEntity(IEntityService service)
{
    [McpServerTool(Name = "add_entity", Title = "Add Entity", ReadOnly = false, Idempotent = false, Destructive = false),
     Description("Create a new IP entity type.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
