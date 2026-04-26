namespace IPmcp.App.Services.Fields.Models;

public class FieldShortModel
{
    public required int EntityFieldId { get; init; }
    public required int EntityTypeId { get; init; }
    public required string ShortName { get; init; }
    public required string FieldName { get; init; }
    public string? DisplayName { get; init; }
    public required FieldType FieldType { get; init; }
    public string? SqlTableName { get; init; }
    public string? SqlFieldName { get; init; }
    public required bool IsActive { get; init; }
    public required bool IsVisible { get; init; }
    public required bool IsReadOnly { get; init; }
    public required bool IsRequired { get; init; }
}
