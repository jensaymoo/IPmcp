using IPmcp.App.Extensions;
using IPmcp.App.Services.Fields.Models;
using IPmcp.Database;
using LinqToDB;

namespace IPmcp.App.Services.Fields;

public class FieldService(AppDataConnection db) : IFieldService
{
    public Task<IEnumerable<FieldShortModel>> ListFieldsAsync(ListFieldFilter filter, CancellationToken ct) =>
        ServiceHelper.ExecuteAsync(async () =>
        {
            var rows = await db.Fields
                .Where(f => f.EntityTypeId == filter.EntityTypeId)
                .OrderBy(f => f.EntityFieldId)
                .ApplyPagination(filter.Skip, filter.Limit)
                .ToListAsync(ct);

            IEnumerable<FieldShortModel> result = rows.Select(f => new FieldShortModel
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
            return result;
        });
}
