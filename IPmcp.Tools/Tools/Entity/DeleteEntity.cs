using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class DeleteEntity(IEntityService service)
{
    [McpServerTool(Name = "delete_entity", Title = "Delete Entity", ReadOnly = false, Idempotent = false, Destructive = true),
     Description("Delete an IP entity type by identifier.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
