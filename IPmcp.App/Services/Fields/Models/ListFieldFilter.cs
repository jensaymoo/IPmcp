namespace IPmcp.App.Services.Fields.Models;

public record ListFieldFilter(int EntityTypeId, int? Limit = 50, int? Skip = 0);
