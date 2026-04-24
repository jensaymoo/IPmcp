using System.ComponentModel;
using IPmcp.App.Services.Entities;
using ModelContextProtocol.Server;

namespace IPmcp.Tools.Tools.Entity;

[McpServerToolType]
public class ReadEntity(IEntityService service)
{
    [McpServerTool(Name = "read_entity"), Description("Read a single IP entity type by identifier.")]
    public string Execute() => throw new NotImplementedException();
}
