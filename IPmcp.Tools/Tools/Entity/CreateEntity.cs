using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class CreateEntity(IEntityService service)
{
    [McpServerTool(Name = "create_entity"), Description("Create a new IP entity type.")]
    public string Execute() => throw new NotImplementedException();
}
