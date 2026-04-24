using LinqToDB.Mapping;

namespace IPmcp.Database.Models;

[Table("ipentityfield", Schema = "system")]
public class Field
{
    [PrimaryKey, Column("entityfield_id"), NotNull]
    public int EntityFieldId { get; set; }

    [Column("entitytype_id"), NotNull]
    public int EntityTypeId { get; set; }

    [Column("field_name"), NotNull]
    public string FieldName { get; set; } = null!;

    [Column("field_type"), Nullable]
    public string? FieldType { get; set; }

    [Column("sql_table_name"), Nullable]
    public string? SqlTableName { get; set; }

    [Column("sql_field_name"), Nullable]
    public string? SqlFieldName { get; set; }

    [Column("sql_batch"), Nullable]
    public int? SqlBatch { get; set; }

    [Column("is_active"), Nullable]
    public int? IsActive { get; set; }

    [Column("is_visible"), Nullable]
    public int? IsVisible { get; set; }

    [Column("is_audit_on"), Nullable]
    public int? IsAuditOn { get; set; }

    [Column("unitofmeasure_id"), Nullable]
    public int? UnitOfMeasureId { get; set; }

    [Column("default_value"), Nullable]
    public string? DefaultValue { get; set; }

    [Column("field_format_id"), NotNull]
    public int FieldFormatId { get; set; }

    [Column("display_name"), Nullable]
    public string? DisplayName { get; set; }

    [Column("is_virtual"), Nullable]
    public int? IsVirtual { get; set; }

    [Column("is_read_only"), Nullable]
    public int? IsReadOnly { get; set; }

    [Column("is_searchable"), Nullable]
    public int? IsSearchable { get; set; }

    [Column("is_required"), Nullable]
    public int? IsRequired { get; set; }

    [Column("default_group"), Nullable]
    public string? DefaultGroup { get; set; }

    [Column("is_indexed"), Nullable]
    public int? IsIndexed { get; set; }

    [Column("created_by_id"), Nullable]
    public int? CreatedById { get; set; }

    [Column("created_time"), Nullable]
    public DateTime? CreatedTime { get; set; }

    [Column("updated_by_id"), Nullable]
    public int? UpdatedById { get; set; }

    [Column("updated_time"), Nullable]
    public DateTime? UpdatedTime { get; set; }

    [Column("is_array"), Nullable]
    public int? IsArray { get; set; }

    [Column("text_search_boost_factor"), Nullable]
    public double? TextSearchBoostFactor { get; set; }

    [Column("search_field_format_id"), Nullable]
    public int? SearchFieldFormatId { get; set; }

    [Column("workspace_id"), NotNull]
    public int WorkspaceId { get; set; }

    [Column("short_name"), NotNull]
    public string ShortName { get; set; } = null!;

    [Column("is_in_list"), Nullable]
    public int? IsInList { get; set; }

    [Column("is_word_wrap_on"), Nullable]
    public int? IsWordWrapOn { get; set; }

    [Column("link_definition"), Nullable]
    public string? LinkDefinition { get; set; }

    [Column("calculation_definition"), Nullable]
    public string? CalculationDefinition { get; set; }

    [Column("tooltip"), Nullable]
    public string? Tooltip { get; set; }

    [Column("source_type"), Nullable]
    public string? SourceType { get; set; }

    [Column("indivisible_phrase"), Nullable]
    public int? IndivisiblePhrase { get; set; }
}
