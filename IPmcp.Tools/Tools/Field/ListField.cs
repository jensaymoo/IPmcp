using System.ComponentModel;
using IPmcp.App.Exceptions;
using IPmcp.App.Services.Fields;
using IPmcp.App.Services.Fields.Models;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Field;

[McpServerToolType]
public class ListField(IFieldService service)
{
    [McpServerTool(Name = "list_field", Title = "List Fields", ReadOnly = true, Idempotent = true, Destructive = false),
     Description(
         "Retrieve a paginated list of fields for a given IdeaPlatform entity type (system table). " +
         "Each field represents a column in the entity's table and contains metadata: " +
         "entityFieldId, entityTypeId, shortName, fieldName, displayName, fieldType, sqlTableName, sqlFieldName, isActive, isVisible, isReadOnly, isRequired, workspaceId. " +
         "Use this tool to discover available fields for a specific entity. " +
         "Requires 'entityTypeId' to filter fields by entity. " +
         "Supports pagination via 'limit' and 'skip' parameters.")]
    public async Task<IEnumerable<FieldShortModel>> Execute(
        [Description("The ID of the entity type to list fields for.")] int entityTypeId,
        [Description("Maximum number of fields to return.")] int? limit = 50,
        [Description("Number of fields to skip before returning results.")] int? skip = 0,
        CancellationToken ct = default)
    {
        try
        {
            var result = await service.ListFieldsAsync(new ListFieldFilter(entityTypeId, limit, skip), ct);
            return result.Any() ? result : throw new McpException("No fields found.");
        }
        catch (DatabaseException ex)
        {
            throw new McpException(ex.Message, ex);
        }
    }
}
