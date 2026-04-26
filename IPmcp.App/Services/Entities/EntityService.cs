using IPmcp.App.Extensions;
using IPmcp.App.Services.Entities.Models;
using IPmcp.Database;
using IPmcp.Database.Extensions;
using LinqToDB;

namespace IPmcp.App.Services.Entities;

public class EntityService(AppDataConnection db) : IEntityService
{
    public Task<IEnumerable<EntityShortModel>> ListEntitiesAsync(ListEntityFilter filter, CancellationToken ct) =>
        ServiceHelper.ExecuteAsync(async () =>
        {
            var entities = db.Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchPattern))
                entities = entities.Where(e =>
                    e.TableName.MatchesText(filter.SearchPattern) ||
                    e.DisplayName.MatchesText(filter.SearchPattern));

            var rows = await entities
                .OrderBy(e => e.EntityTypeId)
                .ApplyPagination(filter.Skip, filter.Limit)
                .ToListAsync(ct);

            IEnumerable<EntityShortModel> result = rows.Select(e => new EntityShortModel
            {
                EntityTypeId = e.EntityTypeId,
                ShortName = e.ShortName,
                TableName = e.TableName,
                DisplayName = e.DisplayName,
                IsActive = e.IsActive == 1,
                IsAbstract = e.IsAbstract == 1,
                BaseEntityTypeId = e.BaseEntityTypeId,
            }).ToList();
            return result;
        });

    public Task<EntityDetailModel?> GetEntityAsync(int entityTypeId, CancellationToken ct) =>
        ServiceHelper.ExecuteAsync(async () =>
        {
            var entity = await db.Entities
                .Where(e => e.EntityTypeId == entityTypeId)
                .FirstOrDefaultAsync(ct);

            if (entity is null)
                return null;

            return new EntityDetailModel
            {
                EntityTypeId = entity.EntityTypeId,
                ShortName = entity.ShortName,
                TableName = entity.TableName,
                DisplayName = entity.DisplayName,
                IsActive = entity.IsActive == 1,
                IsAbstract = entity.IsAbstract == 1,
                BaseEntityTypeId = entity.BaseEntityTypeId,
            };
        });
}
