using System.ComponentModel;
using IPmcp.App.Exceptions;
using IPmcp.App.Services.Rules;
using IPmcp.App.Services.Rules.Models;
using ModelContextProtocol;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Rule;

[McpServerToolType]
public class ListRule(IRuleService service)
{
    [McpServerTool(Name = "list_rule", Title = "List Rules", ReadOnly = true, Idempotent = true, Destructive = false),
     Description(
         "Retrieve a paginated list of rules for a given IdeaPlatform entity type. " +
         "Each rule contains metadata: ruleId, shortName, displayName, ruleType, event, code, isActive. " +
         "Use this tool to discover rules attached to a specific entity. " +
         "Requires 'entityTypeId' obtained from 'list_entity'. " +
         "Supports pagination via 'limit' and 'skip' parameters. " +
         "Supports full-text search via 'searchPattern' across shortName and displayName using " +
         "operators: words=AND by default, OR for alternatives, -word to exclude, \"phrase\" for exact match " +
         "(e.g. 'validate OR check -draft \"before save\"').")]
    public async Task<IEnumerable<RuleShortModel>> Execute(
        [Description("The ID of the entity type to list rules for.")] int entityTypeId,
        [Description("Maximum number of rules to return.")] int? limit = 50,
        [Description("Number of rules to skip before returning results.")] int? skip = 0,
        [Description("Full-text search filter on shortName and displayName.")] string? searchPattern = null,
        CancellationToken ct = default)
    {
        try
        {
            var result = await service.ListRulesAsync(new ListRuleFilter(entityTypeId, limit, skip, searchPattern), ct);
            return result.Any() ? result : throw new McpException("No rules found.");
        }
        catch (DatabaseException ex)
        {
            throw new McpException(ex.Message, ex);
        }
    }
}
