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
     Description(
         "Retrieve detailed information about a single IdeaPlatform entity type by its identifier. " +
         "Use this tool after 'list_entity' to get full details for a specific entity, including all associated fields. " +
         "Returns entity metadata (entityTypeId, shortName, tableName, displayName, isActive, isAbstract, baseEntityTypeId) " +
         "and a complete list of fields with their properties (entityFieldId, shortName, fieldName, displayName, fieldType, sqlTableName, sqlFieldName, isActive, isVisible, isReadOnly, isRequired). " +
         "Requires 'entityTypeId' obtained from 'list_entity'.")]
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
