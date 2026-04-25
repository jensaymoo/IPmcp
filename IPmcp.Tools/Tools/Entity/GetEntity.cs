using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class GetEntity(IEntityService service)
{
    [McpServerTool(Name = "get_entity", Title = "Get Entity", ReadOnly = true, Idempotent = true, Destructive = false),
     Description("Read a single IP entity type by identifier.")]
    public Task<string> Execute(CancellationToken ct = default) => throw new NotImplementedException();
}
