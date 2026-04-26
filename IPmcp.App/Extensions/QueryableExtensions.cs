namespace IPmcp.App.Extensions;

internal static class QueryableExtensions
{
    internal static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, int? skip, int? limit)
    {
        if (skip.HasValue)
            query = query.Skip(skip.Value);
        if (limit.HasValue)
            query = query.Take(limit.Value);
        return query;
    }
}
