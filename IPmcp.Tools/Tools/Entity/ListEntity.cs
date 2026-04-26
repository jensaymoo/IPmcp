using System.ComponentModel;
using IPmcp.App.Exceptions;
using IPmcp.App.Services.Entities;
using IPmcp.App.Services.Entities.Models;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class ListEntity(IEntityService service)
{
    [McpServerTool(Name = "list_entity", Title = "List Entities", ReadOnly = true, Idempotent = true, Destructive = false),
     Description(
         "Retrieve a paginated list of IdeaPlatform entity types (system tables). " +
         "Each entity represents a system table and contains metadata: " +
         "entityTypeId, shortName, tableName, displayName, isActive, isAbstract, baseEntityTypeId, workspaceId. " +
         "Use this tool to discover available entities before querying their fields or performing CRUD operations. " +
         "Supports pagination via 'limit' and 'skip' parameters. " +
         "Supports full-text search via 'searchPattern' across tableName and displayName using " +
         "operators: words=AND by default, OR for alternatives, -word to exclude, \"phrase\" for exact match " +
         "(e.g. 'invoice OR order -draft \"line item\"').")]
    public async Task<IEnumerable<EntityShortModel>> Execute(
        [Description("Maximum number of entities to return.")] int? limit = 100,
        [Description("Number of entities to skip before returning results.")] int? skip = 0,
        [Description("Full-text search filter on tableName and displayName.")] string? searchPattern = null,
        CancellationToken ct = default)
    {
        try
        {
            var result = await service.ListEntitiesAsync(new ListEntityFilter(limit, skip, searchPattern), ct);
            return result.Any() ? result : throw new McpException("No entities found.");
        }
        catch (DatabaseException ex)
        {
            throw new McpException(ex.Message, ex);
        }
    }
}
