using IPmcp.App.Services.Entities.Models;
using IPmcp.Database;
using LinqToDB;

namespace IPmcp.App.Services.Entities;

public class EntityService(AppDataConnection db) : IEntityService
{
    public IEnumerable<EntityModel> ListEntities(ListEntityFilter filter)
        => db.Entities
             .Select(e => new EntityModel
             {
                 EntityTypeId = e.EntityTypeId,
                 ShortName = e.ShortName,
                 TableName = e.TableName,
                 DisplayName = e.DisplayName,
                 IsActive = e.IsActive == 1,
                 IsAbstract = e.IsAbstract == 1,
                 BaseEntityTypeId = e.BaseEntityTypeId,
                 WorkspaceId = e.WorkspaceId
             })
             .ToList();
}
