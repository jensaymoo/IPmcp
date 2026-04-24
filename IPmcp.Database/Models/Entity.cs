using LinqToDB.Mapping;

namespace IPmcp.Database.Models;

[Table("ipentitytype", Schema = "system")]
public class Entity
{
    [PrimaryKey, Column("entitytype_id"), NotNull]
    public int EntityTypeId { get; set; }

    [Column("table_name"), NotNull]
    public string TableName { get; set; } = null!;

    [Column("is_abstract"), Nullable]
    public int? IsAbstract { get; set; }

    [Column("pk_field_name"), Nullable]
    public string? PkFieldName { get; set; }

    [Column("is_active"), Nullable]
    public int? IsActive { get; set; }

    [Column("is_audit_on"), Nullable]
    public int? IsAuditOn { get; set; }

    [Column("sql_table_main"), Nullable]
    public string? SqlTableMain { get; set; }

    [Column("sql_table_attr"), Nullable]
    public string? SqlTableAttr { get; set; }

    [Column("fcount_integer"), Nullable]
    public int? FcountInteger { get; set; }

    [Column("is_workflow_on"), Nullable]
    public int? IsWorkflowOn { get; set; }

    [Column("display_name"), Nullable]
    public string? DisplayName { get; set; }

    [Column("base_entitytype_id"), Nullable]
    public int? BaseEntityTypeId { get; set; }

    [Column("fcount_double"), Nullable]
    public int? FcountDouble { get; set; }

    [Column("fcount_boolean"), Nullable]
    public int? FcountBoolean { get; set; }

    [Column("fcount_string"), Nullable]
    public int? FcountString { get; set; }

    [Column("fcount_text"), Nullable]
    public int? FcountText { get; set; }

    [Column("fcount_datetime"), Nullable]
    public int? FcountDatetime { get; set; }

    [Column("fcount_date"), Nullable]
    public int? FcountDate { get; set; }

    [Column("created_by_id"), Nullable]
    public int? CreatedById { get; set; }

    [Column("created_time"), Nullable]
    public DateTime? CreatedTime { get; set; }

    [Column("updated_by_id"), Nullable]
    public int? UpdatedById { get; set; }

    [Column("updated_time"), Nullable]
    public DateTime? UpdatedTime { get; set; }

    [Column("fcount_time"), Nullable]
    public int? FcountTime { get; set; }

    [Column("is_text_search_on"), Nullable]
    public int? IsTextSearchOn { get; set; }

    [Column("workspace_id"), NotNull]
    public int WorkspaceId { get; set; }

    [Column("short_name"), NotNull]
    public string ShortName { get; set; } = null!;

    [Column("active_condition"), Nullable]
    public string? ActiveCondition { get; set; }

    [Column("ds_type"), Nullable]
    public string? DsType { get; set; }

    [Column("sql_query"), Nullable]
    public string? SqlQuery { get; set; }

    [Column("list_display_calculation"), Nullable]
    public string? ListDisplayCalculation { get; set; }

    [Column("details_display_calculation"), Nullable]
    public string? DetailsDisplayCalculation { get; set; }

    [Column("workflow_calculation_type"), Nullable]
    public string? WorkflowCalculationType { get; set; }

    [Column("default_workflow"), Nullable]
    public string? DefaultWorkflow { get; set; }

    [Column("workflow_calculation"), Nullable]
    public string? WorkflowCalculation { get; set; }

    [Column("is_individual_history"), Nullable]
    public int? IsIndividualHistory { get; set; }

    [Column("delete_strategy"), Nullable]
    public string? DeleteStrategy { get; set; }

    [Column("id_generator"), Nullable]
    public string? IdGenerator { get; set; }

    [Column("activecondition_condition_schema"), Nullable]
    public string? ActiveconditionConditionSchema { get; set; }

    [Column("fcount_bigint"), Nullable]
    public int? FcountBigint { get; set; }

    [Column("partition_field"), Nullable]
    public string? PartitionField { get; set; }

    [Column("inherits_parent_table"), Nullable]
    public int? InheritsParentTable { get; set; }
}
