namespace IPmcp.App.Services.Rules.Models;

public record ListRuleFilter(int EntityTypeId, int? Limit, int? Skip, string? SearchPattern = null, string? CodePattern = null);
