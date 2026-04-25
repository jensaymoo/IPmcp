namespace IPmcp.App.Services.Entities.Models;

public record ListEntityFilter(int? Limit = 50, int? Skip = 0, string? SearchPattern = null);
