using LinqToDB.Mapping;

namespace IPmcp.Database.Models;

[Table("iprule", Schema = "system")]
public class Rule
{
    [PrimaryKey, Column("rule_id"), NotNull]
    public int RuleId { get; set; }

    [Column("is_ui"), Nullable]
    public int? IsUi { get; set; }

    [Column("short_name"), Nullable]
    public string? ShortName { get; set; }

    [Column("display_name"), Nullable]
    public string? DisplayName { get; set; }

    [Column("if_condition"), Nullable]
    public string? IfCondition { get; set; }

    [Column("is_active"), Nullable]
    public int? IsActive { get; set; }

    [Column("go_script"), Nullable]
    public string? GoScript { get; set; }

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

    [Column("log"), Nullable]
    public string? Log { get; set; }

    [Column("rule_type"), Nullable]
    public string? RuleType { get; set; }

    [Column("table_name"), Nullable]
    public string? TableName { get; set; }

    [Column("title"), Nullable]
    public string? Title { get; set; }

    [Column("title_type"), Nullable]
    public string? TitleType { get; set; }

    [Column("mandatory_comments_type"), Nullable]
    public string? MandatoryCommentsType { get; set; }

    [Column("prefix"), Nullable]
    public string? Prefix { get; set; }

    [Column("is_exec_allowed"), Nullable]
    public int? IsExecAllowed { get; set; }

    [Column("ifcondition_condition_schema"), Nullable]
    public string? IfconditionConditionSchema { get; set; }

    [Column("condition_type"), Nullable]
    public string? ConditionType { get; set; }

    [Column("condition_type_date"), Nullable]
    public string? ConditionTypeDate { get; set; }

    [Column("date_value"), Nullable]
    public DateTime? DateValue { get; set; }

    [Column("field_name"), Nullable]
    public string? FieldName { get; set; }

    [Column("period_unit"), Nullable]
    public string? PeriodUnit { get; set; }

    [Column("period_value"), Nullable]
    public int? PeriodValue { get; set; }

    [Column("period_action"), Nullable]
    public string? PeriodAction { get; set; }

    [Column("date_validation_tablename"), Nullable]
    public string? DateValidationTablename { get; set; }

    [Column("validated_field_name"), Nullable]
    public string? ValidatedFieldName { get; set; }

    [Column("related_query"), Nullable]
    public string? RelatedQuery { get; set; }

    [Column("transition_name"), Nullable]
    public string? TransitionName { get; set; }
}
