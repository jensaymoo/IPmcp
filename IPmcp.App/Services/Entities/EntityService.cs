using IPmcp.App.Exceptions;
using IPmcp.App.Services.Entities.Models;
using IPmcp.Database;
using IPmcp.Database.Extensions;
using LinqToDB;

namespace IPmcp.App.Services.Entities;

public class EntityService(AppDataConnection db) : IEntityService
{
    public async Task<IEnumerable<EntityShortModel>> ListEntitiesAsync(ListEntityFilter filter, CancellationToken ct)
    {
        try
        {
            var entities = db.Entities.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchPattern))
                entities = entities.Where(e =>
                    e.TableName.MatchesText(filter.SearchPattern) ||
                    e.DisplayName.MatchesText(filter.SearchPattern));

            var query = entities
                .Select(e => new EntityShortModel
                {
                    EntityTypeId = e.EntityTypeId,
                    ShortName = e.ShortName,
                    TableName = e.TableName,
                    DisplayName = e.DisplayName,
                    IsActive = e.IsActive == 1,
                    IsAbstract = e.IsAbstract == 1,
                    BaseEntityTypeId = e.BaseEntityTypeId,
                })
                .OrderBy(e => e.EntityTypeId)
                .AsQueryable();

            if (filter.Skip.HasValue)
                query = query.Skip(filter.Skip.Value);

            if (filter.Limit.HasValue)
                query = query.Take(filter.Limit.Value);

            return await query.ToListAsync(ct);
        }
        catch (Exception ex) when (ex is LinqToDBException or System.Data.Common.DbException)
        {
            throw new DatabaseException(ex);
        }
    }
}
