using IPmcp.App.Services.Fields.Models;

namespace IPmcp.App.Services.Fields;

public interface IFieldService
{
    Task<IEnumerable<FieldShortModel>> ListFieldsAsync(ListFieldFilter filter, CancellationToken ct);
}
