using IPmcp.App.Exceptions;
using IPmcp.App.Services.Fields.Models;
using IPmcp.Database;
using LinqToDB;

namespace IPmcp.App.Services.Fields;

public class FieldService(AppDataConnection db) : IFieldService
{
    public async Task<IEnumerable<FieldShortModel>> ListFieldsAsync(ListFieldFilter filter, CancellationToken ct)
    {
        try
        {
            var query = db.Fields
                .Where(f => f.EntityTypeId == filter.EntityTypeId)
                .OrderBy(f => f.EntityFieldId)
                .AsQueryable();

            if (filter.Skip.HasValue)
                query = query.Skip(filter.Skip.Value);

            if (filter.Limit.HasValue)
                query = query.Take(filter.Limit.Value);

            var rows = await query.ToListAsync(ct);

            return rows.Select(f => new FieldShortModel
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
            });
        }
        catch (Exception ex) when (ex is LinqToDBException or System.Data.Common.DbException)
        {
            throw new DatabaseException(ex);
        }
        catch (Exception ex)
        {
            throw new DatabaseException(ex.Message, ex);
        }
    }
}
