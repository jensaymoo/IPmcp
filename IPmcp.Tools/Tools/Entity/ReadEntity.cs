using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public static class ReadEntity
{
    [McpServerTool(Name = "read_entity"), Description("Read a single IP entity type by identifier.")]
    public static string Execute(IEntityService service) => throw new NotImplementedException();
}
