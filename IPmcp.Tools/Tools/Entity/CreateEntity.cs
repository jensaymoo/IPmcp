using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public static class CreateEntity
{
    [McpServerTool(Name = "create_entity"), Description("Create a new IP entity type.")]
    public static string Execute(IEntityService service) => throw new NotImplementedException();
}
