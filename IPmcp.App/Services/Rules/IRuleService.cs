using IPmcp.App.Services.Rules.Models;

namespace IPmcp.App.Services.Rules;

public interface IRuleService
{
    Task<IEnumerable<RuleShortModel>> ListRulesAsync(ListRuleFilter filter, CancellationToken ct);
}
