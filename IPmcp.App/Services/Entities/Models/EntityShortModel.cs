namespace IPmcp.App.Services.Entities.Models;

public class EntityShortModel
{
    public required int EntityTypeId { get; init; }
    public required string ShortName { get; init; }
    public required string TableName { get; init; }
    public string? DisplayName { get; init; }
    public required bool IsActive { get; init; }
    public required bool IsAbstract { get; init; }
    public int? BaseEntityTypeId { get; init; }
}
