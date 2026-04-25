using IPmcp.App.Services.Entities.Models;

namespace IPmcp.App.Services.Entities;

public interface IEntityService
{
    Task<IEnumerable<EntityShortModel>> ListEntitiesAsync(ListEntityFilter filter, CancellationToken ct);
}
