using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public static class ListEntity
{
    [McpServerTool(Name = "list_entity"), Description("List all IP entity types.")]
    public static string Execute(IEntityService service) => throw new NotImplementedException();
}
