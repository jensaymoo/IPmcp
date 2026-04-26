using System.ComponentModel;
using IPmcp.App.Exceptions;
using IPmcp.App.Services.Entities;
using IPmcp.App.Services.Entities.Models;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class GetEntity(IEntityService service)
{
    [McpServerTool(Name = "get_entity", Title = "Get Entity", ReadOnly = true, Idempotent = true, Destructive = false),
     Description("Read a single IP entity type by identifier, including all associated fields.")]
    public async Task<EntityDetailModel> Execute(
        [Description("The unique identifier of the entity type to retrieve.")] int entityTypeId,
        CancellationToken ct = default)
    {
        try
        {
            return await service.GetEntityAsync(entityTypeId, ct)
                   ?? throw new McpException("Entity not found.");
        }
        catch (DatabaseException ex)
        {
            throw new McpException(ex.Message, ex);
        }
    }
}
