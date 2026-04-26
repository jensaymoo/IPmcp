namespace IPmcp.App.Services.Entities.Models;

public record ListEntityFilter(int? Limit, int? Skip, string? SearchPattern = null);
