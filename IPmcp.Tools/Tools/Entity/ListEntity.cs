using System.ComponentModel;
using IPmcp.App.Services.Entities;
using IPmcp.App.Services.Entities.Models;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public static class ListEntity
{
    [McpServerTool(Name = "list_entity", ReadOnly = true, Idempotent = true), Description("List all IP entity types.")]
    public static IEnumerable<EntityModel> Execute(IEntityService service, ListEntityFilter filter)
        => service.ListEntities(filter);
}
