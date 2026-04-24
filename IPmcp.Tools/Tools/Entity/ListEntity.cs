using System.ComponentModel;
using IPmcp.App.Services.Entities;
using IPmcp.App.Services.Entities.Models;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class ListEntity(IEntityService service)
{
    [McpServerTool(Name = "list_entity", ReadOnly = true, Idempotent = true), Description("List all IP entity types.")]
    public IEnumerable<EntityModel> Execute(ListEntityFilter filter)
        => service.ListEntities(filter);
}
