using IPmcp.App.Exceptions;
using IPmcp.App.Services.Entities.Models;
using IPmcp.App.Services.Fields.Models;
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

    public async Task<EntityDetailModel?> GetEntityAsync(int entityTypeId, CancellationToken ct)
    {
        try
        {
            var entity = await db.Entities
                .Where(e => e.EntityTypeId == entityTypeId)
                .FirstOrDefaultAsync(ct);

            if (entity is null)
                return null;

            var fieldRows = await db.Fields
                .Where(f => f.EntityTypeId == entityTypeId)
                .OrderBy(f => f.EntityFieldId)
                .ToListAsync(ct);

            var fields = fieldRows.Select(f => new FieldShortModel
            {
                EntityFieldId = f.EntityFieldId,
                EntityTypeId = f.EntityTypeId,
                ShortName = f.ShortName,
                FieldName = f.FieldName,
                DisplayName = f.DisplayName,
                FieldType = Enum.Parse<FieldType>(f.FieldType!, ignoreCase: true),
                SqlTableName = f.SqlTableName,
                SqlFieldName = f.SqlFieldName,
                IsActive = f.IsActive == 1,
                IsVisible = f.IsVisible == 1,
                IsReadOnly = f.IsReadOnly == 1,
                IsRequired = f.IsRequired == 1
            }).ToList();

            return new EntityDetailModel
            {
                EntityTypeId = entity.EntityTypeId,
                ShortName = entity.ShortName,
                TableName = entity.TableName,
                DisplayName = entity.DisplayName,
                IsActive = entity.IsActive == 1,
                IsAbstract = entity.IsAbstract == 1,
                BaseEntityTypeId = entity.BaseEntityTypeId,
                Fields = fields
            };
        }
        catch (Exception ex) when (ex is LinqToDBException or System.Data.Common.DbException)
        {
            throw new DatabaseException(ex);
        }
    }
}
