using LinqToDB.Mapping;

namespace IPmcp.Database.Models;

[Table("ipentitytype_iprule", Schema = "system")]
public class EntityTypeRule
{
    [PrimaryKey, Column("relation_id"), NotNull]
    public int RelationId { get; set; }

    [Column("entitytype_id"), Nullable]
    public int? EntityTypeId { get; set; }

    [Column("rule_id"), Nullable]
    public int? RuleId { get; set; }

    [Column("sort_order"), Nullable]
    public int? SortOrder { get; set; }

    [Column("event_id"), Nullable]
    public int? EventId { get; set; }

    [Column("is_active"), Nullable]
    public int? IsActive { get; set; }

    [Column("created_by_id"), Nullable]
    public int? CreatedById { get; set; }

    [Column("created_time"), Nullable]
    public DateTime? CreatedTime { get; set; }

    [Column("updated_by_id"), Nullable]
    public int? UpdatedById { get; set; }

    [Column("updated_time"), Nullable]
    public DateTime? UpdatedTime { get; set; }

    [Column("workspace_id"), Nullable]
    public int? WorkspaceId { get; set; }

    [Column("short_name"), Nullable]
    public string? ShortName { get; set; }
}
