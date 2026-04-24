using IPmcp.App.Services.Entities.Models;

namespace IPmcp.App.Services.Entities;

public interface IEntityService
{
    IEnumerable<EntityModel> ListEntities(ListEntityFilter filter);
}
