using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public static class DeleteEntity
{
    [McpServerTool(Name = "delete_entity"), Description("Delete an IP entity type by identifier.")]
    public static string Execute(IEntityService service) => throw new NotImplementedException();
}
