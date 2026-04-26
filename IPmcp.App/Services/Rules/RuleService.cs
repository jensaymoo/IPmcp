using IPmcp.App.Extensions;
using IPmcp.App.Services.Rules.Models;
using IPmcp.Database;
using IPmcp.Database.Extensions;
using LinqToDB;

namespace IPmcp.App.Services.Rules;

public class RuleService(AppDataConnection db) : IRuleService
{
    public Task<IEnumerable<RuleShortModel>> ListRulesAsync(ListRuleFilter filter, CancellationToken ct) =>
        ServiceHelper.ExecuteAsync(async () =>
        {
            var joined = db.EntityTypeRules
                .Where(etr => etr.EntityTypeId == filter.EntityTypeId)
                .Join(db.Rules, etr => etr.RuleId, r => r.RuleId, (etr, r) => new { etr, r });

            if (!string.IsNullOrWhiteSpace(filter.SearchPattern))
                joined = joined.Where(x =>
                    x.r.ShortName.MatchesText(filter.SearchPattern) ||
                    x.r.DisplayName.MatchesText(filter.SearchPattern));

            if (!string.IsNullOrWhiteSpace(filter.CodePattern))
                joined = joined.Where(x => x.r.GoScript.MatchesText(filter.CodePattern));

            var rows = await joined
                .OrderBy(x => x.etr.SortOrder)
                .ThenBy(x => x.r.RuleId)
                .ApplyPagination(filter.Skip, filter.Limit)
                .ToListAsync(ct);

            IEnumerable<RuleShortModel> result = rows.Select(x => new RuleShortModel
            {
                RuleId = x.r.RuleId,
                ShortName = x.r.ShortName,
                DisplayName = x.r.DisplayName,
                RuleType = x.r.IsUi switch { 1 => RuleType.JavaScript, 0 => RuleType.Java, _ => RuleType.Unknown },
                Event = x.etr.EventId.HasValue ? (RuleEvent)x.etr.EventId.Value : RuleEvent.Unknown,
                Code = x.r.GoScript,
                IsActive = x.r.IsActive == 1
            }).ToList();
            return result;
        });
}
