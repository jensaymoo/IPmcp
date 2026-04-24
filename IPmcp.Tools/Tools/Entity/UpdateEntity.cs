using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class UpdateEntity(IEntityService service)
{
    [McpServerTool(Name = "update_entity"), Description("Update an existing IP entity type.")]
    public string Execute() => throw new NotImplementedException();
}
