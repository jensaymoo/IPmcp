namespace IPmcp.App.Services.Rules.Models;

public class RuleShortModel
{
    public required int RuleId { get; init; }
    public string? ShortName { get; init; }
    public string? DisplayName { get; init; }
    public required RuleType RuleType { get; init; }
    public required RuleEvent Event { get; init; }
    public string? Code { get; init; }
    public required bool IsActive { get; init; }
}
