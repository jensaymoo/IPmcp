using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class DeleteEntity(IEntityService service)
{
    [McpServerTool(Name = "delete_entity"), Description("Delete an IP entity type by identifier.")]
    public string Execute() => throw new NotImplementedException();
}
